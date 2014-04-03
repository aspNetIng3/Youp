using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YoupFO.Models
{   
    #region Models
    public class Blog

    {
        [Required(ErrorMessage = "Le nom du blog est obligatoire")]
        [DataType(DataType.Text)]
        [DisplayName("Nom du blog")]
        public string name { get; set; }

    }

    #endregion
}