#-------------------------------------------------------------------------------
# File 'rat_audit_1.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'rat_audit_1.com'
#-------------------------------------------------------------------------------

echo "Running rat_audit_1.com ..."
echo ""

Set-Location $pb_data

&$env:cmd\dump_rat

# CONVERSION ERROR (expected, #8): awk.
# awk -f $cmd/pad_to_79_bytes.awk < ohip_rat_ascii.dump > $application_production/rat.ps

echo ""
echo "Finished !"
echo ""
echo ""
echo "You should now vi the rat.ps in production and then run rat_audit_2.comA"

Set-Location $env:application_production
