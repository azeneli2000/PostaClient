using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Perdoruesi
    {
        public Int64 id { get; set; }

        [Display(Name = "Emri")]
        [Required(ErrorMessage = "Vendosni Emrin !")]
        public String emri { get; set; }



        [Display(Name = "Adresa")]
        [Required(ErrorMessage = "Vendosni Adresen !")]
        public string adresa { get; set; }

        //public Int64 idSkonto { get; set; }

        [Display(Name = "Perdoruesi")]
        [Required(ErrorMessage = "Vendosni Perdoruesin !")]
        public String perdoruesi { get; set; }

        [Display(Name = "Fjalekalimi")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Vendosni Fjalekalimin !")]
        public string password { get; set; }

        [Display(Name = "Perserit")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Perserisni Fjalekalimin !")]
        [Compare("password", ErrorMessage = "Fjalekalimi nuk perkon me perseritjen !")]
        public string rePasssword { get; set; }

        [Display(Name = "Agjensi")]
        public bool agjensi { get; set; }

        [Display(Name = "Perdorues Aktiv")]
        public bool aktiv { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Shenime")]
        public string shenime { get; set; }

        public Int64 idMagazina { get; set; }
        public decimal detyrimi { get; set; }


    }
}
