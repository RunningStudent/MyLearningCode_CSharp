using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocketProgram.IISClass
{
    public interface IHttpProcess
    {
        void ProcessRequest(HttpContext context);
    }
}
