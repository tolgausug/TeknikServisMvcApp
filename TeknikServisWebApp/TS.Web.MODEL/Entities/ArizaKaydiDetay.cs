using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Web.MODEL.IdentityModels;

namespace TS.Web.MODEL.Entities
{
    [Table("ArizaKaydiDetaylari")]
    public class ArizaKaydiDetay
    {
        [Key]
        public int ArizaKaydiDetayId { get; set; }
        public int ArizaKaydiId { get; set; }
        [Display(Name = "Operatör İşlem Zamanı")]
        public DateTime OprIslemZamani { get; set; } = DateTime.Now;
        public bool OprOnayladiMi { get; set; } = false;
        [Display(Name = "Operatör Açıklaması")]
        [StringLength(200)]
        public string OprAciklamasi { get; set; }
        [Display(Name = "Tekniker Raporu")]
        [StringLength(200)]
        public string TeknikerRaporu { get; set; }
        public decimal Fiyat { get; set; }
        [Display(Name = "Tekniker İşlemi Bitirme Zamanı")]
        public DateTime BitirmeZamani { get; set; }
        public string OperatorId { get; set; }
        public string TeknikerId { get; set; }

        [ForeignKey("OperatorId")]
        public virtual ApplicationUser Operatoru { get; set; }
        [ForeignKey("TeknikerId")]
        public virtual ApplicationUser Teknikeri { get; set; }
    }
}
