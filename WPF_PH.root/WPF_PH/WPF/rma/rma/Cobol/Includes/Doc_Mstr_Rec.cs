using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Doc_Mstr_Rec
    {
        //05  doc-nbr pic x(3).
        public string doc_nbr { get; set; }
        //05  doc-dept pic 99.
        public int doc_dept { get; set; }
        //05  doc-ohip-nbr pic 9(6).
        public long doc_ohip_nbr { get; set; }
        //05  doc-pract-nbr redefines doc-ohip-nbr pic 9(6).
        public long doc_pract_nbr_redefines { get; set; }
        //05  doc-sin-nbr.
        public long doc_sin_nbr_grp { get; set; }
        //10  doc-sin-123                         pic 999.
        public int doc_sin_123_child { get; set; }
        //10  doc-sin-456                         pic 999.
        public int doc_sin_456_child { get; set; }
        //10  doc-sin-789                         pic 999.
        public int doc_sin_789_child { get; set; }
        //05  doc-clinic-nbr pic 99.
        public int doc_clinic_nbr { get; set; }
        //05  doc-spec-cd pic 99.
        public int doc_spec_cd { get; set; }
        // 05  doc-hosp-nbr pic x999.
        public string doc_hosp_nbr { get; set; }
        // 05  doc-name pic x(24).
        public string doc_name { get; set; }
        // 05  doc-name-soundex pic x(4).
        public string doc_name_soundex { get; set; }

        //  05  doc-inits.
        public string doc_inits_grp { get; set; }
        //10  doc-init1 pic x.
        public string doc_init1_child { get; set; }
        // 10  doc-init2 pic x.
        public string doc_init2_child { get; set; }
        // 10  doc-init3 pic x.
        public string doc_init3 { get; set; }

        //   05  doc-address-office.
        public string doc_address_office_grp { get; set; }
        // 10  doc-addr-office-1                   pic x(24).
        public string doc_addr_office_1_child { get; set; }
        // 10  doc-addr-office-2                   pic x(24).
        public string doc_addr_office_2_child { get; set; }
        //10  doc-addr-office-3                   pic x(24).
        public string doc_addr_office_3_child { get; set; }

        //05  doc-addr-office-r redefines  doc-address-office.
        public string[] doc_addr_office_r_redefines { get; set; }
        //10  doc-addr-office occurs 3 times pic x(24).
        public string[] doc_addr_office { get; set; }

        //  05  doc-addr-office-pc.
        public string doc_addr_office_pc_grp { get; set; }
        // 10  doc-addr-office-pc-123.
        public string doc_addr_office_pc_123_grp_child { get; set; }
        // 15  doc-addr-office-pc1 pic a.
        public string doc_addr_office_pc1_child { get; set; }
        // 15  doc-addr-office-pc2 pic 9.
        public int doc_addr_office_pc2_child { get; set; }
        //15  doc-addr-office-pc3 pic a.
        public string doc_addr_office_pc3_child { get; set; }

        // 10  doc-addr-office-pc-456.
        public string doc_addr_office_pc_456_grp_child { get; set; }
        // 15  doc-addr-office-pc4 pic 9.
        public int doc_addr_office_pc4_child { get; set; }
        // 15  doc-addr-office-pc5 pic a.
        public string doc_addr_office_pc5_child { get; set; }
        // 15  doc-addr-office-pc6 pic 9.
        public int doc_addr_office_pc6 { get; set; }

        //  05  doc-address-home.
        public string doc_address_home_grp { get; set; }
        // 10  doc-addr-home-1                     pic x(24).
        public string doc_addr_home_1_child { get; set; }
        // 10  doc-addr-home-2                     pic x(24).
        public string doc_addr_home_2_child { get; set; }
        //10  doc-addr-home-3                     pic x(24).
        public string doc_addr_home_3_child { get; set; }

        //  05  doc-addr-home-r redefines doc-address-home.
        public string doc_addr_home_r_grp_redefines { get; set; }
        //10  doc-addr-home occurs 3 times pic x(24).
        public string[] doc_addr_home { get; set; }

        //   05  doc-addr-home-pc.
        public string doc_addr_home_pc_grp { get; set; }
        //10  doc-addr-home-pc-123.
        public string doc_addr_home_pc_123_grp_child { get; set; }
        // 15  doc-addr-home-pc1 pic a.
        public string doc_addr_home_pc1_child { get; set; }
        // 15  doc-addr-home-pc2 pic 9.
        public int doc_addr_home_pc2_child { get; set; }
        // 15  doc-addr-home-pc3 pic a.
        public string doc_addr_home_pc3_child { get; set; }
        // 10  doc-addr-home-pc-456.
        public string doc_addr_home_pc_456_grp_child { get; set; }
        // 15  doc-addr-home-pc4 pic 9.
        public int doc_addr_home_pc4_child { get; set; }
        // 15  doc-addr-home-pc5 pic a.
        public string doc_addr_home_pc5_child { get; set; }
        // 15  doc-addr-home-pc6 pic 9.
        public int doc_addr_home_pc6_child { get; set; }

        // 05  doc-full-part-ind pic x.
        public string doc_full_part_ind { get; set; }
        // 05  doc-class-code redefines doc-full-part-ind pic x.
        public string doc_class_code_redefines { get; set; }

        //05  doc-bank-info.
        public string doc_bank_info_grp { get; set; }
        // 10  doc-bank-nbr pic 9(4).
        public int doc_bank_nbr_child { get; set; }
        // 10  doc-bank-branch pic 9(5).
        public int doc_bank_branch_child { get; set; }
        //  10  doc-bank-acct pic x(12).
        public string doc_bank_acct { get; set; }

        // 05  doc-fac-dates.
        public string doc_fac_dates_grp { get; set; }
        // 10  doc-date-fac-start.
        public string doc_date_fac_start_grp_chiild { get; set; }

        // 15  doc-date-fac-start-yy pic 9999.
        public int doc_date_fac_start_yy_child { get; set; }
        // 15  doc-date-fac-start-mm pic 99.
        public int doc_date_fac_start_mm_child { get; set; }
        // 15  doc-date-fac-start-dd pic 99.
        public int doc_date_fac_start_dd { get; set; }
        // 10  doc-date-fac-term.
        public string doc_date_fac_term_grp_child { get; set; }
        // 15  doc-date-fac-term-yy pic 9999.
        public int doc_date_fac_term_yy_child { get; set; }
        // 15  doc-date-fac-term-mm pic 99.
        public int doc_date_fac_term_mm_child { get; set; }
        //15  doc-date-fac-term-dd pic 99.
        public int doc_date_fac_term_dd_child { get; set; }

        // 05    doc-fac-dates-r redefines doc-fac-dates.
        public string doc_fac_dates_r_redefines { get; set; }

        // 10  doc-date-fac occurs 2 times.            
        public string[] doc_date_fac_grp_child { get; set; }
        //  15  doc-date-fac-yy pic 9999.
        public int[] doc_date_fac_yy_child { get; set; }
        // 15  doc-date-fac-mm pic 99.
        public int[] doc_date_fac_mm_child { get; set; }
        // 15  doc-date-fac-dd pic 99.
        public int[] doc_date_fac_dd { get; set; }


        //   05  doc-annual-ceiling-info.
        public string doc_annual_ceiling_info_grp { get; set; }
        // 10  doc-ytdgua pic s9(7)v99 comp.
        public decimal doc_ytdgua_child { get; set; }
        // 10  doc-ytdgub pic s9(7)v99 comp.
        public decimal doc_ytdgub_child { get; set; }
        // 10  doc-ytdguc pic s9(7)v99 comp.
        public decimal doc_ytdguc_child { get; set; }
        // 10  doc-ytdgud pic s9(7)v99 comp.
        public decimal doc_ytdgud_child { get; set; }
        // 10  doc-ytdcea pic s9(7)v99 comp.
        public decimal doc_ytdcea_child { get; set; }
        // 10  doc-ytdcex pic s9(7)v99 comp.
        public decimal doc_ytdcex_child { get; set; }
        // 10  doc-ytdear pic s9(7)v99 comp.
        public decimal doc_ytdear_child { get; set; }
        //10  doc-ytdinc pic s9(7)v99 comp.
        public decimal doc_ytdinc_child { get; set; }
        // 10  doc-ytdeft pic s9(7)v99 comp.
        public decimal doc_ytdeft_child { get; set; }
        // 10  doc-totinc-g pic s9(7)v99 comp.
        public decimal doc_totinc_g_child { get; set; }

        //  10  doc-ep-date-deposit pic 9(8).
        public long doc_ep_date_deposit_child { get; set; }
        // 10  doc-totinc pic s9(7)v99 comp.
        public decimal doc_totinc_child { get; set; }
        // 10  doc-ep-ceiexp pic s9(7)v99 comp.
        public decimal doc_ep_ceiexp_child { get; set; }
        // 10  doc-adjcea pic s9(7)v99 comp.
        public decimal doc_adjcea_child { get; set; }
        // 10  doc-adjcex pic s9(7)v99 comp.
        public decimal doc_adjcex_child { get; set; }
        // 10  doc-ceicea pic s9(7)v99 comp.
        public decimal doc_ceicea_child { get; set; }
        // 10  doc-ceicex pic s9(7)v99 comp.
        public decimal doc_ceicex_child { get; set; }
        // 10  ceicea-prt-format pic x(13).
        public string ceicea_prt_format_child { get; set; }
        // 10  ceicex-prt-format pic x(13).
        public string ceicex_prt_format_child { get; set; }
        // 10  ytdcea-prt-format pic x(13).
        public string ytdcea_prt_format_child { get; set; }
        // 10  ytdcex-prt-format pic x(13).
        public string ytdcex_prt_format_child { get; set; }
        // 10  doc-clinic-nbr-2                    pic 99.
        public int doc_clinic_nbr_2_child { get; set; }
        // 10  doc-clinic-nbr-3                    pic 99.
        public int doc_clinic_nbr_3_child { get; set; }
        // 10  doc-clinic-nbr-4                    pic 99.
        public int doc_clinic_nbr_4_child { get; set; }
        // 10  doc-clinic-nbr-5                    pic 99.
        public int doc_clinic_nbr_5_child { get; set; }
        // 10  doc-clinic-nbr-6                    pic 99.
        public int doc_clinic_nbr_6_child { get; set; }
        // 10  doc-spec-cd-2                       pic 99.
        public int doc_spec_cd_2_child;
        // 10  doc-spec-cd-3                       pic 99.
        public int doc_spec_cd_3_child { get; set; }
        //    10  doc-ytdinc-g pic s9(7)v99 comp.
        public decimal doc_ytdinc_g_child { get; set; }

        // 05  doc-locations.
        public string doc_locations_grp { get; set; }
        // 10  doc-loc-1                           pic x999.
        public string doc_loc_1_child { get; set; }
        // 10  doc-loc-2                           pic x999.
        public string doc_loc_2_child { get; set; }
        // 10  doc-loc-3                           pic x999.
        public string doc_loc_3_child { get; set; }
        // 10  doc-loc-4                           pic x999.
        public string doc_loc_4_child { get; set; }
        // 10  doc-loc-5                           pic x999.
        public string doc_loc_5_child { get; set; }
        // 10  doc-loc-6                           pic x999.
        public string doc_loc_6_child { get; set; }
        // 10  doc-loc-7                           pic x999.
        public string doc_loc_7_child { get; set; }
        // 10  doc-loc-8                           pic x999.
        public string doc_loc_8_child { get; set; }
        // 10  doc-loc-9                           pic x999.
        public string doc_loc_9_child { get; set; }
        //10  doc-loc-10                          pic x999.
        public string doc_loc_10_child { get; set; }
        //10  doc-loc-11                          pic x999.
        public string doc_loc_11_child { get; set; }
        //10  doc-loc-12                          pic x999.
        public string doc_loc_12_child { get; set; }
        //10  doc-loc-13                          pic x999.
        public string doc_loc_13_child { get; set; }
        // 10  doc-loc-14                          pic x999.
        public string doc_loc_14_child { get; set; }
        //10  doc-loc-15                          pic x999.
        public string doc_loc_15_child { get; set; }
        //10  doc-loc-16                          pic x999.
        public string doc_loc_16_child { get; set; }
        //10  doc-loc-17                          pic x999.
        public string doc_loc_17_child { get; set; }
        //10  doc-loc-18                          pic x999.
        public string doc_loc_18_child { get; set; }
        //10  doc-loc-19                          pic x999.
        public string doc_loc_19_child { get; set; }
        //10  doc-loc-20                          pic x999.
        public string doc_loc_20_child { get; set; }
        //10  doc-loc-21                          pic x999.
        public string doc_loc_21_child { get; set; }
        //10  doc-loc-22                          pic x999.
        public string doc_loc_22_child { get; set; }
        //10  doc-loc-23                          pic x999.
        public string doc_loc_23_child { get; set; }
        //10  doc-loc-24                          pic x999.
        public string doc_loc_24_child { get; set; }
        //10  doc-loc-25                          pic x999.
        public string doc_loc_25_child { get; set; }
        //10  doc-loc-26                          pic x999.
        public string doc_loc_26_child { get; set; }
        //10  doc-loc-27                          pic x999.
        public string doc_loc_27_child { get; set; }
        //10  doc-loc-28                          pic x999.
        public string doc_loc_28_child { get; set; }
        //10  doc-loc-29                          pic x999.
        public string doc_loc_29_child { get; set; }
        //10  doc-loc-30                          pic x999.
        public string doc_loc_30_child { get; set; }

        // 05  doc-locations-r redefines  doc-locations.
        public string doc_locations_r_redefines { get; set; }
        //10  doc-loc occurs 30 times pic x999.
        public string[] doc_loc { get; set; }

        //05  doc-rma-expense-percent-misc pic 9(5)v9(4) comp.
        public decimal docrma_expense_percent_misc { get; set; }
        //05  filler2 pic x(8).
        public string filler2 { get; set; }
        //05  doc-ind-pays-gst pic x.
        public string doc_ind_pays_gst { get; set; }
        //05  doc-nx-avail-batch pic 999.
        public int doc_nx_avail_batch { get; set; }

        // * 2002/07/16 - MC - add 5 more next batch nbr for each clinic
        // 05  doc-nx-avail-batch-2                    pic 999.
        public int doc_nx_avail_batch_2 { get; set; }
        // 05  doc-nx-avail-batch-3                    pic 999.
        public int doc_nx_avail_batch_3 { get; set; }
        //05  doc-nx-avail-batch-4                    pic 999.
        public int doc_nx_avail_batch_4 { get; set; }
        //05  doc-nx-avail-batch-5                    pic 999.
        public int doc_nx_avail_batch_5 { get; set; }
        //05  doc-nx-avail-batch-6                    pic 999.
        public int doc_nx_avail_batch_6 { get; set; }

        // * 2002/07/16 - end
        // 05  doc-yrly-ceiling-computed pic 9(7)v99 comp.
        public decimal doc_yrly_ceiling_computed { get; set; }
        // 05  doc-yrly-expense-computed pic 9(7)v99 comp.
        public decimal doc_yrly_expense_computed { get; set; }
        //05  doc-rma-expense-percent-reg pic 9(5)v9(4) comp.
        public decimal doc_rma_expense_percent_reg { get; set; }
        //05  doc-sub-specialty pic x(15).
        public string doc_sub_specialty { get; set; }
        //05  doc-payeft pic s9(7)v99 comp.
        public decimal doc_payeft { get; set; }
        //05  doc-ytdded pic s9(7)v99 comp.
        public decimal doc_ytdded { get; set; }
        //05  doc-dept-expense-percent-misc pic 9(5)v9(4) comp.
        public decimal doc_dept_expense_percent_misc { get; set; }
        //05  doc-dept-expense-percent-reg pic 9(5)v9(4) comp.
        public decimal doc_dept_expense_percent_reg { get; set; }
        //05  doc-ep-ped pic s9(9) comp.
        public long doc_ep_ped { get; set; }
        //05  doc-ep-pay-code pic x.
        public string doc_ep_pay_code { get; set; }
        //05  doc-ep-pay-sub-code pic x.
        public string doc_ep_pay_sub_code { get; set; }
        //05  filler3 pic x(1).
        public string filler3 { get; set; }
        //05  doc-ind-holdback-active pic x(1).
        public string doc_ind_holdback_active { get; set; }
        //05  group-regular-service pic x(4).
        public string group_regular_service { get; set; }

        //* 2002/09/23 - MC             
        //05  group-over-serviced pic x(4).
        public string group_over_serviced { get; set; }
    }
}
