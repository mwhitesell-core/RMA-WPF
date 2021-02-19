#-------------------------------------------------------------------------------
# File 'addrlabels2.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'addrlabels2'
#-------------------------------------------------------------------------------

&$env:QUIZ addrlabels `
  ";and select if doc-date-fac-term >= 20020101 and doc-date-fac-term <= 20021231 sort on doc-clinic-nbr on doc-name on doc-inits" `
  ${1} ${2} ${3} ${4}
