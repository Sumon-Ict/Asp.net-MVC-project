using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFirstDemo.Models
{
    public class SummaryModel
    {
        public string Name { get; set; }

        public int age { get; set; }

        public SummaryModel(string name,int _age)
        {
            Name = name;
            age = _age;
        }

        public SummaryModel()
        {
            Name = "Kalam ";
            age = 67;
        }
    }
}
