using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
  public  class ShoferiDetyrim
    {
        public Int64 id { get; set; }
        [Display(Name = "Detyrimi")]

        public decimal detyrimi { get; set; }
        [Display(Name = "Emri")]

        public string emri { get; set; }
        [Display(Name = "Dorezuar")]
        [Required(ErrorMessage = "Vendosni vleren e dorezimit !")]
        public decimal dorezuar { get; set; }
    }
}
