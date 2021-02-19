using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F072_CLIENT_MSTR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F072_CLIENT_MSTR> Collection( Guid? rowid,
															string client_id,
															decimal? operator_nbrmin,
															decimal? operator_nbrmax,
															string description,
															int? checksum_valuemin,
															int? checksum_valuemax,
                                                            string sortcolumn,
                                                            string sortdirection,
                                                            bool replaceSearch,
                                                            int skip)
        {
            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",rowid),
					new SqlParameter("CLIENT_ID",client_id),
					new SqlParameter("minOPERATOR_NBR",operator_nbrmin),
					new SqlParameter("maxOPERATOR_NBR",operator_nbrmax),
					new SqlParameter("DESCRIPTION",description),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F072_CLIENT_MSTR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F072_CLIENT_MSTR>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F072_CLIENT_MSTR_Search]", parameters);
            var collection = new ObservableCollection<F072_CLIENT_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F072_CLIENT_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLIENT_ID = Reader["CLIENT_ID"].ToString(),
					OPERATOR_NBR = ConvertDEC(Reader["OPERATOR_NBR"]),
					DESCRIPTION = Reader["DESCRIPTION"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClient_id = Reader["CLIENT_ID"].ToString(),
					_originalOperator_nbr = ConvertDEC(Reader["OPERATOR_NBR"]),
					_originalDescription = Reader["DESCRIPTION"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F072_CLIENT_MSTR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F072_CLIENT_MSTR> Collection(ObservableCollection<F072_CLIENT_MSTR>
                                                               f072ClientMstr = null)
        {
            if (IsSameSearch() && f072ClientMstr != null)
            {
                return f072ClientMstr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F072_CLIENT_MSTR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CLIENT_ID",WhereClient_id),
					new SqlParameter("OPERATOR_NBR",WhereOperator_nbr),
					new SqlParameter("DESCRIPTION",WhereDescription),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F072_CLIENT_MSTR_Match]", parameters);
            var collection = new ObservableCollection<F072_CLIENT_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F072_CLIENT_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLIENT_ID = Reader["CLIENT_ID"].ToString(),
					OPERATOR_NBR = ConvertDEC(Reader["OPERATOR_NBR"]),
					DESCRIPTION = Reader["DESCRIPTION"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereClient_id = WhereClient_id,
					_whereOperator_nbr = WhereOperator_nbr,
					_whereDescription = WhereDescription,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClient_id = Reader["CLIENT_ID"].ToString(),
					_originalOperator_nbr = ConvertDEC(Reader["OPERATOR_NBR"]),
					_originalDescription = Reader["DESCRIPTION"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereClient_id = WhereClient_id;
					_whereOperator_nbr = WhereOperator_nbr;
					_whereDescription = WhereDescription;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereClient_id == null 
				&& WhereOperator_nbr == null 
				&& WhereDescription == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereClient_id ==  _whereClient_id
				&& WhereOperator_nbr ==  _whereOperator_nbr
				&& WhereDescription ==  _whereDescription
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereClient_id = null; 
			WhereOperator_nbr = null; 
			WhereDescription = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _CLIENT_ID;
		private decimal? _OPERATOR_NBR;
		private string _DESCRIPTION;
		private int? _CHECKSUM_VALUE;

		public Guid ROWID
		{
			get { return _ROWID; }
			set
			{
				if (_ROWID != value)
				{
					_ROWID = value;
					ChangeState();
				}
			}
		}
		public string CLIENT_ID
		{
			get { return _CLIENT_ID; }
			set
			{
				if (_CLIENT_ID != value)
				{
					_CLIENT_ID = value;
					ChangeState();
				}
			}
		}
		public decimal? OPERATOR_NBR
		{
			get { return _OPERATOR_NBR; }
			set
			{
				if (_OPERATOR_NBR != value)
				{
					_OPERATOR_NBR = value;
					ChangeState();
				}
			}
		}
		public string DESCRIPTION
		{
			get { return _DESCRIPTION; }
			set
			{
				if (_DESCRIPTION != value)
				{
					_DESCRIPTION = value;
					ChangeState();
				}
			}
		}
		public int? CHECKSUM_VALUE
		{
			get { return _CHECKSUM_VALUE; }
			set
			{
				if (_CHECKSUM_VALUE != value)
				{
					_CHECKSUM_VALUE = value;
					ChangeState();
				}
			}
		}


        #endregion

        #region Where

		public Guid? WhereRowid { get; set; }
		private Guid? _whereRowid;
		public string WhereClient_id { get; set; }
		private string _whereClient_id;
		public decimal? WhereOperator_nbr { get; set; }
		private decimal? _whereOperator_nbr;
		public string WhereDescription { get; set; }
		private string _whereDescription;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalClient_id;
		private decimal? _originalOperator_nbr;
		private string _originalDescription;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			CLIENT_ID = _originalClient_id;
			OPERATOR_NBR = _originalOperator_nbr;
			DESCRIPTION = _originalDescription;
			CHECKSUM_VALUE = _originalChecksum_value;

            RecordState = State.UnChanged;

            return true;
        }


        public bool Delete()
        {
			int RowsAffected = 0;
			var parameters = new SqlParameter[]
				{
					new SqlParameter("RowCheckSum",RowCheckSum),
					new SqlParameter("ROWID",ROWID),
					new SqlParameter("CLIENT_ID",CLIENT_ID)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F072_CLIENT_MSTR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F072_CLIENT_MSTR_Purge]");
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
						new SqlParameter("CLIENT_ID", SqlNull(CLIENT_ID)),
						new SqlParameter("OPERATOR_NBR", SqlNull(OPERATOR_NBR)),
						new SqlParameter("DESCRIPTION", SqlNull(DESCRIPTION)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F072_CLIENT_MSTR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLIENT_ID = Reader["CLIENT_ID"].ToString();
						OPERATOR_NBR = ConvertDEC(Reader["OPERATOR_NBR"]);
						DESCRIPTION = Reader["DESCRIPTION"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClient_id = Reader["CLIENT_ID"].ToString();
						_originalOperator_nbr = ConvertDEC(Reader["OPERATOR_NBR"]);
						_originalDescription = Reader["DESCRIPTION"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("CLIENT_ID", SqlNull(CLIENT_ID)),
						new SqlParameter("OPERATOR_NBR", SqlNull(OPERATOR_NBR)),
						new SqlParameter("DESCRIPTION", SqlNull(DESCRIPTION)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F072_CLIENT_MSTR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLIENT_ID = Reader["CLIENT_ID"].ToString();
						OPERATOR_NBR = ConvertDEC(Reader["OPERATOR_NBR"]);
						DESCRIPTION = Reader["DESCRIPTION"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClient_id = Reader["CLIENT_ID"].ToString();
						_originalOperator_nbr = ConvertDEC(Reader["OPERATOR_NBR"]);
						_originalDescription = Reader["DESCRIPTION"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                   
                    break;
            }
	    CloseConnection();
	     
            RecordState = State.UnChanged;
        }

        #endregion

      
    }
}