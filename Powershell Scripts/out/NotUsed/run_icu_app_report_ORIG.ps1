#-------------------------------------------------------------------------------
# File 'run_icu_app_report_ORIG.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_icu_app_report_ORIG'
#-------------------------------------------------------------------------------

# Program: run_icu_app_report
#
Remove-Item run_icu_app_report.log *> $null

#batch << BATCH_EXIT
&$env:cmd\batch_icu_app_report *> run_icu_app_report.log
#BATCH_EXIT
