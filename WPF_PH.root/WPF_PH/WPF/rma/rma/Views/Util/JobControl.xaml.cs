#region '"Screen Comments"'



#endregion

using System;
using System.Text;
using System.Windows;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.ExceptionManagement;
using Core.Windows.UI.Core.Windows;
using Core.Windows.UI.Core.Windows.UI;

namespace rma.Views
{

    partial class JobControl : BasePage
    {

        #region '" Web Form Designer Generated Code "'

        public JobControl()
        {

            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;



            InitializeComponent();

            this.HasExitProcedure = false;

            this.FormName = "JobControl";

            //  Set the ACTIVITIES for the screen.
            this.ChangeActivity = true;
            this.FindActivity = false;
            this.DeleteActivity = false;
            this.EntryActivity = true;
            this.UseAcceptProcessing = true;
            this.HasPathRequestFields = false;
        }

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();

            dsrDesignerExecute.Click += dsrDesignerExecute_Click;
            dsrDesigner_01.Click += dsrDesigner_01_Click;
            fldScheduleDate.Process += fldScheduleDate_Process;
            fldScheduleTime.Input += fldScheduleTime_Input;
            fldAMPM.Process += fldAMPM_Process;
            fldRunSchedule.Output += fldRunSchedule_Input;
            fldFormat.Output += fldFormat_Input;
            fldDayOfWeek.Output += fldDayOfWeek_Input;
            fldAMPM.Output += fldAMPM_Input;

            JOBNAME = new CoreCharacter("JOBNAME", 100, this, Core.Framework.Core.Framework.ResetTypes.ResetAtStartup, Common.cEmptyString);
            JOBPATH = new CoreCharacter("JOBPATH", 200, this, Core.Framework.Core.Framework.ResetTypes.ResetAtStartup, Common.cEmptyString);
            RunSchedule = new CoreCharacter("RunSchedule", 40, this, Core.Framework.Core.Framework.ResetTypes.ResetAtMode, Common.cEmptyString);
            ScheduleDate = new CoreDate("ScheduleDate", this, ResetTypes.ResetAtMode, GetDate());
            ScheduleTime = new CoreDecimal("ScheduleTime", 10, this, ResetTypes.ResetAtMode, GetTime(true));
            Format = new CoreCharacter("Format", 10, this, Core.Framework.Core.Framework.ResetTypes.ResetAtMode, Common.cEmptyString);
            ProcessingStatus = new CoreCharacter("ProcessingStatus", 50, this, Core.Framework.Core.Framework.ResetTypes.ResetAtMode, Common.cEmptyString);
            AMPM = new CoreCharacter("AMPM", 2, this, Core.Framework.Core.Framework.ResetTypes.ResetAtMode, GetAMPM(true));
            TMP_SUBMIT = new CoreCharacter("TMP_FISCAL_YR", 1, this, ResetTypes.ResetAtStartup, "N");
            Interval = new CoreDecimal("Interval", 3, this, Core.Framework.Core.Framework.ResetTypes.ResetAtMode, 0);
            DayOfWeek = new CoreCharacter("DayOfWeek", 30, this, Core.Framework.Core.Framework.ResetTypes.ResetAtMode, Common.cEmptyString);
            MonthsOfYear = new CoreCharacter("MonthsOfYear", 30, this, Core.Framework.Core.Framework.ResetTypes.ResetAtMode, Common.cEmptyString);

            Page_Load();
        }

        protected override void SetVariables()
        {
            

        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;

            dsrDesignerExecute.Click -= dsrDesignerExecute_Click;
            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            fldScheduleDate.Process -= fldScheduleDate_Process;
            fldScheduleTime.Input -= fldScheduleTime_Input;
            fldAMPM.Process -= fldAMPM_Process;
            fldRunSchedule.Output -= fldRunSchedule_Input;
            fldFormat.Output -= fldFormat_Input;
            fldDayOfWeek.Output -= fldDayOfWeek_Input;
            fldAMPM.Output -= fldAMPM_Input;
        }




        #endregion

