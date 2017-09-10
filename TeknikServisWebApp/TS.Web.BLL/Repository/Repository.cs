using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TS.Web.BLL.SiteSettings;
using TS.Web.DAL;
using TS.Web.MODEL.Entities;
using TS.Web.MODEL.ViewModels;

namespace TS.Web.BLL.Repository
{
    public class KategoriRepo : RepositoryBase<Kategori, int> { }
    public class ArizaKaydiRepo : RepositoryBase<ArizaKaydi, int> {
        public ArizaKaydi GetById(string Id) => GetAll().FirstOrDefault(x => x.MusteriId == Id);
        public int Insert(ArizaViewModel model)
        {
            
            MyContext db = new MyContext();
            using (db.Database.BeginTransaction())
            {
                

                try
                {
                    int a;
                    ArizaKaydi yeniArizaKaydi = new ArizaKaydi()
                    {
                        MusteriId = model.MusteriId, 
                        Aciklama = model.Aciklama,
                        KategoriId = model.KategoriId,
                        Adres=model.Adres 
                    };
                    db.ArizaKayitlari.Add(yeniArizaKaydi);
                    db.SaveChanges();
                    a = yeniArizaKaydi.ArizaKaydiId;
                        db.ArizaKaydiDetaylari.Add(new ArizaKaydiDetay()
                        {
                             ArizaKaydiId=yeniArizaKaydi.ArizaKaydiId
                        });
                    
                    db.SaveChanges();
                    db.Database.CurrentTransaction.Commit();
                    return a;
                }
                catch (Exception ex)
                {
                    db.Database.CurrentTransaction.Rollback();
                }
                return 0;
            }
        }
    }
    public class ArizaKaydiDetayRepo : RepositoryBase<ArizaKaydiDetay, int> { }
}
