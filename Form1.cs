using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using PhoneNumber.Helper;
using PhoneNumber.Models;
using System.Collections.Specialized;

namespace PhoneNumber
{
    public partial class Form1 : Form
    {
        private List<Phone> phoneNumberList;
        
        public Form1()
        {
            InitializeComponent();
            phoneNumberList = new List<Phone>();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if(phoneNumberList.Count != 0)
            {
                var helper = new SeleniumHelper();

                helper.CheckPhoneNumbers(phoneNumberList, 0, pgbCheck);
                FileHelper.ShowDataToGridView(dgvPhoneNumber, phoneNumberList);
                if (MessageBox.Show("Xuất File Excel?", "Thông báo", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes
                ) btnExport_Click(sender, e);
            }
            else if(txtPhoneNumber.Text != null)
            {
                
                string dir = lblFileName.Text;
                string phoneNumber = txtPhoneNumber.Text;

                if(rdSendFile.Checked || rdSendPicture.Checked)
                {
                    Thread thread1 = new Thread(() =>
                    {
                        var helper = new SeleniumHelper();
                        helper.SendFile(phoneNumber, dir);
                    });
                } 
                else
                {
                    Thread thread1 = new Thread(() =>
                    {
                        var helper = new SeleniumHelper();
                        helper.SendMessageAndPicture(phoneNumber, dir, txtMessage.Text);
                    });
                    Thread thread2 = new Thread(() =>
                    {
                        var helper = new SeleniumHelper(@"C:\Users\LENOVO\AppData\Local\Google\Chrome\User Data 1");
                        helper.SendMessageAndPicture(phoneNumber, dir, txtMessage.Text);
                    });
                    thread1.IsBackground = true;
                    thread2.IsBackground = true;
                    thread1.Start();
                    thread2.Start();

                } 
                
            } 
            else
            {
                MessageBox.Show("Nhập số điện thoại hoặc file để kiểm tra");
            }
        }
        
        private void btnExport_Click(object sender, EventArgs e)
        {
            var fd = new SaveFileDialog();
            fd.DefaultExt = ".xlsx";
            var stateOpen = fd.ShowDialog();

            if(stateOpen != DialogResult.Cancel)
            {
                FileHelper.ExportExcelFile(phoneNumberList, fd.FileName);
            }
        }

        private void mnFileExport_Click(object sender, EventArgs e)
        {
            btnExport_Click(sender, e);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            var fd = new OpenFileDialog();
            var stateOpen = fd.ShowDialog();

            if (stateOpen != DialogResult.Cancel)
            {
                string fileExt = FileHelper.GetExtention(fd.FileName);
                lblFileName.Text = fd.FileName;
                if (fileExt == "xlsx" || fileExt == "xls")
                {
                    phoneNumberList = FileHelper.ImportExcelFile(fd.FileName);
                    FileHelper.ShowDataToGridView(dgvPhoneNumber, phoneNumberList);
                } 
                else
                {
                    StringCollection FileCollection = new StringCollection();
                    FileCollection.Add(fd.FileName);
                    Clipboard.SetFileDropList(FileCollection);
                }
            }
        }

        private void mnFileImport_Click(object sender, EventArgs e)
        {
            btnImport_Click(sender, e);
        }


        private void mnExit_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("Thoát?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes
            ) this.Close();
        }
    }
}
