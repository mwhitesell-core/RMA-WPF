#-------------------------------------------------------------------------------
# File 'letter_resubmit.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'letter_resubmit'
#-------------------------------------------------------------------------------

# letter_resubmit

echo "Submittingletter_resubmit to run IN BATCH !!"

Set-Location $env:application_production
Remove-Item resubmit.ls *> $null
&$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "letter_resubmit" -InitializationScript $init -ScriptBlock {
  & $env:cmd\elig_corrections_letters_resubmits *> resubmit.ls
}

echo "Done submittingletter_resubmit to batch"
