using System;
using System.Windows.Forms;

namespace pryErpChalimond
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            CargarEstadisticas();
        }

        private void CargarEstadisticas()
        {
            try
            {
                // Cantidad de Personal
                object countPersonal = clsConexion.EjecutarEscalar("SELECT COUNT(*) FROM Personal");
                lblPersonalCount.Text = countPersonal != null ? countPersonal.ToString() : "0";

                // Cantidad de Usuarios de Sistema
                object countUsuarios = clsConexion.EjecutarEscalar("SELECT COUNT(*) FROM Usuarios");
                lblUsuariosCount.Text = countUsuarios != null ? countUsuarios.ToString() : "0";

                // Cantidad de registros en la auditoria
                object countAuditoria = clsConexion.EjecutarEscalar("SELECT COUNT(*) FROM AuditoriaSesion");
                lblAuditoriaCount.Text = countAuditoria != null ? countAuditoria.ToString() : "0";
            }
            catch (Exception ex)
            {
                // En caso de que falle por estar vacía o recién inicializada, mostramos 0
                Console.WriteLine("Error al cargar estadísticas en dashboard: " + ex.Message);
            }
        }

        private void lblWelcomeSub_Click(object sender, EventArgs e)
        {

        }
    }
}
