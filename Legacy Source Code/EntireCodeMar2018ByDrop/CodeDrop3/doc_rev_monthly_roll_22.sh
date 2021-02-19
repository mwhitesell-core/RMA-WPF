echo  "DOC_REV_MONTHLY_ROLL_22"
echo  

echo  MONTHLY ROLLOVER OF DOCTOR REVENUE MASTER    
echo 
echo   WARNING  DOCTOR REVENUE FILE WILL BE UPDATED BY THIS RUN --
echo  A BACKUP OF THE FILE WILL NOW BE RUN

echo 
echo  'HIT   "NEWLINE"   TO COMMENCE BACKUP ...'
read garbage
echo 

echo 
echo 
echo  'PROGRAM "u014_f050" NOW LOADING ...'
echo 
qtp auto=$obj/u014_f050.qtc << E_O_F
22
E_O_F

echo  'PROGRAM "u015" NOW LOADING ...'
echo 
qtp auto=$obj/u015.qtc 2>&1  1>u015_22.log << u015_EXIT
22@
22@
22@
22@
u015_EXIT

echo 

