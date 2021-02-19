# file: u141.awk 
# creates a fixed length file of a csv file

param(
[string]$infile,
[string]$outfile
)


function global:processClinic {
param(
[string]$tmpClinic
)
 $lengthField = $tmpClinic.length 
 if ($lengthField -gt 2) {
   $tmpClinic = $tmpClinic.Substring(0,2)
 } elseif ($lengthField -lt 2 ) {
   $tmpClinic = $tmpClinic.PadLeft(2,'0')
 }
 $global:fieldClinic= $tmpClinic
}

function global:processAgent {
param(
[string]$tmpAgent
)
 $lengthField =$tmpAgent.length 
 if ($lengthField -gt 1) {
   $tmpAgent = $tmpAgent.Substring(0,1)
 } elseif ($lengthField -le 1 ) {
   $tmpAgent = $tmpAgent.PadLeft(1,'0')
 }
 $global:fieldAgent=$tmpAgent
}

function global:processDocNbr
{
param(
[string]$tmpDocNbr
)
 $lengthField = $tmpDocNbr.length 
 if ($lengthField -gt 3) {

   $tmpDocNbr = $tmpDocNbr.Substring(0,3)
 } elseif ($lengthField -lt 3 ) {
   $tmpDocNbr = $tmpDocNbr.PadLeft(3,'0')
 }
 $global:fieldDocNbr=$tmpDocNbr
}


function global:processDocSurname {
param(
[string]$tmpDocSurname
)
 $lengthField = $tmpDocSurname.length
 if ($lengthField -gt 24) {
   $tmpDocSurname = $tmpDocSurname.Substring(0,24)
 }
 $global:fieldDocSurname = $tmpDocSurname
}

function global:processAmt
{
param(
[string]$tmpAmt
)
# (if negative number remove '-' to process number and the add it back
#  as a leading dash when processing finished)
 $negativeNbr = $tmpAmt.IndexOf("-")
 if ($negativeNbr -ne -1)  {
   if (0) { echo "Neg BEFORE=$tmpAmt`n" }
   $tmpAmt = $tmpAmt.Substring(1,$tmpAmt.length - 1)
   if (0) { echo "Neg AFTER1=$tmpAmt`n" }
 }

 # remove trailing spaces, if there are any
 $tmpAmt = $tmpAmt.TrimEnd()

 # (ensure 2 decimal digits after the decimal point - otherwise pad with trailing zero)
 $decimalPosition = $tmpAmt.IndexOf(".")
 $lengthField = $tmpAmt.length
 $diff = $lengthField - $decimalPosition 
 
 if ($debug1) { echo "LENGTHFIELD=$lengthField`n" }
 if ($debug1) { echo "DECIMALPOSITION=$decimalPosition`n" }
 if ($debug1) { echo "DIFF=$diff`n" }
 if ($debug1) { echo "Amt BEFORE=$tmpAmt`n" }
 if ($decimalPosition -eq -1) {
   # (no decimal positions - add 2 trailing zeros for pennies)
   $tmpAmt = $tmpAmt+"00"
 } elseif ($diff -eq 3){
     $tmpAmt = $tmpAmt.Substring(0,$decimalPosition) + $tmpAmt.Substring($decimalPosition + 1,2)
 } elseif ($diff -eq 2){
     $tmpAmt = $tmpAmt.Substring(0,$decimalPosition) + $tmpAmt.Substring($decimalPosition + 1,1) + "0"
 } elseif ($diff -eq 1){
     $tmpAmt = $tmpAmt.Substring(0,$decimalPosition) + "00"
 }

 if ($debug1) { echo "Amt AFTER = $tmpAmt`n"}
#this test changed from 8 to 9 with change to 1M$ amounts in payroll
 if ($lengthField -gt 9) {
   $tmpAmt = $tmpAmt.Substring(0,9)
 }

 if ($negativeNbr -ne -1)  {
   $global:lastDigit = $tmpAmt.Substring($tmpAmt.length - 1 , 1)
   getOverPunchedLastDigit 
   $tmpAmt = $tmpAmt.Substring(0,$tmpAmt.Length - 1)+ $global:lastDigit
 }
 $global:fieldAmt = $tmpAmt
}


