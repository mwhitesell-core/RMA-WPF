# filename: reformat_meditech_patient_file_1.awk
#
# creates a file that contains only 3 fields :                             
# SITE - x(1)  ,  HEALTH NBR - x(10)  ,  CHART NBR - x(10)
# CHART NBR is reformatted form of input field 
# This program will be run only one time to finding out the KEY problems in the master file
#
# The incoming file looks like:
# 0$="DEVENPORT,OLIVE","14/02/18","F","1062314",".","501-200 JACKSON ST.W.","","HAMILTON",
# "L8P 4R9","3873487478-KC" 
#
# the 'words' we want are:
# DESC					WORD #	  	EXAMPLE DATA
# ---------------------------------	--------	-------------
# health care number - version code     $word(12)	3873487478-KC
# phone number 			  	$word(11)	564-2345
# province      		  	$word(10)	ON      
# postal code			 	$word(09)	L8P 4R9
# city                 		 	$word(08)	HAMILTON
# address line 2		 	$word(07)	AP # 203
# address line 1		 	$word(06)	501-200 JACKSON ST.W.
# siteFlag     			 	$word(05)       ".","H","M","K", ...
# chart number			 	$word(04)       1062314
# sex				 	$word(03)	F
# patient birth date		 	$word(02)	14/02/18 (dd/mm/yy)
# lastname, firstname		 	$word(01)	DEVENPORT,OLIVE
#
# format for output is:
# outSite          	x(1) 
# outChartNbr		x(10)
#            15  first-char              pic x. 
#            15  tp-pat-id-no-yy         pic 99.
#            15  tp-pat-id-no-mm         pic 99.
#            15  tp-pat-id-no-5-digit    pic x.
#            15  tp-pat-id-no-6-7-digit  pic 9(2).
#            15  tp-pat-id-no-8-digit    pic 9.
#            15  tp-pat-id-no-9-digit    pic x.
# outHealthNbr		x(10)

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
#	{printf "$1=%s\n",$1
#	}

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
   healthNbr	= substr($12,1,10)
   if (debug1) printf "hNbr:|%s| \n",healthNbr
#  (if field is too short then text quotation marks 
#   can be included as part of data - remove them)
   healthNbr = removeQuotes(healthNbr)
   if (debug1) printf "hNbr:|%s| \n",healthNbr
   versionCode	= substr($12,12,2)
   if (debug1) printf "vers:|%s| \n", versionCode
   versionCode = removeQuotes(versionCode)
   if (debug1) printf "vers:|%s| \n", versionCode
   phoneNbr	= $11
   prov    	= $10
   postalCode	= substr($9,1,3)  substr($9,5,3) #remove blank in middle
   city		= $8
   addr2	= $7 
   addr1	= $6
   siteFlag	= $5 
   chartNbr   	= $4	
   sex 		= $3
   if (length($2) > 0)
      {
       birthYY	= substr($2,7,2) 
       birthMM	= substr($2,4,2) 
       birthDD	= substr($2,1,2) 
      }
   else
      {
       birthYY	= "00"
       birthMM	= "00"
       birthDD	= "00"
      }
   combinedName = $1
   split_name() # split into lastname and firstName
   health65Flag	 = " "   # TODO
   healthExpiryDate = "9999"   # TODO
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

   if (length(healthNbr) > 10)
     {outHealthNbr = substr(healthNbr,1,10) }
   else 
     { outHealthNbr = healthNbr substr(blanks,1,10-length(healthNbr)) }


   if (debug1 > 1)
     {
      printf "\nOUTPUT:\n"
      printf "outSiteFlag= %s\n",outSiteFlag
      printf "outHealthNbr= %s\n",outHealthNbr
      printf "outChartNbr= %s\n",outChartNbr
     }
   printf "%s%s%s\n",\
	outSiteFlag,
	outHealthNbr, \
	outChartNbr
#        " | " $4 " | " , \
# 	length(chartNbr)
#	chartNbr
  }

}
#-------------------------------------------------------------------------
function chartNbr_reformat()
{
    if (index(".G" , substr(chartNbr,1,1)) > 0 )
      { outChartNbr = "0001" substr(chartNbr,5,6) 
      }
   else
      { outChartNbr = chartNbr 
      }
}
#-------------------------------------------------------------------------
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
#-------------------------------------------------------------------------
function removeQuotes(strField)
{
 gsub (/\"/ , "" ,strField)    
 return strField
}
#-------------------------------------------------------------------------
END{
}