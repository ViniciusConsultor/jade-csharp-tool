using System;
namespace Com.iFLYTEK.WinForms.Browser
{
    public interface IBaseBrowserForm
    {
        void GoBack();
        void GoForward();
        void GoNavigate();
        void RefreshBrowser();
        void Stop();
    }
}
