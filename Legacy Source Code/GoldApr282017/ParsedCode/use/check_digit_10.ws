01  ws-check-digit-nbrs-10.  
    05  ws-temp-10					pic 999.  
    05  ws-temp-1-10					pic 99.  
    05  ws-temp-2-10					pic 99.  
    05  ws-temp-2-10-r  redefines ws-temp-2-10.  
	10  ws-temp-2a-10				pic 9.  
	10  ws-temp-2b-10				pic 9.  
  
*	(digit #10 is the check digit using modulus 10)  
01  ws-check-nbr-10.  
    05  ws-chk-nbr-10					pic 9(10).  
    05  ws-chk-nbr-10-r redefines ws-chk-nbr-10.  
	10  ws-chk-nbr-1-10				pic 9.  
	10  ws-chk-nbr-2-10				pic 9.  
	10  ws-chk-nbr-3-10				pic 9.  
	10  ws-chk-nbr-4-10				pic 9.  
	10  ws-chk-nbr-5-10				pic 9.  
	10  ws-chk-nbr-6-10				pic 9.  
	10  ws-chk-nbr-7-10				pic 9.  
	10  ws-chk-nbr-8-10				pic 9.  
        10  ws-chk-nbr-9-10				pic 9.  
        10  ws-chk-nbr-10-10				pic 9.  
  
  
