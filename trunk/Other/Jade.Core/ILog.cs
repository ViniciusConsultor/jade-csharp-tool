using System;
namespace Jade
{
    public interface ILog
    {
        void Error(string msg);
        void Info(string msg);
        void Success(string msg);
        void Warn(string msg);
    }
}
