using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Parm_file_rec
    {
        	 //01  parm-file-rec. 
	 //public  string Parm_file_rec { get; set;}
	 //    05  parm-status    pic 9. 

            //	( status	0	after parm file created 
            //	    1	after sort by doc 
            //		2	after r051ca printed
            //		3	after sort by dept ) 

     public  int Parm_status { get; set;}
	 //    05  parm-program-nbr   pic x(5). 
	 public  string Parm_program_nbr { get; set;}
	 //    05  parm-clinic-nbr    pic xx. 
	 public  string Parm_clinic_nbr { get; set;}
	 //    05  parm-clinic-name   pic x(20). 
	 public  string Parm_clinic_name { get; set;}
	 //    05  parm-ped. 
	 public  string Parm_ped { get; set;}
	 // 10  parm-ped-yy    pic 9999. 
	 public  int Parm_ped_yy { get; set;}
	 // 10  parm-ped-mm    pic 99. 
	 public  int Parm_ped_mm { get; set;}
	 // 10  parm-ped-dd    pic 99. 
	 public  int Parm_ped_dd { get; set;}

}
}
