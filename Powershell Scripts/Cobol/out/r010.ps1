#-------------------------------------------------------------------------------
# File 'r010.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'r010'
#-------------------------------------------------------------------------------

# 
# 98/jun/29 B.E.        added delete of u010_out_file after processing
# 2001/oct/17 M.C.      convert r010 from cobol to powerhouse  
#

echo "R010 BEGINNING$(udate)"

echo "Running r010cycle ..."
Set-Location $application_production

Move-Item r010daily_cycle.sf r010cycle.sf
Copy-Item r010daily.sfd r010cycle.sfd
Move-Item extf001aa_cycle.sf extf001aacycle.sf
Copy-Item extf001aa.sfd extf001aacycle.sfd
Move-Item extf001_cycle.sf extf001cycle.sf
Copy-Item extf001.sfd extf001cycle.sfd

quiz++ $obj\r010cycle  >> r010cycle.log

#lp r010cycle.txt

echo "R010 ENDING$(udate)"
