using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public class ScreenData
    {
        public string RowData { get; set; }
        public string GroupNumberLevel1 { get; set; }
        public string GroupNameLevel1 { get; set; }

        public string GroupNumberLevel2 { get; set; }
        public string GroupNameLevel2 { get; set; }

        public string GroupNumberLevel3 { get; set; }
        public string GroupNameLevel3 { get; set; }
        public string GroupNumberSub { get; set; }
        public string Line { get; set; }
        public int Col { get; set; }
        public string Data1 { get; set; }
        public string Data2 { get; set; }
        public string Data3 { get; set; }
        public string Data4 { get; set; }
        public string Data5 { get; set; }
        public rowDataType RowDataType { get; set; }
        public bool IsRequired { get; set; }
        public string NumericFormat { get; set; }
        public string InputVariableName { get; set; }
        public int MaxLength { get; set; }
        public rowStatus RowStatus { get; set; }
        public rowClassType RowClassType { get; set; }
    }
}
