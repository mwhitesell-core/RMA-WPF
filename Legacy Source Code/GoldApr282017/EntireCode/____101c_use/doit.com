for i in $*
do
  fname=`basename $i`
  dy_time "working on .. $fname "
  mv $fname         $fname.bak
  awk -f doit.awk < $fname.bak > $fname
done
