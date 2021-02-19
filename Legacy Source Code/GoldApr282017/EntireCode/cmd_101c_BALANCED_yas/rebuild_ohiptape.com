# this macro will rebuild an "editted" rat ascii file back into the original
# rat ascii format that was received from OHIP (ie. one with no cr/lf)
# this macro is used when the incoming rat has to be corrrected
# and is "dumped" so that it can be vi'd.

echo " "
echo " "
if [ ! -f u020_tapeout_file.dump ]
then
  echo "ERROR -can't find your editted 'u020_tapeout_file.dump'"
  echo "macro terminating !"
  echo " "
else
  if [ -f u020_tapeout_file ]
  then
    echo "Warning - existing 'u020_tapeout_file' found - renamed to .bak"
    echo "        - make sure you delete it when the ohip tape is successfully created!"
    echo " "
    mv u020_tapeout_file u020_tapeout_file.bak
  fi
  echo "New 'u020_tapeout_file' file being created from editted file ..."
  awk -f $cmd/rebuild_ohiptape.awk < u020_tapeout_file.dump > u020_tapeout_file
  echo "done !"
fi
