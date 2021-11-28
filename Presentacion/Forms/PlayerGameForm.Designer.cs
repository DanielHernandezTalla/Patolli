namespace Presentacion.Forms
{
    partial class PlayerGameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerGameForm));
            this.panBackground = new System.Windows.Forms.Panel();
            this.panBoard = new System.Windows.Forms.Panel();
            this.panControls = new System.Windows.Forms.Panel();
            this.panTurnsInfo = new System.Windows.Forms.Panel();
            this.panBackground.SuspendLayout();
            this.SuspendLayout();
            // 
            // panBackground
            // 
            this.panBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panBackground.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panBackground.Controls.Add(this.panBoard);
            this.panBackground.Controls.Add(this.panControls);
            this.panBackground.Controls.Add(this.panTurnsInfo);
            this.panBackground.Location = new System.Drawing.Point(36, 0);
            this.panBackground.MaximumSize = new System.Drawing.Size(2000, 1600);
            this.panBackground.Name = "panBackground";
            this.panBackground.Size = new System.Drawing.Size(1230, 700);
            this.panBackground.TabIndex = 0;
            // 
            // panBoard
            // 
            this.panBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panBoard.BackColor = System.Drawing.Color.Wheat;
            this.panBoard.Location = new System.Drawing.Point(250, 0);
            this.panBoard.MaximumSize = new System.Drawing.Size(1600, 1600);
            this.panBoard.MinimumSize = new System.Drawing.Size(680, 700);
            this.panBoard.Name = "panBoard";
            this.panBoard.Size = new System.Drawing.Size(730, 700);
            this.panBoard.TabIndex = 3;
            // 
            // panControls
            // 
            this.panControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panControls.BackColor = System.Drawing.Color.Turquoise;
            this.panControls.Location = new System.Drawing.Point(980, 0);
            this.panControls.MaximumSize = new System.Drawing.Size(250, 1600);
            this.panControls.Name = "panControls";
            this.panControls.Size = new System.Drawing.Size(250, 700);
            this.panControls.TabIndex = 2;
            // 
            // panTurnsInfo
            // 
            this.panTurnsInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panTurnsInfo.BackColor = System.Drawing.Color.Turquoise;
            this.panTurnsInfo.Location = new System.Drawing.Point(0, 0);
            this.panTurnsInfo.MaximumSize = new System.Drawing.Size(250, 1600);
            this.panTurnsInfo.Name = "panTurnsInfo";
            this.panTurnsInfo.Size = new System.Drawing.Size(250, 700);
            this.panTurnsInfo.TabIndex = 0;
            // 
            // PlayerGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1304, 701);
            this.Controls.Add(this.panBackground);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1320, 726);
            this.Name = "PlayerGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PlayerGame";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlayerGameForm_FormClosing);
            this.SizeChanged += new System.EventHandler(this.PlayerGameForm_SizeChanged);
            this.panBackground.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panBackground;
        private System.Windows.Forms.Panel panBoard;
        private System.Windows.Forms.Panel panControls;
        private System.Windows.Forms.Panel panTurnsInfo;
    }
}