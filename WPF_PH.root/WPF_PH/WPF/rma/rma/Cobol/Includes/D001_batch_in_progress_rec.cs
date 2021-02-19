using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class D001_batch_in_progress_rec
    {
        	 //01  d001-batch-in-progress-rec.
	// public  string D001_batch_in_progress_rec { get; set;}
	 //    05  d001-recovery-command-line.
	 public  string D001_recovery_command_line { get; set;}
	 // 10  d001-command-part-1   pic x(12).
	 public  string D001_command_part_1 { get; set;}
	 // 10  d001-space-1   pic x(1).
	 public  string D001_space_1 { get; set;}
	 // 10  d001-batch-nbr.  
	 public  string D001_batch_nbr { get; set;}
	 //            15  d001-bat-clinic-nbr-1-2         pic 99.     
	 public  int D001_bat_clinic_nbr_1_2 { get; set;}
	 //            15  d001-bat-doc-nbr                pic x(3).   
	 public  string D001_bat_doc_nbr { get; set;}
	 //            15  d001-bat-week-day  pic x(3).
	 public  string D001_bat_week_day { get; set;}
	 //            15  d001-bat-week-day-r redefines d001-bat-week-day                                                   pic 999.  
	 public  int D001_bat_week_day_r { get; set;}
	 // 10  d001-space-2   pic x(1).
	 public  string D001_space_2 { get; set;}
	 // 10  d001-loc    pic x(4).
	 public  string D001_loc { get; set;}
	 // 10  d001-space-3    pic x(1).
	 public  string D001_space_3 { get; set;}
	 // 10  d001-agent-cd    pic x(1).
	 public  string D001_agent_cd { get; set;}
	 // 10  d001-space-4   pic x(1).
	 public  string D001_space_4 { get; set;}
	 // 10  d001-i-o-pat-ind   pic x(1).
	 public  string D001_i_o_pat_ind { get; set;}
	 // 10  d001-space-5   pic x(1).
	 public  string D001_space_5 { get; set;}
	 // 10  d001-payroll      pic x(1).
	 public  string D001_payroll { get; set;}
	 // 10  d001-space-6   pic x(1).
	 public  string D001_space_6 { get; set;}
	 // 10  d001-f001-exists-ind  pic x(1).
	 public  string D001_f001_exists_ind { get; set;}
	 // 10  d001-space-7   pic x(1).
	 public  string D001_space_7 { get; set;}
	 // 10  d001-command-part-2   pic x(14).
	 public  string D001_command_part_2 { get; set;}

}
}
