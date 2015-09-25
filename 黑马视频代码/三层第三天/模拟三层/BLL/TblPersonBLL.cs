using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 模拟三层.DAL;

namespace 模拟三层.BLL
{
    public class TblPersonBLL
    {

        /// <summary>
        /// 给指定编号的人的年龄+1
        /// </summary>
        /// <returns></returns>
        public bool AddAge(int id)
        {
            TblPersonDal addage = new TblPersonDal();
            return (addage.AddAge(id)>0);
        }
    }
}
