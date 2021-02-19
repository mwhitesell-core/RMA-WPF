#-------------------------------------------------------------------------------
# File 'suspend_clinicare_dtl.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'suspend_clinicare_dtl'
#-------------------------------------------------------------------------------

Remove-Item suspdtl.txt *> $null
&$env:QTP suspdtl
&$env:QUIZ suspend_clinicare_dtl
&$env:QUIZ suspend_agent
&$env:QUIZ dump_tech
&$env:QUIZ suspend_desc
&$env:QUIZ suspend_suffix
