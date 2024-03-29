﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OneToOneEmployeeAddress
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("Address")]
        public int? AddressId { get; set;}

        public Address Address { get; set; }
    }
}
