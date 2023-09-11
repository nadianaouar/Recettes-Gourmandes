using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecettesGourmandes.Models
{
    public class Recette
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Veillez saisir un nom pour la nouvelle Recette")]
        [Display(Name ="Recette")]
        public String NomRecette { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Information nutritionnelle")]
        public string Description { get; set; }
        public byte[] RecetteImage { get; set; }
        public string RecetteImageType { get; set; }

    }
}