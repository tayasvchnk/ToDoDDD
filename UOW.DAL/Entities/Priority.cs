﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UOW.DAL.Entities
{
    public class Priority : BaseEntity
    {
        public string PriorityName { get; set; } = null!;
    }
}
