# u021.awk 
# called from u021.com
# builds com file to process a series of file thru u021a/u021 macros
# timeStamp of when job was run passed as parm variable
# 2003/oct/23 b.e. = original

param(
    [string]$OFILENAME,
    [string]$timeStamp
    )

$path = Convert-Path .

$debug = 0
$subDir = "u021_logs"
$cmdFilename = "$path/u021.tmp.com.ps1"

$intMonth = @{}
$intMonth["A"] = 1
$intMonth["B"] = 2
$intMonth["C"] = 3
$intMonth["D"] = 4
$intMonth["E"] = 5
$intMonth["F"] = 6
$intMonth["G"] = 7
$intMonth["H"] = 8
$intMonth["I"] = 9
$intMonth["J"] = 10
$intMonth["K"] = 11
$intMonth["L"] = 12

# separate filename into name.extension
$posPeriod = $OFILENAME.indexOf(".")
if ($posPeriod -eq 0) {
  $filename = $OFILENAME
  }

else {
  $filename = $OFILENAME.Substring(0,$posPeriod)
  $extension= $OFILENAME.Substring($posPeriod+1)
  }

if ($debug) {Write-Host "filname=$filename extension=$extension"}

$shouldBeE = $filename.Substring(0,1)
$month     = $filename.Substring(1,1)
$clinic    = $filename.Substring(2,4)
$restOfName= $filename.Substring(6)
if ($debug){Write-Host "$shouldBeE $month $clinic $restOfName"}
$buffer = ""
$buffer = $buffer + "echo `"processing file  ... $OFILENAME ..."+ (Get-Date -uformat %D) +"`"`n"
$buffer = $buffer + "Remove-Item u021a *> `$null`n"
$buffer = $buffer + "`n"
$buffer = $buffer + "Copy-Item $OFILENAME u021a`n"
$buffer = $buffer + "`$rcmd = `$env:COBOL + `"u021a $clinic "+$intMonth[$month]+" $OFILENAME Y`"`n"
$buffer = $buffer + "Invoke-Expression `$rcmd"
$buffer = $buffer + "`n"
$buffer = $buffer + "echo 'Done processing - $OFILENAME ... renaming as backup'`n"
$buffer = $buffer + "Move-Item $OFILENAME $subDir/$timeStamp/${OFILENAME}.done | Out-Null`n"
$buffer = $buffer + "echo `"`"`n"
$buffer = $buffer + "`n"
[System.IO.File]::AppendAllText($cmdFilename, $buffer)