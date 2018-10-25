using System;
using System.Collections.Generic;
using System.Text;

namespace Amcart.Core.ExceptionManagement
{
    public interface IExceptionHandler
    {
        Exception Process(Exception exception);
    }
}
