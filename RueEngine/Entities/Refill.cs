using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RueEngine.Entities
{
    public class Refill
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public virtual int Id { get; set; }
        public virtual DateTime DateAndTime { get; set; }
        public virtual int VehicleId { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual double Litreage { get; set; }
        public virtual decimal Mileage { get; set; }
        public bool Closed { get; set; }
    }
}