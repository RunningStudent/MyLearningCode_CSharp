using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 模拟三层.UI
{
    /// <summary>
    /// 用静态类实现窗体间的数据传递
    /// </summary>
    /// 由于是窗体数据传递所以,这个类写在UI层中,如果写在业务层
    /// 那么当窗体改为web,那么业务层相应的方法则作废
    public static class GlobalFmData
    {
        static public int autoId;
    }
}
