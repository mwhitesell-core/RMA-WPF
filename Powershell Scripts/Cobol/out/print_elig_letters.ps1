#-------------------------------------------------------------------------------
# File 'print_elig_letters.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'print_elig_letters'
#-------------------------------------------------------------------------------

# print_elig_letters 
# 2010/may/26 brad  - generated and prints patient letters except those that have been 'logically' deleted
# 2010/Jul/14 MC1   - update f010 for letter sent after printing letters to patient 
# 2011/Mar/08 MC2   - qutil tmp-counters file, run u085.qtc before r085e_?.qzc, add to run u085e.qtc afterward
#                     save the subfile u085e_savef010.sf by renaming to the run date
# 2011/Apr/04 MC3   - include the new program r085e_3.qzc 
#                     save the subfile r085e.sf instead of u085e_savef010.sf by copying with the run date
#                     also save r085e.txt by copying with the run date


echo "Runningprint_elig_letters ..."

Set-Location $pb_data
Remove-Item ohip_run_dates_backup_10*
Move-Item ohip_run_dates_backup_09.dat ohip_run_dates_backup_10.dat
Move-Item ohip_run_dates_backup_09.idx ohip_run_dates_backup_10.idx
Move-Item ohip_run_dates_backup_08.dat ohip_run_dates_backup_09.dat
Move-Item ohip_run_dates_backup_08.idx ohip_run_dates_backup_09.idx
Move-Item ohip_run_dates_backup_07.dat ohip_run_dates_backup_08.dat
Move-Item ohip_run_dates_backup_07.idx ohip_run_dates_backup_08.idx
Move-Item ohip_run_dates_backup_06.dat ohip_run_dates_backup_07.dat
Move-Item ohip_run_dates_backup_06.idx ohip_run_dates_backup_07.idx
Move-Item ohip_run_dates_backup_05.dat ohip_run_dates_backup_06.dat
Move-Item ohip_run_dates_backup_05.idx ohip_run_dates_backup_06.idx
Move-Item ohip_run_dates_backup_04.dat ohip_run_dates_backup_05.dat
Move-Item ohip_run_dates_backup_04.idx ohip_run_dates_backup_05.idx
Move-Item ohip_run_dates_backup_03.dat ohip_run_dates_backup_04.dat
Move-Item ohip_run_dates_backup_03.idx ohip_run_dates_backup_04.idx
Move-Item ohip_run_dates_backup_02.dat ohip_run_dates_backup_03.dat
Move-Item ohip_run_dates_backup_02.idx ohip_run_dates_backup_03.idx
Move-Item ohip_run_dates_backup_01.dat ohip_run_dates_backup_02.dat
Move-Item ohip_run_dates_backup_01.idx ohip_run_dates_backup_02.idx
Copy-Item ohip_run_dates.dat ohip_run_dates_backup_01.dat
Copy-Item ohip_run_dates.idx ohip_run_dates_backup_01.idx

#########

# 2011/03/08 - MC2
Remove-Item tmp_counters.*

$pipedInput = @"
create file tmp-counters
"@

$pipedInput | qutil++

# 2011/03/08 - end

Set-Location $application_production

# 2011/03/08 - MC2
echo "Running u085 ...to update tmp-counters"
$pipedInput = @"
exec $obj/u085.qtc
"@

$pipedInput | qtp++

# 2011/03/08 - end

################

Remove-Item r085e.txt  > $null

echo " Running r085e  ..."
$pipedInput = @"
#exec $obj/r085e_1.qzc
#exec $obj/r085e_2.qzc
#exec $obj/r085e_3.qzc
$rcmd = $env:QUIZ + "r085e_1"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r085e_2"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r085e_3 DISC_r085e"
Invoke-Expression $rcmd
"@

$pipedInput | quiz++

# r085e.txt

$timeStamp = "20$(Get-Date -uformat `"%y_%m_%d.%H:%M`")"

Copy-Item r085e.txt r085e_$timeStamp.txt
Copy-Item r085e.sf r085e_$timeStamp.sf
Copy-Item r085e.sfd r085e_$timeStamp.sfd

################


# 2011/03/08 - MC2
echo ""
echo "Running u085e ...to update patient mstr"
$pipedInput = @"
exec $obj/u085e.qtc
"@

$pipedInput | qtp++


# 2011/03/08 - end

echo "Doneprint_elig_letters"
