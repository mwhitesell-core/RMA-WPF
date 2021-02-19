# f020_info_export.com

echo CREATE export file in MP environment ...
echo

echo Entering \'upload\' directory
cd $application_upl;pwd
qtp auto=$obj/f020_info_export.qtc
cp f020_info_export.sf* /alpha/rmabill/rmabill101c/upload

echo
echo Setup of 101c environment
echo . /macros/setup_rmabill.com  101c
whence rmabill
./rmabill 101c

echo Entering \'upload\' directory
cd $application_upl;pwd

echo UPLOAD data into 101c environment
echo "dict = " $DICT
echo "obj = " $obj
echo "obj = " $obj
echo "data = " $data
echo Running Upload program
qtp auto=$obj/f020_info_import.qtc

echo Done!

