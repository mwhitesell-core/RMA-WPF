
#region "Screen Comments"

// ---------------------------------------------------------------;
// ;
// SYSTEM;       Holiday Property Bond                         ;
// ;
// PROGRAM;      BOOK0100                                      ;
// ;
// TASK;         ACCEPTS PARAMETERS FOR PROPERTY SEARCH        ;
// ;
// SCREENS:                                                    ;
// CALLING:      BOOK0200    PROPERTY AVAILABILITY DISPLAY     ;
// ;
// ---------------------------------------------------------------;
// F      ALLOW INPUT OF COMPLETE PROPERTY CODE                 ;
// ---------------------------------------------------------------;
// 07/11/90 - PASSES T-INDEX-KEY TO BOOK0200 , NOT THE
// DEFINED ITEM D-PROPERTY-TYPE.
// ----------------------------------------------------------------
// 30/08/95 - RECEIVE USER-SEC-FILE FROM IVST0000, PASS TO BOOK0200.
// --------------------------------------------------------------------
// 12/09/95 - NEW FIELD T-SHOW-ALL. PASSED TO BOOK0200 AND IS USED TO
// DETERMINE WHETHER TO ALL PROPERTIES OR JUST FREE ONES.
// --------------------------------------------------------------------
// 01/08/96 - remove start/end dates from screen
// --------------------------------------------------------------------
// 21/05/97 - allow start/end dates and location to be changed before
// re-calling BOOK020.
// Call BOOK0200 automatically after re-entering dates
// --------------------------------------------------------------------
// 01/07/97 - Removed Subscreen BOOK0200
// Calling this screen from here was causing double-bookings if the
// operator changed the year. This was because T-INDEX-KEY was not
// being reset to D-INDEX-KEY.
// --------------------------------------------------------------------
// 11/08/97 - Don`t allow user to enter  BH  (BL is Blore Hall)
// --------------------------------------------------------------------
// 09/09/97 - Add LOCN-BK-COMMENTS to screen.
// --------------------------------------------------------------------
// 30/10/97 - INFO if within Locations ON-REQUEST-DAYS
// --------------------------------------------------------------------
// 26/08/98 - Dont allow entry of  @  anywhere in property-id
// --------------------------------------------------------------------
// 12/03/03 - Warn user if they enter in a past Year
// --------------------------------------------------------------------
// 17/11/03 - t-property-type, removed REQUIRED and changed message
// to    . (I don`t actually know why the message was
// being displayed, as it isn`t on the live system!)
// Now the user can simply skip over this field.
// --------------------------------------------------------------------
// 24.01.05 - stop non SHH sites being booked under investor 999SH
// --------------------------------------------------------------------
// 08.02.05 - Allow IRE  sites to be booked under investor 999SH
// --------------------------------------------------------------------
// 04.03.05 - Ensure SHHL sites are only booked using SHHL menu.
// --------------------------------------------------------------------
// 02.06.05 - Small changes to allow owner booking under 999??
// --------------------------------------------------------------------
// 01.12.06 ME  Allow SHHL properties to be booked from book0300.qks 
// (Main investor screen)
// --------------------------------------------------------------------
// 22.01.08 ME  Allow SHH to book IV, SN && JF tenency properties.
// --------------------------------------------------------------------
// 18.07.08 ME  Add check for website booking on progress.
// --------------------------------------------------------------------
// 11.09.08 ME  Check that backup.job and newweb.job are not running.
// --------------------------------------------------------------------
// 10.02.09 ME  Make sure Owners can only book their own property.
// --------------------------------------------------------------------
// 11.02.09 ME  Make provision to hold Long Term booking requests.
// ---------------------------------------------------------------------
// 28/07/09 RC  Add selection for Pets
// ---------------------------------------------------------------------
// 18/03/10 RC  Don`t INFO or WARN with RESPONSE for signonuser weblive
// to avaoid problems using QKIN for live web bookings
// ---------------------------------------------------------------------
// 25.01.12 ME  make sure Interval International (customer-type= I ) 
// can only book SHH properties.
// ---------------------------------------------------------------------

#endregion



using System;
using System.Text;
using System.Windows;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.ExceptionManagement;
using Core.Windows.UI.Core.Windows;
using Core.Windows.UI.Core.Windows.UI;
using System.Data.OracleClient;

namespace rma.Views
{

    partial class BOOK0100 : BasePage
    {

        #region " Form Designer Generated Code "





        public BOOK0100()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "BOOK0100";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = true;
            this.FindActivity = true;
            this.DeleteActivity = false;
            this.EntryActivity = true;
            this.UseAcceptProcessing = true;        

        }

        #endregion

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();
            dsrDesigner_03.Click += dsrDesigner_03_Click;
            dsrDesigner_09.Click += dsrDesigner_09_Click;
            dsrDesigner_05.Click += dsrDesigner_05_Click;
            fldT_PROPERTY_TYPE.LookupOn += fldT_PROPERTY_TYPE_LookupOn;
            fldT_YEAR.Input += fldT_YEAR_Input;
            fldT_PROPERTY_TYPE.Edit += fldT_PROPERTY_TYPE_Edit;
            fldT_AREA.Input += fldT_AREA_Input;
            fldT_AREA.Edit += fldT_AREA_Edit;
            fldT_END.Edit += fldT_END_Edit;
            fldT_YEAR.Process += fldT_YEAR_Process;
            fldT_PROPERTY_TYPE.Process += fldT_PROPERTY_TYPE_Process;
            fldT_START.Process += fldT_START_Process;
          

