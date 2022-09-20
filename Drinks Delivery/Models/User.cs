using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drinks_Delivery.Models
{
    [System.Serializable]
    public class User
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string SSN { get; set; }
        public string Birthdate { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
