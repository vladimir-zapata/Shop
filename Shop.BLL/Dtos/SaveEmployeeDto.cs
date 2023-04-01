using Shop.BLL.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shop.BLL.Dtos
{
    public class SaveEmployeeDto : DtoBase
    {
        public int Empid { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime? Birthdate { get; set; }
        public DateTime? Hiredate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Postalcode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public int Mgrid { get; set; }
    }
}
