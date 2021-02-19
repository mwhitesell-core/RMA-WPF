using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Fee_mstr_rec
    {
        	 //01 fee-mstr-rec.   
	 //public  string Fee_mstr_rec { get; set;}
	 //    05  fee-oma-cd.   
	 public  string Fee_oma_cd { get; set;}
	 // 10  fee-oma-cd-ltr1   pic x.   
	 public  string Fee_oma_cd_ltr1 { get; set;}
	 // 10  filler    pic 999.   
	 public  int Filler { get; set;}
	 //    05  fee-special-m-suffix-ind  pic x.   
	 public  string Fee_special_m_suffix_ind { get; set;}
	 //    05  fee-effective-date.   
	 public  string Fee_effective_date { get; set;}
	 // 10  fee-date-yy    pic 9999.   
	 public  int Fee_date_yy { get; set;}
	 // 10  fee-date-mm    pic 99.   
	 public  int Fee_date_mm { get; set;}
	 // 10  fee-date-dd    pic 99.   
	 public  int Fee_date_dd { get; set;}
	 //    05  fee-active-for-entry    pic x(1).
	 public  string Fee_active_for_entry { get; set;}
	 //    05  fee-desc    pic x(48).   
	 public  string Fee_desc { get; set;}
	 //    05  fee-current-prev-years.   
	 public  string Fee_current_prev_years { get; set;}
	 // 10  fee-curr-a-anae   pic 99.   
	 public  int Fee_curr_a_anae { get; set;}
	 // 10  fee-curr-h-anae   pic 99.   
	 public  int Fee_curr_h_anae { get; set;}
	 // 10  fee-curr-a-asst   pic 99.        
	 public  int Fee_curr_a_asst { get; set;}
	 // 10  fee-curr-h-asst   pic 99.   
	 public  int Fee_curr_h_asst { get; set;}
	 // 10  fee-curr-add-on-codes.   
	 public  string Fee_curr_add_on_codes { get; set;}
	 //     15  fee-curr-add-on-cd  pic x999    occurs 10 times.   
	 public  string[] Fee_curr_add_on_cd { get; set;}
	 // 10  fee-curr-oma-ind-card-reqs.   
	 public  string Fee_curr_oma_ind_card_reqs { get; set;}
	 //     15  fee-curr-oma-ind-card-required pic x     occurs  3 times.   
	 public  string[] Fee_curr_oma_ind_card_required { get; set;}
	 // 10  fee-curr-page.
	 public  string Fee_curr_page { get; set;}
	 //     15 fee-curr-page-alpha  pic x(2).
	 public  string Fee_curr_page_alpha { get; set;}
	 //     15 fee-curr-page-numeric  pic 999.
	 public  int Fee_curr_page_numeric { get; set;}
	 // 10  fee-curr-add-on-perc-flat-ind pic x.   
	 public  string Fee_curr_add_on_perc_flat_ind { get; set;}
	 // 10  fee-prev-a-anae   pic 99.   
	 public  int Fee_prev_a_anae { get; set;}
	 // 10  fee-prev-h-anae   pic 99.        
	 public  int Fee_prev_h_anae { get; set;}
	 // 10  fee-prev-a-asst   pic 99.         
	 public  int Fee_prev_a_asst { get; set;}
	 // 10  fee-prev-h-asst   pic 99.        
	 public  int Fee_prev_h_asst { get; set;}
	 // 10  fee-prev-add-on-codes.   
	 public  string Fee_prev_add_on_codes { get; set;}
	 //     15  fee-prev-add-on-cd  pic x999 occurs 10 times.   
	 public  string[] Fee_prev_add_on_cd { get; set;}
	 // 10  fee-prev-oma-ind-card-reqs.   
	 public  string Fee_prev_oma_ind_card_reqs { get; set;}
	 //     15  fee-prev-oma-ind-card-required  pic x  occurs  3 times.   
	 public  string[] Fee_prev_oma_ind_card_required { get; set;}
	 // 10  fee-prev-page.
	 public  string Fee_prev_page { get; set;}
	 //     15 fee-prev-page-alpha  pic x(2).
	 public  string Fee_prev_page_alpha { get; set;}
	 //     15 fee-prev-page-numeric  pic 999.
	 public  int Fee_prev_page_numeric { get; set;}
	 // 10  fee-prev-add-on-perc-flat-ind pic x.   
	 public  string Fee_prev_add_on_perc_flat_ind { get; set;}
	 //    05  fee-current-prev-year-r redefines fee-current-prev-years.   
	 public  string Fee_current_prev_year_r { get; set;}
	 // 10  fee-years occurs 2 times.   
	 public  string[] Fee_years { get; set;}
	 //     15  fee-anae occurs 2 times          pic 99.        
	 public  int[,] Fee_anae { get; set;}
	 //     15  fee-asst occurs 2 times          pic 99.   
	 public  int[,] Fee_asst { get; set;}
	 //     15  fee-add-on-codes.   
	 public  string[] Fee_add_on_codes { get; set;}
	 //  20  fee-add-on-cd  pic x999 occurs 10 times.   
	 public  string[,] Fee_add_on_cd { get; set;}
	 //     15  fee-oma-ind-card-requireds.   
	 public  string[] Fee_oma_ind_card_requireds { get; set;}
	 //  20  fee-oma-ind-card-required pic x  occurs  3 times.   
	 public  string[,] Fee_oma_ind_card_required { get; set;}
	 //            15  fee-page-alpha-numeric.
	 public  string[] Fee_page_alpha_numeric { get; set;}
	 //  20 fee-page-alpha  pic x(2).
	 public  string[] Fee_page_alpha { get; set;}
	 //         20 fee-page   pic 9(3).
	 public  int[] Fee_page { get; set;}
	 //     15  fee-add-on-perc-or-flat-ind pic x.   
	 public  string[] Fee_add_on_perc_or_flat_ind { get; set;}
	 //    05  fee-icc-code.   
	 public  string Fee_icc_code { get; set;}
	 // 10  fee-icc-sec    pic xx.   
	 public  string Fee_icc_sec { get; set;}
	 // 10  fee-icc-cat    pic  9.   
	 public  int Fee_icc_cat { get; set;}
	 // 10  fee-icc-grp    pic 99.   
	 public  int Fee_icc_grp { get; set;}
	 // 10  fee-icc-reduc-ind   pic  9.   
	 public  int Fee_icc_reduc_ind { get; set;}
	 //    05  fee-diag-ind    pic x.   
	 public  string Fee_diag_ind { get; set;}
	 //    05  fee-phy-ind    pic x.   
	 public  string Fee_phy_ind { get; set;}
	 //    05  fee-tech-ind    pic x.   
	 public  string Fee_tech_ind { get; set;}
	 //    05  fee-hosp-nbr-ind   pic x.   
	 public  string Fee_hosp_nbr_ind { get; set;}
	 //    05  fee-i-o-ind    pic x.   
	 public  string Fee_i_o_ind { get; set;}
	 //    05  fee-admit-ind    pic x.   
	 public  string Fee_admit_ind { get; set;}
	 //    05  fee-spec-fr    pic 99.   
	 public  int Fee_spec_fr { get; set;}
	 //    05  fee-spec-to    pic 99. 
	 public  int Fee_spec_to { get; set;}
	 //    05  fee-global-addon-cd-exclusion  pic x(01).
	 public  string Fee_global_addon_cd_exclusion { get; set;}
	 //    05  filler     pic x(38).
	// public  string Filler { get; set;}

}
}
