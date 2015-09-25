using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 资料管理器_数据库_
{
    class Contentinfo
    {
        
        public string dName { get; set; }
        public string dContent { get; set; }
        public override string ToString()
        {
            return dName;
        }
    }
}
