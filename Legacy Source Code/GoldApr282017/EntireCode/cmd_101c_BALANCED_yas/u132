#!/bin/ksh
#file:  u132
# 04/sep/20 b.e. - original
# 07/jan/09 b.e. - added new param (DC=default compensation) or SP=special paym)

clear
echo Running \'processing of Payroll Transactions Upload \'
echo 
echo You must pass 3 paramters to this macro:
echo
echo 1\) The SEQUENCE NBR of the driver file parameters you want applied to WB
echo 2\) The FILENAME of the transaction you uploaded\(ascii\) to the \'upload\' directory
echo 3\) The TYPE of transaction you want to upload \(DC\) or \(SP\)
echo
#echo Hit ENTER to continue
#read garbage

if [ "$1" = "" ]
then
  echo 
  echo 
  echo  **ERROR**
  echo  You must supply the SEQUENCE NBR of the driver paremeters you want to use
  echo
  exit
else
if [ "$2" = "" ]
then
  echo 
  echo 
  echo  **ERROR**
  echo  You must supply the name of the file you want to process
  echo
  exit
else
if [ "$3" = "" ]
then
  echo 
  echo 
  echo  **ERROR**
  echo  You must supply the TYPE of transaction: DC=Default Compensation or SP=Special Payment
  echo
  exit
else
if [ ! -f $application_upl/$2 ]
then
  echo 
  echo 
  echo **ERROR** No such file to process - $application_upl/$2
  echo 
  exit
else
  if ( [ -f $application_upl/u132.dat ] )
  then
    echo 
    echo
    echo **ERROR** 
    echo Unprocessed file '$application_upl/u132.dat' already exists - process it first! 
    echo 
    exit
else
  
echo
echo Process now loading ... when done the log file will be paged to your screen
  
#$cmd/u132.com $1 $2 $3 > u132.log
$cmd/u132.com $1 $2 $3 
#pg u132.log
fi    
fi
fi
fi
fi
