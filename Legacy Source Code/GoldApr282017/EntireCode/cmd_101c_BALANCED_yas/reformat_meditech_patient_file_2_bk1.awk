# filename: reformat_meditech_patient_file_2.awk
#
# modification history
# 2007/may./07 b.e. - removed double quotes from health card nbr and version cd
#
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
# health care number - version code	$word(12)	3873487478-KC
# phone number 				$word(11)	564-2345
# province      			$word(10)	ON      
# postal code				$word(09)	L8P 4R9
# city                 			$word(08)	HAMILTON
# address line 2			$word(07)	AP # 203                  
# address line 1			$word(06)	501-200 JACKSON ST.W.
# siteFlag     				$word(05)       ".","H"
# chart number				$word(04)       1062314
# sex					$word(03)	F
# patient birth date			$word(02)       04/02/18 (dd/mm/yy) -- dd/mm/yyyy new format
# lastname, firstname			$word(01) 	DEVENPORT,OLIVE
#
# format for output is:
# outFunctionCode  	x(2) hard coded to  "AA"
# outLastName		x(24)
# outFirstName		x(24)
# outBirthDate		x(10) (yyyy/mm/dd)
# outsex 		x(1)
# outChartNbr		x(9)	TODO in the future will be longer (10 or 15 chars)
#            15  first-char              pic x 'M,K,H,1,5'.
#            15  tp-pat-id-no-yy         pic 99.
#            15  tp-pat-id-no-mm         pic 99.
#            15  tp-pat-id-no-5-digit    pic x.
#            15  tp-pat-id-no-6-7-digit  pic 9(2).
#            15  tp-pat-id-no-8-digit    pic 9.
#            15  tp-pat-id-no-9-digit    pic x.
#            15  filler                  pic x(5).
# outStreetAddr-1	x(28)
# outStreetAddr-2	x(28)		New item , must be added 
# outCity		x(18)
# outProv 		x(2)
# outPostalCode		x(6)
# outPhoneNbr		x(20)		?????
# outPatOhipNbr         x(8)      TODO for now I put (_) value but will be changed in the future
# outHealthNbr		x(10)
# outVersionCode	x(2)		?????
# outHealth65Flag	x(1)		?????
# outHealthExpiryDate   x(4)	  mmyy  '0000'

BEGIN {
FS="\~"
blanks="                                                                        "
zeros="00000000000000000000000" 
qmark="?????????????????????????????????????????????????????????????????????????"
debug=0
debug1=0
}

