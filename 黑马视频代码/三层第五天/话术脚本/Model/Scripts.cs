using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 话术脚本.Model
{
    public class Scripts
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Msg { get; set; }
        public int ParentId { get; set; }
    }
}
