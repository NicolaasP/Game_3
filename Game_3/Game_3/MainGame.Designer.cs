﻿namespace Game_3
{
    partial class MainGame
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
            this.components = new System.ComponentModel.Container();
            this.ticker = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ticker
            // 
            this.ticker.Tick += new System.EventHandler(this.Ticker_Tick);
            // 
            // MainGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 761);
            this.Name = "MainGame";
            this.Text = "MainGame";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainGame_FormClosed);
            this.Load += new System.EventHandler(this.MainGame_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainGame_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainGame_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainGame_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer ticker;
    }
}