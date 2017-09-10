using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS.Web.MODEL.ViewModels
{
    public class KategoriViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [Index(IsUnique = true)]
        [Display(Name = "Kategori Adı")]
        public string KategoriAdi { get; set; }
        [StringLength(200)]
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }
    }
}
