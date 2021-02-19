BEGIN {
}

{
$0 = tolower($0)
gsub(/\014/,"",$0)      # remove form feeds
gsub(/\032/,"",$0)      # remove END OF FILES (CTRL-z)
###gsub (/_/,"-",$2)    # replace underscores with hyphens 

#printf "%s\n",$0
#printf "%s %s %s \n",$1,$2,NF
 {
  if ($1 == "assign" && $2 == "index" || $1 == "contiguous" || $1 == "space" || $1 == "infos")
  {
#   (comment out these statements) 
    printf "*%s \n",$0
  }
  else
  if ($1 == "assign" && $2 == "data")
  {
    gsub (/\.db/,"",$0)    #  remove '.db' from name of database file
    gsub (/data/,"to disk",$0)    # 
    foundquote=index($0,"\"")
    $0 = substr($0,foundquote) "$pb_data" substr($0,foundquote+1)
    printf "%s \n",$0
  }
  else
  if ($1 == "data" && $2 == "block")
  {
    gsub (/data/,"    ",$0)    
    printf "%s \n",$0
  }
  else
  {
    printf "%s \n",$0
  }
 }
}
