using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RueEngine.Da;
using RueEngine.Entities;

namespace RueEngine.Bl
{
    public class DriverBl
    {
        DatabaseContext databasecontext = new DatabaseContext();
        public Driver Save(int id, string FullName)
        {
            var driver = id > 0 ? GetById(id) : new Driver();

            driver.FullName = FullName;

            var driverDa = new DriverDa(databasecontext);

            //if new
            if (id < 1) driver = driverDa.Add(driver);
            //update
            else driver = driverDa.Update(driver);
            return driver;
        }
        public void Delete(int id)
        {
            var driver = new DriverDa(databasecontext);
            if (id > 0)
            {
                var currentOrder = GetById(id);
                driver.Delete(currentOrder);
            }
        }       
        public Driver GetById(int id)
        {
            return new DriverDa(databasecontext).GetById(id);
        }
        public static List<Driver> GetList()
        {
            return DriverDa.GetList();
        }
    }
}