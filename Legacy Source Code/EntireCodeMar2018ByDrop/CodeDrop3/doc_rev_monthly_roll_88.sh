echo  "DOC_REV_MONTHLY_ROLL_88"
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
88
E_O_F

echo  'PROGRAM "U015" NOW LOADING ...'
qtp auto=$obj/u015.qtc 2>&1  1>u015_88.log << u015_EXIT
88@
88@
88@
88@
u015_EXIT

echo 