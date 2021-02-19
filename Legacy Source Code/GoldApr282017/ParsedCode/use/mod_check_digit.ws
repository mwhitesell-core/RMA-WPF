01  ws-nbr-val. 
 
    05  ws-nbr-to-b-val			pic 9(8). 
    05  ws-nbr-to-b-val-r redefines ws-nbr-to-b-val. 
	10  ws-nbr-to-b-val-1-8 occurs 8 times 
					pic 9. 
    05  ws-sum-1-2-val. 
	10  ws-sum-1-2-val-r occurs 7 times. 
	    15  ws-sum-1-2-val-r1	pic 99. 
	    15  ws-sum-1-2-val-r1-r redefines ws-sum-1-2-val-r1. 
		20  ws-sum-1 		pic 9	occurs 2 times. 
    05  ws-sum-1-2-val-r-sep redefines ws-sum-1-2-val. 
	10  ws-sum-1-2 occurs 7 times	pic 99. 
 
01  ws-hc-nbr-val. 
 
    05  ws-hc-nbr-to-b-val			pic 9(10). 
    05  ws-hc-nbr-to-b-val-r redefines ws-hc-nbr-to-b-val. 
	10  ws-hc-nbr-to-b-val-1-10 occurs 10 times 
					pic 9. 
    05  ws-hc-sum-1-2-val. 
	10  ws-hc-sum-1-2-val-r occurs 9 times. 
	    15  ws-hc-sum-1-2-val-r1	pic 99. 
	    15  ws-hc-sum-1-2-val-r1-r redefines ws-hc-sum-1-2-val-r1. 
		20  ws-hc-sum-1 		pic 9	occurs 2 times. 
    05  ws-hc-sum-1-2-val-r-sep redefines ws-hc-sum-1-2-val. 
	10  ws-hc-sum-1-2 occurs 9 times	pic 99. 
