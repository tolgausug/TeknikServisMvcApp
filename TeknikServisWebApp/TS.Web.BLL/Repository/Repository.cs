using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            int a = 0;
            MyContext db = new MyContext();
            using (db.Database.BeginTransaction())
            {
                
                try
                {
                    ArizaKaydi yeniArizaKaydi = new ArizaKaydi()
                    {
                        MusteriId = model.MusteriId,
                        Aciklama = model.Aciklama,
                        KategoriId = model.KategoriId
                         
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
                }
                catch (Exception ex)
                {
                    db.Database.CurrentTransaction.Rollback();
                }
                return a;
            }
        }
    }
    public class ArizaKaydiDetayRepo : RepositoryBase<ArizaKaydiDetay, int> { }
}
