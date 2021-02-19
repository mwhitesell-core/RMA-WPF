for i in `ls *.cli`
do
fil_name=`echo $i |sed 's/\.cli//g'`
 awk '{FIRSTWORDPOS=index($0,$1)-1
       LEADINGBLANKS=substr($0,0,FIRSTWORDPOS)
       sub(/&/,"\\")
       sub(/^\)/,"\!")
       gsub(/BETA/,"$BETA")
       gsub(/727/,"$CHARLY")
       gsub(/%1%/," ${1}")
       gsub(/%2%/," ${2}")
       gsub(/%3%/," ${3}")
       gsub(/%4%/," ${4}")
       gsub(/%5%/," ${5}")
       gsub(/%6%/," ${6}")
       gsub(/%7%/," ${7}")
       gsub(/%8%/," ${8}")
       gsub(/%9%/," ${9}")
	gsub(/%-%/," ${+}")
	gsub(/RING_BELL/, "echo ")
	gsub(/\[!ASC(II)* 214\]/, "")
	gsub(/\[!ASC(II)* 216\]/, "")
	gsub(/\[!ASC(II)* 217\]/, "")
	gsub(/\[!ASC(II)* 224\]/, "")
	gsub(/\[!ASC(II)* 225\]/, "")
	gsub(/\[!else\]/, "else")
	gsub(/\[!READ \]/, "read garbage")
       gsub(/\/ASSORTMENT/,"AS")
       gsub(/(\[)*( )*!EQ(UAL)*( )*(\])*/,"-eq")
       gsub(/(\[)*( )*!NEQUAL( )*(\])*/,"-ne")
       gsub(/(\[)*( )*!END( )*(\])*/,"fi")
       gsub(/(\[)*( )*!ELSE( )*(\])*/,"else")
       gsub(/(\[)*( )*!DIR( )*(\])*/,"`pwd`")
       gsub(/(\[)*( )*!CONSOLE( )*(\])*/,"`tty`")
       gsub(/(\[)*( )*!STR(ING)*\/P( )*(\])*/,"# \[!STR\/P\] - not supported ")
       gsub(/(\[)*( )*!STR(ING)*( )*(\])*/,"`$STRING`")
       gsub(/(\[)*( )*!SEA( )*(\])*/,":$PATH")
       gsub(/(\[)*( )*!DATE( )*(\])*/,"`date \"+%d-%h-%y\"`")
       gsub(/(\[)*( )*!TIME( )*(\])*/,"`date \"+%H:%M:%S\"`")
       gsub(/(\[)*( )*!USER(NAME)*( )*(\])*/,"`who am i | awk{print $1}`")
       sub(/^(( )*|(\t)*)*COM(M)*(ENT)*/,LEADINGBLANKS "# ")
       sub(/^(( )*|(\t)*)*com(m)*(ent)*/,LEADINGBLANKS "# ")
       sub(/^(( )*|(\t)*)*RW/,"")
       sub(/^(( )*|(\t)*)*REWIND @MTB[0-1]/,"")
       sub(/^(( )*|(\t)*)*QB(ATCH)*/,"batch " )
       sub(/^(( )*|(\t)*)*IVERFIY/,"# IVERIFY")
       sub(/^(( )*|(\t)*)*IDELETE/,"# IVERIFY")
       sub(/^(( )*|(\t)*)*ICREATE/,"# ICREATE")
       sub(/^(( )*|(\t)*)*SUPERU(SER)*/,"# SU(PERUSER) REQUIRES PASSWD ENTRY")
       sub(/^(( )*|(\t)*)*SUPERPROCESS/,"# SUPERPROCESS NOT SUPPORTED")
       sub(/^(( )*|(\t)*)*STR(ING)*/,"STRING=")
       sub(/^(( )*|(\t)*)*LABEL/,"# LABEL NOT NEEDED ")
       sub(/^(( )*|(\t)*)*SEND/,"echo >/dev/" )
       sub(/^(( )*|(\t)*)*FILESTATUS/,"FAS")
       sub(/^(( )*|(\t)*)*str(ing)*/,"STRING=")
       sub(/^(( )*|(\t)*)*GOD/,LEADINGBLANKS "# GOD - NOT SUPPORTED")
       sub(/^(( )*|(\t)*)*PAUSE/,LEADINGBLANKS "sleep ")
       sub(/^(( )*|(\t)*)*TY(PE)*/,LEADINGBLANKS "cat ")
       sub(/^(( )*|(\t)*)*MOVE(\/D)*/,LEADINGBLANKS "tmpmv ")
       sub(/^(( )*|(\t)*)*PROMPT/,LEADINGBLANKS "tmpecho ")
       sub(/^(( )*|(\t)*)*QPR(INT)*[^2-3]/,LEADINGBLANKS "lp ")
       sub(/^(( )*|(\t)*)*QPR(INT)*2/,LEADINGBLANKS "lp -dprinter2 ")
       sub(/^(( )*|(\t)*)*QPR(INT)*3/,LEADINGBLANKS "lp -dprinter3 ")
       sub(/^(( )*|(\t)*)*SEA(RCHLIST)*/,LEADINGBLANKS "PATH= ")
       sub(/^(( )*|(\t)*)*QDIS(PLAY)*(\/V)*\/TYP=PR/,LEADINGBLANKS "lpstat -p ")
       sub(/^(( )*|(\t)*)*QDIS(PLAY)*(\/V)*\/TYP=B/,LEADINGBLANKS "at -l ")
       sub(/^(( )*|(\t)*)*DUMP(_II)*/,LEADINGBLANKS "cpio -ovcB ")
       sub(/^(( )*|(\t)*)*DLOAD/,LEADINGBLANKS "cpio -ivcB ")
       sub(/^(( )*|(\t)*)*PERM/,LEADINGBLANKS "# PERM - NO UNIX EQUIV ")
       sub(/^(( )*|(\t)*)*DEL(ETE)*/,LEADINGBLANKS "rm ")
       sub(/^(( )*|(\t)*)*WHO/,LEADINGBLANKS "who ")
       sub(/^(( )*|(\t)*)*TIME/,LEADINGBLANKS "date ")
       sub(/^(( )*|(\t)*)*ACL(\/K)*/,LEADINGBLANKS "chmod a+rwx ")#MUST OWN
       sub(/^(( )*|(\t)*)*broadcast/,LEADINGBLANKS "wall ")
       sub(/^(( )*|(\t)*)*BY(E)*/,LEADINGBLANKS "exit ")
       sub(/^(( )*|(\t)*)*CHAR/,LEADINGBLANKS "# CHAR")
       sub(/^(( )*|(\t)*)*COPY/,LEADINGBLANKS "cp ")
       sub(/^(( )*|(\t)*)*COPY\/[o,O,M]/,LEADINGBLANKS "# REWRITE TO CPIO $1 ")
       sub(/^(( )*|(\t)*)*CREA\/DIR/,LEADINGBLANKS "mkdir ")
       sub(/^(( )*|(\t)*)*CREATE/,LEADINGBLANKS "touch ")
       sub(/^(( )*|(\t)*)*CREATE(\/|[A-Z])*\/LINK/,LEADINGBLANKS "ln ")
       sub(/^(( )*|(\t)*)*DIR(\/I)*/,LEADINGBLANKS "cd ")
       sub(/^(( )*|(\t)*)*EXE(CUTE)*/,LEADINGBLANKS "")
       sub(/^(( )*|(\t)*)*REN(AME)*/,LEADINGBLANKS "mv ") 
       sub(/^(( )*|(\t)*)*F(\/)*AS(S)*/,LEADINGBLANKS "ls -laF")
       sub(/^(( )*|(\t)*)*FADIR/,LEADINGBLANKS "ls -l | grep \"^d\" ")
       sub(/^(( )*|(\t)*)*W(r|R)(I)*(TE)*/,LEADINGBLANKS "echo ")
       sub(/^(( )*|(\t)*)*wr(i)*(te)*/,LEADINGBLANKS "echo ")
       sub(/^(( )*|(\t)*)*pop/,LEADINGBLANKS "exit ")
       sub(/^(( )*|(\t)*)*POP/,LEADINGBLANKS "exit ")
       sub(/^(( )*|(\t)*)*PU(SH)*/,LEADINGBLANKS "echo ")
       sub(/^(( )*|(\t)*)*pu(sh)*/,LEADINGBLANKS "echo ")
       sub(/^(( )*|(\t)*)*X(EQ|O)(\/M)*( )*/,LEADINGBLANKS "cobrun \$obj\/")
       sub(/^(( )*|(\t)*)*X(EQ|O)*( )*/,LEADINGBLANKS "cobrun \$obj\/")
       sub(/^(( )*|(\t)*)*x(eq|o)(\/M)*( )*/,LEADINGBLANKS "cobrun \$obj\/")
       sub(/\/1=IG(N(ORE)*)*/,"  >/dev/null ")
       sub(/\/1=ig(n(ore)*)*/,"  >/dev/null ")
       sub(/\/2=IG(N(ORE)*)*/," 2>/dev/null ")
       sub(/\/2=ig(n(ore)*)*/," 2>/dev/null ")
       sub(/\/L=/," > ")
       sub(/\/l=/," > ")
	if ($1 ~ /\.CLI/) {
                gsub(/.CLI/,"")
		sub(/^/, "\$cmd\/")
	}
	sub(/^\/M/, "")
       print}' $i |  		\
	tr '[A-Z]' '[a-z]' | 	\
awk  '$NF == "\\" { print $0 "\n # COMMAND SPANS MORE THAN ONE LINE *\n" }
      $NF != "\\" { if ($1 == "rm") { gsub(/\*/,"?"); 
				      gsub(/\+/,"*"); 
				      sub(/\/V/," ");
				      sub(/\/C/,"-i ");
				      gsub(/:/,"/"); print } 
		    else if ($1 == "mv") {
      				gsub(/\*/,"?"); 
				gsub(/\+/,"*"); 
				gsub(/:/,"/"); print } 
      		    else if (($1 == "cd") && ($2 == "")) { 
					sub(/cd/,"pwd"); print } 
      		    else if ($1 == "cd") { gsub(/:/,"/") ; print } 
		    else if ($1 == "cp") { gsub(/:/,"/");
			 if ($2 ~ "/A"){sub(/\/A/,"");
					sub(/cp/,"cat ");
					print $0 " >/usr/tmp/" $2".TMP",
						" \n  mv /usr/tmp/"$2".TMP",
						" " $2 }
			 else { printf("%s ",$1);
			 	for ( i = 3; i <= NF; i++ ) { 
			  	 	printf("%s ",$i)};
			   	printf("%s \n", $2)} } 
		    else if ($1 == "ln") { gsub(/:/,"/"); print}
		    else if ($1 == "echo") { gsub(/,/," "); print}
		    else if ($1 == "cpio" && $2 == "-ovcB" ) {
			 gsub(/\/BUFF(ERSIZE)*/," obs");
			 gsub(/@MTB0(:[0-9]*[0-9]*)/," > /dev/rmt/0 ");
			 gsub(/\+/,"*");
			 gsub(/#/,"`pwd`");
			 gsub(/:/,"/");
			 gsub(/\\/,"/");
			 sub(/\/V/,"");
			 print}
		    else if ($1 == "cpio" && $2 == "-ivcB" ) {
			 gsub(/\/BUFF(ERSIZE)*/," ibs");
			 gsub(/@MTB0(:[0-9]*[0-9]*)*/," < /dev/rmt/0 ");
			 print}
		    else if ($1 == "PATH=" ) {
			 gsub(/,/," ");
			 gsub(/:/,"\/");
			 sub(/\/$PATH/,":$PATH");
			 print $0 " \; export PATH"}
		    else if ($1 == "tmpecho") {
		 	 sub(/tmpecho/,"echo ");
			 sub(/DIR/,"`pwd`");
       		 	 sub(/SEA/,"`echo $PATH`");
       			 sub(/DATE/,"`date \"+%d-%h-%y\"`");
       			 sub(/TIME/,"`date \"+%H:%M:%S\"`");
			 print}
		    else if ($1 == "tmpmv") {
			 gsub(/\/V/,"");
			 gsub(/\/D/,"");
			 sub(/tmpmv/,"mv ");
 			 printf("%s ",$1);
			 for ( i = 3; i <= NF; i++ ) { 
			  	printf("%s ",$i)};
			  	printf("%s \n", $2)}  
		    else if ($1 == "cat") {
      				gsub(/\*/,"?"); 
				gsub(/\+/,"*"); 
				gsub(/:/,"/"); print } 
		    else if ($1 == "lp") {
				sub(/(\/)*TITLE/,"");
				sub(/(\/)*LPT/,"printer");
				sub(/(\/)*QUEUE=/,"-d ");
				sub(/(\/)*COP(IES)*\=/,"-n ");
      				gsub(/\*/,"?"); 
				gsub(/\+/,"*"); 
				gsub(/:/,"/"); print } 
		    else if ($1 == "SED") {
			 	sub(/SED/,"ed ")
      				gsub(/\*/,"?"); 
				gsub(/\+/,"*"); 
				gsub(/:/,"/"); print } 
		    else if ($1 == "touch") {
		             if ($0 ~ "\/LINK") {
				     sub(/\/LINK/,"");
				     sub(/touch/,"ln");}
				sub(/\=UDF/,"");
				sub(/\/TYPE/,"");
				sub(/\/FIXED\=[0-9]*/,"");
				print}
		    else if ($1 == "ls") {
				gsub(/\/TY(PE)*\=DIR/," | grep \"^d\" ");
				gsub(/\/TY(PE)*(\=[A-Z]*)*/,"");
      				gsub(/\/TLM/,""); 
      				gsub(/\/DCR/,""); 
      				gsub(/\/LENGTH/,""); 
      				gsub(/\/REC/,""); 
      				gsub(/\/S/,""); 
      				gsub(/\/s/,""); 
      				gsub(/\*/,"?"); 
				gsub(/\+/,"*"); 
				gsub(/:/,"/"); print } 
		    else if ($1 == "batch") {
				gsub(/\/QPRI\=[0-9]*/,"");
				gsub(/\/QOUT(PUT)*\=[1-9A-Z_\.]*/,"");
				gsub(/\/OPERATOR/,"");
				gsub(/\/NOT(IFY)*/,"");
				gsub(/\/M/,"<< \!");
				print}
		    else if ($0 ~ "\-eq") {
			gsub(/\-eq/,"if [ -eq");
			gsub(/if \[ \-eq,\`echo $STRING\`/,"if [ $STRING -eq");
			print $0 "\n then" }
		    else if ($0 ~ "\-ne") {
			gsub(/\-ne/,"if [ -ne");
			print $0 "\n then" }
		    else 
			   print}'  > $fil_name
done
