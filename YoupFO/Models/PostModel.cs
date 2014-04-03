using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using YoupRepository.Models.POCO;

namespace YoupFO.Models
{
    #region Models
    public class Post
    {
        [Required(ErrorMessage = "Le titre de l'article est obligatoire")]
        [DataType(DataType.Text)]
        [DisplayName("Titre de l'article")]
        public string title { get; set; }


        [DataType(DataType.Text)]
        [DisplayName("Contenu de l'article")]
        public string content { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Visibilité")]
        public int visibility { get; set; }


    }

    public partial class ListPosts
    {
        public List<PostsPOCO> listPosts { get; set; }

    }


    #endregion
}