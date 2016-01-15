using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RueEngine.Da;
using RueEngine.Entities;

namespace RueEngine.Bl
{
    public class TripBl
    {
        DatabaseContext databasecontext = new DatabaseContext();
        public Trip Save(int id, DateTime DateTimeStart, DateTime DateTimeEnd, int VehicleId, int DriverId, int RefillId, decimal MileageStart, decimal MileageEnd, string TripDetails, string ExpenseAccount)
        {
            var trip = id > 0 ? GetById(id) : new Trip();

            trip.DateTimeStart = DateTimeStart;
            trip.DateTimeEnd = DateTimeEnd;
            trip.DriverId = DriverId;
            trip.VehicleId = VehicleId;
            trip.RefillId = RefillId;
            trip.MileageStart = MileageStart;
            trip.MileageEnd = MileageEnd;
            trip.TripDetails = TripDetails;
            trip.ExpenseAccount = ExpenseAccount;


            var tripDa = new TripDa(databasecontext);

            //if new
            if (id < 1) trip = tripDa.Add(trip);
            //update
            else trip = tripDa.Update(trip);
            return trip;
        }
        public void Delete(int id)
        {
            var trip = new TripDa(databasecontext);
            if (id > 0)
            {
                var currentTrip = GetById(id);
                trip.Delete(currentTrip);
            }
        }
        public Trip GetById(int id)
        {
            return new TripDa(databasecontext).GetById(id);
        }
        public static Trip GetPrevious(int VehicleId)
        {
            return TripDa.GetList().Where(q => q.VehicleId == VehicleId).OrderByDescending(q => q.Id).FirstOrDefault();
        }
        public static Trip GetPrevious(int VehicleId, int CurrentTripId)
        {
            if (CurrentTripId == 0) return TripDa.GetList().Where(q => q.VehicleId == VehicleId).OrderByDescending(q => q.Id).FirstOrDefault();
            else return TripDa.GetList().Where(q => q.VehicleId == VehicleId && q.Id < CurrentTripId).OrderByDescending(q => q.Id).FirstOrDefault();
        }
        public static bool DriverInUse(int DriverId)
        {
            return TripDa.GetList().Where(q => q.DriverId == DriverId).ToList().Count > 0;
        }
        public static bool VehicleInUse(int VehicleId)
        {
            return TripDa.GetList().Where(q => q.VehicleId == VehicleId).ToList().Count > 0;
        }
        public static bool RefillInUse(int RefillId)
        {
            return TripDa.GetList().Where(q => q.RefillId == RefillId).ToList().Count > 0;
        }  
        public static List<Trip> GetList()
        {
            return TripDa.GetList().OrderByDescending(q => q.Id).ToList();
        }
    }
}