﻿using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contadores.Models
{
    public class Meter
    {
        //object meter
        [PrimaryKey, Identity]
        public int id { get; set; }
        public string serialNumber { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
    }
}