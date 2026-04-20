namespace DentalAppointment
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtFullName = new TextBox();
            txtPhoneNumber = new TextBox();
            cboDoctor = new ComboBox();
            label3 = new Label();
            dtpAppointment = new DateTimePicker();
            label4 = new Label();
            cboOfficeLocation = new ComboBox();
            label5 = new Label();
            btnConfirm = new Button();
            label6 = new Label();
            txtReason = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(120, 30);
            label1.Name = "label1";
            label1.Size = new Size(123, 32);
            label1.TabIndex = 0;
            label1.Text = "Full Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(66, 94);
            label2.Name = "label2";
            label2.Size = new Size(177, 32);
            label2.TabIndex = 1;
            label2.Text = "Phone Number";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(279, 23);
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderText = "Last Name, First Name";
            txtFullName.Size = new Size(400, 39);
            txtFullName.TabIndex = 2;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(279, 87);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.PlaceholderText = "(xxx)xxx-xxxx";
            txtPhoneNumber.Size = new Size(400, 39);
            txtPhoneNumber.TabIndex = 3;
            // 
            // cboDoctor
            // 
            cboDoctor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDoctor.FormattingEnabled = true;
            cboDoctor.Location = new Point(279, 145);
            cboDoctor.Name = "cboDoctor";
            cboDoctor.Size = new Size(400, 40);
            cboDoctor.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(157, 153);
            label3.Name = "label3";
            label3.Size = new Size(86, 32);
            label3.TabIndex = 5;
            label3.Text = "Doctor";
            // 
            // dtpAppointment
            // 
            dtpAppointment.Location = new Point(279, 207);
            dtpAppointment.Name = "dtpAppointment";
            dtpAppointment.Size = new Size(400, 39);
            dtpAppointment.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 214);
            label4.Name = "label4";
            label4.Size = new Size(212, 32);
            label4.TabIndex = 7;
            label4.Text = "Appointment Date";
            // 
            // cboOfficeLocation
            // 
            cboOfficeLocation.DropDownStyle = ComboBoxStyle.DropDownList;
            cboOfficeLocation.FormattingEnabled = true;
            cboOfficeLocation.Location = new Point(279, 265);
            cboOfficeLocation.Name = "cboOfficeLocation";
            cboOfficeLocation.Size = new Size(400, 40);
            cboOfficeLocation.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(68, 273);
            label5.Name = "label5";
            label5.Size = new Size(175, 32);
            label5.TabIndex = 9;
            label5.Text = "Office Location";
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(373, 455);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(182, 84);
            btnConfirm.TabIndex = 10;
            btnConfirm.Text = "Confirm Appointment";
            btnConfirm.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(67, 334);
            label6.Name = "label6";
            label6.Size = new Size(179, 32);
            label6.TabIndex = 11;
            label6.Text = "Reason for Visit";
            // 
            // txtReason
            // 
            txtReason.Location = new Point(279, 327);
            txtReason.Multiline = true;
            txtReason.Name = "txtReason";
            txtReason.Size = new Size(400, 96);
            txtReason.TabIndex = 12;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(756, 586);
            Controls.Add(txtReason);
            Controls.Add(label6);
            Controls.Add(btnConfirm);
            Controls.Add(label5);
            Controls.Add(cboOfficeLocation);
            Controls.Add(label4);
            Controls.Add(dtpAppointment);
            Controls.Add(label3);
            Controls.Add(cboDoctor);
            Controls.Add(txtPhoneNumber);
            Controls.Add(txtFullName);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Schedule Appointment";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtFullName;
        private TextBox txtPhoneNumber;
        private ComboBox cboDoctor;
        private Label label3;
        private DateTimePicker dtpAppointment;
        private Label label4;
        private ComboBox cboOfficeLocation;
        private Label label5;
        private Button btnConfirm;
        private Label label6;
        private TextBox txtReason;
    }
}
