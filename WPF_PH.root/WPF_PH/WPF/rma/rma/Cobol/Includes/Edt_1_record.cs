using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Edt_1_record
    {
        	 //01  edt-1-record. 
	 //public  string Edt_1_record { get; set;}
	 //    05  edt-1-trans-cd    pic xx. 
	 public  string Edt_1_trans_cd { get; set;}
	 //    05  edt-1-record-type   pic x. 
	 public  string Edt_1_record_type { get; set;}
	 //    05  edt-1-release-id   pic x(3).
	 public  string Edt_1_release_id { get; set;}
	 //    05  edt-1-moh-off-cd   pic x. 
	 public  string Edt_1_moh_off_cd { get; set;}
	 //    05  edt-1-filler-1     pic x(10).
	 public  string Edt_1_filler_1 { get; set;}
	 //    05  edt-1-operator-nbr   pic x(6).
	 public  string Edt_1_operator_nbr { get; set;}
	 //    05  edt-1-group-nbr    pic x(4). 
	 public  string Edt_1_group_nbr { get; set;}
	 //    05  edt-1-doc-nbr    pic 9(6). 
	 public  int Edt_1_doc_nbr { get; set;}
	 //    05  edt-1-specialty-cd   pic xx. 
	 public  string Edt_1_specialty_cd { get; set;}
	 //    05  edt-1-station-nbr   pic x(3).
	 public  string Edt_1_station_nbr { get; set;}
	 //    05  edt-1-process-date.
	 public  string Edt_1_process_date { get; set;}
	 //  10  edt-1-process-date-yy  pic 9(4). 
	 public  int Edt_1_process_date_yy { get; set;}
	 // 10  edt-1-process-date-mm  pic 99. 
	 public  int Edt_1_process_date_mm { get; set;}
	 // 10  edt-1-process-date-dd  pic 99. 
	 public  int Edt_1_process_date_dd { get; set;}
	 //     05  edt-1-filler-2    pic x(33). 
	 public  string Edt_1_filler_2 { get; set;}

        public object Edt_Reference { get; set; }
    }
}
