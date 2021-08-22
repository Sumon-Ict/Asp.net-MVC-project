using InventorySystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Training.Entities
{
    public class Stock : IEntity<int>
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

    }
}
