# pr_wa.awk
# read a comma delimited text file
# incoming file format is:
#      month,claim nbr (missing leading 0 in doctor,ohip rejection code
# required format: month 9(2),clinic 9(2),zero 9(1),rest of claim nbr 9(8), code x(3)
 
BEGIN{}
 
{
gsub(/ /,"",$0)         # remove blanks
clinic = substr($2,1,2)
claimNbr=substr($2,3,8)
#printf "%-2s%-2s0%-8s%-3s", $1,clinic,claimNbr,$3
printf "%-2s%-2s0%8s%-3s", $1,clinic,claimNbr,$3
}
 
END{}
