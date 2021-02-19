echo   "APPLICATION_OF_RAT_70"
echo  
echo  "**   APPLICATION OF OHIP REMITTANCE ADVICE TAPE   ** WITHOUT BACKUP"
echo 
echo   -  W A R N I N G  -
echo 
echo   IF THIS IS THE 1ST PROCESSING OF THIS RAT TAPE
echo   THEN CONVERT_RAT_TO_ASCII MUST BE RUN TO CONVERT
echo   THE DISK FILE FROM 'EBCDIC' TO 'ASCII'
echo                                           

echo 
echo   -  WARNING  -
echo   DOCTOR CASH FILE AND CLAIMS MASTER
echo    WILL BE UPDATED BY THIS RUN
echo 
echo     A DOCTOR CASH BACKUP SHOULD HAVE ALREADY BEEN RUN --BEFORE-- THIS UPDATE ...

echo 

echo 'Now starting U030 for Clinic 71 ...'
date
cd  $application_production/71
pwd
rm   1>/dev/null  2>/dev/null  u030_71.ls
$cmd/u030 71 1>u030_71.ls 2>&1

echo 'Now starting U030 for Clinic 72 ...'
date
cd  $application_production/72
pwd
rm   1>/dev/null  2>/dev/null  u030_72.ls
$cmd/u030 72  1>u030_72.ls 2>&1

echo 'Now starting U030 for Clinic 73 ...'
date
cd  $application_production/73
pwd
rm   1>/dev/null  2>/dev/null  u030_73.ls
$cmd/u030 73 1>u030_73.ls 2>&1

echo 'Now starting U030 for Clinic 74 ...'
date
cd  $application_production/74
pwd
rm   1>/dev/null  2>/dev/null  u030_74.ls
$cmd/u030 74 1>u030_74.ls 2>&1

echo 'Now starting U030 for Clinic 75 ...'
date
cd  $application_production/75
pwd
rm   1>/dev/null  2>/dev/null  u030_75.ls
$cmd/u030 75 1>u030_75.ls 2>&1
date


