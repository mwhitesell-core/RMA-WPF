##  2016/Dec/01	MC	- utl0013 
##			- check for doctors that have both dept 13 and 14
##			  and set 'Y' to pay-this-doctor-ohip-premium for dept 14

cd $application_root/production

rm utl0013.log

echo "utl0013.com  -  STARTING - `date`" > utl0013.log    

qtp  auto=$obj/utl0013.qtc  >> utl0013.log
quiz auto=$obj/utl0013.qzc  >> utl0013.log

echo "utl0013 - ENDING - `date`" >> utl0013.log
