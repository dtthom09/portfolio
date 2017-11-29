namespace UPVApp
{
    partial class Letter_Form
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
            this.comboBox_Origin = new System.Windows.Forms.ComboBox();
            this.label_Origin = new System.Windows.Forms.Label();
            this.label_Dest = new System.Windows.Forms.Label();
            this.comboBox_Dest = new System.Windows.Forms.ComboBox();
            this.label_Fixed = new System.Windows.Forms.Label();
            this.textBox_Fixed = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.errorProvider_Letter = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_Letter)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_Origin
            // 
            this.comboBox_Origin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Origin.FormattingEnabled = true;
            this.comboBox_Origin.Location = new System.Drawing.Point(132, 33);
            this.comboBox_Origin.Name = "comboBox_Origin";
            this.comboBox_Origin.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Origin.TabIndex = 0;
            // 
            // label_Origin
            // 
            this.label_Origin.AutoSize = true;
            this.label_Origin.Location = new System.Drawing.Point(38, 36);
            this.label_Origin.Name = "label_Origin";
            this.label_Origin.Size = new System.Drawing.Size(78, 13);
            this.label_Origin.TabIndex = 1;
            this.label_Origin.Text = "Origin Address:";
            // 
            // label_Dest
            // 
            this.label_Dest.AutoSize = true;
            this.label_Dest.Location = new System.Drawing.Point(12, 95);
            this.label_Dest.Name = "label_Dest";
            this.label_Dest.Size = new System.Drawing.Size(104, 13);
            this.label_Dest.TabIndex = 2;
            this.label_Dest.Text = "Destination Address:";
            // 
            // comboBox_Dest
            // 
            this.comboBox_Dest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Dest.FormattingEnabled = true;
            this.comboBox_Dest.Location = new System.Drawing.Point(132, 92);
            this.comboBox_Dest.Name = "comboBox_Dest";
            this.comboBox_Dest.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Dest.TabIndex = 3;
            // 
            // label_Fixed
            // 
            this.label_Fixed.AutoSize = true;
            this.label_Fixed.Location = new System.Drawing.Point(57, 154);
            this.label_Fixed.Name = "label_Fixed";
            this.label_Fixed.Size = new System.Drawing.Size(59, 13);
            this.label_Fixed.TabIndex = 4;
            this.label_Fixed.Text = "Fixed Cost:";
            // 
            // textBox_Fixed
            // 
            this.textBox_Fixed.Location = new System.Drawing.Point(132, 151);
            this.textBox_Fixed.Name = "textBox_Fixed";
            this.textBox_Fixed.Size = new System.Drawing.Size(100, 20);
            this.textBox_Fixed.TabIndex = 5;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(60, 212);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // errorProvider_Letter
            // 
            this.errorProvider_Letter.ContainerControl = this;
            // 
            // Letter_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBox_Fixed);
            this.Controls.Add(this.label_Fixed);
            this.Controls.Add(this.comboBox_Dest);
            this.Controls.Add(this.label_Dest);
            this.Controls.Add(this.label_Origin);
            this.Controls.Add(this.comboBox_Origin);
            this.Name = "Letter_Form";
            this.Text = "Letter_Form";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_Letter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_Origin;
        private System.Windows.Forms.Label label_Origin;
        private System.Windows.Forms.Label label_Dest;
        private System.Windows.Forms.ComboBox comboBox_Dest;
        private System.Windows.Forms.Label label_Fixed;
        private System.Windows.Forms.TextBox textBox_Fixed;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.ErrorProvider errorProvider_Letter;
    }
}