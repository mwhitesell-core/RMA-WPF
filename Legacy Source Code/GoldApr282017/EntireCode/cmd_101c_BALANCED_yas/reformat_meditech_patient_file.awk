# filengthame:
# reformat incoming Meditech patient file into format expected by RMA's
# upload program u011 - because we don't know the before/after data
# we have to make each record an 'A'dd transaction.
# the incoming file looks like:
# 0$="DEVENPORT,OLIVE""14/02/18""F""1062314""501-200 JACKSON ST.W.""""HAMILTON"
# "L8P 4R9""3873487478-KC" 
#
# the 'words' we want are:
# DESC					WORD #	  	EXAMPLE DATA
# ---------------------------------	--------	-------------
# health care number - version code	$word(18)	3873487478-KC
# postal code				$word(16)	L8P 4R9
# city                 			$word(14)	HAMILTON
# address line 1			$word(10)	501-200 JACKSON ST.W.
# chart number				$word(8)	1062314
# sex					$word(6)	F
# patient DDrth date			$word(4)	14/02/18 (dd/mm/yy)
# lastname, firstname			$word(2)	DEVENPORT,OLIVE
#
# format for output is:
# outFunctionCode  	x(2) hard coded to  "AA"
# outLastName		x(24)
# outFirstName		x(24)
# outBirthDate		x(10) (yyyy/mm/dd)
# outsex 		x(1)
# outChartNbr		x(9)			???????????
#            15  tp-pat-id-no-yy         pic 99.
#            15  tp-pat-id-no-mm         pic 99.
#            15  tp-pat-id-no-5-digit    pic x.
#            15  tp-pat-id-no-6-7-digit  pic 9(2).
#            15  tp-pat-id-no-8-digit    pic 9.
#        10  tp-pat-id-no-9-digit        pic x.
# outStreetAddr		x(28)
# outCity		x(18)
# outProv 		x(2)
# outPostalCode		x(6)
# outPhoneNbr		x(10)		?????
#  05  tp-pat-ohip-no                  pic x(8). ???????
# outtHealthNbr		x(10)
# outVersionCode	x(2)		?????
# outHealth65Flag	x(1)		?????
# outHealthExpiryDate   x(4)	mmyy	?????

BEGIN {
FS="\""
blanks="                                                                        "
debug=0
debug1=0
}

