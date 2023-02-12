using System;

namespace Shop.Web.Models
{
    public class Employee
    {
        public int empid { get; set; }

        public string lastname { get; set; }

        public string firstname { get; set; }

        public string title { get; set; }

        public string titleofcourtesy { get; set; }

        public DateTime birthdate { get; set; }

        public DateTime hiredate { get; set;}

        public string address { get; set; }

        public string city { get; set; }

        public string phone { get; set; }

        public int mgrid { get; set; }
    }
}
