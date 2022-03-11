using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiCrud.vm
{
    public class NewEmp1Vm
    {

        public int EmpId { get; set; }

        public string EmpName { get; set; }
        public int? EmpSal { get; set; }

        public string EmpCity { get; set; }
    }
}