
namespace Figonx
{
    partial class FigonxAntiCheat
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
            this.takescreenshot_jpg = new System.Windows.Forms.Timer(this.components);
            this.jpg_delete = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // takescreenshot_jpg
            // 
            this.takescreenshot_jpg.Enabled = true;
            this.takescreenshot_jpg.Interval = 125000;
            this.takescreenshot_jpg.Tick += new System.EventHandler(this.takescreenshot_jpg_Tick);
            // 
            // jpg_delete
            // 
            this.jpg_delete.Enabled = true;
            this.jpg_delete.Interval = 120000;
            this.jpg_delete.Tick += new System.EventHandler(this.jpg_delete_Tick);
            // 
            // FigonxAntiCheat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(44, 42);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FigonxAntiCheat";
            this.Opacity = 0.01D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FigonxAntiCheat_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer takescreenshot_jpg;
        private System.Windows.Forms.Timer jpg_delete;
    }
}

