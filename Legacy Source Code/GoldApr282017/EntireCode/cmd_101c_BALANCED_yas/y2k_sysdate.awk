# program: y2k_sysdate.awk
# programs needed: y2k_sysdate_programs.com and test_inputfile
# usage: . ./y2k_sysdate_programs.com

# Search for the fields needed to display out string

{
print $0

if (   $1 == "accept" && $2 == "sys-date" && $3 == "from" \
    && (   $4 == "date." \
        || $4 == "date" \
       ) \
   )
  {
   # If string was found as above then print the output string 
   printf("%s\t\t%s\n","    perform y2k-default-sysdate", \
           "thru y2k-default-sysdate-exit.")
  }
}
# Add a blank line and our output to last line of code in program

END { printf("\n%s\n","    copy \"y2k_default_sysdate_century.rtn\".") }
