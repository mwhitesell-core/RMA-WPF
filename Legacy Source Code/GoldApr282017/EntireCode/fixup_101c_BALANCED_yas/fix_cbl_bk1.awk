BEGIN {
}

{
gsub (/_/,"-",$2)    # replace underscores with hyphens 
gsub(/\014/,"",$0)	# remove form feeds

printf "BEFORE:%s\n",$0

FoundQuote1=index($0,"\"")
# if data within quotes, then don't lowercase it
if (FoundQuote1 > 0)
  {
   LeftOfLine=substr($0,1,FoundQuote1)
   MidOfLine=substr($0,FoundQuote1+1,length($0))
   FoundQuote2=index(MidOfLine,"\"")
   if (FoundQuote2 > 0)
     {
      MidOfLine=substr(MidOfLine,1,length(MidOfLine)-1)
      RightOfLine=substr(MidOfLine,FoundQuote2,length(MidOfLine))
      printf "Left =%s \n",LeftOfLine
      printf "Mid  =%s \n",MidOfLine
      printf "Right=%s \n",RightOfLine
      printf "%s \n",tolower(LeftOfLine)
      printf "%s \n",substr(MidOfLine,1,FoundQuote2)
      printf "%s \n",tolower(RightOfLine)
      $0 = tolower(LeftOfLine) + substr(MidOfLine,1,FoundQuote2) + tolower(RightOfLine)
     }
   else
     {
#     (only single quote on line - ignore)
      $0 = tolower($0)
     }
   }
else
  {
   $0 = tolower($0)
  }

if ($1 == "assign" && $2 == "index"i || $1 == "contiguous" || $1 == "space")
 {
#   (comment out these statements) 
    printf "*%s \n",$0
  }
  else
  if ($1 == "copy")
  {
    gsub (/copy \"/,"copy \"/alpha/rmabill/rmabill100/use/",$0)    # hard code directory 
    gsub (/copy  \"/,"copy \"/alpha/rmabill/rmabill100/use/",$0)    # hard code directory 
    gsub (/copy	\"/,"copy \"/alpha/rmabill/rmabill100/use/",$0)    # hard code directory 
    printf "%s \n",$0
  }
  else
  {
    printf "%s \n",$0
  }
}