# MAIN
{
if (length($0)==0 )
        {next
        }
# (all valid date is surrounded by quotes AND delimited by a comma
#  - remove the comma as not needed)

#gsub (/\"\,\"/,"\"\"",$0)
#printf "0$=%s \n", $0
if (debug) printf "0$=%s \n", $0
if (debug) printf "NF=%s \n", NF

#printf "$0=%s\n",$0
#gsub (/\"/ , "" ,$1)
for (i=1; i<=12; i++)
        {$i=substr($i,2,length($i)-2)
        }

#$1=substr($1,2,length($1)-2)
#$2,3,4,5, ...
#gsub (/\"/ , "" ,$2)
#$3,4,5,6 .....

#for (i=1; i<=12; i++)
#       {printf "$1=%s\n",$1
#       }

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


   patOhipNbr	= substr(blanks,1,8) 

#  (if field is too short then text has quotation marks
#   that can be included incorrectly, as part of data - remove quotes)
   healthNbr    = substr($12,1,10)
   healthNbr    = removeQuotes(healthNbr)
   versionCode  = substr($12,12,2)
   versionCode  = removeQuotes(versionCode)

#  phoneNbr	= substr($11,1,10)
   phoneNbr	= $11
   prov    	= $10
#   postalCode	= substr($9,1,3)  substr($9,5,3) #remove blank in middle
   postalCode	= $9
   city		= $8
   addr2	= $7
   addr1	= $6
   siteFlag	= $5
   chartNbr   	= $4	
   sex 		= $3
   
#   if (length($2) > 0)
#      {
#       birthYY	= substr($2,7,2) 
#       birthMM	= substr($2,4,2) 
#       birthDD	= substr($2,1,2) 
#       if (birthYY > 01)
#           {outBirthDate  = 19 birthYY "\/" birthMM "\/" birthDD 
#            }
#       else
#           {outBirthDate  = 20 birthYY "\/" birthMM "\/" birthDD 
#            }
#      }
#   else
#      {outBirthDate  = substr(blanks,1,10)
#       }


   if (length($2) > 0)
      {outBirthDate  = substr($2,7,4) "\/" substr($2,4,2) "\/" substr($2,1,2) 
       }
   else
      {outBirthDate  = substr(blanks,1,10)
       }

   combinedName = $1

#   printf "BEFORE%s  =  %s\n", $1, combinedName
   split_name() # split into lastname and firstName
#   printf "FIRST/LAST=%s+%s\n", firstName,lastName

   health65Flag	 = " "  
#  healthExpiryDate : format = "yymm"
   healthExpiryDate = "0000" 
   if (debug > 1)
     {
      printf "\nINPUT: \n"
      printf "firstname= %s\n",firstName
      printf "lastName= %s\n",lastName
      printf "birthYY= %s\n",birthYY
      printf "birthMM= %s\n",birthMM
      printf "birthDD= %s\n",birthDD
      printf "sex= %s\n",sex
      printf "siteflag= %s\n",siteFlag
      printf "chartNbr= %s\n",chartNbr
      printf "addr1= %s\n",addr1
      printf "addr2= %s\n",addr2
      printf "city= %s\n",city
      printf "prov= %s\n",prov
      printf "postalCode= %s\n",postalCode
      printf "phoneNbr= %s\n",phoneNbr
      printf "patOhipNbr= %s\n",patOhipNbr
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

   outSex = sex

# TODO  (currently chartNbr is max length of 9 BUT to be changed to 15)
#  if (length(chartNbr) > 9)
#    {outChartNbr = substr(chartNbr,1,9) } # truncate
#  else
#    {outChartNbr = chartNbr substr(blanks,1,9-length(chartNbr)) }
#            15  tp-pat-id-no-yy         pic 99.
#            15  tp-pat-id-no-mm         pic 99.
#            15  tp-pat-id-no-5-digit    pic x.
#            15  tp-pat-id-no-6-7-digit  pic 9(2).
#            15  tp-pat-id-no-8-digit    pic 9.
#        10  tp-pat-id-no-9-digit        pic x.




  if (length(siteFlag) > 1)
#     {outSiteFlag = substr(siteFlag,1,1) }
     {outSiteFlag = "?" }
   else
     {outSiteFlag = siteFlag substr(qmark,1,1-length(siteFlag)) }

   if (length(chartNbr) > 10)
     {outChartNbr = substr(chartNbr,length(chartNbr)-9,10) }

   if (length(chartNbr) == 10)
         { chartNbr_reformat() }

   if ( length(chartNbr) == 7 && index("15" , substr(chartNbr,1,1)) > 0 )
        {
        outChartNbr = substr(zeros,1,3) chartNbr ;
        chartNbr = "12345678901"
        }

   if (length(chartNbr) < 10)
      {outChartNbr = outSiteFlag substr(zeros,1,9-length(chartNbr)) chartNbr }
#     {outChartNbr = "1" substr(zeros,1,9-length(chartNbr)) chartNbr }

   outChartNbr = outChartNbr substr(blanks,1,5) # adding filler x(5)

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


   if (length(postalCode) <= 6)
     { outPostalCode = postalCode substr(blanks,1,6-length(postalCode)) }

   if (length(postalCode) == 7)
     { outPostalCode = substr(postalCode,1,3)  substr(postalCode,5,3) } #remove blank in middle

   if (length(postalCode) > 7)
     { outPostalCode = substr(postalCode ,1,6) }

   if (length(phoneNbr) > 20)
     {outPhoneNbr = substr(phoneNbr,1,20) } # truncate
   else
     { outPhoneNbr = phoneNbr substr(blanks,1,20-length(phoneNbr)) }

   if (length(patOhipNbr) > 8)
     {outPatOhipNbr = substr(patOhipNbr,1,8) }
   else
     { outPatOhipNbr = patOhipNbr substr(blanks,1,8-length(patOhipNbr)) }


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
      printf "outSiteFlag= %s\n",outSiteFlag
      printf "outChartNbr= %s\n",outChartNbr
      printf "outAddr1= %s\n",outAddr1
      printf "outAddr2= %s\n",outAddr2
      printf "outCity= %s\n",outCity
      printf "outProv= %s\n",outProv
      printf "outPostalCode= %s\n",outPostalCode
      printf "outPhoneNbr= %s\n",outPhoneNbr
      printf "outPatOhipNbr= %s\n",outPatOhipNbr
      printf "outHealthNbr= %s\n",outHealthNbr
      printf "outVersionCode= %s\n",outVersionCode
      printf "outHealth65Flag= %s\n",outHealth65Flag 
      printf "outExpiryDate= %s\n",outHealthExpiryDate
     }
   printf "%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s\n",\
	"C1"           ,
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
	outPatOhipNbr, \
	outHealthNbr, \
	outVersionCode, \
	outHealth65Flag, \
	outHealthExpiryDate
   printf "%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s\n",\
	"C2"           ,
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
	outPatOhipNbr, \
	outHealthNbr, \
	outVersionCode, \
	outHealth65Flag, \
	outHealthExpiryDate
  }


}
#---------------------------------------------------------------------------------------

function chartNbr_reformat()
{
    if (index(".G" , substr(chartNbr,1,1)) > 0 )
      { outChartNbr = "0001" substr(chartNbr,5,6)
      }
   else
      { outChartNbr = chartNbr
      }
}

#---------------------------------------------------------------------------------------
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
#   printf "DURING%s  =  %s\n", $1, combinedName
}
#-------------------------------------------------------------------------
function removeQuotes(strField)
{
 gsub (/\"/ , "" ,strField)
 return strField
}
#-------------------------------------------------------------------------
END{
}
