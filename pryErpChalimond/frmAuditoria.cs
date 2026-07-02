using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace pryErpChalimond
{
    public partial class frmAuditoria : Form
    {
        private bool isUpdatingFilters = false;

        public frmAuditoria()
        {
            InitializeComponent();
        }

        private void frmAuditoria_Load(object sender, EventArgs e)
        {
            // Inicializar combo de filtros
            cmbExitosoFiltro.Items.Clear();
            cmbExitosoFiltro.Items.Add("Todos");
            cmbExitosoFiltro.Items.Add("Inicio Exitoso");
            cmbExitosoFiltro.Items.Add("Intento Fallido");
            cmbExitosoFiltro.SelectedIndex = 0;

            // Configurar DateTimePickers por defecto con la fecha actual
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today;

            // Cargar datos
            CargarAuditorias();

            // Suscribir eventos para filtrado automático
            txtUserFiltro.TextChanged += (s, ev) => CargarAuditorias();
            cmbExitosoFiltro.SelectedIndexChanged += (s, ev) => CargarAuditorias();
            dtpDesde.ValueChanged += (s, ev) => CargarAuditorias();
            dtpHasta.ValueChanged += (s, ev) => CargarAuditorias();
        }

        private void CargarAuditorias()
        {
            if (isUpdatingFilters) return;

            try
            {
                string sql = "SELECT NombreUsuario, FechaHora, Modulo, Accion, Exitoso, Detalle FROM AuditoriaSesion WHERE 1=1";
                List<OleDbParameter> parameters = new List<OleDbParameter>();

                // Filtro por usuario (búsqueda parcial insensible a mayúsculas/minúsculas)
                string usuarioFiltro = txtUserFiltro.Text.Trim();
                if (!string.IsNullOrEmpty(usuarioFiltro))
                {
                    sql += " AND NombreUsuario LIKE ?";
                    parameters.Add(new OleDbParameter("?", OleDbType.VarWChar) { Value = "%" + usuarioFiltro + "%" });
                }

                // Filtro por resultado (Exitoso)
                if (cmbExitosoFiltro.SelectedIndex == 1) // Inicio Exitoso
                {
                    sql += " AND Exitoso = ?";
                    parameters.Add(new OleDbParameter("?", OleDbType.Boolean) { Value = true });
                }
                else if (cmbExitosoFiltro.SelectedIndex == 2) // Intento Fallido
                {
                    sql += " AND Exitoso = ?";
                    parameters.Add(new OleDbParameter("?", OleDbType.Boolean) { Value = false });
                }

                // Filtro por rango de fechas
                if (chkFechaFiltro.Checked)
                {
                    // Desde el inicio del día (00:00:00) hasta el final del día (23:59:59)
                    DateTime fechaDesde = dtpDesde.Value.Date;
                    DateTime fechaHasta = dtpHasta.Value.Date.AddDays(1).AddSeconds(-1);

                    sql += " AND FechaHora >= ? AND FechaHora <= ?";
                    parameters.Add(new OleDbParameter("?", OleDbType.Date) { Value = fechaDesde });
                    parameters.Add(new OleDbParameter("?", OleDbType.Date) { Value = fechaHasta });
                }

                sql += " ORDER BY FechaHora DESC";

                DataTable dt = clsConexion.ObtenerTabla(sql, parameters.Count > 0 ? parameters.ToArray() : null);
                dgvAuditoria.DataSource = dt;

                // Notificar cuando la búsqueda no devuelve registros (omitido para filtrado automático fluido)

                // Cambiar cabeceras para mostrar nombres legibles
                if (dgvAuditoria.Columns.Count > 0)
                {
                    if (dgvAuditoria.Columns.Contains("NombreUsuario")) dgvAuditoria.Columns["NombreUsuario"].HeaderText = "Usuario";
                    if (dgvAuditoria.Columns.Contains("FechaHora")) dgvAuditoria.Columns["FechaHora"].HeaderText = "Fecha y Hora";
                    if (dgvAuditoria.Columns.Contains("Modulo")) dgvAuditoria.Columns["Modulo"].HeaderText = "Módulo";
                    if (dgvAuditoria.Columns.Contains("Accion")) dgvAuditoria.Columns["Accion"].HeaderText = "Acción";
                    if (dgvAuditoria.Columns.Contains("Exitoso")) dgvAuditoria.Columns["Exitoso"].HeaderText = "Exitoso";
                    if (dgvAuditoria.Columns.Contains("Detalle")) dgvAuditoria.Columns["Detalle"].HeaderText = "Detalle de Evento";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar registros de auditoría: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarAuditorias();
        }



        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            isUpdatingFilters = true;
            try
            {
                txtUserFiltro.Clear();
                cmbExitosoFiltro.SelectedIndex = 0;
                chkFechaFiltro.Checked = false;
                dtpDesde.Value = DateTime.Today;
                dtpHasta.Value = DateTime.Today;
            }
            finally
            {
                isUpdatingFilters = false;
            }
            CargarAuditorias();
        }

        private void chkFechaFiltro_CheckedChanged(object sender, EventArgs e)
        {
            dtpDesde.Enabled = chkFechaFiltro.Checked;
            dtpHasta.Enabled = chkFechaFiltro.Checked;
            CargarAuditorias();
        }
    }
}
