using System;
using log4net;

namespace NAPP.Ninject.Extensions.Logging.Log4Net
{
    public class Log4NetLogger : Domain.Infrastructure.Log.ILogger
    {
        private ILog _log;

        public Log4NetLogger(ILog log)
        {
            _log = log;

            IsDebugEnabled = true;
            IsErrorEnabled = true;
            IsInfoEnabled = true;

            log4net.Config.XmlConfigurator.Configure();
        }

        public void Debug(string message)
        {
            _log.Debug(message);
        }

        public void Debug(string format, params object[] args)
        {
            _log.DebugFormat(format, args);
        }

        public void Debug(Exception exception, string format, params object[] args)
        {
            _log.Debug(string.Format(format, args), exception);
        }

        public void DebugException(string message, Exception exception)
        {
            _log.Debug(message, exception);
        }

        public void Info(string message)
        {
            _log.Info(message);
        }

        public void Info(string format, params object[] args)
        {
            _log.InfoFormat(format, args);
        }

        public void Info(Exception exception, string format, params object[] args)
        {
            _log.InfoFormat(string.Format(format, args), exception);
        }

        public void InfoException(string message, Exception exception)
        {
            _log.Info(message, exception);
        }

        public void Trace(string message)
        {
            throw new NotImplementedException();
        }

        public void Trace(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Trace(Exception exception, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void TraceException(string message, Exception exception)
        {
            throw new NotImplementedException();
        }

        public void Warn(string message)
        {
            throw new NotImplementedException();
        }

        public void Warn(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Warn(Exception exception, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void WarnException(string message, Exception exception)
        {
            throw new NotImplementedException();
        }

        public void Error(string message)
        {
            _log.Error(message);
        }

        public void Error(string format, params object[] args)
        {
            _log.ErrorFormat(format, args);
        }

        public void Error(Exception exception, string format, params object[] args)
        {
            _log.Error(string.Format(format, args), exception);
        }

        public void ErrorException(string message, Exception exception)
        {
            throw new NotImplementedException();
        }

        public void Fatal(string message)
        {
            throw new NotImplementedException();
        }

        public void Fatal(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Fatal(Exception exception, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void FatalException(string message, Exception exception)
        {
            throw new NotImplementedException();
        }

        public Type Type { get; private set; }
        public string Name { get; private set; }
        public bool IsDebugEnabled { get; private set; }
        public bool IsInfoEnabled { get; private set; }
        public bool IsTraceEnabled { get; private set; }
        public bool IsWarnEnabled { get; private set; }
        public bool IsErrorEnabled { get; private set; }
        public bool IsFatalEnabled { get; private set; }
    }
}