#-------------------------------------------------------------------------------
# File 'u022.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'u022'
#-------------------------------------------------------------------------------

# U022
# 99/dev/14 B.E. - added backup of u020a1_resubmits.sf
# 02/juan/07 B.E. - removed deletion of u022a subfile

Set-Location $application_production
echo "RESUBMITS IN PROGRESS$(udate)"

Remove-Item u022_tp.sf*
Remove-Item u022a?.sf*
Remove-Item u022e?.sf*
Remove-Item ru022a
Remove-Item ru022b
Remove-Item ru022
Remove-Item ru022mr

$pipedInput = @"
${1}
${2}
"@

$pipedInput | qtp++ $obj\u022a1

quiz++ $obj\r022

# save resubmit subfile for debugging purposes
Copy-Item u022a1.sf u022a1_resubmits.sf
Copy-Item u022a1.sfd u022a1_resubmits.sfd
Copy-Item u022a1_audit.sf u022a1_audit_resubmits.sf
Copy-Item u022a1_audit.sfd u022a1_audit_resubmits.sfd

qtp++ $obj\u022

Move-Item ru022a.txt ru022a
Move-Item ru022b.txt ru022b
Move-Item ru022.txt ru022
Move-Item ru022mr.txt ru022mr_before

#lp ru022
#lp ru022b
#lp ru022_sd
#lp ru022b_sd

Move-Item u020_tp.sf u022_tp.sf
Move-Item u020_tp.sfd u022_tp.sfd

Set-Location $pb_data
Remove-Item resubmit.required
Set-Location $application_production

##  regenerate ru022mr for correct report
$pipedInput = @"
exec $obj/r022a7
exec $obj/r022a8
exec $obj/r022a9
"@

$pipedInput | quiz++

Move-Item ru022mr.txt ru022mr

echo "ENDING RESUBMIT RUN$(udate)"