# MAIN
{
# (all valid date is surrounded by quotes AND delimited by a comma
#  - remove the comma as not needed)
gsub (/\"\,\"/,"\"\"",$0)    
#printf "0$=%s \n", $0
if (debug) printf "0$=%s \n", $0
if (debug) printf "NF=%s \n", NF

#found1=index($0,"copy")
found2=0
#skip1=index($0,"\"")	# skip if no quotes found on line
#if (skip1==0) {skip1=1}
#else          {skip1=0}
#skip2=index($0,"\*")

#found=found1 + found2
#skip=skip1 + skip2

#if (NF > 0 && found > 0 && skip == 0)
if (NF > 0)
  {
   i = NF
   while  ( (debug == 1)  && i > 0)
     {
      printf "$i(%s)=%s\n",i, $i
      i = i - 1
     }
   healthNbr	= substr($18,1,10)
   versionCode	= substr($18,12,2)
   postalCode	= substr($16,1,3)  substr($16,5,3) #remove blank in middle
   city		= $14
   addr1	= $10
   addr2	= $12
   prov		= "pr"
   chartNbr   	= $8	
   sex 		= $6
   birthYY	= substr($4,7,2) 
   birthMM	= substr($4,4,2) 
   birthDD	= substr($4,1,2) 
   combinedName = $2
#   printf "BEFORE%s  =  %s\n", $2, combinedName
   split_name() # split into lastname and firstName
#   printf "FIRST/LAST=%s+%s\n", firstName,lastName

   phoneNbr	= "phone-numb"
   health65Flag	 = "?"
   healthExpiryDate = "yymm"
   if (debug > 1)
     {
      printf "\nINPUT: \n"
      printf "firstname= %s\n",firstName
      printf "lastName= %s\n",lastName
      printf "birthYY= %s\n",birthYY
      printf "birthMM= %s\n",birthMM
      printf "birthDD= %s\n",birthDD
      printf "sex= %s\n",sex
      printf "chartNbr= %s\n",chartNbr
      printf "addr1= %s\n",addr1
      printf "addr2= %s\n",addr2
      printf "city= %s\n",city
      printf "prov= %s\n",prov
      printf "postalCode= %s\n",postalCode
      printf "phoneNbr= %s\n",phoneNbr
      printf "healthNbr= %s\n",healthNbr
      printf "versionCode= %s\n",versionCode
      printf "65 Flag= %s\n",health65Flag 
      printf "expiryDate= %s\n",healthExpiryDate
     }
   outFunctionCode = "AA"

   if (length(lastName) > 24 )
     {outLastName = substr(lastName,1,24) } # truncate
   else
     {outLastName = lastName substr(blanks,1,24-length(lastName)) }

   if (length(firstName) > 24 )
     {outFirstName = substr(firstName,1,24) } # truncate
   else
     {outFirstName = firstName substr(blanks,1,24-length(firstName)) }

   if (birthYY > 01)
     {outBirthDate  = 19 birthYY "\/" birthMM "\/" birthDD }
   else
     {outBirthDate  = 20 birthYY "\/" birthMM "\/" birthDD }
   outSex = sex

#  (currently chartNbr is max length of 9 BUT to be changed to 15)
   if (length(chartNbr) > 15)
     {outChartNbr = substr(chartNbr,1,15) } # truncate
   else
     {outChartNbr = chartNbr substr(blanks,1,15-length(chartNbr)) }
#            15  tp-pat-id-no-yy         pic 99.
#            15  tp-pat-id-no-mm         pic 99.
#            15  tp-pat-id-no-5-digit    pic x.
#            15  tp-pat-id-no-6-7-digit  pic 9(2).
#            15  tp-pat-id-no-8-digit    pic 9.
#        10  tp-pat-id-no-9-digit        pic x.

   if (length(addr1) > 28)
     {outAddr1 = substr(addr1,1,28) } # truncate
   else
     {outAddr1 = addr1 substr(blanks,1,28-length(addr1)) }

   if (length(addr2) > 28)
     {outAddr2 = substr(addr2,1,28) } # truncate
   else
     {outAddr2 = addr2 substr(blanks,1,28-length(addr2)) }

   if (length(city) > 18)
     {outCity = substr(city,1,18) } # truncate
   else
     {outCity = city substr(blanks,1,18-length(city)) }

   if (length(prov) > 2)
     { outProv = substr(prov,1,2) } # truncate
   else
     { outProv = prov substr(blanks,1,2-length(prov)) }

   outPostalCode= postalCode

   if (length(phoneNbr) > 10)
     {outPhoneNbr = substr(phoneNbr,1,10) } # truncate
   else
     { outPhoneNbr = phoneNbr substr(blanks,1,10-length(phoneNbr)) }

   if (length(healthNbr) > 10)
     {outHealthNbr = substr(healthNbr,1,10) }
   else
     { outHealthNbr = healthNbr substr(blanks,1,10-length(healthNbr)) }

   if (length(versionCode) > 2)
     {outVersionCode = substr(versionCode,1,2) } # truncate
   else
     { outVersionCode = versionCode substr(blanks,1,2-length(versionCode)) }

   if (length(health65Flag) > 0)
      {outHealth65Flag = substr(health65Flag,1,1) }
   else
      {outHealth65Flag = " " }

   if (length(healthExpiryDate) > 4)
     {outHealthExpiryDate  = substr(healthExpiryDate,1,4) }
   else
     { outHealthExpiryDate = healthExpiryDate substr(blanks,1,4-length(healthExpiryDate)) }

   if (debug > 1)
     {
      printf "\nOUTPUT:\n"
      printf "outfirstname= %s\n",outFirstName
      printf "outlastName= %s\n",outLastName
      printf "outBirthDate= %s\n",outBirthDate
      printf "outSex= %s\n",outSex
      printf "outChartNbr= %s\n",outChartNbr
      printf "outAddr1= %s\n",outAddr1
      printf "outAddr2= %s\n",outAddr2
      printf "outCity= %s\n",outCity
      printf "outProv= %s\n",outProv
      printf "outPostalCode= %s\n",outPostalCode
      printf "outPhoneNbr= %s\n",outPhoneNbr
      printf "outHealthNbr= %s\n",outHealthNbr
      printf "outVersionCode= %s\n",outVersionCode
      printf "outHealth65Flag= %s\n",outHealth65Flag 
      printf "outExpiryDate= %s\n",outHealthExpiryDate
     }
   printf "%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s\n",\
	outFunctionCode,
	outLastName, \
	outFirstName, \
	outBirthDate, 
	outSex, \
	outChartNbr, \
	outAddr1, \
	outAddr2, \
	outCity, \
	outProv, \
        outPostalCode, \
	outPhoneNbr, \
	outHealthNbr, \
	outVersionCode, \
	outHealth65Flag, \
	outHealthExpiryDate

  }


}
function split_name()
# (text in front of comma is lastname and text after comma is firstname -
#  if no command found then assume it's all last name)
{
 commaPos=index(combinedName,"\,")    # find comma
# if (debug1) printf "COMMA%s \n", commaPos
 if (commaPos > 0)
   {
    lastName  = substr(combinedName,1,commaPos - 1)
    firstName = substr(combinedName,commaPos + 1, length(combinedName))
   }
 else
   {
    lastName = combinedName
    firstName = " "
   }
#   printf "DURING%s  =  %s\n", $2, combinedName
}
END{
}
