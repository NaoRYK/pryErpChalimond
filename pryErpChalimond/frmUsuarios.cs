using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace pryErpChalimond
{
    public partial class frmUsuarios : Form
    {
        private int selectedIdUsuario = -1;
        private bool isNewMode = false;
        private int preselectedPersonalId = -1;

        public frmUsuarios()
        {
            InitializeComponent();
        }

        public frmUsuarios(int idPersonal) : this()
        {
            this.preselectedPersonalId = idPersonal;
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            CargarPersonalCombo();
            CargarPerfilesCombo();
            CargarUsuariosGrilla();
            EstilizarControles();
            LimpiarEdicion();

            if (preselectedPersonalId != -1)
            {
                IniciarModoNuevoConPersonal(preselectedPersonalId);
            }
        }

        private void IniciarModoNuevoConPersonal(int idPersonal)
        {
            btnNuevo_Click(null, null);
            cmbPersonalAsociar.SelectedValue = idPersonal;
        }

        private void CargarUsuariosGrilla()
        {
            try
            {
                // Consultar usuarios, su rol y su personal asociado
                string sql = @"
                     SELECT U.IdUsuario, U.NombreUsuario, P.NombrePerfil, 
                            IIF(PE.IdPersonal IS NULL, '(Ninguno)', PE.Apellido + ', ' + PE.Nombre) AS PersonalAsociado,
                            U.IdPerfil, U.IdPersonal, U.Activo AS Activo
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
                if (dgvUsuarios.Columns.Contains("Activo")) dgvUsuarios.Columns["Activo"].HeaderText = "Activo";
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

        private void CargarPerfilesCombo()
        {
            try
            {
                DataTable dt = clsConexion.ObtenerTabla("SELECT IdPerfil, NombrePerfil FROM Perfiles ORDER BY IdPerfil");
                cmbPerfil.DataSource = dt;
                cmbPerfil.DisplayMember = "NombrePerfil";
                cmbPerfil.ValueMember = "IdPerfil";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de perfiles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarEstadoControles(bool editando, bool nuevo)
        {
            bool activo = editando || nuevo;
            
            txtUsuarioSel.ReadOnly = editando || !activo;
            txtContrasena.Enabled = activo;
            cmbPerfil.Enabled = activo;
            cmbPersonalAsociar.Enabled = activo;
            
            if (txtUsuarioSel.Text.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                chkActivo.Enabled = false;
            }
            else
            {
                chkActivo.Enabled = activo;
            }
            
            btnGuardar.Enabled = activo;
            btnLimpiar.Enabled = true; // Cancelar/Limpiar está siempre disponible para vaciar o salir de un modo
            
            if (nuevo)
            {
                lblTituloEditar.Text = "Crear Nuevo Usuario";
                btnGuardar.Text = "Crear Usuario";
                btnGuardar.BackColor = System.Drawing.Color.FromArgb(16, 185, 129); // Emerald-500
                btnLimpiar.Text = "Cancelar";
            }
            else if (editando)
            {
                lblTituloEditar.Text = "Modificar Usuario";
                btnGuardar.Text = "Guardar Cambios";
                btnGuardar.BackColor = System.Drawing.Color.FromArgb(79, 70, 229); // Indigo-600
                btnLimpiar.Text = "Cancelar";
            }
            else
            {
                lblTituloEditar.Text = "Seleccione un usuario";
                btnGuardar.Text = "Guardar Cambios";
                btnGuardar.BackColor = System.Drawing.Color.FromArgb(71, 85, 105); // Slate-500
                btnLimpiar.Text = "Limpiar";
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                isNewMode = false;
                txtContrasena.Clear(); // Vacío en edición por defecto

                DataGridViewRow row = dgvUsuarios.Rows[e.RowIndex];
                selectedIdUsuario = Convert.ToInt32(row.Cells["IdUsuario"].Value);
                txtUsuarioSel.Text = row.Cells["NombreUsuario"].Value.ToString();
                
                // Cargar perfil seleccionado
                object idPerfilVal = row.Cells["IdPerfil"].Value;
                if (idPerfilVal != DBNull.Value && idPerfilVal != null)
                {
                    cmbPerfil.SelectedValue = Convert.ToInt32(idPerfilVal);
                }

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

                // Cargar estado activo del usuario
                object activoVal = row.Cells["Activo"].Value;
                chkActivo.Checked = activoVal != DBNull.Value && Convert.ToBoolean(activoVal);

                ConfigurarEstadoControles(true, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string username = txtUsuarioSel.Text.Trim();
            int idPerfil = Convert.ToInt32(cmbPerfil.SelectedValue);

            int personalIdSelected = Convert.ToInt32(cmbPersonalAsociar.SelectedValue);
            object idPersonal = personalIdSelected == -1 ? DBNull.Value : (object)personalIdSelected;

            if (isNewMode)
            {
                // Crear Usuario
                if (string.IsNullOrEmpty(username))
                {
                    MessageBox.Show("El nombre de usuario es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsuarioSel.Focus();
                    return;
                }

                string password = txtContrasena.Text;
                if (string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("La contraseña es obligatoria para un usuario nuevo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContrasena.Focus();
                    return;
                }

                try
                {
                    // 1. Validar que el usuario no exista
                    string sqlCheckUser = "SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = ?";
                    long countUser = Convert.ToInt64(clsConexion.EjecutarEscalar(sqlCheckUser, new OleDbParameter[] { new OleDbParameter("?", username) }));
                    if (countUser > 0)
                    {
                        MessageBox.Show("El nombre de usuario ya está registrado.", "Usuario Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtUsuarioSel.Focus();
                        return;
                    }

                    // 2. Validar que el personal no tenga ya un usuario asignado (si no es nulo)
                    if (personalIdSelected != -1)
                    {
                        string sqlCheckPersonal = "SELECT COUNT(*) FROM Usuarios WHERE IdPersonal = ?";
                        long countPersonal = Convert.ToInt64(clsConexion.EjecutarEscalar(sqlCheckPersonal, new OleDbParameter[] { new OleDbParameter("?", personalIdSelected) }));
                        if (countPersonal > 0)
                        {
                            MessageBox.Show("El empleado seleccionado ya posee una cuenta de usuario asignada.", "Personal Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbPersonalAsociar.Focus();
                            return;
                        }
                    }

                    // 3. Insertar nuevo usuario
                    string sqlInsert = "INSERT INTO Usuarios (NombreUsuario, Contrasena, IdPerfil, IdPersonal, IntentosFallidos, LoginCount, Activo) VALUES (?, ?, ?, ?, 0, 0, ?)";
                    OleDbParameter[] parameters = new OleDbParameter[] {
                        new OleDbParameter("?", username),
                        new OleDbParameter("?", password),
                        new OleDbParameter("?", idPerfil),
                        idPersonal == DBNull.Value ? new OleDbParameter("?", DBNull.Value) { OleDbType = OleDbType.Integer } : new OleDbParameter("?", idPersonal),
                        new OleDbParameter("?", chkActivo.Checked)
                    };

                    clsConexion.EjecutarConsulta(sqlInsert, parameters);

                    // Registrar auditoría de la creación
                    string perfilTexto = cmbPerfil.Text;
                    string personalTexto = personalIdSelected == -1 ? "Ninguno" : cmbPersonalAsociar.Text;
                    string detalle = $"Creación de usuario '{username}' por administrador. Rol: {perfilTexto}. Personal Asociado: {personalTexto}.";
                    clsAuditoria.Registrar(clsSesion.Usuario, "Seguridad", "CrearUsuario", detalle);

                    MessageBox.Show("Usuario creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    CargarUsuariosGrilla();
                    LimpiarEdicion();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Modificar Usuario
                if (selectedIdUsuario == -1)
                {
                    MessageBox.Show("Por favor seleccione un usuario de la lista para modificar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Impedir la deactivación de la cuenta administrador principal 'admin'
                if (username.Equals("admin", StringComparison.OrdinalIgnoreCase) && !chkActivo.Checked)
                {
                    MessageBox.Show("La cuenta principal 'admin' no puede ser desactivada para evitar el bloqueo del sistema.", "Operación Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    // Validar duplicado de personal (excluyendo el usuario actual)
                    if (personalIdSelected != -1)
                    {
                        string sqlCheckPersonal = "SELECT COUNT(*) FROM Usuarios WHERE IdPersonal = ? AND IdUsuario <> ?";
                        long countPersonal = Convert.ToInt64(clsConexion.EjecutarEscalar(sqlCheckPersonal, new OleDbParameter[] {
                            new OleDbParameter("?", personalIdSelected),
                            new OleDbParameter("?", selectedIdUsuario)
                        }));
                        if (countPersonal > 0)
                        {
                            MessageBox.Show("El empleado seleccionado ya posee otra cuenta de usuario asignada.", "Personal Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbPersonalAsociar.Focus();
                            return;
                        }
                    }

                    string password = txtContrasena.Text;
                    string sql;
                    OleDbParameter[] parameters;

                    if (!string.IsNullOrEmpty(password))
                    {
                        sql = "UPDATE Usuarios SET IdPerfil = ?, IdPersonal = ?, Contrasena = ?, Activo = ? WHERE IdUsuario = ?";
                        parameters = new OleDbParameter[] {
                            new OleDbParameter("?", idPerfil),
                            idPersonal == DBNull.Value ? new OleDbParameter("?", DBNull.Value) { OleDbType = OleDbType.Integer } : new OleDbParameter("?", idPersonal),
                            new OleDbParameter("?", password),
                            new OleDbParameter("?", chkActivo.Checked),
                            new OleDbParameter("?", selectedIdUsuario)
                        };
                    }
                    else
                    {
                        sql = "UPDATE Usuarios SET IdPerfil = ?, IdPersonal = ?, Activo = ? WHERE IdUsuario = ?";
                        parameters = new OleDbParameter[] {
                            new OleDbParameter("?", idPerfil),
                            idPersonal == DBNull.Value ? new OleDbParameter("?", DBNull.Value) { OleDbType = OleDbType.Integer } : new OleDbParameter("?", idPersonal),
                            new OleDbParameter("?", chkActivo.Checked),
                            new OleDbParameter("?", selectedIdUsuario)
                        };
                    }

                    clsConexion.EjecutarConsulta(sql, parameters);

                    // Registrar auditoría de la modificación
                    string perfilTexto = cmbPerfil.Text;
                    string personalTexto = personalIdSelected == -1 ? "Ninguno" : cmbPersonalAsociar.Text;
                    string cambioClave = !string.IsNullOrEmpty(password) ? " (Se actualizó la contraseña)" : "";
                    string estadoActivo = chkActivo.Checked ? "Activa" : "Inactiva";
                    string detalle = $"Modificación de usuario '{username}' por administrador. Nuevo Rol: {perfilTexto}. Personal Asociado: {personalTexto}. Cuenta: {estadoActivo}.{cambioClave}";
                    
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
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarEdicion();
        }

        private void LimpiarEdicion()
        {
            selectedIdUsuario = -1;
            isNewMode = false;
            txtUsuarioSel.Clear();
            txtContrasena.Clear();
            if (cmbPerfil.Items.Count > 0)
            {
                cmbPerfil.SelectedIndex = 0;
                foreach (DataRowView item in cmbPerfil.Items)
                {
                    if (item["NombrePerfil"].ToString().Equals("Usuario", StringComparison.OrdinalIgnoreCase))
                    {
                        cmbPerfil.SelectedValue = item["IdPerfil"];
                        break;
                    }
                }
            }
            chkActivo.Checked = true; // Activo por defecto
            if (cmbPersonalAsociar.Items.Count > 0)
            {
                cmbPersonalAsociar.SelectedIndex = 0;
            }
            dgvUsuarios.ClearSelection();
            ConfigurarEstadoControles(false, false);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            selectedIdUsuario = -1;
            isNewMode = true;
            txtUsuarioSel.Clear();
            txtContrasena.Clear();
            if (cmbPerfil.Items.Count > 0)
            {
                cmbPerfil.SelectedIndex = 0;
                foreach (DataRowView item in cmbPerfil.Items)
                {
                    if (item["NombrePerfil"].ToString().Equals("Usuario", StringComparison.OrdinalIgnoreCase))
                    {
                        cmbPerfil.SelectedValue = item["IdPerfil"];
                        break;
                    }
                }
            }
            chkActivo.Checked = true; // Activo por defecto
            dgvUsuarios.ClearSelection();
            if (cmbPersonalAsociar.Items.Count > 0)
            {
                cmbPersonalAsociar.SelectedIndex = 0;
            }
            ConfigurarEstadoControles(false, true);
            txtUsuarioSel.Focus();
        }

        // Alterna entre mostrar y ocultar el texto de la contraseña
        private void btnToggleContrasena_Click(object sender, EventArgs e)
        {
            // Invertir el modo de asteriscos
            txtContrasena.UseSystemPasswordChar = !txtContrasena.UseSystemPasswordChar;
            // Cambiar el ícono del botón según el estado actual
            btnToggleContrasena.Text = txtContrasena.UseSystemPasswordChar ? "👁" : "🙈";
        }

        private void cmbPersonalAsociar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isNewMode) return;
            if (cmbPersonalAsociar.SelectedValue == null) return;

            try
            {
                int idPersonal = Convert.ToInt32(cmbPersonalAsociar.SelectedValue);
                if (idPersonal == -1)
                {
                    txtUsuarioSel.Clear();
                    txtContrasena.Clear();
                    return;
                }

                string sql = "SELECT DNI, Nombre, Apellido FROM Personal WHERE IdPersonal = ?";
                DataTable dt = clsConexion.ObtenerTabla(sql, new OleDbParameter[] { new OleDbParameter("?", idPersonal) });

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    string dni = row["DNI"].ToString().Trim().Replace(".", "");
                    string nombre = row["Nombre"].ToString().Trim();
                    string apellido = row["Apellido"].ToString().Trim();

                    // Generar sugerencia de usuario: nombre.apellido (en minúsculas y sin acentos ni espacios)
                    string sugerenciaUsuario = $"{nombre}.{apellido}".ToLower()
                        .Replace(" ", "")
                        .Replace("á", "a")
                        .Replace("é", "e")
                        .Replace("í", "i")
                        .Replace("ó", "o")
                        .Replace("ú", "u")
                        .Replace("ñ", "n");
                    txtUsuarioSel.Text = sugerenciaUsuario;
                    txtContrasena.Text = dni; // Contraseña por defecto es el DNI
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al auto-completar datos: " + ex.Message);
            }
        }

        private void EstilizarControles()
        {
            var fontLabel = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            var fontInput = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            var fontTitulo = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);

            lblTitulo.Font = fontTitulo;
            lblTitulo.ForeColor = System.Drawing.Color.FromArgb(248, 250, 252);

            lblTituloEditar.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            lblTituloEditar.ForeColor = System.Drawing.Color.FromArgb(241, 245, 249);

            foreach (Control c in pnlEditar.Controls)
            {
                if (c is Label lbl)
                {
                    if (lbl != lblTituloEditar)
                    {
                        lbl.Font = fontLabel;
                        lbl.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
                    }
                }
                else if (c is TextBox txt)
                {
                    txt.Font = fontInput;
                    txt.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
                    txt.ForeColor = System.Drawing.Color.White;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (c is ComboBox cmb)
                {
                    cmb.Font = fontInput;
                    cmb.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
                    cmb.ForeColor = System.Drawing.Color.White;
                    cmb.FlatStyle = FlatStyle.Flat;
                }
            }

            EstilizarBoton(btnGuardar, System.Drawing.Color.FromArgb(79, 70, 229));
            EstilizarBoton(btnLimpiar, System.Drawing.Color.FromArgb(71, 85, 105));
            EstilizarBoton(btnNuevo, System.Drawing.Color.FromArgb(16, 185, 129));

            EstilizarGrilla(dgvUsuarios);
        }

        private void EstilizarBoton(Button btn, System.Drawing.Color baseColor)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btn.ForeColor = System.Drawing.Color.White;
            btn.BackColor = baseColor;
            btn.Cursor = Cursors.Hand;

            btn.MouseEnter += (s, e) => {
                if (btn.Enabled)
                {
                    btn.BackColor = AclararColor(btn.BackColor, 20);
                }
            };
            btn.MouseLeave += (s, e) => {
                if (btn == btnGuardar)
                {
                    if (!btn.Enabled)
                    {
                        btn.BackColor = System.Drawing.Color.FromArgb(71, 85, 105);
                    }
                    else
                    {
                        btn.BackColor = isNewMode ? System.Drawing.Color.FromArgb(16, 185, 129) : System.Drawing.Color.FromArgb(79, 70, 229);
                    }
                }
                else
                {
                    btn.BackColor = btn.Enabled ? baseColor : System.Drawing.Color.FromArgb(71, 85, 105);
                }
            };
        }

        private void EstilizarGrilla(DataGridView dgv)
        {
            dgv.BackgroundColor = System.Drawing.Color.FromArgb(15, 23, 42);
            dgv.GridColor = System.Drawing.Color.FromArgb(30, 41, 59);
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(241, 245, 249);
            dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            dgv.ColumnHeadersHeight = 38;

            dgv.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            dgv.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);
            dgv.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            dgv.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(79, 70, 229);
            dgv.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            dgv.RowTemplate.Height = 36;
        }

        private System.Drawing.Color AclararColor(System.Drawing.Color color, int val)
        {
            int r = Math.Min(color.R + val, 255);
            int g = Math.Min(color.G + val, 255);
            int b = Math.Min(color.B + val, 255);
            return System.Drawing.Color.FromArgb(r, g, b);
        }
    }
}
