echo  "DOC_REV_MONTHLY_ROLL_70"
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
qtp auto=$obj/u014_f050.qtc 2>&1 1> u014_f050_70.log  << E_O_F
70
E_O_F

echo 
echo  'PROGRAM "u014_f050tp" NOW LOADING ...'
echo 
qtp auto=$obj/u014_f050tp.qtc 2>&1 1> u014_f050tp_70.log  << E_O_F2
70
E_O_F2

echo  'PROGRAM "u015" NOW LOADING ...'
echo
qtp auto=$obj/u015.qtc 2>&1 1> u015_70.log  << u015_EXIT
71@
75@
71@
75@
u015_EXIT

echo 
echo  'PROGRAM "u015tp" NOW LOADING ...'
echo 
qtp auto=$obj/u015tp.qtc 2>&1 1> u015tp_70.log  << u015tp_EXIT
71@
75@
71@
75@
u015tp_EXIT



echo 
