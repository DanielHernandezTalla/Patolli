
namespace SocketsForms
{
    partial class frmIpPort
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIpPort));
            this.pnClientServer = new System.Windows.Forms.Panel();
            this.txtPuerto = new System.Windows.Forms.TextBox();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUnirsePartida = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtErrorIp = new System.Windows.Forms.Label();
            this.txtErrorPuerto = new System.Windows.Forms.Label();
            this.pnClientServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnClientServer
            // 
            this.pnClientServer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnClientServer.BackColor = System.Drawing.Color.White;
            this.pnClientServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnClientServer.Controls.Add(this.txtErrorPuerto);
            this.pnClientServer.Controls.Add(this.txtErrorIp);
            this.pnClientServer.Controls.Add(this.txtPuerto);
            this.pnClientServer.Controls.Add(this.txtIp);
            this.pnClientServer.Controls.Add(this.label2);
            this.pnClientServer.Controls.Add(this.btnUnirsePartida);
            this.pnClientServer.Controls.Add(this.label1);
            this.pnClientServer.Location = new System.Drawing.Point(117, 80);
            this.pnClientServer.Name = "pnClientServer";
            this.pnClientServer.Size = new System.Drawing.Size(400, 250);
            this.pnClientServer.TabIndex = 1;
            // 
            // txtPuerto
            // 
            this.txtPuerto.BackColor = System.Drawing.Color.White;
            this.txtPuerto.Font = new System.Drawing.Font("Dubai", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPuerto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtPuerto.Location = new System.Drawing.Point(40, 137);
            this.txtPuerto.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.txtPuerto.MaxLength = 5;
            this.txtPuerto.Name = "txtPuerto";
            this.txtPuerto.Size = new System.Drawing.Size(313, 36);
            this.txtPuerto.TabIndex = 4;
            // 
            // txtIp
            // 
            this.txtIp.Font = new System.Drawing.Font("Dubai", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtIp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtIp.Location = new System.Drawing.Point(40, 47);
            this.txtIp.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.txtIp.MaxLength = 15;
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(313, 36);
            this.txtIp.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Dubai Medium", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(40, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 36);
            this.label2.TabIndex = 1;
            this.label2.Text = "Puerto";
            // 
            // btnUnirsePartida
            // 
            this.btnUnirsePartida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(75)))), ((int)(((byte)(8)))));
            this.btnUnirsePartida.FlatAppearance.BorderSize = 0;
            this.btnUnirsePartida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnirsePartida.Font = new System.Drawing.Font("Dubai", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUnirsePartida.ForeColor = System.Drawing.Color.White;
            this.btnUnirsePartida.Location = new System.Drawing.Point(40, 194);
            this.btnUnirsePartida.Name = "btnUnirsePartida";
            this.btnUnirsePartida.Size = new System.Drawing.Size(313, 36);
            this.btnUnirsePartida.TabIndex = 2;
            this.btnUnirsePartida.Text = "Unirse a Partida";
            this.btnUnirsePartida.UseVisualStyleBackColor = false;
            this.btnUnirsePartida.Click += new System.EventHandler(this.btnUnirsePartida_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Dubai Medium", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(40, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Publica";
            // 
            // txtErrorIp
            // 
            this.txtErrorIp.ForeColor = System.Drawing.Color.Red;
            this.txtErrorIp.Location = new System.Drawing.Point(40, 86);
            this.txtErrorIp.Name = "txtErrorIp";
            this.txtErrorIp.Size = new System.Drawing.Size(313, 15);
            this.txtErrorIp.TabIndex = 9;
            // 
            // txtErrorPuerto
            // 
            this.txtErrorPuerto.ForeColor = System.Drawing.Color.Red;
            this.txtErrorPuerto.Location = new System.Drawing.Point(40, 176);
            this.txtErrorPuerto.Name = "txtErrorPuerto";
            this.txtErrorPuerto.Size = new System.Drawing.Size(313, 15);
            this.txtErrorPuerto.TabIndex = 10;
            // 
            // frmIpPort
            // 
            this.AcceptButton = this.btnUnirsePartida;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(634, 411);
            this.Controls.Add(this.pnClientServer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmIpPort";
            this.Text = "IpPort";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmIpPort_FormClosing);
            this.pnClientServer.ResumeLayout(false);
            this.pnClientServer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnClientServer;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUnirsePartida;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPuerto;
        private System.Windows.Forms.Label txtErrorPuerto;
        private System.Windows.Forms.Label txtErrorIp;
    }
}