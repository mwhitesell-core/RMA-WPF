BEGIN {
lineNbr=0
}

{
lineNbr=lineNbr+1

 gsub (/'/,"\"",$0)    #  replace
found1 =index($0,"date")
found2 =index($0,"dte")
found3 =index($0,"\-dt\-")
found4 =index($0,"year")
found5 =index($0,"yr")
found6 =index($0,"yy")
found7 =index($0,"fiscal")
found8 =index($0,"period")
found9 =index($0,"ped")
found10=index($0,"calendar")
found20 = index($0,"a-05-creation-date")
.
.

found=found1+found2+found3+found4+found5+found6+found7+found8+found9+found10 \
	   + found20	\
           + found21    \
           + found22    \
           + found23    \
           + found24    \
           + found25    \
           + found26    \
           + found27    \
           + found28    \
           + found29    \
           + found30    \
           + found31    \
           + found32    \
           + found33    \
           + found34    \
           + found35    \
           + found36    \
           + found37    \
           + found38    \
           + found39    \
           + found40    \
           + found41    \
           + found42    \
           + found43    \
           + found44    \
           + found45    \
           + found46    \
           + found47    \
           + found48    \
           + found49    \
           + found50    \
           + found51    \
           + found52    \
           + found53    \
           + found54    \
           + found55    \
           + found56    \
           + found57    \
           + found58    \
           + found59    \
           + found60    \
           + found61    \
           + found62    \
           + found63    \
           + found64    \
           + found65    \
           + found66    \
           + found67    \
           + found68    \
           + found69    \
           + found70    \
           + found71    \
           + found72    \
           + found73    \
           + found74    \
           + found75    \
           + found76    \
           + found77    \
           + found78    \
           + found79    \
           + found80    \
           + found81    \
           + found82    \
           + found83    \
           + found84    \
           + found85    \
           + found86    \
           + found87    \
           + found88    \
           + found89    \
           + found90    \
           + found91    \
           + found92    \
           + found93    \
           + found94    \
           + found95    \
           + found96    \
           + found97    \
           + found98    \
           + found99    \
           + found100   \
           + found101   \
           + found102   \
           + found103   \
           + found104   \
           + found105   \
           + found106   \
           + found107   \
           + found108   \
           + found109   \
           + found110   \
           + found111   \
           + found112   \
           + found113   \
           + found114   \
           + found115   \
           + found116   \
           + found117   \
           + found118   \
           + found119   \
           + found120   \
           + found121   \
           + found122   \
           + found123   \
           + found124   \
           + found125   \
           + found126   \
           + found127   \
           + found128   \
           + found129   \
           + found130   \
           + found131   \
           + found132   \
           + found133   \
           + found134   \
           + found135   \
           + found136   \
           + found137   \
           + found138   \
           + found139   \
           + found140   \
           + found141   \
           + found142   \
           + found143   \
           + found144   \
           + found145   \
           + found146   \
           + found147   \
           + found148   \
           + found149   \
           + found150   \
           + found151   \
           + found152   \
           + found153   \
           + found154   \
           + found155   \
           + found156   \
           + found157   \
           + found158   \
           + found159   \
           + found160   \
           + found161   \
           + found162   \
           + found163   \
           + found164   \
           + found165   \
           + found166   \
           + found167   \
           + found168   \
           + found169   \
           + found170   \
           + found171   \
           + found172   \
           + found173   \
           + found174   \
           + found175   \
           + found176   \
           + found177   \
           + found178   \
           + found179   \
           + found180   \
           + found181   \
           + found182   \
           + found183   \
           + found184   \
           + found185   \
           + found186   \
           + found187   \
           + found188   \
           + found189   \
           + found190   \
           + found191   \
           + found192   \
           + found193   \
           + found194   \
           + found195   \
           + found196   \
           + found197   \
           + found198   \
           + found199   \
           + found200   \
           + found201   \
           + found202   \
           + found203   \
           + found204   \
           + found205   \
           + found206   \
           + found207   \
           + found208   \
           + found209   \
           + found210   \
           + found211   \
           + found212   \
           + found213   \
           + found214   \
           + found215   \
           + found216   \
           + found217   \
           + found218   \
           + found219   \
           + found220   \
           + found221   \
           + found222   \
           + found223   \
           + found224   \
           + found225   \
           + found226   \
           + found227   \
           + found228   \
           + found229   \
           + found230   \
           + found231   \
           + found232   

skip1 =index($0,"date-written")
skip2 =index($0,"date-compiled")
skip3 =index($0,"\"")		#skip any comment lines (contain quote)
skip=skip1+skip2+skip3

if (found > 0 && skip==0 )
  {
#  source line#,text
   printf "%s= %s\n",lineNbr,$0
  }
}
END {
}
