#-------------------------------------------------------------------------------
# File 'web_create_claims.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'web_create_claims'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

# $cmd/web_create_claims 

echo "Start Time of $env:cmd\web_create_claims  is  $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

echo ""
echo "Running web_create_claims_new_susp ..."
echo ""

if ("$1" -eq "")
{
        echo "`a"
        echo ""
        echo "**ERROR**"
        echo "You must supply the 6 character date yymmdd for the files to created!"
        echo "Files created will be:  Wyymmdd.pr"
        echo "                               .hdr"
        echo "                               .dtl"
        echo "                               .des"
        echo ""
        exit
}

if (((Test-Path w${1}.pr) -and ((Get-Item w${1}.pr ).Length -gt 0 )) -or ((Test-Path w${1}.hdr) -and ((Get-Item `
  w${1}.hdr ).Length -gt 0 )) -or ((Test-Path w${1}.dtl) -and ((Get-Item w${1}.dtl ).Length -gt 0 )) -or ((Test-Path `
  w${1}.des) -and ((Get-Item w${1}.des ).Length -gt 0 )))
{
  echo "`a"
  echo ""
  echo "*WARNING*"
  echo "Files for w${1} already exist!"
  echo ""
  echo "If you continue the files will be overridden!"
  echo ""
  echo "Enter 'Ctrl-c' to stop this macro or 'enter' to continue"
  echo ""
  echo "Continue ?"
  $garbage = Read-Host
}

Remove-Item w${1}.pr *> $null
Remove-Item w${1}.hdr *> $null
Remove-Item w${1}.dtl *> $null
Remove-Item w${1}.des *> $null

$rcmd = $env:QTP + "load_f002_suspend_files"
Invoke-Expression $rcmd

echo "Create Web upload file of Priced Claims"
$rcmd = $env:QUIZ  + "rmaprice DISC_rmaprice.rf"
Invoke-Expression $rcmd

if ((Test-Path rmaprice.txt) -and ((Get-Item rmaprice.txt ).Length -gt 0 ))
{
  Move-Item -Force rmaprice.txt w${1}.pr
} else {
  echo "`a`a`a`a`a`a"
  echo "**ERROR** - something is wrong!! - no priced claims file found!"
}

echo "Create Web upload of updated 'visit' Headers - u716a\r716a ..."
$rcmd = $env:QTP + "u716a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r716a"
Invoke-Expression $rcmd
if ((Test-Path r716a.txt) -and ((Get-Item r716a.txt ).Length -gt 0 ))
{
  Move-Item -Force r716a.txt w${1}.hdr
}

echo "Create Web upload of updated 'visit' Details - r716b ..."
$rcmd = $env:QUIZ +"r716b"
Invoke-Expression $rcmd
if ((Test-Path r716b.txt) -and ((Get-Item r716b.txt ).Length -gt 0 ))
{
  Move-Item -Force r716b.txt w${1}.dtl
}

echo "Create Web upload of updated  'comments\descriptions'- r716c ..."
$rcmd = $env:QTP + "u716c"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r716c1"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r716c2"
Invoke-Expression $rcmd
if ((Test-Path r716c1.txt) -and ((Get-Item r716c1.txt ).Length -gt 0 ))
{
  Move-Item -Force r716c1.txt w${1}.des
}
if ((Test-Path r716c2.txt) -and ((Get-Item r716c2.txt ).Length -gt 0 ))
{
  echo "`a`a`a`a`a`a"
  echo "**ERROR** - some description text was TRUNCATED - review r716c2.txt!!"

  if ( $env:networkprinter -ne 'null'  )
  {
    Get-Content r716c2.txt | Out-Printer -Name $env:networkprinter
  }
}

echo ""
echo "File created are: "
Get-ChildItem w${1}.*
echo ""
echo ""


# run regular diskette suspend processing pgms
&$env:cmd\disk_create_claims "false"

echo ""
echo ""
echo "DONE !"
echo ""

echo "End   Time of $env:cmd\web_create_claims  is  $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
