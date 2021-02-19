BEGIN {
}

{
printf "%s\n",$0		# write out source code line

if ($1 == "accept" && $2 == "sys-date" && $3 == "from"  && $4 == "date\." )
  {
   printf "*TEMPFIX-START\n"
   printf "    move sys-date-left			to sys-date-temp.\n"
   printf "    move sys-date-temp			to sys-date-right.\n"
   printf "    move zeros				to sys-date-blank.\n"
   printf "    add 19000000			to sys-date-numeric.\n" 
   printf "*TEMPFIX-END\n"
  }
}
END {
}
