using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElectronicsShop.Core
{
    public class Entity<TPrimaryKey>
    {
        [Key]
        public TPrimaryKey Id { get; set; }
    }
}
