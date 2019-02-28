using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdexWebClient
{
    public class DatePicker
    {
        [Display(Name = "Data e fillimit : ")]
        [Required(ErrorMessage = "Vendosni Daten e fillimit !")]
        public DateTime? DataFillimi { get; set; }
        [Display(Name = " Data e mbarimit : ")]
        [Required(ErrorMessage = "Vendosni Daten e mbarimit !")]

        public DateTime? DataMbarimi { get; set; }
    }
}