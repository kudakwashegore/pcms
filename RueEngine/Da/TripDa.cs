using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

using RueEngine.Entities;

namespace RueEngine.Da
{
    public class TripDa
    {
        private DatabaseContext _databasecontext;
        public TripDa(){}
        public TripDa(DatabaseContext databasecontext)
        {
           _databasecontext = databasecontext;
        }
        public Trip Add(Trip trip)
        {
            _databasecontext.Trips.Add(trip);
            _databasecontext.SaveChanges();
            return trip;
        }
        public Trip Update(Trip trip)
        {
            //_databasecontext.Entry(orderItem).State = EntityState.Modified;
            _databasecontext.SaveChanges();
            return trip;
        }
        public void Delete(Trip trip)
        {
            _databasecontext.Trips.Remove(trip);
            _databasecontext.SaveChanges();
        }
        public Trip GetById(int id)
        {
            return _databasecontext.Trips.Single(it => it.Id == id);
        }

        public static List<Trip> GetList()
        {
            var dbContext = new DatabaseContext();
            List<Trip> trip = dbContext.Trips                        
                        .ToList();
            return trip;
        }
    }
}