namespace DigitalSignature
{
    partial class DigitalSignatureMainWindow
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
            this.label2 = new System.Windows.Forms.Label();
            this.publicKeyE = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.publicKeyN = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pKeyName1 = new System.Windows.Forms.Label();
            this.pKeyName2 = new System.Windows.Forms.Label();
            this.messageToSend = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.signBox = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.sentMessageHashBox = new System.Windows.Forms.RichTextBox();
            this.label3ToChange = new System.Windows.Forms.Label();
            this.decryptedSignHashBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chooseSigningStandartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rSAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eCDSAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusLabel = new System.Windows.Forms.Label();
            this.timeBox = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Alice";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // publicKeyE
            // 
            this.publicKeyE.Location = new System.Drawing.Point(327, 135);
            this.publicKeyE.Name = "publicKeyE";
            this.publicKeyE.Size = new System.Drawing.Size(302, 116);
            this.publicKeyE.TabIndex = 1;
            this.publicKeyE.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(327, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 32);
            this.button1.TabIndex = 2;
            this.button1.Text = "Get public key";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label3.Location = new System.Drawing.Point(323, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Bob";
            // 
            // publicKeyN
            // 
            this.publicKeyN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.publicKeyN.Location = new System.Drawing.Point(327, 309);
            this.publicKeyN.Name = "publicKeyN";
            this.publicKeyN.Size = new System.Drawing.Size(302, 106);
            this.publicKeyN.TabIndex = 4;
            this.publicKeyN.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 70);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 32);
            this.button2.TabIndex = 5;
            this.button2.Text = "Reset keys";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pKeyName1
            // 
            this.pKeyName1.AutoSize = true;
            this.pKeyName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.pKeyName1.Location = new System.Drawing.Point(323, 112);
            this.pKeyName1.Name = "pKeyName1";
            this.pKeyName1.Size = new System.Drawing.Size(33, 20);
            this.pKeyName1.TabIndex = 6;
            this.pKeyName1.Text = "E =";
            // 
            // pKeyName2
            // 
            this.pKeyName2.AutoSize = true;
            this.pKeyName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.pKeyName2.Location = new System.Drawing.Point(323, 286);
            this.pKeyName2.Name = "pKeyName2";
            this.pKeyName2.Size = new System.Drawing.Size(33, 20);
            this.pKeyName2.TabIndex = 7;
            this.pKeyName2.Text = "N =";
            // 
            // messageToSend
            // 
            this.messageToSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.messageToSend.Location = new System.Drawing.Point(12, 134);
            this.messageToSend.Name = "messageToSend";
            this.messageToSend.Size = new System.Drawing.Size(276, 158);
            this.messageToSend.TabIndex = 8;
            this.messageToSend.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(8, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(219, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Message to sent with the sign";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 309);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 28);
            this.button3.TabIndex = 10;
            this.button3.Text = "Sign and send";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(684, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "Sign";
            // 
            // signBox
            // 
            this.signBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.signBox.Location = new System.Drawing.Point(687, 100);
            this.signBox.Name = "signBox";
            this.signBox.Size = new System.Drawing.Size(302, 96);
            this.signBox.TabIndex = 12;
            this.signBox.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(684, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "Sent message hash";
            // 
            // sentMessageHashBox
            // 
            this.sentMessageHashBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.sentMessageHashBox.Location = new System.Drawing.Point(687, 232);
            this.sentMessageHashBox.Name = "sentMessageHashBox";
            this.sentMessageHashBox.Size = new System.Drawing.Size(302, 96);
            this.sentMessageHashBox.TabIndex = 14;
            this.sentMessageHashBox.Text = "";
            // 
            // label3ToChange
            // 
            this.label3ToChange.AutoSize = true;
            this.label3ToChange.Location = new System.Drawing.Point(684, 347);
            this.label3ToChange.Name = "label3ToChange";
            this.label3ToChange.Size = new System.Drawing.Size(138, 17);
            this.label3ToChange.TabIndex = 15;
            this.label3ToChange.Text = "Decrypted sign hash";
            // 
            // decryptedSignHashBox
            // 
            this.decryptedSignHashBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.decryptedSignHashBox.Location = new System.Drawing.Point(687, 367);
            this.decryptedSignHashBox.Name = "decryptedSignHashBox";
            this.decryptedSignHashBox.Size = new System.Drawing.Size(302, 96);
            this.decryptedSignHashBox.TabIndex = 16;
            this.decryptedSignHashBox.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseSigningStandartToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1019, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chooseSigningStandartToolStripMenuItem
            // 
            this.chooseSigningStandartToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rSAToolStripMenuItem,
            this.eCDSAToolStripMenuItem});
            this.chooseSigningStandartToolStripMenuItem.Name = "chooseSigningStandartToolStripMenuItem";
            this.chooseSigningStandartToolStripMenuItem.Size = new System.Drawing.Size(147, 20);
            this.chooseSigningStandartToolStripMenuItem.Text = "Choose signing standart";
            // 
            // rSAToolStripMenuItem
            // 
            this.rSAToolStripMenuItem.Checked = true;
            this.rSAToolStripMenuItem.CheckOnClick = true;
            this.rSAToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rSAToolStripMenuItem.Name = "rSAToolStripMenuItem";
            this.rSAToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.rSAToolStripMenuItem.Text = "RSA";
            this.rSAToolStripMenuItem.Click += new System.EventHandler(this.rSAToolStripMenuItem_Click);
            // 
            // eCDSAToolStripMenuItem
            // 
            this.eCDSAToolStripMenuItem.CheckOnClick = true;
            this.eCDSAToolStripMenuItem.Name = "eCDSAToolStripMenuItem";
            this.eCDSAToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.eCDSAToolStripMenuItem.Text = "ECDSA";
            this.eCDSAToolStripMenuItem.Click += new System.EventHandler(this.eCDSAToolStripMenuItem_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.statusLabel.Location = new System.Drawing.Point(13, 368);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 26);
            this.statusLabel.TabIndex = 18;
            // 
            // timeBox
            // 
            this.timeBox.Location = new System.Drawing.Point(687, 484);
            this.timeBox.Name = "timeBox";
            this.timeBox.Size = new System.Drawing.Size(100, 23);
            this.timeBox.TabIndex = 19;
            // 
            // DigitalSignatureMainWindow
            // 
            this.ClientSize = new System.Drawing.Size(1019, 519);
            this.Controls.Add(this.timeBox);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.decryptedSignHashBox);
            this.Controls.Add(this.label3ToChange);
            this.Controls.Add(this.sentMessageHashBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.signBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.messageToSend);
            this.Controls.Add(this.pKeyName2);
            this.Controls.Add(this.pKeyName1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.publicKeyN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.publicKeyE);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Name = "DigitalSignatureMainWindow";
            this.Text = "Digital signature";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox publicKeyE;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox publicKeyN;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label pKeyName1;
        private System.Windows.Forms.Label pKeyName2;
        private System.Windows.Forms.RichTextBox messageToSend;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox signBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox sentMessageHashBox;
        private System.Windows.Forms.Label label3ToChange;
        private System.Windows.Forms.RichTextBox decryptedSignHashBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem chooseSigningStandartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rSAToolStripMenuItem;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ToolStripMenuItem eCDSAToolStripMenuItem;
        private System.Windows.Forms.TextBox timeBox;

    }
}

