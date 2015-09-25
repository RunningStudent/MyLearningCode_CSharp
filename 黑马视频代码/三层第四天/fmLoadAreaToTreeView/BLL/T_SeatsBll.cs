using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fmLoadArea.Model;
using fmLoadArea.DAL;

namespace fmLoadArea.BLL
{
    public class T_SeatsBll
    {
        public int Register(UserMsg um)
        {
            T_SeatsDal dal=new T_SeatsDal();
            um.CC_LoginPassWord = CommonHelper.GetMD5FromString(um.CC_LoginPassWord);
            return dal.Register(um);
        }
    }
}
