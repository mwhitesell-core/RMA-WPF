# file: u141.awk 
# creates a fixed length file of a csv file
BEGIN {
FS=","
zeros="00000000000000000000000" 
blanks="                                                                        "
debug=0
debug1=0
}
# MAIN
{
if (length($0)==0 )
  {next
} 

fieldClinic=""
fieldAgent=""
fieldDocNbr=""
fieldDocSurname=""
fieldDocInits=""
fieldDocGivenNames=""
fieldAmt=""
fieldOmaCode=""
fieldReference=""
fieldBypass=""

if (debug1) printf "LENGTH 0$=%s \n", length($0)
if (debug1) printf "0$=%s \n", $0
if (debug1) printf "%s \n", $1
if (debug1) printf "%s \n", $2
if (debug1) printf "%s \n", $3
if (debug1) printf "%s \n", $4
if (debug1) printf "%s \n", $5
if (debug1) printf "%s \n", $6
if (debug1) printf "%s \n", $7
if (debug1) printf "%s \n", $8

processClinic($1)
processAgent($2)
processDocNbr($3)
processDocSurname($4)
processAmt($5)
processOmaCode($6)
processReference($7)
processBypass($8)

printf "%-2s!%-1s!%-3s!%-24s!%-4s!%9.9s!%-11s!%-6s!\n",fieldClinic,fieldAgent,fieldDocNbr,fieldDocSurname,fieldOmaCode,fieldAmt,fieldReference,fieldBypass

}

function processClinic(tmpClinic)
{
 lengthField =length(tmpClinic) 
 if (lengthField > 2) {
   tmpClinic = substr(tmpClinic,1,3)
 } else if (lengthField < 2 ) {
   tmpClinic = substr(zeros,1,2 - lengthField) tmpClinic
 }
 fieldClinic=tmpClinic
}

function processAgent(tmpAgent)
{
 lengthField =length(tmpAgent) 
 if (lengthField > 1) {
   tmpAgent = substr(tmpAgent,1,1)
 } else if (lengthField < 1 ) {
   tmpAgent = substr(zeros,1,1 - lengthField) tmpAgent
 }
 fieldAgent=tmpAgent
}

function processDocNbr(tmpDocNbr)
{
 lengthField =length(tmpDocNbr) 
 if (lengthField > 3) {
   tmpDocNbr = substr(tmpDocNbr,1,3)
 } else if (lengthField < 3 ) {
   tmpDocNbr = substr(zeros,1,3 - lengthField) tmpDocNbr
 }
 fieldDocNbr=tmpDocNbr
}


function processDocSurname(tmpDocSurname)
{
 lengthField =length(tmpDocSurname) 
 if (lengthField > 24) {
   tmpDocSurname = substr(tmpDocSurname,1,24)
 }
 fieldDocSurname = tmpDocSurname
}

function processAmt(tmpAmt)
{
# (if negative number remove '-' to process number and the add it back
#  as a leading dash when processing finished)
 negativeNbr = index(tmpAmt,"-")
 if (negativeNbr)  {
   if (0) printf "Neg BEFORE=%s\n",tmpAmt
   tmpAmt = substr(tmpAmt,2,length(tmpAmt) - 1)
   if (0) printf "Neg AFTER1=%s\n",tmpAmt
 }

 # (ensure 2 decimal digits after the decimal point - otherwise pad with trailing zero)
 decimalPosition=index(tmpAmt,"\.")
 lengthField=length(tmpAmt)
 diff = lengthField - decimalPosition 
 
 if (debug1) printf "LENGTHFIELD=%s\n",lengthField
 if (debug1) printf "DECIMALPOSITION=%s\n",decimalPosition
 if (debug1) printf "DIFF=%s\n",diff
 if (debug1) printf "Amt BEFORE=%s\n",tmpAmt
 if (decimalPosition == 0) {
   # (no decimal positions - add 2 trailing zeros for pennies)
   tmpAmt = tmpAmt "00"
 } else if (diff == 2){
     tmpAmt = substr(tmpAmt,1,decimalPosition - 1) substr(tmpAmt,decimalPosition + 1,2)
 } else if (diff  == 1){
     tmpAmt = substr(tmpAmt,1,decimalPosition - 1) substr(tmpAmt,decimalPosition + 1,1) "0"
 } else if (diff == 0){
     tmpAmt = substr(tmpAmt,1,decimalPosition - 1) "00"
 }

 if (debug1) printf "Amt AFTER =%s\n",tmpAmt
#this test changed from 8 to 9 with change to 1M$ amounts in payroll
 if (lengthField > 9) {
   tmpAmt = substr(tmpAmt,1,9)
 }

 if (negativeNbr)  {
   lastDigit = substr(tmpAmt,length(tmpAmt),1)
   getOverPunchedLastDigit() 
   tmpAmt = substr(tmpAmt,1,length(tmpAmt) - 1) lastDigit
 }
 fieldAmt=tmpAmt
}


function processOmaCode(tmpOmaCode)
{
 lengthField =length(tmpOmaCode) 
 if (lengthField > 4) {
   tmpOmaCode= substr(tmpOmaCode,1,4)
 }
 fieldOmaCode=tmpOmaCode
}


function processReference(tmpReference)
{
 lengthField =length(tmpReference) 
 if (lengthField > 11) {
   tmpReference= substr(tmpReference,1,11)
 }
 fieldReference= tmpReference
}

function processBypass(tmpBypass)
{
 lengthField =length(tmpBypass) 
 if (lengthField > 6) {
   tmpBypass= substr(tmpBypass,1,6)
 }
 fieldBypass= tmpBypass
}


function getOverPunchedLastDigit()
{
  if       (lastDigit == "0") {lastDigit = "p" }
  else {if (lastDigit == "1") {lastDigit = "q" }
  else {if (lastDigit == "2") {lastDigit = "r" }
  else {if (lastDigit == "3") {lastDigit = "s" }
  else {if (lastDigit == "4") {lastDigit = "t" }
  else {if (lastDigit == "5") {lastDigit = "u" }
  else {if (lastDigit == "6") {lastDigit = "v" }
  else {if (lastDigit == "7") {lastDigit = "w" }
  else {if (lastDigit == "8") {lastDigit = "x" }
  else {if (lastDigit == "9") {lastDigit = "y" }
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

END{
}
