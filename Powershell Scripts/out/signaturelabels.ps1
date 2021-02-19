#-------------------------------------------------------------------------------
# File 'signaturelabels.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'signaturelabels'
#-------------------------------------------------------------------------------

echo ""
echo "SELECT CLINIC NBR '22' OR '60 TO 65' OR '0' FOR ALL:"
$var0 = Read-Host
echo ""
echo "SELECT DEPT 1 TO 14 OR 0 FOR ALL:"
$var1 = Read-Host
echo ""
echo "SELECT '1' FULL OR '2' PART OR '3' CS OR '4' PS OR '0' FOR ALL:"
$var2 = Read-Host
echo ""
echo ""
echo "PLEASE SELECT ONE OF THE FOLLOWING SORT SEQUENCES"
echo "FOR DOCTOR SIGNATURE LABELS"
echo ""
echo ""
echo "1. SORT ON CLINIC (NUMERIC)"
echo "2. SORT ON CLINIC (ALPHA)"
echo ""
echo "3. SORT ON CLINIC ON DEPT (NUMERIC)"
echo "4. SORT ON CLINIC ON DEPT (ALPHA)"
echo ""
echo "5. SORT ON DEPT ON CLASS  (NUMERIC)"
echo "6. SORT ON DEPT ON CLASS  (ALPHA)"
echo ""
echo "7. SORT ON CLINIC ON DEPT ON CLASS (NUMERIC)"
echo "8. SORT ON CLINIC ON DEPT ON CLASS (ALPHA)"
echo ""
echo ""
echo "ENTER OPTION:"
$var3 = Read-Host
echo ""

if (-not(Test-Path $env:cmd\signaturelabels${var3}.ps1 ))
{
   echo "Invalid Option!`a"
   exit
}

&$env:cmd\signaturelabels${var3} $var0 $var1 $var2 $var3