function global:processOmaCode
{
 param(
 [string]$tmpOmaCode
 )

 $lengthField = $tmpOmaCode.Length
  
 if ($lengthField -gt 4) {
   $tmpOmaCode= $tmpOmaCode.Substring(0,4)
 }
 $global:fieldOmaCode= $tmpOmaCode
}


function global:processReference
{
 param(
 [string]$tmpReference
 )
 $lengthField = $tmpReference.Length 
 if ($lengthField -gt 11) {
   $tmpReference = $tmpReference.Substring(0,11)
 }
 $global:fieldReference = $tmpReference
}

function global:processBypass
{
param(
[string]$tmpByPass
)
 $lengthField = $tmpBypass.Length 
 if ($lengthField -gt 6) {
   $tmpBypass = $tmpBypass.Substring(0,6)
 }
 elseif($lengthField -eq 0) {
    $tmpByPass = "      "
 }
 $global:fieldBypass = $tmpBypass
}


function global:getOverPunchedLastDigit
{
  if       ($global:lastDigit -eq "0") {$global:lastDigit = "p" }
  else {if ($global:lastDigit -eq "1") {$global:lastDigit = "q" }
  else {if ($global:lastDigit -eq "2") {$global:lastDigit = "r" }
  else {if ($global:lastDigit -eq "3") {$global:lastDigit = "s" }
  else {if ($global:lastDigit -eq "4") {$global:lastDigit = "t" }
  else {if ($global:lastDigit -eq "5") {$global:lastDigit = "u" }
  else {if ($global:lastDigit -eq "6") {$global:lastDigit = "v" }
  else {if ($global:lastDigit -eq "7") {$global:lastDigit = "w" }
  else {if ($global:lastDigit -eq "8") {$global:lastDigit = "x" }
  else {if ($global:lastDigit -eq "9") {$global:lastDigit = "y" }
       }
       }
       }
       }
       }
       }
       }
       }
       }
}

$debug=0
$debug1=0

$read = New-Object System.IO.StreamReader($infile)
$write = New-Object System.IO.StreamWriter($outfile)
# MAIN
while($line = $read.ReadLine()) {
    if ($line.length -eq 0 ) {
        $line = $read.ReadLine()
    } 

    $global:fieldClinic=""
    $global:fieldAgent=""
    $global:fieldDocNbr=""
    $global:fieldDocSurname=""
    $global:fieldDocInits=""
    $global:fieldDocGivenNames=""
    $global:fieldAmt=""
    $global:fieldOmaCode=""
    $global:fieldReference=""
    $global:fieldBypass=""

    if ($debug1) { $len = $0.length ;echo "LENGTH 0$=$len `n"}
    if ($debug1) { echo "0$=$0 `n"}
    if ($debug1) { echo "$1 `n"}
    if ($debug1) { echo "$2 `n"}
    if ($debug1) { echo "$3 `n"}
    if ($debug1) { echo "$4 `n"}
    if ($debug1) { echo "$5 `n"}
    if ($debug1) { echo "$6 `n"}
    if ($debug1) { echo "$7 `n"}
    if ($debug1) { echo "$8 `n"}
    $split = $line.split(",")

    $1 = $split[0]
    $2 = $split[1]
    $3 = $split[2]
    $4 = $split[3]
    $5 = $split[4]
    $6 = $split[5]
    $7 = $split[6]
    $8 = $split[7]

    processClinic $1
    processAgent $2
    processDocNbr $3
    processDocSurname $4
    processAmt $5
    processOmaCode $6
    processReference $7
    processBypass $8

    #printf "%-2s!%-1s!%-3s!%-24s!%-4s!%9.9s!%-11s!%-6s!\n",fieldClinic,fieldAgent,fieldDocNbr,fieldDocSurname,fieldOmaCode,fieldAmt,fieldReference,fieldBypass
    $write.WriteLine($fieldClinic.PadRight(2," ") + "!" + $fieldAgent.PadRight(1," ") + "!" + $fieldDocNbr.PadRight(3, " ") + `
                     "!" + $fieldDocSurname.PadRight(24, " ") + "!" + $fieldOmaCode.PadRight(4, " ") + "!" + $fieldAmt.PadLeft(9, " ") + `
                     "!" + $fieldReference.PadRight(11, " ") + "!" + $fieldBypass.PadRight(6, " ") + "!")
    
}

$write.Close()
$read.Close()

