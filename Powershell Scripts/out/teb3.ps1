
#-------------------------------------------------------------------------------
# File 'teb3.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'teb3'
#-------------------------------------------------------------------------------

# teb3
#
# MODIFICATION HISTORY
# 04/jan/23  b.e.   -new 
# 15/Mar/24  MC1    - include the run of utl0201_f119.qtc and utl0201.qzu for 3 enviroments
#                     note that this program must be run after u090f.qts (after increasing current-ep-nbr + 1)
# 15/Jun/11  yas    - utl0201_a.txt =  "Highest MTD Payment Amount by Dept"  and 
#                     utl0201_b.txt =  "Highest different MTD in Payment Amount from LAST MONTH  by Dept"         
#                     $cmd/utl0020.com  is for the revenue reports
# 15/Aug/12  MC2    - include the run of r138_csv.qzc, r139_csv.qtc/qzc for 101c only
#                   - r138_csv.txt = Defict report for Ross
#                   - r139_csv.txt = INCEXP minus TOTDED not equal PAYEFT for pay code 2
# 15/Sep/22  MC3    - transfer the run of r128 here from $cmd/teb2
#                   - r128.txt = Inactive Doctor with no activity for last 3 ep nbr and has outstanding claim
#                                for dept 14 or 15 with pay code 2, this report is printed for Helena,
#                   - r128_csv.txt = Inactive Doctor with no activity for last 3 ep nbr and has outstanding claim,
#                     this should be run for 101c only as solo and mp has no claims
# 16/Mar/30  MC4   - include the run of r138_csv.qtc as part of r138_csv.txt

param(
  [string] $1,
  [string] $2
)

echo "Payroll teb3 - starting -"(Get-Date).ToString('yyyy-MM-dd 0:h:mm:ss')

echo "Running CLINIC:  $clinic_nbr"

#------------------------------------------------------------------
#MC1

# NOTE: clinic 22 - "normal" clinic 22 payroll
#       clinic 99 - "MP" / Manual Payments payroll
#       clinic 10 - "solo/solotest" payroll
#

echo "--- executing utl0201_f119.qtc  ---"

Set-Location $env:application_root\production

Remove-Item utl0201_f119.ps*, utl0201*.txt, utl0201.sf*  -EA SilentlyContinue

# If 101c, pass 101C 
if ($env:clinic_nbr -eq "22")
{
   $rcmd = $env:QTP + "utl0201_f119 101C" 
   invoke-expression $rcmd 
}
else
{
   # If MP, pass MP   
   if ($env:clinic_nbr -eq "99")
   {
      $rcmd = $env:QTP + "utl0201_f119 MP" 
      invoke-expression $rcmd 
   }
   else
   {
      # If solo, pass SOLO 
      if ($env:clinic_nbr -eq "10")
      {
         $rcmd = $env:QTP + "utl0201_f119 SOLO" 
         invoke-expression $rcmd 
      }
   }
}

$rcmd = $env:QUIZ + "utl0201_1" 
invoke-expression $rcmd 
$rcmd = $env:QUIZ + "utl0201_2" 
invoke-expression $rcmd 

#Core - Added to rename report according to quiz file
Get-Content utl0201_2.txt > utl0201_a.txt

$rcmd = $env:QUIZ + "utl0201_3" 
invoke-expression $rcmd 

#Core - Added to rename report according to quiz file
Get-Content utl0201_2.txt > utl0201_b.txt

if ( $env:networkprinter -ne 'null'  )
{
   Get-Content utl0201_a.txt | Out-Printer -Name $env:networkprinter
   Get-Content utl0201_b.txt | Out-Printer -Name $env:networkprinter
}

#------------------------------------------------------------------
if ($env:clinic_nbr -eq "22")
{
   Set-Location $env:application_production

   #MC3 - Inactive Doctors for last 3 ep nbr and have outstanding claims
   Remove-Item r128*.sf*, r128.txt, r128_csv.txt  -EA SilentlyContinue
   #Remove-Item $env:pb_data\tmp_counters_alpha* -EA SilentlyContinue

   <#$pipedInput = @"
   create file tmp-counters-alpha
   "@
   $pipedInput | qutil++#>

   $rcmd = $env:TRUNCATE+ "tmp_counters_alpha"
   Invoke-Expression $rcmd

   $rcmd = $env:QTP + "r128a"
   invoke-expression $rcmd

   $rcmd = $env:QUIZ + "r128b" 
   invoke-expression $rcmd

   #Core - Added to rename report according to quiz file
   Get-Content r128b.txt > r128.txt

   $rcmd = $env:QUIZ + "r128b_csv DISC_r128_csv.ff" 
   invoke-expression $rcmd 

   #Core - Added to rename report according to quiz file
   # gw2018. not needed with .ff option. Get-Content r128b_csv.txt > r128_csv.txt

   if ( $env:networkprinter -ne 'null'  )
   {
      Get-Content r128.txt | Out-Printer -Name $env:networkprinter
   }

   #MC2
   #MC4
   #rm r138_csv.txt r139*.sf* r139_csv.txt 1>/dev/null 2>&1
   Remove-Item r138*.sf*, r138_csv.txt, r139*.sf*, r139_csv.txt  -EA SilentlyContinue

   #####  Deficit Report
   #MC4
   $rcmd = $env:QTP + "r138_csv"
   invoke-expression $rcmd

   $rcmd = $env:QUIZ + "r138_csv DISC_r138_csv.ff" 
   invoke-expression $rcmd 

   #####  INCEXP minus TOTDED not equal to PAYEFT for pay code 2
   $rcmd = $env:QTP + "r139_csv"
   invoke-expression $rcmd

   $rcmd = $env:QUIZ + "r139_csv DISC_r139_csv.ff" 
   invoke-expression $rcmd 

   ##### Revenue Reports
   echo "--- utl0020 ---"

   $rcmd = $cmd + "\utl0020.com  >> teb_1.log  2>&1"
   invoke-expression $rcmd

   # MC3 - end
}

echo "Done!"
echo "Payroll teb3 -   ending -"(Get-Date).ToString('yyyy-MM-dd 0:h:mm:ss')
