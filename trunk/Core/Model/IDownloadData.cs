using System;

namespace Jade.Model
{
    public interface IDownloadData
    {
        bool IsChecked { get; set; }
        int publishedIndex { get; }
        int editedIndex { get; }
        bool bbspinglun { get; set; }
        bool cmspinglun { get; set; }
        string comment_url { get; set; }
        string Content { get; set; }
        string CreateTime { get; set; }
        DateTime? DownloadTime { get; set; }
        string EditorUserName { get; set; }
        DateTime? EditTime { get; set; }
        string gfbm_id { get; set; }
        string gfbm_link { get; set; }
        int ID { get; set; }
        bool IsDownload { get; set; }
        bool IsEdit { get; set; }
        bool ISgfbm { get; set; }
        bool ISkfbm { get; set; }
        bool IsPublish { get; set; }
        string Keywords { get; set; }
        string kfbm_id { get; set; }
        string kfbm_link { get; set; }
        string label_base { get; set; }
        string news_abs { get; set; }
        string news_description { get; set; }
        string news_down { get; set; }
        string news_guideimage { get; set; }
        string news_guideimage2 { get; set; }
        string news_keywords2 { get; set; }
        string news_left { get; set; }
        string news_link { get; set; }
        string news_right { get; set; }
        string news_source_name { get; set; }
        string news_template_file { get; set; }
        string news_top { get; set; }
        string news_video { get; set; }
        string Other { get; set; }
        string Source { get; set; }
        string SubTitle { get; set; }
        string Summary { get; set; }
        int? TaskId { get; set; }
        string Title { get; set; }
        string Url { get; set; }
        int RemoteId { get; set; }
    }
}
