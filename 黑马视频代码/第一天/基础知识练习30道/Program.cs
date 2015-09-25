using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 基础知识练习30道
{
    class Program
    {
        #region 1.声明两个变量：int n1 = 10, n2 = 20;要求将两个变量交换，最后输出n1为20,n2为10。扩展（*）：不使用第三个变量如何交换？
        ////
        //static void Main(string[] args)
        //{
        //    int n1 = 10, n2 = 20;
        //    n1 += n2;
        //    n2 = n1 - n2;
        //    n1 -= n2;
        //    Console.WriteLine("n1={0},n2={1}", n1, n2);
        //    Console.ReadKey();
        //}
        #endregion

        #region 2.用方法来实现：将上题封装一个方法来做。提示：方法有两个参数n1,n2,在方法中将n1与n2进行交换，使用ref。（*）
        //static void Main(string[] args)
        //{
        //    int n1 = 10, n2 = 20;
        //    Change(ref n1,ref n2);
        //    Console.WriteLine("n1={0},n2={1}", n1, n2);
        //    Console.ReadKey();
        //}

        //private static void Change(ref int  n1,ref int n2)
        //{

        //    n1 += n2;
        //    n2 = n1 - n2;
        //    n1 -= n2;
        //}

        #endregion

        #region 3.请用户输入一个字符串，计算字符串中的字符个数，并输出。
        //static void Main(string[] args)
        //{
        //    string str;
        //    Console.WriteLine("输入一个字符串");
        //    str = Console.ReadLine();
        //    char c = str[0];
        //    int js=0;
        //    while (c != '\0')
        //    { 
        //        js++;
        //        c = str[js];
        //    }

        //    Console.WriteLine(js);
        //}

        #endregion

        #region 4.用方法来实现：计算两个数的最大值。
        ////思考：方法的参数？返回值？扩展（*）：计算任意多个数间的最大值（提示：params）。
        //static void Main(string[] args)
        //{

        //    Console.WriteLine(Max(1, 2));
        //    Console.ReadKey();
        //}
        //static int Max(params int[] sums)
        //{
        //    int max = sums[0];
        //    for (int i = 0; i < sums.Length; i++)
        //    {
        //        if (max < sums[i])
        //        {
        //            max = sums[i];
        //        }
        //    }
        //    return max;
        //}

        #endregion

        #region 5,用方法来实现：计算1-100之间的所有整数的和
        //static void Main(string[] args)
        //{
        //    Console.WriteLine(Calculate(100));
        //    Console.ReadKey();
        //}
        //static int Calculate(int n)
        //{
        //    int sum=0;
        //    for (int i = 0; i <= n; i++)
        //    {
        //        sum += i;
        //    }
        //    return sum;
        //}

        #endregion

        #region 6.用方法来实现：计算1-100之间的所有奇数的和。
        //static void Main(string[] args)
        //{

        //    int sum = 0;
        //    for (int i = 0; i < 101; i++)
        //    {
        //        if (i % 2 != 0)
        //            sum += i;
        //    }
        //    Console.WriteLine(sum);
        //    Console.ReadKey();
        //}

        #endregion

        #region  7.用方法来实现：判断一个给定的整数是否为“质数”。
        //static void Main(string[] args)
        //{
        //    int n;
        //    while (true)
        //    {
        //        Console.WriteLine("输入一个数字");
        //        n = Convert.ToInt16(Console.ReadLine());
        //        //Ctrl+K,M光标在方法上自动生成方法
        //        Console.WriteLine("这个数{0}素数", isZhi(n) ? "是" : "不是");

        //    }
        //}

        //private static bool isZhi(int n)
        //{
        //    if (n > 1)
        //    {
        //        for (int i = 2; i < (int)Math.Sqrt(n)+1;i++ )
        //        {
        //            if (n % i == 0)
        //                return false;
        //        }
        //        return true;
        //    }
        //    else
        //    {
        //        throw new ArgumentException("数字小于1的不是质数");
        //    }
        //}
        //#region 我写的
        ////static bool isZhi(int n)
        ////{
        ////    int i;
        ////    for (i = 2; i < n; i++)
        ////    {
        ////        if (n % i == 0)
        ////        {
        ////            break;
        ////        }
        ////    }
        ////    if (i >= n)
        ////        return true;
        ////    else
        ////        return false;
        ////}
        //#endregion


        #endregion

        #region  8.用方法来实现：计算1-100之间的所有质数（素数）的和。
        //static void Main(string[] args)
        //{
        //    int sum = 0;
        //    for (int i = 0; i < 101; i++)
        //    {
        //        if (isZhi(i))
        //        {
        //            sum += i;
        //        }
        //    }
        //    Console.WriteLine(sum);
        //    Console.ReadKey();
        //}
        //private static bool isZhi(int n)
        //{
        //    if (n > 1)
        //    {
        //        for (int i = 2; i < (int)Math.Sqrt(n) + 1; i++)
        //        {
        //            if (n % i == 0)
        //                return false;
        //        }
        //        return true;
        //    }
        //    else
        //    {
        //        throw new ArgumentException("数字小于1的不是质数");
        //    }
        //}
        //#region 我写的判断素数
        ////static bool isZhi(int n)
        ////{
        ////    int i;
        ////    for (i = 2; i < n; i++)
        ////    {
        ////        if (n % i == 0)
        ////        {
        ////            break;
        ////        }
        ////    }
        ////    if (i >= n)
        ////        return true;
        ////    else
        ////        return false;
        ////}
        //#endregion


        #endregion

        #region 9.用方法来实现：有一个整数数组：{ 1, 3, 5, 7, 90, 2, 4, 6, 8, 10 },找出其中最大值，并输出。不能调用数组的Max()方法。
        //static void Main(string[] args)
        //{
        //    int[] sums = { 1, 3, 5, 7, 90, 2, 4, 6, 8, 10 };
        //    Console.WriteLine(FindMax(sums));
        //}
        //static int FindMax(int[] sums)
        //{
        //    int max = sums[0];
        //    for (int i = 0; i < sums.Length; i++)
        //    {
        //        if (max < sums[i])
        //        {
        //            max = sums[i];
        //        }
        //    }
        //    return max;
        //}

        #endregion

        #region  10.用方法来实现：有一个字符串数组：{ "马龙", "迈克尔乔丹", "雷吉米勒", "蒂姆邓肯", "科比布莱恩特" },请输出最长的字符串。
        //static void Main(string[] args)
        //{
        //    string[] str = { "马龙", "迈克尔乔丹", "雷吉米勒", "蒂姆邓肯", "科比布莱恩特" };
        //     Console.WriteLine("最长字符串是:{0}",FindLongest(str));
        //     Console.ReadKey();
        //}
        //static string FindLongest(string[] str)
        //{
        //    string longest = str[0];
        //    for (int i = 0; i < str.Length; i++)
        //    {
        //        if (longest.Length < str[i].Length)
        //        {
        //            longest = str[i];
        //        }
        //    }
        //    return longest;
        //}

        #endregion

        #region 11.用方法来实现：请计算出一个整型数组的平均值。{ 1, 3, 5, 7, 90, 2, 4, 6, 8, 10 }。要求：计算结果如果有小数，则显示小数点后两位（四舍五入）。
        //static void Main(string[] args)
        //{
        //    int[] sums = { 1, 3, 5, 7, 90, 2, 4, 6, 8, 10 };
        //    double average = sums.Average() ;
        //    Console.WriteLine("{0:0.00}",average);
        //    Console.ReadKey();
        //}
        #endregion

        #region 12.请通过冒泡排序法对整数数组{ 1, 3, 5, 7, 90, 2, 4, 6, 8, 10 }实现升序排序。
        //static void Main(string[] args)
        //{
        //    int[] sums = { 1, 3, 5, 7, 90, 2, 4, 6, 8, 10 };
        //    MaoSort(sums);

        //    foreach (var item in sums)
        //    {
        //        Console.Write("{0} ", item);
        //    }
        //    Console.ReadKey();
        //}

        //private static void MaoSort(int[] sums)
        //{
        //    for (int i = 0; i < sums.Length-1; i++)
        //    {
        //        for (int j = i; j < sums.Length - i - 1; j++)
        //        {
        //            if (sums[j + 1] < sums[j])
        //            {
        //                sums[j + 1] = sums[j] + (sums[j] = sums[j + 1]) * 0;
        //            }
        //        }
        //    }
        //}
        #endregion

        #region 13.有如下字符串：【"患者：“大夫，我咳嗽得很重。”     大夫：“你多大年记？”     患者：“七十五岁。”
        //大夫：“二十岁咳嗽吗”患者：“不咳嗽。”     大夫：“四十岁时咳嗽吗？”     患者：“也不咳嗽。”     大夫：“那现在不咳嗽，还要等到什么时咳嗽？”"】
        //需求：①请统计出该字符中“咳嗽”二字的出现次数，以及每次“咳嗽”出现的索引位置。②扩展（*）：统计出每个字符的出现次数。
        //static void Main(string[] args)
        //{
        //    string str = "患者：“大夫，我咳嗽得很重。”     大夫：“你多大年记？”     患者：“七十五岁。”     大夫：“二十岁咳嗽吗”患者：“不咳嗽。”     大夫：“四十岁时咳嗽吗？”     患者：“也不咳嗽。”     大夫：“那现在不咳嗽，还要等到什么时咳嗽？”";
        //    int count = 0;
        //    int t = 0;
        //    List<int> index = new List<int>();
        //    while (str.IndexOf("咳嗽", t) != -1)
        //    {
        //        index.Add(str.IndexOf("咳嗽", t));
        //       t = str.IndexOf("咳嗽", t) + 2;//咳嗽是两个字,可以跳过两个
        //        count++;
        //    }
        //    Console.WriteLine("咳嗽出现{0}次,分别在:", count);
        //    foreach (var item in index)
        //    {
        //        Console.Write(item + " ");
        //    }
        //     //拓展:
        //    Dictionary<char, int> d = new Dictionary<char, int>();
        //    foreach (var item in str)
        //    {
        //        if (!d.ContainsKey(item))
        //        {
        //            d[item] = 1;
        //        }
        //        else
        //        {
        //            d[item]++;
        //        }
        //    }
        //    foreach (KeyValuePair<char, int> item in d)
        //    {
        //        Console.WriteLine("{0},{1}", item.Key, item.Value);
        //    }
        //    Console.ReadKey();
        //}
        #endregion


        #region 14.将字符串"  hello      world,你  好 世界   !    "两端空格去掉，并且将其中的所有其他空格都替换成一个空格，输出结果为："hello world,你 好 世界 !"。
        //static void Main(string[] args)
        //{
        //    string str = "  hello      world,你  好 世界   !    ";
        //    str=str.Trim();
        //    string[] newstr = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        //    str = string.Join(" ", newstr);
        //    Console.WriteLine(str);
        //    Console.ReadKey();
        //}
        #endregion

        #region 15.请统计出数组：{1,2,3,4,5,6,7,8,9,1,2,3,79,23,45,64,9,3,2,4}中的不重复的数字的个数。
        //static void Main(string[] args)
        //{
        //    int[] sums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 79, 23, 45, 64, 9, 3, 2, 4};
        //    #region 方法一
        //    //List<int> s = new List<int>(sums);
        //    //int js = 0;
        //    //foreach (var item in s)
        //    //{
        //    //    if (s.Count(x => x == item) == 1)
        //    //        js++;
        //    //}
        //    //Console.WriteLine(js);
        //    #endregion
        //    #region 删除重复的数字
        //    Array.Sort(sums);
        //    List<int> intList = new List<int>();
        //    for (int i = 0; i < sums.Length-1; i++)
        //    {
        //        if (sums[i] != sums[i + 1])//如果后一个与当前的不一样,就加入
        //        {
        //            intList.Add(sums[i]);
        //        }
        //    }
        //    //举个例子:1 2 3 3 3 3 3 3,自行想象,最后一个必须加
        //    intList.Add(sums[sums.Length - 1]);
        //    foreach (int item in intList)
        //    {
        //        Console.WriteLine(item);
        //    }
        //    #endregion
        //    Console.ReadKey();
        //}
        #endregion

        #region 乱入之把一个整形转换为2进制
        //static void Main(string[] args)
        //{
        //    int number;
        //    Console.WriteLine("输入一个数");
        //    number = Convert.ToInt16(Console.ReadLine());
        //    string str = ChangeToBinary(number);
        //    Console.WriteLine(str);
        //    Console.ReadKey();
        //}

        //private static string ChangeToBinary(int number)
        //{
        //    //视频里用的是泛型集合
        //    StringBuilder sb = new StringBuilder();
        //    int yuShu=0;
        //    int Shang;
        //    while (number > 2)
        //    {
        //        yuShu = number % 2;
        //        sb.Append(yuShu.ToString());
        //        Shang = number / 2;
        //        number = Shang;
        //    }
        //    sb.Append(yuShu.ToString());
        //    char []chs=sb.ToString().ToCharArray();
        //    Array.Reverse(chs);
        //    return new string(chs);
        //}
        #endregion

        #region 乱入之9*9表
        //static void Main(string[] args)
        //{
        //    for (int i = 1; i < 10; i++)
        //    {
        //        for (int j = 1; j < i+1; j++)
        //        {
        //            Console.Write("{0}*{1}={2}\t", i, j, i * j);
        //        }
        //        Console.WriteLine();
        //    }

        //    Console.ReadKey();
        //}
        #endregion

        #region 乱入之模拟Trim()
        //static void Main(string[] args)
        //{
        //    string str = "      好多空格     ";
        //    #region 方法一
        //    //List<char> charList = new List<char>(str);
        //    //while (charList[0] == ' ')
        //    //{
        //    //    charList.RemoveAt(0);
        //    //}
        //    //while (charList[charList.Count - 1] == ' ')
        //    //{
        //    //    charList.RemoveAt(charList.Count - 1);
        //    //}
        //    //foreach (var item in charList)
        //    //{
        //    //    Console.Write(item);
        //    //}
        //    #endregion
        //    #region 伪方法二
        //    List<char> charList = new List<char>(str);
        //    charList.RemoveAll(x => x == ' ');
        //    foreach (var item in charList)
        //    {
        //        Console.Write(item);
        //    }
        //    Console.ReadKey();
        //    #endregion

        //    #region 视频方法
        //    int start = 0;
        //    int end = str.Length - 1;
        //    while (start < end)
        //    {
        //        if (!char.IsWhiteSpace(str[start]))
        //        {
        //            break;
        //        }
        //        start++;
        //    }
        //    while (end >= start)
        //    {
        //        if (char.IsWhiteSpace(str[end]))
        //        {
        //            break;
        //        }
        //        end--;
        //    }
        //    str = str.Substring(start, end -start+ 1);//右不取
        //    Console.WriteLine(str);
        //    #endregion
        //}
        #endregion

        #region 16.制作一个控制台小程序。要求：用户可以在控制台录入每个学生的姓名，当用户输入quit（不区分大小写）时，程序停止接受用户的输入，
        //并且显示出用户输入的学生的个数，以及每个学生的姓名。
        //static void Main(string[] args)
        //{
        //    List<string> names = new List<string>();
        //    string name = null;
        //    while (true)
        //    {
        //        Console.WriteLine("输入姓名");
        //        name = Console.ReadLine();
        //        if (name.ToLower() == "quit")
        //            break;
        //        else
        //            names.Add(name);
        //    }
        //    Console.WriteLine("你一共输入了{0}个名字",names.Count);
        //    foreach (var item in names)
        //    {
        //        Console.WriteLine(item);
        //    }
        //    Console.ReadKey();

        //}
        #endregion

        #region 17,制作一个控制台小程序。要求：用户可以在控制台录入每个学生的姓名，当用户输入quit（不区分大小写）时，程序停止接受用户的输入，再增加一个显示姓“王”的同学的个数，此处不考虑复姓问题。
        //static void Main(string[] args)
        //{
        //    List<string> names = new List<string>();
        //    string name = null;
        //    while (true)
        //    {
        //        Console.WriteLine("输入姓名");
        //        name = Console.ReadLine();//输入时候就能判断是否有'王'
        //        if (name.ToLower() == "quit")
        //            break;
        //        else
        //            names.Add(name);
        //    }
        //    Console.WriteLine("你一共输入了{0}个名字", names.Count);
        //    foreach (var item in names)
        //    {
        //        Console.WriteLine(item);
        //    }
        //    Console.WriteLine("姓王的同学一共有{0}个",names.Count(x=>x[0]=='王'));
        //    Console.ReadKey();
        //}
        #endregion

        #region 18.将普通日期格式：“2011年6月4日” 转换成汉字日期格式：“二零一一年六月四日”。暂时不考虑10日、13日、23日等“带十”的问题。
        //static void Main(string[] args)
        //{
        //    //另一种方法switch case
        //    Dictionary<char, char> date = new Dictionary<char, char>();
        //    date.Add('1', '一');
        //    date.Add('2', '二');
        //    date.Add('3', '三');
        //    date.Add('4', '四');
        //    date.Add('5', '五');
        //    date.Add('6', '六');
        //    date.Add('7', '七');
        //    date.Add('8', '八');
        //    date.Add('9', '九');
        //    string str = "2011年6月4日";
        //    StringBuilder sb = new StringBuilder();
        //    foreach (var item in str)
        //    {
        //        if (date.ContainsKey(item))
        //        {
        //            sb.Append(date[item]);
        //        }
        //        else
        //        {
        //            sb.Append(item);
        //        }
        //    }
        //    Console.WriteLine(sb.ToString());
        //    Console.ReadKey();
        //}
        #endregion

        #region 19.创建一个Person类，属性：姓名、性别、年龄；方法：SayHi() 。再创建一个Employee类继承Person类，扩展属性Salary,重写SayHi方法。
        //public class Person
        //{
        //    public string name { get; set; }
        //    public string sex { get; set; }
        //    public int age { get; set; }
        //    public virtual void SayHi()
        //    {
        //        Console.WriteLine("我是人,哈哈哈哈");
        //    }
        //}
        //public class Emploee : Person
        //{
        //    public int Salary { get; set; }
        //    public override void SayHi()
        //    {
        //        Console.WriteLine("我是员工");
        //    }
        //}

        //static void Main(string[] args)
        //{
        //    Person p = new Person();
        //    p.SayHi();
        //    p = new Emploee();
        //    p.SayHi();
        //    Console.ReadKey();
        //}
        #endregion

        #region 20.请编写一个类：ItcastClass,该类中有一个私有字段_names,数据类型为：字符串数组，长度为5，并且有5个默认的姓名。
        //要求：为ItcastClass类编写一个索引器，要求该索引器能够通过下标来访问_names中的内容。
        static void Main(string[] args)
        {
            ItcastClass a = new ItcastClass();
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }
            Console.ReadKey();
        }
        class ItcastClass
        {
            private string[] _names = { "A", "B", "C", "D", "E" };
            public int Length = 5;
            public string this[int index]
            {
                set
                {
                    _names[index] = value;
                }
                get
                {
                    return _names[index];
                }
            }
        }


        #endregion

        #region 23.请将字符串数组{ "中国", "美国", "巴西", "澳大利亚", "加拿大" }中的内容反转。然后输出反转后的数组。不能用数组的Reverse()方法。
        //static void Main(string[] args)
        //{
        //    string[] strs = { "中国", "美国", "巴西", "澳大利亚", "加拿大" };
        //    string temp = null;
        //    for (int i = 0; i < strs.Length/2; i++)
        //    {
        //        temp = strs[i];
        //        strs[i] = strs[strs.Length - 1 - i];
        //        strs[strs.Length - 1 - i] = temp;
        //    }
        //    foreach (string item in strs)
        //    {
        //        Console.WriteLine(item);
        //    }
        //    Console.ReadKey();
        //}
        #endregion



    }
}
