BEGIN {
FileNbr=000
}

{
$0 = tolower($0)
#printf "%s\n",$0
#printf "%s %s %s \n",$1,$2,NF
# select only those lines with 3 fields beginning
# with 'file': ie. 'file filename &'
if (NF == 3  &&  $1 == "file")
 {
  FileName=$2
  FileNbr=FileNbr+1
  if      (FileNbr > 99) {FileNbrCnt=FileNbr}
  else if (FileNbr >  9) {FileNbrCnt="0" FileNbr}
  else                  {FileNbrCnt="00" FileNbr}
  printf "cancel clear                     \n"
  printf "set process nolimit              \n"
  printf "access %s                        \n",FileName
  printf "subfile keep_sec_%s keep portable include %s \n",FileNbrCnt,FileName
  printf "go                               \n"
 }
else
 {
 }
}
