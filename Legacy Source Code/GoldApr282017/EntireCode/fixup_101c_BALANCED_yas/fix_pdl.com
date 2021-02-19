for i in $*
do
  fname=`basename $i`
  dy_time "working on .. $fname "
  awk -f fix_pdl.awk < $fname.full > $fname.pdl
done
