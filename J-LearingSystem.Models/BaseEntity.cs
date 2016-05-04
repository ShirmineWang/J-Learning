﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_LearingSystem.Models
{
    [NotMapped]
    public abstract class BaseEntity
    {
        [Key]
        public string Id { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString("N");
        }
    }
}
