using System;
using System.Drawing;
using System.Windows.Forms;

namespace pryErpChalimond
{
    public partial class frmMain : Form
    {
        private string loggedUser;
        private string loggedRol;
        private string connectionTime;
        private Form activeForm = null;

        public frmMain(string usuario, string rol, string horaConexion)
        {
            InitializeComponent();
            this.loggedUser = usuario;
            this.loggedRol = rol;
            this.connectionTime = horaConexion;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblStatusUsuario.Text = $"Usuario: {loggedUser}";
            lblStatusRol.Text = $"Rol: {loggedRol}";
            lblStatusHora.Text = $"Conexión: {connectionTime}";

            // Restringir acceso a Auditoría y Gestión de Usuarios si el rol no es Admin
            if (!loggedRol.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                btnAuditoria.Visible = false;
                btnUsuarios.Visible = false;
            }

            // Cargar dashboard por defecto
            AbrirFormularioHijo(new frmDashboard());
            DestacarBotonActivo(btnInicio);
        }

        public void AbrirFormularioHijo(Form frmHijo)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose();
            }

            activeForm = frmHijo;
            frmHijo.TopLevel = false;
            frmHijo.FormBorderStyle = FormBorderStyle.None;
            frmHijo.Dock = DockStyle.Fill;
            
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(frmHijo);
            pnlContent.Tag = frmHijo;
            
            frmHijo.Show();
        }

        private void DestacarBotonActivo(Button btn)
        {
            // Resetear estilos de todos los botones
            btnInicio.BackColor = Color.FromArgb(15, 23, 42);
            btnInicio.ForeColor = Color.FromArgb(148, 163, 184);

            btnPersonal.BackColor = Color.FromArgb(15, 23, 42);
            btnPersonal.ForeColor = Color.FromArgb(148, 163, 184);

            btnAuditoria.BackColor = Color.FromArgb(15, 23, 42);
            btnAuditoria.ForeColor = Color.FromArgb(148, 163, 184);

            btnUsuarios.BackColor = Color.FromArgb(15, 23, 42);
            btnUsuarios.ForeColor = Color.FromArgb(148, 163, 184);

            // Destacar botón activo
            btn.BackColor = Color.FromArgb(30, 41, 59);
            btn.ForeColor = Color.FromArgb(129, 140, 248);
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            DestacarBotonActivo(btnInicio);
            AbrirFormularioHijo(new frmDashboard());
        }

        private void btnPersonal_Click(object sender, EventArgs e)
        {
            DestacarBotonActivo(btnPersonal);
            AbrirFormularioHijo(new frmPersonal());
        }

        private void btnAuditoria_Click(object sender, EventArgs e)
        {
            if (!loggedRol.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Acceso denegado: Esta pantalla solo está disponible para administradores.", "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DestacarBotonActivo(btnAuditoria);
            AbrirFormularioHijo(new frmAuditoria());
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            if (!loggedRol.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Acceso denegado: Esta pantalla solo está disponible para administradores.", "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DestacarBotonActivo(btnUsuarios);
            AbrirFormularioHijo(new frmUsuarios());
        }

        private void btnSalirMain_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea cerrar la sesión actual?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Registrar auditoría de logout
                clsAuditoria.Registrar(clsSesion.Usuario, "Seguridad", "Logout", "Cierre de sesión manual.");

                // Limpiar sesión
                clsSesion.Usuario = "desconocido";
                clsSesion.Rol = "";

                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            // Registrar auditoría si la sesión seguía activa al cerrar la ventana directamente
            if (clsSesion.Usuario != "desconocido" && this.DialogResult != DialogResult.Yes)
            {
                clsAuditoria.Registrar(clsSesion.Usuario, "Seguridad", "Logout", "Cierre directo de la ventana de la aplicación.");
                clsSesion.Usuario = "desconocido";
                clsSesion.Rol = "";
            }
        }
    }
}
