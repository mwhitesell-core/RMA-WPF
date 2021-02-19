using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F098_EQUIV_OMA_CODE_MSTR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F098_EQUIV_OMA_CODE_MSTR> Collection( Guid? rowid,
															string orig_oma_code,
															string equiv_oma_code,
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
					new SqlParameter("ORIG_OMA_CODE",orig_oma_code),
					new SqlParameter("EQUIV_OMA_CODE",equiv_oma_code),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F098_EQUIV_OMA_CODE_MSTR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F098_EQUIV_OMA_CODE_MSTR>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F098_EQUIV_OMA_CODE_MSTR_Search]", parameters);
            var collection = new ObservableCollection<F098_EQUIV_OMA_CODE_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F098_EQUIV_OMA_CODE_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					ORIG_OMA_CODE = Reader["ORIG_OMA_CODE"].ToString(),
					EQUIV_OMA_CODE = Reader["EQUIV_OMA_CODE"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalOrig_oma_code = Reader["ORIG_OMA_CODE"].ToString(),
					_originalEquiv_oma_code = Reader["EQUIV_OMA_CODE"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F098_EQUIV_OMA_CODE_MSTR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F098_EQUIV_OMA_CODE_MSTR> Collection(ObservableCollection<F098_EQUIV_OMA_CODE_MSTR>
                                                               f098EquivOmaCodeMstr = null)
        {
            if (IsSameSearch() && f098EquivOmaCodeMstr != null)
            {
                return f098EquivOmaCodeMstr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F098_EQUIV_OMA_CODE_MSTR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("ORIG_OMA_CODE",WhereOrig_oma_code),
					new SqlParameter("EQUIV_OMA_CODE",WhereEquiv_oma_code),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F098_EQUIV_OMA_CODE_MSTR_Match]", parameters);
            var collection = new ObservableCollection<F098_EQUIV_OMA_CODE_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F098_EQUIV_OMA_CODE_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					ORIG_OMA_CODE = Reader["ORIG_OMA_CODE"].ToString(),
					EQUIV_OMA_CODE = Reader["EQUIV_OMA_CODE"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereOrig_oma_code = WhereOrig_oma_code,
					_whereEquiv_oma_code = WhereEquiv_oma_code,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalOrig_oma_code = Reader["ORIG_OMA_CODE"].ToString(),
					_originalEquiv_oma_code = Reader["EQUIV_OMA_CODE"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereOrig_oma_code = WhereOrig_oma_code;
					_whereEquiv_oma_code = WhereEquiv_oma_code;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereOrig_oma_code == null 
				&& WhereEquiv_oma_code == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereOrig_oma_code ==  _whereOrig_oma_code
				&& WhereEquiv_oma_code ==  _whereEquiv_oma_code
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereOrig_oma_code = null; 
			WhereEquiv_oma_code = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _ORIG_OMA_CODE;
		private string _EQUIV_OMA_CODE;
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
		public string ORIG_OMA_CODE
		{
			get { return _ORIG_OMA_CODE; }
			set
			{
				if (_ORIG_OMA_CODE != value)
				{
					_ORIG_OMA_CODE = value;
					ChangeState();
				}
			}
		}
		public string EQUIV_OMA_CODE
		{
			get { return _EQUIV_OMA_CODE; }
			set
			{
				if (_EQUIV_OMA_CODE != value)
				{
					_EQUIV_OMA_CODE = value;
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
		public string WhereOrig_oma_code { get; set; }
		private string _whereOrig_oma_code;
		public string WhereEquiv_oma_code { get; set; }
		private string _whereEquiv_oma_code;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalOrig_oma_code;
		private string _originalEquiv_oma_code;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			ORIG_OMA_CODE = _originalOrig_oma_code;
			EQUIV_OMA_CODE = _originalEquiv_oma_code;
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
					new SqlParameter("ORIG_OMA_CODE",ORIG_OMA_CODE)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F098_EQUIV_OMA_CODE_MSTR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F098_EQUIV_OMA_CODE_MSTR_Purge]");
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
						new SqlParameter("ORIG_OMA_CODE", SqlNull(ORIG_OMA_CODE)),
						new SqlParameter("EQUIV_OMA_CODE", SqlNull(EQUIV_OMA_CODE)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F098_EQUIV_OMA_CODE_MSTR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						ORIG_OMA_CODE = Reader["ORIG_OMA_CODE"].ToString();
						EQUIV_OMA_CODE = Reader["EQUIV_OMA_CODE"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalOrig_oma_code = Reader["ORIG_OMA_CODE"].ToString();
						_originalEquiv_oma_code = Reader["EQUIV_OMA_CODE"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("ORIG_OMA_CODE", SqlNull(ORIG_OMA_CODE)),
						new SqlParameter("EQUIV_OMA_CODE", SqlNull(EQUIV_OMA_CODE)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F098_EQUIV_OMA_CODE_MSTR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						ORIG_OMA_CODE = Reader["ORIG_OMA_CODE"].ToString();
						EQUIV_OMA_CODE = Reader["EQUIV_OMA_CODE"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalOrig_oma_code = Reader["ORIG_OMA_CODE"].ToString();
						_originalEquiv_oma_code = Reader["EQUIV_OMA_CODE"].ToString();
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