using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_03_Repository
{
    public enum OutingType
    {
        Golf = 1,
        Bowling = 2,
        AmusementPark = 3,
        Concert = 4
    }
    public class Outing
    {
        public OutingType OutingType { get; set; }
        public int OutingAttendance { get; set; }
        public DateTime OutingDate { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal CostPerOuting { get; set; }

        public Outing() { }

        public Outing(OutingType outingType, int outingAttendance, DateTime outingDate, decimal costPerPerson, decimal costPerOuting)
        {
            OutingType = outingType;
            OutingAttendance = outingAttendance;
            OutingDate = outingDate;
            CostPerPerson = costPerPerson;
            CostPerOuting = costPerOuting;
        }
    }
}

