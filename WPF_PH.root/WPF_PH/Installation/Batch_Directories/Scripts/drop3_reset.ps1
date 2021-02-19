Push-Location
cd \\$env:ROOT
if($env:RMABILL_VERS -eq "101c") {
echo "resetting 101c environment"
rm -Force -Recurse alpha\rmabill\rmabill101c\
cp -Force -Recurse drop3_reset\rmabill101c alpha\rmabill
}
if($env:RMABILL_VERS -eq "101cd3") {
echo "resetting 101cd3 environment"
rm -Force -Recurse alpha\rmabill\rmabill101cd3\
cp -Force -Recurse drop3_reset\rmabill101cd3 alpha\rmabill
}
echo "resetting home directories"
rm -Force -Recurse alpha\home
cp -Force -Recurse drop3_reset\home alpha
Pop-Location