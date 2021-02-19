for i in $*
do
  fname=`basename $i`
  dy_time "working on .. $fname "
# awk -f renameto8.awk < $fname > $fname.cli
  awk -f renameto8.awk  $fname 
done
