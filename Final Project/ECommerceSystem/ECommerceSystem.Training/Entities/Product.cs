﻿using ECommerceSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.Training.Entities
{
  public class Product : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}