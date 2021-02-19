# file: u132.awk 
# creates a fixed length file of a csv file
BEGIN {
FS=","
zeros="00000000000000000000000" 
blanks="                                                                        "
debug=0
debug1=0
if (debug) printf "colDocNbr=%s\n",colDocNbr
if (debug) printf "colDocSurname=%s\n",colDocSurname
if (debug) printf "colDocInits=%s\n",colDocInits
if (debug) printf "colDocGivenNames=%s\n",colDocGivenNames
if (debug) printf "colAmt=%s\n",colAmt
if (debug) printf "colCompCode=%s\n",colCompCode
}

# MAIN
{

if (length($0)==0 )
  {next
} 

fieldDocNbr=""
fieldDocSurname=""
fieldDocInits=""
fieldDocGivenNames=""
fieldAmt=""
fieldCompCode=""
if (debug1) printf "0$=%s \n", $0
if (debug1) printf "LENGTH 0$=%s \n", length($0)
if (debug1) printf "substr 0$=%s \n", substr($0,length($0),1)

if (colDocNbr == 1) {
    processDocNbr($1)
} else if (colDocNbr == 2) {
    processDocNbr($2)
} else if (colDocNbr == 3) {
    processDocNbr($3)
} else if (colDocNbr == 4) {
    processDocNbr($4)
} else if (colDocNbr == 5) {
    processDocNbr($5)
} else if (colDocNbr == 6) {
    processDocNbr($6)
}

if (colDocSurname == 1) {
    processDocSurname($1)
} else if (colDocSurname == 2) {
    processDocSurname($2)
} else if (colDocSurname == 3) {
    processDocSurname($3)
} else if (colDocSurname == 4) {
    processDocSurname($4)
} else if (colDocSurname == 5) {
    processDocSurname($5)
} else if (colDocSurname == 6) {
    processDocSurname($6)
}

if (colDocInits == 1) {
    processDocInits($1)
} else if (colDocInits == 2) {
    processDocInits($2)
} else if (colDocInits == 3) {
    processDocInits($3)
} else if (colDocInits == 4) {
    processDocInits($4)
} else if (colDocInits == 5) {
    processDocInits($5)
} else if (colDocInits == 6) {
    processDocInits($6)
}
if (colDocGivenName == 1) {
    processDocGivenName($1)
} else if (colDocGivenName == 2) {
    processDocGivenName($2)
} else if (colDocGivenName == 3) {
    processDocGivenName($3)
} else if (colDocGivenName == 4) {
    processDocGivenName($4)
} else if (colDocGivenName == 5) {
    processDocGivenName($5)
} else if (colDocGivenName == 6) {
    processDocGivenName($6)
}
if (colAmt == 1) {
    processAmt($1)
} else if (colAmt == 2) {
    processAmt($2)
} else if (colAmt == 3) {
    processAmt($3)
} else if (colAmt == 4) {
    processAmt($4)
} else if (docAmt == 5) {
    processAmt($5)
} else if (colAmt == 6) {
    processAmt($6)
}
if (colCompCode == 1) {
    processCompCode($1)
} else if (colCompCode == 2) {
    processCompCode($2)
} else if (colCompCode == 3) {
    processCompCode($3)
} else if (colCompCode == 4) {
    processCompCode($4)
} else if (colCompCode == 5) {
    processCompCode($5)
} else if (colCompCode == 6) {
    processCompCode($6)
}

printf "%-3s!%-24s!%-3s!%-24s!%9.9s!%-6s\n",fieldDocNbr,fieldDocSurname,fieldDocInits,fieldDocGivenNames,fieldAmt,fieldCompCode

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


function processDocInits(tmpDocInits)
{
 LengthField =length(tmpDocInits) 
 if (lengthField > 3) {
   tmpDocInits= substr(tmpDocInits,1,3)
 }
 fieldDocInits=tmpDocInits
}


function processDocGivenNames(tmpDocGivenNames)
{
 lengthField =length(tmpDocGivenNames) 
 if (lengthField > 24) {
   tmpDocGivenNames = substr(tmpDocGivenNames,1,24)
 }
 fieldDocGivenNames=tmpDocGivenNames
}

function processAmt(tmpAmt)
{
# (if negative number remove '-' to process number and the add it back
#  as a leading dash when processing finished)
 negativeNbr = index(tmpAmt,"-")
 if (negativeNbr)  {
   if (0) printf "Neg BEFORE=%s\n",tmpAmt
   if (0) printf "Neg BEFORE=%s\n",negativeNbr
   tmpAmt = substr(tmpAmt,1,negativeNbr - 1) substr(tmpAmt,negativeNbr + 1,lengthtmpAMt - negativeNbr)
   if (0) printf "Neg AFTER =%s\n",tmpAmt
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
   tmpAmt = tmpAmt "-"
 }
 fieldAmt=tmpAmt
}


function processCompCode(tmpCompCode)
{
 lengthField =length(tmpAmt) 
 if (lengthField > 6) {
   tmpCompCode= substr(tmpCompCode,1,6)
 }
 fieldCompCode=tmpCompCode
}


END{
}