        private void Page_Load(System.Object sender, System.EventArgs e)
        {
            // Put user code to initialize the page here

        }


        #region '"Renaissance Architect Migration Services Default Regions"'

        #region '"Declarations (Variables, Files and Transactions)"'

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.

        private CoreCharacter JOBNAME;
        private CoreCharacter JOBPATH;

        private CoreCharacter RunSchedule;
        private CoreDate ScheduleDate;
        private CoreDecimal ScheduleTime;
        private CoreCharacter Format;
        private CoreCharacter ProcessingStatus;
        private CoreCharacter AMPM;
        private CoreCharacter TMP_SUBMIT;

        private CoreDecimal Interval;
        private CoreCharacter DayOfWeek;
        private CoreCharacter MonthsOfYear;


        private decimal GetDate()
        {

            return decimal.Parse(DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0'));

        }


        private decimal GetTime([System.Runtime.InteropServices.Optional] bool Future/* TRANSERROR: default parameter value: false */  )
        {
            int intHour = DateTime.Now.Hour;
            int intMinute = DateTime.Now.Minute;
            int intOffSet;
            DateTime tmpdate;


            if (Future)
            {
                if ((System.Configuration.ConfigurationManager.AppSettings["Batch_Offset"]) == null)
                {
                    intOffSet = 60;
                }
                else
                {
                    intOffSet = int.Parse(System.Configuration.ConfigurationManager.AppSettings["Batch_Offset"]);
                }

                intHour += Convert.ToInt16(QDesign.Round(intOffSet / 60, 0, RoundOptionTypes.Down));
                intMinute += intOffSet % (60);
                if (intMinute >= 60)
                {
                    intMinute = intMinute - 60;
                    intHour = intHour + 1;
                }

                if (intHour >= 24)
                {
                    tmpdate = ScheduleDate.DateValue;

                    ScheduleDate.DateValue = tmpdate.AddDays(System.Convert.ToDouble(QDesign.Round(intHour / 24, 0, RoundOptionTypes.Down)));
                    intHour = intHour % (24);

                }

            }
            if (intHour > 12)
            {
                return decimal.Parse((intHour - 12).ToString() + Convert.ToString(intMinute).PadLeft(2, '0'));
            }
            else
            {
                return System.Convert.ToDecimal(intHour.ToString() + DateTime.Now.Minute.ToString().PadLeft(2, '0'));
            }
        }


        private string GetAMPM([System.Runtime.InteropServices.Optional] bool Future/* TRANSERROR: default parameter value: false */  )
        {
            int intHour = DateTime.Now.Hour;
            if (Future)
            {
                intHour += 1;
            }
            if (intHour - 12 < 0)
            {
                return "am";
            }
            else
            {
                return "pm";
            }
        }

        #endregion

        #region '"Standard Generated Procedures"'

        #region '"Grid Field Declarations"'

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 1/24/2007 11:27:55 AM

        // # No code was generated or needed for this region.

        #endregion

        #region '"Grid Procedures"'

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 1/24/2007 11:27:55 AM

        // # No code was generated or needed for this region.

        #endregion

        #region '"Transaction Management Procedures"'

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 6/16/2006 10:38:32 AM


        #endregion

        #region '"FILE Management Procedures"'

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 1/24/2007 11:27:55 AM

        // #-----------------------------------------
        // # InitializeFiles Procedure.
        // #-----------------------------------------
        protected override void InitializeFiles()
        {

            try
            {


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


        // #-----------------------------------------
        // # CloseFiles Procedure.
        // #-----------------------------------------
        protected override void CloseFiles()
        {

            try
            {


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

        #region '"Display Procedures"'

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.

        // #-----------------------------------------
        // # DisplayFormatting Procedure
        // # Precompiler Ver.: 1.0.2356.23440  Generated on: 6/16/2006 9:37:18 AM
        // #-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                // #BEGIN STANDARD PROCEDURE CONTENT
                // # Precompiler Ver.: 1.0.2561.19714 Generated on: 1/24/2007 11:27:55 AM
                Display(ref fldRunSchedule);
                Display(ref fldScheduleDate);
                Display(ref fldScheduleTime);
                Display(ref fldInterval);
                Display(ref fldDayOfWeek);
                Display(ref fldMonthsOfYear);
                Display(ref fldFormat);
                Display(ref fldProcessingStatus);
                Display(ref fldAMPM);
                Display(ref fldDayOfMonth);
                // #END STANDARD PROCEDURE CONTENT
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

        #region '"Update Validation"'

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.

        // #-----------------------------------------
        // # UpdateValidation Procedure
        // # Precompiler Ver.: 1.0.2358.16376  Generated on: 6/16/2006 10:31:29 AM
        // #-----------------------------------------
        //  TODO: Must fix manually!
        protected override void UpdateValidation()
        {
            try
            {
                // #BEGIN STANDARD PROCEDURE CONTENT
                // # Precompiler Ver.: 1.0.2358.16376 Generated on: 6/16/2006 11:46:02 AM
                if (fldRunSchedule.ValueChanged)
                {
                    Validate(ref fldRunSchedule, ValidateTypes.Accept, false);
                }
                if (fldScheduleDate.ValueChanged)
                {
                    Validate(ref fldScheduleDate, ValidateTypes.Accept, false);
                }
                if (fldScheduleTime.ValueChanged)
                {
                    Validate(ref fldScheduleTime, ValidateTypes.Accept, false);
                }
                if (fldFormat.ValueChanged)
                {
                    Validate(ref fldFormat, ValidateTypes.Accept, false);
                }
                // #END STANDARD PROCEDURE CONTENT
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

        #region '"Select Processing"'

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.

        #endregion

        #region '"RecordBuffer Events"'

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.  Updated: 1/24/2007 11:27:55 AM

        // #-----------------------------------------
        // # BindFields Procedure.
        // #-----------------------------------------
        public override void BindFields()
        {

            try
            {
                fldRunSchedule.Bind(RunSchedule);
                fldScheduleDate.Bind(ScheduleDate);
                fldScheduleTime.Bind(ScheduleTime);
                fldInterval.Bind(Interval);
                fldDayOfWeek.Bind(DayOfWeek);
                fldMonthsOfYear.Bind(MonthsOfYear);
                fldFormat.Bind(Format);
                fldProcessingStatus.Bind(ProcessingStatus);
                fldAMPM.Bind(AMPM);
                fldDayOfMonth.Bind(Interval);
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

        #region '"Automatic Item Initialization"'

        // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        // # Do not delete, modify or move it.

        #endregion

        #endregion

        #region '"Renaissance Architect Generated 4GL Procedures"'

        public override void PagePostProcess(PageArgs e)
        {

            try
            {

                Page.PageTitle = "Job Control";

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

                Receiving(JOBNAME, JOBPATH);

            }
            catch (CustomApplicationException ex)
            {

                throw ex;

            }
            catch (Exception ex)
            {
                //  Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }


        protected override void SaveParamsReceived()
        {

            try
            {



            }
            catch (CustomApplicationException ex)
            {

                throw ex;

            }
            catch (Exception ex)
            {
                //  Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }


        #endregion

        #region '"Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"'

        protected override bool Initialize()
        {

            try
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(JOBPATH.Value.Trim());

                string[] arrCommand = null;
                string[] arrParameters = null;

                string strLine = string.Empty;
                string strTemp = string.Empty;

                int intCount = 1;
                int intUpper = 0;

                //  Read command line from jobscript file.
                strLine = sr.ReadLine();

                while (!((strLine) == null) && intCount < 16)
                {
                    if (strLine.Contains("~"))
                    {
                        arrCommand = strLine.Split('~');

                        //  Determine parameters from passed in command line.
                        intUpper = arrCommand.GetUpperBound(0);
                        strTemp = arrCommand[intUpper].ToString();

                        arrParameters = strTemp.Split(',');
                    }
                    else
                    {
                        arrCommand = strLine.Split(',');
                    }

                    switch (arrCommand[0].ToUpper())
                    {
                        case "QTP":
                            AssignLabels(intCount, "QTP  - " + arrCommand[1]);
                            intCount += 1;
                            break;
                        case "QUIZ":
                            AssignLabels(intCount, "QUIZ - " + arrCommand[1]);
                            IsQuiz = true;
                            intCount += 1;
                            break;
                    }



                    //  Read next command line from jobscript file.
                    strLine = sr.ReadLine();
                }

                sr.Close();
                sr.Dispose();

                fldScheduleDate.IsEnabled = false;
                fldScheduleTime.IsEnabled = false;
                fldAMPM.IsEnabled = false;


                fldInterval.IsEnabled = false;
                fldDayOfWeek.IsEnabled = false;
                fldMonthsOfYear.IsEnabled = false;

                RunSchedule.Value = "N";
                Display(ref fldRunSchedule);

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


        private bool AssignLabels(int intPosition, string strValue)
        {

            try
            {

                switch (intPosition)
                {
                    case 1:
                        Label1.Text = strValue;
                        return true;
                    case 2:
                        Label2.Text = strValue;
                        return true;
                    case 3:
                        Label3.Text = strValue;
                        return true;
                    case 4:
                        Label4.Text = strValue;
                        return true;
                    case 5:
                        Label5.Text = "....";

                        return true;
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


        protected override bool Find()
        {

            try
            {

                ErrorMessage("Please use ADD to Submit Jobs.");

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

                fldScheduleDate.IsEnabled = true;
                fldScheduleTime.IsEnabled = false;
                fldAMPM.IsEnabled = false;
                fldDayOfMonth.IsEnabled = false;
                fldInterval.IsEnabled = false;
                fldDayOfWeek.IsEnabled = false;
                fldMonthsOfYear.IsEnabled = false;

                if (IsQuiz)
                {
                    if (fldFormat.Text == "")
                    {
                        Format.Value = "P";
                        Display(ref fldFormat);
                        fldFormat.IsEnabled = true;
                    }
                }
                else
                {
                    fldFormat.IsEnabled = false;
                }

                Accept(ref fldRunSchedule);               

                

                if (RunSchedule.Value.Trim() != "N")
                {
                    if (RunSchedule.Value.Trim() == "O")
                    {
                        fldScheduleDate.IsEnabled = true;
                        Accept(ref fldScheduleDate);
                    }
                    fldScheduleTime.IsEnabled = true;
                    fldAMPM.IsEnabled = true;

                    Accept(ref fldScheduleTime);
                    Accept(ref fldAMPM);       


                    if (RunSchedule.Value.Trim() == "D" || RunSchedule.Value.Trim() == "W")
                    {
                        fldInterval.IsEnabled = true;
                        Accept(ref fldInterval);     
                    }

                    if (RunSchedule.Value.Trim() == "W")
                    {
                        fldDayOfWeek.IsEnabled = true;
                        Accept(ref fldDayOfWeek);    
                    }

                    if (RunSchedule.Value.Trim() == "M")
                    {
                        fldMonthsOfYear.IsEnabled = true;
                        fldDayOfMonth.IsEnabled = true;
                        Accept(ref fldMonthsOfYear);
                        Accept(ref fldDayOfMonth);    

                    }

                    if (RunSchedule.Value.Trim() == "O")
                    {
                        ScheduleDate.Value = GetDate();
                        Accept(ref fldScheduleDate);
                    }

                    ScheduleTime.Value = GetTime(true);
                    AMPM.Value = GetAMPM(false);

                    Accept(ref fldScheduleTime);
                    Accept(ref fldAMPM);



                    if (RunSchedule.Value.Trim() == "D" || RunSchedule.Value.Trim() == "W")
                    {
                        fldInterval.IsEnabled = true;
                        Accept(ref fldInterval);
                    }

                    if (RunSchedule.Value.Trim() == "W")
                    {
                        fldDayOfWeek.IsEnabled = true;
                        Accept(ref fldDayOfWeek);
                    }

                    if (RunSchedule.Value.Trim() == "M")
                    {
                        Accept(ref fldDayOfMonth);
                        Accept(ref fldMonthsOfYear);
                    }

                }
                else
                {
                    ScheduleTime.Value = GetTime(true);
                    AMPM.Value = GetAMPM(false);
                    fldScheduleDate.IsEnabled = false;
                    fldScheduleTime.IsEnabled = false;
                    fldAMPM.IsEnabled = false;
                    Display(ref fldScheduleTime);
                    Display(ref fldScheduleDate);
                    Display(ref fldAMPM);
                }

                if (IsQuiz)
                {
                    Accept(ref fldFormat);
                }
                else
                {
                    Format.Value = "";
                    Display(ref fldFormat);
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


        protected override bool Update()
        {
            try
            {

                if (RunSchedule.Value.Trim() != "N")
                {
                    if (CheckDateTime())
                    {
                        SetReportSchedule();
                    }
                }
                else
                {
                    RunReport();
                }

                TMP_SUBMIT.Value = "Y";

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



        protected void dsrDesignerExecute_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (RunSchedule.Value.Trim() != "Now")
                {
                    if (CheckDateTime())
                    {
                        SetReportSchedule();
                    }
                }
                else
                {
                    RunReport();
                }

                TMP_SUBMIT.Value = "Y";

                ReturnAndClose();

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


       


        private bool SetReportSchedule()
        {

            Batch_Job.Service BatchJob = new Batch_Job.Service();

            try
            {

                int hour = Convert.ToInt16(ScheduleTime.Value.ToString().PadLeft(4).Substring(0, 2));
                int minute = Convert.ToInt16(ScheduleTime.Value.ToString().PadLeft(4).Substring(2));
                int year = ScheduleDate.DateValue.Year;
                int month = ScheduleDate.DateValue.Month;
                int day = ScheduleDate.DateValue.Day;
                bool blnEveryDay = RunSchedule.Value.Trim() != "N";
                int intDayorMonth = 0;

                if (hour < 12 && AMPM.Value == "pm")
                {
                    hour = hour + 12;
                }

                // 05-Junio-2009 DMF - Code was not allowing 12 AM hour job scheduling.  
                // Was converting everything to 12 PM hour. ie. Requesting 12:40 AM, resulted in 12:40 PM
                // Made this change and job now schedules correctly for 12:40 AM
                if (hour == 12 && AMPM.Value == "am")
                {
                    hour = hour - 12;
                }
                // 05-Junio-2009 DMF - End Change

                DateTime dtePass = new DateTime(year, month, day, hour, minute, 0);

                if (blnEveryDay)
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(JOBPATH.Value.Trim());
                    string strText = sr.ReadToEnd();

                    sr.Close();
                    sr.Dispose();

                    strText = "KEEP" + Environment.NewLine + strText;

                    System.IO.StreamWriter sw = new System.IO.StreamWriter(JOBPATH.Value.Trim(), false);
                    sw.Write(strText);

                    sw.Close();
                    sw.Dispose();
                }

                if (IsQuiz)
                {
                    AddFormatToFile();
                }


                switch (RunSchedule.Value.Trim())
                {
                    case "O":
                        BatchJob.ScheduleBatch(JOBNAME.Value.Trim(), JOBPATH.Value.Trim(), dtePass, UserID, "rma", "O", 0, "0");
                        break;
                    case "D":
                        BatchJob.ScheduleBatch(JOBNAME.Value.Trim(), JOBPATH.Value.Trim(), dtePass, UserID, "rma", "D", ((int)(Interval.Value)), "0");
                        break;
                    case "W":

                        switch (DayOfWeek.Value)
                        {
                            case "SU":
                                intDayorMonth = 1;
                                break;
                            case "MO":
                                intDayorMonth = 2;
                                break;
                            case "TU":
                                intDayorMonth = 3;
                                break;
                            case "WE":
                                intDayorMonth = 4;
                                break;
                            case "TH":
                                intDayorMonth = 5;
                                break;
                            case "FR":
                                intDayorMonth = 6;
                                break;
                            case "SA":
                                intDayorMonth = 7;
                                break;
                        }

                        BatchJob.ScheduleBatch(JOBNAME.Value.Trim(), JOBPATH.Value.Trim(), dtePass, UserID, "rma", "W", ((int)(Interval.Value)), intDayorMonth.ToString());
                        break;
                    case "M":
                        switch (MonthsOfYear.Value)
                        {
                            case "January":
                                intDayorMonth = 1;
                                break;
                            case "February":
                                intDayorMonth = 2;
                                break;
                            case "March":
                                intDayorMonth = 3;
                                break;
                            case "April":
                                intDayorMonth = 4;
                                break;
                            case "May":
                                intDayorMonth = 5;
                                break;
                            case "June":
                                intDayorMonth = 6;
                                break;
                            case "July":
                                intDayorMonth = 7;
                                break;
                            case "August":
                                intDayorMonth = 8;
                                break;
                            case "September":
                                intDayorMonth = 9;
                                break;
                            case "October":
                                intDayorMonth = 10;
                                break;
                            case "November":
                                intDayorMonth = 11;
                                break;
                            case "December":
                                intDayorMonth = 12;
                                break;
                        }

                        BatchJob.ScheduleBatch(JOBNAME.Value.Trim(), JOBPATH.Value.Trim(), dtePass, UserID, "rma", "M", ((int)(Interval.Value)), intDayorMonth.ToString());
                        break;
                }


                Information("The Job has been successfully scheduled!");

                return true;

            }
            catch (Exception ex)
            {

                return false;


            }

        }


        private bool CheckDateTime()
        {

            DateTime dtScheduleTime;

            dtScheduleTime = Convert.ToDateTime(ScheduleTime.Value.ToString("0#:##") + ":00" + fldAMPM.Text);

            if (RunSchedule.Value.Trim() == "Once")
            {
                //  Determine the chronological order of the date.
                if (ScheduleDate.DateValue < DateTime.Today.Date)
                {
                    ErrorMessage("You must select a future date.");
                }
                else if (ScheduleDate.DateValue == DateTime.Today.Date)
                {
                    int intTime = dtScheduleTime.Hour;

                    // If AMPM.Value = "pm" Then
                    // intTime = Hour(dtScheduleTime)
                    // End If
                    if (intTime <= DateTime.Now.Hour)
                    {
                        if (dtScheduleTime.Minute < DateTime.Now.Minute)
                        {
                            ErrorMessage("You must select a future time.");
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }

            return true;

        }


        private void RunReport()
        {

            Batch_Job.Service BatchJob = new Batch_Job.Service();
            //BatchJob.Url = "http://localhost:64991/CSharp_Batch_Job/Service.asmx";
            try
            {
                
                    if (IsQuiz)
                    {
                        AddFormatToFile();
                    }

                    BatchJob.RunJob(JOBPATH.Value.Trim(), "1");

                    if (IsQuiz)
                    {
                        //object[] arrRunscreen = {  };
                        //RunScreen(new ReportList(), RunScreenModes.Find, ref arrRunscreen);

                    }

                


                Information("Generation has completed!");

                ReturnAndClose();

            }
            catch (CustomApplicationException ex)
            {

                throw ex;

            }
            catch (Exception ex)
            {
                //  Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex);
                throw ex;

            }
            

        }


        protected void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {

            try
            {

                fldScheduleDate.IsEnabled = true;
                fldScheduleTime.IsEnabled = false;
                fldAMPM.IsEnabled = false;
                fldDayOfMonth.IsEnabled = false;
                fldInterval.IsEnabled = false;
                fldDayOfWeek.IsEnabled = false;
                fldMonthsOfYear.IsEnabled = false;

                if (IsQuiz)
                {
                    Format.Value = "P";
                    Display(ref fldFormat);
                    fldFormat.IsEnabled = true;
                }

                Accept(ref fldRunSchedule);



                if (RunSchedule.Value.Trim() != "N")
                {
                    if (RunSchedule.Value.Trim() == "O")
                    {
                        fldScheduleDate.IsEnabled = true;
                    }
                    fldScheduleTime.IsEnabled = true;
                    fldAMPM.IsEnabled = true;

                    Accept(ref fldScheduleTime);
                    Accept(ref fldAMPM);


                    if (RunSchedule.Value.Trim() == "D" || RunSchedule.Value.Trim() == "W")
                    {
                        fldInterval.IsEnabled = true;
                        Accept(ref fldInterval);
                    }

                    if (RunSchedule.Value.Trim() == "W")
                    {
                        fldDayOfWeek.IsEnabled = true;
                        Accept(ref fldDayOfWeek);
                    }

                    if (RunSchedule.Value.Trim() == "M")
                    {
                        fldMonthsOfYear.IsEnabled = true;
                        fldDayOfMonth.IsEnabled = true;
                        Accept(ref fldMonthsOfYear);
                        Accept(ref fldDayOfMonth);

                    }

                    if (RunSchedule.Value.Trim() == "O")
                    {
                        ScheduleDate.Value = GetDate();
                        Accept(ref fldScheduleDate);
                    }

                    ScheduleTime.Value = GetTime(true);
                    AMPM.Value = GetAMPM(false);

                    Accept(ref fldScheduleTime);
                    Accept(ref fldAMPM);



                    if (RunSchedule.Value.Trim() == "D" || RunSchedule.Value.Trim() == "W")
                    {
                        fldInterval.IsEnabled = true;
                        Accept(ref fldInterval);
                    }

                    if (RunSchedule.Value.Trim() == "W")
                    {
                        fldDayOfWeek.IsEnabled = true;
                        Accept(ref fldDayOfWeek);
                    }

                    if (RunSchedule.Value.Trim() == "M")
                    {
                        Accept(ref fldDayOfMonth);
                        Accept(ref fldMonthsOfYear);
                    }

                }
                else
                {
                    ScheduleTime.Value = GetTime(true);
                    AMPM.Value = GetAMPM(false);
                    fldScheduleDate.IsEnabled = false;
                    fldScheduleTime.IsEnabled = false;
                    fldAMPM.IsEnabled = false;
                    Display(ref fldScheduleTime);
                    Display(ref fldScheduleDate);
                    Display(ref fldAMPM);
                }

                if (IsQuiz)
                {
                    Accept(ref fldFormat);
                }
                else
                {
                    Format.Value = "";
                    Display(ref fldFormat);
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


        protected void fldScheduleDate_Process()
        {

            try
            {
                DateTime dtScheduleTime = DateTime.MinValue;

                dtScheduleTime = Convert.ToDateTime(ScheduleTime.Value.ToString("0#:##") + ":00" + fldAMPM.Text);

                if (RunSchedule.Value.Trim() == "O")
                {
                    //  Determine the chronological order of the date.
                    if (ScheduleDate.DateValue < DateTime.Today.Date)
                    {
                        ErrorMessage("You must select a future date.");
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

        protected void fldScheduleTime_Input()
        {

            try
            {
                if (FieldText == "")
                {
                    FieldText = ScheduleTime.Value.ToString();
                }

                if (FieldText != " ")
                {
                    FieldText = FieldText.Replace(":", "");
                    try
                    {
                        if (Convert.ToInt16(FieldText) >= 1300)
                        {
                            if (Convert.ToInt16(FieldText) >= 2400)
                            {
                                ErrorMessage("Value for Time is incorrect. Please use hh:mm");
                            }
                            FieldText = ((Convert.ToInt16(FieldText)) - 1200).ToString();
                            AMPM.Value = "pm";
                            Display(ref fldAMPM);
                        }
                    }
                    catch (Exception ex)
                    {

                        ErrorMessage("Value for Time is incorrect. Please use hh:mm");

                    }

                    try
                    {
                        if (Convert.ToInt16(FieldText.Substring(FieldText.Length - 2, 2)) > 59)
                        {
                            ErrorMessage("Minutes are not valid.");
                        }
                    }
                    catch (Exception ex)
                    {

                        ErrorMessage("Minutes are not valid.");

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


        protected void fldAMPM_Process()
        {

            try
            {
                DateTime dtScheduleTime = DateTime.MinValue;

                var ampm = "";
                switch (fldAMPM.Text.Trim())
                {
                    case "A":
                    case "AM":
                        ampm = "am";
                        break;
                    case "P":
                    case "PM":
                        ampm = "pm";
                        break;

                }

                dtScheduleTime = Convert.ToDateTime(ScheduleTime.Value.ToString("0#:##") + ":00" + ampm);

                if (RunSchedule.Value.Trim() == "Once")
                {
                    //  Determine the chronological order of the date.
                    if (ScheduleDate.DateValue == DateTime.Today.Date)
                    {
                        int intTime = dtScheduleTime.Hour;

                        if (intTime <= DateTime.Now.Hour)
                        {
                            if (dtScheduleTime.Minute < DateTime.Now.Minute)
                            {
                                ErrorMessage("You must select a future time.");
                            }
                        }
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


        private void AddFormatToFile()
        {

            try
            {
                var format = "";
                switch (Format.Value.Trim())
                {
                    case "P":
                        format = "PDF";
                        break;
                    case "H":
                        format = "HTML";
                        break;
                    case "E":
                        format = "EXCEL";
                        break;
                    case "T":
                        format = "TEXT";
                        break;

                    case "W":
                        format = "WORD";
                        break;
                }


                System.IO.StreamReader sr = new System.IO.StreamReader(JOBPATH.Value.Trim());
                string strText = sr.ReadToEnd();

                sr.Close();
                sr.Dispose();

                strText = strText.Replace("\r\nQUIZ~", "\r\nQUIZ~" + format + "~"); 

                System.IO.StreamWriter sw = new System.IO.StreamWriter(JOBPATH.Value.Trim(), false);
                sw.Write(strText);

                sw.Close();
                sw.Dispose();

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



        protected override bool Exit()
        {

            try
            {

                if (TMP_SUBMIT.Value == "N")
                {
                    System.IO.File.Delete(JOBPATH.Value.Trim());
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


        private void fldRunSchedule_Input()
        {

            try
            {
                switch(FieldText.Trim())
                {
                    case "N":
                        FieldText = "Now";
                            break;
                    case "O":
                            FieldText = "Once";
                            break;
                    case "D":
                            FieldText = "Daily";
                            break;
                    case "W":
                            FieldText = "Weekly";
                            break;
                    case "M":
                            FieldText = "Monthly";
                            break;
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

        private void fldFormat_Input()
        {

            try
            {
                switch (FieldText.Trim())
                {
                    case "P":
                        FieldText = "PDF";
                        break;
                    case "H":
                        FieldText = "HTML";
                        break;
                    case "E":
                        FieldText = "EXCEL";
                        break;
                    case "T":
                        FieldText = "TEXT";
                        break;
                    case "W":
                        FieldText = "WORD";
                        break;
                   
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

        private void fldDayOfWeek_Input()
        {

            try
            {
                switch (FieldText.Trim())
                {
                    case "M":
                    case "MO":
                        FieldText = "Monday";
                            break;
                    case "TU":
                            FieldText = "Tuesday";
                            break;
                    case "W":
                    case "WE":
                            FieldText = "Wednesday";
                            break;
                    case "TH":
                            FieldText = "Thursday";
                            break;
                    case "F":
                    case "FR":
                            FieldText = "Friday";
                            break;
                    case "SA":
                            FieldText = "Saturady";
                            break;
                    case "SU":
                            FieldText = "Sunday";
                            break;
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

        private void fldAMPM_Input()
        {

            try
            {
                switch (FieldText.Trim())
                {
                    case "A":
                    case "AM":
                        FieldText = "am";
                            break;
                    case "P":
                    case "PM":
                            FieldText = "pm";
                            break;
                   
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
        
        



        #endregion

        #endregion

    }
}


