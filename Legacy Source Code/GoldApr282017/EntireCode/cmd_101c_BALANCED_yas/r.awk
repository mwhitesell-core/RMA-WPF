BEGIN {
tab="   "
space=" "
}

{
origLine=""
modLine =""

#printf "1=%s\n",$1
#printf "2=%s\n",$2
#printf "3=%s\n",$3
#printf "4=%s\n",$4
#
#  **********************************************************************
#                        PREMIUM PAYMENTS
#  FOR PAYMENT:          2006-09-29
#  PROVIDER NUMBER:      012384
#  PROVIDER NAME:        DR. DEVIN CLARKE PETERSON
#  GROUP BILLING NUMBER: 02215
#  GROUP NAME:           REGIONAL MEDICAL ASSOCIATES
#
#  CURRENT FISCAL
#  PAYMENT         PAYMENT     NUMBER OF    TOTAL DOLLAR VALUE   TOTAL
  TYPE            RATE           CLAIMS    OF APPROVED CLAIMS   PAYMENT
  CHILD <30 DAYS   30.0000% MTD       1           $66.30         $19.89
                            YTD       1           $66.30         $19.89
  CHILD 5YR <16YR  10.0000% MTD       4          $265.20         $26.52
                            YTD      12          $795.60         $79.56
#  **********************************************************************
#                           PROCESSING CHARGE SUMMARY
#                  EXEMPTED      CHARGEABLE                       TOTAL
#  PROVIDER #       CLAIMS         CLAIMS     CHARGE    GST      CHARGE
#  2215-012263          0            16      $30.19    $1.81     $32.00


found1 =index($0,"\*\*\*\*
found1a=index($0,"update")
if (found1 != 0 && found1a != 0) {found1=0} # don't take date if part of update
found2 =index($0,"dte")
found3 =index($0,"\-dt\-")
found4 =index($0,"year")
found5 =index($0,"yr")
found6 =index($0,"yy")
found7 =index($0,"fiscal")
found8 =index($0,"period")
found9 =index($0,"ped")
found10=index($0,"calendar")
found=found1+found2+found3+found4+found5+found6+found7+found8+found9+found10
skip1 =index($0,"date-written")
skip2 =index($0,"date-compiled")
skip3 =index($0,"perform")      # skip if date part of perform "paragraph" name

# skip if paragraph name on line by itself(assume paragraph name if first
# character is not blank or tab)
firstChar=substr($0,1,1)
if (NF == 1 && firstChar != space && firstChar != tab)
   {skip4=1}
else
   {skip4=0}
if (substr($0,1,1) == "*")      # skip comments
   {skip5=1}
else
   {skip5=0}
if ($1 == "copy")                # skip if call to 'copybook'
   {skip6=1}
else
   {skip6=0}
skip7 =index($0,"go to")        # skip if date part of goto 'paragraph name'
skip=skip1+skip2+skip3+skip4+skip5+skip6+skip7

# preceed any line that contains date with "Y2k" flag so it can be easily found
if (found > 0 && skip==0 )
  {

   origLine = $0
   modLine = $0

   if ($2 =="pic" && ($3 == "999999" || $3 == "9(6)") && (origLine ~ /(yr|yy|year|date|ped)/) )
     {autoFix=autoFixMsg
      gsub(/999999/,"9(8)",modLine)
      gsub(/9(6)/  ,"9(8)",modLine)
     }
   if ($2 =="pic" && ($3 == "xxxxxx" || $3 == "x(6)") && (origLine ~ /(yr|yy|year|date|ped)/) )
     {autoFix=autoFixMsg
      gsub(/xxxxxx/,"x(8)",modLine)
      gsub(/x\(6\)/ ,"x(8)" ,modLine)
     }
   if ($2 =="pic" && ($3 == "99" || $3 == "9(2)") && (origLine ~ /(yr|yy|year)/) )
     {autoFix=autoFixMsg
      gsub(/99/  ,"9(4)",modLine)
      gsub(/9\(2\)/,"9(4)",modLine)
     }
   if ($2 =="pic" && ($3 == "xx" || $3 == "x(2)") && (origLine ~ /(yr|yy|year)/) )
     {autoFix=autoFixMsg
      gsub(/xx/  ,"x(4)",modLine)
      gsub(/x\(2\)/,"x(4)",modLine)
      }

   if ($3 =="pic" && ($4 == "xxxxxx" || $4 == "x(6)") && (origLine ~ /(yr|yy|year|date|ped)/) )
     {autoFix=autoFixMsg
      gsub(/xxxxxx/,"x(8)",modLine)
      gsub(/x\(6\)/ ,"x(8)" ,modLine)
     }
   if ($3 =="pic" && ($4 == "999999" || $4 == "9(6)") && (origLine ~ /(yr|yy|year|date|ped)/) )
     {autoFix=autoFixMsg
      gsub(/999999/,"9(8)",modLine)
      gsub(/9\(6\)/ ,"9(8)" ,modLine)
     }
   if ($3 =="pic" && ($4 == "99" || $4 == "9(2)") && (origLine ~ /(yr|yy|year)/) )
     {autoFix=autoFixMsg
      gsub(/99/    ,"9(4)",modLine)
      gsub(/9\(2\)/ ,"9(4)" ,modLine)
     }
   if ($3 =="pic" && ($4 == "xx" || $4 == "x(2)") && (origLine ~ /(yr|yy|year)/) )
     {autoFix=autoFixMsg
      gsub(/xx/    ,"x(4)",modLine)
      gsub(/x\(2\)/ ,"x(4)" ,modLine)
     }

   if ($4 =="pic" && ($5 == "xxxxxx" || $5 == "x(6)") && (origLine ~ /(yr|yy|year|date|ped)/) )
     {autoFix=autoFixMsg
      gsub(/xxxxxx/,"x(8)",modLine)
      gsub(/x\(6\)/ ,"x(8)" ,modLine)
     }
   if ($4 =="pic" && ($5 == "999999" || $5 == "9(6)") && (origLine ~ /(yr|yy|year|date|ped)/) )
     {autoFix=autoFixMsg
      gsub(/999999/,"9(8)",modLine)
      gsub(/9\(6\)/ ,"9(8)" ,modLine)
     }
   if ($4 =="pic" && ($5 == "99" || $5 == "9(2)") && (origLine ~ /(yr|yy|year)/) )
     {autoFix=autoFixMsg
      gsub(/99/    ,"9(4)",modLine)
      gsub(/9\(2\)/ ,"9(4)" ,modLine)
     }
   if ($4 =="pic" && ($5 == "xx" || $5 == "x(2)") && (origLine ~ /(yr|yy|year)/)  )
     {autoFix=autoFixMsg
      gsub(/xx/    ,"x(4)",modLine)
      gsub(/x\(2\)/ ,"x(4)" ,modLine)
     }

   if ($5 =="pic" && ($6 == "xxxxxx" || $6 == "x(6)") && (origLine ~ /(yr|yy|year|date|ped)/) )
     {autoFix=autoFixMsg
      gsub(/xxxxxx/,"x(8)",modLine)
      gsub(/x\(6\)/ ,"x(8)" ,modLine)
     }
   if ($5 =="pic" && ($6 == "999999" || $6 == "9(6)") && (origLine ~ /(yr|yy|year|date|ped)/) )
     {autoFix=autoFixMsg
      gsub(/999999/,"9(8)",modLine)
      gsub(/9\(6\)/ ,"9(8)" ,modLine)
     }
   if ($5 =="pic" && ($6 == "99" || $6 == "9(2)") && (origLine ~ /(yr|yy|year)/)  )
     {autoFix=autoFixMsg
      gsub(/99/    ,"9(4)",modLine)
      gsub(/9\(2\)/ ,"9(4)" ,modLine)
     }
   if ($5 =="pic" && ($6 = "xx" || $6 == "x(2)") && (origLine ~ /(yr|yy|year)/)  )
     {autoFix=autoFixMsg
      gsub(/xx/    ,"x(4)",modLine)
      gsub(/x\(2\)/ ,"x(4)" ,modLine)
     }

   if ($6 =="pic" && ($7 == "xxxxxx" || $7 == "x(6)") && (origLine ~ /(yr|yy|year|date|ped)/) )
      {autoFix=autoFixMsg
      gsub(/xxxxxx/,"x(8)",modLine)
      gsub(/x\(6\)/ ,"x(8)" ,modLine)
     }
   if ($6 =="pic" && ($7 = "999999" || $7 == "9(6)") && (origLine ~ /(yr|yy|year|date|ped)/)  )
     {autoFix=autoFixMsg
      gsub(/999999/,"9(8)",modLine)
      gsub(/9\(6\)/ ,"9(8)" ,modLine)
     }
   if ($6 =="pic" && ($7 = "99" || $7 == "9(2)") && (origLine ~ /(yr|yy|year)/) )
     {autoFix=autoFixMsg
      gsub(/99/    ,"9(4)",modLine)
      gsub(/9\(2\)/ ,"9(4)" ,modLine)
     }
   if ($6 =="pic" && ($7 == "xx" || $7 == "x(2)") && (origLine ~ /(yr|yy|year)/) )
     {autoFix=autoFixMsg
      gsub(/xx/    ,"x(4)",modLine)
      gsub(/x\(2\)/ ,"x(4)" ,modLine)
     }

   if ($7 =="pic" && ($8 == "xxxxxx" || $8 == "x(6)") && (origLine ~ /(yr|yy|year|date|ped)/) )
     {autoFix=autoFixMsg
      gsub(/xxxxxx/,"x(8)",modLine)
      gsub(/x\(6\)/ ,"x(8)" ,modLine)
     }
   if ($7 =="pic" && ($8 == "999999" || $8 == "9(6)") && (origLine ~ /(yr|yy|year|date|ped)/) )
     {autoFix=autoFixMsg
      gsub(/999999/,"9(8)",modLine)
      gsub(/9\(6\)/ ,"9(8)" ,modLine)
     }
   if ($7 =="pic" && ($8 == "99" || $8 == "9(2)") && (origLine ~ /(yr|yy|year)/) )
     {autoFix=autoFixMsg
      gsub(/99/    ,"9(4)",modLine)
      gsub(/9\(2\)/ ,"9(4)" ,modLine)
     }
   if ($7 =="pic" && ($8 == "xx" || $8 == "x(2)") && (origLine ~ /(yr|yy|year)/) )
     {autoFix=autoFixMsg
      gsub(/xx/    ,"x(4)",modLine)
      gsub(/x\(2\)/ ,"x(4)" ,modLine)
     }

   if (autoFix != "")
     {
      printf "%s\n",autoFix             # autofix y2k comment
      if (substr(origLine,1,1) == space )
        { origLine = "*" substr(origLine,2,length(origLine)) } # replace 1st char
                                                         # with asterisk
      else
        { origLine = "*" substr(origLine,1,length(origLine)) } # insert asterisk
      printf "%s\n",origLine            # commented original line
      printf "%s\n" ,modLine                 # auto corrected line
     }
   else
     {
      printf "* (y2k)\n"                # y2k comment
      printf "%s\n",modLine                  # print unchanged line
     }
  }
  else
    {
     printf "%s\n",$0                   # print unchanged line
    }
}
END {
}
