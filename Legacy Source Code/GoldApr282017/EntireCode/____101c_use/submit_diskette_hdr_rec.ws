01  header-rec.
    05  hdr-ohip-nbr				pic 9(8).
    05  hdr-surname	 			pic x(9).
    05  hdr-first-name				pic x(5).
* y2k    05  hdr-birth-date				pic 9(4).
    05  hdr-birth-date				pic 9(6).
    05  hdr-sex 	      			pic x.
    05  hdr-accounting-nbr			pic x(8).
    05  hdr-refer-pract-nbr			pic 9(6).
    05  hdr-hosp-nbr	 	      		pic x(4).
    05  hdr-i-o-ind 	  	     		pic x.
    05  hdr-admit-date.
        10  hdr-admit-dd			pic 99.
        10  hdr-admit-mm			pic 99.
* y2k        10  hdr-admit-yy			pic xx.
        10  hdr-admit-yy			pic xxxx.
    05  hdr-oma-cd       	  		pic x(4).
    05  hdr-oma-suff	         		pic x(1).
    05  filler 		            		pic x(2).
    05  hdr-fee-billed	 	    		pic 9999V99.
    05  hdr-nbr-of-serv  	  		pic 99.
    05  hdr-serv-date.
        10  hdr-serv-date-dd			pic 99.
        10  hdr-serv-date-mm			pic 99.
* y2k        10  hdr-serv-date-yy			pic 99.
        10  hdr-serv-date-yy			pic 9999. 
	05  hdr-diag-code	  	   		pic 9(3).
    05  hdr-add-serv.
        10  hdr-add-serv-nbr-1			pic 9.
        10  hdr-add-serv-day-1			pic 99.
        10  hdr-add-serv-nbr-2			pic 9.
        10  hdr-add-serv-day-2			pic 99.
        10  hdr-add-serv-nbr-3			pic 9.
        10  hdr-add-serv-day-3			pic 99.
    05  hdr-add-serv-r redefines hdr-add-serv.
	10  hdr-add-servs  occurs 3.
	    15 hdr-add-serv-nbr			pic 9.
	    15 hdr-add-serv-day			pic 99.

*    *************************************************************
*            DYAD  EXTENSIONS TO OHIP STANDARD FORMAT

    05  hdr-health-care-nbr			pic x(12).
    05  hdr-health-care-ver                     pic x(02).
    05  hdr-health-care-prov                    pic x(02).
    05  hdr-relationship                        pic x(01).
    05  hdr-patient-surname			pic x(09).
    05  hdr-subscr-initials			pic x(03).
    05  hdr-agent-cd     			pic x(01).
    05  hdr-loc-code  				pic x(04).
    05  hdr-wcb-claim-nbr			pic x(09).
* y2k    05  hdr-wcb-accident-date			pic x(06).
    05  hdr-wcb-accident-date			pic x(08).
    05  hdr-wcb-employer-name-addr		pic x(40).
    05  hdr-wcb-employer-postal-code		pic x(06).
