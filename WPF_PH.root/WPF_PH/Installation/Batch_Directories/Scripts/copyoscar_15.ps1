#-------------------------------------------------------------------------------
# File 'copyoscar_15.ps1'
# Converted to PowerShell by CORE Migration on 2019-05-14 14:15:24
# Original file name was 'copyoscar_15'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

if ("$1" -eq "")
{
	echo ""
	echo ""
	echo "** ERROR **"
	echo "You must provide 'number' of oscar folder!"
	echo ""
	echo "Valid Format: copyoscar_x YY YY=1 thru 10"
	exit
} else {
	Copy-Item runoscar_15.ps1 ..\oscar$1
	Copy-Item HJ254482.001_254482.rma.enc.dat ..\oscar$1
}