#! /bin/awk -f        
BEGIN {
  }
{
#gsub("LIVE RUN","TEST RUN")  
#gsub("A0000000010102024944000209802201020","A0000000010102024944017509813901020")  
printf "%s\n", $0 
  }

END {
 }
