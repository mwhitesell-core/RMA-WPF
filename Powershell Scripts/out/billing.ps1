#-------------------------------------------------------------------------------
# File 'billing.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'billing'
#-------------------------------------------------------------------------------

echo ""
echo "ENTER TERM FROM DATE (YYYYMMDD) OR '0' FOR ALL: "
$var0 = Read-Host
$lenVar0 = "$($var0.length)"
if ($lenVar0 -ne 8)
{
  echo "`a`aERROR - you must enter 8 digit date!!!"
} else {
echo ""
echo "SELECT CLINIC NBR '22' OR '60 TO 65' OR '0' FOR ALL: "
$var1 = Read-Host
echo ""
echo "SELECT DEPT 1 TO 14 OR 0 FOR ALL: "
$var2 = Read-Host
echo ""
echo "SELECT '1' FULL OR '2' PART OR '3' CS OR '4' PS OR '0' FOR ALL: "
$var3 = Read-Host
echo ""
echo ""
echo "PLEASE SELECT ONE OF THE FOLLOWING SORT SEQUENCES"
echo "FOR BILLING LIST"
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
echo "7. SORT ON Doc number only (NUMERIC)      "
echo "8. SORT ON Doc Name only   (ALPHA)        "
echo ""
echo "9. SORT ON Dept ON Doc Name (ALPHA)        "
echo ""
echo "ENTER OPTION:"
$var4 = Read-Host
echo ""

if (-not(Test-Path $env:cmd\billing${var4}.ps1 ))
  {
    echo "Invalid Option!`a"
    exit
}

$rcmd = $env:cmd + "\billing${var4} $var0 $var1 $var2 $var3 $var4"
invoke-expression $rcmd

}
