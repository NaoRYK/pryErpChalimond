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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlForm = new System.Windows.Forms.Panel();
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
            this.dgvPersonal = new System.Windows.Forms.DataGridView();
            this.pnlDatosContainer = new System.Windows.Forms.Panel();
            this.pnlContactoContainer = new System.Windows.Forms.Panel();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.btnAgregarContacto = new System.Windows.Forms.Button();
            this.btnEliminarContacto = new System.Windows.Forms.Button();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.dgvContactos = new System.Windows.Forms.DataGridView();
            this.btnTabDatos = new System.Windows.Forms.Button();
            this.btnTabContactos = new System.Windows.Forms.Button();
            this.pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonal)).BeginInit();
            this.pnlDatosContainer.SuspendLayout();
            this.pnlContactoContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(35, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(271, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Gestión de Personal";
            // 
            // pnlForm
            // 
            this.pnlForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
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
            this.pnlForm.Size = new System.Drawing.Size(760, 285);
            this.pnlForm.TabIndex = 1;
            // 
            // lblDireccionesAdicionales
            // 
            this.lblDireccionesAdicionales.AutoSize = true;
            this.lblDireccionesAdicionales.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDireccionesAdicionales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblDireccionesAdicionales.Location = new System.Drawing.Point(17, 200);
            this.lblDireccionesAdicionales.Name = "lblDireccionesAdicionales";
            this.lblDireccionesAdicionales.Size = new System.Drawing.Size(135, 15);
            this.lblDireccionesAdicionales.TabIndex = 17;
            this.lblDireccionesAdicionales.Text = "Direcciones Adicionales";
            // 
            // lstDireccionesAdicionales
            // 
            this.lstDireccionesAdicionales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lstDireccionesAdicionales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstDireccionesAdicionales.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lstDireccionesAdicionales.ForeColor = System.Drawing.Color.White;
            this.lstDireccionesAdicionales.FormattingEnabled = true;
            this.lstDireccionesAdicionales.ItemHeight = 17;
            this.lstDireccionesAdicionales.Location = new System.Drawing.Point(20, 220);
            this.lstDireccionesAdicionales.Name = "lstDireccionesAdicionales";
            this.lstDireccionesAdicionales.Size = new System.Drawing.Size(400, 53);
            this.lstDireccionesAdicionales.TabIndex = 18;
            // 
            // txtDireccionAdicional
            // 
            this.txtDireccionAdicional.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtDireccionAdicional.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDireccionAdicional.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDireccionAdicional.ForeColor = System.Drawing.Color.White;
            this.txtDireccionAdicional.Location = new System.Drawing.Point(430, 220);
            this.txtDireccionAdicional.Name = "txtDireccionAdicional";
            this.txtDireccionAdicional.Size = new System.Drawing.Size(200, 25);
            this.txtDireccionAdicional.TabIndex = 19;
            // 
            // btnAgregarDireccionAdicional
            // 
            this.btnAgregarDireccionAdicional.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnAgregarDireccionAdicional.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarDireccionAdicional.FlatAppearance.BorderSize = 0;
            this.btnAgregarDireccionAdicional.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarDireccionAdicional.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarDireccionAdicional.ForeColor = System.Drawing.Color.White;
            this.btnAgregarDireccionAdicional.Location = new System.Drawing.Point(640, 219);
            this.btnAgregarDireccionAdicional.Name = "btnAgregarDireccionAdicional";
            this.btnAgregarDireccionAdicional.Size = new System.Drawing.Size(50, 27);
            this.btnAgregarDireccionAdicional.TabIndex = 20;
            this.btnAgregarDireccionAdicional.Text = "Agregar";
            this.btnAgregarDireccionAdicional.UseVisualStyleBackColor = false;
            this.btnAgregarDireccionAdicional.Click += new System.EventHandler(this.btnAgregarDireccionAdicional_Click);
            // 
            // btnEliminarDireccionAdicional
            // 
            this.btnEliminarDireccionAdicional.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnEliminarDireccionAdicional.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarDireccionAdicional.FlatAppearance.BorderSize = 0;
            this.btnEliminarDireccionAdicional.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarDireccionAdicional.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminarDireccionAdicional.ForeColor = System.Drawing.Color.White;
            this.btnEliminarDireccionAdicional.Location = new System.Drawing.Point(695, 219);
            this.btnEliminarDireccionAdicional.Name = "btnEliminarDireccionAdicional";
            this.btnEliminarDireccionAdicional.Size = new System.Drawing.Size(45, 27);
            this.btnEliminarDireccionAdicional.TabIndex = 21;
            this.btnEliminarDireccionAdicional.Text = "Borrar";
            this.btnEliminarDireccionAdicional.UseVisualStyleBackColor = false;
            this.btnEliminarDireccionAdicional.Click += new System.EventHandler(this.btnEliminarDireccionAdicional_Click);
            // 
            // btnVerMapa
            // 
            this.btnVerMapa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnVerMapa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerMapa.FlatAppearance.BorderSize = 0;
            this.btnVerMapa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerMapa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnVerMapa.ForeColor = System.Drawing.Color.White;
            this.btnVerMapa.Location = new System.Drawing.Point(600, 160);
            this.btnVerMapa.Name = "btnVerMapa";
            this.btnVerMapa.Size = new System.Drawing.Size(130, 27);
            this.btnVerMapa.TabIndex = 16;
            this.btnVerMapa.Text = "Ver Ubicación";
            this.btnVerMapa.UseVisualStyleBackColor = false;
            this.btnVerMapa.Click += new System.EventHandler(this.btnVerMapa_Click);
            // 
            // txtUbicacionGeografica
            // 
            this.txtUbicacionGeografica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtUbicacionGeografica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUbicacionGeografica.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUbicacionGeografica.ForeColor = System.Drawing.Color.White;
            this.txtUbicacionGeografica.Location = new System.Drawing.Point(380, 160);
            this.txtUbicacionGeografica.Name = "txtUbicacionGeografica";
            this.txtUbicacionGeografica.Size = new System.Drawing.Size(210, 25);
            this.txtUbicacionGeografica.TabIndex = 13;
            // 
            // lblUbicacionGeografica
            // 
            this.lblUbicacionGeografica.AutoSize = true;
            this.lblUbicacionGeografica.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUbicacionGeografica.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblUbicacionGeografica.Location = new System.Drawing.Point(377, 140);
            this.lblUbicacionGeografica.Name = "lblUbicacionGeografica";
            this.lblUbicacionGeografica.Size = new System.Drawing.Size(211, 15);
            this.lblUbicacionGeografica.TabIndex = 12;
            this.lblUbicacionGeografica.Text = "Ubicación (Coordenadas o Link Maps)";
            // 
            // cmbLocalidad
            // 
            this.cmbLocalidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.cmbLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocalidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbLocalidad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbLocalidad.ForeColor = System.Drawing.Color.White;
            this.cmbLocalidad.FormattingEnabled = true;
            this.cmbLocalidad.Location = new System.Drawing.Point(200, 160);
            this.cmbLocalidad.Name = "cmbLocalidad";
            this.cmbLocalidad.Size = new System.Drawing.Size(160, 25);
            this.cmbLocalidad.TabIndex = 11;
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLocalidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblLocalidad.Location = new System.Drawing.Point(197, 140);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(58, 15);
            this.lblLocalidad.TabIndex = 10;
            this.lblLocalidad.Text = "Localidad";
            // 
            // cmbProvincia
            // 
            this.cmbProvincia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvincia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbProvincia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbProvincia.ForeColor = System.Drawing.Color.White;
            this.cmbProvincia.FormattingEnabled = true;
            this.cmbProvincia.Location = new System.Drawing.Point(20, 160);
            this.cmbProvincia.Name = "cmbProvincia";
            this.cmbProvincia.Size = new System.Drawing.Size(160, 25);
            this.cmbProvincia.TabIndex = 9;
            this.cmbProvincia.SelectedIndexChanged += new System.EventHandler(this.cmbProvincia_SelectedIndexChanged);
            // 
            // lblProvincia
            // 
            this.lblProvincia.AutoSize = true;
            this.lblProvincia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProvincia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblProvincia.Location = new System.Drawing.Point(17, 140);
            this.lblProvincia.Name = "lblProvincia";
            this.lblProvincia.Size = new System.Drawing.Size(58, 15);
            this.lblProvincia.TabIndex = 8;
            this.lblProvincia.Text = "Provincia";
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDireccion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDireccion.ForeColor = System.Drawing.Color.White;
            this.txtDireccion.Location = new System.Drawing.Point(20, 100);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(710, 25);
            this.txtDireccion.TabIndex = 7;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDireccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblDireccion.Location = new System.Drawing.Point(17, 80);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(60, 15);
            this.lblDireccion.TabIndex = 6;
            this.lblDireccion.Text = "Dirección";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombre.ForeColor = System.Drawing.Color.White;
            this.txtNombre.Location = new System.Drawing.Point(500, 40);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(230, 25);
            this.txtNombre.TabIndex = 5;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblNombre.Location = new System.Drawing.Point(497, 20);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(53, 15);
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "Nombre";
            // 
            // txtApellido
            // 
            this.txtApellido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellido.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtApellido.ForeColor = System.Drawing.Color.White;
            this.txtApellido.Location = new System.Drawing.Point(240, 40);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(240, 25);
            this.txtApellido.TabIndex = 3;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblApellido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblApellido.Location = new System.Drawing.Point(237, 20);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(52, 15);
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "Apellido";
            // 
            // txtDni
            // 
            this.txtDni.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtDni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDni.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDni.ForeColor = System.Drawing.Color.White;
            this.txtDni.Location = new System.Drawing.Point(20, 40);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(200, 25);
            this.txtDni.TabIndex = 1;
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDni.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblDni.Location = new System.Drawing.Point(17, 20);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(29, 15);
            this.lblDni.TabIndex = 0;
            this.lblDni.Text = "DNI";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(0, 295);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(150, 35);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar Personal";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(165, 295);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(120, 35);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(640, 295);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(120, 35);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dgvPersonal
            // 
            this.dgvPersonal.AllowUserToAddRows = false;
            this.dgvPersonal.AllowUserToDeleteRows = false;
            this.dgvPersonal.AllowUserToResizeRows = false;
            this.dgvPersonal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPersonal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPersonal.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvPersonal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPersonal.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPersonal.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPersonal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPersonal.ColumnHeadersHeight = 35;
            this.dgvPersonal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPersonal.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPersonal.EnableHeadersVisualStyles = false;
            this.dgvPersonal.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.dgvPersonal.Location = new System.Drawing.Point(40, 420);
            this.dgvPersonal.MultiSelect = false;
            this.dgvPersonal.Name = "dgvPersonal";
            this.dgvPersonal.ReadOnly = true;
            this.dgvPersonal.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPersonal.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPersonal.RowHeadersVisible = false;
            this.dgvPersonal.RowTemplate.Height = 35;
            this.dgvPersonal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPersonal.Size = new System.Drawing.Size(760, 180);
            this.dgvPersonal.TabIndex = 5;
            this.dgvPersonal.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPersonal_CellClick);
            // 
            // pnlDatosContainer
            // 
            this.pnlDatosContainer.Controls.Add(this.pnlForm);
            this.pnlDatosContainer.Controls.Add(this.btnGuardar);
            this.pnlDatosContainer.Controls.Add(this.btnLimpiar);
            this.pnlDatosContainer.Controls.Add(this.btnEliminar);
            this.pnlDatosContainer.Location = new System.Drawing.Point(40, 75);
            this.pnlDatosContainer.Name = "pnlDatosContainer";
            this.pnlDatosContainer.Size = new System.Drawing.Size(760, 335);
            this.pnlDatosContainer.TabIndex = 1;
            // 
            // pnlContactoContainer
            // 
            this.pnlContactoContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlContactoContainer.Controls.Add(this.lblTipo);
            this.pnlContactoContainer.Controls.Add(this.cmbTipo);
            this.pnlContactoContainer.Controls.Add(this.lblValor);
            this.pnlContactoContainer.Controls.Add(this.txtValor);
            this.pnlContactoContainer.Controls.Add(this.btnAgregarContacto);
            this.pnlContactoContainer.Controls.Add(this.btnEliminarContacto);
            this.pnlContactoContainer.Controls.Add(this.dgvContactos);
            this.pnlContactoContainer.Location = new System.Drawing.Point(40, 75);
            this.pnlContactoContainer.Name = "pnlContactoContainer";
            this.pnlContactoContainer.Size = new System.Drawing.Size(760, 335);
            this.pnlContactoContainer.TabIndex = 8;
            this.pnlContactoContainer.Visible = false;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblTipo.Location = new System.Drawing.Point(17, 10);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(101, 15);
            this.lblTipo.TabIndex = 0;
            this.lblTipo.Text = "Tipo de Contacto";
            // 
            // cmbTipo
            // 
            this.cmbTipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTipo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTipo.ForeColor = System.Drawing.Color.White;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(20, 30);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(150, 25);
            this.cmbTipo.TabIndex = 1;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblValor.Location = new System.Drawing.Point(182, 10);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(154, 15);
            this.lblValor.TabIndex = 2;
            this.lblValor.Text = "Valor (Contacto/Dirección)";
            // 
            // txtValor
            // 
            this.txtValor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtValor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtValor.ForeColor = System.Drawing.Color.White;
            this.txtValor.Location = new System.Drawing.Point(185, 30);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(250, 25);
            this.txtValor.TabIndex = 3;
            // 
            // btnAgregarContacto
            // 
            this.btnAgregarContacto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnAgregarContacto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarContacto.FlatAppearance.BorderSize = 0;
            this.btnAgregarContacto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarContacto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarContacto.ForeColor = System.Drawing.Color.White;
            this.btnAgregarContacto.Location = new System.Drawing.Point(450, 29);
            this.btnAgregarContacto.Name = "btnAgregarContacto";
            this.btnAgregarContacto.Size = new System.Drawing.Size(90, 27);
            this.btnAgregarContacto.TabIndex = 4;
            this.btnAgregarContacto.Text = "Agregar";
            this.btnAgregarContacto.UseVisualStyleBackColor = false;
            this.btnAgregarContacto.Click += new System.EventHandler(this.btnAgregarContacto_Click);
            // 
            // btnEliminarContacto
            // 
            this.btnEliminarContacto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnEliminarContacto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarContacto.FlatAppearance.BorderSize = 0;
            this.btnEliminarContacto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarContacto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminarContacto.ForeColor = System.Drawing.Color.White;
            this.btnEliminarContacto.Location = new System.Drawing.Point(550, 29);
            this.btnEliminarContacto.Name = "btnEliminarContacto";
            this.btnEliminarContacto.Size = new System.Drawing.Size(90, 27);
            this.btnEliminarContacto.TabIndex = 5;
            this.btnEliminarContacto.Text = "Eliminar";
            this.btnEliminarContacto.UseVisualStyleBackColor = false;
            this.btnEliminarContacto.Click += new System.EventHandler(this.btnEliminarContacto_Click);
            // 
            // dgvContactos
            // 
            this.dgvContactos.AllowUserToAddRows = false;
            this.dgvContactos.AllowUserToDeleteRows = false;
            this.dgvContactos.AllowUserToResizeRows = false;
            this.dgvContactos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContactos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvContactos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvContactos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvContactos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvContactos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvContactos.ColumnHeadersHeight = 35;
            this.dgvContactos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvContactos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvContactos.EnableHeadersVisualStyles = false;
            this.dgvContactos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.dgvContactos.Location = new System.Drawing.Point(20, 75);
            this.dgvContactos.MultiSelect = false;
            this.dgvContactos.Name = "dgvContactos";
            this.dgvContactos.ReadOnly = true;
            this.dgvContactos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvContactos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvContactos.RowHeadersVisible = false;
            this.dgvContactos.RowTemplate.Height = 35;
            this.dgvContactos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContactos.Size = new System.Drawing.Size(720, 245);
            this.dgvContactos.TabIndex = 7;
            // 
            // btnTabDatos
            // 
            this.btnTabDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnTabDatos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabDatos.FlatAppearance.BorderSize = 0;
            this.btnTabDatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabDatos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTabDatos.ForeColor = System.Drawing.Color.White;
            this.btnTabDatos.Location = new System.Drawing.Point(460, 20);
            this.btnTabDatos.Name = "btnTabDatos";
            this.btnTabDatos.Size = new System.Drawing.Size(160, 35);
            this.btnTabDatos.TabIndex = 6;
            this.btnTabDatos.Text = "Información Básica";
            this.btnTabDatos.UseVisualStyleBackColor = false;
            this.btnTabDatos.Click += new System.EventHandler(this.btnTabDatos_Click);
            // 
            // btnTabContactos
            // 
            this.btnTabContactos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnTabContactos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabContactos.FlatAppearance.BorderSize = 0;
            this.btnTabContactos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabContactos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTabContactos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnTabContactos.Location = new System.Drawing.Point(630, 20);
            this.btnTabContactos.Name = "btnTabContactos";
            this.btnTabContactos.Size = new System.Drawing.Size(120, 35);
            this.btnTabContactos.TabIndex = 7;
            this.btnTabContactos.Text = "Contactos";
            this.btnTabContactos.UseVisualStyleBackColor = false;
            this.btnTabContactos.Click += new System.EventHandler(this.btnTabContactos_Click);
            // 
            // frmPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.AcceptButton = this.btnGuardar;
            this.ClientSize = new System.Drawing.Size(848, 640);
            this.Controls.Add(this.dgvPersonal);
            this.Controls.Add(this.pnlDatosContainer);
            this.Controls.Add(this.pnlContactoContainer);
            this.Controls.Add(this.btnTabDatos);
            this.Controls.Add(this.btnTabContactos);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.chkActivo);
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
    }
}
