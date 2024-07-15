﻿using Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Files
{
    [Auditable]
    public class CsvFile
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
