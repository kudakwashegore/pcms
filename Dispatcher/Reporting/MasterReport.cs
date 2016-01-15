using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RueEngine.Bl;
using RueEngine.Entities;
using RueEngine.Utilities;

namespace UIView.Reporting
{
    public class MasterReport
    {       
        public virtual string DateTimeStart { get; set; }
        public virtual string DateTimeEnd { get; set; }
        public virtual string DriverName { get; set; }
        public virtual int DriverId { get; set; }
        public virtual string VehicleName { get; set; }
        public virtual int VehicleId { get; set; }
        public virtual string Refill { get; set; }
        public virtual int RefillId { get; set; }
        public virtual string KmL { get; set; }
        public virtual decimal MileageStart { get; set; }
        public virtual decimal MileageEnd { get; set; }
        public virtual decimal MileageTravelled { get; set; }
        public virtual decimal Cost { get; set; }
        public virtual string TripDetails { get; set; }
        public virtual string ExpenseAccount { get; set; }

        public static List<MasterReport> GetList()
        {
            List<MasterReport> items = new List<MasterReport>();



            foreach(var item in TripBl.GetList())
            {
                MasterReport reportData = new MasterReport();
                Refill r = new RefillBl().GetById(item.RefillId);
                Vehicle v = new VehicleBl().GetById(item.VehicleId);
                Driver d = new DriverBl().GetById(item.DriverId);

                string closed = "";

                reportData.DateTimeStart = string.Format("{0}", item.DateTimeStart.ToString("dd/MM/yy,hh:mm tt"));
                reportData.DateTimeEnd = string.Format("{0}", item.DateTimeEnd.ToString("dd/MM/yy,hh:mm tt"));
                reportData.DriverName = d.FullName;
                reportData.DriverId = d.Id;
                reportData.VehicleName = string.Format("{0}({1})", v.Name, v.RegistrationNumber);
                reportData.VehicleId = v.Id;
                reportData.Refill = string.Format("Refill No: {5}\nDate: {0}\nAmount: ${1}\nLiterage: {2}L\nPerfo': {3}km/l\nStatus: {4}", r.DateAndTime.ToString("dd/MM/yy "), r.Amount, r.Litreage, (RefillBl.TotalMileage(r.Id)/(decimal)r.Litreage).ToString("N2"), closed = r.Closed ? "Closed" : "Open", r.Id);
                reportData.RefillId = r.Id;
                reportData.MileageStart = item.MileageStart;
                reportData.MileageEnd = item.MileageEnd;
                reportData.MileageTravelled = (item.MileageEnd - item.MileageStart);
                reportData.TripDetails = item.TripDetails;
                reportData.ExpenseAccount = item.ExpenseAccount;
                reportData.Cost = (reportData.MileageTravelled / RefillBl.TotalMileage(r.Id)) * r.Amount;
                    
                items.Add(reportData);

            }

            return items;
        }   
 
        public static List<MasterReport> GetList(int VehicleId)
        {
            return GetList().Where(q => q.VehicleId == VehicleId).ToList();
        }
        public static List<MasterReport> GetList(int VehicleId, int DriverId)
        {
            return GetList().Where(q => q.VehicleId == VehicleId && q.DriverId == DriverId).ToList();
        }

    }
}
