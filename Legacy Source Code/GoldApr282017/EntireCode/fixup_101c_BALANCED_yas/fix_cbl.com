for i in $*
do
  fname=`basename $i`
  dy_time "working on .. $fname "
#  mv $fname $fname.bak
#  awk -f fix_cbl.awk < $fname.bak > $fname
  $src/cobdown < $fname.cb | awk -f $src/fix_cbl.awk > $fname.cbl
  # Kevin ... testing for * as comment, not ;
  #$PH_USR/migrate/phdown < $fname.cb | awk -f $src/fix_cbl.awk > $fname.cbl
#  awk -f fix_cbl.awk < $fname.cb > $fname.cbl
done
