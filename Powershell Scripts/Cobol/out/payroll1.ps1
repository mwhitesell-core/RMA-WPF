#-------------------------------------------------------------------------------
# File 'payroll1.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'payroll1'
#-------------------------------------------------------------------------------

$pipedInput = @"
exec $obj/payrolllist nogo
sort on doc-clinic-nbr on doc-nbr
go
${1}
${2}
${3}
"@

$pipedInput | quiz++
