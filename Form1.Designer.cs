
namespace PhoneNumber
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
            this.menuFuture = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnFileImport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnFileExport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendAPhotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendAFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendMessageAndPhotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdSendFile = new System.Windows.Forms.RadioButton();
            this.rdSendPicture = new System.Windows.Forms.RadioButton();
            this.lblFileName = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pgbCheck = new System.Windows.Forms.ProgressBar();
            this.dgvPhoneNumber = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rdSendMessageAndPicture = new System.Windows.Forms.RadioButton();
            this.menuFuture.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhoneNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // menuFuture
            // 
            this.menuFuture.BackColor = System.Drawing.Color.Silver;
            this.menuFuture.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuFuture.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuFuture.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuFuture.Location = new System.Drawing.Point(0, 0);
            this.menuFuture.Name = "menuFuture";
            this.menuFuture.Size = new System.Drawing.Size(1010, 31);
            this.menuFuture.TabIndex = 0;
            this.menuFuture.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnFileImport,
            this.mnFileExport,
            this.mnExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(49, 27);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mnFileImport
            // 
            this.mnFileImport.Name = "mnFileImport";
            this.mnFileImport.Size = new System.Drawing.Size(166, 28);
            this.mnFileImport.Text = "Nhập File";
            this.mnFileImport.Click += new System.EventHandler(this.mnFileImport_Click);
            // 
            // mnFileExport
            // 
            this.mnFileExport.Name = "mnFileExport";
            this.mnFileExport.Size = new System.Drawing.Size(166, 28);
            this.mnFileExport.Text = "Xuất file ";
            this.mnFileExport.Click += new System.EventHandler(this.mnFileExport_Click);
            // 
            // mnExit
            // 
            this.mnExit.Name = "mnExit";
            this.mnExit.Size = new System.Drawing.Size(166, 28);
            this.mnExit.Text = "Thoát";
            this.mnExit.Click += new System.EventHandler(this.mnExit_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendMessageToolStripMenuItem,
            this.sendAPhotoToolStripMenuItem,
            this.sendAFileToolStripMenuItem,
            this.sendMessageAndPhotoToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(62, 27);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // sendMessageToolStripMenuItem
            // 
            this.sendMessageToolStripMenuItem.Name = "sendMessageToolStripMenuItem";
            this.sendMessageToolStripMenuItem.Size = new System.Drawing.Size(288, 28);
            this.sendMessageToolStripMenuItem.Text = "Send a Message";
            // 
            // sendAPhotoToolStripMenuItem
            // 
            this.sendAPhotoToolStripMenuItem.Name = "sendAPhotoToolStripMenuItem";
            this.sendAPhotoToolStripMenuItem.Size = new System.Drawing.Size(288, 28);
            this.sendAPhotoToolStripMenuItem.Text = "Send a Photo";
            // 
            // sendAFileToolStripMenuItem
            // 
            this.sendAFileToolStripMenuItem.Name = "sendAFileToolStripMenuItem";
            this.sendAFileToolStripMenuItem.Size = new System.Drawing.Size(288, 28);
            this.sendAFileToolStripMenuItem.Text = "Send a File";
            // 
            // sendMessageAndPhotoToolStripMenuItem
            // 
            this.sendMessageAndPhotoToolStripMenuItem.Name = "sendMessageAndPhotoToolStripMenuItem";
            this.sendMessageAndPhotoToolStripMenuItem.Size = new System.Drawing.Size(288, 28);
            this.sendMessageAndPhotoToolStripMenuItem.Text = "Send Message and Photo";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.rdSendMessageAndPicture);
            this.panel1.Controls.Add(this.rdSendFile);
            this.panel1.Controls.Add(this.rdSendPicture);
            this.panel1.Controls.Add(this.lblFileName);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnImport);
            this.panel1.Controls.Add(this.btnCheck);
            this.panel1.Controls.Add(this.txtMessage);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtPhoneNumber);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1010, 148);
            this.panel1.TabIndex = 1;
            // 
            // rdSendFile
            // 
            this.rdSendFile.AutoSize = true;
            this.rdSendFile.Location = new System.Drawing.Point(796, 61);
            this.rdSendFile.Name = "rdSendFile";
            this.rdSendFile.Size = new System.Drawing.Size(100, 24);
            this.rdSendFile.TabIndex = 7;
            this.rdSendFile.Text = "Send File";
            this.rdSendFile.UseVisualStyleBackColor = true;
            // 
            // rdSendPicture
            // 
            this.rdSendPicture.AutoSize = true;
            this.rdSendPicture.Checked = true;
            this.rdSendPicture.Location = new System.Drawing.Point(796, 20);
            this.rdSendPicture.Name = "rdSendPicture";
            this.rdSendPicture.Size = new System.Drawing.Size(126, 24);
            this.rdSendPicture.TabIndex = 6;
            this.rdSendPicture.TabStop = true;
            this.rdSendPicture.Text = "Send Picture";
            this.rdSendPicture.UseVisualStyleBackColor = true;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(12, 109);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(87, 20);
            this.lblFileName.TabIndex = 4;
            this.lblFileName.Text = "Filename: ";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(490, 61);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(150, 29);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export Excel file";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(490, 20);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(150, 29);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "Import file";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCheck.Location = new System.Drawing.Point(644, 20);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(144, 69);
            this.btnCheck.TabIndex = 5;
            this.btnCheck.Text = "Kiểm tra / Gửi";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(186, 62);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(283, 27);
            this.txtMessage.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nhập tin nhắn";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(186, 22);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(283, 27);
            this.txtPhoneNumber.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập số điện thoại";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.pgbCheck);
            this.panel2.Controls.Add(this.dgvPhoneNumber);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 179);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1010, 462);
            this.panel2.TabIndex = 2;
            // 
            // pgbCheck
            // 
            this.pgbCheck.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pgbCheck.Location = new System.Drawing.Point(0, 435);
            this.pgbCheck.Name = "pgbCheck";
            this.pgbCheck.Size = new System.Drawing.Size(1006, 23);
            this.pgbCheck.TabIndex = 1;
            // 
            // dgvPhoneNumber
            // 
            this.dgvPhoneNumber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhoneNumber.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.phoneNumber,
            this.name,
            this.state});
            this.dgvPhoneNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhoneNumber.Location = new System.Drawing.Point(0, 0);
            this.dgvPhoneNumber.MultiSelect = false;
            this.dgvPhoneNumber.Name = "dgvPhoneNumber";
            this.dgvPhoneNumber.ReadOnly = true;
            this.dgvPhoneNumber.RowHeadersWidth = 51;
            this.dgvPhoneNumber.RowTemplate.Height = 24;
            this.dgvPhoneNumber.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhoneNumber.Size = new System.Drawing.Size(1006, 458);
            this.dgvPhoneNumber.TabIndex = 0;
            // 
            // id
            // 
            this.id.HeaderText = "STT";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 125;
            // 
            // phoneNumber
            // 
            this.phoneNumber.HeaderText = "Số Điện Thoại";
            this.phoneNumber.MinimumWidth = 6;
            this.phoneNumber.Name = "phoneNumber";
            this.phoneNumber.ReadOnly = true;
            this.phoneNumber.Width = 125;
            // 
            // name
            // 
            this.name.HeaderText = "Họ tên";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 125;
            // 
            // state
            // 
            this.state.HeaderText = "Trạng thái";
            this.state.MinimumWidth = 6;
            this.state.Name = "state";
            this.state.ReadOnly = true;
            this.state.Width = 125;
            // 
            // rdSendMessageAndPicture
            // 
            this.rdSendMessageAndPicture.AutoSize = true;
            this.rdSendMessageAndPicture.Location = new System.Drawing.Point(796, 105);
            this.rdSendMessageAndPicture.Name = "rdSendMessageAndPicture";
            this.rdSendMessageAndPicture.Size = new System.Drawing.Size(213, 24);
            this.rdSendMessageAndPicture.TabIndex = 8;
            this.rdSendMessageAndPicture.Text = "Send Messagge & Picture";
            this.rdSendMessageAndPicture.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AcceptButton = this.btnCheck;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 641);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuFuture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuFuture;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check Phone Number Is Valid";
            this.menuFuture.ResumeLayout(false);
            this.menuFuture.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhoneNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuFuture;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnFileImport;
        private System.Windows.Forms.ToolStripMenuItem mnFileExport;
        private System.Windows.Forms.ToolStripMenuItem mnExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvPhoneNumber;
        private System.Windows.Forms.ProgressBar pgbCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn state;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendMessageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendAPhotoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendAFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendMessageAndPhotoToolStripMenuItem;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdSendFile;
        private System.Windows.Forms.RadioButton rdSendPicture;
        private System.Windows.Forms.RadioButton rdSendMessageAndPicture;
    }
}

