﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UOW.DAL.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
