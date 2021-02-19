using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Param_file_rec
    {
        	 //01   param-file-rec. 
	 //public  string Param_file_rec { get; set;}
	 //     05  param-clinic-nbr-1-2   pic 99. 
	 public  int Param_clinic_nbr_1_2 { get; set;}
	 //     05  param-clinic-nbr   pic 9(4). 
	 public  int Param_clinic_nbr { get; set;}
	 //     05  param-clinic-name   pic x(20). 
	 public  string Param_clinic_name { get; set;}
	 //     05  param-date-period-end-yy  pic 9999. 
	 public  int Param_date_period_end_yy { get; set;}
	 //     05  param-date-period-end-dd  pic 99. 
	 public  int Param_date_period_end_dd { get; set;}
	 //     05  param-date-period-end-mm  pic x(11). 
	 public  string Param_date_period_end_mm { get; set;}
	 //     05  param-run-date. 
	 public  string Param_run_date { get; set;}
	 //         10  param-date-yy   pic 9999. 
	 public  int Param_date_yy { get; set;}
	 //         10  param-date-mm   pic 99. 
	 public  int Param_date_mm { get; set;}
	 //         10  param-date-dd   pic 99. 
	 public  int Param_date_dd { get; set;}
	 //     05  filler     pic x. 
	 public  string Filler { get; set;}

}
}
