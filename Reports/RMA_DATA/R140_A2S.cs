#region "Screen Comments"

// 2008/11/24 M.C. - modify to have the same headings and format as r140_b.txt
// 2008/12/02 MC1 - modify page length and  add nohead to the same as for r140_b.txt
// so that when Yas upload in word, it displays properly
// 2008/12/02 - MC1
// set page width 132 length 60 
// 2008/12/02 - end

#endregion

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
    public class R140_A2S : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R140_A2S";
        protected const bool REPORT_HAS_PARAMETERS = false;

        // Data Helpers.
        private Reader rdrAFP_A2S_FILE = new Reader();
        private Reader rdrF074_AFP_GROUP_MSTR = new Reader();

        //#CORE_BEGIN_INCLUDE: PRINTER_CODES"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 10/10/2017 2:46:57 PM

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

                Sort = "DOC_AFP_PAYM_GROUP ASC, AFP_SOLO_NAME ASC";

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

        private void Access_AFP_A2S_FILE()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_AFP_PAYM_GROUP, ");
            strSQL.Append("AFP_SOLO_NAME, ");
            strSQL.Append("AFP_PAYMENT_PERCENTAGE, ");
            strSQL.Append("AFP_CONVERSION_SIGN, ");
            strSQL.Append("AFP_CONVERSION_AMT, ");
            strSQL.Append("AFP_SUBMISSION_SIGN, ");
            strSQL.Append("AFP_SUBMISSION_AMT, ");
            strSQL.Append("DOC_AFP_PAYM_SOLO ");
            strSQL.Append("FROM SEQUENTIAL.AFP_A2S_FILE ");

            strSQL.Append(Choose());

            rdrAFP_A2S_FILE.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.m_strFlatFileDictionary, ReportFunctions.TextFiles);

            strSQL = null;
        }

        private void Link_F074_AFP_GROUP_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_AFP_PAYM_GROUP, ");
            strSQL.Append("AFP_REPORTING_MTH, ");
            strSQL.Append("AFP_GROUP_NAME ");
            strSQL.Append("FROM [101C].INDEXED.F074_AFP_GROUP_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DOC_AFP_PAYM_GROUP = ").Append(Common.StringToField(rdrAFP_A2S_FILE.GetString("DOC_AFP_PAYM_GROUP")));

            rdrF074_AFP_GROUP_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

        private decimal X_DOC_COUNT()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = 1m;
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

        private string X_PAY_PERCENTAGE()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(rdrAFP_A2S_FILE.GetNumber("AFP_PAYMENT_PERCENTAGE")) == QDesign.NULL(0d))
                {
                    strReturnValue = "10/60";
                }
                else
                {
                    strReturnValue = " " + QDesign.ASCII(rdrAFP_A2S_FILE.GetNumber("AFP_PAYMENT_PERCENTAGE"), 2);
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private decimal X_CONVERSION_AMT()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrAFP_A2S_FILE.GetString("AFP_CONVERSION_SIGN")) == QDesign.NULL(" "))
                {
                    decReturnValue = rdrAFP_A2S_FILE.GetNumber("AFP_CONVERSION_AMT");
                }
                else
                {
                    decReturnValue = 0 - rdrAFP_A2S_FILE.GetNumber("AFP_CONVERSION_AMT");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_SUBMISSION_AMT()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(rdrAFP_A2S_FILE.GetString("AFP_SUBMISSION_SIGN")) == QDesign.NULL(" "))
                {
                    decReturnValue = rdrAFP_A2S_FILE.GetNumber("AFP_SUBMISSION_AMT");
                }
                else
                {
                    decReturnValue = 0 - rdrAFP_A2S_FILE.GetNumber("AFP_SUBMISSION_AMT");
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }

        #endregion

        #region " CONTROLS "

        public override void DeclareReportControls()
        {
            try
            {
                AddControl(ReportSection.PAGE_HEADING, "X_FF", DataTypes.Character, 1);
                AddControl(ReportSection.PAGE_HEADING, "INDEXED.F074_AFP_GROUP_MSTR.AFP_REPORTING_MTH", DataTypes.Character, 6);
                AddControl(ReportSection.HEADING_AT, "SEQUENTIAL.AFP_A2S_FILE.DOC_AFP_PAYM_GROUP", DataTypes.Character, 4);
                AddControl(ReportSection.HEADING_AT, "INDEXED.F074_AFP_GROUP_MSTR.AFP_GROUP_NAME", DataTypes.Character, 75);
                AddControl(ReportSection.REPORT, "SEQUENTIAL.AFP_A2S_FILE.AFP_SOLO_NAME", DataTypes.Character, 75);
                AddControl(ReportSection.REPORT, "SEQUENTIAL.AFP_A2S_FILE.DOC_AFP_PAYM_SOLO", DataTypes.Character, 6);
                AddControl(ReportSection.REPORT, "X_PAY_PERCENTAGE", DataTypes.Character, 5);
                AddControl(ReportSection.REPORT, "X_CONVERSION_AMT", DataTypes.Numeric, 11);
                AddControl(ReportSection.REPORT, "X_SUBMISSION_AMT", DataTypes.Numeric, 11);
                AddControl(ReportSection.FOOTING_AT, "X_DOC_COUNT", DataTypes.Numeric, 6);
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
        //# Do not delete, modify or move it.  Updated: 10/10/2017 2:46:57 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "X_FF":
                    return Common.StringToField(X_FF().PadRight(1, ' '));

                case "INDEXED.F074_AFP_GROUP_MSTR.AFP_REPORTING_MTH":
                    return Common.StringToField(rdrF074_AFP_GROUP_MSTR.GetString("AFP_REPORTING_MTH").PadRight(6, ' '));

                case "SEQUENTIAL.AFP_A2S_FILE.DOC_AFP_PAYM_GROUP":
                    return Common.StringToField(rdrAFP_A2S_FILE.GetString("DOC_AFP_PAYM_GROUP").PadRight(4, ' '));

                case "INDEXED.F074_AFP_GROUP_MSTR.AFP_GROUP_NAME":
                    return Common.StringToField(rdrF074_AFP_GROUP_MSTR.GetString("AFP_GROUP_NAME").PadRight(75, ' '));

                case "SEQUENTIAL.AFP_A2S_FILE.AFP_SOLO_NAME":
                    return Common.StringToField(rdrAFP_A2S_FILE.GetString("AFP_SOLO_NAME").PadRight(75, ' '));

                case "SEQUENTIAL.AFP_A2S_FILE.DOC_AFP_PAYM_SOLO":
                    return Common.StringToField(rdrAFP_A2S_FILE.GetString("DOC_AFP_PAYM_SOLO").PadRight(6, ' '));

                case "X_PAY_PERCENTAGE":
                    return Common.StringToField(X_PAY_PERCENTAGE().PadRight(5, ' '));

                case "X_CONVERSION_AMT":
                    return X_CONVERSION_AMT().ToString().PadLeft(11, ' ');

                case "X_SUBMISSION_AMT":
                    return X_SUBMISSION_AMT().ToString().PadLeft(11, ' ');

                case "X_DOC_COUNT":
                    return X_DOC_COUNT().ToString().PadLeft(6, ' ');

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_AFP_A2S_FILE();

                while (rdrAFP_A2S_FILE.Read())
                {
                    Link_F074_AFP_GROUP_MSTR();
                    while (rdrF074_AFP_GROUP_MSTR.Read())
                    {
                        WriteData();
                    }
                    rdrF074_AFP_GROUP_MSTR.Close();
                }
                rdrAFP_A2S_FILE.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrAFP_A2S_FILE != null))
            {
                rdrAFP_A2S_FILE.Close();
                rdrAFP_A2S_FILE = null;
            }
            if ((rdrF074_AFP_GROUP_MSTR != null))
            {
                rdrF074_AFP_GROUP_MSTR.Close();
                rdrF074_AFP_GROUP_MSTR = null;
            }
        }


        #endregion

        #endregion
    }
}
