using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 模拟三层.Model
{
    public class UserMsg
    {
        //CC_AutoID
        //CC_LoginId
        //CC_LoginPassword
        //CC_UserName
        //
        public int AutoId { get; set; }
        public string LoginId { get; set; }
        public string Psw { get; set; }
        public string UserName { get; set; }
    }
}
