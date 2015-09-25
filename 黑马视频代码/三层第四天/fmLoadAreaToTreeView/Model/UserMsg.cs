using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fmLoadArea.Model
{
    public class UserMsg
    {
        //CC_AutoId,CC_LoginId,CC_LoginPassWord,CC_UserName,CC_ErrorTimes,CC_LockDateTime,CC_TestInt
        public int CC_AutoId { get; set; }
        public string CC_LoginId { get; set; }
        public string CC_LoginPassWord { get; set; }
        public string CC_UserName { get; set; }
        public int ErrorTimes { get; set; }
        public DateTime? CC_LockDateTime { get; set; }
        public int CC_TestInt { get; set; }
    }
}
