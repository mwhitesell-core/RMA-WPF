#-------------------------------------------------------------------------------
# File 'r011_70.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'r011_70'
#-------------------------------------------------------------------------------

$pipedInput = @"
execute $obj/r011a_70
execute $obj/r011b_70
execute $obj/r011c_70 
"@

$pipedInput | quiz++

Get-Content r011b_70.txt, r011c_70.txt  >> r011a_70.txt
Move-Item r011a_70.txt r011_70
