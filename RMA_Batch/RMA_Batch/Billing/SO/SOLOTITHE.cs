
#region "Screen Comments"

// doc     : solotithe.qts           
// purpose : create a excel file for dept 4 H132 docs                          
// sort by doc-name  
// who     : For Dwayne Martins                                    
// *************************************************************
// Date  Who  Description
// 2008/10/07 Yasemin         original
// 2016/Aug/11   MC1             - add a new column for term date as requested by Yasemin
// 2016/Aug/15        - change the same as prodtithe.qts for choose and sorted
// 2016/Sep/08          - Yasemin agreed to include the new column primary-flag


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class SOLOTITHE : BaseClassControl
{

    private SOLOTITHE m_SOLOTITHE;

    public SOLOTITHE(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public SOLOTITHE(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_SOLOTITHE != null))
        {
            m_SOLOTITHE.CloseTransactionObjects();
            m_SOLOTITHE = null;
        }
    }

    public SOLOTITHE GetSOLOTITHE(int Level)
    {
        if (m_SOLOTITHE == null)
        {
            m_SOLOTITHE = new SOLOTITHE("SOLOTITHE", Level);
        }
        else
        {
            m_SOLOTITHE.ResetValues();
        }
        return m_SOLOTITHE;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.


    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {


        try
        {

            SOLOTITHE_ONE_1 ONE_1 = new SOLOTITHE_ONE_1(Name, Level);
            ONE_1.Run();
            ONE_1.Dispose();
            ONE_1 = null;

            return true;


        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);
            return false;


        }
        catch (Exception ex)
        {
            WriteError(ex);
            return false;

        }

    }







    #endregion

    #endregion

}



public class SOLOTITHE_ONE_1 : SOLOTITHE
{

    public SOLOTITHE_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF119_DOCTOR_YTD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_EXTRA = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_EXTRA", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_TITHD1 = new CoreDecimal("X_TITHD1", 7, this);
        X_TITHD2 = new CoreDecimal("X_TITHD2", 7, this);
        X_TITHD3 = new CoreDecimal("X_TITHD3", 7, this);
        X_TOTITD = new CoreDecimal("X_TOTITD", 7, this);
        X_NONRB = new CoreDecimal("X_NONRB", 7, this);
        X_NONRBP = new CoreDecimal("X_NONRBP", 7, this);
        X_DEPMED = new CoreDecimal("X_DEPMED", 7, this);
        X_PAYEFT = new CoreDecimal("X_PAYEFT", 7, this);
        X_ADVOUT = new CoreDecimal("X_ADVOUT", 7, this);
        X_TOTREV = new CoreDecimal("X_TOTREV", 7, this);
        X_TOTDED = new CoreDecimal("X_TOTDED", 7, this);
        fleSOLOTITHE = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SOLOTITHE", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        TERM_DATE.GetValue += TERM_DATE_GetValue;
        COMMA.GetValue += COMMA_GetValue;
        X_NUM_CR.GetValue += X_NUM_CR_GetValue;
        X_CR.GetValue += X_CR_GetValue;
        fleF020_DOCTOR_MSTR.InitializeItems += fleF020_DOCTOR_MSTR_AutomaticItemInitialization;
        fleF020_DOCTOR_EXTRA.InitializeItems += fleF020_DOCTOR_EXTRA_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(SOLOTITHE_ONE_1)"

    private SqlFileObject fleF119_DOCTOR_YTD;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF020_DOCTOR_EXTRA;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")) == "H132")
            {
                return true;
            }

