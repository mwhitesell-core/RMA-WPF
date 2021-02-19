# u021.awk 
# called from u021.com
# builds com file to process a series of file thru u021a/u021 macros
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

printf "echo \"processing file  ... %s ... `date`\"\n", FILENAME >> cmdFilename
printf "rm 1>/dev/null 2>/dev/null u021a\n" 				\
		 	           >> cmdFilename
printf "\n"                        >> cmdFilename
printf "cp %s u021a\n", FILENAME   >> cmdFilename
printf "cobrun $obj/u021a <<COBRUN_EXIT\n"	 >> cmdFilename
printf "%s\n",clinic 		   >> cmdFilename
printf "%s\n",intMonth[month]	   >> cmdFilename
printf "%s\n",FILENAME 		   >> cmdFilename
printf "COBRUN_EXIT\n"	 	   >> cmdFilename
printf "\n"                        >> cmdFilename
printf "echo 'Done processing - %s ... renaming as backup'\n",FILENAME	\
		                   >> cmdFilename
printf "mv 1>/dev/null 2>/dev/null %s %s/%s/%s.done\n", FILENAME,subDir,\
						     timeStamp,FILENAME \
				   >> cmdFilename
printf "echo \n"                   >> cmdFilename
printf "\n"                        >> cmdFilename

}
# MAIN
{
}

END {
}
