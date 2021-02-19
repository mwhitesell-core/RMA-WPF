# 1267	2014-oct-14	be1	- correct test for zero length file

echo Running 'verify_adj_file'
echo
echo This program will verify the contents of the adj_claim_file
echo before the Cycle commences ...
echo

cd $application_root/production

echo Running r990 ...
rm r990.txt 
quiz auto=$obj/r990.qzc

#be1 if [ -s r990.txt > 0 ] 
if [ -s r990.txt  ] 
then
 	echo	
 	echo	
 	echo	
	echo 
	echo "ERROR   Printing R990 report of bad transactions in adj_claim_file"
	echo "        FIX THEM BEFORE continuing the Cycle run"
 	echo	
 	echo	
	echo
	lp r990.txt
 	echo	
 	echo	
	echo "The report is now on the line printer"
	echo 
 	echo	
 	echo	
 	echo	
else
 	echo	
 	echo	
 	echo	
	echo "No problems with file - you can continue the Cycle run now"
 	echo	
 	echo	
 	echo	
fi