            Page_Load();

        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleM_INVESTORS = new OracleFileObject(this, FileTypes.Master, 0, "INDEXED", "M_INVESTORS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleUSER_SEC_FILE = new OracleFileObject(this, FileTypes.Master, 0, "INDEXED", "USER_SEC_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleLOCATIONS = new OracleFileObject(this, FileTypes.Reference, 0, "INDEXED", "LOCATIONS", "", false, false, false, 0, "m_cnnQUERY");
            fleRUN_CONTROL = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "RUN_CONTROL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            T_YEAR = new CoreCharacter("T_YEAR", 4, this, Common.cEmptyString);
            T_START = new CoreDecimal("T_START", 2, this);
            T_END = new CoreDecimal("T_END", 2, this);
            T_START_DATE = new CoreDate("T_START_DATE", this);
            T_END_DATE = new CoreDate("T_END_DATE", this);
            T_PROPERTY_TYPE = new CoreCharacter("T_PROPERTY_TYPE", 6, this, Common.cEmptyString);
            T_SPLIT_WEEKS = new CoreCharacter("T_SPLIT_WEEKS", 2, this, Common.cEmptyString);
            T_DISABLED = new CoreCharacter("T_DISABLED", 2, this, Common.cEmptyString);
            T_CHANGEOVER = new CoreCharacter("T_CHANGEOVER", 2, this, Common.cEmptyString);
            fleLOCN_BK_COMMENTS = new OracleFileObject(this, FileTypes.Designer, 0, "INDEXED", "LOCN_BK_COMMENTS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            T_START_WEEK = new CoreCharacter("T_START_WEEK", 2, this, Common.cEmptyString);
            T_END_WEEK = new CoreCharacter("T_END_WEEK", 2, this, Common.cEmptyString);
            T_LOCATION = new CoreCharacter("T_LOCATION", 2, this, Common.cEmptyString);
            T_PROP_ID = new CoreCharacter("T_PROP_ID", 4, this, Common.cEmptyString);
            T_BOOKING_NOW = new CoreCharacter("T_BOOKING_NOW", 1, this, "N");
            T_WEB_BOOKED = new CoreCharacter("T_WEB_BOOKED", 1, this, " ");
            T_PROPERTY_CODE = new CoreCharacter("T_PROPERTY_CODE", 4, this, Common.cEmptyString);
            T_AREA = new CoreCharacter("T_AREA", 4, this, Common.cEmptyString);
            T_SHOW_ALL = new CoreCharacter("T_SHOW_ALL", 1, this, "N");
            T_SPECIFIC_WEEK = new CoreCharacter("T_SPECIFIC_WEEK", 1, this, "N");
            T_BOOKED = new CoreCharacter("T_BOOKED", 1, this, "N");
            T_FIRST_TIME = new CoreCharacter("T_FIRST_TIME", 1, this, "Y");
            T_INDEX_KEY = new CoreCharacter("T_INDEX_KEY", 15, this, Common.cEmptyString);
            T_LT_INVESTOR = new CoreCharacter("T_LT_INVESTOR", 8, this, " ");
            T_PETS = new CoreCharacter("T_PETS", 1, this, " ");

            fleLOCATIONS.Access += fleLOCATIONS_Access;
            D_START_DATE.GetValue += D_START_DATE_GetValue;
            D_END_DATE.GetValue += D_END_DATE_GetValue;
            fleLOCN_BK_COMMENTS.Access += fleLOCN_BK_COMMENTS_Access;
            D_PROPERTY_TYPE.GetValue += D_PROPERTY_TYPE_GetValue;
            D_INDEX_KEY.GetValue += D_INDEX_KEY_GetValue;
            fleLOCN_BK_COMMENTS.AccessIsOptional = true;

        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleLOCATIONS.Access -= fleLOCATIONS_Access;
            D_START_DATE.GetValue -= D_START_DATE_GetValue;
            D_END_DATE.GetValue -= D_END_DATE_GetValue;
            fleLOCN_BK_COMMENTS.Access -= fleLOCN_BK_COMMENTS_Access;
            D_PROPERTY_TYPE.GetValue -= D_PROPERTY_TYPE_GetValue;
            D_INDEX_KEY.GetValue -= D_INDEX_KEY_GetValue;
            fldT_PROPERTY_TYPE.LookupOn -= fldT_PROPERTY_TYPE_LookupOn;
            fldT_YEAR.Input -= fldT_YEAR_Input;
            fldT_PROPERTY_TYPE.Edit -= fldT_PROPERTY_TYPE_Edit;
            fldT_AREA.Input -= fldT_AREA_Input;
            fldT_AREA.Edit -= fldT_AREA_Edit;
            fldT_END.Edit -= fldT_END_Edit;
            fldT_YEAR.Process -= fldT_YEAR_Process;
            fldT_PROPERTY_TYPE.Process -= fldT_PROPERTY_TYPE_Process;
            fldT_START.Process -= fldT_START_Process;

            dsrDesigner_03.Click -= dsrDesigner_03_Click;
            dsrDesigner_09.Click -= dsrDesigner_09_Click;
            dsrDesigner_05.Click -= dsrDesigner_05_Click;


        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private OracleConnection m_cnnQUERY = new OracleConnection();
        private OracleConnection m_cnnTRANS_UPDATE = new OracleConnection();
        private OracleTransaction m_trnTRANS_UPDATE;
        private OracleFileObject fleM_INVESTORS;
        private OracleFileObject fleUSER_SEC_FILE;
        private OracleFileObject fleLOCATIONS;

        private void fleLOCATIONS_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleLOCATIONS.ElementOwner("LOCATION")).Append(" = ").Append(Common.StringToField(QDesign.Substring(T_PROPERTY_TYPE.Value, 1, 2)));


                AccessClause = strText.ToString();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private OracleFileObject fleRUN_CONTROL;
        private CoreCharacter T_YEAR;
        private CoreDecimal T_START;
        private CoreDecimal T_END;
        private CoreDate T_START_DATE;
        private CoreDate T_END_DATE;
        private CoreCharacter T_PROPERTY_TYPE;
        private CoreCharacter T_SPLIT_WEEKS;
        private CoreCharacter T_DISABLED;
        private CoreCharacter T_CHANGEOVER;
        private DDecimal D_START_DATE = new DDecimal();
        private void D_START_DATE_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0m;
                if (QDesign.NULL(T_START.Value) == 1)
                {
                    CurrentValue = QDesign.NConvert(QDesign.ASCII(QDesign.NConvert(T_YEAR.Value) - 1) + "1226");
                }
                else if (QDesign.NULL(T_START.Value) == 2)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0103");
                }
                else if (QDesign.NULL(T_START.Value) == 3)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0110");
                }
                else if (QDesign.NULL(T_START.Value) == 4)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0117");
                }
                else if (QDesign.NULL(T_START.Value) == 5)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0124");
                }
                else if (QDesign.NULL(T_START.Value) == 6)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0131");
                }
                else if (QDesign.NULL(T_START.Value) == 7)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0207");
                }
                else if (QDesign.NULL(T_START.Value) == 8)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0214");
                }
                else if (QDesign.NULL(T_START.Value) == 9)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0221");
                }
                else if (QDesign.NULL(T_START.Value) == 10)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0228");
                }
                else if (QDesign.NULL(T_START.Value) == 11)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0307");
                }
                else if (QDesign.NULL(T_START.Value) == 12)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0314");
                }
                else if (QDesign.NULL(T_START.Value) == 13)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0321");
                }
                else if (QDesign.NULL(T_START.Value) == 14)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0328");
                }
                else if (QDesign.NULL(T_START.Value) == 15)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0404");
                }
                else if (QDesign.NULL(T_START.Value) == 16)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0411");
                }
                else if (QDesign.NULL(T_START.Value) == 17)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0418");
                }
                else if (QDesign.NULL(T_START.Value) == 18)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0425");
                }
                else if (QDesign.NULL(T_START.Value) == 19)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0502");
                }
                else if (QDesign.NULL(T_START.Value) == 20)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0509");
                }
                else if (QDesign.NULL(T_START.Value) == 21)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0516");
                }
                else if (QDesign.NULL(T_START.Value) == 22)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0523");
                }
                else if (QDesign.NULL(T_START.Value) == 23)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0530");
                }
                else if (QDesign.NULL(T_START.Value) == 24)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0606");
                }
                else if (QDesign.NULL(T_START.Value) == 25)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0613");
                }
                else if (QDesign.NULL(T_START.Value) == 26)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0620");
                }
                else if (QDesign.NULL(T_START.Value) == 27)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0627");
                }
                else if (QDesign.NULL(T_START.Value) == 28)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0704");
                }
                else if (QDesign.NULL(T_START.Value) == 29)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0711");
                }
                else if (QDesign.NULL(T_START.Value) == 30)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0718");
                }
                else if (QDesign.NULL(T_START.Value) == 31)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0725");
                }
                else if (QDesign.NULL(T_START.Value) == 32)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0801");
                }
                else if (QDesign.NULL(T_START.Value) == 33)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0808");
                }
                else if (QDesign.NULL(T_START.Value) == 34)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0815");
                }
                else if (QDesign.NULL(T_START.Value) == 35)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0822");
                }
                else if (QDesign.NULL(T_START.Value) == 36)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0829");
                }
                else if (QDesign.NULL(T_START.Value) == 37)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0905");
                }
                else if (QDesign.NULL(T_START.Value) == 38)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0912");
                }
                else if (QDesign.NULL(T_START.Value) == 39)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0919");
                }
                else if (QDesign.NULL(T_START.Value) == 40)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0926");
                }
                else if (QDesign.NULL(T_START.Value) == 41)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "1003");
                }
                else if (QDesign.NULL(T_START.Value) == 42)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "1010");
                }
                else if (QDesign.NULL(T_START.Value) == 43)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "1017");
                }
                else if (QDesign.NULL(T_START.Value) == 44)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "1024");
                }
                else if (QDesign.NULL(T_START.Value) == 45)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "1031");
                }
                else if (QDesign.NULL(T_START.Value) == 46)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "1107");
                }
                else if (QDesign.NULL(T_START.Value) == 47)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "1114");
                }
                else if (QDesign.NULL(T_START.Value) == 48)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "1121");
                }
                else if (QDesign.NULL(T_START.Value) == 49)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "1128");
                }
                else if (QDesign.NULL(T_START.Value) == 50)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "1205");
                }
                else if (QDesign.NULL(T_START.Value) == 51)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "1212");
                }
                else if (QDesign.NULL(T_START.Value) == 52)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "1219");
                }
                else if (QDesign.NULL(T_START.Value) == 53)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "1226");
                }

                Value = CurrentValue;

            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DDecimal D_END_DATE = new DDecimal();
        private void D_END_DATE_GetValue(ref decimal Value)
        {

            try
            {
                decimal CurrentValue = 0m;
                if (QDesign.NULL(T_END.Value) == 1)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0110");
                }
                else if (QDesign.NULL(T_END.Value) == 2)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0117");
                }
                else if (QDesign.NULL(T_END.Value) == 3)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0124");
                }
                else if (QDesign.NULL(T_END.Value) == 4)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0131");
                }
                else if (QDesign.NULL(T_END.Value) == 5)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0207");
                }
                else if (QDesign.NULL(T_END.Value) == 6)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0214");
                }
                else if (QDesign.NULL(T_END.Value) == 7)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0221");
                }
                else if (QDesign.NULL(T_END.Value) == 8)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0228");
                }
                else if (QDesign.NULL(T_END.Value) == 9)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0307");
                }
                else if (QDesign.NULL(T_END.Value) == 10)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0314");
                }
                else if (QDesign.NULL(T_END.Value) == 11)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0321");
                }
                else if (QDesign.NULL(T_END.Value) == 12)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0328");
                }
                else if (QDesign.NULL(T_END.Value) == 13)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0404");
                }
                else if (QDesign.NULL(T_END.Value) == 14)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0411");
                }
                else if (QDesign.NULL(T_END.Value) == 15)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0418");
                }
                else if (QDesign.NULL(T_END.Value) == 16)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0425");
                }
                else if (QDesign.NULL(T_END.Value) == 17)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0502");
                }
                else if (QDesign.NULL(T_END.Value) == 18)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0509");
                }
                else if (QDesign.NULL(T_END.Value) == 19)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0516");
                }
                else if (QDesign.NULL(T_END.Value) == 20)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0523");
                }
                else if (QDesign.NULL(T_END.Value) == 21)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0530");
                }
                else if (QDesign.NULL(T_END.Value) == 22)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0606");
                }
                else if (QDesign.NULL(T_END.Value) == 23)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0613");
                }
                else if (QDesign.NULL(T_END.Value) == 24)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0620");
                }
                else if (QDesign.NULL(T_END.Value) == 25)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0627");
                }
                else if (QDesign.NULL(T_END.Value) == 26)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0704");
                }
                else if (QDesign.NULL(T_END.Value) == 27)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0711");
                }
                else if (QDesign.NULL(T_END.Value) == 28)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0718");
                }
                else if (QDesign.NULL(T_END.Value) == 29)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0725");
                }
                else if (QDesign.NULL(T_END.Value) == 30)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0801");
                }
                else if (QDesign.NULL(T_END.Value) == 31)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0808");
                }
                else if (QDesign.NULL(T_END.Value) == 32)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0815");
                }
                else if (QDesign.NULL(T_END.Value) == 33)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0822");
                }
                else if (QDesign.NULL(T_END.Value) == 34)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0829");
                }
                else if (QDesign.NULL(T_END.Value) == 35)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0905");
                }
                else if (QDesign.NULL(T_END.Value) == 36)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0912");
                }
                else if (QDesign.NULL(T_END.Value) == 37)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0919");
                }
                else if (QDesign.NULL(T_END.Value) == 38)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "0926");
                }
                else if (QDesign.NULL(T_END.Value) == 39)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "1003");
                }
                else if (QDesign.NULL(T_END.Value) == 40)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "1010");
                }
                else if (QDesign.NULL(T_END.Value) == 41)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "1017");
                }
                else if (QDesign.NULL(T_END.Value) == 42)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "1024");
                }
                else if (QDesign.NULL(T_END.Value) == 43)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "1031");
                }
                else if (QDesign.NULL(T_END.Value) == 44)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "1107");
                }
                else if (QDesign.NULL(T_END.Value) == 45)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "1114");
                }
                else if (QDesign.NULL(T_END.Value) == 46)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "1121");
                }
                else if (QDesign.NULL(T_END.Value) == 47)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "1128");
                }
                else if (QDesign.NULL(T_END.Value) == 48)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "1205");
                }
                else if (QDesign.NULL(T_END.Value) == 49)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "1212");
                }
                else if (QDesign.NULL(T_END.Value) == 50)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "1219");
                }
                else if (QDesign.NULL(T_END.Value) == 51)
                {
                    CurrentValue = QDesign.NConvert(T_YEAR.Value + "1226");
                }
                else if ((QDesign.NULL(T_END.Value) == 52 || QDesign.NULL(T_END.Value) == 53))
                {
                    CurrentValue = QDesign.NConvert(QDesign.ASCII(QDesign.NConvert(T_YEAR.Value) + 1) + "0114");
                }

                Value = CurrentValue;

            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private OracleFileObject fleLOCN_BK_COMMENTS;

        private void fleLOCN_BK_COMMENTS_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleLOCN_BK_COMMENTS.ElementOwner("LOCATION")).Append(" = ").Append(Common.StringToField(QDesign.Substring(T_PROPERTY_TYPE.Value, 1, 2)));

                AccessClause = strText.ToString();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fleLOCN_BK_COMMENTS_SelectIf(ref string SelectIfClause)
        {


            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(" (    ").Append(fleLOCN_BK_COMMENTS.ElementOwner("COMM_STRT_DATE")).Append(" <=   D_END_DATE.Value)  AND ");
                strSQL.Append("    ").Append(fleLOCN_BK_COMMENTS.ElementOwner("COMM_END_DATE")).Append(" >=   D_START_DATE.Value) )");
                strSQL.Append(")");

                SelectIfClause = strSQL.ToString();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private CoreCharacter T_START_WEEK;
        private CoreCharacter T_END_WEEK;
        private CoreCharacter T_LOCATION;
        private CoreCharacter T_PROP_ID;
        private CoreCharacter T_BOOKING_NOW;
        private CoreCharacter T_WEB_BOOKED;
        private CoreCharacter T_PROPERTY_CODE;
        private CoreCharacter T_AREA;
        private CoreCharacter T_SHOW_ALL;
        private CoreCharacter T_SPECIFIC_WEEK;
        private CoreCharacter T_BOOKED;
        private CoreCharacter T_FIRST_TIME;
        private CoreCharacter T_INDEX_KEY;
        private CoreCharacter T_LT_INVESTOR;
        private CoreCharacter T_PETS;
        private DCharacter D_PROPERTY_TYPE = new DCharacter(7);
        private void D_PROPERTY_TYPE_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (QDesign.NULL(T_PROPERTY_CODE.Value) == QDesign.NULL(" "))
                {
                    CurrentValue = QDesign.Pack((QDesign.RightJustify(T_PROPERTY_TYPE.Value)) + "@");
                }
                else
                {
                    CurrentValue = T_PROPERTY_TYPE.Value + "@";
                }

                Value = CurrentValue;

            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }
        private DCharacter D_INDEX_KEY = new DCharacter(15);
        private void D_INDEX_KEY_GetValue(ref string Value)
        {

            try
            {
                Value = T_AREA.Value + T_YEAR.Value + D_PROPERTY_TYPE.Value;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:49:31 PM

        //# No code was generated or needed for this region.

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:49:31 PM

        //# No code was generated or needed for this region.

        #endregion

        #region "Transaction Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:49:31 PM

        //#-----------------------------------------
        //# InitializeTransactionObjects Procedure.
        //#-----------------------------------------

        protected override void InitializeTransactionObjects()
        {

            try
            {
                m_cnnTRANS_UPDATE = new OracleConnection(Common.GetConnectionString());
                m_cnnTRANS_UPDATE.Open();
                m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
                m_cnnQUERY = new OracleConnection(Common.GetConnectionString());


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        //#-----------------------------------------
        //# CloseTransactionObjects Procedure.
        //#-----------------------------------------

        protected override void CloseTransactionObjects()
        {

            try
            {
                CloseFiles();

                if ((m_trnTRANS_UPDATE != null))
                    m_trnTRANS_UPDATE.Dispose();
                if ((m_cnnTRANS_UPDATE != null))
                    m_cnnTRANS_UPDATE.Close();
                if ((m_cnnTRANS_UPDATE != null))
                    m_cnnTRANS_UPDATE.Dispose();
                if ((m_cnnQUERY != null))
                    m_cnnQUERY.Close();
                if ((m_cnnQUERY != null))
                    m_cnnQUERY.Dispose();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }


        protected override void TRANS_UPDATE(TransactionMethods Method)
        {
            if (Method == TransactionMethods.Rollback)
            {
                m_trnTRANS_UPDATE.Rollback();
            }
            else
            {
                m_trnTRANS_UPDATE.Commit();
            }

            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            Initialize_TRANS_UPDATE();

        }


        private void Initialize_TRANS_UPDATE()
        {
            fleM_INVESTORS.Transaction = m_trnTRANS_UPDATE;
            fleUSER_SEC_FILE.Transaction = m_trnTRANS_UPDATE;
            fleRUN_CONTROL.Transaction = m_trnTRANS_UPDATE;
            fleLOCN_BK_COMMENTS.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:49:31 PM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
                fleLOCATIONS.Connection = m_cnnQUERY;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        //#-----------------------------------------
        //# CloseFiles Procedure.
        //#-----------------------------------------

        protected override void CloseFiles()
        {

            try
            {
                fleM_INVESTORS.Dispose();
                fleUSER_SEC_FILE.Dispose();
                fleLOCATIONS.Dispose();
                fleRUN_CONTROL.Dispose();
                fleLOCN_BK_COMMENTS.Dispose();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        #endregion
        
        #region "Display Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.

        //#-----------------------------------------
        //# DisplayFormatting Procedure
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 06/19/2013 8:55:38 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:49:31 PM
                Display(ref fldT_YEAR);
                Display(ref fldT_PROPERTY_TYPE);
                Display(ref fldT_PROPERTY_CODE);
                Display(ref fldT_AREA);
                Display(ref fldT_START);
                Display(ref fldT_END);
                Display(ref fldT_SHOW_ALL);
                Display(ref fldT_SPECIFIC_WEEK);
                Display(ref fldT_CHANGEOVER);
                Display(ref fldT_SPLIT_WEEKS);
                Display(ref fldT_DISABLED);
                Display(ref fldT_PETS);
                Display(ref fldLOCN_BK_COMMENTS_BK_COMMENT_1);
                Display(ref fldLOCN_BK_COMMENTS_BK_COMMENT_2);
                Display(ref fldLOCN_BK_COMMENTS_BK_COMMENT_3);
                //#END STANDARD PROCEDURE CONTENT

            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        #endregion

        #region "Update Validation"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.

        #endregion


        #region "RecordBuffer Events"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:49:31 PM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldT_YEAR.Bind(T_YEAR);
                fldT_PROPERTY_TYPE.Bind(T_PROPERTY_TYPE);
                fldT_PROPERTY_CODE.Bind(T_PROPERTY_CODE);
                fldT_AREA.Bind(T_AREA);
                fldT_START.Bind(T_START);
                fldT_END.Bind(T_END);
                fldT_SHOW_ALL.Bind(T_SHOW_ALL);
                fldT_SPECIFIC_WEEK.Bind(T_SPECIFIC_WEEK);
                fldT_CHANGEOVER.Bind(T_CHANGEOVER);
                fldT_SPLIT_WEEKS.Bind(T_SPLIT_WEEKS);
                fldT_DISABLED.Bind(T_DISABLED);
                fldT_PETS.Bind(T_PETS);
                fldLOCN_BK_COMMENTS_BK_COMMENT_1.Bind(fleLOCN_BK_COMMENTS);
                fldLOCN_BK_COMMENTS_BK_COMMENT_2.Bind(fleLOCN_BK_COMMENTS);
                fldLOCN_BK_COMMENTS_BK_COMMENT_3.Bind(fleLOCN_BK_COMMENTS);

            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }


        #endregion

        #region "Update Audit Tables"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  

        #endregion

        #region "Automatic Item Initialization"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.

        #endregion

        #endregion

        #region "Renaissance Architect Generated 4GL Procedures"



        private void fldT_PROPERTY_TYPE_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleLOCATIONS.ElementOwner("LOCATION")).Append(" = ").Append(Common.StringToField(QDesign.Substring(FieldText, 1, 2)));

                fleLOCATIONS.GetData(strSQL.ToString(), GetDataOptions.IsOptional);
                if (!AccessOk)
                {
                    Warning("0");
                    // " "
                }

            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }




        protected override void SaveParamsReceived()
        {

            try
            {
                SaveReceivingParams(fleM_INVESTORS, fleUSER_SEC_FILE);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }




        protected override void RetrieveParamsReceived()
        {

            try
            {
                Receiving(fleM_INVESTORS, fleUSER_SEC_FILE);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }


        #endregion

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"



        private void fldT_YEAR_Input()
        {

            try
            {

                //#CORE_BEGIN_INCLUDE: YEARCENT.USE"

                //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
                //# Do not delete, modify or move it.  Updated: 07/12/2013 1:49:31 PM

                if (2 == FieldText.Length)
                {
                    if (string.Compare(QDesign.NULL(QDesign.Substring(FieldText, 1, 2)), QDesign.NULL("69")) < 0)
                    {
                        FieldText = "20" + QDesign.Substring(FieldText, 1, 2);
                    }
                    else
                    {
                        FieldText = "19" + QDesign.Substring(FieldText, 1, 2);
                    }
                }


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        //#CORE_END_INCLUDE: YEARCENT.USE"



        private bool Internal_CHECK_WEB_BOOKING()
        {


            try
            {

                T_START_WEEK.Value = QDesign.ASCII(T_START.Value, 2);
                T_END_WEEK.Value = QDesign.ASCII(T_END.Value, 2);
                T_LOCATION.Value = QDesign.Substring(T_PROPERTY_TYPE.Value, 1, 2);
                T_PROP_ID.Value = T_PROPERTY_CODE.Value;
                T_LT_INVESTOR.Value = fleM_INVESTORS.GetStringValue("INVESTOR");

                return true;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }


        private bool Internal_CHECK_AREA()
        {


            try
            {

                if (QDesign.NULL(fleM_INVESTORS.GetStringValue("INVESTOR")) == "999SH" && QDesign.NULL(QDesign.Substring(T_AREA.Value, 1, 3)) != "SHH" && QDesign.NULL(T_AREA.Value) != "IRE" && QDesign.NULL(fleLOCATIONS.GetStringValue("LOCATION")) != "JF" && QDesign.NULL(fleLOCATIONS.GetStringValue("LOCATION")) != "SN" && QDesign.NULL(fleLOCATIONS.GetStringValue("LOCATION")) != "IV")
                {
                    ErrorMessage("52001");
                }
                if (QDesign.NULL(fleM_INVESTORS.GetStringValue("CUSTOMER_TYPE")) == "I" && QDesign.NULL(QDesign.Substring(T_AREA.Value, 1, 3)) != "SHH" && QDesign.NULL(fleLOCATIONS.GetStringValue("LOCATION")) != "BI")
                {
                    ErrorMessage("52002");
                }

                return true;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }


        private bool Internal_GET_COMMENTS()
        {


            try
            {

                // --> GET LOCN_BK_COMMENTS <--
                fleLOCN_BK_COMMENTS.GetData();
                // --> End GET LOCN_BK_COMMENTS <--
                Display(ref fldLOCN_BK_COMMENTS_BK_COMMENT_1);
                Display(ref fldLOCN_BK_COMMENTS_BK_COMMENT_2);
                Display(ref fldLOCN_BK_COMMENTS_BK_COMMENT_3);

                return true;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldT_YEAR_Process()
        {

            try
            {

                if (string.Compare(QDesign.NULL(T_YEAR.Value), QDesign.NULL(QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY)), 1, 4))) < 0)
                {
                    Information("*** This year is in the past, please correct unless you are sure!");
                    // TODO: May need to fix manually
                }
                Internal_GET_COMMENTS();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldT_PROPERTY_TYPE_Edit()
        {

            try
            {

                if (QDesign.NULL(QDesign.Substring(T_PROPERTY_TYPE.Value, 1, 2)) == "BH")
                {
                    ErrorMessage("52003");
                }
                if (QDesign.NULL(QDesign.Substring(fleM_INVESTORS.GetStringValue("INVESTOR"), 1, 3)) == "999" && QDesign.NULL(QDesign.Substring(T_PROPERTY_TYPE.Value, 1, 2)) != QDesign.NULL(QDesign.Substring(fleM_INVESTORS.GetStringValue("INVESTOR"), 4, 2)))
                {
                    ErrorMessage("52004");
                }
                if (QDesign.NULL(fleM_INVESTORS.GetStringValue("CUSTOMER_TYPE")) == "I" && QDesign.NULL(QDesign.Substring(fleLOCATIONS.GetStringValue("AREA"), 1, 3)) != "SHH" && QDesign.NULL(fleLOCATIONS.GetStringValue("LOCATION")) != "BI")
                {
                    ErrorMessage("52002");
                }


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldT_PROPERTY_TYPE_Process()
        {

            try
            {

                if (QDesign.NULL(QDesign.Substring(T_PROPERTY_TYPE.Value, 1, 2)) != QDesign.NULL(" "))
                {
                    T_AREA.Value = fleLOCATIONS.GetStringValue("AREA");
                    Display(ref fldT_AREA);
                }
                T_INDEX_KEY.Value = D_INDEX_KEY.Value;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldT_AREA_Input()
        {

            try
            {

                if (QDesign.NULL(QDesign.Substring(T_PROPERTY_TYPE.Value, 1, 2)) == QDesign.NULL("  ") && QDesign.NULL(FieldText) == QDesign.NULL(" "))
                {
                    ErrorMessage("52005");
                }


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldT_AREA_Edit()
        {

            try
            {

                Internal_CHECK_AREA();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldT_START_Process()
        {

            try
            {

                if (QDesign.NULL(fleLOCATIONS.GetDecimalValue("ON_REQUEST_DAYS")) > 0 && QDesign.NULL(UserID) != "weblive" && QDesign.NULL(D_START_DATE.Value) < QDesign.NULL((QDesign.PhDate(QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)) + fleLOCATIONS.GetDecimalValue("ON_REQUEST_DAYS") + 14))))
                {
                    Information("** Limited Freesale until\a " + QDesign.Substring(QDesign.ASCII(QDesign.PhDate(QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)) + fleLOCATIONS.GetDecimalValue("ON_REQUEST_DAYS"))), 7, 2) + "/" + QDesign.Substring(QDesign.ASCII(QDesign.PhDate(QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)) + fleLOCATIONS.GetDecimalValue("ON_REQUEST_DAYS"))), 5, 2) + "/" + QDesign.Substring(QDesign.ASCII(QDesign.PhDate(QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)) + fleLOCATIONS.GetDecimalValue("ON_REQUEST_DAYS"))), 1, 4) + "  Check individual properties");
                    // TODO: May need to fix manually
                }
                Internal_GET_COMMENTS();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldT_END_Edit()
        {

            try
            {

                if (QDesign.NULL(T_END.Value) > QDesign.NULL(T_START.Value + 5))
                {
                    ErrorMessage("52006");
                }
                if (QDesign.NULL(T_END.Value) < QDesign.NULL(T_START.Value))
                {
                    ErrorMessage("52007");
                }


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }


        protected override bool Initialize()
        {


            try
            {

                // --> GET RUN_CONTROL <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleRUN_CONTROL.ElementOwner("PROG_ID")).Append(" = ");
                m_strWhere.Append(Common.StringToField("backup.job"));

                fleRUN_CONTROL.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                // --> End GET RUN_CONTROL <--
                if (AccessOk)
                {
                    ErrorMessage("52008");
                }
                // --> GET RUN_CONTROL <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleRUN_CONTROL.ElementOwner("PROG_ID")).Append(" = ");
                m_strWhere.Append(Common.StringToField("newweb.job"));

                fleRUN_CONTROL.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                // --> End GET RUN_CONTROL <--
                if (AccessOk)
                {
                    ErrorMessage("52009");
                }

                return true;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }


        protected override bool Entry()
        {


            try
            {

                if (QDesign.NULL(T_FIRST_TIME.Value) == "Y")
                {
                    Accept(ref fldT_YEAR);
                    Accept(ref fldT_PROPERTY_TYPE);
                    T_AREA.Value = fleLOCATIONS.GetStringValue("AREA");
                    Display(ref fldT_AREA);
                    if (QDesign.NULL(T_AREA.Value) != QDesign.NULL(" "))
                    {
                        Internal_CHECK_AREA();
                    }
                    if (QDesign.NULL(T_PROPERTY_TYPE.Value) != QDesign.NULL(" "))
                    {
                        Accept(ref fldT_PROPERTY_CODE);
                    }
                    if (QDesign.NULL(T_AREA.Value) == QDesign.NULL(" "))
                    {
                        Accept(ref fldT_AREA);
                    }
                    Internal_CHECK_AREA();
                    Accept(ref fldT_START);
                    Accept(ref fldT_END);
                    if (QDesign.NULL(T_PROPERTY_CODE.Value) != QDesign.NULL(" "))
                    {
                        Internal_CHECK_WEB_BOOKING();
                    }
                    Internal_GET_COMMENTS();
                }
                else
                {
                    Accept(ref fldT_PROPERTY_CODE);
                }
                Accept(ref fldT_SHOW_ALL);
                Accept(ref fldT_SPECIFIC_WEEK);
                Accept(ref fldT_CHANGEOVER);
                Accept(ref fldT_SPLIT_WEEKS);
                Accept(ref fldT_DISABLED);
                Accept(ref fldT_PETS);
               
                // TODO: May need to fix manually
                T_INDEX_KEY.Value = D_INDEX_KEY.Value;
                object[] arrRunscreen = { fleM_INVESTORS, fleUSER_SEC_FILE, fleLOCN_BK_COMMENTS, T_SHOW_ALL, T_SPECIFIC_WEEK, T_AREA, T_YEAR, T_START,
                T_END, T_INDEX_KEY, T_PROPERTY_TYPE, T_PROPERTY_CODE, T_SPLIT_WEEKS, T_DISABLED, T_CHANGEOVER, T_BOOKED, T_PETS };
                //RunScreen(new BOOK0200(), RunScreenModes.Find, ref arrRunscreen);
                T_FIRST_TIME.Value = "N";
                if (QDesign.NULL(T_BOOKED.Value) == "Y")
                {
                    ReturnAndClose();
                    // RETURN
                }
                Display(ref fldT_YEAR);
                Display(ref fldT_START);
                Display(ref fldT_END);

                return true;


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_03_Click(object sender, System.EventArgs e)
        {

            try
            {

                Accept(ref fldT_PROPERTY_CODE);
                T_INDEX_KEY.Value = D_INDEX_KEY.Value;
               
                // TODO: May need to fix manually
                object[] arrRunscreen = { fleM_INVESTORS, fleUSER_SEC_FILE, fleLOCN_BK_COMMENTS, T_SHOW_ALL, T_SPECIFIC_WEEK, T_AREA, T_YEAR, T_START,
                T_END, T_INDEX_KEY, T_PROPERTY_TYPE, T_PROPERTY_CODE, T_SPLIT_WEEKS, T_DISABLED, T_CHANGEOVER, T_BOOKED, T_PETS };
                //RunScreen(new BOOK0200(), RunScreenModes.Find, ref arrRunscreen);
                T_FIRST_TIME.Value = "N";
                if (QDesign.NULL(T_BOOKED.Value) == "Y")
                {
                    ReturnAndClose();
                    // RETURN
                }
                Display(ref fldT_YEAR);
                Display(ref fldT_START);
                Display(ref fldT_END);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }





        public override void PagePostProcess(PageArgs e)
        {

            try
            {
                Page.PageTitle = "S E L E C T   W E E K S / P R O P E R T Y";
                



            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }


        //#-----------------------------------------
        //# Update Procedure
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 06/19/2013 8:55:38 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 06/19/2013 8:55:38 AM
                fleM_INVESTORS.PutData(false, PutTypes.New);
                fleUSER_SEC_FILE.PutData(false, PutTypes.New);
                fleUSER_SEC_FILE.PutData();
                fleM_INVESTORS.PutData();
                //#END STANDARD PROCEDURE CONTENT

                ReturnAndClose();
                return true;

            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        //#-----------------------------------------
        //# dsrDesigner_09_Click Procedure
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 06/19/2013 8:55:38 AM
        //#-----------------------------------------
        private void dsrDesigner_09_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:49:31 PM
                Accept(ref fldT_PETS);
                Display(ref fldLOCN_BK_COMMENTS_BK_COMMENT_1);
                Display(ref fldLOCN_BK_COMMENTS_BK_COMMENT_2);
                Display(ref fldLOCN_BK_COMMENTS_BK_COMMENT_3);
                //#END STANDARD PROCEDURE CONTENT

            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        //#-----------------------------------------
        //# dsrDesigner_05_Click Procedure
        //# Precompiler Ver.: 1.0.4916.13714  Generated on: 06/19/2013 8:55:38 AM
        //#-----------------------------------------
        private void dsrDesigner_05_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4916.13714 Generated on: 07/12/2013 1:49:31 PM
                Accept(ref fldT_START);
                Accept(ref fldT_END);
                Accept(ref fldT_SHOW_ALL);
                Accept(ref fldT_SPECIFIC_WEEK);
                //#END STANDARD PROCEDURE CONTENT

            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        #endregion

        #endregion

    }

}
