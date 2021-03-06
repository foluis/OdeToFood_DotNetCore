﻿using Microsoft.AspNetCore.Mvc;
using OdeToFood_DotNetCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood_DotNetCore.ViewComponents
{
    public class Greeting:ViewComponent
    {
        private IGreeter _greeter;

        public Greeting(IGreeter greeter)
        {
            _greeter = greeter;
        }

        public IViewComponentResult Invoke()
        {
            var model = _greeter.GetGreeting();
            return View("Default",model);
        }
    }
}
