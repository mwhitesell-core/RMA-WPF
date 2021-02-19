#-------------------------------------------------------------------------------
# File 'agep_part3.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'agep_part3'
#-------------------------------------------------------------------------------


# macro: agep_part3 
# 2013/Sep/11 M.C. To delete the undefined doctor payment claim and reduce the pay amount in f001 file
#                  based on the subfile r030r_undefined_doc that is generated from r030r2.qzc if exists


Get-Date

Set-Location $application_production

echo "Current Directory:"
Get-Location


echo ""
echo "start of the run for AGEP payment PART 3"
echo ""

echo "Running delete undefined doc pay claim   "

qtp++ $obj\u031

echo ""
echo "end of the run for AGEP payment PART 3"
echo ""
Get-Date
