
using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;
using rma.Cobol.Reports;


public class R123BMP : BaseClassControl
{

    private R123bMP m_R123bMP;

    public R123BMP(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public R123BMP(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
    }

    public R123bMP GetR120(int Level)
    {
        if (m_R123bMP == null)
        {
            m_R123bMP = new R123bMP ("R123bMP", Level);
        }
        else
        {
            //m_R123b.ResetValues();
        }
        return m_R123bMP;
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
            R123bMP r123b = null;
            r123b = new R123bMP(Name, Level);

            r123b.MainLine(Prompt(1).ToString());
            r123b = null;

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

