using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Constants_mstr_rec_2
    {
        	 //01  constants-mstr-rec-2. 
	// public  string Constants_mstr_rec_2 { get; set;}
	 //    05  const-rec-2-rec-nbr   pic 99. 
	 public  int Const_rec_2_rec_nbr { get; set;}
	 //    05  const-info.                             
	 public  string Const_info { get; set;}
	 // 10  const-info-curr-prev occurs 2 times. 
	 public  string[] Const_info_curr_prev { get; set;}
	 //        15  const-effective-date.                  
	 public  string[] Const_effective_date { get; set;}
	 //         20  const-yy   pic 9(4).
	 public  int[] Const_yy { get; set;}
	 //         20  const-mm    pic 99. 
	 public  int[] Const_mm { get; set;}
	 //         20  const-dd    pic 99. 
	 public  int[] Const_dd { get; set;}
	 //     15  const-bilateral   pic 99v99. 
	 public  decimal[] Const_bilateral { get; set;}
	 //     15  const-ic   pic 99v99. 
	 public  decimal[] Const_ic { get; set;}
	 //     15  const-sr   pic 99v99. 
	 public  decimal[] Const_sr { get; set;}
	 //     15  const-wcb   pic 999v9(5). 
	 public  decimal[] Const_wcb { get; set;}
	 //     15  const-ohip-oma-rates occurs 2 times. 
	 public  string[,] Const_ohip_oma_rates { get; set;}
	 //         20  const-asst   pic 99v99. 
	 public  decimal[,] Const_asst { get; set;}
	 //         20  const-reg       pic 99v99. 
	 public  decimal[,] Const_reg { get; set;}
	 //         20  const-cert      pic 99v99. 
	 public  decimal[,] Const_cert { get; set;}
	 //    05  const-info-r redefines const-info.                   
	 public  string[] Const_info_r { get; set;}
	 // 10  const-info-curr-prev-r. 
	 public  string[] Const_info_curr_prev_r { get; set;}
	 //     15  const-effective-date-curr. 
	 public  string[] Const_effective_date_curr { get; set;}
	 //         20  const-yy-curr  pic 9999. 
	 public  int[] Const_yy_curr { get; set;}
	 //         20  const-mm-curr  pic 99. 
	 public  int[] Const_mm_curr { get; set;}
	 //         20  const-dd-curr  pic 99. 
	 public  int[] Const_dd_curr { get; set;}
	 //     15  const-bilateral-curr  pic 99v99. 
	 public  decimal[] Const_bilateral_curr { get; set;}
	 //     15  const-ic-curr   pic 99v99. 
	 public  decimal[] Const_ic_curr { get; set;}
	 //     15  const-sr-curr   pic 99v99. 
	 public  decimal[] Const_sr_curr { get; set;}
	 //     15  const-wcb-curr   pic 999v9(5). 
	 public  decimal[] Const_wcb_curr { get; set;}
	 //     15  const-ohip-oma-rates-curr. 
	 public  string[] Const_ohip_oma_rates_curr { get; set;}
	 //         20  const-asst-h-curr  pic 99v99. 
	 public  decimal[] Const_asst_h_curr { get; set;}
	 //         20  const-reg-h-curr  pic 99v99. 
	 public  decimal[] Const_reg_h_curr { get; set;}
	 //         20  const-cert-h-curr  pic 99v99. 
	 public  decimal[] Const_cert_h_curr { get; set;}
	 //         20  const-asst-a-curr    pic 99v99. 
	 public  decimal[] Const_asst_a_curr { get; set;}
	 //         20  const-reg-a-curr    pic 99v99. 
	 public  decimal[] Const_reg_a_curr { get; set;}
	 //          20  const-cert-a-curr  pic 99v99. 
	 public  decimal[] Const_cert_a_curr { get; set;}
	 //     15  const-effective-date-prev. 
	 public  string[] Const_effective_date_prev { get; set;}
	 //         20  const-yy-prev  pic 9999. 
	 public  int[] Const_yy_prev { get; set;}
	 //         20  const-mm-prev  pic 99. 
	 public  int[] Const_mm_prev { get; set;}
	 //         20  const-dd-prev  pic 99. 
	 public  int[] Const_dd_prev { get; set;}
	 //     15  const-bilateral-prev  pic 99v99. 
	 public  decimal[] Const_bilateral_prev { get; set;}
	 //     15  const-ic-prev   pic 99v99. 
	 public  decimal[] Const_ic_prev { get; set;}
	 //     15  const-sr-prev   pic 99v99. 
	 public  decimal[] Const_sr_prev { get; set;}
	 //     15  const-wcb-prev   pic 999v9(5). 
	 public  decimal[] Const_wcb_prev { get; set;}
	 //     15  const-ohip-oma-rates-prev. 
	 public  string[] Const_ohip_oma_rates_prev { get; set;}
	 //         20  const-asst-h-prev  pic 99v99. 
	 public  decimal[] Const_asst_h_prev { get; set;}
	 //         20  const-reg-h-prev  pic 99v99. 
	 public  decimal[] Const_reg_h_prev { get; set;}
	 //         20  const-cert-h-prev  pic 99v99. 
	 public  decimal[] Const_cert_h_prev { get; set;}
	 //         20  const-asst-a-prev  pic 99v99. 
	 public  decimal[] Const_asst_a_prev { get; set;}
	 //         20  const-reg-a-prev    pic 99v99. 
	 public  decimal[] Const_reg_a_prev { get; set;}
	 //         20  const-cert-a-prev  pic 99v99. 
	 public  decimal[] Const_cert_a_prev { get; set;}
	 //    05  const-max-nbr-rates   pic 99. 
	 public  int[] Const_max_nbr_rates { get; set;}
	 //    05  const-groups.                 
	 public  string[] Const_groups { get; set;}
	 // 10  const-group-rates occurs 19 times. 
	 public  string[,] Const_group_rates { get; set;}
	 //  20  const-section  pic xx. 
	 public  string[,] Const_section { get; set;}
	 //  20  const-group   pic 99. 
	 public  int[,] Const_group { get; set;}
	 //    05  const-group-r redefines const-groups.               
	 public  string[] Const_group_r { get; set;}
	 // 10  const-group-rates-r. 
	 public  string[] Const_group_rates_r { get; set;}
	 //     15  const-sect-1   pic xx. 
	 public  string[] Const_sect_1 { get; set;}
	 //     15  const-group-1   pic 99. 
	 public  int[] Const_group_1 { get; set;}
	 //     15  const-curr-1       pic 99v99. 
	 public  decimal[] Const_curr_1 { get; set;}
	 //     15  const-prev-1       pic 99v99. 
	 public  decimal[] Const_prev_1 { get; set;}
	 //     15  const-sect-2   pic xx. 
	 public  string[] Const_sect_2 { get; set;}
	 //     15  const-group-2   pic 99. 
	 public  int[] Const_group_2 { get; set;}
	 //     15  const-curr-2       pic 99v99. 
	 public  decimal[] Const_curr_2 { get; set;}
	 //     15  const-prev-2      pic 99v99. 
	 public  decimal[] Const_prev_2 { get; set;}
	 //     15  const-sect-3   pic xx. 
	 public  string[] Const_sect_3 { get; set;}
	 //     15  const-group-3   pic 99. 
	 public  int[] Const_group_3 { get; set;}
	 //     15  const-curr-3       pic 99v99. 
	 public  decimal[] Const_curr_3 { get; set;}
	 //     15  const-prev-3        pic 99v99. 
	 public  decimal[] Const_prev_3 { get; set;}
	 //     15  const-sect-4   pic xx. 
	 public  string[] Const_sect_4 { get; set;}
	 //     15  const-group-4   pic 99. 
	 public  int[] Const_group_4 { get; set;}
	 //     15  const-curr-4       pic 99v99. 
	 public  decimal[] Const_curr_4 { get; set;}
	 //     15  const-prev-4       pic 99v99. 
	 public  decimal[] Const_prev_4 { get; set;}
	 //     15  const-sect-5   pic xx. 
	 public  string[] Const_sect_5 { get; set;}
	 //     15  const-group-5   pic 99. 
	 public  int[] Const_group_5 { get; set;}
	 //     15  const-curr-5       pic 99v99. 
	 public  decimal[] Const_curr_5 { get; set;}
	 //     15  const-prev-5       pic 99v99. 
	 public  decimal[] Const_prev_5 { get; set;}
	 //     15  const-sect-6   pic xx. 
	 public  string[] Const_sect_6 { get; set;}
	 //     15  const-group-6   pic 99. 
	 public  int[] Const_group_6 { get; set;}
	 //     15  const-curr-6       pic 99v99. 
	 public  decimal[] Const_curr_6 { get; set;}
	 //     15  const-prev-6       pic 99v99. 
	 public  decimal[] Const_prev_6 { get; set;}
	 //     15  const-sect-7   pic xx. 
	 public  string[] Const_sect_7 { get; set;}
	 //     15  const-group-7   pic 99. 
	 public  int[] Const_group_7 { get; set;}
	 //     15  const-curr-7       pic 99v99. 
	 public  decimal[] Const_curr_7 { get; set;}
	 //     15  const-prev-7       pic 99v99. 
	 public  decimal[] Const_prev_7 { get; set;}
	 //     15  const-sect-8   pic xx. 
	 public  string[] Const_sect_8 { get; set;}
	 //     15  const-group-8   pic 99. 
	 public  int[] Const_group_8 { get; set;}
	 //     15  const-curr-8        pic 99v99. 
	 public  decimal[] Const_curr_8 { get; set;}
	 //     15  const-prev-8      pic 99v99. 
	 public  decimal[] Const_prev_8 { get; set;}
	 //     15  const-sect-9   pic xx. 
	 public  string[] Const_sect_9 { get; set;}
	 //     15  const-group-9   pic 99. 
	 public  int[] Const_group_9 { get; set;}
	 //     15  const-curr-9      pic 99v99. 
	 public  decimal[] Const_curr_9 { get; set;}
	 //     15  const-prev-9       pic 99v99. 
	 public  decimal[] Const_prev_9 { get; set;}
	 //     15  const-sect-10   pic xx. 
	 public  string[] Const_sect_10 { get; set;}
	 //     15  const-group-10   pic 99. 
	 public  int[] Const_group_10 { get; set;}
	 //     15  const-curr-10     pic 99v99. 
	 public  decimal[] Const_curr_10 { get; set;}
	 //     15  const-prev-10       pic 99v99. 
	 public  decimal[] Const_prev_10 { get; set;}
	 //     15  const-sect-11   pic xx. 
	 public  string[] Const_sect_11 { get; set;}
	 //     15  const-group-11   pic 99. 
	 public  int[] Const_group_11 { get; set;}
	 //     15  const-curr-11       pic 99v99. 
	 public  decimal[] Const_curr_11 { get; set;}
	 //     15  const-prev-11       pic 99v99. 
	 public  decimal[] Const_prev_11 { get; set;}
	 //     15  const-sect-12   pic xx. 
	 public  string[] Const_sect_12 { get; set;}
	 //     15  const-group-12   pic 99. 
	 public  int[] Const_group_12 { get; set;}
	 //     15  const-curr-12       pic 99v99. 
	 public  decimal[] Const_curr_12 { get; set;}
	 //     15  const-prev-12       pic 99v99. 
	 public  decimal[] Const_prev_12 { get; set;}
	 //     15  const-sect-13   pic xx. 
	 public  string[] Const_sect_13 { get; set;}
	 //     15  const-group-13   pic 99. 
	 public  int[] Const_group_13 { get; set;}
	 //     15  const-curr-13       pic 99v99. 
	 public  decimal[] Const_curr_13 { get; set;}
	 //     15  const-prev-13       pic 99v99. 
	 public  decimal[] Const_prev_13 { get; set;}
	 //     15  const-sect-14   pic xx. 
	 public  string[] Const_sect_14 { get; set;}
	 //     15  const-group-14   pic 99. 
	 public  int[] Const_group_14 { get; set;}
	 //     15  const-curr-14       pic 99v99. 
	 public  decimal[] Const_curr_14 { get; set;}
	 //     15  const-prev-14      pic 99v99. 
	 public  decimal[] Const_prev_14 { get; set;}
	 //     15  const-sect-15   pic xx. 
	 public  string[] Const_sect_15 { get; set;}
	 //     15  const-group-15   pic 99. 
	 public  int[] Const_group_15 { get; set;}
	 //     15  const-curr-15      pic 99v99. 
	 public  decimal[] Const_curr_15 { get; set;}
	 //     15  const-prev-15       pic 99v99. 
	 public  decimal[] Const_prev_15 { get; set;}
	 //     15  const-sect-16   pic xx. 
	 public  string[] Const_sect_16 { get; set;}
	 //     15  const-group-16   pic 99. 
	 public  int[] Const_group_16 { get; set;}
	 //     15  const-curr-16       pic 99v99. 
	 public  decimal[] Const_curr_16 { get; set;}
	 //      15  const-prev-16       pic 99v99. 
	 public  decimal[] Const_prev_16 { get; set;}
	 //     15  const-sect-17   pic xx. 
	 public  string[] Const_sect_17 { get; set;}
	 //     15  const-group-17   pic 99. 
	 public  int[] Const_group_17 { get; set;}
	 //     15  const-curr-17       pic 99v99. 
	 public  decimal[] Const_curr_17 { get; set;}
	 //     15  const-prev-17       pic 99v99. 
	 public  decimal[] Const_prev_17 { get; set;}
	 //     15  const-sect-18   pic xx. 
	 public  string[] Const_sect_18 { get; set;}
	 //     15  const-group-18   pic 99. 
	 public  int[] Const_group_18 { get; set;}
	 //     15  const-curr-18       pic 99v99. 
	 public  decimal[] Const_curr_18 { get; set;}
	 //     15  const-prev-18       pic 99v99. 
	 public  decimal[] Const_prev_18 { get; set;}
	 //     15  const-sect-19   pic xx. 
	 public  string[] Const_sect_19 { get; set;}
	 //     15  const-group-19   pic 99. 
	 public  int[] Const_group_19 { get; set;}
	 //     15  const-curr-19       pic 99v99. 
	 public  decimal[] Const_curr_19 { get; set;}
	 //     15  const-prev-19       pic 99v99. 
	 public  decimal[] Const_prev_19 { get; set;}
	 //    05  filler     pic x(41). 
	 public  string[] Filler { get; set;}

}
}
