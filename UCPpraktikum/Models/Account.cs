using System;
using System.Collections.Generic;

namespace UCPpraktikum.Models
{
    public partial class Account
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int IdApplication { get; set; }

        public Admin Admin { get; set; }
        public ReadingApplication ReadingApplication { get; set; }
        public User User { get; set; }
    }
}
