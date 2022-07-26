using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.Core
{
    public class Entity<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
    }
}
