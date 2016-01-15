using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

using RueEngine.Entities;

namespace RueEngine.Da
{
    public class DriverDa
    {
        private DatabaseContext _databasecontext;
        public DriverDa(){}
        public DriverDa(DatabaseContext databasecontext)
        {
           _databasecontext = databasecontext;
        }
        public Driver Add(Driver driver)
        {
            _databasecontext.Drivers.Add(driver);
            _databasecontext.SaveChanges();
            return driver;
        }
        public Driver Update(Driver driver)
        {
            //_databasecontext.Entry(order).State = EntityState.Modified;
            _databasecontext.SaveChanges();
            return driver;
        }
        public void Delete(Driver driver)
        {
            _databasecontext.Drivers.Remove(driver);
            _databasecontext.SaveChanges();
        }
        public Driver GetById(int id)
        {
            return _databasecontext.Drivers.Single(it => it.Id == id);
        }

        public static List<Driver> GetList()
        {
            var dbContext = new DatabaseContext();
            List<Driver> drivers = dbContext.Drivers                        
                        .ToList();
            return drivers;
        }
    }
}