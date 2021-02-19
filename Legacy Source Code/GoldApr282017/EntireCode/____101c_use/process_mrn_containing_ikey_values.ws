* filename: process_mrn_containing_ikey_values.ws
* used by process_mrn_containing_ikey_values.rtn code
* 2015/Oct/28 	MC1 - add redefinition for chart nbr 4 check


01  x-key-pat-mstr.
    05  x-key-pat-mstr-dtl.
        10  x-pat-i-key                   pic x.
        10  x-pat-con-nbr                 pic 99.
        10  x-pat-i-nbr                   pic 9(12).
        10  x-filler                      pic x.
01  x-key-pat-mstr-r redefines x-key-pat-mstr.
    05  filler                           pic x(4).
    05  x-key-pat-mstr-test.
        10  x-ikey-1-digit               pic x.
* MC1
*       10  x-ikey-2-11-digits           pic x(10).
        10  x-ikey-2-11-digits.         
	    15  x-ikey-2-digit		 pic x.
	    15  x-ikey-3-11-digits	 pic x(9).
* MC1 - end
    05  filler                           pic x.

* MC1
01   x-pat-chart-nbr-4.
     05  x-pat-chart4-1-digit		pic x.
     05  x-pat-chart4-9-digits		pic x(9).
* MC1 - end
