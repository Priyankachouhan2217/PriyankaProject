using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiCrud.vm
{
    public class Emp1ViewModel
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int Id { get; set; }

        public int? EmpSal { get; set; }
        public String EmpCity { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string state { get; set; }
        public string Country { get; set; }

    }
}