#-------------------------------------------------------------------------------
# File 'check_f001_invalid_clinic.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'check_f001_invalid_clinic'
#-------------------------------------------------------------------------------

# 2014/Oct/20   MC check_f001_invalid_clinic
#                  run this only if you receive invalid clinic in r001b / r001

Set-Location $env:application_root\production

&$env:QUIZ checkf001_f090

echo "Run delete invalid batch record only if the amount is zero.."
echo "Otherwise you have to contact DYAD .."
