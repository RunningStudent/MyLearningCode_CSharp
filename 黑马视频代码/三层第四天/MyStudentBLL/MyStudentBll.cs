using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyStudentDAL;
using StudentModel;

namespace MyStudentBLL
{
    public class MyStudentBll
    {
        MyStudentDal dal = new MyStudentDal();

        /// <summary>
        /// 获得所有班级信息
        /// </summary>
        /// <returns></returns>
        public List<StudentClass> GetClassMsg()
        {
            return dal.GetClassMsg();
        }


        /// <summary>
        /// 添加一条学生数据到数据库
        /// </summary>
        /// <param name="s">学生数据</param>
        /// <returns>数据库影响条数</returns>
        public int Insert(Student s)
        {
            return dal.Insert(s);
        }

        /// <summary>
        /// 获得前20条数据,这20数据在数据库中排序未知
        /// </summary>
        /// <returns></returns>
        public List<Student> GetTop20Data()
        {
            return dal.GetTop20Data();
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="s"></param>
        /// <returns>数据库影响条数</returns>
        public int Update(Student s)
        {
            return dal.Update(s);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns>数据库影响条数</returns>
        public int Delete(int studentID)
        {
            return dal.Delete(studentID);
        }
    }
}
