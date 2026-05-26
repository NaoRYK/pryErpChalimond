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

        public frmPersonal()
        {
            InitializeComponent();
        }

        private void frmPersonal_Load(object sender, EventArgs e)
        {
            CargarProvincias();
            CargarGrillaPersonal();
            CargarTiposContacto();
            LimpiarFormulario();
            SetTab(true);
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
                MessageBox.Show("Error al cargar provincias: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProvincia.SelectedValue == null || !(cmbProvincia.SelectedValue is int))
            {
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

                // Renombrar cabeceras
                if (dgvPersonal.Columns.Contains("DNI")) dgvPersonal.Columns["DNI"].HeaderText = "DNI";
                if (dgvPersonal.Columns.Contains("Apellido")) dgvPersonal.Columns["Apellido"].HeaderText = "Apellido";
                if (dgvPersonal.Columns.Contains("Nombre")) dgvPersonal.Columns["Nombre"].HeaderText = "Nombre";
                if (dgvPersonal.Columns.Contains("Direccion")) dgvPersonal.Columns["Direccion"].HeaderText = "Dirección";
                if (dgvPersonal.Columns.Contains("UbicacionGeografica")) dgvPersonal.Columns["UbicacionGeografica"].HeaderText = "Ubicación Geográfica";
                if (dgvPersonal.Columns.Contains("NombreProvincia")) dgvPersonal.Columns["NombreProvincia"].HeaderText = "Provincia";
                if (dgvPersonal.Columns.Contains("NombreLocalidad")) dgvPersonal.Columns["NombreLocalidad"].HeaderText = "Localidad";
                if (dgvPersonal.Columns.Contains("Activo")) dgvPersonal.Columns["Activo"].HeaderText = "Activo";
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

            if (string.IsNullOrEmpty(dni) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(direccion))
            {
                MessageBox.Show("DNI, Apellido, Nombre y Dirección son obligatorios.", "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbProvincia.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una provincia.", "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar personal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            selectedIdPersonal = -1;
            txtDni.Clear();
            txtApellido.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
            txtUbicacionGeografica.Clear();
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
            cmbTipo.Items.Add("Dirección Adicional");
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
                return;
            }

            chkActivo.Enabled = true;
            btnAgregarContacto.Enabled = true;
            btnEliminarContacto.Enabled = true;
            txtValor.Enabled = true;
            cmbTipo.Enabled = true;

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

                // 2. Obtener contactos
                CargarGrillaContactos(selectedIdPersonal);
            }
            catch (Exception ex)
            {
                isUpdatingUI = false;
                MessageBox.Show("Error al cargar datos del personal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGrillaContactos(int idPersonal)
        {
            try
            {
                string sql = "SELECT IdContacto, Tipo, Valor FROM PersonalContactos WHERE IdPersonal = ? ORDER BY Tipo, Valor";
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
    }
}
