* 98/dec/01 D.B.	- y2k conversion
* 99/jan/13 B.E.	- changed sys-y1/y2 to y1 thru y4
*			- added 'default-century-...' and century-date variables

01 century-year					pic 9(4).
01 century-date					pic 9(8).
01 default-century-cc				pic 9(2) value 19.
01 default-century-cccc				pic 9(4) value 1900.

01  sys-date. 
* y2k    05  sys-date-long				pic x(6).    
    05  sys-date-long				pic x(8).    
    05  sys-date-long-r  redefines  sys-date-long. 
* y2k	10  sys-yy				pic 99. 
	10  sys-yy				pic 9999. 
	10  sys-yy-alpha  redefines  sys-yy. 
* y2k	    15  sys-y1				pic 9. 
* y2k	    15  sys-y2				pic 9. 
	    15  sys-y1				pic 9. 
	    15  sys-y2				pic 9. 
	    15  sys-y3				pic 9. 
	    15  sys-y4				pic 9. 
 	10  sys-mm				pic 99. 
	10  sys-dd				pic 99. 
* remove after y2k upgrade of dgux
01  sys-date-numeric redefines sys-date 	pic 9(8).
01  sys-date-y2kfix  redefines sys-date.
    05 sys-date-left				pic x(6).
    05 filler					pic x(2).
01  sys-date-y2kfixed redefines sys-date.
    05 sys-date-blank				pic x(2).
    05 sys-date-right				pic x(6).
01  sys-date-temp 				pic x(8).

01  run-date. 
* y2k    05  run-yy					pic 99. 
    05  run-yy					pic 9999. 
    05  filler					pic x	value "/". 
    05  run-mm					pic 99. 
    05  filler					pic x	value "/". 
    05  run-dd					pic 99. 
 
01  sys-time. 
    05  sys-hrs					pic 99. 
    05  sys-min					pic 99. 
    05  sys-sec					pic 99. 
    05  sys-hdr					pic 99. 
 
01  run-time. 
    05  run-hrs					pic 99. 
    05  filler					pic x	value ":". 
    05  run-min					pic 99. 
    05  filler					pic x	value ":". 
    05  run-sec					pic 99. 
