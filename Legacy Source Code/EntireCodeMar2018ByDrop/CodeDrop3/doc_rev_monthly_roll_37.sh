echo  "DOC_REV_MONTHLY_ROLL_37"
echo  

echo  MONTHLY ROLLOVER OF DOCTOR REVENUE MASTER    
echo 
echo   WARNING  DOCTOR REVENUE FILE WILL BE UPDATED BY THIS RUN --
echo  A BACKUP OF THE FILE WILL NOW BE RUN

echo 
echo 

echo 
echo  MONTHLY ROLL OVER WILL NOW BE RUN --
echo 
echo  'PROGRAM "U014" NOW LOADING ...'
echo
qtp auto=$obj/u014_f050.qtc << E_O_F
37
E_O_F

echo  'PROGRAM "U015" NOW LOADING ...'
echo 
qtp auto=$obj/u015.qtc 2>&1  1>u015_37.log << u015_EXIT
37@
37@
37@
37@
u015_EXIT

echo 
