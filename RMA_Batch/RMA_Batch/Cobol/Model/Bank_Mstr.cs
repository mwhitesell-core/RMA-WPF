using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol.Model
{
    public class Bank_Mstr
    {
        public Guid ROWID { get; set; }
	   public string BANK_CD { get; set; }
	   public string  BANK_NAME { get; set; }
	   public string BANK_ADDRESS1 { get; set; }
	   public string BANK_ADDRESS2 { get; set; }
	   public string BANK_CITY { get; set; }
	   public string BANK_PROV { get; set; }
	   public string BANK_PC1 { get; set; }
	   public string BANK_PC2 { get; set; }
	   public string BANK_PC3 { get; set; }
	   public int  BANK_PC4 { get; set; }
	   public string  BANK_PC5 { get; set; }
	   public int  BANK_PC6 { get; set; }
    }
}
