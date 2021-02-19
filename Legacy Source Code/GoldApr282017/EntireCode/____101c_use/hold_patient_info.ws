* file: hold_patient_info.ws
* 01/mar/08 B.E. -original - taken from u011 and inserted as copybook
*			     in u011 and newu703
* 02/mar/28 M.C. - changed redefinition of hold-chart-no. Was original 2 field
*		   and changed to a single x(10) field.
* 02/apr/29 B.E. - changed size of hold-chart-no from x(10) to x(11) to hold
*		   St Joes hospital chart numbers.

*
*   (FILE RELATED - KEYS STORAGE.)
*
01  hold-chart-no.
* 	   05  hold-chart-alpha                        pic x.
*    	05  hold-chart-id-no                        pic x(9).
*    	05  hold-chart-id-no                        pic x(10).
    05  hold-chart-id-no                        pic x(11).

01  hold-health-nbr                             pic 9(10).

01  hold-ohip-mmyy.
    05  hold-ohip-no                            pic x(8).
    05  hold-ohip-mm                            pic xx.
    05  hold-ohip-yy                            pic xx.
    05  filler                                  pic x(3).

01  hold-orig-chart-no                          pic x(15).
01  hold-new-chart-no                           pic x(15).

01  hold-acronym.
    05  hold-last-name                          pic x(6).
    05  hold-first-name                         pic x(3).
01  hold-orig-acronym                           pic x(9).
01  hold-new-acronym                            pic x(9).

01  hold-version-cd.
    05  hold-version-cd-1                       pic x.
    05  hold-version-cd-2                       pic x.

01  save-pat-ikey.
    05  save-con-nbr                            pic 99.
    05  save-i-nbr                              pic 9(12).


*  FLAGS

01  flag-ohip-vs-chart                          pic xx.
    88  health                                  value "H ".
    88  ohip                                    value "O ".
    88  chart                                   value "C ".
    88  health-and-ohip                         value "HO".
    88  health-and-chart                        value "HC".
    88  ohip-and-chart                          value "OC".
    88  all-three                               value "AL".

*
*   (FEEDBACK AND OCCURRENCE.)
*
77  pat-occur                                   pic 9(12).
77  pat-occur-od                                pic 9(12).
77  pat-occur-hc                                pic 9(12).
77  pat-occur-acr                               pic 9(12).
77  pat-occur-chrt                              pic 9(12).
77  hold-pat-occur                              pic 9(12).
77  hold-orig-acron-pat-occur                   pic 9(12).
77  hold-orig-chart-pat-occur                   pic 9(12).
77  ws-feedback-pat-mstr                        pic x(4).
77  hold-feedback-pat-mstr                      pic x(4).
77  hold-orig-acron-feedback                    pic x(4).
77  hold-orig-chrt-feedback                     pic x(4).
77  hold-orig-hc-feedback                       pic x(4).
77  hold-orig-od-feedback                       pic x(4).
77  feedback-pat-mstr                           pic x(4).
77  feedback-pat-mstr-od                        pic x(4).
77  feedback-pat-mstr-hc                        pic x(4).
77  feedback-pat-mstr-acr                       pic x(4).
77  feedback-pat-mstr-chrt                      pic x(4).

