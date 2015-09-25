using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using StudentModel;

namespace MyStudentDAL
{
    public class MyStudentDal
    {
        /// <summary>
        /// 获得所有的班级信息
        /// </summary>
        /// <returns></returns>
        public List<StudentClass> GetClassMsg()
        {
            List<StudentClass> list = new List<StudentClass>();
            string sql = "select * from MyClass";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, System.Data.CommandType.Text))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        StudentClass sClass = new StudentClass();
                        sClass.ClassId = reader.GetInt32(0);
                        sClass.ClassName = reader.GetString(1);
                        list.Add(sClass);
                    }
                }
            }
            return list;
        }


        /// <summary>
        /// 插入一条新数据
        /// </summary>
        /// <param name="s">学生数据</param>
        /// <returns>数据库影响条数</returns>
        public int Insert(Student s)
        {
            string sql = "insert into MyStudent values(@name,@age,@gender,@math,@english,@classId,@birthday)";
            SqlParameter[] pars = new SqlParameter[]{
                new SqlParameter("@name",s.Name),
                new SqlParameter("@age",s.Age),
                new SqlParameter("@gender",s.Gender),
                new SqlParameter("@math",s.MathScore==null?DBNull.Value:(object)s.MathScore),
                new SqlParameter("@english",s.EnglishScore),
                new SqlParameter("@classId",s.Myclass.ClassId),
                new SqlParameter("@birthday",s.Birthday)
            };
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pars);
        }


        /// <summary>
        /// 获取前20条学生数据及其班级信息
        /// </summary>
        /// <returns></returns>
        public List<Student> GetTop20Data()
        {
            List<Student> list = new List<Student>();
            string sql = "select top 20 MyStudent.*,MyClass.className from MyStudent inner join MyClass on MyStudent.FClassId=MyClass.classId";
            //Fid	FName	FAge	FGender	  FMath	  FEnglish	FClassId	FBirthday	className
            using (SqlDataReader reader=SqlHelper.ExecuteReader(sql, System.Data.CommandType.Text))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Student s = new Student();
                        s.StudentId = reader.GetInt32(0);
                        s.Name = reader.GetString(1);
                        s.Age = reader.GetInt32(2);
                        s.Gender = reader.GetString(3);
                        s.MathScore = reader.IsDBNull(4) ? null : (int?)reader.GetInt32(4);
                        s.EnglishScore = reader.GetInt32(5);
                        s.Birthday = reader.GetDateTime(7);
                        

                        StudentClass studentClass = new StudentClass();
                        studentClass.ClassId = reader.GetInt32(6);
                        studentClass.ClassName = reader.GetString(8);
                        s.Myclass = studentClass;

                        list.Add(s);
                    }
                }
            }


            return list;
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="s"></param>
        /// <returns>数据库影响条数</returns>
        public int Update(Student s)
        {
            string sql = "update MyStudent set FName=@name,FAge=@age,FGender=@gender,FMath=@math,FEnglish=@english,FClassId=@classId,FBirthday=@birthday where Fid=@id";
            SqlParameter[] pas = new SqlParameter[]{
                new SqlParameter("@name",s.Name),
                new SqlParameter("@age",s.Age),
                new SqlParameter("@gender",s.Gender),
                new SqlParameter("@math",s.MathScore==null?DBNull.Value:(object)s.MathScore),
                new SqlParameter("@english",s.EnglishScore),
                new SqlParameter("@classId",s.Myclass.ClassId),
                new SqlParameter("@birthday",s.Birthday),
                new SqlParameter("@id",s.StudentId)
            };
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pas);
        }


        /// <summary>
        /// 根据学生id删除数据
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>数据库影响条数</returns>
        public int Delete(int studentId)
        {
            string sql = "delete MyStudent where Fid=@id";
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, new SqlParameter("@id", studentId));
        }
    }
}
