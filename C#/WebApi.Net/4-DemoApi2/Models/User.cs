﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _4_DemoApi2.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}