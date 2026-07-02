using System;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Windows.Forms;

namespace pryErpChalimond
{
    public partial class frmPersonal : Form
    {
        private int selectedIdPersonal = -1;
        private bool isUpdatingUI = false;
        private Label lblContactosAviso;
        private bool isEditMode = false;

        public frmPersonal()
        {
            InitializeComponent();
        }

        private void frmPersonal_Load(object sender, EventArgs e)
        {
            // Maximizar la ventana principal automáticamente al abrir este módulo
            frmMain mainForm = Application.OpenForms["frmMain"] as frmMain;
            if (mainForm != null)
                mainForm.WindowState = FormWindowState.Maximized;

            CargarProvincias();
            CargarGrillaPersonal();
            CargarTiposContacto();

            // Configurar aviso dinámico para contactos
            lblContactosAviso = new Label();
            lblContactosAviso.Text = "⚠️ Seleccione un empleado en la lista izquierda para poder gestionar sus contactos y redes sociales.";
            lblContactosAviso.ForeColor = System.Drawing.Color.FromArgb(248, 113, 113); // Light Red / Salmon
            lblContactosAviso.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblContactosAviso.AutoSize = false;
            lblContactosAviso.Size = new System.Drawing.Size(502, 100);
            lblContactosAviso.Location = new System.Drawing.Point(20, 100);
            lblContactosAviso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblContactosAviso.Visible = false;
            pnlContactoContainer.Controls.Add(lblContactosAviso);

            EstilizarControles();
            LimpiarFormulario();
            SetTab(true);

            // Interceptar eventos de ComboBoxes para simular ReadOnly
            cmbProvincia.KeyDown += PreventComboBoxUsage;
            cmbProvincia.KeyPress += PreventComboBoxUsageKey;
            cmbProvincia.DropDown += PreventComboBoxUsageClick;

            cmbLocalidad.KeyDown += PreventComboBoxUsage;
            cmbLocalidad.KeyPress += PreventComboBoxUsageKey;
            cmbLocalidad.DropDown += PreventComboBoxUsageClick;

            cmbTipo.KeyDown += PreventComboBoxUsage;
            cmbTipo.KeyPress += PreventComboBoxUsageKey;
            cmbTipo.DropDown += PreventComboBoxUsageClick;

            // Ocultar gestión de usuario para roles no administradores
            if (!clsSesion.Rol.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                btnGestionarUsuario.Visible = false;
            }
        }

        private void CargarProvincias()
        {
            try
            {
                DataTable dt = clsConexion.ObtenerTabla("SELECT IdProvincia, NombreProvincia FROM Provincias ORDER BY NombreProvincia ASC");
                cmbProvincia.DataSource = dt;
                cmbProvincia.DisplayMember = "NombreProvincia";
                cmbProvincia.ValueMember = "IdProvincia";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar provincias: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProvincia.SelectedValue == null || !(cmbProvincia.SelectedValue is int))
            {
                cmbLocalidad.DataSource = null;
                cmbLocalidad.Items.Clear();
                cmbLocalidad.Enabled = false;
                return;
            }

            int idProvincia = Convert.ToInt32(cmbProvincia.SelectedValue);

            // Obtener el nombre de la provincia seleccionada
            string nombreProvincia = "";
            DataRowView drv = cmbProvincia.SelectedItem as DataRowView;
            if (drv != null)
            {
                nombreProvincia = drv["NombreProvincia"].ToString();
            }

            if (nombreProvincia.Equals("Córdoba", StringComparison.OrdinalIgnoreCase))
            {
                CargarLocalidadesCordoba(idProvincia);
                cmbLocalidad.Enabled = true;
            }
            else
            {
                // Si no es Córdoba, no aplica la lista de localidades de Córdoba
                cmbLocalidad.DataSource = null;
                cmbLocalidad.Items.Clear();
                cmbLocalidad.Items.Add("No aplica (Solo Córdoba)");
                cmbLocalidad.SelectedIndex = 0;
                cmbLocalidad.Enabled = false;
            }
        }

