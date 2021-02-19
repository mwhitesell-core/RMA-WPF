using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class RUN_DATE : BaseTable
    {
        #region Retrieve

        public ObservableCollection<RUN_DATE> Collection( long? date_yymmmin,
															long? date_yymmmax,
                                                            string sortcolumn,
                                                            string sortdirection,
                                                            bool replaceSearch,
                                                            int skip)
        {
            	var parameters = new SqlParameter[]
				{
					new SqlParameter("minDATE_YYMM",date_yymmmin),
					new SqlParameter("maxDATE_YYMM",date_yymmmax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[DIRECT].[sp_RUN_DATE_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<RUN_DATE>();
				}

            }

            Reader = CoreReader("[DIRECT].[sp_RUN_DATE_Search]", parameters);
            var collection = new ObservableCollection<RUN_DATE>();

            while (Reader.Read())
            {
                collection.Add(new RUN_DATE
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					DATE_YYMM = Convert.ToInt32(Reader["DATE_YYMM"]),

					_originalDate_yymm = Convert.ToInt32(Reader["DATE_YYMM"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public RUN_DATE Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<RUN_DATE> Collection(ObservableCollection<RUN_DATE>
                                                               runDate = null)
        {
            if (IsSameSearch() && runDate != null)
            {
                return runDate;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<RUN_DATE>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("DATE_YYMM",WhereDate_yymm),
				};

			Reader = CoreReader("[DIRECT].[sp_RUN_DATE_Match]", parameters);
            var collection = new ObservableCollection<RUN_DATE>();

            while (Reader.Read())
            {
                collection.Add(new RUN_DATE
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					DATE_YYMM = Convert.ToInt32(Reader["DATE_YYMM"]),

					_whereDate_yymm = WhereDate_yymm,

					_originalDate_yymm = Convert.ToInt32(Reader["DATE_YYMM"]),

                    RecordState = State.UnChanged
                });
            }

					_whereDate_yymm = WhereDate_yymm;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereDate_yymm == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereDate_yymm ==  _whereDate_yymm
;
        }

        private bool ClearSearch()
        {
			WhereDate_yymm = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private int _DATE_YYMM;

		public int DATE_YYMM
		{
			get { return _DATE_YYMM; }
			set
			{
				if (_DATE_YYMM != value)
				{
					_DATE_YYMM = value;
					ChangeState();
				}
			}
		}


        #endregion

        #region Where

		public string WhereDate_yymm { get; set; }
		private string _whereDate_yymm;


        #endregion

        #region Original

		private int _originalDate_yymm;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			DATE_YYMM = _originalDate_yymm;

            RecordState = State.UnChanged;

            return true;
        }


        public bool Delete()
        {
			int RowsAffected = 0;
			var parameters = new SqlParameter[]
				{
					new SqlParameter("RowCheckSum",RowCheckSum),
				};
			RowsAffected = CoreExecuteNonQuery("[DIRECT].[sp_RUN_DATE_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[DIRECT].[sp_RUN_DATE_Purge]");
		    CloseConnection();
		    return true;
		}


        #endregion

        #region Submit

        public void Submit()
        {
            int RowsAffected = 0;
            SqlParameter[] parameters; 
            switch (RecordState)
            {
                case State.Adding:
                case State.Added:
					parameters = new SqlParameter[]
					{
						new SqlParameter("DATE_YYMM", SqlNull(DATE_YYMM))
					};
					Reader = CoreReader("[DIRECT].[sp_RUN_DATE_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						DATE_YYMM = Convert.ToInt32(Reader["DATE_YYMM"]);
						_originalDate_yymm = Convert.ToInt32(Reader["DATE_YYMM"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("DATE_YYMM", SqlNull(DATE_YYMM))
					};
					Reader = CoreReader("[DIRECT].[sp_RUN_DATE_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						DATE_YYMM = Convert.ToInt32(Reader["DATE_YYMM"]);
						_originalDate_yymm = Convert.ToInt32(Reader["DATE_YYMM"]);
					}
                   
                    break;
            }
	    CloseConnection();
	     
            RecordState = State.UnChanged;
        }

        #endregion

      
    }
}