BEGIN {
recCtr=0
directory = ""
mac01 = sprintf("%s/alpha/rmabill/rmabill100/production/mac.201" , directory)
mac02 = sprintf("%s/alpha/rmabill/rmabill100/production/mac.202" , directory)
mac03 = sprintf("%s/alpha/rmabill/rmabill100/production/mac.203" , directory)
mac04 = sprintf("%s/alpha/rmabill/rmabill100/production/mac.204" , directory)
mac05 = sprintf("%s/alpha/rmabill/rmabill100/production/mac.205" , directory)
mac06 = sprintf("%s/alpha/rmabill/rmabill100/production/mac.206" , directory)
mac07 = sprintf("%s/alpha/rmabill/rmabill100/production/mac.207" , directory)
mac08 = sprintf("%s/alpha/rmabill/rmabill100/production/mac.208" , directory)
mac09 = sprintf("%s/alpha/rmabill/rmabill100/production/mac.209" , directory)
mac10 = sprintf("%s/alpha/rmabill/rmabill100/production/mac.210" , directory)
mac11 = sprintf("%s/alpha/rmabill/rmabill100/production/mac.211" , directory)
mac12 = sprintf("%s/alpha/rmabill/rmabill100/production/mac.212" , directory)
mac13 = sprintf("%s/alpha/rmabill/rmabill100/production/mac.213" , directory)
mac14 = sprintf("%s/alpha/rmabill/rmabill100/production/mac.214" , directory)
mac15 = sprintf("%s/alpha/rmabill/rmabill100/production/mac.215" , directory)
mac16 = sprintf("%s/alpha/rmabill/rmabill100/production/mac.216" , directory)
mac17 = sprintf("%s/alpha/rmabill/rmabill100/production/mac.217" , directory)
mac18 = sprintf("%s/alpha/rmabill/rmabill100/production/mac.218" , directory)
mac19 = sprintf("%s/alpha/rmabill/rmabill100/production/mac.219" , directory)
mac20 = sprintf("%s/alpha/rmabill/rmabill100/production/mac.220" , directory)
mac21 = sprintf("%s/alpha/rmabill/rmabill100/production/mac.221" , directory)
mac22 = sprintf("%s/alpha/rmabill/rmabill100/production/mac.222" , directory)
mac23 = sprintf("%s/alpha/rmabill/rmabill100/production/mac.223" , directory)
mac24 = sprintf("%s/alpha/rmabill/rmabill100/production/mac.224" , directory)
mac25 = sprintf("%s/alpha/rmabill/rmabill100/production/mac.225" , directory)
mac26 = sprintf("%s/alpha/rmabill/rmabill100/production/mac.226" , directory)
mac27 = sprintf("%s/alpha/rmabill/rmabill100/production/mac.227" , directory)
mac28 = sprintf("%s/alpha/rmabill/rmabill100/production/mac.228" , directory)
mac29 = sprintf("%s/alpha/rmabill/rmabill100/production/mac.229" , directory)
mac30 = sprintf("%s/alpha/rmabill/rmabill100/production/mac.230" , directory)
mac31 = sprintf("%s/alpha/rmabill/rmabill100/production/mac.231" , directory)
mac32 = sprintf("%s/alpha/rmabill/rmabill100/production/mac.232" , directory)
}
{
recCtr=recCtr+1
if (recCtr >     0 && recCtr <  252 ) { printf "%s \n",$0 >> mac01 }
if (recCtr >   250 && recCtr <  502 ) { printf "%s \n",$0 >> mac02 }
if (recCtr >   500 && recCtr <  752 ) { printf "%s \n",$0 >> mac03 }
if (recCtr >   750 && recCtr < 1002 ) { printf "%s \n",$0 >> mac04 }
if (recCtr >  1000 && recCtr < 1252 ) { printf "%s \n",$0 >> mac05 }
if (recCtr >  1250 && recCtr < 1502 ) { printf "%s \n",$0 >> mac06 }
if (recCtr >  1500 && recCtr < 1752 ) { printf "%s \n",$0 >> mac07 }
if (recCtr >  1750 && recCtr < 2002 ) { printf "%s \n",$0 >> mac08 }
if (recCtr >  2000 && recCtr < 2252 ) { printf "%s \n",$0 >> mac09 }
if (recCtr >  2250 && recCtr < 2502 ) { printf "%s \n",$0 >> mac10 }
if (recCtr >  2500 && recCtr < 2752 ) { printf "%s \n",$0 >> mac11 }
if (recCtr >  2750 && recCtr < 3002 ) { printf "%s \n",$0 >> mac12 }
if (recCtr >  3000 && recCtr < 3252 ) { printf "%s \n",$0 >> mac13 }
if (recCtr >  3250 && recCtr < 3502 ) { printf "%s \n",$0 >> mac14 }
if (recCtr >  3500 && recCtr < 3752 ) { printf "%s \n",$0 >> mac15 }
if (recCtr >  3750 && recCtr < 4002 ) { printf "%s \n",$0 >> mac16 }
if (recCtr >  4000 && recCtr < 4252 ) { printf "%s \n",$0 >> mac17 }
if (recCtr >  4250 && recCtr < 4502 ) { printf "%s \n",$0 >> mac18 }
if (recCtr >  4500 && recCtr < 4752 ) { printf "%s \n",$0 >> mac19 }
if (recCtr >  4750 && recCtr < 5002 ) { printf "%s \n",$0 >> mac20 }
if (recCtr >  5000 && recCtr < 5252 ) { printf "%s \n",$0 >> mac21 }
if (recCtr >  5250 && recCtr < 5502 ) { printf "%s \n",$0 >> mac22 }
if (recCtr >  5500 && recCtr < 5752 ) { printf "%s \n",$0 >> mac23 }
if (recCtr >  5750 && recCtr < 6002 ) { printf "%s \n",$0 >> mac24 }
if (recCtr >  6000 && recCtr < 6252 ) { printf "%s \n",$0 >> mac25 }
if (recCtr >  6250 && recCtr < 6502 ) { printf "%s \n",$0 >> mac26 }
if (recCtr >  6500 && recCtr < 6752 ) { printf "%s \n",$0 >> mac27 }
if (recCtr >  6750 && recCtr < 7002 ) { printf "%s \n",$0 >> mac28 }
if (recCtr >  7000 && recCtr < 7252 ) { printf "%s \n",$0 >> mac29 }
if (recCtr >  7250 && recCtr < 7502 ) { printf "%s \n",$0 >> mac30 }
if (recCtr >  7500 && recCtr < 7752 ) { printf "%s \n",$0 >> mac31 }
if (recCtr >  7750 && recCtr < 8002 ) { printf "%s \n",$0 >> mac32 }
}
