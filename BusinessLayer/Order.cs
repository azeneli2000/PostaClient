using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
  public   class Order
    {
        [Display(Name = "ID")]
        public Int64 idOrder { get; set; }

        [Display(Name = "Adresa")]
        [Required(ErrorMessage = "Vendosni Adresen !")]
        public string adresaMarresi { get; set; }

        //************************PICKUP

        public Boolean pickUp { get; set; }

        public Int64? DriverIdPickUp { get; set; }

        public DateTime? OraPickUp { get; set; }

        //************************KTHYER
        public Boolean KthyerMag { get; set; }

        public Int64? IdMagazina { get; set; }

        public Int64? DriverIdKthyerMag { get; set; }

        public DateTime? OraKthyerMag { get; set; }

        public Boolean KthyerKlienti { get; set; }
        public Boolean KonfirmimShoferi { get; set; }

        //************************DOREZUAR
        [Display(Name = "Dorezuar")]
        public Boolean Dorzuar { get; set; }


        public Int64? DriverIdDorezimi { get; set; }
        [Display(Name = "Data/Ora Dorzimi")]
        public DateTime? OraDorezimi { get; set; }


        //************************TE DHENAT E DERGESES
        [Display(Name = "Paguesi")]
        [Required(ErrorMessage = "Vendosni kush paguan !")]
        public string Paguan { get; set; }

        public Int64 IdKlienti { get; set; }
        [Display(Name = "Sherbimi")]
        [Required(ErrorMessage = "Zgjidhni sherbimin !")]
        public Int64 IdLloji { get; set; }

        [Display(Name = "Zona")]
        [Required(ErrorMessage = "Zgjidhni zonen !")]
        public Int64 IdZona { get; set; }
        [Display(Name = "Cmimi")]
        [Required(ErrorMessage = "Vendosni cmimin !")]
        public decimal Cmimi { get; set; }

        public string Valua { get; set; }
        [Display(Name = "Data/Ora Dergesa")]
        public DateTime DataOraOrder { get; set; }

        [Display(Name = "Pesha")]
        [Required(ErrorMessage = "Vendosni peshen !")]
        public decimal Pesha { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Shenime")]
        public string Shenime { get; set; }
        [Display(Name = "Telefon")]
        [Required(ErrorMessage = "Vendosni numrin e telefonit !")]
        public string Telefon { get; set; }

        [Display(Name = "Zona")]
        public string ZonaEmertimi { get; set; }

        [Display(Name = "Sherbimi")]
        public string LlojiEmertimi { get; set; }


        public byte[] BarcodeImage { get; set; }
        public string Barcode { get; set; }
        public string ImageUrl { get; set; }
        [Display(Name = "Emri")]
        [Required(ErrorMessage = "Vendosni emrin  e marresit !")]
        public string EmriMarresi { get; set; }

        [Display(Name = "Vlera")]
        [Required(ErrorMessage = "Vendosni vleren e dergeses !")]
        public decimal Vlera { get; set; }
        public string EmriKlienti { get; set; }
        public string EmriShoferi { get; set; }
    }
}
