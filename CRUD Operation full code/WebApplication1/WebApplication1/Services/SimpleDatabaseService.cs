using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public class SimpleDatabaseService : IDatabaseService
    {
        private IDriverService _driverService;
        public SimpleDatabaseService(IDriverService driverService)
        {
            _driverService = driverService;
        }
        public string Getname()
        {
            return "SimpledatabaseServices";
        }
    }
}
