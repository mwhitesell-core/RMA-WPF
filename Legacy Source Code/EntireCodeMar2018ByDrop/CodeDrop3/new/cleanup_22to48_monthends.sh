echo  "********************************************************************"

echo         THIS PROGRAM WILL DELETE THE Clinics 22 to 48 reports       
echo      MAKE SURE ALL THE REPORTS ARE PRINTED AND COPY MAG TAPE IS RUN
echo 
echo  "********************************************************************"
echo 
echo  "**** HIT NEW LINE TO CONTINUE ****"
read garbage
echo
date

$cmd/cleanup_22_monthend
$cmd/cleanup_23_monthend
$cmd/cleanup_24_monthend
$cmd/cleanup_25_monthend
$cmd/cleanup_26_monthend
$cmd/cleanup_30_monthend
$cmd/cleanup_31_monthend
$cmd/cleanup_32_monthend
$cmd/cleanup_33_monthend
$cmd/cleanup_34_monthend
$cmd/cleanup_35_monthend
$cmd/cleanup_36_monthend
$cmd/cleanup_41_monthend
$cmd/cleanup_42_monthend
$cmd/cleanup_43_monthend
$cmd/cleanup_44_monthend
$cmd/cleanup_45_monthend
$cmd/cleanup_46_monthend
$cmd/cleanup_48_monthend
$cmd/cleanup_98_monthend

date
