#-------------------------------------------------------------------------------
# File 'u140_stage1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'u140_stage1'
#-------------------------------------------------------------------------------

#file:  u140_stage1
# 04/jun/01 b.e. - original
# 08/sep/09 M.C. - transfer filename check from u140_stage3

param(
	[string]$1
     )

clear
echo "Running `'processing of AFP Conversion Payment file - Stage 1`'"
echo ""
echo ""

$filename = "$1"

if ("$1" -eq "")
{
  echo ""
  echo ""
  echo "**ERROR**"
  echo "You must supply the name of the file you want to process"
  echo ""
  exit
} else {
if (-not(Test-Path $filename ))
{
  echo ""
  echo ""
  echo "**ERROR** No such file to process - $filename"
  echo ""
  exit
} else {
  if (Test-Path afp_fixed_payments.dat)
  {
    echo ""
    echo "**ERROR**"
    echo "Unprocessed fileafp_fixed_payments.dat already exists - process it first!"
    echo ""
    exit
  } else {

echo ""
echo ""
echo "Process now loading ... when done the log file will be paged to your screen"

&$env:cmd\u140_stage1.com $1 > u140_stage1.log
Get-Content u140_stage1.log
}
}
}
