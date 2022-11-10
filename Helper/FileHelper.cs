using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using PhoneNumber.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PhoneNumber.Helper
{
    public class FileHelper
    {
        public static List<Phone> ImportExcelFile(string fileDir)
        {
            List<Phone> phoneNumberList = new List<Phone>();
            FileStream fs = new FileStream(fileDir, FileMode.Open);
            XSSFWorkbook wb = new XSSFWorkbook(fs);
            ISheet sheet = wb.GetSheetAt(0);

            if(sheet != null)
            {
                int row = sheet.LastRowNum;

                for(int i = 1; i <= row; i++)
                {
                    IRow rowValue = sheet.GetRow(i);

                    var phoneItem = new Phone(i, rowValue.GetCell(0).ToString());
                    phoneNumberList.Add(phoneItem);
                }
            }

            return phoneNumberList;
        }

        /*public static List<List<Phone>> ToGroupList(List<Phone> phoneNumberList, int groupCount)
        {
            var groupList = new List<List<Phone>>();
            var resize = Math.Ceiling((double)(phoneNumberList.Count / groupCount));

            for(int i = 0; i < groupCount; i++)
            {
                var phoneListTemp = new List<Phone>();

                for(int j = 0; j < resize; j++)
                {
                    phoneNumberList.Add(phoneNumberList.ElementAt(i * groupCount + j));
                }

                groupList.Add(phoneListTemp);
            }

            return groupList;
        }*/

        public static void ExportExcelFile(List<Phone> phoneNumberList, string dirOutput = "phoneOuput.xlsx")
        {
            FileStream fs = new FileStream(dirOutput, FileMode.CreateNew, FileAccess.Write);
            IWorkbook wb = new XSSFWorkbook();
            ISheet sheet = wb.CreateSheet("output");
            IRow rowHead = sheet.CreateRow(0);

            rowHead.CreateCell(0).SetCellValue("#STT");
            rowHead.CreateCell(1).SetCellValue("Số Điện Thoại");
            rowHead.CreateCell(2).SetCellValue("Họ tên");
            rowHead.CreateCell(3).SetCellValue("Trạng Thái");

            phoneNumberList.ForEach((item) => { 
                IRow rowvalue = sheet.CreateRow(item.id);

                rowvalue.CreateCell(0).SetCellValue(item.id);
                rowvalue.CreateCell(1).SetCellValue(item.phoneNumber);
                rowvalue.CreateCell(2).SetCellValue(item.name);
                rowvalue.CreateCell(3).SetCellValue(item.state);
            });

            wb.Write(fs);
        }

        public static void ShowDataToGridView(DataGridView dgv, List<Phone> phones)
        {
            dgv.Rows.Clear();
            foreach (var item in phones)
            {
                var row = (DataGridViewRow)dgv.Rows[0].Clone();

                row.Cells[0].Value = item.id;
                row.Cells[1].Value = item.phoneNumber;
                row.Cells[2].Value = item.name;
                row.Cells[3].Value = item.state;

                dgv.Rows.Add(row);
            }
        }

        public static string GetExtention(string fileDir)
        {
            string[] dir = fileDir.Split('\\');
            return dir[dir.Length - 1].Split('.')[1];
        }
    }
}
