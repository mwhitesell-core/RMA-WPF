#-------------------------------------------------------------------------------
# File 'yearend_payroll_reload.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'yearend_payroll_reload'
#-------------------------------------------------------------------------------

# YEAREND PAYROLL RELOAD
# To restore from tape:
echo "RELOAD YEAREND PAYROLL ..."
Set-Location $pb_data
# CONVERSION ERROR (expected, #5): cpio.
# cpio -icuvB -I backup_earnings_yearend
echo "FINISH ..."
