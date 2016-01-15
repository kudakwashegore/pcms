using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

using RueEngine.Entities;

namespace RueEngine.Da
{
    public class VehicleDa
    {
        private DatabaseContext _databasecontext;
        public VehicleDa(){}
        public VehicleDa(DatabaseContext databasecontext)
        {
           _databasecontext = databasecontext;
        }
        public Vehicle Add(Vehicle vehicle)
        {
            _databasecontext.Vehicles.Add(vehicle);
            _databasecontext.SaveChanges();
            return vehicle;
        }
        public Vehicle Update(Vehicle vehicle)
        {
            //_databasecontext.Entry(order).State = EntityState.Modified;
            _databasecontext.SaveChanges();
            return vehicle;
        }
        public void Delete(Vehicle vehicle)
        {
            _databasecontext.Vehicles.Remove(vehicle);
            _databasecontext.SaveChanges();
        }
        public Vehicle GetById(int id)
        {
            return _databasecontext.Vehicles.Single(it => it.Id == id);
        }

        public static List<Vehicle> GetList()
        {
            var dbContext = new DatabaseContext();
            List<Vehicle> vehicles = dbContext.Vehicles                        
                        .ToList();
            return vehicles;
        }
    }
}