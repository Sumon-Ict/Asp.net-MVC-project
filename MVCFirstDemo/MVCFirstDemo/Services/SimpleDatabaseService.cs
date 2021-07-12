using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFirstDemo.Services
{
    public class SimpleDatabaseService : IDatabaseService
    {

        private IDriverServices _driverServices;

        public SimpleDatabaseService(IDriverServices driverServices)
        {
            _driverServices = driverServices;
        }
        public string Name()
        {
            return "simpledatabaseservices";

        }

        

    }
}
