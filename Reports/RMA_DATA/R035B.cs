//  PROGRAm-id.     r035b.qzs
//  ((C)) Dyad Technologies
//  PROGRAM PURPOSE : To prdecimal the direct bill invoices
//  This pgm is the second series of the 3 pgms
//  MODIFICATION HISTORY
//  DATE   WHO          DESCRIPTION
//  2001/MAR/27 M.C.         - ORIGINAL (convert from u035a/b/c.cbl)
//  2001/Apr/16 yas.         - create new format for the letter          
//  2001/May/24 yas.         - create new format for the letter          
//  2001/may/29 B.E. - added HP escape codes for compress/font printing
//  2001/jun/26 B.E. - decimal alignment depending upon number of digits
//  to be printed before decimal was altered.
//  2001/jul/23 B.E. - moved columns to allow for longer doctor name
//  2003/jan/21 yas     - define x-cheques to prdecimal company name depending on 
//  dept-company (add link to f070-dept-mstr)
//  2004/mar/09 M.C.    - Yas requested to prdecimal province 
//  2004/apr/06 M.C.    - Yas requested to not to prdecimal province if the province
//  is `XX`
//  2004/jun/16 b.e. - added `FOR CANADIAN RESIDENTS ONLY` line and
//  shading-box-4
//  2005/jan/27 M.C.    - add clmhdr-doc-dept on the sort statement
//  2005/oct/24 yas.    - change lemees to knight (sue`s email address)
//  2007/mar/05 M.C.    - since access to f070 in u035a.qts, link here is redundant
//  - substitute clmhdr-doc-dept with dept-company
//  2008/mar/05 M.C.    - Yasemin requested to prdecimal 15 characters for doctor name
//  and 55 lines per page
//  2008/Apr/03 MC/BE   - prdecimal 40 lines for first page and 50 lines for subsequent pages
//  for each patient on the invoice
//  2010/Jan/21 MC1 - Yasemin would like to change from `STATEMENT OF ACCOUNT` to 
//  `INVOICE`
//  2011/feb/24 MC2     - Yasemin/Leena requested to change the company name without `of Hamilton`
//  effective as of Feb 11, 2011
//  2012/Jan/23 MC3     - use clmhdr-sub-nbr instead of clm-shadow-subdivision
//  2012/Jul/31 MC4     - extend message in x-msg-due-1                       
//  2016/Jan/04 MC5     - change phone no
//  2016/Dec/15 MC6 - change extension and email for Jillian Vaughan
//  (link to messages are at the patient, not claim level and prdecimal them
//  at the very end of the bill)
//  link clm-shadow-patient             &
//  &
using Core.DataAccess.SqlServer;
using Core.DataAccess.TextFile;
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
    public class R035B : BaseRDLClass
    {
        protected const string REPORT_NAME = "R035B1";
        protected const bool REPORT_HAS_PARAMETERS = false;
        private Reader rdrU035DTL_TOTALLED = new Reader();
        private Reader rdrF010_PAT_MSTR = new Reader();
        private Reader rdrF094_MSG_MSTR = new Reader();
        //#CORE_BEGIN_INCLUDE: PRINTER_CODES"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 2017-07-24 6:39:01 PM

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
                strReturnValue = "~~";
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

        public DataSet GetDataSet(string strConnection, string[] arrParameters, string strReportAssembly, bool blnDebug)
        {
            try
            {
                //  Set Report Properties...
                ReportName = REPORT_NAME;
                ReportHasParameters = REPORT_HAS_PARAMETERS;
                ConfigFile = strReportAssembly;
                ReportFunctions.DebugReport = blnDebug;
                Sort = "CLMHDR_AGENT_CD ASC, CLM_SHADOW_CLINIC ASC, CLMHDR_SUB_NBR ASC, PAT_SURNAME ASC, PAT_GIVEN_NAME ASC, " +
                "DEPT_COMPANY ASC, CLMHDR_PAT_OHIP_ID_OR_CHART ASC, X_PAT ASC, CLM_SHADOW_BATCH_NBR ASC, CLM_SHADOW_C" +
                "LAIM_NBR ASC, X_CLAIM_REC_COUNTER ASC, X_TYPE ASC";
                ProcessData(strConnection, arrParameters);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return ReportData;
        }
        private void Access_U035DTL_TOTALLED()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("CLMHDR_PAT_OHIP_ID_OR_CHART, ");
            strSQL.Append("CLMHDR_AGENT_CD, ");
            strSQL.Append("CLM_SHADOW_CLINIC, ");
            strSQL.Append("CLMHDR_SUB_NBR, ");
            strSQL.Append("PAT_SURNAME, ");
            strSQL.Append("PAT_GIVEN_NAME, ");
            strSQL.Append("DEPT_COMPANY, ");
            strSQL.Append("X_PAT, ");
            strSQL.Append("CLM_SHADOW_BATCH_NBR, ");
            strSQL.Append("CLM_SHADOW_CLAIM_NBR, ");
            strSQL.Append("X_CLAIM_REC_COUNTER, ");
            strSQL.Append("X_TYPE, ");
            strSQL.Append("SUBSCR_ADDR3, ");
            strSQL.Append("SUBSCR_ADDR1, ");
            strSQL.Append("SUBSCR_ADDR2, ");
            strSQL.Append("SUBSCR_POSTAL_CD, ");
            strSQL.Append("PAT_COUNTRY, ");
            strSQL.Append("PAT_OHIP_MMYY, ");
            strSQL.Append("X_CHARGE, ");
            strSQL.Append("X_CHARGE_TOT, ");
            strSQL.Append("X_CREDIT, ");
            strSQL.Append("X_CREDIT_TOT, ");
            strSQL.Append("X_BALDUE_TOT, ");
            strSQL.Append("X_SERV_DATE, ");
            strSQL.Append("X_NBR_SERV, ");
            strSQL.Append("X_OHIP_CD, ");
            strSQL.Append("X_PAT_DTL_COUNTER, ");
            strSQL.Append("X_DOC_NAME, ");
            strSQL.Append("X_CLAIM_NO, ");
            strSQL.Append("X_DESC ");
            strSQL.Append("FROM TEMPORARYDATA.U035DTL_TOTALLED ");

            strSQL.Append(Choose());

            rdrU035DTL_TOTALLED.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);
            strSQL = null;
        }
        private void Link_F010_PAT_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("PAT_I_KEY, ");
            strSQL.Append("PAT_CON_NBR, ");
            strSQL.Append("PAT_I_NBR, ");
            strSQL.Append("FILLER4, ");
            strSQL.Append("SUBSCR_MSG_NBR, ");
            strSQL.Append("PAT_PROV_CD, ");
            strSQL.Append("SUBSCR_PROV_CD ");
            strSQL.Append("FROM INDEXED.F010_PAT_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("PAT_I_KEY = ").Append(Common.StringToField(QDesign.Substring(rdrU035DTL_TOTALLED.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"), 1, 1)));
            strSQL.Append(" AND PAT_CON_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrU035DTL_TOTALLED.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"), 2, 2)));
            strSQL.Append(" AND PAT_I_NBR = ").Append(QDesign.NConvert(QDesign.Substring(rdrU035DTL_TOTALLED.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"), 4, 12)));
            strSQL.Append(" AND FILLER4 = ").Append(Common.StringToField(QDesign.Substring(rdrU035DTL_TOTALLED.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"), 16, 1)));

            rdrF010_PAT_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }
        private void Link_F094_MSG_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("MSG_DTL1, ");
            strSQL.Append("MSG_DTL2, ");
            strSQL.Append("MSG_DTL3, ");
            strSQL.Append("MSG_DTL4, ");
            strSQL.Append("MSG_SUB_KEY_1, ");
            strSQL.Append("MSG_SUB_KEY_23 ");
            strSQL.Append("FROM INDEXED.F094_MSG_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("MSG_SUB_KEY_1 = ").Append(Common.StringToField("M"));
            strSQL.Append(" AND MSG_SUB_KEY_23 = ").Append(Common.StringToField(rdrF010_PAT_MSTR.GetString("SUBSCR_MSG_NBR")));

            rdrF094_MSG_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());
            strSQL = null;
        }

        private string Choose()
        {
            StringBuilder strChoose = new StringBuilder(string.Empty);

            return strChoose.ToString();
        }

        public override bool SelectIf()
        {
            bool blnSelected = false;

            if (ReportFunctions.astrScreenParameters[0].ToString() == "1")
            {
                if (QDesign.NULL(rdrU035DTL_TOTALLED.GetNumber("DEPT_COMPANY")) == QDesign.NULL(1d))
                {
                    blnSelected = true;
                }
            }
            else
            {
                if (QDesign.NULL(rdrU035DTL_TOTALLED.GetNumber("DEPT_COMPANY")) != QDesign.NULL(1d))
                {
                    blnSelected = true;
                }
            }

            return blnSelected;
        }

        private string HP_SET_TOP_MARGIN()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (HPIII_SET_MARGIN_TOP_PART1() + ("2" + HPIII_SET_MARGIN_TOP_PART2()));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string HPIII_INIT_PAGE_CODES()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (HPIII_FONT_SYMBOL_ASCII().TrimEnd()
                            + (HPIII_LINES_PER_INCH().TrimEnd()
                            + (HPIII_FONT_SPACING_PROP().TrimEnd()
                            + (HPIII_FONT_HEIGHT_10().TrimEnd()
                            + (HPIII_FONT_UPRIGHT().TrimEnd()
                            + (HPIII_MEDIUM().TrimEnd()
                            + (HPIII_CGTIMES().TrimEnd() + HP_SET_TOP_MARGIN())))))));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_TITLE_1A()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (HPIII_FONT_HEIGHT_14()
                            + (HPIII_BOLD() + ("INVOICE"
                            + (HPIII_FONT_HEIGHT_8() + HPIII_MEDIUM()))));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_TITLE_1B()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (HPIII_FONT_HEIGHT_14()
                            + (HPIII_BOLD() + ("FOR PHYSICIAN PROFESSIONAL SERVICES"
                            + (HPIII_FONT_HEIGHT_8() + HPIII_MEDIUM()))));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_MSG_0()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (HPIII_FONT_HEIGHT_10()
                            + (HPIII_FONT_ITALIC() + (" NOTE:"
                            + (HPIII_FONT_UPRIGHT()
                            + (HPIII_FONT_HEIGHT_8() + HPIII_MEDIUM())))));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_MSG_1()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (HPIII_FONT_HEIGHT_10()
                            + (HPIII_FONT_ITALIC() + (" This account is for physician services only.  The hospital may have billed you separately for servic" +
                            "es they rendered."
                            + (HPIII_FONT_UPRIGHT()
                            + (HPIII_FONT_HEIGHT_8() + HPIII_MEDIUM())))));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_MSG_2()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (HPIII_FONT_HEIGHT_10()
                            + (HPIII_BOLD() + ("If this invoice is not paid within 60 days, it will be sent to a collection agency."
                            + (HPIII_FONT_HEIGHT_8() + HPIII_MEDIUM()))));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_PAT_NAME()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.Pack((rdrU035DTL_TOTALLED.GetString("PAT_GIVEN_NAME") + (" " + rdrU035DTL_TOTALLED.GetString("PAT_SURNAME"))));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CITY_PROV()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(rdrF010_PAT_MSTR.GetString("PAT_PROV_CD")) != "XX"))
                {
                    strReturnValue = QDesign.Pack((rdrU035DTL_TOTALLED.GetString("SUBSCR_ADDR3") + (", " + rdrF010_PAT_MSTR.GetString("SUBSCR_PROV_CD"))));
                }
                else
                {
                    strReturnValue = QDesign.Pack(rdrU035DTL_TOTALLED.GetString("SUBSCR_ADDR3"));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CHEQUES()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(rdrU035DTL_TOTALLED.GetNumber("DEPT_COMPANY")) == QDesign.NULL(1d)))
                {
                    strReturnValue = "Make cheque payable to Regional Medical Associates";
                }
                else
                {
                    strReturnValue = "Make cheque payable to RMA Inc.";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
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
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CHARGE_LIT1()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = HPIII_COLUMN_209();
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CHARGE_TOT_LIT1()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (HPIII_COLUMN_209()
                            + (HPIII_UP_A_ROW()
                            + (HPIII_BACKWARD_DOT_125()
                            + (HPIII_UNDERLINE_ON()
                            + (HPIII_FORWARD_DOT_162()
                            + (HPIII_UNDERLINE_OFF()
                            + (HPIII_DOWN_A_ROW() + HPIII_COLUMN_209())))))));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CREDIT_LIT1()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = HPIII_COLUMN_228();
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CREDIT_TOT_LIT1()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (HPIII_COLUMN_228()
                            + (HPIII_UP_A_ROW()
                            + (HPIII_BACKWARD_DOT_125()
                            + (HPIII_UNDERLINE_ON()
                            + (HPIII_FORWARD_DOT_162()
                            + (HPIII_UNDERLINE_OFF()
                            + (HPIII_DOWN_A_ROW() + HPIII_COLUMN_228())))))));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_BALDUE_TOT_LIT1()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = HPIII_COLUMN_160();
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal X_CHARGE_DOLLARS()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (rdrU035DTL_TOTALLED.GetNumber("X_CHARGE") / 100);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CHARGE_CENTS()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.PHMod(Math.Abs(rdrU035DTL_TOTALLED.GetNumber("X_CHARGE")), 100);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CHARGE_TOT_DOLLARS()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (rdrU035DTL_TOTALLED.GetNumber("X_CHARGE_TOT") / 100);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CHARGE_TOT_CENTS()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.PHMod(Math.Abs(rdrU035DTL_TOTALLED.GetNumber("X_CHARGE_TOT")), 100);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CREDIT_DOLLARS()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (rdrU035DTL_TOTALLED.GetNumber("X_CREDIT") / 100);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CREDIT_CENTS()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.PHMod(Math.Abs(rdrU035DTL_TOTALLED.GetNumber("X_CREDIT")), 100);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CREDIT_TOT_DOLLARS()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (rdrU035DTL_TOTALLED.GetNumber("X_CREDIT_TOT") / 100);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CREDIT_TOT_CENTS()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.PHMod(Math.Abs(rdrU035DTL_TOTALLED.GetNumber("X_CREDIT_TOT")), 100);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_BALDUE_TOT_DOLLARS()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = (rdrU035DTL_TOTALLED.GetNumber("X_BALDUE_TOT") / 100);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_BALDUE_TOT_CENTS()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.PHMod(Math.Abs(rdrU035DTL_TOTALLED.GetNumber("X_BALDUE_TOT")), 100);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CHARGE_DOLLARS_ABS()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = Math.Abs(X_CHARGE_DOLLARS());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CHARGE_TOT_DOLLARS_ABS()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = Math.Abs(X_CHARGE_TOT_DOLLARS());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CREDIT_DOLLARS_ABS()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = Math.Abs(X_CREDIT_DOLLARS());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CREDIT_TOT_DOLLARS_ABS()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = Math.Abs(X_CREDIT_TOT_DOLLARS());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_BALDUE_TOT_DOLLARS_ABS()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = Math.Abs(X_BALDUE_TOT_DOLLARS());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CHARGE_CTR1()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(X_CHARGE_DOLLARS_ABS()) < QDesign.NULL(10d)))
                {
                    decReturnValue = 26;
                }
                else if ((QDesign.NULL(X_CHARGE_DOLLARS_ABS()) < QDesign.NULL(100d)))
                {
                    decReturnValue = 46;
                }
                else if ((QDesign.NULL(X_CHARGE_DOLLARS_ABS()) < QDesign.NULL(1000d)))
                {
                    decReturnValue = 61;
                }
                else if ((QDesign.NULL(X_CHARGE_DOLLARS_ABS()) < QDesign.NULL(10000d)))
                {
                    decReturnValue = 76;
                }
                else if ((QDesign.NULL(X_CHARGE_DOLLARS_ABS()) < QDesign.NULL(100000d)))
                {
                    decReturnValue = 95;
                }
                else
                {
                    decReturnValue = 126;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CHARGE_TOT_CTR1()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(X_CHARGE_TOT_DOLLARS_ABS()) < QDesign.NULL(10d)))
                {
                    decReturnValue = 26;
                }
                else if ((QDesign.NULL(X_CHARGE_TOT_DOLLARS_ABS()) < QDesign.NULL(100d)))
                {
                    decReturnValue = 46;
                }
                else if ((QDesign.NULL(X_CHARGE_TOT_DOLLARS_ABS()) < QDesign.NULL(1000d)))
                {
                    decReturnValue = 61;
                }
                else if ((QDesign.NULL(X_CHARGE_TOT_DOLLARS_ABS()) < QDesign.NULL(10000d)))
                {
                    decReturnValue = 76;
                }
                else if ((QDesign.NULL(X_CHARGE_TOT_DOLLARS_ABS()) < QDesign.NULL(100000d)))
                {
                    decReturnValue = 95;
                }
                else
                {
                    decReturnValue = 126;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CREDIT_CTR1()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(X_CREDIT_DOLLARS_ABS()) < QDesign.NULL(10d)))
                {
                    decReturnValue = 26;
                }
                else if ((QDesign.NULL(X_CREDIT_DOLLARS_ABS()) < QDesign.NULL(100d)))
                {
                    decReturnValue = 46;
                }
                else if ((QDesign.NULL(X_CREDIT_DOLLARS_ABS()) < QDesign.NULL(1000d)))
                {
                    decReturnValue = 61;
                }
                else if ((QDesign.NULL(X_CREDIT_DOLLARS_ABS()) < QDesign.NULL(10000d)))
                {
                    decReturnValue = 76;
                }
                else if ((QDesign.NULL(X_CREDIT_DOLLARS_ABS()) < QDesign.NULL(100000d)))
                {
                    decReturnValue = 95;
                }
                else
                {
                    decReturnValue = 126;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CREDIT_TOT_CTR1()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(X_CREDIT_TOT_DOLLARS_ABS()) < QDesign.NULL(10d)))
                {
                    decReturnValue = 26;
                }
                else if ((QDesign.NULL(X_CREDIT_TOT_DOLLARS_ABS()) < QDesign.NULL(100d)))
                {
                    decReturnValue = 46;
                }
                else if ((QDesign.NULL(X_CREDIT_TOT_DOLLARS_ABS()) < QDesign.NULL(1000d)))
                {
                    decReturnValue = 61;
                }
                else if ((QDesign.NULL(X_CREDIT_TOT_DOLLARS_ABS()) < QDesign.NULL(10000d)))
                {
                    decReturnValue = 76;
                }
                else if ((QDesign.NULL(X_CREDIT_TOT_DOLLARS_ABS()) < QDesign.NULL(100000d)))
                {
                    decReturnValue = 95;
                }
                else
                {
                    decReturnValue = 126;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_BALDUE_TOT_CTR1()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(X_BALDUE_TOT_DOLLARS_ABS()) < QDesign.NULL(10d)))
                {
                    decReturnValue = 26;
                }
                else if ((QDesign.NULL(X_BALDUE_TOT_DOLLARS_ABS()) < QDesign.NULL(100d)))
                {
                    decReturnValue = 46;
                }
                else if ((QDesign.NULL(X_BALDUE_TOT_DOLLARS_ABS()) < QDesign.NULL(1000d)))
                {
                    decReturnValue = 61;
                }
                else if ((QDesign.NULL(X_BALDUE_TOT_DOLLARS_ABS()) < QDesign.NULL(10000d)))
                {
                    decReturnValue = 76;
                }
                else if ((QDesign.NULL(X_BALDUE_TOT_DOLLARS_ABS()) < QDesign.NULL(100000d)))
                {
                    decReturnValue = 95;
                }
                else
                {
                    decReturnValue = 126;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CHARGE_CTR2()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(X_CHARGE_DOLLARS()) < QDesign.NULL(0d)))
                {
                    decReturnValue = (X_CHARGE_CTR1() + 14);
                }
                else
                {
                    decReturnValue = X_CHARGE_CTR1();
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CHARGE_TOT_CTR2()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(X_CHARGE_TOT_DOLLARS()) < QDesign.NULL(0d)))
                {
                    decReturnValue = (X_CHARGE_TOT_CTR1() + 14);
                }
                else
                {
                    decReturnValue = X_CHARGE_TOT_CTR1();
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string X_CHARGE_SIGN()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(X_CHARGE_DOLLARS()) < QDesign.NULL(0d)))
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
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CHARGE_TOT_SIGN()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(X_CHARGE_TOT_DOLLARS()) < QDesign.NULL(0d)))
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
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal X_CREDIT_CTR2()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(X_CREDIT_DOLLARS()) < QDesign.NULL(0d)))
                {
                    decReturnValue = (X_CREDIT_CTR1() + 14);
                }
                else
                {
                    decReturnValue = X_CREDIT_CTR1();
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CREDIT_TOT_CTR2()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(X_CREDIT_TOT_DOLLARS()) < QDesign.NULL(0d)))
                {
                    decReturnValue = (X_CREDIT_TOT_CTR1() + 14);
                }
                else
                {
                    decReturnValue = X_CREDIT_TOT_CTR1();
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string X_CREDIT_SIGN()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(X_CREDIT_DOLLARS()) < QDesign.NULL(0d)))
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
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CREDIT_TOT_SIGN()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(X_CREDIT_TOT_DOLLARS()) < QDesign.NULL(0d)))
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
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal X_BALDUE_TOT_CTR2()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(X_BALDUE_TOT_DOLLARS()) < QDesign.NULL(0d)))
                {
                    decReturnValue = (X_BALDUE_TOT_CTR1() + 14);
                }
                else
                {
                    decReturnValue = X_BALDUE_TOT_CTR1();
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string X_BALDUE_TOT_SIGN()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(X_BALDUE_TOT_DOLLARS()) < QDesign.NULL(0d)))
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
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal X_CHARGE_CTR3()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(X_CHARGE_DOLLARS_ABS()) < QDesign.NULL(1000d)))
                {
                    decReturnValue = X_CHARGE_CTR2();
                }
                else
                {
                    decReturnValue = (X_CHARGE_CTR2() + 14);
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CHARGE_TOT_CTR3()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(X_CHARGE_TOT_DOLLARS_ABS()) < QDesign.NULL(1000d)))
                {
                    decReturnValue = X_CHARGE_TOT_CTR2();
                }
                else
                {
                    decReturnValue = (X_CHARGE_TOT_CTR2() + 14);
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CREDIT_CTR3()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(X_CREDIT_DOLLARS_ABS()) < QDesign.NULL(1000d)))
                {
                    decReturnValue = X_CREDIT_CTR2();
                }
                else
                {
                    decReturnValue = (X_CREDIT_CTR2() + 14);
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_CREDIT_TOT_CTR3()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(X_CREDIT_TOT_DOLLARS_ABS()) < QDesign.NULL(1000d)))
                {
                    decReturnValue = X_CREDIT_TOT_CTR2();
                }
                else
                {
                    decReturnValue = (X_CREDIT_TOT_CTR2() + 14);
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_BALDUE_TOT_CTR3()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(X_BALDUE_TOT_DOLLARS_ABS()) < QDesign.NULL(1000d)))
                {
                    decReturnValue = X_BALDUE_TOT_CTR2();
                }
                else
                {
                    decReturnValue = (X_BALDUE_TOT_CTR2() + 14);
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string X_CHARGE_LIT2()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (X_ESC() + ("*p-"
                            + (QDesign.ASCII(X_CHARGE_CTR3(), 3).TrimEnd() + "X")));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CHARGE_TOT_LIT2()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (X_ESC() + ("*p-"
                            + (QDesign.ASCII(X_CHARGE_TOT_CTR3(), 3).TrimEnd() + "X")));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CREDIT_LIT2()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (X_ESC() + ("*p-"
                            + (QDesign.ASCII(X_CREDIT_CTR3(), 3).TrimEnd() + "X")));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CREDIT_TOT_LIT2()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (X_ESC() + ("*p-"
                            + (QDesign.ASCII(X_CREDIT_TOT_CTR3(), 3).TrimEnd() + "X")));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_BALDUE_TOT_LIT2()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (X_ESC() + ("*p-"
                            + (QDesign.ASCII(X_BALDUE_TOT_CTR3(), 3).TrimEnd() + "X")));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CHARGE_DOLLARS_ABS_A()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.ASCII(X_CHARGE_DOLLARS_ABS(), 6);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CHARGE_TOT_DOLLARS_ABS_A()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.ASCII(X_CHARGE_TOT_DOLLARS_ABS(), 6);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CREDIT_DOLLARS_ABS_A()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.ASCII(X_CREDIT_DOLLARS_ABS(), 6);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CREDIT_TOT_DOLLARS_ABS_A()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.ASCII(X_CREDIT_TOT_DOLLARS_ABS(), 6);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_BALDUE_TOT_DOLLARS_ABS_A()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.ASCII(X_BALDUE_TOT_DOLLARS_ABS(), 6);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CHARGE_DOLLARS_ABS_B()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(X_CHARGE_DOLLARS_ABS()) > QDesign.NULL(99999d)))
                {
                    strReturnValue = (X_CHARGE_SIGN() + X_CHARGE_DOLLARS_ABS_A());
                }
                else if ((QDesign.NULL(X_CHARGE_DOLLARS_ABS()) > QDesign.NULL(9999d)))
                {
                    strReturnValue = (X_CHARGE_SIGN() + QDesign.Substring(X_CHARGE_DOLLARS_ABS_A(), 2, 5));
                }
                else if ((QDesign.NULL(X_CHARGE_DOLLARS_ABS()) > QDesign.NULL(999d)))
                {
                    strReturnValue = (X_CHARGE_SIGN() + QDesign.Substring(X_CHARGE_DOLLARS_ABS_A(), 3, 4));
                }
                else if ((QDesign.NULL(X_CHARGE_DOLLARS_ABS()) > QDesign.NULL(99d)))
                {
                    strReturnValue = (X_CHARGE_SIGN() + QDesign.Substring(X_CHARGE_DOLLARS_ABS_A(), 4, 3));
                }
                else if ((QDesign.NULL(X_CHARGE_DOLLARS_ABS()) > QDesign.NULL(9d)))
                {
                    strReturnValue = (X_CHARGE_SIGN() + QDesign.Substring(X_CHARGE_DOLLARS_ABS_A(), 5, 2));
                }
                else
                {
                    strReturnValue = (X_CHARGE_SIGN() + QDesign.Substring(X_CHARGE_DOLLARS_ABS_A(), 6, 1));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CHARGE_TOT_DOLLARS_ABS_B()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(X_CHARGE_TOT_DOLLARS_ABS()) > QDesign.NULL(99999d)))
                {
                    strReturnValue = (X_CHARGE_TOT_SIGN() + X_CHARGE_TOT_DOLLARS_ABS_A());
                }
                else if ((QDesign.NULL(X_CHARGE_TOT_DOLLARS_ABS()) > QDesign.NULL(9999d)))
                {
                    strReturnValue = (X_CHARGE_TOT_SIGN() + QDesign.Substring(X_CHARGE_TOT_DOLLARS_ABS_A(), 2, 5));
                }
                else if ((QDesign.NULL(X_CHARGE_TOT_DOLLARS_ABS()) > QDesign.NULL(999d)))
                {
                    strReturnValue = (X_CHARGE_TOT_SIGN() + QDesign.Substring(X_CHARGE_TOT_DOLLARS_ABS_A(), 3, 4));
                }
                else if ((QDesign.NULL(X_CHARGE_TOT_DOLLARS_ABS()) > QDesign.NULL(99d)))
                {
                    strReturnValue = (X_CHARGE_TOT_SIGN() + QDesign.Substring(X_CHARGE_TOT_DOLLARS_ABS_A(), 4, 3));
                }
                else if ((QDesign.NULL(X_CHARGE_TOT_DOLLARS_ABS()) > QDesign.NULL(9d)))
                {
                    strReturnValue = (X_CHARGE_TOT_SIGN() + QDesign.Substring(X_CHARGE_TOT_DOLLARS_ABS_A(), 5, 2));
                }
                else
                {
                    strReturnValue = (X_CHARGE_TOT_SIGN() + QDesign.Substring(X_CHARGE_TOT_DOLLARS_ABS_A(), 6, 1));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CREDIT_DOLLARS_ABS_B()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(X_CREDIT_DOLLARS_ABS()) > QDesign.NULL(99999d)))
                {
                    strReturnValue = (X_CREDIT_SIGN() + X_CREDIT_DOLLARS_ABS_A());
                }
                else if ((QDesign.NULL(X_CREDIT_DOLLARS_ABS()) > QDesign.NULL(9999d)))
                {
                    strReturnValue = (X_CREDIT_SIGN() + QDesign.Substring(X_CREDIT_DOLLARS_ABS_A(), 2, 5));
                }
                else if ((QDesign.NULL(X_CREDIT_DOLLARS_ABS()) > QDesign.NULL(999d)))
                {
                    strReturnValue = (X_CREDIT_SIGN() + QDesign.Substring(X_CREDIT_DOLLARS_ABS_A(), 3, 4));
                }
                else if ((QDesign.NULL(X_CREDIT_DOLLARS_ABS()) > QDesign.NULL(99d)))
                {
                    strReturnValue = (X_CREDIT_SIGN() + QDesign.Substring(X_CREDIT_DOLLARS_ABS_A(), 4, 3));
                }
                else if ((QDesign.NULL(X_CREDIT_DOLLARS_ABS()) > QDesign.NULL(9d)))
                {
                    strReturnValue = (X_CREDIT_SIGN() + QDesign.Substring(X_CREDIT_DOLLARS_ABS_A(), 5, 2));
                }
                else
                {
                    strReturnValue = (X_CREDIT_SIGN() + QDesign.Substring(X_CREDIT_DOLLARS_ABS_A(), 6, 1));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CREDIT_TOT_DOLLARS_ABS_B()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(X_CREDIT_TOT_DOLLARS_ABS()) > QDesign.NULL(99999d)))
                {
                    strReturnValue = (X_CREDIT_TOT_SIGN() + X_CREDIT_TOT_DOLLARS_ABS_A());
                }
                else if ((QDesign.NULL(X_CREDIT_TOT_DOLLARS_ABS()) > QDesign.NULL(9999d)))
                {
                    strReturnValue = (X_CREDIT_TOT_SIGN() + QDesign.Substring(X_CREDIT_TOT_DOLLARS_ABS_A(), 2, 5));
                }
                else if ((QDesign.NULL(X_CREDIT_TOT_DOLLARS_ABS()) > QDesign.NULL(999d)))
                {
                    strReturnValue = (X_CREDIT_TOT_SIGN() + QDesign.Substring(X_CREDIT_TOT_DOLLARS_ABS_A(), 3, 4));
                }
                else if ((QDesign.NULL(X_CREDIT_TOT_DOLLARS_ABS()) > QDesign.NULL(99d)))
                {
                    strReturnValue = (X_CREDIT_TOT_SIGN() + QDesign.Substring(X_CREDIT_TOT_DOLLARS_ABS_A(), 4, 3));
                }
                else if ((QDesign.NULL(X_CREDIT_TOT_DOLLARS_ABS()) > QDesign.NULL(9d)))
                {
                    strReturnValue = (X_CREDIT_TOT_SIGN() + QDesign.Substring(X_CREDIT_TOT_DOLLARS_ABS_A(), 5, 2));
                }
                else
                {
                    strReturnValue = (X_CREDIT_TOT_SIGN() + QDesign.Substring(X_CREDIT_TOT_DOLLARS_ABS_A(), 6, 1));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_BALDUE_TOT_DOLLARS_ABS_B()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(X_BALDUE_TOT_DOLLARS_ABS()) > QDesign.NULL(99999d)))
                {
                    strReturnValue = (X_BALDUE_TOT_SIGN() + X_BALDUE_TOT_DOLLARS_ABS_A());
                }
                else if ((QDesign.NULL(X_BALDUE_TOT_DOLLARS_ABS()) > QDesign.NULL(9999d)))
                {
                    strReturnValue = (X_BALDUE_TOT_SIGN() + QDesign.Substring(X_BALDUE_TOT_DOLLARS_ABS_A(), 2, 5));
                }
                else if ((QDesign.NULL(X_BALDUE_TOT_DOLLARS_ABS()) > QDesign.NULL(999d)))
                {
                    strReturnValue = (X_BALDUE_TOT_SIGN() + QDesign.Substring(X_BALDUE_TOT_DOLLARS_ABS_A(), 3, 4));
                }
                else if ((QDesign.NULL(X_BALDUE_TOT_DOLLARS_ABS()) > QDesign.NULL(99d)))
                {
                    strReturnValue = (X_BALDUE_TOT_SIGN() + QDesign.Substring(X_BALDUE_TOT_DOLLARS_ABS_A(), 4, 3));
                }
                else if ((QDesign.NULL(X_BALDUE_TOT_DOLLARS_ABS()) > QDesign.NULL(9d)))
                {
                    strReturnValue = (X_BALDUE_TOT_SIGN() + QDesign.Substring(X_BALDUE_TOT_DOLLARS_ABS_A(), 5, 2));
                }
                else
                {
                    strReturnValue = (X_BALDUE_TOT_SIGN() + QDesign.Substring(X_BALDUE_TOT_DOLLARS_ABS_A(), 6, 1));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CHARGE_DOLLARS_ABS_CHAR()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.RightJustify(X_CHARGE_DOLLARS_ABS_B());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CHARGE_TOT_DOLLARS_ABS_CHAR()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.RightJustify(X_CHARGE_TOT_DOLLARS_ABS_B());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CREDIT_DOLLARS_ABS_CHAR()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.RightJustify(X_CREDIT_DOLLARS_ABS_B());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CREDIT_TOT_DOLLARS_ABS_CHAR()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.RightJustify(X_CREDIT_TOT_DOLLARS_ABS_B());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_BALDUE_TOT_DOLLARS_ABS_CHAR()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.RightJustify(X_BALDUE_TOT_DOLLARS_ABS_B());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CHARGE_PRT_DOLLARS()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(X_CHARGE_DOLLARS_ABS()) < QDesign.NULL(1000d)))
                {
                    strReturnValue = (" " + X_CHARGE_DOLLARS_ABS_CHAR());
                }
                else
                {
                    strReturnValue = (QDesign.Substring(X_CHARGE_DOLLARS_ABS_CHAR(), 1, 4) + ("," + QDesign.Substring(X_CHARGE_DOLLARS_ABS_CHAR(), 5, 3)));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CHARGE_TOT_PRT_DOLLARS()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(X_CHARGE_TOT_DOLLARS_ABS()) < QDesign.NULL(1000d)))
                {
                    strReturnValue = (" " + X_CHARGE_TOT_DOLLARS_ABS_CHAR());
                }
                else
                {
                    strReturnValue = (QDesign.Substring(X_CHARGE_TOT_DOLLARS_ABS_CHAR(), 1, 4) + ("," + QDesign.Substring(X_CHARGE_TOT_DOLLARS_ABS_CHAR(), 5, 3)));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CREDIT_PRT_DOLLARS()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(X_CREDIT_DOLLARS_ABS()) < QDesign.NULL(1000d)))
                {
                    strReturnValue = (" " + X_CREDIT_DOLLARS_ABS_CHAR());
                }
                else
                {
                    strReturnValue = (QDesign.Substring(X_CREDIT_DOLLARS_ABS_CHAR(), 1, 4) + ("," + QDesign.Substring(X_CREDIT_DOLLARS_ABS_CHAR(), 5, 3)));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CREDIT_TOT_PRT_DOLLARS()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(X_CREDIT_TOT_DOLLARS_ABS()) < QDesign.NULL(1000d)))
                {
                    strReturnValue = (" " + X_CREDIT_TOT_DOLLARS_ABS_CHAR());
                }
                else
                {
                    strReturnValue = (QDesign.Substring(X_CREDIT_TOT_DOLLARS_ABS_CHAR(), 1, 4) + ("," + QDesign.Substring(X_CREDIT_TOT_DOLLARS_ABS_CHAR(), 5, 3)));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_BALDUE_TOT_PRT_DOLLARS()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(X_BALDUE_TOT_DOLLARS_ABS()) < QDesign.NULL(1000d)))
                {
                    strReturnValue = (" " + X_BALDUE_TOT_DOLLARS_ABS_CHAR());
                }
                else
                {
                    strReturnValue = (QDesign.Substring(X_BALDUE_TOT_DOLLARS_ABS_CHAR(), 1, 4) + ("," + QDesign.Substring(X_BALDUE_TOT_DOLLARS_ABS_CHAR(), 5, 3)));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CHARGE_PRT_CENTS()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.ASCII(X_CHARGE_CENTS(), 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CHARGE_TOT_PRT_CENTS()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.ASCII(X_CHARGE_TOT_CENTS(), 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CREDIT_PRT_CENTS()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.ASCII(X_CREDIT_CENTS(), 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CREDIT_TOT_PRT_CENTS()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.ASCII(X_CREDIT_TOT_CENTS(), 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_BALDUE_TOT_PRT_CENTS()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.ASCII(X_BALDUE_TOT_CENTS(), 2);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CHARGE_PRT()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(rdrU035DTL_TOTALLED.GetNumber("X_CHARGE")) != QDesign.NULL(0d)))
                {
                    strReturnValue = (QDesign.LeftJustify(X_CHARGE_LIT1()).TrimEnd()
                                + (QDesign.LeftJustify(X_CHARGE_LIT2()).TrimEnd()
                                + (QDesign.LeftJustify(X_CHARGE_PRT_DOLLARS()).TrimEnd()
                                + (X_PERIOD() + X_CHARGE_PRT_CENTS()))));
                }
                else
                {
                    strReturnValue = " ";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CHARGE_TOT_PRT()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (X_CHARGE_TOT_LIT1().TrimEnd()
                            + (X_CHARGE_TOT_LIT2().TrimEnd()
                            + (QDesign.LeftJustify(X_CHARGE_TOT_PRT_DOLLARS()).TrimEnd()
                            + (X_PERIOD() + X_CHARGE_TOT_PRT_CENTS()))));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CREDIT_PRT()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(rdrU035DTL_TOTALLED.GetNumber("X_CREDIT")) != QDesign.NULL(0d)))
                {
                    strReturnValue = (X_CREDIT_LIT1().TrimEnd()
                                + (X_CREDIT_LIT2().TrimEnd()
                                + (QDesign.LeftJustify(X_CREDIT_PRT_DOLLARS()).TrimEnd()
                                + (X_PERIOD() + X_CREDIT_PRT_CENTS()))));
                }
                else
                {
                    strReturnValue = " ";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_CREDIT_TOT_PRT()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (X_CREDIT_TOT_LIT1().TrimEnd()
                            + (X_CREDIT_TOT_LIT2().TrimEnd()
                            + (QDesign.LeftJustify(X_CREDIT_TOT_PRT_DOLLARS()).TrimEnd()
                            + (X_PERIOD() + X_CREDIT_TOT_PRT_CENTS()))));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_BALDUE_TOT_PRT()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (X_BALDUE_TOT_LIT1().TrimEnd()
                            + (X_BALDUE_TOT_LIT2().TrimEnd()
                            + (QDesign.LeftJustify(X_BALDUE_TOT_PRT_DOLLARS()).TrimEnd()
                            + (X_PERIOD() + X_BALDUE_TOT_PRT_CENTS()))));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_SERV_DATE_ASCII()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = QDesign.ASCII(rdrU035DTL_TOTALLED.GetNumber("X_SERV_DATE"), 8);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        //  TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:
        private string X_SERV_DATE_PRT()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(rdrU035DTL_TOTALLED.GetNumber("X_SERV_DATE")) != QDesign.NULL(0d)))
                {
                    strReturnValue = (QDesign.Substring(X_SERV_DATE_ASCII(), 1, 4) + ("/"
                                + (QDesign.Substring(X_SERV_DATE_ASCII(), 5, 2) + ("/" + QDesign.Substring(X_SERV_DATE_ASCII(), 7, 2)))));
                }
                else
                {
                    strReturnValue = " ";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_SERV_NBR_PRT()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(rdrU035DTL_TOTALLED.GetNumber("X_NBR_SERV")) != QDesign.NULL(0d)))
                {
                    strReturnValue = QDesign.ASCII(rdrU035DTL_TOTALLED.GetNumber("X_NBR_SERV"), 2);
                }
                else
                {
                    strReturnValue = " ";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_OHIP_CD_PRT()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(rdrU035DTL_TOTALLED.GetString("X_OHIP_CD")) != "PAID"))
                {
                    strReturnValue = rdrU035DTL_TOTALLED.GetString("X_OHIP_CD");
                }
                else
                {
                    strReturnValue = " ";
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_DASH()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(rdrU035DTL_TOTALLED.GetString("X_OHIP_CD")) != "PAID"))
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
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private decimal X_LINES_PER_PAGE()
        {
            decimal decReturnValue = 0;
            try
            {
                if ((QDesign.NULL(rdrU035DTL_TOTALLED.GetNumber("X_PAT_DTL_COUNTER")) < QDesign.NULL(41d)))
                {
                    decReturnValue = 40;
                }
                else if ((QDesign.NULL(rdrU035DTL_TOTALLED.GetNumber("X_PAT_DTL_COUNTER")) < QDesign.NULL(91d)))
                {
                    decReturnValue = 90;
                }
                else if ((QDesign.NULL(rdrU035DTL_TOTALLED.GetNumber("X_PAT_DTL_COUNTER")) < QDesign.NULL(141d)))
                {
                    decReturnValue = 140;
                }
                else if ((QDesign.NULL(rdrU035DTL_TOTALLED.GetNumber("X_PAT_DTL_COUNTER")) < QDesign.NULL(191d)))
                {
                    decReturnValue = 190;
                }
                else if ((QDesign.NULL(rdrU035DTL_TOTALLED.GetNumber("X_PAT_DTL_COUNTER")) < QDesign.NULL(241d)))
                {
                    decReturnValue = 240;
                }
                else if ((QDesign.NULL(rdrU035DTL_TOTALLED.GetNumber("X_PAT_DTL_COUNTER")) < QDesign.NULL(291d)))
                {
                    decReturnValue = 290;
                }
                else
                {
                    decReturnValue = 340;
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private decimal X_LAST_LINE_ON_PAGE()
        {
            decimal decReturnValue = 0;
            try
            {
                decReturnValue = QDesign.PHMod(rdrU035DTL_TOTALLED.GetNumber("X_PAT_DTL_COUNTER"), X_LINES_PER_PAGE());
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        private string X_NEW_PAGE_SKIP_5_LINES()
        {
            string strReturnValue = string.Empty;
            try
            {
                if ((QDesign.NULL(X_LAST_LINE_ON_PAGE()) == QDesign.NULL(0d)))
                {
                    strReturnValue = (X_FF() + HPIII_DOWN_5_ROWS());
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_PRINT_LINE()
        {
            string strReturnValue = string.Empty;
            try
            {
                if (((QDesign.NULL(rdrU035DTL_TOTALLED.GetString("X_OHIP_CD")) != QDesign.NULL("     "))
                            && (QDesign.NULL(rdrU035DTL_TOTALLED.GetString("X_OHIP_CD")) != "ZZZZZ")))
                {
                    strReturnValue = QDesign.Substring(rdrU035DTL_TOTALLED.GetString("X_DOC_NAME"), 1, 15) + "        "
                                + HPIII_COLUMN_34()
                                + rdrU035DTL_TOTALLED.GetString("X_CLAIM_NO")
                                + HPIII_COLUMN_58()
                                + X_SERV_DATE_PRT()
                                + HPIII_COLUMN_83()
                                + X_SERV_NBR_PRT()
                                + HPIII_COLUMN_91()
                                + X_OHIP_CD_PRT()
                                + HPIII_COLUMN_101()
                                + X_DASH()
                                + HPIII_COLUMN_103()
                                + rdrU035DTL_TOTALLED.GetString("X_DESC")
                                + HPIII_COLUMN_135()
                                + QDesign.LeftJustify(X_CHARGE_PRT()).TrimEnd()
                                + QDesign.LeftJustify(X_CREDIT_PRT()).TrimEnd() + X_NEW_PAGE_SKIP_5_LINES();
                }
                else
                {
                    strReturnValue = (HPIII_FONT_HEIGHT_8()
                                + (HPIII_BOLD()
                                + (HPIII_COLUMN_103()
                                + (HPIII_UNDERLINE_ON()
                                + (rdrU035DTL_TOTALLED.GetString("X_DESC").TrimEnd()
                                + (HPIII_UNDERLINE_OFF()
                                + (HPIII_FONT_HEIGHT_8()
                                + (HPIII_MEDIUM() + X_NEW_PAGE_SKIP_5_LINES()))))))));
                }
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_PAT_MSG_1_2()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (HPIII_FONT_HEIGHT_10()
                            + (HPIII_FONT_ITALIC()
                            + (HPIII_BOLD()
                            + (QDesign.LeftJustify(rdrF094_MSG_MSTR.GetString("MSG_DTL1")).TrimEnd() + (" "
                            + (QDesign.LeftJustify(rdrF094_MSG_MSTR.GetString("MSG_DTL2")).TrimEnd()
                            + (HPIII_FONT_UPRIGHT()
                            + (HPIII_FONT_HEIGHT_8() + HPIII_MEDIUM()))))))));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_PAT_MSG_3_4()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (HPIII_FONT_HEIGHT_10()
                            + (HPIII_FONT_ITALIC()
                            + (HPIII_BOLD()
                            + (QDesign.LeftJustify(rdrF094_MSG_MSTR.GetString("MSG_DTL3")).TrimEnd() + (" "
                            + (QDesign.LeftJustify(rdrF094_MSG_MSTR.GetString("MSG_DTL4")).TrimEnd()
                            + (HPIII_FONT_UPRIGHT()
                            + (HPIII_FONT_HEIGHT_8() + HPIII_MEDIUM()))))))));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_MSG_DUE_1()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (HPIII_FONT_HEIGHT_10()
                            + (HPIII_BOLD() + ("Note: All accounts are due when rendered. " + (" RMA is a 3rd party billing office on behalf of the physician."
                            + (HPIII_FONT_HEIGHT_8() + HPIII_MEDIUM())))));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_SHADING_BOX_1()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (X_ESC() + ("&a-2R"
                            + (X_ESC() + ("&a01C"
                            + (X_ESC() + ("*c1900A"
                            + (X_ESC() + ("*c075B"
                            + (X_ESC() + ("*c20G"
                            + (X_ESC() + ("*c2P"
                            + (X_ESC() + ("&a0C"
                            + (X_ESC() + "&a+2R")))))))))))))));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_SHADING_BOX_2()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (X_ESC() + ("&a-2R"
                            + (X_ESC() + ("&a125C"
                            + (X_ESC() + ("*c800A"
                            + (X_ESC() + ("*c075B"
                            + (X_ESC() + ("*c20G"
                            + (X_ESC() + ("*c2P"
                            + (X_ESC() + ("&a0C"
                            + (X_ESC() + "&a+2R")))))))))))))));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_SHADING_BOX_3A()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (X_ESC() + ("&a-2R"
                            + (X_ESC() + ("&a115C"
                            + (X_ESC() + ("*c485A"
                            + (X_ESC() + ("*c075B"
                            + (X_ESC() + ("*c20G"
                            + (X_ESC() + ("*c2P"
                            + (X_ESC() + "&a0C")))))))))))));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_SHADING_BOX_3B()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (X_ESC() + ("&a168C"
                            + (X_ESC() + ("*c700A"
                            + (X_ESC() + ("*c075B"
                            + (X_ESC() + ("*c20G"
                            + (X_ESC() + ("*c2P"
                            + (X_ESC() + ("&a0C"
                            + (X_ESC() + "&a+2R")))))))))))));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_SHADING_BOX_4()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (X_ESC() + ("&a-3R"
                            + (X_ESC() + ("&a01C"
                            + (X_ESC() + ("*c1900A"
                            + (X_ESC() + ("*c150B"
                            + (X_ESC() + ("*c20G"
                            + (X_ESC() + ("*c2P"
                            + (X_ESC() + ("&a0C"
                            + (X_ESC() + "&a+2R")))))))))))))));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_SUBTOTALS_LINE()
        {
            string strReturnValue = string.Empty;
            try
            {
                //strReturnValue = X_ESC() + "&a+1R" + X_ESC() + "&a170C" + "Totals:" + QDesign.LeftJustify(X_CHARGE_TOT_PRT()).TrimEnd() + QDesign.LeftJustify(X_CREDIT_TOT_PRT()).TrimEnd();
                strReturnValue = X_ESC() + "&a+1R" + X_ESC() + "&a170C" + "Totals:";
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_BALDUE_LINE()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = (HPIII_FONT_HEIGHT_10()
                            + (HPIII_BOLD() + ("BALANCE DUE"
                            + (QDesign.LeftJustify(X_BALDUE_TOT_PRT())
                            + (HPIII_FONT_HEIGHT_8() + HPIII_MEDIUM())))));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }

        private string X_MSG_EMAIL()
        {
            string strReturnValue = string.Empty;
            try
            {
                strReturnValue = ("4)  E-mail RMA at "
                            + (HPIII_BOLD()
                            + (HPIII_UNDERLINE_ON() + ("vaughanj@mcmaster.ca"
                            + (HPIII_UNDERLINE_OFF()
                            + (HPIII_MEDIUM() + " with your credit card information and the account number above."))))));
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.HEADING_AT, "HPIII_INIT_PAGE_CODES", DataTypes.Character, 198);
                AddControl(ReportSection.HEADING_AT, "X_TITLE_1A", DataTypes.Character, 90);
                AddControl(ReportSection.HEADING_AT, "X_TITLE_1B", DataTypes.Character, 90);
                AddControl(ReportSection.HEADING_AT, "X_PAT_NAME", DataTypes.Character, 40);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U035DTL_TOTALLED.SUBSCR_ADDR1", DataTypes.Character, 30);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U035DTL_TOTALLED.SUBSCR_ADDR2", DataTypes.Character, 30);
                AddControl(ReportSection.HEADING_AT, "X_CITY_PROV", DataTypes.Character, 30);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U035DTL_TOTALLED.SUBSCR_POSTAL_CD", DataTypes.Character, 10);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U035DTL_TOTALLED.PAT_COUNTRY", DataTypes.Character, 1);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.U035DTL_TOTALLED.PAT_OHIP_MMYY", DataTypes.Character, 15);
                AddControl(ReportSection.REPORT, "X_PRINT_LINE", DataTypes.Character, 250);
                AddControl(ReportSection.FOOTING_AT, "X_SUBTOTALS_LINE", DataTypes.Character, 220);
                AddControl(ReportSection.FOOTING_AT, "HPIII_FONT_HEIGHT_10", DataTypes.Character, 9);
                AddControl(ReportSection.FOOTING_AT, "HPIII_BOLD", DataTypes.Character, 5);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U035DTL_TOTALLED.X_CHARGE_TOT", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U035DTL_TOTALLED.X_CREDIT_TOT", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U035DTL_TOTALLED.X_BALDUE_TOT", DataTypes.Numeric, 8);
                AddControl(ReportSection.FOOTING_AT, "HPIII_FONT_HEIGHT_8", DataTypes.Character, 9);
                AddControl(ReportSection.FOOTING_AT, "HPIII_MEDIUM", DataTypes.Character, 5);
                AddControl(ReportSection.FOOTING_AT, "X_SHADING_BOX_1", DataTypes.Character, 80);
                AddControl(ReportSection.FOOTING_AT, "X_PAT_MSG_1_2", DataTypes.Character, 190);
                AddControl(ReportSection.FOOTING_AT, "X_PAT_MSG_3_4", DataTypes.Character, 190);
                AddControl(ReportSection.FOOTING_AT, "X_MSG_DUE_1", DataTypes.Character, 190);
                AddControl(ReportSection.FOOTING_AT, "X_FF", DataTypes.Character, 2);
                AddControl(ReportSection.FOOTING_AT, "X_SHADING_BOX_3A", DataTypes.Character, 80);
                AddControl(ReportSection.FOOTING_AT, "X_SHADING_BOX_3B", DataTypes.Character, 80);
                AddControl(ReportSection.FOOTING_AT, "X_CHEQUES", DataTypes.Character, 62);
                AddControl(ReportSection.FOOTING_AT, "X_MSG_EMAIL", DataTypes.Character, 198);
                AddControl(ReportSection.FOOTING_AT, "X_SHADING_BOX_4", DataTypes.Character, 80);
                AddControl(ReportSection.FOOTING_AT, "X_MSG_0", DataTypes.Character, 150);
                AddControl(ReportSection.FOOTING_AT, "X_MSG_1", DataTypes.Character, 150);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U035DTL_TOTALLED.CLMHDR_AGENT_CD", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U035DTL_TOTALLED.CLM_SHADOW_CLINIC", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U035DTL_TOTALLED.CLMHDR_SUB_NBR", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U035DTL_TOTALLED.PAT_SURNAME", DataTypes.Character, 25);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U035DTL_TOTALLED.PAT_GIVEN_NAME", DataTypes.Character, 17);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U035DTL_TOTALLED.DEPT_COMPANY", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U035DTL_TOTALLED.CLMHDR_PAT_OHIP_ID_OR_CHART", DataTypes.Character, 16);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U035DTL_TOTALLED.X_PAT", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U035DTL_TOTALLED.CLM_SHADOW_BATCH_NBR", DataTypes.Character, 8);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U035DTL_TOTALLED.CLM_SHADOW_CLAIM_NBR", DataTypes.Character, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U035DTL_TOTALLED.X_CLAIM_REC_COUNTER", DataTypes.Character, 6);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.U035DTL_TOTALLED.X_TYPE", DataTypes.Character, 1);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U035DTL_TOTALLED.X_CHARGE", DataTypes.Numeric, 10);
                AddControl(ReportSection.FOOTING_AT, "TEMPORARYDATA.U035DTL_TOTALLED.X_CREDIT", DataTypes.Numeric, 10);
            }

            catch (Exception ex)
            {
                //  Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 2018-05-11 7:47:38 AM
        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "HPIII_INIT_PAGE_CODES":
                    return Common.StringToField(HPIII_INIT_PAGE_CODES(), intSize);

                case "X_TITLE_1A":
                    return Common.StringToField(X_TITLE_1A(), intSize);

                case "X_TITLE_1B":
                    return Common.StringToField(X_TITLE_1B(), intSize);

                case "X_PAT_NAME":
                    return Common.StringToField(X_PAT_NAME(), intSize);

                case "TEMPORARYDATA.U035DTL_TOTALLED.SUBSCR_ADDR1":
                    return Common.StringToField(rdrU035DTL_TOTALLED.GetString("SUBSCR_ADDR1"));

                case "TEMPORARYDATA.U035DTL_TOTALLED.SUBSCR_ADDR2":
                    return Common.StringToField(rdrU035DTL_TOTALLED.GetString("SUBSCR_ADDR2"));

                case "X_CITY_PROV":
                    return Common.StringToField(X_CITY_PROV(), intSize);

                case "TEMPORARYDATA.U035DTL_TOTALLED.SUBSCR_POSTAL_CD":
                    return Common.StringToField(rdrU035DTL_TOTALLED.GetString("SUBSCR_POSTAL_CD"));

                case "TEMPORARYDATA.U035DTL_TOTALLED.PAT_COUNTRY":
                    return Common.StringToField(rdrU035DTL_TOTALLED.GetString("PAT_COUNTRY"));

                case "TEMPORARYDATA.U035DTL_TOTALLED.PAT_OHIP_MMYY":
                    return Common.StringToField(rdrU035DTL_TOTALLED.GetString("PAT_OHIP_MMYY"));

                case "X_PRINT_LINE":
                    return Common.StringToField(X_PRINT_LINE(), intSize);

                case "X_SUBTOTALS_LINE":
                    return Common.StringToField(X_SUBTOTALS_LINE(), intSize);

                case "HPIII_FONT_HEIGHT_10":
                    return Common.StringToField(HPIII_FONT_HEIGHT_10(), intSize);

                case "HPIII_BOLD":
                    return Common.StringToField(HPIII_BOLD(), intSize);

                case "TEMPORARYDATA.U035DTL_TOTALLED.X_CHARGE_TOT":
                    return rdrU035DTL_TOTALLED.GetNumber("X_CHARGE_TOT").ToString();

                case "TEMPORARYDATA.U035DTL_TOTALLED.X_CREDIT_TOT":
                    return rdrU035DTL_TOTALLED.GetNumber("X_CREDIT_TOT").ToString();

                case "TEMPORARYDATA.U035DTL_TOTALLED.X_BALDUE_TOT":
                    return rdrU035DTL_TOTALLED.GetNumber("X_BALDUE_TOT").ToString();

                case "HPIII_FONT_HEIGHT_8":
                    return Common.StringToField(HPIII_FONT_HEIGHT_8(), intSize);

                case "HPIII_MEDIUM":
                    return Common.StringToField(HPIII_MEDIUM(), intSize);

                case "X_SHADING_BOX_1":
                    return Common.StringToField(X_SHADING_BOX_1(), intSize);

                case "X_PAT_MSG_1_2":
                    return Common.StringToField(X_PAT_MSG_1_2(), intSize);

                case "X_PAT_MSG_3_4":
                    return Common.StringToField(X_PAT_MSG_3_4(), intSize);

                case "X_MSG_DUE_1":
                    return Common.StringToField(X_MSG_DUE_1(), intSize);

                case "X_FF":
                    return Common.StringToField(X_FF(), intSize);

                case "X_SHADING_BOX_3A":
                    return Common.StringToField(X_SHADING_BOX_3A(), intSize);

                case "X_SHADING_BOX_3B":
                    return Common.StringToField(X_SHADING_BOX_3B(), intSize);

                case "X_CHEQUES":
                    return Common.StringToField(X_CHEQUES(), intSize);

                case "X_MSG_EMAIL":
                    return Common.StringToField(X_MSG_EMAIL(), intSize);

                case "X_SHADING_BOX_4":
                    return Common.StringToField(X_SHADING_BOX_4(), intSize);

                case "X_MSG_0":
                    return Common.StringToField(X_MSG_0(), intSize);

                case "X_MSG_1":
                    return Common.StringToField(X_MSG_1(), intSize);

                case "TEMPORARYDATA.U035DTL_TOTALLED.CLMHDR_AGENT_CD":
                    return Common.StringToField(rdrU035DTL_TOTALLED.GetString("CLMHDR_AGENT_CD"));

                case "TEMPORARYDATA.U035DTL_TOTALLED.CLM_SHADOW_CLINIC":
                    return Common.StringToField(rdrU035DTL_TOTALLED.GetString("CLM_SHADOW_CLINIC"));

                case "TEMPORARYDATA.U035DTL_TOTALLED.CLMHDR_SUB_NBR":
                    return Common.StringToField(rdrU035DTL_TOTALLED.GetString("CLMHDR_SUB_NBR"));

                case "TEMPORARYDATA.U035DTL_TOTALLED.PAT_SURNAME":
                    return Common.StringToField(rdrU035DTL_TOTALLED.GetString("PAT_SURNAME"));

                case "TEMPORARYDATA.U035DTL_TOTALLED.PAT_GIVEN_NAME":
                    return Common.StringToField(rdrU035DTL_TOTALLED.GetString("PAT_GIVEN_NAME"));

                case "TEMPORARYDATA.U035DTL_TOTALLED.DEPT_COMPANY":
                    return Common.StringToField(rdrU035DTL_TOTALLED.GetString("DEPT_COMPANY"));

                case "TEMPORARYDATA.U035DTL_TOTALLED.CLMHDR_PAT_OHIP_ID_OR_CHART":
                    return Common.StringToField(rdrU035DTL_TOTALLED.GetString("CLMHDR_PAT_OHIP_ID_OR_CHART"));

                case "TEMPORARYDATA.U035DTL_TOTALLED.X_PAT":
                    return Common.StringToField(rdrU035DTL_TOTALLED.GetString("X_PAT"));

                case "TEMPORARYDATA.U035DTL_TOTALLED.CLM_SHADOW_BATCH_NBR":
                    return Common.StringToField(rdrU035DTL_TOTALLED.GetString("CLM_SHADOW_BATCH_NBR"));

                case "TEMPORARYDATA.U035DTL_TOTALLED.CLM_SHADOW_CLAIM_NBR":
                    return Common.StringToField(rdrU035DTL_TOTALLED.GetString("CLM_SHADOW_CLAIM_NBR"));

                case "TEMPORARYDATA.U035DTL_TOTALLED.X_CLAIM_REC_COUNTER":
                    return Common.StringToField(rdrU035DTL_TOTALLED.GetString("X_CLAIM_REC_COUNTER"));

                case "TEMPORARYDATA.U035DTL_TOTALLED.X_TYPE":
                    return Common.StringToField(rdrU035DTL_TOTALLED.GetString("X_TYPE"));

                case "TEMPORARYDATA.U035DTL_TOTALLED.X_CHARGE":
                    return rdrU035DTL_TOTALLED.GetNumber("X_CHARGE").ToString();

                case "TEMPORARYDATA.U035DTL_TOTALLED.X_CREDIT":
                    return rdrU035DTL_TOTALLED.GetNumber("X_CREDIT").ToString();

                default:
                    return string.Empty;
            }
        }
        public override void AccessData()
        {
            try
            {
                Access_U035DTL_TOTALLED();
                while (rdrU035DTL_TOTALLED.Read())
                {
                    Link_F010_PAT_MSTR();
                    while (rdrF010_PAT_MSTR.Read())
                    {
                        Link_F094_MSG_MSTR();
                        while (rdrF094_MSG_MSTR.Read())
                        {
                            WriteData();
                        }

                        rdrF094_MSG_MSTR.Close();
                    }

                    rdrF010_PAT_MSTR.Close();
                }

                rdrU035DTL_TOTALLED.Close();
            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }
        public override void CloseReaders()
        {
            if (!(rdrU035DTL_TOTALLED == null))
            {
                rdrU035DTL_TOTALLED.Close();
                rdrU035DTL_TOTALLED = null;
            }

            if (!(rdrF010_PAT_MSTR == null))
            {
                rdrF010_PAT_MSTR.Close();
                rdrF010_PAT_MSTR = null;
            }

            if (!(rdrF094_MSG_MSTR == null))
            {
                rdrF094_MSG_MSTR.Close();
                rdrF094_MSG_MSTR = null;
            }
        }
    }
}
