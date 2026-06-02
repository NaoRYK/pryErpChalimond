namespace pryErpChalimond
{
    partial class frmDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDashboard));
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblWelcomeSub = new System.Windows.Forms.Label();
            this.pnlStatPersonal = new System.Windows.Forms.Panel();
            this.lblPersonalCount = new System.Windows.Forms.Label();
            this.lblPersonalTitle = new System.Windows.Forms.Label();
            this.pnlStatUsuarios = new System.Windows.Forms.Panel();
            this.lblUsuariosCount = new System.Windows.Forms.Label();
            this.lblUsuariosTitle = new System.Windows.Forms.Label();
            this.pnlStatAuditoria = new System.Windows.Forms.Panel();
            this.lblAuditoriaCount = new System.Windows.Forms.Label();
            this.lblAuditoriaTitle = new System.Windows.Forms.Label();
            this.lblInfoSystem = new System.Windows.Forms.Label();
            this.pnlStatPersonal.SuspendLayout();
            this.pnlStatUsuarios.SuspendLayout();
            this.pnlStatAuditoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(40, 40);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(431, 45);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Panel de Control - Principal";
            // 
            // lblWelcomeSub
            // 
            this.lblWelcomeSub.AutoSize = true;
            this.lblWelcomeSub.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.lblWelcomeSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblWelcomeSub.Location = new System.Drawing.Point(44, 90);
            this.lblWelcomeSub.Name = "lblWelcomeSub";
            this.lblWelcomeSub.Size = new System.Drawing.Size(367, 21);
            this.lblWelcomeSub.TabIndex = 1;
            this.lblWelcomeSub.Text = "Resumen de estado de base de datos de Chalimond";
            // 
            // pnlStatPersonal
            // 
            this.pnlStatPersonal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlStatPersonal.Controls.Add(this.lblPersonalCount);
            this.pnlStatPersonal.Controls.Add(this.lblPersonalTitle);
            this.pnlStatPersonal.Location = new System.Drawing.Point(45, 140);
            this.pnlStatPersonal.Name = "pnlStatPersonal";
            this.pnlStatPersonal.Size = new System.Drawing.Size(230, 120);
            this.pnlStatPersonal.TabIndex = 2;
            // 
            // lblPersonalCount
            // 
            this.lblPersonalCount.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblPersonalCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(140)))), ((int)(((byte)(248)))));
            this.lblPersonalCount.Location = new System.Drawing.Point(15, 45);
            this.lblPersonalCount.Name = "lblPersonalCount";
            this.lblPersonalCount.Size = new System.Drawing.Size(200, 60);
            this.lblPersonalCount.TabIndex = 1;
            this.lblPersonalCount.Text = "0";
            this.lblPersonalCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPersonalTitle
            // 
            this.lblPersonalTitle.AutoSize = true;
            this.lblPersonalTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPersonalTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblPersonalTitle.Location = new System.Drawing.Point(15, 15);
            this.lblPersonalTitle.Name = "lblPersonalTitle";
            this.lblPersonalTitle.Size = new System.Drawing.Size(144, 19);
            this.lblPersonalTitle.TabIndex = 0;
            this.lblPersonalTitle.Text = "Personal Registrado";
            // 
            // pnlStatUsuarios
            // 
            this.pnlStatUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlStatUsuarios.Controls.Add(this.lblUsuariosCount);
            this.pnlStatUsuarios.Controls.Add(this.lblUsuariosTitle);
            this.pnlStatUsuarios.Location = new System.Drawing.Point(295, 140);
            this.pnlStatUsuarios.Name = "pnlStatUsuarios";
            this.pnlStatUsuarios.Size = new System.Drawing.Size(230, 120);
            this.pnlStatUsuarios.TabIndex = 3;
            // 
            // lblUsuariosCount
            // 
            this.lblUsuariosCount.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblUsuariosCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.lblUsuariosCount.Location = new System.Drawing.Point(15, 45);
            this.lblUsuariosCount.Name = "lblUsuariosCount";
            this.lblUsuariosCount.Size = new System.Drawing.Size(200, 60);
            this.lblUsuariosCount.TabIndex = 1;
            this.lblUsuariosCount.Text = "0";
            this.lblUsuariosCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUsuariosTitle
            // 
            this.lblUsuariosTitle.AutoSize = true;
            this.lblUsuariosTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUsuariosTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblUsuariosTitle.Location = new System.Drawing.Point(15, 15);
            this.lblUsuariosTitle.Name = "lblUsuariosTitle";
            this.lblUsuariosTitle.Size = new System.Drawing.Size(143, 19);
            this.lblUsuariosTitle.TabIndex = 0;
            this.lblUsuariosTitle.Text = "Usuarios de Sistema";
            // 
            // pnlStatAuditoria
            // 
            this.pnlStatAuditoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlStatAuditoria.Controls.Add(this.lblAuditoriaCount);
            this.pnlStatAuditoria.Controls.Add(this.lblAuditoriaTitle);
            this.pnlStatAuditoria.Location = new System.Drawing.Point(545, 140);
            this.pnlStatAuditoria.Name = "pnlStatAuditoria";
            this.pnlStatAuditoria.Size = new System.Drawing.Size(230, 120);
            this.pnlStatAuditoria.TabIndex = 4;
            // 
            // lblAuditoriaCount
            // 
            this.lblAuditoriaCount.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblAuditoriaCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(179)))), ((int)(((byte)(8)))));
            this.lblAuditoriaCount.Location = new System.Drawing.Point(15, 45);
            this.lblAuditoriaCount.Name = "lblAuditoriaCount";
            this.lblAuditoriaCount.Size = new System.Drawing.Size(200, 60);
            this.lblAuditoriaCount.TabIndex = 1;
            this.lblAuditoriaCount.Text = "0";
            this.lblAuditoriaCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAuditoriaTitle
            // 
            this.lblAuditoriaTitle.AutoSize = true;
            this.lblAuditoriaTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAuditoriaTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblAuditoriaTitle.Location = new System.Drawing.Point(15, 15);
            this.lblAuditoriaTitle.Name = "lblAuditoriaTitle";
            this.lblAuditoriaTitle.Size = new System.Drawing.Size(159, 19);
            this.lblAuditoriaTitle.TabIndex = 0;
            this.lblAuditoriaTitle.Text = "Registros de Auditoría";
            // 
            // lblInfoSystem
            // 
            this.lblInfoSystem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblInfoSystem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblInfoSystem.Location = new System.Drawing.Point(44, 290);
            this.lblInfoSystem.Name = "lblInfoSystem";
            this.lblInfoSystem.Size = new System.Drawing.Size(730, 200);
            this.lblInfoSystem.TabIndex = 5;
            this.lblInfoSystem.Text = resources.GetString("lblInfoSystem.Text");
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(848, 607);
            this.Controls.Add(this.lblInfoSystem);
            this.Controls.Add(this.pnlStatAuditoria);
            this.Controls.Add(this.pnlStatUsuarios);
            this.Controls.Add(this.pnlStatPersonal);
            this.Controls.Add(this.lblWelcomeSub);
            this.Controls.Add(this.lblWelcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            this.pnlStatPersonal.ResumeLayout(false);
            this.pnlStatPersonal.PerformLayout();
            this.pnlStatUsuarios.ResumeLayout(false);
            this.pnlStatUsuarios.PerformLayout();
            this.pnlStatAuditoria.ResumeLayout(false);
            this.pnlStatAuditoria.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblWelcomeSub;
        private System.Windows.Forms.Panel pnlStatPersonal;
        private System.Windows.Forms.Label lblPersonalTitle;
        private System.Windows.Forms.Label lblPersonalCount;
        private System.Windows.Forms.Panel pnlStatUsuarios;
        private System.Windows.Forms.Label lblUsuariosCount;
        private System.Windows.Forms.Label lblUsuariosTitle;
        private System.Windows.Forms.Panel pnlStatAuditoria;
        private System.Windows.Forms.Label lblAuditoriaCount;
        private System.Windows.Forms.Label lblAuditoriaTitle;
        private System.Windows.Forms.Label lblInfoSystem;
    }
}
