namespace SimConnectPanel
{
    partial class Form1
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
            this.button_Connect = new System.Windows.Forms.Button();
            this.button_Test = new System.Windows.Forms.Button();
            this.richResponse = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(12, 12);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(104, 23);
            this.button_Connect.TabIndex = 0;
            this.button_Connect.Text = "Connect to FSX";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // button_Test
            // 
            this.button_Test.Location = new System.Drawing.Point(12, 41);
            this.button_Test.Name = "button_Test";
            this.button_Test.Size = new System.Drawing.Size(75, 23);
            this.button_Test.TabIndex = 3;
            this.button_Test.Text = "Test";
            this.button_Test.UseVisualStyleBackColor = true;
            this.button_Test.Click += new System.EventHandler(this.button_Test_Click);
            // 
            // richResponse
            // 
            this.richResponse.Location = new System.Drawing.Point(12, 70);
            this.richResponse.Name = "richResponse";
            this.richResponse.Size = new System.Drawing.Size(268, 191);
            this.richResponse.TabIndex = 4;
            this.richResponse.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.richResponse);
            this.Controls.Add(this.button_Test);
            this.Controls.Add(this.button_Connect);
            this.Name = "Form1";
            this.Text = "SimConnectPanel";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.Button button_Test;
        private System.Windows.Forms.RichTextBox richResponse;
    }
}

