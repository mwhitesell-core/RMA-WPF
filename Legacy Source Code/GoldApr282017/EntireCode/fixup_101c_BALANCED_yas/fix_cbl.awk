BEGIN {
}

{
## gsub (/_/,"-",$2)    # replace underscores with hyphens 
gsub(/\014/,"",$0)	# remove form feeds
gsub(/\032/,"",$0)	# remove END OF FILES (CTRL-z)
gsub(/""/,"\" \"",$0)	# change null to single blank

#printf "BEFORE:%s\n",$0

# perform variable name changes due to names longer than 30 characters
gsub("hc-subscr-date-msg-nbr-effective-to-r" ,"hc-subscr-dt-msg-no-eff-to-r")
gsub("hc-subscr-date-msg-nbr-eff-to-r1"      ,"hc-subscr-dt-msg-no-eff-to-r1")
gsub("hc-subscr-date-msg-nbr-effective-to-yy","hc-subscr-dt-msg-no-eff-to-yy")
gsub("hc-subscr-date-msg-nbr-effective-to-mm","hc-subscr-dt-msg-no-eff-to-mm")
gsub("hc-subscr-date-msg-nbr-effective-to-dd","hc-subscr-dt-msg-no-eff-to-dd")
gsub("hc-subscr-date-msg-nbr-effective-to"   ,"hc-subscr-dt-msg-no-eff-to")
gsub("hc-subscr-date-last-statement-r"       ,"hc-subscr-date-last-stmnt-r")
gsub("hc-subscr-date-last-statement-yy"      ,"hc-subscr-date-last-stmnt-yy")
gsub("hc-subscr-date-last-statement-mm"      ,"hc-subscr-date-last-stmnt-mm")
gsub("hc-subscr-date-last-statement-dd"      ,"hc-subscr-date-last-stmnt-dd")

gsub("od-subscr-date-msg-nbr-effective-to-r" ,"od-subscr-dt-msg-no-eff-to-r")
gsub("od-subscr-date-msg-nbr-eff-to-r1"      ,"od-subscr-dt-msg-no-eff-to-r1")
gsub("od-subscr-date-msg-nbr-effective-to-yy","od-subscr-dt-msg-no-eff-to-yy")
gsub("od-subscr-date-msg-nbr-effective-to-mm","od-subscr-dt-msg-no-eff-to-mm")
gsub("od-subscr-date-msg-nbr-effective-to-dd","od-subscr-dt-msg-no-eff-to-dd")
gsub("od-subscr-date-msg-nbr-effective-to"   ,"od-subscr-dt-msg-no-eff-to")
gsub("od-subscr-date-last-statement-r"       ,"od-subscr-date-last-stmnt-r")
gsub("od-subscr-date-last-statement-yy"      ,"od-subscr-date-last-stmnt-yy")
gsub("od-subscr-date-last-statement-mm"      ,"od-subscr-date-last-stmnt-mm")
gsub("od-subscr-date-last-statement-dd"      ,"od-subscr-date-last-stmnt-dd")

gsub("chrt-pat-nbr-outstanding-claims"         ,"chrt-pat-nbr-outstand-claims")
gsub("chrt-subscr-date-msg-nbr-effective-to-r" ,"chrt-subscr-dt-msg-no-eff-to-r")
gsub("chrt-subscr-date-msg-nbr-eff-to-r1"      ,"chrt-subscr-dt-msg-no-eff-to-1")
gsub("chrt-subscr-date-msg-nbr-effective-to-yy","chrt-subscr-dt-msg-no-effto-yy")
gsub("chrt-subscr-date-msg-nbr-effective-to-mm","chrt-subscr-dt-msg-no-effto-mm")
gsub("chrt-subscr-date-msg-nbr-effective-to-dd","chrt-subscr-dt-msg-no-effto-dd")
gsub("chrt-subscr-date-msg-nbr-effective-to","od-subscr-dt-msg-no-eff-to")
gsub("chrt-subscr-date-last-statement-r"    ,"chrt-subscr-dt-last-stmnt-r")
gsub("chrt-subscr-date-last-statement-yy"   ,"chrt-subscr-dt-last-stmnt-yy")
gsub("chrt-subscr-date-last-statement-mm"   ,"chrt-subscr-dt-last-stmnt-mm")
gsub("chrt-subscr-date-last-statement-dd"   ,"chrt-subscr-dt-last-stmnt-dd")
gsub("chrt-subscr-date-msg-nbr-effective-to","chrt-subscr-dt-msg-no-eff-to")
gsub("chrt-subscr-date-last-statement"      ,"chrt-subscr-date-last-stmnt")
gsub("chrt-pat-date-last-elig-mailing"      ,"chrt-pat-dt-last-elig-mailing")

gsub("acr-pat-nbr-outstanding-claims"         ,"acr-pat-nbr-outstand-claims")
gsub("acr-subscr-date-msg-nbr-effective-to-r" ,"acr-subscr-dt-msg-no-eff-to-r")
gsub("acr-subscr-date-msg-nbr-eff-to-r1"      ,"acr-subscr-dt-msg-no-eff-to-r1")
gsub("acr-subscr-date-msg-nbr-effective-to-yy","acr-subscr-dt-msg-no-eff-to-yy")
gsub("acr-subscr-date-msg-nbr-effective-to-mm","acr-subscr-dt-msg-no-eff-to-mm")
gsub("acr-subscr-date-msg-nbr-effective-to-dd","acr-subscr-dt-msg-no-eff-to-dd")
gsub("acr-subscr-date-msg-nbr-effective-to","od-subscr-dt-msg-no-eff-to")
gsub("acr-subscr-date-last-statement-r"    ,"acr-subscr-dt-last-stmnt-r")
gsub("acr-subscr-date-last-statement-yy"   ,"acr-subscr-dt-last-stmnt-yy")
gsub("acr-subscr-date-last-statement-mm"   ,"acr-subscr-dt-last-stmnt-mm")
gsub("acr-subscr-date-last-statement-dd"   ,"acr-subscr-dt-last-stmnt-dd")
gsub("acr-subscr-date-msg-nbr-effective-to","acr-subscr-dt-msg-no-eff-to")
gsub("acr-subscr-date-last-statement"      ,"acr-subscr-date-last-stmnt")
gsub("acr-pat-date-last-elig-mailing"      ,"acr-pat-dt-last-elig-mailing")

gsub("ws-subscr-date-msg-nbr-effective-to-r" ,"ws-subscr-dt-msg-no-eff-to-r")
gsub("ws-subscr-date-msg-nbr-eff-to-r1"      ,"ws-subscr-dt-msg-no-eff-to-r1")
gsub("ws-subscr-date-msg-nbr-effective-to-yy","ws-subscr-dt-msg-no-eff-to-yy")
gsub("ws-subscr-date-msg-nbr-effective-to-mm","ws-subscr-dt-msg-no-eff-to-mm")
gsub("ws-subscr-date-msg-nbr-effective-to-dd","ws-subscr-dt-msg-no-eff-to-dd")
gsub("ws-subscr-date-msg-nbr-effective-to"   ,"ws-subscr-dt-msg-no-eff-to")
gsub("ws-subscr-date-last-statement-r"       ,"ws-subscr-date-last-stmnt-r")
gsub("ws-subscr-date-last-statement-yy"      ,"ws-subscr-date-last-stmnt-yy")
gsub("ws-subscr-date-last-statement-mm"      ,"ws-subscr-date-last-stmnt-mm")
gsub("ws-subscr-date-last-statement-dd"      ,"ws-subscr-date-last-stmnt-dd")

gsub("subscr-date-msg-nbr-effective-to-r" ,"subscr-date-msg-nbr-eff-to-r")
gsub("subscr-date-msg-nbr-effective-to-yy","subscr-date-msg-nbr-eff-to-yy")
gsub("subscr-date-msg-nbr-effective-to-mm","subscr-date-msg-nbr-eff-to-mm")
gsub("subscr-date-msg-nbr-effective-to-dd","subscr-date-msg-nbr-eff-to-dd")
gsub("subscr-date-msg-nbr-effective-to"   ,"subscr-date-msg-nbr-eff-to")

gsub("fee-curr-oma-ind-card-requireds" ,"fee-curr-oma-ind-card-reqs")
gsub("fee-curr-add-on-perc-or-flat-ind","fee-curr-add-on-perc-flat-ind")
gsub("fee-prev-oma-ind-card-requireds" ,"fee-prev-oma-ind-card-reqs")
gsub("fee-prev-add-on-perc-or-flat-ind","fee-prev-add-on-perc-flat-ind")

gsub("month-descs-and-max-days-in-mth","month-descs-and-max-days-mth")

gsub("clmhdr-manual-and-tape-payments"   ,"clmhdr-manual-and-tape-paymnts")
gsub("clmhdr-orig-batch-nbr-another-def","clmhdr-orig-batch-nbr-next-def")

gsub("da1-check-if-chart-or-valid-ohip","da1-chk-if-chart-or-valid-ohip")
gsub("wd0-90-set-ohip-tape-submit-ind","wd0-90-set-ohip-tape-submt-ind")
gsub("yf2-search-oma-recs-for-addon-cd","yf2-search-oma-recs-4-addon-cd")
gsub("yf3-search-oma-recs-for-addon-cd","yf3-search-oma-recs-4-addon-cd")
gsub("zh0-10-acpt-old-new-batch-option","zh0-10-acpt-old-new-batch-opt")
gsub("zh1-acpt-old-or-new-batch-option","zh1-acpt-old-or-new-batch-opt")

if ( ($1 == "assign" && $2 == "index") || $1 == "contiguous" || $1 == "space" || $1 == "expunge")
 {
#   (comment out these statements) 
    printf "*%s \n",$0
 }
 else
 if ($1 == "call" && $2 == "program")
  {
    $0=tolower($0)	# lowercase name of program being called
    printf "%s \n",$0
  }
  else
  {
    printf "%s \n",$0
  }
}
