# transaction file contains 3 lines of parameters per transaction
# this program will ignore the first 3 lines and copy any remaining
# lines to a new parameter file

BEGIN {
blanks="                                                                        "
directory = "/alpha/rmabill/rmabill101c"

newParmFile = sprintf("%s/data/batch_update_f050_f051_f060.flg.new" , directory)
debug=0
recCounter = 0 # used to coun
}

# MAIN
{
if (length($0)==0 )
        {next
        }
if (debug) printf "0$=%s \n", $0

recCounter = recCounter + 1
if (recCounter > 3)
  {
    printf "%s\n",$0 >> newParmFile
  }
}
END{
}
