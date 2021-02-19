* 98/dec/01 D.B.	- y2k

01  constants-mstr-rec-2. 
* 
*	use subscripts    ss-yr-nbr    (curr = 1;prev = 2) 
*	              and ss-rate-type (ohip = 1;oma = 2) 
* 
    05  const-rec-2-rec-nbr			pic 99. 
    05  const-info.                             
	10  const-info-curr-prev occurs 2 times. 
   	    15  const-effective-date.                  
* y2k
*	        20  const-yy			pic 99. 
	        20  const-yy			pic 9(4).
	        20  const-mm	 		pic 99. 
	        20  const-dd 			pic 99. 
	    15  const-bilateral			pic 99v99. 
	    15  const-ic			pic 99v99. 
	    15  const-sr			pic 99v99. 
	    15  const-wcb			pic 999v9(5). 
	    15  const-ohip-oma-rates occurs 2 times. 
	        20  const-asst			pic 99v99. 
	        20  const-reg     		pic 99v99. 
	        20  const-cert    		pic 99v99. 
    05  const-info-r redefines const-info.                   
	10  const-info-curr-prev-r. 
	    15  const-effective-date-curr. 
* y2k
*	        20  const-yy-curr		pic 99. 
	        20  const-yy-curr		pic 9999. 
	        20  const-mm-curr		pic 99. 
	        20  const-dd-curr		pic 99. 
	    15  const-bilateral-curr		pic 99v99. 
	    15  const-ic-curr			pic 99v99. 
	    15  const-sr-curr			pic 99v99. 
	    15  const-wcb-curr			pic 999v9(5). 
	    15  const-ohip-oma-rates-curr. 
	        20  const-asst-h-curr		pic 99v99. 
	        20  const-reg-h-curr		pic 99v99. 
	        20  const-cert-h-curr		pic 99v99. 
	        20  const-asst-a-curr   	pic 99v99. 
	        20  const-reg-a-curr 	 	pic 99v99. 
 	        20  const-cert-a-curr		pic 99v99. 
	    15  const-effective-date-prev. 
* y2k	        20  const-yy-prev		pic 99. 
	        20  const-yy-prev		pic 9999. 
	        20  const-mm-prev		pic 99. 
	        20  const-dd-prev		pic 99. 
	    15  const-bilateral-prev		pic 99v99. 
	    15  const-ic-prev			pic 99v99. 
	    15  const-sr-prev			pic 99v99. 
	    15  const-wcb-prev			pic 999v9(5). 
	    15  const-ohip-oma-rates-prev. 
	        20  const-asst-h-prev		pic 99v99. 
	        20  const-reg-h-prev		pic 99v99. 
	        20  const-cert-h-prev		pic 99v99. 
	        20  const-asst-a-prev		pic 99v99. 
	        20  const-reg-a-prev	  	pic 99v99. 
	        20  const-cert-a-prev		pic 99v99. 
    05  const-max-nbr-rates			pic 99. 
    05  const-groups.                 
	10  const-group-rates occurs 19 times. 
	    15  const-section-group. 
		20  const-section		pic xx. 
		20  const-group			pic 99. 
	    15  const-rates-curr-prev occurs 2 times pic 99v99. 
    05  const-group-r redefines const-groups.               
	10  const-group-rates-r. 
	    15  const-sect-1			pic xx. 
	    15  const-group-1			pic 99. 
	    15  const-curr-1     		pic 99v99. 
	    15  const-prev-1     		pic 99v99. 
	    15  const-sect-2			pic xx. 
	    15  const-group-2			pic 99. 
	    15  const-curr-2     		pic 99v99. 
	    15  const-prev-2    		pic 99v99. 
	    15  const-sect-3			pic xx. 
	    15  const-group-3			pic 99. 
	    15  const-curr-3     		pic 99v99. 
	    15  const-prev-3     	 	pic 99v99. 
	    15  const-sect-4			pic xx. 
	    15  const-group-4			pic 99. 
	    15  const-curr-4     		pic 99v99. 
	    15  const-prev-4     		pic 99v99. 
	    15  const-sect-5			pic xx. 
	    15  const-group-5			pic 99. 
	    15  const-curr-5     		pic 99v99. 
	    15  const-prev-5     		pic 99v99. 
	    15  const-sect-6			pic xx. 
	    15  const-group-6			pic 99. 
	    15  const-curr-6     		pic 99v99. 
	    15  const-prev-6     		pic 99v99. 
	    15  const-sect-7			pic xx. 
	    15  const-group-7			pic 99. 
	    15  const-curr-7     		pic 99v99. 
	    15  const-prev-7     		pic 99v99. 
	    15  const-sect-8			pic xx. 
	    15  const-group-8			pic 99. 
	    15  const-curr-8     	 	pic 99v99. 
	    15  const-prev-8    		pic 99v99. 
	    15  const-sect-9			pic xx. 
	    15  const-group-9			pic 99. 
	    15  const-curr-9   			pic 99v99. 
	    15  const-prev-9     		pic 99v99. 
	    15  const-sect-10			pic xx. 
	    15  const-group-10			pic 99. 
	    15  const-curr-10  			pic 99v99. 
	    15  const-prev-10     		pic 99v99. 
	    15  const-sect-11			pic xx. 
	    15  const-group-11			pic 99. 
	    15  const-curr-11     		pic 99v99. 
	    15  const-prev-11     		pic 99v99. 
	    15  const-sect-12			pic xx. 
	    15  const-group-12			pic 99. 
	    15  const-curr-12     		pic 99v99. 
	    15  const-prev-12     		pic 99v99. 
	    15  const-sect-13			pic xx. 
	    15  const-group-13			pic 99. 
	    15  const-curr-13     		pic 99v99. 
	    15  const-prev-13     		pic 99v99. 
	    15  const-sect-14			pic xx. 
	    15  const-group-14			pic 99. 
	    15  const-curr-14     		pic 99v99. 
	    15  const-prev-14    		pic 99v99. 
	    15  const-sect-15			pic xx. 
	    15  const-group-15			pic 99. 
	    15  const-curr-15    		pic 99v99. 
	    15  const-prev-15     		pic 99v99. 
	    15  const-sect-16			pic xx. 
	    15  const-group-16			pic 99. 
	    15  const-curr-16     		pic 99v99. 
 	    15  const-prev-16     		pic 99v99. 
	    15  const-sect-17			pic xx. 
	    15  const-group-17			pic 99. 
	    15  const-curr-17     		pic 99v99. 
	    15  const-prev-17     		pic 99v99. 
	    15  const-sect-18			pic xx. 
	    15  const-group-18			pic 99. 
	    15  const-curr-18     		pic 99v99. 
	    15  const-prev-18     		pic 99v99. 
	    15  const-sect-19			pic xx. 
	    15  const-group-19			pic 99. 
	    15  const-curr-19     		pic 99v99. 
	    15  const-prev-19     		pic 99v99. 
* (y2k)
*   05  filler					pic x(47). 
    05  filler					pic x(41). 
