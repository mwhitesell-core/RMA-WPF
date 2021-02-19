#-------------------------------------------------------------------------------
# File 'brad_elig.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'brad_elig'
#-------------------------------------------------------------------------------

# print_elig_letters 
# 2010/may/26 brad  - generated and prints patient letters except those that have been 'logically' deleted
# 2010/Jul/14 MC1   - update f010 for letter sent after printing letters to patient 
# 2011/Mar/08 MC2   - qutil tmp-counters file, run u085.qtc before r085e_?.qzc, add to run u085e.qtc afterward
#                     save the subfile u085ie_savef010.sf by renaming to the run date

echo "Runningprint_elig_letters ..."

#########

Set-Location $env:application_production

# 2011/03/08 - MC2
Remove-Item tmp_counters.*

$pipedInput = @"
create file tmp-counters
"@

$pipedInput | qutil++

# 2011/03/08 - end


# 2011/03/08 - MC2
echo "Running u085 ...to update tmp-counters"
&$env:QTP u085

# 2011/03/08 - end

################

Remove-Item r085e.txt *> $null

echo " Running r085e  ..."
&$env:QUIZ r085e_1
&$env:QUIZ r085e_2
