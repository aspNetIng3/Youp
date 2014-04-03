using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.Models.DTO
{
    public class PostsDTO : PostsBaseDTO
    {

        public int _id { get; set; }
        public string _title { get; set; }
        public string _content { get; set; }
        public int _visibilityId { get; set; }
        public int _themeId { get; set; }
        public int _blogId { get; set; }
        public DateTime _createAt { get; set; }
        public DateTime _updateAt { get; set; }
        public DateTime _deleteAt { get; set; }



        public override int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public override string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public override string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public override int Visibility
        {
            get { return _visibilityId; }
            set { _visibilityId = value; }
        }

        public override int ThemeId
        {
            get { return _themeId; }
            set { _themeId = value; }
        }

        public override int BlogId
        {
            get { return _blogId; }
            set { _blogId = value; }
        }

        public override DateTime CreateAt
        {
            get { return _createAt; }
            set { _createAt = value; }
        }

        public override DateTime UpdateAt
        {
            get { return _updateAt; }
            set { _updateAt = value; }
        }

        public override DateTime DeleteAt
        {
            get { return _deleteAt; }
            set { _deleteAt = value; }
        }
    }
}
