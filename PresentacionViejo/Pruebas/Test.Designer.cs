namespace Presentacion.Pruebas
{
    partial class Test
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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.numResultado = new System.Windows.Forms.NumericUpDown();
            this.btnExecute = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numBlade = new System.Windows.Forms.NumericUpDown();
            this.numPlayers = new System.Windows.Forms.NumericUpDown();
            this.btnCreate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numResultado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBlade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(781, 243);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(97, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // numResultado
            // 
            this.numResultado.Location = new System.Drawing.Point(862, 402);
            this.numResultado.Name = "numResultado";
            this.numResultado.Size = new System.Drawing.Size(47, 20);
            this.numResultado.TabIndex = 3;
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(781, 402);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 40);
            this.btnExecute.TabIndex = 4;
            this.btnExecute.Text = "Ejecutar turno";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.Location = new System.Drawing.Point(778, 445);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(121, 76);
            this.lblInfo.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(778, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tamaño Aspa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(778, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Cantidad Jugadores";
            // 
            // numBlade
            // 
            this.numBlade.Location = new System.Drawing.Point(781, 63);
            this.numBlade.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numBlade.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numBlade.Name = "numBlade";
            this.numBlade.Size = new System.Drawing.Size(120, 20);
            this.numBlade.TabIndex = 8;
            this.numBlade.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // numPlayers
            // 
            this.numPlayers.Location = new System.Drawing.Point(781, 116);
            this.numPlayers.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numPlayers.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numPlayers.Name = "numPlayers";
            this.numPlayers.Size = new System.Drawing.Size(120, 20);
            this.numPlayers.TabIndex = 9;
            this.numPlayers.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(781, 12);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 10;
            this.btnCreate.Text = "Crear";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(924, 711);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.numPlayers);
            this.Controls.Add(this.numBlade);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.numResultado);
            this.Controls.Add(this.btnUpdate);
            this.Name = "Test";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test";
            ((System.ComponentModel.ISupportInitialize)(this.numResultado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBlade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPlayers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.NumericUpDown numResultado;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numBlade;
        private System.Windows.Forms.NumericUpDown numPlayers;
        private System.Windows.Forms.Button btnCreate;
    }
}