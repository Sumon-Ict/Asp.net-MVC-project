using BookSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSystem.Training.Entities
{
  public  class Book : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Writer { get; set; }
        public DateTime PublishedDate { get; set; }
        public int Price { get; set; }

    }
}
