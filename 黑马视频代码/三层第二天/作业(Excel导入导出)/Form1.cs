using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using System.Data.SqlClient;
using System.IO;

namespace 作业_Excel导入导出_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //数据导出为Excel
        private void btnExport_Click(object sender, EventArgs e)
        {

            string sql = "select CC_AutoId,CC_CustomerName,CC_CellPhone,CC_Landline,CC_BuyDate,CC_CarNum,CC_BracketNum from T_Customers";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text))
            {
                if (reader.HasRows)
                {

                    IWorkbook wb = new HSSFWorkbook();
                    ISheet sheet = wb.CreateSheet("customers");
                    int rowIndex = 0;//手动处理行索引
                    while (reader.Read())
                    {
                        int autoId = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string cellPhone = reader.GetString(2);
                        //数据为空,那么就不能Get..,所以要在这里判断
                        string landLine = reader.IsDBNull(3) ? null : reader.GetString(3);//可为空

                        DateTime BuyDate = reader.GetDateTime(4);
                        string carNum = reader.GetString(5);
                        string bracketNum = reader.GetString(6);
                        IRow row = sheet.CreateRow(rowIndex);
                        rowIndex++;

                        row.CreateCell(0).SetCellValue(autoId);
                        row.CreateCell(1).SetCellValue(name);
                        row.CreateCell(2).SetCellValue(cellPhone);
                        //如果为空或Null,把Excel这个单元格设置为值为空
                        if (string.IsNullOrEmpty(landLine))
                        {
                            row.CreateCell(3).SetCellType(CellType.BLANK);
                        }
                        else
                        {
                            row.CreateCell(3).SetCellValue(landLine);
                        }

                        //============设置日期格式=======
                        //创建单元格样式对象
                        ICellStyle cellStyle = wb.CreateCellStyle();
                        //设置单元格样式对象属性
                        cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("m/d/yy h:mm");
                        ICell BuyDateRow = row.CreateCell(4);
                        BuyDateRow.CellStyle = cellStyle;
                        BuyDateRow.SetCellValue(BuyDate);
                        //==============设置完成========

                        row.CreateCell(5).SetCellValue(carNum);
                        row.CreateCell(6).SetCellValue(bracketNum);

                    }
                    using (FileStream fs = File.OpenWrite("Customers.xls"))
                    {
                        wb.Write(fs);
                        MessageBox.Show("ok");
                    }
                }
            }
        }


        //Excel数据导入数据库,当
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "if((select COUNT(*) from T_Customers where CC_CarNum=@carNume and CC_BracketNum=@bracketNum)=0) begin  insert into T_Customers(CC_AutoId,CC_CustomerName,CC_CellPhone,CC_Landline,CC_BuyDate,CC_CarNum,CC_BracketNum)  values(@autoId,@customerName,@cellPhone,@landLine,@buyDate,@carNume,@bracketNum)  end";
            using (FileStream fs=File.OpenRead("Customers.xls"))
            {
                IWorkbook wb = new HSSFWorkbook(fs);
                ISheet sheet = wb.GetSheetAt(0);
                for (int i = 0; i < sheet.LastRowNum;i++ )
                {
                    IRow row = sheet.GetRow(i);

                    for (int j = 0; j <= row.LastCellNum;j++ )
                    {
                        int autoId = (int)row.GetCell(0).NumericCellValue;
                        string customerName = row.GetCell(1).StringCellValue;
                        string cellPhone = row.GetCell(2).StringCellValue;
                        //landLine,数据在设置SqlParameter时候获取,那时候做一些判断
                        DateTime buyDate = row.GetCell(4).DateCellValue;
                        string carNum = row.GetCell(5).StringCellValue;
                        string bracketNum = row.GetCell(6).StringCellValue;


                        //数据参数输入
                        SqlParameter[] pars = new SqlParameter[]{
                            new SqlParameter("@autoId",autoId),
                            new SqlParameter("@customerName",customerName),
                            new SqlParameter("@cellPhone",cellPhone),
                            
                            //可空数据判断
                            new SqlParameter("@landLine",row.GetCell(3).CellType==CellType.BLANK?
                            DBNull.Value:(object)row.GetCell(3).StringCellValue
                        ),
                            new SqlParameter("@autoId",autoId),
                            new SqlParameter("@buyDate",buyDate),
                            new SqlParameter("@carNume",carNum),
                            new SqlParameter("@bracketNum",bracketNum)
                        };

                        SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pars);



                    }
                }
            }
            MessageBox.Show("OK");

        }




    }
}
