#region "Screen Comments"

// Country Codes

#endregion


using Core.Framework;
using Core.Framework.Core.Framework;
using Core.ExceptionManagement;
using System.Data.SqlClient;
using System.Text;
using Core.DataAccess.SqlServer;
using Core.Windows;
using Core.Windows.UI.Core.Windows;
using Core.Windows.UI.Core.Windows.UI;
using System.Data;
using System;
using System.Windows;
using System.Data.OracleClient;

namespace rma.Views
{
    partial class ReportList : BasePage
    {

        #region " Form Designer Generated Code "



        public ReportList()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();

            this.FormName = "ReportList";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = false;
            this.FindActivity = true;
            this.DeleteActivity = true;
            this.EntryActivity = false;
            this.UseAcceptProcessing = true;
            this.GridDesigner = "dsrDesigner_01";
            this.HasExitProcedure = false;
            this.ScreenType = ScreenTypes.Grid;
            dsrDesigner_01.DefaultFirstRowInGrid = true;

            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

        }

        

        #endregion

        private void Page_Load(System.Object sender, System.EventArgs e)
        {
            SetVariables();
            
            dsrDesigner_01.Click += dsrDesigner_01_Click;
            dtlRENAISSANCE_REPORTS.EditClick += dtlRENAISSANCE_REPORTS_EditClick;
            dsrDesignerCompleted.Click += dsrDesignerCompleted_Click;
            dsrDesignerFailed.Click += dsrDesignerFailed_Click;
            Page_Load();
        }

        private string TMP_STATUS = "0002";

