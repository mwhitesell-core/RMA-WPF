#region "Screen Comments"

//#> program-id.     r124a_paycode7.qzs
//
//       ((C)) Dyad Technologies
//
//    PURPOSE: Print the SERVICE CHARGES  for the physician
//		for those like JCC in paycode 7 
//             - PHASE I: create subfile of MTD column 1 and 2 values
//			using MTD and YTD columns of regular file/reports

//    MODIFICATION HISTORY
// DATE SAF#  WHO        DESCRIPTION
// 2014/apr/12 1301  be	- clone from r124a.qzs
//2014/apr/12       be1	- print blanks instead of zeros

#endregion

using Core.DataAccess.SqlServer;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.ReportFramework;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace RMA_DATA
{
    public class R124A_PAYCODE7 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R124A_PAYCODE7";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        //private Reader rdrF119_DOCTOR_YTD = new Reader();
        //private Reader rdrF190_COMP_CODES = new Reader();
        //private Reader rdrF020_DOCTOR_MSTR = new Reader();
        //private Reader rdrF020_DOCTOR_EXTRA = new Reader();
        //private Reader rdrF070_DEPT_MSTR = new Reader();
        //private Reader rdrF080_BANK_MSTR = new Reader();
        //private Reader rdrCONSTANTS_MSTR_REC_6 = new Reader();
        //private Reader rdrF112_PYCDCEILINGS = new Reader();
        private Reader rdrDATA = new Reader();

        public string SubOperationAt { get; private set; }

        //#CORE_BEGIN_INCLUDE: F119_DOCTOR_YTD"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 2017-07-24 7:27:24 PM

        private string F119_REC_MSG()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = "B";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string F119_REC_MTD_YTD()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = "A";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        //#CORE_END_INCLUDE: F119_DOCTOR_YTD"

        //#CORE_BEGIN_INCLUDE: PRINTER_CODES"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 2017-07-24 7:27:24 PM

        private decimal X_ESC_NUM()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = 27m;
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string X_ESC()
        {
            string strReturnValue = string.Empty;

            try
            {
                //strReturnValue = QDesign.Substring(QDesign.Characters(X_ESC_NUM()), 1, 1);
                strReturnValue = "\x1B";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal X_FF_NUM()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = 12m;
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string X_FF()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Substring(QDesign.Characters(X_FF_NUM()), 1, 1);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_FF_PDF()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&l0H";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal X_LF_NUM()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = 10;
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string X_LF()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Substring(QDesign.Characters(X_LF_NUM()), 1, 1);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal X_CR_NUM()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = 13m;
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string X_CR()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Substring(QDesign.Characters(X_CR_NUM()), 1, 1);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_LINE_CTRL()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_CR();
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_PORTRAIT()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&l0O";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_PORTRAIT_REVERSE()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&l2O";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_LANDSCAPE()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&l1O";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_LANDSCAPE_REVERSE()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&l3O";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_FONT_SYMBOL_ASCII()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "(0U";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_FONT_SPACING_FIXED()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "(s0P";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_FONT_SPACING_PROP()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "(s1P";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_FONT_PITCH_6()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "(s6H";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_FONT_PITCH_8()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "(s8H";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_FONT_PITCH_9()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "(s9H";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_FONT_PITCH_10()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "(s10H";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_FONT_PITCH_12()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "(s12H";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_FONT_PITCH_13()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "(s13H";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_FONT_PITCH_14()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "(s14H";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_FONT_PITCH_1666()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "(s16.66H";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_FONT_HEIGHT_6()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "(s6.00V";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_FONT_HEIGHT_8()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "(s8.00V";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_FONT_HEIGHT_9()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "(s9.00V";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_FONT_HEIGHT_10()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "(s10.00V";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_FONT_HEIGHT_12()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "(s12.00V";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_FONT_HEIGHT_14()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "(s14.00V";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_FONT_HEIGHT_1425()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "(s14.25V";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_FONT_HEIGHT_16()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "(s16.00V";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_FONT_HEIGHT_18()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "(s18.00V";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_FONT_HEIGHT_20()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "(s20.00V";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_FONT_UPRIGHT()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "(s000S";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_FONT_ITALIC()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "(s001S";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_FONT_OUTLINE()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "(s032S";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_FONT_SHADOW()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "(s128S";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_POINT_6()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&k2S";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_POINT_8()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&k4S";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_LINES_PER_INCH()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&l6D";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_LINES_PER_INCH_1()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&l1D";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_LINES_PER_INCH_2()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&l2D";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_LINES_PER_INCH_3()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&l3D";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_LINES_PER_INCH_4()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&l4D";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_LINES_PER_INCH_6()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&l6D";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_LINES_PER_INCH_8()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&l8D";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_LINES_PER_INCH_12()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&l12D";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_LINES_PER_INCH_13()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&l13D";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_LINES_PER_INCH_16()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&l16D";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_LINES_PER_INCH_24()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&l24D";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_LINES_PER_INCH_48()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&l48D";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_LIGHT()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "(s-3B";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_MEDIUM()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "(s0B";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_MEDIUM_BOLD()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "(s2B";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_BOLD()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "(s3B";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_CGTIMES()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "(s4101T";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_CGCENT_SCHOOL_B()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "(s4119T";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_ITC_AVANT_GARDE()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "(s4127T";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_UNIVERS()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "(s4148T";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_ANTIQUE_OLIVE()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "(s4168T";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_SET_MARGIN_TOP_PART1()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&l";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_SET_MARGIN_TOP_PART2()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = "E";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_SET_PAGE_LENGTH_PART1()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&l";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_SET_PAGE_LENGTH_PART2()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = "F";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_SET_MARGIN_LEFT_PART1()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&a";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_SET_MARGIN_LEFT_PART2()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = "L";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_SET_MARGIN_RIGHT_PART1()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&a";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_SET_MARGIN_RIGHT_PART2()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = "M";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_COLUMN_5()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&a005C";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_COLUMN_27()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&a027C";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_COLUMN_34()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&a034C";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_COLUMN_47()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&a047C";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_COLUMN_58()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&a058C";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_COLUMN_83()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&a083C";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_COLUMN_91()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&a091C";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_COLUMN_93()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&a093C";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_COLUMN_100()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&a100C";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_COLUMN_101()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&a101C";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_COLUMN_103()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&a103C";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_COLUMN_135()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&a135C";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_COLUMN_153()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&a153C";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_COLUMN_160()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&a160C";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_COLUMN_163()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&a163C";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_COLUMN_194()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&a194C";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_COLUMN_209()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&a209C";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_COLUMN_213()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&a213C";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_COLUMN_214()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&a214C";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_COLUMN_228()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&a228C";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_UP_A_ROW()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&a-1R";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_BACKWARD_DOT_125()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "*p-125X";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_BACKWARD_DOT_130()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "*p-130X";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_BACKWARD_DOT_135()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "*p-135X";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_BACKWARD_DOT_170()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "*p-170X";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_UNDERLINE_ON()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&d0D";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_FORWARD_DOT_156()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "*p+156X";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_FORWARD_DOT_159()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "*p+159X";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_FORWARD_DOT_162()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "*p+162X";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_FORWARD_DOT_170()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "*p+170X";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_FORWARD_DOT_175()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "*p+175X";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_FORWARD_DOT_180()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "*p+180X";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_FORWARD_DOT_195()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "*p+195X";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_UNDERLINE_OFF()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&d@";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_BACKWARD_DOT_195()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "*p-200X";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_UP_DOT_10()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "*p-10Y";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_DOWN_A_ROW()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&a+1R";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_DOWN_5_ROWS()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&a+5R";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        //#CORE_END_INCLUDE: PRINTER_CODES"

        #endregion

        #region " Renaissance Data "

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                // Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                // Create Subfile.
                SubFile = true;
                SubFileName = "R124A_PAYCODE7";
                SubFileType = SubFileType.Keep;

                Sort = "";

                // Start report data processing.
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }

        #endregion

        #region " Renaissance Statements "

        #region " ACCESS "

        private void Access_Data()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT alldata.* FROM (SELECT mstr.DOC_NBR, mstr.DOC_DEPT, mstr.DOC_FULL_PART_IND, mstr.DOC_BANK_NBR, mstr.DOC_BANK_BRANCH, mstr.DOC_PAYEFT, mstr.DOC_EP_DATE_DEPOSIT, ");
            strSQL.Append("mstr.DOC_EP_PED, mstr.DOC_BANK_ACCT, mstr.YTDCEA_PRT_FORMAT, mstr.CEICEA_PRT_FORMAT, mstr.YTDCEX_PRT_FORMAT, mstr.CEICEX_PRT_FORMAT, mstr.DOC_INIT1, mstr.DOC_INIT2, mstr.DOC_INIT3, ");
            strSQL.Append("mstr.DOC_NAME, ");
            strSQL.Append("ytd.COMP_CODE, ytd.AMT_MTD, ytd.AMT_YTD, ytd.PROCESS_SEQ, ytd.REC_TYPE, ytd.TEXT, ");
            strSQL.Append("comp.COMP_TYPE, comp.DESC_SHORT, comp.COMP_CODE_GROUP, comp.DESC_LONG, ");
            strSQL.Append("dept.DEPT_NBR, dept.DEPT_COMPANY, dept.DEPT_NAME, ");
            strSQL.Append("constmstr.CURRENT_EP_NBR, constmstr.FIRST_EP_NBR_OF_CAL_YR, constmstr.LAST_EP_NBR_OF_CAL_YR, ");
            strSQL.Append("bank.BANK_CD, bank.BANK_NAME, bank.BANK_ADDRESS1, ");
            strSQL.Append("extra.YTDREQ_PRT_FORMAT, extra.CEIREQ_PRT_FORMAT, extra.YTDTAR_PRT_FORMAT, extra.CEITAR_PRT_FORMAT ");
            strSQL.Append("FROM [INDEXED].[F119_DOCTOR_YTD] ytd ");
            strSQL.Append("LEFT OUTER JOIN [101C].[INDEXED].[F190_COMP_CODES] comp ON ytd.COMP_CODE = comp.COMP_CODE ");
            strSQL.Append("LEFT OUTER JOIN [INDEXED].[F020_DOCTOR_MSTR] mstr ON ytd.DOC_NBR = mstr.DOC_NBR ");
            strSQL.Append("LEFT OUTER JOIN [INDEXED].[F020_DOCTOR_EXTRA] extra ON ytd.DOC_NBR = extra.DOC_NBR ");
            strSQL.Append("LEFT OUTER JOIN [101C].[INDEXED].[F070_DEPT_MSTR] dept ON dept.DEPT_NBR = mstr.DOC_dept ");
            strSQL.Append("LEFT OUTER JOIN [101C].[INDEXED].[F080_BANK_MSTR] bank ON CONCAT(RIGHT('0000' + RTRIM(mstr.DOC_BANK_NBR), 4), RIGHT('00000' + RTRIM(mstr.DOC_BANK_BRANCH), 5)) = bank.BANK_CD ");
            strSQL.Append("INNER JOIN [INDEXED].[CONSTANTS_MSTR_REC_6] constmstr ON constmstr.CONST_REC_NBR = 6 ");
            strSQL.Append("INNER JOIN [INDEXED].[F112_PYCDCEILINGS] ceil on ceil.EP_NBR = constmstr.CURRENT_EP_NBR AND ceil.DOC_NBR = mstr.DOC_NBR ");
            strSQL.Append("WHERE (ceil.DOC_PAY_CODE = '7')) AS alldata ");

            rdrDATA.GetDataTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }


        #endregion

        #region " CHOOSE "

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);


            return strChoose.ToString();
        }

        #endregion

        #region " SELECT IF "

        #endregion

        #region " DEFINES "

        private decimal X_DEPOSIT()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = rdrDATA.GetNumber("DOC_PAYEFT");
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_DEPOSIT_DATE()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = rdrDATA.GetNumber("DOC_EP_DATE_DEPOSIT");
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_PED()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = rdrDATA.GetNumber("DOC_EP_PED");
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string X_BANK_ACCOUNT()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.LeftJustify(rdrDATA.GetString("DOC_BANK_ACCT"));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_BANK_ACCOUNT_PRIVACY_MASKED()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.Substring(X_BANK_ACCOUNT(), 1, 1) == " ")
                {
                    strReturnValue = "************";
                }
                else if (QDesign.Substring(X_BANK_ACCOUNT(), 2, 1) == " ")
                    strReturnValue = "************";
                else if (QDesign.Substring(X_BANK_ACCOUNT(), 3, 1) == " ")
                    strReturnValue = "************";
                else if (QDesign.Substring(X_BANK_ACCOUNT(), 4, 1) == " ")
                    strReturnValue = "************";
                else if (QDesign.Substring(X_BANK_ACCOUNT(), 5, 1) == " ")
                    strReturnValue = "************";
                else if (QDesign.Substring(X_BANK_ACCOUNT(), 6, 1) == " ")
                    strReturnValue = "********" + QDesign.Substring(X_BANK_ACCOUNT(), 2, 4);
                else if (QDesign.Substring(X_BANK_ACCOUNT(), 7, 1) == " ")
                    strReturnValue = "********" + QDesign.Substring(X_BANK_ACCOUNT(), 3, 4);
                else if (QDesign.Substring(X_BANK_ACCOUNT(), 8, 1) == " ")
                    strReturnValue = "********" + QDesign.Substring(X_BANK_ACCOUNT(), 4, 4);
                else if (QDesign.Substring(X_BANK_ACCOUNT(), 9, 1) == " ")
                    strReturnValue = "********" + QDesign.Substring(X_BANK_ACCOUNT(), 5, 4);
                else if (QDesign.Substring(X_BANK_ACCOUNT(), 10, 1) == " ")
                    strReturnValue = "********" + QDesign.Substring(X_BANK_ACCOUNT(), 6, 4);
                else if (QDesign.Substring(X_BANK_ACCOUNT(), 11, 1) == " ")
                    strReturnValue = "********" + QDesign.Substring(X_BANK_ACCOUNT(), 7, 4);
                else if (QDesign.Substring(X_BANK_ACCOUNT(), 12, 1) == " ")
                    strReturnValue = "********" + QDesign.Substring(X_BANK_ACCOUNT(), 8, 4);
                else
                    strReturnValue = "********" + QDesign.Substring(X_BANK_ACCOUNT(), 9, 4);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_BANK()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = rdrDATA.GetString("BANK_NAME");
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_BRANCH()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = rdrDATA.GetString("BANK_ADDRESS1");
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_YTDCEA_POS_PRT()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Substring(rdrDATA.GetString("YTDCEA_PRT_FORMAT"), 1, 3);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_YTDCEA_VAL_PRT()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Substring(rdrDATA.GetString("YTDCEA_PRT_FORMAT"), 4, 10);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CEICEA_POS_PRT()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Substring(rdrDATA.GetString("CEICEA_PRT_FORMAT"), 1, 3);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CEICEA_VAL_PRT()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Substring(rdrDATA.GetString("CEICEA_PRT_FORMAT"), 4, 10);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_YTDCEX_POS_PRT()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Substring(rdrDATA.GetString("YTDCEX_PRT_FORMAT"), 1, 3);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_YTDCEX_VAL_PRT()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Substring(rdrDATA.GetString("YTDCEX_PRT_FORMAT"), 4, 10);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        #endregion

        private string X_CEICEX_POS_PRT()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Substring(rdrDATA.GetString("CEICEX_PRT_FORMAT"), 1, 3);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CEICEX_VAL_PRT()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Substring(rdrDATA.GetString("CEICEX_PRT_FORMAT"), 4, 10);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_DEPT_NAME()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(rdrDATA.GetString("DEPT_NAME")) != QDesign.NULL(""))
                {
                    strReturnValue = rdrDATA.GetString("DEPT_NAME");
                }
                else
                {
                    strReturnValue = "UNKNOWN DEPARTMENT";
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_FULL_PART_IND()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (rdrDATA.GetString("DOC_FULL_PART_IND") == "F")
                {
                    strReturnValue = "GFT";
                }
                else if (rdrDATA.GetString("DOC_FULL_PART_IND") == "C")
                {
                    strReturnValue = "CLINICAL SCHOLAR";
                }
                else if (rdrDATA.GetString("DOC_FULL_PART_IND") == "S")
                {
                    strReturnValue = "PLASTIC SURGERY";
                }
                else if (rdrDATA.GetString("DOC_FULL_PART_IND") == "P")
                {
                    strReturnValue = "Non-GFT";
                }
                else
                {
                    strReturnValue = "CLASSIFICATION UNKNOWN";
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_DOC_ID_INFO()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = "Dr. " + (rdrDATA.GetString("DOC_INIT1") + rdrDATA.GetString("DOC_INIT2") + rdrDATA.GetString("DOC_INIT3")).Trim() + " " + rdrDATA.GetString("DOC_NAME").Trim() + "    " + QDesign.ASCII(rdrDATA.GetNumber("DOC_DEPT"), 2) + "-" + rdrDATA.GetString("DOC_NBR") + "  ";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_YTDREQ_POS_PRT()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Substring(rdrDATA.GetString("YTDREQ_PRT_FORMAT"), 1, 3);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_YTDREQ_VAL_PRT()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Substring(rdrDATA.GetString("YTDREQ_PRT_FORMAT"), 4, 10);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CEIREQ_POS_PRT()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Substring(rdrDATA.GetString("CEIREQ_PRT_FORMAT"), 1, 3);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CEIREQ_VAL_PRT()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Substring(rdrDATA.GetString("CEIREQ_PRT_FORMAT"), 4, 10);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_YTDTAR_POS_PRT()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Substring(rdrDATA.GetString("YTDTAR_PRT_FORMAT"), 1, 3);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_YTDTAR_VAL_PRT()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Substring(rdrDATA.GetString("YTDTAR_PRT_FORMAT"), 4, 10);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CEITAR_POS_PRT()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Substring(rdrDATA.GetString("CEITAR_PRT_FORMAT"), 1, 3);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CEITAR_VAL_PRT()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.Substring(rdrDATA.GetString("CEITAR_PRT_FORMAT"), 4, 10);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_PERIOD()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = ".";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal X_COLUMN_TO_PRINT_IN()
        {
            decimal decReturnValue = 0;

            try
            {
                if (rdrDATA.GetString("COMP_CODE") == "DEPINC" || rdrDATA.GetString("COMP_CODE") == "SVCRTE" || rdrDATA.GetString("COMP_CODE") == "KEYHRS" || rdrDATA.GetString("COMP_CODE") == "KEYRTE")
                {
                    decReturnValue = 1;
                }
                else
                {
                    decReturnValue = 2;
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }


        private decimal X_MTD_DOLLARS()
        {
            decimal decReturnValue = 0;

            try
            {
                if (rdrDATA.GetString("REC_TYPE") == "A" && X_COLUMN_TO_PRINT_IN() == 1)
                {
                    decReturnValue = Math.Truncate(rdrDATA.GetNumber("AMT_MTD") / 100);
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_MTD_CENTS()
        {
            decimal decReturnValue = 0;

            try
            {
                if (rdrDATA.GetString("REC_TYPE") == "A" && X_COLUMN_TO_PRINT_IN() == 1)
                {
                    decReturnValue = QDesign.PHMod(Math.Abs(rdrDATA.GetNumber("AMT_MTD")), 100);
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_YTD_DOLLARS()
        {
            decimal decReturnValue = 0;

            try
            {
                if (rdrDATA.GetString("REC_TYPE") == "A" && X_COLUMN_TO_PRINT_IN() == 2)
                {
                    decReturnValue = Math.Truncate(rdrDATA.GetNumber("AMT_MTD") / 100);
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_YTD_CENTS()
        {
            decimal decReturnValue = 0;

            try
            {
                if (rdrDATA.GetString("REC_TYPE") == "A" && X_COLUMN_TO_PRINT_IN() == 2)
                {
                    decReturnValue = QDesign.PHMod(Math.Abs(rdrDATA.GetNumber("AMT_MTD")), 100);
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_MTD_DOLLARS_ABS()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = Math.Abs(X_MTD_DOLLARS());
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_YTD_DOLLARS_ABS()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = Math.Abs(X_YTD_DOLLARS());
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_MTD_CTRL()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(X_MTD_DOLLARS_ABS()) < 10)
                {
                    decReturnValue = 21;
                }
                else if (QDesign.NULL(X_MTD_DOLLARS_ABS()) < 100)
                {
                    decReturnValue = 42;
                }
                else if (QDesign.NULL(X_MTD_DOLLARS_ABS()) < 1000)
                {
                    decReturnValue = 63;
                }
                else if (QDesign.NULL(X_MTD_DOLLARS_ABS()) < 10000)
                {
                    decReturnValue = 84;
                }
                else if (QDesign.NULL(X_MTD_DOLLARS_ABS()) < 100000)
                {
                    decReturnValue = 105;
                }
                else if (QDesign.NULL(X_MTD_DOLLARS_ABS()) < 1000000)
                {
                    decReturnValue = 126;
                }
                else if (QDesign.NULL(X_MTD_DOLLARS_ABS()) < 10000000)
                {
                    decReturnValue = 147;
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_YTD_CTRL()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(X_YTD_DOLLARS_ABS()) < 10)
                {
                    decReturnValue = 21;
                }
                else if (QDesign.NULL(X_YTD_DOLLARS_ABS()) < 100)
                {
                    decReturnValue = 42;
                }
                else if (QDesign.NULL(X_YTD_DOLLARS_ABS()) < 1000)
                {
                    decReturnValue = 63;
                }
                else if (QDesign.NULL(X_YTD_DOLLARS_ABS()) < 10000)
                {
                    decReturnValue = 84;
                }
                else if (QDesign.NULL(X_YTD_DOLLARS_ABS()) < 100000)
                {
                    decReturnValue = 105;
                }
                else if (QDesign.NULL(X_YTD_DOLLARS_ABS()) < 1000000)
                {
                    decReturnValue = 126;
                }
                else if (QDesign.NULL(X_YTD_DOLLARS_ABS()) < 10000000)
                {
                    decReturnValue = 147;
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_MTD_CTR2()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(X_MTD_DOLLARS()) < 0)
                {
                    decReturnValue = X_MTD_CTRL() + 14;
                }
                else
                {
                    decReturnValue = X_MTD_CTRL();
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string X_MTD_SIGN()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(X_MTD_DOLLARS()) < 0)
                {
                    strReturnValue = "-";
                }
                else
                {
                    strReturnValue = " ";
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal X_YTD_CTR2()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(X_YTD_DOLLARS()) < 0)
                {
                    decReturnValue = X_YTD_CTRL() + 14;
                }
                else
                {
                    decReturnValue = X_YTD_CTRL();
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string X_YTD_SIGN()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(X_YTD_DOLLARS()) < 0)
                {
                    strReturnValue = "-";
                }
                else
                {
                    strReturnValue = " ";
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal X_MTD_CTR3()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(X_MTD_DOLLARS_ABS()) < 1000)
                {
                    decReturnValue = X_MTD_CTR2();
                }
                else
                {
                    decReturnValue = X_MTD_CTR2() + 14;
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_YTD_CTR3()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(X_YTD_DOLLARS_ABS()) < 1000)
                {
                    decReturnValue = X_YTD_CTR2();
                }
                else
                {
                    decReturnValue = X_YTD_CTR2() + 14;
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string X_MTD_LIT1()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (rdrDATA.GetString("COMP_CODE") != "SVCCHG" && rdrDATA.GetString("COMP_CODE") != "KEYCHG")
                {
                    strReturnValue = HPIII_COLUMN_100();
                }
                else
                {
                    strReturnValue = HPIII_COLUMN_100() + HPIII_UP_A_ROW() + HPIII_BACKWARD_DOT_135() + HPIII_UNDERLINE_ON() + HPIII_FORWARD_DOT_195() + HPIII_UNDERLINE_OFF() + HPIII_DOWN_A_ROW() + HPIII_COLUMN_100();
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_YTD_LIT1()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (rdrDATA.GetString("COMP_CODE") != "DOCCHG" && rdrDATA.GetString("COMP_CODE") != "FINCHG")
                {
                    strReturnValue = HPIII_COLUMN_153();
                }
                else
                {
                    strReturnValue = HPIII_COLUMN_153() + HPIII_UP_A_ROW() + HPIII_BACKWARD_DOT_135() + HPIII_UNDERLINE_ON() + HPIII_FORWARD_DOT_195() + HPIII_UNDERLINE_OFF() + HPIII_DOWN_A_ROW() + HPIII_COLUMN_153();
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_MTD_LIT2()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "*p-" + QDesign.ASCII(X_MTD_CTR3(), 3).Trim() + "X"; ;
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_YTD_LIT2()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "*p-" + QDesign.ASCII(X_YTD_CTR3(), 3).Trim() + "X"; ;
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_MTD_DOLLARS_ABS_A()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.ASCII(X_MTD_DOLLARS_ABS(), 7);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_YTD_DOLLARS_ABS_A()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.ASCII(X_YTD_DOLLARS_ABS(), 7);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_MTD_DOLLARS_ABS_B()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(X_MTD_DOLLARS_ABS()) > 999999)
                {
                    strReturnValue = X_MTD_SIGN() + X_MTD_DOLLARS_ABS_A();
                }
                else if (QDesign.NULL(X_MTD_DOLLARS_ABS()) > 99999)
                {
                    strReturnValue = X_MTD_SIGN() + QDesign.Substring(X_MTD_DOLLARS_ABS_A(), 2, 6);
                }
                else if (QDesign.NULL(X_MTD_DOLLARS_ABS()) > 9999)
                {
                    strReturnValue = X_MTD_SIGN() + QDesign.Substring(X_MTD_DOLLARS_ABS_A(), 3, 5);
                }
                else if (QDesign.NULL(X_MTD_DOLLARS_ABS()) > 999)
                {
                    strReturnValue = X_MTD_SIGN() + QDesign.Substring(X_MTD_DOLLARS_ABS_A(), 4, 4);
                }
                else if (QDesign.NULL(X_MTD_DOLLARS_ABS()) > 99)
                {
                    strReturnValue = X_MTD_SIGN() + QDesign.Substring(X_MTD_DOLLARS_ABS_A(), 5, 3);
                }
                else if (QDesign.NULL(X_MTD_DOLLARS_ABS()) > 9)
                {
                    strReturnValue = X_MTD_SIGN() + QDesign.Substring(X_MTD_DOLLARS_ABS_A(), 6, 2);
                }
                else
                {
                    strReturnValue = X_MTD_SIGN() + QDesign.Substring(X_MTD_DOLLARS_ABS_A(), 7, 1);
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_YTD_DOLLARS_ABS_B()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(X_YTD_DOLLARS_ABS()) > 999999)
                {
                    strReturnValue = X_YTD_SIGN() + X_YTD_DOLLARS_ABS_A();
                }
                else if (QDesign.NULL(X_YTD_DOLLARS_ABS()) > 99999)
                {
                    strReturnValue = X_YTD_SIGN() + QDesign.Substring(X_YTD_DOLLARS_ABS_A(), 2, 6);
                }
                else if (QDesign.NULL(X_YTD_DOLLARS_ABS()) > 9999)
                {
                    strReturnValue = X_YTD_SIGN() + QDesign.Substring(X_YTD_DOLLARS_ABS_A(), 3, 5);
                }
                else if (QDesign.NULL(X_YTD_DOLLARS_ABS()) > 999)
                {
                    strReturnValue = X_YTD_SIGN() + QDesign.Substring(X_YTD_DOLLARS_ABS_A(), 4, 4);
                }
                else if (QDesign.NULL(X_YTD_DOLLARS_ABS()) > 99)
                {
                    strReturnValue = X_YTD_SIGN() + QDesign.Substring(X_YTD_DOLLARS_ABS_A(), 5, 3);
                }
                else if (QDesign.NULL(X_YTD_DOLLARS_ABS()) > 9)
                {
                    strReturnValue = X_YTD_SIGN() + QDesign.Substring(X_YTD_DOLLARS_ABS_A(), 6, 2);
                }
                else
                {
                    strReturnValue = X_YTD_SIGN() + QDesign.Substring(X_YTD_DOLLARS_ABS_A(), 7, 1);
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_MTD_DOLLARS_ABS_CHAR()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.RightJustify(X_MTD_DOLLARS_ABS_B(), " ", 8);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_YTD_DOLLARS_ABS_CHAR()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.RightJustify(X_YTD_DOLLARS_ABS_B(), " ", 8);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_PERIOD_COL_1()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(X_MTD_DOLLARS()) != 0 || QDesign.NULL(X_MTD_CENTS()) != 0)
                {
                    strReturnValue = ".";
                }
                else
                {
                    strReturnValue = " ";
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_PERIOD_COL_2()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(X_YTD_DOLLARS()) != 0 || QDesign.NULL(X_YTD_CENTS()) != 0)
                {
                    strReturnValue = ".";
                }
                else
                {
                    strReturnValue = " ";
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_MTD_PRT_DOLLARS()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(X_MTD_DOLLARS()) == 0 && QDesign.NULL(X_MTD_CENTS()) == 0)
                {
                    strReturnValue = " ";
                }
                else if (QDesign.NULL(X_MTD_DOLLARS_ABS()) < 1000)
                {
                    strReturnValue = " " + X_MTD_DOLLARS_ABS_CHAR();
                }
                else
                {
                    strReturnValue = QDesign.Substring(X_MTD_DOLLARS_ABS_CHAR(), 1, 5) + "," + QDesign.Substring(X_MTD_DOLLARS_ABS_CHAR(), 6, 3);
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_YTD_PRT_DOLLARS()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(X_YTD_DOLLARS()) == 0 && QDesign.NULL(X_YTD_CENTS()) == 0)
                {
                    strReturnValue = " ";
                }
                else if (QDesign.NULL(X_YTD_DOLLARS_ABS()) < 1000)
                {
                    strReturnValue = "  " + X_YTD_DOLLARS_ABS_CHAR();
                }
                else if (QDesign.NULL(X_YTD_DOLLARS_ABS()) > 100000)
                {
                    strReturnValue = QDesign.Substring(X_YTD_DOLLARS_ABS_CHAR(), 1, 2) + "," + QDesign.Substring(X_YTD_DOLLARS_ABS_CHAR(), 3, 3) + "," + QDesign.Substring(X_YTD_DOLLARS_ABS_CHAR(), 6, 3);
                }
                else
                {
                    strReturnValue = " " + QDesign.Substring(X_YTD_DOLLARS_ABS_CHAR(), 1, 5) + "," + QDesign.Substring(X_YTD_DOLLARS_ABS_CHAR(), 6, 3);
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_MTD_PRT_CENTS()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(X_MTD_DOLLARS()) != 0 || QDesign.NULL(X_MTD_CENTS()) != 0)
                {
                    strReturnValue = QDesign.ASCII(X_MTD_CENTS(), 2);
                }
                else if (QDesign.NULL(X_MTD_DOLLARS()) == 0 && QDesign.NULL(X_MTD_CENTS()) == 0)
                {
                    strReturnValue = " ";
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_YTD_PRT_CENTS()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(X_YTD_DOLLARS()) != 0 || QDesign.NULL(X_YTD_CENTS()) != 0)
                {
                    strReturnValue = QDesign.ASCII(X_YTD_CENTS(), 2);
                }
                else if (QDesign.NULL(X_YTD_DOLLARS()) == 0 && QDesign.NULL(X_YTD_CENTS()) == 0)
                {
                    strReturnValue = " ";
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal X_COUNT_INCREQ()
        {
            decimal decReturnValue = 0;

            try
            {
                if (rdrDATA.GetString("COMP_CODE_GROUP").CompareTo("J") <= 0)
                {
                    decReturnValue = 1;
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_COUNT_STATUS()
        {
            decimal decReturnValue = 0;

            try
            {
                if (rdrDATA.GetString("COMP_CODE_GROUP").CompareTo("L") <= 0)
                {
                    decReturnValue = 1;
                }
                else
                {
                    decReturnValue = 0;
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_COUNT_INCREQ_STATUS()
        {
            decimal decReturnValue = 0;

            try
            {
                if (rdrDATA.GetString("COMP_CODE_GROUP").CompareTo("J") >= 0 && rdrDATA.GetString("COMP_CODE_GROUP").CompareTo("L") <= 0)
                {
                    decReturnValue = 1;
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_INCREQ()
        {
            decimal decReturnValue = 0;

            try
            {
                if (rdrDATA.GetString("COMP_CODE_GROUP").CompareTo("J") == 0)
                {
                    decReturnValue = 1;
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_INCTAR()
        {
            decimal decReturnValue = 0;

            try
            {
                if (rdrDATA.GetString("COMP_CODE_GROUP").CompareTo("K") == 0)
                {
                    decReturnValue = 1;
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_STATUS()
        {
            decimal decReturnValue = 0;

            try
            {
                if (rdrDATA.GetString("COMP_CODE_GROUP").CompareTo("L") == 0)
                {
                    decReturnValue = 1;
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string X_MSG_TEXT()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (rdrDATA.GetString("COMP_CODE") == "STATUS" && QDesign.NULL(rdrDATA.GetNumber("AMT_YTD")) < 0)
                {
                    strReturnValue = "Your YTD Ceiling Payments are overpaid by ";
                }
                else if (rdrDATA.GetString("COMP_CODE") == "PAYPOT" && QDesign.NULL(rdrDATA.GetNumber("DEPT_COMPANY")) == 1)
                {
                    strReturnValue = "Current Ceiling Payable";
                }
                else if (rdrDATA.GetString("COMP_CODE") == "PAYPOT" && QDesign.NULL(rdrDATA.GetNumber("DEPT_COMPANY")) != 1)
                {
                    strReturnValue = "Current Earnings Payable";
                }
                else if (rdrDATA.GetString("COMP_CODE") == "YTDEAR" && QDesign.NULL(rdrDATA.GetNumber("DEPT_COMPANY")) == 1)
                {
                    strReturnValue = "YTD Ceiling Paid";
                }
                else if (rdrDATA.GetString("COMP_CODE") == "YTDEAR" && QDesign.NULL(rdrDATA.GetNumber("DEPT_COMPANY")) != 1)
                {
                    strReturnValue = "YTD Earnings Paid";
                }
                else if (rdrDATA.GetString("REC_TYPE") == F119_REC_MSG())
                {
                    strReturnValue = rdrDATA.GetString("TEXT");
                }
                else
                {
                    strReturnValue = rdrDATA.GetString("DESC_LONG");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_LINE_TEXT()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (rdrDATA.GetString("REC_TYPE") == "A")
                    strReturnValue = X_MSG_TEXT() + X_MTD_LIT1().Trim() + X_MTD_LIT2().Trim() + QDesign.LeftJustify(X_MTD_PRT_DOLLARS()).Trim() + X_PERIOD_COL_1() + X_MTD_PRT_CENTS() + X_YTD_LIT1().Trim() + X_YTD_LIT2().Trim() + QDesign.LeftJustify(X_YTD_PRT_DOLLARS()).Trim() + X_PERIOD_COL_2() + X_YTD_PRT_CENTS();
                else
                    strReturnValue = rdrDATA.GetString("TEXT");
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string LAST_DOC_NBR;
        private decimal SUB_X_COUNT_INCREQ;
        private decimal SUB_X_COUNT_STATUS;
        private decimal SUB_X_COUNT_INCREQ_STATUS;
        private decimal SUB_X_INCREQ;
        private decimal SUB_X_INCTAR;
        private decimal SUB_X_STATUS;

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "INDEXED.F119_DOCTOR_YTD.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "INDEXED.F119_DOCTOR_YTD.COMP_CODE", DataTypes.Character, 6);
                AddControl(ReportSection.REPORT, "INDEXED.F190_COMP_CODES.COMP_CODE_GROUP", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "INDEXED.F119_DOCTOR_YTD.PROCESS_SEQ", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "X_COUNT_INCREQ", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "X_COUNT_STATUS", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "X_LINE_TEXT", DataTypes.Character, 190);
                AddControl(ReportSection.REPORT, "X_DEPOSIT", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "X_DEPOSIT_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "X_PED", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "X_BANK_ACCOUNT_PRIVACY_MASKED", DataTypes.Character, 12);
                AddControl(ReportSection.REPORT, "X_BANK", DataTypes.Character, 30);
                AddControl(ReportSection.REPORT, "X_BRANCH", DataTypes.Character, 30);
                AddControl(ReportSection.REPORT, "X_DEPT_NAME", DataTypes.Character, 30);
                AddControl(ReportSection.REPORT, "X_FULL_PART_IND", DataTypes.Character, 25);
                AddControl(ReportSection.REPORT, "X_DOC_ID_INFO", DataTypes.Character, 50);
                AddControl(ReportSection.REPORT, "INDEXED.CONSTANTS_MSTR_REC_6.FIRST_EP_NBR_OF_CAL_YR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "INDEXED.CONSTANTS_MSTR_REC_6.LAST_EP_NBR_OF_CAL_YR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "X_YTDCEA_POS_PRT", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "X_YTDCEA_VAL_PRT", DataTypes.Character, 10);
                AddControl(ReportSection.REPORT, "X_CEICEA_POS_PRT", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "X_CEICEA_VAL_PRT", DataTypes.Character, 10);
                AddControl(ReportSection.REPORT, "X_YTDCEX_POS_PRT", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "X_YTDCEX_VAL_PRT", DataTypes.Character, 10);
                AddControl(ReportSection.REPORT, "X_CEICEX_POS_PRT", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "X_CEICEX_VAL_PRT", DataTypes.Character, 10);
                AddControl(ReportSection.REPORT, "X_YTDREQ_POS_PRT", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "X_YTDREQ_VAL_PRT", DataTypes.Character, 10);
                AddControl(ReportSection.REPORT, "X_CEIREQ_POS_PRT", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "X_CEIREQ_VAL_PRT", DataTypes.Character, 10);
                AddControl(ReportSection.REPORT, "X_YTDTAR_POS_PRT", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "X_YTDTAR_VAL_PRT", DataTypes.Character, 10);
                AddControl(ReportSection.REPORT, "X_CEITAR_POS_PRT", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "X_CEITAR_VAL_PRT", DataTypes.Character, 10);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "X_COUNT_INCREQ_STATUS", DataTypes.Numeric, 1);
                AddControl(ReportSection.REPORT, "X_INCREQ", DataTypes.Numeric, 1);
                AddControl(ReportSection.REPORT, "X_INCTAR", DataTypes.Numeric, 1);
                AddControl(ReportSection.REPORT, "X_STATUS", DataTypes.Numeric, 1);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        #endregion

        #region " Renaissance Precompiler Generated Code "

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 2017-07-24 7:27:24 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "INDEXED.F119_DOCTOR_YTD.DOC_NBR":
                    return Common.StringToField(rdrDATA.GetString("DOC_NBR").PadRight(3, ' '));

                case "INDEXED.F119_DOCTOR_YTD.COMP_CODE":
                    return Common.StringToField(rdrDATA.GetString("COMP_CODE").PadRight(6, ' '));

                case "INDEXED.F190_COMP_CODES.COMP_CODE_GROUP":
                    return Common.StringToField(rdrDATA.GetString("COMP_CODE_GROUP").PadRight(1, ' '));

                case "INDEXED.F119_DOCTOR_YTD.PROCESS_SEQ":
                    return rdrDATA.GetNumber("PROCESS_SEQ").ToString().PadLeft(2, ' ');

                case "X_COUNT_INCREQ":
                    return SUB_X_COUNT_INCREQ.ToString();

                case "X_COUNT_STATUS":
                    return SUB_X_COUNT_STATUS.ToString();

                case "X_LINE_TEXT":
                    return Common.StringToField(X_LINE_TEXT().PadRight(190, ' '));

                case "X_DEPOSIT":
                    return X_DEPOSIT().ToString().PadLeft(10, ' ');

                case "X_DEPOSIT_DATE":
                    return X_DEPOSIT_DATE().ToString().PadLeft(8, ' ');

                case "X_PED":
                    return X_PED().ToString().PadLeft(8, ' ');

                case "X_BANK_ACCOUNT_PRIVACY_MASKED":
                    return Common.StringToField(X_BANK_ACCOUNT_PRIVACY_MASKED().PadRight(12, ' '));

                case "X_BANK":
                    return Common.StringToField(X_BANK().PadRight(30, ' '));

                case "X_BRANCH":
                    return Common.StringToField(X_BRANCH().PadRight(30, ' '));

                case "X_DEPT_NAME":
                    return Common.StringToField(X_DEPT_NAME().PadRight(30, ' '));

                case "X_FULL_PART_IND":
                    return Common.StringToField(X_FULL_PART_IND().PadRight(25, ' '));

                case "X_DOC_ID_INFO":
                    return Common.StringToField(X_DOC_ID_INFO().PadRight(50, ' '));

                case "INDEXED.CONSTANTS_MSTR_REC_6.FIRST_EP_NBR_OF_CAL_YR":
                    return rdrDATA.GetNumber("FIRST_EP_NBR_OF_CAL_YR").ToString().PadLeft(6, ' ');

                case "INDEXED.CONSTANTS_MSTR_REC_6.LAST_EP_NBR_OF_CAL_YR":
                    return rdrDATA.GetNumber("LAST_EP_NBR_OF_CAL_YR").ToString().PadLeft(6, ' ');

                case "X_YTDCEA_POS_PRT":
                    return Common.StringToField(X_YTDCEA_POS_PRT().PadRight(3, ' '));

                case "X_YTDCEA_VAL_PRT":
                    return Common.StringToField(X_YTDCEA_VAL_PRT().PadRight(10, ' '));

                case "X_CEICEA_POS_PRT":
                    return Common.StringToField(X_CEICEA_POS_PRT().PadRight(3, ' '));

                case "X_CEICEA_VAL_PRT":
                    return Common.StringToField(X_CEICEA_VAL_PRT().PadRight(10, ' '));

                case "X_YTDCEX_POS_PRT":
                    return Common.StringToField(X_YTDCEX_POS_PRT().PadRight(3, ' '));

                case "X_YTDCEX_VAL_PRT":
                    return Common.StringToField(X_YTDCEX_VAL_PRT().PadRight(10, ' '));

                case "X_CEICEX_POS_PRT":
                    return Common.StringToField(X_CEICEX_POS_PRT().PadRight(3, ' '));

                case "X_CEICEX_VAL_PRT":
                    return Common.StringToField(X_CEICEX_VAL_PRT().PadRight(10, ' '));

                case "X_YTDREQ_POS_PRT":
                    return Common.StringToField(X_YTDREQ_POS_PRT().PadRight(3, ' '));

                case "X_YTDREQ_VAL_PRT":
                    return Common.StringToField(X_YTDREQ_VAL_PRT().PadRight(10, ' '));

                case "X_CEIREQ_POS_PRT":
                    return Common.StringToField(X_CEIREQ_POS_PRT().PadRight(3, ' '));

                case "X_CEIREQ_VAL_PRT":
                    return Common.StringToField(X_CEIREQ_VAL_PRT().PadRight(10, ' '));

                case "X_YTDTAR_POS_PRT":
                    return Common.StringToField(X_YTDTAR_POS_PRT().PadRight(3, ' '));

                case "X_YTDTAR_VAL_PRT":
                    return Common.StringToField(X_YTDTAR_VAL_PRT().PadRight(10, ' '));

                case "X_CEITAR_POS_PRT":
                    return Common.StringToField(X_CEITAR_POS_PRT().PadRight(3, ' '));

                case "X_CEITAR_VAL_PRT":
                    return Common.StringToField(X_CEITAR_VAL_PRT().PadRight(10, ' '));

                case "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT":
                    return rdrDATA.GetNumber("DOC_DEPT").ToString().PadLeft(2, ' ');

                case "X_COUNT_INCREQ_STATUS":
                    return SUB_X_COUNT_INCREQ_STATUS.ToString();

                case "X_INCREQ":
                    return SUB_X_INCREQ.ToString();

                case "X_INCTAR":
                    return SUB_X_INCTAR.ToString();

                case "X_STATUS":
                    return SUB_X_STATUS.ToString();

                default:
                    break;
            }

            return string.Empty;
        }


        public override void AccessData()
        {
            try
            {
                Access_Data();

                while (rdrDATA.Read())
                {
                    if (LAST_DOC_NBR != rdrDATA.GetString("DOC_NBR"))
                    {
                        LAST_DOC_NBR = rdrDATA.GetString("DOC_NBR");
                        SUB_X_COUNT_INCREQ = X_COUNT_INCREQ();
                        SUB_X_COUNT_STATUS = X_COUNT_STATUS();
                        SUB_X_COUNT_INCREQ_STATUS = X_COUNT_INCREQ_STATUS();
                        SUB_X_INCREQ = X_INCREQ();
                        SUB_X_INCTAR = X_INCTAR();
                        SUB_X_STATUS = X_STATUS();
                    }
                    else
                    {
                        SUB_X_COUNT_INCREQ += X_COUNT_INCREQ();
                        SUB_X_COUNT_STATUS += X_COUNT_STATUS();
                        SUB_X_COUNT_INCREQ_STATUS += X_COUNT_INCREQ_STATUS();
                        SUB_X_INCREQ += X_INCREQ();
                        SUB_X_INCTAR += X_INCTAR();
                        SUB_X_STATUS += X_STATUS();
                    }

                    WriteData();
                }
                rdrDATA.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

       public override void CloseReaders()
        {
            if ((rdrDATA != null))
            {
                rdrDATA.Close();
                rdrDATA = null;
            }
        }

        #endregion

        #endregion
    }
}
