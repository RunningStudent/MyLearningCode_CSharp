using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 模拟三层.DAL;
using 模拟三层.Model;

namespace 模拟三层.BLL
{
    /// <summary>
    /// TblSeat表的逻辑层
    /// </summary>
    public class TblSeatBLL
    {
        TbSeatDal dal = new TbSeatDal();
        /// <summary>
        /// 逻辑层:登入,能给密码MD5转化,返回bool
        /// </summary>
        /// <param name="uid">用户名</param>
        /// <param name="psw">密码</param>
        /// <returns>bool</returns>
        public bool Login(string uid, string psw)
        {
            return dal.Login(uid, CommonHelper.GetMD5FromString(psw)) >= 1;
        }

        /// <summary>
        /// 有三种状态:登入成功,密码错误,用户名不存在,故使用枚举单做返回值,如果登入成功返回用户信息
        /// </summary>
        /// <param name="uid">用户名</param>
        /// <param name="psw">密码</param>
        /// <param name="usermg">输出参数:用户信息</param>
        /// <returns></returns>
        public LoginReasult Login2(string uid, string psw, out UserMsg usermg)
        {
            UserMsg um = dal.GetUeserBaseMsgByLoginId(uid);
            usermg = null;
            if (um == null)
            {
                return LoginReasult.UserNameNoExist;
            }
            else if (um.Psw == CommonHelper.GetMD5FromString(psw))
            {
                usermg = um;
                return LoginReasult.Succeed;
            }
            else
            {
                return LoginReasult.PswError;
            }

        }



        /// <summary>
        /// 修改密码操作,进行了两个新密码相同性的判断,旧密码正确性的判断
        /// </summary>
        /// <param name="autoid"></param>
        /// <param name="oldPsw"></param>
        /// <param name="newPsw1"></param>
        /// <param name="newPsw2"></param>
        /// <returns></returns>
        public ChangePswReasult ChangePsw(int autoid, string oldPsw, string newPsw1, string newPsw2)
        {
            if (CheckNewPswsIsSome(newPsw1,newPsw2))
            {
                if (CheckOldPsw(CommonHelper.GetMD5FromString(oldPsw),autoid))
                {
                    //以防万一的判断
                    if (dal.UpdatePsw(autoid, CommonHelper.GetMD5FromString(newPsw1)) > 0)
                    {
                        return ChangePswReasult.Successed;
                    }
                    else
                    {
                        return ChangePswReasult.Failed;
                    }
                    
                }
                else
                {
                    return ChangePswReasult.ErrorOldPsw;
                }
            }
            else
            {
                return ChangePswReasult.DifPsw;
            }
        }


        /// <summary>
        /// 检查旧密码是否正确
        /// </summary>
        /// <param name="oldPsw">旧密码</param>
        /// <param name="autoid">用户信息编号</param>
        /// <returns></returns>
        public bool CheckOldPsw(string oldPsw,int autoid)
        {
            
            return dal.CheckOldPsw(oldPsw, autoid) > 0;
        }

        /// <summary>
        /// 判断两个密码是否相同
        /// </summary>
        /// <param name="psw1"></param>
        /// <param name="psw2"></param>
        /// <returns></returns>
        public bool CheckNewPswsIsSome(string psw1, string psw2)
        {
            return psw1 == psw2;
        }


    }
    public enum ChangePswReasult
    {
        /// <summary>
        /// 修改成功
        /// </summary>
        Successed,
        /// <summary>
        /// 两个新密码不一致
        /// </summary>
        DifPsw,
        /// <summary>
        /// 旧密码错误
        /// </summary>
        ErrorOldPsw,
        /// <summary>
        /// 未知原因,登入失败
        /// </summary>
        Failed
    }
    public enum LoginReasult
    {
        /// <summary>
        /// 登入成功
        /// </summary>
        Succeed,
        /// <summary>
        /// 用户名不存在
        /// </summary>
        UserNameNoExist,
        /// <summary>
        /// 密码错误
        /// </summary>
        PswError
    }
}
