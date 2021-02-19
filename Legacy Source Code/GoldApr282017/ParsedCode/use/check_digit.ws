01  ws-check-digit-nbrs. 
    05  ws-temp					pic 999. 
    05  ws-temp-1				pic 99. 
    05  ws-temp-2				pic 99. 
    05  ws-temp-2-r  redefines ws-temp-2. 
	10  ws-temp-2a				pic 9. 
	10  ws-temp-2b				pic 9. 
 
*	(digit #8 is the check digit using modulus 10) 
01  ws-check-nbr. 
    05  ws-chk-nbr				pic 9(8). 
    05  ws-chk-nbr-r redefines ws-chk-nbr. 
	10  ws-chk-nbr-1			pic 9. 
	10  ws-chk-nbr-2			pic 9. 
	10  ws-chk-nbr-3			pic 9. 
	10  ws-chk-nbr-4			pic 9. 
	10  ws-chk-nbr-5			pic 9. 
	10  ws-chk-nbr-6			pic 9. 
	10  ws-chk-nbr-7			pic 9. 
	10  ws-chk-nbr-8			pic 9. 
 
 
