
namespace Presentacion.Forms
{
    partial class ClientServerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientServerForm));
            this.pnClientServer = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUnirse = new System.Windows.Forms.Button();
            this.btnCrearPartida = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
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
            this.pnClientServer.Controls.Add(this.label2);
            this.pnClientServer.Controls.Add(this.btnUnirse);
            this.pnClientServer.Controls.Add(this.btnCrearPartida);
            this.pnClientServer.Controls.Add(this.label1);
            this.pnClientServer.Location = new System.Drawing.Point(96, 72);
            this.pnClientServer.Name = "pnClientServer";
            this.pnClientServer.Size = new System.Drawing.Size(434, 272);
            this.pnClientServer.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Dubai Medium", 15.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(57, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 36);
            this.label2.TabIndex = 1;
            this.label2.Text = "Privada";
            // 
            // btnUnirse
            // 
            this.btnUnirse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(75)))), ((int)(((byte)(8)))));
            this.btnUnirse.FlatAppearance.BorderSize = 0;
            this.btnUnirse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnirse.Font = new System.Drawing.Font("Dubai", 14.25F);
            this.btnUnirse.ForeColor = System.Drawing.Color.White;
            this.btnUnirse.Location = new System.Drawing.Point(50, 183);
            this.btnUnirse.Name = "btnUnirse";
            this.btnUnirse.Size = new System.Drawing.Size(313, 36);
            this.btnUnirse.TabIndex = 2;
            this.btnUnirse.Text = "Unirse a Partida";
            this.btnUnirse.UseVisualStyleBackColor = false;
            this.btnUnirse.Click += new System.EventHandler(this.btnUnirse_Click);
            // 
            // btnCrearPartida
            // 
            this.btnCrearPartida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(75)))), ((int)(((byte)(8)))));
            this.btnCrearPartida.FlatAppearance.BorderSize = 0;
            this.btnCrearPartida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearPartida.Font = new System.Drawing.Font("Dubai", 14.25F);
            this.btnCrearPartida.ForeColor = System.Drawing.Color.White;
            this.btnCrearPartida.Location = new System.Drawing.Point(50, 81);
            this.btnCrearPartida.Name = "btnCrearPartida";
            this.btnCrearPartida.Size = new System.Drawing.Size(313, 36);
            this.btnCrearPartida.TabIndex = 1;
            this.btnCrearPartida.Text = "Crear Partida";
            this.btnCrearPartida.UseVisualStyleBackColor = false;
            this.btnCrearPartida.Click += new System.EventHandler(this.btnCrearPartida_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Dubai Medium", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(57, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ser Host";
            // 
            // ClientServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(634, 411);
            this.Controls.Add(this.pnClientServer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ClientServerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar Rol";
            this.pnClientServer.ResumeLayout(false);
            this.pnClientServer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnClientServer;
        private System.Windows.Forms.Button btnCrearPartida;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUnirse;
    }
}

