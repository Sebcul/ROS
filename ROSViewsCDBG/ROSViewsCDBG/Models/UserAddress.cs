using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROSViewsCDBG.Models
{
    public class UserAddress
    {
        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public int Zip_Code { get; set; }

        public int? BoxNo { get; set; }

        public string Description { get; set; }
    }
}
