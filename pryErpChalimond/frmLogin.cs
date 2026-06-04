using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace pryErpChalimond
{
    public partial class frmLogin : Form
    {
        private int intentosRestantes = 3;

        public frmLogin()
        {
            InitializeComponent();
            lblError.Text = "";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                lblError.Text = "Por favor ingrese usuario y contraseña.";
                return;
            }

            try
            {
                // Buscar el usuario y obtener su contraseña, perfil, estado de personal y contadores
                string sql = @"
                    SELECT U.IdUsuario, U.Contrasena, U.IntentosFallidos, U.LoginCount, P.NombrePerfil, PE.Activo AS PersonalActivo, U.IdPersonal, U.Activo AS UsuarioActivo
                    FROM (Usuarios U
                    INNER JOIN Perfiles P ON U.IdPerfil = P.IdPerfil)
                    LEFT JOIN Personal PE ON U.IdPersonal = PE.IdPersonal
                    WHERE U.NombreUsuario = ?";

                OleDbParameter[] parameters = new OleDbParameter[] {
                    new OleDbParameter("?", usuario)
                };

                DataTable dt = clsConexion.ObtenerTabla(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    string dbContrasena = row["Contrasena"].ToString();
                    string perfil = row["NombrePerfil"].ToString();
                    int idUsuario = Convert.ToInt32(row["IdUsuario"]);
                    int loginCount = Convert.ToInt32(row["LoginCount"]);
                    
                    // Verificar si la cuenta de usuario está activa
                    bool esUsuarioActivo = true;
                    if (dt.Columns.Contains("UsuarioActivo") && row["UsuarioActivo"] != DBNull.Value)
                    {
                        esUsuarioActivo = Convert.ToBoolean(row["UsuarioActivo"]);
                    }

                    if (!esUsuarioActivo)
                    {
                        RegistrarAuditoria(usuario, false, "Intento de inicio de sesión con cuenta desactivada.");
                        lblError.Text = "Acceso denegado: Esta cuenta de usuario está desactivada.";
                        return;
                    }

                    // Verificar si tiene personal asociado y si este está inactivo
                    object activoObj = row["PersonalActivo"];
                    bool tienePersonal = row["IdPersonal"] != DBNull.Value;
                    bool esPersonalActivo = true;
                    if (tienePersonal && activoObj != DBNull.Value)
                    {
                        esPersonalActivo = Convert.ToBoolean(activoObj);
                    }

                    // Si el personal asociado está inactivo, denegar el acceso inmediatamente sin verificar la contraseña
                    if (tienePersonal && !esPersonalActivo)
                    {
                        RegistrarAuditoria(usuario, false, "Intento de inicio de sesión con personal inactivo.");
                        lblError.Text = "Acceso denegado: El personal asociado está inactivo.";
                        return;
                    }

                    if (dbContrasena == contrasena)
                    {
                        // Inicializar variables globales de sesión
                        clsSesion.Usuario = usuario;
                        clsSesion.Rol = perfil;

                        // Login correcto: reiniciar intentos fallidos, incrementar contador de logins, registrar auditoría
                        string sqlUpdate = "UPDATE Usuarios SET IntentosFallidos = 0, LoginCount = LoginCount + 1 WHERE IdUsuario = ?";
                        clsConexion.EjecutarConsulta(sqlUpdate, new OleDbParameter[] { new OleDbParameter("?", idUsuario) });

                        RegistrarAuditoria(usuario, true, "Inicio de sesión correcto.");

                        // Abrir FormMain
                        string horaConexion = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        frmMain mainForm = new frmMain(usuario, perfil, horaConexion);
                        this.Hide();
                        DialogResult mainResult = mainForm.ShowDialog();

                        if (mainResult == DialogResult.Yes || mainResult == DialogResult.OK)
                        {
                            // Resetear campos de login y mostrar formulario de login nuevamente
                            txtUsuario.Text = "";
                            txtContrasena.Text = "";
                            lblError.Text = "";
                            intentosRestantes = 3;
                            this.Show();
                            txtUsuario.Focus();
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        // Contraseña incorrecta
                        int intentosFallidosDB = Convert.ToInt32(row["IntentosFallidos"]) + 1;
                        string sqlUpdate = "UPDATE Usuarios SET IntentosFallidos = ? WHERE IdUsuario = ?";
                        clsConexion.EjecutarConsulta(sqlUpdate, new OleDbParameter[] {
                            new OleDbParameter("?", intentosFallidosDB),
                            new OleDbParameter("?", idUsuario)
                        });

                        RegistrarAuditoria(usuario, false, $"Contraseña incorrecta. Intento fallido #{intentosFallidosDB}");
                        ProcesarFalloLogin();
                    }
                }
                else
                {
                    // Usuario no existe
                    RegistrarAuditoria(usuario, false, "Usuario inexistente.");
                    ProcesarFalloLogin();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProcesarFalloLogin()
        {
            intentosRestantes--;
            if (intentosRestantes <= 0)
            {
                MessageBox.Show("Se han agotado los 3 intentos permitidos. El programa se cerrará.", "Acceso Bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
            }
            else
            {
                lblError.Text = $"Credenciales incorrectas. Intentos restantes: {intentosRestantes}";
            }
        }

        private void RegistrarAuditoria(string usuario, bool exitoso, string detalle)
        {
            clsAuditoria.Registrar(usuario, "Seguridad", "Login", detalle, exitoso);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            pnlUserUnderline.BackColor = Color.FromArgb(129, 140, 248);
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            pnlUserUnderline.BackColor = Color.FromArgb(71, 85, 105);
        }

        private void txtContrasena_Enter(object sender, EventArgs e)
        {
            pnlPasswordUnderline.BackColor = Color.FromArgb(129, 140, 248);
        }

        private void txtContrasena_Leave(object sender, EventArgs e)
        {
            pnlPasswordUnderline.BackColor = Color.FromArgb(71, 85, 105);
        }

        private void pnlBackground_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
