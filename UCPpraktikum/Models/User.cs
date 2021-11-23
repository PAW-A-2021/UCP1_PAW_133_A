using System;
using System.Collections.Generic;

namespace UCPpraktikum.Models
{
    public partial class User
    {
        public int IdUser { get; set; }
        public string NicknameUser { get; set; }

        public Account IdUser1 { get; set; }
        public Admin IdUserNavigation { get; set; }
    }
}
