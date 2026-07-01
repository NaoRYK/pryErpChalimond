namespace pryErpChalimond
{
    partial class frmPersonal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPersonal));
            // Decorative / structural
            this.pnlAccent = new System.Windows.Forms.Panel();
            this.pnlHeaderSep = new System.Windows.Forms.Panel();
            this.pnlDivider = new System.Windows.Forms.Panel();
            this.pnlSectionDiv = new System.Windows.Forms.Panel();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblEmpleados = new System.Windows.Forms.Label();
            // Existing
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVerMapa = new System.Windows.Forms.Button();
            this.txtUbicacionGeografica = new System.Windows.Forms.TextBox();
            this.lblUbicacionGeografica = new System.Windows.Forms.Label();
            this.cmbLocalidad = new System.Windows.Forms.ComboBox();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.cmbProvincia = new System.Windows.Forms.ComboBox();
            this.lblProvincia = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.lblDni = new System.Windows.Forms.Label();
            this.lblDireccionesAdicionales = new System.Windows.Forms.Label();
            this.lstDireccionesAdicionales = new System.Windows.Forms.ListBox();
            this.txtDireccionAdicional = new System.Windows.Forms.TextBox();
            this.btnAgregarDireccionAdicional = new System.Windows.Forms.Button();
            this.btnEliminarDireccionAdicional = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGestionarUsuario = new System.Windows.Forms.Button();
            this.dgvPersonal = new System.Windows.Forms.DataGridView();
            this.pnlDatosContainer = new System.Windows.Forms.Panel();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.pnlContactoContainer = new System.Windows.Forms.Panel();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.btnEliminarContacto = new System.Windows.Forms.Button();
            this.btnAgregarContacto = new System.Windows.Forms.Button();
            this.dgvContactos = new System.Windows.Forms.DataGridView();
            this.btnTabDatos = new System.Windows.Forms.Button();
            this.btnTabContactos = new System.Windows.Forms.Button();
            this.pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonal)).BeginInit();
            this.pnlDatosContainer.SuspendLayout();
            this.pnlContactoContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactos)).BeginInit();
            this.SuspendLayout();

            // ── ACCENT STRIP ────────────────────────────────────────────────
            this.pnlAccent.BackColor = System.Drawing.Color.FromArgb(79, 70, 229);
            this.pnlAccent.Location = new System.Drawing.Point(0, 0);
            this.pnlAccent.Name = "pnlAccent";
            this.pnlAccent.Size = new System.Drawing.Size(4, 680);
            this.pnlAccent.TabIndex = 200;

            // ── TITLE ────────────────────────────────────────────────────────
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(18, 11);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Gestión de Personal";

            // ── SUBTITLE ─────────────────────────────────────────────────────
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblSubtitulo.Location = new System.Drawing.Point(20, 46);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.TabIndex = 201;
            this.lblSubtitulo.Text = "Administración de empleados y datos de contacto";

            // ── HEADER SEPARATOR ─────────────────────────────────────────────
            this.pnlHeaderSep.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.pnlHeaderSep.Location = new System.Drawing.Point(0, 66);
            this.pnlHeaderSep.Name = "pnlHeaderSep";
            this.pnlHeaderSep.Size = new System.Drawing.Size(860, 1);
            this.pnlHeaderSep.TabIndex = 202;

            // ── LIST SECTION LABEL ───────────────────────────────────────────
            this.lblEmpleados.AutoSize = true;
            this.lblEmpleados.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblEmpleados.ForeColor = System.Drawing.Color.White;
            this.lblEmpleados.Location = new System.Drawing.Point(10, 80);
            this.lblEmpleados.Name = "lblEmpleados";
            this.lblEmpleados.TabIndex = 203;
            this.lblEmpleados.Text = "LISTA DE EMPLEADOS";

            // ── VERTICAL DIVIDER ─────────────────────────────────────────────
            this.pnlDivider.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.pnlDivider.Location = new System.Drawing.Point(296, 66);
            this.pnlDivider.Name = "pnlDivider";
            this.pnlDivider.Size = new System.Drawing.Size(1, 614);
            this.pnlDivider.TabIndex = 204;

            // ── dgvPersonal ──────────────────────────────────────────────────
            this.dgvPersonal.AllowUserToAddRows = false;
            this.dgvPersonal.AllowUserToDeleteRows = false;
            this.dgvPersonal.AllowUserToResizeRows = false;
            this.dgvPersonal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPersonal.BackgroundColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.dgvPersonal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPersonal.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPersonal.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPersonal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPersonal.ColumnHeadersHeight = 38;
            this.dgvPersonal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(79, 70, 229);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPersonal.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPersonal.EnableHeadersVisualStyles = false;
            this.dgvPersonal.GridColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.dgvPersonal.Location = new System.Drawing.Point(10, 100);
            this.dgvPersonal.MultiSelect = false;
            this.dgvPersonal.Name = "dgvPersonal";
            this.dgvPersonal.ReadOnly = true;
            this.dgvPersonal.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPersonal.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPersonal.RowHeadersVisible = false;
            this.dgvPersonal.RowTemplate.Height = 36;
            this.dgvPersonal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPersonal.Size = new System.Drawing.Size(280, 570);
            this.dgvPersonal.TabIndex = 5;
            this.dgvPersonal.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPersonal_CellClick);

            // ── TAB BUTTONS ──────────────────────────────────────────────────
            this.btnTabDatos.BackColor = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnTabDatos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabDatos.FlatAppearance.BorderSize = 0;
            this.btnTabDatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabDatos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTabDatos.ForeColor = System.Drawing.Color.White;
            this.btnTabDatos.Location = new System.Drawing.Point(308, 74);
            this.btnTabDatos.Name = "btnTabDatos";
            this.btnTabDatos.Size = new System.Drawing.Size(165, 34);
            this.btnTabDatos.TabIndex = 6;
            this.btnTabDatos.Text = "Información Básica";
            this.btnTabDatos.UseVisualStyleBackColor = false;
            this.btnTabDatos.Click += new System.EventHandler(this.btnTabDatos_Click);

            this.btnTabContactos.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnTabContactos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabContactos.FlatAppearance.BorderSize = 0;
            this.btnTabContactos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabContactos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTabContactos.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.btnTabContactos.Location = new System.Drawing.Point(479, 74);
            this.btnTabContactos.Name = "btnTabContactos";
            this.btnTabContactos.Size = new System.Drawing.Size(120, 34);
            this.btnTabContactos.TabIndex = 7;
            this.btnTabContactos.Text = "Contactos";
            this.btnTabContactos.UseVisualStyleBackColor = false;
            this.btnTabContactos.Click += new System.EventHandler(this.btnTabContactos_Click);

            // ── pnlSectionDiv (inside pnlForm) ───────────────────────────────
            this.pnlSectionDiv.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.pnlSectionDiv.Location = new System.Drawing.Point(20, 316);
            this.pnlSectionDiv.Name = "pnlSectionDiv";
            this.pnlSectionDiv.Size = new System.Drawing.Size(502, 1);
            this.pnlSectionDiv.TabIndex = 100;

            // ── FIELD: DNI ────────────────────────────────────────────────────
            this.lblDni.AutoSize = true;
            this.lblDni.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDni.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblDni.Location = new System.Drawing.Point(20, 16);
            this.lblDni.Name = "lblDni";
            this.lblDni.TabIndex = 0;
            this.lblDni.Text = "DNI";

            this.txtDni.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.txtDni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDni.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDni.ForeColor = System.Drawing.Color.White;
            this.txtDni.Location = new System.Drawing.Point(20, 33);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(180, 25);
            this.txtDni.TabIndex = 1;

            this.chkActivo.AutoSize = true;
            this.chkActivo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.chkActivo.ForeColor = System.Drawing.Color.White;
            this.chkActivo.Location = new System.Drawing.Point(210, 36);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(66, 21);
            this.chkActivo.TabIndex = 9;
            this.chkActivo.Text = "Activo";
            this.chkActivo.BackColor = System.Drawing.Color.Transparent;
            this.chkActivo.UseVisualStyleBackColor = false;
            this.chkActivo.CheckedChanged += new System.EventHandler(this.chkActivo_CheckedChanged);

            // ── FIELD: Apellido + Nombre ──────────────────────────────────────
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblApellido.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblApellido.Location = new System.Drawing.Point(20, 74);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "Apellido";

            this.txtApellido.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.txtApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellido.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtApellido.ForeColor = System.Drawing.Color.White;
            this.txtApellido.Location = new System.Drawing.Point(20, 91);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(242, 25);
            this.txtApellido.TabIndex = 3;

            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblNombre.Location = new System.Drawing.Point(278, 74);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "Nombre";

            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombre.ForeColor = System.Drawing.Color.White;
            this.txtNombre.Location = new System.Drawing.Point(278, 91);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(244, 25);
            this.txtNombre.TabIndex = 5;

            // ── FIELD: Dirección ──────────────────────────────────────────────
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDireccion.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblDireccion.Location = new System.Drawing.Point(20, 134);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.TabIndex = 6;
            this.lblDireccion.Text = "Dirección";

            this.txtDireccion.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDireccion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDireccion.ForeColor = System.Drawing.Color.White;
            this.txtDireccion.Location = new System.Drawing.Point(20, 151);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(502, 25);
            this.txtDireccion.TabIndex = 7;

            // ── FIELD: Provincia + Localidad ──────────────────────────────────
            this.lblProvincia.AutoSize = true;
            this.lblProvincia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProvincia.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblProvincia.Location = new System.Drawing.Point(20, 194);
            this.lblProvincia.Name = "lblProvincia";
            this.lblProvincia.TabIndex = 8;
            this.lblProvincia.Text = "Provincia";

            this.cmbProvincia.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvincia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbProvincia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbProvincia.ForeColor = System.Drawing.Color.White;
            this.cmbProvincia.FormattingEnabled = true;
            this.cmbProvincia.Location = new System.Drawing.Point(20, 211);
            this.cmbProvincia.Name = "cmbProvincia";
            this.cmbProvincia.Size = new System.Drawing.Size(237, 25);
            this.cmbProvincia.TabIndex = 9;
            this.cmbProvincia.SelectedIndexChanged += new System.EventHandler(this.cmbProvincia_SelectedIndexChanged);

            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLocalidad.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblLocalidad.Location = new System.Drawing.Point(270, 194);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.TabIndex = 10;
            this.lblLocalidad.Text = "Localidad";

            this.cmbLocalidad.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.cmbLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocalidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbLocalidad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbLocalidad.ForeColor = System.Drawing.Color.White;
            this.cmbLocalidad.FormattingEnabled = true;
            this.cmbLocalidad.Location = new System.Drawing.Point(270, 211);
            this.cmbLocalidad.Name = "cmbLocalidad";
            this.cmbLocalidad.Size = new System.Drawing.Size(252, 25);
            this.cmbLocalidad.TabIndex = 11;

            // ── FIELD: Ubicación ──────────────────────────────────────────────
            this.lblUbicacionGeografica.AutoSize = true;
            this.lblUbicacionGeografica.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUbicacionGeografica.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblUbicacionGeografica.Location = new System.Drawing.Point(20, 254);
            this.lblUbicacionGeografica.Name = "lblUbicacionGeografica";
            this.lblUbicacionGeografica.TabIndex = 12;
            this.lblUbicacionGeografica.Text = "Ubicación (Coordenadas o Link Maps)";

            this.txtUbicacionGeografica.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.txtUbicacionGeografica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUbicacionGeografica.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUbicacionGeografica.ForeColor = System.Drawing.Color.White;
            this.txtUbicacionGeografica.Location = new System.Drawing.Point(20, 271);
            this.txtUbicacionGeografica.Name = "txtUbicacionGeografica";
            this.txtUbicacionGeografica.Size = new System.Drawing.Size(363, 25);
            this.txtUbicacionGeografica.TabIndex = 13;

            this.btnVerMapa.BackColor = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnVerMapa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerMapa.FlatAppearance.BorderSize = 0;
            this.btnVerMapa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerMapa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnVerMapa.ForeColor = System.Drawing.Color.White;
            this.btnVerMapa.Location = new System.Drawing.Point(395, 270);
            this.btnVerMapa.Name = "btnVerMapa";
            this.btnVerMapa.Size = new System.Drawing.Size(127, 27);
            this.btnVerMapa.TabIndex = 16;
            this.btnVerMapa.Text = "Ver Ubicación";
            this.btnVerMapa.UseVisualStyleBackColor = false;
            this.btnVerMapa.Click += new System.EventHandler(this.btnVerMapa_Click);

            // ── SECTION: Direcciones Adicionales ─────────────────────────────
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.label1.Location = new System.Drawing.Point(20, 326);
            this.label1.Name = "label1";
            this.label1.TabIndex = 22;
            this.label1.Text = "Agregar dirección adicional";

            this.txtDireccionAdicional.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.txtDireccionAdicional.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDireccionAdicional.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDireccionAdicional.ForeColor = System.Drawing.Color.White;
            this.txtDireccionAdicional.Location = new System.Drawing.Point(20, 343);
            this.txtDireccionAdicional.Name = "txtDireccionAdicional";
            this.txtDireccionAdicional.Size = new System.Drawing.Size(326, 25);
            this.txtDireccionAdicional.TabIndex = 19;

            this.btnEliminarDireccionAdicional.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnEliminarDireccionAdicional.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarDireccionAdicional.FlatAppearance.BorderSize = 0;
            this.btnEliminarDireccionAdicional.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarDireccionAdicional.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminarDireccionAdicional.ForeColor = System.Drawing.Color.White;
            this.btnEliminarDireccionAdicional.Location = new System.Drawing.Point(356, 342);
            this.btnEliminarDireccionAdicional.Name = "btnEliminarDireccionAdicional";
            this.btnEliminarDireccionAdicional.Size = new System.Drawing.Size(72, 27);
            this.btnEliminarDireccionAdicional.TabIndex = 21;
            this.btnEliminarDireccionAdicional.Text = "Borrar";
            this.btnEliminarDireccionAdicional.UseVisualStyleBackColor = false;
            this.btnEliminarDireccionAdicional.Click += new System.EventHandler(this.btnEliminarDireccionAdicional_Click);

            this.btnAgregarDireccionAdicional.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnAgregarDireccionAdicional.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarDireccionAdicional.FlatAppearance.BorderSize = 0;
            this.btnAgregarDireccionAdicional.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarDireccionAdicional.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarDireccionAdicional.ForeColor = System.Drawing.Color.White;
            this.btnAgregarDireccionAdicional.Location = new System.Drawing.Point(436, 342);
            this.btnAgregarDireccionAdicional.Name = "btnAgregarDireccionAdicional";
            this.btnAgregarDireccionAdicional.Size = new System.Drawing.Size(86, 27);
            this.btnAgregarDireccionAdicional.TabIndex = 20;
            this.btnAgregarDireccionAdicional.Text = "Agregar";
            this.btnAgregarDireccionAdicional.UseVisualStyleBackColor = false;
            this.btnAgregarDireccionAdicional.Click += new System.EventHandler(this.btnAgregarDireccionAdicional_Click);

            this.lblDireccionesAdicionales.AutoSize = true;
            this.lblDireccionesAdicionales.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDireccionesAdicionales.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblDireccionesAdicionales.Location = new System.Drawing.Point(20, 385);
            this.lblDireccionesAdicionales.Name = "lblDireccionesAdicionales";
            this.lblDireccionesAdicionales.TabIndex = 17;
            this.lblDireccionesAdicionales.Text = "Direcciones registradas";

            this.lstDireccionesAdicionales.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lstDireccionesAdicionales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstDireccionesAdicionales.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lstDireccionesAdicionales.ForeColor = System.Drawing.Color.White;
            this.lstDireccionesAdicionales.FormattingEnabled = true;
            this.lstDireccionesAdicionales.ItemHeight = 17;
            this.lstDireccionesAdicionales.Location = new System.Drawing.Point(20, 402);
            this.lstDireccionesAdicionales.Name = "lstDireccionesAdicionales";
            this.lstDireccionesAdicionales.Size = new System.Drawing.Size(502, 58);
            this.lstDireccionesAdicionales.TabIndex = 18;

            // ── pnlForm ───────────────────────────────────────────────────────
            this.pnlForm.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlForm.Controls.Add(this.pnlSectionDiv);
            this.pnlForm.Controls.Add(this.chkActivo);
            this.pnlForm.Controls.Add(this.label1);
            this.pnlForm.Controls.Add(this.btnVerMapa);
            this.pnlForm.Controls.Add(this.txtUbicacionGeografica);
            this.pnlForm.Controls.Add(this.lblUbicacionGeografica);
            this.pnlForm.Controls.Add(this.cmbLocalidad);
            this.pnlForm.Controls.Add(this.lblLocalidad);
            this.pnlForm.Controls.Add(this.cmbProvincia);
            this.pnlForm.Controls.Add(this.lblProvincia);
            this.pnlForm.Controls.Add(this.txtDireccion);
            this.pnlForm.Controls.Add(this.lblDireccion);
            this.pnlForm.Controls.Add(this.txtNombre);
            this.pnlForm.Controls.Add(this.lblNombre);
            this.pnlForm.Controls.Add(this.txtApellido);
            this.pnlForm.Controls.Add(this.lblApellido);
            this.pnlForm.Controls.Add(this.txtDni);
            this.pnlForm.Controls.Add(this.lblDni);
            this.pnlForm.Controls.Add(this.lblDireccionesAdicionales);
            this.pnlForm.Controls.Add(this.lstDireccionesAdicionales);
            this.pnlForm.Controls.Add(this.txtDireccionAdicional);
            this.pnlForm.Controls.Add(this.btnAgregarDireccionAdicional);
            this.pnlForm.Controls.Add(this.btnEliminarDireccionAdicional);
            this.pnlForm.Location = new System.Drawing.Point(0, 0);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(542, 468);
            this.pnlForm.TabIndex = 1;

            // ── ACTION BUTTONS ────────────────────────────────────────────────
            // Row 1 — Nuevo/Editar swap at same Y (476), Guardar overlaps Editar
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(10, 476);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(130, 38);
            this.btnNuevo.TabIndex = 25;
            this.btnNuevo.Text = "Nuevo Empleado";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);

            // btnLimpiar at SAME position as btnNuevo — they swap on edit mode
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(10, 476);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(130, 38);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Cancelar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(150, 476);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(130, 38);
            this.btnEditar.TabIndex = 24;
            this.btnEditar.Text = "Editar Datos";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            // btnGuardar at SAME position as btnEditar — they swap on edit mode
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(34, 197, 94);
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(150, 476);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(130, 38);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar Personal";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // Row 2 — Eliminar + Gestionar Usuario
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(10, 522);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(130, 38);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            this.btnGestionarUsuario.BackColor = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnGestionarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGestionarUsuario.FlatAppearance.BorderSize = 0;
            this.btnGestionarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionarUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGestionarUsuario.ForeColor = System.Drawing.Color.White;
            this.btnGestionarUsuario.Location = new System.Drawing.Point(150, 522);
            this.btnGestionarUsuario.Name = "btnGestionarUsuario";
            this.btnGestionarUsuario.Size = new System.Drawing.Size(382, 38);
            this.btnGestionarUsuario.TabIndex = 23;
            this.btnGestionarUsuario.Text = "Crear Cuenta de Usuario";
            this.btnGestionarUsuario.UseVisualStyleBackColor = false;
            this.btnGestionarUsuario.Click += new System.EventHandler(this.btnGestionarUsuario_Click);

            // ── pnlDatosContainer ─────────────────────────────────────────────
            this.pnlDatosContainer.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlDatosContainer.Controls.Add(this.pnlForm);
            this.pnlDatosContainer.Controls.Add(this.btnNuevo);
            this.pnlDatosContainer.Controls.Add(this.btnLimpiar);
            this.pnlDatosContainer.Controls.Add(this.btnEditar);
            this.pnlDatosContainer.Controls.Add(this.btnGuardar);
            this.pnlDatosContainer.Controls.Add(this.btnEliminar);
            this.pnlDatosContainer.Controls.Add(this.btnGestionarUsuario);
            this.pnlDatosContainer.Location = new System.Drawing.Point(308, 112);
            this.pnlDatosContainer.Name = "pnlDatosContainer";
            this.pnlDatosContainer.Size = new System.Drawing.Size(542, 568);
            this.pnlDatosContainer.TabIndex = 1;

            // ── CONTACTO PANEL ────────────────────────────────────────────────
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTipo.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblTipo.Location = new System.Drawing.Point(20, 10);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.TabIndex = 0;
            this.lblTipo.Text = "Tipo";

            this.cmbTipo.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTipo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTipo.ForeColor = System.Drawing.Color.White;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(20, 27);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(120, 25);
            this.cmbTipo.TabIndex = 1;

            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblValor.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblValor.Location = new System.Drawing.Point(152, 10);
            this.lblValor.Name = "lblValor";
            this.lblValor.TabIndex = 2;
            this.lblValor.Text = "Valor (Contacto / Enlace)";

            this.txtValor.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.txtValor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtValor.ForeColor = System.Drawing.Color.White;
            this.txtValor.Location = new System.Drawing.Point(152, 27);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(218, 25);
            this.txtValor.TabIndex = 3;

            this.btnEliminarContacto.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnEliminarContacto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarContacto.FlatAppearance.BorderSize = 0;
            this.btnEliminarContacto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarContacto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminarContacto.ForeColor = System.Drawing.Color.White;
            this.btnEliminarContacto.Location = new System.Drawing.Point(382, 26);
            this.btnEliminarContacto.Name = "btnEliminarContacto";
            this.btnEliminarContacto.Size = new System.Drawing.Size(76, 27);
            this.btnEliminarContacto.TabIndex = 5;
            this.btnEliminarContacto.Text = "Eliminar";
            this.btnEliminarContacto.UseVisualStyleBackColor = false;
            this.btnEliminarContacto.Click += new System.EventHandler(this.btnEliminarContacto_Click);

            this.btnAgregarContacto.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnAgregarContacto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarContacto.FlatAppearance.BorderSize = 0;
            this.btnAgregarContacto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarContacto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarContacto.ForeColor = System.Drawing.Color.White;
            this.btnAgregarContacto.Location = new System.Drawing.Point(466, 26);
            this.btnAgregarContacto.Name = "btnAgregarContacto";
            this.btnAgregarContacto.Size = new System.Drawing.Size(76, 27);
            this.btnAgregarContacto.TabIndex = 4;
            this.btnAgregarContacto.Text = "Agregar";
            this.btnAgregarContacto.UseVisualStyleBackColor = false;
            this.btnAgregarContacto.Click += new System.EventHandler(this.btnAgregarContacto_Click);

            this.dgvContactos.AllowUserToAddRows = false;
            this.dgvContactos.AllowUserToDeleteRows = false;
            this.dgvContactos.AllowUserToResizeRows = false;
            this.dgvContactos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContactos.BackgroundColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.dgvContactos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvContactos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvContactos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvContactos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvContactos.ColumnHeadersHeight = 38;
            this.dgvContactos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvContactos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvContactos.EnableHeadersVisualStyles = false;
            this.dgvContactos.GridColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.dgvContactos.Location = new System.Drawing.Point(20, 72);
            this.dgvContactos.MultiSelect = false;
            this.dgvContactos.Name = "dgvContactos";
            this.dgvContactos.ReadOnly = true;
            this.dgvContactos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvContactos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvContactos.RowHeadersVisible = false;
            this.dgvContactos.RowTemplate.Height = 36;
            this.dgvContactos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContactos.Size = new System.Drawing.Size(502, 486);
            this.dgvContactos.TabIndex = 7;

            // ── pnlContactoContainer ──────────────────────────────────────────
            this.pnlContactoContainer.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlContactoContainer.Controls.Add(this.lblTipo);
            this.pnlContactoContainer.Controls.Add(this.cmbTipo);
            this.pnlContactoContainer.Controls.Add(this.lblValor);
            this.pnlContactoContainer.Controls.Add(this.txtValor);
            this.pnlContactoContainer.Controls.Add(this.btnEliminarContacto);
            this.pnlContactoContainer.Controls.Add(this.btnAgregarContacto);
            this.pnlContactoContainer.Controls.Add(this.dgvContactos);
            this.pnlContactoContainer.Location = new System.Drawing.Point(308, 112);
            this.pnlContactoContainer.Name = "pnlContactoContainer";
            this.pnlContactoContainer.Size = new System.Drawing.Size(542, 568);
            this.pnlContactoContainer.TabIndex = 8;
            this.pnlContactoContainer.Visible = false;

            // ── FORM ──────────────────────────────────────────────────────────
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.ClientSize = new System.Drawing.Size(860, 680);
            this.Controls.Add(this.pnlAccent);
            this.Controls.Add(this.pnlHeaderSep);
            this.Controls.Add(this.pnlDivider);
            this.Controls.Add(this.lblEmpleados);
            this.Controls.Add(this.dgvPersonal);
            this.Controls.Add(this.pnlDatosContainer);
            this.Controls.Add(this.pnlContactoContainer);
            this.Controls.Add(this.btnTabDatos);
            this.Controls.Add(this.btnTabContactos);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPersonal";
            this.Text = "frmPersonal";
            this.Load += new System.EventHandler(this.frmPersonal_Load);
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonal)).EndInit();
            this.pnlDatosContainer.ResumeLayout(false);
            this.pnlContactoContainer.ResumeLayout(false);
            this.pnlContactoContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlAccent;
        private System.Windows.Forms.Panel pnlHeaderSep;
        private System.Windows.Forms.Panel pnlDivider;
        private System.Windows.Forms.Panel pnlSectionDiv;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblEmpleados;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.ComboBox cmbProvincia;
        private System.Windows.Forms.Label lblProvincia;
        private System.Windows.Forms.ComboBox cmbLocalidad;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.TextBox txtUbicacionGeografica;
        private System.Windows.Forms.Label lblUbicacionGeografica;
        private System.Windows.Forms.Button btnVerMapa;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvPersonal;
        private System.Windows.Forms.Panel pnlDatosContainer;
        private System.Windows.Forms.Panel pnlContactoContainer;
        private System.Windows.Forms.Button btnTabDatos;
        private System.Windows.Forms.Button btnTabContactos;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Button btnAgregarContacto;
        private System.Windows.Forms.Button btnEliminarContacto;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.DataGridView dgvContactos;
        private System.Windows.Forms.Label lblDireccionesAdicionales;
        private System.Windows.Forms.ListBox lstDireccionesAdicionales;
        private System.Windows.Forms.TextBox txtDireccionAdicional;
        private System.Windows.Forms.Button btnAgregarDireccionAdicional;
        private System.Windows.Forms.Button btnEliminarDireccionAdicional;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGestionarUsuario;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnNuevo;
    }
}
