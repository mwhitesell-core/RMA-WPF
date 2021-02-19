using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class CHECKSUM_IDS : BaseTable
    {
        #region Retrieve

        public ObservableCollection<CHECKSUM_IDS> Collection( int? idmin,
															int? idmax,
															long? nextvalmin,
															long? nextvalmax,
                                                            string sortcolumn,
                                                            string sortdirection,
                                                            bool replaceSearch,
                                                            int skip)
        {
            	var parameters = new SqlParameter[]
				{
					new SqlParameter("minID",idmin),
					new SqlParameter("maxID",idmax),
					new SqlParameter("minNEXTVAL",nextvalmin),
					new SqlParameter("maxNEXTVAL",nextvalmax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_CHECKSUM_IDS_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<CHECKSUM_IDS>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_CHECKSUM_IDS_Search]", parameters);
            var collection = new ObservableCollection<CHECKSUM_IDS>();

            while (Reader.Read())
            {
                collection.Add(new CHECKSUM_IDS
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ID = Convert.ToInt32(Reader["ID"]),
					NEXTVAL = Reader["NEXTVAL"].ToString(),

					_originalId = Convert.ToInt32(Reader["ID"]),
					_originalNextval = Reader["NEXTVAL"].ToString(),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public CHECKSUM_IDS Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<CHECKSUM_IDS> Collection(ObservableCollection<CHECKSUM_IDS>
                                                               checksumIds = null)
        {
            if (IsSameSearch() && checksumIds != null)
            {
                return checksumIds;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<CHECKSUM_IDS>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ID",WhereId),
					new SqlParameter("NEXTVAL",WhereNextval),
				};

			Reader = CoreReader("[INDEXED].[sp_CHECKSUM_IDS_Match]", parameters);
            var collection = new ObservableCollection<CHECKSUM_IDS>();

            while (Reader.Read())
            {
                collection.Add(new CHECKSUM_IDS
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ID = Convert.ToInt32(Reader["ID"]),
					NEXTVAL = Reader["NEXTVAL"].ToString(),

					_whereId = WhereId,
					_whereNextval = WhereNextval,

					_originalId = Convert.ToInt32(Reader["ID"]),
					_originalNextval = Reader["NEXTVAL"].ToString(),

                    RecordState = State.UnChanged
                });
            }

					_whereId = WhereId;
					_whereNextval = WhereNextval;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereId == null 
				&& WhereNextval == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereId ==  _whereId
				&& WhereNextval ==  _whereNextval
;
        }

        private bool ClearSearch()
        {
			WhereId = null; 
			WhereNextval = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private int _ID;
		private string _NEXTVAL;

		public int ID
		{
			get { return _ID; }
			set
			{
				if (_ID != value)
				{
					_ID = value;
					ChangeState();
				}
			}
		}
		public string NEXTVAL
		{
			get { return _NEXTVAL; }
			set
			{
				if (_NEXTVAL != value)
				{
					_NEXTVAL = value;
					ChangeState();
				}
			}
		}


        #endregion

        #region Where

		public int? WhereId { get; set; }
		private int? _whereId;
		public string WhereNextval { get; set; }
		private string _whereNextval;


        #endregion

        #region Original

		private int _originalId;
		private string _originalNextval;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ID = _originalId;
			NEXTVAL = _originalNextval;

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
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_CHECKSUM_IDS_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_CHECKSUM_IDS_Purge]");
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
						new SqlParameter("ID", SqlNull(ID))
					};
					Reader = CoreReader("[INDEXED].[sp_CHECKSUM_IDS_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ID = Convert.ToInt32(Reader["ID"]);
						NEXTVAL = Reader["NEXTVAL"].ToString();
						_originalId = Convert.ToInt32(Reader["ID"]);
						_originalNextval = Reader["NEXTVAL"].ToString();
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ID", SqlNull(ID)),
						new SqlParameter("NEXTVAL", SqlNull(NEXTVAL))
					};
					Reader = CoreReader("[INDEXED].[sp_CHECKSUM_IDS_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ID = Convert.ToInt32(Reader["ID"]);
						NEXTVAL = Reader["NEXTVAL"].ToString();
						_originalId = Convert.ToInt32(Reader["ID"]);
						_originalNextval = Reader["NEXTVAL"].ToString();
					}
                   
                    break;
            }
	    CloseConnection();
	     
            RecordState = State.UnChanged;
        }

        #endregion

      
    }
}