        protected override void SetVariables()
        {
            //Put user code to initialize the page here

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.
            fleRENAISSANCE_REPORTS = new OracleFileObject(this, FileTypes.Primary, 15, "INDEXED", "Renaissance_Reports", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            
            fleRENAISSANCE_REPORTS.Access += fleRENAISSANCE_REPORTS_Access;
            DEF_STATUS.GetValue += DEF_STATUS_GetValue;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;

            fleRENAISSANCE_REPORTS.Access -= fleRENAISSANCE_REPORTS_Access;
            DEF_STATUS.GetValue -= DEF_STATUS_GetValue;
            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dtlRENAISSANCE_REPORTS.EditClick -= dtlRENAISSANCE_REPORTS_EditClick;
            dsrDesignerCompleted.Click -= dsrDesignerCompleted_Click;
            dsrDesignerFailed.Click -= dsrDesignerFailed_Click;
        }

       	#region "Renaissance Architect Default Regions"

	#region "Declarations (Variables, Files and Transactions)"

	//# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
	//# Do not delete, modify or move it.

	//#Transactions
	private OracleConnection m_cnnQUERY = new OracleConnection();
	private OracleConnection m_cnnTRANS_UPDATE = new OracleConnection();

	private OracleTransaction m_trnTRANS_UPDATE;
	//#Files
    private OracleFileObject fleRENAISSANCE_REPORTS;
	

	private void fleRENAISSANCE_REPORTS_Access(ref string AccessClause)
	{
		try {
			StringBuilder strText = new StringBuilder("");

			strText.Append(" WHERE (RUN_BY = ").Append(Common.StringToField(this.UserID.ToLower()));
            strText.Append(" OR RUN_BY = ").Append(Common.StringToField(this.UserID.ToUpper()));
			strText.Append(") AND REPORT_STATUS = ").Append(Common.StringToField(TMP_STATUS));
			strText.Append(" ORDER BY RUN_DATE DESC, RUN_TIME DESC");

			AccessClause = strText.ToString();

		} catch (CustomApplicationException ex) {
			throw ex;

		} catch (Exception ex) {
			ExceptionManager.Publish(ex);
			throw ex;

		}

	}

	//#Variables
	
	private DCharacter DEF_STATUS = new DCharacter(10);
	
	private void DEF_STATUS_GetValue(ref string Value)
	{

		try {
			if (QDesign.NULL(TMP_STATUS) == "0002") {
				//Value = GetString("IM.ReportList.Completed", ResourceTypes.Message)
				Value = "Completed";
			} else {
				//Value = GetString("IM.ReportList.Failed", ResourceTypes.Message)
				Value = "Failed";
			}


		} catch (CustomApplicationException ex) {
			throw ex;


		} catch (Exception ex) {
			ExceptionManager.Publish(ex);
			throw ex;

		}


	}
	//#Parameters

	//#Controls

	#endregion

	#region "Standard Generated Procedures"

	#region "Grid Field Declarations"

	//# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
	//# Do not delete, modify or move it.  Updated: 21/12/2006 4:59:06 PM

	protected TextBox fldRENAISSANCE_REPORTS_REPORT_TITLE;
	protected DateControl fldRENAISSANCE_REPORTS_RUN_DATE;
	private TextBox withEventsField_fldRENAISSANCE_REPORTS_RUN_TIME;
	protected TextBox fldRENAISSANCE_REPORTS_RUN_TIME {
		get { return withEventsField_fldRENAISSANCE_REPORTS_RUN_TIME; }
		set {
			if (withEventsField_fldRENAISSANCE_REPORTS_RUN_TIME != null) {
				withEventsField_fldRENAISSANCE_REPORTS_RUN_TIME.Output -= fldRENAISSANCE_REPORTS_RUN_TIME_Output;
			}
			withEventsField_fldRENAISSANCE_REPORTS_RUN_TIME = value;
			if (withEventsField_fldRENAISSANCE_REPORTS_RUN_TIME != null) {
				withEventsField_fldRENAISSANCE_REPORTS_RUN_TIME.Output += fldRENAISSANCE_REPORTS_RUN_TIME_Output;
			}
		}
	}

	protected TextBox fldRENAISSANCE_REPORTS_REPORT_FORMAT;

	#endregion

	#region "Grid Procedures"

	//# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
	//# Do not delete, modify or move it.  Updated: 21/12/2006 4:59:06 PM

	//#-----------------------------------------
	//# GetGridFieldObject Procedure.
	//#-----------------------------------------

    protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
				case "FLDGRDRENAISSANCE_REPORTS_REPORT_TITLE":
                    fldRENAISSANCE_REPORTS_REPORT_TITLE = (TextBox)DataListField;
					CoreField = fldRENAISSANCE_REPORTS_REPORT_TITLE;
					fldRENAISSANCE_REPORTS_REPORT_TITLE.Bind(fleRENAISSANCE_REPORTS);
					break;
				case "FLDGRDRENAISSANCE_REPORTS_RUN_DATE":
                    fldRENAISSANCE_REPORTS_RUN_DATE = (DateControl)DataListField;
					CoreField = fldRENAISSANCE_REPORTS_RUN_DATE;
					fldRENAISSANCE_REPORTS_RUN_DATE.Bind(fleRENAISSANCE_REPORTS);
					break;
				case "FLDGRDRENAISSANCE_REPORTS_RUN_TIME":
                    fldRENAISSANCE_REPORTS_RUN_TIME = (TextBox)DataListField;
					CoreField = fldRENAISSANCE_REPORTS_RUN_TIME;
					fldRENAISSANCE_REPORTS_RUN_TIME.Bind(fleRENAISSANCE_REPORTS);
					break;
				case "FLDGRDRENAISSANCE_REPORTS_REPORT_FORMAT":
                    fldRENAISSANCE_REPORTS_REPORT_FORMAT = (TextBox)DataListField;
					CoreField = fldRENAISSANCE_REPORTS_REPORT_FORMAT;
					fldRENAISSANCE_REPORTS_REPORT_FORMAT.Bind(fleRENAISSANCE_REPORTS);
					break;
			}


		} catch (CustomApplicationException ex) {
			throw ex;


		} catch (Exception ex) {
			ExceptionManager.Publish(ex);
			throw ex;

		}

	}
	//#-----------------------------------------
	//# SetRelations Procedure.
	//#-----------------------------------------

	public override void SetRelations()
	{

		try {
			dtlRENAISSANCE_REPORTS.OccursWithFile = fleRENAISSANCE_REPORTS;

		} catch (CustomApplicationException ex) {
			throw ex;


		} catch (Exception ex) {
			ExceptionManager.Publish(ex);
			throw ex;

		}

	}


	#endregion

	#region "Transaction Management Procedures"

	//# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
	//# Do not delete, modify or move it.  Updated: 21/12/2006 4:59:06 PM

	//#-----------------------------------------
	//# InitializeTransactionObjects Procedure.
	//#-----------------------------------------

	protected override void InitializeTransactionObjects()
	{

		try {
			m_cnnTRANS_UPDATE = new OracleConnection(Common.GetConnectionString());
			m_cnnTRANS_UPDATE.Open();
			m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
			m_cnnQUERY = new OracleConnection(Common.GetConnectionString());


		} catch (CustomApplicationException ex) {
			throw ex;


		} catch (Exception ex) {
			ExceptionManager.Publish(ex);
			throw ex;

		}

	}

	//#-----------------------------------------
	//# CloseTransactionObjects Procedure.
	//#-----------------------------------------

	protected override void CloseTransactionObjects()
	{

		try {
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


		} catch (CustomApplicationException ex) {
			throw ex;


		} catch (Exception ex) {
			ExceptionManager.Publish(ex);
			throw ex;

		}

	}


	protected override void TRANS_UPDATE(TransactionMethods Method)
	{
		if (Method == TransactionMethods.Rollback) {
			m_trnTRANS_UPDATE.Rollback();
		} else {
			m_trnTRANS_UPDATE.Commit();
		}

		m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
		Initialize_TRANS_UPDATE();

	}


	private void Initialize_TRANS_UPDATE()
	{
		fleRENAISSANCE_REPORTS.Transaction = m_trnTRANS_UPDATE;


	}



	#endregion

	#region "FILE Management Procedures"

	//# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
	//# Do not delete, modify or move it.  Updated: 21/12/2006 4:59:06 PM

	//#-----------------------------------------
	//# InitializeFiles Procedure.
	//#-----------------------------------------

	protected override void InitializeFiles()
	{

		try {
			Initialize_TRANS_UPDATE();


		} catch (CustomApplicationException ex) {
			throw ex;


		} catch (Exception ex) {
			ExceptionManager.Publish(ex);
			throw ex;

		}

	}

	//#-----------------------------------------
	//# CloseFiles Procedure.
	//#-----------------------------------------

	protected override void CloseFiles()
	{

		try {
			fleRENAISSANCE_REPORTS.Dispose();


		} catch (CustomApplicationException ex) {
			throw ex;


		} catch (Exception ex) {
			ExceptionManager.Publish(ex);
			throw ex;

		}

	}



	#endregion

	#region "Display Procedures"

	//# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
	//# Do not delete, modify or move it.

	#endregion

	#region "Update Validation"

	//# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
	//# Do not delete, modify or move it.

	#endregion



	#endregion

	#region "RecordBuffer Events"

	//# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
	//# Do not delete, modify or move it.  Updated: 21/12/2006 4:59:06 PM



	#endregion

	#region "Automatic Item Initialization"

	//# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
	//# Do not delete, modify or move it.

	#endregion

	

	#region "Renaissance Architect Generated 4GL Procedures"


	#endregion

	#region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"


	public override void PagePostProcess(PageArgs e)
	{
		try {
			//Page.PageTitle = GetString("IM.ReportList.Title", ResourceTypes.Message) & " - " & DEF_STATUS.Value
			Page.PageTitle = "Report List" + " - " + DEF_STATUS.Value;

		} catch (CustomApplicationException ex) {
			throw ex;

		} catch (Exception ex) {
			ExceptionManager.Publish(ex);
			throw ex;

		}

	}


	private void fldRENAISSANCE_REPORTS_RUN_TIME_Output()
	{
		string value = string.Empty;

		try {
			value = QDesign.Substring(fleRENAISSANCE_REPORTS.GetDecimalValue("RUN_TIME").ToString(), 1, 2);

            if (value == "24")
            {
                FieldText = "00" + QDesign.Substring(fleRENAISSANCE_REPORTS.GetDecimalValue("RUN_TIME").ToString(), 3, 2);
            }
            else if (String.Compare(value, "24") > 0)
            {
                FieldText = "0" + QDesign.Substring(fleRENAISSANCE_REPORTS.GetDecimalValue("RUN_TIME").ToString(), 1, 3);
            }
            else
            {
                FieldText = QDesign.Substring(fleRENAISSANCE_REPORTS.GetDecimalValue("RUN_TIME").ToString(), 1, 4);
            }
					

		} catch (CustomApplicationException ex) {
			throw ex;

		} catch (Exception ex) {
			ExceptionManager.Publish(ex);
			throw ex;

		}

	}

	//#-----------------------------------------
	//# Find Procedure
	//# Precompiler Ver.: 2.2.0.37127  Generated on: 20/09/2005 10:16:07 AM
	//#-----------------------------------------
	protected override bool Find()
	{

		try {
			//#BEGIN STANDARD PROCEDURE CONTENT
			//# Precompiler Ver.: 2.2.0.37127 Generated on: 20/09/2005 10:16:07 AM

			fleRENAISSANCE_REPORTS.GetData(GetDataOptions.CreateSubSelect);

			//#END STANDARD PROCEDURE CONTENT
			return true;

		} catch (CustomApplicationException ex) {
			throw ex;

		} catch (Exception ex) {
			ExceptionManager.Publish(ex);
			throw ex;

		}

	}

	//#-----------------------------------------
	//# Path Procedure
	//# Precompiler Ver.: 2.2.0.37127  Generated on: 20/09/2005 10:16:07 AM
	//#-----------------------------------------
	protected override bool Path()
	{

		try {
			//#BEGIN STANDARD PROCEDURE CONTENT
			//# Precompiler Ver.: 2.2.0.37127 Generated on: 20/09/2005 10:16:07 AM
			//#END STANDARD PROCEDURE CONTENT

			return true;

		} catch (CustomApplicationException ex) {
			throw ex;

		} catch (Exception ex) {
			ExceptionManager.Publish(ex);
			throw ex;

		}

	}

	//#-----------------------------------------
	//# dtlRENAISSANCE_REPORTS_EditClick Procedure
	//# Precompiler Ver.: 2.2.0.37127  Generated on: 20/09/2005 10:16:07 AM
	//#-----------------------------------------

	private void dtlRENAISSANCE_REPORTS_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
	{
		try {
			//#BEGIN STANDARD PROCEDURE CONTENT
			//# Precompiler Ver.: 1.0.2539.20686 Generated on: 21/12/2006 4:59:06 PM
			dsrDesigner_01_Click(null, null);
			//#END STANDARD PROCEDURE CONTENT

		} catch (CustomApplicationException ex) {
			throw ex;

		} catch (Exception ex) {
			ExceptionManager.Publish(ex);
			throw ex;

		}

	}

	//#-----------------------------------------
	//# dsrDesigner_01_Click Procedure
	//# Precompiler Ver.: 2.2.0.37127  Generated on: 20/09/2005 10:16:07 AM
	//#-----------------------------------------

	private void dsrDesigner_01_Click(object sender, System.EventArgs e)
	{
		try {
			AddOpenReport(GetReportString());

		} catch (Exception ex) {
			ExceptionManager.Publish(ex);
			throw ex;

		}

	}

	private string GetReportString()
	{

		string strReportUserPath = string.Empty;
		string strReportName = string.Empty;
		string strReportFormat = string.Empty;
		string strReportExtension = string.Empty;

		StringBuilder strReportPath = new StringBuilder("");

		try {
			strReportUserPath = GetReportUserPath();
			strReportName = fleRENAISSANCE_REPORTS.GetStringValue("REPORT_FILE_NAME").Trim();
			strReportFormat = fleRENAISSANCE_REPORTS.GetStringValue("REPORT_FORMAT").Trim();

			switch (strReportFormat) {
				case "PDF":
                case ".pdf":
					strReportExtension = ".pdf";

					break;
				case "EXCEL":
                case ".xls":
					strReportExtension = ".xls";

					break;
				case "HTML4.0":
				case "HTML3.2":
                case ".html":
					strReportExtension = ".html";

					break;
				case "MHTML":
					strReportExtension = ".mth";

					break;
				case ".txt":
					strReportExtension = ".txt";

					break;
                case ".rtf":
                    strReportExtension = ".rtf";

                    break;
				default:
					strReportExtension = "";
					break;
			}

			strReportPath.Append(strReportUserPath).Append(strReportName).Append(strReportExtension);

			return strReportPath.ToString();

		} catch (Exception ex) {
			ExceptionManager.Publish(ex);
			throw ex;

		}

	}

	private string GetReportUserPath()
	{

		string strReportUserPath = string.Empty;
		string strReportCompletedPath = string.Empty;

		try {
			strReportCompletedPath = System.Configuration.ConfigurationManager.AppSettings["CompletedReportsPath"];

			if (!strReportCompletedPath.EndsWith( "\\")) {
				strReportCompletedPath = strReportCompletedPath + "\\";
			}

			strReportUserPath = strReportCompletedPath + (fleRENAISSANCE_REPORTS.GetStringValue("RUN_BY").Trim()) + "\\Reports\\";

			return strReportUserPath;

		} catch (Exception ex) {
			ExceptionManager.Publish(ex);
			throw ex;

		}

	}


	public void AddOpenReport(string strReport)
	{
        System.Diagnostics.Process.Start(strReport);

	}

	//#-----------------------------------------
	//# Update Procedure
	//# Precompiler Ver.: 1.0.2495.14536  Generated on: 21/11/2006 4:11:15 PM
	//#-----------------------------------------
	protected override bool Update()
	{
		try {
			string strReport = string.Empty;
			while (fleRENAISSANCE_REPORTS.For()) {
				if (fleRENAISSANCE_REPORTS.DeletedRecord) {
					strReport = GetReportString();
				} else {
					strReport = string.Empty;
				}
				fleRENAISSANCE_REPORTS.PutData(false, PutTypes.Deleted);
				if (!(strReport == string.Empty)) {
                    if (System.IO.File.Exists(strReport))
					    System.IO.File.Delete(strReport);
				}
			}
			return true;

		} catch (CustomApplicationException ex) {
			throw ex;


		} catch (Exception ex) {
			ExceptionManager.Publish(ex);
			throw ex;

		}

	}

	//#-----------------------------------------
	//# Delete Procedure
	//# Precompiler Ver.: 1.0.2495.14536  Generated on: 21/11/2006 4:11:16 PM
	//#-----------------------------------------
	protected override bool Delete()
	{
		try {
			//#BEGIN STANDARD PROCEDURE CONTENT
			//# Precompiler Ver.: 1.0.2495.14536 Generated on: 21/11/2006 4:11:16 PM
			fleRENAISSANCE_REPORTS.DeletedRecord = true;
			//#END STANDARD PROCEDURE CONTENT
			return true;

		} catch (CustomApplicationException ex) {
			throw ex;


		} catch (Exception ex) {
			ExceptionManager.Publish(ex);
			throw ex;

		}

	}

	#endregion




	protected void dsrDesignerCompleted_Click(object sender, System.EventArgs e)
	{
		try {
			TMP_STATUS = "0002";
            PagePostProcess(null);
			Push(PushTypes.Find);

		} catch (CustomApplicationException ex) {
			throw ex;


		} catch (Exception ex) {
			ExceptionManager.Publish(ex);
			throw ex;

		}

	}


	protected void dsrDesignerFailed_Click(object sender, System.EventArgs e)
	{
		try {
			TMP_STATUS = "0001";
            PagePostProcess(null);
			Push(PushTypes.Find);

		} catch (CustomApplicationException ex) {
			throw ex;


		} catch (Exception ex) {
			ExceptionManager.Publish(ex);
			throw ex;

		}

	}
	
}


    #endregion

    }

