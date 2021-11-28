
namespace Presentacion.Forms
{
    partial class AuthForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthForm));
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnClientServer = new System.Windows.Forms.Panel();
            this.txtErrorNombre = new System.Windows.Forms.Label();
            this.txtNombreError = new System.Windows.Forms.Label();
            this.pnClientServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Dubai", 12.75F);
            this.txtNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtNombre.Location = new System.Drawing.Point(34, 81);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(313, 36);
            this.txtNombre.TabIndex = 6;
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(75)))), ((int)(((byte)(8)))));
            this.btnIngresar.FlatAppearance.BorderSize = 0;
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.Font = new System.Drawing.Font("Dubai", 14.25F);
            this.btnIngresar.ForeColor = System.Drawing.Color.White;
            this.btnIngresar.Location = new System.Drawing.Point(34, 151);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(313, 36);
            this.btnIngresar.TabIndex = 5;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Dubai Medium", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(34, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 36);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nombre";
            // 
            // pnClientServer
            // 
            this.pnClientServer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnClientServer.BackColor = System.Drawing.Color.White;
            this.pnClientServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnClientServer.Controls.Add(this.txtErrorNombre);
            this.pnClientServer.Controls.Add(this.txtNombreError);
            this.pnClientServer.Controls.Add(this.txtNombre);
            this.pnClientServer.Controls.Add(this.label1);
            this.pnClientServer.Controls.Add(this.btnIngresar);
            this.pnClientServer.Location = new System.Drawing.Point(117, 80);
            this.pnClientServer.Name = "pnClientServer";
            this.pnClientServer.Size = new System.Drawing.Size(400, 250);
            this.pnClientServer.TabIndex = 7;
            // 
            // txtErrorNombre
            // 
            this.txtErrorNombre.ForeColor = System.Drawing.Color.Red;
            this.txtErrorNombre.Location = new System.Drawing.Point(34, 120);
            this.txtErrorNombre.Name = "txtErrorNombre";
            this.txtErrorNombre.Size = new System.Drawing.Size(313, 15);
            this.txtErrorNombre.TabIndex = 8;
            // 
            // txtNombreError
            // 
            this.txtNombreError.AutoSize = true;
            this.txtNombreError.BackColor = System.Drawing.Color.White;
            this.txtNombreError.ForeColor = System.Drawing.Color.Red;
            this.txtNombreError.Location = new System.Drawing.Point(-184, 25);
            this.txtNombreError.Name = "txtNombreError";
            this.txtNombreError.Size = new System.Drawing.Size(0, 13);
            this.txtNombreError.TabIndex = 7;
            // 
            // AuthForm
            // 
            this.AcceptButton = this.btnIngresar;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(634, 411);
            this.Controls.Add(this.pnClientServer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AuthForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autentificación";
            this.pnClientServer.ResumeLayout(false);
            this.pnClientServer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnClientServer;
        private System.Windows.Forms.Label txtNombreError;
        private System.Windows.Forms.Label txtErrorNombre;
    }
}