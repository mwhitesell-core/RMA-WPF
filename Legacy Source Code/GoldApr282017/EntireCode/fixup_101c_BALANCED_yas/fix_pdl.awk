BEGIN {
ProcessingFile =0
ProcessingIndex=0
}

{
gsub(/\014/,"",$0)	# remove form feeds

##printf "BEFORE:%s\n",$0

FoundFile= index($1,"File")
if (FoundFile > 0)
  {
   ProcessingFile =1
   ProcessingIndex=0
  }

FoundIndex= index($1,"Index")
if (FoundIndex > 0)
  {
   ProcessingFile =0
   ProcessingIndex=1
  }

# if data within quotes, then don't lowercase it
if (FoundQuote1 > 0)
  {
   LeftOfLine=substr($0,1,FoundQuote1)
   MidOfLine=substr($0,FoundQuote1+1,length($0))
   FoundQuote2=index(MidOfLine,"\"")
   if (FoundQuote2 > 0)
     {
      MidOfLine=substr(MidOfLine,1,length(MidOfLine))
#     RightOfLine=substr(MidOfLine,FoundQuote2,length(MidOfLine)-1) "."
      RightOfLine=substr(MidOfLine,FoundQuote2,length(MidOfLine)-1)
      if ($1=="COPY")
         {
          MiddleOfLine=tolower(substr(MidOfLine,1,FoundQuote2-1))
          gsub(/-/,"_",MiddleOfLine)
         }
      else
         {
          MiddleOfLine=        substr(MidOfLine,1,FoundQuote2-1)
         }
#      printf "LeftOfLine=%s \n",LeftOfLine
#      printf "lengthofLEFT=%s \n",length(LeftOfLine)
#      printf "MidOfLine=%s \n",MidOfLine
#      printf "lengthofMID=%s \n",length(MidOfLine)
#      printf "MiddleOfLine=%s \n",MiddleOfLine
#      printf "lengthofMIDDLE=%s \n",length(MiddleOfLine)
#      printf "RightOfLine=%s \n",RightOfLine
#      printf "Foundquote2=%s \n",FoundQuote2
      $0 = tolower(LeftOfLine) MiddleOfLine tolower(RightOfLine)
#      printf "$0=%s \n",$0
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

if ($1 == "xxx" || $1 == "null")
  {
#  (comment out these statements) 
   printf ";%s \n",$0
  }
else
  if ($1 == "Open" || $1 == "open" || $1 == "OPEN")
  {
   if (ProcessingFile == 1)
     {
      $0 = tolower($0)
      gsub (/-/,"_",$0)    # replace hyphens in filename with underscores 
      #gsub (/open \"/,"open $pb_data/",$0)    # add logical to open name
      gsub (/open /,"open $pb_data/",$0)    # add logical to open name
      printf "%s \n",$0
     }
   else
   if (ProcessingIndex == 1)
     {
      $0 = tolower($0)
      gsub (/-/,"_",$0)		# replace hyphens in filename with underscores 
      printf ";%s \n",$0	# comment index opens
     }
   else
     {
      printf "%s \n",$0
     }
  }
  else
    {
     if ($1 == "index")
       {
	FoundContinue=index($0,"&")
	if (FoundContinue > 0)
	  {
 	   $0 = substr($0,1,FoundContinue-1) "; &"# comment out continuation
						  # since next line (open)
						  # will be commented out
	  }
       }
     else
       {
       }
    printf "%s\n",$0
    }
}
