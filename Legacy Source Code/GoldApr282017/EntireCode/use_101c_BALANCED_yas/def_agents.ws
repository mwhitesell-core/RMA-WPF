*  
*    -----modification history------  
*    date      who          what/why  
* filename: def_agents.ws
*
* 90/jul/01  b. e.        - original  
* 90/sep/10  b. e.        - added "4" to definition of direct bill  
* 91/feb/11  m.c.  - sms 138 - use agent 2 for ohip wcb  
* 95/oct/03  yas   - pdr 631 - use agent 5 for moh reduction  
* 1999/Jun/18 S.B  - Combined Sick Kids and RMA agents.
* 2001/nov/06 B.E. - added agent 3 for ICU (revenue clinic 85) direct bills
* 2013/Jan/29 MC1  - since 2005/12/15 , agent 3 is no longer allowed        

01  def-agent-code				pic x(01).  
    88 def-agent-ohip			value "0".  
    88 def-agent-in-pat-diag-billing   	value "1".  
    88 def-agent-ohip-wcb 		value "2".  
*    88 def-agent-3-not-used		value "3".  
    88 def-agent-icu-direct-bill	value "3".  
    88 def-agent-ohip-not-valid		value "4".  
    88 def-agent-moh-reduction		value "5".  
* 2013/01/29 - MC1
*    88 def-agent-bill-direct		value "6","4","3".  
    88 def-agent-bill-direct		value "6","4".  
    88 def-agent-misc-payments		value "7".  
    88 def-agent-alternate-funding	value "8".  
    88 def-agent-wcb 			value "9".  
  
    88 def-agent-ifhp-direct            value "x".
    88 def-agent-ontario-direct         value "x".
    88 def-agent-foreign-direct         value "x".
    88 def-agent-reciprocal             value "x".
    88 def-agent-quebec-direct          value "x".
