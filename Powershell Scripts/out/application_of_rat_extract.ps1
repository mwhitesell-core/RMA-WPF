#-------------------------------------------------------------------------------
# File 'application_of_rat_extract.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'application_of_rat_extract'
#-------------------------------------------------------------------------------

echo ""

echo "**   APPLICATION OF OHIP REMITTANCE ADVICE TAPE   ** WITHOUT BACKUP"
echo ""
echo "-  W A R N I N G  -"
echo ""
echo "IF THIS IS THE 1ST PROCESSING OF THIS RAT TAPE"
echo "THEN CONVERT_RAT_TO_ASCII MUST BE RUN TO CONVERT"
echo "THE DISK FILE FROMEBCDIC TOASCII"
echo ""
echo "IF FILE HAS BEEN CONVERTED ONCE THEN  HIT   `"NEWLINE`"   TO CONTINUE ..."
 $garbage = Read-Host

echo ""
Set-Location $env:application_production

echo ""
echo "EXECUTE U030A.CB TO EXTRACT RECORDS INTO APPROPRIATE FILES"
echo "***  ENTER  2215  FOR CLINIC  22  ***"
echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

&$env:COBOL u030a

echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

echo ""
Set-Location $env:application_production\43

echo ""
echo "EXECUTE U030A.CB TO EXTRACT RECORDS INTO APPROPRIATE FILES"
echo "***  ENTER  H055  FOR CLINIC  43  ***"
echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

&$env:COBOL u030a

echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

echo ""
Set-Location $env:application_production\61

echo ""
echo "EXECUTE U030A.CB TO EXTRACT RECORDS INTO APPROPRIATE FILES"
echo "***  ENTER  9595  FOR CLINIC 61  ****"
echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

&$env:COBOL u030a

echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

echo ""
Set-Location $env:application_production\62

echo ""
echo "EXECUTE U030A.CB TO EXTRACT RECORDS INTO APPROPRIATE FILES"
echo "***  ENTER  9598  FOR CLINIC  62  ***"
echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

&$env:COBOL u030a

echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

echo ""
Set-Location $env:application_production\63

echo ""
echo "EXECUTE U030A.CB TO EXTRACT RECORDS INTO APPROPRIATE FILES"
echo "***  ENTER  9607  FOR CLINIC  63 ***"
echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

&$env:COBOL u030a

echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

echo ""
Set-Location $env:application_production\64

echo ""
echo "EXECUTE U030A.CB TO EXTRACT RECORDS INTO APPROPRIATE FILES"
echo "***  ENTER  9619  FOR CLINIC 64  ***"
echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

&$env:COBOL u030a

echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

echo ""
Set-Location $env:application_production\65

echo ""
echo "EXECUTE U030A.CB TO EXTRACT RECORDS INTO APPROPRIATE FILES"
echo "***  ENTER  9632  FOR CLINIC 65  ****"
echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

&$env:COBOL u030a

echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

echo ""
Set-Location $env:application_production\80

echo ""
echo "EXECUTE U030A.CB TO EXTRACT RECORDS INTO APPROPRIATE FILES"
echo "***  ENTER AA32  FOR CLINIC 80  ***"
echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

&$env:COBOL u030a

echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

echo ""

Set-Location $env:application_production\81

echo ""
echo "EXECUTE U030A.CB TO EXTRACT RECORDS INTO APPROPRIATE FILES"
echo "***  ENTER  AA03  FOR CLINIC 81  ****"
echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

&$env:COBOL u030a

echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

echo ""
Set-Location $env:application_production\82

echo ""
echo "EXECUTE U030A.CB TO EXTRACT RECORDS INTO APPROPRIATE FILES"
echo "***  ENTER  AA21  FOR CLINIC  CLINIC 82 ***"
echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

&$env:COBOL u030a

echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

echo ""
Set-Location $env:application_production\83

echo ""
echo "EXECUTE U030A.CB TO EXTRACT RECORDS INTO APPROPRIATE FILES"
echo "***  ENTER  AA25  FOR CLINIC  83 ***"
echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

&$env:COBOL u030a

echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

echo ""
Set-Location $env:application_production\84

echo ""
echo "EXECUTE U030A.CB TO EXTRACT RECORDS INTO APPROPRIATE FILES"
echo "***  ENTER  6072  FOR CLINIC  84  ***"
echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

&$env:COBOL u030a

echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

echo ""
Set-Location $env:application_production\90

echo ""
echo "EXECUTE U030A.CB TO EXTRACT RECORDS INTO APPROPRIATE FILES"
echo "***  ENTER  0000  FOR CLINIC  90 ***"
echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

&$env:COBOL u030a

echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

echo ""
Set-Location $env:application_production\91

echo ""
echo "EXECUTE U030A.CB TO EXTRACT RECORDS INTO APPROPRIATE FILES"
echo "***  ENTER  AA5V  FOR CLINIC  91 ***"
echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

&$env:COBOL u030a

echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

echo ""
Set-Location $env:application_production\92

echo ""
echo "EXECUTE U030A.CB TO EXTRACT RECORDS INTO APPROPRIATE FILES"
echo "***  ENTER  AA5W  FOR CLINIC  92 ***"
echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

&$env:COBOL u030a

echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

echo ""
Set-Location $env:application_production\93

echo ""
echo "EXECUTE U030A.CB TO EXTRACT RECORDS INTO APPROPRIATE FILES"
echo "***  ENTER  AA5X  FOR CLINIC  93 ***"
echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

&$env:COBOL u030a

echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

echo ""
Set-Location $env:application_production\94

echo ""
echo "EXECUTE U030A.CB TO EXTRACT RECORDS INTO APPROPRIATE FILES"
echo "***  ENTER  AA5V  FOR CLINIC  94 ***"
echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

&$env:COBOL u030a

echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

echo ""
Set-Location $env:application_production\95

echo ""
echo "EXECUTE U030A.CB TO EXTRACT RECORDS INTO APPROPRIATE FILES"
echo "***  ENTER  AA2K  FOR CLINIC  95 ***"
echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

&$env:COBOL u030a

echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

echo ""
Set-Location $env:application_production\96

echo ""
echo "EXECUTE U030A.CB TO EXTRACT RECORDS INTO APPROPRIATE FILES"
echo "***  ENTER  6317  FOR CLINIC  96 ***"
echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host

&$env:COBOL u030a

echo "HIT     `"NEWLINE`"      TO CONTINUE ..."
 $garbage = Read-Host
