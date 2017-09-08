using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Web.MODEL.Entities;
using System.Web;

namespace TS.Web.MODEL.ViewModels
{
    public class ArizaViewModel
    {
        [StringLength(250, MinimumLength = 10, ErrorMessage = "10 Karakterden az olmamalıdır")]
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }

        [Display(Name = "Telefon Numarası")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public Kategori Kategori { get; set; }

        public HttpPostedFileBase UrunFotografFile { get; set; }

        public string UrunFotografYolu { get; set; }
    }
}
