#region "Screen Comments"

// #> program-id.     r124b_mp.qzs
// ********************************************************************
// IF YOU MODIFY THIS PROGRAM ALSO MODIFY the year end pgm ????
// ********************************************************************
// ((C)) Dyad Technologies
// PURPOSE: Prdecimal the STATEMENT OF EARNINGS for the physician
// for the  * MANUAL PAYMENTS(`mp`) *   payment subsystem
// PHASE II - READ SUBFILE AND CREATE ACTUAL STATEMENT
// MODIFICATION HISTORY
// DATE   WHO  DESCRIPTION
// 00/nov/13 B.E. - cloned from r124b_rma.qzs to create this `mp` statement
// 00/nov/15 B.E. - moved x-date-title  from r124a into this pgm so it could
// be customized for each clinic
// 00/sep/02 B.E. - removed `from November` message from YTD column
// 06/jan/17 b.e. - added x-parm-portal to indicate if printing the regular
// prdecimal version of report or generating the portal upload
// file in which case include doctor id/dept on prdecimal lines
// 07/mar/26 b.e.  - prdecimal the `privacy masked` bank account now created in 
// r124a.qzs so that the full bank account nbr is not visible
// 07/sep/04 M.C.  - add new defined item x-new-parm and x-eol-doc-nbr for
// portal (DOC or DEP)
// 07/sep/25 b.e.  - portal DEP run should ignore any dept 14,15 and 31 doctors
// because there is not manager for that dept.
// 07/sep/26 b.e.  - form feed at end of page wasn`t working - noticed when
// manager PDF was created with multi-page doc report. Added
// x-ff-pdf to last line of page to get FF right.
// 08/nov/18 M.C.  - Yasemin requested to take out the messages (x-msg2c/d/e/f)
// on the statement
// 11/Apr/28 MC1   - remove `of Hamilton` in company name and  
// centre for company name in x-title-0
// 11/May/03 MC2   - access to f070 and f123 to get company name
// - modify x-title-0 to pick up company name instead of hardcode
// 13/Jul/09 MC3   - change from Mary Brownridge to Helena Vecera and extension 20397
// 14/Dec/01 MC4   - change from Helena Vecera   to Rizwan Khan   and extension 23350
// 15/Aug/27 MC5   - change from Rizwan Khan back to Helena Vecera, from extension 23350 to 20397
// 16/Mar/30 MC6   - change from Helena Vecera   to Nenita Hernandez  and extension 23350
// 16/Oct/20 MC7   - Yasemin requests to add Nenita`s email to be the same as 101c
// set page width 200 length 0
// 2011/05/03 - MC2
// access *r124a                                               

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
    public class R124B_MP_31 : BaseRDLClass
    {
        #region " Renaissance Declarations (Variables, DataReaders, Parameters and Use Files) "

        protected const string REPORT_NAME = "R124B_MP_31";
        protected const bool REPORT_HAS_PARAMETERS = true;

        // Data Helpers.
        private Reader rdrR124A = new Reader();
        private Reader rdrF070_DEPT_MSTR = new Reader();
        private Reader rdrF123_COMPANY_MSTR = new Reader();

        //#CORE_BEGIN_INCLUDE: PRINTER_CODES"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 2017-07-24 9:15:32 PM

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
                //strReturnValue = QDesign.Substring(QDesign.Characters(X_LF_NUM()), 1, 1);
                strReturnValue = QDesign.Characters(X_LF_NUM());
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
                //strReturnValue = QDesign.Substring(QDesign.Characters(X_CR_NUM()), 1, 1);
                strReturnValue = QDesign.Characters(X_CR_NUM());
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

                Sort = "DOC_DEPT ASC, DOC_NBR ASC, COMP_CODE_GROUP ASC, PROCESS_SEQ ASC";

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

        private void Access_R124A()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DOC_DEPT, ");
            strSQL.Append("COMP_CODE, ");
            strSQL.Append("DOC_NBR, ");
            strSQL.Append("COMP_CODE_GROUP, ");
            strSQL.Append("PROCESS_SEQ, ");
            strSQL.Append("X_COUNT_STATUS, ");
            strSQL.Append("X_COUNT_INCREQ, ");
            strSQL.Append("X_INCREQ, ");
            strSQL.Append("X_INCTAR, ");
            strSQL.Append("X_COUNT_INCREQ_STATUS, ");
            strSQL.Append("FIRST_EP_NBR_OF_CAL_YR, ");
            strSQL.Append("LAST_EP_NBR_OF_CAL_YR, ");
            strSQL.Append("X_YTDCEA_POS_PRT, ");
            strSQL.Append("X_YTDCEA_VAL_PRT, ");
            strSQL.Append("X_CEICEA_POS_PRT, ");
            strSQL.Append("X_CEICEA_VAL_PRT, ");
            strSQL.Append("X_YTDCEX_POS_PRT, ");
            strSQL.Append("X_YTDCEX_VAL_PRT, ");
            strSQL.Append("X_YTDREQ_POS_PRT, ");
            strSQL.Append("X_YTDREQ_VAL_PRT, ");
            strSQL.Append("X_CEIREQ_POS_PRT, ");
            strSQL.Append("X_CEIREQ_VAL_PRT, ");
            strSQL.Append("X_YTDTAR_POS_PRT, ");
            strSQL.Append("X_YTDTAR_VAL_PRT, ");
            strSQL.Append("X_DOC_ID_INFO, ");
            strSQL.Append("X_DEPT_NAME, ");
            strSQL.Append("X_DEPOSIT, ");
            strSQL.Append("X_BANK, ");
            strSQL.Append("X_DEPOSIT_DATE, ");
            strSQL.Append("X_BRANCH, ");
            strSQL.Append("X_BANK_ACCOUNT_PRIVACY_MASKED, ");
            strSQL.Append("X_PED, ");
            strSQL.Append("X_LINE_TEXT ");
            strSQL.Append("FROM TEMPORARYDATA.R124A ");

            strSQL.Append(Choose());

            rdrR124A.GetDataTable = TextHelper.ExecuteDataTable(strSQL.ToString(), ReportFunctions.m_strFlatFilePath, ReportFunctions.TextFiles);

            strSQL = null;
        }

        private void Link_F070_DEPT_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("DEPT_NBR, ");
            strSQL.Append("DEPT_COMPANY ");
            strSQL.Append("FROM [101C].INDEXED.F070_DEPT_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("DEPT_NBR = ").Append(rdrR124A.GetNumber("DOC_DEPT"));

            rdrF070_DEPT_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

            strSQL = null;
        }

        private void Link_F123_COMPANY_MSTR()
        {
            StringBuilder strSQL = new StringBuilder(string.Empty);

            strSQL.Append("SELECT ");
            strSQL.Append("COMPANY_NBR, ");
            strSQL.Append("COMPANY_NAME ");
            strSQL.Append("FROM [101C].INDEXED.F123_COMPANY_MSTR ");
            strSQL.Append("WHERE ");
            strSQL.Append("COMPANY_NBR = ").Append(rdrF070_DEPT_MSTR.GetNumber("DEPT_COMPANY"));

            rdrF123_COMPANY_MSTR.GetOptionalTable = SqlHelper.ExecuteDataTable(m_cnnQUERY, CommandType.Text, strSQL.ToString());

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

        public override bool SelectIf()
        {
            bool blnSelected = false;

            if (QDesign.NULL(rdrR124A.GetString("COMP_CODE")) != "INCEXP" & QDesign.NULL(rdrR124A.GetString("COMP_CODE")) != "PAYPOT"
                && (X_NEW_PARM() == "DOC" && rdrR124A.GetNumber("DOC_DEPT") == 31))
            {
                blnSelected = true;
            }

            return blnSelected;
        }

        #endregion

        #region " DEFINES "

        private string X_PARM_PORTAL()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.NULL(ReportFunctions.astrScreenParameters[0].ToString());
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_NEW_PARM()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = QDesign.NULL(ReportFunctions.astrScreenParameters[1].ToString());
                // Prompt String: "Enter  DOC   or   DEP  : " _
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_EOL_DOC_NBR()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(X_NEW_PARM()) == "DOC")
                {
                    strReturnValue = rdrR124A.GetString("DOC_NBR");
                }
                else if (QDesign.NULL(X_NEW_PARM()) == "DEP")
                {
                    strReturnValue = "Z" + QDesign.ASCII(rdrR124A.GetNumber("DOC_DEPT"), 2);
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_PORTAL_FIELDS()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(X_PARM_PORTAL()) == "PORTAL")
                {
                    strReturnValue = "~" + X_EOL_DOC_NBR() + QDesign.Substring(QDesign.ASCII(rdrR124A.GetNumber("DOC_DEPT"), 2), 1, 2) + "~";
                }
                else
                {
                    strReturnValue = "";
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string HP_SET_TOP_MARGIN()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = HPIII_SET_MARGIN_TOP_PART1() + "2" + HPIII_SET_MARGIN_TOP_PART2();
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string HPIII_INIT_PAGE_CODES()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = HPIII_FONT_SYMBOL_ASCII().TrimEnd() + HPIII_LINES_PER_INCH().TrimEnd() + HPIII_FONT_SPACING_PROP().TrimEnd() + HPIII_FONT_HEIGHT_10().TrimEnd() + HPIII_FONT_UPRIGHT().TrimEnd() + HPIII_MEDIUM().TrimEnd() + HPIII_CGTIMES().TrimEnd() + HP_SET_TOP_MARGIN();
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_COMP_CODE_GROUP_DESC()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(rdrR124A.GetString("COMP_CODE_GROUP")) == "A")
                {
                    strReturnValue = HPIII_FONT_HEIGHT_10() + HPIII_BOLD() + "PAYMENTS" + HPIII_FONT_HEIGHT_10() + HPIII_MEDIUM();
                }
                else if (QDesign.NULL(rdrR124A.GetString("COMP_CODE_GROUP")) == "C")
                {
                    strReturnValue = HPIII_FONT_HEIGHT_10() + HPIII_BOLD() + "EXPENSES" + HPIII_FONT_HEIGHT_10() + HPIII_MEDIUM();
                }
                else if (QDesign.NULL(rdrR124A.GetString("COMP_CODE_GROUP")) == "F")
                {
                    strReturnValue = HPIII_FONT_HEIGHT_10() + HPIII_BOLD() + "CLINICAL CEILING PAYMENT" + HPIII_FONT_HEIGHT_10() + HPIII_MEDIUM();
                }
                else if (QDesign.NULL(rdrR124A.GetString("COMP_CODE_GROUP")) == "G")
                {
                    strReturnValue = HPIII_FONT_HEIGHT_10() + HPIII_BOLD() + "DEDUCTIONS" + HPIII_FONT_HEIGHT_10() + HPIII_MEDIUM();
                }
                else if (QDesign.NULL(rdrR124A.GetString("COMP_CODE_GROUP")) == "J")
                {
                    strReturnValue = HPIII_FONT_HEIGHT_10() + HPIII_BOLD() + "CURRENT STATUS" + HPIII_FONT_HEIGHT_10() + HPIII_MEDIUM();
                }
                else if (QDesign.NULL(rdrR124A.GetString("COMP_CODE_GROUP")) == "B" | QDesign.NULL(rdrR124A.GetString("COMP_CODE_GROUP")) == "D" | QDesign.NULL(rdrR124A.GetString("COMP_CODE_GROUP")) == "E" | QDesign.NULL(rdrR124A.GetString("COMP_CODE_GROUP")) == "H" | QDesign.NULL(rdrR124A.GetString("COMP_CODE_GROUP")) == "I" | QDesign.NULL(rdrR124A.GetString("COMP_CODE_GROUP")) == "K" | QDesign.NULL(rdrR124A.GetString("COMP_CODE_GROUP")) == "L" | QDesign.NULL(rdrR124A.GetString("COMP_CODE_GROUP")) == "M" | QDesign.NULL(rdrR124A.GetString("COMP_CODE_GROUP")) == "N")
                {
                    strReturnValue = " ";
                }
                else
                {
                    strReturnValue = "?";
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private decimal X_COUNT_DIFF()
        {
            decimal decReturnValue = 0;

            try
            {
                decReturnValue = (rdrR124A.GetNumber("X_COUNT_STATUS") - rdrR124A.GetNumber("X_COUNT_INCREQ"));
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_INCREQ_OFFSET()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(X_COUNT_DIFF()) > QDesign.NULL(1d) & QDesign.NULL(rdrR124A.GetNumber("X_INCREQ")) != QDesign.NULL(0d))
                {
                    decReturnValue = X_COUNT_DIFF() + 5;
                }
                else if (QDesign.NULL(X_COUNT_DIFF()) == QDesign.NULL(1d) & QDesign.NULL(rdrR124A.GetNumber("X_INCREQ")) != QDesign.NULL(0d))
                {
                    decReturnValue = X_COUNT_DIFF() + 4;
                }
                else if (QDesign.NULL(rdrR124A.GetNumber("X_INCREQ")) != QDesign.NULL(0d))
                {
                    decReturnValue = X_COUNT_DIFF() + 3;
                }
                else if (QDesign.NULL(X_COUNT_DIFF()) > QDesign.NULL(1d) & QDesign.NULL(rdrR124A.GetNumber("X_INCTAR")) != QDesign.NULL(0d))
                {
                    decReturnValue = X_COUNT_DIFF() + 2;
                }
                else if (QDesign.NULL(X_COUNT_DIFF()) == QDesign.NULL(1d))
                {
                    decReturnValue = X_COUNT_DIFF() + 1;
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private decimal X_STATUS_OFFSET()
        {
            decimal decReturnValue = 0;

            try
            {
                if (QDesign.NULL(X_COUNT_DIFF()) > QDesign.NULL(1d) & QDesign.NULL(rdrR124A.GetNumber("X_INCREQ")) != QDesign.NULL(0d))
                {
                    decReturnValue = (X_COUNT_DIFF() + 2) * 80;
                }
                else if (QDesign.NULL(X_COUNT_DIFF()) == QDesign.NULL(1d) & QDesign.NULL(rdrR124A.GetNumber("X_INCREQ")) != QDesign.NULL(0d))
                {
                    decReturnValue = (X_COUNT_DIFF() + Convert.ToDecimal(1.75)) * 80;
                }
                else if (QDesign.NULL(rdrR124A.GetNumber("X_INCREQ")) != QDesign.NULL(0d))
                {
                    decReturnValue = (X_COUNT_DIFF() + Convert.ToDecimal(1.5)) * 80;
                }
                else
                {
                    decReturnValue = (X_COUNT_DIFF() + Convert.ToDecimal(0.25)) * 80;
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return decReturnValue;
        }
        private string X_SHADING_CTRL_CODES_A()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&a13R" + X_ESC() + "&a20C" + X_ESC() + "*c1800A" + X_ESC() + "*c300B" + X_ESC() + "*c20G" + X_ESC() + "*c2P" + X_ESC() + "&a0C" + X_ESC() + "&a0R";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_SHADING_CTRL_CODES_B()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(rdrR124A.GetNumber("X_COUNT_INCREQ_STATUS")) == QDesign.NULL(0d))
                {
                    strReturnValue = " ";
                }
                else
                {
                    strReturnValue = X_ESC() + "&a-" + QDesign.ASCII(X_INCREQ_OFFSET()) + "R" + X_ESC() + "&a0C" + X_ESC() + "*c2000A" + X_ESC() + "*c" + QDesign.ASCII(X_STATUS_OFFSET()) + "B" + X_ESC() + "*c20G" + X_ESC() + "*c2P" + X_ESC() + "&a+" + QDesign.ASCII(X_INCREQ_OFFSET()) + "R";
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_COMP_CODE_GROUP_DESC_CTRL()
        {
            string strReturnValue = string.Empty;

            try
            {
                if (QDesign.NULL(rdrR124A.GetString("COMP_CODE_GROUP")) == "B" | QDesign.NULL(rdrR124A.GetString("COMP_CODE_GROUP")) == "D" | QDesign.NULL(rdrR124A.GetString("COMP_CODE_GROUP")) == "H")
                {
                    strReturnValue = X_ESC() + "&a-1R";
                }
                else if (QDesign.NULL(rdrR124A.GetString("COMP_CODE_GROUP")) == "E" | QDesign.NULL(rdrR124A.GetString("COMP_CODE_GROUP")) == "I" | QDesign.NULL(rdrR124A.GetString("COMP_CODE_GROUP")) == "K" | QDesign.NULL(rdrR124A.GetString("COMP_CODE_GROUP")) == "L")
                {
                    strReturnValue = " ";
                }
                else if (QDesign.NULL(rdrR124A.GetString("COMP_CODE_GROUP")) == "M" | QDesign.NULL(rdrR124A.GetString("COMP_CODE_GROUP")) == "N")
                {
                    strReturnValue = X_LF() + X_LF() + X_CR();
                }
                else
                {
                    strReturnValue = X_LF() + X_CR();
                }
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_TITLE_0()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = HPIII_FONT_HEIGHT_16() + HPIII_BOLD() + QDesign.Center(rdrF123_COMPANY_MSTR.GetString("COMPANY_NAME")) + HPIII_FONT_HEIGHT_10() + HPIII_MEDIUM();
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_TITLE_1()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = HPIII_FONT_HEIGHT_14() + HPIII_BOLD() + "STATEMENT OF" + HPIII_FONT_HEIGHT_10() + HPIII_MEDIUM() + X_ESC() + "&a+80C";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_TITLE_1B()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = HPIII_FONT_HEIGHT_18() + HPIII_BOLD() + "MISCELLANEOUS PAYMENTS" + HPIII_FONT_HEIGHT_10() + HPIII_MEDIUM() + X_ESC() + "&a+80C";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_DATE_TITLE()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = "For the Fiscal Period July 1, " + QDesign.Substring(QDesign.ASCII(rdrR124A.GetNumber("FIRST_EP_NBR_OF_CAL_YR"), 6), 1, 4) + " to June 30, " + QDesign.Substring(QDesign.ASCII(rdrR124A.GetNumber("LAST_EP_NBR_OF_CAL_YR"), 6), 1, 4);
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_TITLE_2()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = HPIII_FONT_HEIGHT_12() + HPIII_BOLD() + X_DATE_TITLE() + HPIII_FONT_HEIGHT_10() + HPIII_MEDIUM();
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_MSG0A()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = HPIII_BOLD() + "The 4.8% holdback shows as a single total on your monthly Revenue Analysis (R051CA) report.";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_MSG0B()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = "Revenue (at 100%) reflects the holdback.";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_MSG2A()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = HPIII_BOLD() + "Rejections for Health card numbers & version codes are up to 1800/month - " + HPIII_FONT_ITALIC() + "an increase of 100%." + HPIII_FONT_UPRIGHT();
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_MSG2B()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = HPIII_BOLD() + " Please have your office obtain the current information with every visit." + HPIII_FONT_HEIGHT_10() + HPIII_CGTIMES() + HPIII_MEDIUM();
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_MSG2C()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = HPIII_BOLD() + "The payment shown above may include conversion funding amounts related to" + HPIII_FONT_HEIGHT_10() + HPIII_CGTIMES() + HPIII_MEDIUM();
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_MSG2D()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = HPIII_BOLD() + "the Hamilton wide Alternate Funding Plan.  Please check your remittance  " + HPIII_FONT_HEIGHT_10() + HPIII_CGTIMES() + HPIII_MEDIUM();
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_MSG2E()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = HPIII_BOLD() + "advice to ensure the payment shown above agrees with the amount shown as " + HPIII_FONT_HEIGHT_10() + HPIII_CGTIMES() + HPIII_MEDIUM();
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_MSG2F()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = HPIII_BOLD() + "`Monthly AHSC AFP Redirection`." + HPIII_FONT_HEIGHT_10() + HPIII_CGTIMES() + HPIII_MEDIUM();
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_MSG3()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = " ";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_MSG_LAST()
        {
            string strReturnValue = string.Empty;

            try
            {
                //strReturnValue = "For assistance, call " + HPIII_BOLD() + HPIII_FONT_ITALIC() + "  Nenita Hernandez" + HPIII_FONT_UPRIGHT() + HPIII_MEDIUM() + HPIII_CGTIMES() + " at extension 23350, or e-mail: hernann@mcmaster.ca" + X_FF() + X_FF_PDF();
                strReturnValue = "For assistance, call " + HPIII_BOLD() + HPIII_FONT_ITALIC() + "  Nenita Hernandez" + HPIII_FONT_UPRIGHT() + HPIII_MEDIUM() + HPIII_CGTIMES() + " at extension 23350, or e-mail: hernann@mcmaster.ca~~";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_YTDCEA_POS_CTRL_CD()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&a080C" + X_ESC() + "*p-" + rdrR124A.GetString("X_YTDCEA_POS_PRT") + "X";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_YTDCEA_VAL_CTRL_CD()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = rdrR124A.GetString("X_YTDCEA_VAL_PRT") + X_ESC() + "&a095C";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_CEICEA_POS_CTRL_CD()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&a080C" + X_ESC() + "*p-" + rdrR124A.GetString("X_CEICEA_POS_PRT") + "X";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_CEICEA_VAL_CTRL_CD()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = rdrR124A.GetString("X_CEICEA_VAL_PRT") + X_ESC() + "&a095C";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_YTDCEX_POS_CTRL_CD()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&a080C" + X_ESC() + "*p-" + rdrR124A.GetString("X_YTDCEX_POS_PRT") + "X";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_YTDCEX_VAL_CTRL_CD()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = rdrR124A.GetString("X_YTDCEX_VAL_PRT") + X_ESC() + "&a095C";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_YTDREQ_POS_CTRL_CD()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&a140C" + X_ESC() + "*p-" + rdrR124A.GetString("X_YTDREQ_POS_PRT") + "X";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_YTDREQ_VAL_CTRL_CD()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = rdrR124A.GetString("X_YTDREQ_VAL_PRT");
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_CEIREQ_POS_CTRL_CD()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&a140C" + X_ESC() + "*p-" + rdrR124A.GetString("X_CEIREQ_POS_PRT") + "X";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_CEIREQ_VAL_CTRL_CD()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = rdrR124A.GetString("X_CEIREQ_VAL_PRT");
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_YTDTAR_POS_CTRL_CD()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&a140C" + X_ESC() + "*p-" + rdrR124A.GetString("X_YTDTAR_POS_PRT") + "X";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_YTDTAR_VAL_CTRL_CD()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = rdrR124A.GetString("X_YTDTAR_VAL_PRT");
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_OFFSET_BANK_LIT()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&a120C";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string X_OFFSET_BANK_VAL()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "&a140C";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string XREPORTINITIALIZATIONCODESLINE1()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = X_ESC() + "%-12345X@PJL COMMENT Werx4Ms rev 5.1.3.49";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string XREPORTINITIALIZATIONCODESLINE2()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = "@PJL INITIALIZE";
            }

            catch (Exception ex)
            {
                // Write the exception to the log file.
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }

            return strReturnValue;
        }
        private string XREPORTINITIALIZATIONCODESLINE3()
        {
            string strReturnValue = string.Empty;

            try
            {
                strReturnValue = "@PJL  ENTER LANGUAGE=PCL";
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
                AddControl(ReportSection.INITIAL_HEADING, "XREPORTINITIALIZATIONCODESLINE1", DataTypes.Character, 80);
                AddControl(ReportSection.INITIAL_HEADING, "X_PORTAL_FIELDS", DataTypes.Character, 7);
                AddControl(ReportSection.INITIAL_HEADING, "XREPORTINITIALIZATIONCODESLINE2", DataTypes.Character, 80);
                AddControl(ReportSection.INITIAL_HEADING, "XREPORTINITIALIZATIONCODESLINE3", DataTypes.Character, 80);
                AddControl(ReportSection.HEADING_AT, "HPIII_INIT_PAGE_CODES", DataTypes.Character, 198);
                AddControl(ReportSection.HEADING_AT, "X_SHADING_CTRL_CODES_A", DataTypes.Character, 80);
                AddControl(ReportSection.HEADING_AT, "X_TITLE_0", DataTypes.Character, 90);
                AddControl(ReportSection.HEADING_AT, "X_LINE_CTRL", DataTypes.Character, 2);
                AddControl(ReportSection.HEADING_AT, "X_TITLE_1", DataTypes.Character, 90);
                AddControl(ReportSection.HEADING_AT, "HPIII_MEDIUM", DataTypes.Character, 5);
                AddControl(ReportSection.HEADING_AT, "X_TITLE_1B", DataTypes.Character, 80);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.R124A.X_DOC_ID_INFO", DataTypes.Character, 50);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.R124A.X_DEPT_NAME", DataTypes.Character, 30);
                AddControl(ReportSection.HEADING_AT, "HPIII_BOLD", DataTypes.Character, 5);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.R124A.X_DEPOSIT", DataTypes.Numeric, 8);
                AddControl(ReportSection.HEADING_AT, "X_OFFSET_BANK_LIT", DataTypes.Character, 7);
                AddControl(ReportSection.HEADING_AT, "X_OFFSET_BANK_VAL", DataTypes.Character, 7);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.R124A.X_BANK", DataTypes.Character, 30);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.R124A.X_DEPOSIT_DATE", DataTypes.Numeric, 8);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.R124A.X_BRANCH", DataTypes.Character, 30);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.R124A.X_BANK_ACCOUNT_PRIVACY_MASKED", DataTypes.Character, 12);
                AddControl(ReportSection.HEADING_AT, "X_TITLE_2", DataTypes.Character, 90);
                AddControl(ReportSection.HEADING_AT, "TEMPORARYDATA.R124A.X_PED", DataTypes.Numeric, 8);
                AddControl(ReportSection.HEADING_AT, "X_COMP_CODE_GROUP_DESC_CTRL", DataTypes.Character, 7);
                AddControl(ReportSection.HEADING_AT, "X_COMP_CODE_GROUP_DESC", DataTypes.Character, 100);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R124A.X_LINE_TEXT", DataTypes.Character, 190);
                AddControl(ReportSection.FOOTING_AT, "X_SHADING_CTRL_CODES_B", DataTypes.Character, 80);
                AddControl(ReportSection.FOOTING_AT, "X_MSG_LAST", DataTypes.Character, 160);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R124A.DOC_DEPT", DataTypes.Numeric, 2);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R124A.DOC_NBR", DataTypes.Character, 3);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R124A.COMP_CODE_GROUP", DataTypes.Character, 1);
                AddControl(ReportSection.REPORT, "TEMPORARYDATA.R124A.PROCESS_SEQ", DataTypes.Numeric, 2);
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
        //# Do not delete, modify or move it.  Updated: 2017-07-24 9:15:33 PM

        public override string ReturnControlValue(string strControl, int intSize)
        {
            switch (strControl)
            {
                case "XREPORTINITIALIZATIONCODESLINE1":
                    return Common.StringToField(XREPORTINITIALIZATIONCODESLINE1(), intSize);

                case "X_PORTAL_FIELDS":
                    return Common.StringToField(X_PORTAL_FIELDS(), intSize);

                case "XREPORTINITIALIZATIONCODESLINE2":
                    return Common.StringToField(XREPORTINITIALIZATIONCODESLINE2(), intSize);

                case "XREPORTINITIALIZATIONCODESLINE3":
                    return Common.StringToField(XREPORTINITIALIZATIONCODESLINE3(), intSize);

                case "HPIII_INIT_PAGE_CODES":
                    return Common.StringToField(HPIII_INIT_PAGE_CODES(), intSize);

                case "X_SHADING_CTRL_CODES_A":
                    return Common.StringToField(X_SHADING_CTRL_CODES_A(), intSize);

                case "X_TITLE_0":
                    return Common.StringToField(X_TITLE_0(), intSize);

                case "X_LINE_CTRL":
                    return Common.StringToField(X_LINE_CTRL(), intSize);

                case "X_TITLE_1":
                    return Common.StringToField(X_TITLE_1(), intSize);

                case "HPIII_MEDIUM":
                    return Common.StringToField(HPIII_MEDIUM(), intSize);

                case "X_TITLE_1B":
                    return Common.StringToField(X_TITLE_1B(), intSize);

                case "TEMPORARYDATA.R124A.X_DOC_ID_INFO":
                    return Common.StringToField(rdrR124A.GetString("X_DOC_ID_INFO"));

                case "TEMPORARYDATA.R124A.X_DEPT_NAME":
                    return Common.StringToField(rdrR124A.GetString("X_DEPT_NAME"));

                case "HPIII_BOLD":
                    return Common.StringToField(HPIII_BOLD(), intSize);

                case "TEMPORARYDATA.R124A.X_DEPOSIT":
                    return rdrR124A.GetNumber("X_DEPOSIT").ToString();

                case "X_OFFSET_BANK_LIT":
                    return Common.StringToField(X_OFFSET_BANK_LIT(), intSize);

                case "X_OFFSET_BANK_VAL":
                    return Common.StringToField(X_OFFSET_BANK_VAL(), intSize);

                case "TEMPORARYDATA.R124A.X_BANK":
                    return Common.StringToField(rdrR124A.GetString("X_BANK"));

                case "TEMPORARYDATA.R124A.X_DEPOSIT_DATE":
                    return rdrR124A.GetNumber("X_DEPOSIT_DATE").ToString();

                case "TEMPORARYDATA.R124A.X_BRANCH":
                    return Common.StringToField(rdrR124A.GetString("X_BRANCH"));

                case "TEMPORARYDATA.R124A.X_BANK_ACCOUNT_PRIVACY_MASKED":
                    return Common.StringToField(rdrR124A.GetString("X_BANK_ACCOUNT_PRIVACY_MASKED"));

                case "X_TITLE_2":
                    return Common.StringToField(X_TITLE_2(), intSize);

                case "TEMPORARYDATA.R124A.X_PED":
                    return rdrR124A.GetNumber("X_PED").ToString();

                case "X_COMP_CODE_GROUP_DESC_CTRL":
                    return Common.StringToField(X_COMP_CODE_GROUP_DESC_CTRL(), intSize);

                case "X_COMP_CODE_GROUP_DESC":
                    return Common.StringToField(X_COMP_CODE_GROUP_DESC(), intSize);

                case "TEMPORARYDATA.R124A.X_LINE_TEXT":
                    return Common.StringToField(rdrR124A.GetString("X_LINE_TEXT"));

                case "X_SHADING_CTRL_CODES_B":
                    return Common.StringToField(X_SHADING_CTRL_CODES_B(), intSize);

                case "X_MSG_LAST":
                    return Common.StringToField(X_MSG_LAST(), intSize);

                case "TEMPORARYDATA.R124A.DOC_DEPT":
                    return rdrR124A.GetNumber("DOC_DEPT").ToString();

                case "TEMPORARYDATA.R124A.DOC_NBR":
                    return Common.StringToField(rdrR124A.GetString("DOC_NBR"));

                case "TEMPORARYDATA.R124A.COMP_CODE_GROUP":
                    return Common.StringToField(rdrR124A.GetString("COMP_CODE_GROUP"));

                case "TEMPORARYDATA.R124A.PROCESS_SEQ":
                    return rdrR124A.GetNumber("PROCESS_SEQ").ToString();

                default:
                    return string.Empty;
            }
        }

        public override void AccessData()
        {
            try
            {
                Access_R124A();

                while (rdrR124A.Read())
                {
                    Link_F070_DEPT_MSTR();
                    while (rdrF070_DEPT_MSTR.Read())
                    {
                        Link_F123_COMPANY_MSTR();
                        while ((rdrF123_COMPANY_MSTR.Read()))
                        {
                            WriteData();
                        }
                        rdrF123_COMPANY_MSTR.Close();
                    }
                    rdrF070_DEPT_MSTR.Close();
                }
                rdrR124A.Close();

            }

            catch (Exception ex)
            {
                ReportFunctions.RecordReportError(ReportFunctions.strReportLogPath, ex);
            }
        }

        public override void CloseReaders()
        {
            if ((rdrR124A != null))
            {
                rdrR124A.Close();
                rdrR124A = null;
            }
            if ((rdrF070_DEPT_MSTR != null))
            {
                rdrF070_DEPT_MSTR.Close();
                rdrF070_DEPT_MSTR = null;
            }
            if ((rdrF123_COMPANY_MSTR != null))
            {
                rdrF123_COMPANY_MSTR.Close();
                rdrF123_COMPANY_MSTR = null;
            }
        }


        #endregion

        #endregion
    }
}