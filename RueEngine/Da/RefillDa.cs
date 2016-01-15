using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

using RueEngine.Entities;

namespace RueEngine.Da
{
    public class RefillDa
    {
        private DatabaseContext _databasecontext;
        public RefillDa(){}
        public RefillDa(DatabaseContext databasecontext)
        {
           _databasecontext = databasecontext;
        }
        public Refill Add(Refill refill)
        {
            _databasecontext.Refills.Add(refill);
            _databasecontext.SaveChanges();
            return refill;
        }
        public Refill Update(Refill refill)
        {
            _databasecontext.SaveChanges();
            return refill;
        }
        public void Delete(Refill refill)
        {
            _databasecontext.Refills.Remove(refill);
            _databasecontext.SaveChanges();
        }
        public Refill GetById(int id)
        {
            return _databasecontext.Refills.Single(it => it.Id == id);
        }

        public static List<Refill> GetList()
        {
            var dbContext = new DatabaseContext();
            List<Refill> refill = dbContext.Refills                        
                        .ToList();
            return refill;
        }
    }
}