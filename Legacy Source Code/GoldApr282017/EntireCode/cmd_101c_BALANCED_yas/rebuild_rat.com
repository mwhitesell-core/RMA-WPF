# this macro will rebuild an "editted" rat ascii file back into the original
# rat ascii format that was received from OHIP (ie. one with no cr/lf)
# this macro is used when the incoming rat has to be corrrected
# and is "dumped" so that it can be vi'd.

echo " "
echo " "
if [ ! -f ohip_rat_ascii.dump ]
then
  echo "ERROR -can't find your editted 'rat_ascii_file.dump"
  echo "macro terminating !"
  echo " "
else
  if [ -f ohip_rat_ascii ]
  then
    echo "Warning - existing 'rat_ascii_file' found - renamed to .bak"
    echo "        - make sure you delete it when the rat is successfully applied!"
    echo " "
    mv ohip_rat_ascii ohip_rat_ascii.bak
  fi
  echo "New rat_ascii_file being created from editted file ..."
  awk -f $cmd/rebuild_rat.awk < ohip_rat_ascii.dump > ohip_rat_ascii
  echo "done !"
fi
