echo "Running rat_audit_2.com ..."
echo
echo "WARNING - you must have vi'd rat.ps to eliminate unwanted clinic data"
echo "         or you will be auditing multi-clinic rat records!!!!"
echo 
echo "Hit Enter to continue ..."
read garbage
echo

cd $application_production

echo "starting rat_audit_1 ..."
quiz auto=$obj/rat_audit_1.qzc

echo "starting rat_audit_2 ..."
quiz auto=$obj/rat_audit_2.qzc

echo "starting rat_audit_3 ..."
quiz auto=$obj/rat_audit_3.qzc

echo "starting rat_audit_4 ..."
quiz auto=$obj/rat_audit_4.qzc

echo "starting rat_audit_5 ..."
quiz auto=$obj/rat_audit_5.qzc

echo "starting rat_audit_6a ..."
quiz auto=$obj/rat_audit_6a.qzc

echo "starting rat_audit_6b ..."
quiz auto=$obj/rat_audit_6b.qzc

echo "starting rat_audit_6c ..."
quiz auto=$obj/rat_audit_6c.qzc

echo "starting rat_audit_8 ..."
quiz auto=$obj/rat_audit_8.qzc

echo "starting rat_audit_10 ..."
quiz auto=$obj/rat_audit_10.qzc

cat  rat_audit_1.txt   \
     rat_audit_2.txt   \
     rat_audit_3.txt   \
     rat_audit_4.txt   \
     rat_audit_5.txt   \
     rat_audit_6a.txt  \
     rat_audit_6b.txt  \
     rat_audit_6c.txt  \
     rat_audit_8.txt   \
     rat_audit_10.txt  > rat_audit.txt
#lp rat_audit.txt

echo
echo Done!
