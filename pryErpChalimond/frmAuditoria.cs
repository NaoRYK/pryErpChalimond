using System;
using System.Data;
using System.Windows.Forms;

namespace pryErpChalimond
{
    public partial class frmAuditoria : Form
    {
        public frmAuditoria()
        {
            InitializeComponent();
        }

        private void frmAuditoria_Load(object sender, EventArgs e)
        {
            CargarAuditorias();
        }

        private void CargarAuditorias()
        {
            try
            {
                string sql = "SELECT NombreUsuario, FechaHora, Exitoso, Detalle FROM AuditoriaSesion ORDER BY FechaHora DESC";
                DataTable dt = clsConexion.ObtenerTabla(sql);
                dgvAuditoria.DataSource = dt;

                // Cambiar cabeceras para mostrar nombres legibles
                if (dgvAuditoria.Columns.Count > 0)
                {
                    dgvAuditoria.Columns["NombreUsuario"].HeaderText = "Usuario";
                    dgvAuditoria.Columns["FechaHora"].HeaderText = "Fecha y Hora";
                    dgvAuditoria.Columns["Exitoso"].HeaderText = "Exitoso";
                    dgvAuditoria.Columns["Detalle"].HeaderText = "Detalle de Evento";
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
    }
}
