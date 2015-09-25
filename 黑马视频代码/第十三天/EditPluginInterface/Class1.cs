using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EditPluginInterface
{
    public interface EditInterface
    {
         string name
        { get; }
         void Run(TextBox txtB);
        //应为是编辑插件,只要给它文本框对象就够了
    }
}
