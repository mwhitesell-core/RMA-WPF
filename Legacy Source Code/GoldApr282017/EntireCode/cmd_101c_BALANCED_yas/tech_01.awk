echo 
echo "Micro fiche processing requires that each report line of a cobol"
echo "generated report ends with CR. This pgm adds a CR after each LF"
echo
echo 'sub(/$/, "\015")'
echo 'if (NR == 1) '
echo '  sub(/^/, "\015\014")'

mv $1 input_file.tmp
cat input_file.tmp | 	\
awk '{
gsub(/\014/,"\014\015",$0)      
print $0
}' 	> $1

rm input_file.tmp
