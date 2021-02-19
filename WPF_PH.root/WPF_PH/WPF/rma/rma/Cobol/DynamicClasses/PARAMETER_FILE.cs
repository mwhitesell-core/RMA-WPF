using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class PARAMETER_FILE : BaseTable
    {
        #region Retrieve

        public ObservableCollection<PARAMETER_FILE> Collection( Guid? rowid,
															string clmhdr_pat_key_type,
															string clmhdr_pat_key_data,
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
					new SqlParameter("CLMHDR_PAT_KEY_TYPE",clmhdr_pat_key_type),
					new SqlParameter("CLMHDR_PAT_KEY_DATA",clmhdr_pat_key_data),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[SEQUENTIAL].[sp_PARAMETER_FILE_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<PARAMETER_FILE>();
				}

            }

            Reader = CoreReader("[SEQUENTIAL].[sp_PARAMETER_FILE_Search]", parameters);
            var collection = new ObservableCollection<PARAMETER_FILE>();

            while (Reader.Read())
            {
                collection.Add(new PARAMETER_FILE
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLMHDR_PAT_KEY_TYPE = Reader["CLMHDR_PAT_KEY_TYPE"].ToString(),
					CLMHDR_PAT_KEY_DATA = Reader["CLMHDR_PAT_KEY_DATA"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClmhdr_pat_key_type = Reader["CLMHDR_PAT_KEY_TYPE"].ToString(),
					_originalClmhdr_pat_key_data = Reader["CLMHDR_PAT_KEY_DATA"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public PARAMETER_FILE Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<PARAMETER_FILE> Collection(ObservableCollection<PARAMETER_FILE>
                                                               parameterFile = null)
        {
            if (IsSameSearch() && parameterFile != null)
            {
                return parameterFile;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<PARAMETER_FILE>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CLMHDR_PAT_KEY_TYPE",WhereClmhdr_pat_key_type),
					new SqlParameter("CLMHDR_PAT_KEY_DATA",WhereClmhdr_pat_key_data),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[SEQUENTIAL].[sp_PARAMETER_FILE_Match]", parameters);
            var collection = new ObservableCollection<PARAMETER_FILE>();

            while (Reader.Read())
            {
                collection.Add(new PARAMETER_FILE
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLMHDR_PAT_KEY_TYPE = Reader["CLMHDR_PAT_KEY_TYPE"].ToString(),
					CLMHDR_PAT_KEY_DATA = Reader["CLMHDR_PAT_KEY_DATA"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereClmhdr_pat_key_type = WhereClmhdr_pat_key_type,
					_whereClmhdr_pat_key_data = WhereClmhdr_pat_key_data,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClmhdr_pat_key_type = Reader["CLMHDR_PAT_KEY_TYPE"].ToString(),
					_originalClmhdr_pat_key_data = Reader["CLMHDR_PAT_KEY_DATA"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereClmhdr_pat_key_type = WhereClmhdr_pat_key_type;
					_whereClmhdr_pat_key_data = WhereClmhdr_pat_key_data;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereClmhdr_pat_key_type == null 
				&& WhereClmhdr_pat_key_data == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereClmhdr_pat_key_type ==  _whereClmhdr_pat_key_type
				&& WhereClmhdr_pat_key_data ==  _whereClmhdr_pat_key_data
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereClmhdr_pat_key_type = null; 
			WhereClmhdr_pat_key_data = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _CLMHDR_PAT_KEY_TYPE;
		private string _CLMHDR_PAT_KEY_DATA;
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
		public string CLMHDR_PAT_KEY_TYPE
		{
			get { return _CLMHDR_PAT_KEY_TYPE; }
			set
			{
				if (_CLMHDR_PAT_KEY_TYPE != value)
				{
					_CLMHDR_PAT_KEY_TYPE = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_PAT_KEY_DATA
		{
			get { return _CLMHDR_PAT_KEY_DATA; }
			set
			{
				if (_CLMHDR_PAT_KEY_DATA != value)
				{
					_CLMHDR_PAT_KEY_DATA = value;
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
		public string WhereClmhdr_pat_key_type { get; set; }
		private string _whereClmhdr_pat_key_type;
		public string WhereClmhdr_pat_key_data { get; set; }
		private string _whereClmhdr_pat_key_data;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalClmhdr_pat_key_type;
		private string _originalClmhdr_pat_key_data;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			CLMHDR_PAT_KEY_TYPE = _originalClmhdr_pat_key_type;
			CLMHDR_PAT_KEY_DATA = _originalClmhdr_pat_key_data;
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
					new SqlParameter("ROWID",ROWID)
				};
			RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_PARAMETER_FILE_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_PARAMETER_FILE_Purge]");
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
						new SqlParameter("CLMHDR_PAT_KEY_TYPE", SqlNull(CLMHDR_PAT_KEY_TYPE)),
						new SqlParameter("CLMHDR_PAT_KEY_DATA", SqlNull(CLMHDR_PAT_KEY_DATA)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_PARAMETER_FILE_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLMHDR_PAT_KEY_TYPE = Reader["CLMHDR_PAT_KEY_TYPE"].ToString();
						CLMHDR_PAT_KEY_DATA = Reader["CLMHDR_PAT_KEY_DATA"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClmhdr_pat_key_type = Reader["CLMHDR_PAT_KEY_TYPE"].ToString();
						_originalClmhdr_pat_key_data = Reader["CLMHDR_PAT_KEY_DATA"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("CLMHDR_PAT_KEY_TYPE", SqlNull(CLMHDR_PAT_KEY_TYPE)),
						new SqlParameter("CLMHDR_PAT_KEY_DATA", SqlNull(CLMHDR_PAT_KEY_DATA)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_PARAMETER_FILE_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLMHDR_PAT_KEY_TYPE = Reader["CLMHDR_PAT_KEY_TYPE"].ToString();
						CLMHDR_PAT_KEY_DATA = Reader["CLMHDR_PAT_KEY_DATA"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClmhdr_pat_key_type = Reader["CLMHDR_PAT_KEY_TYPE"].ToString();
						_originalClmhdr_pat_key_data = Reader["CLMHDR_PAT_KEY_DATA"].ToString();
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