using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class Constants_mstr_rec_1
    {        	
	 //    05  const-rec-1-rec-nbr   pic 99. 
	 public  int Const_rec_1_rec_nbr { get; set;}
	 //    05  const-max-nbr-clinics   pic 99.             
	 public  int Const_max_nbr_clinics { get; set;}
	 //    05  const-clinic-data. 
	 public  string Const_clinic_data { get; set;}
	 // 10  const-clinic-data-r occurs  63  times. 
	 public  string[] Const_clinic_data_r { get; set;}
	 //     15  const-clinic-nbr-1-2  pic 99.      
	 public  int[] Const_clinic_nbr_1_2 { get; set;}
	 //     15  const-clinic-nbr  pic x(4).  
	 public  string[] Const_clinic_nbr { get; set;}
	 //    05  const-scr-data  redefines  const-clinic-data.                  
	 public  string Const_scr_data { get; set;}
	 // 10  const-clinic-1-2-nbr-1  pic 99.  
	 public  int Const_clinic_1_2_nbr_1 { get; set;}
	 // 10  const-clinic-nbr-1   pic x(4).  
	 public  string Const_clinic_nbr_1 { get; set;}
	 // 10  const-clinic-1-2-nbr-2  pic 99.  
	 public  int Const_clinic_1_2_nbr_2 { get; set;}
	 // 10  const-clinic-nbr-2   pic x(4).  
	 public  string Const_clinic_nbr_2 { get; set;}
	 // 10  const-clinic-1-2-nbr-3  pic 99.  
	 public  int Const_clinic_1_2_nbr_3 { get; set;}
	 // 10  const-clinic-nbr-3   pic x(4).  
	 public  string Const_clinic_nbr_3 { get; set;}
	 // 10  const-clinic-1-2-nbr-4  pic 99.  
	 public  int Const_clinic_1_2_nbr_4 { get; set;}
	 // 10  const-clinic-nbr-4   pic x(4).  
	 public  string Const_clinic_nbr_4 { get; set;}
	 // 10  const-clinic-1-2-nbr-5  pic 99.  
	 public  int Const_clinic_1_2_nbr_5 { get; set;}
	 // 10  const-clinic-nbr-5   pic x(4).  
	 public  string Const_clinic_nbr_5 { get; set;}
	 // 10  const-clinic-1-2-nbr-6  pic 99.  
	 public  int Const_clinic_1_2_nbr_6 { get; set;}
	 // 10  const-clinic-nbr-6   pic x(4).  
	 public  string Const_clinic_nbr_6 { get; set;}
	 // 10  const-clinic-1-2-nbr-7  pic 99.  
	 public  int Const_clinic_1_2_nbr_7 { get; set;}
	 // 10  const-clinic-nbr-7   pic x(4).  
	 public  string Const_clinic_nbr_7 { get; set;}
	 // 10  const-clinic-1-2-nbr-8  pic 99.  
	 public  int Const_clinic_1_2_nbr_8 { get; set;}
	 // 10  const-clinic-nbr-8   pic x(4).  
	 public  string Const_clinic_nbr_8 { get; set;}
	 // 10  const-clinic-1-2-nbr-9  pic 99.  
	 public  int Const_clinic_1_2_nbr_9 { get; set;}
	 // 10  const-clinic-nbr-9   pic x(4).  
	 public  string Const_clinic_nbr_9 { get; set;}
	 // 10  const-clinic-1-2-nbr-10  pic 99.  
	 public  int Const_clinic_1_2_nbr_10 { get; set;}
	 // 10  const-clinic-nbr-10   pic x(4).  
	 public  string Const_clinic_nbr_10 { get; set;}
	 // 10  const-clinic-1-2-nbr-11  pic 99.  
	 public  int Const_clinic_1_2_nbr_11 { get; set;}
	 // 10  const-clinic-nbr-11   pic x(4).  
	 public  string Const_clinic_nbr_11 { get; set;}
	 // 10  const-clinic-1-2-nbr-12  pic 99.  
	 public  int Const_clinic_1_2_nbr_12 { get; set;}
	 // 10  const-clinic-nbr-12   pic x(4).  
	 public  string Const_clinic_nbr_12 { get; set;}
	 // 10  const-clinic-1-2-nbr-13  pic 99.  
	 public  int Const_clinic_1_2_nbr_13 { get; set;}
	 // 10  const-clinic-nbr-13   pic x(4).  
	 public  string Const_clinic_nbr_13 { get; set;}
	 // 10  const-clinic-1-2-nbr-14  pic 99.  
	 public  int Const_clinic_1_2_nbr_14 { get; set;}
	 // 10  const-clinic-nbr-14   pic x(4).  
	 public  string Const_clinic_nbr_14 { get; set;}
	 // 10  const-clinic-1-2-nbr-15  pic 99.  
	 public  int Const_clinic_1_2_nbr_15 { get; set;}
	 // 10  const-clinic-nbr-15   pic x(4).  
	 public  string Const_clinic_nbr_15 { get; set;}
	 // 10  const-clinic-1-2-nbr-16  pic 99.  
	 public  int Const_clinic_1_2_nbr_16 { get; set;}
	 // 10  const-clinic-nbr-16   pic x(4).  
	 public  string Const_clinic_nbr_16 { get; set;}
	 // 10  const-clinic-1-2-nbr-17  pic 99.  
	 public  int Const_clinic_1_2_nbr_17 { get; set;}
	 // 10  const-clinic-nbr-17   pic x(4).  
	 public  string Const_clinic_nbr_17 { get; set;}
	 // 10  const-clinic-1-2-nbr-18  pic 99.  
	 public  int Const_clinic_1_2_nbr_18 { get; set;}
	 // 10  const-clinic-nbr-18   pic x(4).  
	 public  string Const_clinic_nbr_18 { get; set;}
	 // 10  const-clinic-1-2-nbr-19  pic 99.  
	 public  int Const_clinic_1_2_nbr_19 { get; set;}
	 // 10  const-clinic-nbr-19   pic x(4).  
	 public  string Const_clinic_nbr_19 { get; set;}
	 // 10  const-clinic-1-2-nbr-20  pic 99.  
	 public  int Const_clinic_1_2_nbr_20 { get; set;}
	 // 10  const-clinic-nbr-20   pic x(4).  
	 public  string Const_clinic_nbr_20 { get; set;}
	 // 10  const-clinic-1-2-nbr-21  pic 99.  
	 public  int Const_clinic_1_2_nbr_21 { get; set;}
	 // 10  const-clinic-nbr-21   pic x(4).  
	 public  string Const_clinic_nbr_21 { get; set;}
	 // 10  const-clinic-1-2-nbr-22  pic 99.  
	 public  int Const_clinic_1_2_nbr_22 { get; set;}
	 // 10  const-clinic-nbr-22   pic x(4).  
	 public  string Const_clinic_nbr_22 { get; set;}
	 // 10  const-clinic-1-2-nbr-23  pic 99.  
	 public  int Const_clinic_1_2_nbr_23 { get; set;}
	 // 10  const-clinic-nbr-23   pic x(4).  
	 public  string Const_clinic_nbr_23 { get; set;}
	 // 10  const-clinic-1-2-nbr-24  pic 99.  
	 public  int Const_clinic_1_2_nbr_24 { get; set;}
	 // 10  const-clinic-nbr-24   pic x(4).  
	 public  string Const_clinic_nbr_24 { get; set;}
	 // 10  const-clinic-1-2-nbr-25  pic 99.  
	 public  int Const_clinic_1_2_nbr_25 { get; set;}
	 // 10  const-clinic-nbr-25   pic x(4).  
	 public  string Const_clinic_nbr_25 { get; set;}
	 // 10  const-clinic-1-2-nbr-26  pic 99.  
	 public  int Const_clinic_1_2_nbr_26 { get; set;}
	 // 10  const-clinic-nbr-26   pic x(4).  
	 public  string Const_clinic_nbr_26 { get; set;}
	 // 10  const-clinic-1-2-nbr-27  pic 99.  
	 public  int Const_clinic_1_2_nbr_27 { get; set;}
	 // 10  const-clinic-nbr-27   pic x(4).  
	 public  string Const_clinic_nbr_27 { get; set;}
	 // 10  const-clinic-1-2-nbr-28  pic 99.  
	 public  int Const_clinic_1_2_nbr_28 { get; set;}
	 // 10  const-clinic-nbr-28   pic x(4).  
	 public  string Const_clinic_nbr_28 { get; set;}
	 // 10  const-clinic-1-2-nbr-29  pic 99.  
	 public  int Const_clinic_1_2_nbr_29 { get; set;}
	 // 10  const-clinic-nbr-29   pic x(4).  
	 public  string Const_clinic_nbr_29 { get; set;}
	 // 10  const-clinic-1-2-nbr-30  pic 99.  
	 public  int Const_clinic_1_2_nbr_30 { get; set;}
	 // 10  const-clinic-nbr-30   pic x(4).  
	 public  string Const_clinic_nbr_30 { get; set;}
	 // 10  const-clinic-1-2-nbr-31  pic 99.  
	 public  int Const_clinic_1_2_nbr_31 { get; set;}
	 // 10  const-clinic-nbr-31   pic x(4).  
	 public  string Const_clinic_nbr_31 { get; set;}
	 // 10  const-clinic-1-2-nbr-32  pic 99.  
	 public  int Const_clinic_1_2_nbr_32 { get; set;}
	 // 10  const-clinic-nbr-32   pic x(4).  
	 public  string Const_clinic_nbr_32 { get; set;}
	 // 10  const-clinic-1-2-nbr-33  pic 99.  
	 public  int Const_clinic_1_2_nbr_33 { get; set;}
	 // 10  const-clinic-nbr-33   pic x(4).  
	 public  string Const_clinic_nbr_33 { get; set;}
	 // 10  const-clinic-1-2-nbr-34  pic 99.  
	 public  int Const_clinic_1_2_nbr_34 { get; set;}
	 // 10  const-clinic-nbr-34   pic x(4).  
	 public  string Const_clinic_nbr_34 { get; set;}
	 // 10  const-clinic-1-2-nbr-35  pic 99.  
	 public  int Const_clinic_1_2_nbr_35 { get; set;}
	 // 10  const-clinic-nbr-35   pic x(4).  
	 public  string Const_clinic_nbr_35 { get; set;}
	 // 10  const-clinic-1-2-nbr-36  pic 99.  
	 public  int Const_clinic_1_2_nbr_36 { get; set;}
	 // 10  const-clinic-nbr-36   pic x(4).  
	 public  string Const_clinic_nbr_36 { get; set;}
	 // 10  const-clinic-1-2-nbr-37  pic 99.  
	 public  int Const_clinic_1_2_nbr_37 { get; set;}
	 // 10  const-clinic-nbr-37   pic x(4).  
	 public  string Const_clinic_nbr_37 { get; set;}
	 // 10  const-clinic-1-2-nbr-38  pic 99.  
	 public  int Const_clinic_1_2_nbr_38 { get; set;}
	 // 10  const-clinic-nbr-38   pic x(4).  
	 public  string Const_clinic_nbr_38 { get; set;}
	 // 10  const-clinic-1-2-nbr-39  pic 99.  
	 public  int Const_clinic_1_2_nbr_39 { get; set;}
	 // 10  const-clinic-nbr-39   pic x(4).  
	 public  string Const_clinic_nbr_39 { get; set;}
	 // 10  const-clinic-1-2-nbr-40  pic 99.  
	 public  int Const_clinic_1_2_nbr_40 { get; set;}
	 // 10  const-clinic-nbr-40   pic x(4).  
	 public  string Const_clinic_nbr_40 { get; set;}
	 // 10  const-clinic-1-2-nbr-41  pic 99.  
	 public  int Const_clinic_1_2_nbr_41 { get; set;}
	 // 10  const-clinic-nbr-41   pic x(4).  
	 public  string Const_clinic_nbr_41 { get; set;}
	 // 10  const-clinic-1-2-nbr-42  pic 99.  
	 public  int Const_clinic_1_2_nbr_42 { get; set;}
	 // 10  const-clinic-nbr-42   pic x(4).  
	 public  string Const_clinic_nbr_42 { get; set;}
	 // 10  const-clinic-1-2-nbr-43  pic 99.  
	 public  int Const_clinic_1_2_nbr_43 { get; set;}
	 // 10  const-clinic-nbr-43   pic x(4).  
	 public  string Const_clinic_nbr_43 { get; set;}
	 // 10  const-clinic-1-2-nbr-44  pic 99.  
	 public  int Const_clinic_1_2_nbr_44 { get; set;}
	 // 10  const-clinic-nbr-44   pic x(4).  
	 public  string Const_clinic_nbr_44 { get; set;}
	 // 10  const-clinic-1-2-nbr-45  pic 99.  
	 public  int Const_clinic_1_2_nbr_45 { get; set;}
	 // 10  const-clinic-nbr-45   pic x(4).  
	 public  string Const_clinic_nbr_45 { get; set;}
	 // 10  const-clinic-1-2-nbr-46  pic 99.  
	 public  int Const_clinic_1_2_nbr_46 { get; set;}
	 // 10  const-clinic-nbr-46   pic x(4).  
	 public  string Const_clinic_nbr_46 { get; set;}
	 // 10  const-clinic-1-2-nbr-47  pic 99.  
	 public  int Const_clinic_1_2_nbr_47 { get; set;}
	 // 10  const-clinic-nbr-47   pic x(4).  
	 public  string Const_clinic_nbr_47 { get; set;}
	 // 10  const-clinic-1-2-nbr-48  pic 99.  
	 public  int Const_clinic_1_2_nbr_48 { get; set;}
	 // 10  const-clinic-nbr-48   pic x(4).  
	 public  string Const_clinic_nbr_48 { get; set;}
	 // 10  const-clinic-1-2-nbr-49  pic 99.  
	 public  int Const_clinic_1_2_nbr_49 { get; set;}
	 // 10  const-clinic-nbr-49   pic x(4).  
	 public  string Const_clinic_nbr_49 { get; set;}
	 // 10  const-clinic-1-2-nbr-50  pic 99.  
	 public  int Const_clinic_1_2_nbr_50 { get; set;}
	 // 10  const-clinic-nbr-50   pic x(4).  
	 public  string Const_clinic_nbr_50 { get; set;}
	 // 10  const-clinic-1-2-nbr-51  pic 99.  
	 public  int Const_clinic_1_2_nbr_51 { get; set;}
	 // 10  const-clinic-nbr-51   pic x(4).  
	 public  string Const_clinic_nbr_51 { get; set;}
	 // 10  const-clinic-1-2-nbr-52  pic 99.  
	 public  int Const_clinic_1_2_nbr_52 { get; set;}
	 // 10  const-clinic-nbr-52   pic x(4).  
	 public  string Const_clinic_nbr_52 { get; set;}
	 // 10  const-clinic-1-2-nbr-53  pic 99.  
	 public  int Const_clinic_1_2_nbr_53 { get; set;}
	 // 10  const-clinic-nbr-53   pic x(4).  
	 public  string Const_clinic_nbr_53 { get; set;}
	 // 10  const-clinic-1-2-nbr-54  pic 99.  
	 public  int Const_clinic_1_2_nbr_54 { get; set;}
	 // 10  const-clinic-nbr-54   pic x(4).  
	 public  string Const_clinic_nbr_54 { get; set;}
	 // 10  const-clinic-1-2-nbr-55  pic 99.  
	 public  int Const_clinic_1_2_nbr_55 { get; set;}
	 // 10  const-clinic-nbr-55   pic x(4).  
	 public  string Const_clinic_nbr_55 { get; set;}
	 // 10  const-clinic-1-2-nbr-56  pic 99.  
	 public  int Const_clinic_1_2_nbr_56 { get; set;}
	 // 10  const-clinic-nbr-56   pic x(4).  
	 public  string Const_clinic_nbr_56 { get; set;}
	 // 10  const-clinic-1-2-nbr-57  pic 99.  
	 public  int Const_clinic_1_2_nbr_57 { get; set;}
	 // 10  const-clinic-nbr-57   pic x(4).  
	 public  string Const_clinic_nbr_57 { get; set;}
	 // 10  const-clinic-1-2-nbr-58  pic 99.  
	 public  int Const_clinic_1_2_nbr_58 { get; set;}
	 // 10  const-clinic-nbr-58   pic x(4).  
	 public  string Const_clinic_nbr_58 { get; set;}
	 // 10  const-clinic-1-2-nbr-59  pic 99.  
	 public  int Const_clinic_1_2_nbr_59 { get; set;}
	 // 10  const-clinic-nbr-59   pic x(4).  
	 public  string Const_clinic_nbr_59 { get; set;}
	 // 10  const-clinic-1-2-nbr-60  pic 99.  
	 public  int Const_clinic_1_2_nbr_60 { get; set;}
	 // 10  const-clinic-nbr-60   pic x(4).  
	 public  string Const_clinic_nbr_60 { get; set;}
	 // 10  const-clinic-1-2-nbr-61  pic 99.  
	 public  int Const_clinic_1_2_nbr_61 { get; set;}
	 // 10  const-clinic-nbr-61   pic x(4).  
	 public  string Const_clinic_nbr_61 { get; set;}
	 // 10  const-clinic-1-2-nbr-62  pic 99.  
	 public  int Const_clinic_1_2_nbr_62 { get; set;}
	 // 10  const-clinic-nbr-62   pic x(4).  
	 public  string Const_clinic_nbr_62 { get; set;}
	 // 10  const-clinic-1-2-nbr-63  pic 99.  
	 public  int Const_clinic_1_2_nbr_63 { get; set;}
	 // 10  const-clinic-nbr-63   pic x(4).  
	 public  string Const_clinic_nbr_63 { get; set;}
	 //    05  filler     pic x(2).  
	 public  string Filler { get; set;}

}
}
