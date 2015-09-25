using System;
using System.Collections.Generic;
using System.Text;
using 用代码生成器生成的代码对数据库操作.DAL;
using 用代码生成器生成的代码对数据库操作.Model;

namespace 用代码生成器生成的代码对数据库操作.BLL
{

    public partial class MyClassBLL
    {
        public MyClass Add(MyClass myClass)
        {
            return new MyClassDAL().Add(myClass);
        }

        public int DeleteByClassId(int classId)
        {
            return new MyClassDAL().DeleteByClassId(classId);
        }

		public int Update(MyClass myClass)
        {
            return new MyClassDAL().Update(myClass);
        }
        

        public MyClass GetByClassId(int classId)
        {
            return new MyClassDAL().GetByClassId(classId);
        }
		public int GetTotalCount()
		{
			return new MyClassDAL().GetTotalCount();
		}
		
		public IEnumerable<MyClass> GetPagedData(int minrownum,int maxrownum)
		{
			return new MyClassDAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<MyClass> GetAll()
		{
			return new MyClassDAL().GetAll();
		}
    }
}
