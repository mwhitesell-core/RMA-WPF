#-------------------------------------------------------------------------------
# File 'yearend_payroll_purges.bk2.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'yearend_payroll_purges.bk2'
#-------------------------------------------------------------------------------

#  YEAREND PAYROLL PURGES 
#
# 00/jul/08 B.E. - disable running pgm in 'batch'
# 00/jul/10 B.E. - force log into be in $pb_prod
# 06/may/24 M.C. - As per Brad's request, include the new report r113
#                  to let user to verify the records in the new f113-default-comp
# 07/jul/09 M.C. - do not delete and recreate f020-doctor-extra via qutil
# 07/jul/12 M.C. - Yasemin requested not to delete F113-DEFAULT-COMP-UPLOAD-DRIVER
#                  when deleting f113-default-comp (they both share the same prefix)

Set-Location $pb_prod

Remove-Item $pb_prod\payrollpurge.log *> $null

###batch << BATCH_EXIT
echo "YEAREND PAYROLL PURGES - STARTING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" > $pb_prod\payrollpurge.log

echo "--- yearend_1---"
&$env:QTP yearend_1 >> $pb_prod\payrollpurge.log 2> $pb_prod\payrollpurge.log

Set-Location $pb_data

echo "--- delete files ---"
Remove-Item f110_compensation*
Remove-Item f112_pycdceilings*
##rm f113_default_comp* - 2007/07/12
Remove-Item f113_default_comp.*
Remove-Item f119_doctor_ytd*
Remove-Item f198_user_defined_totals*
##rm f020_doctor_extra*

echo "--- create files ---"
$pipedInput = @"
create file f110-compensation
create file f112-pycdceilings
create file f113-default-comp
create file f119-doctor-ytd
create file f198-user-defined-totals
;##create file f020-doctor-extra
"@

$pipedInput | qutil++

Set-Location $pb_prod

echo "--- yearend_2---"
&$env:QTP yearend_2 >> $pb_prod\payrollpurge.log 2> $pb_prod\payrollpurge.log

# 2006/Jul/11 - MC - add purge_f113.qtc  to delete comp-code LTD
&$env:QTP purge_f113 >> $pb_prod\payrollpurge.log 2> $pb_prod\payrollpurge.log


# 2006/may/24 - MC - add a new report r113
#                  - ask user to verify the content of the report
#                  - make neccessary correction if needed

&$env:QUIZ r113

Get-Content r113.txt | Out-Printer


# 2006/jun/13 - MC - Mary requests to blank out f112
# 2006/Jul/12 - MC - Mary changed her mind, roll over f112, not recreate empty file
#                    but zero out required and target revenue fields for the new year

##cd $pb_data

##echo "--- recreate f112 file ---"
##rm f112_pycdceilings*
##qutil << QUTIL_EXIT
##create file f112-pycdceilings
##QUTIL_EXIT


echo "YEAREND PAYROLL PURGES - ENDING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" >> payrollpurge.log
###BATCH_EXIT
