#-------------------------------------------------------------------------------
# File 'letters_eligibility_info_wrong.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'letters_eligibility_info_wrong'
#-------------------------------------------------------------------------------

# letters_eligbility_info_wrong
# 00/sep/22 B.E. - allow only 5 doctors to appear on letters. Renamed
#                  r085c.qzs to r085e.qzs and added u085c/d.qts
# 02/nov/18 B.E. - added delete of r085e.txt before running
# 04/feb/24 M.C. - transfer the calls of $cmd/f086patid and $cmd/f086a_origpatid
#                  to $cmd/process_elig_corrected_patients
# 10/may/26 brad1 - comment out r085e.qzc and move that pgm into new macro print_elig_letters
# 10/jul/14 MC1   - comment out u085.qtc  and move that pgm into new macro print_elig_letters 

# Note: This macro called by letters_resubmit 

echo "Runningletters_eligbility_info_wrong ..."

#Core - Commented out, files are in database
#Set-Location $env:pb_data
#Remove-Item f085_backup_10*
#Move-Item -Force f085_backup_09 f085_backup_10
#Move-Item -Force f085_backup_09.idx f085_backup_10.idx
#Move-Item -Force f085_backup_08 f085_backup_09
#Move-Item -Force f085_backup_08.idx f085_backup_09.idx
#Move-Item -Force f085_backup_07 f085_backup_08
#Move-Item -Force f085_backup_07.idx f085_backup_08.idx
#Move-Item -Force f085_backup_06 f085_backup_07
#Move-Item -Force f085_backup_06.idx f085_backup_07.idx
#Move-Item -Force f085_backup_05 f085_backup_06
#Move-Item -Force f085_backup_05.idx f085_backup_06.idx
#Move-Item -Force f085_backup_04 f085_backup_05
#Move-Item -Force f085_backup_04.idx f085_backup_05.idx
#Move-Item -Force f085_backup_03 f085_backup_04
#Move-Item -Force f085_backup_03.idx f085_backup_04.idx
#Move-Item -Force f085_backup_02 f085_backup_03
#Move-Item -Force f085_backup_02.idx f085_backup_03.idx
#Move-Item -Force f085_backup_01 f085_backup_02
#Move-Item -Force f085_backup_01.idx f085_backup_02.idx
#Copy-Item f085_rejected_claims f085_backup_01
#Copy-Item f085_rejected_claims.idx f085_backup_01.idx

##  $cmd/f086patid  - transfer to $cmd/process_elig_corrected_patients
##  $cmd/f086a_origpatid - transfer to $cmd/process_elig_corrected_patients

Set-Location $env:application_production

Remove-Item r085?.txt *> $null
Remove-Item r086.txt *> $null
Remove-Item r087.txt *> $null

echo " Running r085a $Env:root\ u085b $Env:root\r085c $Env:root\ r086 $Env:root\ r087  ..."
#quiz auto=$obj/r085.qzc - replaced by r085a/r085b

$rcmd = $env:QUIZ + "r085a"
Invoke-Expression $rcmd
#quiz auto=$obj/r085b.qzc - replaced by u085b/r085c
$rcmd = $env:QTP + "u085b"
Invoke-Expression $rcmd
#quiz auto=$obj/r085c.qzc 00/sep/22 B.E.
$rcmd = $env:QTP + "u085c"
Invoke-Expression $rcmd
$rcmd = $env:QTP + "u085d"
Invoke-Expression $rcmd
# brad1 quiz auto=$obj/r085e.qzc

$rcmd = $env:QUIZ + "r086"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r087"
Invoke-Expression $rcmd

#MC1 - comment out update to f010
##echo "Running u085 ..." 
##qtp  auto=$obj/u085.qtc

if ( $env:networkprinter -ne 'null'  )
{
   Get-Content r086.txt | Out-Printer -Name $env:networkprinter
   Get-Content r087.txt | Out-Printer -Name $env:networkprinter
}

echo "Doneletters_eligbility_info_wrong"
