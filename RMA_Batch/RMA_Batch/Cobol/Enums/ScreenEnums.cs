using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol
{
    public enum rowStatus
    {
        GroupName = 1,
        Display = 2,
        Input = 3,
        InputAutoTab = 4,
        DisplayInput = 5
    }
    public enum rowDataType
    {
        AlphaNumeric = 1,
        Numeric = 2,
        NumericBlankWhenZero = 3,
        AlphaNumericPassword = 4
    }

    public enum rowClassType
    {
        Simple = 1,
        Multiple = 2
    }

    public enum variableType
    {
        RegularType = 1,
        SingleDimension = 2,
        DoubleDimension = 3
    }

    public enum LineDataType
    {
        Paragraph = 1,
        Move = 2,
        UnParsedCode = 3
    }

    public enum PerformType
    {
        PerformOnly = 1,
        PerformThru = 2,
        PerformUntil = 3,
        PerformTimes = 4,
        PerformVarying = 5,
        PerformThruUntil = 6,
        PerformVaryingFromByUntil = 7
    }
   
}
