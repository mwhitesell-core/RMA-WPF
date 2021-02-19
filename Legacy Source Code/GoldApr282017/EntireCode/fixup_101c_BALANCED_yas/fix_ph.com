for i in $*
do
  fname=`basename $i`
  $macros/dy_time "working on .. $fname "
  mv $fname $fname.bak
  $PH_USR/migrate/phdown < $fname.bak | awk -f $src/fix_ph.awk > $fname
#  awk -f fix_ph.awk < $fname.bak > $fname
done
