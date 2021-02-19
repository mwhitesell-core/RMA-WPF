#-------------------------------------------------------------------------------
# File 'run_patient_purge.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
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

Set-Location $root\charly\purge

Get-Date

bcheck++ $pb_data\f010_pat_mstr  > f010_verify_before

Get-Date

echo ""
echo "Starting Time for Patient Purge$(udate)"
echo ""

echo "PROGRAM `"U099`" NOW LOADING ..."

echo ""
Get-Date
echo ""
$pipedInput = @"
exec  $obj/u099.qtc
20160101
exit
"@

$pipedInput | qtp++  > u099.log

quiz++ $obj\r099a
quiz++ $obj\r099b
quiz++ $obj\r099c
quiz++ $obj\r099d

Get-ChildItem ru099.txt

Get-Contents ru099.txt| Out-Printer
Get-Contents u099.log| Out-Printer

echo ""
echo "Ending   Time for Patient Purge$(udate)"
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

Set-Location $root\charly\rmabill\rmabill101c\data

## 2013/01/07 - MC1
##mv f010_pat_mstr      f010_pat_mstr_orig
##mv f010_pat_mstr.idx  f010_pat_mstr_orig.idx

Move-Item f010_pat_mstr $root\foxtrot\purge\f010_pat_mstr_orig
Move-Item f010_pat_mstr.idx $root\foxtrot\purge\f010_pat_mstr_orig.idx

Set-Location $pb_data

. .\createfiles.com

Get-Item f010* | % {$_.isreadonly = $false}

Move-Item f010_pat_mstr $root\charly\rmabill\rmabill101c\data\f010_pat_mstr
Move-Item f010_pat_mstr.idx $root\charly\rmabill\rmabill101c\data\f010_pat_mstr.idx

# CONVERSION WARNING; Symbolic link creation.
# ln -s /charly/rmabill/rmabill101c/data/f010_pat_mstr     f010_pat_mstr
# CONVERSION WARNING; Symbolic link creation.
# ln -s /charly/rmabill/rmabill101c/data/f010_pat_mstr.idx f010_pat_mstr.idx

echo ""
echo "Starting Time for Patient Recreate$(udate)"
echo ""
echo ""
echo "PROGRAM `"u080`" LOADING ..."


Set-Location $root\charly\purge

Remove-Item u080.log
$pipedInput = @"
exec     $obj/u080.qtc
exit
"@

$pipedInput | qtp++  >> u080.log

quiz++ $obj\r080  >> r080.log

Get-Contents u080.log| Out-Printer

echo ""

Get-Date

bcheck++ $pb_data\f010_pat_mstr  > f010_verify_after

Get-Date


echo ""
echo "Ending   Time for Patient Recreate$(udate)"
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
echo "Starting Time for UTL0012$(udate)"
echo ""


Set-Location $root\charly\purge

Remove-Item utl0012.log

echo "utl0012.com  -  STARTING -$(udate)"  > utl0012.log

quiz++ $obj\utl0012  >> utl0012.log

echo "utl0012 - ENDING -$(udate)"  >> utl0012.log

echo ""
echo "Ending   Time for UTL0012$(udate)"
echo ""

####################
