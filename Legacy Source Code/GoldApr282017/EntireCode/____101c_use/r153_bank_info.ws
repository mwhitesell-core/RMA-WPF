* file: r153_bank_info.ws  (cloned from r123_bank_info.ws)
* 2014/05/15 - MC1 - change ws-originator-nbr-clinic-mp to 0102117527



77   ws-nbr-settlement-accounts pic 99          value 4.


77   ws-settlement-account-1      pic x(12)       value "7701918     ".
77   ws-institution-id-1          pic 9(9)        value 001000562.  

77   ws-settlement-account-2      pic x(12)       value "1172611     ".
77   ws-institution-id-2          pic 9(9)        value 001000062.  

77   ws-settlement-account-3      pic x(12)       value "9594213     ".
77   ws-institution-id-3          pic 9(9)        value 001000062.

77   ws-settlement-account-4      pic x(12)       value "9079319     ".
77   ws-institution-id-4          pic 9(9)        value 001000062.



01   ws-settlement-account 	pic x(12).
01   ws-account-return		pic x(12).  
01   ws-institution-id. 
     05  ws-bank-nbr-id		pic 9(4).
     05  ws-bank-branch-id	pic 9(5).
01   ws-institution-return.  
     05  ws-bank-nbr-return     pic 9(4).
     05  ws-bank-branch-return 	pic 9(5).

77   ws-dest-data-centre        pic 9(5)        value 01020.  

77   ws-short-name              pic x(15)       value
                   "  R. M. A.    ".     
77   ws-long-name               pic x(30)       value
            " Regional Medical Associates  ".    

01   ws-originator-numbers.
     05  ws-originator-nbr-clinic-22  pic x(10)       value "0102024944".
     05  ws-originator-nbr-clinic-81  pic x(10)       value "0102006210".
     05  ws-originator-nbr-clinic-85  pic x(10)       value "0102018480".
* MC1
*    05  ws-originator-nbr-clinic-mp  pic x(10)       value "0102007764".
     05  ws-originator-nbr-clinic-mp  pic x(10)       value "0102117527".
* MC1 - end

01   ws-file-creation-nbr             pic 9(4)        value 1.
