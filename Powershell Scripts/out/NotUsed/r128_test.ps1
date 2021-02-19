#-------------------------------------------------------------------------------
# File 'r128_test.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r128_test'
#-------------------------------------------------------------------------------

Remove-Item r128*.sf*, r128*.txt *> $null

Remove-Item $pb_data\tmp_counters_alpha*

$pipedInput = @"
create file tmp-counters-alpha
"@

$pipedInput | qutil++

&$env:QTP r128a
&$env:QUIZ r128b
&$env:QUIZ r128b_csv
