using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol.Model
{
    public class Dept_Mstr
    {
       public Guid ROWID { get; set; }
	   public int DEPT_NBR { get; set; } 
	   public string DEPT_NAME { get; set; }
	   public string DEPT_ADDR1 { get; set; } 
	   public string DEPT_ADDR2 { get; set; }
	   public string DEPT_ADDR3 { get; set; }
	   public string DEPT_CHAIRMAN { get; set; }
	   public string DEPT_CO_ORDINATOR { get; set; }
	   public int  DEPT_NBR_DOCS { get; set; }
	   public int  DEPT_COMPANY { get; set; }
	   public string FILLER { get; set; }	    
    }
}
