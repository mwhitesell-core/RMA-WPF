# u021.awk 
# called from u021.com
# builds com file to process a series of file thru u031/u021 macros
# timeStamp of when job was run passed as parm variable
# 2003/oct/23 b.e. = original

BEGIN {
debug = 0
subDir = "u021_logs"
cmdFilename = "u021.tmp.com"

intMonth["A"] = 1
intMonth["B"] = 2
intMonth["C"] = 3
intMonth["D"] = 4
intMonth["E"] = 5
intMonth["F"] = 6
intMonth["G"] = 7
intMonth["H"] = 8
intMonth["I"] = 9
intMonth["J"] = 10
intMonth["K"] = 11
intMonth["L"] = 12

# separate filename into name.extension
posPeriod = index(FILENAME,".")
if (posPeriod==0) 
  {filename = FILENAME
  }
else
  {filename =substr(FILENAME,1,posPeriod - 1)
   extension=substr(FILENAME,posPeriod + 1)
  }
if (debug) printf"filename=%s extension=%s \n", filename,extension

shouldBeE = substr(filename,1,1)
month     = substr(filename,2,1)
clinic    = substr(filename,3,4)
restOfName= substr(filename,7)
if (debug) printf"%s/%s/%s/%s \n", shouldBeE,month,clinic,restOfName

printf "echo 'processing file  ... %s ... `date`'\n", FILENAME >> cmdFilename
printf "rm 1>/dev/null 2>/dev/null u031\n" 				\
		 	           >> cmdFilename
printf "\n"                        >> cmdFilename
printf "cp %s u031\n", FILENAME    >> cmdFilename
printf "$cmd/u031 %s %s %s\n",clinic ,intMonth[month],FILENAME		\
				   >> cmdFilename
printf "\n"                        >> cmdFilename
printf "echo 'Done processing - %s ... renaming as backup'\n",FILENAME	\
		                   >> cmdFilename
printf "mv 1>/dev/null 2>/dev/null %s %s/%s/%s.done\n", FILENAME,subDir,\
						     timeStamp,FILENAME \
				   >> cmdFilename

printf "echo 'cat r031?? files to print file and place in backup directory'\n"\
				   >> cmdFilename
printf "cat 1>/dev/null 2>/dev/null  r031b.lp r031b.txt > r031b.lp\n"  	\
				   >> cmdFilename
printf "mv  1>/dev/null 2>/dev/null  r031b.txt  %s/%s/r031b.%s\n",	\
				    subDir,timeStamp,FILENAME >> cmdFilename

printf "cat 1>/dev/null 2>/dev/null r031ba.lp r031ba.txt > r031ba.lp\n" \
				   >> cmdFilename
printf "mv  1>/dev/null 2>/dev/null r031ba.txt %s/%s/r031ba.%s\n",	\
				    subDir,timeStamp,FILENAME >> cmdFilename

printf "cat 1>/dev/null 2>/dev/null  r031c.lp r031c.txt > r031c.lp\n" 	\
				   >> cmdFilename
printf "mv  1>/dev/null 2>/dev/null  r031c.txt  %s/%s/r031c.%s\n", 	\
				    subDir,timeStamp,FILENAME >> cmdFilename

printf "echo \n"                   >> cmdFilename
printf "\n"                        >> cmdFilename
printf "\n"                        >> cmdFilename

}
# MAIN
{
}

END {
}
