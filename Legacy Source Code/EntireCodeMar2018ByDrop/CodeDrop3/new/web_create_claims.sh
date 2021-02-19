# $cmd/web_create_claims 

echo Start Time of $cmd/web_create_claims  is  `date`

echo
echo "Running web_create_claims_new_susp ..."
echo

if [ "$1" = "" ]
then
        echo 
        echo
        echo  "**ERROR**"
        echo  "You must supply the 6 character date yymmdd for the files to created!"
	echo "Files created will be:  Wyymmdd.pr"
	echo "                               .hdr"
	echo "                               .dtl"
	echo "                               .des"
	echo 
        exit
fi

if [ -s w${1}.pr !! -s w${1}.hdr !! -s w${1}.dtl !! -s w${1}.des ]
then
  echo 
  echo
  echo  "*WARNING*"
  echo  "Files for w${1} already exist!"
  echo 
  echo  "If you continue the files will be overridden!"
  echo
  echo  "Enter 'Ctrl-c' to stop this macro or 'enter' to continue"
  echo
  echo "Continue ?"
  read garbage
fi

rm w${1}.pr  1>/dev/null 2>&1
rm w${1}.hdr 1>/dev/null 2>&1
rm w${1}.dtl 1>/dev/null 2>&1
rm w${1}.des 1>/dev/null 2>&1

echo "Create Web upload file of Priced Claims"
quiz auto=$obj/rmaprice.qzc
if [ -s rmaprice.txt ]
then
  mv rmaprice.txt w${1}.pr
else
  echo 
  echo "**ERROR** - something is wrong!! - no priced claims file found!"
fi

echo "Create Web upload of updated 'visit' Headers - u716a/r716a ..."
qtp  auto=$obj/u716a.qtc
quiz auto=$obj/r716a.qzc
if [ -s r716a.txt ]
then
  mv r716a.txt w${1}.hdr
fi

echo "Create Web upload of updated 'visit' Details - r716b ..."
quiz auto=$obj/r716b.qzc
if [ -s r716b.txt ]
then
  mv r716b.txt w${1}.dtl
fi

echo "Create Web upload of updated  'comments/descriptions'- r716c ..."
qtp  auto=$obj/u716c.qtc

quiz auto=$obj/r716c1.qzc
quiz auto=$obj/r716c2.qzc
if [ -s r716c1.txt ]
then
  mv r716c1.txt w${1}.des
fi
if [ -s r716c2.txt ]
then
  echo 
  echo "**ERROR** - some description text was TRUNCATED - review r716c2.txt!!"
  lp  r716c2.txt 
fi

echo
echo "File created are: "
ls -l w${1}.*
echo
echo


# run regular diskette suspend processing pgms
$cmd/disk_create_claims

echo
echo
echo "DONE !"
echo

echo End   Time of $cmd/web_create_claims  is  `date`