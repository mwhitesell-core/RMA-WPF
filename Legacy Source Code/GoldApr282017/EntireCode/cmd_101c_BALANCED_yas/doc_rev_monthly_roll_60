echo  "DOC_REV_MONTHLY_ROLL_60"
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
echo  'PROGRAM "u014_f050" NOW LOADING ...'
echo
qtp auto=$obj/u014_f050.qtc 2>&1 1>u014_f050_60.log << E_O_F
60
E_O_F

echo 
echo  'PROGRAM "u014_f050tp" NOW LOADING ...'
echo
qtp auto=$obj/u014_f050tp.qtc 2>&1 1>u014_f050tp_60.log << E_O_F2
60
E_O_F2

echo  'PROGRAM "u015" NOW LOADING ...'
echo
qtp auto=$obj/u015.qtc  2>&1 1>u015_60.log  << u015_EXIT
61@
66@
61@
66@
u015_EXIT

echo 
echo  'PROGRAM "u015tp" NOW LOADING ...'
echo 
qtp auto=$obj/u015tp.qtc 2>&1  1>u015tp_60.log  << u015tp_EXIT
61@
66@
61@
66@
u015tp_EXIT

echo 
