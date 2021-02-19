BEGIN {
lineNbr=19
}

{
#printf "%s\n",$0
lineNbr=lineNbr+1
printf "found%s = index($0,\"%s\")\n",lineNbr,$1
}
END {
printf "found= found20\n"
i = 20
while  (i < lineNbr)
  {
   i = i + 1
   printf "	   + found%s	\\\n",i
  }
}
