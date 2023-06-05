namespace RsaSignatureConfirmation
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
            messsageTextBox = new RichTextBox();
            keyTextBox = new RichTextBox();
            signatureTextBox = new RichTextBox();
            logsTextBox = new RichTextBox();
            startbtn = new Button();
            verifyBtn = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // messsageTextBox
            // 
            messsageTextBox.Enabled = false;
            messsageTextBox.Location = new Point(52, 37);
            messsageTextBox.Name = "messsageTextBox";
            messsageTextBox.Size = new Size(10, 10);
            messsageTextBox.TabIndex = 0;
            messsageTextBox.Text = "";
            // 
            // keyTextBox
            // 
            keyTextBox.Enabled = false;
            keyTextBox.Location = new Point(84, 37);
            keyTextBox.Name = "keyTextBox";
            keyTextBox.Size = new Size(10, 10);
            keyTextBox.TabIndex = 1;
            keyTextBox.Text = "";
            keyTextBox.TextChanged += keyTextBox_TextChanged;
            // 
            // signatureTextBox
            // 
            signatureTextBox.Enabled = false;
            signatureTextBox.Location = new Point(68, 37);
            signatureTextBox.Name = "signatureTextBox";
            signatureTextBox.Size = new Size(10, 10);
            signatureTextBox.TabIndex = 2;
            signatureTextBox.Text = "";
            // 
            // logsTextBox
            // 
            logsTextBox.Location = new Point(503, 37);
            logsTextBox.Name = "logsTextBox";
            logsTextBox.Size = new Size(259, 311);
            logsTextBox.TabIndex = 3;
            logsTextBox.Text = "";
            // 
            // startbtn
            // 
            startbtn.Location = new Point(503, 367);
            startbtn.Name = "startbtn";
            startbtn.Size = new Size(75, 23);
            startbtn.TabIndex = 4;
            startbtn.Text = "Start Server";
            startbtn.UseVisualStyleBackColor = true;
            startbtn.Click += startbtn_Click;
            // 
            // verifyBtn
            // 
            verifyBtn.Location = new Point(687, 367);
            verifyBtn.Name = "verifyBtn";
            verifyBtn.Size = new Size(75, 23);
            verifyBtn.TabIndex = 5;
            verifyBtn.Text = "Verify";
            verifyBtn.UseVisualStyleBackColor = true;
            verifyBtn.Click += verifyBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 32);
            label1.Name = "label1";
            label1.Size = new Size(179, 15);
            label1.TabIndex = 6;
            label1.Text = "Verify your RSA signature HERE!!!";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(verifyBtn);
            Controls.Add(startbtn);
            Controls.Add(logsTextBox);
            Controls.Add(signatureTextBox);
            Controls.Add(keyTextBox);
            Controls.Add(messsageTextBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }





        #endregion

        private RichTextBox messsageTextBox;
        private RichTextBox keyTextBox;
        private RichTextBox signatureTextBox;
        private RichTextBox logsTextBox;
        private Button startbtn;
        private Button verifyBtn;
        private Label label1;
    }
}