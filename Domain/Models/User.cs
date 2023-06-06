using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        public int ID { get; set; }
        public string ?Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ?LastModified { get; set; }

    }
}
