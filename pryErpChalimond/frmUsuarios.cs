using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace pryErpChalimond
{
    public partial class frmUsuarios : Form
    {
        private int selectedIdUsuario = -1;

        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            CargarPersonalCombo();
            CargarUsuariosGrilla();
            LimpiarEdicion();
        }

        private void CargarUsuariosGrilla()
        {
            try
            {
                // Consultar usuarios, su rol y su personal asociado
                string sql = @"
                    SELECT U.IdUsuario, U.NombreUsuario, P.NombrePerfil, 
                           IIF(PE.IdPersonal IS NULL, '(Ninguno)', PE.Apellido + ', ' + PE.Nombre) AS PersonalAsociado,
                           U.IdPerfil, U.IdPersonal
                    FROM (Usuarios U
                    INNER JOIN Perfiles P ON U.IdPerfil = P.IdPerfil)
                    LEFT JOIN Personal PE ON U.IdPersonal = PE.IdPersonal
                    ORDER BY U.NombreUsuario ASC";

                DataTable dt = clsConexion.ObtenerTabla(sql);
                dgvUsuarios.DataSource = dt;

                // Ocultar IDs e información técnica
                if (dgvUsuarios.Columns.Contains("IdUsuario")) dgvUsuarios.Columns["IdUsuario"].Visible = false;
                if (dgvUsuarios.Columns.Contains("IdPerfil")) dgvUsuarios.Columns["IdPerfil"].Visible = false;
                if (dgvUsuarios.Columns.Contains("IdPersonal")) dgvUsuarios.Columns["IdPersonal"].Visible = false;

                // Renombrar cabeceras
                if (dgvUsuarios.Columns.Contains("NombreUsuario")) dgvUsuarios.Columns["NombreUsuario"].HeaderText = "Usuario";
                if (dgvUsuarios.Columns.Contains("NombrePerfil")) dgvUsuarios.Columns["NombrePerfil"].HeaderText = "Rol";
                if (dgvUsuarios.Columns.Contains("PersonalAsociado")) dgvUsuarios.Columns["PersonalAsociado"].HeaderText = "Personal Asociado";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la grilla de usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPersonalCombo()
        {
            try
            {
                DataTable dt = clsConexion.ObtenerTabla("SELECT IdPersonal, (Apellido + ', ' + Nombre) AS NombreCompleto FROM Personal WHERE Activo = Yes ORDER BY Apellido, Nombre");
                
                // Agregar fila para opción "(Ninguno)"
                DataRow newRow = dt.NewRow();
                newRow["IdPersonal"] = -1;
                newRow["NombreCompleto"] = "(Ninguno / Desasociar)";
                dt.Rows.InsertAt(newRow, 0);

                cmbPersonalAsociar.DataSource = dt;
                cmbPersonalAsociar.DisplayMember = "NombreCompleto";
                cmbPersonalAsociar.ValueMember = "IdPersonal";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de personal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                DataGridViewRow row = dgvUsuarios.Rows[e.RowIndex];
                selectedIdUsuario = Convert.ToInt32(row.Cells["IdUsuario"].Value);
                txtUsuarioSel.Text = row.Cells["NombreUsuario"].Value.ToString();
                
                // Determinar si es Administrador (Rol "Admin")
                string rol = row.Cells["NombrePerfil"].Value.ToString();
                chkEsAdmin.Checked = rol.Equals("Admin", StringComparison.OrdinalIgnoreCase);

                // Cargar personal asociado
                object idPersonalVal = row.Cells["IdPersonal"].Value;
                if (idPersonalVal == DBNull.Value || idPersonalVal == null)
                {
                    cmbPersonalAsociar.SelectedValue = -1;
                }
                else
                {
                    cmbPersonalAsociar.SelectedValue = Convert.ToInt32(idPersonalVal);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (selectedIdUsuario == -1)
            {
                MessageBox.Show("Por favor seleccione un usuario de la lista para modificar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = txtUsuarioSel.Text;
            bool esAdmin = chkEsAdmin.Checked;
            int idPerfil = esAdmin ? 1 : 2; // 1 = Admin, 2 = Usuario

            int personalIdSelected = Convert.ToInt32(cmbPersonalAsociar.SelectedValue);
            object idPersonal = personalIdSelected == -1 ? DBNull.Value : (object)personalIdSelected;

            try
            {
                // Ejecutar actualización del usuario
                string sql = "UPDATE Usuarios SET IdPerfil = ?, IdPersonal = ? WHERE IdUsuario = ?";
                OleDbParameter[] parameters = new OleDbParameter[] {
                    new OleDbParameter("?", idPerfil),
                    idPersonal == DBNull.Value ? new OleDbParameter("?", DBNull.Value) { OleDbType = OleDbType.Integer } : new OleDbParameter("?", idPersonal),
                    new OleDbParameter("?", selectedIdUsuario)
                };

                clsConexion.EjecutarConsulta(sql, parameters);

                // Registrar auditoría de la modificación
                string perfilTexto = esAdmin ? "Admin" : "Usuario";
                string personalTexto = personalIdSelected == -1 ? "Ninguno" : cmbPersonalAsociar.Text;
                string detalle = $"Modificación de usuario '{username}' por administrador. Nuevo Rol: {perfilTexto}. Personal Asociado: {personalTexto}.";
                
                clsAuditoria.Registrar(clsSesion.Usuario, "Seguridad", "ModificarUsuario", detalle);

                MessageBox.Show("Usuario modificado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                CargarUsuariosGrilla();
                LimpiarEdicion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar cambios del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarEdicion();
        }

        private void LimpiarEdicion()
        {
            selectedIdUsuario = -1;
            txtUsuarioSel.Clear();
            chkEsAdmin.Checked = false;
            if (cmbPersonalAsociar.Items.Count > 0)
            {
                cmbPersonalAsociar.SelectedIndex = 0;
            }
            dgvUsuarios.ClearSelection();
        }
    }
}
