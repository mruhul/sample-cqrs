using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Core.Logger;

namespace Sample.Infrastructure.Logger
{
    public class NLogLogger : ILogger
    {
        private readonly NLog.Logger _logger;

        public NLogLogger(string name)
        {
            _logger = NLog.LogManager.GetLogger(name);
        }

        public void Debug(string message)
        {
            if(_logger.IsDebugEnabled) _logger.Debug(message);
        }

        public void Debug(string message, params object[] args)
        {
            if (_logger.IsDebugEnabled) _logger.Debug(message, args);
        }
    }
}
