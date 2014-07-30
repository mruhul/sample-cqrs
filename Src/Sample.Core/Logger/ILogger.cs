using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Core.Logger
{
    public interface ILogger
    {
        void Debug(string message);
        void Debug(string message, params object[] args);
    }
}
