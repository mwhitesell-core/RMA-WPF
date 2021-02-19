using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Suspend_address_rec
    {
        	 //01  suspend-address-rec.
	 //public  string Suspend_address_rec { get; set;}
	 //    05  addr-address-line-1                   pic x(25).
	 public  string Addr_address_line_1 { get; set;}
	 //    05  addr-address-line-2                   pic x(25).
	 public  string Addr_address_line_2 { get; set;}
	 //    05  addr-address-line-3                   pic x(25).
	 public  string Addr_address_line_3 { get; set;}
	 //    05  addr-postal-code                      pic x(9).
	 public  string Addr_postal_code { get; set;}
	 //    05  addr-surname                          pic x(25).
	 public  string Addr_surname { get; set;}
	 //    05  addr-first-name                       pic x(25).
	 public  string Addr_first_name { get; set;}
	 //    05  addr-birth-date.
	 public  string Addr_birth_date { get; set;}
	 //        10  addr-birth-yy                     pic 9(4).
	 public  int Addr_birth_yy { get; set;}
	 //        10  addr-birth-mm                     pic 99.
	 public  int Addr_birth_mm { get; set;}
	 //        10  addr-birth-dd                     pic 99.
	 public  int Addr_birth_dd { get; set;}
	 //    05  addr-sex                              pic x.
	 public  string Addr_sex { get; set;}
	 //    05  addr-phone-no                         pic x(20).
	 public  string Addr_phone_no { get; set;}
	 //    05  suspend-addr-id.
	 public  string Suspend_addr_id { get; set;}
	 //        10  addr-doc-pract-nbr                pic 9(6).
	 public  int Addr_doc_pract_nbr { get; set;}
	 //        10  addr-accounting-nbr               pic x(8).
	 public  string Addr_accounting_nbr { get; set;}

}
}
