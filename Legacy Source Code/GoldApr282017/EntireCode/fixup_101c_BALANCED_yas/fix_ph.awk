#! /bin/awk -f
{
# add logical to object (QUICK)
if ($1 == "screen" || $2 == "screen")
  sub(/screen /,"screen $pb_obj/",$0)

# add logical to object (QTP and QUIZ)
if ($1 == "build")
  sub(/build /,"build $pb_obj/",$0)

# add logical to use file
if ($1 == "use")
  sub(/use /,"use $pb_src/",$0)

# remove control Z
gsub (/\032/,"  ",$0)

printf "%s\n", $0
}
