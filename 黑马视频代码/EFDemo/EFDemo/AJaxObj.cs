using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFDemo
{
    /// <summary>
    /// 包装类，以后所有的逻辑都会使用此包装类进行json字符串的序列化
    /// </summary>
    public class AjaxObj
    {
        /// <summary>
        /// 状态
        /// </summary>
        public string status
        {
            get;
            set;
        }

        /// <summary>
        /// 这是提示的文本
        /// </summary>
        public string msg
        {
            get;
            set;
        }

        /// <summary>
        /// 真正的逻辑数据集合(有可能是数组，有可能是对象)
        /// </summary>
        public object datas
        {
            get;
            set;
        }
    }

}