#-------------------------------------------------------------------------------
# File 't4a_addrlabels.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 't4a_addrlabels'
#-------------------------------------------------------------------------------

echo ""
echo "SELECT ADDRESS: '1' FOR OFFICE OR '2' FOR HOME"
$var5 = Read-Host
echo ""
echo "SELECT CLINIC NUMBER '22' OR '60 TO 65' OR '0' FOR ALL:"
$var0 = Read-Host
echo ""
echo "SELECT DEPT. 1 TO 14 OR 0 FOR ALL:"
$var1 = Read-Host
echo ""
echo "SELECT '1' FULL OR '2' PART OR '3' CS OR '4' PS OR '0' FOR ALL:"
$var2 = Read-Host
echo ""
echo "SELECT '1' RMA  OR '2' RMAINC OR '0' FOR ALL:"
$var6 = Read-Host
echo ""
echo ""
echo "PLEASE SELECT ONE OF THE FOLLOWING SORT SEQUENCES"
echo "FOR ADDRESS LABELS"
echo ""
echo ""
echo "1. SORT ON CLINIC    \(NUMERIC\)"
echo "2. SORT ON CLINIC    \(ALPHA\)"
echo ""
echo "3. SORT ON CLINIC ON DEPT    \(NUMERIC\)"
echo "4. SORT ON CLINIC ON DEPT    \(ALPHA\)"
echo ""
echo "5. SORT ON DEPT ON CLASS     \(NUMERIC\)"
echo "6. SORT ON DEPT ON CLASS     \(ALPHA\)"
echo ""
echo "7. SORT ON CLINIC ON DEPT ON CLASS    \(NUMERIC\)"
echo "8. SORT ON CLINIC ON DEPT ON CLASS    \(ALPHA\)"
echo ""
echo ""
echo "ENTER OPTION:"
$var3 = Read-Host
echo ""

if (-not(Test-Path $env:cmd\t4a_addrlabels${var3}.ps1 ))
{
        echo "Invalid Option!`a"
        exit
}

&$env:cmd\t4a_addrlabels${var3} $var5 $var0 $var1 $var2 $var6 $var3
