namespace pryErpChalimond
{
    partial class frmUsuarios
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.pnlEditar = new System.Windows.Forms.Panel();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.cmbPersonalAsociar = new System.Windows.Forms.ComboBox();
            this.lblPersonalAsociar = new System.Windows.Forms.Label();
            this.chkEsAdmin = new System.Windows.Forms.CheckBox();
            this.txtUsuarioSel = new System.Windows.Forms.TextBox();
            this.lblUsuarioSel = new System.Windows.Forms.Label();
            this.lblTituloEditar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.pnlEditar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(35, 30);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(277, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Gestión de Usuarios";
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AllowUserToResizeRows = false;
            this.dgvUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsuarios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUsuarios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsuarios.ColumnHeadersHeight = 35;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsuarios.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUsuarios.EnableHeadersVisualStyles = false;
            this.dgvUsuarios.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.dgvUsuarios.Location = new System.Drawing.Point(40, 95);
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsuarios.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUsuarios.RowHeadersVisible = false;
            this.dgvUsuarios.RowHeadersWidth = 40;
            this.dgvUsuarios.RowTemplate.Height = 35;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(460, 480);
            this.dgvUsuarios.TabIndex = 1;
            this.dgvUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellClick);
            // 
            // pnlEditar
            // 
            this.pnlEditar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlEditar.Controls.Add(this.btnLimpiar);
            this.pnlEditar.Controls.Add(this.btnGuardar);
            this.pnlEditar.Controls.Add(this.cmbPersonalAsociar);
            this.pnlEditar.Controls.Add(this.lblPersonalAsociar);
            this.pnlEditar.Controls.Add(this.chkEsAdmin);
            this.pnlEditar.Controls.Add(this.txtUsuarioSel);
            this.pnlEditar.Controls.Add(this.lblUsuarioSel);
            this.pnlEditar.Controls.Add(this.lblTituloEditar);
            this.pnlEditar.Location = new System.Drawing.Point(520, 95);
            this.pnlEditar.Name = "pnlEditar";
            this.pnlEditar.Size = new System.Drawing.Size(288, 480);
            this.pnlEditar.TabIndex = 2;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(25, 340);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(238, 38);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Cancelar / Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(25, 290);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(238, 40);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar Cambios";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cmbPersonalAsociar
            // 
            this.cmbPersonalAsociar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.cmbPersonalAsociar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPersonalAsociar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPersonalAsociar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbPersonalAsociar.ForeColor = System.Drawing.Color.White;
            this.cmbPersonalAsociar.FormattingEnabled = true;
            this.cmbPersonalAsociar.Location = new System.Drawing.Point(25, 215);
            this.cmbPersonalAsociar.Name = "cmbPersonalAsociar";
            this.cmbPersonalAsociar.Size = new System.Drawing.Size(238, 25);
            this.cmbPersonalAsociar.TabIndex = 5;
            // 
            // lblPersonalAsociar
            // 
            this.lblPersonalAsociar.AutoSize = true;
            this.lblPersonalAsociar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPersonalAsociar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblPersonalAsociar.Location = new System.Drawing.Point(22, 190);
            this.lblPersonalAsociar.Name = "lblPersonalAsociar";
            this.lblPersonalAsociar.Size = new System.Drawing.Size(115, 17);
            this.lblPersonalAsociar.TabIndex = 4;
            this.lblPersonalAsociar.Text = "Asociar a Personal:";
            // 
            // chkEsAdmin
            // 
            this.chkEsAdmin.AutoSize = true;
            this.chkEsAdmin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.chkEsAdmin.ForeColor = System.Drawing.Color.White;
            this.chkEsAdmin.Location = new System.Drawing.Point(25, 145);
            this.chkEsAdmin.Name = "chkEsAdmin";
            this.chkEsAdmin.Size = new System.Drawing.Size(124, 23);
            this.chkEsAdmin.TabIndex = 3;
            this.chkEsAdmin.Text = "Administrador";
            this.chkEsAdmin.UseVisualStyleBackColor = true;
            // 
            // txtUsuarioSel
            // 
            this.txtUsuarioSel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtUsuarioSel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuarioSel.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtUsuarioSel.ForeColor = System.Drawing.Color.White;
            this.txtUsuarioSel.Location = new System.Drawing.Point(25, 95);
            this.txtUsuarioSel.Name = "txtUsuarioSel";
            this.txtUsuarioSel.ReadOnly = true;
            this.txtUsuarioSel.Size = new System.Drawing.Size(238, 26);
            this.txtUsuarioSel.TabIndex = 2;
            // 
            // lblUsuarioSel
            // 
            this.lblUsuarioSel.AutoSize = true;
            this.lblUsuarioSel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUsuarioSel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblUsuarioSel.Location = new System.Drawing.Point(22, 70);
            this.lblUsuarioSel.Name = "lblUsuarioSel";
            this.lblUsuarioSel.Size = new System.Drawing.Size(133, 17);
            this.lblUsuarioSel.TabIndex = 1;
            this.lblUsuarioSel.Text = "Usuario Seleccionado:";
            // 
            // lblTituloEditar
            // 
            this.lblTituloEditar.AutoSize = true;
            this.lblTituloEditar.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTituloEditar.ForeColor = System.Drawing.Color.White;
            this.lblTituloEditar.Location = new System.Drawing.Point(20, 20);
            this.lblTituloEditar.Name = "lblTituloEditar";
            this.lblTituloEditar.Size = new System.Drawing.Size(168, 25);
            this.lblTituloEditar.TabIndex = 0;
            this.lblTituloEditar.Text = "Modificar Usuario";
            // 
            // frmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(848, 607);
            this.Controls.Add(this.pnlEditar);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUsuarios";
            this.Text = "frmUsuarios";
            this.Load += new System.EventHandler(this.frmUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.pnlEditar.ResumeLayout(false);
            this.pnlEditar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Panel pnlEditar;
        private System.Windows.Forms.Label lblTituloEditar;
        private System.Windows.Forms.Label lblUsuarioSel;
        private System.Windows.Forms.TextBox txtUsuarioSel;
        private System.Windows.Forms.CheckBox chkEsAdmin;
        private System.Windows.Forms.Label lblPersonalAsociar;
        private System.Windows.Forms.ComboBox cmbPersonalAsociar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiar;
    }
}
