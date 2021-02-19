using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    //copy "f090_const_mstr_rec_3.ws". 
    public class Constants_Mstr_Rec_3
    {
        //05  const-rec-3-rec-nbr pic 99. 
        public int const_rec_3_rec_nbr { get; set; }

        //05  const-percentages-misc-curr.
        public decimal[] const_percentages_misc_curr { get; set; }
        //10  const-misc-curr occurs 9 times pic 9v9999.
        public decimal[] const_misc_curr_child { get; set; }
        //05  const-percentages-misc-curr-r redefines const-percentages-misc-curr.
        public decimal[] const_percentages_misc_curr_r { get; set; }
        //10  const-misc-1-curr pic 9v9999.
        public decimal const_misc_1_curr_child { get; set; }
        //10  const-misc-2-curr pic 9v9999.
        public decimal const_misc_2_curr_child { get; set; }
        //10  const-misc-3-curr pic 9v9999.
        public decimal const_misc_3_curr_child { get; set; }
        //10  const-misc-4-curr pic 9v9999.
        public decimal const_misc_4_curr_child { get; set; }
        //10  const-misc-5-curr pic 9v9999.
        public decimal const_misc_5_curr_child { get; set; }
        //10  const-misc-6-curr pic 9v9999.
        public decimal const_misc_6_curr_child { get; set; }
        //10  const-misc-7-curr pic 9v9999.
        public decimal const_misc_7_curr_child { get; set; }
        //10  const-misc-8-curr pic 9v9999.
        public decimal const_misc_8_curr_child { get; set; }
        //10  const-misc-9-curr pic 9v9999.
        public decimal const_misc_9_curr_child { get; set; }

        //05  const-percentages-misc-prev.
        public decimal[] const_percentages_misc_prev { get; set; }
        //10  const-misc-prev occurs 9 times pic 9v9999.
        public decimal[] const_misc_prev_child { get; set; }

        //05  const-percentages-misc-prev-r redefines const-percentages-misc-prev.
        public decimal[] const_percentages_misc_prev_r_grp { get; set; }
        //10  const-misc-1-prev pic 9v9999.
        public decimal const_misc_1_prev_child { get; set; }
        //10  const-misc-2-prev pic 9v9999.
        public decimal const_misc_2_prev_child { get; set; }
        //10  const-misc-3-prev pic 9v9999.
        public decimal const_misc_3_prev_child { get; set; }
        //10  const-misc-4-prev pic 9v9999.
        public decimal const_misc_4_prev_child { get; set; }
        //10  const-misc-5-prev pic 9v9999.
        public decimal const_misc_5_prev_child { get; set; }
        //10  const-misc-6-prev pic 9v9999.
        public decimal const_misc_6_prev_child { get; set; }
        //10  const-misc-7-prev pic 9v9999.
        public decimal const_misc_7_prev_child { get; set; }
        //10  const-misc-8-prev pic 9v9999.
        public decimal const_misc_8_prev_child { get; set; }
        //10  const-misc-9-prev pic 9v9999.
        public decimal const_misc_9_prev_child { get; set; }
        //05  filler pic x(292). 
        public string filler { get; set; }
    }
}
