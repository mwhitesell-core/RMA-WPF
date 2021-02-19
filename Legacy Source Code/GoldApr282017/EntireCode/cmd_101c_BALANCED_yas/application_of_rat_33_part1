echo   "APPLICATION_OF_RAT_33"

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
echo  PROGRAM "U030" NOW LOADING ...

cd  $application_production/33
rm   >/dev/null  2>/dev/null  u030_33.ls
#batch << BATCH_EXIT
$cmd/u030 33 1>u030_33.ls 2>&1
#BATCH_EXIT
date
