'
' * 由SharpDevelop创建。
' * 用户： Administrator
' * 日期: 2015-1-31
' * 时间: 23:01
' * 
' * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
' 


Class Program
	Public Shared Function Jude(s As Integer) As String
		s /= 10
		Select Case s
			Case 9
				Return "优秀"
			Case 8
				Return "良"
			Case 6
				Return "中"
			Case Else
				Return "差"
		End Select
	End Function
	Public Shared Sub Main(args As String())
		'1.	编写一段程序，运行时向用户提问“你考了多少分？（0~100）”，
'		 * 接受输入后判断其等级并显示出来。判断依据如下：等级={优 （90~100分）；
'		* 良 （80~89分）；中 （60~69分）；差 （0~59分）；}

		Dim score As Integer
		Console.WriteLine("请输入您的成绩")
		score = Convert.ToInt16(Console.ReadLine())
		Console.WriteLine(Jude(score))
		Console.ReadKey()
	End Sub
End Class
