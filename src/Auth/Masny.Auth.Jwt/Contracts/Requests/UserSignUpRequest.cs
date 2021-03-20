﻿using System.ComponentModel.DataAnnotations;

namespace Masny.Auth.Jwt.Contracts.Requests
{
    public class UserSignUpRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
