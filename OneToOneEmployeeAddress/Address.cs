using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OneToOneEmployeeAddress
{
    public class Address
    {
        public int Id { get; set; }

        public string StreetLine { get; set; }

        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}
