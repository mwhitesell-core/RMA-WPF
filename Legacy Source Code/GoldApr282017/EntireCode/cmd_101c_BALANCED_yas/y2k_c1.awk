BEGIN {
}

{
 gsub (/'/,"\"",$0)    
##printf "%s \n", $0

found1=index($0,"copy")
found2=0
skip1=index($0,"\"")	# skip if no quotes found on line
if (skip1==0) {skip1=1}
else          {skip1=0}
skip2=index($0,"\*")

found=found1 + found2
skip=skip1 + skip2

##printf "%s\n",$0
##printf "%s=%s=%s=%s=%s\n",skip,skip1,skip2,found,NF
if (NF > 0 && found > 0 && skip == 0)
  {
   $0=tolower($0)	# lowercase name of program being called
#  (filename is between quotes)
   quote1=index($0,"\"")
   startPos=quote1+1
   remainder=substr($0,startPos,length($0)startPos)
   quote2=index(remainder,"\"")
   if (quote2 > 0) { fileName=substr(remainder,1,quote2-1) }
   else            { fileName=remainder }
#  (note location of files is hard coded)
   printf "/alpha/rmabill/rmabill100/use/%s \n",fileName
  }
}
