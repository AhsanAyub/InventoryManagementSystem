using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class productEntity
    {
        public int prodID { get; set; }
        public String prodName { get; set; }
        public int itemRemaining { get; set; }
        public String prodExpiration { get; set; }
        public int prodPrice { get; set; }
        public String catName { get; set; }
    }
}
