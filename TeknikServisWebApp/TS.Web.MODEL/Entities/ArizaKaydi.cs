using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TS.Web.MODEL.IdentityModels;

namespace TS.Web.MODEL.Entities
{
    [Table("ArizaKayitlari")]
    public class ArizaKaydi
    {
        [Key]
        public int ArizaKaydiId { get; set; }
        public int KategoriId { get; set; }
        [Display(Name = "Açıklama")]
        [StringLength(200)]
        public string Aciklama { get; set; }
        public string UrunFotografYolu { get; set; }
        [StringLength(50)]
        public string Konumu { get; set; }
        [StringLength(200)]
        public string Adres { get; set; }
        public int Puan { get; set; } = 3;
        [Display(Name = "Arıza Giderildi Mi")]
        public bool ArizaGiderildiMi { get; set; } = false;
        [Display(Name = "Oluşturulma Zamanı")]
        public DateTime OlusturulmaZamani { get; set; } = DateTime.Now;
        public string MusteriId { get; set; }
        
        [ForeignKey("KategoriId")]
        public virtual Kategori Kategori { get; set; }

        [ForeignKey("MusteriId")]
        public virtual ApplicationUser Musterisi { get; set; }
    }
}
