namespace Sifravimas
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
            this.LibraryEncryptButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LibraryDecryptButton = new System.Windows.Forms.Button();
            this.LibraryEncodedTextBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LibraryRawTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CBCButton = new System.Windows.Forms.RadioButton();
            this.ECBButton = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.FileDecryptButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LibraryEncryptButton
            // 
            this.LibraryEncryptButton.Location = new System.Drawing.Point(320, 202);
            this.LibraryEncryptButton.Name = "LibraryEncryptButton";
            this.LibraryEncryptButton.Size = new System.Drawing.Size(55, 23);
            this.LibraryEncryptButton.TabIndex = 1;
            this.LibraryEncryptButton.Text = "Encrypt";
            this.LibraryEncryptButton.UseVisualStyleBackColor = true;
            this.LibraryEncryptButton.Click += new System.EventHandler(this.LibraryEncryptButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.FileDecryptButton);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.LibraryDecryptButton);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.LibraryEncryptButton);
            this.panel1.Location = new System.Drawing.Point(8, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 426);
            this.panel1.TabIndex = 2;
            // 
            // LibraryDecryptButton
            // 
            this.LibraryDecryptButton.Location = new System.Drawing.Point(381, 202);
            this.LibraryDecryptButton.Name = "LibraryDecryptButton";
            this.LibraryDecryptButton.Size = new System.Drawing.Size(55, 23);
            this.LibraryDecryptButton.TabIndex = 6;
            this.LibraryDecryptButton.Text = "Decrypt";
            this.LibraryDecryptButton.UseVisualStyleBackColor = true;
            this.LibraryDecryptButton.Click += new System.EventHandler(this.LibraryDecryptButton_Click);
            // 
            // LibraryEncodedTextBox
            // 
            this.LibraryEncodedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LibraryEncodedTextBox.Location = new System.Drawing.Point(3, 3);
            this.LibraryEncodedTextBox.Multiline = true;
            this.LibraryEncodedTextBox.Name = "LibraryEncodedTextBox";
            this.LibraryEncodedTextBox.Size = new System.Drawing.Size(417, 174);
            this.LibraryEncodedTextBox.TabIndex = 3;
            this.LibraryEncodedTextBox.Text = "ENCRYPTED TEXT GOES HERE";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.LibraryRawTextBox);
            this.panel3.Location = new System.Drawing.Point(14, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(427, 184);
            this.panel3.TabIndex = 2;
            // 
            // LibraryRawTextBox
            // 
            this.LibraryRawTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LibraryRawTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LibraryRawTextBox.Location = new System.Drawing.Point(3, 3);
            this.LibraryRawTextBox.Multiline = true;
            this.LibraryRawTextBox.Name = "LibraryRawTextBox";
            this.LibraryRawTextBox.Size = new System.Drawing.Size(417, 174);
            this.LibraryRawTextBox.TabIndex = 4;
            this.LibraryRawTextBox.Text = "TEXT TO ENCRYPT GOES HERE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "DES:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(500, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Enter your very own key here:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(503, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(57, 20);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "01";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(566, 42);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(57, 20);
            this.textBox2.TabIndex = 11;
            this.textBox2.Text = "ff";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(629, 42);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(57, 20);
            this.textBox3.TabIndex = 12;
            this.textBox3.Text = "ff";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(692, 42);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(57, 20);
            this.textBox4.TabIndex = 13;
            this.textBox4.Text = "01";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(755, 42);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(57, 20);
            this.textBox5.TabIndex = 14;
            this.textBox5.Text = "ff";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(818, 42);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(57, 20);
            this.textBox6.TabIndex = 15;
            this.textBox6.Text = "01";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(881, 42);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(57, 20);
            this.textBox7.TabIndex = 16;
            this.textBox7.Text = "ff";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(944, 42);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(57, 20);
            this.textBox8.TabIndex = 17;
            this.textBox8.Text = "01";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(500, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Notes:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(500, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Enter hexadecimal values, up to ff";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(500, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(315, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "01 01 01 01 01 01 01 is NOT accepted, DES sees it as too weak";
            // 
            // CBCButton
            // 
            this.CBCButton.AutoSize = true;
            this.CBCButton.Checked = true;
            this.CBCButton.Location = new System.Drawing.Point(503, 177);
            this.CBCButton.Name = "CBCButton";
            this.CBCButton.Size = new System.Drawing.Size(46, 17);
            this.CBCButton.TabIndex = 21;
            this.CBCButton.TabStop = true;
            this.CBCButton.Text = "CBC";
            this.CBCButton.UseVisualStyleBackColor = true;
            // 
            // ECBButton
            // 
            this.ECBButton.AutoSize = true;
            this.ECBButton.Location = new System.Drawing.Point(503, 200);
            this.ECBButton.Name = "ECBButton";
            this.ECBButton.Size = new System.Drawing.Size(46, 17);
            this.ECBButton.TabIndex = 22;
            this.ECBButton.TabStop = true;
            this.ECBButton.Text = "ECB";
            this.ECBButton.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(503, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Mode:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.LibraryEncodedTextBox);
            this.panel2.Location = new System.Drawing.Point(14, 231);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(427, 174);
            this.panel2.TabIndex = 7;
            // 
            // FileDecryptButton
            // 
            this.FileDecryptButton.Location = new System.Drawing.Point(14, 202);
            this.FileDecryptButton.Name = "FileDecryptButton";
            this.FileDecryptButton.Size = new System.Drawing.Size(94, 23);
            this.FileDecryptButton.TabIndex = 8;
            this.FileDecryptButton.Text = "Decrypt from File";
            this.FileDecryptButton.UseVisualStyleBackColor = true;
            this.FileDecryptButton.Click += new System.EventHandler(this.FileDecryptButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 456);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ECBButton);
            this.Controls.Add(this.CBCButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LibraryEncryptButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox LibraryEncodedTextBox;
        private System.Windows.Forms.TextBox LibraryRawTextBox;
        private System.Windows.Forms.Button LibraryDecryptButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton CBCButton;
        private System.Windows.Forms.RadioButton ECBButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button FileDecryptButton;
    }
}

