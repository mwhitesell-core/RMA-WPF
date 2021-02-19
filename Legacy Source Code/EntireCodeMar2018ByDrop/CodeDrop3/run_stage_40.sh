echo " --- r004a (COBOL) --- "
cobrun $obj/r004a << R004A_EXIT
22
Y
R004A_EXIT

echo " --- r004b (COBOL) --- "
cobrun $obj/r004b

echo " --- r004c (COBOL) --- "
cobrun $obj/r004c << R004C_EXIT
Y
R004C_EXIT

#lp r004

echo " --- r005 (COBOL) --- "
cobrun $obj/r005 << R005_EXIT
22
Y
R005_EXIT

#lp r005

echo " --- r011 (COBOL) --- "
cobrun $obj/r011 << R011_EXIT
22
Y
R011_EXIT

#lp r011

echo " --- r011mohr (QUIZ) --- "
quiz auto=$obj/r011mohr << QUIZ_EXIT
22@
QUIZ_EXIT

#lp r011mohr.txt

echo " --- r012 (COBOL) --- "
cobrun $obj/r012 << R012_EXIT
22
Y
R012_EXIT

#lp r012

echo " --- r013 (COBOL) --- "
cobrun $obj/r013 << R013_EXIT
22
Y
R013_EXIT

#lp r013

echo " --- r051a (COBOL) --- "
cobrun $obj/r051a << R051A_EXIT
22
Y
R051A_EXIT
 
echo " --- r051b (COBOL) --- "
cobrun $obj/r051b
echo " --- r051c (COBOL) --- "
cobrun $obj/r051c

#lp r051ca

echo " --- r051b (COBOL) --- "
cobrun $obj/r051b
echo " --- r051c (COBOL) --- "
cobrun $obj/r051c

#lp r051cb

#echo NOW RUNNING $cmd/r004_ph_portal_22to48
#$cmd/r004_ph_portal_22to48
