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
using System.IO;
using System.Data.SqlClient;


namespace 用NPOI操作Excel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //将一个集合中的数据写入到Excel
        private void btnInclude_Click(object sender, EventArgs e)
        {
            //对象初始化器
            List<Person> list = new List<Person>(){
                new Person(){Name="路人甲",Age=18,Mail="J@qq.com"},
                new Person(){Name="路人乙",Age=28,Mail="Y@qq.com"},
                new Person(){Name="路人丙",Age=38,Mail="B@qq.com"},
            };

            //创建工作簿
            IWorkbook wb = new HSSFWorkbook();
            //创建工作表
            ISheet sheet = wb.CreateSheet("测试");
            //创建行
            for (int i = 0; i < list.Count();i++ )
            {
                IRow row=sheet.CreateRow(i);
                //创建单元格
                row.CreateCell(0).SetCellValue(list[i].Name);
                row.CreateCell(1).SetCellValue(list[i].Age);
                row.CreateCell(2).SetCellValue(list[i].Mail);
            }
            using (FileStream fs=File.OpenWrite("NewTestExcel.xls"))
            {
                wb.Write(fs);
            }
            MessageBox.Show("Ok");
        }


        //导出Excel数据
        private void btnExport_Click(object sender, EventArgs e)
        {
            //用一个流给工作薄传输文件
            using (FileStream fs = File.OpenRead("ReadExcel.xls"))
            {
                //创建工作薄对象,传入文件流
                IWorkbook wBook = new HSSFWorkbook(fs);

                //获得工作表的数量,根据工作表的数量,循环获得每个工作表
                for (int i = 0; i < wBook.NumberOfSheets; i++)
                {
                    //根据工作表索引获得工作表
                    ISheet sheet = wBook.GetSheetAt(i);
                    //打印工作表名字
                    Console.WriteLine("==================={0}==================", sheet.SheetName);

                    //获得工作表的行数,并获得没一行,这里用的是最后一个行的!!索引!!,所以要<=
                    for (int j = 0; j <= sheet.LastRowNum; j++)
                    {
                        //获得行
                        IRow row = sheet.GetRow(j);

                        //获得单元格,奇怪的是LastCellNum是最后一个单元格+1,所以不要k<=
                        for (int k = 0; k < row.LastCellNum; k++)
                        {
                            ICell cell = row.GetCell(k);
                            //打印
                            //可以点出多种格式的cellValue
                            //如果实际数据与代码不相符则报错
                            //为了可以用toString()把数据类型统一化再输出
                            Console.Write("{0}\t", cell.ToString());
                        }

                        Console.WriteLine();
                    }
                }
            }

        }


        //从数据库中导出数据为Excel
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "Select * from T_Seats";
            IWorkbook wb = new HSSFWorkbook();

            using (SqlDataReader reader=SqlHelper.ExecuteReader(sql,CommandType.Text))
            {
                if (reader.HasRows)
                {
                    ISheet sheet = wb.CreateSheet("T_Seats");
                    int rowIndex = 0;//创建变量控制数据行的索引
                    while (reader.Read())
                    {
                        //获取数据
                        int autoID = reader.GetInt32(0);
                        string uid = reader.GetString(1);
                        string psw = reader.GetString(2);
                        string username = reader.GetString(3);
                        int errorTimes = reader.GetInt32(4);
                        //可空类型判断
                        DateTime? lockDate = reader.IsDBNull(5) ? null : (DateTime?)reader.GetDateTime(5);
                        int? testId = reader.IsDBNull(6) ? null : (int?)reader.GetInt32(6);

                        //数据写入
                        IRow row=sheet.CreateRow(rowIndex);//行创建
                        rowIndex++;
                        row.CreateCell(0).SetCellValue(autoID);
                        row.CreateCell(1).SetCellValue(uid);
                        row.CreateCell(2).SetCellValue(psw);
                        row.CreateCell(3).SetCellValue(username);
                        row.CreateCell(4).SetCellValue(errorTimes);
                        //可空类型处理
                        ICell lockDateCell = row.CreateCell(5);
                        ICell testIdCell=row.CreateCell(6);
                        
                        if (lockDate == null)
                        {
                            //如果数据为NUll,设置该单元格数据为空
                            lockDateCell.SetCellType(CellType.BLANK);
                        }
                        else
                        {
                            lockDateCell.SetCellValue((DateTime)lockDate);

                            //设置日期格式

                            //创建单元格样式对象
                            ICellStyle cellStyle = wb.CreateCellStyle();
                            //设置单元格样式对象属性
                            cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("m/d/yy h:mm");
                            //设置单元格对象属性
                            lockDateCell.CellStyle = cellStyle;                        }

                        if (testId==null)
                        {
                            testIdCell.SetCellType(CellType.BLANK);
                        }
                        else
                        {
                            testIdCell.SetCellValue((int)testId);
                        }
                    }
                }
            }

            using (FileStream fs=File.OpenWrite("T_Seats.xls"))
            {
                wb.Write(fs);
            }
            MessageBox.Show("ok");


        }
        
        //Excel导入数据库
        private void button2_Click(object sender, EventArgs e)
        {
            using (FileStream fs=File.OpenRead("T_Seats.xls"))
            {
                IWorkbook wb = new HSSFWorkbook(fs);

                ISheet sheet = wb.GetSheetAt(0);
                for (int i = 0; i <= sheet.LastRowNum;i++)
                {
                    IRow row = sheet.GetRow(i);
                    //string autoId = row.GetCell(0).StringCellValue;

                    string uid = row.GetCell(1).StringCellValue;
                    string psw = row.GetCell(2).StringCellValue;
                    string username = row.GetCell(3).StringCellValue;
                    int errorTimes = (int)row.GetCell(4).NumericCellValue;
                    DateTime lockDate=DateTime.FromOADate(row.GetCell(5).NumericCellValue);
                    //仅仅是double类型传入数据库也能能变成DateTime格式,但是有点偏差
                    int testId =(int) row.GetCell(6).NumericCellValue;
                    string sql = "insert into T_Seats values(@uid,@psw,@username,@errorTimes,@lockDate,@testID)";

                    SqlParameter[] pars = new SqlParameter[]{
                        new SqlParameter("@uid",uid),
                        new SqlParameter("@psw",psw),
                        new SqlParameter("@username",username),
                        new SqlParameter("@errorTimes",errorTimes),

                        //从Excel文件读取该单元格,如果单元格的数值为空,获得该单元格为Null,把传入数据库的数据设置为Null
                        new SqlParameter("@lockDate",
                            (row.GetCell(5)!=null&&row.GetCell(5).CellType!=CellType.BLANK)?(object)lockDate:DBNull.Value),

                        new SqlParameter("@testID",(row.GetCell(6)!=null&&row.GetCell(6).CellType!=CellType.BLANK)?(object)lockDate:DBNull.Value)
                    };

                    SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pars);
                }
            }

            MessageBox.Show("ok");
        }


        

    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string  Mail { get; set; }
    }
}
