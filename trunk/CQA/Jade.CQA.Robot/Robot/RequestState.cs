using System;
using System.Diagnostics;
using System.Net;

using Jade.CQA.Robot.Event;
using Jade.CQA.Robot.Services;
using Jade.CQA.Robot.Utils;

namespace Jade.CQA.Robot
{
    /// <summary>
    /// ����״̬
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RequestState<T>
    {
        #region Instance Properties

        /// <summary>
        /// �ɼ�����
        /// </summary>
        public CrawlStep CrawlStep { get; set; }

        /// <summary>
        /// ִ���쳣
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// ���ط�ʽ
        /// </summary>
        public DownloadMethod Method { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public PropertyBag PropertyBag { get; set; }

        /// <summary>
        /// ���ò���
        /// </summary>
        public CrawlStep Referrer { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public Action<RequestState<T>> Complete { private get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public Action<DownloadProgressEventArgs> DownloadProgress { get; set; }

        /// <summary>
        /// ���ؼ�ʱ��
        /// </summary>
        public Stopwatch DownloadTimer { get; set; }

        /// <summary>
        /// web����
        /// </summary>
        public HttpWebRequest Request { get; set; }

        /// <summary>
        /// ��Ӧbuffer
        /// </summary>
        public MemoryStreamWithFileBackingStore ResponseBuffer { get; set; }

        /// <summary>
        /// ���Դ���
        /// </summary>
        public int Retry { get; set; }

        /// <summary>
        /// ״̬
        /// </summary>
        public T State { get; set; }

        #endregion

        #region Instance Methods

        /// <summary>
        /// ִ����ɲ���
        /// </summary>
        /// <param name="propertyBag"></param>
        /// <param name="exception"></param>
        public void CallComplete(PropertyBag propertyBag, Exception exception)
        {
            Clean();

            PropertyBag = propertyBag;
            Exception = exception;
            Complete(this);
        }

        /// <summary>
        /// ����
        /// </summary>
        public void Clean()
        {
            if (ResponseBuffer != null)
            {
                ResponseBuffer.FinishedWriting();
                ResponseBuffer = null;
            }
        }

        #endregion
    }
}