            return false;


        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);
            return false;


        }
        catch (Exception ex)
        {
            WriteError(ex);
            return false;

        }

    }

    private CoreDecimal X_TITHD1;
    private CoreDecimal X_TITHD2;
    private CoreDecimal X_TITHD3;
    private CoreDecimal X_TOTITD;
    private CoreDecimal X_NONRB;
    private CoreDecimal X_NONRBP;
    private CoreDecimal X_DEPMED;
    private CoreDecimal X_PAYEFT;
    private CoreDecimal X_ADVOUT;
    private CoreDecimal X_TOTREV;
    private CoreDecimal X_TOTDED;
    private DCharacter TERM_DATE = new DCharacter("TERM_DATE", 8);
    private void TERM_DATE_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (Convert.ToDecimal(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_YY").ToString().PadLeft(4, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_MM").ToString().PadLeft(2, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_DD").ToString().PadLeft(2, '0')) != 0)
            {
                CurrentValue = Convert.ToDecimal(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_YY").ToString().PadLeft(4, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_MM").ToString().PadLeft(2, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_DD").ToString().PadLeft(2, '0')).ToString();
                  
            }

            Value = CurrentValue;

        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);


        }
        catch (Exception ex)
        {
            WriteError(ex);

        }



    }
    private DCharacter COMMA = new DCharacter("COMMA", 1);
    private void COMMA_GetValue(ref string Value)
    {

        try
        {
            Value = "~";


        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);


        }
        catch (Exception ex)
        {
            WriteError(ex);

        }



    }
    private DInteger X_NUM_CR = new DInteger("X_NUM_CR", 4);
    private void X_NUM_CR_GetValue(ref decimal Value)
    {

        try
        {
            Value = 13;


        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);


        }
        catch (Exception ex)
        {
            WriteError(ex);

        }



    }
    private DCharacter X_CR = new DCharacter("X_CR", 2);
    private void X_CR_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Characters(X_NUM_CR.Value);


        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);


        }
        catch (Exception ex)
        {
            WriteError(ex);

        }



    }


    private SqlFileObject fleSOLOTITHE;


    #endregion


    #region "Standard Generated Procedures(SOLOTITHE_ONE_1)"


    #region "Automatic Item Initialization(SOLOTITHE_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:05:16 PM

    //#-----------------------------------------
    //# fleF020_DOCTOR_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:05:15 PM
    //#-----------------------------------------
    private void fleF020_DOCTOR_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_NBR", !Fixed, fleF119_DOCTOR_YTD.GetStringValue("DOC_NBR"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF119_DOCTOR_YTD.GetDecimalValue("DOC_OHIP_NBR"));

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
    //# fleF020_DOCTOR_EXTRA_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:05:15 PM
    //#-----------------------------------------
    private void fleF020_DOCTOR_EXTRA_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_DOCTOR_EXTRA.set_SetValue("DOC_NBR", !Fixed, fleF119_DOCTOR_YTD.GetStringValue("DOC_NBR"));
            fleF020_DOCTOR_EXTRA.set_SetValue("FILLER", !Fixed, fleF119_DOCTOR_YTD.GetStringValue("FILLER"));

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


    #region "Transaction Management Procedures(SOLOTITHE_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:05:14 PM

    //#-----------------------------------------
    //# InitializeTransactionObjects Procedure.
    //#-----------------------------------------

    protected override void InitializeTransactionObjects()
    {

        try
        {
            m_cnnTRANS_UPDATE = new SqlConnection(Common.GetSqlConnectionString());
            m_cnnTRANS_UPDATE.Open();
            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            m_cnnQUERY = new SqlConnection(Common.GetSqlConnectionString());


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
        fleF119_DOCTOR_YTD.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_EXTRA.Transaction = m_trnTRANS_UPDATE;
        fleSOLOTITHE.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(SOLOTITHE_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:05:14 PM

    //#-----------------------------------------
    //# InitializeFiles Procedure.
    //#-----------------------------------------

    protected override void InitializeFiles()
    {

        try
        {
            Initialize_TRANS_UPDATE();


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
            fleF119_DOCTOR_YTD.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF020_DOCTOR_EXTRA.Dispose();
            fleSOLOTITHE.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(SOLOTITHE_ONE_1)"


    public void Run()
	{

		try {
			Request("ONE_1");

			while (fleF119_DOCTOR_YTD.QTPForMissing()) {
				// --> GET F119_DOCTOR_YTD <--

				fleF119_DOCTOR_YTD.GetData();
				// --> End GET F119_DOCTOR_YTD <--

				while (fleF020_DOCTOR_MSTR.QTPForMissing("1")) {
					// --> GET F020_DOCTOR_MSTR <--
					m_strWhere = new StringBuilder(" WHERE ");
					m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
					m_strWhere.Append(Common.StringToField(fleF119_DOCTOR_YTD.GetStringValue("DOC_NBR")));

					fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
					// --> End GET F020_DOCTOR_MSTR <--

					while (fleF020_DOCTOR_EXTRA.QTPForMissing("2")) {
						// --> GET F020_DOCTOR_EXTRA <--
						m_strWhere = new StringBuilder(" WHERE ");
						m_strWhere.Append(" ").Append(fleF020_DOCTOR_EXTRA.ElementOwner("DOC_NBR")).Append(" = ");
						m_strWhere.Append(Common.StringToField(fleF119_DOCTOR_YTD.GetStringValue("DOC_NBR")));

						fleF020_DOCTOR_EXTRA.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
						// --> End GET F020_DOCTOR_EXTRA <--


						if (Transaction()) {

							 if (Select_If()) {

								Sort(fleF119_DOCTOR_YTD.GetSortValue("DOC_NBR"));



							}

						}

					}

				}

			}

			while (Sort(fleF119_DOCTOR_YTD, fleF020_DOCTOR_MSTR, fleF020_DOCTOR_EXTRA)) {
				if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "TITHD1") {
					X_TITHD1.Value = X_TITHD1.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
				}
				if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "TITHD2") {
					X_TITHD2.Value = X_TITHD2.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
				}
				if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "TITHD3") {
					X_TITHD3.Value = X_TITHD3.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
				}
				if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "TOTITD") {
					X_TOTITD.Value = X_TOTITD.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
				}
				if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "NONRB") {
					X_NONRB.Value = X_NONRB.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
				}
				if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "NONRBP") {
					X_NONRBP.Value = X_NONRBP.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
				}
				if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "DEPMED") {
					X_DEPMED.Value = X_DEPMED.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
				}
				if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "PAYEFT") {
					X_PAYEFT.Value = X_PAYEFT.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
				}
				if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "ADVOUT") {
					X_ADVOUT.Value = X_ADVOUT.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD") / 100;
				}
				X_TOTREV.Value = X_NONRB.Value + X_NONRBP.Value;
				X_TOTDED.Value = X_TITHD1.Value + X_TITHD2.Value + X_TITHD3.Value + X_DEPMED.Value;

                SubFile(ref m_trnTRANS_UPDATE, ref fleSOLOTITHE, fleF119_DOCTOR_YTD.At("DOC_NBR"), SubFileType.Portable, fleF020_DOCTOR_MSTR, "DOC_NBR", 
                       COMMA, "DOC_NAME", 
                       COMMA, "DOC_INIT1", "DOC_INIT2", "DOC_INIT3", 
                       COMMA, X_NONRB,
                       COMMA, X_NONRBP, 
                       COMMA, X_TOTREV, 
                       COMMA, X_TITHD1, 
                       COMMA, X_TITHD2, 
                       COMMA, X_TITHD3, 
                       COMMA, X_DEPMED, 
                       COMMA, X_TOTDED, 
                       COMMA, X_ADVOUT, 
                       COMMA, TERM_DATE, 
                       COMMA, fleF020_DOCTOR_EXTRA,
                       "DOC_FLAG_PRIMARY");

				Reset(ref X_TITHD1, fleF119_DOCTOR_YTD.At("DOC_NBR"));
				Reset(ref X_TITHD2, fleF119_DOCTOR_YTD.At("DOC_NBR"));
				Reset(ref X_TITHD3, fleF119_DOCTOR_YTD.At("DOC_NBR"));
				Reset(ref X_TOTITD, fleF119_DOCTOR_YTD.At("DOC_NBR"));
				Reset(ref X_NONRB, fleF119_DOCTOR_YTD.At("DOC_NBR"));
				Reset(ref X_NONRBP, fleF119_DOCTOR_YTD.At("DOC_NBR"));
				Reset(ref X_DEPMED, fleF119_DOCTOR_YTD.At("DOC_NBR"));
				Reset(ref X_PAYEFT, fleF119_DOCTOR_YTD.At("DOC_NBR"));
				Reset(ref X_ADVOUT, fleF119_DOCTOR_YTD.At("DOC_NBR"));
				Reset(ref X_TOTREV, fleF119_DOCTOR_YTD.At("DOC_NBR"));
				Reset(ref X_TOTDED, fleF119_DOCTOR_YTD.At("DOC_NBR"));

			}



		} catch (CustomApplicationException ex) {
			WriteError(ex);


		} catch (Exception ex) {
			WriteError(ex);


		} finally {
			EndRequest("ONE_1");

		}

	}




    #endregion


}
//ONE_1




