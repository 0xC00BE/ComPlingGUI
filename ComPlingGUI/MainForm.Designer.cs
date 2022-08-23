namespace ComPlingGUI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnControl = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbNIC = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbNetworks = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnControl
            // 
            this.btnControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnControl.Location = new System.Drawing.Point(144, 255);
            this.btnControl.Name = "btnControl";
            this.btnControl.Size = new System.Drawing.Size(212, 59);
            this.btnControl.TabIndex = 2;
            this.btnControl.Text = "Start";
            this.btnControl.UseVisualStyleBackColor = true;
            this.btnControl.Click += new System.EventHandler(this.btnControl_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Networks - one per line in  CIDR notation:";
            // 
            // cbNIC
            // 
            this.cbNIC.FormattingEnabled = true;
            this.cbNIC.Location = new System.Drawing.Point(116, 12);
            this.cbNIC.Name = "cbNIC";
            this.cbNIC.Size = new System.Drawing.Size(375, 21);
            this.cbNIC.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Network interface: ";
            // 
            // rtbNetworks
            // 
            this.rtbNetworks.Location = new System.Drawing.Point(16, 63);
            this.rtbNetworks.Name = "rtbNetworks";
            this.rtbNetworks.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbNetworks.Size = new System.Drawing.Size(475, 186);
            this.rtbNetworks.TabIndex = 6;
            this.rtbNetworks.Text = resources.GetString("rtbNetworks.Text");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 345);
            this.Controls.Add(this.rtbNetworks);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbNIC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "ComPling";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbNIC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbNetworks;
    }
}

