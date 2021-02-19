#region "Screen Comments"

// #> PROGRAM-ID.     R124A_XLS.QZS
// ((C)) Dyad Infosys LTD 
// PURPOSE: Excel YTD Earnings (r124a like) workbook as per Ross`s spec 
// - PHASE I: create subfile for xls output  
// MODIFICATION HISTORY
// DATE          WHO      DESCRIPTION
// 2015/May/01   be      - original - clone from r124a.qzs 
// creation of subfile for xls output (processed by r124b_xls.qzs)
// 2016/Jan/06   MC1 - correct the last column to be amt-ytd of f119-doctor-ytd instead of amt-mtd

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
    public class R124A_XLS : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R124A_XLS";
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
        //private Reader rdrF119_1 = new Reader();
        //private Reader rdrF119_2 = new Reader();
        //private Reader rdrF119_3 = new Reader();
        //private Reader rdrF119_4 = new Reader();
        //private Reader rdrF119_5 = new Reader();
        //private Reader rdrF119_6 = new Reader();
        //private Reader rdrF119_7 = new Reader();
        //private Reader rdrF119_8 = new Reader();
        //private Reader rdrF119_9 = new Reader();
        //private Reader rdrF119_10 = new Reader();
        //private Reader rdrF119_11 = new Reader();
        //private Reader rdrF119_12 = new Reader();
        //private Reader rdrF119_13 = new Reader();
        private Reader rdrDATA = new Reader();

        //#CORE_BEGIN_INCLUDE: F119_DOCTOR_YTD"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 2017-07-24 8:50:54 PM

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
        //# Do not delete, modify or move it.  Updated: 2017-07-24 8:50:54 PM

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
                SubFileName = "R124A_XLS";
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

            strSQL.Append("SELECT alldata.* FROM (SELECT ytd.COMP_CODE, ytd.DOC_NBR, ytd.REC_TYPE, ytd.COMP_CODE_GROUP, ytd.PROCESS_SEQ, ytd.AMT_MTD, ytd.AMT_YTD, ");
            strSQL.Append("mstr.DOC_DEPT, mstr.DOC_BANK_NBR, mstr.DOC_BANK_BRANCH, mstr.DOC_PAYEFT, mstr.DOC_EP_DATE_DEPOSIT, mstr.DOC_EP_PED, comp.DESC_LONG, dept.DEPT_NAME, ");
            strSQL.Append("dept.DEPT_NBR, mstr.DOC_FULL_PART_IND, mstr.DOC_INIT1, mstr.DOC_INIT2, mstr.DOC_INIT3, mstr.DOC_NAME, constmstr.FIRST_EP_NBR_OF_CAL_YR, constmstr.LAST_EP_NBR_OF_CAL_YR, ");
            strSQL.Append("bank.BANK_CD, bank.BANK_NAME, dept.DEPT_COMPANY, ");
            strSQL.Append("constmstr.CONST_REC_NBR, constmstr.CURRENT_EP_NBR, constmstr.FIRST_EP_NBR_OF_FISCAL_YR, ");
            strSQL.Append("ceil.EP_NBR, ceil.DOC_PAY_CODE, ");
            strSQL.Append("ytdhist1.AMT_MTD AMT_MTD_1, ytdhist1.AMT_YTD AMT_YTD_1, ");
            strSQL.Append("ytdhist2.AMT_MTD AMT_MTD_2, ytdhist2.AMT_YTD AMT_YTD_2, ");
            strSQL.Append("ytdhist3.AMT_MTD AMT_MTD_3, ytdhist3.AMT_YTD AMT_YTD_3, ");
            strSQL.Append("ytdhist4.AMT_MTD AMT_MTD_4, ytdhist4.AMT_YTD AMT_YTD_4, ");
            strSQL.Append("ytdhist5.AMT_MTD AMT_MTD_5, ytdhist5.AMT_YTD AMT_YTD_5, ");
            strSQL.Append("ytdhist6.AMT_MTD AMT_MTD_6, ytdhist6.AMT_YTD AMT_YTD_6, ");
            strSQL.Append("ytdhist7.AMT_MTD AMT_MTD_7, ytdhist7.AMT_YTD AMT_YTD_7, ");
            strSQL.Append("ytdhist8.AMT_MTD AMT_MTD_8, ytdhist8.AMT_YTD AMT_YTD_8, ");
            strSQL.Append("ytdhist9.AMT_MTD AMT_MTD_9, ytdhist9.AMT_YTD AMT_YTD_9, ");
            strSQL.Append("ytdhist10.AMT_MTD AMT_MTD_10, ytdhist10.AMT_YTD AMT_YTD_10, ");
            strSQL.Append("ytdhist11.AMT_MTD AMT_MTD_11, ytdhist11.AMT_YTD AMT_YTD_11, ");
            strSQL.Append("ytdhist12.AMT_MTD AMT_MTD_12, ytdhist12.AMT_YTD AMT_YTD_12, ");
            strSQL.Append("ytdhist13.AMT_MTD AMT_MTD_13, ytdhist13.AMT_YTD AMT_YTD_13 ");
            strSQL.Append("FROM [INDEXED].[F119_DOCTOR_YTD] ytd ");
            strSQL.Append("LEFT OUTER JOIN [101C].[INDEXED].[F190_COMP_CODES] comp ON ytd.COMP_CODE = comp.COMP_CODE ");
            strSQL.Append("LEFT OUTER JOIN [INDEXED].[F020_DOCTOR_MSTR] mstr ON ytd.DOC_NBR = mstr.DOC_NBR ");
            strSQL.Append("LEFT OUTER JOIN [INDEXED].[F020_DOCTOR_EXTRA] extra ON ytd.DOC_NBR = extra.DOC_NBR ");
            strSQL.Append("LEFT OUTER JOIN [101C].[INDEXED].[F070_DEPT_MSTR] dept ON dept.DEPT_NBR = mstr.DOC_DEPT ");
            strSQL.Append("LEFT OUTER JOIN [INDEXED].[F080_BANK_MSTR] bank ON CONCAT(RIGHT('0000' + RTRIM(mstr.DOC_BANK_NBR), 4), RIGHT('00000' + RTRIM(mstr.DOC_BANK_BRANCH), 5)) = bank.BANK_CD ");
            strSQL.Append("INNER JOIN [INDEXED].[CONSTANTS_MSTR_REC_6] constmstr ON constmstr.CONST_REC_NBR = 6 ");
            strSQL.Append("INNER JOIN [INDEXED].[F112_PYCDCEILINGS] ceil ON ceil.EP_NBR = constmstr.CURRENT_EP_NBR AND ceil.DOC_NBR = mstr.DOC_NBR ");
            strSQL.Append("LEFT OUTER JOIN [INDEXED].[F119_DOCTOR_YTD_HISTORY] ytdhist1 ON ytdhist1.DOC_NBR = ytd.DOC_NBR AND ytdhist1.EP_NBR = constmstr.FIRST_EP_NBR_OF_FISCAL_YR AND ytdhist1.REC_TYPE = ytd.REC_TYPE AND ytdhist1.COMP_CODE_GROUP = ytd.COMP_CODE_GROUP AND ytdhist1.PROCESS_SEQ = ytd.PROCESS_SEQ AND ytdhist1.COMP_CODE = ytd.COMP_CODE ");
            strSQL.Append("LEFT OUTER JOIN [INDEXED].[F119_DOCTOR_YTD_HISTORY] ytdhist2 ON ytdhist2.DOC_NBR = ytd.DOC_NBR AND ytdhist2.EP_NBR = constmstr.FIRST_EP_NBR_OF_FISCAL_YR + 1 AND ytdhist2.REC_TYPE = ytd.REC_TYPE AND ytdhist2.COMP_CODE_GROUP = ytd.COMP_CODE_GROUP AND ytdhist2.PROCESS_SEQ = ytd.PROCESS_SEQ AND ytdhist2.COMP_CODE = ytd.COMP_CODE ");
            strSQL.Append("LEFT OUTER JOIN [INDEXED].[F119_DOCTOR_YTD_HISTORY] ytdhist3 ON ytdhist3.DOC_NBR = ytd.DOC_NBR AND ytdhist3.EP_NBR = constmstr.FIRST_EP_NBR_OF_FISCAL_YR + 2 AND ytdhist3.REC_TYPE = ytd.REC_TYPE AND ytdhist3.COMP_CODE_GROUP = ytd.COMP_CODE_GROUP AND ytdhist3.PROCESS_SEQ = ytd.PROCESS_SEQ AND ytdhist3.COMP_CODE = ytd.COMP_CODE ");
            strSQL.Append("LEFT OUTER JOIN [INDEXED].[F119_DOCTOR_YTD_HISTORY] ytdhist4 ON ytdhist4.DOC_NBR = ytd.DOC_NBR AND ytdhist4.EP_NBR = constmstr.FIRST_EP_NBR_OF_FISCAL_YR + 3 AND ytdhist4.REC_TYPE = ytd.REC_TYPE AND ytdhist4.COMP_CODE_GROUP = ytd.COMP_CODE_GROUP AND ytdhist4.PROCESS_SEQ = ytd.PROCESS_SEQ AND ytdhist4.COMP_CODE = ytd.COMP_CODE ");
            strSQL.Append("LEFT OUTER JOIN [INDEXED].[F119_DOCTOR_YTD_HISTORY] ytdhist5 ON ytdhist5.DOC_NBR = ytd.DOC_NBR AND ytdhist5.EP_NBR = constmstr.FIRST_EP_NBR_OF_FISCAL_YR + 4 AND ytdhist5.REC_TYPE = ytd.REC_TYPE AND ytdhist5.COMP_CODE_GROUP = ytd.COMP_CODE_GROUP AND ytdhist5.PROCESS_SEQ = ytd.PROCESS_SEQ AND ytdhist5.COMP_CODE = ytd.COMP_CODE ");
            strSQL.Append("LEFT OUTER JOIN [INDEXED].[F119_DOCTOR_YTD_HISTORY] ytdhist6 ON ytdhist6.DOC_NBR = ytd.DOC_NBR AND ytdhist6.EP_NBR = constmstr.FIRST_EP_NBR_OF_FISCAL_YR + 5 AND ytdhist6.REC_TYPE = ytd.REC_TYPE AND ytdhist6.COMP_CODE_GROUP = ytd.COMP_CODE_GROUP AND ytdhist6.PROCESS_SEQ = ytd.PROCESS_SEQ AND ytdhist6.COMP_CODE = ytd.COMP_CODE ");
            strSQL.Append("LEFT OUTER JOIN [INDEXED].[F119_DOCTOR_YTD_HISTORY] ytdhist7 ON ytdhist7.DOC_NBR = ytd.DOC_NBR AND ytdhist7.EP_NBR = constmstr.FIRST_EP_NBR_OF_FISCAL_YR + 6 AND ytdhist7.REC_TYPE = ytd.REC_TYPE AND ytdhist7.COMP_CODE_GROUP = ytd.COMP_CODE_GROUP AND ytdhist7.PROCESS_SEQ = ytd.PROCESS_SEQ AND ytdhist7.COMP_CODE = ytd.COMP_CODE ");
            strSQL.Append("LEFT OUTER JOIN [INDEXED].[F119_DOCTOR_YTD_HISTORY] ytdhist8 ON ytdhist8.DOC_NBR = ytd.DOC_NBR AND ytdhist8.EP_NBR = constmstr.FIRST_EP_NBR_OF_FISCAL_YR + 7 AND ytdhist8.REC_TYPE = ytd.REC_TYPE AND ytdhist8.COMP_CODE_GROUP = ytd.COMP_CODE_GROUP AND ytdhist8.PROCESS_SEQ = ytd.PROCESS_SEQ AND ytdhist8.COMP_CODE = ytd.COMP_CODE ");
            strSQL.Append("LEFT OUTER JOIN [INDEXED].[F119_DOCTOR_YTD_HISTORY] ytdhist9 ON ytdhist9.DOC_NBR = ytd.DOC_NBR AND ytdhist9.EP_NBR = constmstr.FIRST_EP_NBR_OF_FISCAL_YR + 8 AND ytdhist9.REC_TYPE = ytd.REC_TYPE AND ytdhist9.COMP_CODE_GROUP = ytd.COMP_CODE_GROUP AND ytdhist9.PROCESS_SEQ = ytd.PROCESS_SEQ AND ytdhist9.COMP_CODE = ytd.COMP_CODE ");
            strSQL.Append("LEFT OUTER JOIN [INDEXED].[F119_DOCTOR_YTD_HISTORY] ytdhist10 ON ytdhist10.DOC_NBR = ytd.DOC_NBR AND ytdhist10.EP_NBR = constmstr.FIRST_EP_NBR_OF_FISCAL_YR + 9 AND ytdhist10.REC_TYPE = ytd.REC_TYPE AND ytdhist10.COMP_CODE_GROUP = ytd.COMP_CODE_GROUP AND ytdhist10.PROCESS_SEQ = ytd.PROCESS_SEQ AND ytdhist10.COMP_CODE = ytd.COMP_CODE ");
            strSQL.Append("LEFT OUTER JOIN [INDEXED].[F119_DOCTOR_YTD_HISTORY] ytdhist11 ON ytdhist11.DOC_NBR = ytd.DOC_NBR AND ytdhist11.EP_NBR = constmstr.FIRST_EP_NBR_OF_FISCAL_YR + 10 AND ytdhist11.REC_TYPE = ytd.REC_TYPE AND ytdhist11.COMP_CODE_GROUP = ytd.COMP_CODE_GROUP AND ytdhist11.PROCESS_SEQ = ytd.PROCESS_SEQ AND ytdhist11.COMP_CODE = ytd.COMP_CODE ");
            strSQL.Append("LEFT OUTER JOIN [INDEXED].[F119_DOCTOR_YTD_HISTORY] ytdhist12 ON ytdhist12.DOC_NBR = ytd.DOC_NBR AND ytdhist12.EP_NBR = constmstr.FIRST_EP_NBR_OF_FISCAL_YR + 11 AND ytdhist12.REC_TYPE = ytd.REC_TYPE AND ytdhist12.COMP_CODE_GROUP = ytd.COMP_CODE_GROUP AND ytdhist12.PROCESS_SEQ = ytd.PROCESS_SEQ AND ytdhist12.COMP_CODE = ytd.COMP_CODE ");
            strSQL.Append("LEFT OUTER JOIN [INDEXED].[F119_DOCTOR_YTD_HISTORY] ytdhist13 ON ytdhist13.DOC_NBR = ytd.DOC_NBR AND ytdhist13.EP_NBR = constmstr.FIRST_EP_NBR_OF_FISCAL_YR + 12 AND ytdhist13.REC_TYPE = ytd.REC_TYPE AND ytdhist13.COMP_CODE_GROUP = ytd.COMP_CODE_GROUP AND ytdhist13.PROCESS_SEQ = ytd.PROCESS_SEQ AND ytdhist13.COMP_CODE = ytd.COMP_CODE ");
            strSQL.Append("WHERE ((ytd.REC_TYPE = 'B' ) OR ((comp.COMP_CODE_GROUP <> 'Z') ");
            strSQL.Append("AND (ytd.COMP_CODE <> 'GTYPEA') AND (ytd.AMT_MTD <> 0 OR (ytd.AMT_YTD <> 0 AND ytd.COMP_CODE <> 'DEFIC')) AND (ytd.REC_TYPE = 'A'))) ");
            strSQL.Append("AND (ceil.DOC_PAY_CODE <> '7')) AS alldata ORDER BY DOC_NBR");

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
                if (QDesign.NULL(rdrDATA.GetString("DOC_FULL_PART_IND")) == "F")
                {
                    strReturnValue = "GFT";
                }
                else if (QDesign.NULL(rdrDATA.GetString("DOC_FULL_PART_IND")) == "C")
                {
                    strReturnValue = "CLINICAL SCHOLAR";
                }
                else if (QDesign.NULL(rdrDATA.GetString("DOC_FULL_PART_IND")) == "S")
                {
                    strReturnValue = "PLASTIC SURGERY";
                }
                else if (QDesign.NULL(rdrDATA.GetString("DOC_FULL_PART_IND")) == "P")
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
                strReturnValue = "Dr. " + (rdrDATA.GetString("DOC_INIT1") + rdrDATA.GetString("DOC_INIT2") + rdrDATA.GetString("DOC_INIT3")).Trim() + " " + rdrDATA.GetString("DOC_NAME").Trim() + "    " + QDesign.ASCII(rdrDATA.GetString("DOC_DEPT"), 2) + "-" + rdrDATA.GetString("DOC_NBR") + "  ";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
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

        private string X_LINE_TEXT_XLS()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_MSG_TEXT().PadRight(50, ' ') + "," + QDesign.ASCII(QDesign.NULL(rdrDATA.GetNumber("AMT_MTD_1"))) + "," + QDesign.ASCII(QDesign.NULL(rdrDATA.GetNumber("AMT_MTD_2"))) + "," + QDesign.ASCII(QDesign.NULL(rdrDATA.GetNumber("AMT_MTD_3"))) + "," + QDesign.ASCII(QDesign.NULL(rdrDATA.GetNumber("AMT_MTD_4"))) + "," + QDesign.ASCII(QDesign.NULL(rdrDATA.GetNumber("AMT_MTD_5"))) + "," + QDesign.ASCII(QDesign.NULL(rdrDATA.GetNumber("AMT_MTD_6"))) + "," + QDesign.ASCII(QDesign.NULL(rdrDATA.GetNumber("AMT_MTD_7"))) + "," + QDesign.ASCII(QDesign.NULL(rdrDATA.GetNumber("AMT_MTD_8"))) + "," + QDesign.ASCII(QDesign.NULL(rdrDATA.GetNumber("AMT_MTD_9"))) + "," + QDesign.ASCII(QDesign.NULL(rdrDATA.GetNumber("AMT_MTD_10"))) + "," + QDesign.ASCII(QDesign.NULL(rdrDATA.GetNumber("AMT_MTD_11"))) + "," + QDesign.ASCII(QDesign.NULL(rdrDATA.GetNumber("AMT_MTD_12"))) + "," + QDesign.ASCII(QDesign.NULL(rdrDATA.GetNumber("AMT_MTD_13"))) + "," + QDesign.ASCII(QDesign.NULL(rdrDATA.GetNumber("AMT_YTD")));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.REPORT, "INDEXED.F119_DOCTOR_YTD.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "INDEXED.F119_DOCTOR_YTD.COMP_CODE", DataTypes.Character, 6);
                AddControl(ReportSection.REPORT, "INDEXED.F190_COMP_CODES.COMP_CODE_GROUP", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "INDEXED.F119_DOCTOR_YTD.PROCESS_SEQ", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "INDEXED.F119_DOCTOR_YTD.REC_TYPE", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "AMT_MTD_1", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "AMT_MTD_2", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "AMT_MTD_3", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "AMT_MTD_4", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "AMT_MTD_5", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "AMT_MTD_6", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "AMT_MTD_7", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "AMT_MTD_8", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "AMT_MTD_9", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "AMT_MTD_10", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "AMT_MTD_11", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "AMT_MTD_12", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "AMT_MTD_13", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "INDEXED.F119_DOCTOR_YTD.AMT_MTD", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "INDEXED.F119_DOCTOR_YTD.AMT_YTD", DataTypes.Numeric, 9);
                AddControl(ReportSection.REPORT, "X_LINE_TEXT_XLS", DataTypes.Character, 230);
                AddControl(ReportSection.REPORT, "X_DEPOSIT", DataTypes.Numeric, 10);
                AddControl(ReportSection.REPORT, "X_DEPOSIT_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "X_PED", DataTypes.Numeric, 8);
                AddControl(ReportSection.REPORT, "X_DEPT_NAME", DataTypes.Character, 30);
                AddControl(ReportSection.REPORT, "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "X_FULL_PART_IND", DataTypes.Character, 25);
                AddControl(ReportSection.REPORT, "X_DOC_ID_INFO", DataTypes.Character, 50);
                AddControl(ReportSection.REPORT, "INDEXED.CONSTANTS_MSTR_REC_6.CURRENT_EP_NBR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "INDEXED.CONSTANTS_MSTR_REC_6.FIRST_EP_NBR_OF_CAL_YR", DataTypes.Numeric, 6);
                AddControl(ReportSection.REPORT, "INDEXED.CONSTANTS_MSTR_REC_6.LAST_EP_NBR_OF_CAL_YR", DataTypes.Numeric, 6);
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
        //# Do not delete, modify or move it.  Updated: 2017-07-24 8:50:54 PM

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

                case "INDEXED.F119_DOCTOR_YTD.REC_TYPE":
                    return Common.StringToField(rdrDATA.GetString("REC_TYPE").PadRight(1, ' '));

                case "AMT_MTD_1":
                    return rdrDATA.GetNumber("AMT_MTD_1").ToString().PadLeft(6, ' ');

                case "AMT_MTD_2":
                    return rdrDATA.GetNumber("AMT_MTD_2").ToString().PadLeft(6, ' ');

                case "AMT_MTD_3":
                    return rdrDATA.GetNumber("AMT_MTD_3").ToString().PadLeft(6, ' ');

                case "AMT_MTD_4":
                    return rdrDATA.GetNumber("AMT_MTD_4").ToString().PadLeft(6, ' ');

                case "AMT_MTD_5":
                    return rdrDATA.GetNumber("AMT_MTD_5").ToString().PadLeft(6, ' ');

                case "AMT_MTD_6":
                    return rdrDATA.GetNumber("AMT_MTD_6").ToString().PadLeft(6, ' ');

                case "AMT_MTD_7":
                    return rdrDATA.GetNumber("AMT_MTD_7").ToString().PadLeft(6, ' ');

                case "AMT_MTD_8":
                    return rdrDATA.GetNumber("AMT_MTD_8").ToString().PadLeft(6, ' ');

                case "AMT_MTD_9":
                    return rdrDATA.GetNumber("AMT_MTD_9").ToString().PadLeft(6, ' ');

                case "AMT_MTD_10":
                    return rdrDATA.GetNumber("AMT_MTD_10").ToString().PadLeft(6, ' ');

                case "AMT_MTD_11":
                    return rdrDATA.GetNumber("AMT_MTD_11").ToString().PadLeft(6, ' ');

                case "AMT_MTD_12":
                    return rdrDATA.GetNumber("AMT_MTD_12").ToString().PadLeft(6, ' ');

                case "AMT_MTD_13":
                    return rdrDATA.GetNumber("AMT_MTD_13").ToString().PadLeft(6, ' ');

                case "INDEXED.F119_DOCTOR_YTD.AMT_MTD":
                    return rdrDATA.GetNumber("AMT_MTD").ToString().PadLeft(9, ' ');

                case "INDEXED.F119_DOCTOR_YTD.AMT_YTD":
                    return rdrDATA.GetNumber("AMT_YTD").ToString().PadLeft(9, ' ');

                case "X_LINE_TEXT_XLS":
                    return Common.StringToField(X_LINE_TEXT_XLS().PadRight(230, ' '));

                case "X_DEPOSIT":
                    return X_DEPOSIT().ToString().PadLeft(10, ' ');

                case "X_DEPOSIT_DATE":
                    return X_DEPOSIT_DATE().ToString().PadLeft(8, ' ');

                case "X_PED":
                    return X_PED().ToString().PadLeft(8, ' ');

                case "X_DEPT_NAME":
                    return Common.StringToField(X_DEPT_NAME().PadRight(30, ' '));

                case "INDEXED.F020_DOCTOR_MSTR.DOC_DEPT":
                    return rdrDATA.GetNumber("DOC_DEPT").ToString().PadLeft(2, ' ');

                case "X_FULL_PART_IND":
                    return Common.StringToField(X_FULL_PART_IND().PadRight(25, ' '));

                case "X_DOC_ID_INFO":
                    return Common.StringToField(X_DOC_ID_INFO().PadRight(50, ' '));

                case "INDEXED.CONSTANTS_MSTR_REC_6.CURRENT_EP_NBR":
                    return rdrDATA.GetNumber("CURRENT_EP_NBR").ToString().PadLeft(6, ' ');

                case "INDEXED.CONSTANTS_MSTR_REC_6.FIRST_EP_NBR_OF_CAL_YR":
                    return rdrDATA.GetNumber("FIRST_EP_NBR_OF_CAL_YR").ToString().PadLeft(6, ' ');

                case "INDEXED.CONSTANTS_MSTR_REC_6.LAST_EP_NBR_OF_CAL_YR":
                    return rdrDATA.GetNumber("LAST_EP_NBR_OF_CAL_YR").ToString().PadLeft(6, ' ');

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
