#-------------------------------------------------------------------------------
# File 'rerun_68_69.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'rerun_68_69'
#-------------------------------------------------------------------------------

Set-Location $Env:root\charly\purge

echo "Starting split subfile to 68 & 69   Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

&$env:QTP extract_68_69

echo "Ending   split subfile to 68 & 69   Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

#######################################################
# save the original subfiles
Move-Item -Force u072-retain-claim-hdr.sf u072-retain-claim-hdr-orig.sf
Move-Item -Force u072-retain-claim-hdr.sfd u072-retain-claim-hdr-orig.sfd
Move-Item -Force u072-delete-claim-hdr.sf u072-delete-claim-hdr-orig.sf
Move-Item -Force u072-delete-claim-hdr.sfd u072-delete-claim-hdr-orig.sfd

echo "Starting r072_68 to r072_69 reports Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

Copy-Item u072-retain-claim-hdr-68.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-68.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 68
&$env:QUIZ r072b 68
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_68
Remove-Item r072?.txt
#lp r072_68


Copy-Item u072-retain-claim-hdr-69.sf u072-retain-claim-hdr.sf
Copy-Item u072-delete-claim-hdr-69.sf u072-delete-claim-hdr.sf

&$env:QUIZ r072a 69
&$env:QUIZ r072b 69
&$env:QUIZ r072c
&$env:QUIZ r072d
&$env:QUIZ r072e

Get-Content r072a.txt, r072b.txt, r072c.txt | Set-Content r072_69
Remove-Item r072?.txt
#lp r072_69

echo "Ending   r072_68 to r072_69 reports Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

#  rename the original subfiles

Move-Item -Force u072-retain-claim-hdr-orig.sf u072-retain-claim-hdr.sf
Move-Item -Force u072-retain-claim-hdr-orig.sfd u072-retain-claim-hdr.sfd
Move-Item -Force u072-delete-claim-hdr-orig.sf u072-delete-claim-hdr.sf
Move-Item -Force u072-delete-claim-hdr-orig.sfd u072-delete-claim-hdr.sfd
