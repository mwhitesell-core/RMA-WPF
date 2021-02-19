
#region "Screen Comments"

// MODIFICATION HISTORY:
// 1999/JAN/15  S.B.     - Checked for Y2K.


#endregion

using Core.DataAccess.SqlServer;
using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;



public class FIX_SEQ_NBRS : BaseClassControl
{

    private FIX_SEQ_NBRS m_FIX_SEQ_NBRS;

    public FIX_SEQ_NBRS(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;



    }

    public FIX_SEQ_NBRS(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;



    }

    public override void Dispose()
    {
        if ((m_FIX_SEQ_NBRS != null))
        {
            m_FIX_SEQ_NBRS.CloseTransactionObjects();
            m_FIX_SEQ_NBRS = null;
        }
    }

    public FIX_SEQ_NBRS GetFIX_SEQ_NBRS(int Level)
    {
        if (m_FIX_SEQ_NBRS == null)
        {
            m_FIX_SEQ_NBRS = new FIX_SEQ_NBRS("FIX_SEQ_NBRS", Level);
        }
        else
        {
            m_FIX_SEQ_NBRS.ResetValues();
        }
        return m_FIX_SEQ_NBRS;
    }



    #region "Renaissance Architect Migration Services Default Regions"




    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"


    private StringBuilder sb = new StringBuilder("");


    public override bool RunQTP()
    {


        try
        {
            var sql = new StringBuilder("");

            sb.Append(Environment.NewLine).Append(Environment.NewLine);


            sql.Append(" select count (*) ");
            sql.Append(" from[indexed].[F119_DOCTOR_YTD] ytd ");
            sql.Append("  Inner Join[Indexed].[F190_COMP_CODES] comp ");
            sql.Append("  on ytd.COMP_CODE = comp.COMP_CODE ");
            sql.Append("  where(ytd.comp_code <> 'MSG') ");



            SqlDataReader result = SqlHelper.ExecuteReader(Common.GetSqlConnectionString(), CommandType.Text, sql.ToString());


            sb.Append("Request 1: ").Append(Environment.NewLine);

            while (result.Read())
            {
                sb.Append("			Records Read:  ").Append(result[0]).Append(Environment.NewLine);
            }


            sql = new StringBuilder("");
            sql.Append("  UPDATE ");
            sql.Append("  [indexed].[F119_DOCTOR_YTD] ");
            sql.Append("   SET ");
            sql.Append("  process_seq = comp.REPORTING_SEQ, ");
            sql.Append("  comp_code_group = comp.COMP_CODE_GROUP ");
            sql.Append("  FROM ");
            sql.Append("  [indexed].[F119_DOCTOR_YTD] ytd ");
            sql.Append("   INNER JOIN ");
            sql.Append("  [Indexed].[F190_COMP_CODES] comp ");
            sql.Append("  on ");
            sql.Append("   ytd.COMP_CODE = comp.COMP_CODE ");
            sql.Append("   WHERE ");
            sql.Append("  (ytd.comp_code <> 'MSG') ");
       


            var updated = SqlHelper.ExecuteNonQuery(Common.GetSqlConnectionString(), CommandType.Text, sql.ToString());
            sb.Append("			Records Updated:  ").Append(updated).Append(Environment.NewLine);


            sql = new StringBuilder("");
            sql.Append("  select count(*) ");
            sql.Append("  from[indexed].[F110_COMPENSATION]  Compens  ");
            sql.Append("  Inner Join[Indexed].[F190_COMP_CODES]  comp ");
            sql.Append("  on Compens.COMP_CODE = comp.COMP_CODE ");

            result = SqlHelper.ExecuteReader(Common.GetSqlConnectionString(), CommandType.Text, sql.ToString());

            sb.Append(Environment.NewLine).Append(Environment.NewLine);
            sb.Append("Request 2: ").Append(Environment.NewLine);

            while (result.Read())
            {
                sb.Append("			Records Read:  ").Append(result[0]).Append(Environment.NewLine);
            }


            sql = new StringBuilder("");
            sql.Append("  UPDATE ");
            sql.Append("      [indexed].[F110_COMPENSATION] ");
            sql.Append("  SET ");
            sql.Append("      process_seq = comp.PROCESS_SEQ, ");
            sql.Append("      comp_type = comp.COMP_TYPE ");
            sql.Append("    FROM ");
            sql.Append("         [indexed].[F110_COMPENSATION] compens ");
            sql.Append("    INNER JOIN ");
            sql.Append("           [Indexed].[F190_COMP_CODES] comp ");
            sql.Append("   on ");
            sql.Append("          compens.COMP_CODE = comp.COMP_CODE ");

            updated = SqlHelper.ExecuteNonQuery(Common.GetSqlConnectionString(), CommandType.Text, sql.ToString());
            sb.Append("			Records Updated:  ").Append(updated).Append(Environment.NewLine);

            sb.Append(Environment.NewLine).Append(Environment.NewLine);

            Console.Write(sb.ToString());

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

