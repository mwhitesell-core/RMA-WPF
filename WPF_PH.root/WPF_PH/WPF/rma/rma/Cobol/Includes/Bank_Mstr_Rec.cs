using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Bank_Mstr_Rec
    {
        //05  bank-cd pic x(9).    
        public string bank_cd { get; set; }
        // 05  bank-name pic x(30). 
        public string bank_name { get; set; }
        // 05  bank-address.
        public string bank_address_grp { get; set; }
        // 10  bank-address1 pic x(30). 
        public string bank_address1_child { get; set; }
        //10  bank-address2 pic x(30). 
        public string bank_address2_child { get; set; }

        // 05  bank-city-prov.
        public string bank_city_prov_grp { get; set; }
        //10  bank-city pic x(15). 
        public string bank_city { get; set; }
        //10  bank-prov pic x(15). 
        public string bank_prov { get; set; }

        //05  bank-postal-cd.
        public string bank_postal_cd_grp { get; set; }
        //10  bank-pc-123. 
        public string bank_pc_123_grp_child { get; set; }
        //15  bank-pc1 pic x.
        public string bank_pc1_child { get; set; }
        //15  bank-pc2 pic 9. 
        public int bank_pc2_child { get; set; }
        //15  bank-pc3 pic x.
        public string bank_pc3_child { get; set; }

        //10  bank-pc-456. 
        public string bank_pc_456_grp_child { get; set; }
        //15  bank-pc4 pic 9. 
        public int bank_pc4_child { get; set; }
        //15  bank-pc5 pic x.
        public string bank_pc5_child { get; set; }
        //15  bank-pc6 pic 9. 
        public int bank_pc6_child { get; set; }
    }
}
