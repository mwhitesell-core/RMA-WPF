echo  "DOC_REV_MONTHLY_ROLL_86"
echo  

echo  MONTHLY ROLLOVER OF DOCTOR REVENUE MASTER
echo 
echo   WARNING  DOCTOR REVENUE FILE WILL BE UPDATED BY THIS RUN --
echo  A BACKUP OF THE FILE WILL NOW BE RUN

#echo 
#echo  'HIT   "NEWLINE"   TO COMMENCE BACKUP ...'
#read garbage
#echo 

#$cmd/backup_f001_f050

echo 
#echo  MONTHLY ROLL OVER WILL NOW BE RUN --
#echo  'HIT   "NEWLINE"   TO CONTINUE ...'
#read garbage
echo 
echo  'PROGRAM "U014" NOW LOADING ...'
echo
qtp auto=$obj/u014_f050.qtc 2>&1 1>u014_f050_86.log << E_O_F
86
E_O_F

echo  'PROGRAM "U015" NOW LOADING ...'
echo 
qtp auto=$obj/u015.qtc 2>&1  1>u015_86.log << u015_EXIT
86@
86@
86@
86@
u015_EXIT


#echo 
#echo  'TO FINISH THIS RUN  HIT  "NEWLINE" ...'
#read garbage