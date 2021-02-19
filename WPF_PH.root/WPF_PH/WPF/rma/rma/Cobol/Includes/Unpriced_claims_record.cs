using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Unpriced_claims_record
    {
       
        //    05  unpriced-trans-id                        pic xx. 
        public string Unpriced_trans_id { get; set; }
        //    05  unpriced-input-rec-type                  pic x. 
        public string Unpriced_input_rec_type { get; set; }

        //05  unpriced-bathdr-rec-full                pic x(177).
        public string unpriced_bathdr_rec_full { get; set; }
        //    05  unpriced-bathdr-rec. 
        public string Unpriced_bathdr_rec { get; set; }
        //        10  unpriced-release-id                  pic x(3).
        public string Unpriced_release_id { get; set; }
        //        10  unpriced-moh-code                    pic x. 
        public string Unpriced_moh_code { get; set; }
        //        10  unpriced-bathdr-batch-nbr. 
        public string Unpriced_bathdr_batch_nbr_grp { get; set; }
        //            15  unpriced-bathdr-batch-nbr-date   pic 9(8).
        public int Unpriced_bathdr_batch_nbr_date { get; set; }
        //            15  unpriced-bathdr-batch-nbr-seq    pic 9(4).
        public int Unpriced_bathdr_batch_nbr_seq { get; set; }
        //        10  unpriced-bathdr-opr-nbr              pic x(6). 
        public string Unpriced_bathdr_opr_nbr { get; set; }
        //        10  unpriced-bathdr-fac-no               pic x(4). 
        public string Unpriced_bathdr_fac_no { get; set; }
        //        10  unpriced-bathdr-prov-ohip-no         pic 9(6). 
        public int Unpriced_bathdr_prov_ohip_no { get; set; }
        //        10  unpriced-bathdr-spec-cd              pic 9(2). 
        public int Unpriced_bathdr_spec_cd { get; set; }
        //        10  filler                              pic x(29). 
        public string Filler { get; set; }
        //        10  unpriced-payroll-flag               pic x(1). 
        public string Unpriced_payroll_flag { get; set; }
        //        10  unpriced-default-batch-i-o-ind      pic x(1). 
        public string Unpriced_default_batch_i_o_ind { get; set; }
        //        10  unpriced-default-batch-loc       pic x(4). 
        public string Unpriced_default_batch_loc { get; set; }

        // 10  unpriced-bathdr-clinic--ignore    pic 99.
        public int Unpriced_bathdr_clinic__ignore { get; set; }

        // 10  unpriced-bathdr-oscar-doc-id         pic x(10).
        public string Unpriced_bathdr_oscar_doc_id { get; set; }

        // 10  unpriced-bathdr-dept                pic 99.
        public int Unpriced_bathdr_dept { get; set; }

        //10  unpriced-bathdr-clinic-1-2          pic 99.
        public int Unpriced_bathdr_clinic_1_2 { get; set; }
        

        // 10  unpriced-bathdr-doc-nbr             pic x(3).
        public string Unpriced_bathdr_doc_nbr { get; set; }


        // HEH        
        public string Unpriced_clmhdr_health_nbr { get; set; }        
        public string Unpriced_clmhdr_version_cd { get; set; }        
        public string Unpriced_clmhdr_birth_date_grp { get; set; }        
        public int Unpriced_clmhdr_birth_date_yy { get; set; }        
        public int Unpriced_clmhdr_birth_date_mm { get; set; }        
        public int Unpriced_clmhdr_birth_date_dd { get; set; }        
        public string Unpriced_clmhdr_claim_grp { get; set; }        
        public string Unpriced_clmhdr_doc_nbr { get; set; }        
        public string Unpriced_clmhdr_wk { get; set; }        
        public string Unpriced_clmhdr_day { get; set; }        
        public string Unpriced_clmhdr_claim_nbr { get; set; }        
        public string Unpriced_clmhdr_pay_pgm { get; set; }        
        public string Unpriced_clmhdr_payee { get; set; }        
        public int Unpriced_clmhdr_ref_doc_nbr { get; set; }        
        public string Unpriced_clmhdr_hosp_nbr { get; set; }        
        public string Unpriced_clmhdr_admit_date_grp { get; set; }        
        public string Unpriced_clmhdr_admit_date_yy { get; set; }        
        public string Unpriced_clmhdr_admit_date_mm { get; set; }        
        public string Unpriced_clmhdr_admit_date_dd { get; set; }        
        public int Unpriced_clmhdr_ref_lab_no { get; set; }        
        public string Unpriced_clmhdr_man_review { get; set; }        
        public int Unpriced_moh_location_code { get; set; }        
        public string Unpriced_reserved_for_ooc { get; set; }
        public string Unpriced_reserved_for_ooc2 { get; set; }
        public string Unpriced_confidentiality_flag { get; set; }
        public string Unpriced_clmhdr_agent_cd { get; set; }        
        public string Unpriced_clmhdr_i_o_ind { get; set; }        
        public string Unpriced_clmhdr_hc_prov_cd { get; set; }        
        public string Unpriced_clmhdr_hc_ohip_nbr { get; set; }        
        public string Unpriced_clmhdr_pat_acronym { get; set; }        
        //public int Unpriced_bathdr_clinic_1_2 { get; set; }        
        public string Unpriced_clmhdr_pat_surname2 { get; set; }        
        public string Unpriced_clmhdr_given_name2 { get; set; }
        //public string Filler { get; set; }

        
        public string Unpriced_clmhdr_pat_ohip_nbr { get; set; }        
        public string Unpriced_clmhdr_pat_surname_2 { get; set; }        
        public string Unpriced_clmhdr_given_name_2 { get; set; }        
        public string Unpriced_clmhdr_sex { get; set; }        
        public int Unpriced_clmhdr_sex_2 { get; set; }
        public string Unpriced_clmhdr_pat_surname { get; set; }        
        public string Unpriced_clmhdr_given_name { get; set; }        
        public string Unpriced_clmhdr_prov_cd { get; set; }        
        //public string Filler { get; set; }        
        //public string Unpriced_confidentiality_flag { get; set; }        
        public string Unpriced_clmhdr_loc_code { get; set; }        
       // public string Unpriced_clmhdr_agent_cd { get; set; }        
        //public string Unpriced_clmhdr_i_o_ind { get; set; }        
        public string Unpriced_clmhdr_phone_no_1_7 { get; set; }        
        public string Unpriced_clmhdr_phone_no_8_10 { get; set; }        
        public string Unpriced_clmhdr_phone_no_1_3 { get; set; }        
        public string Unpriced_clmhdr_phone_no_4_10 { get; set; }
        
        public string Unpriced_clmhdr_prov_cd_grp { get; set; }
        public string Unpriced_itm1_oma_svc_code { get; set; }
        public string Unpriced_itm1_oma_svc_suff { get; set; }        
        public string Filler1 { get; set; }        
        public decimal Unpriced_itm1_oma_amt_billed { get; set; }        
        public int Unpriced_itm1_nbr_serv { get; set; }        
        public string Unpriced_itm1_svc_date_grp { get; set; }
        public int Unpriced_itm1_svc_date_yy { get; set; }
        public int Unpriced_itm1_svc_date_mm { get; set; }        
        public int Unpriced_itm1_svc_date_dd { get; set; }        
        public string Unpriced_itm1_diag_cd { get; set; }        
        public string Filler_diag { get; set; }
//        public string Unpriced_reserved_for_ooc { get; set; }       
        public string Filler2 { get; set; }        
        public string Unpriced_itm2_oma_svc_cd_grp { get; set; }        
        public string Unpriced_itm2_oma_svc_code { get; set; }        
        public string Unpriced_itm2_oma_svc_suff { get; set; }        
        public string Filler3 { get; set; }        
        public decimal Unpriced_itm2_oma_amt_billed { get; set; }        
        public int Unpriced_itm2_nbr_serv { get; set; }
        public string Unpriced_itm2_svc_date_grp { get; set; }        
        public int Unpriced_itm2_svc_date_yy { get; set; }        
        public int Unpriced_itm2_svc_date_mm { get; set; }        
        public int Unpriced_itm2_svc_date_dd { get; set; }        
        public string Unpriced_itm2_diag_cd { get; set; }        
        public string Filler4 { get; set; }        
        public string Unpriced_itm1_override_price { get; set; }        
        public string Unpriced_itm1_bilateral { get; set; }
        public string Unpriced_itm2_override_price { get; set; }        
        public string Unpriced_itm2_bilateral { get; set; }        
        public string Unpriced_itm3_override_price { get; set; }        
        public string Unpriced_itm4_bilateral { get; set; }        
        public string Filler5 { get; set; }


        public string Unpriced_pat_addr_1 { get; set; }        
        public string Unpriced_pat_addr_2 { get; set; }        
        public string Unpriced_pat_addr_3 { get; set; }        
        public string Unpriced_clmhdr_hc_prov_cd_2 { get; set; }        
        public string Unpriced_pat_addr_post_cd { get; set; }        
        public string Unpriced_clmhdr_pat_surname_grp { get; set; }        
        public string Unpriced_clmhdr_surname_1_6 { get; set; }        
        public string Unpriced_clmhdr_surname_7_30 { get; set; }        
        public string Unpriced_clmhdr_given_name_grp { get; set; }
        public string Unpriced_clmhdr_given_name1_3 { get; set; }        
        public string Unpriced_clmhdr_given_name4_30 { get; set; }        
        //public string Unpriced_clmhdr_sex { get; set; }
        public string Unpriced_clmhdr_phone_no { get; set; }        
        public string Unpriced_clmhdr_birth_date2_grp { get; set; }        
        public int Unpriced_clmhdr_birth_date_yy2 { get; set; }        
        public int Unpriced_clmhdr_birth_date_mm2 { get; set; }        
        public int Unpriced_clmhdr_birth_date_dd2 { get; set; }        
        //public string Filler { get; set; }        
        public string Unpriced_pat_addr_post_cd1 { get; set; }        
        public string Unpriced_pat_addr_post_cd2 { get; set; }        
        public string Unpriced_pat_addr_post_cd3 { get; set; }        
        public string Unpriced_pat_addr_post_cd4 { get; set; }        
        public string Unpriced_pat_addr_post_cd5 { get; set; }        
        public string Unpriced_pat_addr_post_cd6 { get; set; }        
        public string Unpriced_cr { get; set; }
        
        public int Unpriced_trailer_clmhdr1_cnt { get; set; }        
        public int Unpriced_trailer_clmhdr2_cnt { get; set; }        
        public int Unpriced_trailer_itm_cnt { get; set; }        
        public int Unpriced_trailer_pat_addr_cnt { get; set; }        
        //public string Filler1 { get; set; }        
        //public string Filler2 { get; set; }

        public object Object_Reference { get; set; }
    }

    // HEH

    public class Unpriced_clmhdr1_rec { 

    // 10  unpriced-clmhdr-health-nbr           pic x(10).
    public string Unpriced_clmhdr_health_nbr { get; set; }


    //        10  unpriced-clmhdr-version-cd           pic x(2). 
    public string Unpriced_clmhdr_version_cd { get; set; }
    //        10  unpriced-clmhdr-birth-date. 
    public string Unpriced_clmhdr_birth_date_grp { get; set; }
    //            15  unpriced-clmhdr-birth-date-yy    pic 9(4). 
    public int Unpriced_clmhdr_birth_date_yy { get; set; }
    //            15  unpriced-clmhdr-birth-date-mm    pic 99. 
    public int Unpriced_clmhdr_birth_date_mm { get; set; }
    //            15  unpriced-clmhdr-birth-date-dd    pic 99. 
    public int Unpriced_clmhdr_birth_date_dd { get; set; }
    //        10  unpriced-clmhdr-claim. 
    public string Unpriced_clmhdr_claim_grp { get; set; }
    //            15  unpriced-clmhdr-doc-nbr          pic x(3). 
    public string Unpriced_clmhdr_doc_nbr { get; set; }
    //            15  unpriced-clmhdr-wk               pic xx. 
    public string Unpriced_clmhdr_wk { get; set; }
    //            15  unpriced-clmhdr-day              pic x. 
    public string Unpriced_clmhdr_day { get; set; }
    //            15  unpriced-clmhdr-claim-nbr        pic xx. 
    public string Unpriced_clmhdr_claim_nbr { get; set; }
    //        10  unpriced-clmhdr-pay-pgm              pic x(3). 
    public string Unpriced_clmhdr_pay_pgm { get; set; }
    //        10  unpriced-clmhdr-payee                pic x. 
    public string Unpriced_clmhdr_payee { get; set; }
    //        10  unpriced-clmhdr-ref-doc-nbr          pic 9(6). 
    public int Unpriced_clmhdr_ref_doc_nbr { get; set; }
    //        10  unpriced-clmhdr-hosp-nbr             pic x(4). 
    public string Unpriced_clmhdr_hosp_nbr { get; set; }
    //        10  unpriced-clmhdr-admit-date. 
    public string Unpriced_clmhdr_admit_date_grp { get; set; }
    //            15  unpriced-clmhdr-admit-date-yy    pic x(4). 
    public string Unpriced_clmhdr_admit_date_yy { get; set; }
    //            15  unpriced-clmhdr-admit-date-mm    pic xx. 
    public string Unpriced_clmhdr_admit_date_mm { get; set; }
    //            15  unpriced-clmhdr-admit-date-dd    pic xx. 
    public string Unpriced_clmhdr_admit_date_dd { get; set; }
    //        10  unpriced-clmhdr-ref-lab-no           pic 9(4). 
    public int Unpriced_clmhdr_ref_lab_no { get; set; }
    //        10  unpriced-clmhdr-man-review           pic x. 
    public string Unpriced_clmhdr_man_review { get; set; }
    // 10  unpriced-moh-location-code  pic 9(4).
    public int Unpriced_moh_location_code { get; set; }
    // 10  unpriced-reserved-for-ooc  pic x(11).
    public string Unpriced_reserved_for_ooc { get; set; }
    // 10  unpriced-confidentiality-flag        pic x(1).
    public string Unpriced_confidentiality_flag { get; set; }
    // 10  unpriced-clmhdr-agent-cd             pic x.
    public string Unpriced_clmhdr_agent_cd { get; set; }
    // 10  unpriced-clmhdr-i-o-ind              pic x.
    public string Unpriced_clmhdr_i_o_ind { get; set; }
    // 10  unpriced-clmhdr-hc-prov-cd           pic x(2).
    public string Unpriced_clmhdr_hc_prov_cd { get; set; }
    // 10  unpriced-clmhdr-hc-ohip-nbr          pic x(12).
    public string Unpriced_clmhdr_hc_ohip_nbr { get; set; }
    // 10 unpriced-clmhdr-pat-acronym          pic x(9).
    public string Unpriced_clmhdr_pat_acronym { get; set; }
    // 10  unpriced-bathdr-clinic-1-2           pic 99.
    public int Unpriced_bathdr_clinic_1_2 { get; set; }
    // 10  unpriced-clmhdr-pat-surname2         pic x(30).
    public string Unpriced_clmhdr_pat_surname2 { get; set; }
    // 10  unpriced-clmhdr-given-name2          pic x(30).
    public string Unpriced_clmhdr_given_name2 { get; set; }

        // 10  filler                              pic x(06).
     public string Filler { get; set; }
    }

    public class Unpriced_clmhdr2_rec  // HER
    {
        //        10  unpriced-clmhdr-pat-ohip-nbr         pic x(12). 
        public string Unpriced_clmhdr_pat_ohip_nbr { get; set; }
        //        10  unpriced-clmhdr-pat-surname_2          pic x(9). 
        public string Unpriced_clmhdr_pat_surname_2 { get; set; }
        //        10  unpriced-clmhdr-given-name_2           pic x(5). 
        public string Unpriced_clmhdr_given_name_2 { get; set; }
        //        10  unpriced-clmhdr-sex_2                  pic 9. 
        public int Unpriced_clmhdr_sex { get; set; }

        // 10  unpriced-clmhdr-pat-surname          pic x(9).
        public string Unpriced_clmhdr_pat_surname { get; set; }

        // 10  unpriced-clmhdr-given-name           pic x(5).
        public string Unpriced_clmhdr_given_name { get; set; }

        // 10  unpriced-clmhdr-prov-cd              pic x(2).
        public string Unpriced_clmhdr_prov_cd { get; set; }

        // 10  filler                              pic x(30).
        public string Filler { get; set; }

        // 10  unpriced-confidentiality-flag        pic x(1).
        public string Unpriced_confidentiality_flag { get; set; }

        // 10  unpriced-clmhdr-loc-code             pic x(4).
        public string Unpriced_clmhdr_loc_code { get; set; }

        // 10  unpriced-clmhdr-agent-cd             pic x.
        public string Unpriced_clmhdr_agent_cd { get; set; }

        // 10  unpriced-clmhdr-i-o-ind              pic x.
        public  string Unpriced_clmhdr_i_o_ind { get; set; }

        // 15 unpriced-clmhdr-phone-no-1-7     pic x(07).
        public string Unpriced_clmhdr_phone_no_1_7 { get; set; }

        // 15 unpriced-clmhdr-phone-no-8-10    pic x(03).
        public string Unpriced_clmhdr_phone_no_8_10 { get; set; }

        // 15 unpriced-clmhdr-phone-no-1-3     pic x(03).
        public string Unpriced_clmhdr_phone_no_1_3 { get; set; }

        // 15 unpriced-clmhdr-phone-no-4-10    pic x(07).
        public string Unpriced_clmhdr_phone_no_4_10 { get; set; }

    }

    public class Unpriced_item_rec
    {

        //        10  unpriced-clmhdr-prov-cd              pic x(2). 
        public string Unpriced_clmhdr_prov_cd_grp { get; set; }
        // 15  unpriced-itm1-oma-svc-code       pic x(4).
        public string Unpriced_itm1_oma_svc_code { get; set; }
        // 15  unpriced-itm1-oma-svc-suff       pic x.
        public string Unpriced_itm1_oma_svc_suff { get; set; }
        //        10  filler                              pic x(30). 
        public string Filler1 { get; set; }
        //10  unpriced-itm1-oma-amt-billed         pic 9(4)v99.
        public decimal Unpriced_itm1_oma_amt_billed { get; set; }
        // 10  unpriced-itm1-nbr-serv               pic 99.
        public int Unpriced_itm1_nbr_serv { get; set; }
        // 10  unpriced-itm1-svc-date.
        public string Unpriced_itm1_svc_date_grp { get; set; }
        // 15  unpriced-itm1-svc-date-yy        pic 9(4).
        public int Unpriced_itm1_svc_date_yy { get; set; }
        // 15  unpriced-itm1-svc-date-mm        pic 99.
        public int Unpriced_itm1_svc_date_mm { get; set; }
        // 15  unpriced-itm1-svc-date-dd        pic 99.
        public int Unpriced_itm1_svc_date_dd { get; set; }
        // 10  unpriced-itm1-diag-cd                pic x(3).
        public string Unpriced_itm1_diag_cd { get; set; }
        // 10  filler-diag                         pic x(1).
        public string Filler_diag { get; set; }
        // 10  unpriced-reserved-for-ooc           pic x(09).
        public string Unpriced_reserved_for_ooc { get; set; }
        // 10  filler                              pic x(11).
        public string Filler2 { get; set; }
        // 10  unpriced-itm2-oma-svc-cd.
        public string Unpriced_itm2_oma_svc_cd_grp { get; set; }
        // 15  unpriced-itm2-oma-svc-code       pic x(4).
        public string Unpriced_itm2_oma_svc_code { get; set; }
        // 15  unpriced-itm2-oma-svc-suff       pic x.
        public string Unpriced_itm2_oma_svc_suff { get; set; }
        // 10  filler                              pic x(2).
        public string Filler3 { get; set; }
        // 10  unpriced-itm2-oma-amt-billed         pic 9(4)v99.
        public decimal Unpriced_itm2_oma_amt_billed { get; set; }
        // 10  unpriced-itm2-nbr-serv               pic 99.
        public int Unpriced_itm2_nbr_serv { get; set; }
        // 10  unpriced-itm2-svc-date.
        public string Unpriced_itm2_svc_date_grp { get; set; }
        // 15  unpriced-itm2-svc-date-yy        pic 9(4).
        public int Unpriced_itm2_svc_date_yy { get; set; }
        // 15  unpriced-itm2-svc-date-mm pic 99.
        public int Unpriced_itm2_svc_date_mm { get; set; }
        // 15  unpriced-itm2-svc-date-dd        pic 99.
        public int Unpriced_itm2_svc_date_dd { get; set; }
        // 10  unpriced-itm2-diag-cd                pic x(3).
        public string Unpriced_itm2_diag_cd { get; set; }
        // 10  filler3                               pic x(6).
        public string Filler4 { get; set; }
        // 10  unpriced-itm1-override-price         pic x(1).
        public string Unpriced_itm1_override_price { get; set; }
        // 10  unpriced-itm1-bilateral              pic x(1).
        public string Unpriced_itm1_bilateral { get; set; }
        // 10  unpriced-itm2-override-price         pic x(1).
        public string Unpriced_itm2_override_price { get; set; }
        // 10  unpriced-itm2-bilateral              pic x(1).
        public string Unpriced_itm2_bilateral { get; set; }
        // 10  unpriced-itm3-override-price         pic x(1).
        public string Unpriced_itm3_override_price { get; set; }
        // 10  unpriced-itm4-bilateral              pic x(1).
        public string Unpriced_itm4_bilateral { get; set; }
        // 10  filler                               pic x(112).
        public string Filler5 { get; set; }
    }

    public class Unpriced_pat_addr_rec   // HEA/ HEP
    {
        // 10  unpriced-pat-addr-1                  pic x(25).
        public string Unpriced_pat_addr_1 { get; set; }
        // 10  unpriced-pat-addr-2                  pic x(25).
        public string Unpriced_pat_addr_2 { get; set; }
        // 10  unpriced-pat-addr-3                  pic x(18).
        public string Unpriced_pat_addr_3 { get; set; }
        // 10  unpriced-clmhdr-hc-prov-cd-2         pic x(2).
        public string Unpriced_clmhdr_hc_prov_cd_2 { get; set; }
        // 10  unpriced-pat-addr-post-cd           pic x(9).
        public string Unpriced_pat_addr_post_cd { get; set; }
        // 10  unpriced-clmhdr-pat-surname.
        public string Unpriced_clmhdr_pat_surname_grp { get; set; }
        // 15  unpriced-clmhdr-surname-1-6   pic x(06).
        public string Unpriced_clmhdr_surname_1_6 { get; set; }
        // 15  unpriced-clmhdr-surname-7-30  pic x(24).
        public string Unpriced_clmhdr_surname_7_30 { get; set; }
        // 10  unpriced-clmhdr-given-name.
        public string Unpriced_clmhdr_given_name_grp { get; set; }
        // 15  unpriced-clmhdr-given-name1-3   pic x(03).
        public string Unpriced_clmhdr_given_name1_3 { get; set; }
        // 15  unpriced-clmhdr-given-name4-30  pic x(27).
        public string Unpriced_clmhdr_given_name4_30 { get; set; }
        // 10  unpriced-clmhdr-sex                  pic x.
        public string Unpriced_clmhdr_sex { get; set; }
        // 10  unpriced-clmhdr-phone-no             pic x(20) .
        public string Unpriced_clmhdr_phone_no { get; set; }
        // 10  unpriced-clmhdr-birth-date2.
        public string Unpriced_clmhdr_birth_date2_grp { get; set; }
        //15  unpriced-clmhdr-birth-date-yy2   pic 9(4).
        public int Unpriced_clmhdr_birth_date_yy2 { get; set; }
        // 15  unpriced-clmhdr-birth-date-mm2   pic 99.
        public int Unpriced_clmhdr_birth_date_mm2 { get; set; }
        // 15  unpriced-clmhdr-birth-date-dd2   pic 99.
        public int Unpriced_clmhdr_birth_date_dd2 { get; set; }
        // 10  filler                              pic x(05).
        public string Filler { get; set; }

        // 15  unpriced-pat-addr-post-cd1       pic x.
        public string Unpriced_pat_addr_post_cd1 { get; set; }

        // 15  unpriced-pat-addr-post-cd2       pic 9.
        public int Unpriced_pat_addr_post_cd2 { get; set; }

        // 15  unpriced-pat-addr-post-cd3       pic x.
        public string Unpriced_pat_addr_post_cd3{ get; set; }

        // 15  unpriced-pat-addr-post-cd4       pic 9.
        public int Unpriced_pat_addr_post_cd4 { get; set; }

        // 15  unpriced-pat-addr-post-cd5       pic x.
        public string Unpriced_pat_addr_post_cd5 { get; set; }

        // 15  unpriced-pat-addr-post-cd6       pic 9.
        public int Unpriced_pat_addr_post_cd6 { get; set; }
    }

    public class Unpriced_trailer_rec   // HEE
    {
        //10  unpriced-trailer-clmhdr1-cnt pic 9(4).
        public int Unpriced_trailer_clmhdr1_cnt { get; set; }
        // 10  unpriced-trailer-clmhdr2-cnt         pic 9(4).
        public int Unpriced_trailer_clmhdr2_cnt { get; set; }
        // 10  unpriced-trailer-itm-cnt             pic 9(5).
        public int Unpriced_trailer_itm_cnt { get; set; }
        // 10  unpriced-trailer-pat-addr-cnt        pic 9(4).
        public int Unpriced_trailer_pat_addr_cnt { get; set; }
        // 10  filler                              pic x(63).
        public string Filler1 { get; set; }
        //10  filler                              pic x(99).
        public string Filler2 { get; set; }
    }
    
}

   

