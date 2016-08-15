﻿using System.ComponentModel.DataAnnotations;

namespace OdeToFood_DotNetCore.ViewModels
{
    public class LoginViewModel
    {
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }

        public string ReturnURL { get; set; }

    }
}
