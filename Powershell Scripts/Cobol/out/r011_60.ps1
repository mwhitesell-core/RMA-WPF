#-------------------------------------------------------------------------------
# File 'r011_60.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'r011_60'
#-------------------------------------------------------------------------------

$pipedInput = @"
execute $obj/r011a
execute $obj/r011b
execute $obj/r011c
"@

$pipedInput | quiz++

Get-Content r011b.txt, r011c.txt  >> r011a.txt
Move-Item r011a.txt r011_60
