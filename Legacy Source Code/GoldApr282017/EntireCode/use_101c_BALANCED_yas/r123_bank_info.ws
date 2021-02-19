* file: r123_bank_info.ws
* 2001/oct/21 B.E. added originator nbr for clinic 85
* 2003/01/22 - MC - now we have 2 companies
* 2007/11/14 - be - now we have 3 companies
* 2009/01/19 - MC - now we have 4 companies
* 2010/10/12 - MC - change bank number for company 3

*77   ws-nbr-settlement-accounts  pic 99          value 1.
*77   ws-settlement-account      pic x(12)       value "7701918     ".
*77   ws-institution-id          pic 9(9)        value 001000562.  

* 2009/01/19 - MC
*77   ws-nbr-settlement-accounts pic 99          value 3.
77   ws-nbr-settlement-accounts pic 99          value 4.
* 2009/01/19 - end


77   ws-settlement-account-1      pic x(12)       value "7701918     ".
77   ws-institution-id-1          pic 9(9)        value 001000562.  

77   ws-settlement-account-2      pic x(12)       value "1172611     ".
77   ws-institution-id-2          pic 9(9)        value 001000062.  

* 2010/10/12 - MC
*77   ws-settlement-account-3      pic x(12)       value "9276211     ".
77   ws-settlement-account-3      pic x(12)       value "9594213     ".
* 2010/10/12 - end
77   ws-institution-id-3          pic 9(9)        value 001000062.

* 2009/01/19 - MC  
77   ws-settlement-account-4      pic x(12)       value "9079319     ".
77   ws-institution-id-4          pic 9(9)        value 001000062.
* 2009/01/19 - end


*77   ws-account-return          pic x(12)       value "7701918". 
*77   ws-institution-return      pic 9(9)        value 001000562.


01   ws-settlement-account 	pic x(12).
01   ws-account-return		pic x(12).  
01   ws-institution-id. 
     05  ws-bank-nbr-id		pic 9(4).
     05  ws-bank-branch-id	pic 9(5).
01   ws-institution-return.  
     05  ws-bank-nbr-return     pic 9(4).
     05  ws-bank-branch-return 	pic 9(5).
* 2003/01/22 - end

77   ws-dest-data-centre        pic 9(5)        value 01020.  

77   ws-short-name              pic x(15)       value
                   "  R. M. A.    ".     
77   ws-long-name               pic x(30)       value
            " Regional Medical Associates  ".    

01   ws-originator-numbers.
     05  ws-originator-nbr-clinic-22  pic x(10)       value "0102024944".
     05  ws-originator-nbr-clinic-81  pic x(10)       value "0102006210".
     05  ws-originator-nbr-clinic-85  pic x(10)       value "0102018480".
     05  ws-originator-nbr-clinic-mp  pic x(10)       value "0102007764".

01   ws-file-creation-nbr             pic 9(4)        value 1.
