#-------------------------------------------------------------------------------
# File 'run_stage_40_ph_22to48.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_stage_40_ph_22to48'
#-------------------------------------------------------------------------------

echo " --- r004a\b\c\d (PH) --- "
&$env:QUIZ r004a 22000000 48ZZZ999 > r004.log
&$env:QUIZ r004b >> r004.log
&$env:QUIZ r004c >> r004.log
&$env:QUIZ r004d >> r004.log


echo " --- r005 (PH) --- "
&$env:QUIZ r005 22@ 48@ "22 - 48 Clinic Totals" > r005.log


echo " --- r011 (PH) --- "
&$env:QUIZ r011 22@ 48@ "22 - 48 Clinic Totals" > r011.log



echo " --- r012 (PH) --- "
&$env:QUIZ r012 22@ 48@ "22 - 48 Clinic Totals" > r012.log


echo " --- r013 (PH) --- "
&$env:QUIZ r013 22@ 48@ "22 - 48 Clinic Totals" > r013.log


echo " --- r051ca (PH) --- "
&$env:QUIZ r051ca 22@ 48@ > r051.log

echo " --- r070a\b\c\d (PH) --- "
&$env:QUIZ r070a 22@ 48@ > r070.log
&$env:QUIZ r070b >> r070.log
&$env:QUIZ r070c >> r070.log
&$env:QUIZ r070d >> r070.log
