#-------------------------------------------------------------------------------
# File 'run_patient_purge.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_patient_purge'
#-------------------------------------------------------------------------------

#  2011/Mar/03 M.C. - run_patient_purge requested by Yasemin to run 4 macros
#                     $cmd/patient_purge, $cmd/pat_mstr_recreate. $cmd/u920.com, $cmd/utl0012.com
#                     from /charly/purge
#  2013/Jan/07 MC1  - move original file to /foxtrot/purge to be consistent with others
#  2013/Mar/09 yas  - ******** DO NOT run $cmd/u920.com .. we only need to run it with the claims purge

echo "PATIENT_PURGE"
echo ""
echo "PATIENT FILE PURGE STAGE # 1"
echo "NOTE -- THE Backup MUST HAVE BEEN RUN !!!"
echo ""

Set-Location \\$env:root\charly\purge

Get-Date

# CONVERSION ERROR (expected, #17): bcheck.
# bcheck -n $env:pb_data/f010_pat_mstr > f010_verify_before

Get-Date

echo ""
echo "Starting Time for Patient Purge $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
echo ""

echo "PROGRAM `"U099`" NOW LOADING ..."

echo ""
Get-Date
echo ""
$rcmd = $env:QTP + "u099 20160101" > u099.log
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r099a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r099b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r099c"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r099d"
Invoke-Expression $rcmd
#Core - Added to rename report according to quiz file
Get-Content r099d.txt > ru099.txt

Get-ChildItem ru099.txt

if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru099.txt | Out-Printer -Name $env:networkprinter
   Get-Content u099.log | Out-Printer -Name $env:networkprinter
}

echo ""
echo "Ending   Time for Patient Purge $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
echo ""

##########################


#    "PAT_MSTR_RECREATE"
echo ""
echo "PATIENT FILE PURGE STAGE" # 2
echo "NOTE -- THE PREVIOUS STAGES MUST HAVE BEEN RUN !!!"
echo ""
echo "SAVE THE ORIGINAL PATIENT UNDERORIG FILENAME"
echo ""
echo ""

Set-Location $Env:root\charly\rmabill\rmabill${env:RMABILL_VERS}\data

## 2013/01/07 - MC1
##mv f010_pat_mstr      f010_pat_mstr_orig
##mv f010_pat_mstr.idx  f010_pat_mstr_orig.idx

Move-Item -Force f010_pat_mstr \\$env:root\foxtrot\purge\f010_pat_mstr_orig
Move-Item -Force f010_pat_mstr.idx \\$env:root\foxtrot\purge\f010_pat_mstr_orig.idx

Set-Location $env:pb_data

. .\createfiles.com

Get-Item f010* | % {$_.isreadonly = $false}

Move-Item -Force f010_pat_mstr \\$env:root\charly\rmabill\rmabill101c\data\f010_pat_mstr
Move-Item -Force f010_pat_mstr.idx \\$env:root\charly\rmabill\rmabill101c\data\f010_pat_mstr.idx

# CONVERSION ERROR (expected, #80): Symbolic link creation.
# ln -s /charly/rmabill/rmabill101c/data/f010_pat_mstr     f010_pat_mstr
# CONVERSION ERROR (expected, #81): Symbolic link creation.
# ln -s /charly/rmabill/rmabill101c/data/f010_pat_mstr.idx f010_pat_mstr.idx

echo ""
echo "Starting Time for Patient Recreate $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
echo ""
echo ""
echo "PROGRAM `"u080`" LOADING ..."


Set-Location \\$env:root\charly\purge

Remove-Item u080.log
$rcmd = $env:QTP + "u080" >> u080.log
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r080" >> r080.log
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r080.txt > ru080.txt

if ( $env:networkprinter -ne 'null'  )
{
   Get-Content u080.log | Out-Printer -Name $env:networkprinter
}

echo ""

Get-Date

# CONVERSION ERROR (expected, #106): bcheck.
# bcheck -n $env:pb_data/f010_pat_mstr > f010_verify_after

Get-Date


echo ""
echo "Ending   Time for Patient Recreate $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
echo ""


####################

#    "utl0012.com"
echo ""
echo "PATIENT FILE PURGE STAGE" # 3
echo "NOTE -- THE PREVIOUS STAGES MUST HAVE BEEN RUN !!!"
echo ""
echo "Check if any claims without patient information"
echo ""

echo ""
echo "Starting Time for UTL0012  $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
echo ""


Set-Location \\$env:root\charly\purge

Remove-Item utl0012.log

echo "utl0012.com  -  STARTING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" > utl0012.log

$rcmd = $env:QUIZ + "utl0012_a" >> utl0012.log
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "utl0012_b" >> utl0012.log
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content utl0012_b.txt > utl0012.txt

echo "utl0012 - ENDING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" >> utl0012.log

echo ""
echo "Ending   Time for UTL0012  $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
echo ""

####################