        private void CargarLocalidadesCordoba(int idProvincia)
        {
            try
            {
                DataTable dt = clsConexion.ObtenerTabla("SELECT IdLocalidad, NombreLocalidad FROM Localidades WHERE IdProvincia = ? ORDER BY NombreLocalidad ASC", new OleDbParameter[] {
                    new OleDbParameter("?", idProvincia)
                });
                cmbLocalidad.DataSource = dt;
                cmbLocalidad.DisplayMember = "NombreLocalidad";
                cmbLocalidad.ValueMember = "IdLocalidad";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar localidades de Córdoba: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGrillaPersonal()
        {
            try
            {
                int currentId = selectedIdPersonal;

                string sql = @"
                    SELECT P.IdPersonal, P.DNI, P.Apellido, P.Nombre, P.Direccion, P.Latitud, P.Longitud, P.UbicacionGeografica, 
                           PR.NombreProvincia, L.NombreLocalidad, P.Activo, P.IdProvincia, P.IdLocalidad
                    FROM (Personal P
                    INNER JOIN Provincias PR ON P.IdProvincia = PR.IdProvincia)
                    LEFT JOIN Localidades L ON P.IdLocalidad = L.IdLocalidad
                    ORDER BY P.Apellido, P.Nombre";

                DataTable dt = clsConexion.ObtenerTabla(sql);
                dgvPersonal.DataSource = dt;

                // Ocultar IDs e información técnica innecesaria para el usuario en la grilla principal
                if (dgvPersonal.Columns.Contains("IdPersonal")) dgvPersonal.Columns["IdPersonal"].Visible = false;
                if (dgvPersonal.Columns.Contains("IdProvincia")) dgvPersonal.Columns["IdProvincia"].Visible = false;
                if (dgvPersonal.Columns.Contains("IdLocalidad")) dgvPersonal.Columns["IdLocalidad"].Visible = false;
                if (dgvPersonal.Columns.Contains("Latitud")) dgvPersonal.Columns["Latitud"].Visible = false;
                if (dgvPersonal.Columns.Contains("Longitud")) dgvPersonal.Columns["Longitud"].Visible = false;

                // Ocultar columnas detalladas para vista limpia en modo Master-Detail
                if (dgvPersonal.Columns.Contains("DNI")) dgvPersonal.Columns["DNI"].Visible = false;
                if (dgvPersonal.Columns.Contains("Direccion")) dgvPersonal.Columns["Direccion"].Visible = false;
                if (dgvPersonal.Columns.Contains("UbicacionGeografica")) dgvPersonal.Columns["UbicacionGeografica"].Visible = false;
                if (dgvPersonal.Columns.Contains("NombreProvincia")) dgvPersonal.Columns["NombreProvincia"].Visible = false;
                if (dgvPersonal.Columns.Contains("NombreLocalidad")) dgvPersonal.Columns["NombreLocalidad"].Visible = false;
                if (dgvPersonal.Columns.Contains("Activo")) dgvPersonal.Columns["Activo"].Visible = false;

                // Renombrar cabeceras
                if (dgvPersonal.Columns.Contains("Apellido")) dgvPersonal.Columns["Apellido"].HeaderText = "Apellido";
                if (dgvPersonal.Columns.Contains("Nombre")) dgvPersonal.Columns["Nombre"].HeaderText = "Nombre";

                // Restaurar la selección si corresponde
                if (currentId != -1)
                {
                    foreach (DataGridViewRow row in dgvPersonal.Rows)
                    {
                        if (Convert.ToInt32(row.Cells["IdPersonal"].Value) == currentId)
                        {
                            row.Selected = true;
                            dgvPersonal.CurrentCell = row.Cells["Apellido"];
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar personal en la grilla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPersonal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                DataGridViewRow row = dgvPersonal.Rows[e.RowIndex];
                selectedIdPersonal = Convert.ToInt32(row.Cells["IdPersonal"].Value);

                txtDni.Text = row.Cells["DNI"].Value.ToString();
                txtApellido.Text = row.Cells["Apellido"].Value.ToString();
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtDireccion.Text = row.Cells["Direccion"].Value.ToString();
                
                string ubicacion = row.Cells["UbicacionGeografica"].Value.ToString();
                if (string.IsNullOrEmpty(ubicacion))
                {
                    string lat = row.Cells["Latitud"].Value.ToString();
                    string lng = row.Cells["Longitud"].Value.ToString();
                    if (!string.IsNullOrEmpty(lat) && !string.IsNullOrEmpty(lng) && lat != "0" && lng != "0")
                    {
                        ubicacion = $"{lat}, {lng}";
                    }
                }
                txtUbicacionGeografica.Text = ubicacion;

                cmbProvincia.SelectedValue = Convert.ToInt32(row.Cells["IdProvincia"].Value);

                // Forzar carga de localidad si corresponde
                string provNombre = row.Cells["NombreProvincia"].Value.ToString();
                if (provNombre.Equals("Córdoba", StringComparison.OrdinalIgnoreCase))
                {
                    cmbLocalidad.SelectedValue = Convert.ToInt32(row.Cells["IdLocalidad"].Value);
                }

                // Cargar datos de contactos y estado activo
                CargarDatosContactoSeleccionado();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar personal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string dni = txtDni.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string direccion = txtDireccion.Text.Trim();

            if (string.IsNullOrEmpty(dni))
            {
                MessageBox.Show("El campo DNI es obligatorio.", "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDni.Focus();
                return;
            }

            // Validar DNI argentino
            if (!System.Text.RegularExpressions.Regex.IsMatch(dni, @"^(\d{7,8}|\d{1,2}\.\d{3}\.\d{3})$"))
            {
                MessageBox.Show("El DNI debe ser un número válido de 7 u 8 dígitos (ej: 12345678 o 12.345.678).", "Formato de DNI Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDni.Focus();
                return;
            }

            if (string.IsNullOrEmpty(apellido))
            {
                MessageBox.Show("El campo Apellido es obligatorio.", "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return;
            }
            if (apellido.Length < 2)
            {
                MessageBox.Show("El Apellido debe tener al menos 2 caracteres.", "Formato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return;
            }
            // Validación: Apellido solo puede contener letras (incluye acentos y ñ)
            if (!System.Text.RegularExpressions.Regex.IsMatch(apellido, @"^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s\-']+$"))
            {
                MessageBox.Show("El Apellido solo puede contener letras, espacios, guiones o apóstrofes.", "Formato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return;
            }

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("El campo Nombre es obligatorio.", "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }
            if (nombre.Length < 2)
            {
                MessageBox.Show("El Nombre debe tener al menos 2 caracteres.", "Formato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }
            // Validación: Nombre solo puede contener letras (incluye acentos y ñ)
            if (!System.Text.RegularExpressions.Regex.IsMatch(nombre, @"^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s\-']+$"))
            {
                MessageBox.Show("El Nombre solo puede contener letras, espacios, guiones o apóstrofes.", "Formato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrEmpty(direccion))
            {
                MessageBox.Show("El campo Dirección es obligatorio.", "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDireccion.Focus();
                return;
            }

            if (cmbProvincia.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una provincia.", "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbProvincia.Focus();
                return;
            }

            int idProvincia = Convert.ToInt32(cmbProvincia.SelectedValue);
            int idLocalidad = -1; // Por defecto

            // Verificar si la provincia seleccionada es Córdoba
            string provNombre = "";
            DataRowView drv = cmbProvincia.SelectedItem as DataRowView;
            if (drv != null) provNombre = drv["NombreProvincia"].ToString();

            if (provNombre.Equals("Córdoba", StringComparison.OrdinalIgnoreCase))
            {
                if (cmbLocalidad.SelectedValue == null || !(cmbLocalidad.SelectedValue is int))
                {
                    MessageBox.Show("Debe seleccionar una localidad para la provincia de Córdoba.", "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbLocalidad.Focus();
                    return;
                }
                idLocalidad = Convert.ToInt32(cmbLocalidad.SelectedValue);
            }

            // Validar y parsear ubicación geográfica (opcional)
            string ubicacion = txtUbicacionGeografica.Text.Trim();
            double? latitud = null;
            double? longitud = null;

            if (!string.IsNullOrEmpty(ubicacion))
            {
                double latTemp, lngTemp;
                if (TryParseCoordinates(ubicacion, out latTemp, out lngTemp))
                {
                    latitud = latTemp;
                    longitud = lngTemp;
                }
            }

            try
            {
                if (selectedIdPersonal == -1)
                {
                    // Validar DNI único antes de insertar
                    string sqlCheck = "SELECT COUNT(*) FROM Personal WHERE DNI = ?";
                    long count = Convert.ToInt64(clsConexion.EjecutarEscalar(sqlCheck, new OleDbParameter[] { new OleDbParameter("?", dni) }));
                    if (count > 0)
                    {
                        MessageBox.Show("Ya existe un personal registrado con ese DNI.", "DNI Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Insertar
                    string sqlInsert = @"
                        INSERT INTO Personal (DNI, Apellido, Nombre, Direccion, Latitud, Longitud, UbicacionGeografica, IdProvincia, IdLocalidad, Activo) 
                        VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, YES)";

                    OleDbParameter[] parameters = new OleDbParameter[] {
                        new OleDbParameter("?", dni),
                        new OleDbParameter("?", apellido),
                        new OleDbParameter("?", nombre),
                        new OleDbParameter("?", direccion),
                        latitud.HasValue ? new OleDbParameter("?", latitud.Value) : new OleDbParameter("?", DBNull.Value) { OleDbType = OleDbType.Double },
                        longitud.HasValue ? new OleDbParameter("?", longitud.Value) : new OleDbParameter("?", DBNull.Value) { OleDbType = OleDbType.Double },
                        string.IsNullOrEmpty(ubicacion) ? new OleDbParameter("?", DBNull.Value) { OleDbType = OleDbType.VarChar } : new OleDbParameter("?", ubicacion),
                        new OleDbParameter("?", idProvincia),
                        idLocalidad == -1 
                            ? new OleDbParameter("?", DBNull.Value) { OleDbType = OleDbType.Integer }
                            : new OleDbParameter("?", idLocalidad)
                    };

                    clsConexion.EjecutarConsulta(sqlInsert, parameters);
                    clsAuditoria.Registrar(clsSesion.Usuario, "Personal", "Crear", $"Se registró al personal '{apellido}, {nombre}' con DNI: {dni}.");
                    MessageBox.Show("Personal registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Validar DNI único excluyendo al actual
                    string sqlCheck = "SELECT COUNT(*) FROM Personal WHERE DNI = ? AND IdPersonal <> ?";
                    long count = Convert.ToInt64(clsConexion.EjecutarEscalar(sqlCheck, new OleDbParameter[] {
                        new OleDbParameter("?", dni),
                        new OleDbParameter("?", selectedIdPersonal)
                    }));
                    if (count > 0)
                    {
                        MessageBox.Show("Ya existe otro personal registrado con ese DNI.", "DNI Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Actualizar
                    string sqlUpdate = @"
                        UPDATE Personal 
                        SET DNI = ?, Apellido = ?, Nombre = ?, Direccion = ?, Latitud = ?, Longitud = ?, UbicacionGeografica = ?, IdProvincia = ?, IdLocalidad = ? 
                        WHERE IdPersonal = ?";

                    OleDbParameter[] parameters = new OleDbParameter[] {
                        new OleDbParameter("?", dni),
                        new OleDbParameter("?", apellido),
                        new OleDbParameter("?", nombre),
                        new OleDbParameter("?", direccion),
                        latitud.HasValue ? new OleDbParameter("?", latitud.Value) : new OleDbParameter("?", DBNull.Value) { OleDbType = OleDbType.Double },
                        longitud.HasValue ? new OleDbParameter("?", longitud.Value) : new OleDbParameter("?", DBNull.Value) { OleDbType = OleDbType.Double },
                        string.IsNullOrEmpty(ubicacion) ? new OleDbParameter("?", DBNull.Value) { OleDbType = OleDbType.VarChar } : new OleDbParameter("?", ubicacion),
                        new OleDbParameter("?", idProvincia),
                        idLocalidad == -1 
                            ? new OleDbParameter("?", DBNull.Value) { OleDbType = OleDbType.Integer }
                            : new OleDbParameter("?", idLocalidad),
                        new OleDbParameter("?", selectedIdPersonal)
                    };

                    clsConexion.EjecutarConsulta(sqlUpdate, parameters);
                    clsAuditoria.Registrar(clsSesion.Usuario, "Personal", "Modificar", $"Se modificaron los datos del personal '{apellido}, {nombre}' con DNI: {dni} (ID: {selectedIdPersonal}).");
                    MessageBox.Show("Personal actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                CargarGrillaPersonal();
                LimpiarFormulario();
                isEditMode = false;
                ActualizarModoEdicion();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (message.Contains("Personal.IdLocalidad") || message.Contains("idLocalidad") || message.Contains("Localidades"))
                {
                    MessageBox.Show("Error de validación: Debe especificar una localidad válida para la provincia seleccionada.", "Debe ingresar una localidad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Error al guardar personal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (selectedIdPersonal == -1)
            {
                MessageBox.Show("Debe seleccionar un personal de la grilla para eliminar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar a este personal del sistema?\nSe eliminarán también sus contactos asociados.", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    // 1. Eliminar contactos
                    clsConexion.EjecutarConsulta("DELETE FROM PersonalContactos WHERE IdPersonal = ?", new OleDbParameter[] {
                        new OleDbParameter("?", selectedIdPersonal)
                    });

                    // 2. Desvincular usuarios asociados (poner IdPersonal en NULL)
                    clsConexion.EjecutarConsulta("UPDATE Usuarios SET IdPersonal = NULL WHERE IdPersonal = ?", new OleDbParameter[] {
                        new OleDbParameter("?", selectedIdPersonal)
                    });

                    clsConexion.EjecutarConsulta("DELETE FROM Personal WHERE IdPersonal = ?", new OleDbParameter[] {
                        new OleDbParameter("?", selectedIdPersonal)
                    });

                    clsAuditoria.Registrar(clsSesion.Usuario, "Personal", "Eliminar", $"Se eliminó al personal con ID: {selectedIdPersonal} y todos sus contactos asociados.");

                    MessageBox.Show("Personal eliminado correctamente.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrillaPersonal();
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar personal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            isEditMode = false;
            if (selectedIdPersonal != -1)
            {
                CargarGrillaPersonal();
                if (dgvPersonal.CurrentRow != null)
                {
                    dgvPersonal_CellClick(dgvPersonal, new DataGridViewCellEventArgs(0, dgvPersonal.CurrentRow.Index));
                }
            }
            else
            {
                LimpiarFormulario();
            }
            ActualizarModoEdicion();
        }

        private void LimpiarFormulario()
        {
            selectedIdPersonal = -1;
            txtDni.Clear();
            txtApellido.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
            txtUbicacionGeografica.Clear();
            txtDireccionAdicional.Clear();
            if (cmbProvincia.Items.Count > 0) cmbProvincia.SelectedIndex = 0;
            txtDni.Focus();
            CargarDatosContactoSeleccionado();
        }

        private void btnVerMapa_Click(object sender, EventArgs e)
        {
            string ubicacion = txtUbicacionGeografica.Text.Trim();

            if (string.IsNullOrEmpty(ubicacion))
            {
                MessageBox.Show("Ingrese una ubicación (coordenadas o enlace de Google Maps) para visualizar.", "Ubicación Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string url = "";
            double latTemp, lngTemp;
            if (ubicacion.StartsWith("http://", StringComparison.OrdinalIgnoreCase) || 
                ubicacion.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                url = ubicacion;
            }
            else if (TryParseCoordinates(ubicacion, out latTemp, out lngTemp))
            {
                url = string.Format(CultureInfo.InvariantCulture, "https://www.google.com/maps?q={0},{1}", latTemp, lngTemp);
            }
            else
            {
                url = $"https://www.google.com/maps?q={Uri.EscapeDataString(ubicacion)}";
            }

            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir la ubicación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarTiposContacto()
        {
            cmbTipo.Items.Clear();
            cmbTipo.Items.Add("Email");
            cmbTipo.Items.Add("Teléfono");
            cmbTipo.Items.Add("Instagram");
            cmbTipo.Items.Add("Facebook");
            cmbTipo.Items.Add("LinkedIn");
            cmbTipo.Items.Add("Twitter / X");
            cmbTipo.Items.Add("Otro");
            cmbTipo.SelectedIndex = 0;
        }

        private void CargarDatosContactoSeleccionado()
        {
            if (selectedIdPersonal == -1)
            {
                isUpdatingUI = true;
                chkActivo.Checked = false;
                chkActivo.Enabled = false;
                isUpdatingUI = false;

                btnAgregarContacto.Enabled = false;
                btnEliminarContacto.Enabled = false;
                txtValor.Clear();
                txtValor.Enabled = false;
                cmbTipo.Enabled = false;
                dgvContactos.DataSource = null;

                // Actualizar aviso y visibilidad
                if (lblContactosAviso != null)
                {
                    lblContactosAviso.Visible = true;
                    lblTipo.Visible = false;
                    cmbTipo.Visible = false;
                    lblValor.Visible = false;
                    txtValor.Visible = false;
                    btnAgregarContacto.Visible = false;
                    btnEliminarContacto.Visible = false;
                    dgvContactos.Visible = false;
                }

                lblTitulo.Text = "Gestión de Personal: Registrar Nuevo";
                btnGuardar.Text = "Registrar Personal";
                btnGuardar.BackColor = System.Drawing.Color.FromArgb(34, 197, 94); // Emerald/Green-500
                btnEliminar.Enabled = false;
                btnEliminar.BackColor = System.Drawing.Color.FromArgb(71, 85, 105); // Slate-500 (deshabilitado)

                CargarDireccionesAdicionales();
                ActualizarBotonUsuario(-1);
                ActualizarModoEdicion();
                return;
            }

            chkActivo.Enabled = true;
            btnAgregarContacto.Enabled = true;
            btnEliminarContacto.Enabled = true;
            txtValor.Enabled = true;
            cmbTipo.Enabled = true;

            // Actualizar aviso y visibilidad
            if (lblContactosAviso != null)
            {
                lblContactosAviso.Visible = false;
                lblTipo.Visible = true;
                cmbTipo.Visible = true;
                lblValor.Visible = true;
                txtValor.Visible = true;
                btnAgregarContacto.Visible = true;
                btnEliminarContacto.Visible = true;
                dgvContactos.Visible = true;
            }

            string personalNombre = "";
            if (dgvPersonal.CurrentRow != null)
            {
                personalNombre = $"{dgvPersonal.CurrentRow.Cells["Apellido"].Value}, {dgvPersonal.CurrentRow.Cells["Nombre"].Value}";
            }
            lblTitulo.Text = string.IsNullOrEmpty(personalNombre) 
                ? $"Gestión de Personal: Editar #{selectedIdPersonal}" 
                : $"Gestión de Personal: {personalNombre}";
            btnGuardar.Text = "Guardar Cambios";
            btnGuardar.BackColor = System.Drawing.Color.FromArgb(79, 70, 229); // Indigo-600
            btnEliminar.Enabled = true;
            btnEliminar.BackColor = System.Drawing.Color.FromArgb(239, 68, 68); // Red-500

            try
            {
                isUpdatingUI = true;

                // 1. Obtener estado Activo/Inactivo
                object activoObj = clsConexion.EjecutarEscalar("SELECT Activo FROM Personal WHERE IdPersonal = ?", new OleDbParameter[] {
                    new OleDbParameter("?", selectedIdPersonal)
                });

                if (activoObj != null)
                {
                    chkActivo.Checked = Convert.ToBoolean(activoObj);
                }

                isUpdatingUI = false;

                // 2. Obtener contactos (excluyendo direcciones adicionales)
                CargarGrillaContactos(selectedIdPersonal);

                // 3. Cargar direcciones adicionales
                CargarDireccionesAdicionales();

                // 4. Actualizar botón de usuario
                ActualizarBotonUsuario(selectedIdPersonal);
            }
            catch (Exception ex)
            {
                isUpdatingUI = false;
                MessageBox.Show("Error al cargar datos del personal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ActualizarModoEdicion();
        }

        private void CargarGrillaContactos(int idPersonal)
        {
            try
            {
                string sql = "SELECT IdContacto, Tipo, Valor FROM PersonalContactos WHERE IdPersonal = ? AND Tipo <> 'Dirección Adicional' ORDER BY Tipo, Valor";
                DataTable dt = clsConexion.ObtenerTabla(sql, new OleDbParameter[] { new OleDbParameter("?", idPersonal) });

                dgvContactos.DataSource = dt;

                if (dgvContactos.Columns.Contains("IdContacto")) dgvContactos.Columns["IdContacto"].Visible = false;
                if (dgvContactos.Columns.Contains("Tipo")) dgvContactos.Columns["Tipo"].HeaderText = "Tipo de Contacto";
                if (dgvContactos.Columns.Contains("Valor")) dgvContactos.Columns["Valor"].HeaderText = "Contacto / Dirección / Enlace";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar contactos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTabDatos_Click(object sender, EventArgs e)
        {
            SetTab(true);
        }

        private void btnTabContactos_Click(object sender, EventArgs e)
        {
            SetTab(false);
        }

        private void SetTab(bool showDatos)
        {
            pnlDatosContainer.Visible = showDatos;
            pnlContactoContainer.Visible = !showDatos;

            if (showDatos)
            {
                btnTabDatos.BackColor = System.Drawing.Color.FromArgb(79, 70, 229);
                btnTabDatos.ForeColor = System.Drawing.Color.White;
                btnTabContactos.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
                btnTabContactos.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            }
            else
            {
                btnTabDatos.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
                btnTabDatos.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
                btnTabContactos.BackColor = System.Drawing.Color.FromArgb(79, 70, 229);
                btnTabContactos.ForeColor = System.Drawing.Color.White;

                // Cargar/actualizar los contactos del personal seleccionado
                CargarDatosContactoSeleccionado();
            }
        }

        private void chkActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdatingUI) return;

            if (selectedIdPersonal == -1) return;

            bool nuevoEstado = chkActivo.Checked;

            try
            {
                string sql = "UPDATE Personal SET Activo = ? WHERE IdPersonal = ?";
                clsConexion.EjecutarConsulta(sql, new OleDbParameter[] {
                    new OleDbParameter("?", nuevoEstado),
                    new OleDbParameter("?", selectedIdPersonal)
                });

                string estadoTexto = nuevoEstado ? "Activado" : "Desactivado";
                clsAuditoria.Registrar(clsSesion.Usuario, "Personal", "ModificarEstado", $"Se cambió el estado del personal ID: {selectedIdPersonal} a {estadoTexto}.");
                MessageBox.Show($"El personal ha sido {estadoTexto} en el sistema.", "Cambio de Estado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar la grilla principal de personal para reflejar el estado Activo
                CargarGrillaPersonal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar estado del personal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarContacto_Click(object sender, EventArgs e)
        {
            if (selectedIdPersonal == -1)
            {
                MessageBox.Show("Debe seleccionar un personal válido.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tipo = cmbTipo.SelectedItem?.ToString();
            string valor = txtValor.Text.Trim();

            if (string.IsNullOrEmpty(tipo) || string.IsNullOrEmpty(valor))
            {
                MessageBox.Show("Por favor complete el valor de contacto.", "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string sql = "INSERT INTO PersonalContactos (IdPersonal, Tipo, Valor) VALUES (?, ?, ?)";
                clsConexion.EjecutarConsulta(sql, new OleDbParameter[] {
                    new OleDbParameter("?", selectedIdPersonal),
                    new OleDbParameter("?", tipo),
                    new OleDbParameter("?", valor)
                });

                clsAuditoria.Registrar(clsSesion.Usuario, "PersonalContactos", "Crear", $"Se agregó contacto tipo '{tipo}' para el personal ID: {selectedIdPersonal}.");

                txtValor.Clear();
                txtValor.Focus();
                CargarGrillaContactos(selectedIdPersonal);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar contacto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarContacto_Click(object sender, EventArgs e)
        {
            if (dgvContactos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un contacto de la lista para eliminar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idContacto = Convert.ToInt32(dgvContactos.SelectedRows[0].Cells["IdContacto"].Value);

            DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar el contacto/dirección seleccionado?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    clsConexion.EjecutarConsulta("DELETE FROM PersonalContactos WHERE IdContacto = ?", new OleDbParameter[] {
                        new OleDbParameter("?", idContacto)
                    });

                    clsAuditoria.Registrar(clsSesion.Usuario, "PersonalContactos", "Eliminar", $"Se eliminó el contacto ID: {idContacto} del personal ID: {selectedIdPersonal}.");

                    CargarGrillaContactos(selectedIdPersonal);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar contacto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool TryParseCoordinates(string input, out double lat, out double lng)
        {
            lat = 0;
            lng = 0;
            if (string.IsNullOrEmpty(input)) return false;

            input = input.Trim();

            // Si es un enlace de Google Maps, intentar extraer las coordenadas
            if (input.StartsWith("http://", StringComparison.OrdinalIgnoreCase) || 
                input.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                // Formato estándar con @lat,lng
                var match = System.Text.RegularExpressions.Regex.Match(input, @"@(-?\d+(?:\.\d+)?),(-?\d+(?:\.\d+)?)");
                if (match.Success)
                {
                    if (double.TryParse(match.Groups[1].Value, NumberStyles.Any, CultureInfo.InvariantCulture, out lat) &&
                        double.TryParse(match.Groups[2].Value, NumberStyles.Any, CultureInfo.InvariantCulture, out lng))
                    {
                        return true;
                    }
                }
                
                // Formato con query parameter q=lat,lng
                match = System.Text.RegularExpressions.Regex.Match(input, @"[?&]q=(-?\d+(?:\.\d+)?),(-?\d+(?:\.\d+)?)");
                if (match.Success)
                {
                    if (double.TryParse(match.Groups[1].Value, NumberStyles.Any, CultureInfo.InvariantCulture, out lat) &&
                        double.TryParse(match.Groups[2].Value, NumberStyles.Any, CultureInfo.InvariantCulture, out lng))
                    {
                        return true;
                    }
                }
                
                // Formato con place/lat,lng
                match = System.Text.RegularExpressions.Regex.Match(input, @"/place/(-?\d+(?:\.\d+)?),(-?\d+(?:\.\d+)?)");
                if (match.Success)
                {
                    if (double.TryParse(match.Groups[1].Value, NumberStyles.Any, CultureInfo.InvariantCulture, out lat) &&
                        double.TryParse(match.Groups[2].Value, NumberStyles.Any, CultureInfo.InvariantCulture, out lng))
                    {
                        return true;
                    }
                }
                
                return false;
            }

            // Separadores comunes de coordenadas
            char[] separators = new char[] { ';', ',', ' ', '\t' };
            
            // Caso especial: coma como decimal AND coma como separador de coordenadas
            // Ej: -31,4258118851343, -64,17535910581091
            string[] commaParts = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (commaParts.Length == 4)
            {
                string latPart = commaParts[0].Trim() + "." + commaParts[1].Trim();
                string lngPart = commaParts[2].Trim() + "." + commaParts[3].Trim();
                if (double.TryParse(latPart, NumberStyles.Any, CultureInfo.InvariantCulture, out lat) &&
                    double.TryParse(lngPart, NumberStyles.Any, CultureInfo.InvariantCulture, out lng))
                {
                    return true;
                }
            }

            // Probar otros separadores
            foreach (var separator in separators)
            {
                string[] parts = input.Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 2)
                {
                    string latPart = parts[0].Trim().Replace(',', '.');
                    string lngPart = parts[1].Trim().Replace(',', '.');
                    if (double.TryParse(latPart, NumberStyles.Any, CultureInfo.InvariantCulture, out lat) &&
                        double.TryParse(lngPart, NumberStyles.Any, CultureInfo.InvariantCulture, out lng))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void CargarDireccionesAdicionales()
        {
            lstDireccionesAdicionales.DataSource = null;
            lstDireccionesAdicionales.Items.Clear();

            if (selectedIdPersonal == -1)
            {
                txtDireccionAdicional.Clear();
                txtDireccionAdicional.Enabled            = false;
                btnAgregarDireccionAdicional.Enabled     = false;
                btnEliminarDireccionAdicional.Enabled    = false;
                return;
            }

            txtDireccionAdicional.Enabled            = true;
            btnAgregarDireccionAdicional.Enabled     = true;
            btnEliminarDireccionAdicional.Enabled    = true;

            try
            {
                // Tabla unificada: Dirección principal + Ubicación + Adicionales
                // IdContacto negativo = solo lectura (no se puede borrar desde esta lista)
                System.Data.DataTable dt = new System.Data.DataTable();
                dt.Columns.Add("IdContacto", typeof(int));
                dt.Columns.Add("Valor",      typeof(string));

                // Agregar dirección principal y ubicación geográfica desde Personal
                System.Data.DataTable dtPersonal = clsConexion.ObtenerTabla(
                    "SELECT Direccion, UbicacionGeografica FROM Personal WHERE IdPersonal = ?",
                    new OleDbParameter[] { new OleDbParameter("?", selectedIdPersonal) });

                if (dtPersonal.Rows.Count > 0)
                {
                    string dirPrincipal = dtPersonal.Rows[0]["Direccion"].ToString().Trim();
                    string ubicacion    = dtPersonal.Rows[0]["UbicacionGeografica"].ToString().Trim();

                    // IdContacto = -1 reservado para la dirección principal
                    if (!string.IsNullOrEmpty(dirPrincipal))
                        dt.Rows.Add(-1, "[Principal] " + dirPrincipal);

                    // IdContacto = -2 reservado para la ubicación geográfica
                    if (!string.IsNullOrEmpty(ubicacion))
                        dt.Rows.Add(-2, "[Ubicación] " + ubicacion);
                }

                // Agregar las direcciones adicionales almacenadas en PersonalContactos
                System.Data.DataTable dtAdicionales = clsConexion.ObtenerTabla(
                    "SELECT IdContacto, Valor FROM PersonalContactos WHERE IdPersonal = ? AND Tipo = 'Dirección Adicional' ORDER BY Valor",
                    new OleDbParameter[] { new OleDbParameter("?", selectedIdPersonal) });

                foreach (System.Data.DataRow row in dtAdicionales.Rows)
                    dt.Rows.Add(Convert.ToInt32(row["IdContacto"]), row["Valor"].ToString());

                lstDireccionesAdicionales.DataSource    = dt;
                lstDireccionesAdicionales.DisplayMember = "Valor";
                lstDireccionesAdicionales.ValueMember   = "IdContacto";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar direcciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarDireccionAdicional_Click(object sender, EventArgs e)
        {
            if (selectedIdPersonal == -1)
            {
                MessageBox.Show("Debe seleccionar un personal válido.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string valor = txtDireccionAdicional.Text.Trim();

            if (string.IsNullOrEmpty(valor))
            {
                MessageBox.Show("Por favor complete el valor de la dirección adicional.", "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string sql = "INSERT INTO PersonalContactos (IdPersonal, Tipo, Valor) VALUES (?, 'Dirección Adicional', ?)";
                clsConexion.EjecutarConsulta(sql, new OleDbParameter[] {
                    new OleDbParameter("?", selectedIdPersonal),
                    new OleDbParameter("?", valor)
                });

                clsAuditoria.Registrar(clsSesion.Usuario, "PersonalContactos", "Crear", $"Se agregó dirección adicional '{valor}' para el personal ID: {selectedIdPersonal}.");

                txtDireccionAdicional.Clear();
                txtDireccionAdicional.Focus();
                CargarDireccionesAdicionales();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar dirección adicional: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarDireccionAdicional_Click(object sender, EventArgs e)
        {
            if (lstDireccionesAdicionales.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una dirección de la lista para eliminar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idContacto = Convert.ToInt32(lstDireccionesAdicionales.SelectedValue);

            // IdContacto negativo = dirección principal o ubicación (no eliminables desde aquí)
            if (idContacto < 0)
            {
                MessageBox.Show("La dirección principal y la ubicación no pueden eliminarse desde aquí.\nEdite directamente los campos 'Dirección' o 'Ubicación' del formulario.", "No disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string valor = lstDireccionesAdicionales.Text;

            DialogResult result = MessageBox.Show($"¿Está seguro de que desea eliminar la dirección adicional '{valor}'?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    clsConexion.EjecutarConsulta("DELETE FROM PersonalContactos WHERE IdContacto = ?", new OleDbParameter[] {
                        new OleDbParameter("?", idContacto)
                    });

                    clsAuditoria.Registrar(clsSesion.Usuario, "PersonalContactos", "Eliminar", $"Se eliminó la dirección adicional ID: {idContacto} del personal ID: {selectedIdPersonal}.");

                    CargarDireccionesAdicionales();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar dirección adicional: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ActualizarBotonUsuario(int idPersonal)
        {
            if (idPersonal == -1)
            {
                btnGestionarUsuario.Enabled = false;
                btnGestionarUsuario.Text = "Gestionar Usuario";
                btnGestionarUsuario.BackColor = System.Drawing.Color.FromArgb(71, 85, 105);
                return;
            }

            try
            {
                string sql = "SELECT COUNT(*) FROM Usuarios WHERE IdPersonal = ?";
                long count = Convert.ToInt64(clsConexion.EjecutarEscalar(sql, new OleDbParameter[] { new OleDbParameter("?", idPersonal) }));

                btnGestionarUsuario.Enabled = true;
                if (count > 0)
                {
                    btnGestionarUsuario.Text = "Editar Cuenta de Usuario";
                    btnGestionarUsuario.BackColor = System.Drawing.Color.FromArgb(79, 70, 229);
                }
                else
                {
                    btnGestionarUsuario.Text = "Crear Cuenta de Usuario";
                    btnGestionarUsuario.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al verificar cuenta de usuario: " + ex.Message);
            }
        }

        private void btnGestionarUsuario_Click(object sender, EventArgs e)
        {
            if (selectedIdPersonal == -1) return;

            try
            {
                frmMain mainForm = Application.OpenForms["frmMain"] as frmMain;
                if (mainForm != null)
                {
                    mainForm.AbrirUsuariosConPersonal(selectedIdPersonal);
                }
                else
                {
                    MessageBox.Show("Error de navegación: No se pudo encontrar el formulario principal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir gestión de usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EstilizarControles()
        {
            var fontLabel = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            var fontInput = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            var fontTitulo = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);

            lblTitulo.Font = fontTitulo;
            lblTitulo.ForeColor = System.Drawing.Color.FromArgb(248, 250, 252);

            foreach (Control c in pnlForm.Controls)
            {
                if (c is Label lbl)
                {
                    if (lbl != label1 && lbl != lblDireccionesAdicionales)
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

            foreach (Control c in pnlContactoContainer.Controls)
            {
                if (c is Label lbl)
                {
                    if (lbl != lblContactosAviso)
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

            txtDireccionAdicional.Font = fontInput;
            txtDireccionAdicional.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            txtDireccionAdicional.ForeColor = System.Drawing.Color.White;
            txtDireccionAdicional.BorderStyle = BorderStyle.FixedSingle;

            lstDireccionesAdicionales.Font = fontInput;
            lstDireccionesAdicionales.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lstDireccionesAdicionales.ForeColor = System.Drawing.Color.White;
            lstDireccionesAdicionales.BorderStyle = BorderStyle.FixedSingle;

            EstilizarBoton(btnGuardar, System.Drawing.Color.FromArgb(34, 197, 94));
            EstilizarBoton(btnLimpiar, System.Drawing.Color.FromArgb(71, 85, 105));
            EstilizarBoton(btnEliminar, System.Drawing.Color.FromArgb(239, 68, 68));
            EstilizarBoton(btnVerMapa, System.Drawing.Color.FromArgb(79, 70, 229));
            EstilizarBoton(btnAgregarDireccionAdicional, System.Drawing.Color.FromArgb(16, 185, 129));
            EstilizarBoton(btnEliminarDireccionAdicional, System.Drawing.Color.FromArgb(220, 38, 38));
            EstilizarBoton(btnAgregarContacto, System.Drawing.Color.FromArgb(16, 185, 129));
            EstilizarBoton(btnEliminarContacto, System.Drawing.Color.FromArgb(220, 38, 38));
            EstilizarBoton(btnGestionarUsuario, System.Drawing.Color.FromArgb(79, 70, 229));
            EstilizarBoton(btnEditar, System.Drawing.Color.FromArgb(79, 70, 229));
            EstilizarBoton(btnNuevo, System.Drawing.Color.FromArgb(16, 185, 129));

            chkActivo.BackColor = System.Drawing.Color.Transparent;
            chkActivo.ForeColor = System.Drawing.Color.White;
            chkActivo.UseVisualStyleBackColor = false;

            EstilizarBotonTab(btnTabDatos);
            EstilizarBotonTab(btnTabContactos);

            EstilizarGrilla(dgvPersonal);
            EstilizarGrilla(dgvContactos);
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
                    btn.BackColor = selectedIdPersonal == -1 ? System.Drawing.Color.FromArgb(34, 197, 94) : System.Drawing.Color.FromArgb(79, 70, 229);
                }
                else if (btn == btnEliminar)
                {
                    btn.BackColor = selectedIdPersonal == -1 ? System.Drawing.Color.FromArgb(71, 85, 105) : System.Drawing.Color.FromArgb(239, 68, 68);
                }
                else if (btn == btnGestionarUsuario)
                {
                    ActualizarBotonUsuario(selectedIdPersonal);
                }
                else
                {
                    btn.BackColor = btn.Enabled ? baseColor : System.Drawing.Color.FromArgb(71, 85, 105);
                }
            };
        }

        private void EstilizarBotonTab(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (selectedIdPersonal == -1) return;
            isEditMode = true;
            ActualizarModoEdicion();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            isEditMode = true;
            ActualizarModoEdicion();
            txtDni.Focus();
        }

        private void ActualizarModoEdicion()
        {
            txtDni.ReadOnly = !isEditMode;
            txtApellido.ReadOnly = !isEditMode;
            txtNombre.ReadOnly = !isEditMode;
            txtDireccion.ReadOnly = !isEditMode;
            txtUbicacionGeografica.ReadOnly = !isEditMode;
            
            // Mantener Enabled=true para preservar el diseño oscuro, bloqueamos interacción en los eventos
            cmbProvincia.Enabled = true;
            cmbLocalidad.Enabled = true;
            chkActivo.Enabled = isEditMode && (selectedIdPersonal != -1);

            cmbTipo.Enabled = true;
            // txtValor siempre permite escritura cuando hay un empleado seleccionado;
            // los contactos se gestionan independientemente del modo de edición del formulario
            txtValor.ReadOnly = false;
            btnAgregarContacto.Enabled = isEditMode && (selectedIdPersonal != -1);
            btnEliminarContacto.Enabled = isEditMode && (selectedIdPersonal != -1);

            txtDireccionAdicional.ReadOnly = !isEditMode;
            btnAgregarDireccionAdicional.Enabled = isEditMode && (selectedIdPersonal != -1);
            btnEliminarDireccionAdicional.Enabled = isEditMode && (selectedIdPersonal != -1);

            btnGuardar.Visible = isEditMode;
            btnLimpiar.Visible = isEditMode;
            btnEditar.Visible = !isEditMode && (selectedIdPersonal != -1);
            btnNuevo.Visible = !isEditMode;

            btnEliminar.Enabled = !isEditMode && (selectedIdPersonal != -1);
            btnGestionarUsuario.Enabled = !isEditMode && (selectedIdPersonal != -1);

            // Fijar color Slate-800 de fondo y borde FixedSingle para legibilidad total
            System.Drawing.Color bg = System.Drawing.Color.FromArgb(30, 41, 59);
            txtDni.BackColor = bg;
            txtApellido.BackColor = bg;
            txtNombre.BackColor = bg;
            txtDireccion.BackColor = bg;
            txtUbicacionGeografica.BackColor = bg;
            cmbProvincia.BackColor = bg;
            cmbLocalidad.BackColor = bg;
            txtDireccionAdicional.BackColor = bg;
            txtValor.BackColor = bg;

            txtDni.BorderStyle = BorderStyle.FixedSingle;
            txtApellido.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtDireccion.BorderStyle = BorderStyle.FixedSingle;
            txtUbicacionGeografica.BorderStyle = BorderStyle.FixedSingle;
            txtDireccionAdicional.BorderStyle = BorderStyle.FixedSingle;
            txtValor.BorderStyle = BorderStyle.FixedSingle;

            // Letra gris en modo lectura, letra blanca en modo edición
            System.Drawing.Color fg = isEditMode ? System.Drawing.Color.White : System.Drawing.Color.FromArgb(148, 163, 184);
            txtDni.ForeColor = fg;
            txtApellido.ForeColor = fg;
            txtNombre.ForeColor = fg;
            txtDireccion.ForeColor = fg;
            txtUbicacionGeografica.ForeColor = fg;
            cmbProvincia.ForeColor = fg;
            cmbLocalidad.ForeColor = fg;
            txtDireccionAdicional.ForeColor = fg;
            txtValor.ForeColor = fg;

            btnLimpiar.Text = "Cancelar";
        }

        private void PreventComboBoxUsage(object sender, KeyEventArgs e)
        {
            if (!isEditMode)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void PreventComboBoxUsageKey(object sender, KeyPressEventArgs e)
        {
            if (!isEditMode)
            {
                e.Handled = true;
            }
        }

        private void PreventComboBoxUsageClick(object sender, EventArgs e)
        {
            if (!isEditMode)
            {
                ComboBox cmb = sender as ComboBox;
                if (cmb != null)
                {
                    cmb.DroppedDown = false;
                }
            }
        }
    }
}
