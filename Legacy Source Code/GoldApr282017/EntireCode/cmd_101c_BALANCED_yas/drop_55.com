awk -f $cmd/drop_55.awk < $1 > $2
