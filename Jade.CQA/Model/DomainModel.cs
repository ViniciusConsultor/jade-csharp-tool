﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jade.CQA.Model
{
    /// <summary>
    /// 知识类型
    /// </summary>
    public enum KnowedgeType
    {
        /// <summary>
        /// 百度知道
        /// </summary>
        BaiduZhidao = 0,
        /// <summary>
        /// 搜搜问问
        /// </summary>
        SosoWenwen = 1,

        /// <summary>
        /// 新浪爱问
        /// </summary>
        iAsk = 2
    }

    /// <summary>
    /// 基础对象
    /// </summary>
    public class BaseModel
    {
        public KnowedgeType KnowedgeType
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 问题
    /// </summary>
    public class Question : BaseModel
    {
        private string _id;
        private string _title;
        private string _content;
        private string _viewCount;
        private DateTime _createTime;
        private string _category;
        private string _tags;
        private string _url;
        private string _state;

        public Question()
        {
        }

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// 问题标题
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// 问题内容、补充内容
        /// </summary>
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        /// <summary>
        /// 查看次数
        /// </summary>
        public string ViewCount
        {
            get { return _viewCount; }
            set { _viewCount = value; }
        }
        
        /// <summary>
        /// 问题提问时间
        /// </summary>
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

        /// <summary>
        /// 分类
        /// </summary>
        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        /// <summary>
        /// 问题标签
        /// </summary>
        public string Tags
        {
            get { return _tags; }
            set { _tags = value; }
        }

        /// <summary>
        /// Url地址
        /// </summary>
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        /// <summary>
        /// 问题状态
        /// </summary>
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }
    }

    /// <summary>
    /// 答案
    /// </summary>
    public class Answer : BaseModel
    {
        private string _answerId;
        private string _userName;
        private DateTime _createTime;
        private string _content;
        private int _up;
        private int _down;
        private int _commentCount;

        public Answer()
        {
        }

        public string AnswerId
        {
            get { return _answerId; }
            set { _answerId = value; }
        }

        /// <summary>
        /// 回答人
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        /// <summary>
        /// 回答时间
        /// </summary>
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        /// <summary>
        /// 赞同数目
        /// </summary>
        public int Up
        {
            get { return _up; }
            set { _up = value; }
        }
        
        /// <summary>
        /// 踩数目
        /// </summary>
        public int Down
        {
            get { return _down; }
            set { _down = value; }
        }

        /// <summary>
        /// 评论数目
        /// </summary>
        public int CommentCount
        {
            get { return _commentCount; }
            set { _commentCount = value; }
        }
    }

    /// <summary>
    /// 问题与答案
    /// </summary>
    public class QuestionAnswer : BaseModel
    {
        private string _questionId;
        private List<string> _satisfiedAnswerIds;
        private List<string> _recommendedAnswerIds;
        private List<string> _relatedQuestionIds;

        public QuestionAnswer()
        {
        }

        /// <summary>
        /// 问题编号
        /// </summary>
        public string QuestionId
        {
            get { return _questionId; }
            set { _questionId = value; }
        }

        /// <summary>
        /// 满意答案（用户标记）
        /// </summary>
        public List<string> SatisfiedAnswerIds
        {
            get { return _satisfiedAnswerIds; }
            set { _satisfiedAnswerIds = value; }
        }

        /// <summary>
        /// 推荐答案(其他用户推荐)
        /// </summary>
        public List<string> RecommendedAnswerIds
        {
            get { return _recommendedAnswerIds; }
            set { _recommendedAnswerIds = value; }
        }

        /// <summary>
        /// 相关问题编号
        /// </summary>
        public List<string> RelatedQuestionIds
        {
            get { return _relatedQuestionIds; }
            set { _relatedQuestionIds = value; }
        }
    }

    /// <summary>
    /// 用户
    /// </summary>
    public class User : BaseModel
    {
        private string _displayName;
        private double _adoptionRate;
        private int _anwserCount;
        private int _adoptionCount;
        private string _expertArea;
        private string _userStage;

        public User()
        {
        }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }

        /// <summary>
        /// 采用率
        /// </summary>
        public double AdoptionRate
        {
            get { return _adoptionRate; }
            set { _adoptionRate = value; }
        }

        /// <summary>
        /// 回答次数
        /// </summary>
        public int AnwserCount
        {
            get { return _anwserCount; }
            set { _anwserCount = value; }
        }

        /// <summary>
        /// 被采纳次数
        /// </summary>
        public int AdoptionCount
        {
            get { return _adoptionCount; }
            set { _adoptionCount = value; }
        }

        /// <summary>
        /// 擅长领域
        /// </summary>
        public string ExpertArea
        {
            get { return _expertArea; }
            set { _expertArea = value; }
        }

        /// <summary>
        /// 用户身份、等级
        /// </summary>
        public string UserStage
        {
            get { return _userStage; }
            set { _userStage = value; }
        }
    }
}
