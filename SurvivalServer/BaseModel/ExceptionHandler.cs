using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseModel
{
    public static class ExceptionHandler
    {
        public static void Handle(Exception exception)
        {
            FLog.LogE("{0}", exception.ToString());
            // throw exception;
        }
    }
}
