#-------------------------------------------------------------------------------
# File 'mohd_part2.bk3.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'mohd_part2.bk3'
#-------------------------------------------------------------------------------


# macro: mohd_part2
# 2013/May/15 M.C. clone from agep_part2 for MOHD  

Get-Date

Set-Location $env:application_production\22

echo "Current Directory:"
Get-Location


echo ""
echo "execute powerhouse program u030b_part3_b.qtc  for MOHD payment creation"
echo ""

echo "Running u030b_part3_b.qtc ..."
&$env:QTP u030b_part3_b

echo ""
echo "execute powerhouse program r030k and r030l  for MOHD  payment reports"
echo ""
&$env:QUIZ r030k
&$env:QUIZ r030l
&$env:QUIZ r030m
&$env:QUIZ r030n
&$env:QUIZ r030q

Get-Content ru030n.txt | Add-Content ru030k.txt
Get-Content ru030n.txt | Add-Content ru030m.txt

Move-Item -Force ru030k.txt ru030k_mohd.txt
Move-Item -Force ru030l.txt ru030l_mohd.txt
Move-Item -Force ru030m.txt ru030m_mohd.txt
Move-Item -Force ru030n.txt ru030n_mohd.txt
Move-Item -Force ru030q.txt ru030q_mohd.txt

Get-Content ru030k_mohd.txt | Out-Printer
Get-Content ru030m_mohd.txt | Out-Printer
Get-Content ru030l_mohd.txt | Out-Printer

echo ""
echo "end of the run for MOHD payment PART 2"
echo ""
Get-Date
