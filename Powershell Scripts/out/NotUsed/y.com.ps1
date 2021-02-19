#-------------------------------------------------------------------------------
# File 'y.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'y.com'
#-------------------------------------------------------------------------------


echo "removing duplicates from u140_d1 subfile"
&$env:QTP u140_d1_remove_dups
Move-Item -Force u140_d1.sf u140_d1_with_dups.sf
Move-Item -Force u140_d1.sfd u140_d1_with_dups.sfd

Move-Item -Force u140_d2.sf u140_d1.sf
Move-Item -Force u140_d2.sfd u140_d1.sfd

echo "ensure that all docs in u140_d1 are also in f075"
echo "running u140_f.qtc"
&$env:QTP u140_f

echo "run reports"
# run reports
&$env:cmd\r140_reports

echo "Entering `'upload`' directory"
Set-Location $application_upl ; Get-Location

Get-ChildItem r140_a1f.txt, r140_a2g.txt, r140_a2s.txt, r140_a3c.txt, r140_a4t.txt, r140_a.txt, r140_a.txt, r140_b.txt
echo ""
echo ""
echo "Confirm the above reports are correct and then complete this process"
echo "by runningu140_stage4"
echo ""
echo "Done!"
