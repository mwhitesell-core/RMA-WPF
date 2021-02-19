
echo
echo `date`

qtp << QTP_EXIT
exec unlof002_aug_claim.qtc
${1}
QTP_EXIT

echo
echo `date`

