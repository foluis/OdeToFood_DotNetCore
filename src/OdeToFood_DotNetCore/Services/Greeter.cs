using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood_DotNetCore.Services
{
    public interface IGreeter
    {
        string GetGreeting();
    }

    public class Greeter : IGreeter
    {
        private object _greeting;

        public Greeter(IConfiguration config)
        {
            _greeting = config["greating3"];
        }

        public string GetGreeting()
        {            
                return _greeting.ToString();
        }
    }
}
