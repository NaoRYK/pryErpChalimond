using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace pryErpChalimond
{
    public class clsConexion
    {
        private static string dbName = "Chalimond.accdb";
        private static string connectionString;

        static clsConexion()
        {
            try
            {
                // Ubicar la base de datos en la carpeta del ensamblado de la aplicación.
                string assemblyPath = Assembly.GetExecutingAssembly().Location;
                string assemblyDir = Path.GetDirectoryName(assemblyPath);
                if (string.IsNullOrEmpty(assemblyDir))
                {
                    assemblyDir = AppDomain.CurrentDomain.BaseDirectory;
                }
                string dbPath = Path.Combine(assemblyDir, dbName);
                connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath};Persist Security Info=False;";

                // Inicializar la base de datos: crear archivo, tablas e insertar datos de prueba si no existen.
                InicializarBaseDatos(dbPath);
            }
            catch (Exception ex)
            {
                string bitness = Environment.Is64BitProcess ? "64 bits" : "32 bits";
                string errorMsg = $"Error crítico al inicializar la base de datos:\n\n" +
                                  $"Detalle del error: {ex.Message}\n\n" +
                                  $"La aplicación se está ejecutando en un proceso de {bitness}.\n\n" +
                                  $"Si el error indica que 'Microsoft.ACE.OLEDB.12.0' no está registrado en el equipo local, " +
                                  $"significa que el controlador (driver) de Access instalado en su equipo no coincide con la arquitectura del proceso ({bitness}).\n\n" +
                                  $"Por favor:\n" +
                                  $"1. Asegúrese de compilar y ejecutar el proyecto para la plataforma correcta (AnyCPU sin 'Preferir 32 bits', o x64).\n" +
                                  $"2. Si no tiene instalado el motor de base de datos de Access, instale el 'Microsoft Access Database Engine 2016' correspondiente a {bitness}.\n\n" +
                                  $"El programa podría fallar al continuar.";
                
                MessageBox.Show(errorMsg, "Error de Inicialización de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        /// <summary>
        /// Devuelve un objeto OleDbConnection abierto.
        /// </summary>
        public static OleDbConnection ObtenerConexion()
        {
            OleDbConnection conn = new OleDbConnection(connectionString);
            conn.Open();
            return conn;
        }

        /// <summary>
        /// Ejecuta una instrucción SQL que no retorna registros (INSERT, UPDATE, DELETE).
        /// </summary>
        public static int EjecutarConsulta(string sql, OleDbParameter[] parametros = null)
        {
            using (OleDbConnection conn = ObtenerConexion())
            {
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    if (parametros != null)
                    {
                        cmd.Parameters.AddRange(parametros);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Ejecuta una consulta que retorna un solo valor escalar.
        /// </summary>
        public static object EjecutarEscalar(string sql, OleDbParameter[] parametros = null)
        {
            using (OleDbConnection conn = ObtenerConexion())
            {
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    if (parametros != null)
                    {
                        cmd.Parameters.AddRange(parametros);
                    }
                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// Ejecuta una consulta y retorna un DataTable con los resultados.
        /// </summary>
        public static DataTable ObtenerTabla(string sql, OleDbParameter[] parametros = null)
        {
            using (OleDbConnection conn = ObtenerConexion())
            {
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    if (parametros != null)
                    {
                        cmd.Parameters.AddRange(parametros);
                    }
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        /// <summary>
        /// Crea el archivo de base de datos y su estructura de tablas si no existen.
        /// </summary>
        private static void InicializarBaseDatos(string dbPath)
        {
            // 1. Crear el archivo físico de Access (.accdb) si no existe.
            if (!File.Exists(dbPath))
            {
                try
                {
                    Type catType = Type.GetTypeFromProgID("ADOX.Catalog");
                    if (catType != null)
                    {
                        object catalog = Activator.CreateInstance(catType);
                        string adoxConnString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath};";
                        catType.InvokeMember("Create", BindingFlags.InvokeMethod, null, catalog, new object[] { adoxConnString });
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(catalog);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al crear la base de datos mediante ADOX: " + ex.Message);
                    // Si falla, intentaremos ver si podemos copiarla de la carpeta raíz del proyecto.
                    string rootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", dbName);
                    if (File.Exists(rootPath))
                    {
                        File.Copy(rootPath, dbPath);
                    }
                    else
                    {
                        throw new Exception("No se pudo crear ni ubicar el archivo de base de datos Chalimond.accdb.", ex);
                    }
                }
            }

            // 2. Crear las tablas necesarias.
            using (OleDbConnection conn = ObtenerConexion())
            {
                // Crear tabla Perfiles
                if (!ExisteTabla(conn, "Perfiles"))
                {
                    string sql = @"CREATE TABLE Perfiles (
                        IdPerfil COUNTER PRIMARY KEY,
                        NombrePerfil VARCHAR(50) NOT NULL UNIQUE
                    )";
                    EjecutarComando(conn, sql);
                }

                // Crear tabla Provincias
                if (!ExisteTabla(conn, "Provincias"))
                {
                    string sql = @"CREATE TABLE Provincias (
                        IdProvincia COUNTER PRIMARY KEY,
                        NombreProvincia VARCHAR(100) NOT NULL UNIQUE
                    )";
                    EjecutarComando(conn, sql);
                }

                // Crear tabla Localidades
                if (!ExisteTabla(conn, "Localidades"))
                {
                    string sql = @"CREATE TABLE Localidades (
                        IdLocalidad COUNTER PRIMARY KEY,
                        NombreLocalidad VARCHAR(100) NOT NULL,
                        IdProvincia INT NOT NULL
                    )";
                    EjecutarComando(conn, sql);
                }

                // Crear tabla Personal
                if (!ExisteTabla(conn, "Personal"))
                {
                    string sql = @"CREATE TABLE Personal (
                        IdPersonal COUNTER PRIMARY KEY,
                        DNI VARCHAR(20) NOT NULL UNIQUE,
                        Apellido VARCHAR(100) NOT NULL,
                        Nombre VARCHAR(100) NOT NULL,
                        Direccion VARCHAR(200) NOT NULL,
                        Latitud DOUBLE,
                        Longitud DOUBLE,
                        UbicacionGeografica VARCHAR(255),
                        IdProvincia INT NOT NULL,
                        IdLocalidad INT,
                        Activo YESNO DEFAULT YES
                    )";
                    EjecutarComando(conn, sql);
                }
                else
                {
                    // Si la tabla ya existe, asegurarse de que tenga la columna UbicacionGeografica
                    if (!ExisteColumna(conn, "Personal", "UbicacionGeografica"))
                    {
                        try
                        {
                            EjecutarComando(conn, "ALTER TABLE Personal ADD COLUMN UbicacionGeografica VARCHAR(255)");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al agregar columna UbicacionGeografica a Personal: " + ex.Message);
                        }
                    }

                    // Asegurarse de que IdLocalidad permita valores nulos (alterando la columna)
                    try
                    {
                        EjecutarComando(conn, "ALTER TABLE Personal ALTER COLUMN IdLocalidad INT NULL");
                    }
                    catch
                    {
                        try
                        {
                            EjecutarComando(conn, "ALTER TABLE Personal ALTER COLUMN IdLocalidad INT");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al hacer nullable la columna IdLocalidad: " + ex.Message);
                        }
                    }
                }

                // Crear tabla PersonalContactos
                if (!ExisteTabla(conn, "PersonalContactos"))
                {
                    string sql = @"CREATE TABLE PersonalContactos (
                        IdContacto COUNTER PRIMARY KEY,
                        IdPersonal INT NOT NULL,
                        Tipo VARCHAR(50) NOT NULL,
                        Valor VARCHAR(200) NOT NULL
                    )";
                    EjecutarComando(conn, sql);
                }

                // Crear tabla Usuarios
                if (!ExisteTabla(conn, "Usuarios"))
                {
                    string sql = @"CREATE TABLE Usuarios (
                        IdUsuario COUNTER PRIMARY KEY,
                        NombreUsuario VARCHAR(50) NOT NULL UNIQUE,
                        Contrasena VARCHAR(100) NOT NULL,
                        IdPerfil INT NOT NULL,
                        IdPersonal INT,
                        IntentosFallidos INT DEFAULT 0,
                        LoginCount INT DEFAULT 0
                    )";
                    EjecutarComando(conn, sql);
                }

                // Crear tabla AuditoriaSesion
                if (!ExisteTabla(conn, "AuditoriaSesion"))
                {
                    string sql = @"CREATE TABLE AuditoriaSesion (
                        IdAuditoria COUNTER PRIMARY KEY,
                        NombreUsuario VARCHAR(50) NOT NULL,
                        FechaHora DATETIME NOT NULL,
                        Exitoso YESNO NOT NULL,
                        Detalle VARCHAR(255) NOT NULL,
                        Modulo VARCHAR(50),
                        Accion VARCHAR(50)
                    )";
                    EjecutarComando(conn, sql);
                }
                else
                {
                    // Asegurarse de que existan las columnas Modulo y Accion para escalabilidad
                    if (!ExisteColumna(conn, "AuditoriaSesion", "Modulo"))
                    {
                        try
                        {
                            EjecutarComando(conn, "ALTER TABLE AuditoriaSesion ADD COLUMN Modulo VARCHAR(50)");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al agregar columna Modulo: " + ex.Message);
                        }
                    }
                    if (!ExisteColumna(conn, "AuditoriaSesion", "Accion"))
                    {
                        try
                        {
                            EjecutarComando(conn, "ALTER TABLE AuditoriaSesion ADD COLUMN Accion VARCHAR(50)");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al agregar columna Accion: " + ex.Message);
                        }
                    }
                }

                // 3. Semillar datos de configuración base.
                SemillarDatos(conn);
            }
        }

        private static bool ExisteTabla(OleDbConnection conn, string nombreTabla)
        {
            DataTable dt = conn.GetSchema("Tables", new string[] { null, null, nombreTabla, "TABLE" });
            return dt.Rows.Count > 0;
        }

        private static bool ExisteColumna(OleDbConnection conn, string nombreTabla, string nombreColumna)
        {
            DataTable dt = conn.GetSchema("Columns", new string[] { null, null, nombreTabla, nombreColumna });
            return dt.Rows.Count > 0;
        }

        private static void EjecutarComando(OleDbConnection conn, string sql)
        {
            using (OleDbCommand cmd = new OleDbCommand(sql, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }

        private static void SemillarDatos(OleDbConnection conn)
        {
            // 1. Semillar Perfiles
            long cantPerfiles = ObtenerConteo(conn, "SELECT COUNT(*) FROM Perfiles");
            if (cantPerfiles == 0)
            {
                EjecutarComando(conn, "INSERT INTO Perfiles (NombrePerfil) VALUES ('Admin')");
                EjecutarComando(conn, "INSERT INTO Perfiles (NombrePerfil) VALUES ('Usuario')");
            }

            // 2. Semillar Provincias
            long cantProvincias = ObtenerConteo(conn, "SELECT COUNT(*) FROM Provincias");
            if (cantProvincias == 0)
            {
                EjecutarComando(conn, "INSERT INTO Provincias (NombreProvincia) VALUES ('Córdoba')");
                EjecutarComando(conn, "INSERT INTO Provincias (NombreProvincia) VALUES ('Buenos Aires')");
                EjecutarComando(conn, "INSERT INTO Provincias (NombreProvincia) VALUES ('Santa Fe')");
                EjecutarComando(conn, "INSERT INTO Provincias (NombreProvincia) VALUES ('Mendoza')");
                EjecutarComando(conn, "INSERT INTO Provincias (NombreProvincia) VALUES ('Tucumán')");
                EjecutarComando(conn, "INSERT INTO Provincias (NombreProvincia) VALUES ('Entre Ríos')");
                EjecutarComando(conn, "INSERT INTO Provincias (NombreProvincia) VALUES ('Salta')");
                EjecutarComando(conn, "INSERT INTO Provincias (NombreProvincia) VALUES ('Chaco')");
            }

            // Obtener el ID de la provincia de Córdoba para semillar sus localidades
            object idCbaObj = null;
            using (OleDbCommand cmd = new OleDbCommand("SELECT IdProvincia FROM Provincias WHERE NombreProvincia = 'Córdoba'", conn))
            {
                idCbaObj = cmd.ExecuteScalar();
            }

            if (idCbaObj != null)
            {
                int idCordoba = Convert.ToInt32(idCbaObj);

                // 3. Semillar Localidades de Córdoba
                long cantLocalidades = ObtenerConteo(conn, "SELECT COUNT(*) FROM Localidades");
                if (cantLocalidades == 0)
                {
                    string[] localidadesCordoba = new string[] {
                        "Córdoba Capital", "Villa Carlos Paz", "Río Cuarto", "Villa María", 
                        "Alta Gracia", "San Francisco", "Bell Ville", "Río Tercero", 
                        "La Falda", "Jesús María", "Cosquín", "Villa General Belgrano",
                        "Cruz del Eje", "Marcos Juárez", "Arroyito", "Laboulaye"
                    };

                    foreach (string loc in localidadesCordoba)
                    {
                        using (OleDbCommand cmd = new OleDbCommand("INSERT INTO Localidades (NombreLocalidad, IdProvincia) VALUES (?, ?)", conn))
                        {
                            cmd.Parameters.AddWithValue("?", loc);
                            cmd.Parameters.AddWithValue("?", idCordoba);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }

            // 4. Semillar Usuario Admin Inicial (contraseña "admin")
            long cantAdmin = ObtenerConteo(conn, "SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = 'admin'");
            if (cantAdmin == 0)
            {
                // Obtener ID del perfil Admin
                int idPerfilAdmin = 1; // Por defecto
                using (OleDbCommand cmd = new OleDbCommand("SELECT IdPerfil FROM Perfiles WHERE NombrePerfil = 'Admin'", conn))
                {
                    object id = cmd.ExecuteScalar();
                    if (id != null) idPerfilAdmin = Convert.ToInt32(id);
                }

                using (OleDbCommand cmd = new OleDbCommand("INSERT INTO Usuarios (NombreUsuario, Contrasena, IdPerfil, IntentosFallidos, LoginCount) VALUES (?, ?, ?, 0, 0)", conn))
                {
                    cmd.Parameters.AddWithValue("?", "admin");
                    cmd.Parameters.AddWithValue("?", "admin");
                    cmd.Parameters.AddWithValue("?", idPerfilAdmin);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static long ObtenerConteo(OleDbConnection conn, string query)
        {
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                return Convert.ToInt64(cmd.ExecuteScalar());
            }
        }
    }
}
