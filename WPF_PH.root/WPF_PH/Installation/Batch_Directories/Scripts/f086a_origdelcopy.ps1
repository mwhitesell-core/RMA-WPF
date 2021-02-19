#-------------------------------------------------------------------------------
# File 'f086a_origdelcopy.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'f086a_origdelcopy'
#-------------------------------------------------------------------------------

# f086a_origdelcopy
# 00/oct/16 B.E. - added code to keep 5 backups of files

Remove-Item f086a_orig_new_pat_ids_bkp_5.dat *> $null
Move-Item -Force f086a_orig_new_pat_ids_bkp_4.dat f086a_orig_new_pat_ids_bkp_5.dat
Move-Item -Force f086a_orig_new_pat_ids_bkp_3.dat f086a_orig_new_pat_ids_bkp_4.dat
Move-Item -Force f086a_orig_new_pat_ids_bkp_2.dat f086a_orig_new_pat_ids_bkp_3.dat
Move-Item -Force f086a_orig_new_pat_ids_bkp.dat f086a_orig_new_pat_ids_bkp_2.dat
Copy-Item f086a_orig_new_pat_ids.dat f086a_orig_new_pat_ids_bkp.dat

Remove-Item f086a_orig_new_pat_ids.dat

#<#$pipedInput = @"
#create file f086a-orig-new-pat-ids
#"@

#$pipedInput | qutil++#>
#$rcmd = $env:TRUNCATE + "f086a_orig_new_pat_ids"
#Invoke-Expression $rcmd

#Remove-Item f086a_orig_new_pat_ids.dat

New-Item -Path . -Name "f086a_orig_new_pat_ids.dat" -ItemType "file"

Get-Item f086a_orig_new_pat_ids.dat | % {$_.isreadonly = $false}
