#! /bin/ksh -f
BEGIN {
blanks="                                                                               "
}

{
  len=length($0)
  $0 = $0 substr(blanks,1,79-len)
 if (lastline != "") {printf "%s\015\n",lastline}  #add 'cr' in front of 'lf'
#  if (lastline != "") {printf "%s\n",lastline}  #add 'cr' in front of 'lf'
  lastline=$0
}
END{
printf "%s\015\n\032",lastline   # add 'cr' in front of 'lf' and EOF
#printf "%s\n\032",lastline        # add 'cr' in front of 'lf' and EOF
				  # to end file
}
