﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDirectoryAPI.Domain
{
    public class User
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public required string EmployeeID { get; set; }
        public string? SiteName { get; set; }
        public string? BusinessUnitName { get; set; }
        public string? AccountName { get; set; }
        public string? GroupName { get; set; }
        public string? CategoryName { get; set; }
        public string? TypeName { get; set; }
        public DateTime Date { get; set; }
        public string? Duration { get; set; }
        public bool IsProcessed { get; set; }
    }
}
