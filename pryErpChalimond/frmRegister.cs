using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace pryErpChalimond
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
            lblError.Text = "";
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            CargarRoles();
            CargarPersonal();
        }

        private void CargarRoles()
        {
            try
            {
                DataTable dt = clsConexion.ObtenerTabla("SELECT IdPerfil, NombrePerfil FROM Perfiles ORDER BY NombrePerfil ASC");
                cmbRol.DataSource = dt;
                cmbRol.DisplayMember = "NombrePerfil";
                cmbRol.ValueMember = "IdPerfil";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPersonal()
        {
            try
            {
                DataTable dt = clsConexion.ObtenerTabla("SELECT IdPersonal, (Apellido + ', ' + Nombre) AS NombreCompleto FROM Personal WHERE Activo = Yes ORDER BY Apellido, Nombre");
                cmbPersonal.DataSource = dt;
                cmbPersonal.DisplayMember = "NombreCompleto";
                cmbPersonal.ValueMember = "IdPersonal";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar personal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text;
            
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                lblError.Text = "Por favor ingrese usuario y contraseña.";
                return;
            }

            if (cmbRol.SelectedValue == null)
            {
                lblError.Text = "Seleccione un rol válido.";
                return;
            }

            if (cmbPersonal.SelectedValue == null)
            {
                lblError.Text = "Seleccione un personal válido.";
                return;
            }

            int idPerfil = Convert.ToInt32(cmbRol.SelectedValue);
            int idPersonal = Convert.ToInt32(cmbPersonal.SelectedValue);

            try
            {
                // Validar si el usuario ya existe
                string sqlCheck = "SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = ?";
                long count = Convert.ToInt64(clsConexion.EjecutarEscalar(sqlCheck, new OleDbParameter[] { new OleDbParameter("?", usuario) }));

                if (count > 0)
                {
                    lblError.Text = "El nombre de usuario ya está registrado.";
                    return;
                }

                // Insertar nuevo usuario
                string sqlInsert = "INSERT INTO Usuarios (NombreUsuario, Contrasena, IdPerfil, IdPersonal, IntentosFallidos, LoginCount) VALUES (?, ?, ?, ?, 0, 0)";
                OleDbParameter[] parameters = new OleDbParameter[] {
                    new OleDbParameter("?", usuario),
                    new OleDbParameter("?", contrasena),
                    new OleDbParameter("?", idPerfil),
                    new OleDbParameter("?", idPersonal)
                };

                clsConexion.EjecutarConsulta(sqlInsert, parameters);

                MessageBox.Show("Usuario registrado exitosamente. Ahora puede iniciar sesión.", "Registro Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            pnlUserUnderline.BackColor = Color.FromArgb(129, 140, 248);
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            pnlUserUnderline.BackColor = Color.FromArgb(71, 85, 105);
        }

        private void txtContrasena_Enter(object sender, EventArgs e)
        {
            pnlPasswordUnderline.BackColor = Color.FromArgb(129, 140, 248);
        }

        private void txtContrasena_Leave(object sender, EventArgs e)
        {
            pnlPasswordUnderline.BackColor = Color.FromArgb(71, 85, 105);
        }
    }
}
