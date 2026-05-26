using System;
using System.Data.OleDb;

namespace pryErpChalimond
{
    public static class clsAuditoria
    {
        public static void Registrar(string usuario, string modulo, string accion, string detalle, bool exitoso = true)
        {
            try
            {
                string sql = "INSERT INTO AuditoriaSesion (NombreUsuario, FechaHora, Exitoso, Detalle, Modulo, Accion) VALUES (?, ?, ?, ?, ?, ?)";
                OleDbParameter[] parameters = new OleDbParameter[] {
                    new OleDbParameter("?", OleDbType.VarWChar) { Value = usuario ?? "desconocido" },
                    new OleDbParameter("?", OleDbType.Date) { Value = DateTime.Now },
                    new OleDbParameter("?", OleDbType.Boolean) { Value = exitoso },
                    new OleDbParameter("?", OleDbType.VarWChar) { Value = detalle ?? "" },
                    new OleDbParameter("?", OleDbType.VarWChar) { Value = modulo ?? "" },
                    new OleDbParameter("?", OleDbType.VarWChar) { Value = accion ?? "" }
                };
                clsConexion.EjecutarConsulta(sql, parameters);
            }
            catch (Exception ex)
            {
                // Registrar en consola en caso de error para no interrumpir el flujo principal de la aplicación.
                Console.WriteLine("Error al registrar auditoría: " + ex.Message);
            }
        }
    }
}
