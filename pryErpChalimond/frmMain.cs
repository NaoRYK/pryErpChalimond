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
            DestacarBotonActivo(btnAuditoria);
            AbrirFormularioHijo(new frmAuditoria());
        }

        private void btnSalirMain_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea cerrar la sesión actual?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }
    }
}
