namespace Test.Main
{
    partial class PlayerGame
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
            this.panBackground.Location = new System.Drawing.Point(14, 0);
            this.panBackground.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panBackground.MaximumSize = new System.Drawing.Size(2333, 1846);
            this.panBackground.Name = "panBackground";
            this.panBackground.Size = new System.Drawing.Size(1283, 808);
            this.panBackground.TabIndex = 0;
            // 
            // panBoard
            // 
            this.panBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panBoard.BackColor = System.Drawing.SystemColors.Control;
            this.panBoard.Location = new System.Drawing.Point(233, 0);
            this.panBoard.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panBoard.MaximumSize = new System.Drawing.Size(1867, 1846);
            this.panBoard.MinimumSize = new System.Drawing.Size(793, 808);
            this.panBoard.Name = "panBoard";
            this.panBoard.Size = new System.Drawing.Size(817, 808);
            this.panBoard.TabIndex = 3;
            // 
            // panControls
            // 
            this.panControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panControls.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panControls.Location = new System.Drawing.Point(1050, 0);
            this.panControls.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panControls.MaximumSize = new System.Drawing.Size(233, 1846);
            this.panControls.Name = "panControls";
            this.panControls.Size = new System.Drawing.Size(233, 808);
            this.panControls.TabIndex = 2;
            // 
            // panTurnsInfo
            // 
            this.panTurnsInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panTurnsInfo.BackColor = System.Drawing.Color.Gold;
            this.panTurnsInfo.Location = new System.Drawing.Point(0, 0);
            this.panTurnsInfo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panTurnsInfo.MaximumSize = new System.Drawing.Size(233, 1846);
            this.panTurnsInfo.Name = "panTurnsInfo";
            this.panTurnsInfo.Size = new System.Drawing.Size(233, 808);
            this.panTurnsInfo.TabIndex = 0;
            // 
            // PlayerGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1311, 809);
            this.Controls.Add(this.panBackground);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(1327, 832);
            this.Name = "PlayerGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PlayerGame";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlayerGame_FormClosing);
            this.SizeChanged += new System.EventHandler(this.PlayerGame_SizeChanged);
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