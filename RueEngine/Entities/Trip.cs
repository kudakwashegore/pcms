using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RueEngine.Entities
{
    public class Trip
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public virtual int Id { get; set; }
        public virtual DateTime DateTimeStart { get; set; }
        public virtual DateTime DateTimeEnd { get; set; }
        public virtual int DriverId { get; set; }
        public virtual int RefillId { get; set; }
        public virtual int VehicleId { get; set; }
        public virtual decimal MileageStart { get; set; }
        public virtual decimal MileageEnd { get; set; }
        public virtual string TripDetails { get; set; }
        public virtual string ExpenseAccount { get; set; }
    }
}
