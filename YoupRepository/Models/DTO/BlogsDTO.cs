using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.Models.DTO
{
    public class BlogsDTO : BlogsBaseDTO
    {

        public int _id { get; set; }
        public string _name { get; set; }
        public int _isActive { get; set; }
        public string _userId { get; set; }
        public DateTime _createAt { get; set; }
        public DateTime _updateAt { get; set; }
        public DateTime _deleteAt { get; set; }

 

        public override int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public override string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public override int IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        public override string UserId
        {
            get { return _userId; }
            set { _userId = value; }
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
