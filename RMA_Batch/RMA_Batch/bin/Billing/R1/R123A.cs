
using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;
using rma.Cobol.Reports;


public class R123A : BaseClassControl
{

    private R123a m_R123a;

    public R123A(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public R123A(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
    }

    public R123a GetR120(int Level)
    {
        if (m_R123a == null)
        {
            m_R123a = new R123a("R123a", Level);
        }
        else
        {
            //m_R123b.ResetValues();
        }
        return m_R123a;
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
            R123a r123a = null;
            r123a = new R123a(Name, Level);            
        
            r123a.MainLine(wsSundry: Prompt(1).ToString(),
                         wsVersionNbr: Convert.ToInt32(Prompt(2)),
                         wsTapeYear: Convert.ToInt32(Prompt(3)),
                         wsTapeDay: Convert.ToInt32(Prompt(4)),
                         wsFundYr: Convert.ToInt32(Prompt(5)),
                         wsFundDay: Convert.ToInt32(Prompt(6)),
                         wsDateCheckOption: Prompt(7).ToString(),
                         yearEndOpton: Prompt(8).ToString(),
                         yearEndLabel: Prompt(9).ToString(),
                         selClinic: Prompt(10).ToString(),
                         wsChqYr: Convert.ToInt32(Prompt(11)),
                         wsChqMth: Convert.ToInt32(Prompt(12)),
                         wsChqDay: Convert.ToInt32(Prompt(13)),
                         selOK: Prompt(14).ToString());

            r123a = null;
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


