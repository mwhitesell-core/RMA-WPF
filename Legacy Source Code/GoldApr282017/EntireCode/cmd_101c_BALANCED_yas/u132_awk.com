#file: u132_awk.com
awk -f $cmd/u132.awk < $7 > u132.dat -v colDocNbr=$1 \
				     -v colDocSurname=$2 \
				     -v colDocInits=$3 \
				     -v colDocGivenNames=$4 \
				     -v colAmt=$5 \
				     -v colCompCode=$6
