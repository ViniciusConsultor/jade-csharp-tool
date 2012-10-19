using System;

namespace Jade.CQA.Robot.Interfaces
{
    public interface IRobot
    {
        #region Instance Methods

        bool IsAllowed(string userAgent, Uri uri);

        #endregion
    }
}