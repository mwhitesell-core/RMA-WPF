using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class New_pat_file_rec
    {
        	 //01 new-pat-file-rec. 
	 //public  string New_pat_file_rec { get; set;}
	 //   05 new-pat-ohip                    pic x(12). 
	 public  string New_pat_ohip { get; set;}
	 //   05 new-pat-surname                 pic x(25). 
	 public  string New_pat_surname { get; set;}
	 //   05 new-pat-first-name              pic x(17). 
	 public  string New_pat_first_name { get; set;}
	 //   05 new-pat-subscr-surname          pic x(25). 
	 public  string New_pat_subscr_surname { get; set;}
	 //   05 new-pat-address-line-1          pic x(30). 
	 public  string New_pat_address_line_1 { get; set;}
	 //   05 new-pat-address-line-2          pic x(30). 
	 public  string New_pat_address_line_2 { get; set;}
	 //   05 new-pat-address-line-3          pic x(30). 
	 public  string New_pat_address_line_3 { get; set;}
	 //   05 new-pat-address-prov-cd         pic x(2). 
	 public  string New_pat_address_prov_cd { get; set;}
	 //   05 new-pat-postal-code             pic x(10). 
	 public  string New_pat_postal_code { get; set;}
	 //   05 new-pat-birth-date              pic x(08). 
	 public  string New_pat_birth_date { get; set;}
	 //   05 new-pat-sex                     pic x. 
	 public  string New_pat_sex { get; set;}

}
}
