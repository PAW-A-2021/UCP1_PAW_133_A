using System;
using System.Collections.Generic;

namespace UCPpraktikum.Models
{
    public partial class Admin
    {
        public int IdAdmin { get; set; }
        public string NicknameAdmin { get; set; }

        public Account IdAdminNavigation { get; set; }
        public User User { get; set; }
    }
}
