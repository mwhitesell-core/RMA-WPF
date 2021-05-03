#-------------------------------------------------------------------------------
# File 'yearend_payroll_purges.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'yearend_payroll_purges'
#-------------------------------------------------------------------------------

#  YEAREND PAYROLL PURGES 
#
# 00/jul/08 B.E. - disable running pgm in 'batch'
# 00/jul/10 B.E. - force log into be in $env:pb_prod
# 06/may/24 M.C. - As per Brad's request, include the new report r113
#                  to let user to verify the records in the new f113-default-comp
# 07/jul/09 M.C. - do not delete and recreate f020-doctor-extra via qutil
# 07/jul/12 M.C. - Yasemin requested not to delete F113-DEFAULT-COMP-UPLOAD-DRIVER
#                  when deleting f113-default-comp (they both share the same prefix)
# 15/Jul/08 MC1  - correct to delete files with specific names instead of wild card for f110/f112/f119 because
#                  do not want to delete audit files, save audit files as bkp  and recreate the new audit files
# 15/Jul/15 MC2  - Brad said do not need to save audit files for backup as he will take care of the file transfer 
#                  nightly from c:\macros\ftp_get_utl0201.bat   at 11:50 pm
# 15/Sep/22 MC3  - include the run of r112_csv.qzc

Set-Location $env:pb_prod

Remove-Item $env:pb_prod\payrollpurge.log *> $null

echo "YEAREND PAYROLL PURGES - STARTING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" > $env:pb_prod\payrollpurge.log

echo "--- yearend_1---"
$rcmd = $env:QTP + "yearend_1" 
Invoke-Expression $rcmd *>> $env:pb_prod\payrollpurge.log

#Core - Commented out removing data files and creating them
#Set-Location $env:pb_data

#echo "--- delete files ---"
# MC1
#rm f110_compensation*
#rm f112_pycdceilings*
#Remove-Item f110_compensation.*
#Remove-Item f112_pycdceilings.*
#Remove-Item f113_default_comp.*
#rm f119_doctor_ytd*
#Remove-Item f119_doctor_ytd.*
#Remove-Item f198_user_defined_totals*
##rm f020_doctor_extra*

#echo "--- create files ---"
#<#$pipedInput = @"
#create file f110-compensation
#create file f112-pycdceilings
#create file f113-default-comp
#create file f119-doctor-ytd
#create file f198-user-defined-totals
#;##create file f020-doctor-extra
#"@

#$pipedInput | qutil++#>

$rcmd = $env:TRUNCATE+ "f110_compensation"
Invoke-Expression $rcmd
$rcmd = $env:TRUNCATE+ "f112_pycdceilings"
Invoke-Expression $rcmd
$rcmd = $env:TRUNCATE+ "f113_default_comp"
Invoke-Expression $rcmd
$rcmd = $env:TRUNCATE+ "f119_doctor_ytd"
Invoke-Expression $rcmd
$rcmd = $env:TRUNCATE+ "f198_user_defined_totals"
Invoke-Expression $rcmd

#Set-Location $env:pb_prod

echo "--- yearend_2---"
$rcmd = $env:QTP + "yearend_2"
Invoke-Expression $rcmd *>> $env:pb_prod\payrollpurge.log


# MC3
$rcmd = $env:QUIZ + "r112_csv" 
Invoke-Expression $rcmd *>> $env:pb_prod\payrollpurge.log
# 2006/Jul/11 - MC - add purge_f113.qtc  to delete comp-code LTD
$rcmd = $env:QTP + "purge_f113"
Invoke-Expression $rcmd *>> $env:pb_prod\payrollpurge.log

# 2006/may/24 - MC - add a new report r113
#                  - ask user to verify the content of the report
#                  - make neccessary correction if needed

$rcmd = $env:QUIZ + "r113"
Invoke-Expression $rcmd *>> $env:pb_prod\payrollpurge.log

if ( $env:networkprinter -ne 'null'  )
{
   Get-Content r113.txt | Out-Printer -Name $env:networkprinter
}


# 2006/jun/13 - MC - Mary requests to blank out f112
# 2006/Jul/12 - MC - Mary changed her mind, roll over f112, not recreate empty file
#                    but zero out required and target revenue fields for the new year

##cd $pb_data

##echo "--- recreate f112 file ---"
##rm f112_pycdceilings*
##qutil << QUTIL_EXIT
##create file f112-pycdceilings
##QUTIL_EXIT


#MC1 - save audit files before recreate them
##mv f020_doctor_audit.dat           f020_doctor_audit.dat.bkp
##mv f110_compensation_audit.dat     f110_compensation_audit.dat.bkp
##mv f112_pycdceilings_audit.dat     f112_pycdceilings_audit.dat.bkp
##mv f119_doctor_ytd_audit.dat       f119_doctor_ytd_audit.dat.bkp

#<#echo "--- create files ---"
#$pipedInput = @"
#create file f020-doctor-audit
#create file f028-audit-file
#create file f110-compensation-audit
#create file f112-pycdceilings-audit
#create file f119-doctor-ytd-audit
#"@

#$pipedInput | qutil++#>

$rcmd = $env:TRUNCATE+ "f020_doctor_audit"
Invoke-Expression $rcmd
$rcmd = $env:TRUNCATE+ "f028_audit_file"
Invoke-Expression $rcmd
$rcmd = $env:TRUNCATE+ "f110_compensation_audit"
Invoke-Expression $rcmd
$rcmd = $env:TRUNCATE+ "f112_pycdceilings_audit"
Invoke-Expression $rcmd
$rcmd = $env:TRUNCATE+ "f119_doctor_ytd_audit"
Invoke-Expression $rcmd
# MC1 - end

echo "YEAREND PAYROLL PURGES - ENDING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" >> $env:pb_prod\payrollpurge.log
#
##BATCH_EXIT
