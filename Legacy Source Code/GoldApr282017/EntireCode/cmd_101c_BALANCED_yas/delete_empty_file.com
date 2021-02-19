ls -l $1 >/dev/null  2>/dev/null
if [ ! -s $1 ]
then
   echo deleting $1
   rm $1
fi
