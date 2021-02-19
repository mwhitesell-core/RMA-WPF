*  Source: d001_d003_confidentiality_check

don't use this code - it's out of date
refer to correct code in 'confidentially_check_rma/ministry_codes.rtn

ga1-check-for-confidentiality. 
 
    if hold-desc(1) =   'NO PATIENT CONTACT' 
		     or 'NO VERIFICATION PLEASE' 
    then 
	move 'Y'		to clmhdr-confidential-flag 
        go to ga1-99-exit. 
*   endif 
 
    perform ga11-check-for-oma-diag-cd	thru ga11-99-exit 
	varying ss-clmdtl-oma from 1 by 1 until ss-clmdtl-oma > 8 
			or clmhdr-confidential-flag   = 'Y' 
			or hold-oma-cd(ss-clmdtl-oma) = ' '. 
 
ga1-99-exit. 
    exit. 
 
 
ga11-check-for-oma-diag-cd. 
 
    if hold-diag-cd (ss-clmdtl-oma) = 042 or 043 or 044 or 097 or 098 
                               or 099 or 290 or 291 or 292 or 295 
                               or 296 or 297 or 298 or 299 or 300 
                               or 301 or 311 or 632 or 634 or 635 
                               or 640 or 895 or 319 
    then 
	move 'Y'		to clmhdr-confidential-flag 
    else 
	if hold-oma-cd (ss-clmdtl-oma) = 'A198' or 'K620' or 'K623' 
				      or 'K624' or 'G100' or 'G362' 
				      or 'K018' or 'K021' or 'K051' 
				      or 'K052' or 'K061' or 'K007' 
				      or 'K010' or 'K624' or 'K012' 
				      or 'K004' or 'K629' or 'K024' 
				      or 'K623' or 'K025' or 'K198' 
				      or 'K197' or 'K190' or 'K203' 
				      or 'K015' or 'K204' or 'K205' 
				      or 'K206' or 'K200' or 'K201' 
				      or 'K202' or 'K207' or 'K053' 
				      or 'K195' or 'K193' or 'A195' 
				      or 'C195' or 'C193' or 'C192' 
				      or 'K629' or 'K199' or 'K196' 
				      or 'K191' or 'K192' or 'K194' 
				      or 'K005' or 'K008' or 'A395' 
				      or 'A196' or 'A193' or 'A194' 
				      or 'C395' or 'C196' or 'C197' 
				      or 'C199' or 'C198' or 'W195' 
				      or 'W395' or 'W196' or 'A197' 
	then 
	    move 'Y'		to clmhdr-confidential-flag 
	else 
	    if     (hold-oma-suff (ss-clmdtl-oma) = 'A' or 'B' or 'C') 
	       AND (hold-oma-cd   (ss-clmdtl-oma) = 'E108' or 'E753' 
					   	 or 'R200' or 'R872' 
					   	 or 'S274' or 'S436' 
					  	 or 'S626' or 'S738' 
					   	 or 'S741' or 'S752' 
					  	 or 'S756' or 'S768' 
					  	 or 'A777' or 'C777' 
					  	 or 'W777' or 'A902' 
					  	 or 'S783' or 'S785') 
	    then 
		move 'Y'	to clmhdr-confidential-flag. 
*	    endif 
*	endif 
*   endif 
 
ga11-99-exit. 
    exit. 
 
 
