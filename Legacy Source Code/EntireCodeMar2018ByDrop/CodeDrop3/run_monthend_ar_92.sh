echo
echo                        CONTRACT 92
echo
echo         RUN MONTHEND REPORTS AND ACCOUNTS RECEIVABLE
echo
echo

cd $application_production/92

cobrun $obj/r004a << R004A_EXIT
92
Y
R004A_EXIT

cobrun $obj/r004b

cobrun $obj/r004c << R004C_EXIT
Y
R004C_EXIT

#lp r004

cobrun $obj/r005 << R005_EXIT
92
Y
R005_EXIT

#lp r005

cobrun $obj/r011 << R011_EXIT
92
Y
R011_EXIT

#lp r011

cobrun $obj/r012 << R012_EXIT
92
Y
R012_EXIT

#lp r012

cobrun $obj/r013 << R013_EXIT
92
Y
R013_EXIT

#lp r013

cobrun $obj/r051a << R051A_EXIT
92
Y
R051A_EXIT

cobrun $obj/r051b

cobrun $obj/r051c

#lp r051ca

cobrun $obj/r051b

cobrun $obj/r051c

#lp r051cb

cobrun $obj/r070a << R070A_EXIT
92
Y
Y
R070A_EXIT

cobrun $obj/r070b

cobrun $obj/r070c << R070C_EXIT
N
R070C_EXIT

#lp r070_92
