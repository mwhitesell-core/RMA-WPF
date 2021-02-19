#-------------------------------------------------------------------------------
# File 'u132_bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'u132_bk1'
#-------------------------------------------------------------------------------

#file:  u132
# 04/sep/20 b.e. - original

clear
echo "Running `'processing of Payroll Transactions Upload `'"
echo ""
echo "You must pass 2 paramters to this macro:"
echo ""
echo "1\) The SEQUENCE NBR of the driver file parameters you want applied"
echo "2\) The FILENAME of the transaction you uploaded\(ascii\) to the `'upload`' directory"
echo ""
echo ""
#echo Hit ENTER to continue
#read garbage

if ("$1" -eq "")
{
  echo ""
  echo ""
  echo "**ERROR**"
  echo "You must supply the SEQUENCE NBR of the driver paremeters you want to use"
  echo ""
  exit
} else {
if ("$2" -eq "")
{
  echo ""
  echo ""
  echo "**ERROR**"
  echo "You must supply the name of the file you want to process"
  echo ""
  exit
} else {
if (-not(Test-Path $application_upl\$2 ))
{
  echo ""
  echo ""
  echo "**ERROR** No such file to process - $application_upl\$2"
  echo ""
  exit
} else {
  if (Test-Path $application_upl\u132.dat)
  {
    echo ""
    echo ""
    echo "**ERROR**"
    echo "Unprocessed file$application_upl\u132.dat already exists - process it first!"
    echo ""
    exit
} else {

echo ""
echo "Process now loading ... when done the log file will be paged to your screen"

#$cmd/u132.com $1 $2 > u132.log
&$env:cmd\u132.com $1 $2
#pg u132.log
}
}
}
}
