using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RueEngine.Da;
using RueEngine.Entities;

namespace RueEngine.Bl
{
    public class VehicleBl
    {
        DatabaseContext databasecontext = new DatabaseContext();
        public Vehicle Save(int id, string Name, string RegistrationNumber)
        {
            var vehicle = id > 0 ? GetById(id) : new Vehicle();

            vehicle.Name = Name;
            vehicle.RegistrationNumber = RegistrationNumber;

            var vehicleDa = new VehicleDa(databasecontext);

            //if new
            if (id < 1) vehicle = vehicleDa.Add(vehicle);
            //update
            else vehicle = vehicleDa.Update(vehicle);
            return vehicle;
        }
        public void Delete(int id)
        {
            var vehicle = new VehicleDa(databasecontext);
            if (id > 0)
            {
                var currentVehicle = GetById(id);
                vehicle.Delete(currentVehicle);
            }
        }
        public Vehicle GetById(int id)
        {
            return new VehicleDa(databasecontext).GetById(id);
        }
        public static List<Vehicle> GetList()
        {
            return VehicleDa.GetList();
        }
    }

    public class VehicleData
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public static List<VehicleData> GetList()
        {
            List<VehicleData> items = new List<VehicleData>();

            foreach (var item in VehicleBl.GetList())
            {
                VehicleData vehicleData = new VehicleData();

                vehicleData.Id = item.Id;
                vehicleData.FullName = string.Format("{0}({1})", item.Name, item.RegistrationNumber);
                items.Add(vehicleData);

            }

            return items;
        }

    }
}