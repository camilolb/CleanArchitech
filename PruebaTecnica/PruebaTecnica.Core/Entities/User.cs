﻿using System;
namespace PruebaTecnica.Core.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime Date { get; set; }
    }
}
