using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildSportGambleApplication.Models
{
    class UserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Username";
        public string Password { get; set; }
        public int Points { get; set; }
        public string Role { get; set; } = "User";
    }
}
