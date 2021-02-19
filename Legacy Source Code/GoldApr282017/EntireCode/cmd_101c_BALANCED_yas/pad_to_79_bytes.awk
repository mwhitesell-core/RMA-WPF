#! /bin/ksh S -f
BEGIN {
blanks="                                                                                                                                                               "
}

{
  len=length($0)
#  printf "len=%s\n",len
#  printf "$0=%s\n",$0

  if (len < 79) { 
  	$0 = substr($0,79) substr(blanks,1, 79 -  len)
 	printf "%s\015",$0			# replace 'lf' with 'cr' 
  } 
  if (len < 158) { 
  	line1a = substr($0,79) 
  	line1b = substr($0,79,len - 156) substr(blanks,1, 156 -  len)
 	printf "%s\015",line1a		# replace 'lf' with 'cr' 
 	printf "%s\015",line1b		# replace 'lf' with 'cr' 
  } 
  if (len > 157) { 
  	line1a = substr($0,1,79) 
  	line1b = substr($0,80,79)
 	printf "%s\015",line1a		# replace 'lf' with 'cr' 
 	printf "%s\015",line1b		# replace 'lf' with 'cr' 
  } 


#  	printf "%s\n",$0			# output 'lf' 
#	printf "%s\015",$0			# output 'cr'
#	printf "%s\015\n",$0			# output 'cr' 'lf' 
}
END{
}
