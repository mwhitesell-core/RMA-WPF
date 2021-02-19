brad+m020.qks:;			        $cmd/batch_update_f050_f051_f060
brad+m020.qks:;      let comline = "$cmd/batch_update_f050_f051_f060 " + ascii(doc-nbr,3) + " " + ascii(doc-dept,2) 
brad+m020.qks:        let comline = "$cmd/batch_update_f050_f051_f060 " + ascii(doc-nbr,3) + " " + ascii(doc-dept,2)  + " " + ascii(w-start-date,8)
fixf050.qks:screen $pb_obj/fixf050
fixf050.qks:file f050-doc-revenue-mstr
fixf050.qks:field docrev-clinic-1-2 of f050-doc-revenue-mstr required nochange &
fixf050.qks:field docrev-dept of f050-doc-revenue-mstr required nochange  &
fixf050.qks:field docrev-doc-nbr of f050-doc-revenue-mstr required nochange &
fixf050.qks:field docrev-location of f050-doc-revenue-mstr required nochange &
fixf050.qks:field docrev-oma-code of f050-doc-revenue-mstr required nochange &
fixf050.qks:field docrev-adj-cd-sub-type of f050-doc-revenue-mstr required &
fixf050.qks:      nochange id same lookup noton f050-doc-revenue-mstr viaindex &
fixf050.qks:      docrev-key using docrev-key of f050-doc-revenue-mstr &
fixf050.qks:field docrev-mtd-in-rec of f050-doc-revenue-mstr  label "IN  $  :"
fixf050.qks:field docrev-mtd-in-svc of f050-doc-revenue-mstr  label "IN  SVC:" pic "    ^^^^^^^"
fixf050.qks:field docrev-mtd-out-rec of f050-doc-revenue-mstr label "OUT $  :"
fixf050.qks:field docrev-mtd-out-svc of f050-doc-revenue-mstr label "OUT SVC:" pic "    ^^^^^^^"
fixf050.qks:field docrev-ytd-in-rec of f050-doc-revenue-mstr
fixf050.qks:field docrev-ytd-in-svc of f050-doc-revenue-mstr  pic "    ^^^^^^^"
fixf050.qks:field docrev-ytd-out-rec of f050-doc-revenue-mstr
fixf050.qks:field docrev-ytd-out-svc of f050-doc-revenue-mstr pic "    ^^^^^^^"
