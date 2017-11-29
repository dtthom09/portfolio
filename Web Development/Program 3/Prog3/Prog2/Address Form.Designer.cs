namespace UPVApp
{
    partial class Address_Form
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
            this.label_Name = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.label_Address1 = new System.Windows.Forms.Label();
            this.textBox_Address1 = new System.Windows.Forms.TextBox();
            this.label_Address2 = new System.Windows.Forms.Label();
            this.label_City = new System.Windows.Forms.Label();
            this.textBox_Address2 = new System.Windows.Forms.TextBox();
            this.textBox_City = new System.Windows.Forms.TextBox();
            this.label_State = new System.Windows.Forms.Label();
            this.comboBox_State = new System.Windows.Forms.ComboBox();
            this.label_Zip = new System.Windows.Forms.Label();
            this.textBox_Zip = new System.Windows.Forms.TextBox();
            this.button_AddressEnter = new System.Windows.Forms.Button();
            this.errorProviderAddress = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderAddress)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Location = new System.Drawing.Point(46, 27);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(38, 13);
            this.label_Name.TabIndex = 0;
            this.label_Name.Text = "Name:";
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(103, 24);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(100, 20);
            this.textBox_Name.TabIndex = 1;
            // 
            // label_Address1
            // 
            this.label_Address1.AutoSize = true;
            this.label_Address1.Location = new System.Drawing.Point(36, 66);
            this.label_Address1.Name = "label_Address1";
            this.label_Address1.Size = new System.Drawing.Size(48, 13);
            this.label_Address1.TabIndex = 2;
            this.label_Address1.Text = "Address:";
            // 
            // textBox_Address1
            // 
            this.textBox_Address1.Location = new System.Drawing.Point(103, 63);
            this.textBox_Address1.Name = "textBox_Address1";
            this.textBox_Address1.Size = new System.Drawing.Size(100, 20);
            this.textBox_Address1.TabIndex = 3;
            // 
            // label_Address2
            // 
            this.label_Address2.AutoSize = true;
            this.label_Address2.Location = new System.Drawing.Point(30, 109);
            this.label_Address2.Name = "label_Address2";
            this.label_Address2.Size = new System.Drawing.Size(54, 13);
            this.label_Address2.TabIndex = 4;
            this.label_Address2.Text = "Address2:";
            // 
            // label_City
            // 
            this.label_City.AutoSize = true;
            this.label_City.Location = new System.Drawing.Point(57, 141);
            this.label_City.Name = "label_City";
            this.label_City.Size = new System.Drawing.Size(27, 13);
            this.label_City.TabIndex = 5;
            this.label_City.Text = "City:";
            // 
            // textBox_Address2
            // 
            this.textBox_Address2.Location = new System.Drawing.Point(103, 106);
            this.textBox_Address2.Name = "textBox_Address2";
            this.textBox_Address2.Size = new System.Drawing.Size(100, 20);
            this.textBox_Address2.TabIndex = 6;
            // 
            // textBox_City
            // 
            this.textBox_City.Location = new System.Drawing.Point(103, 138);
            this.textBox_City.Name = "textBox_City";
            this.textBox_City.Size = new System.Drawing.Size(100, 20);
            this.textBox_City.TabIndex = 7;
            // 
            // label_State
            // 
            this.label_State.AutoSize = true;
            this.label_State.Location = new System.Drawing.Point(49, 172);
            this.label_State.Name = "label_State";
            this.label_State.Size = new System.Drawing.Size(35, 13);
            this.label_State.TabIndex = 8;
            this.label_State.Text = "State:";
            // 
            // comboBox_State
            // 
            this.comboBox_State.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_State.FormattingEnabled = true;
            this.comboBox_State.Items.AddRange(new object[] {
            "KY",
            "FL",
            "CA",
            "HI",
            "IN",
            "WI",
            "SC",
            "NC"});
            this.comboBox_State.Location = new System.Drawing.Point(103, 169);
            this.comboBox_State.Name = "comboBox_State";
            this.comboBox_State.Size = new System.Drawing.Size(121, 21);
            this.comboBox_State.TabIndex = 9;
            // 
            // label_Zip
            // 
            this.label_Zip.AutoSize = true;
            this.label_Zip.Location = new System.Drawing.Point(59, 206);
            this.label_Zip.Name = "label_Zip";
            this.label_Zip.Size = new System.Drawing.Size(25, 13);
            this.label_Zip.TabIndex = 10;
            this.label_Zip.Text = "Zip:";
            // 
            // textBox_Zip
            // 
            this.textBox_Zip.Location = new System.Drawing.Point(103, 203);
            this.textBox_Zip.Name = "textBox_Zip";
            this.textBox_Zip.Size = new System.Drawing.Size(100, 20);
            this.textBox_Zip.TabIndex = 11;
            // 
            // button_AddressEnter
            // 
            this.button_AddressEnter.Location = new System.Drawing.Point(33, 238);
            this.button_AddressEnter.Name = "button_AddressEnter";
            this.button_AddressEnter.Size = new System.Drawing.Size(75, 23);
            this.button_AddressEnter.TabIndex = 12;
            this.button_AddressEnter.Text = "OK";
            this.button_AddressEnter.UseVisualStyleBackColor = true;
            this.button_AddressEnter.Click += new System.EventHandler(this.button_AddressEnter_Click);
            // 
            // errorProviderAddress
            // 
            this.errorProviderAddress.ContainerControl = this;
            // 
            // Address_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 273);
            this.Controls.Add(this.button_AddressEnter);
            this.Controls.Add(this.textBox_Zip);
            this.Controls.Add(this.label_Zip);
            this.Controls.Add(this.comboBox_State);
            this.Controls.Add(this.label_State);
            this.Controls.Add(this.textBox_City);
            this.Controls.Add(this.textBox_Address2);
            this.Controls.Add(this.label_City);
            this.Controls.Add(this.label_Address2);
            this.Controls.Add(this.textBox_Address1);
            this.Controls.Add(this.label_Address1);
            this.Controls.Add(this.textBox_Name);
            this.Controls.Add(this.label_Name);
            this.Name = "Address_Form";
            this.Text = "Address_Form";
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderAddress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Label label_Address1;
        private System.Windows.Forms.TextBox textBox_Address1;
        private System.Windows.Forms.Label label_Address2;
        private System.Windows.Forms.Label label_City;
        private System.Windows.Forms.TextBox textBox_Address2;
        private System.Windows.Forms.TextBox textBox_City;
        private System.Windows.Forms.Label label_State;
        private System.Windows.Forms.ComboBox comboBox_State;
        private System.Windows.Forms.Label label_Zip;
        private System.Windows.Forms.TextBox textBox_Zip;
        private System.Windows.Forms.Button button_AddressEnter;
        private System.Windows.Forms.ErrorProvider errorProviderAddress;
    }
}