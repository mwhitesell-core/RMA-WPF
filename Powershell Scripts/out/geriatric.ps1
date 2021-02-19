#-------------------------------------------------------------------------------
# File 'geriatric.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'geriatric'
#-------------------------------------------------------------------------------

$rcmd = $env:QTP + "geriatric"
Invoke-Expression $rcmd

#CORE - RDL fix
cat geriatric2.ps -raw | %{$_.replace("`r`n", "`r")} > geriatric2.ps2
copy-item geriatric2.ps2 geriatric2.ps
remove-item geriatric2.ps2

$rcmd = $env:QUIZ + "geriatric"
Invoke-Expression $rcmd

