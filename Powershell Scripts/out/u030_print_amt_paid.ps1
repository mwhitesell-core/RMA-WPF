#-------------------------------------------------------------------------------
# File 'u030_print_amt_paid.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'u030_print_amt_paid'
#-------------------------------------------------------------------------------

# macro: u030_print_amt_paid
# 08/aug/14 M.C. print doctor amt paid for claims that were entered prior 20080624
#                for clinics 31-36 & 41-48

Set-Location $env:application_production\clinic_31_to_48

Get-Content ..\31\u030_tape_145_file.dat, ..\32\u030_tape_145_file.dat, ..\33\u030_tape_145_file.dat, `
  ..\34\u030_tape_145_file.dat, ..\35\u030_tape_145_file.dat, ..\36\u030_tape_145_file.dat, `
  ..\41\u030_tape_145_file.dat, ..\42\u030_tape_145_file.dat, ..\43\u030_tape_145_file.dat, `
  ..\44\u030_tape_145_file.dat, ..\45\u030_tape_145_file.dat, ..\46\u030_tape_145_file.dat, `
  ..\47\u030_tape_145_file.dat, ..\48\u030_tape_145_file.dat | Set-Content u030_tape_145_file.dat



echo ""
echo "execute powerhouse program u030p.qtc  for Amt paid"
echo ""

echo "Running u030p.qtc ..."
&$env:QTP u030p


echo "Running r030p.qtc ..."
&$env:QUIZ r030p

#Core - Added to rename report according to quiz file
Get-Content r030p.txt > ru030p.txt

if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030p.txt | Out-Printer -Name $env:networkprinter
}

echo ""
echo "end of the run for u030_print_amt_paid"
echo ""
Get-Date
