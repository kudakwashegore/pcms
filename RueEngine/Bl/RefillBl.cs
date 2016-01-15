using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RueEngine.Da;
using RueEngine.Entities;

namespace RueEngine.Bl
{
    public class RefillBl
    {
        DatabaseContext databasecontext = new DatabaseContext();
        public Refill Save(int id, DateTime DateAndTime, int VehicleId, decimal Amount, double Litreage, decimal Mileage)
        {
            var refill = id > 0 ? GetById(id) : new Refill();

            refill.DateAndTime = DateAndTime;
            refill.VehicleId = VehicleId;
            refill.Amount = Amount;
            refill.Litreage = Litreage;
            refill.Mileage = Mileage;
            refill.Closed = false;

            var refillDa = new RefillDa(databasecontext);

            //if new
            if (id < 1) refill = refillDa.Add(refill);
            //update
            else refill = refillDa.Update(refill);
            return refill;
        }
        public void SetClosed(Refill refill)
        {
            var refillUpdate = refill.Id > 0 ? GetById(refill.Id) : new Refill();

            if (!(refill.Id > 0)) return;

            var refillDa = new RefillDa(databasecontext);
            refillUpdate.Closed = true;
            refillDa.Update(refillUpdate);
        }
        public void Delete(int id)
        {
            var refill = new RefillDa(databasecontext);
            if (id > 0)
            {
                var currentRefillItem = GetById(id);
                refill.Delete(currentRefillItem);
            }
        }
        public static Refill GetPrevious(int VehicleId)
        {
            return RefillDa.GetList().Where(q => q.VehicleId == VehicleId).OrderByDescending(q => q.Id).FirstOrDefault(); 
        }
        public static Refill GetPrevious(int VehicleId, int CurrentRefillId)
        {
            if (CurrentRefillId == 0) return RefillDa.GetList().Where(q => q.VehicleId == VehicleId).OrderByDescending(q => q.Id).FirstOrDefault();
            else return RefillDa.GetList().Where(q => q.VehicleId == VehicleId && q.Id < CurrentRefillId).OrderByDescending(q => q.Id).FirstOrDefault();
        }  
        public static decimal TotalMileage(int RefillId)
        {
            return (TripDa.GetList().Where(q => q.RefillId == RefillId).Sum(q => q.MileageEnd) - TripDa.GetList().Where(q => q.RefillId == RefillId).Sum(q => q.MileageStart));
        }
        public static bool VehicleInUse(int VehicleId)
        {
            return RefillDa.GetList().Where(q => q.VehicleId == VehicleId).ToList().Count > 0;
        }  
        public Refill GetById(int id)
        {
            return new RefillDa(databasecontext).GetById(id);
        }
        public static List<Refill> GetList()
        {
            return RefillDa.GetList().OrderByDescending(q=>q.Id).ToList();
        }
    }
}