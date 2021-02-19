for i in $*
do
  fname=`basename $i`
  dy_time "working on .. $fname "
  mv $fname $fname.orig
  awk -f fix_cbl.awk < $fname.orig > $fname
#  awk -f fix_cbl.awk < $fname > $fname.new
done
