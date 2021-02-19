echo   "APPLICATION_OF_RAT_60"
echo  
echo  "**   APPLICATION OF OHIP REMITTANCE ADVICE TAPE   ** WITHOUT BACKUP"
echo 
echo   -  W A R N I N G  -
echo 
echo   IF THIS IS THE 1ST PROCESSING OF THIS RAT TAPE
echo   THEN CONVERT_RAT_TO_ASCII MUST BE RUN TO CONVERT
echo   THE DISK FILE FROM 'EBCDIC' TO 'ASCII'
echo                                           
#echo   'IF FILE HAS BEEN CONVERTED ONCE THEN  HIT   "NEWLINE"   TO CONTINUE ...'
# read garbage

echo 
echo   -  WARNING  -
echo   DOCTOR CASH FILE AND CLAIMS MASTER
echo    WILL BE UPDATED BY THIS RUN
echo 
echo     A DOCTOR CASH BACKUP SHOULD HAVE ALREADY BEEN RUN --BEFORE-- THIS UPDATE ...

#echo     'HIT   "NEWLINE"   TO INITIATE UPDATE PROGRAM ...'
# read garbage
echo 
#echo  'PROGRAM "U030" NOW LOADING ...'

#echo 'Now starting U030 for Clinic 60 ...'a
#date
#cd  $application_production/60
#pwd
#rm   >/dev/null  2>/dev/null  u030_60.ls
#$cmd/u030_60 1>u030_60.ls 2>&1

echo 'Now starting U030 for Clinic 61 ...'
date
cd  $application_production/61
pwd
rm   1>/dev/null  2>/dev/null  u030_61.ls
$cmd/u030 61 1>u030_61.ls 2>&1

echo 'Now starting U030 for Clinic 62 ...'
date
cd  $application_production/62
pwd
rm   1>/dev/null  2>/dev/null  u030_62.ls
$cmd/u030 62  1>u030_62.ls 2>&1

echo 'Now starting U030 for Clinic 63 ...'
date
cd  $application_production/63
pwd
rm   1>/dev/null  2>/dev/null  u030_63.ls
$cmd/u030 63 1>u030_63.ls 2>&1

echo 'Now starting U030 for Clinic 64 ...'
date
cd  $application_production/64
pwd
rm   1>/dev/null  2>/dev/null  u030_64.ls
$cmd/u030 64 1>u030_64.ls 2>&1

echo 'Now starting U030 for Clinic 65 ...'
date
cd  $application_production/65
pwd
rm   1>/dev/null  2>/dev/null  u030_65.ls
$cmd/u030 65 1>u030_65.ls 2>&1

echo 'Now starting U030 for Clinic 66 ...'
date
cd  $application_production/66
pwd
rm   1>/dev/null  2>/dev/null  u030_66.ls
$cmd/u030 66 1>u030_66.ls 2>&1
date


