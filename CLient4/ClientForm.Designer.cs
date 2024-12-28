namespace CLient4
{
    partial class ClientForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button buttonRecord;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonCreateModel;
        private System.Windows.Forms.PictureBox pictureBoxVoice;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.TextBox userNameTextBox;

        private void InitializeComponent()
        {
            this.buttonRecord = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonCreateModel = new System.Windows.Forms.Button();
            this.pictureBoxVoice = new System.Windows.Forms.PictureBox();
            this.labelFile = new System.Windows.Forms.Label();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVoice)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRecord
            // 
            this.buttonRecord.Location = new System.Drawing.Point(12, 12);
            this.buttonRecord.Name = "buttonRecord";
            this.buttonRecord.Size = new System.Drawing.Size(75, 23);
            this.buttonRecord.TabIndex = 0;
            this.buttonRecord.Text = "Запись";
            this.buttonRecord.UseVisualStyleBackColor = true;
            this.buttonRecord.Click += new System.EventHandler(this.buttonRecord_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(12, 41);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 1;
            this.buttonSend.Text = "Отправить";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // buttonCreateModel
            // 
            this.buttonCreateModel.Location = new System.Drawing.Point(12, 65);
            this.buttonCreateModel.Name = "buttonCreateModel";
            this.buttonCreateModel.Size = new System.Drawing.Size(100, 23);
            this.buttonCreateModel.TabIndex = 2;
            this.buttonCreateModel.Text = "Создать модель";
            this.buttonCreateModel.UseVisualStyleBackColor = true;
            this.buttonCreateModel.Click += new System.EventHandler(this.buttonCreateModel_Click);
            // 
            // pictureBoxVoice
            // 
            this.pictureBoxVoice.Location = new System.Drawing.Point(155, 12);
            this.pictureBoxVoice.Name = "pictureBoxVoice";
            this.pictureBoxVoice.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxVoice.TabIndex = 3;
            this.pictureBoxVoice.TabStop = false;
            this.pictureBoxVoice.Visible = false;
            this.pictureBoxVoice.Click += new System.EventHandler(this.pictureBoxVoice_Click);
            // 
            // labelFile
            // 
            this.labelFile.AutoSize = true;
            this.labelFile.Location = new System.Drawing.Point(90, 75);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(0, 13);
            this.labelFile.TabIndex = 4;
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(97, 99);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(175, 20);
            this.userNameTextBox.TabIndex = 5;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 131);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.labelFile);
            this.Controls.Add(this.pictureBoxVoice);
            this.Controls.Add(this.buttonCreateModel);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.buttonRecord);
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVoice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

