using System;
using System.Collections.Generic;

namespace Jade.ConfigTool
{
    public enum KnowedgeType
    {
        BaiduZhidao = 0,
        SosoWenwen = 1
    }

    public class BaseModel
    {
        public KnowedgeType KnowedgeType
        {
            get;
            set;
        }
    }

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
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        public string ViewCount
        {
            get { return _viewCount; }
            set { _viewCount = value; }
        }
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }
        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }
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

    public class Answer:BaseModel
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

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        public int Up
        {
            get { return _up; }
            set { _up = value; }
        }
        public int Down
        {
            get { return _down; }
            set { _down = value; }
        }
        public int CommentCount
        {
            get { return _commentCount; }
            set { _commentCount = value; }
        }
    }

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

    class Person
    {

        string firstName;
        string secondName;
        string comments;
        public Person(string firstName, string secondName)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            comments = String.Empty;
        }
        public Person(string firstName, string secondName, string comments)
            : this(firstName, secondName)
        {
            this.comments = comments;
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string SecondName
        {
            get { return secondName; }
            set { secondName = value; }
        }
        public string Comments
        {
            get { return comments; }
            set { comments = value; }
        }
    }

}