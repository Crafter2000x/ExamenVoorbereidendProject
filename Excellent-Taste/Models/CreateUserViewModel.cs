using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excellent_Taste.Models
{
    public class CreateUserViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }
    }
}
