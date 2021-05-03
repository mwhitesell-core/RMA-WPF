
Imports System.ComponentModel
Imports System.Configuration
Imports System.IO
Imports System.Text
Imports System.Web
Imports System.Web.Caching
Imports System.Web.SessionState
Imports System.Xml
Imports Core.ExceptionManagement
Imports Core.Framework
Imports Core.Framework.Core.Framework
Imports Core.Globalization.Core.Globalization
Imports Core.Windows.UI.Core.Windows
Imports Core.Windows.UI.Core.Windows.UI
Imports System.Data.OracleClient
Imports System.Data.SqlClient
Imports Core.DataAccess.Oracle
Imports Core.DataAccess.SqlServer


Namespace Core.Windows
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: BaseClassWeb
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' <summary>
    '''     Summary of BaseClassWeb.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Campbell]	7/5/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Class BaseClassControl 'MenuOptionWeb
        Inherits BaseClass 'BaseMenuOption

        Dim g_recordCount As Integer = 0

        <EditorBrowsable(EditorBrowsableState.Advanced)> Private ReadOnly _
            m_LogFile As StringBuilder = New StringBuilder("")

        <EditorBrowsable(EditorBrowsableState.Advanced)> Private ReadOnly _
            m_ClassParameters As StringBuilder = New StringBuilder("")

        <EditorBrowsable(EditorBrowsableState.Advanced)> Private ReadOnly _
            m_GlobalParameters As StringBuilder = New StringBuilder("")

        <EditorBrowsable(EditorBrowsableState.Advanced)> Private ReadOnly _
            m_Error As StringBuilder = New StringBuilder("")

        <EditorBrowsable(EditorBrowsableState.Advanced)> Public Subtotal_Files As ArrayList = New ArrayList
        <EditorBrowsable(EditorBrowsableState.Advanced)> Public InializesFile As ArrayList = New ArrayList

        <EditorBrowsable(EditorBrowsableState.Advanced)> Public m_SortOrder As String

        <EditorBrowsable(EditorBrowsableState.Advanced)> Public m_intParrallelOccurrence As Integer = 0

        <EditorBrowsable(EditorBrowsableState.Advanced)> Public m_blnNoRecords As Boolean

        <EditorBrowsable(EditorBrowsableState.Advanced)> Public m_strNoRecordsLevel As String = String.Empty

        <EditorBrowsable(EditorBrowsableState.Advanced)> Public m_SortFileOrder As String

        <EditorBrowsable(EditorBrowsableState.Advanced)> Public m_intSortOrder As Integer = 0

        <EditorBrowsable(EditorBrowsableState.Advanced)> Public dtSortOrder As New DataTable

        <EditorBrowsable(EditorBrowsableState.Advanced)> Public arrSortOrder As New ArrayList

        <EditorBrowsable(EditorBrowsableState.Advanced)> Public dtSorted As New DataTable

        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected strSortOrder As String = String.Empty

        <EditorBrowsable(EditorBrowsableState.Advanced)> Friend arrFileInRequests As ArrayList = New ArrayList

        <EditorBrowsable(EditorBrowsableState.Advanced)> Friend arrFilesProcessed As ArrayList = New ArrayList

        <EditorBrowsable(EditorBrowsableState.Advanced)> Friend arrSubFiles As ArrayList = New ArrayList

        Friend arrReadInRequests As ArrayList = New ArrayList

        <EditorBrowsable(EditorBrowsableState.Advanced)> Friend m_hsFileInOutput As SortedList = New SortedList

        <EditorBrowsable(EditorBrowsableState.Advanced)> Friend m_hsFileInRequests As Hashtable = New Hashtable

        <EditorBrowsable(EditorBrowsableState.Advanced)> Friend m_hsFilesProcessed As Hashtable = New Hashtable

        <EditorBrowsable(EditorBrowsableState.Advanced)> Public intSorted As Integer = 0

        <EditorBrowsable(EditorBrowsableState.Advanced)> Public QTPRequest As Boolean = False

        <EditorBrowsable(EditorBrowsableState.Advanced)> Public blnQTPSubFile As Boolean = False

        <EditorBrowsable(EditorBrowsableState.Advanced)> Private blnAppendSubFile As Boolean = False

        <EditorBrowsable(EditorBrowsableState.Advanced)> Public strFileNoRecords As String = String.Empty

        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected strFileSortName As String = String.Empty

        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_reportsPath As String = String.Empty

        <EditorBrowsable(EditorBrowsableState.Advanced)> Private m_strUserID As String

        Public hsSubConverted As Hashtable = New Hashtable
        Private NoDataSubfile As ArrayList = New ArrayList

        Private m_strDEFAULT_BATCH_FILE_DIRECTORY As String = ""

        Private hsAverage As Hashtable = New Hashtable
        Private hsAverageCount As Hashtable = New Hashtable
        Private blInaverage = False
        Private blnOver5000Records = False

        Private hsMaximum As Hashtable = New Hashtable
        Private hsMinimum As Hashtable = New Hashtable

        Private blnIsInInitialize As Boolean = False

        Private strStartParrallel As String = String.Empty
        Private intTransactions As Integer = 0
        Private ReadOnly m_blnDidLock As Boolean = False
        Private NoSubFileData As Boolean = False
        Private ReadOnly m_strUniqueSessionID As String

        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property UniqueSessionID As String
            Get
                Return m_strUniqueSessionID
            End Get
        End Property

        Private intTotalSkippedRecords As Integer
        Public Property TotalSkippedRecords() As Integer

            Get
                Return intTotalSkippedRecords
            End Get
            Set(ByVal Value As Integer)
                intTotalSkippedRecords = Value
            End Set
        End Property

        Private intRecordsProcessed As Integer
        Public Property RecordsProcessed() As Integer

            Get
                Return intRecordsProcessed
            End Get
            Set(ByVal Value As Integer)
                intRecordsProcessed = Value
            End Set
        End Property


        Public ReadOnly Property IsAxiant As Boolean
            Get
                If IsNothing(ConfigurationManager.AppSettings("Axiant")) Then
                    Return False
                End If

                Return ConfigurationManager.AppSettings("Axiant").ToUpper() = "TRUE"
            End Get
        End Property

        Public Property CancelQTPs As Boolean
            Get
                Return Session("CancelQTPs")
            End Get
            Set(value As Boolean)
                Session("CancelQTPs") = value
            End Set
        End Property
        Private CurrentQTPCancel As Boolean

        Public m_hsFileWhere As New Hashtable
        Public m_blnUseMemory As Boolean = False

        Public arrTempTables As ArrayList
        Public WhereElementColumn As String = ""
        Public m_blnIsAt As Boolean = False
        Protected dcSysDate As Decimal = 0
        Protected dcSysTime As Decimal = 0
        Protected dcSysDateTime As Decimal = 0
        Protected arrKeepFile As New ArrayList
        Public blnDeleteSubFile As Boolean = False
        Public blnDeletedSubFile As Boolean = False
        Public blnHasSort As Boolean = False
        Public blnHasBeenSort As Boolean = False
        Public blnHasRunSubfile As Boolean = False
        Private blnAtInitial As BooleanTypes = BooleanTypes.NotSet
        Private Shared m_strParmPrompts As String
        Protected Friend Shared m_htParmPrompts As Hashtable
        Public alSubTempText As New ArrayList
        Public intFirstFileRecordCount As Integer = 0
        Private intSortCount As Integer = 0
        Public blnIsInSelectIf As Boolean = False
        Public blnGlobalUseTableSelectIf As BooleanTypes = BooleanTypes.NotSet
        Public intFirstRecordCount As Integer = 0
        Public intFirstOverrideOccurs As Integer = 0
#If TARGET_DB = "INFORMIX" Then
        Public m_arrSelectifColumn As ArrayList
        Public cnnQUERY As IfxConnection
        Public cnnTRANS_UPDATE As IfxConnection
        Public trnTRANS_UPDATE As IfxTransaction

#Else
        Public m_arrSelectifColumn As New ArrayList
#End If
        Public blnGotSQL As BooleanTypes = BooleanTypes.NotSet
        Public hsSQL As New Hashtable
        Public hsSQLEnum As New Hashtable
        Public strFromTables As String = ""
        Public blnOneFile As Boolean = True
        Public blnRunForMissing As Boolean = False
        Public m_dtbDataTable As DataTable
        Public m_blnGetSQL As Boolean = False
        Public m_strQTPOrderBy As String = ""
        Public m_blnInChoose As Boolean = False
        Private intRecordLimit As Integer = 0
        Private hsSubFileSize As Hashtable
        Private ReadOnly m_htLockTimes As New Hashtable
        Protected Friend Shared HasParallel As Boolean = False
        Public blnTrans As Boolean = False
        Private m_fleJoinFile As IFileObject
        Private m_strJoinColumn As String = String.Empty
        Private m_strSqlValDB As String = String.Empty
        Private m_strDelimiter As String = "§"  'ALT 0167

        '-----------------------------------------------------------------------------------------------------------
        ' In order to handle OldValue, and the fact that PowerHouse changes any reference to the
        ' item on which the EDIT procedure is executing to either FIELDTEXT or FIELDVALUE, we are
        ' storing OLDVALUE in this array prior to calling the edit procedure.  We then assign FIELDTEXT/FIELDVALUE
        ' to the record buffer so that we don't have to worry about changing the item to FIELDTEXT/FIELDVALUE.
        ' OldValue will be stored using the following structure: ITEM in position 0
        '                                                        FIELDTEXT in Position 1
        '                                                        FIELDVALUE in Position 2
        ''' --- sOldValue ----------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of sOldValue.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Structure sOldValue
            ''' --- Field --------------------------------------------------------------
            ''' <exclude />
            ''' <summary>
            '''     Summary of Field.
            ''' </summary>
            ''' <remarks>
            ''' </remarks>
            ''' <history>
            '''     [Campbell]	7/4/2005	Created
            ''' </history>
            ''' --- End of Comments ----------------------------------------------------
            Dim Field As String

            ''' --- FieldText ----------------------------------------------------------
            ''' <exclude />
            ''' <summary>
            '''     Contains the most recent value in the field.
            ''' </summary>
            ''' <remarks>
            ''' </remarks>
            ''' <history>
            '''     [Campbell]	7/4/2005	Created
            ''' </history>
            ''' --- End of Comments ----------------------------------------------------
            Dim FieldText As String

            ''' --- FieldValue ---------------------------------------------------------
            ''' <exclude />
            ''' <summary>
            '''     Contains the most recent numeric or date value in the field.
            ''' </summary>
            ''' <remarks>
            ''' </remarks>
            ''' <history>
            '''     [Campbell]	7/4/2005	Created
            ''' </history>
            ''' --- End of Comments ----------------------------------------------------
            Dim FieldValue As Decimal
        End Structure

        ''' --- m_OldValue ---------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of m_OldValue.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private m_OldValue As sOldValue _
        ' Array used to store OldValue.

        ''' --- m_htFileInfo -------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of m_htFileInfo.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private m_htFileInfo As Hashtable _
        ' Stores the RowId and CheckSum_Value for files that performed a PUT.

        ''' --- m_intRecordsToFillInFindOrDetailFind -------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Used to determine whether GetData has been issued from Find Or DetailFind.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected Friend _
            m_intRecordsToFillInFindOrDetailFind As Integer = -1   '

        ''' --- m_blnPromptOK ------------------------------------------------------
        ''' <summary>
        '''     Indicates that a value was entered in a field when prompted using the
        '''     Accept or RequestPrompt methods.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> Protected m_blnPromptOK As Boolean

        ''' --- stcFileInfo --------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of stcFileInfo.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Serializable, EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Structure stcFileInfo
            ''' --- RowId --------------------------------------------------------------
            ''' <exclude />
            ''' <summary>
            '''     Summary of RowId.
            ''' </summary>
            ''' <remarks>
            ''' </remarks>
            ''' <history>
            '''     [Campbell]	7/4/2005	Created
            ''' </history>
            ''' --- End of Comments ----------------------------------------------------
            Dim RowId As String

            ''' --- CheckSum -----------------------------------------------------------
            ''' <exclude />
            ''' <summary>
            '''     Summary of CheckSum.
            ''' </summary>
            ''' <remarks>
            ''' </remarks>
            ''' <history>
            '''     [Campbell]	7/4/2005	Created
            ''' </history>
            ''' --- End of Comments ----------------------------------------------------
            Dim CheckSum As Decimal

            ''' --- AlteredRecord -----------------------------------------------------------
            ''' <exclude />
            ''' <summary>
            '''     Summary of AlteredRecord.
            ''' </summary>
            ''' <remarks>
            ''' </remarks>
            ''' <history>
            '''     [Campbell]	7/4/2005	Created
            ''' </history>
            ''' --- End of Comments ----------------------------------------------------
            Dim AlteredRecord As Boolean

            ''' --- NewRecord -----------------------------------------------------------
            ''' <exclude />
            ''' <summary>
            '''     Summary of NewRecord.
            ''' </summary>
            ''' <remarks>
            ''' </remarks>
            ''' <history>
            '''     [Campbell]	7/4/2005	Created
            ''' </history>
            ''' --- End of Comments ----------------------------------------------------
            Dim NewRecord As Boolean

            ''' --- DeletedRecord -----------------------------------------------------------
            ''' <exclude />
            ''' <summary>
            '''     Summary of DeletedRecord.
            ''' </summary>
            ''' <remarks>
            ''' </remarks>
            ''' <history>
            '''     [Campbell]	7/4/2005	Created
            ''' </history>
            ''' --- End of Comments ----------------------------------------------------
            Dim DeletedRecord As Boolean
        End Structure

        ''' --- m_intCountIntoSequence ---------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of m_intRunScreenSequence.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Friend m_intCountIntoSequence As Integer = 0 _
        ' Indicates the sequence of the CountInto.  This ensure that we don't call this function each time we post back.

        ''' --- m_strCountIntoCalled ---------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of m_strCountIntoCalled.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private m_strCountIntoCalled As String = String.Empty _
        ' Stores "Y" values for each count into that is called.

        ''' --- m_blnOracle --------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of m_blnOracle.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private m_blnOracle As Boolean = True

        Private m_strcommandseverity As String

        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Property commandseverity As String
            Get
                Return m_strcommandseverity
            End Get
            Set(Value As String)
                m_strcommandseverity = Value
            End Set
        End Property

        ''' --- ScreenSession ------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Set or return screen specific session information for a given key.
        ''' </summary>
        ''' <remarks>
        '''     This property sets/returns session information for a specific key.
        '''     This value can only be retrieved from the screen that set the value.
        ''' </remarks>
        ''' <example>
        '''     ScreenSession(UniqueSessionID + "T_TEMP") = T_TEMP.Value <br />
        '''     T_TEMP.Value = ScreenSession(UniqueSessionID + "T_TEMP")
        ''' </example>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Browsable(False),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Friend Property CountIntoCalled As Boolean
            Get
                m_intCountIntoSequence += 1
                Return MethodWasExecuted(m_intCountIntoSequence, "COUNT_INTO")
            End Get
            Set(Value As Boolean)
                If Value Then SetMethodExecutedFlag(m_strCountIntoCalled, "COUNT_INTO", m_intCountIntoSequence)
            End Set
        End Property

        '--------------------------
        ' Find Activity property.
        '--------------------------
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     Gets or sets a value indicating that the current screen has no actions.
        ''' </summary>
        ''' <value>True if the screen has no activities.</value>
        ''' <remarks>
        '''     Use the NoAction property to indicate that the screen has no actions specified.
        '''     <br /><br />
        ''' </remarks>
        ''' <history>
        '''     [Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Property NoAction As Boolean
            Get
                Return False
            End Get
            Set(Value As Boolean)
            End Set
        End Property

        <EditorBrowsable(EditorBrowsableState.Advanced)> Private m_NoDBConnect As Boolean = False

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     Gets or sets a value indicating that the current menu should not connect to the database.
        ''' </summary>
        ''' <value>True if the menu should not connect to a DB.</value>
        ''' <remarks>
        '''     Use the NoDBConnect property to indicate that the screen has no actions specified.
        '''     <br /><br />
        ''' </remarks>
        ''' <history>
        '''     [GlennA]	30-oct-2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Property NoDBConnect As Boolean
            Get
                Return m_NoDBConnect
            End Get
            Set(Value As Boolean)
                m_NoDBConnect = Value
            End Set
        End Property

        <Browsable(False),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property IsInitial As Boolean
            Get
                Return intSorted = 1
            End Get
        End Property

        <Browsable(False),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property RecordCount As Integer
            Get
                Return intSortCount
            End Get
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     Gets or sets a value indicating to use AutoUpdate.
        ''' </summary>
        ''' <value>True if AutoUpdate is turned on.</value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <Bindable(False),
            Browsable(True),
            EditorBrowsable(EditorBrowsableState.Always)>
        Public Property AutoUpdate As Boolean
            Get
                Return Session(UniqueSessionID + "AutoUpdate")
            End Get
            Set(Value As Boolean)
                Session(UniqueSessionID + "AutoUpdate") = Value
            End Set
        End Property

        ''' --- IncrementCountIntoSequence ------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Added due to the fact that when hovering over the CountIntoCalled method in debug
        '''     caused this counter to increment.
        ''' </summary>
        ''' <remarks>
        '''     This value can only be retrieved from the screen that set the value.
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Browsable(False),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Friend Sub IncrementCountIntoSequence()
            m_intCountIntoSequence += 1
        End Sub

        ''' --- m_intRunScreenSequence ---------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of m_intRunScreenSequence.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private m_intRunScreenSequence As Integer = 0 _
        ' Indicates the sequence of run screen calls.

        ''' --- m_strRunScreenFolder -----------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of m_strRunScreenFolder.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private m_strRunScreenFolder As String _
        ' The sub-directory from which to call the run screen.

        ''' --- m_intRunScreenFolderLength -----------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of m_intRunScreenFolderLength.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private m_intRunScreenFolderLength As Short = -1 _
        ' RunScreenFolderLength is used in a call to Run Screen to identify folder based on Run Screen Name

        ''' --- m_strRunScreenFolderLength -----------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of m_strRunScreenFolderLength.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private Shared m_strRunScreenFolderLength As String _
        ' strRunScreenFolderLength is used to get initial value from config file

        ''' --- m_intPutSequence ---------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of m_intPutSequence.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private m_intPutSequence As Integer = 0 _
        ' Indicates the sequence of put calls.

        ''' --- m_intGetSequence ---------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of m_intGetSequence.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private m_intGetSequence As Integer = 0

        ''' --- m_strRunScreen -----------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of m_strRunScreen.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_strRunScreen As String = ""

        ' Push verb.
        ''' --- m_strPush ----------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of m_strPush.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private m_strPush As String = String.Empty

        ''' --- m_intLevel ---------------------------------------------------------
        ''' <summary>
        '''     Indicates the number of levels the current screen has traversed.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> Protected m_intLevel As Integer = 1



        Public NumberedSessionID As New CoreInteger("NumberedSessionID", 8, Me)
        Public QTPSessionID As String = String.Empty



        ''' --- m_blnIsUsingSqlServer -------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of m_blnIsUsingSqlServer.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private m_blnIsUsingSqlServer As TriState = TriState.UseDefault



        ''' --- m_strRunFlag -------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of m_strRunFlag.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private m_strRunFlag As String = "" _
        ' The RUN_FLAG value from SESSION.

        ''' --- m_strRunFlag -------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of m_strPutFlag.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private m_strPutFlag As String = "" _
        ' The PUT_FLAG value from SESSION.

        ''' --- m_strGetFlag -------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of m_strGetFlag.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private m_strGetFlag As String = String.Empty

        ''' --- m_strScreenKey -----------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Indicates the current level of the screen.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_strScreenKey As String

        ''' --- m_strExternalFlag -------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of m_strRunFlag.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private m_strExternalFlag As String = "" _
        ' The EXTERNAL_FLAG value from SESSION.

        ''' --- m_intRunScreenMode -------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of m_intRunScreenMode.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_intRunScreenMode As PageModeTypes

        ''' --- GlobalizationManager -----------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of GlobalizationManager.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private GlobalizationManager As GlobalizationManager

        ''' --- m_strPageId --------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of m_strPageId.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private ReadOnly m_strPageId As String

        ''' --- m_pmtMode ----------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of m_pmtMode.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private m_pmtMode As PageModeTypes

        ''' --- ObjectStateMedium --------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of ObjectStateMedium.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected _
            ObjectStateMedium As StateMedium = StateMedium.SessionOnServer

        ''' --- m_hstInternalStateInfo ---------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of m_hstInternalStateInfo.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private m_hstInternalStateInfo As Hashtable _
        ' To store the state of Temporary and File Objects

        ''' --- m_colMessages ------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of m_colMessages.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Friend m_colMessages As New Collection

        ''' --- m_blnHasError ------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of m_blnHasError.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private m_blnHasError As Boolean = False

        ''' --- m_bfoFileForRecordStatus -------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of m_bfoFileForRecordStatus.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private m_bfoFileForRecordStatus As BaseFileObject _
        ' m_bfoFileForRecordStatus is used in DeletedRecord, AlteredRecord and NewRecord method

        ''' --- m_bfoPrimaryFile ---------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of m_bfoPrimaryFile.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Friend m_bfoPrimaryFile As BaseFileObject _
        ' m_bfoPrimaryFile is used to store Primary File Object

        ''' --- m_strPrimaryFile ---------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of m_strPrimaryFile.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private m_strPrimaryFile As String = ""

        ''' --- m_intMaxRecordsToRetrieve ------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of m_intMaxRecordsToRetrieve.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected Friend Shared _
            m_intMaxRecordsToRetrieve As Integer = -1

        ''' --- m_intProcessLimit ------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of m_intProcessLimit.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	6/29/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected Friend Shared m_intProcessLimit As Integer = -1

#Region " Events "

        ''' --- InitializeInternalValues -------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of InitializeInternalValues.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Friend Event InitializeInternalValues()

        ''' --- LoadPageState ------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of LoadPageState.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Friend Event LoadPageState(Sender As Object, e As PageStateEventArgs, blnFromAppend As Boolean)

        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Friend Event SetOverRideOccurrence(value As Integer, FileName As String)

        ''' --- SavePageState ------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of SavePageState.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Friend Event SavePageState(Sender As Object, e As PageStateEventArgs)

        ''' --- Reset ------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of Reset.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Friend Event ResetFile(Sender As Object)

        ''' --- SaveTempFile ------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of SavePageState.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Friend Event SaveTempFile(Sender As Object, e As PageStateEventArgs)

        ''' --- ClearFiles ------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of ClearFiles.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Friend Event ClearFiles(Sender As Object, e As PageStateEventArgs)

#End Region

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub New()
            MyBase.New()
        End Sub


        ''' --- New ----------------------------------------------------------------
        ''' <summary>
        '''     Instantiates a New instance of BaseClassWeb.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub New(UniqueID As String)
            If ConfigurationManager.AppSettings("AuthenticationDatabase") Is Nothing OrElse
               ConfigurationManager.AppSettings("AuthenticationDatabase").ToString.Equals(cORACLE) Then
                m_blnOracle = True
            Else
                m_blnOracle = False
            End If
            SetRunScreenFolderLength()

            m_strUniqueSessionID = UniqueID
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' <summary>
        '''     Instantiates a New instance of BaseClassWeb.
        ''' </summary>
        ''' <param name="Name">A String holding the name of the screen.</param>
        ''' <param name="Level">An Integer representing the screen level of the screen.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub New(Name As String, Level As Integer)
            MyBase.New()

            m_intLevel = Level
            Me.Name = Name

            'Set PageId that can be used to store and retrieve Internal Session
            m_strPageId = Name + "_" + Level.ToString

            SetGlobalizationManager()

            If ConfigurationManager.AppSettings("AuthenticationDatabase") Is Nothing OrElse
               ConfigurationManager.AppSettings("AuthenticationDatabase").ToString.Equals(cORACLE) Then
                m_blnOracle = True
            Else
                m_blnOracle = False
            End If
            SetRunScreenFolderLength()

            m_strUniqueSessionID = ""
        End Sub

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub New(Name As String, Level As Integer, UniqueID As String)
            MyBase.New()

            m_intLevel = Level
            Me.Name = Name

            'Set PageId that can be used to store and retrieve Internal Session
            m_strPageId = Name + "_" + Level.ToString
            m_strUniqueSessionID = UniqueID

            SetGlobalizationManager()

            If ConfigurationManager.AppSettings("AuthenticationDatabase") Is Nothing OrElse
               ConfigurationManager.AppSettings("AuthenticationDatabase").ToString.Equals(cORACLE) Then
                m_blnOracle = True
            Else
                m_blnOracle = False
            End If
            SetRunScreenFolderLength()
        End Sub

        ''' --- New ----------------------------------------------------------------
        ''' <summary>
        '''     Instantiates a New instance of BaseClassWeb.
        ''' </summary>
        ''' <param name="Name">A String holding the name of the screen.</param>
        ''' <param name="Level">An Integer representing the screen level of the screen.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub New(Name As String, Level As Integer, Request As Boolean)
            MyBase.New()
            Me.QTPRequest = Request
            If Request AndAlso ScreenType <> ScreenTypes.QUIZ Then
                ScreenType = ScreenTypes.QTP
            End If

            m_intLevel = Level
            Me.Name = Name

            'Set PageId that can be used to store and retrieve Internal Session
            m_strPageId = Name + "_" + Level.ToString

            SetGlobalizationManager()

            If ConfigurationManager.AppSettings("AuthenticationDatabase") Is Nothing OrElse
               ConfigurationManager.AppSettings("AuthenticationDatabase").ToString.Equals(cORACLE) Then
                m_blnOracle = True
            Else
                m_blnOracle = False
            End If
            SetRunScreenFolderLength()

            m_strUniqueSessionID = ""
        End Sub

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub New(Name As String, Level As Integer, Request As Boolean, UniqueID As String)
            MyBase.New()
            Me.QTPRequest = Request
            If Request AndAlso ScreenType <> ScreenTypes.QUIZ Then
                ScreenType = ScreenTypes.QTP
            End If

            m_intLevel = Level
            Me.Name = Name

            'Set PageId that can be used to store and retrieve Internal Session
            m_strPageId = Name + "_" + Level.ToString

            SetGlobalizationManager()

            If ConfigurationManager.AppSettings("AuthenticationDatabase") Is Nothing OrElse
               ConfigurationManager.AppSettings("AuthenticationDatabase").ToString.Equals(cORACLE) Then
                m_blnOracle = True
            Else
                m_blnOracle = False
            End If
            SetRunScreenFolderLength()

            m_strUniqueSessionID = UniqueID
        End Sub

#Region " Properties "

        ''' --- FormNameLevel ------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of FormNameLevel.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property FormNameLevel As String
            Get
                If m_strScreenKey Is Nothing Then
                    m_strScreenKey = Me.FormName + "_" + Me.Level.ToString
                End If
                Return m_strScreenKey
            End Get
        End Property

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Overridable ReadOnly Property MaxRecordsToRetrieve As Integer
            Get
                ' If m_intMaxRecordsToRetrieve is -1, then read the value from web.config.
                ' If no value in web.config, set the value to 0 so we don't re-read each time.
                If m_intMaxRecordsToRetrieve = -1 Then
                    If ConfigurationManager.AppSettings("MaxRecords") Is Nothing Then
                        m_intMaxRecordsToRetrieve = 0
                    Else
                        m_intMaxRecordsToRetrieve = CInt(ConfigurationManager.AppSettings("MaxRecords"))
                    End If
                End If
                Return m_intMaxRecordsToRetrieve
            End Get
        End Property

        ' Used for the State Manager Component.
        ''' --- ScreenSession ------------------------------------------------------
        ''' <summary>
        '''     Set or return screen specific session information for a given key.
        ''' </summary>
        ''' <param name="Key">The key used to retrieve the value.</param>
        ''' <remarks>
        '''     This property sets/returns session information for a specific key.
        '''     This value can only be retrieved from the screen that set the value.
        ''' </remarks>
        ''' <example>
        '''     ScreenSession(UniqueSessionID + "T_TEMP") = T_TEMP.Value <br />
        '''     T_TEMP.Value = ScreenSession(UniqueSessionID + "T_TEMP")
        ''' </example>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Browsable(False),
            EditorBrowsable(EditorBrowsableState.Always)>
        Public Property ScreenSession(Key As String) As Object
            Get
                Return Session(Me.FormNameLevel + "_" + Key)
            End Get
            Set(Value As Object)
                Session(Me.FormNameLevel + "_" + Key) = Value
            End Set
        End Property

        ''' --- DeleteScreenSession -----------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of DeleteScreenSession.
        ''' </summary>
        ''' <param name="Key"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub DeleteScreenSession(Key As String)

            Try
                Session.Remove(Me.FormNameLevel + "_" + Key)

            Catch ex As Exception

                Throw ex

            End Try
        End Sub

        ''' --- GlobalSession ------------------------------------------------------
        ''' <summary>
        '''     Set or return session information for a given key.
        ''' </summary>
        ''' <param name="Key"></param>
        ''' <remarks>
        '''     This property sets/returns session information for a specific key.
        '''     This value can be retrieved from any screen regardless of which screen set
        '''     this value.
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Browsable(False),
            EditorBrowsable(EditorBrowsableState.Always)>
        Public Property GlobalSession(Key As String) As Object
            Get
                Return Session(Key)
            End Get
            Set(Value As Object)
                Session(Key) = Value
            End Set
        End Property

        ''' --- RemoveScreenSession ------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Deletes the screen session key.
        ''' </summary>
        ''' <param name="Key"></param>
        ''' <remarks>
        '''     This property deletes the  session information for a specific key.
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Browsable(False),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub RemoveScreenSession(Key As String)
            Session.Remove(Me.FormNameLevel + "_" + Key)
        End Sub

        ''' --- RemoveGlobalSession ------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Deletes the global session key.
        ''' </summary>
        ''' <param name="Key"></param>
        ''' <remarks>
        '''     This property sets/returns session information for a specific key.
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Browsable(False),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub RemoveGlobalSession(Key As String)
            Session.Remove(Key)
        End Sub

        ''' --- AccessOk -----------------------------------------------------------
        ''' <summary>
        '''     Summary of AccessOk.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Overrides Property AccessOk As Boolean
            'The AccessOk condition relates to a session and not to a specific screen.
            Get
                Return Session(UniqueSessionID + "AccessOK")
            End Get
            Set
                Session(UniqueSessionID + "AccessOK") = Value
            End Set
        End Property

        '' --- SshConnectionOpen -----------------------------------------------------------
        ''' <summary>
        '''     Summary of SshConnectionOpen.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        Private Property SshConnectionOpen As Boolean
            Get
                If Session(UniqueSessionID + "SshOpen") Is Nothing Then
                    Return False
                Else
                    Return CBool(Session(UniqueSessionID + "SshOpen"))
                End If
            End Get
            Set(value As Boolean)
                Session(UniqueSessionID + "SshOpen") = value
            End Set
        End Property

        Private Sub RemoveSshConnectionOpen()
            Session.Remove(UniqueSessionID + "SshOpen")
        End Sub

        ''' --- Language -----------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     This member supports the Renaissance Architect Framework infrastructure and
        '''     is not intended to be used directly from your code.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        '''     [Mark]      19/7/2005   Updated summary from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Property Language As String
            Get
                Return GlobalizationManager.SupportedLanguage
            End Get
            Set(Value As String)
                Session.Add(UniqueSessionID + "Language", Value.ToLower)
            End Set
        End Property

        ''' --- Level --------------------------------------------------------------
        ''' <summary>
        '''     Retrieves the current Screen Level.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Overrides Property Level As Integer
            Get
                Return m_intLevel
            End Get
            Set
                m_intLevel = Value
            End Set


        End Property

        ''' --- Mode ---------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     This member supports the Renaissance Architect Framework infrastructure and
        '''     is not intended to be used directly from your code.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        '''     [Mark]      19/7/2005   Used summary from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Overrides Property Mode As PageModeTypes
            Get
                Return m_pmtMode
            End Get
            Set(Value As PageModeTypes)
                m_pmtMode = Value
            End Set
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     This member supports the Renaissance Architect Framework infrastructure and
        '''     is not intended to be used directly from your code.
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <Browsable(False),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property SetAlteredFlag As Boolean
            Get
                ' The AlteredRecord flag is not set to True if the value was changed when
                ' FindMode is true except when in the PostFind or DetailPostFind.  If in
                ' NoMode (in our case we are in NoMode when searching for a record using FIND
                ' and no records are found, or by pressing the cancel button), the AlteredRecord flag
                ' should not be set to True, unless we are running the INITIALIZE procedure.  In
                ' all other modes, the AlteredRecord status should change to True when the value changes.
                If _
                    Mode = PageModeTypes.Change OrElse Mode = PageModeTypes.Entry OrElse Mode = PageModeTypes.Correct OrElse
                    Mode = PageModeTypes.NoMode OrElse
                    (Mode = PageModeTypes.Find AndAlso m_blnInPostFindOrDetailPostFind) OrElse m_blnInInitialize Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

        ''' --- PageSession --------------------------------------------------------
        ''' <summary>
        '''     Stores page specific values into the Session.
        ''' </summary>
        ''' <param name="PageSessionKey"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Property PageSession(PageSessionKey As String) As Object
            'This property is added to store page specific values into the Session
            Get
                Dim strPageSessionKey As String = Me.FormName + "_" + Me.Level.ToString + "_" + PageSessionKey
                Return Session(UniqueSessionID + strPageSessionKey)
            End Get
            Set(Value As Object)
                Dim strPageSessionKey As String = Me.FormName + "_" + Me.Level.ToString + "_" + PageSessionKey
                Session(UniqueSessionID + strPageSessionKey) = Value
            End Set
        End Property

        ''' --- ScreenSequence -----------------------------------------------------
        ''' <summary>
        '''     Summary of ScreenSequence.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Property ScreenSequence As String
            Get
                Return Session(UniqueSessionID + FormName + "_" + Level.ToString + "_ScreenSequence") & ""
            End Get
            Set(value As String)
                Session(UniqueSessionID + FormName + "_" + Level.ToString + "_ScreenSequence") = value
            End Set
        End Property

        Private intTotalRecordsFound As Integer
        Public Property TotalRecordsFound() As Integer

            Get
                Return intTotalRecordsFound
            End Get
            Set(ByVal Value As Integer)
                intTotalRecordsFound = Value
            End Set
        End Property

        Private intTotalRecordsProcessed As Integer
        Public Overridable Property TotalRecordsProcessed() As Integer
            'Note: Only to be used in While skipping records with an error in Find/DetailFind
            Get
                Return intTotalRecordsProcessed
            End Get
            Set(ByVal Value As Integer)
                intTotalRecordsProcessed = Value
            End Set
        End Property

        ''' --- Session ------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of Session.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Property Session As Hashtable
            Get
                If ApplicationState.Current.Session Is Nothing Then
                    ApplicationState.Current.Session = New Hashtable
                End If
                Return ApplicationState.Current.Session
            End Get
            Set(value As Hashtable)
                ApplicationState.Current.Session = value
            End Set
        End Property

        ''' --- Application --------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of Application.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Property Application As Hashtable
            Get
                Return ApplicationState.Current.Application
            End Get
            Set(value As Hashtable)
                ApplicationState.Current.Application = value
            End Set
        End Property

        ''' --- IsInAppendOrEntry --------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of IsInAppendOrEntry.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Friend ReadOnly Property IsInAppendOrEntry As Boolean
            Get
                Return m_blnIsInAppendOrEntry
            End Get
        End Property

        ''' --- PrimaryFile --------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of PrimaryFile.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Property PrimaryFile As String
            Get
                Return m_strPrimaryFile
            End Get
            Set(Value As String)
                m_strPrimaryFile = Value
            End Set
        End Property

        ''' --- InFind -------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of InFind.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Friend ReadOnly Property InFind As Boolean
            Get
                Return m_blnInFind
            End Get
        End Property

        ''' --- InFindOrDetailFind -------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of InFindOrDetailFind.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Friend ReadOnly Property InFindOrDetailFind As Boolean
            Get
                Return m_blnInFindOrDetailFind
            End Get
        End Property

        ''' --- CalledPageSession --------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of CalledPageSession.
        ''' </summary>
        ''' <param name="CalledScreenName"></param>
        ''' <param name="CalledScreenLevel"></param>
        ''' <param name="PageSessionKey"></param>
        ''' <remarks>
        '''     CalledPageSession property uses Session Collection, however to make it
        '''     readable and maitainable it adds prefix "PageName_Level_" to SessionKey passed,
        '''     which mimics a Page-Specific Session.
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Property CalledPageSession(CalledScreenName As String, CalledScreenLevel As Integer,
                                          PageSessionKey As String) As Object
            Get
                Dim strPageSessionKey As String = CalledScreenName + "_" + CalledScreenLevel.ToString + "_" +
                                                  m_intRunScreenSequence.ToString + "_" + PageSessionKey
                Return Session(UniqueSessionID + strPageSessionKey)
            End Get
            Set(Value As Object)
                Dim strPageSessionKey As String = CalledScreenName + "_" + CalledScreenLevel.ToString + "_" +
                                                  m_intRunScreenSequence.ToString + "_" + PageSessionKey
                Session(UniqueSessionID + strPageSessionKey) = Value
            End Set
        End Property

#End Region

#Region " Methods "

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub PurgeFile(FileName As String)

            SessionInformation.Remove(FileName, Session("SessionID"))
        End Sub

        ''' --- RunSshShellCommand ---------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of RunCommand.
        ''' </summary>
        ''' <param name="Command"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Function RunSshShellCommand(Command As String) As String

            Return SessionInformation.RunSshCommand(Command.TrimEnd)
        End Function






        '----------------------------------------
        ' CodeExecuted property.
        '----------------------------------------
        ''' -----------------------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Internal function.
        ''' </summary>
        ''' <value>True if the screen is called from the menu tree.</value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Property CodeExecuted As Boolean
            Get
                If ScreenSession(UniqueSessionID + "CodeExecuted") Is Nothing Then
                    Return False
                Else
                    Return ScreenSession(UniqueSessionID + "CodeExecuted")
                End If
            End Get
            Set(Value As Boolean)
                ScreenSession(UniqueSessionID + "CodeExecuted") = Value
            End Set
        End Property



        ''' <summary>
        '''     Places one or more commands on the screen's pending buffer.
        ''' </summary>
        ''' <example>
        '''     Push(PushTypes.Find)
        ''' </example>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Sub Push(Name As PushTypes)

            Push(Name.ToString)
        End Sub

        ''' --- Push ---------------------------------------------------------------
        ''' <summary>
        '''     Places one or more commands on the screen's pending buffer.
        ''' </summary>
        ''' <param name="Designer">The designer procedure to place on the screen's pending buffer.</param>
        ''' <remarks>
        '''     This method puts one or more commands on the pending buffer.  Once the
        '''     user has finished executing a specific procedure, the pending buffer is checked
        '''     for the commands to execute.
        '''     <note>
        '''         The Push method has a First In First Out configuration.  The following will be executed as follows: <br />
        '''         Push(PushTypes.NextRecord)<br />
        '''         Push(PushTypes.Find)<br />
        '''         <br />
        '''         In the example listed above, the Find will be executed first, then the NextRecord command.
        '''     </note>
        ''' </remarks>
        ''' <example>
        '''     Push(dsrDesigner_BAT)
        ''' </example>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Sub Push(Designer As Designer)

            'Push(Designer.ID)
        End Sub

        ''' --- Push ---------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Places one or more commands on the screen's pending buffer.
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <example>
        '''     Push(dsrDesigner_BAT)
        ''' </example>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Sub Push(Name As String)

            Dim strSeparator As String = ","
            If m_strPush.Length = 0 Then strSeparator = String.Empty
            m_strPush = Name + strSeparator + m_strPush
        End Sub

        ''' <summary>
        '''     Places one or more commands on the screen's pending buffer.
        ''' </summary>
        ''' <param name="Name">The designer procedures to place on the screen's pending buffer.</param>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Sub Push(ByVal ParamArray Name() As Designer)

            'Dim intCount As Integer
            'Dim strSeparator As String = ","
            'For intCount = 0 To UBound(Name)
            '    If m_strPush.Length = 0 Then
            '        m_strPush = m_strPush + Name(intCount).ID
            '    Else
            '        m_strPush = m_strPush + strSeparator + Name(intCount).ID
            '    End If
            'Next
        End Sub

        ''' <summary>
        '''     Places one or more commands on the screen's pending buffer.
        ''' </summary>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Sub Push(ByVal ParamArray Name() As PushTypes)

            Dim intCount As Integer
            Dim strSeparator As String = ","
            For intCount = 0 To UBound(Name)
                If m_strPush.Length = 0 Then
                    m_strPush = m_strPush + Name(intCount).ToString
                Else
                    m_strPush = m_strPush + strSeparator + Name(intCount).ToString
                End If
            Next
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     Compares a string to a pattern.
        ''' </summary>
        ''' <param name="Value">A string of characters to compare against a pattern.</param>
        ''' <param name="Pattern">A string representing a specific pattern to match against the passed in value.</param>
        ''' <returns>A Boolean</returns>
        ''' <remarks>
        '''     Will return True, if the pattern matches the string and False, if not.
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Function MatchPattern(Value As String, Pattern As String) As Boolean

            Try
                'Added the following because !0 means nothing is PH and regular expressions can not duplicate this
                If (Pattern = "!0" OrElse Pattern.IndexOf("|!0") >= 0) AndAlso Value.Trim.Length = 0 Then
                    Return True
                End If
                Return EvalRegularExpressionAsPowerHousePattern(Value, GetRegularExpresssionPattern(Pattern))
            Catch ex As CustomApplicationException
                If ex.Message.Equals("Invalid pattern!") Then 'IM.InvalidPattern
                    Warning("Invalid pattern!") 'IM.InvalidPattern
                    Return True
                Else
                    Throw ex
                End If
            End Try
        End Function

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Overridable Function Prompt(intArr As Integer) As Object
            Dim strTmp As String = ""
            Dim arrTemp() As Object = Session(UniqueSessionID + "Prompt")
            If IsNothing(arrTemp) OrElse arrTemp.Length = 0 OrElse arrTemp.Length < intArr Then
                arrTemp = Common.Parms
                If IsNothing(arrTemp) OrElse arrTemp.Length = 0 OrElse arrTemp.Length < intArr Then
                    Return ""
                End If
            End If

            Select Case arrTemp(intArr - 1).GetType.ToString
                Case "CORE.WINDOWS.UI.CORE.WINDOWS.CoreCharacter"
                    If m_blnInChoose Then
                        Return CType(arrTemp(intArr - 1), CoreCharacter).Value.Replace(CORE_DELIMITER, ",")
                    End If
                    Return CType(arrTemp(intArr - 1), CoreCharacter).Value
                Case "CORE.WINDOWS.CoreVarChar"
                    If m_blnInChoose Then
                        Return CType(arrTemp(intArr - 1), CoreVarChar).Value.Replace(CORE_DELIMITER, ",")
                    End If
                    Return CType(arrTemp(intArr - 1), CoreVarChar).Value
                Case "CORE.WINDOWS.UI.CORE.WINDOWS.CoreDecimal"
                    If m_blnInChoose AndAlso CType(arrTemp(intArr - 1), String).IndexOf(CORE_DELIMITER) > -1 Then
                        Return CType(arrTemp(intArr - 1), String).Replace(CORE_DELIMITER, ",")
                    End If
                    Return CType(arrTemp(intArr - 1), CoreDecimal).Value
                Case "CORE.WINDOWS.UI.CORE.WINDOWS.CoreInteger"
                    If m_blnInChoose AndAlso CType(arrTemp(intArr - 1), String).IndexOf(CORE_DELIMITER) > -1 Then
                        Return CType(arrTemp(intArr - 1), String).Replace(CORE_DELIMITER, ",")
                    End If
                    Return CType(arrTemp(intArr - 1), CoreInteger).Value
                Case "CORE.WINDOWS.UI.CORE.WINDOWS.CoreDate"
                    If m_blnInChoose AndAlso CType(arrTemp(intArr - 1), String).IndexOf(CORE_DELIMITER) > -1 Then
                        Return CType(arrTemp(intArr - 1), String).Replace(CORE_DELIMITER, ",")
                    End If
                    Return CType(arrTemp(intArr - 1), CoreDate).Value
                Case "Core.Framework.Core.Framework.DCharacter"
                    If m_blnInChoose Then
                        Return CType(arrTemp(intArr - 1), DCharacter).Value.Replace(CORE_DELIMITER, ",")
                    End If
                    Return CType(arrTemp(intArr - 1), DCharacter).Value
                Case "Core.Framework.Core.Framework.DVarChar"
                    If m_blnInChoose Then
                        Return CType(arrTemp(intArr - 1), DVarChar).Value.Replace(CORE_DELIMITER, ",")
                    End If
                    Return CType(arrTemp(intArr - 1), DVarChar).Value
                Case "Core.Framework.Core.Framework.DDecimal"
                    If m_blnInChoose AndAlso CType(arrTemp(intArr - 1), String).IndexOf(CORE_DELIMITER) > -1 Then
                        Return CType(arrTemp(intArr - 1), String).Replace(CORE_DELIMITER, ",")
                    End If
                    Return CType(arrTemp(intArr - 1), DDecimal).Value
                Case "Core.Framework.Core.Framework.DInteger"
                    If m_blnInChoose AndAlso CType(arrTemp(intArr - 1), String).IndexOf(CORE_DELIMITER) > -1 Then
                        Return CType(arrTemp(intArr - 1), String).Replace(CORE_DELIMITER, ",")
                    End If
                    Return CType(arrTemp(intArr - 1), DInteger).Value
                Case "Core.Framework.Core.Framework.DDate"
                    If m_blnInChoose AndAlso CType(arrTemp(intArr - 1), String).IndexOf(CORE_DELIMITER) > -1 Then
                        Return CType(arrTemp(intArr - 1), String).Replace(CORE_DELIMITER, ",")
                    End If
                    Return CType(arrTemp(intArr - 1), DDate).Value
                Case "System.String"
                    If m_blnInChoose Then
                        Return CType(arrTemp(intArr - 1), String).Replace(CORE_DELIMITER, ",")
                    End If
                    Return CType(arrTemp(intArr - 1), String)
                Case Else
                    If m_blnInChoose AndAlso CType(arrTemp(intArr - 1), String).IndexOf(CORE_DELIMITER) > -1 Then
                        Return CType(arrTemp(intArr - 1), String).Replace(CORE_DELIMITER, ",")
                    End If
                    Return arrTemp(intArr - 1)
            End Select
        End Function

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Overridable Function RunQTP() As Boolean
        End Function


        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Overridable Function RunQUIZ() As Boolean
        End Function

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function RunBaseJOB(JobNumber As Integer, SessionID As String, Parms() As Object) As Boolean

            Return RunQTPBase(JobNumber, SessionID, Parms)
        End Function

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function RunQTPBase(JobNumber As Integer, SessionID As String, Parms() As Object) As Boolean

            Dim blnSuccess As Boolean = False

            Try



                Session(UniqueSessionID + "Prompt") = Parms
                Session(UniqueSessionID + "NumberedSessionID") = JobNumber
                Session(UniqueSessionID + "QTPSessionID") = SessionID

                RegisterStateFlag()

                Dim strUser As String = Session(UniqueSessionID + "UserID") & ""
                If strUser.Length = 0 Then
                    strUser = Session(UniqueSessionID + "m_strUser") & ""
                End If

                If Not ConfigurationManager.AppSettings("InputCenturyFrom") Is Nothing Then
                    m_intDefaultInputCentury =
                        ConfigurationManager.AppSettings("InputCenturyFrom").ToString.Split(",")(0)
                    ' If we have a 2 digit century, multiply by 100 to give us
                    ' the century that we add to the year entered.  (ie. 19 becomes 1900)
                    If m_intDefaultInputCentury.ToString.Length = 2 Then
                        m_intDefaultInputCentury *= 100
                    End If
                    Session(UniqueSessionID + "DefaultInputCentury") = m_intDefaultInputCentury
                    m_intInputFromYear = ConfigurationManager.AppSettings("InputCenturyFrom").ToString.Split(",")(1)
                    Session(UniqueSessionID + "InputFromYear") = m_intInputFromYear
                Else
                    m_intDefaultInputCentury = (CInt(Now.Year.ToString.Substring(0, 2)) - 1) * 100
                    Session(UniqueSessionID + "DefaultInputCentury") = m_intDefaultInputCentury
                    m_intInputFromYear = 50
                    Session(UniqueSessionID + "InputFromYear") = m_intInputFromYear
                End If

                If IsNothing(Session(UniqueSessionID + "StartFile")) Then
                    Session(UniqueSessionID + "StartFile") = Me.Name
                    If strUser.Length > 0 Then
                        Session(UniqueSessionID + "LogName") = strUser & "_" & Me.Name & "_" & Now.Year.ToString &
                                                               Now.Month.ToString.PadLeft(2, "0") &
                                                               Now.Day.ToString.PadLeft(2, "0") &
                                                               Now.TimeOfDay.Hours.ToString.PadLeft(2, "0") &
                                                               Now.TimeOfDay.Minutes.ToString.PadLeft(2, "0") &
                                                               Now.TimeOfDay.Seconds.ToString.PadLeft(2, "0") &
                                                               Now.TimeOfDay.Milliseconds.ToString.PadLeft(3, "0")
                    Else
                        Session(UniqueSessionID + "LogName") = Me.Name & "_" & Now.Year.ToString &
                                                               Now.Month.ToString.PadLeft(2, "0") &
                                                               Now.Day.ToString.PadLeft(2, "0") &
                                                               Now.TimeOfDay.Hours.ToString.PadLeft(2, "0") &
                                                               Now.TimeOfDay.Minutes.ToString.PadLeft(2, "0") &
                                                               Now.TimeOfDay.Seconds.ToString.PadLeft(2, "0") &
                                                               Now.TimeOfDay.Milliseconds.ToString.PadLeft(3, "0")
                    End If
                End If

#If TARGET_DB = "INFORMIX" Then
                ' Write the Process Id to the log file.
                Dim sb As StringBuilder = New StringBuilder("ProcessID: ")
                sb.Append(System.Diagnostics.Process.GetCurrentProcess.Id.ToString).Append(vbNewLine)
                sb.Append("Program:   ").Append(Me.Name).Append(vbNewLine)
                WriteLogFile(sb.ToString)
#End If

                If ScreenType = ScreenTypes.QUIZ Then
                    RunQUIZ()
                Else

                    If IsAxiant() Then
                        Try
                            InitializeTransactionObjects()
                            Try
                                RunQTP()
                            Catch ex As CustomApplicationException
                                WriteError(ex)
                            Catch ex As Exception
                                WriteError(ex)
                            End Try

                            If CancelQTPs Then
                                TRANS_UPDATE(TransactionMethods.Rollback)
                            Else
                                TRANS_UPDATE(TransactionMethods.Commit)
                            End If


                        Catch ex As Exception
                            CancelQTPs = True
                            TRANS_UPDATE(TransactionMethods.Rollback)
                            m_LogFile.Append("Changes made since the last commit have been rolled back to a stable state. ")
                            m_LogFile.Append("Therefore, statistics reported may be incorrect. ")

                            WriteLogFile(m_LogFile.ToString)
                        End Try
                    Else

                        RunQTP()

                        If Not IsNothing(Session(UniqueSessionID + "hsSubfile")) AndAlso Not IsNothing(Session("TempFiles")) Then


                            Dim subkey As String



                            For Each subkey In DirectCast(Session("TempFiles"), ArrayList)


                                PutDataTextTable(subkey, Session(UniqueSessionID + "hsSubfile")(subkey),
                                                 Session(UniqueSessionID + "hsSubfileKeepText").Item(subkey),
                                                 Nothing)
                                Session(UniqueSessionID + "hsSubfile").Item(subkey).Clear()


                            Next


                        End If

                        Dim strDirectory As String = GetDEFAULT_BATCH_FILE_DIRECTORY()
                        Dim newFile As String = ""

                        If Not strDirectory.Trim = "" Then
                            If Not Directory.Exists(strDirectory) Then Directory.CreateDirectory(strDirectory)
                            If _
                                (Not ConfigurationManager.AppSettings("JobOutPut") Is Nothing AndAlso
                                 ConfigurationManager.AppSettings("JobOutPut").ToUpper() = "TRUE") Then
                                newFile = strDirectory & "\" & Session("JobOutPut") & ".txt"
                            Else
                                newFile = strDirectory & "\" & Session(UniqueSessionID + "LogName") & ".txt"
                            End If


                            If File.Exists(newFile) Then

                                Dim sr As StreamReader = New StreamReader(newFile)
                                Dim line As String = sr.ReadLine
                                While Not IsNothing(line)
                                    Console.WriteLine(line)
                                    line = sr.ReadLine
                                End While

                            End If


                        End If


                    End If



                End If


                Try
                    CloseTransactionObjects()
                Catch ex As CustomApplicationException
                    Throw ex
                Catch ex As Exception
                    Throw ex
                End Try

                If Me.Name = Session(UniqueSessionID + "StartFile") Then

                    If Not IsNothing(Session(UniqueSessionID + "hsSubfile")) Then
                        Dim Enumerator As IDictionaryEnumerator = Session("hsSubfile").GetEnumerator
                        While Enumerator.MoveNext
                            If _
                                Not _
                                (ScreenType = ScreenTypes.QUIZ AndAlso Enumerator.Key.ToString.ToUpper.EndsWith("_TEMP")) _
                                Then
                                If (ConfigurationManager.AppSettings("SubfileTEMPtoSQL") & "").ToUpper <> "TRUE" Then
                                    SessionInformation.SetSession(Enumerator.Key.ToString, Enumerator.Value, SessionID)
                                End If
                            End If
                        End While
                    End If
                    If Not IsNothing(Session(UniqueSessionID + "hsSubfileKeepText")) Then
                        Dim Enumerator As IDictionaryEnumerator =
                                Session(UniqueSessionID + "hsSubfileKeepText").GetEnumerator
                        While Enumerator.MoveNext
                            If (ConfigurationManager.AppSettings("SubfileTEMPtoSQL") & "").ToUpper <> "TRUE" Then
                                SessionInformation.SetSession(Enumerator.Key.ToString & "_Length", Enumerator.Value,
                                                              SessionID)
                            End If
                        End While
                    End If

                    Session.Remove(UniqueSessionID + "hsSubfile")
                    Session.Remove(UniqueSessionID + "hsSubfileKeepText")
                    'Session.Remove(UniqueSessionID + "LogName")
                    If _
                        Not IsNothing(Session(UniqueSessionID + "alSubTempFile")) AndAlso
                        Session(UniqueSessionID + "alSubTempFile").Count > 0 Then
                        For i As Integer = 0 To Session(UniqueSessionID + "alSubTempFile").Count - 1
                            Dim strSQL As New StringBuilder("DROP TABLE ")
                            strSQL.Append(Session(UniqueSessionID + "alSubTempFile")(i))
#If TARGET_DB = "INFORMIX" Then
                            'Try
                            '    InformixHelper.ExecuteNonQuery(GetInformixConnectionString(), CommandType.Text, strSQL.ToString)
                            'Catch ex As Exception

                            'End Try

#End If
                        Next
                    End If
                    Session.Remove(UniqueSessionID + "alSubTempFile")
                End If

                If _
                    Me.Name = Session(UniqueSessionID + "StartFile") AndAlso
                    Not IsNothing(Session(UniqueSessionID + "arrMoveFiles")) Then

                End If



                If Me.Name = Session(UniqueSessionID + "StartFile") Then
#If TARGET_DB = "INFORMIX" Then

                    cnnQUERY = Session(UniqueSessionID + "cnnQUERY")
                    cnnTRANS_UPDATE = Session(UniqueSessionID + "cnnTRANS_UPDATE")
                    trnTRANS_UPDATE = Session(UniqueSessionID + "trnTRANS_UPDATE")

                    Try
                        If Not trnTRANS_UPDATE Is Nothing Then trnTRANS_UPDATE.Commit()
                    Catch
                    End Try

                    If Not trnTRANS_UPDATE Is Nothing Then trnTRANS_UPDATE = Nothing
                    If Not cnnTRANS_UPDATE Is Nothing Then cnnTRANS_UPDATE.Close()
                    If Not cnnTRANS_UPDATE Is Nothing Then cnnTRANS_UPDATE.Dispose()
                    If Not cnnQUERY Is Nothing Then cnnQUERY.Close()
                    If Not cnnQUERY Is Nothing Then cnnQUERY.Dispose()

                    Session.Remove(UniqueSessionID + "cnnQUERY")
                    Session.Remove(UniqueSessionID + "cnnTRANS_UPDATE")
                    Session.Remove(UniqueSessionID + "trnTRANS_UPDATE")
#End If
                    Session.Remove(UniqueSessionID + "StartFile")
                    Session.Remove(UniqueSessionID + "Prompt")
                    Session.Remove(UniqueSessionID + "NumberedSessionID")
                    Session.Remove(UniqueSessionID + "QTPSessionID")
                    Session.Remove(UniqueSessionID + "hsSubFileSize")
                End If

                blnSuccess = True

            Catch ex As Exception

                If Me.Name = Session(UniqueSessionID + "StartFile") Then
#If TARGET_DB = "INFORMIX" Then

                    cnnQUERY = Session(UniqueSessionID + "cnnQUERY")
                    cnnTRANS_UPDATE = Session(UniqueSessionID + "cnnTRANS_UPDATE")
                    trnTRANS_UPDATE = Session(UniqueSessionID + "trnTRANS_UPDATE")

                    Try
                        If Not trnTRANS_UPDATE Is Nothing Then trnTRANS_UPDATE.Commit()
                    Catch
                    End Try

                    If Not trnTRANS_UPDATE Is Nothing Then trnTRANS_UPDATE = Nothing
                    If Not cnnTRANS_UPDATE Is Nothing Then cnnTRANS_UPDATE.Close()
                    If Not cnnTRANS_UPDATE Is Nothing Then cnnTRANS_UPDATE.Dispose()
                    If Not cnnQUERY Is Nothing Then cnnQUERY.Close()
                    If Not cnnQUERY Is Nothing Then cnnQUERY.Dispose()

                    Session.Remove(UniqueSessionID + "cnnQUERY")
                    Session.Remove(UniqueSessionID + "cnnTRANS_UPDATE")
                    Session.Remove(UniqueSessionID + "trnTRANS_UPDATE")
#End If
                    Session.Remove(UniqueSessionID + "StartFile")
                    Session.Remove(UniqueSessionID + "Prompt")
                    Session.Remove(UniqueSessionID + "NumberedSessionID")
                    Session.Remove(UniqueSessionID + "QTPSessionID")
                    Session.Remove(UniqueSessionID + "hsSubFileSize")
                End If



                ' Write the exception to the event log.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

            Return blnSuccess
        End Function



        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function ParrallelForMissing(ParrallelFileObj As BaseFileObject) As Boolean
        End Function

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function Transaction() As Boolean

            blnTrans = True

            If blnAtInitial = BooleanTypes.NotSet Then
                blnAtInitial = BooleanTypes.False
            ElseIf blnAtInitial = BooleanTypes.False Then
                blnAtInitial = BooleanTypes.True
            End If

#If TARGET_DB = "INFORMIX" Then

            If blnGotSQL = BooleanTypes.NotSet AndAlso blnRunForMissing Then
                blnGotSQL = BooleanTypes.False
                If m_blnGetSQL Then
                    Return True
                End If
                Return False
            End If
#End If

            If blnDeleteSubFile Then
                blnHasRunSubfile = True
                Return True
            End If
            If Not m_blnNoRecords Then
                blnHasRunSubfile = True
                intTransactions += 1
            End If

            Return Not m_blnNoRecords
        End Function

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub Sort(ByVal ParamArray value() As Object)

#If TARGET_DB = "INFORMIX" Then
            If Not blnGotSQL = BooleanTypes.True Then
                Exit Sub
            End If
#End If

            strSortOrder = ""
            blnHasSort = True

            If blnDeleteSubFile Then
                Exit Sub
            End If

            Dim dc As DataColumn
            Dim rw As DataRow

            If dtSortOrder.Columns.Count = 0 Then

                dc = New DataColumn()
                dc.ColumnName = "Sort"
                dc.DataType = Type.GetType("System.String")
                dtSortOrder.Columns.Add(dc)

                For i As Integer = 0 To value.Length - 1

                    If value(i).GetType.ToString = "System.String" AndAlso value(i).IndexOf("~!Numeric!~") >= 0 Then
                        dc = New DataColumn()
                        dc.ColumnName = i.ToString
                        dc.DataType = Type.GetType("System.Decimal")
                        dtSortOrder.Columns.Add(dc)

                    ElseIf _
                        value(i).GetType.ToString = "System.String" AndAlso
                        value(i).IndexOf("~!NumericDescending!~") >= 0 Then
                        dc = New DataColumn()
                        dc.ColumnName = i.ToString
                        dc.DataType = Type.GetType("System.Decimal")
                        dtSortOrder.Columns.Add(dc)

                    Else
                        dc = New DataColumn()
                        dc.ColumnName = i.ToString
                        dc.DataType = Type.GetType("System.String")
                        dtSortOrder.Columns.Add(dc)
                    End If

                Next
            End If

            Dim arrSort() As String = m_SortOrder.Split(",")
            For i As Integer = 0 To arrSort.Length - 1
                Try
                    arrSortOrder.Add((i + 1).ToString & "_" & arrSort(i).Trim)
                Catch ex As Exception

                End Try
            Next

            Dim strvalue As String = ""
            Dim strdec As String = ""

            rw = dtSortOrder.NewRow
            rw.Item("Sort") = m_SortOrder
            For i As Integer = 0 To value.Length - 1

                strvalue = value(i)

                If value(i).GetType.ToString = "System.Decimal" Then
                    If strvalue.IndexOf(".") >= 0 Then
                        strdec = strvalue.Substring(strvalue.IndexOf(".") + 1)
                        strvalue = strvalue.Substring(0, strvalue.IndexOf("."))
                    End If
                    strdec = strdec.PadRight(4, "0")
                    strvalue = strvalue.PadLeft(12, "0")
                    strvalue = strvalue & "." & strdec
                End If

                If strvalue.IndexOf("~!Descending!~") >= 0 Then
                    strvalue = strvalue.ToString.Replace("~!Descending!~", "")
                    strSortOrder = strSortOrder & i.ToString & " DESC,"
                ElseIf strvalue.IndexOf("~!NumericDescending!~") >= 0 Then
                    strvalue = strvalue.ToString.Replace("~!NumericDescending!~", "")
                    strSortOrder = strSortOrder & i.ToString & " DESC,"
                Else
                    If strvalue.IndexOf("~!Numeric!~") >= 0 Then
                        strvalue = strvalue.ToString.Replace("~!Numeric!~", "")
                    End If
                    strSortOrder = strSortOrder & i.ToString & " ASC,"
                End If

                rw.Item(i.ToString) = strvalue
            Next

            strSortOrder = strSortOrder.Substring(0, strSortOrder.Length - 1)
            dtSortOrder.Rows.Add(rw)
        End Sub

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub Sorted(ByVal ParamArray value() As Object)

            Sort(value)
        End Sub

        ''' --- m_blnStartJobScript --------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of m_blnStartJobScript.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private m_blnStartJobScript As Boolean

        ''' --- m_strJobParams --------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of m_strJobParams.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private m_strJobParams As String = String.Empty

        ''' --- m_blnStartJobScript --------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of m_blnStartJobScript.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Public m_blnAppendJobScript As Boolean

        Public m_strJobScriptPath As String = String.Empty

        Protected Function JobScriptPath() As String

            Try

                If m_strJobScriptPath = "" Then
                    m_strJobScriptPath = ConfigurationManager.AppSettings("JobScriptPath") & "\"
                End If

                Return m_strJobScriptPath

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try
        End Function

        Protected Sub StartJobScript()
            Try
                m_blnStartJobScript = True
            Catch ex As Exception

            End Try
        End Sub

        Protected Sub EndJobScript()
            Try
                m_blnStartJobScript = False
                m_blnAppendJobScript = False
                Session(UniqueSessionID + "dtNow") = Nothing
                Session.Remove(UniqueSessionID + "RunJob")
            Catch ex As Exception

            End Try
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of ReadParmPrompts.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [mayur]	8/19/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub ReadParmPrompts()
            m_htParmPrompts = New Hashtable
            Dim strParmPromptsFileName As String = ConfigurationManager.AppSettings("ParmPrompts")
            Dim intOccurs As Integer = 2
            'Note: Using XmlTextReader, instead of XMLDocument to make the loading faster
            'At present its not strictly observing the Encoding specifiec in the XML File,
            'XmlTextReader always the default Encoding which is Windows-1252
            Dim objParmPromptXML As XmlTextReader = Nothing
            If (strParmPromptsFileName Is Nothing OrElse strParmPromptsFileName.Trim.Equals(String.Empty)) Then
                Return
            Else
                If File.Exists(strParmPromptsFileName) Then
                    Try
                        objParmPromptXML = New XmlTextReader(strParmPromptsFileName)
                        With objParmPromptXML
                            Dim strJobName As String

                            While .Read
                                Select Case .NodeType
                                    Case XmlNodeType.Element
                                        If .Name.ToUpper.Equals("SCREEN") Then
                                            Dim strParmPrompts(6) As String
                                            strJobName = String.Empty

                                            While .MoveToNextAttribute()
                                                Select Case .Name.ToUpper
                                                    Case "JOB"
                                                        strJobName = .Value
                                                    Case "FIELD"
                                                        strParmPrompts(ParmPrompts.Field) = .Value
                                                    Case "TYPE"
                                                        strParmPrompts(ParmPrompts.Type) = .Value
                                                    Case "SIZE"
                                                        strParmPrompts(ParmPrompts.Size) = .Value
                                                    Case "LABEL"
                                                        strParmPrompts(ParmPrompts.Label) = .Value
                                                    Case "CHOOSE"
                                                        strParmPrompts(ParmPrompts.Prompt) = .Value
                                                    Case "VALUES"
                                                        strParmPrompts(ParmPrompts.Values) = .Value
                                                    Case "SHIFT"
                                                        strParmPrompts(ParmPrompts.ShiftType) = .Value
                                                End Select
                                            End While

                                            If m_htParmPrompts.Contains(strJobName) Then
                                                m_htParmPrompts(strJobName & "~occurs" & intOccurs & "~") =
                                                    strParmPrompts
                                                intOccurs = intOccurs + 1
                                            Else
                                                m_htParmPrompts(strJobName) = strParmPrompts
                                                intOccurs = 2
                                            End If

                                        End If
                                End Select
                            End While
                        End With
                    Catch ex As Exception
                        Throw ex
                    Finally
                        objParmPromptXML.Close()
                        objParmPromptXML = Nothing
                    End Try

                End If
            End If

            Session(UniqueSessionID + "m_htParmPrompts") = m_htParmPrompts
        End Sub

        Public Function ExecuteMethod() As Boolean

            Dim intSequence As Integer = 0
            m_intRunScreenSequence += 1
            intSequence = m_intRunScreenSequence

            Dim blnMethodWasExecuted As Boolean
            blnMethodWasExecuted = MethodWasExecuted(intSequence, "RUN_FLAG")

            If blnMethodWasExecuted Then
                Return False
            Else
                ' Save the sequence information and set a flag indicating screen was run.
                SetMethodExecutedFlag(m_strRunFlag, "RUN_FLAG", intSequence)

                If _
                    Not IsNothing(Session(UniqueSessionID + "RunJob")) AndAlso
                    Session(UniqueSessionID + "RunJob") = False Then
                    Session.Remove(UniqueSessionID + "RunJob")
                    Return False
                End If

                Return True
            End If
        End Function

        'Public Function WriteToJobScript(ScriptName As String, strName As String, Type As JobScriptType,
        '                                 ByVal ParamArray arrValue() As String) As Boolean

        '    Try

        '        Dim strValue As String = String.Empty

        '        Dim intSequence As Integer
        '        Dim strUserID As String = String.Empty
        '        Dim dtStartDate As Date
        '        Dim dtLastAccessTime As Date
        '        Dim blnIsActive As Boolean
        '        Dim intNumberedSessionID As Int32
        '        Dim strParm As String = String.Empty

        '        SessionInformation.GetSessionInformation(Session("SessionID"), strUserID, dtStartDate, dtLastAccessTime,
        '                                                 blnIsActive, intNumberedSessionID, UniqueSessionID)

        '        m_htParmPrompts = Session(UniqueSessionID + "m_htParmPrompts")
        '        If IsNothing(m_htParmPrompts) Then ReadParmPrompts()

        '        If m_htParmPrompts.Contains(strName) AndAlso arrValue.Length = 1 Then

        '            Dim JOB As New CoreCharacter("JOB", 20, Me, ResetTypes.ResetAtStartup)
        '            Dim PARM1 As New CoreCharacter("PARM1", 200, Me, ResetTypes.ResetAtStartup, "")
        '            Dim PARM2 As New CoreCharacter("PARM2", 200, Me, ResetTypes.ResetAtStartup, "")
        '            Dim PARM3 As New CoreCharacter("PARM3", 200, Me, ResetTypes.ResetAtStartup, "")
        '            Dim PARM4 As New CoreCharacter("PARM4", 200, Me, ResetTypes.ResetAtStartup, "")
        '            Dim PARM5 As New CoreCharacter("PARM5", 200, Me, ResetTypes.ResetAtStartup, "")
        '            Dim PARM6 As New CoreCharacter("PARM6", 200, Me, ResetTypes.ResetAtStartup, "")
        '            Dim PARM7 As New CoreCharacter("PARM7", 200, Me, ResetTypes.ResetAtStartup, "")
        '            Dim PARM8 As New CoreCharacter("PARM8", 200, Me, ResetTypes.ResetAtStartup, "")
        '            Dim PARM9 As New CoreCharacter("PARM9", 200, Me, ResetTypes.ResetAtStartup, "")
        '            Dim PARM10 As New CoreCharacter("PARM10", 200, Me, ResetTypes.ResetAtStartup, "")

        '            Dim PARM1TYPE As New CoreCharacter("PARM1TYPE", 300, Me, ResetTypes.ResetAtStartup, "")
        '            Dim PARM2TYPE As New CoreCharacter("PARM2TYPE", 300, Me, ResetTypes.ResetAtStartup, "")
        '            Dim PARM3TYPE As New CoreCharacter("PARM3TYPE", 300, Me, ResetTypes.ResetAtStartup, "")
        '            Dim PARM4TYPE As New CoreCharacter("PARM4TYPE", 300, Me, ResetTypes.ResetAtStartup, "")
        '            Dim PARM5TYPE As New CoreCharacter("PARM5TYPE", 300, Me, ResetTypes.ResetAtStartup, "")
        '            Dim PARM6TYPE As New CoreCharacter("PARM6TYPE", 300, Me, ResetTypes.ResetAtStartup, "")
        '            Dim PARM7TYPE As New CoreCharacter("PARM7TYPE", 300, Me, ResetTypes.ResetAtStartup, "")
        '            Dim PARM8TYPE As New CoreCharacter("PARM8TYPE", 300, Me, ResetTypes.ResetAtStartup, "")
        '            Dim PARM9TYPE As New CoreCharacter("PARM9TYPE", 300, Me, ResetTypes.ResetAtStartup, "")
        '            Dim PARM10TYPE As New CoreCharacter("PARM10TYPE", 300, Me, ResetTypes.ResetAtStartup, "")

        '            JOB.Value = strName

        '            Dim chooseFlag As String = String.Empty
        '            PARM1TYPE.Value = m_htParmPrompts(strName)(1).ToString.Trim & "~" &
        '                              m_htParmPrompts(strName)(2).ToString.Trim & "~" &
        '                              m_htParmPrompts(strName)(3).ToString.Trim & "~" &
        '                              m_htParmPrompts(strName)(4).ToString.Trim & "~" &
        '                              m_htParmPrompts(strName)(5).ToString.Trim & "~" &
        '                              m_htParmPrompts(strName)(6).ToString.Trim

        '            If m_htParmPrompts.Contains(strName & "~occurs2~") Then
        '                PARM2TYPE.Value = m_htParmPrompts(strName & "~occurs2~")(1).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs2~")(2).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs2~")(3).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs2~")(4).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs2~")(5).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs2~")(6).ToString.Trim
        '            End If
        '            If m_htParmPrompts.Contains(strName & "~occurs3~") Then
        '                PARM3TYPE.Value = m_htParmPrompts(strName & "~occurs3~")(1).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs3~")(2).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs3~")(3).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs3~")(4).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs3~")(5).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs3~")(6).ToString.Trim
        '            End If
        '            If m_htParmPrompts.Contains(strName & "~occurs4~") Then
        '                PARM4TYPE.Value = m_htParmPrompts(strName & "~occurs4~")(1).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs4~")(2).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs4~")(3).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs4~")(4).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs4~")(5).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs4~")(6).ToString.Trim
        '            End If
        '            If m_htParmPrompts.Contains(strName & "~occurs5~") Then
        '                PARM5TYPE.Value = m_htParmPrompts(strName & "~occurs5~")(1).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs5~")(2).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs5~")(3).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs5~")(4).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs5~")(5).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs5~")(6).ToString.Trim
        '            End If
        '            If m_htParmPrompts.Contains(strName & "~occurs6~") Then
        '                PARM6TYPE.Value = m_htParmPrompts(strName & "~occurs6~")(1).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs6~")(2).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs6~")(3).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs6~")(4).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs6~")(5).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs6~")(6).ToString.Trim
        '            End If
        '            If m_htParmPrompts.Contains(strName & "~occurs7~") Then
        '                PARM7TYPE.Value = m_htParmPrompts(strName & "~occurs7~")(1).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs7~")(2).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs7~")(3).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs7~")(4).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs7~")(5).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs7~")(6).ToString.Trim
        '            End If
        '            If m_htParmPrompts.Contains(strName & "~occurs8~") Then
        '                PARM8TYPE.Value = m_htParmPrompts(strName & "~occurs8~")(1).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs8~")(2).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs8~")(3).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs8~")(4).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs8~")(5).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs8~")(6).ToString.Trim
        '            End If
        '            If m_htParmPrompts.Contains(strName & "~occurs9~") Then
        '                PARM9TYPE.Value = m_htParmPrompts(strName & "~occurs9~")(1).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs9~")(2).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs9~")(3).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs9~")(4).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs9~")(5).ToString.Trim & "~" &
        '                                  m_htParmPrompts(strName & "~occurs9~")(6).ToString.Trim
        '            End If
        '            If m_htParmPrompts.Contains(strName & "~occurs10~") Then
        '                PARM10TYPE.Value = m_htParmPrompts(strName & "~occurs10~")(1).ToString.Trim & "~" &
        '                                   m_htParmPrompts(strName & "~occurs10~")(2).ToString.Trim & "~" &
        '                                   m_htParmPrompts(strName & "~occurs10~")(3).ToString.Trim & "~" &
        '                                   m_htParmPrompts(strName & "~occurs10~")(4).ToString.Trim & "~" &
        '                                   m_htParmPrompts(strName & "~occurs10~")(5).ToString.Trim & "~" &
        '                                   m_htParmPrompts(strName & "~occurs10~")(6).ToString.Trim
        '            End If

        '            If Session(UniqueSessionID + "RunJob") Is Nothing Then Session(UniqueSessionID + "RunJob") = False

        '            RunScreen("JobControl/ParameterScreen", RunScreenModes.Entry, JOB, PARM1, PARM2, PARM3, PARM4, PARM5,
        '                      PARM6, PARM7, PARM8, PARM9, PARM10, PARM1TYPE, PARM2TYPE, PARM3TYPE, PARM4TYPE, PARM5TYPE,
        '                      PARM6TYPE, PARM7TYPE, PARM8TYPE, PARM9TYPE, PARM10TYPE)

        '            strParm = arrValue(0) &
        '                      AddQuotes(PARM1.Value.Trim, PARM1TYPE.Value.Split("~")(0), PARM1TYPE.Value.Split("~")(3))
        '            If PARM2TYPE.Value.Trim.Length > 0 Then
        '                strParm = strParm & "," &
        '                          AddQuotes(PARM2.Value.Trim, PARM2TYPE.Value.Split("~")(0),
        '                                    PARM2TYPE.Value.Split("~")(3))
        '            End If
        '            If PARM3TYPE.Value.Trim.Length > 0 Then
        '                strParm = strParm & "," &
        '                          AddQuotes(PARM3.Value.Trim, PARM3TYPE.Value.Split("~")(0),
        '                                    PARM3TYPE.Value.Split("~")(3))
        '            End If
        '            If PARM4TYPE.Value.Trim.Length > 0 Then
        '                strParm = strParm & "," &
        '                          AddQuotes(PARM4.Value.Trim, PARM4TYPE.Value.Split("~")(0),
        '                                    PARM4TYPE.Value.Split("~")(3))
        '            End If
        '            If PARM5TYPE.Value.Trim.Length > 0 Then
        '                strParm = strParm & "," &
        '                          AddQuotes(PARM5.Value.Trim, PARM5TYPE.Value.Split("~")(0),
        '                                    PARM5TYPE.Value.Split("~")(3))
        '            End If
        '            If PARM6TYPE.Value.Trim.Length > 0 Then
        '                strParm = strParm & "," &
        '                          AddQuotes(PARM6.Value.Trim, PARM6TYPE.Value.Split("~")(0),
        '                                    PARM6TYPE.Value.Split("~")(3))
        '            End If
        '            If PARM7TYPE.Value.Trim.Length > 0 Then
        '                strParm = strParm & "," &
        '                          AddQuotes(PARM7.Value.Trim, PARM7TYPE.Value.Split("~")(0),
        '                                    PARM7TYPE.Value.Split("~")(3))
        '            End If
        '            If PARM8TYPE.Value.Trim.Length > 0 Then
        '                strParm = strParm & "," &
        '                          AddQuotes(PARM8.Value.Trim, PARM8TYPE.Value.Split("~")(0),
        '                                    PARM8TYPE.Value.Split("~")(3))
        '            End If
        '            If PARM9TYPE.Value.Trim.Length > 0 Then
        '                strParm = strParm & "," &
        '                          AddQuotes(PARM9.Value.Trim, PARM9TYPE.Value.Split("~")(0),
        '                                    PARM8TYPE.Value.Split("~")(3))
        '            End If
        '            If PARM10TYPE.Value.Trim.Length > 0 Then
        '                strParm = strParm & "," &
        '                          AddQuotes(PARM10.Value.Trim, PARM10TYPE.Value.Split("~")(0),
        '                                    PARM10TYPE.Value.Split("~")(3))
        '            End If

        '        End If

        '        If m_blnStartJobScript Then

        '            strName = strName.TrimEnd

        '            m_intRunScreenSequence += 1
        '            intSequence = m_intRunScreenSequence

        '            Dim blnMethodWasExecuted As Boolean
        '            blnMethodWasExecuted = MethodWasExecuted(intSequence, "RUN_FLAG")

        '            If Not blnMethodWasExecuted Then
        '                ' Save the sequence information and set a flag indicating screen was run.
        '                SetMethodExecutedFlag(m_strRunFlag, "RUN_FLAG", intSequence)

        '                If strParm.Length > 0 Then
        '                    strValue = strParm
        '                Else
        '                    For i As Integer = 0 To arrValue.Length - 1
        '                        strValue = strValue & arrValue(i) & "~"
        '                    Next
        '                    strValue = strValue.Substring(0, strValue.Length - 1)
        '                End If

        '                Dim dtNow As String = String.Empty

        '                If IsNothing(Session(UniqueSessionID + "dtNow")) Then
        '                    dtNow = ServerDateTimeValue()
        '                    Session(UniqueSessionID + "dtNow") = dtNow
        '                Else
        '                    dtNow = Session(UniqueSessionID + "dtNow")
        '                End If

        '                Dim strJobScriptPath As String = JobScriptPath()
        '                If Not Directory.Exists(strJobScriptPath) Then Directory.CreateDirectory(strJobScriptPath)
        '                Dim sw As StreamWriter =
        '                        New StreamWriter(
        '                            strJobScriptPath & ScriptName & "_" & Session("SessionID") & "_" & strUserID & "_" &
        '                            dtNow & ".txt", m_blnAppendJobScript)
        '                m_blnAppendJobScript = True

        '                sw.Write("USER," & strUserID & vbNewLine)

        '                Select Case Type
        '                    Case JobScriptType.Keep
        '                        sw.Write("KEEP" & vbNewLine)
        '                    Case JobScriptType.QTP
        '                        sw.Write("QTP~" & strName & "~" & strValue & vbNewLine)
        '                    Case JobScriptType.QUIZ
        '                        sw.Write("QUIZ~PDF~" & strName & "~" & strValue & vbNewLine)
        '                    Case JobScriptType.Screen
        '                        sw.Write("SCREEN~" & strName & "~" & vbNewLine)
        '                    Case JobScriptType.Job
        '                        m_strJobParams = strName & "~" & strValue.Substring(arrValue(0).Length)
        '                        sw.Write(strName & "~" & strValue & vbNewLine)
        '                    Case JobScriptType.SetSystemval
        '                        sw.Write("SetSystemval~" & strValue & vbNewLine)
        '                    Case JobScriptType.LOG
        '                        sw.Write("LOG~" & strName & "~" & strValue & vbNewLine)
        '                    Case JobScriptType.MACRO
        '                        sw.Write("MACRO~" & strName & "~" & strValue & vbNewLine)
        '                    Case JobScriptType.TXT
        '                        sw.Write("QUIZ~TXT~" & strName & "~" & strValue & vbNewLine)
        '                End Select

        '                sw.Close()

        '            End If
        '            Return True

        '        End If

        '        Return False

        '    Catch ex As CustomApplicationException
        '        Throw ex
        '    Catch ex As Exception

        '        ' Write the exception to the event log and throw an error.
        '        ExceptionManager.Publish(ex)
        '        Throw ex

        '    End Try
        'End Function

        ' NOTE: This function also exists in Page.aspx.vb.  If you update this function, also update the
        '       the one there.
        Private Function AddQuotes(value As String, dataType As String, isChoose As String) As String

            If isChoose = "Y" Then
                If dataType = "CHR" Then
                    If value.IndexOf(",") > -1 Then
                        Dim ar() As String = value.Split(",")
                        For i As Integer = 0 To ar.Length - 1
                            ar(i) = StringToField(ar(i))
                        Next
                        value = Join(ar, CORE_DELIMITER)
                    Else
                        If GetSystemVal("CHOOSE") = "Y" Then
                            DeleteSystemVal("CHOOSE")
                        Else
                            value = StringToField(value)
                        End If
                    End If
                Else
                    value = value.Replace(",", CORE_DELIMITER)
                End If
            End If

            Return value
        End Function

        '----------------------------
        ' CalledPageSession property uses Session Collection, however to make it
        ' readable and maitainable it adds
        ' prefix "PageName_Level_" to SessionKey passed, which mimics
        ' a Page-Specific Session
        '----------------------------
        ''' --- CalledPageSession --------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of CalledPageSession.
        ''' </summary>
        ''' <param name="CalledScreenName"></param>
        ''' <param name="CalledScreenLevel"></param>
        ''' <param name="PageSessionKey"></param>
        ''' <param name="strSequence"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Bindable(False),
            Browsable(False),
            EditorBrowsable(EditorBrowsableState.Advanced)>
        Friend Property CalledPageSession(CalledScreenName As String, CalledScreenLevel As Integer,
                                          PageSessionKey As String, strSequence As String) As Object
            Get
                Dim strPageSessionKey As String = CalledScreenName + "_" + CalledScreenLevel.ToString + "_" +
                                                  strSequence + "_" + PageSessionKey
                Return Me.Session(UniqueSessionID + strPageSessionKey)
            End Get
            Set(Value As Object)
                Dim strPageSessionKey As String = CalledScreenName + "_" + CalledScreenLevel.ToString + "_" +
                                                  strSequence + "_" + PageSessionKey
                Me.Session(UniqueSessionID + strPageSessionKey) = Value
            End Set
        End Property

        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Function RunJobNow(RunJobName As String) As String

            m_blnStartJobScript = False
            m_blnAppendJobScript = False

            Dim strUserID As String = String.Empty
            Dim dtStartDate As Date
            Dim dtLastAccessTime As Date
            Dim blnIsActive As Boolean
            Dim intNumberedSessionID As Int32
            Dim dtNow As String = Session(UniqueSessionID + "dtNow")
            If IsNothing(dtNow) OrElse dtNow = "" Then
                dtNow = ServerDateTimeValue()
            End If
            SessionInformation.GetSessionInformation(Session("SessionID"), strUserID, dtStartDate, dtLastAccessTime,
                                                     blnIsActive, intNumberedSessionID, UniqueSessionID)
            RunJobName = RunJobName.Trim & "_" & Session("SessionID") & "_" & strUserID & "_" & dtNow

            Dim jobName As String = JobScriptPath() & RunJobName.Trim & ".txt"

            Dim sr As New StreamReader(jobName)
            Dim strText As String = sr.ReadToEnd
            sr.Close()
            sr.Dispose()

            'strText = strText.Replace("QUIZ~", "QUIZ~PDF~")

            Dim sw As New StreamWriter(jobName, False)
            sw.Write(strText)
            sw.Close()
            sw.Dispose()

            Session(UniqueSessionID + "dtNow") = Nothing
            Session.Remove(UniqueSessionID + "RunJob")

            Return jobName
        End Function

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub RunJob(RunJobName As String)

            m_blnStartJobScript = False
            m_blnAppendJobScript = False


            m_strRunScreenFolder = "JobControl"
            m_strRunScreen = "JobControl"

            m_intRunScreenSequence += 1

            Dim blnMethodWasExecuted As Boolean
            blnMethodWasExecuted = MethodWasExecuted(m_strRunFlag, m_intRunScreenSequence, "RUN_FLAG")

            If Not blnMethodWasExecuted Then

                Dim strUserID As String = String.Empty
                Dim dtStartDate As Date
                Dim dtLastAccessTime As Date
                Dim blnIsActive As Boolean
                Dim intNumberedSessionID As Int32
                Dim dtNow As String = Session(UniqueSessionID + "dtNow")
                If IsNothing(dtNow) OrElse dtNow = "" Then
                    dtNow = ServerDateTimeValue()
                End If
                Session(UniqueSessionID + "dtNow") = Nothing

                SessionInformation.GetSessionInformation(Session("SessionID"), strUserID, dtStartDate, dtLastAccessTime,
                                                         blnIsActive, intNumberedSessionID, UniqueSessionID)

                RunJobName = RunJobName.Trim & "_" & Session("SessionID") & "_" & strUserID & "_" & dtNow

                ' Save the sequence information and set a flag indicating screen was run.
                SetMethodExecutedFlag(m_strRunFlag, "RUN_FLAG", m_intRunScreenSequence)

                ' Save the parameters passed to the RUN SCREEN.

                Me.CalledPageSession(m_strRunScreen, Me.Level + 1, "PARM1", m_intRunScreenSequence.ToString) =
                    RunJobName.Trim
                Me.CalledPageSession(m_strRunScreen, Me.Level + 1, "PARM2", m_intRunScreenSequence.ToString) =
                    JobScriptPath() & RunJobName.Trim & ".txt"

                ' Track the total sessions, so we can remove these upon returning from the run screen.
                Session(
                    UniqueSessionID + m_strRunScreen + "_" + (Me.Level + 1).ToString + "_" +
                    m_intRunScreenSequence.ToString) = Session.Count

                ' Default: E for subscreen invoked during the standard entry procedure, otherwise NULL.

                Session(UniqueSessionID + m_strRunScreen + "_" + (Me.Level + 1).ToString + "_ScreenSequence") =
                    m_intRunScreenSequence.ToString
                Session(UniqueSessionID + "ScreenLevel") += 1

                Session(UniqueSessionID + m_strRunScreen + "_" + (Me.Level + 1).ToString + "_Mode") =
                    RunScreenModes.Entry

                QDesign.ThrowCustomApplicationException(cRunScreenException)

            End If

            If blnMethodWasExecuted Then

                ' Decrement the ScreenLevel.
                Session(UniqueSessionID + "ScreenLevel") = Me.Level

                ' Remove the Mode and ScreenSequence session information for the screen called.
                Session.Remove(UniqueSessionID + m_strRunScreen + "_" + (Me.Level + 1).ToString + "_Mode")
                Session.Remove(UniqueSessionID + m_strRunScreen + "_" + (Me.Level + 1).ToString + "_ScreenSequence")

                DeleteSessions(
                    Session(
                        UniqueSessionID + m_strRunScreen + "_" + (Me.Level + 1).ToString + "_" +
                        m_intRunScreenSequence.ToString))
                Session.Remove(
                    UniqueSessionID + m_strRunScreen + "_" + (Me.Level + 1).ToString + "_" +
                    m_intRunScreenSequence.ToString)

                ' Retrieve the parameters back from session.

                ' If a message was thrown on the previous screen, display it in the current screen.
                'DisplayMessagesFromRunScreen(m_strRunScreen + "_" + (Me.Level + 1).ToString + "_" + strSequence.ToString)

            End If

            Session(UniqueSessionID + "dtNow") = Nothing
            Session.Remove(UniqueSessionID + "RunJob")
        End Sub

        ''' --- ServerDateTimeValue ------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Returns the current time on the server.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function ServerDateTimeValue() As String

            Return _
                Now.Year.ToString & Now.Month.ToString.PadLeft(2, "0") & Now.Day.ToString.PadLeft(2, "0") &
                Now.Hour.ToString.PadLeft(2, "0") & Now.Minute.ToString.PadLeft(2, "0") &
                Now.Second.ToString.PadLeft(2, "0")
        End Function

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function AtFinal() As Boolean

            If blnHasBeenSort Then
                If intSorted < intTransactions Then
                    Return False
                Else
                    Return True
                End If
            Else
                If intFirstOverrideOccurs < intFirstRecordCount - 1 Then
                    Return False
                Else
                    Return True
                End If
            End If
        End Function

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function AtInitial() As Boolean

            If blnHasBeenSort Then
                If intSorted = 1 Then
                    Return True
                End If
            Else
                If blnAtInitial = BooleanTypes.False Then
                    Return True
                End If
            End If



            Return False
        End Function

#If TARGET_DB = "INFORMIX" Then

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
       Public Function Sort(ByVal ParamArray arrFileobect() As IfxFileObject) As Boolean

            Dim arrRecNum() As String

            blnHasBeenSort = True
            If intSortCount = 0 AndAlso Not IsNothing(dtSortOrder) Then intSortCount = dtSortOrder.Rows.Count

            If (IsNothing(dtSortOrder) AndAlso IsNothing(dtSorted)) OrElse intSortCount <= 0 Then
                If Me.ScreenType = ScreenTypes.QUIZ And Not blnDeletedSubFile Then
                    blnDeleteSubFile = True
                    Return True
                End If
                Return False
            End If

            If intSorted < intSortCount AndAlso (intRecordLimit = 0 OrElse intRecordLimit > intSorted) Then

                strFileSortName = String.Empty
                If intSorted = 0 Then

                    RaiseEvent ClearFiles(Me, New PageStateEventArgs("_"))

                    intTransactions = dtSortOrder.Rows.Count
                    arrReadInRequests = arrFileInRequests

                    GC.Collect()
                    If m_strQTPOrderBy.Length > 0 Then
                        dtSorted = dtSortOrder
                    Else
                        dtSortOrder.DefaultView.Sort = strSortOrder
                        dtSorted = dtSortOrder.DefaultView.ToTable
                    End If

                    dtSortOrder.Dispose()
                    dtSortOrder = Nothing
                    GC.Collect()

                    If intSortCount > intRecordLimit And intRecordLimit > 0 Then intSortCount = intRecordLimit

                End If
                arrRecNum = dtSorted.Rows(intSorted).Item(0).ToString.Split(",")
                For i As Integer = 0 To arrRecNum.Length - 1
                    arrFileobect(i).OverRideOccurrence = CInt(arrRecNum(i))
                    arrFileobect(i).m_intSortNextOccurence = -1
                    arrFileobect(i).SortOccurrence = -1
                    arrFileobect(i).m_arrOutPutColumns = Nothing
                    arrFileobect(i).m_arrOutPutValues = Nothing
                    If arrFileobect(i).AliasName <> "" Then
                        strFileSortName = strFileSortName & arrFileobect(i).AliasName & "~"
                    Else
                        strFileSortName = strFileSortName & arrFileobect(i).BaseName & "~"
                    End If

                Next

                If intSorted + 1 < intSortCount Then
                    arrRecNum = dtSorted.Rows(intSorted + 1).Item(0).ToString.Split(",")
                    For i As Integer = 0 To arrRecNum.Length - 1
                        arrFileobect(i).m_intSortNextOccurence = CInt(arrRecNum(i))
                    Next
                End If

                intSorted = intSorted + 1
                Return True

            End If

            Return False
        End Function

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
           Public Function Sorted(ByVal ParamArray arrFileobect() As IfxFileObject) As Boolean

            Dim arrRecNum() As String

            blnHasBeenSort = True

            If intSortCount = 0 AndAlso Not IsNothing(dtSortOrder) Then intSortCount = dtSortOrder.Rows.Count

            If IsNothing(dtSortOrder) OrElse dtSortOrder.Rows.Count <= 0 Then
                If Me.ScreenType = ScreenTypes.QUIZ And Not blnDeletedSubFile Then
                    blnDeleteSubFile = True
                    Return True
                End If
                Return False
            End If

            If intSorted < dtSortOrder.Rows.Count Then

                strFileSortName = String.Empty
                If intSorted = 0 Then

                    RaiseEvent ClearFiles(Me, New PageStateEventArgs("_"))

                    intTransactions = dtSortOrder.Rows.Count
                    arrReadInRequests = arrFileInRequests

                    GC.Collect()

                End If
                arrRecNum = dtSortOrder.Rows(intSorted).Item(0).ToString.Split(",")
                For i As Integer = 0 To arrRecNum.Length - 1
                    arrFileobect(i).OverRideOccurrence = CInt(arrRecNum(i))
                    arrFileobect(i).m_intSortNextOccurence = -1
                    arrFileobect(i).SortOccurrence = -1
                    arrFileobect(i).m_arrOutPutColumns = Nothing
                    arrFileobect(i).m_arrOutPutValues = Nothing
                    If arrFileobect(i).AliasName <> "" Then
                        strFileSortName = strFileSortName & arrFileobect(i).AliasName & "~"
                    Else
                        strFileSortName = strFileSortName & arrFileobect(i).BaseName & "~"
                    End If

                Next

                If intSorted + 1 < dtSortOrder.Rows.Count Then
                    arrRecNum = dtSortOrder.Rows(intSorted + 1).Item(0).ToString.Split(",")
                    For i As Integer = 0 To arrRecNum.Length - 1
                        arrFileobect(i).m_intSortNextOccurence = CInt(arrRecNum(i))
                    Next
                End If

                intSorted = intSorted + 1
                Return True

            End If

            Return False
        End Function
#Else

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function Sort(ByVal ParamArray arrFileobect() As OracleFileObject) As Boolean

            Dim arrRecNum() As String

            blnHasBeenSort = True
            If intSortCount = 0 AndAlso Not IsNothing(dtSortOrder) Then intSortCount = dtSortOrder.Rows.Count

            If IsNothing(dtSortOrder) OrElse dtSortOrder.Rows.Count <= 0 Then
                If Me.ScreenType = ScreenTypes.QUIZ And Not blnDeletedSubFile Then
                    blnDeleteSubFile = True
                    Return True
                End If
                Return False
            End If

            If intSorted < dtSortOrder.Rows.Count Then

                strFileSortName = String.Empty
                If intSorted = 0 Then

                    RaiseEvent ClearFiles(Me, New PageStateEventArgs("_"))

                    intTransactions = dtSortOrder.Rows.Count
                    arrReadInRequests = arrFileInRequests

                    GC.Collect()
                    dtSortOrder.DefaultView.Sort = strSortOrder
                    dtSorted = dtSortOrder.DefaultView.ToTable

                End If
                arrRecNum = dtSorted.Rows(intSorted).Item(0).ToString.Split(",")
                For i As Integer = 0 To arrRecNum.Length - 1
                    arrFileobect(i).OverRideOccurrence = CInt(arrRecNum(i))
                    arrFileobect(i).m_intSortNextOccurence = -1
                    arrFileobect(i).SortOccurrence = -1
                    arrFileobect(i).m_arrOutPutColumns = Nothing
                    arrFileobect(i).m_arrOutPutValues = Nothing
                    If arrFileobect(i).AliasName <> "" Then
                        strFileSortName = strFileSortName & arrFileobect(i).AliasName & "~"
                    Else
                        strFileSortName = strFileSortName & arrFileobect(i).BaseName & "~"
                    End If

                Next

                If intSorted + 1 < dtSortOrder.Rows.Count Then
                    arrRecNum = dtSorted.Rows(intSorted + 1).Item(0).ToString.Split(",")
                    For i As Integer = 0 To arrRecNum.Length - 1
                        arrFileobect(i).m_intSortNextOccurence = CInt(arrRecNum(i))
                    Next
                End If

                intSorted = intSorted + 1
                Return True

            End If

            Return False
        End Function

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function Sorted(ByVal ParamArray arrFileobect() As OracleFileObject) As Boolean

            Dim arrRecNum() As String

            blnHasBeenSort = True
            If intSortCount = 0 AndAlso Not IsNothing(dtSortOrder) Then intSortCount = dtSortOrder.Rows.Count

            If IsNothing(dtSortOrder) OrElse dtSortOrder.Rows.Count <= 0 Then
                If Me.ScreenType = ScreenTypes.QUIZ And Not blnDeletedSubFile Then
                    blnDeleteSubFile = True
                    Return True
                End If
                Return False
            End If

            If intSorted < dtSortOrder.Rows.Count Then

                strFileSortName = String.Empty
                If intSorted = 0 Then

                    RaiseEvent ClearFiles(Me, New PageStateEventArgs("_"))

                    intTransactions = dtSortOrder.Rows.Count
                    arrReadInRequests = arrFileInRequests

                    GC.Collect()

                End If
                arrRecNum = dtSortOrder.Rows(intSorted).Item(0).ToString.Split(",")
                For i As Integer = 0 To arrRecNum.Length - 1
                    arrFileobect(i).OverRideOccurrence = CInt(arrRecNum(i))
                    arrFileobect(i).m_intSortNextOccurence = -1
                    arrFileobect(i).SortOccurrence = -1
                    arrFileobect(i).m_arrOutPutColumns = Nothing
                    arrFileobect(i).m_arrOutPutValues = Nothing
                    If arrFileobect(i).AliasName <> "" Then
                        strFileSortName = strFileSortName & arrFileobect(i).AliasName & "~"
                    Else
                        strFileSortName = strFileSortName & arrFileobect(i).BaseName & "~"
                    End If

                Next

                If intSorted + 1 < dtSortOrder.Rows.Count Then
                    arrRecNum = dtSortOrder.Rows(intSorted + 1).Item(0).ToString.Split(",")
                    For i As Integer = 0 To arrRecNum.Length - 1
                        arrFileobect(i).m_intSortNextOccurence = CInt(arrRecNum(i))
                    Next
                End If

                intSorted = intSorted + 1
                Return True

            End If

            Return False
        End Function

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function Sort(ByVal ParamArray arrFileobect() As SqlFileObject) As Boolean

            Dim arrRecNum() As String
            Dim arrNextRecNum() As String
            Dim arrPrevRecNum() As String

            blnHasBeenSort = True
            If intSortCount = 0 AndAlso Not IsNothing(dtSortOrder) Then intSortCount = dtSortOrder.Rows.Count

            If IsNothing(dtSortOrder) OrElse dtSortOrder.Rows.Count <= 0 AndAlso blnDeleteSubFile Then
                If Not blnDeletedSubFile Then
                    blnDeletedSubFile = True
                    Return True
                End If
                Return False
            ElseIf dtSortOrder.Rows.Count = 0 AndAlso Not blnDeletedSubFile Then
                blnDeleteSubFile = True
                Return True
            End If

            If intSorted < dtSortOrder.Rows.Count Then

                strFileSortName = String.Empty
                If intSorted = 0 Then

                    RaiseEvent ClearFiles(Me, New PageStateEventArgs("_"))

                    intTransactions = dtSortOrder.Rows.Count
                    arrReadInRequests = arrFileInRequests

                    GC.Collect()
                    dtSortOrder.DefaultView.Sort = strSortOrder
                    dtSorted = dtSortOrder.DefaultView.ToTable

                End If



                arrRecNum = dtSorted.Rows(intSorted).Item(0).ToString.Split(",")
                For i As Integer = 0 To arrRecNum.Length - 1
                    arrFileobect(i).OverRideOccurrence = CInt(arrRecNum(i))
                    arrFileobect(i).m_intSortNextOccurence = -1
                    arrFileobect(i).SortOccurrence = -1
                    arrFileobect(i).m_arrOutPutColumns = Nothing
                    arrFileobect(i).m_arrOutPutValues = Nothing
                    If arrFileobect(i).AliasName <> "" Then
                        strFileSortName = strFileSortName & arrFileobect(i).AliasName & "~"
                    Else
                        strFileSortName = strFileSortName & arrFileobect(i).BaseName & "~"
                    End If


                    If arrFileobect(i).m_HasAt = False Then
                        arrFileobect(i).m_Subtoal = New Hashtable
                    End If



                Next

                Dim sqlfile As SqlFileObject
                For Each sqlfile In Subtotal_Files
                    If sqlfile.m_HasAt = False Then
                        sqlfile.m_Subtoal = New Hashtable
                    End If
                Next

                For Each sqlfile In InializesFile
                    sqlfile.IsInitialized = False
                    sqlfile.m_blnOutPutOutGet = True
                Next


                'If intSorted + 1 < dtSortOrder.Rows.Count Then
                '    arrRecNum = dtSorted.Rows(intSorted + 1).Item(0).ToString.Split(",")
                '    For i As Integer = 0 To arrRecNum.Length - 1
                '        arrFileobect(i).m_intSortNextOccurence = CInt(arrRecNum(i))
                '    Next
                'End If

                If intSorted <= dtSortOrder.Rows.Count - 1 Then
                    arrRecNum = dtSorted.Rows(intSorted).Item(0).ToString.Split(",")

                    If intSorted = 0 Then
                        If dtSortOrder.Rows.Count > 1 Then
                            arrNextRecNum = dtSorted.Rows(intSorted + 1).Item(0).ToString.Split(",")
                            For i As Integer = 0 To arrRecNum.Length - 1
                                arrFileobect(i).m_intSortNextOccurence = CInt(arrNextRecNum(i))
                            Next
                        End If
                    ElseIf intSorted < dtSortOrder.Rows.Count - 1 Then
                        arrNextRecNum = dtSorted.Rows(intSorted + 1).Item(0).ToString.Split(",")
                        arrPrevRecNum = dtSorted.Rows(intSorted - 1).Item(0).ToString.Split(",")
                        For i As Integer = 0 To arrRecNum.Length - 1
                            arrFileobect(i).m_intSortNextOccurence = CInt(arrNextRecNum(i))
                            arrFileobect(i).m_intSortPreviousOccurence = CInt(arrPrevRecNum(i))
                        Next
                    ElseIf intSorted = dtSortOrder.Rows.Count - 1 Then
                        arrPrevRecNum = dtSorted.Rows(intSorted - 1).Item(0).ToString.Split(",")
                        For i As Integer = 0 To arrRecNum.Length - 1
                            arrFileobect(i).m_intSortPreviousOccurence = CInt(arrPrevRecNum(i))
                        Next
                    End If

                End If

                intSorted = intSorted + 1
                Return True

            End If

            Return False
        End Function

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function Sorted(ByVal ParamArray arrFileobect() As SqlFileObject) As Boolean

            Dim arrRecNum() As String

            blnHasBeenSort = True
            If intSortCount = 0 AndAlso Not IsNothing(dtSortOrder) Then intSortCount = dtSortOrder.Rows.Count

            If IsNothing(dtSortOrder) OrElse dtSortOrder.Rows.Count <= 0 AndAlso blnDeleteSubFile Then
                If Not blnDeletedSubFile Then
                    blnDeleteSubFile = True
                    Return True
                End If
                Return False
            End If

            If intSorted < dtSortOrder.Rows.Count Then

                strFileSortName = String.Empty
                If intSorted = 0 Then

                    RaiseEvent ClearFiles(Me, New PageStateEventArgs("_"))

                    intTransactions = dtSortOrder.Rows.Count
                    arrReadInRequests = arrFileInRequests

                    GC.Collect()

                End If
                arrRecNum = dtSortOrder.Rows(intSorted).Item(0).ToString.Split(",")
                For i As Integer = 0 To arrRecNum.Length - 1
                    arrFileobect(i).OverRideOccurrence = CInt(arrRecNum(i))
                    arrFileobect(i).m_intSortNextOccurence = -1
                    arrFileobect(i).SortOccurrence = -1
                    arrFileobect(i).m_arrOutPutColumns = Nothing
                    arrFileobect(i).m_arrOutPutValues = Nothing
                    If arrFileobect(i).AliasName <> "" Then
                        strFileSortName = strFileSortName & arrFileobect(i).AliasName & "~"
                    Else
                        strFileSortName = strFileSortName & arrFileobect(i).BaseName & "~"
                    End If

                Next

                If intSorted + 1 < dtSortOrder.Rows.Count Then
                    arrRecNum = dtSortOrder.Rows(intSorted + 1).Item(0).ToString.Split(",")
                    For i As Integer = 0 To arrRecNum.Length - 1
                        arrFileobect(i).m_intSortNextOccurence = CInt(arrRecNum(i))
                    Next
                End If

                intSorted = intSorted + 1
                Return True

            End If

            Return False
        End Function

        Public Sub SubTotal(ByRef objFileObject As SqlFileObject, strColumn As String, value As Decimal,
                            ItemType As ItemType)
            If ItemType = ItemType.Negative Then
                objFileObject.SetValue(strColumn) = objFileObject.GetDecimalValue(strColumn) - value
            Else
                objFileObject.SetValue(strColumn) = objFileObject.GetDecimalValue(strColumn) + value
            End If
        End Sub

        Public Sub SubTotal(ByRef objFileObject As SqlFileObject, strColumn As String, value As Decimal)

            Dim v As Decimal

            If blnHasSort Then

                If IsNothing(objFileObject.m_Subtoal) Then
                    objFileObject.m_Subtoal = New Hashtable
                End If

                If objFileObject.m_Subtoal.Contains(strColumn) Then
                    v = objFileObject.m_Subtoal(strColumn) + value
                    objFileObject.m_Subtoal(strColumn) = v
                Else
                    objFileObject.m_Subtoal.Add(strColumn, objFileObject.GetDecimalValue(strColumn) + value)
                    v = objFileObject.GetDecimalValue(strColumn) + value
                End If

                objFileObject.SetValue(strColumn) = v
            Else
                objFileObject.SetValue(strColumn) = objFileObject.GetDecimalValue(strColumn) + value
            End If




        End Sub

        Public Sub SubTotal(ByRef objFileObject As OracleFileObject, strColumn As String, value As Decimal,
                            ItemType As ItemType)
            If ItemType = ItemType.Negative Then
                objFileObject.SetValue(strColumn) = objFileObject.GetDecimalValue(strColumn) - value
            Else
                objFileObject.SetValue(strColumn) = objFileObject.GetDecimalValue(strColumn) + value
            End If
        End Sub

        Public Sub SubTotal(ByRef objFileObject As OracleFileObject, strColumn As String, value As Decimal)
            objFileObject.SetValue(strColumn) = objFileObject.GetDecimalValue(strColumn) + value
        End Sub

        'SubTotal AT
        Public Sub SubTotal(ByRef objFileObject As SqlFileObject, strColumn As String, value As Decimal,
                            blnAt As Boolean, ItemType As ItemType)
            If blnAt Then
                If ItemType = ItemType.Negative Then
                    objFileObject.SetValue(strColumn) = objFileObject.GetDecimalValue(strColumn) - value
                Else
                    objFileObject.SetValue(strColumn) = objFileObject.GetDecimalValue(strColumn) + value
                End If
            End If
        End Sub

        Public Sub SubTotal(ByRef objFileObject As SqlFileObject, strColumn As String, value As Decimal,
                            blnAt As Boolean)
            If blnAt Then
                objFileObject.SetValue(strColumn) = objFileObject.GetDecimalValue(strColumn) + value
            End If
        End Sub

        Public Sub SubTotal(ByRef objFileObject As OracleFileObject, strColumn As String, value As Decimal,
                            blnAt As Boolean, Optional ByVal ItemType As ItemType = ItemType.Positive)
            If blnAt Then
                If ItemType = ItemType.Negative Then
                    objFileObject.SetValue(strColumn) = objFileObject.GetDecimalValue(strColumn) - value
                Else
                    objFileObject.SetValue(strColumn) = objFileObject.GetDecimalValue(strColumn) + value
                End If
            End If
        End Sub

        Public Sub SubTotal(ByRef objFileObject As SqlFileObject, strColumn As String, value As Decimal,
                            blnAt As Boolean, blnCondition As Boolean,
                            Optional ByVal ItemType As ItemType = ItemType.Positive)
            If blnAt AndAlso blnCondition Then
                If ItemType = ItemType.Negative Then
                    objFileObject.SetValue(strColumn) = objFileObject.GetDecimalValue(strColumn) - value
                Else
                    objFileObject.SetValue(strColumn) = objFileObject.GetDecimalValue(strColumn) + value
                End If
            End If
        End Sub

        Public Sub SubTotal(ByRef objFileObject As OracleFileObject, strColumn As String, value As Decimal,
                            blnAt As Boolean, blnCondition As Boolean,
                            Optional ByVal ItemType As ItemType = ItemType.Positive)
            If blnAt AndAlso blnCondition Then
                If ItemType = ItemType.Negative Then
                    objFileObject.SetValue(strColumn) = objFileObject.GetDecimalValue(strColumn) - value
                Else
                    objFileObject.SetValue(strColumn) = objFileObject.GetDecimalValue(strColumn) + value
                End If
            End If
        End Sub

#End If

        Public Sub SubTotal(ByRef objVariable As CoreDecimal, value As Decimal, ItemType As ItemType)
            If ItemType = ItemType.Negative Then
                objVariable.Value = objVariable.Value - value
            Else
                objVariable.Value = objVariable.Value + value
            End If
        End Sub

        Public Sub SubTotal(ByRef objVariable As CoreDecimal, value As Decimal)
            objVariable.Value = objVariable.Value + value
        End Sub

        Public Sub SubTotal(ByRef objVariable As CoreInteger, value As Decimal, ItemType As ItemType)
            If ItemType = ItemType.Negative Then
                objVariable.Value = objVariable.Value - value
            Else
                objVariable.Value = objVariable.Value + value
            End If
        End Sub

        Public Sub SubTotal(ByRef objVariable As CoreInteger, value As Decimal)
            objVariable.Value = objVariable.Value + value
        End Sub

        Public Sub SubTotal(ByRef objVariable As CoreDecimal, value As Decimal, blnAt As Boolean,
                            Optional ByVal ItemType As ItemType = ItemType.Positive)
            If blnAt Then
                If ItemType = ItemType.Negative Then
                    objVariable.Value = objVariable.Value - value
                Else
                    objVariable.Value = objVariable.Value + value
                End If
            End If
        End Sub

        Public Sub SubTotal(ByRef objVariable As CoreDecimal, value As Decimal, blnAt As Boolean,
                            blnCondition As Boolean, Optional ByVal ItemType As ItemType = ItemType.Positive)
            If blnAt AndAlso blnCondition Then
                If ItemType = ItemType.Negative Then
                    objVariable.Value = objVariable.Value - value
                Else
                    objVariable.Value = objVariable.Value + value
                End If
            End If
        End Sub

        Public Sub SubTotal(ByRef objVariable As CoreDecimal, value As Decimal, blnAt As Boolean)
            If blnAt Then
                objVariable.Value = objVariable.Value + value
            End If
        End Sub

        Public Sub SubTotal(ByRef objVariable As CoreInteger, value As Decimal, blnAt As Boolean, ItemType As ItemType)
            If blnAt Then
                If ItemType = ItemType.Negative Then
                    objVariable.Value = objVariable.Value - value
                Else
                    objVariable.Value = objVariable.Value + value
                End If
            End If
        End Sub

        Public Sub SubTotal(ByRef objVariable As CoreInteger, value As Decimal, blnAt As Boolean)
            If blnAt Then
                objVariable.Value = objVariable.Value + value
            End If
        End Sub

        Public Sub SubTotal(ByRef objVariable As CoreInteger, value As Decimal, blnAt As Boolean,
                            blnCondition As Boolean, ItemType As ItemType)
            If blnAt AndAlso blnCondition Then
                If ItemType = ItemType.Negative Then
                    objVariable.Value = objVariable.Value - value
                Else
                    objVariable.Value = objVariable.Value + value
                End If
            End If
        End Sub


        Public Sub SubTotal(ByRef objVariable As CoreInteger, value As Decimal, blnAt As Boolean,
                            blnCondition As Boolean)
            If blnAt AndAlso blnCondition Then
                objVariable.Value = objVariable.Value + value

            End If
        End Sub

        Public Sub Count(ByRef objFileObject As SqlFileObject, strColumn As String, ItemType As ItemType)
            Dim strName As String = String.Empty
            If objFileObject.AliasName <> "" Then
                strName = objFileObject.AliasName & "_" & strColumn
            Else
                strName = objFileObject.BaseName & "_" & strColumn
            End If

            If ItemType = ItemType.Negative Then
                objFileObject.SetValue(strColumn) = objFileObject.GetDecimalValue(strColumn) - 1
            Else
                objFileObject.SetValue(strColumn) = objFileObject.GetDecimalValue(strColumn) + 1
            End If
        End Sub

        Public Sub Count(ByRef objFileObject As SqlFileObject, strColumn As String)
            Dim strName As String = String.Empty
            If objFileObject.AliasName <> "" Then
                strName = objFileObject.AliasName & "_" & strColumn
            Else
                strName = objFileObject.BaseName & "_" & strColumn
            End If

            objFileObject.SetValue(strColumn) = objFileObject.GetDecimalValue(strColumn) + 1
        End Sub

        Public Sub Count(ByRef objFileObject As OracleFileObject, strColumn As String, ItemType As ItemType)
            Dim strName As String = String.Empty
            If objFileObject.AliasName <> "" Then
                strName = objFileObject.AliasName & "_" & strColumn
            Else
                strName = objFileObject.BaseName & "_" & strColumn
            End If

            If ItemType = ItemType.Negative Then
                objFileObject.SetValue(strColumn) = objFileObject.GetDecimalValue(strColumn) - 1
            Else
                objFileObject.SetValue(strColumn) = objFileObject.GetDecimalValue(strColumn) + 1
            End If
        End Sub

        Public Sub Count(ByRef objFileObject As OracleFileObject, strColumn As String)
            Dim strName As String = String.Empty
            If objFileObject.AliasName <> "" Then
                strName = objFileObject.AliasName & "_" & strColumn
            Else
                strName = objFileObject.BaseName & "_" & strColumn
            End If

            objFileObject.SetValue(strColumn) = objFileObject.GetDecimalValue(strColumn) + 1
        End Sub

        Public Sub Count(ByRef objVariable As CoreDecimal, ItemType As ItemType)
            Dim strName As String = objVariable.m_strVariableName
            If ItemType = ItemType.Negative Then
                objVariable.Value = objVariable.Value - 1
            Else
                objVariable.Value = objVariable.Value + 1
            End If
        End Sub

        Public Sub Count(ByRef objVariable As CoreDecimal)
            Dim strName As String = objVariable.m_strVariableName
            objVariable.Value = objVariable.Value + 1
        End Sub

        Public Sub Count(ByRef objVariable As CoreInteger, ItemType As ItemType)
            Dim strName As String = objVariable.m_strVariableName
            If ItemType = ItemType.Negative Then
                objVariable.Value = objVariable.Value - 1
            Else
                objVariable.Value = objVariable.Value + 1
            End If
        End Sub

        Public Sub Count(ByRef objVariable As CoreInteger)
            Dim strName As String = objVariable.m_strVariableName
            objVariable.Value = objVariable.Value + 1
        End Sub

        Public Sub Count(ByRef objFileObject As SqlFileObject, strColumn As String, blnAt As Boolean,
                         ItemType As ItemType)
            If blnAt Then
                Count(objFileObject, strColumn, ItemType)
            End If
        End Sub

        Public Sub Count(ByRef objFileObject As SqlFileObject, strColumn As String, blnAt As Boolean)
            If blnAt Then
                Count(objFileObject, strColumn)
            End If
        End Sub

        Public Sub Count(ByRef objFileObject As OracleFileObject, strColumn As String, blnAt As Boolean,
                         ItemType As ItemType)
            If blnAt Then
                Count(objFileObject, strColumn, ItemType)
            End If
        End Sub

        Public Sub Count(ByRef objFileObject As OracleFileObject, strColumn As String, blnAt As Boolean)
            If blnAt Then
                Count(objFileObject, strColumn)
            End If
        End Sub

        Public Sub Count(ByRef objFileObject As OracleFileObject, strColumn As String, blnAt As Boolean,
                         blnCondition As Boolean, ItemType As ItemType)
            If blnAt AndAlso blnCondition Then
                Count(objFileObject, strColumn, ItemType)
            End If
        End Sub

        Public Sub Count(ByRef objFileObject As OracleFileObject, strColumn As String, blnAt As Boolean,
                         blnCondition As Boolean)
            If blnAt AndAlso blnCondition Then
                Count(objFileObject, strColumn)
            End If
        End Sub

        Public Sub Count(ByRef objFileObject As SqlFileObject, strColumn As String, blnAt As Boolean,
                         blnCondition As Boolean, ItemType As ItemType)
            If blnAt AndAlso blnCondition Then
                Count(objFileObject, strColumn, ItemType)
            End If
        End Sub

        Public Sub Count(ByRef objFileObject As SqlFileObject, strColumn As String, blnAt As Boolean,
                         blnCondition As Boolean)
            If blnAt AndAlso blnCondition Then
                Count(objFileObject, strColumn)
            End If
        End Sub

        Public Sub Count(ByRef objVariable As CoreDecimal, blnAt As Boolean, ItemType As ItemType)
            If blnAt Then
                Count(objVariable, ItemType)
            End If
        End Sub

        Public Sub Count(ByRef objVariable As CoreDecimal, blnAt As Boolean)
            If blnAt Then
                Count(objVariable)
            End If
        End Sub

        Public Sub Count(ByRef objVariable As CoreDecimal, blnAt As Boolean, blnCondition As Boolean,
                         ItemType As ItemType)
            If blnAt AndAlso blnCondition Then
                Count(objVariable, ItemType)
            End If
        End Sub

        Public Sub Count(ByRef objVariable As CoreDecimal, blnAt As Boolean, blnCondition As Boolean)
            If blnAt AndAlso blnCondition Then
                Count(objVariable)
            End If
        End Sub

        Public Sub Count(ByRef objVariable As CoreInteger, blnAt As Boolean, ItemType As ItemType)
            If blnAt Then
                Count(objVariable, ItemType)
            End If
        End Sub

        Public Sub Count(ByRef objVariable As CoreInteger, blnAt As Boolean)
            If blnAt Then
                Count(objVariable)
            End If
        End Sub

        Public Sub Count(ByRef objVariable As CoreInteger, blnAt As Boolean, blnCondition As Boolean,
                         ItemType As ItemType)
            If blnAt AndAlso blnCondition Then
                Count(objVariable, ItemType)
            End If
        End Sub

        Public Sub Count(ByRef objVariable As CoreInteger, blnAt As Boolean, blnCondition As Boolean)
            If blnAt AndAlso blnCondition Then
                Count(objVariable)
            End If
        End Sub

#If TARGET_DB = "INFORMIX" Then

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Determines the system date from the database.
        ''' </summary>
        ''' <param name="cnnQUERY">An active connection to a Informix Database.</param>
        ''' <returns>The system date (in the format YYYYMMDD) from the database.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        '''     SysDate(cnnQUERY) returns "20050104"
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Function SysDate(ByRef cnnQUERY As IfxConnection) As Decimal

            Dim dblDate As Decimal

            Try

                If ScreenType = ScreenTypes.QTP OrElse ScreenType = ScreenTypes.QUIZ Then

                    If dcSysDate = 0 Then
                        dblDate = QDesign.SysDate(cnnQUERY)
                        dcSysDate = dblDate
                    Else
                        dblDate = dcSysDate
                    End If
                Else
                    dblDate = QDesign.SysDate(cnnQUERY)
                End If

                Return dblDate

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Determines the system time from the database.
        ''' </summary>
        ''' <param name="cnnQUERY">An active connection to a Informix Database.</param>
        ''' <returns>The system time (in the format HHMMSSMS) from the database.</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        '''     SysTime(cnnQUERY) returns "13212200"
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Function SysTime(ByRef cnnQUERY As IfxConnection) As Decimal

            Dim dblDate As Decimal

            Try

                If ScreenType = ScreenTypes.QTP OrElse ScreenType = ScreenTypes.QUIZ Then

                    If dcSysTime = 0 Then
                        dblDate = QDesign.SysTime(cnnQUERY)
                        dcSysTime = dblDate
                    Else
                        dblDate = dcSysTime
                    End If
                Else
                    dblDate = QDesign.SysTime(cnnQUERY)
                End If

                Return dblDate

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Determines the system Date Time from a database.
        ''' </summary>
        ''' <param name="cnnQUERY">An active connection to an Informix Database.</param>
        ''' <returns>The system DateTime from the Database.</returns>
        ''' <remarks>The returned value's type is that of a Decimal. It represents an
        ''' instant in time, typically expressed as a date and time of day.
        ''' </remarks>
        ''' <example>
        '''     SysDateTimeAsDecimal(cnnQUERY) returns 20050115202449
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	4/5/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        Public Function SysDateTime(ByRef cnnQUERY As IfxConnection) As Decimal

            Dim dblDate As Decimal

            Try

                If ScreenType = ScreenTypes.QTP OrElse ScreenType = ScreenTypes.QUIZ Then

                    If dcSysDateTime = 0 Then
                        dblDate = QDesign.SysDateTime(cnnQUERY)
                        dcSysDateTime = dblDate
                    Else
                        dblDate = dcSysDateTime
                    End If
                Else
                    dblDate = QDesign.SysDateTime(cnnQUERY)
                End If

                Return dblDate

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try
        End Function

#End If

        Public Sub Average(ByRef objFileObject As BaseFileObject, strColumn As String)
            Dim strName As String = String.Empty
            If objFileObject.AliasName <> "" Then
                strName = objFileObject.AliasName & "_" & strColumn
            Else
                strName = objFileObject.BaseName & "_" & strColumn
            End If

            If hsAverage.ContainsKey(strName) Then
                objFileObject.SetValue(strColumn) =
                    (hsAverage.Item(strName) + objFileObject.GetDecimalValue(strColumn)) / 2
                hsAverage.Item(strName) = objFileObject.GetDecimalValue(strColumn)
            Else
                hsAverage.Add(strName, objFileObject.GetDecimalValue(strColumn))
            End If
        End Sub

        Public Sub Average(ByRef objVariable As CoreDecimal)
            Dim strName As String = objVariable.m_strVariableName

            blInaverage = True
            If hsAverage.ContainsKey(strName) Then
                hsAverage.Item(strName) = hsAverage.Item(strName) + objVariable.Value
                hsAverageCount.Item(strName) = hsAverageCount.Item(strName) + 1
            Else

                hsAverage.Add(strName, objVariable.Value)
                hsAverageCount.Add(strName, 1)
            End If

            objVariable.Value = hsAverage.Item(strName) / hsAverageCount.Item(strName)

            blInaverage = False

        End Sub

        Public Sub Average(ByRef objVariable As CoreInteger)
            Dim strName As String = objVariable.m_strVariableName

            If hsAverage.ContainsKey(strName) Then
                objVariable.Value = (hsAverage.Item(strName) + objVariable.Value) / 2
                hsAverage.Item(strName) = objVariable.Value
            Else
                hsAverage.Add(strName, objVariable.Value)
            End If
        End Sub

        Public Sub Average(ByRef objFileObject As BaseFileObject, strColumn As String, blnAt As Boolean,
                           Optional ByVal ItemType As ItemType = ItemType.Positive)
            If blnAt Then
                Average(objFileObject, strColumn)
            End If
        End Sub

        Public Sub Average(ByRef objVariable As CoreDecimal, blnAt As Boolean,
                           Optional ByVal ItemType As ItemType = ItemType.Positive)
            If blnAt Then
                Average(objVariable)
            End If
        End Sub

        Public Sub Average(ByRef objVariable As CoreInteger, blnAt As Boolean,
                           Optional ByVal ItemType As ItemType = ItemType.Positive)
            If blnAt Then
                Average(objVariable)
            End If
        End Sub

        Public Sub Average(ByRef objFileObject As BaseFileObject, strColumn As String, blnAt As Boolean,
                           blnCondition As Boolean, Optional ByVal ItemType As ItemType = ItemType.Positive)
            If blnAt AndAlso blnCondition Then
                Average(objFileObject, strColumn)
            End If
        End Sub

        Public Sub Average(ByRef objVariable As CoreDecimal, blnAt As Boolean, blnCondition As Boolean,
                           Optional ByVal ItemType As ItemType = ItemType.Positive)
            If blnAt AndAlso blnCondition Then
                Average(objVariable)
            End If
        End Sub

        Public Sub Average(ByRef objVariable As CoreInteger, blnAt As Boolean, blnCondition As Boolean,
                           Optional ByVal ItemType As ItemType = ItemType.Positive)
            If blnAt AndAlso blnCondition Then
                Average(objVariable)
            End If
        End Sub

        Public Sub Maximum(ByRef objFileObject As BaseFileObject, strColumn As String)
            Dim strName As String = String.Empty
            If objFileObject.AliasName <> "" Then
                strName = objFileObject.AliasName & "_" & strColumn
            Else
                strName = objFileObject.BaseName & "_" & strColumn
            End If

            If hsMaximum.ContainsKey(strName) Then
                If hsMaximum.Item(strName) > objFileObject.GetDecimalValue(strColumn) Then
                    objFileObject.SetValue(strColumn) = hsMaximum.Item(strName)
                Else
                    hsMaximum.Item(strName) = objFileObject.GetDecimalValue(strColumn)
                End If
            Else
                hsMaximum.Add(strName, objFileObject.GetDecimalValue(strColumn))
            End If
        End Sub

        Public Sub Maximum(ByRef objVariable As CoreDate)
            Dim strName As String = objVariable.m_strVariableName

            If hsMaximum.ContainsKey(strName) Then
                If hsMaximum.Item(strName) > objVariable.Value Then
                    objVariable.Value = hsMaximum.Item(strName)
                Else
                    hsMaximum.Item(strName) = objVariable.Value
                End If
            Else
                hsMaximum.Add(strName, objVariable.Value)
            End If
        End Sub

        Public Sub Maximum(ByRef objVariable As CoreDecimal)
            Dim strName As String = objVariable.m_strVariableName

            If hsMaximum.ContainsKey(strName) Then
                If hsMaximum.Item(strName) > objVariable.Value Then
                    objVariable.Value = hsMaximum.Item(strName)
                Else
                    hsMaximum.Item(strName) = objVariable.Value
                End If
            Else
                hsMaximum.Add(strName, objVariable.Value)
            End If
        End Sub

        Public Sub Maximum(ByRef objVariable As CoreInteger)
            Dim strName As String = objVariable.m_strVariableName

            If hsMaximum.ContainsKey(strName) Then
                If hsMaximum.Item(strName) > objVariable.Value Then
                    objVariable.Value = hsMaximum.Item(strName)
                Else
                    hsMaximum.Item(strName) = objVariable.Value
                End If
            Else
                hsMaximum.Add(strName, objVariable.Value)
            End If
        End Sub

        Public Sub Maximum(ByRef objFileObject As BaseFileObject, strColumn As String, blnAt As Boolean,
                           Optional ByVal ItemType As ItemType = ItemType.Positive)
            If blnAt Then
                Maximum(objFileObject, strColumn)
            End If
        End Sub

        Public Sub Maximum(ByRef objVariable As CoreDecimal, blnAt As Boolean,
                           Optional ByVal ItemType As ItemType = ItemType.Positive)
            If blnAt Then
                Maximum(objVariable)
            End If
        End Sub

        Public Sub Maximum(ByRef objVariable As CoreInteger, blnAt As Boolean,
                           Optional ByVal ItemType As ItemType = ItemType.Positive)
            If blnAt Then
                Maximum(objVariable)
            End If
        End Sub

        Public Sub Maximum(ByRef objFileObject As BaseFileObject, strColumn As String, blnAt As Boolean,
                           blnCondition As Boolean, Optional ByVal ItemType As ItemType = ItemType.Positive)
            If blnAt AndAlso blnCondition Then
                Maximum(objFileObject, strColumn)
            End If
        End Sub

        Public Sub Maximum(ByRef objVariable As CoreDecimal, blnAt As Boolean, blnCondition As Boolean,
                           Optional ByVal ItemType As ItemType = ItemType.Positive)
            If blnAt AndAlso blnCondition Then
                Maximum(objVariable)
            End If
        End Sub

        Public Sub Maximum(ByRef objVariable As CoreInteger, blnAt As Boolean, blnCondition As Boolean,
                           Optional ByVal ItemType As ItemType = ItemType.Positive)
            If blnAt AndAlso blnCondition Then
                Maximum(objVariable)
            End If
        End Sub

        Public Sub Minimum(ByRef objFileObject As BaseFileObject, strColumn As String)
            Dim strName As String = String.Empty
            If objFileObject.AliasName <> "" Then
                strName = objFileObject.AliasName & "_" & strColumn
            Else
                strName = objFileObject.BaseName & "_" & strColumn
            End If

            If hsMinimum.ContainsKey(strName) Then
                If hsMinimum.Item(strName) < objFileObject.GetDecimalValue(strColumn) Then
                    objFileObject.SetValue(strColumn) = hsMinimum.Item(strName)
                Else
                    hsMinimum.Item(strName) = objFileObject.GetDecimalValue(strColumn)
                End If
            Else
                hsMinimum.Add(strName, objFileObject.GetDecimalValue(strColumn))
            End If
        End Sub

        Public Sub Minimum(ByRef objVariable As CoreDecimal, objFileObject As BaseFileObject, strColumn As String)
            Dim strName As String = String.Empty
            If objFileObject.AliasName <> "" Then
                strName = objFileObject.AliasName & "_" & strColumn
            Else
                strName = objFileObject.BaseName & "_" & strColumn
            End If


            If objVariable.Value > objFileObject.GetDecimalValue(strColumn) Then
                objVariable.Value = objFileObject.GetDecimalValue(strColumn)
            End If

        End Sub

        Public Sub Minimum(ByRef objVariable As CoreDecimal, dd As DDecimal)
            Dim strName As String = String.Empty


            If objVariable.Value = 0 OrElse objVariable.Value > dd.Value Then
                objVariable.Value = dd.Value
            End If

        End Sub

        Public Sub Minimum(ByRef objVariable As CoreDecimal)
            Dim strName As String = objVariable.m_strVariableName

            If hsMinimum.ContainsKey(strName) Then
                If hsMinimum.Item(strName) < objVariable.Value Then
                    objVariable.Value = hsMinimum.Item(strName)
                Else
                    hsMinimum.Item(strName) = objVariable.Value
                End If
            Else
                hsMinimum.Add(strName, objVariable.Value)
            End If
        End Sub

        Public Sub Minimum(ByRef objVariable As CoreInteger)
            Dim strName As String = objVariable.m_strVariableName

            If hsMinimum.ContainsKey(strName) Then
                If hsMinimum.Item(strName) < objVariable.Value Then
                    objVariable.Value = hsMinimum.Item(strName)
                Else
                    hsMinimum.Item(strName) = objVariable.Value
                End If
            Else
                hsMinimum.Add(strName, objVariable.Value)
            End If
        End Sub

        Public Sub Minimum(ByRef objFileObject As BaseFileObject, strColumn As String, blnAt As Boolean,
                           Optional ByVal ItemType As ItemType = ItemType.Positive)
            If blnAt Then
                Minimum(objFileObject, strColumn)
            End If
        End Sub

        Public Sub Minimum(ByRef objVariable As CoreDecimal, blnAt As Boolean,
                           Optional ByVal ItemType As ItemType = ItemType.Positive)
            If blnAt Then
                Minimum(objVariable)
            End If
        End Sub

        Public Sub Minimum(ByRef objVariable As CoreInteger, blnAt As Boolean,
                           Optional ByVal ItemType As ItemType = ItemType.Positive)
            If blnAt Then
                Minimum(objVariable)
            End If
        End Sub

        Public Sub Minimum(ByRef objFileObject As BaseFileObject, strColumn As String, blnAt As Boolean,
                           blnCondition As Boolean, Optional ByVal ItemType As ItemType = ItemType.Positive)
            If blnAt AndAlso blnCondition Then
                Minimum(objFileObject, strColumn)
            End If
        End Sub

        Public Sub Minimum(ByRef objVariable As CoreDecimal, blnAt As Boolean, blnCondition As Boolean,
                           Optional ByVal ItemType As ItemType = ItemType.Positive)
            If blnAt AndAlso blnCondition Then
                Minimum(objVariable)
            End If
        End Sub

        Public Sub Minimum(ByRef objVariable As CoreInteger, blnAt As Boolean, blnCondition As Boolean,
                           Optional ByVal ItemType As ItemType = ItemType.Positive)
            If blnAt AndAlso blnCondition Then
                Minimum(objVariable)
            End If
        End Sub

        Public Sub Reset(ByRef objVariable As Object)
            Select Case objVariable.GetType.ToString.ToUpper
                Case "CORE.WINDOWS.UI.CORE.WINDOWS.CORECHARACTER"
                    objVariable.Value = " "
                Case "CORE.WINDOWS.COREVARCHAR"
                    objVariable.Value = " "
                Case "CORE.WINDOWS.UI.CORE.WINDOWS.COREDECIMAL"
                    objVariable.Value = 0
                Case "CORE.WINDOWS.UI.CORE.WINDOWS.COREINTEGER"
                    objVariable.Value = 0
                Case "CORE.WINDOWS.UI.CORE.WINDOWS.COREDATE"
                    objVariable.Value = 0
            End Select



            Dim strName As String = objVariable.m_strVariableName
            If hsAverage.ContainsKey(strName) Then
                hsAverage.Remove(strName)
                hsAverageCount.Remove(strName)
            End If

        End Sub

        Public Sub Reset(ByRef objFileObject As SqlFileObject, column As String)
            objFileObject.SetValue(column) = 0
        End Sub

        Public Sub Reset(ByRef objFileObject As SqlFileObject, column As String, objValue As Object)
            objFileObject.SetValue(column) = objValue
        End Sub

        Public Sub Reset(ByRef objVariable As Object, objValue As Object)
            Select Case objVariable.GetType.ToString.ToUpper
                Case "CORE.WINDOWS.UI.CORE.WINDOWS.CORECHARACTER"
                    objVariable.Value = CStr(objValue)
                Case "CORE.WINDOWS.COREVARCHAR"
                    objVariable.Value = CStr(objValue)
                Case "CORE.WINDOWS.UI.CORE.WINDOWS.COREDECIMAL"
                    objVariable.Value = CDec(objValue)
                Case "CORE.WINDOWS.UI.CORE.WINDOWS.COREINTEGER"
                    objVariable.Value = CInt(objValue)
                Case "CORE.WINDOWS.UI.CORE.WINDOWS.COREDATE"
                    objVariable.Value = CDec(objValue)
            End Select
        End Sub

        Public Sub Reset(ByRef objFileObject As SqlFileObject, column As String, blnAt As Boolean)
            If blnAt Then
                Reset(objFileObject, column)
            End If
        End Sub

        Public Sub Reset(ByRef objVariable As CoreCharacter, blnAt As Boolean)
            If blnAt Then
                Reset(objVariable)
            End If
        End Sub

        Public Sub Reset(ByRef objVariable As CoreVarChar, blnAt As Boolean)
            If blnAt Then
                Reset(objVariable)
            End If
        End Sub

        Public Sub Reset(ByRef objVariable As CoreDecimal, blnAt As Boolean)
            If blnAt Then
                Reset(objVariable)
            End If
        End Sub

        Public Sub Reset(ByRef objVariable As CoreInteger, blnAt As Boolean)
            If blnAt Then
                Reset(objVariable)
            End If
        End Sub

        Public Sub Reset(ByRef objVariable As CoreDate, blnAt As Boolean)
            If blnAt Then
                Reset(objVariable)
            End If
        End Sub

        Public Sub Reset(ByRef objVariable As Object, blnAt As Boolean)
            If blnAt Then
                Reset(objVariable)
            End If
        End Sub

        Public Sub Reset(ByRef objFileObject As SqlFileObject, column As String, objValue As Object, blnAt As Boolean)
            If blnAt Then
                Reset(objFileObject, column, objValue)
            End If
        End Sub

        Public Sub Reset(ByRef objVariable As CoreCharacter, objValue As Object, blnAt As Boolean)
            If blnAt Then
                Reset(objVariable, objValue)
            End If
        End Sub

        Public Sub Reset(ByRef objVariable As CoreVarChar, objValue As Object, blnAt As Boolean)
            If blnAt Then
                Reset(objVariable, objValue)
            End If
        End Sub

        Public Sub Reset(ByRef objVariable As CoreDecimal, objValue As Object, blnAt As Boolean)
            If blnAt Then
                Reset(objVariable, objValue)
            End If
        End Sub

        Public Sub Reset(ByRef objVariable As CoreInteger, objValue As Object, blnAt As Boolean)
            If blnAt Then
                Reset(objVariable, objValue)
            End If
        End Sub

        Public Sub Reset(ByRef objVariable As CoreDate, objValue As Object, blnAt As Boolean)
            If blnAt Then
                Reset(objVariable, objValue)
            End If
        End Sub

        Public Sub Reset(ByRef objVariable As Object, objValue As Object, blnAt As Boolean)
            If blnAt Then
                Reset(objVariable, objValue)
            End If
        End Sub

        Public Sub Reset(ByRef objVariable As Object, blnAt As Boolean, blnCondition As Boolean)
            If blnAt AndAlso blnCondition Then
                Reset(objVariable)
            End If
        End Sub

        Public Sub Reset(ByRef objVariable As CoreCharacter, objValue As Object, blnAt As Boolean,
                         blnCondition As Boolean)
            If blnAt AndAlso blnCondition Then
                Reset(objVariable, objValue)
            End If
        End Sub

        Public Sub Reset(ByRef objVariable As CoreVarChar, objValue As Object, blnAt As Boolean, blnCondition As Boolean)
            If blnAt AndAlso blnCondition Then
                Reset(objVariable, objValue)
            End If
        End Sub

        Public Sub Reset(ByRef objVariable As CoreDecimal, objValue As Object, blnAt As Boolean, blnCondition As Boolean)
            If blnAt AndAlso blnCondition Then
                Reset(objVariable, objValue)
            End If
        End Sub

        Public Sub Reset(ByRef objVariable As CoreInteger, objValue As Object, blnAt As Boolean, blnCondition As Boolean)
            If blnAt AndAlso blnCondition Then
                Reset(objVariable, objValue)
            End If
        End Sub

        Public Sub Reset(ByRef objVariable As CoreDate, objValue As Object, blnAt As Boolean, blnCondition As Boolean)
            If blnAt AndAlso blnCondition Then
                Reset(objVariable, objValue)
            End If
        End Sub

        Public Sub Reset(ByRef objVariable As Object, objValue As Object, blnAt As Boolean, blnCondition As Boolean)
            If blnAt AndAlso blnCondition Then
                Reset(objVariable, objValue)
            End If
        End Sub

        Public Sub NoReset(ByRef objFileObject As SqlFileObject, strColumn As String)
        End Sub

        Public Function At(objDefine As DDecimal) As Boolean

            Dim CurrentValue As String = objDefine.Value
            Dim blnReturn As Boolean = False

            If intSortCount = intSorted Then
                Return True
            End If

            m_blnIsAt = True

            If CurrentValue <> objDefine.Value Then
                blnReturn = True
            End If

            m_blnIsAt = False

            Return blnReturn
        End Function

        Public Function At(objDefine As DCharacter) As Boolean

            Dim CurrentValue As String = objDefine.Value
            Dim blnReturn As Boolean = False

            If intSortCount = intSorted Then
                Return True
            End If

            m_blnIsAt = True

            If CurrentValue <> objDefine.Value Then
                blnReturn = True
            End If

            m_blnIsAt = False

            Return blnReturn
        End Function

        Public Function At(objDefine As DInteger) As Boolean

            Dim CurrentValue As String = objDefine.Value
            Dim blnReturn As Boolean = False

            If intSortCount = intSorted Then
                Return True
            End If

            m_blnIsAt = True

            If CurrentValue <> objDefine.Value Then
                blnReturn = True
            End If

            m_blnIsAt = False

            Return blnReturn
        End Function

        ''' --- Dispose ------------------------------------------------------------
        ''' <summary>
        '''     Performs clean up of objects who have completed their function.
        ''' </summary>
        ''' <remarks>
        '''     <para>
        '''         This function is overridable so that the developer has the option
        '''         of coding their own procedure to suite the needs of the specific screen
        '''         they are working on. By doing so, the screens functionality is tied to the
        '''         Renaissance Architect Framework.
        '''     </para>
        '''     <para>
        '''         <note>This MUST be overridden in the GHOST screen.</note>
        '''     </para>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Overridable Sub Dispose()

            ' NOTE: This MUST be overridden in the GHOST screen.
            Try
                CloseTransactionObjects()
            Catch ex As CustomApplicationException
                Throw ex
            Catch ex As Exception
                Throw ex
            End Try

            hsAverage = Nothing
            hsMaximum = Nothing
            hsMinimum = Nothing
            If Not IsNothing(dtSortOrder) Then
                dtSortOrder.Dispose()
                dtSortOrder = Nothing
            End If
            If Not IsNothing(dtSorted) Then
                dtSorted.Dispose()
                dtSorted = Nothing
            End If

            MyBase.Dispose()

            GC.Collect()
        End Sub

        ''' --- CloseTransactionObjects --------------------------------------------
        ''' <summary>
        '''     Closes all file objects and transaction/connection objects on the page.
        ''' </summary>
        ''' <remarks>
        '''     The CloseTransactionObjects method closes the file objects through the
        '''     call to CloseFiles and closes the transaction/connection objects.
        '''     <br /><br />
        '''     NOTE: This method will be overriden in the derived screen and is generated
        '''     by the Renaissance Architect Precompiler.
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	6/16/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Friend Overridable Sub CloseTransactionObjects()
        End Sub

        ''' --- CloseFiles ---------------------------------------------------------
        ''' <summary>
        '''     Closes all file objects on the page.
        ''' </summary>
        ''' <remarks>
        '''     The CloseFiles method closes disposes of the file objects.
        '''     <br /><br />
        '''     NOTE: This method will be overriden in the derived screen and is generated
        '''     by the Renaissance Architect Precompiler.
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	6/16/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Friend Overridable Sub CloseFiles()
        End Sub

        ''' --- InitializeFiles ----------------------------------------------------
        ''' <summary>
        '''     Assigns the transaction objects to the specified files.
        ''' </summary>
        ''' <remarks>
        '''     The InitializeFiles method is used to assign the transaction objects
        '''     (both the declared transactions and the default transactions) to the appropriate
        '''     File objects.
        '''     <br /><br />
        '''     NOTE: This method will be overriden in the derived screen and is generated
        '''     by the Renaissance Architect PreCompiler.
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	6/16/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Friend Overridable Sub InitializeFiles()
        End Sub

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub CallInitializeInternalValues()
            RaiseEvent InitializeInternalValues()
        End Sub

        ''' --- InitializeVariables ------------------------------------------------
        ''' <summary>
        '''     Performs processing when the screen is initiated.
        ''' </summary>
        ''' <remarks>
        '''     Used to initialize variables.
        '''     <para>
        '''         This function is overridable so that the developer has the option
        '''         of coding their own procedure to suite the needs of the specific screen
        '''         they are working on. By doing so, the screens functionality is tied to the
        '''         Renaissance Architect Framework.
        '''     </para>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Friend Overridable Sub InitializeVariables()
        End Sub

        ''' --- InitializeTransactionObjects ---------------------------------------
        ''' <summary>
        '''     Opens the connections and creates the transactions.
        ''' </summary>
        ''' <remarks>
        '''     The InitializeTransactionObjects method opens the connections and transactions
        '''     that are required by the default transactions as well as the declared transactions.
        '''     <br /><br />
        '''     NOTE: This method will be overriden in the derived screen and is generated
        '''     by the Renaissance Architect PreCompiler.
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	6/16/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Friend Overridable Sub InitializeTransactionObjects()
        End Sub

        ''' --- TRANS_UPDATE -------------------------------------------------------
        ''' 
        ''' '''
        ''' <summary>
        '''     Default TRANS_UPDATE procedure.
        ''' </summary>
        ''' <param name="Method"></param>
        ''' <remarks>
        '''     <para>
        '''         This function is overridable so that the developer has the option
        '''         of coding their own procedure to suite the needs of the specific screen
        '''         they are working on. By doing so, the screens functionality is tied to the
        '''         Renaissance Architect Framework.
        '''     </para>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Friend Overridable Sub TRANS_UPDATE(Method As TransactionMethods)
        End Sub

        ''' --- GetFieldText ---------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of GetFieldText.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetFieldText() As String
            Return FieldText
        End Function

        ''' --- GetFieldValue ---------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of GetFieldValue.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetFieldValue() As Decimal
            Return FieldValue
        End Function

        ''' --- GetRunScreenName ---------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of GetRunScreenName.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetRunScreenName() As String
            Return m_strRunScreen
        End Function



        ''' --- RegisterStateFlag --------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of RegisterStateFlag.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function RegisterStateFlag()
            Session(UniqueSessionID + m_strPageId + "_IsMainState") = "True"
            Return Nothing
        End Function

        ''' --- IsStateAvailable ---------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of IsStateAvailable.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function IsStateAvailable() As Boolean
            Return CBool(Session(UniqueSessionID + m_strPageId + "_IsMainState"))
            Return Nothing
        End Function

        ''' --- GetDictionaryItem --------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of GetDictionaryItem.
        ''' </summary>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Overloads Function GetDictionaryItem(FieldId As String) As CoreDictionaryItem
            Return GetDictionaryItem(Session(UniqueSessionID + "Language"), FieldId)
        End Function

        ''' --- RaiseSavePageState -------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of RaiseSavePageState.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub RaiseSavePageState()

            If ScreenType = ScreenTypes.QTP OrElse ScreenType = ScreenTypes.QUIZ Then
                RaiseEvent SavePageState(Me, New PageStateEventArgs("_", ObjectState.OnlyCoreBaseTypes))
            Else
                RaiseEvent SavePageState(Me, New PageStateEventArgs("_"))
            End If
            'Register a flag that can notify subsequent post back that, State exists
            RegisterStateFlag()
        End Sub

        ''' --- RaiseLoadPageState -------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of RaiseLoadPageState.
        ''' </summary>
        ''' <param name="IncludeObjectState"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Sub RaiseLoadPageState(IncludeObjectState As ObjectState)
            'Note: We are retrieving state only if we have persisted it
            '      We added this code to handle Run Screen from Initialize and similar methods
            If Me.IsStateAvailable() Then
                If ScreenType = ScreenTypes.QTP OrElse ScreenType = ScreenTypes.QUIZ Then
                    RaiseEvent LoadPageState(Me, New PageStateEventArgs("_", ObjectState.OnlyCoreBaseTypes), False)
                Else
                    RaiseEvent LoadPageState(Me, New PageStateEventArgs("_", IncludeObjectState), False)
                End If
            End If
        End Sub

        ''' --- CallRunDesigner ----------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of CallRunDesigner.
        ''' </summary>
        ''' <param name="Designer"></param>
        ''' <param name="PageMode"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Overrides Function CallRunDesigner(Designer As String, PageMode As PageModeTypes,
                                                  Optional ByVal blnExit As Boolean = False) As Boolean

            Dim blnReturnValue As Boolean

            Try
                RetrieveFlags()

                Me.Mode = PageMode
                m_strGenericRetrievalCharacter = Application(cGenericRetrievalCharacter) & ""
                If Not Application(cDefaultCentury) Is Nothing Then
                    m_intDefaultCentury = Application(cDefaultCentury)
                    ' If we have a 2 digit century, multiply by 100 to give us
                    ' the century that we add to the year entered.  (ie. 19 becomes 1900)
                    If m_intDefaultCentury.ToString.Length = 2 Then
                        m_intDefaultCentury *= 100
                    End If
                End If
                If Not Application(cInputCenturyFrom) Is Nothing Then
                    m_intDefaultInputCentury = Application(cInputCenturyFrom).ToString.Split(",")(0)
                    m_intInputFromYear = Application(cInputCenturyFrom).ToString.Split(",")(1)
                    ' If we have a 2 digit century, multiply by 100 to give us
                    ' the century that we add to the year entered.  (ie. 19 becomes 1900)
                    If m_intDefaultInputCentury.ToString.Length = 2 Then
                        m_intDefaultInputCentury *= 100
                    End If
                End If

                'If Menu has not turned off DB connections, initilaize the values
                If NoDBConnect = False Then
                    Try
                        InitializeTransactionObjects()
                    Catch ex As CustomApplicationException
                        Throw ex
                    Catch ex As Exception
                        Throw ex
                    End Try

                    Try
                        InitializeFiles()
                    Catch ex As CustomApplicationException
                        Throw ex
                    Catch ex As Exception
                        Throw ex
                    End Try

                End If

                RetrieveParamsReceived()
                RetrieveInitalizeParamsReceived()
                If Not ScreenSession(UniqueSessionID + "Initialize") Then
                    RaiseEvent InitializeInternalValues()
                    blnIsInInitialize = True
                    Initialize()
                    ScreenSession(UniqueSessionID + "Initialize") = True
                Else
                    RaiseLoadPageState(ObjectState.FileObjectsAndCoreBaseTypes)
                End If
                SaveInitalizeParamsReceived()
                If blnIsInInitialize Then
                    m_intRunScreenSequence = 0
                    m_strRunFlag = ""
                    RemoveFlags()
                End If
                blnIsInInitialize = False
                If PageMode = PageModeTypes.Find Then
                    CallFind()
                End If

                blnReturnValue = RunDesigner(Designer, PageMode)

                SaveParamsReceived()

                RaiseSavePageState()
                Try
                    CloseTransactionObjects()
                Catch ex As CustomApplicationException
                    Throw ex
                Catch ex As Exception
                    Throw ex
                End Try

                If blnExit Then
                    RemoveFlags()
                End If

                Return blnReturnValue

            Catch ex As CustomApplicationException

                Me.RaiseSavePageState()
                Throw ex

            End Try
        End Function

        ''' --- RetrieveFlags ------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of RetrieveFlags.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub RetrieveFlags()

            RetrieveFlagInformation(m_strCountIntoCalled, "COUNT_INTO")
            RetrieveFlagInformation(m_strRunFlag, "RUN_FLAG")
            RetrieveFlagInformation(m_strPutFlag, "PUT_FLAG")
            RetrieveFlagInformation(m_strExternalFlag, "EXTERNAL_FLAG")
            RetrieveFlagInformation(m_htFileInfo, "ROWIDCHECKSUM")
        End Sub

        ''' --- RetrieveFlagInformation --------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of RetrieveFlagInformation.
        ''' </summary>
        ''' <param name="Flag"></param>
        ''' <param name="FlagName"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub RetrieveFlagInformation(ByRef Flag As Hashtable, FlagName As String)

            Flag = Session(UniqueSessionID + FormName + "_" + Level.ToString + "_" + FlagName)
            If Flag Is Nothing Then Flag = New Hashtable
        End Sub

        ''' --- RetrieveFlagInformation --------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of RetrieveFlagInformation.
        ''' </summary>
        ''' <param name="Flag"></param>
        ''' <param name="FlagName"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub RetrieveFlagInformation(ByRef Flag As String, FlagName As String)

            If FlagName = "PUT_FLAG" Then
                Flag = Session(UniqueSessionID + FormName + "_" + Level.ToString + "_" + FlagName)
            Else
                Flag = Session(UniqueSessionID + m_Node + "_" + FormName + "_" + Level.ToString + "_" + FlagName)
            End If

            If Flag = Nothing Then Flag = ""
        End Sub

        ''' --- RemoveFlags --------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of RemoveFlags.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub RemoveFlags()

            RemoveFlags(False)
        End Sub

        ''' --- RemoveFlags --------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of RemoveFlags.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub RemoveFlags(SaveState As Boolean)

            RemoveFlagInformation("COUNT_INTO")
            RemoveFlagInformation("RUN_FLAG")
            RemoveFlagInformation("PUT_FLAG")
            RemoveFlagInformation("EXTERNAL_FLAG")
            RemoveFlagInformation("ROWIDCHECKSUM")

            m_intPutSequence = 0

            If SaveState Then
                Me.RaiseSavePageState()
            End If
        End Sub

        ''' --- RemoveFlagInformation ----------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of RemoveFlagInformation.
        ''' </summary>
        ''' <param name="FlagName"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub RemoveFlagInformation(FlagName As String)

            If FlagName = "PUT_FLAG" Or FlagName = "ROWIDCHECKSUM" Then
                Session.Remove(UniqueSessionID + FormName + "_" + Level.ToString + "_" + FlagName)
            Else
                Session.Remove(UniqueSessionID + m_Node + "_" + FormName + "_" + Level.ToString + "_" + FlagName)
            End If
        End Sub

        ''' --- SetMethodExecutedFlag ----------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of SetMethodExecutedFlag.
        ''' </summary>
        ''' <param name="Flag"></param>
        ''' <param name="FlagName"></param>
        ''' <param name="Sequence"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub SetMethodExecutedFlag(ByRef Flag As String, FlagName As String, Sequence As Integer,
                                         RunScreenName As String)

            Flag = Flag.Substring(0, Sequence - 1) + "Y"
            Session(UniqueSessionID + m_Node + "_" + RunScreenName + "_" + Level.ToString + "_" + FlagName) = Flag
        End Sub

        ''' --- SetMethodExecutedFlag ----------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of SetMethodExecutedFlag.
        ''' </summary>
        ''' <param name="Flag"></param>
        ''' <param name="FlagName"></param>
        ''' <param name="Sequence"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub SetMethodExecutedFlag(ByRef Flag As String, FlagName As String, Sequence As Integer)

            Flag = Flag.Substring(0, Sequence - 1) + "Y"
            If FlagName = "PUT_FLAG" Then
                Session(UniqueSessionID + FormName + "_" + Level.ToString + "_" + FlagName) = Flag
            Else
                Session(UniqueSessionID + m_Node + "_" + FormName + "_" + Level.ToString + "_" + FlagName) = Flag
            End If
        End Sub

        ''' --- RemoveMethodExecutedFlag -------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of RemoveMethodExecutedFlag.
        ''' </summary>
        ''' <param name="Flag"></param>
        ''' <param name="FlagName"></param>
        ''' <param name="Sequence"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub RemoveMethodExecutedFlag(ByRef Flag As String, FlagName As String, Sequence As Integer,
                                            RunScreenName As String)

            Flag = Flag.Substring(0, Sequence - 1) + " "
            Session(UniqueSessionID + m_Node + "_" + RunScreenName + "_" + Level.ToString + "_" + FlagName) = Flag
        End Sub

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub UpdateCommand()

            ' Call the PreUpdate procedure.
            PreUpdate()

            ' Call the Update procedure.
            Update()

            ' Commit the default transaction (TRANS_UPDATE).
            TRANS_UPDATE(TransactionMethods.Commit)

            ' Call the PostUpdate procedure.
            PostUpdate()

            'Save The Recieving list after the Update
            SaveParamsReceived()

            ' Commit the default transaction (TRANS_UPDATE).
            TRANS_UPDATE(TransactionMethods.Commit)
        End Sub

        ''' --- CallInitialize -----------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of CallInitialize.
        ''' </summary>
        ''' <param name="Mode"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Overloads Overrides Function CallInitialize(Mode As PageModeTypes) As Boolean
            Dim blnReturnValue As Boolean

            Try

                Me.Mode = Mode

                Try
                    InitializeTransactionObjects()
                Catch ex As CustomApplicationException
                    Throw ex
                Catch ex As Exception
                    Throw ex
                End Try
                Try
                    InitializeFiles()
                Catch ex As CustomApplicationException
                    Throw ex
                Catch ex As Exception
                    Throw ex
                End Try
                RetrieveParamsReceived()
                RaiseEvent InitializeInternalValues()

                Try
                    ' this has to be added becuase the for was not executing if the mode was entry
                    m_blnInFindOrDetailFind = True
                    m_blnInInitialize = True
                    RetrieveFlags()
                    blnReturnValue = Initialize()
                    m_blnInInitialize = False

                    If Mode = PageModeTypes.Find Then
                        CallFind()
                    ElseIf Mode = PageModeTypes.Entry Then
                        CallEntry()
                        If AutoUpdate Then
                            CallUpdate()
                        End If
                    End If

                    If m_strPush.Length > 0 Then

                        If Me.Mode = PageModeTypes.Find Then Me.Mode = PageModeTypes.Change

                        If Me.Mode = PageModeTypes.Entry Then Me.Mode = PageModeTypes.Correct

                        Dim arrPush() As String = m_strPush.Split(",")
                        m_strPush = ""

                        For i As Integer = 0 To arrPush.Length - 1

                            Select Case arrPush(i)

                                Case "Update"
                                    CallUpdate()
                                Case "Entry"
                                    CallEntry()
                                Case "Find"
                                    CallFind()
                                Case "Return"

                                Case Else
                                    Try

                                        Try
                                            CallByName(Me, arrPush(i) + "_PreCommands", CallType.Method, Nothing,
                                                       Nothing)
                                        Catch ex As Exception
                                        End Try

                                        CallByName(Me, arrPush(i), CallType.Method)

                                        Try
                                            CallByName(Me, arrPush(i) + "_PostCommands", CallType.Method, Nothing,
                                                       Nothing)
                                        Catch ex As Exception
                                        End Try

                                    Catch ex As Exception
                                        Try

                                            Try
                                                CallByName(Me, arrPush(i) + "_PreCommands", CallType.Method, Nothing,
                                                           Nothing)
                                            Catch
                                            End Try

                                            CallByName(Me, arrPush(i) + "_Click", CallType.Method, Nothing, Nothing)

                                            Try
                                                CallByName(Me, arrPush(i) + "_PostCommands", CallType.Method, Nothing,
                                                           Nothing)
                                            Catch
                                            End Try

                                        Catch

                                        End Try
                                    End Try

                            End Select

                            For j As Integer = i + 1 To arrPush.Length - 1
                                If m_strPush.Length > 0 Then m_strPush = m_strPush + ","
                                m_strPush = m_strPush + arrPush(j)
                            Next

                            If m_strPush.IndexOf(",Return") > 0 Then
                                m_strPush = m_strPush.Replace("Find", "").Replace("Entry", "")
                                If m_strPush.IndexOf(",") = 0 Then m_strPush = m_strPush.Substring(1)
                                Do While m_strPush.IndexOf(",,") >= 0
                                    m_strPush.Replace(",,", ",")
                                Loop
                            End If
                            If m_strPush.Trim = "" Then Exit For
                            i = -1
                            arrPush = m_strPush.Split(",")
                            m_strPush = ""

                        Next

                        SaveParamsReceived()
                    End If

                Catch ex As CustomApplicationException
                    If ex.Message <> cReturn.ToString Then
                        If ex.Message = cRunScreenException.ToString AndAlso Me.ScreenType = ScreenTypes.Ghost Then
                            If RunScreenFolderLength = 0 Then
                                GlobalSession(UniqueSessionID + "RunScreenName") = m_strRunScreenFolder & "/" &
                                                                                   m_strRunScreen
                            Else
                                GlobalSession(UniqueSessionID + "RunScreenName") = m_strRunScreen
                            End If
                        Else
                            m_blnInFindOrDetailFind = False
                            ' Check if we need to pass back any messages.
                            Cleanup()
                        End If

                        Throw ex
                    End If
                Catch ex As Exception
                    m_blnInFindOrDetailFind = False
                    Cleanup(False)
                    ' Check if we need to pass back any messages.
                    AddMessage(ex.Message, MessageTypes.Error)

                    Throw ex
                End Try

                m_blnInFindOrDetailFind = False
                Cleanup()

                Return blnReturnValue

            Catch ex As Exception
                If ex.Message = cRunScreenException.ToString Then
                    QDesign.ThrowCustomApplicationException(cMenuRunScreenException)
                End If
                Throw ex
            End Try
        End Function

        ''' --- CallExit -----------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of CallExit.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Overloads Overrides Function CallExit() As Boolean
            Dim blnReturnValue As Boolean

            Try
                InitializeTransactionObjects()
            Catch ex As CustomApplicationException
                Throw ex
            Catch ex As Exception
                Throw ex
            End Try
            Try
                InitializeFiles()
            Catch ex As CustomApplicationException
                Throw ex
            Catch ex As Exception
                Throw ex
            End Try
            RetrieveParamsReceived()
            RaiseEvent InitializeInternalValues()

            Try
                blnReturnValue = [Exit]()

            Catch ex As CustomApplicationException
                If ex.Message <> cReturn.ToString Then
                    Cleanup()
                    Throw ex
                End If
            Catch ex As Exception
                Cleanup(False)
                Throw ex
            End Try

            Cleanup()

            Return blnReturnValue
        End Function

        ''' --- Cleanup ------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of Cleanup.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function Cleanup()
            Cleanup(True)
            Return Nothing
        End Function

        ''' --- Cleanup ------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of Cleanup.
        ''' </summary>
        ''' <param name="SaveState"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function Cleanup(SaveState As Boolean)

            RemoveFlags(SaveState)
            If SaveState Then
                RaiseSavePageState()
            End If
            Try
                CloseTransactionObjects()
            Catch ex As CustomApplicationException
                Throw ex
            Catch ex As Exception
                Throw ex
            End Try
            Return Nothing
        End Function

        '----------------------------
        ' InternalPageState property can be used to persist the value of the
        ' Temporary and File Objects
        ' Note: We have declared this property as "Friend" to limit the usage of this property
        ' within CORE.WINDOWS.UI and In case in future, if we ever decide to change the medium of
        ' persistance we can change this method
        '
        ' To reliably meet above requirement, InternalPageState should never be used to store
        ' value other than the Temporary and File Objects
        '----------------------------
        ''' --- InternalPageState --------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of InternalPageState.
        ''' </summary>
        ''' <param name="ObjectStateKey"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Property InternalPageState(ObjectStateKey As String) As Object
            Get
                Dim objValueFromState As Object

                ObjectStateKey = m_strPageId + ObjectStateKey
                Select Case ObjectStateMedium
                    Case StateMedium.SessionOnServer
                        objValueFromState = Session(UniqueSessionID + ObjectStateKey)
                        If _
                            (Not objValueFromState Is Nothing) AndAlso
                            objValueFromState.GetType.ToString = "System.String[]" Then
                            objValueFromState = CType(objValueFromState, Array).Clone
                        End If
                        Return objValueFromState
                    Case StateMedium.DatabaseOnServer
                        'TODO: m_hstInternalStateInfo Needs to be saved in Database
                        Return m_hstInternalStateInfo(ObjectStateKey)
                    Case StateMedium.DiskOnServer
                        'Needs an implementation
                End Select
                Return Nothing
            End Get
            Set(Value As Object)
                ObjectStateKey = m_strPageId + ObjectStateKey
                Select Case ObjectStateMedium
                    Case StateMedium.SessionOnServer
                        Session(UniqueSessionID + ObjectStateKey) = Value
                    Case StateMedium.DatabaseOnServer
                        'TODO: m_hstInternalStateInfo Needs to be saved in Database
                        m_hstInternalStateInfo(ObjectStateKey) = Value
                    Case StateMedium.DiskOnServer
                        'Needs an implementation
                End Select
            End Set
        End Property

        ''' --- ProcessLocation ----------------------------------------------------
        ''' <summary>
        '''     Returns the ProcessLocation parameter defined in the Global.asax file.
        ''' </summary>
        ''' <returns>Returns a string representing the ProcessLocation value.</returns>
        ''' <remarks>
        '''     Use the ProcessLocation method to return the value for ProcessLocation
        '''     as specified in the web application's Global.asax file.
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Function ProcessLocation() As String

            Dim strProcessLocation As String
            If Application(cProcessLocation) Is Nothing Then
                strProcessLocation = String.Empty
            Else
                strProcessLocation = Application(cProcessLocation)
            End If

            Return strProcessLocation
        End Function

        ''' --- SysName ------------------------------------------------------------
        ''' <summary>
        '''     The dictionary title as specified in the Global.asax file.
        ''' </summary>
        ''' <returns>Returns a string representing the dictionary title.</returns>
        ''' <remarks>
        '''     Use the SysName method to return the dictionary title as specified in
        '''     the web application's Global.asax file.
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Function SysName() As String

            Return (Application(cTitle).ToString + "").PadRight(40)
        End Function

        ''' --- SetRunScreenMemberVariables -------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Sets the m_strRunScreenFolder value and returns the name of the run screen.
        ''' </summary>
        ''' <param name="RunScreenName">The screen to run.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub SetRunScreenMemberVariables(ByRef RunScreenName As String)

            ' Remove/create the folder name for the runscreen.
            If RunScreenName.IndexOf("/") > -1 Then
                Dim intLastIndex As Integer = RunScreenName.LastIndexOf("/")
                m_strRunScreenFolder = RunScreenName.Substring(0, intLastIndex)
                If m_strRunScreenFolder.Substring(0, 1) = "/" Then _
                    m_strRunScreenFolder = m_strRunScreenFolder.Substring(1)
                RunScreenName = RunScreenName.Substring(intLastIndex + 1)
            Else
                m_strRunScreenFolder = RunScreenName.Substring(0, Me.RunScreenFolderLength)
            End If
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     RunScreenFolderLength is used identify the folder of the Run Screen based on Run Screen Name
        '''     RunScreenFolderLength can be defined in "appSettings" section of web.Config
        '''     RunScreenFolderLength defined in web.config can be overrided in the page by assigning it in Init evenhandler of the
        '''     Derived Page.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [mayur]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub SetRunScreenFolderLength()
            If m_intRunScreenFolderLength = -1 Then
                If m_strRunScreenFolderLength Is Nothing Then
                    m_strRunScreenFolderLength = ConfigurationManager.AppSettings("RunScreenFolderLength")
                    If m_strRunScreenFolderLength Is Nothing Then
                        'RunScreenFolderLength is not defined in appSettings section of web.config
                        m_strRunScreenFolderLength = "2"  'Set the default RunScreenFolderLength to 2
                    End If
                End If

                m_intRunScreenFolderLength = CShort(m_strRunScreenFolderLength)
            End If
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     RunScreenFolderLength is used identify the folder of the Run Screen based on Run Screen Name
        '''     RunScreenFolderLength can be defined in "appSettings" section of web.Config
        '''     RunScreenFolderLength defined in web.config can be overrided in the page by assigning it in Init evenhandler of the
        '''     Derived Page.
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [mayur]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <Browsable(False), DefaultValue(2),
            EditorBrowsable(EditorBrowsableState.Always)>
        Public Property RunScreenFolderLength As Short
            Get
                Return m_intRunScreenFolderLength
            End Get
            Set(Value As Short)
                m_intRunScreenFolderLength = Value
            End Set
        End Property

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub RunScreen(objRunScreen As BaseClassControl, RunScreenMode As RunScreenModes)
            Dim arrRunscreen() As Object = Nothing
            RunScreen(objRunScreen, RunScreenMode, arrRunscreen)
        End Sub

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub RunScreen(RunScreen As BaseClassControl, RunScreenMode As RunScreenModes, ByRef arrParm() As Object)

            Dim blnMethodWasExecuted As Boolean
            m_intRunScreenSequence += 1

            blnMethodWasExecuted = MethodWasExecuted(m_strRunFlag, m_intRunScreenSequence, "RUN_FLAG")

            If Not blnMethodWasExecuted Then

                SetMethodExecutedFlag(m_strRunFlag, "RUN_FLAG", m_intRunScreenSequence)

                ' Save the sequence information and set a flag indicating screen was run.
                'TODO: At present we are not saving sequence
                '      Need to revisit for Run/Ghost Screen called from the specified Method on a specified Class
                'SetScreenWasRunFlag(m_intRunScreenSequence)

                ' Save the parameters passed to the RUN SCREEN.
                If Not IsNothing(arrParm) AndAlso arrParm.Length > 0 Then
                    For i As Integer = 0 To arrParm.Length - 1
                        If Not (arrParm(i) Is Nothing) Then
                            Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM" + (i + 1).ToString) =
                                GetParmValue(arrParm(i))
                        End If
                    Next
                End If

                Session(
                    UniqueSessionID + RunScreen.Name + "_" + (Me.Level + 1).ToString + "_" +
                    m_intRunScreenSequence.ToString) = Session.Count

                'Commented from original Base Page
                ' Default: E for subscreen invoked during the standard entry procedure, otherwise NULL.
                If RunScreenMode = RunScreenModes.NoneSelected Then
                    'If Me.Mode = PageModeTypes.Entry Then
                    '    RunScreenMode =  RunScreenModes.Entry
                    'End If
                End If

                If RunScreenMode = RunScreenModes.Same Then
                    ' TODO: Test this scenario once we change the FIND and ENTRY mode code.
                    'RunScreenMode = Mode
                End If

                m_strRunScreen = RunScreen.Name
                Session(UniqueSessionID + RunScreen.Name + "_" + (Me.Level + 1).ToString + "_Mode") = RunScreenMode
                Session(UniqueSessionID + RunScreen.Name + "_" + (Me.Level + 1).ToString + "_ScreenSequence") =
                    m_intRunScreenSequence
                Session(UniqueSessionID + "ScreenLevel") = Me.Level + 1

                'Treating RunScreen as the Ghost Screen, which is used in ReturnAndClose for not throwing an exception
                RunScreen.ScreenType = ScreenTypes.Ghost

                Try
                    RunScreen.CallInitialize(RunScreenMode)
                Catch ex As CustomApplicationException
                    If ex.Message <> cReturn.ToString Then
                        Throw ex
                    End If
                Catch ex As Exception
                    ' Write the exception to the event log and throw an error.
                    ExceptionManager.Publish(ex)
                End Try
                blnMethodWasExecuted = True
            End If

            If blnMethodWasExecuted Then

                ' Reset the m_strRunScreen variable.
                m_strRunScreen = ""

                ' Decrement the ScreenLevel.
                Session(UniqueSessionID + "ScreenLevel") = Me.Level

                ' Remove the Mode and ScreenSequence session information for the screen called.
                If _
                    Not _
                    IsNothing(
                        Session(
                            UniqueSessionID + RunScreen.Name + "_" + (Me.Level + 1).ToString + "_ScreenSequence")) AndAlso
                    Session(UniqueSessionID + RunScreen.Name + "_" + (Me.Level + 1).ToString + "_ScreenSequence") =
                    m_intRunScreenSequence Then
                    Session.Remove(UniqueSessionID + RunScreen.Name + "_" + (Me.Level + 1).ToString + "_Mode")
                    Session.Remove(
                        UniqueSessionID + RunScreen.Name + "_" + (Me.Level + 1).ToString + "_ScreenSequence")
                End If

                ' Retrieve the parameters back from Session.
                If Not IsNothing(arrParm) AndAlso arrParm.Length > 0 Then
                    For i As Integer = 0 To arrParm.Length - 1
                        If Not (arrParm(i) Is Nothing) Then
                            SetParmValue(arrParm(i),
                                         Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM" + (i + 1).ToString),
                                         False)
                        End If
                    Next
                End If

                If Not blnIsInInitialize Then
                    ' Delete the sessions that were created for this run screen.
                    If Session(UniqueSessionID + "Prev") = True Then
                        DeleteSessions(
                            Session(
                                UniqueSessionID + RunScreen.Name + "_" + (Me.Level + 1).ToString + "_" +
                                m_intRunScreenSequence.ToString))
                        Session.Remove(
                            UniqueSessionID + RunScreen.Name + "_" + (Me.Level + 1).ToString + "_" +
                            m_intRunScreenSequence.ToString)
                        Session(UniqueSessionID + "Prev") = True
                    Else
                        DeleteSessions(
                            Session(
                                UniqueSessionID + RunScreen.Name + "_" + (Me.Level + 1).ToString + "_" +
                                m_intRunScreenSequence.ToString))
                        Session.Remove(
                            UniqueSessionID + RunScreen.Name + "_" + (Me.Level + 1).ToString + "_" +
                            m_intRunScreenSequence.ToString)
                    End If
                End If

            End If
        End Sub

        ''' --- RunScreen ----------------------------------------------------------
        ''' <summary>
        '''     Summary of RunScreen.
        ''' </summary>
        ''' <param name="RunScreenName"></param>
        ''' <param name="RunScreenMode"></param>
        ''' <param name="Parm1"></param>
        ''' <param name="Parm2"></param>
        ''' <param name="Parm3"></param>
        ''' <param name="Parm4"></param>
        ''' <param name="Parm5"></param>
        ''' <param name="Parm6"></param>
        ''' <param name="Parm7"></param>
        ''' <param name="Parm8"></param>
        ''' <param name="Parm9"></param>
        ''' <param name="Parm10"></param>
        ''' <param name="Parm11"></param>
        ''' <param name="Parm12"></param>
        ''' <param name="Parm13"></param>
        ''' <param name="Parm14"></param>
        ''' <param name="Parm15"></param>
        ''' <param name="Parm16"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub RunScreen(RunScreenName As String)
            Dim arrRunscreen() As Object = Nothing
            RunScreen(RunScreenName, RunScreenModes.Null, arrRunscreen)
        End Sub

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub RunScreen(RunScreenName As String, RunScreenMode As RunScreenModes)
            Dim arrRunscreen() As Object = Nothing
            RunScreen(RunScreenName, RunScreenMode, arrRunscreen)
        End Sub

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub RunScreen(RunScreenName As String, RunScreenMode As RunScreenModes, ByRef arrParm() As Object)

            Session(UniqueSessionID + "URL") = RunScreenName
            SetRunScreenMemberVariables(RunScreenName)

            m_intRunScreenSequence += 1

            Dim blnMethodWasExecuted As Boolean

            If blnIsInInitialize Then
                blnMethodWasExecuted = MethodWasExecuted(m_intRunScreenSequence, RunScreenName, "RUN_FLAG")
            Else
                blnMethodWasExecuted = MethodWasExecuted(m_strRunFlag, m_intRunScreenSequence, "RUN_FLAG")
            End If

            If Not blnMethodWasExecuted Then

                If blnIsInInitialize Then
                    SetMethodExecutedFlag(m_strRunFlag, "RUN_FLAG", m_intRunScreenSequence, RunScreenName)
                Else
                    SetMethodExecutedFlag(m_strRunFlag, "RUN_FLAG", m_intRunScreenSequence)
                End If

                ' Save the sequence information and set a flag indicating screen was run.
                'TODO: At present we are not saving sequence
                '      Need to revisit for Run/Ghost Screen called from the specified Method on a specified Class
                'SetScreenWasRunFlag(m_intRunScreenSequence)

                ' Save the parameters passed to the RUN SCREEN.
                If Not IsNothing(arrParm) AndAlso arrParm.Length > 0 Then
                    For i As Integer = 0 To arrParm.Length - 1
                        If Not (arrParm(i) Is Nothing) Then
                            Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM" + (i + 1).ToString) =
                                GetParmValue(arrParm(i))
                        End If
                    Next
                End If

                Session(
                    UniqueSessionID + RunScreenName + "_" + (Me.Level + 1).ToString + "_" +
                    m_intRunScreenSequence.ToString) = Session.Count

                'Commented from original Base Page
                ' Default: E for subscreen invoked during the standard entry procedure, otherwise NULL.
                If RunScreenMode = RunScreenModes.NoneSelected Then
                    'If Me.Mode = PageModeTypes.Entry Then
                    '    RunScreenMode =  RunScreenModes.Entry
                    'End If
                End If

                If RunScreenMode = RunScreenModes.Same Then
                    ' TODO: Test this scenario once we change the FIND and ENTRY mode code.
                    'RunScreenMode = Mode
                End If

                m_strRunScreen = RunScreenName
                Session(UniqueSessionID + RunScreenName + "_" + (Me.Level + 1).ToString + "_Mode") = RunScreenMode
                Session(UniqueSessionID + RunScreenName + "_" + (Me.Level + 1).ToString + "_ScreenSequence") =
                    m_intRunScreenSequence
                Session(UniqueSessionID + "ScreenLevel") = Me.Level + 1

                If blnIsInInitialize Then
                    QDesign.ThrowCustomApplicationException(cMenuRunScreenException)
                Else
                    QDesign.ThrowCustomApplicationException(cRunScreenException)
                End If

            Else
                ' Reset the m_strRunScreen variable.
                m_strRunScreen = ""

                ' Decrement the ScreenLevel.
                Session(UniqueSessionID + "ScreenLevel") = Me.Level
                Session.Remove(UniqueSessionID + "URL")

                ' Remove the Mode and ScreenSequence session information for the screen called.
                If _
                    Not _
                    IsNothing(
                        Session(UniqueSessionID + RunScreenName + "_" + (Me.Level + 1).ToString + "_ScreenSequence")) AndAlso
                    Session(UniqueSessionID + RunScreenName + "_" + (Me.Level + 1).ToString + "_ScreenSequence") =
                    m_intRunScreenSequence Then
                    Session.Remove(UniqueSessionID + RunScreenName + "_" + (Me.Level + 1).ToString + "_Mode")
                    Session.Remove(
                        UniqueSessionID + RunScreenName + "_" + (Me.Level + 1).ToString + "_ScreenSequence")
                End If

                ' Retrieve the parameters back from Session.
                If Not IsNothing(arrParm) AndAlso arrParm.Length > 0 Then
                    For i As Integer = 0 To arrParm.Length - 1
                        If Not (arrParm(i) Is Nothing) Then
                            SetParmValue(arrParm(i),
                                         Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM" + (i + 1).ToString),
                                         False)
                        End If
                    Next
                End If

                If Not blnIsInInitialize Then
                    ' Delete the sessions that were created for this run screen.
                    If Session(UniqueSessionID + "Prev") = True Then
                        DeleteSessions(
                            Session(
                                UniqueSessionID + RunScreenName + "_" + (Me.Level + 1).ToString + "_" +
                                m_intRunScreenSequence.ToString))
                        Session.Remove(
                            UniqueSessionID + RunScreenName + "_" + (Me.Level + 1).ToString + "_" +
                            m_intRunScreenSequence.ToString)
                        Session(UniqueSessionID + "Prev") = True
                    Else
                        DeleteSessions(
                            Session(
                                UniqueSessionID + RunScreenName + "_" + (Me.Level + 1).ToString + "_" +
                                m_intRunScreenSequence.ToString))
                        Session.Remove(
                            UniqueSessionID + RunScreenName + "_" + (Me.Level + 1).ToString + "_" +
                            m_intRunScreenSequence.ToString)
                    End If
                End If

                If blnIsInInitialize AndAlso m_intRunScreenSequence > 0 Then
                    m_intRunScreenSequence -= 1
                End If
            End If
        End Sub

        ''' --- RunScreen ----------------------------------------------------------
        ''' <summary>
        '''     Summary of RunScreen.
        ''' </summary>
        ''' <param name="RunScreenName"></param>
        ''' <param name="RunScreenMode"></param>
        ''' <param name="Parm1"></param>
        ''' <param name="Parm2"></param>
        ''' <param name="Parm3"></param>
        ''' <param name="Parm4"></param>
        ''' <param name="Parm5"></param>
        ''' <param name="Parm6"></param>
        ''' <param name="Parm7"></param>
        ''' <param name="Parm8"></param>
        ''' <param name="Parm9"></param>
        ''' <param name="Parm10"></param>
        ''' <param name="Parm11"></param>
        ''' <param name="Parm12"></param>
        ''' <param name="Parm13"></param>
        ''' <param name="Parm14"></param>
        ''' <param name="Parm15"></param>
        ''' <param name="Parm16"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub RunScreen(ByRef RunScreen As BaseClassControl, RunScreenMode As RunScreenModes, ByRef Parm1 As Object _
                             , Optional ByRef Parm2 As Object = Nothing, Optional ByRef Parm3 As Object = Nothing,
                             Optional ByRef Parm4 As Object = Nothing _
                             , Optional ByRef Parm5 As Object = Nothing, Optional ByRef Parm6 As Object = Nothing,
                             Optional ByRef Parm7 As Object = Nothing _
                             , Optional ByRef Parm8 As Object = Nothing, Optional ByRef Parm9 As Object = Nothing,
                             Optional ByRef Parm10 As Object = Nothing _
                             , Optional ByRef Parm11 As Object = Nothing, Optional ByRef Parm12 As Object = Nothing,
                             Optional ByRef Parm13 As Object = Nothing _
                             , Optional ByRef Parm14 As Object = Nothing, Optional ByRef Parm15 As Object = Nothing,
                             Optional ByRef Parm16 As Object = Nothing _
                             , Optional ByRef Parm17 As Object = Nothing, Optional ByRef Parm18 As Object = Nothing,
                             Optional ByRef Parm19 As Object = Nothing _
                             , Optional ByRef Parm20 As Object = Nothing, Optional ByRef Parm21 As Object = Nothing)

            Dim blnMethodWasExecuted As Boolean
            m_intRunScreenSequence += 1

            blnMethodWasExecuted = MethodWasExecuted(m_strRunFlag, m_intRunScreenSequence, "RUN_FLAG")

            If Not blnMethodWasExecuted Then

                SetMethodExecutedFlag(m_strRunFlag, "RUN_FLAG", m_intRunScreenSequence)

                ' Save the sequence information and set a flag indicating screen was run.
                'TODO: At present we are not saving sequence
                '      Need to revisit for Run/Ghost Screen called from the specified Method on a specified Class
                'SetScreenWasRunFlag(m_intRunScreenSequence)

                ' Save the parameters passed to the RUN SCREEN.
                If Not (Parm1 Is Nothing) Then
                    Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM1") = GetParmValue(Parm1)
                End If
                If Not (Parm2 Is Nothing) Then
                    Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM2") = GetParmValue(Parm2)
                End If
                If Not (Parm3 Is Nothing) Then
                    Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM3") = GetParmValue(Parm3)
                End If
                If Not (Parm4 Is Nothing) Then
                    Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM4") = GetParmValue(Parm4)
                End If
                If Not (Parm5 Is Nothing) Then
                    Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM5") = GetParmValue(Parm5)
                End If
                If Not (Parm6 Is Nothing) Then
                    Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM6") = GetParmValue(Parm6)
                End If
                If Not (Parm7 Is Nothing) Then
                    Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM7") = GetParmValue(Parm7)
                End If
                If Not (Parm8 Is Nothing) Then
                    Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM8") = GetParmValue(Parm8)
                End If
                If Not (Parm9 Is Nothing) Then
                    Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM9") = GetParmValue(Parm9)
                End If
                If Not (Parm10 Is Nothing) Then
                    Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM10") = GetParmValue(Parm10)
                End If
                If Not (Parm11 Is Nothing) Then
                    Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM11") = GetParmValue(Parm11)
                End If
                If Not (Parm12 Is Nothing) Then
                    Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM12") = GetParmValue(Parm12)
                End If
                If Not (Parm13 Is Nothing) Then
                    Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM13") = GetParmValue(Parm13)
                End If
                If Not (Parm14 Is Nothing) Then
                    Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM14") = GetParmValue(Parm14)
                End If
                If Not (Parm15 Is Nothing) Then
                    Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM15") = GetParmValue(Parm15)
                End If
                If Not (Parm16 Is Nothing) Then
                    Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM16") = GetParmValue(Parm16)
                End If
                If Not (Parm17 Is Nothing) Then
                    Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM17") = GetParmValue(Parm17)
                End If
                If Not (Parm18 Is Nothing) Then
                    Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM18") = GetParmValue(Parm18)
                End If
                If Not (Parm19 Is Nothing) Then
                    Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM19") = GetParmValue(Parm19)
                End If
                If Not (Parm20 Is Nothing) Then
                    Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM20") = GetParmValue(Parm20)
                End If
                If Not (Parm21 Is Nothing) Then
                    Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM21") = GetParmValue(Parm21)
                End If

                Session(
                    UniqueSessionID + RunScreen.Name + "_" + (Me.Level + 1).ToString + "_" +
                    m_intRunScreenSequence.ToString) = Session.Count

                'Commented from original Base Page
                ' Default: E for subscreen invoked during the standard entry procedure, otherwise NULL.
                If RunScreenMode = RunScreenModes.NoneSelected Then
                    'If Me.Mode = PageModeTypes.Entry Then
                    '    RunScreenMode =  RunScreenModes.Entry
                    'End If
                End If

                If RunScreenMode = RunScreenModes.Same Then
                    ' TODO: Test this scenario once we change the FIND and ENTRY mode code.
                    'RunScreenMode = Mode
                End If

                m_strRunScreen = RunScreen.Name
                Session(UniqueSessionID + RunScreen.Name + "_" + (Me.Level + 1).ToString + "_Mode") = RunScreenMode
                Session(UniqueSessionID + RunScreen.Name + "_" + (Me.Level + 1).ToString + "_ScreenSequence") =
                    m_intRunScreenSequence
                Session(UniqueSessionID + "ScreenLevel") = Me.Level + 1

                'Treating RunScreen as the Ghost Screen, which is used in ReturnAndClose for not throwing an exception
                RunScreen.ScreenType = ScreenTypes.Ghost

                Try
                    RunScreen.CallInitialize(RunScreenMode)
                Catch ex As CustomApplicationException
                    If ex.Message <> cReturn.ToString Then
                        Throw ex
                    End If
                Catch ex As Exception
                    ' Write the exception to the event log and throw an error.
                    ExceptionManager.Publish(ex)
                End Try
                blnMethodWasExecuted = True
            End If

            If blnMethodWasExecuted Then

                ' Reset the m_strRunScreen variable.
                m_strRunScreen = ""

                ' Decrement the ScreenLevel.
                Session(UniqueSessionID + "ScreenLevel") = Me.Level

                ' Remove the Mode and ScreenSequence session information for the screen called.
                If _
                    Not _
                    IsNothing(
                        Session(
                            UniqueSessionID + RunScreen.Name + "_" + (Me.Level + 1).ToString + "_ScreenSequence")) AndAlso
                    Session(UniqueSessionID + RunScreen.Name + "_" + (Me.Level + 1).ToString + "_ScreenSequence") =
                    m_intRunScreenSequence Then
                    Session.Remove(UniqueSessionID + RunScreen.Name + "_" + (Me.Level + 1).ToString + "_Mode")
                    Session.Remove(
                        UniqueSessionID + RunScreen.Name + "_" + (Me.Level + 1).ToString + "_ScreenSequence")
                End If

                ' Retrieve the parameters back from Session.
                If Not (Parm1 Is Nothing) Then
                    SetParmValue(Parm1, Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM1"), False)
                End If
                If Not (Parm2 Is Nothing) Then
                    SetParmValue(Parm2, Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM2"), False)
                End If
                If Not (Parm3 Is Nothing) Then
                    SetParmValue(Parm3, Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM3"), False)
                End If
                If Not (Parm4 Is Nothing) Then
                    SetParmValue(Parm4, Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM4"), False)
                End If
                If Not (Parm5 Is Nothing) Then
                    SetParmValue(Parm5, Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM5"), False)
                End If
                If Not (Parm6 Is Nothing) Then
                    SetParmValue(Parm6, Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM6"), False)
                End If
                If Not (Parm7 Is Nothing) Then
                    SetParmValue(Parm7, Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM7"), False)
                End If
                If Not (Parm8 Is Nothing) Then
                    SetParmValue(Parm8, Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM8"), False)
                End If
                If Not (Parm9 Is Nothing) Then
                    SetParmValue(Parm9, Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM9"), False)
                End If
                If Not (Parm10 Is Nothing) Then
                    SetParmValue(Parm10, Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM10"), False)
                End If
                If Not (Parm11 Is Nothing) Then
                    SetParmValue(Parm11, Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM11"), False)
                End If
                If Not (Parm12 Is Nothing) Then
                    SetParmValue(Parm12, Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM12"), False)
                End If
                If Not (Parm13 Is Nothing) Then
                    SetParmValue(Parm13, Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM13"), False)
                End If
                If Not (Parm14 Is Nothing) Then
                    SetParmValue(Parm14, Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM14"), False)
                End If
                If Not (Parm15 Is Nothing) Then
                    SetParmValue(Parm15, Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM15"), False)
                End If
                If Not (Parm16 Is Nothing) Then
                    SetParmValue(Parm16, Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM16"), False)
                End If
                If Not (Parm17 Is Nothing) Then
                    SetParmValue(Parm17, Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM17"), False)
                End If
                If Not (Parm18 Is Nothing) Then
                    SetParmValue(Parm18, Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM18"), False)
                End If
                If Not (Parm19 Is Nothing) Then
                    SetParmValue(Parm19, Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM19"), False)
                End If
                If Not (Parm20 Is Nothing) Then
                    SetParmValue(Parm20, Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM20"), False)
                End If
                If Not (Parm21 Is Nothing) Then
                    SetParmValue(Parm21, Me.CalledPageSession(RunScreen.Name, Me.Level + 1, "PARM21"), False)
                End If

                If Not blnIsInInitialize Then
                    ' Delete the sessions that were created for this run screen.
                    If Session(UniqueSessionID + "Prev") = True Then
                        DeleteSessions(
                            Session(
                                UniqueSessionID + RunScreen.Name + "_" + (Me.Level + 1).ToString + "_" +
                                m_intRunScreenSequence.ToString))
                        Session.Remove(
                            UniqueSessionID + RunScreen.Name + "_" + (Me.Level + 1).ToString + "_" +
                            m_intRunScreenSequence.ToString)
                        Session(UniqueSessionID + "Prev") = True
                    Else
                        DeleteSessions(
                            Session(
                                UniqueSessionID + RunScreen.Name + "_" + (Me.Level + 1).ToString + "_" +
                                m_intRunScreenSequence.ToString))
                        Session.Remove(
                            UniqueSessionID + RunScreen.Name + "_" + (Me.Level + 1).ToString + "_" +
                            m_intRunScreenSequence.ToString)
                    End If
                End If

            End If
        End Sub

        ''' --- RunScreen ----------------------------------------------------------
        ''' <summary>
        '''     Summary of RunScreen.
        ''' </summary>
        ''' <param name="RunScreenName"></param>
        ''' <param name="RunScreenMode"></param>
        ''' <param name="Parm1"></param>
        ''' <param name="Parm2"></param>
        ''' <param name="Parm3"></param>
        ''' <param name="Parm4"></param>
        ''' <param name="Parm5"></param>
        ''' <param name="Parm6"></param>
        ''' <param name="Parm7"></param>
        ''' <param name="Parm8"></param>
        ''' <param name="Parm9"></param>
        ''' <param name="Parm10"></param>
        ''' <param name="Parm11"></param>
        ''' <param name="Parm12"></param>
        ''' <param name="Parm13"></param>
        ''' <param name="Parm14"></param>
        ''' <param name="Parm15"></param>
        ''' <param name="Parm16"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Sub RunScreen(RunScreenName As String, RunScreenMode As RunScreenModes, ByRef Parm1 As Object _
                             , Optional ByRef Parm2 As Object = Nothing, Optional ByRef Parm3 As Object = Nothing,
                             Optional ByRef Parm4 As Object = Nothing _
                             , Optional ByRef Parm5 As Object = Nothing, Optional ByRef Parm6 As Object = Nothing,
                             Optional ByRef Parm7 As Object = Nothing _
                             , Optional ByRef Parm8 As Object = Nothing, Optional ByRef Parm9 As Object = Nothing,
                             Optional ByRef Parm10 As Object = Nothing _
                             , Optional ByRef Parm11 As Object = Nothing, Optional ByRef Parm12 As Object = Nothing,
                             Optional ByRef Parm13 As Object = Nothing _
                             , Optional ByRef Parm14 As Object = Nothing, Optional ByRef Parm15 As Object = Nothing,
                             Optional ByRef Parm16 As Object = Nothing _
                             , Optional ByRef Parm17 As Object = Nothing, Optional ByRef Parm18 As Object = Nothing,
                             Optional ByRef Parm19 As Object = Nothing _
                             , Optional ByRef Parm20 As Object = Nothing, Optional ByRef Parm21 As Object = Nothing)

            Session(UniqueSessionID + "URL") = RunScreenName
            SetRunScreenMemberVariables(RunScreenName)

            m_intRunScreenSequence += 1

            Dim blnMethodWasExecuted As Boolean

            If blnIsInInitialize Then
                blnMethodWasExecuted = MethodWasExecuted(m_intRunScreenSequence, RunScreenName, "RUN_FLAG")
            Else
                blnMethodWasExecuted = MethodWasExecuted(m_strRunFlag, m_intRunScreenSequence, "RUN_FLAG")
            End If

            If Not blnMethodWasExecuted Then

                If blnIsInInitialize Then
                    SetMethodExecutedFlag(m_strRunFlag, "RUN_FLAG", m_intRunScreenSequence, RunScreenName)
                Else
                    SetMethodExecutedFlag(m_strRunFlag, "RUN_FLAG", m_intRunScreenSequence)
                End If

                ' Save the sequence information and set a flag indicating screen was run.
                'TODO: At present we are not saving sequence
                '      Need to revisit for Run/Ghost Screen called from the specified Method on a specified Class
                'SetScreenWasRunFlag(m_intRunScreenSequence)

                ' Save the parameters passed to the RUN SCREEN.
                If Not (Parm1 Is Nothing) Then
                    Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM1") = GetParmValue(Parm1)
                End If
                If Not (Parm2 Is Nothing) Then
                    Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM2") = GetParmValue(Parm2)
                End If
                If Not (Parm3 Is Nothing) Then
                    Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM3") = GetParmValue(Parm3)
                End If
                If Not (Parm4 Is Nothing) Then
                    Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM4") = GetParmValue(Parm4)
                End If
                If Not (Parm5 Is Nothing) Then
                    Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM5") = GetParmValue(Parm5)
                End If
                If Not (Parm6 Is Nothing) Then
                    Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM6") = GetParmValue(Parm6)
                End If
                If Not (Parm7 Is Nothing) Then
                    Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM7") = GetParmValue(Parm7)
                End If
                If Not (Parm8 Is Nothing) Then
                    Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM8") = GetParmValue(Parm8)
                End If
                If Not (Parm9 Is Nothing) Then
                    Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM9") = GetParmValue(Parm9)
                End If
                If Not (Parm10 Is Nothing) Then
                    Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM10") = GetParmValue(Parm10)
                End If
                If Not (Parm11 Is Nothing) Then
                    Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM11") = GetParmValue(Parm11)
                End If
                If Not (Parm12 Is Nothing) Then
                    Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM12") = GetParmValue(Parm12)
                End If
                If Not (Parm13 Is Nothing) Then
                    Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM13") = GetParmValue(Parm13)
                End If
                If Not (Parm14 Is Nothing) Then
                    Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM14") = GetParmValue(Parm14)
                End If
                If Not (Parm15 Is Nothing) Then
                    Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM15") = GetParmValue(Parm15)
                End If
                If Not (Parm16 Is Nothing) Then
                    Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM16") = GetParmValue(Parm16)
                End If
                If Not (Parm17 Is Nothing) Then
                    Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM17") = GetParmValue(Parm17)
                End If
                If Not (Parm18 Is Nothing) Then
                    Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM18") = GetParmValue(Parm18)
                End If
                If Not (Parm19 Is Nothing) Then
                    Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM19") = GetParmValue(Parm19)
                End If
                If Not (Parm20 Is Nothing) Then
                    Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM20") = GetParmValue(Parm20)
                End If
                If Not (Parm21 Is Nothing) Then
                    Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM21") = GetParmValue(Parm21)
                End If

                Session(
                    UniqueSessionID + RunScreenName + "_" + (Me.Level + 1).ToString + "_" +
                    m_intRunScreenSequence.ToString) = Session.Count

                'Commented from original Base Page
                ' Default: E for subscreen invoked during the standard entry procedure, otherwise NULL.
                If RunScreenMode = RunScreenModes.NoneSelected Then
                    'If Me.Mode = PageModeTypes.Entry Then
                    '    RunScreenMode =  RunScreenModes.Entry
                    'End If
                End If

                If RunScreenMode = RunScreenModes.Same Then
                    ' TODO: Test this scenario once we change the FIND and ENTRY mode code.
                    'RunScreenMode = Mode
                End If

                m_strRunScreen = RunScreenName
                Session(UniqueSessionID + RunScreenName + "_" + (Me.Level + 1).ToString + "_Mode") = RunScreenMode
                Session(UniqueSessionID + RunScreenName + "_" + (Me.Level + 1).ToString + "_ScreenSequence") =
                    m_intRunScreenSequence
                Session(UniqueSessionID + "ScreenLevel") = Me.Level + 1

                If blnIsInInitialize Then
                    QDesign.ThrowCustomApplicationException(cMenuRunScreenException)
                Else
                    QDesign.ThrowCustomApplicationException(cRunScreenException)
                End If

            Else
                ' Reset the m_strRunScreen variable.
                m_strRunScreen = ""

                ' Decrement the ScreenLevel.
                Session(UniqueSessionID + "ScreenLevel") = Me.Level
                Session.Remove(UniqueSessionID + "URL")

                ' Remove the Mode and ScreenSequence session information for the screen called.
                If _
                    Not _
                    IsNothing(
                        Session(UniqueSessionID + RunScreenName + "_" + (Me.Level + 1).ToString + "_ScreenSequence")) AndAlso
                    Session(UniqueSessionID + RunScreenName + "_" + (Me.Level + 1).ToString + "_ScreenSequence") =
                    m_intRunScreenSequence Then
                    Session.Remove(UniqueSessionID + RunScreenName + "_" + (Me.Level + 1).ToString + "_Mode")
                    Session.Remove(
                        UniqueSessionID + RunScreenName + "_" + (Me.Level + 1).ToString + "_ScreenSequence")
                End If

                ' Retrieve the parameters back from Session.
                If Not (Parm1 Is Nothing) Then
                    SetParmValue(Parm1, Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM1"), False)
                End If
                If Not (Parm2 Is Nothing) Then
                    SetParmValue(Parm2, Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM2"), False)
                End If
                If Not (Parm3 Is Nothing) Then
                    SetParmValue(Parm3, Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM3"), False)
                End If
                If Not (Parm4 Is Nothing) Then
                    SetParmValue(Parm4, Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM4"), False)
                End If
                If Not (Parm5 Is Nothing) Then
                    SetParmValue(Parm5, Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM5"), False)
                End If
                If Not (Parm6 Is Nothing) Then
                    SetParmValue(Parm6, Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM6"), False)
                End If
                If Not (Parm7 Is Nothing) Then
                    SetParmValue(Parm7, Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM7"), False)
                End If
                If Not (Parm8 Is Nothing) Then
                    SetParmValue(Parm8, Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM8"), False)
                End If
                If Not (Parm9 Is Nothing) Then
                    SetParmValue(Parm9, Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM9"), False)
                End If
                If Not (Parm10 Is Nothing) Then
                    SetParmValue(Parm10, Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM10"), False)
                End If
                If Not (Parm11 Is Nothing) Then
                    SetParmValue(Parm11, Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM11"), False)
                End If
                If Not (Parm12 Is Nothing) Then
                    SetParmValue(Parm12, Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM12"), False)
                End If
                If Not (Parm13 Is Nothing) Then
                    SetParmValue(Parm13, Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM13"), False)
                End If
                If Not (Parm14 Is Nothing) Then
                    SetParmValue(Parm14, Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM14"), False)
                End If
                If Not (Parm15 Is Nothing) Then
                    SetParmValue(Parm15, Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM15"), False)
                End If
                If Not (Parm16 Is Nothing) Then
                    SetParmValue(Parm16, Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM16"), False)
                End If
                If Not (Parm17 Is Nothing) Then
                    SetParmValue(Parm17, Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM17"), False)
                End If
                If Not (Parm18 Is Nothing) Then
                    SetParmValue(Parm18, Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM18"), False)
                End If
                If Not (Parm19 Is Nothing) Then
                    SetParmValue(Parm19, Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM19"), False)
                End If
                If Not (Parm20 Is Nothing) Then
                    SetParmValue(Parm20, Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM20"), False)
                End If
                If Not (Parm21 Is Nothing) Then
                    SetParmValue(Parm21, Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM21"), False)
                End If

                If Not blnIsInInitialize Then
                    ' Delete the sessions that were created for this run screen.
                    If Session(UniqueSessionID + "Prev") = True Then
                        DeleteSessions(
                            Session(
                                UniqueSessionID + RunScreenName + "_" + (Me.Level + 1).ToString + "_" +
                                m_intRunScreenSequence.ToString))
                        Session.Remove(
                            UniqueSessionID + RunScreenName + "_" + (Me.Level + 1).ToString + "_" +
                            m_intRunScreenSequence.ToString)
                        Session(UniqueSessionID + "Prev") = True
                    Else
                        DeleteSessions(
                            Session(
                                UniqueSessionID + RunScreenName + "_" + (Me.Level + 1).ToString + "_" +
                                m_intRunScreenSequence.ToString))
                        Session.Remove(
                            UniqueSessionID + RunScreenName + "_" + (Me.Level + 1).ToString + "_" +
                            m_intRunScreenSequence.ToString)
                    End If
                End If

                If blnIsInInitialize AndAlso m_intRunScreenSequence > 0 Then
                    m_intRunScreenSequence -= 1
                End If
            End If
        End Sub

        ''' --- Put ----------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     PowerHouse PUT verb.
        ''' </summary>
        ''' <param name="FileObject"></param>
        ''' <param name="Reset"></param>
        ''' <param name="PutType"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <example>
        '''     PutData(fleTEST)<br />
        ''' </example>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Function PutData(ByRef FileObject As SqlFileObject) As Boolean

            Dim blnReturnValue As Boolean
            Dim strFileName As String
            Dim stcFile As stcFileInfo
            Dim Reset As ResetOptions = ResetOptions.NoReset
            Dim PutType As PutTypes = PutTypes.None

            m_intPutSequence += 1

            ' Get the file name (either Alias name or Base name).
            If FileObject.AliasName.TrimEnd.Length > 0 Then
                strFileName = FileObject.AliasName
            Else
                strFileName = FileObject.BaseName
            End If

            strFileName &= m_intPutSequence.ToString

            Dim blnMethodWasExecuted As Boolean

            blnMethodWasExecuted = MethodWasExecuted(m_strPutFlag, m_intPutSequence, "PUT_FLAG")

            If Not blnMethodWasExecuted Then

                ' If the PUT was called with the New, Deleted or NotDeleted option, and
                ' the recordstatus does not match, then don't do anything.
                If FileObject.ContinuePut(PutType) Then
                    FileObject.PutData(CBool(Reset), PutType)

                    ' Store the RowId and CheckSum_Value.
                    If m_htFileInfo Is Nothing Then m_htFileInfo = New Hashtable

                    stcFile.RowId = FileObject.RecordLocation
                    stcFile.CheckSum = FileObject.GetDecimalValue("CHECKSUM_VALUE")
                    stcFile.AlteredRecord = FileObject.AlteredRecord
                    stcFile.DeletedRecord = FileObject.DeletedRecord
                    stcFile.NewRecord = FileObject.NewRecord

                    m_htFileInfo.Add(strFileName, stcFile)
                    Session(UniqueSessionID + FormName + "_" + Level.ToString + "_" + "ROWIDCHECKSUM") = m_htFileInfo
                End If

                ' Save the sequence information and set a flag indicating ACCEPT was run.

                SetMethodExecutedFlag(m_strPutFlag, "PUT_FLAG", m_intPutSequence)

                blnReturnValue = True
            Else

                ' If the first time the PUT was called with the New, Deleted or NotDeleted option, and
                ' the recordstatus did not match, then don't do anything since nothing was done
                ' the first time.  Otherwise, set the appropriate values.
                If FileObject.ContinuePut(PutType) Then

                    ' Call the Reset option.
                    If CBool(Reset) Then
                        FileObject.CallReset()
                        FileObject.AlteredRecord = False
                        FileObject.DeletedRecord = False
                    Else
                        ' Retrieve the RowId and CheckSum_Value.
                        stcFile = CType(m_htFileInfo.Item(strFileName), stcFileInfo)
                        FileObject.SetValue("ROW_ID") = stcFile.RowId
                        FileObject.SetValue("CHECKSUM_VALUE") = stcFile.CheckSum
                        FileObject.AlteredRecord = stcFile.AlteredRecord
                        FileObject.DeletedRecord = stcFile.DeletedRecord
                        FileObject.NewRecord = stcFile.NewRecord
                        FileObject.AcceptChanges()
                    End If

                End If

                blnReturnValue = True
            End If

            ' Cleanup.
            strFileName = Nothing
            stcFile = Nothing

            Return blnReturnValue
        End Function

        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Function PutData(ByRef FileObject As BaseFileObject) As Boolean

            Dim blnReturnValue As Boolean
            Dim strFileName As String
            Dim stcFile As stcFileInfo
            Dim Reset As ResetOptions = ResetOptions.NoReset
            Dim PutType As PutTypes = PutTypes.None

            m_intPutSequence += 1

            ' Get the file name (either Alias name or Base name).
            If FileObject.AliasName.TrimEnd.Length > 0 Then
                strFileName = FileObject.AliasName
            Else
                strFileName = FileObject.BaseName
            End If

            strFileName &= m_intPutSequence.ToString

            Dim blnMethodWasExecuted As Boolean

            blnMethodWasExecuted = MethodWasExecuted(m_strPutFlag, m_intPutSequence, "PUT_FLAG")

            If Not blnMethodWasExecuted Then

                ' If the PUT was called with the New, Deleted or NotDeleted option, and
                ' the recordstatus does not match, then don't do anything.
                If FileObject.ContinuePut(PutType) Then
                    FileObject.PutData(CBool(Reset), PutType)

                    ' Store the RowId and CheckSum_Value.
                    If m_htFileInfo Is Nothing Then m_htFileInfo = New Hashtable

                    stcFile.RowId = FileObject.RecordLocation
                    stcFile.CheckSum = FileObject.GetDecimalValue("CHECKSUM_VALUE")
                    stcFile.AlteredRecord = FileObject.AlteredRecord
                    stcFile.DeletedRecord = FileObject.DeletedRecord
                    stcFile.NewRecord = FileObject.NewRecord

                    m_htFileInfo.Add(strFileName, stcFile)
                    Session(UniqueSessionID + FormName + "_" + Level.ToString + "_" + "ROWIDCHECKSUM") = m_htFileInfo
                End If

                ' Save the sequence information and set a flag indicating ACCEPT was run.

                SetMethodExecutedFlag(m_strPutFlag, "PUT_FLAG", m_intPutSequence)

                blnReturnValue = True
            Else

                ' If the first time the PUT was called with the New, Deleted or NotDeleted option, and
                ' the recordstatus did not match, then don't do anything since nothing was done
                ' the first time.  Otherwise, set the appropriate values.
                If FileObject.ContinuePut(PutType) Then

                    ' Call the Reset option.
                    If CBool(Reset) Then
                        FileObject.CallReset()
                        FileObject.AlteredRecord = False
                        FileObject.DeletedRecord = False
                    Else
                        ' Retrieve the RowId and CheckSum_Value.
                        stcFile = CType(m_htFileInfo.Item(strFileName), stcFileInfo)
                        FileObject.SetValue("ROW_ID") = stcFile.RowId
                        FileObject.SetValue("CHECKSUM_VALUE") = stcFile.CheckSum
                        FileObject.AlteredRecord = stcFile.AlteredRecord
                        FileObject.DeletedRecord = stcFile.DeletedRecord
                        FileObject.NewRecord = stcFile.NewRecord
                        FileObject.AcceptChanges()
                    End If

                End If

                blnReturnValue = True
            End If

            ' Cleanup.
            strFileName = Nothing
            stcFile = Nothing

            Return blnReturnValue
        End Function

        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Function PutData(ByRef FileObject As BaseFileObject, Reset As ResetOptions) As Boolean
            PutData(FileObject, Reset, PutTypes.None)
        End Function

        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Function PutData(ByRef FileObject As SqlFileObject, Reset As ResetOptions) As Boolean
            PutData(FileObject, Reset, PutTypes.None)
        End Function


        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Function PutData(ByRef FileObject As BaseFileObject, Reset As ResetOptions, PutType As PutTypes) _
            As Boolean

            Dim blnReturnValue As Boolean
            Dim strFileName As String
            Dim stcFile As stcFileInfo

            m_intPutSequence += 1

            ' Get the file name (either Alias name or Base name).
            If FileObject.AliasName.TrimEnd.Length > 0 Then
                strFileName = FileObject.AliasName
            Else
                strFileName = FileObject.BaseName
            End If

            strFileName &= m_intPutSequence.ToString

            Dim blnMethodWasExecuted As Boolean

            blnMethodWasExecuted = MethodWasExecuted(m_strPutFlag, m_intPutSequence, "PUT_FLAG")

            If Not blnMethodWasExecuted Then

                ' If the PUT was called with the New, Deleted or NotDeleted option, and
                ' the recordstatus does not match, then don't do anything.
                If FileObject.ContinuePut(PutType) Then
                    FileObject.PutData(CBool(Reset), PutType)

                    ' Store the RowId and CheckSum_Value.
                    If m_htFileInfo Is Nothing Then m_htFileInfo = New Hashtable

                    stcFile.RowId = FileObject.RecordLocation
                    stcFile.CheckSum = FileObject.GetDecimalValue("CHECKSUM_VALUE")
                    stcFile.AlteredRecord = FileObject.AlteredRecord
                    stcFile.DeletedRecord = FileObject.DeletedRecord
                    stcFile.NewRecord = FileObject.NewRecord

                    m_htFileInfo.Add(strFileName, stcFile)
                    Session(UniqueSessionID + FormName + "_" + Level.ToString + "_" + "ROWIDCHECKSUM") = m_htFileInfo
                End If

                ' Save the sequence information and set a flag indicating ACCEPT was run.

                SetMethodExecutedFlag(m_strPutFlag, "PUT_FLAG", m_intPutSequence)

                blnReturnValue = True
            Else

                ' If the first time the PUT was called with the New, Deleted or NotDeleted option, and
                ' the recordstatus did not match, then don't do anything since nothing was done
                ' the first time.  Otherwise, set the appropriate values.
                If FileObject.ContinuePut(PutType) Then

                    ' Call the Reset option.
                    If CBool(Reset) Then
                        FileObject.CallReset()
                        FileObject.AlteredRecord = False
                        FileObject.DeletedRecord = False
                    Else
                        ' Retrieve the RowId and CheckSum_Value.
                        stcFile = CType(m_htFileInfo.Item(strFileName), stcFileInfo)
                        FileObject.SetValue("ROW_ID") = stcFile.RowId
                        FileObject.SetValue("CHECKSUM_VALUE") = stcFile.CheckSum
                        FileObject.AlteredRecord = stcFile.AlteredRecord
                        FileObject.DeletedRecord = stcFile.DeletedRecord
                        FileObject.NewRecord = stcFile.NewRecord
                        FileObject.AcceptChanges()
                    End If

                End If

                blnReturnValue = True
            End If

            ' Cleanup.
            strFileName = Nothing
            stcFile = Nothing

            Return blnReturnValue
        End Function

        '-------------------------------------------------------------------
        ' Name: DeleteSessions
        ' Function: Removes the sessions for a given screen or all sessions.
        ' Example: DeleteSessions(strScreen)
        '-------------------------------------------------------------------
        ''' --- DeleteSessions -----------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of DeleteSessions.
        ''' </summary>
        ''' <param name="StartingAt"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Sub DeleteSessions(StartingAt As Integer)

            Dim intTotalCount As Integer = Session.Count

            Try

                'If StartingAt > 0 Then
                '    ' Loop through the session variables.
                '    Do While intTotalCount > StartingAt
                '        If Session.Keys(intTotalCount - 1).IndexOf(UniqueSessionID) >= 0 Then
                '            Session.RemoveAt(intTotalCount - 1)
                '        End If

                '        intTotalCount -= 1
                '    Loop
                'End If

            Catch ex As Exception

                Throw ex

            End Try
        End Sub

        '-------------------------------------------------------------------
        ' Name: ScreenWasRun
        ' Function: This function determines if the run screen was already
        '           run based on the sequence of screens run within a given
        '           procedural path (ie. when updating a record).
        ' Example: ScreenWasRun(RunScreenName, Me.Level + 1,
        '           m_intRunScreenSequence) returns FALSE.
        '-------------------------------------------------------------------
        ''' --- MethodWasExecuted -------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of MethodWasExecuted.
        ''' </summary>
        ''' <param name="RunScreenName"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function MethodWasExecuted(Sequence As Integer, RunScreenName As String, FlagName As String) As Boolean
            Dim Flag As String
            Flag = Session(UniqueSessionID + m_Node + "_" + RunScreenName + "_" + Level.ToString + "_" + FlagName) & ""
            If Substring(Flag, Sequence, 1) = "Y" Then
                Return True
            Else
                Return False
            End If
        End Function

        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function MethodWasExecuted(Sequence As Integer, FlagName As String) As Boolean
            Dim Flag As String
            Flag = Session(UniqueSessionID + m_Node + "_" + FormName + "_" + Level.ToString + "_" + FlagName) & ""
            If Substring(Flag, Sequence, 1) = "Y" Then
                Return True
            Else
                Return False
            End If
        End Function

        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function MethodWasExecuted(ByRef Flag As String, Sequence As Integer, FlagName As String) As Boolean
            If FlagName = "PUT_FLAG" Then
                Flag = Session(UniqueSessionID + FormName + "_" + Level.ToString + "_" + FlagName) & ""
            Else
                Flag = Session(UniqueSessionID + m_Node + "_" + FormName + "_" + Level.ToString + "_" + FlagName) & ""
            End If

            If Substring(Flag, Sequence, 1) = "Y" Then
                Return True
            Else
                Return False
            End If
        End Function

        ''' --- GetParmValue -------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Determines whether Object is a FILE or TEMPORARY.
        ''' </summary>
        ''' <param name="Parm">An Object which to determine its value.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <example>CalledPageSession(RunScreenName, Me.Level + 1, "PARM1") = GetParmValue(Parm1)</example>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Function GetParmValue(ByRef Parm As Object, Optional ByVal GetValues As Boolean = False) As Object

            Select Case Parm.GetType.ToString
                Case "CORE.WINDOWS.UI.CORE.WINDOWS.OracleFileObject", "CORE.WINDOWS.UI.CORE.WINDOWS.SqlFileObject",
                    "CORE.WINDOWS.UI.CORE.WINDOWS.IfxFileObject"
                    Return CType(Parm, IFileObject).GetInternalValues(True)
                Case "CORE.WINDOWS.UI.CORE.WINDOWS.CoreCharacter"
                    If GetValues AndAlso CType(Parm, CoreCharacter).Occurs > 1 Then
                        Return CType(Parm, CoreCharacter).Values
                    Else
                        Return CType(Parm, CoreCharacter).Value
                    End If
                Case "CORE.WINDOWS.UI.CORE.WINDOWS.CoreVarChar"
                    Return CType(Parm, CoreVarChar).Value
                Case "CORE.WINDOWS.UI.CORE.WINDOWS.CoreDecimal"
                    Return CType(Parm, CoreDecimal).Value
                Case "CORE.WINDOWS.UI.CORE.WINDOWS.CoreInteger"
                    Return CType(Parm, CoreInteger).Value
                Case "CORE.WINDOWS.UI.CORE.WINDOWS.CoreDate"
                    Return CType(Parm, CoreDate).Value
                Case "Core.Framework.Core.Framework.DCharacter"
                    Return CType(Parm, DCharacter).Value
                Case "Core.Framework.Core.Framework.DVarChar"
                    Return CType(Parm, DVarChar).Value
                Case "Core.Framework.Core.Framework.DDecimal"
                    Return CType(Parm, DDecimal).Value
                Case "Core.Framework.Core.Framework.DInteger"
                    Return CType(Parm, DInteger).Value
                Case "Core.Framework.Core.Framework.DDate"
                    Return CType(Parm, DDate).Value
                Case "System.String"
                    Return CType(Parm, String)
            End Select
            Return Nothing
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     This method handles reading the items received from a calling screen.
        ''' </summary>
        ''' <param name="ReceivedObjects">List of Objects received from the calling screen</param>
        ''' <example>
        '''     Receiving(fleEMPLOYEE, TEMP_NAME)
        ''' </example>
        ''' <remarks>
        '''     Receiving should only be used from overrided "RetrieveParamsReceived".
        ''' </remarks>
        ''' <history>
        '''     [mayur]	4/4/2005	Created
        '''     [Mark]  19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Sub Receiving(ByVal ParamArray ReceivedObjects() As Object)
            Dim intParamIndex As Integer
            If IsNothing(Session(UniqueSessionID + FormName + "_" + Level.ToString + "_ScreenSequence")) Then
                Session.Remove(UniqueSessionID + FormName + "_" + Level.ToString + "_ScreenSequence")
                Session.Add(UniqueSessionID + FormName + "_" + Level.ToString + "_ScreenSequence", "1")
            ElseIf Session(UniqueSessionID + FormName + "_" + Level.ToString + "_ScreenSequence").ToString.Length = 0 _
                Then
                Session.Remove(UniqueSessionID + FormName + "_" + Level.ToString + "_ScreenSequence")
                Session.Add(UniqueSessionID + FormName + "_" + Level.ToString + "_ScreenSequence", "1")
            End If

            Dim strKey As String = FormName + "_" + Level.ToString + "_" + ScreenSequence.ToString() + "_PARM"
            For intParamIndex = 0 To ReceivedObjects.Length - 1
                SetParmValue(ReceivedObjects(intParamIndex),
                             Session(UniqueSessionID + strKey + (intParamIndex + 1).ToString), True)
            Next
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     This method handles updating the values that are received by this screen.
        ''' </summary>
        ''' <param name="ReceivedObjects">List of Objects received from the calling screen</param>
        ''' <example>
        '''     SaveReceivingParams(fleEMPLOYEE, TEMP_NAME)
        ''' </example>
        ''' <remarks>
        '''     SaveReceivingParams should only be used from overrided "SaveParamsReceived".
        ''' </remarks>
        ''' <history>
        '''     [mayur]	4/4/2005	Created
        '''     [Mark]  19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Sub SaveReceivingParams(ByVal ParamArray ReceivedObjects() As Object)
            Dim intParamIndex As Integer
            Dim strKey As String = FormName + "_" + Level.ToString + "_" + ScreenSequence.ToString() + "_PARM"
            For intParamIndex = 0 To ReceivedObjects.Length - 1
                Session(UniqueSessionID + strKey + (intParamIndex + 1).ToString) =
                    GetParmValue(ReceivedObjects(intParamIndex))
            Next
        End Sub

        ''' --- SetParmValue -------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Sets the value of an object.
        ''' </summary>
        ''' <param name="Parm">An Object which to assign a value to.</param>
        ''' <param name="ReturnValue"></param>
        ''' <remarks>
        '''     <note>This method should only be called from RetrieveParamsReceived.</note>
        ''' </remarks>
        ''' <example>SetParmValue(Parm1, Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM1"))</example>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Sub SetParmValue(ByRef Parm As Object, ReturnValue As Object)
            'Note: This method should only be called from RetrieveParamsReceived
            SetParmValue(Parm, ReturnValue, True)
        End Sub

        ''' --- SetParmValue -------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Sets the value of an object.
        ''' </summary>
        ''' <param name="Parm">An Object which to assign a value to.</param>
        ''' <param name="ReturnValue"></param>
        ''' <param name="CalledFromRetrieveParamsReceived"></param>
        ''' <remarks>
        '''     <note>This method should only be called from RetrieveParamsReceived.</note>
        ''' </remarks>
        ''' <example>SetParmValue(Parm1, Me.CalledPageSession(RunScreenName, Me.Level + 1, "PARM1"), True)</example>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Sub SetParmValue(ByRef Parm As Object, ReturnValue As Object,
                                   CalledFromRetrieveParamsReceived As Boolean)

            Select Case Parm.GetType.ToString
                Case "CORE.WINDOWS.UI.CORE.WINDOWS.OracleFileObject", "CORE.WINDOWS.UI.CORE.WINDOWS.SqlFileObject",
                    "CORE.WINDOWS.UI.CORE.WINDOWS.IfxFileObject"
                    With CType(Parm, IFileObject)
                        Dim cnnPreviousConnection As IDbConnection
                        Dim trnPreviousTransaction As IDbTransaction
                        cnnPreviousConnection = .Connection
                        trnPreviousTransaction = .Transaction
                        .SetInternalValues(ReturnValue)
                        .Connection = cnnPreviousConnection
                        .Transaction = trnPreviousTransaction
                    End With
                Case "CORE.WINDOWS.UI.CORE.WINDOWS.CoreCharacter"
                    With CType(Parm, CoreCharacter)
                        If CalledFromRetrieveParamsReceived Then
                            .HasReceivedValue = True
                            .InitialValue = CStr(ReturnValue)
                        End If
                        .Value = CStr(ReturnValue)
                    End With
                Case "CORE.WINDOWS.CoreVarChar"
                    With CType(Parm, CoreVarChar)
                        If CalledFromRetrieveParamsReceived Then
                            .HasReceivedValue = True
                            .InitialValue = CStr(ReturnValue)
                        End If
                        .Value = CStr(ReturnValue)
                    End With
                Case "CORE.WINDOWS.UI.CORE.WINDOWS.CoreDecimal"
                    With CType(Parm, CoreDecimal)
                        If CalledFromRetrieveParamsReceived Then
                            .HasReceivedValue = True
                            .InitialValue = CDbl(ReturnValue)
                        End If
                        .Value = CDbl(ReturnValue)
                    End With
                Case "CORE.WINDOWS.UI.CORE.WINDOWS.CoreInteger"
                    With CType(Parm, CoreInteger)
                        If CalledFromRetrieveParamsReceived Then
                            .HasReceivedValue = True
                            .InitialValue = CDbl(ReturnValue)
                        End If
                        .Value = CDbl(ReturnValue)
                    End With
                Case "CORE.WINDOWS.UI.CORE.WINDOWS.CoreDate"
                    With CType(Parm, CoreDate)
                        If CalledFromRetrieveParamsReceived Then
                            .HasReceivedValue = True
                            .InitialValue = CDbl(ReturnValue)
                        End If
                        .Value = CDbl(ReturnValue)
                    End With
            End Select
        End Sub

        ''' --- SetScreenWasRunFlag ------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Sets value indicating that the screen in a particular run screen sequence was run.
        ''' </summary>
        ''' <param name="ScreenSequence"></param>
        ''' <remarks>
        '''     This procedure sets the "Y" flag indicating that the screen at a particular run screen sequence was run.
        ''' </remarks>
        ''' <example>SetScreenWasRunFlag(m_intRunScreenSequence)</example>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Sub SetScreenWasRunFlag(ScreenSequence As Integer)

            Session(Name + "_" + Level.ToString + "_RUN_FLAG") =
                m_strRunFlag.Substring(0, m_intRunScreenSequence - 1) + "Y"
        End Sub

        ''' --- AddMessage ---------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Adds a message to the messages collection.
        ''' </summary>
        ''' <param name="Message">A structure containing the message information.</param>
        ''' <remarks>
        '''     The message collection contains the list of messages to display in the message bar on the screen.
        ''' </remarks>
        ''' <example>AddMessage(Message)</example>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Friend Sub AddMessage(Message As Common.stcMessage)
            m_colMessages.Add(Message)
        End Sub

        ''' --- AddMessage ---------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Adds messages to the current collection.
        ''' </summary>
        ''' <param name="Messages">A collection of Messages.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Friend Sub AddMessage(Messages As Collection)

            Dim Message As stcMessage

            ' Loop through the messages in the collection and
            ' add it to the current collection.
            For Each Message In Messages
                AddMessage(Message)
            Next
        End Sub

        ''' --- AddMessage ---------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Adds a message to the current Message Collection.
        ''' </summary>
        ''' <param name="Message">A string containing a specific message.</param>
        ''' <param name="Type">A MessageType describing the type of message.</param>
        ''' <param name="Parameters">An array of message parameters.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Friend Sub AddMessage(Message As String, Type As MessageTypes, ByVal ParamArray Parameters() As Object)

            Dim oMessage As stcMessage

            Try
                oMessage = ReturnMessage(Message, Type, Parameters)
                AddMessage(oMessage)

                oMessage.Type = MessageTypes.Warning
                GlobalSession(UniqueSessionID + "PassedMessagesError") = True

                If ScreenType <> ScreenTypes.QTP Then
                    If Not GlobalSession(UniqueSessionID + "PassedMessages") Is Nothing Then
                        oMessage.Text = CType(GlobalSession(UniqueSessionID + "PassedMessages"), stcMessage).Text &
                                        vbNewLine & oMessage.Text
                    End If
                End If

                GlobalSession(UniqueSessionID + "PassedMessages") = oMessage

                If Type = MessageTypes.Error OrElse Type = MessageTypes.Severe Then

                    ' For SEVERE messages, run the BACKOUT procedure.
                    If Type = MessageTypes.Severe Then
                        Try

                            RaiseSavePageState()

                            ' Set the mode to NoMode in order to clear the screen.
                            Mode = PageModeTypes.NoMode

                            RemoveFlags()
                        Catch ex As Exception
                            ' Do Nothing
                        End Try
                    End If

                    QDesign.ThrowCustomApplicationException(cAddMessageError)
                End If

            Catch ex As CustomApplicationException

                ex.MessageText = oMessage.Text
                Throw ex

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try
        End Sub

        ''' --- ErrorMessage -------------------------------------------------------
        ''' <summary>
        '''     Adds an Error message to the message collection.
        ''' </summary>
        ''' <param name="Message">A string containing a specific Error Message.</param>
        ''' <param name="Parameters">An array of message parameters.</param>
        ''' <remarks>
        '''     The ErrorMessage method stops execution and displays an error on the screen.
        '''     <note>
        '''         This method will stop code execution and will reprompt at the last executed Accept method if
        '''         applicable.  A message will then be displayed in the messagebar area.
        '''         NOTE: The ErrorMessage method will cause the screen to close when called from the Intialize method.
        '''     </note>
        ''' </remarks>
        ''' <example>
        '''     ErrorMessage("The value you entered is not a valid status type.")<br />
        '''     ErrorMessage("The value at row " + Occurrence + " is incorrect.")<br /><br />
        '''     The following syntax is used when substituting values in error messages that are in the globalization dll:<br />
        '''     Globalization value is "Employee {0} has exceeded his allowable expense limit of {1}"<br />
        '''     ErrorMessage("MSG0001", fleEMPLOYEE.GetStringValue("EMPLOYEE_NAME"), T_TEMP.Value)
        ''' </example>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function ErrorMessage(Message As String, ByVal ParamArray Parameters() As Object)
            AddMessage(Message, MessageTypes.Error, Parameters)
        End Function

        ''' --- Information --------------------------------------------------------
        ''' <summary>
        '''     Adds an Information message to the message collection.
        ''' </summary>
        ''' <param name="Message">A string containing a specific Error Message.</param>
        ''' <param name="Parameters">An array of message parameters.</param>
        ''' <remarks>
        '''     The Information method displays a information message to the user.
        ''' </remarks>
        ''' <example>
        '''     Information("A record will be added to the Employee table.")<br />
        '''     Information("The value at row " + Occurrence + " will be used.")<br /><br />
        '''     The following syntax is used when substituting values in messages that are in the globalization dll:<br />
        '''     Globalization value is "Employee {0} has exceeded his allowable expense limit of {1}"<br />
        '''     Information("MSG0001", fleEMPLOYEE.GetStringValue("EMPLOYEE_NAME"), T_TEMP.Value)
        ''' </example>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function Information(Message As String, ByVal ParamArray Parameters() As Object)
            If Message.Trim.Length > 0 Then
                AddMessage(Message, MessageTypes.Information, Parameters)
            End If
            Return Nothing
        End Function

        ''' --- ReturnMessage ---------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Returns the translated message.
        ''' </summary>
        ''' <param name="Message">A string containing a specific message.</param>
        ''' <param name="Type">A MessageType describing the type of message.</param>
        ''' <param name="Parameters">An array of message parameters.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function ReturnMessage(Message As String, Type As MessageTypes, ByVal ParamArray Parameters() As Object) _
            As stcMessage

            Dim oMessage As stcMessage
            Dim strMessageNumber As String
            Dim strNumber As String = String.Empty
            Dim strMessage As String = String.Empty

            Try

                strMessage = Message

                '' Retrieve the message number.
                'If Message.IndexOf("MSG") > -1 Then
                '    strNumber = strMessageNumber.Substring(3)
                'Else
                '    strNumber = strMessageNumber
                'End If

                '' Get the message from the resource file.
                'If strMessageNumber.Trim.Length > 0 Then
                '    strMessage = Me.GetString(strMessageNumber,
                '                              Global.Core.Globalization.Core.Globalization.ResourceTypes.Message)
                '    If strMessage Is Nothing Then strMessage = String.Empty
                'Else
                '    'To handle an empty error message
                '    strMessage = strMessageNumber
                'End If

                ' Replace the substitution characters with the values.
                If Not IsNothing(Parameters) Then
                    If strMessage.Length > 0 Then
                        Try
                            strMessage = String.Format(strMessage, Parameters)
                        Catch ex As FormatException
                            strMessage = "Wrong number of substitution parameters."
                        Catch ex As Exception
                            strMessage = ex.Message
                        End Try
                    Else
                        strMessage = String.Empty
                    End If
                End If

                ' If the message doesn't exist in the globalization,
                ' the user must have hardcoded an overriden value.
                If strMessage = "????" Or strMessage.Trim.Length = 0 Then
                    'Display an unknown error message or an empty error message
                    strMessage = strNumber
                    strNumber = String.Empty
                End If

                'Add Message whether it is
                oMessage.Text = strMessage
                oMessage.Number = strNumber
                oMessage.Type = Type

                Return oMessage

            Catch ex As CustomApplicationException

                Throw ex

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try
        End Function

        ''' --- Severe -------------------------------------------------------------
        ''' <summary>
        '''     Adds an Severe message to the message collection and aborts processing.
        ''' </summary>
        ''' <param name="Message">A string containing a specific Sever message.</param>
        ''' <param name="Parameters">An array of message parameters.</param>
        ''' <remarks>
        '''     The Severe method stops execution, re-initializes the buffers, calls the Backout method and positions the cursor in
        '''     the field associated with the error message.
        ''' </remarks>
        ''' <example>
        '''     Severe("The value you entered is not a valid status type.")<br />
        '''     Severe("The value at row " + Occurrence + " is incorrect.")<br /><br />
        '''     The following syntax is used when substituting values in error messages that are in the globalization dll:<br />
        '''     Globalization value is "Employee {0} has exceeded his allowable expense limit of {1}"<br />
        '''     Sever("MSG0001", fleEMPLOYEE.GetStringValue("EMPLOYEE_NAME"), T_TEMP.Value)
        ''' </example>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function Severe(Message As String, ByVal ParamArray Parameters() As Object)
            AddMessage(Message, MessageTypes.Severe, Parameters)
            Return Nothing
        End Function

        ''' --- Warning ------------------------------------------------------------
        ''' <summary>
        '''     Adds a Warning message to the message collection.
        ''' </summary>
        ''' <param name="Message">A string containing a specific Error Message.</param>
        ''' <param name="Parameters">An array of message parameters.</param>
        ''' <remarks>
        '''     The Warning method displays a warning message to the user.
        ''' </remarks>
        ''' <example>
        '''     Information("A record will be added to the Employee table.")<br />
        '''     Information("The value at row " + Occurrence + " will be used.")<br /><br />
        '''     The following syntax is used when substituting values in messages that are in the globalization dll:<br />
        '''     Globalization value is "Employee {0} has exceeded his allowable expense limit of {1}"<br />
        '''     Information("MSG0001", fleEMPLOYEE.GetStringValue("EMPLOYEE_NAME"), T_TEMP.Value)
        ''' </example>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function Warning(Message As String, ByVal ParamArray Parameters() As Object)
            AddMessage(Message, MessageTypes.Warning, Parameters)
            Return Nothing
        End Function

        ''' --- GetString ----------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Retrieves the string value of the key passed in.
        ''' </summary>
        ''' <param name="key">A String containing the name of the key to search for.</param>
        ''' <param name="ResourceType">A Resource Type which contains the desired key and corresponding value.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetString(key As String,
                                  ResourceType As Global.Core.Globalization.Core.Globalization.ResourceTypes) As String

            Return GlobalizationManager.GetString(key, ResourceType)
        End Function

        ''' --- SetGlobalizationManager --------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of SetGlobalizationManager.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Sub SetGlobalizationManager()
            Dim strLanguage As String

            If Session(UniqueSessionID + "Language") Is Nothing Then
                'If m_objRequest.UserLanguages Is Nothing Then
                strLanguage = "en-ca"
                'Else
                '    strLanguage = m_objRequest.UserLanguages(0)
                'End If
                GlobalizationManager = New GlobalizationManager(strLanguage)
                Language = strLanguage
            Else
                GlobalizationManager = New GlobalizationManager(Session(UniqueSessionID + "Language").ToString)
            End If
        End Sub

        ''' --- DeleteSystemVal ----------------------------------------------------
        ''' <summary>
        '''     Allows the deletion of values defined at the operating system level.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the systemval to delete.</param>
        ''' <param name="Type">A String indicating the type of systemval.</param>
        ''' <param name="Table"></param>
        ''' <param name="SessionId"></param>
        ''' <remarks>
        '''     <example>
        '''         DeleteSystemVal("PARAMS")<br />
        '''         DeleteSystemVal("QUIZ_PARAMS", "0001", "LNM$JOB")
        '''     </example>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Friend Function DeleteSystemVal(Name As String,
                                                  Optional ByVal Type As String = "0001") As Boolean

            Select Case Type
                Case "0001"
                    If ScreenType = ScreenTypes.QTP OrElse ScreenType = ScreenTypes.QUIZ Then
                        SessionInformation.Remove(Name + Type, QTPSessionID)
                    Else
                        SessionInformation.Remove(Name + Type, Session("SessionID"))
                    End If
                Case "0002", "0003"
                    SessionInformation.RemoveApplication(Name + Type)
            End Select
        End Function

        Private Const cApplicationScope As String = "0003"

        ''' <summary>
        '''     <exclude />
        '''     Determines whether the lock time was set (currently informix only).
        ''' </summary>
        ''' <param name="Transaction">A String indicating the named transaction.</param>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Friend Property LockTimeSet(Transamenction As String) As Boolean
            Get
                If m_htLockTimes.Contains(Transaction) Then
                    Return m_htLockTimes(Transaction)
                Else
                    Return False
                End If
            End Get
            Set(value As Boolean)
                m_htLockTimes.Add(Transaction, value)
            End Set
        End Property

        ''' --- GetSystemVal -------------------------------------------------------
        ''' <summary>
        '''     Retrieves values defined at the operating system level.
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <param name="TypeCode"></param>
        ''' <remarks>
        '''     <example>
        '''         GetSystemVal("PARAMS") <br />
        '''         GetSystemVal("QUIZ_PARAMS", "0002", "LNM$JOB") Returns "ALL"
        '''     </example>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Friend Function GetSystemVal(Name As String) As String
            Return GetSystemVal(Name, "0001")
        End Function

        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Friend Function GetSystemVal(Name As String, TypeCode As String) As String

            Dim strValue As String = Nothing

            If TypeCode = "" Then
                If ScreenType = ScreenTypes.QTP OrElse ScreenType = ScreenTypes.QUIZ Then
#If TARGET_DB = "INFORMIX" Then
                    strValue = Session(Name + "0001")
                    If strValue = Nothing Then strValue = UI.SessionInformation.GetSession(Name + "0001", QTPSessionID)
#Else
                    strValue = SessionInformation.GetSession(Name + "0001", QTPSessionID)
#End If
                Else
                    strValue = SessionInformation.GetSession(Name + "0001", Session("SessionID"))
                End If

                If IsNothing(strValue) Then
                    strValue = SessionInformation.GetApplicationSession(Name + "0002")
                End If
                If IsNothing(strValue) Then
                    strValue = SessionInformation.GetApplicationSession(Name + "0003")
                End If
            Else
                Select Case TypeCode
                    Case "0001"
                        If ScreenType = ScreenTypes.QTP OrElse ScreenType = ScreenTypes.QUIZ Then
#If TARGET_DB = "INFORMIX" Then
                            strValue = Session(UniqueSessionID + Name + "0001")
                            If strValue = Nothing Then strValue = UI.SessionInformation.GetSession(Name + "0001",
QTPSessionID)
#Else
                            strValue = SessionInformation.GetSession(Name + "0001", QTPSessionID)
#End If
                        Else
                            strValue = SessionInformation.GetSession(Name + "0001", Session("SessionID"))

                            If IsNothing(strValue) Then
                                strValue = SessionInformation.GetApplicationSession(Name + "0002")
                            End If
                            If IsNothing(strValue) Then
                                strValue = SessionInformation.GetApplicationSession(Name + "0003")
                            End If
                        End If
                    Case "0002", "0003"
                        strValue = SessionInformation.GetApplicationSession(Name + TypeCode)
                End Select

            End If

            If IsNothing(strValue) Then strValue = String.Empty
            Return strValue
        End Function

        ''' --- SetSystemVal -------------------------------------------------------
        ''' <summary>
        '''     Assigns values at the operating system level.
        ''' </summary>
        ''' <param name="Name">A String containing the name of the systemval.</param>
        ''' <param name="Value">A String containing the value to be assigned to the systemval.</param>
        ''' <param name="Type">A String indicating the type of systemval.</param>
        ''' <remarks>
        '''     <example>
        '''         SetSystemVal("PARAMS", T_TEMP.Value) <br />
        '''         SetSystemValue("QUIZ_PARAMS", "ALL", "0001", "LNM$JOB") returns TRUE or FALSE.
        '''     </example>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Function SetSystemVal(Name As String,
                                        Value As String) As Boolean
            Return SetSystemVal(Name, Value, "0001")
        End Function

        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Function SetSystemVal(Name As String,
                                        Value As String,
                                        Type As String) As Boolean

            If Type = "0001" Then
                If ScreenType = ScreenTypes.QTP OrElse ScreenType = ScreenTypes.QUIZ Then
#If TARGET_DB = "INFORMIX" Then
                    Session(UniqueSessionID + Name + Type) = Value
#Else
                    SessionInformation.SetSession(Name + Type, Value, QTPSessionID)
#End If
                Else
                    SessionInformation.SetSession(Name + Type, Value, Session("SessionID"))
                End If
            Else
                SessionInformation.SetApplicationSession(Name + Type, Value)
            End If

            Return True
        End Function

        ''' --- ReturnAndClose -----------------------------------------------------
        ''' <summary>
        '''     Replaces the RETURN verb.
        ''' </summary>
        ''' <remarks>
        '''     Raises a RETURN error and sets the correct flags in order to
        '''     close the current screen.
        ''' </remarks>
        ''' <example>ReturnAndClose()</example>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Overrides Sub ReturnAndClose()

            SaveParamsReceived()
            MyBase.ReturnAndClose()
        End Sub

#Region " AlteredRecord, DeletedRecord and NewRecord methods "

        'AlteredRecord, DeletedRecord and NewRecord uses
        'm_bfoFileForRecordStatus to return the primary file unless it is changed with the
        'SET ASSUMED (Which we don't support at present) statement. If there is no assumed
        'record-structure, the status is the same as that of the current record-structure,
        'that gets set in GetData

        ''' --- DeletedRecord ------------------------------------------------------
        ''' <summary>
        '''     Returns a boolean indicating whether the current record in the File class (used in last GetData) has been marked
        '''     for deletion.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function DeletedRecord() As Boolean
            If FileForRecordStatus Is Nothing Then
                Return False
            Else
                Return FileForRecordStatus.DeletedRecord
            End If
        End Function

        ''' --- AlteredRecord ------------------------------------------------------
        ''' <summary>
        '''     Returns a boolean indicating whether the current record in the File class (used in last GetData) has been marked as
        '''     altered.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function AlteredRecord() As Boolean
            If FileForRecordStatus Is Nothing Then
                Return False
            Else
                Return FileForRecordStatus.AlteredRecord
            End If
        End Function

        ''' --- NewRecord ----------------------------------------------------------
        ''' <summary>
        '''     Returns a boolean indicating whether the current record in the File class (used in last GetData) has been marked as
        '''     new.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function NewRecord() As Boolean
            If FileForRecordStatus Is Nothing Then
                Return False
            Else
                Return FileForRecordStatus.NewRecord
            End If
        End Function

#End Region

        '-------------------------------------------------------------------
        ' Name: FileForRecordStatus
        ' Function: AlteredRecord, DeletedRecord and NewRecord uses
        ' m_bfoFileForRecordStatus to return the primary file unless it is changed with the
        ' SET ASSUMED (Which we don't support at present) statement. If there is no assumed
        ' record-structure, the status is the same as that of the current record-structure,
        ' that gets set in GetData
        ' Example: FileForRecordStatus
        '-------------------------------------------------------------------
        ''' --- FileForRecordStatus ------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of FileForRecordStatus.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Friend Property FileForRecordStatus As BaseFileObject
            Get
                If Me.PrimaryFileObject Is Nothing Then
                    Return m_bfoFileForRecordStatus
                Else
                    Return Me.PrimaryFileObject
                End If
            End Get

            Set(Value As BaseFileObject)
                If Not Me.m_bfoFileForRecordStatus Is Nothing Then
                    m_bfoFileForRecordStatus.HasLastGetData = False
                End If
                m_bfoFileForRecordStatus = Value
            End Set
        End Property

        ''' --- PrimaryFileObject --------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of PrimaryFileObject.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public ReadOnly Property PrimaryFileObject As BaseFileObject
            Get
                Return m_bfoPrimaryFile
            End Get
        End Property

        ''' --- Finalize -----------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of Finalize.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Overrides Sub Finalize()
            'Remove the references to file objects
            m_bfoPrimaryFile = Nothing
            m_bfoFileForRecordStatus = Nothing

            MyBase.Finalize()
        End Sub

        ''' --- SetAccessOk --------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of SetAccessOk.
        ''' </summary>
        ''' <param name="AccessOk"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Overrides Sub SetAccessOk(AccessOk As Boolean)
            'The ACCESSOK condition relates to a session and not to a specific screen.
            Session(UniqueSessionID + "AccessOK") = AccessOk
        End Sub

        ''' --- ErrorMessage -------------------------------------------------------
        ''' <summary>
        '''     Adds an Error Message to the Message Collection.
        ''' </summary>
        ''' <param name="Message">A string containing a specific Error Message.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function ErrorMessage(Message As String)
            AddMessage(Message, MessageTypes.Error)
            Return Nothing
        End Function

        ''' --- Information --------------------------------------------------------
        ''' <summary>
        '''     Adds an Information Message to the Message Collection.
        ''' </summary>
        ''' <param name="Message">A string containing a specific Information Message.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function Information(Message As String)
            If Message.Trim.Length > 0 Then
                AddMessage(Message, MessageTypes.Information)
            End If
            Return Nothing
        End Function

        ''' --- Severe -------------------------------------------------------------
        ''' <summary>
        '''     Adds an Severe Message to the Message Collection.
        ''' </summary>
        ''' <param name="Message">A string containing a specific Severe Message.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function Severe(Message As String)
            AddMessage(Message, MessageTypes.Severe)
            Return Nothing
        End Function

        ''' --- Warning ------------------------------------------------------------
        ''' <summary>
        '''     Adds an Warning Message to the Message Collection.
        ''' </summary>
        ''' <param name="Message">A string containing a specific Warning Message.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function Warning(Message As String)
            AddMessage(Message, MessageTypes.Warning)
            Return Nothing
        End Function

        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function WriteMiniDictionaryFile(strFileName As String, dt As DataTable, hslenght As Hashtable,
                                         ByVal ParamArray strSubFiles() As Object) As Boolean

            Dim strFilePath As String = ""
            Dim strFileText As New StringBuilder("")
            Dim sw As StreamWriter

            'If arrKeepFile.Contains(strFileName) OrElse alSubTempText.Contains(strFileName) Then
            strFilePath = Directory.GetCurrentDirectory()
            'Else
            '    strFilePath = System.Configuration.ConfigurationManager.AppSettings("FlatFilePath") & "\" & Session(UniqueSessionID + "m_strUser") & "_" & Session(UniqueSessionID + "m_strSessionID")
            'End If

            If Not Directory.Exists(strFilePath) Then
                Directory.CreateDirectory(strFilePath)
            End If

            Dim strFileColumn As String = strFilePath

            If Not IsNothing(Session("PortableSubFiles")) AndAlso DirectCast(Session("PortableSubFiles"), ArrayList).Contains(strFileName) Then
                If strFileColumn.EndsWith("\") Then
                    strFileColumn = strFilePath & strFileName & ".psd"
                Else
                    strFileColumn = strFilePath & "\" & strFileName & ".psd"
                End If
            ElseIf Not IsNothing(Session("DatFiles")) AndAlso DirectCast(Session("DatFiles"), ArrayList).Contains(strFileName) Then
                If strFileColumn.EndsWith("\") Then
                    strFileColumn = System.Configuration.ConfigurationManager.AppSettings("FlatFileDictionary") & strFileName & ".dfd"
                Else
                    strFileColumn = System.Configuration.ConfigurationManager.AppSettings("FlatFileDictionary") & "\" & strFileName & ".dfd"
                End If
            ElseIf Not IsNothing(Session("TempFiles")) AndAlso DirectCast(Session("TempFiles"), ArrayList).Contains(strFileName) Then
                If strFileColumn.EndsWith("\") Then
                    strFileColumn = System.Configuration.ConfigurationManager.AppSettings("FlatFileDictionary") & strFileName & ".dfd"
                Else
                    strFileColumn = System.Configuration.ConfigurationManager.AppSettings("FlatFileDictionary") & "\" & strFileName & ".dfd"
                End If
            Else
                If strFileColumn.EndsWith("\") Then
                    strFileColumn = strFilePath & strFileName & ".sfd"
                Else
                    strFileColumn = strFilePath & "\" & strFileName & ".sfd"
                End If
            End If



            If Not File.Exists(strFileColumn) Then

                For i As Integer = 0 To dt.Columns.Count - 1
                    If dt.Columns(i).ColumnName <> "ROW_ID" AndAlso dt.Columns(i).ColumnName <> "CHECKSUM_VALUE" Then
                        strFileText.Append(dt.Columns(i).ColumnName)
                        strFileText.Append(",")
                        strFileText.Append(dt.Columns(i).DataType.ToString)
                        strFileText.Append(",")
                        If dt.Columns(i).DataType.ToString = "System.DateTime" Then
                            strFileText.Append("8")

                            ' GW2018. Added to treat System.Decical differently by adding 1 to the length to accomodate the +/- sign
                        ElseIf dt.Columns(i).DataType.ToString = "System.Decimal" Then
                            strFileText.Append(GetSubSize(hslenght.Item(dt.Columns(i).ColumnName.ToLower), dt.Columns(i).DataType.ToString) + 1)

                        ElseIf dt.Columns(i).DataType.ToString = "System.Integer" OrElse dt.Columns(i).DataType.ToString = "System.Int64" Then
                            strFileText.Append(GetSubSize(hslenght.Item(dt.Columns(i).ColumnName.ToLower), dt.Columns(i).DataType.ToString))

                        Else
                            strFileText.Append(hslenght.Item(dt.Columns(i).ColumnName.ToLower))
                        End If
                        strFileText.Append(vbNewLine)
                    End If
                Next

                'My.Computer.FileSystem.WriteAllText(strFileColumn, strFileText.ToString, False)
                sw = New StreamWriter(strFileColumn, False)
                sw.Write(strFileText.ToString)
                sw.Flush()
                sw.Close()
                sw.Dispose()
            End If

        End Function
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function lookup_MiniDictionary(dt As DataTable, position As Integer, ByRef datatype As String, ByRef datatype_size As Integer)

            Dim curr_position As Integer = 0

            For Each row As DataRow In dt.Rows
                curr_position = row("position")
                If (curr_position = position) Then
                    datatype = row("Datatype")
                    datatype_size = Convert.ToInt32(row("datatypesize"))
                    Exit For
                End If
            Next row

        End Function


        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function PutDataTextTable(strFileName As String, dt As DataTable, hslenght As Hashtable,
                                         ByVal ParamArray strSubFiles() As Object) As Boolean

            Dim strFilePath As String = ""
            Dim strFile As String = String.Empty
            Dim strFileText As New StringBuilder("")
            Dim sw As StreamWriter
            Dim blnFileExists As Boolean = False
            Dim strText As String = String.Empty
            Dim strTextName As String = String.Empty
            Dim intRowcount As Integer = 0
            Dim strName As String = String.Empty
            Dim blnWriteBlankFile As Boolean = True
            Dim sfdexists As Boolean = True
            Dim hsColumns As New Hashtable
            Dim arrStructure() As String
            strFileName = strFileName

            ' The Mini Dictionary will be used to hold the sfd/psd/dfd definitions
            Dim MiniDictionary As DataTable
            MiniDictionary = New DataTable()
            MiniDictionary.Columns.Add("Position", GetType(System.Int32))
            MiniDictionary.Columns.Add("ColumnName", GetType(System.String))
            MiniDictionary.Columns.Add("Datatype", GetType(System.String))
            MiniDictionary.Columns.Add("DatatypeSize", GetType(System.Int32))

            Dim sw2 As StreamWriter

            'If arrKeepFile.Contains(strFileName) OrElse alSubTempText.Contains(strFileName) Then
            strFilePath = Directory.GetCurrentDirectory()
            'Else
            '    strFilePath = System.Configuration.ConfigurationManager.AppSettings("FlatFilePath") & "\" & Session(UniqueSessionID + "m_strUser") & "_" & Session(UniqueSessionID + "m_strSessionID")
            'End If

            If Not Directory.Exists(strFilePath) Then
                Directory.CreateDirectory(strFilePath)
            End If

            Dim strFileColumn As String = strFilePath

            If Not IsNothing(Session("PortableSubFiles")) AndAlso DirectCast(Session("PortableSubFiles"), ArrayList).Contains(strFileName) Then
                If strFileColumn.EndsWith("\") Then
                    strFileColumn = strFilePath & strFileName & ".psd"
                Else
                    strFileColumn = strFilePath & "\" & strFileName & ".psd"
                End If
            ElseIf Not IsNothing(Session("DatFiles")) AndAlso DirectCast(Session("DatFiles"), ArrayList).Contains(strFileName) Then
                If strFileColumn.EndsWith("\") Then
                    strFileColumn = System.Configuration.ConfigurationManager.AppSettings("FlatFileDictionary") & strFileName & ".dfd"
                Else
                    strFileColumn = System.Configuration.ConfigurationManager.AppSettings("FlatFileDictionary") & "\" & strFileName & ".dfd"
                End If
            ElseIf Not IsNothing(Session("TempFiles")) AndAlso DirectCast(Session("TempFiles"), ArrayList).Contains(strFileName) Then
                If strFileColumn.EndsWith("\") Then
                    strFileColumn = System.Configuration.ConfigurationManager.AppSettings("FlatFileDictionary") & strFileName & ".dfd"
                Else
                    strFileColumn = System.Configuration.ConfigurationManager.AppSettings("FlatFileDictionary") & "\" & strFileName & ".dfd"
                End If
            Else
                If strFileColumn.EndsWith("\") Then
                    strFileColumn = strFilePath & strFileName & ".sfd"
                Else
                    strFileColumn = strFilePath & "\" & strFileName & ".sfd"
                End If
            End If


            'GW2018. This code no longer needed as it was moved to WriteMiniDictionary
            '
            'If Not File.Exists(strFileColumn) Then
            '    For i As Integer = 0 To dt.Columns.Count - 1
            '        If dt.Columns(i).ColumnName <> "ROW_ID" AndAlso dt.Columns(i).ColumnName <> "CHECKSUM_VALUE" Then
            '            strFileText.Append(dt.Columns(i).ColumnName)
            '            strFileText.Append(",")
            '            strFileText.Append(dt.Columns(i).DataType.ToString)
            '            strFileText.Append(",")
            '            If dt.Columns(i).DataType.ToString = "System.DateTime" Then
            '                strFileText.Append("8")
            '            ElseIf dt.Columns(i).DataType.ToString = "System.Decimal" OrElse dt.Columns(i).DataType.ToString = "System.Integer" OrElse dt.Columns(i).DataType.ToString = "System.Int64" Then
            '                strFileText.Append(GetSubSize(hslenght.Item(dt.Columns(i).ColumnName.ToLower), dt.Columns(i).DataType.ToString))
            '            Else
            '                strFileText.Append(hslenght.Item(dt.Columns(i).ColumnName.ToLower))
            '            End If
            '            strFileText.Append(vbNewLine)
            '        End If
            '    Next

            '    'My.Computer.FileSystem.WriteAllText(strFileColumn, strFileText.ToString, False)
            '    sw = New StreamWriter(strFileColumn, False)
            '    sw.Write(strFileText.ToString)
            '    sw.Flush()
            '    sw.Close()
            '    sw.Dispose()
            'ElseIf (strFileColumn.EndsWith(".dfd")) Then

            If (strFileColumn.EndsWith(".dfd")) Then
                Dim sr = New StreamReader(strFileColumn)
                Dim strtmp As String
                strtmp = sr.ReadLine
                hsColumns = New Hashtable
                Do While Not IsNothing(strtmp)
                    If (strtmp.Trim.Length > 0) Then

                        arrStructure = strtmp.Split(",")
                        hsColumns.Add(arrStructure(0), arrStructure(1))
                    End If
                    strtmp = sr.ReadLine
                Loop

            ElseIf File.Exists(strFileColumn) Then

                Dim sr As StreamReader = New StreamReader(strFileColumn)
                Dim text As String = sr.ReadLine
                Dim column_name As String
                Dim position As Integer = 0

                Dim datatype As String
                Dim datatype_size As Integer
                Dim found As Boolean

                While (Not IsNothing(text))

                    column_name = text.Split(",")(0)
                    datatype = text.Split(",")(1)
                    datatype_size = text.Split(",")(2).ToLower

                    MiniDictionary.Rows.Add(position, column_name, datatype, datatype_size)

                    hslenght.Item(text.Split(",")(0).ToLower) = text.Split(",")(2)

                    position = position + 1

                    text = sr.ReadLine
                End While

                If Not hsSubConverted.Contains(strFileName) Then
                    hsSubConverted.Add(strFileName, strFileName)
                End If

            End If

            strFileText.Remove(0, strFileText.Length)

            Try
                If IsNothing(Me.Session(UniqueSessionID + "strSubFileName")) Then
                    strTextName = strFileName
                Else
                    strTextName = Me.Session(UniqueSessionID + "strSubFileName").ToString
                    If strTextName.IndexOf(".") >= 0 Then
                        strName = strTextName.Substring(0, strTextName.IndexOf("."))

                        strTextName = strTextName.Substring(strTextName.IndexOf(".") + 1)
                        strTextName = strTextName.Replace(".", "\") & "\" & strName
                    End If
                End If

                If strTextName.StartsWith("JS") Then
                    strTextName = strTextName.Replace("JS", "SD")
                End If



                If Not IsNothing(Session("PortableSubFiles")) AndAlso DirectCast(Session("PortableSubFiles"), ArrayList).Contains(strFileName) Then
                    If strFilePath.EndsWith("\") Then
                        strFile = strFilePath & strTextName + ".ps"
                    Else
                        strFile = strFilePath & "\" & strTextName + ".ps"
                    End If
                ElseIf Not IsNothing(Session("DatFiles")) AndAlso DirectCast(Session("DatFiles"), ArrayList).Contains(strFileName) Then
                    If strFilePath.EndsWith("\") Then
                        strFile = strFilePath & strTextName + ".dat"
                    Else
                        strFile = strFilePath & "\" & strTextName + ".dat"
                    End If
                ElseIf Not IsNothing(Session("TempFiles")) AndAlso DirectCast(Session("TempFiles"), ArrayList).Contains(strFileName) Then
                    If strFilePath.EndsWith("\") Then
                        strFile = strFilePath & strTextName + ".dat"
                    Else
                        strFile = strFilePath & "\" & strTextName + ".dat"
                    End If
                Else
                    If strFilePath.EndsWith("\") Then
                        strFile = strFilePath & strTextName + ".sf"
                    Else
                        strFile = strFilePath & "\" & strTextName + ".sf"
                    End If
                End If

                Dim aFileInfo As New FileInfo(strFile)

                If File.Exists(strFile) Then
                    blnFileExists = True

                    If aFileInfo.Attributes And FileAttributes.ReadOnly Then
                        If m_blnDidLock = True Then
                            aFileInfo.Attributes -= FileAttributes.ReadOnly
                        Else
                            Err.Raise("This File is Locked!")
                            Return False
                        End If
                    End If

                    aFileInfo = Nothing
                End If

                Dim sr As StreamReader
                Dim strread As String = String.Empty
                Dim blnAppend As Boolean = True
                Dim blnAddCarriage As Boolean = True

                If blnFileExists Then
                    sr = New StreamReader(strFile)
                    strread = sr.ReadLine
                    blnAppend = Not IsNothing(strread) AndAlso strread.Length > 0
                    blnAddCarriage = blnAppend
                Else
                    blnAppend = False
                    blnAddCarriage = False
                End If



                If Not IsNothing(sr) Then
                    sr.Close()
                    sr.Dispose()
                    sr = Nothing
                End If

                Dim tmpVal As String = ""
                Dim tmpPlusMinus As String = ""

                Dim datatype As String = ""
                Dim datatype_size As Integer = 0


                'If Not strFileColumn.EndsWith(".psd") Then

                '    For i As Integer = 0 To dt.Rows.Count - 1
                '        'If strFileText.ToString.Length > 0 OrElse (blnFileExists AndAlso blnAddCarriage) Then
                '        '    Try
                '        '        strFileText.Append(LineTerminator)
                '        '    Catch ex As OutOfMemoryException
                '        '        GC.Collect()
                '        '        strFileText.Append(LineTerminator)
                '        '    End Try
                '        'End If

                '        'blnAddCarriage = True

                '        For j As Integer = 0 To dt.Columns.Count - 1
                '            If _
                '                dt.Columns(j).ColumnName.ToUpper <> "ROW_ID" AndAlso
                '                dt.Columns(j).ColumnName.ToUpper <> "CHECKSUM_VALUE" Then
                '                If dt.Columns(j).DataType.ToString = "System.Decimal" OrElse dt.Columns(j).DataType.ToString = "System.Integer" OrElse dt.Columns(j).DataType.ToString = "System.Int64" Then

                '                    If (strFileColumn.EndsWith(".dfd")) Then
                '                        tmpVal = dt.Rows(i)(j).ToString

                '                        Dim tmpsize As Integer


                '                        tmpsize = hslenght.Item(dt.Columns(j).ColumnName.ToLower)


                '                        If (hsColumns(dt.Columns(j).ColumnName.ToUpper) = "System.Zoned.Signed") Then
                '                            Dim ispos As Boolean = tmpVal.IndexOf("-") = -1
                '                            tmpVal = tmpVal.Replace("-", "")
                '                            tmpVal = tmpVal.Substring(0, tmpVal.Length - 1) + GetOverpunchDigit(tmpVal.Substring(tmpVal.Length - 1, 1), ispos)
                '                        End If



                '                        strFileText.Append(
                '                            tmpVal.PadLeft(tmpsize, "0").Substring(0, tmpsize))
                '                    Else
                '                        tmpVal = dt.Rows(i)(j).ToString

                '                        Dim tmpsize As Integer

                '                        If hsSubConverted.Contains(strFileName) Then
                '                            tmpsize = hslenght.Item(dt.Columns(j).ColumnName.ToLower)
                '                        Else
                '                            tmpsize = GetSubSize(hslenght.Item(dt.Columns(j).ColumnName.ToLower), dt.Columns(j).DataType.ToString)
                '                        End If


                '                        If tmpVal.Trim.StartsWith("-") Then
                '                            tmpVal = tmpVal.Replace("-", "")
                '                            tmpVal =
                '                                tmpVal.PadLeft(tmpsize - 1, "0").
                '                                    Substring(0, tmpsize - 1)
                '                            tmpVal = "-" & tmpVal
                '                        Else
                '                            tmpVal =
                '                                tmpVal.PadLeft(tmpsize - 1, "0").
                '                                    Substring(0, tmpsize - 1)
                '                            tmpVal = "+" & tmpVal
                '                        End If


                '                        strFileText.Append(
                '                            tmpVal.PadLeft(tmpsize, "0").Substring(0, tmpsize))
                '                    End If

                '                ElseIf dt.Columns(j).DataType.ToString = "System.DateTime" Then
                '                    If IsNull(dt.Rows(i)(j)) OrElse dt.Rows(i)(j) = #12:00:00 AM# Then
                '                        strFileText.Append("        ")
                '                    Else
                '                        Dim dateTimeInfo As DateTime = dt.Rows(i)(j)
                '                        strFileText.Append(
                '                            dateTimeInfo.Year.ToString & dateTimeInfo.Month.ToString.PadLeft(2, "0") &
                '                            dateTimeInfo.Day.ToString.PadLeft(2, "0"))
                '                    End If
                '                Else
                '                    strFileText.Append(
                '                        dt.Rows(i)(j).ToString.PadRight(hslenght.Item(dt.Columns(j).ColumnName.ToLower)).
                '                                          Substring(0, hslenght.Item(dt.Columns(j).ColumnName.ToLower)))
                '                End If
                '            End If
                '        Next

                '        intRowcount = intRowcount + 1

                '        If intRowcount = 499 Then
                '            intRowcount = 0

                '            If strFileText.ToString.Length > 0 Then
                '                'My.Computer.FileSystem.WriteAllText(strFile, strFileText.ToString, True)
                '                sw = New StreamWriter(strFile, blnAppend)
                '                blnAppend = True
                '                blnFileExists = True
                '                sw.Write(strFileText.ToString)
                '                sw.Flush()
                '                sw.Close()
                '                sw.Dispose()
                '                sw = Nothing

                '                GC.Collect()

                '                strFileText.Remove(0, strFileText.Length)
                '                blnWriteBlankFile = False
                '            End If
                '        End If
                '    Next

                '    If strFileText.ToString.Length > 0 OrElse blnWriteBlankFile Then
                '        'My.Computer.FileSystem.WriteAllText(strFile, strFileText.ToString, True)

                '        sw = New StreamWriter(strFile, blnAppend)
                '        sw.Write(strFileText.ToString)
                '        sw.Flush()
                '        sw.Close()
                '        sw.Dispose()
                '        sw = Nothing

                '        GC.Collect()

                '        strFileText.Remove(0, strFileText.Length)
                '    End If

                '    ''''''''''''''''''''''end sd

                'End If


                For i As Integer = 0 To dt.Rows.Count - 1
                    If strFileText.ToString.Length > 0 OrElse (blnFileExists AndAlso blnAddCarriage) Then
                        Try
                            strFileText.Append(LineTerminator)
                        Catch ex As OutOfMemoryException
                            GC.Collect()
                            strFileText.Append(LineTerminator)
                        End Try
                    End If

                    blnAddCarriage = True

                    For j As Integer = 0 To dt.Columns.Count - 1
                        If _
                            dt.Columns(j).ColumnName.ToUpper <> "ROW_ID" AndAlso
                            dt.Columns(j).ColumnName.ToUpper <> "CHECKSUM_VALUE" Then
                            If dt.Columns(j).DataType.ToString = "System.Decimal" OrElse dt.Columns(j).DataType.ToString = "System.Integer" OrElse dt.Columns(j).DataType.ToString = "System.Int64" Then

                                If (strFileColumn.EndsWith(".dfd")) Then
                                    tmpVal = dt.Rows(i)(j).ToString

                                    Dim tmpsize As Integer


                                    tmpsize = hslenght.Item(dt.Columns(j).ColumnName.ToLower)

                                    If (hsColumns(dt.Columns(j).ColumnName.ToUpper) = "System.Zoned.Signed") Then
                                        Dim ispos As Boolean = tmpVal.IndexOf("-") = -1
                                        tmpVal = tmpVal.Replace("-", "")
                                        tmpVal = tmpVal.Substring(0, tmpVal.Length - 1) + GetOverpunchDigit(tmpVal.Substring(tmpVal.Length - 1, 1), ispos)

                                    ElseIf tmpVal.Trim.StartsWith("-") Or tmpVal.Trim.StartsWith("+") Then
                                        tmpPlusMinus = tmpVal.Trim.Substring(0, 1)
                                        tmpVal = tmpVal.Replace("-", "").Replace("+", "")
                                        tmpVal = tmpVal.PadLeft(tmpsize - 1, "0")
                                        tmpVal = tmpPlusMinus & tmpVal
                                    End If


                                    strFileText.Append(
                                        tmpVal.PadLeft(tmpsize, "0").Substring(0, tmpsize))
                                Else
                                    tmpVal = dt.Rows(i)(j).ToString

                                    Dim tmpsize As Integer

                                    'If hsSubConverted.Contains(strFileName) Then
                                    '    tmpsize = hslenght.Item(dt.Columns(j).ColumnName.ToLower)
                                    'Else
                                    '    tmpsize = GetSubSize(hslenght.Item(dt.Columns(j).ColumnName.ToLower), dt.Columns(j).DataType.ToString)
                                    'End If


                                    'If tmpVal.Trim.StartsWith("-") Then
                                    '    tmpVal = tmpVal.Replace("-", "")
                                    '    tmpVal =
                                    '        tmpVal.PadLeft(tmpsize - 1, "0").
                                    '            Substring(0, tmpsize - 1)
                                    '    tmpVal = "-" & tmpVal
                                    'Else
                                    '    tmpVal =
                                    '        tmpVal.PadLeft(tmpsize - 1, "0").
                                    '            Substring(0, tmpsize - 1)
                                    '    tmpVal = "+" & tmpVal
                                    'End If


                                    'strFileText.Append(
                                    '    tmpVal.PadLeft(tmpsize, "0").Substring(0, tmpsize))

                                    'If blnOver5000Records Then
                                    'tmpsize = hslenght.Item(dt.Columns(j).ColumnName.ToLower)
                                    'Else

                                    ' GW2018. Mar 10. Lookup on the mini-dirctionary for the column data type and size 
                                    ' based on column position (j 0, 1, 2)....
                                    lookup_MiniDictionary(MiniDictionary, j, datatype, datatype_size)
                                    tmpsize = datatype_size
                                    'tmpsize = GetSubSize(hslenght.Item(dt.Columns(j).ColumnName.ToLower), dt.Columns(j).DataType.ToString)
                                    'End If

                                    If tmpVal.Trim.StartsWith("-") Or tmpVal.Trim.StartsWith("+") Then
                                        tmpPlusMinus = tmpVal.Trim.Substring(0, 1)
                                        tmpVal = tmpVal.Replace("-", "").Replace("+", "")
                                        tmpVal = tmpVal.PadLeft(tmpsize - 1, "0")
                                        tmpVal = tmpPlusMinus & tmpVal
                                    Else
                                        tmpVal = tmpVal.PadLeft(tmpsize - 1, "0")
                                        tmpVal = "+" & tmpVal
                                    End If

                                    Dim buf As String

                                    ' GW2018. Write debug info is field overflows.
                                    If tmpVal.Length > tmpsize Then
                                        sw2 = New StreamWriter("core_debug_overflow.txt", True)
                                        buf = ">>>CoreWarning. MenuOptionWeb.PutDataTextTable. Subfile: " + strFileColumn + ". Column overflow on column " + j.ToString() _
                                                      + " named: " + dt.Columns(j).ColumnName.ToUpper +
                                                      "Dictionary column size=" + tmpsize.ToString() + ", data value size = " + tmpVal.Length.ToString() + ", value=" + tmpVal
                                        sw2.Write(buf.ToString)
                                        sw2.Flush()
                                        sw2.Close()
                                        sw2.Dispose()
                                    End If

                                    strFileText.Append(tmpVal)
                                End If
                            ElseIf dt.Columns(j).DataType.ToString = "System.DateTime" Then
                                If IsNull(dt.Rows(i)(j)) OrElse dt.Rows(i)(j) = #12:00:00 AM# Then
                                    strFileText.Append("        ")
                                Else
                                    Dim dateTimeInfo As DateTime = dt.Rows(i)(j)
                                    strFileText.Append(
                                        dateTimeInfo.Year.ToString & dateTimeInfo.Month.ToString.PadLeft(2, "0") &
                                        dateTimeInfo.Day.ToString.PadLeft(2, "0"))
                                End If
                            Else
                                strFileText.Append(
                                    dt.Rows(i)(j).ToString.PadRight(hslenght.Item(dt.Columns(j).ColumnName.ToLower)).
                                                      Substring(0, hslenght.Item(dt.Columns(j).ColumnName.ToLower)))
                            End If
                        End If
                    Next

                    intRowcount = intRowcount + 1

                    If intRowcount > 4999 Then
                        intRowcount = 0

                        If strFileText.ToString.Length > 0 Then
                            'My.Computer.FileSystem.WriteAllText(strFile, strFileText.ToString, True)
                            'sw = New StreamWriter(strFile + "debug", blnAppend)
                            sw = New StreamWriter(strFile, blnAppend)
                            blnAppend = True
                            blnFileExists = True
                            sw.Write(strFileText.ToString)
                            sw.Flush()
                            sw.Close()
                            sw.Dispose()
                            sw = Nothing

                            GC.Collect()

                            strFileText.Remove(0, strFileText.Length)
                            blnWriteBlankFile = False
                        End If
                    End If
                Next

                If strFileText.ToString.Length > 0 OrElse blnWriteBlankFile Then
                    'My.Computer.FileSystem.WriteAllText(strFile, strFileText.ToString, True)

                    'If strFileColumn.EndsWith(".psd") Then
                    '    sw = New StreamWriter(strFile + "", blnAppend)
                    'Else
                    '    sw = New StreamWriter(strFile + "debug", blnAppend)
                    'End If

                    sw = New StreamWriter(strFile + "", blnAppend)

                    sw.Write(strFileText.ToString)
                    sw.Flush()
                    sw.Close()
                    sw.Dispose()
                    sw = Nothing

                    GC.Collect()

                    strFileText.Remove(0, strFileText.Length)
                End If





                If Not strFileName.ToUpper.EndsWith("_TEMP") AndAlso Not IsNothing(strSubFiles) AndAlso strSubFiles.Length > 0 Then
                    For i As Integer = 0 To strSubFiles.Length - 1
                        Dim strVariable As String = String.Empty
                        Dim strSubFile As String = String.Empty
                        Dim strSubFileName As String = String.Empty
                        Dim strSubFileGroup As String = String.Empty
                        Dim strSubFileAccount As String = String.Empty
                        Dim strFileStatement As String = String.Empty
                        Dim intRecordLength As Integer = 0

                        ' Determine File Statement, Record Length, Variable Name and SubFileName.Group.Account
                        If strSubFiles(i).ToString.Contains("~"c) Then
                            strFileStatement = strSubFiles(i).ToString.Split("~"c)(0)
                            intRecordLength = strSubFiles(i).ToString.Split("~"c)(1)

                            If strFileStatement.Contains("="c) AndAlso intRecordLength > 0 Then
                                strVariable = strFileStatement.Split("="c)(0)
                                strSubFile = strFileStatement.Split("="c)(1)

                                Select Case strSubFile.Split("."c).Length
                                    Case 1
                                        strSubFileName = strSubFile.Split("."c)(0)
                                        strSubFileGroup = Me.Session(UniqueSessionID + "m_strGROUP")
                                        strSubFileAccount = Me.Session(UniqueSessionID + "m_strACCOUNT")

                                    Case 2
                                        strSubFileName = strSubFile.Split("."c)(0)
                                        strSubFileGroup = strSubFile.Split("."c)(1)
                                        strSubFileAccount = Me.Session(UniqueSessionID + "m_strACCOUNT")

                                    Case 3
                                        strSubFileName = strSubFile.Split("."c)(0)
                                        strSubFileGroup = strSubFile.Split("."c)(1)
                                        strSubFileAccount = strSubFile.Split("."c)(2)

                                End Select

                                If strVariable.Trim = strFileName.Trim Then
                                    Dim arrMoveFiles As ArrayList
                                    Dim strPass As String = strVariable & "~" & strSubFileName & "~" & strSubFileGroup &
                                                            "~" & strSubFileAccount & "~" & intRecordLength
                                    arrMoveFiles = Session(UniqueSessionID + "arrMoveFiles")

                                    If IsNothing(arrMoveFiles) Then
                                        arrMoveFiles = New ArrayList
                                    End If
                                    If Not arrMoveFiles.Contains(strPass) Then
                                        arrMoveFiles.Add(strPass)
                                    End If
                                    Session(UniqueSessionID + "arrMoveFiles") = arrMoveFiles

                                End If
                            End If
                        End If
                    Next
                End If

                aFileInfo = New FileInfo(strFile)

                If m_blnDidLock AndAlso aFileInfo.Attributes Then
                    aFileInfo.Attributes = aFileInfo.Attributes Or FileAttributes.ReadOnly
                End If

                aFileInfo = Nothing

            Catch ex As Exception

                WriteError(ex)

            Finally
                dt.Dispose()
                dt = Nothing

            End Try
        End Function

        Private Function GetOverpunchDigit(value As String, positive As Boolean) As String

            If positive Then

                Select Case value.ToUpper()
                    Case "0"
                        Return "{"
                    Case "1"
                        Return "A"
                    Case "2"
                        Return "B"
                    Case "3"
                        Return "C"
                    Case "4"
                        Return "D"
                    Case "5"
                        Return "E"
                    Case "6"
                        Return "F"
                    Case "7"
                        Return "G"
                    Case "8"
                        Return "H"
                    Case "9"
                        Return "I"
                End Select

            Else

                Select Case value.ToUpper()
                    Case "0"
                        Return "}"
                    Case "1"
                        Return "J"
                    Case "2"
                        Return "K"
                    Case "3"
                        Return "L"
                    Case "4"
                        Return "M"
                    Case "5"
                        Return "N"
                    Case "6"
                        Return "O"
                    Case "7"
                        Return "P"
                    Case "8"
                        Return "Q"
                    Case "9"
                        Return "R"
                    Case Else
                        Return 0

                End Select
            End If


        End Function

        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function DeleteDataTextTable(strFileName As String, Optional ByVal IsKeep As Boolean = False,
                                            Optional ByVal blnDeleteSubFile As Boolean = False) As Boolean

            Dim strFilePath As String = Directory.GetCurrentDirectory()
            Dim strFilePath2 As String = Directory.GetCurrentDirectory() & "\" &
                                         Session(UniqueSessionID + "m_strUser") & "_" &
                                         Session(UniqueSessionID + "m_strSessionID")

            Dim strFileColumn As String = strFilePath

            If Not IsNothing(Session("PortableSubFiles")) AndAlso DirectCast(Session("PortableSubFiles"), ArrayList).Contains(strFileName) Then
                If strFileColumn.EndsWith("\") Then
                    strFileColumn = strFilePath & strFileName & ".psd"
                Else
                    strFileColumn = strFilePath & "\" & strFileName & ".psd"
                End If
            Else
                If strFileColumn.EndsWith("\") Then
                    strFileColumn = strFilePath & strFileName & ".sfd"
                Else
                    strFileColumn = strFilePath & "\" & strFileName & ".sfd"
                End If
            End If


            Dim strFile As String = String.Empty
            Dim strFileText As New StringBuilder("")

            Dim strText As String = String.Empty
            Dim strTextName As String = String.Empty
            strFileText.Remove(0, strFileText.Length)
            Dim intRowcount As Integer = 0
            Dim strName As String = String.Empty

            Try

                If File.Exists(strFileColumn) Then
                    File.Delete(strFileColumn)
                End If
                If File.Exists(strFileColumn.Replace(strFilePath, strFilePath2)) Then
                    File.Delete(strFileColumn.Replace(strFilePath, strFilePath2))
                End If

                If IsNothing(Me.Session(UniqueSessionID + "strSubFileName")) Then
                    strTextName = strFileName
                Else
                    strTextName = Me.Session(UniqueSessionID + "strSubFileName").ToString
                    If strTextName.IndexOf(".") >= 0 Then
                        strName = strTextName.Substring(0, strTextName.IndexOf("."))
                        strTextName = strTextName.Substring(strTextName.IndexOf(".") + 1)
                        strTextName = strTextName.Replace(".", "\") & "\" & strName
                    End If
                End If

                If strFile.EndsWith("\") Then
                    strFile = strFilePath & strTextName.Replace("JS", "SD")
                Else
                    strFile = strFilePath & "\" & strTextName.Replace("JS", "SD")
                End If



                If Not IsNothing(Session("PortableSubFiles")) AndAlso DirectCast(Session("PortableSubFiles"), ArrayList).Contains(strFileName) Then
                    strFile = strFile + ".ps"
                Else
                    strFile = strFile + ".sf"
                End If

                If File.Exists(strFile) Then
                    File.Delete(strFile)
                End If

                If File.Exists(strFile + "debug") Then
                    File.Delete(strFile + "debug")
                End If

                If File.Exists(strFile.Replace(strFilePath, strFilePath2)) Then
                    File.Delete(strFile.Replace(strFilePath, strFilePath2))
                End If

                If blnDeleteSubFile Then
                    If IsKeep Then
                        File.CreateText(strFile)
                    End If
                End If


                hsSubConverted.Remove(strFileName)

            Catch ex As Exception

            End Try
        End Function

        Public Function Select_If() As Boolean

            Try
                Dim returnSelectIf As Boolean

                If blnDeleteSubFile OrElse (m_blnGetSQL AndAlso blnGotSQL <> BooleanTypes.True) Then
                    Return True
                Else
                    returnSelectIf = SelectIf()
                End If

                If Not returnSelectIf Then
                    intTransactions -= 1

                    If intTransactions = 0 Then
                        blnHasRunSubfile = False
                    End If

                End If

                Return returnSelectIf

            Catch ex As CustomApplicationException
                WriteError(ex)
                Return False
            Catch ex As Exception
                WriteError(ex)
                Return False
            End Try
        End Function

        Public Overridable Function SelectIf() As Boolean
            Return False
        End Function

#If TARGET_DB = "INFORMIX" Then


#Else

        Protected Sub TruncateTable(strSchema As String, strName As String)

            Dim objReader As SqlDataReader = Nothing
            Try
                Dim strSQL As New StringBuilder("")
                Dim connectionString As String = GetConnectionString()

                'If Not strSchema.Contains(".dbo") Then
                '    strSchema = strSchema & ".dbo."
                'End If
                strSQL.Append("SELECT * FROM ").Append("").Append("sysobjects WHERE TYPE='U' AND NAME='").Append(
                    strName).Append("'")

                objReader = SqlHelper.ExecuteReader(connectionString, CommandType.Text, strSQL.ToString)

                If objReader.Read Then
                    strName = strSchema & strName
                    SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, "TRUNCATE TABLE " & strName.ToLower)
                End If
            Catch ex As Exception
                WriteError(ex)
            Finally
                If Not IsNothing(objReader) Then
                    objReader.Close()
                    objReader = Nothing
                End If
            End Try
        End Sub

        Public Sub SubFile(ByRef m_trnTRANS_UPDATE As OracleTransaction, strName As String, blnCondition As Boolean,
                           SubType As SubFileType, ByVal ParamArray Include() As Object)

            If blnCondition OrElse blnDeleteSubFile Then
                SubFile(m_trnTRANS_UPDATE, strName, SubType, Include)
            End If
        End Sub

        Public Sub SubFile(ByRef m_trnTRANS_UPDATE As OracleTransaction, strName As String, blnAt As Boolean,
                           blnCondition As Boolean, SubType As SubFileType, ByVal ParamArray Include() As Object)

            If (blnCondition AndAlso blnAt) OrElse blnDeleteSubFile Then
                SubFile(m_trnTRANS_UPDATE, strName, SubType, Include)
            End If
        End Sub

        Public Sub SubFile(ByRef m_trnTRANS_UPDATE As SqlTransaction, strName As String, blnCondition As Boolean,
                           SubType As SubFileType, Mode As SubFileMode, ByVal ParamArray Include() As Object)

            AddRecordsProcessed(strName, 0, LogType.Added)

            If blnCondition OrElse blnDeleteSubFile Then
                If Mode = SubFileMode.Append Then
                    If Not Session(UniqueSessionID + "hsSubfile").Contains(strName) Then
                        Session(UniqueSessionID + "hsSubfile").Add(strName, Nothing)
                    End If
                    If Not Session(UniqueSessionID + "hsSubfileKeepText").Contains(strName) Then
                        Session(UniqueSessionID + "hsSubfileKeepText").add(strName,
                                                                           SessionInformation.GetSession(
                                                                               strName + "_Length", QTPSessionID))
                    End If
                ElseIf Mode = SubFileMode.Overwrite Then
                    If Session(UniqueSessionID + "hsSubfile").Contains(strName) Then
                        Session(UniqueSessionID + "hsSubfile").Remove(strName)
                    End If
                End If

                If Mode = SubFileMode.Append Then blnAppendSubFile = True
                SubFile(m_trnTRANS_UPDATE, strName, SubType, Include)
                blnAppendSubFile = False
            End If
        End Sub

        Public Sub SubFile(ByRef m_trnTRANS_UPDATE As SqlTransaction, strName As String, blnCondition As Boolean,
                           SubType As SubFileType, ByVal ParamArray Include() As Object)

            AddRecordsProcessed(strName, 0, LogType.Added)

            If blnCondition OrElse blnDeleteSubFile Then
                If Include(0).GetType.ToString = "Core.Framework.Core.Framework.SubFileMode" Then
                    If Include(0) = SubFileMode.Append Then
                        If Not Session(UniqueSessionID + "hsSubfile").Contains(strName) Then
                            Session(UniqueSessionID + "hsSubfile").Add(strName, Nothing)
                        End If
                    ElseIf Include(0) = SubFileMode.Overwrite Then
                        If Session(UniqueSessionID + "hsSubfile").Contains(strName) Then
                            Session(UniqueSessionID + "hsSubfile").Remove(strName)
                        End If
                    End If
                    If Include(0) = SubFileMode.Append Then blnAppendSubFile = True
                End If
                SubFile(m_trnTRANS_UPDATE, strName, SubType, Include)
            Else
                ' If the condition isn't met, ensure that we still save the table structure so that if used in another
                ' SubFile call (ie. with mode Append), that we don't get a Variable or object block variable not set error.
                If _
                    SubType = SubFileType.Keep OrElse
                    SubType = SubFileType.Portable OrElse
                    SubType = SubFileType.KeepText AndAlso Not Session(UniqueSessionID + "hsSubFileKeepText") Is Nothing _
                    AndAlso
                    (Not CType(Session(UniqueSessionID + "hsSubFileKeepText"), Hashtable).Contains(strName) OrElse
                     CType(Session(UniqueSessionID + "hsSubFileKeepText"), Hashtable).Item(strName) Is Nothing) Then
                    SubFile(strName, SubType, Include)
                End If
            End If
        End Sub

        ' This SubFile should only be called to create the structure that is stored and
        ' used by the Session(UniqueSessionID + "hsSubFileKeepText").  (COLONIAL - NPP20)
        Public Sub SubFile(strName As String, SubType As SubFileType, ByVal ParamArray Include() As Object)

            Dim objReader As SqlDataReader
            Dim strSQL As New StringBuilder("")
            Dim strCreateTableSQL As New StringBuilder("")
            Dim strInsertRowSQL As New StringBuilder("")
            Dim intTableCount As Integer = 0
            Dim fleTemp As SqlFileObject
            Dim strColumns As String = String.Empty
            Dim strValues As String = String.Empty
            Dim strDataValues As String = String.Empty
            Dim strCreateTable As String = String.Empty
            Dim strSchema As String = ConfigurationManager.AppSettings("SubFileSchema") & ""
            Dim IsKeepText As Boolean = (ConfigurationManager.AppSettings("SubfileKEEPtoTEXT") & "").ToUpper = "TRUE"
            Dim intSubFileRow As Integer = 0
            Dim SubTotalValue As String = String.Empty
            Dim hsLenght As New Hashtable
            Dim hsSubfileKeepText As SortedList
            hsSubfileKeepText = Session(UniqueSessionID + "hsSubfileKeepText")
            Dim strCulture As String = ConfigurationManager.AppSettings("Culture") & ""
            Dim strSubfileNumeric As String = ConfigurationManager.AppSettings("SubFileNumeric") & ""
            Dim strConnect As String = GetConnectionString()

            If strCulture.Length > 0 Then
                strCulture = " COLLATE " & strCulture
            End If

            If SubType = SubFileType.KeepText Then
                IsKeepText = True
                SubType = SubFileType.Keep
            End If

            If strSchema.Length > 0 Then
                strSchema = strSchema & "."
            End If

            Dim dt As DataTable
            Dim dc As DataColumn
            Dim rw As DataRow
            Dim arrColumns() As String
            Dim arrValues() As String

            If IsKeepText AndAlso SubType <> SubFileType.Keep AndAlso SubType <> SubFileType.Portable Then
                Session(UniqueSessionID + "alSubTempFile").Add(strName & "_" & Session("SessionID"))
            End If

            If SubType = SubFileType.Portable Then
                If IsNothing(Session("PortableSubFiles")) Then
                    Session("PortableSubFiles") = New ArrayList
                    DirectCast(Session("PortableSubFiles"), ArrayList).Add(strName)
                Else
                    If Not DirectCast(Session("PortableSubFiles"), ArrayList).Contains(strName) Then
                        DirectCast(Session("PortableSubFiles"), ArrayList).Add(strName)
                    End If
                End If
            End If

            ' If we have a temp table that is kept in memory, store the INTEGER or DECIMAL columns in
            ' a hashtable to determine the decimal value decimal.
            Dim htDecimals As Hashtable = Nothing
            Dim hasItemCache As Boolean = False
            If SubType = SubFileType.Temp Then
                hasItemCache = Not Session(strName + "_DataTypes") Is Nothing
                If Not hasItemCache Then htDecimals = New Hashtable
            End If

            If Session(UniqueSessionID + "hsSubfile").Contains(strName) Then
                dt = Session(UniqueSessionID + "hsSubfile").Item(strName)
                blnQTPSubFile = True

                If IsNothing(dt) Then
                    intSubFileRow = 1
                    dt = New DataTable(strName)
                Else
                    intSubFileRow = dt.Rows.Count + 1
                    blnAppendSubFile = False
                End If

            Else
                If SubType = SubFileType.TempText OrElse ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso IsKeepText) Then
                    DeleteDataTextTable(strName, False)
                End If
                dt = New DataTable(strName)
                blnQTPSubFile = False
                intSubFileRow = 1
            End If

            If blnDeleteSubFile Then
                blnDeletedSubFile = True
            End If

            blnHasRunSubfile = True

            Try
                If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                    strCreateTableSQL.Append("CREATE TABLE ")
                    If strSchema <> "" Then
                        strCreateTableSQL.Append(strSchema).Append(strName)
                    Else
                        strCreateTableSQL.Append(strName)
                    End If
                End If

                'If (SubType = SubFileType.Keep AndAlso Not IsKeepText) Then
                '    strInsertRowSQL.Append(" INSERT INTO ")
                '    If strSchema <> "" Then
                '        strInsertRowSQL.Append(strSchema).Append(strName)
                '    Else
                '        strInsertRowSQL.Append(strName)
                '    End If
                'End If

                'Find the tables and Colunms
                For i As Integer = 0 To Include.Length - 1

                    Select Case Include(i).GetType.ToString.ToUpper

                        Case "CORE.WINDOWS.UI.CORE.WINDOWS.SQLFILEOBJECT"
                            intTableCount = intTableCount + 1
                            fleTemp = Include(i)
                            If fleTemp.m_dtbDataTable Is Nothing Then
                                fleTemp.CreateDataStructure()
                            End If


                            If i = Include.Length - 1 OrElse Include(i + 1).GetType.ToString <> "System.String" Then

                                For j As Integer = 0 To fleTemp.Columns.Count - 1

                                    If _
                                        fleTemp.Columns.Item(j).ColumnName <> "ROW_ID" AndAlso
                                        fleTemp.Columns.Item(j).ColumnName <> "CHECKSUM_VALUE" Then

                                        Select Case fleTemp.GetObjectType(fleTemp.Columns.Item(j).ColumnName)
                                            Case "System.String"

                                                Try
                                                    If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                                        dc = New DataColumn()
                                                        dc.ColumnName = fleTemp.Columns.Item(j).ColumnName
                                                        dc.DataType = Type.GetType("System.String")

                                                        If _
                                                            VAL(
                                                                fleTemp.GetObjectSize(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower)) <> 0 _
                                                            Then
                                                            If _
                                                                hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                                hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower) Then
                                                                If _
                                                                    Not _
                                                                    hsLenght.Contains(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower) Then _
                                                                    hsLenght.Add(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower,
                                                                        hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                            fleTemp.Columns.Item(j).ColumnName.ToLower))
                                                                dc.MaxLength =
                                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower)
                                                            Else
                                                                If _
                                                                    Not _
                                                                    hsLenght.Contains(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower) Then _
                                                                    hsLenght.Add(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower,
                                                                        VAL(
                                                                            fleTemp.GetObjectSize(
                                                                                fleTemp.Columns.Item(j).ColumnName.
                                                                                                     ToLower)))
                                                                dc.MaxLength =
                                                                    VAL(
                                                                        fleTemp.GetObjectSize(
                                                                            fleTemp.Columns.Item(j).ColumnName.ToLower))
                                                            End If
                                                        End If

                                                        dt.Columns.Add(dc)

                                                    End If

                                                    'build the columns
                                                    strColumns = strColumns & fleTemp.Columns.Item(j).ColumnName & m_strDelimiter
                                                    'If (SubType = SubFileType.Keep AndAlso Not IsKeepText) Then strValues = strValues & StringToField(fleTemp.GetStringValue(fleTemp.Columns.Item(j).ColumnName)) & "~"
                                                    'strDataValues = strDataValues & fleTemp.GetStringValue(fleTemp.Columns.Item(j).ColumnName) & "~"

                                                    If _
                                                        Not blnQTPSubFile AndAlso
                                                        ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                                        strCreateTable = strCreateTable & dc.ColumnName & " VARCHAR("
                                                        strCreateTable = strCreateTable & dc.MaxLength & ") " &
                                                                         strCulture & " NULL ,"
                                                    End If

                                                Catch ex As Exception
                                                    Dim intNextCol As Integer = 2
                                                    Do _
                                                        While _
                                                            dt.Columns.Contains(
                                                                fleTemp.Columns.Item(j).ColumnName & intNextCol.ToString)
                                                        intNextCol = intNextCol + 1
                                                    Loop

                                                    dc = New DataColumn()
                                                    dc.ColumnName = fleTemp.Columns.Item(j).ColumnName &
                                                                    intNextCol.ToString
                                                    dc.DataType = Type.GetType("System.String")

                                                    If _
                                                        VAL(
                                                            fleTemp.GetObjectSize(
                                                                fleTemp.Columns.Item(j).ColumnName.ToLower)) <> 0 Then
                                                        If _
                                                            hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                            hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                                fleTemp.Columns.Item(j).ColumnName & intNextCol.ToString) _
                                                            Then
                                                            If _
                                                                Not _
                                                                hsLenght.Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString) Then _
                                                                hsLenght.Add(
                                                                    fleTemp.Columns.Item(j).ColumnName &
                                                                    intNextCol.ToString,
                                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                        fleTemp.Columns.Item(j).ColumnName &
                                                                        intNextCol.ToString))
                                                            dc.MaxLength =
                                                                hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                    fleTemp.Columns.Item(j).ColumnName &
                                                                    intNextCol.ToString)
                                                        ElseIf _
                                                            hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                            hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                                fleTemp.Columns.Item(j).ColumnName) Then
                                                            If _
                                                                Not _
                                                                hsLenght.Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString) Then _
                                                                hsLenght.Add(
                                                                    fleTemp.Columns.Item(j).ColumnName &
                                                                    intNextCol.ToString,
                                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                        fleTemp.Columns.Item(j).ColumnName))
                                                            dc.MaxLength =
                                                                hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                    fleTemp.Columns.Item(j).ColumnName)
                                                        Else
                                                            If _
                                                                Not _
                                                                hsLenght.Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString) Then _
                                                                hsLenght.Add(
                                                                    fleTemp.Columns.Item(j).ColumnName &
                                                                    intNextCol.ToString,
                                                                    VAL(
                                                                        fleTemp.GetObjectSize(
                                                                            fleTemp.Columns.Item(j).ColumnName)))
                                                            dc.MaxLength =
                                                                VAL(
                                                                    fleTemp.GetObjectSize(
                                                                        fleTemp.Columns.Item(j).ColumnName))
                                                        End If
                                                    End If

                                                    dt.Columns.Add(dc)

                                                    'build the columns
                                                    strColumns = strColumns & fleTemp.Columns.Item(j).ColumnName & m_strDelimiter
                                                    'If (SubType = SubFileType.Keep AndAlso Not IsKeepText) Then strValues = strValues & StringToField(fleTemp.GetStringValue(fleTemp.Columns.Item(j).ColumnName)) & "~"
                                                    'strDataValues = strDataValues & fleTemp.GetStringValue(fleTemp.Columns.Item(j).ColumnName) & "~"
                                                    If _
                                                        Not blnQTPSubFile AndAlso
                                                        ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                                        strCreateTable = strCreateTable & dc.ColumnName & " VARCHAR("
                                                        strCreateTable = strCreateTable & dc.MaxLength & ") " &
                                                                         strCulture & " NULL ,"
                                                    End If

                                                End Try

                                            Case "System.DateTime"

                                                Try
                                                    If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                                        dc = New DataColumn()
                                                        dc.ColumnName = fleTemp.Columns.Item(j).ColumnName
                                                        dc.DataType = Type.GetType("System.DateTime")
                                                        dt.Columns.Add(dc)
                                                    End If

                                                    'build the columns
                                                    strColumns = strColumns & fleTemp.Columns.Item(j).ColumnName & m_strDelimiter

                                                    'If (SubType = SubFileType.Keep AndAlso Not IsKeepText) Then
                                                    '    If GetDateFromYYYYMMDDDecimal(fleTemp.GetNumericDateTimeValue(fleTemp.Columns.Item(j).ColumnName)) = cZeroDate Then
                                                    '        strValues = strValues & "Null"
                                                    '    Else
                                                    '        strValues = strValues & "CONVERT(DATETIME, " + StringToField(Format(CDate(GetDateFromYYYYMMDDDecimal(fleTemp.GetNumericDateTimeValue(fleTemp.Columns.Item(j).ColumnName))), "yyyy-MM-dd HH:mm:ss")) + ", 120)"
                                                    '    End If
                                                    '    strValues = strValues & "~"
                                                    'End If

                                                    'strDataValues = strDataValues & fleTemp.GetNumericDateTimeValue(fleTemp.Columns.Item(j).ColumnName) & "~"
                                                    If _
                                                        Not blnQTPSubFile AndAlso
                                                        ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                                        strCreateTable = strCreateTable & dc.ColumnName & " DATETIME,"
                                                    End If

                                                Catch ex As Exception
                                                    Dim intNextCol As Integer = 2
                                                    Do _
                                                        While _
                                                            dt.Columns.Contains(
                                                                fleTemp.Columns.Item(j).ColumnName & intNextCol.ToString)
                                                        intNextCol = intNextCol + 1
                                                    Loop

                                                    dc = New DataColumn()
                                                    dc.ColumnName = fleTemp.Columns.Item(j).ColumnName &
                                                                    intNextCol.ToString
                                                    dc.DataType = Type.GetType("System.DateTime")
                                                    dt.Columns.Add(dc)

                                                    'build the columns
                                                    strColumns = strColumns & fleTemp.Columns.Item(j).ColumnName & m_strDelimiter

                                                    'If (SubType = SubFileType.Keep AndAlso Not IsKeepText) Then
                                                    '    If GetDateFromYYYYMMDDDecimal(fleTemp.GetNumericDateTimeValue(fleTemp.Columns.Item(j).ColumnName)) = cZeroDate Then
                                                    '        strValues = strValues & "Null"
                                                    '    Else
                                                    '        strValues = strValues & "CONVERT(DATETIME, " + StringToField(Format(CDate(GetDateFromYYYYMMDDDecimal(fleTemp.GetNumericDateTimeValue(fleTemp.Columns.Item(j).ColumnName))), "yyyy-MM-dd HH:mm:ss")) + ", 120)"
                                                    '    End If
                                                    '    strValues = strValues & "~"
                                                    'End If

                                                    'strDataValues = strDataValues & fleTemp.GetNumericDateTimeValue(fleTemp.Columns.Item(j).ColumnName) & "~"
                                                    If _
                                                        Not blnQTPSubFile AndAlso
                                                        ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                                        strCreateTable = strCreateTable & dc.ColumnName & " DATETIME,"
                                                    End If
                                                End Try

                                            Case "System.Decimal", "System.Double", "System.Single"

                                                Try
                                                    ' If we have an integer or decimal in a temp table that is stored in memory,
                                                    ' save the decimal value ("18,0" for integer, "18,2" if decimal 2, etc.)
                                                    If SubType = SubFileType.Temp AndAlso Not hasItemCache Then
                                                        htDecimals.Add(fleTemp.Columns.Item(j).ColumnName.ToUpper,
                                                                       fleTemp.GetDecimalSize(
                                                                           fleTemp.Columns.Item(j).ColumnName))
                                                    End If

                                                    If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                                        dc = New DataColumn()
                                                        dc.ColumnName = fleTemp.Columns.Item(j).ColumnName
                                                        dc.DataType = Type.GetType("System.Decimal")
                                                        If _
                                                            VAL(
                                                                fleTemp.GetObjectSize(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower)) <> 0 _
                                                            Then
                                                            If _
                                                                hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                                hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower) Then
                                                                If _
                                                                    Not _
                                                                    hsLenght.Contains(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower) Then _
                                                                    hsLenght.Add(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower,
                                                                        hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                            fleTemp.Columns.Item(j).ColumnName.ToLower))
                                                            Else
                                                                If _
                                                                    Not _
                                                                    hsLenght.Contains(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower) Then _
                                                                    hsLenght.Add(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower,
                                                                        VAL(
                                                                            fleTemp.GetObjectSize(
                                                                                fleTemp.Columns.Item(j).ColumnName.
                                                                                                     ToLower)))
                                                            End If
                                                        End If
                                                        dt.Columns.Add(dc)

                                                    End If

                                                    'build the columns
                                                    strColumns = strColumns & fleTemp.Columns.Item(j).ColumnName & m_strDelimiter
                                                    'If (SubType = SubFileType.Keep AndAlso Not IsKeepText) Then strValues = strValues & fleTemp.GetDecimalValue(fleTemp.Columns.Item(j).ColumnName) & "~"
                                                    'strDataValues = strDataValues & fleTemp.GetDecimalValue(fleTemp.Columns.Item(j).ColumnName) & "~"
                                                    If _
                                                        Not blnQTPSubFile AndAlso
                                                        ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                                        If strSubfileNumeric.Length > 0 Then
                                                            strCreateTable = strCreateTable & dc.ColumnName &
                                                                             " DECIMAL(" &
                                                                             fleTemp.GetDecimalSize(
                                                                                 fleTemp.Columns.Item(j).ColumnName.
                                                                                                       ToLower) & "),"
                                                        Else
                                                            strCreateTable = strCreateTable & dc.ColumnName & " FLOAT,"
                                                        End If
                                                    End If
                                                Catch ex As Exception
                                                    Dim intNextCol As Integer = 2
                                                    Do _
                                                        While _
                                                            dt.Columns.Contains(
                                                                fleTemp.Columns.Item(j).ColumnName & intNextCol.ToString)
                                                        intNextCol = intNextCol + 1
                                                    Loop

                                                    dc = New DataColumn()
                                                    dc.ColumnName = fleTemp.Columns.Item(j).ColumnName &
                                                                    intNextCol.ToString
                                                    dc.DataType = Type.GetType("System.Decimal")
                                                    If _
                                                        VAL(
                                                            fleTemp.GetObjectSize(
                                                                fleTemp.Columns.Item(j).ColumnName.ToLower)) <> 0 Then
                                                        If _
                                                            hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                            hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                                fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                intNextCol.ToString) Then
                                                            If _
                                                                Not _
                                                                hsLenght.Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString) Then _
                                                                hsLenght.Add(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString,
                                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                        intNextCol.ToString))
                                                        ElseIf _
                                                            hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                            hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                                fleTemp.Columns.Item(j).ColumnName.ToLower) Then
                                                            If _
                                                                Not _
                                                                hsLenght.Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString) Then _
                                                                hsLenght.Add(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString,
                                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower))
                                                        Else
                                                            If _
                                                                Not _
                                                                hsLenght.Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString) Then _
                                                                hsLenght.Add(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString,
                                                                    VAL(
                                                                        fleTemp.GetObjectSize(
                                                                            fleTemp.Columns.Item(j).ColumnName.ToLower)))
                                                        End If
                                                    End If
                                                    dt.Columns.Add(dc)

                                                    'build the columns
                                                    strColumns = strColumns & fleTemp.Columns.Item(j).ColumnName & m_strDelimiter
                                                    'If (SubType = SubFileType.Keep AndAlso Not IsKeepText) Then strValues = strValues & fleTemp.GetDecimalValue(fleTemp.Columns.Item(j).ColumnName) & "~"
                                                    'strDataValues = strDataValues & fleTemp.GetDecimalValue(fleTemp.Columns.Item(j).ColumnName) & "~"
                                                    If _
                                                        Not blnQTPSubFile AndAlso
                                                        ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                                        If strSubfileNumeric.Length > 0 Then
                                                            strCreateTable = strCreateTable & dc.ColumnName &
                                                                             " DECIMAL(" &
                                                                             fleTemp.GetDecimalSize(
                                                                                 fleTemp.Columns.Item(j).ColumnName.
                                                                                                       ToLower) & "),"
                                                        Else
                                                            strCreateTable = strCreateTable & dc.ColumnName & " FLOAT,"
                                                        End If
                                                    End If
                                                End Try

                                            Case "System.Int32", "System.Int64"

                                                Try
                                                    ' If we have an integer or decimal in a temp table that is stored in memory,
                                                    ' save the decimal value ("18,0" for integer, "18,2" if decimal 2, etc.)
                                                    If SubType = SubFileType.Temp AndAlso Not hasItemCache Then
                                                        htDecimals.Add(fleTemp.Columns.Item(j).ColumnName.ToUpper,
                                                                       "18,0")
                                                    End If

                                                    If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                                        dc = New DataColumn()
                                                        dc.ColumnName = fleTemp.Columns.Item(j).ColumnName
                                                        dc.DataType = Type.GetType("System.Int64")
                                                        If _
                                                            VAL(
                                                                fleTemp.GetObjectSize(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower)) <> 0 _
                                                            Then
                                                            If _
                                                                hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                                hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower) Then
                                                                If _
                                                                    Not _
                                                                    hsLenght.Contains(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower) Then _
                                                                    hsLenght.Add(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower,
                                                                        hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                            fleTemp.Columns.Item(j).ColumnName.ToLower))
                                                            Else
                                                                If _
                                                                    Not _
                                                                    hsLenght.Contains(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower) Then _
                                                                    hsLenght.Add(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower, 10)
                                                            End If
                                                        End If
                                                        dt.Columns.Add(dc)

                                                    End If

                                                    'build the columns
                                                    strColumns = strColumns & fleTemp.Columns.Item(j).ColumnName & m_strDelimiter
                                                    'If (SubType = SubFileType.Keep AndAlso Not IsKeepText) Then strValues = strValues & fleTemp.GetDecimalValue(fleTemp.Columns.Item(j).ColumnName) & "~"
                                                    'strDataValues = strDataValues & fleTemp.GetDecimalValue(fleTemp.Columns.Item(j).ColumnName) & "~"
                                                    If _
                                                        Not blnQTPSubFile AndAlso
                                                        ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                                        strCreateTable = strCreateTable & dc.ColumnName & " FLOAT" & ","
                                                    End If
                                                Catch ex As Exception
                                                    Dim intNextCol As Integer = 2
                                                    Do _
                                                        While _
                                                            dt.Columns.Contains(
                                                                fleTemp.Columns.Item(j).ColumnName & intNextCol.ToString)
                                                        intNextCol = intNextCol + 1
                                                    Loop

                                                    dc = New DataColumn()
                                                    dc.ColumnName = fleTemp.Columns.Item(j).ColumnName &
                                                                    intNextCol.ToString
                                                    dc.DataType = Type.GetType("System.Decimal")
                                                    If _
                                                        VAL(
                                                            fleTemp.GetObjectSize(
                                                                fleTemp.Columns.Item(j).ColumnName.ToLower)) <> 0 Then
                                                        If _
                                                            hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                            hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                                fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                intNextCol.ToString) Then
                                                            If _
                                                                Not _
                                                                hsLenght.Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString) Then _
                                                                hsLenght.Add(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString,
                                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                        intNextCol.ToString))
                                                        ElseIf _
                                                            hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                            hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                                fleTemp.Columns.Item(j).ColumnName.ToLower) Then
                                                            If _
                                                                Not _
                                                                hsLenght.Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString) Then _
                                                                hsLenght.Add(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString,
                                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower))
                                                        Else
                                                            If _
                                                                Not _
                                                                hsLenght.Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString) Then _
                                                                hsLenght.Add(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString, 10)
                                                        End If
                                                    End If
                                                    dt.Columns.Add(dc)

                                                    'build the columns
                                                    strColumns = strColumns & fleTemp.Columns.Item(j).ColumnName & m_strDelimiter
                                                    'If (SubType = SubFileType.Keep AndAlso Not IsKeepText) Then strValues = strValues & fleTemp.GetDecimalValue(fleTemp.Columns.Item(j).ColumnName) & "~"
                                                    'strDataValues = strDataValues & fleTemp.GetDecimalValue(fleTemp.Columns.Item(j).ColumnName) & "~"
                                                    If _
                                                        Not blnQTPSubFile AndAlso
                                                        ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                                        strCreateTable = strCreateTable & dc.ColumnName & " FLOAT" & ","
                                                    End If
                                                End Try

                                        End Select

                                    End If

                                Next

                            End If

                        Case "SYSTEM.STRING"

                            'build the Values
                            Select Case fleTemp.GetObjectType(Include(i))

                                Case ""
                                    Dim message As String = "Error on subfile : " + strName + ". Column '" + Include(i) + "' from Table '" + fleTemp.BaseName + "' does not exist."
                                    Dim ex As CustomApplicationException = New CustomApplicationException(message)
                                    Throw ex

                                Case "System.String"

                                    Try
                                        If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                            dc = New DataColumn()
                                            dc.ColumnName = Include(i)
                                            dc.DataType = Type.GetType("System.String")
                                            If fleTemp.GetObjectSize(Include(i).ToString).Trim <> "" Then

                                                If _
                                                    hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                        Include(i).ToString.ToLower.ToLower) Then
                                                    If Not hsLenght.Contains(Include(i).ToString.ToLower) Then _
                                                        hsLenght.Add(Include(i).ToString.ToLower,
                                                                     hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                         Include(i).ToString.ToLower.ToLower))
                                                    dc.MaxLength =
                                                        hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                            Include(i).ToString.ToLower.ToLower)
                                                Else
                                                    If Not hsLenght.Contains(Include(i).ToString.ToLower) Then _
                                                        hsLenght.Add(Include(i).ToString.ToLower,
                                                                     CInt(fleTemp.GetObjectSize(Include(i).ToString)))
                                                    dc.MaxLength = CInt(fleTemp.GetObjectSize(Include(i).ToString))
                                                End If

                                            End If

                                            dt.Columns.Add(dc)
                                        End If

                                        'build the columns
                                        strColumns = strColumns & Include(i) & m_strDelimiter
                                        'If (SubType = SubFileType.Keep AndAlso Not IsKeepText) Then strValues = strValues & StringToField(fleTemp.GetStringValue(Include(i))) & "~"
                                        'strDataValues = strDataValues & fleTemp.GetStringValue(Include(i)) & "~"
                                        If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) _
                                            Then
                                            strCreateTable = strCreateTable & dc.ColumnName & " VARCHAR("
                                            strCreateTable = strCreateTable & dc.MaxLength & ") " & strCulture &
                                                             " NULL ,"
                                        End If
                                    Catch ex As Exception
                                        Dim intNextCol As Integer = 2
                                        Do While dt.Columns.Contains(Include(i) & intNextCol.ToString)
                                            intNextCol = intNextCol + 1
                                        Loop

                                        dc = New DataColumn()
                                        dc.ColumnName = Include(i) & intNextCol.ToString
                                        dc.DataType = Type.GetType("System.String")
                                        If fleTemp.GetObjectSize(Include(i).ToString).Trim <> "" Then

                                            If _
                                                hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                    Include(i).ToString.ToLower.ToLower & intNextCol.ToString) Then
                                                If _
                                                    Not _
                                                    hsLenght.Contains(Include(i).ToString.ToLower & intNextCol.ToString) _
                                                    Then _
                                                    hsLenght.Add(Include(i).ToString.ToLower & intNextCol.ToString,
                                                                 hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                     Include(i).ToString.ToLower.ToLower &
                                                                     intNextCol.ToString))
                                                dc.MaxLength =
                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                        Include(i).ToString.ToLower.ToLower)
                                            ElseIf _
                                                hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                    Include(i).ToString.ToLower.ToLower) Then
                                                If _
                                                    Not _
                                                    hsLenght.Contains(Include(i).ToString.ToLower & intNextCol.ToString) _
                                                    Then _
                                                    hsLenght.Add(Include(i).ToString.ToLower & intNextCol.ToString,
                                                                 hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                     Include(i).ToString.ToLower.ToLower))
                                                dc.MaxLength =
                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                        Include(i).ToString.ToLower.ToLower)
                                            Else
                                                If _
                                                    Not _
                                                    hsLenght.Contains(Include(i).ToString.ToLower & intNextCol.ToString) _
                                                    Then _
                                                    hsLenght.Add(Include(i).ToString.ToLower & intNextCol.ToString,
                                                                 CInt(fleTemp.GetObjectSize(Include(i).ToString)))
                                                dc.MaxLength = CInt(fleTemp.GetObjectSize(Include(i).ToString))
                                            End If

                                        End If

                                        dt.Columns.Add(dc)

                                        'build the columns
                                        strColumns = strColumns & Include(i) & m_strDelimiter
                                        'If (SubType = SubFileType.Keep AndAlso Not IsKeepText) Then strValues = strValues & StringToField(fleTemp.GetStringValue(Include(i))) & "~"
                                        'strDataValues = strDataValues & fleTemp.GetStringValue(Include(i)) & "~"
                                        If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) _
                                            Then
                                            strCreateTable = strCreateTable & dc.ColumnName & " VARCHAR("
                                            strCreateTable = strCreateTable & dc.MaxLength & ") " & strCulture &
                                                             " NULL ,"
                                        End If
                                    End Try

                                Case "System.DateTime"

                                    Try
                                        If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                            dc = New DataColumn()
                                            dc.ColumnName = Include(i)
                                            dc.DataType = Type.GetType("System.DateTime")
                                            dt.Columns.Add(dc)
                                        End If

                                        'build the columns
                                        strColumns = strColumns & Include(i) & m_strDelimiter

                                        'If (SubType = SubFileType.Keep AndAlso Not IsKeepText) Then
                                        '    If GetDateFromYYYYMMDDDecimal(fleTemp.GetNumericDateTimeValue(Include(i))) = cZeroDate Then
                                        '        strValues = strValues & "Null"
                                        '    Else
                                        '        strValues = strValues & "CONVERT(DATETIME, " + StringToField(Format(CDate(GetDateFromYYYYMMDDDecimal(fleTemp.GetNumericDateTimeValue(Include(i)))), "yyyy-MM-dd HH:mm:ss")) + ", 120)"
                                        '    End If
                                        '    strValues = strValues & "~"
                                        'End If

                                        'strDataValues = strDataValues & fleTemp.GetNumericDateTimeValue(Include(i)) & "~"
                                        If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) _
                                            Then
                                            strCreateTable = strCreateTable & dc.ColumnName & " DATETIME,"
                                        End If
                                    Catch ex As Exception
                                        Dim intNextCol As Integer = 2
                                        Do While dt.Columns.Contains(Include(i) & intNextCol.ToString)
                                            intNextCol = intNextCol + 1
                                        Loop

                                        dc = New DataColumn()
                                        dc.ColumnName = Include(i) & intNextCol.ToString
                                        dc.DataType = Type.GetType("System.DateTime")
                                        dt.Columns.Add(dc)

                                        'build the columns
                                        strColumns = strColumns & Include(i) & m_strDelimiter

                                        'If (SubType = SubFileType.Keep AndAlso Not IsKeepText) Then
                                        '    If GetDateFromYYYYMMDDDecimal(fleTemp.GetNumericDateTimeValue(Include(i))) = cZeroDate Then
                                        '        strValues = strValues & "Null"
                                        '    Else
                                        '        strValues = strValues & "CONVERT(DATETIME, " + StringToField(Format(CDate(GetDateFromYYYYMMDDDecimal(fleTemp.GetNumericDateTimeValue(Include(i)))), "yyyy-MM-dd HH:mm:ss")) + ", 120)"
                                        '    End If
                                        '    strValues = strValues & "~"
                                        'End If

                                        'strDataValues = strDataValues & fleTemp.GetNumericDateTimeValue(Include(i)).ToString.Replace("12:00:00 AM", "NULL") & "~"
                                        If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) _
                                            Then
                                            strCreateTable = strCreateTable & dc.ColumnName & " DATETIME,"
                                        End If
                                    End Try

                                Case "System.Decimal", "System.Double", "System.Single"

                                    Try
                                        ' If we have an integer or decimal in a temp table that is stored in memory,
                                        ' save the decimal value ("18,0" for integer, "18,2" if decimal 2, etc.)
                                        If SubType = SubFileType.Temp AndAlso Not hasItemCache Then
                                            htDecimals.Add(Include(i).ToString.ToUpper,
                                                           fleTemp.GetDecimalSize(Include(i).ToString))
                                        End If

                                        If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                            dc = New DataColumn()
                                            dc.ColumnName = Include(i)
                                            dc.DataType = Type.GetType("System.Decimal")
                                            If fleTemp.GetObjectSize(Include(i).ToString).Trim <> "" Then
                                                If _
                                                    hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                        Include(i).ToString.ToLower.ToLower) Then
                                                    If Not hsLenght.Contains(Include(i).ToString.ToLower) Then _
                                                        hsLenght.Add(Include(i).ToString.ToLower,
                                                                     hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                         Include(i).ToString.ToLower.ToLower))
                                                Else
                                                    If Not hsLenght.Contains(Include(i).ToString.ToLower) Then _
                                                        hsLenght.Add(Include(i).ToString.ToLower,
                                                                     CInt(fleTemp.GetObjectSize(Include(i).ToString)))
                                                End If
                                            End If
                                            dt.Columns.Add(dc)
                                        End If

                                        'build the columns
                                        strColumns = strColumns & Include(i) & m_strDelimiter
                                        'If (SubType = SubFileType.Keep AndAlso Not IsKeepText) Then strValues = strValues & fleTemp.GetDecimalValue(Include(i)) & "~"
                                        'strDataValues = strDataValues & fleTemp.GetDecimalValue(Include(i)) & "~"
                                        If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) _
                                            Then
                                            If strSubfileNumeric.Length > 0 Then
                                                strCreateTable = strCreateTable & dc.ColumnName & " DECIMAL(" &
                                                                 fleTemp.GetDecimalSize(Include(i).ToString) & "),"
                                            Else
                                                strCreateTable = strCreateTable & dc.ColumnName & " FLOAT,"
                                            End If
                                        End If
                                    Catch ex As Exception
                                        Dim intNextCol As Integer = 2
                                        Do While dt.Columns.Contains(Include(i) & intNextCol.ToString)
                                            intNextCol = intNextCol + 1
                                        Loop

                                        dc = New DataColumn()
                                        dc.ColumnName = Include(i) & intNextCol.ToString
                                        dc.DataType = Type.GetType("System.Decimal")
                                        If fleTemp.GetObjectSize(Include(i).ToString).Trim <> "" Then
                                            If _
                                                hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                    Include(i).ToString.ToLower.ToLower & intNextCol.ToString) Then
                                                If _
                                                    Not _
                                                    hsLenght.Contains(Include(i).ToString.ToLower & intNextCol.ToString) _
                                                    Then _
                                                    hsLenght.Add(Include(i).ToString.ToLower & intNextCol.ToString,
                                                                 hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                     Include(i).ToString.ToLower.ToLower &
                                                                     intNextCol.ToString))
                                            ElseIf _
                                                hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                    Include(i).ToString.ToLower.ToLower) Then
                                                If _
                                                    Not _
                                                    hsLenght.Contains(Include(i).ToString.ToLower & intNextCol.ToString) _
                                                    Then _
                                                    hsLenght.Add(Include(i).ToString.ToLower & intNextCol.ToString,
                                                                 hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                     Include(i).ToString.ToLower.ToLower))
                                            Else
                                                If _
                                                    Not _
                                                    hsLenght.Contains(Include(i).ToString.ToLower & intNextCol.ToString) _
                                                    Then _
                                                    hsLenght.Add(Include(i).ToString.ToLower & intNextCol.ToString,
                                                                 CInt(fleTemp.GetObjectSize(Include(i).ToString)))
                                            End If
                                        End If
                                        dt.Columns.Add(dc)

                                        'build the columns
                                        strColumns = strColumns & Include(i) & m_strDelimiter
                                        'If (SubType = SubFileType.Keep AndAlso Not IsKeepText) Then strValues = strValues & fleTemp.GetDecimalValue(Include(i)) & "~"
                                        'strDataValues = strDataValues & fleTemp.GetDecimalValue(Include(i)) & "~"
                                        If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) _
                                            Then
                                            If strSubfileNumeric.Length > 0 Then
                                                strCreateTable = strCreateTable & dc.ColumnName & " DECIMAL(" &
                                                                 fleTemp.GetDecimalSize(Include(i).ToString) & "),"
                                            Else
                                                strCreateTable = strCreateTable & dc.ColumnName & " FLOAT,"
                                            End If
                                        End If
                                    End Try

                                Case "System.Int32", "System.Int64"

                                    Try
                                        ' If we have an integer or decimal in a temp table that is stored in memory,
                                        ' save the decimal value ("18,0" for integer, "18,2" if decimal 2, etc.)
                                        If SubType = SubFileType.Temp AndAlso Not hasItemCache Then
                                            htDecimals.Add(Include(i).ToString.ToUpper, "18,0")
                                        End If

                                        If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                            dc = New DataColumn()
                                            dc.ColumnName = Include(i)
                                            dc.DataType = Type.GetType("System.Int64")
                                            If fleTemp.GetObjectSize(Include(i).ToString).Trim <> "" Then
                                                If _
                                                    hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                        Include(i).ToString.ToLower.ToLower) Then
                                                    If Not hsLenght.Contains(Include(i).ToString.ToLower) Then _
                                                        hsLenght.Add(Include(i).ToString.ToLower,
                                                                     hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                         Include(i).ToString.ToLower.ToLower))
                                                Else
                                                    If Not hsLenght.Contains(Include(i).ToString.ToLower) Then _
                                                        hsLenght.Add(Include(i).ToString.ToLower, 10)
                                                End If
                                            End If
                                            dt.Columns.Add(dc)
                                        End If

                                        'build the columns
                                        strColumns = strColumns & Include(i) & m_strDelimiter
                                        'If (SubType = SubFileType.Keep AndAlso Not IsKeepText) Then strValues = strValues & fleTemp.GetDecimalValue(Include(i)) & "~"
                                        'strDataValues = strDataValues & fleTemp.GetDecimalValue(Include(i)) & "~"
                                        If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) _
                                            Then
                                            strCreateTable = strCreateTable & dc.ColumnName & " FLOAT" & ","
                                        End If
                                    Catch ex As Exception
                                        Dim intNextCol As Integer = 2
                                        Do While dt.Columns.Contains(Include(i) & intNextCol.ToString)
                                            intNextCol = intNextCol + 1
                                        Loop

                                        dc = New DataColumn()
                                        dc.ColumnName = Include(i) & intNextCol.ToString
                                        dc.DataType = Type.GetType("System.Decimal")
                                        If fleTemp.GetObjectSize(Include(i).ToString).Trim <> "" Then
                                            If _
                                                hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                    Include(i).ToString.ToLower.ToLower & intNextCol.ToString) Then
                                                If _
                                                    Not _
                                                    hsLenght.Contains(Include(i).ToString.ToLower & intNextCol.ToString) _
                                                    Then _
                                                    hsLenght.Add(Include(i).ToString.ToLower & intNextCol.ToString,
                                                                 hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                     Include(i).ToString.ToLower.ToLower &
                                                                     intNextCol.ToString))
                                            ElseIf _
                                                hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                    Include(i).ToString.ToLower.ToLower) Then
                                                If _
                                                    Not _
                                                    hsLenght.Contains(Include(i).ToString.ToLower & intNextCol.ToString) _
                                                    Then _
                                                    hsLenght.Add(Include(i).ToString.ToLower & intNextCol.ToString,
                                                                 hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                     Include(i).ToString.ToLower.ToLower))
                                            Else
                                                If _
                                                    Not _
                                                    hsLenght.Contains(Include(i).ToString.ToLower & intNextCol.ToString) _
                                                    Then _
                                                    hsLenght.Add(Include(i).ToString.ToLower & intNextCol.ToString, 10)
                                            End If
                                        End If
                                        dt.Columns.Add(dc)

                                        'build the columns
                                        strColumns = strColumns & Include(i) & m_strDelimiter
                                        'If (SubType = SubFileType.Keep AndAlso Not IsKeepText) Then strValues = strValues & fleTemp.GetDecimalValue(Include(i)) & "~"
                                        'strDataValues = strDataValues & fleTemp.GetDecimalValue(Include(i)) & "~"
                                        If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) _
                                            Then
                                            strCreateTable = strCreateTable & dc.ColumnName & " FLOAT" & ","
                                        End If
                                    End Try

                            End Select

                        Case "CORE.FRAMEWORK.CORE.FRAMEWORK.DCHARACTER", "CORE.FRAMEWORK.CORE.FRAMEWORK.DVARCHAR",
                            "CORE.WINDOWS.UI.CORE.WINDOWS.CORECHARACTER"

                            Try
                                If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                    dc = New DataColumn()
                                    dc.ColumnName = Include(i).Name
                                    dc.DataType = Type.GetType("System.String")
                                    If Include(i).Size > 0 Then
                                        dc.MaxLength = Include(i).Size
                                        If Not hsLenght.Contains(Include(i).Name.ToString.ToLower) Then _
                                            hsLenght.Add(Include(i).Name.ToString.ToLower, Include(i).Size)
                                    End If
                                    dt.Columns.Add(dc)
                                End If

                                strColumns = strColumns & Include(i).Name & m_strDelimiter
                                'If (SubType = SubFileType.Keep AndAlso Not IsKeepText) Then strValues = strValues & StringToField(Include(i).Value) & "~"
                                'strDataValues = strDataValues & Include(i).Value & "~"
                                If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                    strCreateTable = strCreateTable & dc.ColumnName & " VARCHAR("
                                    strCreateTable = strCreateTable & dc.MaxLength & ") " & strCulture & " NULL ,"
                                End If
                            Catch ex As Exception
                                Dim intNextCol As Integer = 2
                                Do While dt.Columns.Contains(Include(i).Name & intNextCol.ToString)
                                    intNextCol = intNextCol + 1
                                Loop

                                dc = New DataColumn()
                                dc.ColumnName = Include(i).Name & intNextCol.ToString
                                dc.DataType = Type.GetType("System.String")
                                If Include(i).Size > 0 Then
                                    dc.MaxLength = Include(i).Size
                                    If Not hsLenght.Contains(Include(i).Name.ToString.ToLower & intNextCol.ToString) _
                                        Then _
                                        hsLenght.Add(Include(i).Name.ToString.ToLower & intNextCol.ToString,
                                                     Include(i).Size)
                                End If
                                dt.Columns.Add(dc)

                                strColumns = strColumns & Include(i).Name & m_strDelimiter
                                'If (SubType = SubFileType.Keep AndAlso Not IsKeepText) Then strValues = strValues & StringToField(Include(i).Value) & "~"
                                'strDataValues = strDataValues & Include(i).Value & "~"
                                If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                    strCreateTable = strCreateTable & dc.ColumnName & " VARCHAR("
                                    strCreateTable = strCreateTable & dc.MaxLength & ") " & strCulture & " NULL ,"
                                End If
                            End Try

                        Case "CORE.WINDOWS.UI.CORE.WINDOWS.COREDATE"

                            Try
                                If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                    dc = New DataColumn()
                                    dc.ColumnName = Include(i).Name
                                    dc.DataType = Type.GetType("System.DateTime")
                                    dt.Columns.Add(dc)
                                End If

                                'build the columns
                                strColumns = strColumns & Include(i).Name & m_strDelimiter

                                'If (SubType = SubFileType.Keep AndAlso Not IsKeepText) Then
                                '    If GetDateFromYYYYMMDDDecimal(Include(i).Value) = cZeroDate Then
                                '        strValues = strValues & "Null"
                                '    Else
                                '        strValues = strValues & "CONVERT(DATETIME, " + StringToField(Format(CDate(GetDateFromYYYYMMDDDecimal(Include(i).Value)), "yyyy-MM-dd HH:mm:ss")) + ", 120)"
                                '    End If
                                '    strValues = strValues & "~"
                                'End If

                                'strDataValues = strDataValues & Include(i).Value & "~"
                                If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                    strCreateTable = strCreateTable & dc.ColumnName & " DATETIME,"
                                End If
                            Catch ex As Exception
                                Dim intNextCol As Integer = 2
                                Do While dt.Columns.Contains(Include(i).Name & intNextCol.ToString)
                                    intNextCol = intNextCol + 1
                                Loop

                                dc = New DataColumn()
                                dc.ColumnName = Include(i).Name & intNextCol.ToString
                                dc.DataType = Type.GetType("System.DateTime")
                                dt.Columns.Add(dc)

                                'build the columns
                                strColumns = strColumns & Include(i).Name & m_strDelimiter

                                'If (SubType = SubFileType.Keep AndAlso Not IsKeepText) Then
                                '    If GetDateFromYYYYMMDDDecimal(Include(i).Value) = cZeroDate Then
                                '        strValues = strValues & "Null"
                                '    Else
                                '        strValues = strValues & "CONVERT(DATETIME, " + StringToField(Format(CDate(GetDateFromYYYYMMDDDecimal(Include(i).Value)), "yyyy-MM-dd HH:mm:ss")) + ", 120)"
                                '    End If
                                '    strValues = strValues & "~"
                                'End If

                                'strDataValues = strDataValues & Include(i).Value.ToString.Replace("12:00:00 AM", "NULL") & "~"
                                If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                    strCreateTable = strCreateTable & dc.ColumnName & " DATETIME,"
                                End If
                            End Try

                        Case "CORE.FRAMEWORK.CORE.FRAMEWORK.DDECIMAL", "CORE.FRAMEWORK.CORE.FRAMEWORK.DINTEGER",
                            "CORE.WINDOWS.UI.CORE.WINDOWS.COREDECIMAL", "CORE.WINDOWS.UI.CORE.WINDOWS.COREINTEGER"

                            Try
                                ' If we have an integer or decimal in a temp table that is stored in memory,
                                ' save the decimal value ("18,0" for integer, "18,2" if decimal 2, etc.)
                                If SubType = SubFileType.Temp AndAlso Not hasItemCache Then
                                    If _
                                        (Include(i).GetType.ToString.ToUpper = "CORE.WINDOWS.UI.CORE.WINDOWS.COREINTEGER" OrElse
                                         Include(i).GetType.ToString.ToUpper = "CORE.WINDOWS.UI.CORE.WINDOWS.COREDECIMAL" OrElse
                                         Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DDECIMAL" OrElse
                                         Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DINTEGER") _
                                        Then
                                        htDecimals.Add(Include(i).Name.ToString.ToUpper, "18,0")
                                    Else
                                        htDecimals.Add(Include(i).Name.ToString.ToUpper, "18,2")
                                    End If
                                End If

                                If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                    dc = New DataColumn()
                                    dc.ColumnName = Include(i).Name
                                    If (Include(i).GetType.ToString.ToUpper = "CORE.WINDOWS.UI.CORE.WINDOWS.COREINTEGER" OrElse
                                         Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DINTEGER") Then
                                        dc.DataType = Type.GetType("System.Int64")
                                    Else
                                        dc.DataType = Type.GetType("System.Decimal")
                                    End If

                                    If Include(i).Size > 0 Then
                                        If Not hsLenght.Contains(Include(i).Name.ToString.ToLower) Then _
                                            hsLenght.Add(Include(i).Name.ToString.ToLower, Include(i).Size)
                                    End If
                                    dt.Columns.Add(dc)
                                End If

                                strColumns = strColumns & Include(i).Name & m_strDelimiter
                                'If (Include(i).GetType.ToString.ToUpper = "CORE.WINDOWS.UI.CORE.WINDOWS.COREINTEGER" OrElse Include(i).GetType.ToString.ToUpper = "CORE.WINDOWS.UI.CORE.WINDOWS.COREDECIMAL" OrElse Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DDECIMAL" OrElse Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DINTEGER") _
                                ' AndAlso Include(i).IsSubtotal Then
                                '    SubTotalValue = Include(i).SubTotalValue
                                '    If (SubType = SubFileType.Keep AndAlso Not IsKeepText) Then strValues = strValues & SubTotalValue & "~"
                                '    strDataValues = strDataValues & SubTotalValue & "~"
                                'Else
                                '    If (Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DDECIMAL" OrElse Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DINTEGER") AndAlso Include(i).IsMaximum Then
                                '        SubTotalValue = Include(i).MaximumValue
                                '        If SubType = SubFileType.Keep Then strValues = strValues & SubTotalValue & "~"
                                '        strDataValues = strDataValues & SubTotalValue & "~"
                                '    End If
                                '    If (SubType = SubFileType.Keep AndAlso Not IsKeepText) Then strValues = strValues & Include(i).Value & "~"
                                '    strDataValues = strDataValues & Include(i).Value & "~"
                                'End If

                                If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                    If _
                                        (Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DDECIMAL" OrElse
                                         Include(i).GetType.ToString.ToUpper = "CORE.WINDOWS.UI.CORE.WINDOWS.COREDECIMAL") Then
                                        strCreateTable = strCreateTable & dc.ColumnName & " DECIMAL(18,2),"
                                    Else
                                        strCreateTable = strCreateTable & dc.ColumnName & " FLOAT" & ","
                                    End If
                                End If
                            Catch ex As Exception
                                Dim intNextCol As Integer = 2
                                Do While dt.Columns.Contains(Include(i).Name & intNextCol.ToString)
                                    intNextCol = intNextCol + 1
                                Loop

                                dc = New DataColumn()
                                dc.ColumnName = Include(i).Name & intNextCol.ToString
                                dc.DataType = Type.GetType("System.Decimal")
                                If Include(i).Size > 0 Then
                                    If Not hsLenght.Contains(Include(i).Name.ToString.ToLower & intNextCol.ToString) _
                                        Then _
                                        hsLenght.Add(Include(i).Name.ToString.ToLower & intNextCol.ToString,
                                                     Include(i).Size)
                                End If
                                dt.Columns.Add(dc)

                                strColumns = strColumns & Include(i).Name & m_strDelimiter
                                'If (Include(i).GetType.ToString.ToUpper = "CORE.WINDOWS.UI.CORE.WINDOWS.COREINTEGER" OrElse Include(i).GetType.ToString.ToUpper = "CORE.WINDOWS.UI.CORE.WINDOWS.COREDECIMAL" OrElse Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DDECIMAL" OrElse Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DINTEGER") _
                                'AndAlso Include(i).IsSubtotal Then
                                '    SubTotalValue = Include(i).SubTotalValue
                                '    If (SubType = SubFileType.Keep AndAlso Not IsKeepText) Then strValues = strValues & SubTotalValue & "~"
                                '    strDataValues = strDataValues & SubTotalValue & "~"
                                'Else
                                '    If (Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DDECIMAL" OrElse Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DINTEGER") AndAlso Include(i).IsMaximum Then
                                '        SubTotalValue = Include(i).MaximumValue
                                '        If SubType = SubFileType.Keep Then strValues = strValues & SubTotalValue & "~"
                                '        strDataValues = strDataValues & SubTotalValue & "~"
                                '    End If
                                '    If (SubType = SubFileType.Keep AndAlso Not IsKeepText) Then strValues = strValues & Include(i).Value & "~"
                                '    strDataValues = strDataValues & Include(i).Value & "~"
                                'End If

                                If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                    If _
                                        (Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DDECIMAL" OrElse
                                         Include(i).GetType.ToString.ToUpper = "CORE.WINDOWS.UI.CORE.WINDOWS.COREDECIMAL") Then
                                        strCreateTable = strCreateTable & dc.ColumnName & " DECIMAL(18,2),"
                                    Else
                                        strCreateTable = strCreateTable & dc.ColumnName & " FLOAT" & ","
                                    End If
                                End If
                            End Try

                        Case "CORE.FRAMEWORK.CORE.FRAMEWORK.DDATE", "CORE.WINDOWS.UI.CORE.WINDOWS.COREDATE"

                            Try
                                If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                    dc = New DataColumn()
                                    dc.ColumnName = Include(i).Name
                                    dc.DataType = Type.GetType("System.DateTime")
                                    dt.Columns.Add(dc)
                                End If

                                strColumns = strColumns & Include(i).Name & m_strDelimiter

                                'If (SubType = SubFileType.Keep AndAlso Not IsKeepText) Then
                                '    If GetDateFromYYYYMMDDDecimal(Include(i).Value) = cZeroDate Then
                                '        strValues = strValues & "Null"
                                '    Else
                                '        strValues = strValues & "CONVERT(DATETIME, " + StringToField(Format(CDate(GetDateFromYYYYMMDDDecimal(Include(i).Value)), "yyyy-MM-dd HH:mm:ss")) + ", 120)"
                                '    End If
                                '    strValues = strValues & "~"
                                'End If

                                'strDataValues = strDataValues & Include(i).Value & "~"
                                If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                    strCreateTable = strCreateTable & dc.ColumnName & " DATETIME,"
                                End If
                            Catch ex As Exception
                                Dim intNextCol As Integer = 2
                                Do While dt.Columns.Contains(Include(i).Name & intNextCol.ToString)
                                    intNextCol = intNextCol + 1
                                Loop

                                dc = New DataColumn()
                                dc.ColumnName = Include(i).Name & intNextCol.ToString
                                dc.DataType = Type.GetType("System.DateTime")
                                dt.Columns.Add(dc)

                                strColumns = strColumns & Include(i).Name & m_strDelimiter

                                'If (SubType = SubFileType.Keep AndAlso Not IsKeepText) Then
                                '    strValues = strValues & GetDateFromYYYYMMDDDecimal(Include(i).Value).ToString.Replace("12:00:00 AM", "NULL") & "~"
                                '    If GetDateFromYYYYMMDDDecimal(Include(i).Value) = cZeroDate Then
                                '        strValues = strValues & "Null"
                                '    Else
                                '        strValues = strValues & "CONVERT(DATETIME, " + StringToField(Format(CDate(GetDateFromYYYYMMDDDecimal(Include(i).Value)), "yyyy-MM-dd HH:mm:ss")) + ", 120)"
                                '    End If
                                '    strValues = strValues & "~"
                                'End If

                                If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                    strCreateTable = strCreateTable & dc.ColumnName & " DATETIME,"
                                End If
                            End Try
                    End Select

                Next

                'If Not strInsertRowSQL.ToString = "" Then

                'If (SubType = SubFileType.Keep AndAlso Not IsKeepText) Then strValues = strValues.Substring(0, strValues.Length - 1)
                'strDataValues = strDataValues.Substring(0, strDataValues.Length - 1)
                strColumns = ""
                For i As Integer = 0 To dt.Columns.Count - 1
                    If _
                        dt.Columns.Item(i).ColumnName.ToLower <> "row_id" AndAlso
                        dt.Columns.Item(i).ColumnName.ToLower <> "checksum_value" Then
                        strColumns = strColumns & dt.Columns(i).ColumnName & m_strDelimiter
                    End If
                Next

                strColumns = strColumns.Substring(0, strColumns.Length - 1)

                If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                    'create insert sql

                    'strInsertRowSQL.Append("(")
                    'strInsertRowSQL.Append(strColumns)
                    'strInsertRowSQL.Append(")")
                    'strInsertRowSQL.Append(" VALUES ")
                    'strInsertRowSQL.Append("(")
                    'strInsertRowSQL.Append(strValues)
                    'strInsertRowSQL.Append(")")

                Else

                    If Not ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso IsKeepText) Then
                        If Not blnQTPSubFile OrElse blnAppendSubFile Then
                            dc = New DataColumn()
                            dc.ColumnName = "CHECKSUM_VALUE"
                            dc.DataType = Type.GetType("System.Decimal")
                            dt.Columns.Add(dc)
                        End If

                        'build the columns
                        strColumns = strColumns & m_strDelimiter & "CHECKSUM_VALUE"
                        'strDataValues = strDataValues & "~" & "0"

                        If Not blnQTPSubFile OrElse blnAppendSubFile Then
                            dc = New DataColumn()
                            dc.ColumnName = "ROW_ID"
                            dc.DataType = Type.GetType("System.String")
                            dt.Columns.Add(dc)
                        End If

                        'build the columns
                        strColumns = strColumns & m_strDelimiter & "ROW_ID"
                        'strDataValues = strDataValues & "~" & Now.TimeOfDay.TotalMilliseconds.ToString & (intSubFileRow).ToString
                    End If

                    arrColumns = strColumns.Split(m_strDelimiter)
                    'arrValues = strDataValues.Split("~")
                    'rw = dt.NewRow
                    'For j As Integer = 0 To dt.Columns.Count - 1
                    '    If dt.Columns(j).DataType.ToString = "System.DateTime" AndAlso (arrValues(j) = "0" OrElse arrValues(j) = "") Then
                    '    ElseIf dt.Columns(j).DataType.ToString = "System.DateTime" Then
                    '        Dim dateTimeInfo As New DateTime(CInt(arrValues(j).ToString.PadRight(16, "0").Substring(0, 4)), CInt(arrValues(j).ToString.PadRight(16, "0").Substring(4, 2)), CInt(arrValues(j).ToString.PadRight(16, "0").Substring(6, 2)), CInt(arrValues(j).ToString.PadRight(16, "0").Substring(8, 2)), CInt(arrValues(j).ToString.PadRight(16, "0").Substring(10, 2)), CInt(arrValues(j).ToString.PadRight(16, "0").Substring(12, 4)))
                    '        rw.Item(arrColumns(j)) = dateTimeInfo
                    '    Else
                    '        rw.Item(arrColumns(j)) = arrValues(j)
                    '    End If
                    'Next
                    'dt.Rows.Add(rw)

                    strColumns = ""
                End If
                'End If

                'Dim strConnect As String = GetConnectionString()
                If Not blnQTPSubFile Then
                    If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                        strCreateTableSQL.Append("(").Append(" ROWID uniqueidentifier NULL DEFAULT (newid()), ")
                        strCreateTableSQL.Append(strCreateTable).Append(" CHECKSUM_VALUE FLOAT DEFAULT 0 ").Append(")")
                    End If

                    'Check if table already exists
                    Dim blnKeepTable As Boolean
                    If IsNothing(ConfigurationManager.AppSettings("KeepSubFile")) Then
                        blnKeepTable = False
                    Else
                        blnKeepTable = ConfigurationManager.AppSettings("KeepSubFile").ToUpper = "TRUE"
                    End If

                    strSQL = New StringBuilder(String.Empty)
                    strSQL.Append("SELECT * FROM ").Append("").Append("sysobjects WHERE TYPE='U' AND NAME='").
                        Append(strName).Append("'")

                    objReader = SqlHelper.ExecuteReader(strConnect, CommandType.Text, strSQL.ToString)

                    If objReader.Read Then
                        strSQL.Remove(0, strSQL.Length)
                        If strSchema <> "" Then
                            strSQL.Append("DROP TABLE ").Append(strSchema).Append(strName)
                        Else
                            strSQL.Append("DROP TABLE ").Append(strName)
                        End If
                        SqlHelper.ExecuteNonQuery(strConnect, CommandType.Text, strSQL.ToString)
                    End If

                    If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                        'Table does not exists
                        'Create Table
                        SqlHelper.ExecuteNonQuery(strConnect, CommandType.Text, strCreateTableSQL.ToString)
                    End If
                End If

                'If (SubType = SubFileType.Keep AndAlso Not IsKeepText) Then
                '    SqlHelper.ExecuteNonQuery(strConnect, CommandType.Text, strInsertRowSQL.ToString.Replace("~", ","))
                'End If

                If _
                    Not _
                    Session(UniqueSessionID + "hsSubfileKeepText").Contains(strName) _
                    Then
                    Session(UniqueSessionID + "hsSubfileKeepText").Add(strName,
                                                                       hsLenght)
                ElseIf _
                    IsNothing(
                        Session(UniqueSessionID + "hsSubfileKeepText").Item(strName)) _
                    Then
                    Session(UniqueSessionID + "hsSubfileKeepText").Remove(strName)
                    Session(UniqueSessionID + "hsSubfileKeepText").Add(strName,
                                                                       hsLenght)
                End If

                If SubType = SubFileType.TempText OrElse ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso IsKeepText) Then

                    If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not arrKeepFile.Contains(strName) Then
                        arrKeepFile.Add(strName)
                    End If

                    'If dt.Rows.Count > 399 Then
                    '    PutDataTextTable(strName, dt, Session(UniqueSessionID + "hsSubfileKeepText").Item(strName))
                    '    dt.Clear()
                    'End If

                End If

                If SubType = SubFileType.Temp AndAlso Not hasItemCache AndAlso htDecimals.Count > 0 Then
                    Dim OnRemove As CacheItemRemovedCallback = Nothing
                    HttpContext.Current.Cache.Add(strName + "_DataTypes", htDecimals, Nothing, DateTime.Now.AddDays(1),
                                                  TimeSpan.Zero, CacheItemPriority.High, OnRemove)
                End If

                blnQTPSubFile = True

               If (blnDeletedSubFile OrElse Not IsKeepText) AndAlso dt.Rows.Count > 0 Then
                    dt.Rows.RemoveAt(0)
                End If

                If Session(UniqueSessionID + "hsSubfile").Contains(strName) Then
                    Session(UniqueSessionID + "hsSubfile").Item(strName) = dt
                Else
                    Session(UniqueSessionID + "hsSubfile").Add(strName, dt)
                End If

                'AddRecordsRead(strName, 0, LogType.OutPut)
                'AddRecordsRead(strName, 0, LogType.Added)
                AddRecordsProcessed(strName, 0, LogType.Added)

                If Not arrSubFiles.Contains(strName) Then
                    arrSubFiles.Add(strName)
                    If (Not m_hsFileInOutput.Contains(strName)) Then
                        m_hsFileInOutput.Add(strName, strName)
                    End If
                End If

            Catch ex As Exception

                WriteError(ex)

            Finally

                If Not IsNothing(objReader) Then
                    objReader.Close()
                    objReader = Nothing
                End If
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
                If Not IsNothing(dc) Then
                    dc.Dispose()
                    dc = Nothing
                End If
                rw = Nothing
                arrColumns = Nothing
                arrValues = Nothing

                hsLenght = Nothing
                hsSubfileKeepText = Nothing

            End Try
        End Sub

        Public Sub SubFile(ByRef m_trnTRANS_UPDATE As SqlTransaction, ByRef SubfileObject As SqlFileObject,
                           blnCondition As Boolean, SubType As SubFileType, ByVal ParamArray Include() As Object)

            AddRecordsProcessed(SubfileObject.BaseName, SubfileObject.AliasName, 0, LogType.Added)

            If blnCondition OrElse blnDeleteSubFile Then
                If Include(0).GetType.ToString = "Core.Framework.Core.Framework.SubFileMode" Then
                    If Include(0) = SubFileMode.Append Then
                        If Not Session(UniqueSessionID + "hsSubfile").Contains(SubfileObject.BaseName) Then
                            Session(UniqueSessionID + "hsSubfile").Add(SubfileObject.BaseName, Nothing)
                        End If
                    ElseIf Include(0) = SubFileMode.Overwrite Then
                        If Session(UniqueSessionID + "hsSubfile").Contains(SubfileObject.BaseName) Then
                            Session(UniqueSessionID + "hsSubfile").Remove(SubfileObject.BaseName)
                        End If
                    End If
                    If Include(0) = SubFileMode.Append Then blnAppendSubFile = True
                End If
                SubFile(m_trnTRANS_UPDATE, SubfileObject, SubType, Include)
            Else
                If Include(0).GetType.ToString = "Core.Framework.Core.Framework.SubFileMode" Then
                    If Include(0) = SubFileMode.Append Then
                        If Not Session(UniqueSessionID + "hsSubfile").Contains(SubfileObject.BaseName) Then
                            Session(UniqueSessionID + "hsSubfile").Add(SubfileObject.BaseName, Nothing)
                        End If
                    ElseIf Include(0) = SubFileMode.Overwrite Then
                        If Session(UniqueSessionID + "hsSubfile").Contains(SubfileObject.BaseName) Then
                            Session(UniqueSessionID + "hsSubfile").Remove(SubfileObject.BaseName)
                        End If
                    End If
                    If Include(0) = SubFileMode.Append Then blnAppendSubFile = True
                End If
                NoSubFileData = True
                SubFile(m_trnTRANS_UPDATE, SubfileObject, SubType, Include)
                NoSubFileData = False
            End If


        End Sub

        Public Sub SubFile(ByRef m_trnTRANS_UPDATE As SqlTransaction, strName As String, blnAt As Boolean,
                           blnCondition As Boolean, SubType As SubFileType, ByVal ParamArray Include() As Object)

            AddRecordsProcessed(strName, 0, LogType.Added)

            If (blnCondition AndAlso blnAt) OrElse blnDeleteSubFile Then
                If Include(0).GetType.ToString = "Core.Framework.Core.Framework.SubFileMode" Then
                    If Include(0) = SubFileMode.Append Then
                        If Not Session(UniqueSessionID + "hsSubfile").Contains(strName) Then
                            Session(UniqueSessionID + "hsSubfile").Add(strName, Nothing)
                        End If
                    ElseIf Include(0) = SubFileMode.Overwrite Then
                        If Session(UniqueSessionID + "hsSubfile").Contains(strName) Then
                            Session(UniqueSessionID + "hsSubfile").Remove(strName)
                        End If
                    End If
                    If Include(0) = SubFileMode.Append Then blnAppendSubFile = True
                End If
                SubFile(m_trnTRANS_UPDATE, strName, SubType, Include)
            Else
                If Not arrSubFiles.Contains(strName) Then
                    arrSubFiles.Add(strName)
                    If (Not m_hsFileInOutput.Contains(strName)) Then
                        m_hsFileInOutput.Add(strName, strName)
                    End If
                End If
            End If
        End Sub

        Public Sub SubFile(ByRef m_trnTRANS_UPDATE As SqlTransaction, strName As String, blnAt As Boolean,
                           blnCondition As Boolean, SubType As SubFileType, Mode As SubFileMode,
                           ByVal ParamArray Include() As Object)

            AddRecordsProcessed(strName, 0, LogType.Added)

            'If Mode = SubFileMode.Append Then
            '    If Not Session(UniqueSessionID + "hsSubfile").Contains(strName) Then
            '        Session(UniqueSessionID + "hsSubfile").Add(strName, Nothing)
            '    End If
            'ElseIf Mode = SubFileMode.Overwrite Then
            '    If Session(UniqueSessionID + "hsSubfile").Contains(strName) Then
            '        Session(UniqueSessionID + "hsSubfile").Remove(strName)
            '    End If
            'End If

            'If (blnCondition AndAlso blnAt) OrElse blnDeleteSubFile Then
            '    If Mode = SubFileMode.Append Then blnAppendSubFile = True
            '    SubFile(m_trnTRANS_UPDATE, strName, SubType, Include)
            '    blnAppendSubFile = False
            'End If

            If (blnCondition AndAlso blnAt) OrElse blnDeleteSubFile Then
                If Mode = SubFileMode.Append Then
                    If Not Session(UniqueSessionID + "hsSubfile").Contains(strName) Then
                        Session(UniqueSessionID + "hsSubfile").Add(strName, Nothing)
                    End If
                ElseIf Mode = SubFileMode.Overwrite Then
                    If Session(UniqueSessionID + "hsSubfile").Contains(strName) Then
                        Session(UniqueSessionID + "hsSubfile").Remove(strName)
                    End If
                End If

                If Mode = SubFileMode.Append Then blnAppendSubFile = True
                SubFile(m_trnTRANS_UPDATE, strName, SubType, Include)
                blnAppendSubFile = False
            Else
                If Not arrSubFiles.Contains(strName) Then
                    arrSubFiles.Add(strName)
                    If (Not m_hsFileInOutput.Contains(strName)) Then
                        m_hsFileInOutput.Add(strName, strName)
                    End If
                End If
            End If
        End Sub

        Public Sub SubFile(ByRef m_trnTRANS_UPDATE As SqlTransaction, ByRef SubfileObject As SqlFileObject,
                           blnAt As Boolean, blnCondition As Boolean, SubType As SubFileType, Mode As SubFileMode,
                           ByVal ParamArray Include() As Object)

            AddRecordsProcessed(SubfileObject.BaseName, SubfileObject.AliasName, 0, LogType.Added)

            If (blnCondition AndAlso blnAt) OrElse blnDeleteSubFile Then
                If Mode = SubFileMode.Append Then
                    If Not Session(UniqueSessionID + "hsSubfile").Contains(SubfileObject.BaseName) Then
                        Session(UniqueSessionID + "hsSubfile").Add(SubfileObject.BaseName, Nothing)
                    End If
                ElseIf Mode = SubFileMode.Overwrite Then
                    If Session(UniqueSessionID + "hsSubfile").Contains(SubfileObject.BaseName) Then
                        Session(UniqueSessionID + "hsSubfile").Remove(SubfileObject.BaseName)
                    End If
                End If

                If Mode = SubFileMode.Append Then blnAppendSubFile = True
                SubFile(m_trnTRANS_UPDATE, SubfileObject, SubType, Include)
                blnAppendSubFile = False

            Else
                NoSubFileData = True
                If Mode = SubFileMode.Append Then
                    If Not Session(UniqueSessionID + "hsSubfile").Contains(SubfileObject.BaseName) Then
                        Session(UniqueSessionID + "hsSubfile").Add(SubfileObject.BaseName, Nothing)
                    End If
                ElseIf Mode = SubFileMode.Overwrite Then
                    If Session(UniqueSessionID + "hsSubfile").Contains(SubfileObject.BaseName) Then
                        Session(UniqueSessionID + "hsSubfile").Remove(SubfileObject.BaseName)
                    End If
                End If

                If Mode = SubFileMode.Append Then blnAppendSubFile = True
                SubFile(m_trnTRANS_UPDATE, SubfileObject, SubType, Include)
                blnAppendSubFile = False
                NoSubFileData = False
            End If
        End Sub

        Public Sub SubFile(ByRef m_trnTRANS_UPDATE As SqlTransaction, ByRef SubfileObject As SqlFileObject,
                           blnAt As Boolean, blnCondition As Boolean, SubType As SubFileType,
                           ByVal ParamArray Include() As Object)

            AddRecordsProcessed(SubfileObject.BaseName, SubfileObject.AliasName, 0, LogType.Added)

            If (blnCondition AndAlso blnAt) OrElse blnDeleteSubFile Then
                If Include(0).GetType.ToString = "Core.Framework.Core.Framework.SubFileMode" Then
                    If Include(0) = SubFileMode.Append Then
                        If Not Session(UniqueSessionID + "hsSubfile").Contains(SubfileObject.BaseName) Then
                            Session(UniqueSessionID + "hsSubfile").Add(SubfileObject.BaseName, Nothing)
                        End If
                    ElseIf Include(0) = SubFileMode.Overwrite Then
                        If Session(UniqueSessionID + "hsSubfile").Contains(SubfileObject.BaseName) Then
                            Session(UniqueSessionID + "hsSubfile").Remove(SubfileObject.BaseName)
                        End If
                    End If
                    If Include(0) = SubFileMode.Append Then blnAppendSubFile = True
                End If
                SubFile(m_trnTRANS_UPDATE, SubfileObject, SubType, Include)
            Else
                NoSubFileData = True
                If Mode = SubFileMode.Append Then
                    If Not Session(UniqueSessionID + "hsSubfile").Contains(SubfileObject.BaseName) Then
                        Session(UniqueSessionID + "hsSubfile").Add(SubfileObject.BaseName, Nothing)
                    End If
                ElseIf Mode = SubFileMode.Overwrite Then
                    If Session(UniqueSessionID + "hsSubfile").Contains(SubfileObject.BaseName) Then
                        Session(UniqueSessionID + "hsSubfile").Remove(SubfileObject.BaseName)
                    End If
                End If

                If Mode = SubFileMode.Append Then blnAppendSubFile = True
                SubFile(m_trnTRANS_UPDATE, SubfileObject, SubType, Include)
                blnAppendSubFile = False
                NoSubFileData = False
            End If
        End Sub

        Public Sub SubFile(ByRef m_trnTRANS_UPDATE As OracleTransaction, strName As String, SubType As SubFileType,
                           ByVal ParamArray Include() As Object)

            Dim objReader As OracleDataReader
            Dim strSQL As New StringBuilder("")
            Dim strCreateTableSQL As New StringBuilder("")
            Dim strInsertRowSQL As New StringBuilder("")
            Dim intTableCount As Integer = 0
            Dim fleTemp As OracleFileObject
            Dim strColumns As String = String.Empty
            Dim strValues As String = String.Empty
            Dim strDataValues As String = String.Empty
            Dim strCreateTable As String = String.Empty
            Dim strSchema As String = ConfigurationManager.AppSettings("SubFileSchema")
            Dim IsKeepText As Boolean = (ConfigurationManager.AppSettings("SubfileKEEPtoTEXT") & "").ToUpper = "TRUE"
            Dim intSubFileRow As Integer = 0
            Dim SubTotalValue As String = String.Empty
            Dim hsLenght As New Hashtable
            Dim hsSubfileKeepText As SortedList
            hsSubfileKeepText = Session(UniqueSessionID + "hsSubfileKeepText")


            If NoSubFileData Then
                If NoDataSubfile.Contains(strName) Then
                    Return
                End If
                NoDataSubfile.Add(strName)
            End If

            If SubType = SubFileType.KeepText Then
                IsKeepText = True
                SubType = SubFileType.Keep
            End If

            Dim dt As DataTable
            Dim dc As DataColumn
            Dim rw As DataRow
            Dim arrColumns() As String
            Dim arrValues() As String

            If IsKeepText AndAlso SubType <> SubFileType.Keep AndAlso SubType <> SubFileType.Portable Then
                Session(UniqueSessionID + "alSubTempFile").Add(strName & "_" & Session("SessionID"))
            End If

            If SubType = SubFileType.Portable Then
                If IsNothing(Session("PortableSubFiles")) Then
                    Session("PortableSubFiles") = New ArrayList
                    DirectCast(Session("PortableSubFiles"), ArrayList).Add(strName)
                Else
                    If Not DirectCast(Session("PortableSubFiles"), ArrayList).Contains(strName) Then
                        DirectCast(Session("PortableSubFiles"), ArrayList).Add(strName)
                    End If
                End If
            End If

            Dim strSubfileNumeric As String = ConfigurationManager.AppSettings("SubFileNumeric")
            If IsNothing(strSubfileNumeric) Then
                strSubfileNumeric = " FLOAT"
            Else
                strSubfileNumeric = " " & strSubfileNumeric.Trim.ToUpper()
            End If

            If Session(UniqueSessionID + "hsSubfile").Contains(strName) Then
                dt = Session(UniqueSessionID + "hsSubfile").Item(strName)
                blnQTPSubFile = True

                If IsNothing(dt) Then
                    intSubFileRow = 1
                    dt = New DataTable(strName)
                Else
                    intSubFileRow = dt.Rows.Count + 1
                    blnAppendSubFile = False
                End If

            Else
                If SubType = SubFileType.TempText OrElse ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso IsKeepText) Then
                    DeleteDataTextTable(strName, False)
                End If
                dt = New DataTable(strName)
                blnQTPSubFile = False
                intSubFileRow = 1
            End If

            If blnDeleteSubFile Then
                blnDeletedSubFile = True
            End If

            blnHasRunSubfile = True

            Try
                If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                    strCreateTableSQL.Append("CREATE TABLE ")
                    If strSchema <> "" Then
                        strCreateTableSQL.Append(strSchema).Append(strName)
                    Else
                        strCreateTableSQL.Append(strName)
                    End If
                End If

                If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                    strInsertRowSQL.Append(" INSERT INTO ")
                    If strSchema <> "" Then
                        strInsertRowSQL.Append(strSchema).Append(strName)
                    Else
                        strInsertRowSQL.Append(strName)
                    End If
                End If

                'Find the tables and Colunms
                For i As Integer = 0 To Include.Length - 1

                    Select Case Include(i).GetType.ToString.ToUpper

                        Case "CORE.WINDOWS.UI.CORE.WINDOWS.ORACLEFILEOBJECT"
                            intTableCount = intTableCount + 1
                            fleTemp = Include(i)

                            If i = Include.Length - 1 OrElse Include(i + 1).GetType.ToString <> "System.String" Then

                                For j As Integer = 0 To fleTemp.Columns.Count - 1

                                    If _
                                        fleTemp.Columns.Item(j).ColumnName <> "ROW_ID" AndAlso
                                        fleTemp.Columns.Item(j).ColumnName <> "CHECKSUM_VALUE" Then

                                        Select Case fleTemp.GetObjectType(fleTemp.Columns.Item(j).ColumnName)
                                            Case "System.String"

                                                Try
                                                    If Not blnQTPSubFile Then
                                                        dc = New DataColumn()
                                                        dc.ColumnName = fleTemp.Columns.Item(j).ColumnName
                                                        dc.DataType = Type.GetType("System.String")

                                                        If _
                                                            VAL(
                                                                fleTemp.GetObjectSize(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower)) <> 0 _
                                                            Then
                                                            If _
                                                                hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                                hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower) Then
                                                                If _
                                                                    Not _
                                                                    hsLenght.Contains(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower) Then _
                                                                    hsLenght.Add(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower,
                                                                        hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                            fleTemp.Columns.Item(j).ColumnName.ToLower))
                                                                dc.MaxLength =
                                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower)
                                                            Else
                                                                If _
                                                                    Not _
                                                                    hsLenght.Contains(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower) Then _
                                                                    hsLenght.Add(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower,
                                                                        VAL(
                                                                            fleTemp.GetObjectSize(
                                                                                fleTemp.Columns.Item(j).ColumnName.
                                                                                                     ToLower)))
                                                                dc.MaxLength =
                                                                    VAL(
                                                                        fleTemp.GetObjectSize(
                                                                            fleTemp.Columns.Item(j).ColumnName.ToLower))
                                                            End If
                                                        End If

                                                        dt.Columns.Add(dc)
                                                    End If

                                                    'build the columns
                                                    strColumns = strColumns & fleTemp.Columns.Item(j).ColumnName & m_strDelimiter
                                                    If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then _
                                                        strValues = strValues &
                                                                    StringToField(
                                                                        fleTemp.GetStringValue(
                                                                            fleTemp.Columns.Item(j).ColumnName)) & m_strDelimiter
                                                    strDataValues = strDataValues &
                                                                    fleTemp.GetStringValue(
                                                                        fleTemp.Columns.Item(j).ColumnName) & m_strDelimiter
                                                    If _
                                                        Not blnQTPSubFile AndAlso (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso
                                                        Not IsKeepText Then
                                                        strCreateTable = strCreateTable &
                                                                         fleTemp.Columns.Item(j).ColumnName &
                                                                         " VARCHAR("
                                                        strCreateTable = strCreateTable &
                                                                         fleTemp.GetObjectSize(
                                                                             fleTemp.Columns.Item(j).ColumnName) & "),"
                                                    End If

                                                Catch ex As Exception
                                                    Dim intNextCol As Integer = 2
                                                    Do _
                                                        While _
                                                            dt.Columns.Contains(
                                                                fleTemp.Columns.Item(j).ColumnName & intNextCol.ToString)
                                                        intNextCol = intNextCol + 1
                                                    Loop

                                                    dc = New DataColumn()
                                                    dc.ColumnName = fleTemp.Columns.Item(j).ColumnName &
                                                                    intNextCol.ToString
                                                    dc.DataType = Type.GetType("System.String")

                                                    If _
                                                        VAL(
                                                            fleTemp.GetObjectSize(
                                                                fleTemp.Columns.Item(j).ColumnName.ToLower)) <> 0 Then
                                                        If _
                                                            hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                            hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                                fleTemp.Columns.Item(j).ColumnName & intNextCol.ToString) _
                                                            Then
                                                            If _
                                                                Not _
                                                                hsLenght.Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString) Then _
                                                                hsLenght.Add(
                                                                    fleTemp.Columns.Item(j).ColumnName &
                                                                    intNextCol.ToString,
                                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                        fleTemp.Columns.Item(j).ColumnName &
                                                                        intNextCol.ToString))
                                                            dc.MaxLength =
                                                                hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                    fleTemp.Columns.Item(j).ColumnName &
                                                                    intNextCol.ToString)
                                                        ElseIf _
                                                            hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                            hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                                fleTemp.Columns.Item(j).ColumnName) Then
                                                            If _
                                                                Not _
                                                                hsLenght.Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString) Then _
                                                                hsLenght.Add(
                                                                    fleTemp.Columns.Item(j).ColumnName &
                                                                    intNextCol.ToString,
                                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                        fleTemp.Columns.Item(j).ColumnName))
                                                            dc.MaxLength =
                                                                hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                    fleTemp.Columns.Item(j).ColumnName)
                                                        Else
                                                            If _
                                                                Not _
                                                                hsLenght.Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString) Then _
                                                                hsLenght.Add(
                                                                    fleTemp.Columns.Item(j).ColumnName &
                                                                    intNextCol.ToString,
                                                                    VAL(
                                                                        fleTemp.GetObjectSize(
                                                                            fleTemp.Columns.Item(j).ColumnName)))
                                                            dc.MaxLength =
                                                                VAL(
                                                                    fleTemp.GetObjectSize(
                                                                        fleTemp.Columns.Item(j).ColumnName))
                                                        End If
                                                    End If

                                                    dt.Columns.Add(dc)

                                                    'build the columns
                                                    strColumns = strColumns & fleTemp.Columns.Item(j).ColumnName & m_strDelimiter
                                                    If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then _
                                                        strValues = strValues &
                                                                    StringToField(
                                                                        fleTemp.GetStringValue(
                                                                            fleTemp.Columns.Item(j).ColumnName)) & m_strDelimiter
                                                    strDataValues = strDataValues &
                                                                    fleTemp.GetStringValue(
                                                                        fleTemp.Columns.Item(j).ColumnName) & m_strDelimiter
                                                    If _
                                                        Not blnQTPSubFile AndAlso (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso
                                                        Not IsKeepText Then
                                                        strCreateTable = strCreateTable &
                                                                         fleTemp.Columns.Item(j).ColumnName &
                                                                         intNextCol.ToString & " VARCHAR("
                                                        strCreateTable = strCreateTable &
                                                                         fleTemp.GetObjectSize(
                                                                             fleTemp.Columns.Item(j).ColumnName) & "),"
                                                    End If

                                                End Try

                                            Case "System.DateTime"

                                                Try
                                                    If Not blnQTPSubFile Then
                                                        dc = New DataColumn()
                                                        dc.ColumnName = fleTemp.Columns.Item(j).ColumnName
                                                        dc.DataType = Type.GetType("System.DateTime")
                                                        dt.Columns.Add(dc)
                                                    End If

                                                    'build the columns
                                                    strColumns = strColumns & fleTemp.Columns.Item(j).ColumnName & m_strDelimiter
                                                    If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then _
                                                        strValues = strValues &
                                                                    fleTemp.GetNumericDateTimeValue(
                                                                        fleTemp.Columns.Item(j).ColumnName) & m_strDelimiter
                                                    strDataValues = strDataValues &
                                                                    fleTemp.GetNumericDateTimeValue(
                                                                        fleTemp.Columns.Item(j).ColumnName) & m_strDelimiter
                                                    If _
                                                        Not blnQTPSubFile AndAlso (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso
                                                        Not IsKeepText Then
                                                        strCreateTable = strCreateTable &
                                                                         fleTemp.Columns.Item(j).ColumnName &
                                                                         " DATETIME,"
                                                    End If

                                                Catch ex As Exception
                                                    Dim intNextCol As Integer = 2
                                                    Do _
                                                        While _
                                                            dt.Columns.Contains(
                                                                fleTemp.Columns.Item(j).ColumnName & intNextCol.ToString)
                                                        intNextCol = intNextCol + 1
                                                    Loop

                                                    dc = New DataColumn()
                                                    dc.ColumnName = fleTemp.Columns.Item(j).ColumnName &
                                                                    intNextCol.ToString
                                                    dc.DataType = Type.GetType("System.DateTime")
                                                    dt.Columns.Add(dc)

                                                    'build the columns
                                                    strColumns = strColumns & fleTemp.Columns.Item(j).ColumnName & m_strDelimiter
                                                    If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then _
                                                        strValues = strValues &
                                                                    fleTemp.GetNumericDateTimeValue(
                                                                        fleTemp.Columns.Item(j).ColumnName) & m_strDelimiter
                                                    strDataValues = strDataValues &
                                                                    fleTemp.GetNumericDateTimeValue(
                                                                        fleTemp.Columns.Item(j).ColumnName) & m_strDelimiter
                                                    If _
                                                        Not blnQTPSubFile AndAlso (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso
                                                        Not IsKeepText Then
                                                        strCreateTable = strCreateTable &
                                                                         fleTemp.Columns.Item(j).ColumnName &
                                                                         intNextCol.ToString & " DATETIME,"
                                                    End If

                                                End Try

                                            Case "System.Decimal", "System.Double", "System.Int32", "System.Int64",
                                                "System.Single"

                                                Try
                                                    If Not blnQTPSubFile Then
                                                        dc = New DataColumn()
                                                        dc.ColumnName = fleTemp.Columns.Item(j).ColumnName
                                                        dc.DataType = Type.GetType("System.Decimal")
                                                        If _
                                                            VAL(
                                                                fleTemp.GetObjectSize(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower)) <> 0 _
                                                            Then
                                                            If _
                                                                hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                                hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower) Then
                                                                If _
                                                                    Not _
                                                                    hsLenght.Contains(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower) Then _
                                                                    hsLenght.Add(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower,
                                                                        hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                            fleTemp.Columns.Item(j).ColumnName.ToLower))
                                                            Else
                                                                If _
                                                                    Not _
                                                                    hsLenght.Contains(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower) Then _
                                                                    hsLenght.Add(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower,
                                                                        VAL(
                                                                            fleTemp.GetObjectSize(
                                                                                fleTemp.Columns.Item(j).ColumnName.
                                                                                                     ToLower)))
                                                            End If
                                                        End If
                                                        dt.Columns.Add(dc)
                                                    End If

                                                    'build the columns
                                                    strColumns = strColumns & fleTemp.Columns.Item(j).ColumnName & m_strDelimiter
                                                    If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then _
                                                        strValues = strValues &
                                                                    fleTemp.GetDecimalValue(
                                                                        fleTemp.Columns.Item(j).ColumnName) & m_strDelimiter
                                                    strDataValues = strDataValues &
                                                                    fleTemp.GetDecimalValue(
                                                                        fleTemp.Columns.Item(j).ColumnName) & m_strDelimiter
                                                    If _
                                                        Not blnQTPSubFile AndAlso (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso
                                                        Not IsKeepText Then
                                                        strCreateTable = strCreateTable &
                                                                         fleTemp.Columns.Item(j).ColumnName &
                                                                         strSubfileNumeric & ","
                                                    End If

                                                Catch ex As Exception
                                                    Dim intNextCol As Integer = 2
                                                    Do _
                                                        While _
                                                            dt.Columns.Contains(
                                                                fleTemp.Columns.Item(j).ColumnName & intNextCol.ToString)
                                                        intNextCol = intNextCol + 1
                                                    Loop

                                                    dc = New DataColumn()
                                                    dc.ColumnName = fleTemp.Columns.Item(j).ColumnName &
                                                                    intNextCol.ToString
                                                    dc.DataType = Type.GetType("System.Decimal")
                                                    If _
                                                        VAL(
                                                            fleTemp.GetObjectSize(
                                                                fleTemp.Columns.Item(j).ColumnName.ToLower)) <> 0 Then
                                                        If _
                                                            hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                            hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                                fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                intNextCol.ToString) Then
                                                            If _
                                                                Not _
                                                                hsLenght.Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString) Then _
                                                                hsLenght.Add(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString,
                                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                        intNextCol.ToString))
                                                        ElseIf _
                                                            hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                            hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                                fleTemp.Columns.Item(j).ColumnName.ToLower) Then
                                                            If _
                                                                Not _
                                                                hsLenght.Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString) Then _
                                                                hsLenght.Add(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString,
                                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower))
                                                        Else
                                                            If _
                                                                Not _
                                                                hsLenght.Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString) Then _
                                                                hsLenght.Add(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString,
                                                                    VAL(
                                                                        fleTemp.GetObjectSize(
                                                                            fleTemp.Columns.Item(j).ColumnName.ToLower)))
                                                        End If
                                                    End If
                                                    dt.Columns.Add(dc)

                                                    'build the columns
                                                    strColumns = strColumns & fleTemp.Columns.Item(j).ColumnName & m_strDelimiter
                                                    If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then _
                                                        strValues = strValues &
                                                                    fleTemp.GetDecimalValue(
                                                                        fleTemp.Columns.Item(j).ColumnName) & m_strDelimiter
                                                    strDataValues = strDataValues &
                                                                    fleTemp.GetDecimalValue(
                                                                        fleTemp.Columns.Item(j).ColumnName) & m_strDelimiter
                                                    If _
                                                        Not blnQTPSubFile AndAlso (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso
                                                        Not IsKeepText Then
                                                        strCreateTable = strCreateTable &
                                                                         fleTemp.Columns.Item(j).ColumnName &
                                                                         intNextCol.ToString & strSubfileNumeric & ","
                                                    End If
                                                End Try

                                        End Select

                                    End If

                                Next

                            End If

                        Case "SYSTEM.STRING"

                            'build the Values
                            Select Case fleTemp.GetObjectType(Include(i))

                                Case ""
                                    Dim message As String = "Error on subfile : " + strName + ". Column '" + Include(i) + "' from Table '" + fleTemp.BaseName + "' does not exist."
                                    Dim ex As CustomApplicationException = New CustomApplicationException(message)
                                    Throw ex

                                Case "System.String"

                                    Try
                                        If Not blnQTPSubFile AndAlso Not dt.Columns.Contains(Include(i)) Then
                                            dc = New DataColumn()
                                            dc.ColumnName = Include(i)
                                            dc.DataType = Type.GetType("System.String")

                                            If fleTemp.GetObjectSize(Include(i).ToString).Trim <> "" Then

                                                If _
                                                    hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                        Include(i).ToString.ToLower.ToLower) Then
                                                    If Not hsLenght.Contains(Include(i).ToString.ToLower) Then _
                                                        hsLenght.Add(Include(i).ToString.ToLower,
                                                                     hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                         Include(i).ToString.ToLower.ToLower))
                                                    dc.MaxLength =
                                                        hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                            Include(i).ToString.ToLower.ToLower)
                                                Else
                                                    If Not hsLenght.Contains(Include(i).ToString.ToLower) Then _
                                                        hsLenght.Add(Include(i).ToString.ToLower,
                                                                     CInt(fleTemp.GetObjectSize(Include(i).ToString)))
                                                    dc.MaxLength = CInt(fleTemp.GetObjectSize(Include(i).ToString))
                                                End If

                                            End If

                                            dt.Columns.Add(dc)
                                        End If

                                        'build the columns
                                        strColumns = strColumns & Include(i) & m_strDelimiter
                                        If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then _
                                            strValues = strValues & StringToField(fleTemp.GetStringValue(Include(i))) &
                                                        m_strDelimiter
                                        strDataValues = strDataValues & fleTemp.GetStringValue(Include(i)) & m_strDelimiter
                                        If Not blnQTPSubFile AndAlso (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText _
                                            Then
                                            strCreateTable = strCreateTable & Include(i) & " VARCHAR("
                                            strCreateTable = strCreateTable & fleTemp.GetObjectSize(Include(i)) & "),"
                                        End If
                                    Catch ex As Exception
                                        Dim intNextCol As Integer = 2
                                        Do While dt.Columns.Contains(Include(i) & intNextCol.ToString)
                                            intNextCol = intNextCol + 1
                                        Loop

                                        dc = New DataColumn()
                                        dc.ColumnName = Include(i) & intNextCol.ToString
                                        dc.DataType = Type.GetType("System.String")
                                        If fleTemp.GetObjectSize(Include(i).ToString).Trim <> "" Then

                                            If _
                                                hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                    Include(i).ToString.ToLower.ToLower & intNextCol.ToString) Then
                                                If _
                                                    Not _
                                                    hsLenght.Contains(Include(i).ToString.ToLower & intNextCol.ToString) _
                                                    Then _
                                                    hsLenght.Add(Include(i).ToString.ToLower & intNextCol.ToString,
                                                                 hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                     Include(i).ToString.ToLower.ToLower &
                                                                     intNextCol.ToString))
                                                dc.MaxLength =
                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                        Include(i).ToString.ToLower.ToLower)
                                            ElseIf _
                                                hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                    Include(i).ToString.ToLower.ToLower) Then
                                                If _
                                                    Not _
                                                    hsLenght.Contains(Include(i).ToString.ToLower & intNextCol.ToString) _
                                                    Then _
                                                    hsLenght.Add(Include(i).ToString.ToLower & intNextCol.ToString,
                                                                 hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                     Include(i).ToString.ToLower.ToLower))
                                                dc.MaxLength =
                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                        Include(i).ToString.ToLower.ToLower)
                                            Else
                                                If _
                                                    Not _
                                                    hsLenght.Contains(Include(i).ToString.ToLower & intNextCol.ToString) _
                                                    Then _
                                                    hsLenght.Add(Include(i).ToString.ToLower & intNextCol.ToString,
                                                                 CInt(fleTemp.GetObjectSize(Include(i).ToString)))
                                                dc.MaxLength = CInt(fleTemp.GetObjectSize(Include(i).ToString))
                                            End If

                                        End If

                                        dt.Columns.Add(dc)

                                        'build the columns
                                        strColumns = strColumns & Include(i) & m_strDelimiter
                                        If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then _
                                            strValues = strValues & StringToField(fleTemp.GetStringValue(Include(i))) &
                                                        m_strDelimiter
                                        strDataValues = strDataValues & fleTemp.GetStringValue(Include(i)) & m_strDelimiter
                                        If Not blnQTPSubFile AndAlso (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText _
                                            Then
                                            strCreateTable = strCreateTable & Include(i) & intNextCol.ToString &
                                                             " VARCHAR("
                                            strCreateTable = strCreateTable & fleTemp.GetObjectSize(Include(i)) & "),"
                                        End If
                                    End Try

                                Case "System.DateTime"

                                    Try
                                        If Not blnQTPSubFile AndAlso Not dt.Columns.Contains(Include(i)) Then
                                            dc = New DataColumn()
                                            dc.ColumnName = Include(i)
                                            dc.DataType = Type.GetType("System.DateTime")
                                            dt.Columns.Add(dc)
                                        End If

                                        'build the columns
                                        strColumns = strColumns & Include(i) & m_strDelimiter
                                        If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then _
                                            strValues = strValues & fleTemp.GetDateValue(Include(i)) & m_strDelimiter
                                        strDataValues = fleTemp.GetNumericDateTimeValue(Include(i)) & m_strDelimiter
                                        If Not blnQTPSubFile AndAlso (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText _
                                            Then
                                            strCreateTable = strCreateTable & Include(i) & " DATETIME,"
                                        End If
                                    Catch ex As Exception
                                        Dim intNextCol As Integer = 2
                                        Do While dt.Columns.Contains(Include(i) & intNextCol.ToString)
                                            intNextCol = intNextCol + 1
                                        Loop

                                        dc = New DataColumn()
                                        dc.ColumnName = Include(i) & intNextCol.ToString
                                        dc.DataType = Type.GetType("System.DateTime")
                                        dt.Columns.Add(dc)

                                        'build the columns
                                        strColumns = strColumns & Include(i) & m_strDelimiter
                                        If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then _
                                            strValues = strValues & fleTemp.GetDateValue(Include(i)) & m_strDelimiter
                                        strDataValues = fleTemp.GetNumericDateTimeValue(Include(i)) & m_strDelimiter
                                        If Not blnQTPSubFile AndAlso (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText _
                                            Then
                                            strCreateTable = strCreateTable & Include(i) & intNextCol.ToString &
                                                             " DATETIME,"
                                        End If
                                    End Try

                                Case "System.Decimal", "System.Double", "System.Int32", "System.Int64", "System.Single"

                                    Try
                                        If Not blnQTPSubFile AndAlso Not dt.Columns.Contains(Include(i)) Then
                                            dc = New DataColumn()
                                            dc.ColumnName = Include(i)
                                            dc.DataType = Type.GetType("System.Decimal")
                                            If fleTemp.GetObjectSize(Include(i).ToString).Trim <> "" Then
                                                If _
                                                    hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                        Include(i).ToString.ToLower.ToLower) Then
                                                    If Not hsLenght.Contains(Include(i).ToString.ToLower) Then _
                                                        hsLenght.Add(Include(i).ToString.ToLower,
                                                                     hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                         Include(i).ToString.ToLower.ToLower))
                                                Else
                                                    If Not hsLenght.Contains(Include(i).ToString.ToLower) Then _
                                                        hsLenght.Add(Include(i).ToString.ToLower,
                                                                     CInt(fleTemp.GetObjectSize(Include(i).ToString)))
                                                End If
                                            End If
                                            dt.Columns.Add(dc)
                                        End If

                                        'build the columns
                                        strColumns = strColumns & Include(i) & m_strDelimiter
                                        If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then _
                                            strValues = strValues & fleTemp.GetDecimalValue(Include(i)) & m_strDelimiter
                                        strDataValues = strDataValues & fleTemp.GetDecimalValue(Include(i)) & m_strDelimiter
                                        If Not blnQTPSubFile AndAlso (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText _
                                            Then
                                            strCreateTable = strCreateTable & Include(i) & strSubfileNumeric & ","
                                        End If

                                    Catch ex As Exception
                                        Dim intNextCol As Integer = 2
                                        Do While dt.Columns.Contains(Include(i) & intNextCol.ToString)
                                            intNextCol = intNextCol + 1
                                        Loop

                                        dc = New DataColumn()
                                        dc.ColumnName = Include(i) & intNextCol.ToString
                                        dc.DataType = Type.GetType("System.Decimal")
                                        If fleTemp.GetObjectSize(Include(i).ToString).Trim <> "" Then
                                            If _
                                                hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                    Include(i).ToString.ToLower.ToLower & intNextCol.ToString) Then
                                                If _
                                                    Not _
                                                    hsLenght.Contains(Include(i).ToString.ToLower & intNextCol.ToString) _
                                                    Then _
                                                    hsLenght.Add(Include(i).ToString.ToLower & intNextCol.ToString,
                                                                 hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                     Include(i).ToString.ToLower.ToLower &
                                                                     intNextCol.ToString))
                                            ElseIf _
                                                hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                    Include(i).ToString.ToLower.ToLower) Then
                                                If _
                                                    Not _
                                                    hsLenght.Contains(Include(i).ToString.ToLower & intNextCol.ToString) _
                                                    Then _
                                                    hsLenght.Add(Include(i).ToString.ToLower & intNextCol.ToString,
                                                                 hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                     Include(i).ToString.ToLower.ToLower))
                                            Else
                                                If _
                                                    Not _
                                                    hsLenght.Contains(Include(i).ToString.ToLower & intNextCol.ToString) _
                                                    Then _
                                                    hsLenght.Add(Include(i).ToString.ToLower & intNextCol.ToString,
                                                                 CInt(fleTemp.GetObjectSize(Include(i).ToString)))
                                            End If
                                        End If
                                        dt.Columns.Add(dc)

                                        'build the columns
                                        strColumns = strColumns & Include(i) & m_strDelimiter
                                        If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then _
                                            strValues = strValues & fleTemp.GetDecimalValue(Include(i)) & m_strDelimiter
                                        strDataValues = strDataValues & fleTemp.GetDecimalValue(Include(i)) & m_strDelimiter
                                        If Not blnQTPSubFile AndAlso (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText _
                                            Then
                                            strCreateTable = strCreateTable & Include(i) & intNextCol.ToString &
                                                             strSubfileNumeric & ","
                                        End If
                                    End Try

                            End Select

                        Case "CORE.FRAMEWORK.CORE.FRAMEWORK.DCHARACTER", "CORE.FRAMEWORK.CORE.FRAMEWORK.DVARCHAR",
                            "CORE.WINDOWS.UI.CORE.WINDOWS.CORECHARACTER", "CORE.WINDOWS.UI.CORE.WINDOWS.COREDATE"

                            Try
                                If Not blnQTPSubFile AndAlso Not dt.Columns.Contains(Include(i).Name) Then
                                    dc = New DataColumn()
                                    dc.ColumnName = Include(i).Name
                                    dc.DataType = Type.GetType("System.String")
                                    If Include(i).Size > 0 Then
                                        dc.MaxLength = Include(i).Size
                                        If Not hsLenght.Contains(Include(i).Name.ToString.ToLower) Then _
                                            hsLenght.Add(Include(i).Name.ToString.ToLower, Include(i).Size)
                                    End If
                                    dt.Columns.Add(dc)
                                End If

                                strColumns = strColumns & Include(i).Name & m_strDelimiter
                                If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then _
                                    strValues = strValues & StringToField(Include(i).Value) & m_strDelimiter
                                strDataValues = strDataValues & Include(i).Value & m_strDelimiter
                                If Not blnQTPSubFile AndAlso (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then
                                    strCreateTable = strCreateTable & Include(i).Name & " VARCHAR("
                                    strCreateTable = strCreateTable & Include(i).Size & "),"
                                End If
                            Catch ex As Exception
                                Dim intNextCol As Integer = 2
                                Do While dt.Columns.Contains(Include(i).Name & intNextCol.ToString)
                                    intNextCol = intNextCol + 1
                                Loop

                                dc = New DataColumn()
                                dc.ColumnName = Include(i).Name & intNextCol.ToString
                                dc.DataType = Type.GetType("System.String")
                                If Include(i).Size > 0 Then
                                    dc.MaxLength = Include(i).Size
                                    If Not hsLenght.Contains(Include(i).Name.ToString.ToLower & intNextCol.ToString) _
                                        Then _
                                        hsLenght.Add(Include(i).Name.ToString.ToLower & intNextCol.ToString,
                                                     Include(i).Size)
                                End If
                                dt.Columns.Add(dc)

                                strColumns = strColumns & Include(i).Name & m_strDelimiter
                                If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then _
                                    strValues = strValues & StringToField(Include(i).Value) & m_strDelimiter
                                strDataValues = strDataValues & Include(i).Value & m_strDelimiter
                                If Not blnQTPSubFile AndAlso (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then
                                    strCreateTable = strCreateTable & Include(i).Name & intNextCol.ToString &
                                                     " VARCHAR("
                                    strCreateTable = strCreateTable & Include(i).Size & "),"
                                End If
                            End Try

                        Case "CORE.FRAMEWORK.CORE.FRAMEWORK.DDECIMAL", "CORE.FRAMEWORK.CORE.FRAMEWORK.DINTEGER",
                            "CORE.WINDOWS.UI.CORE.WINDOWS.COREDECIMAL", "CORE.WINDOWS.UI.CORE.WINDOWS.COREINTEGER"

                            Try
                                If Not blnQTPSubFile AndAlso Not dt.Columns.Contains(Include(i).Name) Then
                                    dc = New DataColumn()
                                    dc.ColumnName = Include(i).Name
                                    If (Include(i).GetType.ToString.ToUpper = "CORE.WINDOWS.UI.CORE.WINDOWS.COREINTEGER" OrElse
                                          Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DINTEGER") Then
                                        dc.DataType = Type.GetType("System.Int64")
                                    Else
                                        dc.DataType = Type.GetType("System.Decimal")
                                    End If
                                    If Include(i).Size > 0 Then
                                        If Not hsLenght.Contains(Include(i).Name.ToString.ToLower) Then _
                                            hsLenght.Add(Include(i).Name.ToString.ToLower, Include(i).Size)
                                    End If
                                    dt.Columns.Add(dc)
                                End If

                                strColumns = strColumns & Include(i).Name & m_strDelimiter
                                If _
                                    (Include(i).GetType.ToString.ToUpper = "CORE.WINDOWS.UI.CORE.WINDOWS.COREINTEGER" OrElse
                                     Include(i).GetType.ToString.ToUpper = "CORE.WINDOWS.UI.CORE.WINDOWS.COREDECIMAL" OrElse
                                     Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DDECIMAL" OrElse
                                     Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DINTEGER") _
                                    AndAlso Include(i).IsSubtotal Then
                                    SubTotalValue = Include(i).SubTotalValue
                                    If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then _
                                        strValues = strValues & SubTotalValue & m_strDelimiter
                                    strDataValues = strDataValues & SubTotalValue & m_strDelimiter
                                Else
                                    If _
                                        (Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DDECIMAL" OrElse
                                         Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DINTEGER") AndAlso
                                        Include(i).IsMaximum Then
                                        SubTotalValue = Include(i).MaximumValue
                                        If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then _
                                            strValues = strValues & SubTotalValue & m_strDelimiter
                                        strDataValues = strDataValues & SubTotalValue & m_strDelimiter
                                    End If
                                    If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then _
                                        strValues = strValues & Include(i).Value & m_strDelimiter
                                    strDataValues = strDataValues & Include(i).Value & m_strDelimiter
                                End If
                                If Not blnQTPSubFile AndAlso (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then
                                    strCreateTable = strCreateTable & Include(i).Name & strSubfileNumeric & ","
                                End If

                            Catch ex As Exception
                                Dim intNextCol As Integer = 2
                                Do While dt.Columns.Contains(Include(i).Name & intNextCol.ToString)
                                    intNextCol = intNextCol + 1
                                Loop

                                dc = New DataColumn()
                                dc.ColumnName = Include(i).Name & intNextCol.ToString
                                dc.DataType = Type.GetType("System.Decimaling")
                                If Include(i).Size > 0 Then
                                    If Not hsLenght.Contains(Include(i).Name.ToString.ToLower & intNextCol.ToString) _
                                        Then _
                                        hsLenght.Add(Include(i).Name.ToString.ToLower & intNextCol.ToString,
                                                     Include(i).Size)
                                End If
                                dt.Columns.Add(dc)

                                strColumns = strColumns & Include(i).Name & m_strDelimiter
                                If _
                                    (Include(i).GetType.ToString.ToUpper = "CORE.WINDOWS.UI.CORE.WINDOWS.COREINTEGER" OrElse
                                     Include(i).GetType.ToString.ToUpper = "CORE.WINDOWS.UI.CORE.WINDOWS.COREDECIMAL" OrElse
                                     Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DDECIMAL" OrElse
                                     Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DINTEGER") _
                                    AndAlso Include(i).IsSubtotal Then
                                    SubTotalValue = Include(i).SubTotalValue
                                    If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then _
                                        strValues = strValues & SubTotalValue & m_strDelimiter
                                    strDataValues = strDataValues & SubTotalValue & m_strDelimiter
                                Else
                                    If _
                                        (Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DDECIMAL" OrElse
                                         Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DINTEGER") AndAlso
                                        Include(i).IsMaximum Then
                                        SubTotalValue = Include(i).MaximumValue
                                        If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then _
                                            strValues = strValues & SubTotalValue & m_strDelimiter
                                        strDataValues = strDataValues & SubTotalValue & m_strDelimiter
                                    End If
                                    If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then _
                                        strValues = strValues & Include(i).Value & m_strDelimiter
                                    strDataValues = strDataValues & Include(i).Value & m_strDelimiter
                                End If
                                If Not blnQTPSubFile AndAlso (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then
                                    strCreateTable = strCreateTable & Include(i).Name & intNextCol.ToString &
                                                     strSubfileNumeric & ","
                                End If
                            End Try

                        Case "CORE.FRAMEWORK.CORE.FRAMEWORK.DDATE", "CORE.WINDOWS.UI.CORE.WINDOWS.COREDATE"

                            Try
                                If Not blnQTPSubFile AndAlso Not dt.Columns.Contains(Include(i).Name) Then
                                    dc = New DataColumn()
                                    dc.ColumnName = Include(i)
                                    dc.DataType = Type.GetType("System.DateTime")
                                    dt.Columns.Add(dc)
                                End If

                                strColumns = strColumns & Include(i).Name & m_strDelimiter
                                If _
                                    (Include(i).GetType.ToString.ToUpper = "CORE.WINDOWS.UI.CORE.WINDOWS.COREINTEGER" OrElse
                                     Include(i).GetType.ToString.ToUpper = "CORE.WINDOWS.UI.CORE.WINDOWS.COREDECIMAL" OrElse
                                     Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DDECIMAL" OrElse
                                     Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DINTEGER") _
                                    AndAlso Include(i).IsSubtotal Then
                                    SubTotalValue = Include(i).SubTotalValue
                                    If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then _
                                        strValues = strValues & SubTotalValue & m_strDelimiter
                                    strDataValues = strDataValues & SubTotalValue & m_strDelimiter
                                Else
                                    If _
                                        (Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DDECIMAL" OrElse
                                         Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DINTEGER") AndAlso
                                        Include(i).IsMaximum Then
                                        SubTotalValue = Include(i).MaximumValue
                                        If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then _
                                            strValues = strValues & SubTotalValue & m_strDelimiter
                                        strDataValues = strDataValues & SubTotalValue & m_strDelimiter
                                    End If
                                    If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then _
                                        strValues = strValues & Include(i).Value & m_strDelimiter
                                    strDataValues = strDataValues & Include(i).Value & m_strDelimiter
                                End If
                                If Not blnQTPSubFile AndAlso (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then
                                    strCreateTable = strCreateTable & Include(i).Name & " DATETIME,"
                                End If
                            Catch ex As Exception
                                Dim intNextCol As Integer = 2
                                Do While dt.Columns.Contains(Include(i).Name & intNextCol.ToString)
                                    intNextCol = intNextCol + 1
                                Loop

                                dc = New DataColumn()
                                dc.ColumnName = Include(i).Name & intNextCol.ToString
                                dc.DataType = Type.GetType("System.DateTime")
                                dt.Columns.Add(dc)

                                strColumns = strColumns & Include(i).Name & m_strDelimiter
                                If _
                                    (Include(i).GetType.ToString.ToUpper = "CORE.WINDOWS.UI.CORE.WINDOWS.COREINTEGER" OrElse
                                     Include(i).GetType.ToString.ToUpper = "CORE.WINDOWS.UI.CORE.WINDOWS.COREDECIMAL" OrElse
                                     Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DDECIMAL" OrElse
                                     Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DINTEGER") _
                                    AndAlso Include(i).IsSubtotal Then
                                    SubTotalValue = Include(i).SubTotalValue
                                    If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then _
                                        strValues = strValues & SubTotalValue & m_strDelimiter
                                    strDataValues = strDataValues & SubTotalValue & m_strDelimiter
                                Else
                                    If _
                                        (Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DDECIMAL" OrElse
                                         Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DINTEGER") AndAlso
                                        Include(i).IsMaximum Then
                                        SubTotalValue = Include(i).MaximumValue
                                        If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then _
                                            strValues = strValues & SubTotalValue & m_strDelimiter
                                        strDataValues = strDataValues & SubTotalValue & m_strDelimiter
                                    End If
                                    If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then _
                                        strValues = strValues & Include(i).Value & m_strDelimiter
                                    strDataValues = strDataValues & Include(i).Value & m_strDelimiter
                                End If
                                If Not blnQTPSubFile AndAlso (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then
                                    strCreateTable = strCreateTable & Include(i).Name & intNextCol.ToString &
                                                     " DATETIME,"
                                End If
                            End Try
                    End Select

                Next

                'If Not strInsertRowSQL.ToString = "" Then

                If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then _
                    strValues = strValues.Substring(0, strValues.Length - 1)
                strDataValues = strDataValues.Substring(0, strDataValues.Length - 1)

                strColumns = ""
                For i As Integer = 0 To dt.Columns.Count - 1
                    If _
                        dt.Columns.Item(i).ColumnName.ToLower <> "row_id" AndAlso
                        dt.Columns.Item(i).ColumnName.ToLower <> "checksum_value" Then
                        strColumns = strColumns & dt.Columns(i).ColumnName & m_strDelimiter
                    End If
                Next

                strColumns = strColumns.Substring(0, strColumns.Length - 1)

                strColumns.Remove(strColumns.Length - 1, 1)

                If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then
                    'create insert sql

                    strInsertRowSQL.Append("(")
                    strInsertRowSQL.Append(strColumns)
                    strInsertRowSQL.Append(")")
                    strInsertRowSQL.Append(" VALUES ")
                    strInsertRowSQL.Append("(")
                    strInsertRowSQL.Append(strValues)
                    strInsertRowSQL.Append(")")

                Else
                    If Not blnQTPSubFile Then
                        dc = New DataColumn()
                        dc.ColumnName = "CHECKSUM_VALUE"
                        dc.DataType = Type.GetType("System.Decimal")
                        dt.Columns.Add(dc)
                    End If

                    'build the columns
                    strColumns = strColumns & m_strDelimiter & "CHECKSUM_VALUE"
                    'strValues = strValues & "~" & "0" ' Not used
                    strDataValues = strDataValues & m_strDelimiter & "0"

                    If Not blnQTPSubFile Then
                        dc = New DataColumn()
                        dc.ColumnName = "ROW_ID"
                        dc.DataType = Type.GetType("System.String")
                        dt.Columns.Add(dc)
                    End If

                    'build the columns
                    strColumns = strColumns & m_strDelimiter & "ROW_ID"
                    'strValues = strValues & "~" & StringToField(Now.TimeOfDay.TotalMilliseconds.ToString & (intSubFileRow).ToString) ' Not used
                    strDataValues = strDataValues & m_strDelimiter & Now.TimeOfDay.TotalMilliseconds.ToString &
                                    (intSubFileRow).ToString

                    arrColumns = strColumns.Split(m_strDelimiter)
                    arrValues = strDataValues.Split(m_strDelimiter)
                    rw = dt.NewRow
                    For j As Integer = 0 To dt.Columns.Count - 1
                        If _
                            dt.Columns(j).DataType.ToString = "System.DateTime" AndAlso
                            (arrValues(j) = "0" OrElse arrValues(j) = "") Then
                        ElseIf dt.Columns(j).DataType.ToString = "System.DateTime" Then
                            Dim _
                                dateTimeInfo As _
                                    New DateTime(CInt(arrValues(j).ToString.PadRight(16, "0").Substring(0, 4)),
                                                 CInt(arrValues(j).ToString.PadRight(16, "0").Substring(4, 2)),
                                                 CInt(arrValues(j).ToString.PadRight(16, "0").Substring(6, 2)),
                                                 CInt(arrValues(j).ToString.PadRight(16, "0").Substring(8, 2)),
                                                 CInt(arrValues(j).ToString.PadRight(16, "0").Substring(10, 2)),
                                                 CInt(arrValues(j).ToString.PadRight(16, "0").Substring(12, 4)))
                            rw.Item(arrColumns(j)) = dateTimeInfo
                        Else
                            rw.Item(arrColumns(j)) = arrValues(j)
                        End If
                    Next
                    dt.Rows.Add(rw)
                    'strValues = "" ' Not used
                    strColumns = ""
                End If

                'End If

                If Not blnQTPSubFile Then
                    If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then
                        strCreateTableSQL.Append("(").Append(strCreateTable).Append(" CHECKSUM_VALUE NUMBER ").Append(
                            ")")
                    End If

                    'Check if table already exists
                    Dim blnKeepTable As Boolean
                    If IsNothing(ConfigurationManager.AppSettings("KeepSubFile")) Then
                        blnKeepTable = False
                    Else
                        blnKeepTable = ConfigurationManager.AppSettings("KeepSubFile").ToUpper = "TRUE"
                    End If

                    strSQL = New StringBuilder(String.Empty)
                    If strSchema <> "" Then
                        strSQL.Append("SELECT * from ALL_TABLES WHERE TABLE_NAME = '").Append(strName).Append(
                            "' AND OWNER = ").Append(StringToField(strSchema))
                    Else
                        strSQL.Append("SELECT * from ALL_TABLES WHERE TABLE_NAME = '").Append(strName).Append(
                            "' AND OWNER = USER ")
                    End If

                    objReader = OracleHelper.ExecuteReader(m_trnTRANS_UPDATE, CommandType.Text, strSQL.ToString)

                    If objReader.Read Then
                        strSQL.Remove(0, strSQL.Length)
                        If strSchema <> "" Then
                            strSQL.Append("DROP TABLE ").Append(strSchema).Append(".").Append(strName)
                        Else
                            strSQL.Append("DROP TABLE ").Append(strName)
                        End If
                        OracleHelper.ExecuteNonQuery(m_trnTRANS_UPDATE, CommandType.Text, strSQL.ToString)
                    End If

                    If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then
                        'Table does not exists
                        'Create Table
                        OracleHelper.ExecuteNonQuery(m_trnTRANS_UPDATE, CommandType.Text, strCreateTableSQL.ToString)
                    End If
                End If

                If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText Then

                    OracleHelper.ExecuteNonQuery(m_trnTRANS_UPDATE, CommandType.Text,
                                                 strInsertRowSQL.ToString.Replace(m_strDelimiter, ","))

                End If

                If _
                    Not _
                    Session(UniqueSessionID + "hsSubfileKeepText").Contains(strName) _
                    Then
                    Session(UniqueSessionID + "hsSubfileKeepText").Add(strName,
                                                                       hsLenght)
                ElseIf _
                    IsNothing(
                        Session(UniqueSessionID + "hsSubfileKeepText").Item(strName)) _
                    Then
                    Session(UniqueSessionID + "hsSubfileKeepText").Remove(strName)
                    Session(UniqueSessionID + "hsSubfileKeepText").Add(strName,
                                                                       hsLenght)
                End If

                If SubType = SubFileType.TempText OrElse ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso IsKeepText) Then

                    If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not arrKeepFile.Contains(strName) Then
                        arrKeepFile.Add(strName)
                    End If

                    If dt.Rows.Count > 399 Then
                        PutDataTextTable(strName, dt, Session(UniqueSessionID + "hsSubfileKeepText").Item(strName))
                        dt.Clear()
                    End If

                End If

                blnQTPSubFile = True

                If Session(UniqueSessionID + "hsSubfile").Contains(strName) Then
                    Session(UniqueSessionID + "hsSubfile").Item(strName) = dt
                Else
                    Session(UniqueSessionID + "hsSubfile").Add(strName, dt)
                End If

                'AddRecordsRead(strName, 0, LogType.OutPut)

                If blnDeletedSubFile Then
                    'AddRecordsRead(strName, 0, LogType.Added)
                    AddRecordsProcessed(strName, 0, LogType.Added)
                Else
                    'AddRecordsRead(strName, 1, LogType.Added)
                    AddRecordsProcessed(strName, 1, LogType.Added)
                End If

                If Not arrSubFiles.Contains(strName) Then
                    arrSubFiles.Add(strName)
                    If (Not m_hsFileInOutput.Contains(strName)) Then
                        m_hsFileInOutput.Add(strName, strName)
                    End If
                End If

            Catch ex As Exception

            End Try
        End Sub

        Public Sub SubFile(ByRef m_trnTRANS_UPDATE As SqlTransaction, strName As String, SubType As SubFileType,
                           Mode As SubFileMode, ByVal ParamArray Include() As Object)

            AddRecordsProcessed(strName, 0, LogType.Added)

            If Mode = SubFileMode.Append Then
                If Not Session(UniqueSessionID + "hsSubfile").Contains(strName) Then
                    Session(UniqueSessionID + "hsSubfile").Add(strName, Nothing)
                End If
            ElseIf Mode = SubFileMode.Overwrite Then
                If Session(UniqueSessionID + "hsSubfile").Contains(strName) Then
                    Session(UniqueSessionID + "hsSubfile").Remove(strName)
                End If
            End If

            If Mode = SubFileMode.Append Then blnAppendSubFile = True
            SubFile(m_trnTRANS_UPDATE, strName, SubType, Include)
            blnAppendSubFile = False
        End Sub

        Public Sub SubFile(ByRef m_trnTRANS_UPDATE As SqlTransaction, ByRef SubfileObject As SqlFileObject,
                           SubType As SubFileType, Mode As SubFileMode, ByVal ParamArray Include() As Object)
            If Mode = SubFileMode.Append Then
                If Not Session(UniqueSessionID + "hsSubfile").Contains(SubfileObject.BaseName) Then
                    Session(UniqueSessionID + "hsSubfile").Add(SubfileObject.BaseName, Nothing)
                End If
            ElseIf Mode = SubFileMode.Overwrite Then
                If Session(UniqueSessionID + "hsSubfile").Contains(SubfileObject.BaseName) Then
                    Session(UniqueSessionID + "hsSubfile").Remove(SubfileObject.BaseName)
                End If
            End If

            If Mode = SubFileMode.Append Then blnAppendSubFile = True
            SubFile(m_trnTRANS_UPDATE, SubfileObject, SubType, Include)
            blnAppendSubFile = False
        End Sub

        Public Sub SubFile(ByRef m_trnTRANS_UPDATE As SqlTransaction, ByRef SubfileObject As SqlFileObject,
                           SubType As SubFileType, ByVal ParamArray Include() As Object)

            AddRecordsProcessed(SubfileObject.BaseName, SubfileObject.AliasName, 0, LogType.Added)

            Dim objReader As SqlDataReader
            Dim strSQL As New StringBuilder("")
            Dim strCreateTableSQL As New StringBuilder("")
            Dim strInsertRowSQL As New StringBuilder("")
            Dim intTableCount As Integer = 0
            Dim fleTemp As SqlFileObject
            Dim strColumns As String = String.Empty
            Dim strValues As String = String.Empty
            Dim strDataValues As String = String.Empty
            Dim strCreateTable As String = String.Empty
            Dim strSchema As String = ConfigurationManager.AppSettings("SubFileSchema") & ""
            Dim IsKeepText As Boolean = (ConfigurationManager.AppSettings("SubfileKEEPtoTEXT") & "").ToUpper = "TRUE"
            Dim intSubFileRow As Integer = 0
            Dim SubTotalValue As String = String.Empty
            Dim hsLenght As New Hashtable
            Dim hsSubfileKeepText As SortedList
            hsSubfileKeepText = Session(UniqueSessionID + "hsSubfileKeepText")
            Dim strName As String = SubfileObject.BaseName
            Dim strSubfileNumeric As String = ConfigurationManager.AppSettings("SubFileNumeric") & ""
            Dim strCulture As String = ConfigurationManager.AppSettings("Culture") & ""
            Dim strConnect As String = GetConnectionString()


            If SubType = SubFileType.KeepSQL
                SubType = SubFileType.Keep
                IsKeepText = False 
            End If

            If NoSubFileData Then
                If SubfileObject.AliasName <> "" Then
                    If NoDataSubfile.Contains(SubfileObject.AliasName) Then
                        Return
                    End If
                    NoDataSubfile.Add(SubfileObject.AliasName)
                Else
                    If NoDataSubfile.Contains(SubfileObject.BaseName) Then
                        Return
                    End If
                    NoDataSubfile.Add(SubfileObject.BaseName)
                End If
            End If



            If strCulture.Length > 0 Then
                strCulture = " COLLATE " & strCulture
            End If

            If SubType = SubFileType.KeepText Then
                IsKeepText = True
                SubType = SubFileType.Keep
            End If

            If strSchema.Length > 0 Then
                strSchema = strSchema & "."
            End If

            Dim dt As DataTable
            Dim dc As DataColumn
            Dim rw As DataRow
            Dim arrColumns() As String
            Dim arrValues() As String

            If IsKeepText AndAlso SubType <> SubFileType.Keep AndAlso SubType <> SubFileType.Portable Then
                Session(UniqueSessionID + "alSubTempFile").Add(strName & "_" & Session("SessionID"))
            End If

            If SubType = SubFileType.Portable Then
                If IsNothing(Session("PortableSubFiles")) Then
                    Session("PortableSubFiles") = New ArrayList
                    DirectCast(Session("PortableSubFiles"), ArrayList).Add(strName)
                Else
                    If Not DirectCast(Session("PortableSubFiles"), ArrayList).Contains(strName) Then
                        DirectCast(Session("PortableSubFiles"), ArrayList).Add(strName)
                    End If
                End If
            End If

            If Session(UniqueSessionID + "hsSubfile").Contains(strName) Then
                dt = Session(UniqueSessionID + "hsSubfile").Item(strName)
                blnQTPSubFile = True

                If IsNothing(dt) Then
                    intSubFileRow = 1
                    dt = New DataTable(strName)
                Else
                    intSubFileRow = dt.Rows.Count + 1
                    blnAppendSubFile = False
                End If



            Else
                If SubType = SubFileType.TempText OrElse ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso IsKeepText) Then
                    DeleteDataTextTable(strName, False)
                End If
                dt = New DataTable(strName)
                blnQTPSubFile = False
                intSubFileRow = 1
            End If

            If blnDeleteSubFile Then
                blnDeletedSubFile = True
            End If

            blnHasRunSubfile = True

            Try
                If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                    strCreateTableSQL.Append("CREATE TABLE ")
                    If strSchema <> "" Then
                        strCreateTableSQL.Append(strSchema).Append(strName)
                    Else
                        strCreateTableSQL.Append(strName)
                    End If
                End If

                If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                    strInsertRowSQL.Append(" INSERT INTO ")
                    If strSchema <> "" Then
                        strInsertRowSQL.Append(strSchema).Append(strName)
                    Else
                        strInsertRowSQL.Append(strName)
                    End If
                End If

                'Find the tables and Colunms
                For i As Integer = 0 To Include.Length - 1

                    Select Case Include(i).GetType.ToString.ToUpper

                        Case "CORE.WINDOWS.UI.CORE.WINDOWS.SQLFILEOBJECT"
                            intTableCount = intTableCount + 1
                            fleTemp = Include(i)

                            If fleTemp.m_dtbDataTable Is Nothing Then
                                fleTemp.CreateDataStructure()
                            End If


                            If i = Include.Length - 1 OrElse Include(i + 1).GetType.ToString <> "System.String" Then

                                For j As Integer = 0 To fleTemp.Columns.Count - 1

                                    If _
                                        fleTemp.Columns.Item(j).ColumnName <> "ROW_ID" AndAlso
                                        fleTemp.Columns.Item(j).ColumnName <> "CHECKSUM_VALUE" Then

                                        Select Case fleTemp.GetObjectType(fleTemp.Columns.Item(j).ColumnName)
                                            Case "System.String"

                                                Try
                                                    If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                                        dc = New DataColumn()
                                                        dc.ColumnName = fleTemp.Columns.Item(j).ColumnName
                                                        dc.DataType = Type.GetType("System.String")

                                                        If _
                                                            VAL(
                                                                fleTemp.GetObjectSize(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower)) <> 0 _
                                                            Then
                                                            If _
                                                                hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                                hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower) Then
                                                                If _
                                                                    Not _
                                                                    hsLenght.Contains(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower) Then _
                                                                    hsLenght.Add(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower,
                                                                        hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                            fleTemp.Columns.Item(j).ColumnName.ToLower))
                                                                dc.MaxLength =
                                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower)
                                                            Else
                                                                If _
                                                                    Not _
                                                                    hsLenght.Contains(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower) Then _
                                                                    hsLenght.Add(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower,
                                                                        VAL(
                                                                            fleTemp.GetObjectSize(
                                                                                fleTemp.Columns.Item(j).ColumnName.
                                                                                                     ToLower)))
                                                                dc.MaxLength =
                                                                    VAL(
                                                                        fleTemp.GetObjectSize(
                                                                            fleTemp.Columns.Item(j).ColumnName.ToLower))
                                                            End If
                                                        End If

                                                        dt.Columns.Add(dc)

                                                    End If

                                                    'build the columns
                                                    strColumns = strColumns & fleTemp.Columns.Item(j).ColumnName & m_strDelimiter
                                                    If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                                        strValues = strValues &
                                                                    StringToField(
                                                                        fleTemp.GetStringValue(
                                                                            fleTemp.Columns.Item(j).ColumnName)) & m_strDelimiter
                                                    strDataValues = strDataValues &
                                                                    fleTemp.GetStringValue(
                                                                        fleTemp.Columns.Item(j).ColumnName) & m_strDelimiter

                                                    If _
                                                        Not blnQTPSubFile AndAlso
                                                        ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                                        strCreateTable = strCreateTable & dc.ColumnName & " VARCHAR("
                                                        strCreateTable = strCreateTable & dc.MaxLength & ") " &
                                                                         strCulture & " NULL ,"
                                                    End If

                                                Catch ex As Exception
                                                    Dim intNextCol As Integer = 2
                                                    Do _
                                                        While _
                                                            dt.Columns.Contains(
                                                                fleTemp.Columns.Item(j).ColumnName & intNextCol.ToString)
                                                        intNextCol = intNextCol + 1
                                                    Loop

                                                    dc = New DataColumn()
                                                    dc.ColumnName = fleTemp.Columns.Item(j).ColumnName &
                                                                    intNextCol.ToString
                                                    dc.DataType = Type.GetType("System.String")

                                                    If _
                                                        VAL(
                                                            fleTemp.GetObjectSize(
                                                                fleTemp.Columns.Item(j).ColumnName.ToLower)) <> 0 Then
                                                        If _
                                                            hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                            hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                                fleTemp.Columns.Item(j).ColumnName & intNextCol.ToString) _
                                                            Then
                                                            If _
                                                                Not _
                                                                hsLenght.Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString) Then _
                                                                hsLenght.Add(
                                                                    fleTemp.Columns.Item(j).ColumnName &
                                                                    intNextCol.ToString,
                                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                        fleTemp.Columns.Item(j).ColumnName &
                                                                        intNextCol.ToString))
                                                            dc.MaxLength =
                                                                hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                    fleTemp.Columns.Item(j).ColumnName &
                                                                    intNextCol.ToString)
                                                        ElseIf _
                                                            hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                            hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                                fleTemp.Columns.Item(j).ColumnName) Then
                                                            If _
                                                                Not _
                                                                hsLenght.Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString) Then _
                                                                hsLenght.Add(
                                                                    fleTemp.Columns.Item(j).ColumnName &
                                                                    intNextCol.ToString,
                                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                        fleTemp.Columns.Item(j).ColumnName))
                                                            dc.MaxLength =
                                                                hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                    fleTemp.Columns.Item(j).ColumnName)
                                                        Else
                                                            If _
                                                                Not _
                                                                hsLenght.Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString) Then _
                                                                hsLenght.Add(
                                                                    fleTemp.Columns.Item(j).ColumnName &
                                                                    intNextCol.ToString,
                                                                    VAL(
                                                                        fleTemp.GetObjectSize(
                                                                            fleTemp.Columns.Item(j).ColumnName)))
                                                            dc.MaxLength =
                                                                VAL(
                                                                    fleTemp.GetObjectSize(
                                                                        fleTemp.Columns.Item(j).ColumnName))
                                                        End If
                                                    End If

                                                    dt.Columns.Add(dc)

                                                    'build the columns
                                                    strColumns = strColumns & fleTemp.Columns.Item(j).ColumnName & m_strDelimiter
                                                    If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                                        strValues = strValues &
                                                                    StringToField(
                                                                        fleTemp.GetStringValue(
                                                                            fleTemp.Columns.Item(j).ColumnName)) & m_strDelimiter
                                                    strDataValues = strDataValues &
                                                                    fleTemp.GetStringValue(
                                                                        fleTemp.Columns.Item(j).ColumnName) & m_strDelimiter
                                                    If _
                                                        Not blnQTPSubFile AndAlso
                                                        ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                                        strCreateTable = strCreateTable & dc.ColumnName & " VARCHAR("
                                                        strCreateTable = strCreateTable & dc.MaxLength & ") " &
                                                                         strCulture & " NULL ,"
                                                    End If

                                                End Try

                                            Case "System.DateTime"

                                                Try
                                                    If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                                        dc = New DataColumn()
                                                        dc.ColumnName = fleTemp.Columns.Item(j).ColumnName
                                                        dc.DataType = Type.GetType("System.DateTime")
                                                        dt.Columns.Add(dc)
                                                    End If

                                                    'build the columns
                                                    strColumns = strColumns & fleTemp.Columns.Item(j).ColumnName & m_strDelimiter

                                                    If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                                        If _
                                                            GetDateFromYYYYMMDDDecimal(
                                                                fleTemp.GetNumericDateTimeValue(
                                                                    fleTemp.Columns.Item(j).ColumnName)) = cZeroDate _
                                                            Then
                                                            strValues = strValues & "Null"
                                                        Else
                                                            strValues = strValues &
                                                                        "CONVERT(DATETIME, " +
                                                                        StringToField(
                                                                            Format(
                                                                                CDate(
                                                                                    GetDateFromYYYYMMDDDecimal(
                                                                                        fleTemp.GetNumericDateTimeValue(
                                                                                            fleTemp.Columns.Item(j).
                                                                                                                           ColumnName))),
                                                                                "yyyy-MM-dd HH:mm:ss")) + ", 120)"
                                                        End If
                                                        strValues = strValues & m_strDelimiter
                                                    End If

                                                    strDataValues = strDataValues &
                                                                    fleTemp.GetNumericDateTimeValue(
                                                                        fleTemp.Columns.Item(j).ColumnName) & m_strDelimiter
                                                    If _
                                                        Not blnQTPSubFile AndAlso
                                                        ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                                        strCreateTable = strCreateTable & dc.ColumnName & " DATETIME,"
                                                    End If

                                                Catch ex As Exception
                                                    Dim intNextCol As Integer = 2
                                                    Do _
                                                        While _
                                                            dt.Columns.Contains(
                                                                fleTemp.Columns.Item(j).ColumnName & intNextCol.ToString)
                                                        intNextCol = intNextCol + 1
                                                    Loop

                                                    dc = New DataColumn()
                                                    dc.ColumnName = fleTemp.Columns.Item(j).ColumnName &
                                                                    intNextCol.ToString
                                                    dc.DataType = Type.GetType("System.DateTime")
                                                    dt.Columns.Add(dc)

                                                    'build the columns
                                                    strColumns = strColumns & fleTemp.Columns.Item(j).ColumnName & m_strDelimiter

                                                    If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                                        If _
                                                            GetDateFromYYYYMMDDDecimal(
                                                                fleTemp.GetNumericDateTimeValue(
                                                                    fleTemp.Columns.Item(j).ColumnName)) = cZeroDate _
                                                            Then
                                                            strValues = strValues & "Null"
                                                        Else
                                                            strValues = strValues &
                                                                        "CONVERT(DATETIME, " +
                                                                        StringToField(
                                                                            Format(
                                                                                CDate(
                                                                                    GetDateFromYYYYMMDDDecimal(
                                                                                        fleTemp.GetNumericDateTimeValue(
                                                                                            fleTemp.Columns.Item(j).
                                                                                                                           ColumnName))),
                                                                                "yyyy-MM-dd HH:mm:ss")) + ", 120)"
                                                        End If
                                                        strValues = strValues & m_strDelimiter
                                                    End If

                                                    strDataValues = strDataValues &
                                                                    fleTemp.GetNumericDateTimeValue(
                                                                        fleTemp.Columns.Item(j).ColumnName) & m_strDelimiter
                                                    If _
                                                        Not blnQTPSubFile AndAlso
                                                        ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                                        strCreateTable = strCreateTable & dc.ColumnName & " DATETIME,"
                                                    End If
                                                End Try

                                            Case "System.Decimal", "System.Double", "System.Single"

                                                Try
                                                    If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                                        dc = New DataColumn()
                                                        dc.ColumnName = fleTemp.Columns.Item(j).ColumnName
                                                        dc.DataType = Type.GetType("System.Decimal")
                                                        If _
                                                            VAL(
                                                                fleTemp.GetObjectSize(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower)) <> 0 _
                                                            Then
                                                            If _
                                                                hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                                hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower) Then
                                                                If _
                                                                    Not _
                                                                    hsLenght.Contains(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower) Then _
                                                                    hsLenght.Add(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower,
                                                                        hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                            fleTemp.Columns.Item(j).ColumnName.ToLower))
                                                            Else
                                                                If _
                                                                    Not _
                                                                    hsLenght.Contains(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower) Then _
                                                                    hsLenght.Add(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower,
                                                                        VAL(
                                                                            fleTemp.GetObjectSize(
                                                                                fleTemp.Columns.Item(j).ColumnName.
                                                                                                     ToLower)))
                                                            End If
                                                        End If
                                                        dt.Columns.Add(dc)

                                                    End If

                                                    'build the columns
                                                    strColumns = strColumns & fleTemp.Columns.Item(j).ColumnName & m_strDelimiter
                                                    If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                                        strValues = strValues &
                                                                    fleTemp.GetDecimalValue(
                                                                        fleTemp.Columns.Item(j).ColumnName) & m_strDelimiter
                                                    strDataValues = strDataValues &
                                                                    fleTemp.GetDecimalValue(
                                                                        fleTemp.Columns.Item(j).ColumnName) & m_strDelimiter
                                                    If _
                                                        Not blnQTPSubFile AndAlso
                                                        ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                                        If strSubfileNumeric.Length > 0 Then
                                                            strCreateTable = strCreateTable & dc.ColumnName &
                                                                             " DECIMAL(" &
                                                                             fleTemp.GetDecimalSize(
                                                                                 fleTemp.Columns.Item(j).ColumnName.
                                                                                                       ToLower) & "),"
                                                        Else
                                                            strCreateTable = strCreateTable & dc.ColumnName & " FLOAT,"
                                                        End If
                                                    End If
                                                Catch ex As Exception
                                                    Dim intNextCol As Integer = 2
                                                    Do _
                                                        While _
                                                            dt.Columns.Contains(
                                                                fleTemp.Columns.Item(j).ColumnName & intNextCol.ToString)
                                                        intNextCol = intNextCol + 1
                                                    Loop

                                                    dc = New DataColumn()
                                                    dc.ColumnName = fleTemp.Columns.Item(j).ColumnName &
                                                                    intNextCol.ToString
                                                    dc.DataType = Type.GetType("System.Decimal")
                                                    If _
                                                        VAL(
                                                            fleTemp.GetObjectSize(
                                                                fleTemp.Columns.Item(j).ColumnName.ToLower)) <> 0 Then
                                                        If _
                                                            hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                            hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                                fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                intNextCol.ToString) Then
                                                            If _
                                                                Not _
                                                                hsLenght.Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString) Then _
                                                                hsLenght.Add(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString,
                                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                        intNextCol.ToString))
                                                        ElseIf _
                                                            hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                            hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                                fleTemp.Columns.Item(j).ColumnName.ToLower) Then
                                                            If _
                                                                Not _
                                                                hsLenght.Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString) Then _
                                                                hsLenght.Add(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString,
                                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower))
                                                        Else
                                                            If _
                                                                Not _
                                                                hsLenght.Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString) Then _
                                                                hsLenght.Add(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString,
                                                                    VAL(
                                                                        fleTemp.GetObjectSize(
                                                                            fleTemp.Columns.Item(j).ColumnName.ToLower)))
                                                        End If
                                                    End If
                                                    dt.Columns.Add(dc)

                                                    'build the columns
                                                    strColumns = strColumns & fleTemp.Columns.Item(j).ColumnName & m_strDelimiter
                                                    If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                                        strValues = strValues &
                                                                    fleTemp.GetDecimalValue(
                                                                        fleTemp.Columns.Item(j).ColumnName) & m_strDelimiter
                                                    strDataValues = strDataValues &
                                                                    fleTemp.GetDecimalValue(
                                                                        fleTemp.Columns.Item(j).ColumnName) & m_strDelimiter
                                                    If _
                                                        Not blnQTPSubFile AndAlso
                                                        ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                                        If strSubfileNumeric.Length > 0 Then
                                                            strCreateTable = strCreateTable & dc.ColumnName &
                                                                             " DECIMAL(" &
                                                                             fleTemp.GetDecimalSize(
                                                                                 fleTemp.Columns.Item(j).ColumnName.
                                                                                                       ToLower) & "),"
                                                        Else
                                                            strCreateTable = strCreateTable & dc.ColumnName & " FLOAT,"
                                                        End If
                                                    End If
                                                End Try

                                            Case "System.Int32", "System.Int64"

                                                Try
                                                    If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                                        dc = New DataColumn()
                                                        dc.ColumnName = fleTemp.Columns.Item(j).ColumnName
                                                        dc.DataType = Type.GetType("System.Int64")

                                                        If _
                                                            hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                            hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                                fleTemp.Columns.Item(j).ColumnName.ToLower) Then
                                                            If _
                                                                Not _
                                                                hsLenght.Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower) Then _
                                                                hsLenght.Add(fleTemp.Columns.Item(j).ColumnName.ToLower,
                                                                             hsSubfileKeepText.Item(fleTemp.BaseName).
                                                                                Item(
                                                                                    fleTemp.Columns.Item(j).ColumnName.
                                                                                        ToLower))
                                                        Else
                                                            If _
                                                                Not _
                                                                hsLenght.Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower) Then _
                                                                hsLenght.Add(fleTemp.Columns.Item(j).ColumnName.ToLower,
                                                                             10)
                                                        End If

                                                        dt.Columns.Add(dc)

                                                    End If

                                                    'build the columns
                                                    strColumns = strColumns & fleTemp.Columns.Item(j).ColumnName & m_strDelimiter
                                                    If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                                        strValues = strValues &
                                                                    fleTemp.GetDecimalValue(
                                                                        fleTemp.Columns.Item(j).ColumnName) & m_strDelimiter
                                                    strDataValues = strDataValues &
                                                                    fleTemp.GetDecimalValue(
                                                                        fleTemp.Columns.Item(j).ColumnName) & m_strDelimiter
                                                    If _
                                                        Not blnQTPSubFile AndAlso
                                                        ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                                        strCreateTable = strCreateTable & dc.ColumnName & " FLOAT" & ","
                                                    End If
                                                Catch ex As Exception
                                                    Dim intNextCol As Integer = 2
                                                    Do _
                                                        While _
                                                            dt.Columns.Contains(
                                                                fleTemp.Columns.Item(j).ColumnName & intNextCol.ToString)
                                                        intNextCol = intNextCol + 1
                                                    Loop

                                                    dc = New DataColumn()
                                                    dc.ColumnName = fleTemp.Columns.Item(j).ColumnName &
                                                                    intNextCol.ToString
                                                    dc.DataType = Type.GetType("System.Decimal")
                                                    If _
                                                        VAL(
                                                            fleTemp.GetObjectSize(
                                                                fleTemp.Columns.Item(j).ColumnName.ToLower)) <> 0 Then
                                                        If _
                                                            hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                            hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                                fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                intNextCol.ToString) Then
                                                            If _
                                                                Not _
                                                                hsLenght.Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString) Then _
                                                                hsLenght.Add(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString,
                                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                        intNextCol.ToString))
                                                        ElseIf _
                                                            hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                            hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                                fleTemp.Columns.Item(j).ColumnName.ToLower) Then
                                                            If _
                                                                Not _
                                                                hsLenght.Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString) Then _
                                                                hsLenght.Add(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString,
                                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower))
                                                        Else
                                                            If _
                                                                Not _
                                                                hsLenght.Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString) Then _
                                                                hsLenght.Add(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString, 10)
                                                        End If
                                                    End If
                                                    dt.Columns.Add(dc)

                                                    'build the columns
                                                    strColumns = strColumns & fleTemp.Columns.Item(j).ColumnName & m_strDelimiter
                                                    If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                                        strValues = strValues &
                                                                    fleTemp.GetDecimalValue(
                                                                        fleTemp.Columns.Item(j).ColumnName) & m_strDelimiter
                                                    strDataValues = strDataValues &
                                                                    fleTemp.GetDecimalValue(
                                                                        fleTemp.Columns.Item(j).ColumnName) & m_strDelimiter
                                                    If _
                                                        Not blnQTPSubFile AndAlso
                                                        ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                                        strCreateTable = strCreateTable & dc.ColumnName & " FLOAT" & ","
                                                    End If
                                                End Try

                                        End Select

                                    End If

                                Next

                            End If

                        Case "SYSTEM.STRING"

                            'build the Values
                            Select Case fleTemp.GetObjectType(Include(i))
                                Case ""
                                    Dim message As String = "Error on subfile : " + strName + ". Column '" + Include(i) + "' from Table '" + fleTemp.BaseName + "' does not exist."
                                    Dim ex As CustomApplicationException = New CustomApplicationException(message)
                                    Throw ex

                                Case "System.String"

                                    Try
                                        If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                            dc = New DataColumn()
                                            dc.ColumnName = Include(i)
                                            dc.DataType = Type.GetType("System.String")
                                            If fleTemp.GetObjectSize(Include(i).ToString).Trim <> "" Then

                                                If _
                                                    hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                        Include(i).ToString.ToLower.ToLower) Then
                                                    If Not hsLenght.Contains(Include(i).ToString.ToLower) Then _
                                                        hsLenght.Add(Include(i).ToString.ToLower,
                                                                     hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                         Include(i).ToString.ToLower.ToLower))
                                                    dc.MaxLength =
                                                        hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                            Include(i).ToString.ToLower.ToLower)
                                                Else
                                                    If Not hsLenght.Contains(Include(i).ToString.ToLower) Then _
                                                        hsLenght.Add(Include(i).ToString.ToLower,
                                                                     CInt(fleTemp.GetObjectSize(Include(i).ToString)))
                                                    dc.MaxLength = CInt(fleTemp.GetObjectSize(Include(i).ToString))
                                                End If

                                            End If

                                            dt.Columns.Add(dc)
                                        End If

                                        'build the columns
                                        strColumns = strColumns & Include(i) & m_strDelimiter
                                        If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                            strValues = strValues & StringToField(fleTemp.GetStringValue(Include(i))) &
                                                        m_strDelimiter
                                        strDataValues = strDataValues & fleTemp.GetStringValue(Include(i)) & m_strDelimiter
                                        If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) _
                                            Then
                                            strCreateTable = strCreateTable & dc.ColumnName & " VARCHAR("
                                            strCreateTable = strCreateTable & dc.MaxLength & ") " & strCulture &
                                                             " NULL ,"
                                        End If
                                    Catch ex As Exception
                                        Dim intNextCol As Integer = 2
                                        Do While dt.Columns.Contains(Include(i) & intNextCol.ToString)
                                            intNextCol = intNextCol + 1
                                        Loop

                                        dc = New DataColumn()
                                        dc.ColumnName = Include(i) & intNextCol.ToString
                                        dc.DataType = Type.GetType("System.String")
                                        If fleTemp.GetObjectSize(Include(i).ToString).Trim <> "" Then

                                            If _
                                                hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                    Include(i).ToString.ToLower.ToLower & intNextCol.ToString) Then
                                                If _
                                                    Not _
                                                    hsLenght.Contains(Include(i).ToString.ToLower & intNextCol.ToString) _
                                                    Then _
                                                    hsLenght.Add(Include(i).ToString.ToLower & intNextCol.ToString,
                                                                 hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                     Include(i).ToString.ToLower.ToLower &
                                                                     intNextCol.ToString))
                                                dc.MaxLength =
                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                        Include(i).ToString.ToLower.ToLower)
                                            ElseIf _
                                                hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                    Include(i).ToString.ToLower.ToLower) Then
                                                If _
                                                    Not _
                                                    hsLenght.Contains(Include(i).ToString.ToLower & intNextCol.ToString) _
                                                    Then _
                                                    hsLenght.Add(Include(i).ToString.ToLower & intNextCol.ToString,
                                                                 hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                     Include(i).ToString.ToLower.ToLower))
                                                dc.MaxLength =
                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                        Include(i).ToString.ToLower.ToLower)
                                            Else
                                                If _
                                                    Not _
                                                    hsLenght.Contains(Include(i).ToString.ToLower & intNextCol.ToString) _
                                                    Then _
                                                    hsLenght.Add(Include(i).ToString.ToLower & intNextCol.ToString,
                                                                 CInt(fleTemp.GetObjectSize(Include(i).ToString)))
                                                dc.MaxLength = CInt(fleTemp.GetObjectSize(Include(i).ToString))
                                            End If

                                        End If

                                        dt.Columns.Add(dc)

                                        'build the columns
                                        strColumns = strColumns & Include(i) & m_strDelimiter
                                        If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                            strValues = strValues & StringToField(fleTemp.GetStringValue(Include(i))) &
                                                        m_strDelimiter
                                        strDataValues = strDataValues & fleTemp.GetStringValue(Include(i)) & m_strDelimiter
                                        If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) _
                                            Then
                                            strCreateTable = strCreateTable & dc.ColumnName & " VARCHAR("
                                            strCreateTable = strCreateTable & dc.MaxLength & ") " & strCulture &
                                                             " NULL ,"
                                        End If
                                    End Try

                                Case "System.DateTime"

                                    Try
                                        If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                            dc = New DataColumn()
                                            dc.ColumnName = Include(i)
                                            dc.DataType = Type.GetType("System.DateTime")
                                            dt.Columns.Add(dc)
                                        End If

                                        'build the columns
                                        strColumns = strColumns & Include(i) & m_strDelimiter

                                        If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                            If _
                                                GetDateFromYYYYMMDDDecimal(fleTemp.GetNumericDateTimeValue(Include(i))) =
                                                cZeroDate Then
                                                strValues = strValues & "Null"
                                            Else
                                                strValues = strValues &
                                                            "CONVERT(DATETIME, " +
                                                            StringToField(
                                                                Format(
                                                                    CDate(
                                                                        GetDateFromYYYYMMDDDecimal(
                                                                            fleTemp.GetNumericDateTimeValue(Include(i)))),
                                                                    "yyyy-MM-dd HH:mm:ss")) + ", 120)"
                                            End If
                                            strValues = strValues & m_strDelimiter
                                        End If

                                        strDataValues = strDataValues & fleTemp.GetNumericDateTimeValue(Include(i)) &
                                                        m_strDelimiter
                                        If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) _
                                            Then
                                            strCreateTable = strCreateTable & dc.ColumnName & " DATETIME,"
                                        End If
                                    Catch ex As Exception
                                        Dim intNextCol As Integer = 2
                                        Do While dt.Columns.Contains(Include(i) & intNextCol.ToString)
                                            intNextCol = intNextCol + 1
                                        Loop

                                        dc = New DataColumn()
                                        dc.ColumnName = Include(i) & intNextCol.ToString
                                        dc.DataType = Type.GetType("System.DateTime")
                                        dt.Columns.Add(dc)

                                        'build the columns
                                        strColumns = strColumns & Include(i) & m_strDelimiter

                                        If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                            If _
                                                GetDateFromYYYYMMDDDecimal(fleTemp.GetNumericDateTimeValue(Include(i))) =
                                                cZeroDate Then
                                                strValues = strValues & "Null"
                                            Else
                                                strValues = strValues &
                                                            "CONVERT(DATETIME, " +
                                                            StringToField(
                                                                Format(
                                                                    CDate(
                                                                        GetDateFromYYYYMMDDDecimal(
                                                                            fleTemp.GetNumericDateTimeValue(Include(i)))),
                                                                    "yyyy-MM-dd HH:mm:ss")) + ", 120)"
                                            End If
                                            strValues = strValues & m_strDelimiter
                                        End If

                                        strDataValues = strDataValues &
                                                        fleTemp.GetNumericDateTimeValue(Include(i)).ToString.Replace(
                                                            "12:00:00 AM", "NULL") & m_strDelimiter
                                        If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) _
                                            Then
                                            strCreateTable = strCreateTable & dc.ColumnName & " DATETIME,"
                                        End If
                                    End Try

                                Case "System.Decimal", "System.Double", "System.Single"

                                    Try
                                        If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                            dc = New DataColumn()
                                            dc.ColumnName = Include(i)
                                            dc.DataType = Type.GetType("System.Decimal")
                                            If fleTemp.GetObjectSize(Include(i).ToString).Trim <> "" Then
                                                If _
                                                    hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                        Include(i).ToString.ToLower.ToLower) Then
                                                    If Not hsLenght.Contains(Include(i).ToString.ToLower) Then _
                                                        hsLenght.Add(Include(i).ToString.ToLower,
                                                                     hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                         Include(i).ToString.ToLower.ToLower))
                                                Else
                                                    If Not hsLenght.Contains(Include(i).ToString.ToLower) Then _
                                                        hsLenght.Add(Include(i).ToString.ToLower,
                                                                     CInt(fleTemp.GetObjectSize(Include(i).ToString)))
                                                End If
                                            End If
                                            dt.Columns.Add(dc)
                                        End If

                                        'build the columns
                                        strColumns = strColumns & Include(i) & m_strDelimiter
                                        If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                            strValues = strValues & fleTemp.GetDecimalValue(Include(i)) & m_strDelimiter
                                        strDataValues = strDataValues & fleTemp.GetDecimalValue(Include(i)) & m_strDelimiter
                                        If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) _
                                            Then
                                            If strSubfileNumeric.Length > 0 Then
                                                strCreateTable = strCreateTable & dc.ColumnName & " DECIMAL(" &
                                                                 fleTemp.GetDecimalSize(Include(i).ToString) & "),"
                                            Else
                                                strCreateTable = strCreateTable & dc.ColumnName & " FLOAT,"
                                            End If
                                        End If
                                    Catch ex As Exception
                                        Dim intNextCol As Integer = 2
                                        Do While dt.Columns.Contains(Include(i) & intNextCol.ToString)
                                            intNextCol = intNextCol + 1
                                        Loop

                                        dc = New DataColumn()
                                        dc.ColumnName = Include(i) & intNextCol.ToString
                                        dc.DataType = Type.GetType("System.Decimal")
                                        If fleTemp.GetObjectSize(Include(i).ToString).Trim <> "" Then
                                            If _
                                                hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                    Include(i).ToString.ToLower.ToLower & intNextCol.ToString) Then
                                                If _
                                                    Not _
                                                    hsLenght.Contains(Include(i).ToString.ToLower & intNextCol.ToString) _
                                                    Then _
                                                    hsLenght.Add(Include(i).ToString.ToLower & intNextCol.ToString,
                                                                 hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                     Include(i).ToString.ToLower.ToLower &
                                                                     intNextCol.ToString))
                                            ElseIf _
                                                hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                    Include(i).ToString.ToLower.ToLower) Then
                                                If _
                                                    Not _
                                                    hsLenght.Contains(Include(i).ToString.ToLower & intNextCol.ToString) _
                                                    Then _
                                                    hsLenght.Add(Include(i).ToString.ToLower & intNextCol.ToString,
                                                                 hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                     Include(i).ToString.ToLower.ToLower))
                                            Else
                                                If _
                                                    Not _
                                                    hsLenght.Contains(Include(i).ToString.ToLower & intNextCol.ToString) _
                                                    Then _
                                                    hsLenght.Add(Include(i).ToString.ToLower & intNextCol.ToString,
                                                                 CInt(fleTemp.GetObjectSize(Include(i).ToString)))
                                            End If
                                        End If
                                        dt.Columns.Add(dc)

                                        'build the columns
                                        strColumns = strColumns & Include(i) & m_strDelimiter
                                        If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                            strValues = strValues & fleTemp.GetDecimalValue(Include(i)) & m_strDelimiter
                                        strDataValues = strDataValues & fleTemp.GetDecimalValue(Include(i)) & m_strDelimiter
                                        If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) _
                                            Then
                                            If strSubfileNumeric.Length > 0 Then
                                                strCreateTable = strCreateTable & dc.ColumnName & " DECIMAL(" &
                                                                 fleTemp.GetDecimalSize(Include(i).ToString) & "),"
                                            Else
                                                strCreateTable = strCreateTable & dc.ColumnName & " FLOAT,"
                                            End If
                                        End If
                                    End Try

                                Case "System.Int32", "System.Int64"

                                    Try
                                        If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                            dc = New DataColumn()
                                            dc.ColumnName = Include(i)
                                            dc.DataType = Type.GetType("System.Int64")

                                            If _
                                                hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                    Include(i).ToString.ToLower.ToLower) Then
                                                If Not hsLenght.Contains(Include(i).ToString.ToLower) Then _
                                                    hsLenght.Add(Include(i).ToString.ToLower,
                                                                 hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                     Include(i).ToString.ToLower.ToLower))
                                            Else
                                                If Not hsLenght.Contains(Include(i).ToString.ToLower) Then _
                                                    hsLenght.Add(Include(i).ToString.ToLower, 10)
                                            End If

                                            dt.Columns.Add(dc)
                                        End If

                                        'build the columns
                                        strColumns = strColumns & Include(i) & m_strDelimiter
                                        If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                            strValues = strValues & fleTemp.GetDecimalValue(Include(i)) & m_strDelimiter
                                        strDataValues = strDataValues & fleTemp.GetDecimalValue(Include(i)) & m_strDelimiter
                                        If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) _
                                            Then
                                            strCreateTable = strCreateTable & dc.ColumnName & " FLOAT" & ","
                                        End If
                                    Catch ex As Exception
                                        Dim intNextCol As Integer = 2
                                        Do While dt.Columns.Contains(Include(i) & intNextCol.ToString)
                                            intNextCol = intNextCol + 1
                                        Loop

                                        dc = New DataColumn()
                                        dc.ColumnName = Include(i) & intNextCol.ToString
                                        dc.DataType = Type.GetType("System.Decimal")
                                        If fleTemp.GetObjectSize(Include(i).ToString).Trim <> "" Then
                                            If _
                                                hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                    Include(i).ToString.ToLower.ToLower & intNextCol.ToString) Then
                                                If _
                                                    Not _
                                                    hsLenght.Contains(Include(i).ToString.ToLower & intNextCol.ToString) _
                                                    Then _
                                                    hsLenght.Add(Include(i).ToString.ToLower & intNextCol.ToString,
                                                                 hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                     Include(i).ToString.ToLower.ToLower &
                                                                     intNextCol.ToString))
                                            ElseIf _
                                                hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                    Include(i).ToString.ToLower.ToLower) Then
                                                If _
                                                    Not _
                                                    hsLenght.Contains(Include(i).ToString.ToLower & intNextCol.ToString) _
                                                    Then _
                                                    hsLenght.Add(Include(i).ToString.ToLower & intNextCol.ToString,
                                                                 hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                     Include(i).ToString.ToLower.ToLower))
                                            Else
                                                If _
                                                    Not _
                                                    hsLenght.Contains(Include(i).ToString.ToLower & intNextCol.ToString) _
                                                    Then _
                                                    hsLenght.Add(Include(i).ToString.ToLower & intNextCol.ToString, 10)
                                            End If
                                        End If
                                        dt.Columns.Add(dc)

                                        'build the columns
                                        strColumns = strColumns & Include(i) & m_strDelimiter
                                        If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                            strValues = strValues & fleTemp.GetDecimalValue(Include(i)) & m_strDelimiter
                                        strDataValues = strDataValues & fleTemp.GetDecimalValue(Include(i)) & m_strDelimiter
                                        If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) _
                                            Then
                                            strCreateTable = strCreateTable & dc.ColumnName & " FLOAT" & ","
                                        End If
                                    End Try

                            End Select

                        Case "CORE.FRAMEWORK.CORE.FRAMEWORK.DCHARACTER", "CORE.FRAMEWORK.CORE.FRAMEWORK.DVARCHAR",
                            "CORE.WINDOWS.UI.CORE.WINDOWS.CORECHARACTER"

                            Try
                                If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                    dc = New DataColumn()
                                    dc.ColumnName = Include(i).Name
                                    dc.DataType = Type.GetType("System.String")
                                    If Include(i).Size > 0 Then
                                        dc.MaxLength = Include(i).Size
                                        If Not hsLenght.Contains(Include(i).Name.ToString.ToLower) Then _
                                            hsLenght.Add(Include(i).Name.ToString.ToLower, Include(i).Size)
                                    End If
                                    dt.Columns.Add(dc)
                                End If

                                strColumns = strColumns & Include(i).Name & m_strDelimiter
                                If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                    strValues = strValues & StringToField(Include(i).Value) & m_strDelimiter
                                strDataValues = strDataValues & Include(i).Value & m_strDelimiter
                                If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                    strCreateTable = strCreateTable & dc.ColumnName & " VARCHAR("
                                    strCreateTable = strCreateTable & dc.MaxLength & ") " & strCulture & " NULL ,"
                                End If
                            Catch ex As Exception
                                Dim intNextCol As Integer = 2
                                Do While dt.Columns.Contains(Include(i).Name & intNextCol.ToString)
                                    intNextCol = intNextCol + 1
                                Loop

                                dc = New DataColumn()
                                dc.ColumnName = Include(i).Name & intNextCol.ToString
                                dc.DataType = Type.GetType("System.String")
                                If Include(i).Size > 0 Then
                                    dc.MaxLength = Include(i).Size
                                    If Not hsLenght.Contains(Include(i).Name.ToString.ToLower & intNextCol.ToString) _
                                        Then _
                                        hsLenght.Add(Include(i).Name.ToString.ToLower & intNextCol.ToString,
                                                     Include(i).Size)
                                End If
                                dt.Columns.Add(dc)

                                strColumns = strColumns & Include(i).Name & m_strDelimiter
                                If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                    strValues = strValues & StringToField(Include(i).Value) & m_strDelimiter
                                strDataValues = strDataValues & Include(i).Value & m_strDelimiter
                                If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                    strCreateTable = strCreateTable & dc.ColumnName & " VARCHAR("
                                    strCreateTable = strCreateTable & dc.MaxLength & ") " & strCulture & " NULL ,"
                                End If
                            End Try

                        Case "CORE.WINDOWS.UI.CORE.WINDOWS.COREDATE"

                            Try
                                If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                    dc = New DataColumn()
                                    dc.ColumnName = Include(i).Name
                                    dc.DataType = Type.GetType("System.DateTime")
                                    dt.Columns.Add(dc)
                                End If

                                'build the columns
                                strColumns = strColumns & Include(i).Name & m_strDelimiter

                                If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                    If GetDateFromYYYYMMDDDecimal(Include(i).Value) = cZeroDate Then
                                        strValues = strValues & "Null"
                                    Else
                                        strValues = strValues &
                                                    "CONVERT(DATETIME, " +
                                                    StringToField(
                                                        Format(CDate(GetDateFromYYYYMMDDDecimal(Include(i).Value)),
                                                               "yyyy-MM-dd HH:mm:ss")) + ", 120)"
                                    End If
                                    strValues = strValues & m_strDelimiter
                                End If

                                strDataValues = strDataValues & Include(i).Value & m_strDelimiter
                                If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                    strCreateTable = strCreateTable & dc.ColumnName & " DATETIME,"
                                End If
                            Catch ex As Exception
                                Dim intNextCol As Integer = 2
                                Do While dt.Columns.Contains(Include(i).Name & intNextCol.ToString)
                                    intNextCol = intNextCol + 1
                                Loop

                                dc = New DataColumn()
                                dc.ColumnName = Include(i).Name & intNextCol.ToString
                                dc.DataType = Type.GetType("System.DateTime")
                                dt.Columns.Add(dc)

                                'build the columns
                                strColumns = strColumns & Include(i).Name & m_strDelimiter

                                If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                    If GetDateFromYYYYMMDDDecimal(Include(i).Value) = cZeroDate Then
                                        strValues = strValues & "Null"
                                    Else
                                        strValues = strValues &
                                                    "CONVERT(DATETIME, " +
                                                    StringToField(
                                                        Format(CDate(GetDateFromYYYYMMDDDecimal(Include(i).Value)),
                                                               "yyyy-MM-dd HH:mm:ss")) + ", 120)"
                                    End If
                                    strValues = strValues & m_strDelimiter
                                End If

                                strDataValues = strDataValues & Include(i).Value.ToString.Replace("12:00:00 AM", "NULL") &
                                                m_strDelimiter
                                If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                    strCreateTable = strCreateTable & dc.ColumnName & " DATETIME,"
                                End If
                            End Try

                        Case "CORE.FRAMEWORK.CORE.FRAMEWORK.DDECIMAL", "CORE.FRAMEWORK.CORE.FRAMEWORK.DINTEGER",
                            "CORE.WINDOWS.UI.CORE.WINDOWS.COREDECIMAL", "CORE.WINDOWS.UI.CORE.WINDOWS.COREINTEGER"

                            Try
                                If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                    dc = New DataColumn()
                                    dc.ColumnName = Include(i).Name
                                    If (Include(i).GetType.ToString.ToUpper = "CORE.WINDOWS.UI.CORE.WINDOWS.COREINTEGER" OrElse
                                         Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DINTEGER") Then
                                        dc.DataType = Type.GetType("System.Int64")
                                    Else
                                        dc.DataType = Type.GetType("System.Decimal")
                                    End If
                                    If Include(i).Size > 0 Then
                                        If Not hsLenght.Contains(Include(i).Name.ToString.ToLower) Then _
                                            hsLenght.Add(Include(i).Name.ToString.ToLower, Include(i).Size)
                                    End If
                                    dt.Columns.Add(dc)
                                End If

                                strColumns = strColumns & Include(i).Name & m_strDelimiter
                                If _
                                    (Include(i).GetType.ToString.ToUpper = "CORE.WINDOWS.UI.CORE.WINDOWS.COREINTEGER" OrElse
                                     Include(i).GetType.ToString.ToUpper = "CORE.WINDOWS.UI.CORE.WINDOWS.COREDECIMAL" OrElse
                                     Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DDECIMAL" OrElse
                                     Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DINTEGER") _
                                    AndAlso Include(i).IsSubtotal Then
                                    SubTotalValue = Include(i).SubTotalValue
                                    If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                        strValues = strValues & SubTotalValue & m_strDelimiter
                                    strDataValues = strDataValues & SubTotalValue & m_strDelimiter
                                Else
                                    If _
                                        (Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DDECIMAL" OrElse
                                         Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DINTEGER") AndAlso
                                        Include(i).IsMaximum Then
                                        SubTotalValue = Include(i).MaximumValue
                                        If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) Then strValues = strValues & SubTotalValue & m_strDelimiter
                                        strDataValues = strDataValues & SubTotalValue & m_strDelimiter
                                    End If

                                    Dim tmpsizeval As String = Include(i).Value
                                    If Include(i).Size > 0 AndAlso tmpsizeval.Length > Include(i).Size Then
                                        If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                       strValues = strValues & tmpsizeval.Substring(0, Include(i).Size) & m_strDelimiter
                                        strDataValues = strDataValues & tmpsizeval.Substring(0, Include(i).Size) & m_strDelimiter
                                    Else
                                        If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                       strValues = strValues & tmpsizeval & m_strDelimiter
                                        strDataValues = strDataValues & tmpsizeval & m_strDelimiter
                                    End If



                                End If

                                If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                    If _
                                        (Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DDECIMAL" OrElse
                                         Include(i).GetType.ToString.ToUpper = "CORE.WINDOWS.UI.CORE.WINDOWS.COREDECIMAL") Then
                                        strCreateTable = strCreateTable & dc.ColumnName & " DECIMAL(18,2),"
                                    Else
                                        strCreateTable = strCreateTable & dc.ColumnName & " FLOAT" & ","
                                    End If
                                End If
                            Catch ex As Exception
                                Dim intNextCol As Integer = 2
                                Do While dt.Columns.Contains(Include(i).Name & intNextCol.ToString)
                                    intNextCol = intNextCol + 1
                                Loop

                                dc = New DataColumn()
                                dc.ColumnName = Include(i).Name & intNextCol.ToString
                                dc.DataType = Type.GetType("System.Decimal")
                                If Include(i).Size > 0 Then
                                    If Not hsLenght.Contains(Include(i).Name.ToString.ToLower & intNextCol.ToString) _
                                        Then _
                                        hsLenght.Add(Include(i).Name.ToString.ToLower & intNextCol.ToString,
                                                     Include(i).Size)
                                End If
                                dt.Columns.Add(dc)

                                strColumns = strColumns & Include(i).Name & m_strDelimiter
                                If _
                                    (Include(i).GetType.ToString.ToUpper = "CORE.WINDOWS.UI.CORE.WINDOWS.COREINTEGER" OrElse
                                     Include(i).GetType.ToString.ToUpper = "CORE.WINDOWS.UI.CORE.WINDOWS.COREDECIMAL" OrElse
                                     Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DDECIMAL" OrElse
                                     Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DINTEGER") _
                                    AndAlso Include(i).IsSubtotal Then
                                    SubTotalValue = Include(i).SubTotalValue
                                    If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                        strValues = strValues & SubTotalValue & m_strDelimiter
                                    strDataValues = strDataValues & SubTotalValue & m_strDelimiter
                                Else
                                    If _
                                        (Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DDECIMAL" OrElse
                                         Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DINTEGER") AndAlso
                                        Include(i).IsMaximum Then
                                        SubTotalValue = Include(i).MaximumValue
                                        If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) Then strValues = strValues & SubTotalValue & m_strDelimiter
                                        strDataValues = strDataValues & SubTotalValue & m_strDelimiter
                                    End If
                                    Dim tmpsizeval As String = Include(i).Value
                                    If Include(i).Size > 0 AndAlso tmpsizeval.Length > Include(i).Size Then
                                        If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                       strValues = strValues & tmpsizeval.Substring(0, Include(i).Size) & m_strDelimiter
                                        strDataValues = strDataValues & tmpsizeval.Substring(0, Include(i).Size) & m_strDelimiter
                                    Else
                                        If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                       strValues = strValues & tmpsizeval & m_strDelimiter
                                        strDataValues = strDataValues & tmpsizeval & m_strDelimiter
                                    End If
                                End If

                                If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                    If _
                                        (Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DDECIMAL" OrElse
                                         Include(i).GetType.ToString.ToUpper = "CORE.WINDOWS.UI.CORE.WINDOWS.COREDECIMAL") Then
                                        strCreateTable = strCreateTable & dc.ColumnName & " DECIMAL(18,2),"
                                    Else
                                        strCreateTable = strCreateTable & dc.ColumnName & " FLOAT" & ","
                                    End If
                                End If
                            End Try

                        Case "CORE.FRAMEWORK.CORE.FRAMEWORK.DDATE", "CORE.WINDOWS.UI.CORE.WINDOWS.COREDATE"

                            Try
                                If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                    dc = New DataColumn()
                                    dc.ColumnName = Include(i).Name
                                    dc.DataType = Type.GetType("System.DateTime")
                                    dt.Columns.Add(dc)
                                End If

                                strColumns = strColumns & Include(i).Name & m_strDelimiter

                                If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                    If GetDateFromYYYYMMDDDecimal(Include(i).Value) = cZeroDate Then
                                        strValues = strValues & "Null"
                                    Else
                                        strValues = strValues &
                                                    "CONVERT(DATETIME, " +
                                                    StringToField(
                                                        Format(CDate(GetDateFromYYYYMMDDDecimal(Include(i).Value)),
                                                               "yyyy-MM-dd HH:mm:ss")) + ", 120)"
                                    End If
                                    strValues = strValues & m_strDelimiter
                                End If

                                strDataValues = strDataValues & Include(i).Value & m_strDelimiter
                                If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                    strCreateTable = strCreateTable & dc.ColumnName & " DATETIME,"
                                End If
                            Catch ex As Exception
                                Dim intNextCol As Integer = 2
                                Do While dt.Columns.Contains(Include(i).Name & intNextCol.ToString)
                                    intNextCol = intNextCol + 1
                                Loop

                                dc = New DataColumn()
                                dc.ColumnName = Include(i).Name & intNextCol.ToString
                                dc.DataType = Type.GetType("System.DateTime")
                                dt.Columns.Add(dc)

                                strColumns = strColumns & Include(i).Name & m_strDelimiter

                                If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                    strValues = strValues &
                                                GetDateFromYYYYMMDDDecimal(Include(i).Value).ToString.Replace(
                                                    "12:00:00 AM", "NULL") & m_strDelimiter
                                    If GetDateFromYYYYMMDDDecimal(Include(i).Value) = cZeroDate Then
                                        strValues = strValues & "Null"
                                    Else
                                        strValues = strValues &
                                                    "CONVERT(DATETIME, " +
                                                    StringToField(
                                                        Format(CDate(GetDateFromYYYYMMDDDecimal(Include(i).Value)),
                                                               "yyyy-MM-dd HH:mm:ss")) + ", 120)"
                                    End If
                                    strValues = strValues & m_strDelimiter
                                End If

                                If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                    strCreateTable = strCreateTable & dc.ColumnName & " DATETIME,"
                                End If
                            End Try
                    End Select

                Next

                'If Not strInsertRowSQL.ToString = "" Then

                If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                    strValues = strValues.Substring(0, strValues.Length - 1)
                If strDataValues <> "" Then
                    strDataValues = strDataValues.Substring(0, strDataValues.Length - 1)
                End If

                strColumns = ""
                For i As Integer = 0 To dt.Columns.Count - 1
                    If _
                        dt.Columns.Item(i).ColumnName.ToLower <> "row_id" AndAlso
                        dt.Columns.Item(i).ColumnName.ToLower <> "checksum_value" Then
                        strColumns = strColumns & dt.Columns(i).ColumnName & m_strDelimiter
                    End If
                Next

                If strColumns <> "" Then
                    strColumns = strColumns.Substring(0, strColumns.Length - 1)
                End If


                If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                    'create insert sql

                    strInsertRowSQL.Append("(")
                    strInsertRowSQL.Append(strColumns)
                    strInsertRowSQL.Append(")")
                    strInsertRowSQL.Append(" VALUES ")
                    strInsertRowSQL.Append("(")
                    strInsertRowSQL.Append(strValues)
                    strInsertRowSQL.Append(")")

                End If

                If Not blnQTPSubFile OrElse blnAppendSubFile Then
                    dc = New DataColumn()
                    dc.ColumnName = "CHECKSUM_VALUE"
                    dc.DataType = Type.GetType("System.Decimal")
                    dt.Columns.Add(dc)
                End If

                'build the columns
                strColumns = strColumns & m_strDelimiter & "CHECKSUM_VALUE"
                'strValues = strValues & "~" & "0" ' Not used
                strDataValues = strDataValues & m_strDelimiter & "0"

                If Not blnQTPSubFile OrElse blnAppendSubFile Then
                    dc = New DataColumn()
                    dc.ColumnName = "ROW_ID"
                    dc.DataType = Type.GetType("System.String")
                    dt.Columns.Add(dc)
                End If

                'build the columns
                strColumns = strColumns & m_strDelimiter & "ROW_ID"
                'strValues = strValues & "~" & StringToField(Now.TimeOfDay.TotalMilliseconds.ToString & (intSubFileRow).ToString) ' Not used
                strDataValues = strDataValues & m_strDelimiter & Now.TimeOfDay.TotalMilliseconds.ToString &
                                (intSubFileRow).ToString

                arrColumns = strColumns.Split(m_strDelimiter)
                arrValues = strDataValues.Split(m_strDelimiter)
                rw = dt.NewRow
                For j As Integer = 0 To dt.Columns.Count - 1
                    If _
                        dt.Columns(j).DataType.ToString = "System.DateTime" AndAlso
                        (arrValues(j) = "0" OrElse arrValues(j) = "") Then
                    ElseIf dt.Columns(j).DataType.ToString = "System.DateTime" Then
                        Dim _
                            dateTimeInfo As _
                                New DateTime(CInt(arrValues(j).ToString.PadRight(16, "0").Substring(0, 4)),
                                             CInt(arrValues(j).ToString.PadRight(16, "0").Substring(4, 2)),
                                             CInt(arrValues(j).ToString.PadRight(16, "0").Substring(6, 2)),
                                             CInt(arrValues(j).ToString.PadRight(16, "0").Substring(8, 2)),
                                             CInt(arrValues(j).ToString.PadRight(16, "0").Substring(10, 2)),
                                             CInt(arrValues(j).ToString.PadRight(16, "0").Substring(12, 4)))
                        rw.Item(arrColumns(j)) = dateTimeInfo
                    ElseIf dt.Columns(j).DataType.ToString = "System.Decimal" Then
                        If arrValues(j).Trim = "" Then
                            rw.Item(arrColumns(j)) = 0
                        ElseIf arrValues(j).Trim = 0 Then
                            rw.Item(arrColumns(j)) = Convert.ToDecimal(arrValues(j))
                        Else
                            rw.Item(arrColumns(j)) = arrValues(j)
                        End If

                    Else
                        rw.Item(arrColumns(j)) = arrValues(j)
                    End If
                Next
                dt.Rows.Add(rw)
                'strValues = "" ' Not used
                strColumns = ""

                SubfileObject.m_dtbDataTable = dt
                SubfileObject.blnOverRideOccurrence = True
                SubfileObject.OverRideOccurrence = dt.Rows.Count - 1
                SubfileObject.Occurs = dt.Rows.Count
                SubfileObject.SubfileInit(dt.Rows.Count - 1)
                SubfileObject.IsInitialized = True
                SubfileObject.RaiseSetItemFinals()
                dt = SubfileObject.m_dtbDataTable

                If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then

                    Dim strNewValues As String = String.Empty

                    For i As Integer = 0 To dt.Columns.Count - 1
                        If dt.Columns(i).ColumnName <> "CHECKSUM_VALUE" AndAlso dt.Columns(i).ColumnName <> "ROW_ID" _
                            Then
                            If dt.Columns(i).DataType.ToString = "System.DateTime" Then
                                If _
                                    IsNull(dt.Rows(dt.Rows.Count - 1)(i)) OrElse
                                    dt.Rows(dt.Rows.Count - 1)(i) = #12:00:00 AM# Then
                                    strNewValues = strNewValues & "NULL, "
                                Else
                                    strNewValues = strNewValues &
                                                   "CONVERT(DATETIME, " +
                                                   StringToField(Format(dt.Rows(dt.Rows.Count - 1)(i),
                                                                        "yyyy-MM-dd HH:mm:ss")) + ", 120), "
                                End If

                            ElseIf _
                                dt.Columns(i).DataType.ToString = "System.Decimal" OrElse
                                dt.Columns(i).DataType.ToString = "System.Double" OrElse
                                dt.Columns(i).DataType.ToString = "System.Integer" Then
                                strNewValues = strNewValues & dt.Rows(dt.Rows.Count - 1)(i).ToString & ", "
                            Else
                                'strNewValues = strNewValues & "'" & dt.Rows(dt.Rows.Count - 1)(i).ToString & "', "
                                strNewValues = strNewValues & StringToField(dt.Rows(dt.Rows.Count - 1)(i).ToString) &
                                               ", "
                            End If
                        End If

                    Next
                    strNewValues = strNewValues.Substring(0, strNewValues.Length - 2)
                    strInsertRowSQL = New StringBuilder(strInsertRowSQL.ToString.Replace(strValues, strNewValues))
                End If

                'Dim strConnect As String = GetConnectionString()
                If Not blnQTPSubFile Then
                    If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                        strCreateTableSQL.Append("(").Append(" ROWID uniqueidentifier NULL DEFAULT (newid()), ")
                        strCreateTableSQL.Append(strCreateTable).Append(" CHECKSUM_VALUE FLOAT DEFAULT 0 ").Append(")")
                    End If

                    'Check if table already exists
                    Dim blnKeepTable As Boolean
                    If IsNothing(ConfigurationManager.AppSettings("KeepSubFile")) Then
                        blnKeepTable = False
                    Else
                        blnKeepTable = ConfigurationManager.AppSettings("KeepSubFile").ToUpper = "TRUE"
                    End If

                    strSQL = New StringBuilder(String.Empty)
                    strSQL.Append("SELECT * FROM ").Append("sysobjects WHERE TYPE='U' AND NAME='").
                        Append(strName).Append("'")

                    objReader = SqlHelper.ExecuteReader(strConnect, CommandType.Text, strSQL.ToString)

                    If objReader.Read Then
                        strSQL.Remove(0, strSQL.Length)
                        If strSchema <> "" Then
                            strSQL.Append("DROP TABLE ").Append(strSchema).Append(".").Append(strName)
                        Else
                            strSQL.Append("DROP TABLE ").Append(strName)
                        End If
                        Try
                            SqlHelper.ExecuteNonQuery(strConnect, CommandType.Text, strSQL.ToString.Replace("..", "."))
                        Catch ex As Exception

                        End Try

                    End If

                    If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                        'Table does not exists
                        'Create Table
                        SqlHelper.ExecuteNonQuery(strConnect, CommandType.Text, strCreateTableSQL.ToString)
                    End If
                End If

                If Not NoSubFileData AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) AndAlso Not blnDeletedSubFile Then
                    SqlHelper.ExecuteNonQuery(strConnect, CommandType.Text, strInsertRowSQL.ToString.Replace(m_strDelimiter, ","))
                End If

                If _
                    Not _
                    Session(UniqueSessionID + "hsSubfileKeepText").Contains(strName) _
                    Then
                    Session(UniqueSessionID + "hsSubfileKeepText").Add(strName,
                                                                       hsLenght)
                ElseIf _
                    IsNothing(
                        Session(UniqueSessionID + "hsSubfileKeepText").Item(strName)) _
                    Then
                    Session(UniqueSessionID + "hsSubfileKeepText").Remove(strName)
                    Session(UniqueSessionID + "hsSubfileKeepText").Add(strName,
                                                                       hsLenght)
                End If

                If NoSubFileData Then
                    dt.Rows.RemoveAt(dt.Rows.Count - 1)
                End If

                If SubType = SubFileType.TempText OrElse ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso IsKeepText) Then

                    If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not arrKeepFile.Contains(strName) Then
                        arrKeepFile.Add(strName)
                    End If

                    ' GW2018. Added. As soon as we formed the first record, create the MiniDictionary
                    'g_recordCount = g_recordCount + 1
                    'If (g_recordCount = 1) Then
                    WriteMiniDictionaryFile(strName, dt, Session(UniqueSessionID + "hsSubfileKeepText").Item(strName))
                    'End If

                    If dt.Rows.Count > 4999 Then
                        PutDataTextTable(strName, dt, Session(UniqueSessionID + "hsSubfileKeepText").Item(strName))
                        blnOver5000Records = True
                        dt.Clear()
                    End If

                End If

                blnQTPSubFile = True

                If (blnDeletedSubFile OrElse Not IsKeepText) AndAlso dt.Rows.Count > 0 Then
                    dt.Rows.RemoveAt(0)
                End If

                If Session(UniqueSessionID + "hsSubfile").Contains(strName) Then
                    Session(UniqueSessionID + "hsSubfile").Item(strName) = dt
                Else
                    Session(UniqueSessionID + "hsSubfile").Add(strName, dt)
                End If

                'AddRecordsRead(strName, 0, LogType.OutPut)

                Dim processedname As String

                If SubfileObject.AliasName <> "" Then
                    processedname = SubfileObject.AliasName
                    If Not arrSubFiles.Contains(processedname) Then
                        arrSubFiles.Add(processedname)
                        If (Not m_hsFileInOutput.Contains(processedname)) Then
                            m_hsFileInOutput.Add(processedname, processedname)
                        End If
                    End If
                Else
                    processedname = strName
                End If

                If blnDeletedSubFile OrElse NoSubFileData Then
                    'AddRecordsRead(strName, 0, LogType.Added)
                    AddRecordsProcessed(processedname, 0, LogType.Added)
                Else
                    'AddRecordsRead(strName, 1, LogType.Added)
                    AddRecordsProcessed(processedname, 1, LogType.Added)
                End If

                If Not arrSubFiles.Contains(strName) Then
                    arrSubFiles.Add(strName)
                    If (Not m_hsFileInOutput.Contains(strName)) Then
                        m_hsFileInOutput.Add(strName, strName)
                    End If
                End If

            Catch ex As Exception

                WriteError(ex)

            Finally

                If Not IsNothing(objReader) Then
                    objReader.Close()
                    objReader = Nothing
                End If
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
                If Not IsNothing(dc) Then
                    dc.Dispose()
                    dc = Nothing
                End If
                rw = Nothing
                arrColumns = Nothing
                arrValues = Nothing

                hsLenght = Nothing
                hsSubfileKeepText = Nothing

            End Try
        End Sub

        Public Sub SubFile(ByRef m_trnTRANS_UPDATE As SqlTransaction, strName As String, SubType As SubFileType,
                           ByVal ParamArray Include() As Object)

            AddRecordsProcessed(strName, 0, LogType.Added)

            Dim objReader As SqlDataReader
            Dim strSQL As New StringBuilder("")
            Dim strCreateTableSQL As New StringBuilder("")
            Dim strInsertRowSQL As New StringBuilder("")
            Dim intTableCount As Integer = 0
            Dim fleTemp As SqlFileObject
            Dim strColumns As String = String.Empty
            Dim strValues As String = String.Empty
            Dim strDataValues As String = String.Empty
            Dim strCreateTable As String = String.Empty
            Dim strSchema As String = ConfigurationManager.AppSettings("SubFileSchema") & ""
            Dim IsKeepText As Boolean = (ConfigurationManager.AppSettings("SubfileKEEPtoTEXT") & "").ToUpper = "TRUE"
            Dim intSubFileRow As Integer = 0
            Dim SubTotalValue As String = String.Empty
            Dim hsLenght As New Hashtable
            Dim hsSubfileKeepText As SortedList
            hsSubfileKeepText = Session(UniqueSessionID + "hsSubfileKeepText")
            Dim strCulture As String = ConfigurationManager.AppSettings("Culture") & ""
            Dim strSubfileNumeric As String = ConfigurationManager.AppSettings("SubFileNumeric") & ""
            Dim strConnect As String = GetConnectionString()

             If SubType = SubFileType.KeepSQL
                SubType = SubFileType.Keep
                IsKeepText = False 
            End If

            If NoSubFileData Then
                If NoDataSubfile.Contains(strName) Then
                    Return
                End If
                NoDataSubfile.Add(strName)
            End If

            If strCulture.Length > 0 Then
                strCulture = " COLLATE " & strCulture
            End If

            If SubType = SubFileType.KeepText Then
                IsKeepText = True
                SubType = SubFileType.Keep
            End If

            If strSchema.Length > 0 Then
                strSchema = strSchema & "."
            End If

            Dim dt As DataTable
            Dim dt2 As DataTable
            Dim dt2_Value As DataTable
            Dim dc As DataColumn
            Dim rw As DataRow
            Dim arrColumns() As String
            Dim arrValues() As String

            If IsKeepText AndAlso SubType <> SubFileType.Keep AndAlso SubType <> SubFileType.Portable Then
                Session(UniqueSessionID + "alSubTempFile").Add(strName & "_" & Session("SessionID"))
            End If

            If SubType = SubFileType.Portable Then
                If IsNothing(Session("PortableSubFiles")) Then
                    Session("PortableSubFiles") = New ArrayList
                    DirectCast(Session("PortableSubFiles"), ArrayList).Add(strName)
                Else
                    If Not DirectCast(Session("PortableSubFiles"), ArrayList).Contains(strName) Then
                        DirectCast(Session("PortableSubFiles"), ArrayList).Add(strName)
                    End If
                End If
            End If

            ' If we have a temp table that is kept in memory, store the INTEGER or DECIMAL columns in
            ' a hashtable to determine the decimal value decimal.
            Dim htDecimals As Hashtable = Nothing
            Dim hasItemCache As Boolean = False
            If SubType = SubFileType.Temp Then
                hasItemCache = Not Session(strName + "_DataTypes") Is Nothing
                If Not hasItemCache Then htDecimals = New Hashtable
            End If

            If Session(UniqueSessionID + "hsSubfile").Contains(strName) Then
                dt = Session(UniqueSessionID + "hsSubfile").Item(strName)
                blnQTPSubFile = True

                If IsNothing(dt) Then
                    intSubFileRow = 1
                    dt = New DataTable(strName)
                Else
                    intSubFileRow = dt.Rows.Count + 1
                    blnAppendSubFile = False
                End If

            Else
                If SubType = SubFileType.TempText OrElse ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso IsKeepText) Then
                    DeleteDataTextTable(strName, False)
                End If
                dt = New DataTable(strName)
                blnQTPSubFile = False
                intSubFileRow = 1
            End If

            If blnDeleteSubFile Then
                blnDeletedSubFile = True
            End If

            blnHasRunSubfile = True

            Try
                If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                    strCreateTableSQL.Append("CREATE TABLE ")
                    If strSchema <> "" Then
                        strCreateTableSQL.Append(strSchema).Append(strName)
                    Else
                        strCreateTableSQL.Append(strName)
                    End If
                End If

                If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                    strInsertRowSQL.Append(" INSERT INTO ")
                    If strSchema <> "" Then
                        strInsertRowSQL.Append(strSchema).Append(strName)
                    Else
                        strInsertRowSQL.Append(strName)
                    End If
                End If

                'Find the tables and Colunms
                For i As Integer = 0 To Include.Length - 1

                    Select Case Include(i).GetType.ToString.ToUpper

                        Case "CORE.WINDOWS.UI.CORE.WINDOWS.SQLFILEOBJECT"
                            intTableCount = intTableCount + 1
                            fleTemp = Include(i)

                            If fleTemp.m_dtbDataTable Is Nothing Then
                                fleTemp.CreateDataStructure()
                            End If


                            'Get all the the record structure of the file object
                            If i = Include.Length - 1 OrElse Include(i + 1).GetType.ToString <> "System.String" Then

                                For j As Integer = 0 To fleTemp.Columns.Count - 1

                                    If _
                                        fleTemp.Columns.Item(j).ColumnName <> "ROW_ID" AndAlso
                                        fleTemp.Columns.Item(j).ColumnName <> "CHECKSUM_VALUE" Then

                                        Select Case fleTemp.GetObjectType(fleTemp.Columns.Item(j).ColumnName)
                                            Case "System.String"

                                                Try
                                                    If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                                        dc = New DataColumn()
                                                        dc.ColumnName = fleTemp.Columns.Item(j).ColumnName
                                                        dc.DataType = Type.GetType("System.String")

                                                        If _
                                                            VAL(
                                                                fleTemp.GetObjectSize(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower)) <> 0 _
                                                            Then
                                                            If _
                                                                hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                                hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower) Then
                                                                If Not hsLenght.Contains(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower) Then _
                                                                    hsLenght.Add(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower,
                                                                        hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                            fleTemp.Columns.Item(j).ColumnName.ToLower))
                                                                dc.MaxLength =
                                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower)
                                                            Else
                                                                If _
                                                                    Not _
                                                                    hsLenght.Contains(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower) Then _
                                                                    hsLenght.Add(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower,
                                                                        VAL(
                                                                            fleTemp.GetObjectSize(
                                                                                fleTemp.Columns.Item(j).ColumnName.
                                                                                                     ToLower)))
                                                                dc.MaxLength =
                                                                    VAL(
                                                                        fleTemp.GetObjectSize(
                                                                            fleTemp.Columns.Item(j).ColumnName.ToLower))
                                                            End If
                                                        End If


                                                        dt.Columns.Add(dc)

                                                    End If

                                                    'build the columns
                                                    strColumns = strColumns & fleTemp.Columns.Item(j).ColumnName & m_strDelimiter
                                                    If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                                        strValues = strValues &
                                                                    StringToField(
                                                                        fleTemp.GetStringValue(
                                                                            fleTemp.Columns.Item(j).ColumnName)) & m_strDelimiter
                                                    strDataValues = strDataValues &
                                                                    fleTemp.GetStringValue(
                                                                        fleTemp.Columns.Item(j).ColumnName) & m_strDelimiter

                                                    If _
                                                        Not blnQTPSubFile AndAlso
                                                        ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                                        strCreateTable = strCreateTable & dc.ColumnName & " VARCHAR("
                                                        strCreateTable = strCreateTable & dc.MaxLength & ") " &
                                                                         strCulture & " NULL ,"
                                                    End If

                                                Catch ex As Exception
                                                    Dim intNextCol As Integer = 2
                                                    Do _
                                                        While _
                                                            dt.Columns.Contains(
                                                                fleTemp.Columns.Item(j).ColumnName & intNextCol.ToString)
                                                        intNextCol = intNextCol + 1
                                                    Loop

                                                    dc = New DataColumn()
                                                    dc.ColumnName = fleTemp.Columns.Item(j).ColumnName &
                                                                    intNextCol.ToString
                                                    dc.DataType = Type.GetType("System.String")

                                                    If _
                                                        VAL(
                                                            fleTemp.GetObjectSize(
                                                                fleTemp.Columns.Item(j).ColumnName.ToLower)) <> 0 Then
                                                        If _
                                                            hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                            hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                                fleTemp.Columns.Item(j).ColumnName & intNextCol.ToString) _
                                                            Then
                                                            If _
                                                                Not _
                                                                hsLenght.Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString) Then _
                                                                hsLenght.Add(
                                                                    fleTemp.Columns.Item(j).ColumnName &
                                                                    intNextCol.ToString,
                                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                        fleTemp.Columns.Item(j).ColumnName &
                                                                        intNextCol.ToString))
                                                            dc.MaxLength =
                                                                hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                    fleTemp.Columns.Item(j).ColumnName &
                                                                    intNextCol.ToString)
                                                        ElseIf _
                                                            hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                            hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                                fleTemp.Columns.Item(j).ColumnName) Then
                                                            If _
                                                                Not _
                                                                hsLenght.Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString) Then _
                                                                hsLenght.Add(
                                                                    fleTemp.Columns.Item(j).ColumnName &
                                                                    intNextCol.ToString,
                                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                        fleTemp.Columns.Item(j).ColumnName))
                                                            dc.MaxLength =
                                                                hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                    fleTemp.Columns.Item(j).ColumnName)
                                                        Else
                                                            If _
                                                                Not _
                                                                hsLenght.Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString) Then _
                                                                hsLenght.Add(
                                                                    fleTemp.Columns.Item(j).ColumnName &
                                                                    intNextCol.ToString,
                                                                    VAL(
                                                                        fleTemp.GetObjectSize(
                                                                            fleTemp.Columns.Item(j).ColumnName)))
                                                            dc.MaxLength =
                                                                VAL(
                                                                    fleTemp.GetObjectSize(
                                                                        fleTemp.Columns.Item(j).ColumnName))
                                                        End If
                                                    End If

                                                    dt.Columns.Add(dc)

                                                    'build the columns
                                                    strColumns = strColumns & fleTemp.Columns.Item(j).ColumnName & m_strDelimiter
                                                    If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                                        strValues = strValues &
                                                                    StringToField(
                                                                        fleTemp.GetStringValue(
                                                                            fleTemp.Columns.Item(j).ColumnName)) & m_strDelimiter
                                                    strDataValues = strDataValues &
                                                                    fleTemp.GetStringValue(
                                                                        fleTemp.Columns.Item(j).ColumnName) & m_strDelimiter
                                                    If _
                                                        Not blnQTPSubFile AndAlso
                                                        ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                                        strCreateTable = strCreateTable & dc.ColumnName & " VARCHAR("
                                                        strCreateTable = strCreateTable & dc.MaxLength & ") " &
                                                                         strCulture & " NULL ,"
                                                    End If

                                                End Try

                                            Case "System.DateTime"

                                                Try
                                                    If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                                        dc = New DataColumn()
                                                        dc.ColumnName = fleTemp.Columns.Item(j).ColumnName
                                                        dc.DataType = Type.GetType("System.DateTime")

                                                        dt.Columns.Add(dc)


                                                    End If

                                                    'build the columns
                                                    strColumns = strColumns & fleTemp.Columns.Item(j).ColumnName & m_strDelimiter

                                                    If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                                        If _
                                                            GetDateFromYYYYMMDDDecimal(
                                                                fleTemp.GetNumericDateTimeValue(
                                                                    fleTemp.Columns.Item(j).ColumnName)) = cZeroDate _
                                                            Then
                                                            strValues = strValues & "Null"
                                                        Else
                                                            strValues = strValues &
                                                                        "CONVERT(DATETIME, " +
                                                                        StringToField(
                                                                            Format(
                                                                                CDate(
                                                                                    GetDateFromYYYYMMDDDecimal(
                                                                                        fleTemp.GetNumericDateTimeValue(
                                                                                            fleTemp.Columns.Item(j).
                                                                                                                           ColumnName))),
                                                                                "yyyy-MM-dd HH:mm:ss")) + ", 120)"
                                                        End If
                                                        strValues = strValues & m_strDelimiter
                                                    End If

                                                    strDataValues = strDataValues &
                                                                    fleTemp.GetNumericDateTimeValue(
                                                                        fleTemp.Columns.Item(j).ColumnName) & m_strDelimiter
                                                    If _
                                                        Not blnQTPSubFile AndAlso
                                                        ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                                        strCreateTable = strCreateTable & dc.ColumnName & " DATETIME,"
                                                    End If

                                                Catch ex As Exception
                                                    Dim intNextCol As Integer = 2
                                                    Do _
                                                        While _
                                                            dt.Columns.Contains(
                                                                fleTemp.Columns.Item(j).ColumnName & intNextCol.ToString)
                                                        intNextCol = intNextCol + 1
                                                    Loop

                                                    dc = New DataColumn()
                                                    dc.ColumnName = fleTemp.Columns.Item(j).ColumnName &
                                                                    intNextCol.ToString
                                                    dc.DataType = Type.GetType("System.DateTime")
                                                    dt.Columns.Add(dc)

                                                    'build the columns
                                                    strColumns = strColumns & fleTemp.Columns.Item(j).ColumnName & m_strDelimiter

                                                    If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                                        If _
                                                            GetDateFromYYYYMMDDDecimal(
                                                                fleTemp.GetNumericDateTimeValue(
                                                                    fleTemp.Columns.Item(j).ColumnName)) = cZeroDate _
                                                            Then
                                                            strValues = strValues & "Null"
                                                        Else
                                                            strValues = strValues &
                                                                        "CONVERT(DATETIME, " +
                                                                        StringToField(
                                                                            Format(
                                                                                CDate(
                                                                                    GetDateFromYYYYMMDDDecimal(
                                                                                        fleTemp.GetNumericDateTimeValue(
                                                                                            fleTemp.Columns.Item(j).
                                                                                                                           ColumnName))),
                                                                                "yyyy-MM-dd HH:mm:ss")) + ", 120)"
                                                        End If
                                                        strValues = strValues & m_strDelimiter
                                                    End If

                                                    strDataValues = strDataValues &
                                                                    fleTemp.GetNumericDateTimeValue(
                                                                        fleTemp.Columns.Item(j).ColumnName) & m_strDelimiter
                                                    If _
                                                        Not blnQTPSubFile AndAlso
                                                        ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                                        strCreateTable = strCreateTable & dc.ColumnName & " DATETIME,"
                                                    End If
                                                End Try

                                            Case "System.Decimal", "System.Double", "System.Single"

                                                Try
                                                    ' If we have an integer or decimal in a temp table that is stored in memory,
                                                    ' save the decimal value ("18,0" for integer, "18,2" if decimal 2, etc.)
                                                    If SubType = SubFileType.Temp AndAlso Not hasItemCache Then
                                                        htDecimals.Add(fleTemp.Columns.Item(j).ColumnName.ToUpper,
                                                                       fleTemp.GetDecimalSize(
                                                                           fleTemp.Columns.Item(j).ColumnName))
                                                    End If

                                                    If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                                        dc = New DataColumn()
                                                        dc.ColumnName = fleTemp.Columns.Item(j).ColumnName
                                                        dc.DataType = Type.GetType("System.Decimal")
                                                        If _
                                                            VAL(
                                                                fleTemp.GetObjectSize(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower)) <> 0 _
                                                            Then
                                                            If _
                                                                hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                                hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower) Then
                                                                If _
                                                                    Not _
                                                                    hsLenght.Contains(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower) Then _
                                                                    hsLenght.Add(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower,
                                                                        hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                            fleTemp.Columns.Item(j).ColumnName.ToLower))
                                                            Else
                                                                If _
                                                                    Not _
                                                                    hsLenght.Contains(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower) Then _
                                                                    hsLenght.Add(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower,
                                                                        VAL(
                                                                            fleTemp.GetObjectSize(
                                                                                fleTemp.Columns.Item(j).ColumnName.
                                                                                                     ToLower)))
                                                            End If
                                                        End If

                                                        dt.Columns.Add(dc)

                                                    End If

                                                    'build the columns
                                                    strColumns = strColumns & fleTemp.Columns.Item(j).ColumnName & m_strDelimiter
                                                    If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                                        strValues = strValues &
                                                                    fleTemp.GetDecimalValue(
                                                                        fleTemp.Columns.Item(j).ColumnName) & m_strDelimiter
                                                    strDataValues = strDataValues &
                                                                    fleTemp.GetDecimalValue(
                                                                        fleTemp.Columns.Item(j).ColumnName) & m_strDelimiter
                                                    If _
                                                        Not blnQTPSubFile AndAlso
                                                        ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                                        If strSubfileNumeric.Length > 0 Then
                                                            strCreateTable = strCreateTable & dc.ColumnName &
                                                                             " DECIMAL(" &
                                                                             fleTemp.GetDecimalSize(
                                                                                 fleTemp.Columns.Item(j).ColumnName.
                                                                                                       ToLower) & "),"
                                                        Else
                                                            strCreateTable = strCreateTable & dc.ColumnName & " FLOAT,"
                                                        End If
                                                    End If
                                                Catch ex As Exception
                                                    Dim intNextCol As Integer = 2
                                                    Do _
                                                        While _
                                                            dt.Columns.Contains(
                                                                fleTemp.Columns.Item(j).ColumnName & intNextCol.ToString)
                                                        intNextCol = intNextCol + 1
                                                    Loop

                                                    dc = New DataColumn()
                                                    dc.ColumnName = fleTemp.Columns.Item(j).ColumnName &
                                                                    intNextCol.ToString
                                                    dc.DataType = Type.GetType("System.Decimal")
                                                    If _
                                                        VAL(
                                                            fleTemp.GetObjectSize(
                                                                fleTemp.Columns.Item(j).ColumnName.ToLower)) <> 0 Then
                                                        If _
                                                            hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                            hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                                fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                intNextCol.ToString) Then
                                                            If _
                                                                Not _
                                                                hsLenght.Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString) Then _
                                                                hsLenght.Add(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString,
                                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                        intNextCol.ToString))
                                                        ElseIf _
                                                            hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                            hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                                fleTemp.Columns.Item(j).ColumnName.ToLower) Then
                                                            If _
                                                                Not _
                                                                hsLenght.Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString) Then _
                                                                hsLenght.Add(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString,
                                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower))
                                                        Else
                                                            If _
                                                                Not _
                                                                hsLenght.Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString) Then _
                                                                hsLenght.Add(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString,
                                                                    VAL(
                                                                        fleTemp.GetObjectSize(
                                                                            fleTemp.Columns.Item(j).ColumnName.ToLower)))
                                                        End If
                                                    End If
                                                    dt.Columns.Add(dc)

                                                    'build the columns
                                                    strColumns = strColumns & fleTemp.Columns.Item(j).ColumnName & m_strDelimiter
                                                    If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                                        strValues = strValues &
                                                                    fleTemp.GetDecimalValue(
                                                                        fleTemp.Columns.Item(j).ColumnName) & m_strDelimiter
                                                    strDataValues = strDataValues &
                                                                    fleTemp.GetDecimalValue(
                                                                        fleTemp.Columns.Item(j).ColumnName) & m_strDelimiter
                                                    If _
                                                        Not blnQTPSubFile AndAlso
                                                        ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                                        If strSubfileNumeric.Length > 0 Then
                                                            strCreateTable = strCreateTable & dc.ColumnName &
                                                                             " DECIMAL(" &
                                                                             fleTemp.GetDecimalSize(
                                                                                 fleTemp.Columns.Item(j).ColumnName.
                                                                                                       ToLower) & "),"
                                                        Else
                                                            strCreateTable = strCreateTable & dc.ColumnName & " FLOAT,"
                                                        End If
                                                    End If
                                                End Try

                                            Case "System.Int32", "System.Int64"

                                                Try
                                                    ' If we have an integer or decimal in a temp table that is stored in memory,
                                                    ' save the decimal value ("18,0" for integer, "18,2" if decimal 2, etc.)
                                                    If SubType = SubFileType.Temp AndAlso Not hasItemCache Then
                                                        htDecimals.Add(fleTemp.Columns.Item(j).ColumnName.ToUpper,
                                                                       "18,0")
                                                    End If

                                                    If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                                        dc = New DataColumn()
                                                        dc.ColumnName = fleTemp.Columns.Item(j).ColumnName
                                                        dc.DataType = Type.GetType("System.Decimal")
                                                        If _
                                                            VAL(
                                                                fleTemp.GetObjectSize(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower)) <> 0 _
                                                            Then
                                                            If _
                                                                hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                                hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower) Then
                                                                If _
                                                                    Not _
                                                                    hsLenght.Contains(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower) Then _
                                                                    hsLenght.Add(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower,
                                                                        hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                            fleTemp.Columns.Item(j).ColumnName.ToLower))
                                                            Else
                                                                If _
                                                                    Not _
                                                                    hsLenght.Contains(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower) Then _
                                                                    hsLenght.Add(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower, 10)
                                                            End If
                                                        End If

                                                        dt.Columns.Add(dc)

                                                    End If

                                                    'build the columns
                                                    strColumns = strColumns & fleTemp.Columns.Item(j).ColumnName & m_strDelimiter
                                                    If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                                        strValues = strValues &
                                                                    fleTemp.GetDecimalValue(
                                                                        fleTemp.Columns.Item(j).ColumnName) & m_strDelimiter
                                                    strDataValues = strDataValues &
                                                                    fleTemp.GetDecimalValue(
                                                                        fleTemp.Columns.Item(j).ColumnName) & m_strDelimiter
                                                    If _
                                                        Not blnQTPSubFile AndAlso
                                                        ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                                        strCreateTable = strCreateTable & dc.ColumnName & " FLOAT" & ","
                                                    End If
                                                Catch ex As Exception
                                                    Dim intNextCol As Integer = 2
                                                    Do _
                                                        While _
                                                            dt.Columns.Contains(
                                                                fleTemp.Columns.Item(j).ColumnName & intNextCol.ToString)
                                                        intNextCol = intNextCol + 1
                                                    Loop

                                                    dc = New DataColumn()
                                                    dc.ColumnName = fleTemp.Columns.Item(j).ColumnName &
                                                                    intNextCol.ToString
                                                    dc.DataType = Type.GetType("System.Decimal")
                                                    If _
                                                        VAL(
                                                            fleTemp.GetObjectSize(
                                                                fleTemp.Columns.Item(j).ColumnName.ToLower)) <> 0 Then
                                                        If _
                                                            hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                            hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                                fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                intNextCol.ToString) Then
                                                            If _
                                                                Not _
                                                                hsLenght.Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString) Then _
                                                                hsLenght.Add(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString,
                                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                        intNextCol.ToString))
                                                        ElseIf _
                                                            hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                            hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                                fleTemp.Columns.Item(j).ColumnName.ToLower) Then
                                                            If _
                                                                Not _
                                                                hsLenght.Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString) Then _
                                                                hsLenght.Add(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString,
                                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                        fleTemp.Columns.Item(j).ColumnName.ToLower))
                                                        Else
                                                            If _
                                                                Not _
                                                                hsLenght.Contains(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString) Then _
                                                                hsLenght.Add(
                                                                    fleTemp.Columns.Item(j).ColumnName.ToLower &
                                                                    intNextCol.ToString, 10)
                                                        End If
                                                    End If
                                                    dt.Columns.Add(dc)

                                                    'build the columns
                                                    strColumns = strColumns & fleTemp.Columns.Item(j).ColumnName & m_strDelimiter
                                                    If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                                        strValues = strValues &
                                                                    fleTemp.GetDecimalValue(
                                                                        fleTemp.Columns.Item(j).ColumnName) & m_strDelimiter
                                                    strDataValues = strDataValues &
                                                                    fleTemp.GetDecimalValue(
                                                                        fleTemp.Columns.Item(j).ColumnName) & m_strDelimiter
                                                    If _
                                                        Not blnQTPSubFile AndAlso
                                                        ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                                        strCreateTable = strCreateTable & dc.ColumnName & " FLOAT" & ","
                                                    End If
                                                End Try
                                        End Select
                                    End If
                                Next
                            End If

                        Case "SYSTEM.STRING"

                            'build the Values
                            Select Case fleTemp.GetObjectType(Include(i))
                                Case ""
                                    Dim message As String = "Error on subfile : " + strName + ". Column '" + Include(i) + "' from Table '" + fleTemp.BaseName + "' does not exist."
                                    Dim ex As CustomApplicationException = New CustomApplicationException(message)
                                    Throw ex

                                Case "System.String"

                                    Try
                                        If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                            dc = New DataColumn()
                                            dc.ColumnName = Include(i)
                                            dc.DataType = Type.GetType("System.String")
                                            If fleTemp.GetObjectSize(Include(i).ToString).Trim <> "" Then

                                                If _
                                                    hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                        Include(i).ToString.ToLower.ToLower) Then
                                                    If Not hsLenght.Contains(Include(i).ToString.ToLower) Then _
                                                        hsLenght.Add(Include(i).ToString.ToLower,
                                                                     hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                         Include(i).ToString.ToLower.ToLower))
                                                    dc.MaxLength =
                                                        hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                            Include(i).ToString.ToLower.ToLower)
                                                Else
                                                    If Not hsLenght.Contains(Include(i).ToString.ToLower) Then _
                                                        hsLenght.Add(Include(i).ToString.ToLower,
                                                                     CInt(fleTemp.GetObjectSize(Include(i).ToString)))
                                                    dc.MaxLength = CInt(fleTemp.GetObjectSize(Include(i).ToString))
                                                End If

                                            End If

                                            dt.Columns.Add(dc)
                                        End If

                                        'build the columns
                                        strColumns = strColumns & Include(i) & m_strDelimiter
                                        If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                            strValues = strValues & StringToField(fleTemp.GetStringValue(Include(i))) &
                                                        m_strDelimiter
                                        strDataValues = strDataValues & fleTemp.GetStringValue(Include(i)) & m_strDelimiter
                                        If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) _
                                            Then
                                            strCreateTable = strCreateTable & dc.ColumnName & " VARCHAR("
                                            strCreateTable = strCreateTable & dc.MaxLength & ") " & strCulture &
                                                             " NULL ,"
                                        End If
                                    Catch ex As Exception
                                        Dim intNextCol As Integer = 2
                                        Do While dt.Columns.Contains(Include(i) & intNextCol.ToString)
                                            intNextCol = intNextCol + 1
                                        Loop

                                        dc = New DataColumn()
                                        dc.ColumnName = Include(i) & intNextCol.ToString
                                        dc.DataType = Type.GetType("System.String")
                                        If fleTemp.GetObjectSize(Include(i).ToString).Trim <> "" Then

                                            If _
                                                hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                    Include(i).ToString.ToLower.ToLower & intNextCol.ToString) Then
                                                If _
                                                    Not _
                                                    hsLenght.Contains(Include(i).ToString.ToLower & intNextCol.ToString) _
                                                    Then _
                                                    hsLenght.Add(Include(i).ToString.ToLower & intNextCol.ToString,
                                                                 hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                     Include(i).ToString.ToLower.ToLower &
                                                                     intNextCol.ToString))
                                                dc.MaxLength =
                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                        Include(i).ToString.ToLower.ToLower)
                                            ElseIf _
                                                hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                    Include(i).ToString.ToLower.ToLower) Then
                                                If _
                                                    Not _
                                                    hsLenght.Contains(Include(i).ToString.ToLower & intNextCol.ToString) _
                                                    Then _
                                                    hsLenght.Add(Include(i).ToString.ToLower & intNextCol.ToString,
                                                                 hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                     Include(i).ToString.ToLower.ToLower))
                                                dc.MaxLength =
                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                        Include(i).ToString.ToLower.ToLower)
                                            Else
                                                If _
                                                    Not _
                                                    hsLenght.Contains(Include(i).ToString.ToLower & intNextCol.ToString) _
                                                    Then _
                                                    hsLenght.Add(Include(i).ToString.ToLower & intNextCol.ToString,
                                                                 CInt(fleTemp.GetObjectSize(Include(i).ToString)))
                                                dc.MaxLength = CInt(fleTemp.GetObjectSize(Include(i).ToString))
                                            End If

                                        End If

                                        dt.Columns.Add(dc)

                                        'build the columns
                                        strColumns = strColumns & Include(i) & m_strDelimiter
                                        If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                            strValues = strValues & StringToField(fleTemp.GetStringValue(Include(i))) &
                                                        m_strDelimiter
                                        strDataValues = strDataValues & fleTemp.GetStringValue(Include(i)) & m_strDelimiter
                                        If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) _
                                            Then
                                            strCreateTable = strCreateTable & dc.ColumnName & " VARCHAR("
                                            strCreateTable = strCreateTable & dc.MaxLength & ") " & strCulture &
                                                             " NULL ,"
                                        End If
                                    End Try

                                Case "System.DateTime"

                                    Try
                                        If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                            dc = New DataColumn()
                                            dc.ColumnName = Include(i)
                                            dc.DataType = Type.GetType("System.DateTime")

                                            dt.Columns.Add(dc)
                                        End If

                                        'build the columns
                                        strColumns = strColumns & Include(i) & m_strDelimiter

                                        If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                            If _
                                                GetDateFromYYYYMMDDDecimal(fleTemp.GetNumericDateTimeValue(Include(i))) =
                                                cZeroDate Then
                                                strValues = strValues & "Null"
                                            Else
                                                strValues = strValues &
                                                            "CONVERT(DATETIME, " +
                                                            StringToField(
                                                                Format(
                                                                    CDate(
                                                                        GetDateFromYYYYMMDDDecimal(
                                                                            fleTemp.GetNumericDateTimeValue(Include(i)))),
                                                                    "yyyy-MM-dd HH:mm:ss")) + ", 120)"
                                            End If
                                            strValues = strValues & m_strDelimiter
                                        End If

                                        strDataValues = strDataValues & fleTemp.GetNumericDateTimeValue(Include(i)) &
                                                        m_strDelimiter
                                        If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) _
                                            Then
                                            strCreateTable = strCreateTable & dc.ColumnName & " DATETIME,"
                                        End If
                                    Catch ex As Exception
                                        Dim intNextCol As Integer = 2
                                        Do While dt.Columns.Contains(Include(i) & intNextCol.ToString)
                                            intNextCol = intNextCol + 1
                                        Loop

                                        dc = New DataColumn()
                                        dc.ColumnName = Include(i) & intNextCol.ToString
                                        dc.DataType = Type.GetType("System.DateTime")
                                        dt.Columns.Add(dc)

                                        'build the columns
                                        strColumns = strColumns & Include(i) & m_strDelimiter

                                        If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                            If _
                                                GetDateFromYYYYMMDDDecimal(fleTemp.GetNumericDateTimeValue(Include(i))) =
                                                cZeroDate Then
                                                strValues = strValues & "Null"
                                            Else
                                                strValues = strValues &
                                                            "CONVERT(DATETIME, " +
                                                            StringToField(
                                                                Format(
                                                                    CDate(
                                                                        GetDateFromYYYYMMDDDecimal(
                                                                            fleTemp.GetNumericDateTimeValue(Include(i)))),
                                                                    "yyyy-MM-dd HH:mm:ss")) + ", 120)"
                                            End If
                                            strValues = strValues & m_strDelimiter
                                        End If

                                        strDataValues = strDataValues &
                                                        fleTemp.GetNumericDateTimeValue(Include(i)).ToString.Replace(
                                                            "12:00:00 AM", "NULL") & m_strDelimiter
                                        If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) _
                                            Then
                                            strCreateTable = strCreateTable & dc.ColumnName & " DATETIME,"
                                        End If
                                    End Try

                                Case "System.Decimal", "System.Double", "System.Single"

                                    Try
                                        ' If we have an integer or decimal in a temp table that is stored in memory,
                                        ' save the decimal value ("18,0" for integer, "18,2" if decimal 2, etc.)
                                        If SubType = SubFileType.Temp AndAlso Not hasItemCache Then
                                            htDecimals.Add(Include(i).ToString.ToUpper,
                                                           fleTemp.GetDecimalSize(Include(i).ToString))
                                        End If

                                        If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                            dc = New DataColumn()
                                            dc.ColumnName = Include(i)
                                            dc.DataType = Type.GetType("System.Decimal")
                                            If fleTemp.GetObjectSize(Include(i).ToString).Trim <> "" Then
                                                If _
                                                    hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                        Include(i).ToString.ToLower.ToLower) Then
                                                    If Not hsLenght.Contains(Include(i).ToString.ToLower) Then _
                                                        hsLenght.Add(Include(i).ToString.ToLower,
                                                                     hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                         Include(i).ToString.ToLower.ToLower))
                                                Else
                                                    If Not hsLenght.Contains(Include(i).ToString.ToLower) Then _
                                                        hsLenght.Add(Include(i).ToString.ToLower,
                                                                     CInt(fleTemp.GetObjectSize(Include(i).ToString)))
                                                End If
                                            End If

                                            dt.Columns.Add(dc)
                                        End If

                                        'build the columns
                                        strColumns = strColumns & Include(i) & m_strDelimiter
                                        If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                            strValues = strValues & fleTemp.GetDecimalValue(Include(i)) & m_strDelimiter
                                        strDataValues = strDataValues & fleTemp.GetDecimalValue(Include(i)) & m_strDelimiter
                                        If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) _
                                            Then
                                            If strSubfileNumeric.Length > 0 Then
                                                strCreateTable = strCreateTable & dc.ColumnName & " DECIMAL(" &
                                                                 fleTemp.GetDecimalSize(Include(i).ToString) & "),"
                                            Else
                                                strCreateTable = strCreateTable & dc.ColumnName & " FLOAT,"
                                            End If
                                        End If
                                    Catch ex As Exception
                                        Dim intNextCol As Integer = 2
                                        Do While dt.Columns.Contains(Include(i) & intNextCol.ToString)
                                            intNextCol = intNextCol + 1
                                        Loop

                                        dc = New DataColumn()
                                        dc.ColumnName = Include(i) & intNextCol.ToString
                                        dc.DataType = Type.GetType("System.Decimal")
                                        If fleTemp.GetObjectSize(Include(i).ToString).Trim <> "" Then
                                            If _
                                                hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                    Include(i).ToString.ToLower.ToLower & intNextCol.ToString) Then
                                                If _
                                                    Not _
                                                    hsLenght.Contains(Include(i).ToString.ToLower & intNextCol.ToString) _
                                                    Then _
                                                    hsLenght.Add(Include(i).ToString.ToLower & intNextCol.ToString,
                                                                 hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                     Include(i).ToString.ToLower.ToLower &
                                                                     intNextCol.ToString))
                                            ElseIf _
                                                hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                    Include(i).ToString.ToLower.ToLower) Then
                                                If _
                                                    Not _
                                                    hsLenght.Contains(Include(i).ToString.ToLower & intNextCol.ToString) _
                                                    Then _
                                                    hsLenght.Add(Include(i).ToString.ToLower & intNextCol.ToString,
                                                                 hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                     Include(i).ToString.ToLower.ToLower))
                                            Else
                                                If _
                                                    Not _
                                                    hsLenght.Contains(Include(i).ToString.ToLower & intNextCol.ToString) _
                                                    Then _
                                                    hsLenght.Add(Include(i).ToString.ToLower & intNextCol.ToString,
                                                                 CInt(fleTemp.GetObjectSize(Include(i).ToString)))
                                            End If
                                        End If
                                        dt.Columns.Add(dc)

                                        'build the columns
                                        strColumns = strColumns & Include(i) & m_strDelimiter
                                        If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                            strValues = strValues & fleTemp.GetDecimalValue(Include(i)) & m_strDelimiter
                                        strDataValues = strDataValues & fleTemp.GetDecimalValue(Include(i)) & m_strDelimiter
                                        If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) _
                                            Then
                                            If strSubfileNumeric.Length > 0 Then
                                                strCreateTable = strCreateTable & dc.ColumnName & " DECIMAL(" &
                                                                 fleTemp.GetDecimalSize(Include(i).ToString) & "),"
                                            Else
                                                strCreateTable = strCreateTable & dc.ColumnName & " FLOAT,"
                                            End If
                                        End If
                                    End Try

                                Case "System.Int32", "System.Int64"

                                    Try
                                        ' If we have an integer or decimal in a temp table that is stored in memory,
                                        ' save the decimal value ("18,0" for integer, "18,2" if decimal 2, etc.)
                                        If SubType = SubFileType.Temp AndAlso Not hasItemCache Then
                                            htDecimals.Add(Include(i).ToString.ToUpper, "18,0")
                                        End If

                                        If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                            dc = New DataColumn()
                                            dc.ColumnName = Include(i)
                                            dc.DataType = Type.GetType("System.Int64")
                                            If fleTemp.GetObjectSize(Include(i).ToString).Trim <> "" Then
                                                If _
                                                    hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                    hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                        Include(i).ToString.ToLower.ToLower) Then
                                                    If Not hsLenght.Contains(Include(i).ToString.ToLower) Then _
                                                        hsLenght.Add(Include(i).ToString.ToLower,
                                                                     hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                         Include(i).ToString.ToLower.ToLower))
                                                Else
                                                    If Not hsLenght.Contains(Include(i).ToString.ToLower) Then _
                                                        hsLenght.Add(Include(i).ToString.ToLower, 10)
                                                End If
                                            End If

                                            dt.Columns.Add(dc)
                                        End If

                                        'build the columns
                                        strColumns = strColumns & Include(i) & m_strDelimiter
                                        If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                            strValues = strValues & fleTemp.GetDecimalValue(Include(i)) & m_strDelimiter
                                        strDataValues = strDataValues & fleTemp.GetDecimalValue(Include(i)) & m_strDelimiter
                                        If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) _
                                            Then
                                            strCreateTable = strCreateTable & dc.ColumnName & " FLOAT" & ","
                                        End If
                                    Catch ex As Exception
                                        Dim intNextCol As Integer = 2
                                        Do While dt.Columns.Contains(Include(i) & intNextCol.ToString)
                                            intNextCol = intNextCol + 1
                                        Loop

                                        dc = New DataColumn()
                                        dc.ColumnName = Include(i) & intNextCol.ToString
                                        dc.DataType = Type.GetType("System.Decimal")
                                        If fleTemp.GetObjectSize(Include(i).ToString).Trim <> "" Then
                                            If _
                                                hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                    Include(i).ToString.ToLower.ToLower & intNextCol.ToString) Then
                                                If _
                                                    Not _
                                                    hsLenght.Contains(Include(i).ToString.ToLower & intNextCol.ToString) _
                                                    Then _
                                                    hsLenght.Add(Include(i).ToString.ToLower & intNextCol.ToString,
                                                                 hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                     Include(i).ToString.ToLower.ToLower &
                                                                     intNextCol.ToString))
                                            ElseIf _
                                                hsSubfileKeepText.Contains(fleTemp.BaseName) AndAlso
                                                hsSubfileKeepText.Item(fleTemp.BaseName).Contains(
                                                    Include(i).ToString.ToLower.ToLower) Then
                                                If _
                                                    Not _
                                                    hsLenght.Contains(Include(i).ToString.ToLower & intNextCol.ToString) _
                                                    Then _
                                                    hsLenght.Add(Include(i).ToString.ToLower & intNextCol.ToString,
                                                                 hsSubfileKeepText.Item(fleTemp.BaseName).Item(
                                                                     Include(i).ToString.ToLower.ToLower))
                                            Else
                                                If _
                                                    Not _
                                                    hsLenght.Contains(Include(i).ToString.ToLower & intNextCol.ToString) _
                                                    Then _
                                                    hsLenght.Add(Include(i).ToString.ToLower & intNextCol.ToString, 10)
                                            End If
                                        End If
                                        dt.Columns.Add(dc)

                                        'build the columns
                                        strColumns = strColumns & Include(i) & m_strDelimiter
                                        If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                            strValues = strValues & fleTemp.GetDecimalValue(Include(i)) & m_strDelimiter
                                        strDataValues = strDataValues & fleTemp.GetDecimalValue(Include(i)) & m_strDelimiter
                                        If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) _
                                            Then
                                            strCreateTable = strCreateTable & dc.ColumnName & " FLOAT" & ","
                                        End If
                                    End Try

                            End Select

                        Case "CORE.FRAMEWORK.CORE.FRAMEWORK.DCHARACTER", "CORE.FRAMEWORK.CORE.FRAMEWORK.DVARCHAR",
                            "CORE.WINDOWS.UI.CORE.WINDOWS.CORECHARACTER"

                            Try
                                If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                    dc = New DataColumn()
                                    dc.ColumnName = Include(i).Name
                                    dc.DataType = Type.GetType("System.String")
                                    If Include(i).Size > 0 Then
                                        dc.MaxLength = Include(i).Size
                                        If Not hsLenght.Contains(Include(i).Name.ToString.ToLower) Then _
                                            hsLenght.Add(Include(i).Name.ToString.ToLower, Include(i).Size)
                                    End If

                                    dt.Columns.Add(dc)
                                End If

                                strColumns = strColumns & Include(i).Name & m_strDelimiter
                                If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                    strValues = strValues & StringToField(Include(i).Value) & m_strDelimiter
                                strDataValues = strDataValues & Include(i).Value & m_strDelimiter
                                If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                    strCreateTable = strCreateTable & dc.ColumnName & " VARCHAR("
                                    strCreateTable = strCreateTable & dc.MaxLength & ") " & strCulture & " NULL ,"
                                End If
                            Catch ex As Exception
                                Dim intNextCol As Integer = 2
                                Do While dt.Columns.Contains(Include(i).Name & intNextCol.ToString)
                                    intNextCol = intNextCol + 1
                                Loop

                                dc = New DataColumn()
                                dc.ColumnName = Include(i).Name & intNextCol.ToString
                                dc.DataType = Type.GetType("System.String")
                                If Include(i).Size > 0 Then
                                    dc.MaxLength = Include(i).Size
                                    If Not hsLenght.Contains(Include(i).Name.ToString.ToLower & intNextCol.ToString) _
                                        Then _
                                        hsLenght.Add(Include(i).Name.ToString.ToLower & intNextCol.ToString,
                                                     Include(i).Size)
                                End If
                                dt.Columns.Add(dc)

                                strColumns = strColumns & Include(i).Name & m_strDelimiter
                                If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                    strValues = strValues & StringToField(Include(i).Value) & m_strDelimiter
                                strDataValues = strDataValues & Include(i).Value & m_strDelimiter
                                If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                    strCreateTable = strCreateTable & dc.ColumnName & " VARCHAR("
                                    strCreateTable = strCreateTable & dc.MaxLength & ") " & strCulture & " NULL ,"
                                End If
                            End Try

                        Case "CORE.WINDOWS.UI.CORE.WINDOWS.COREDATE"

                            Try
                                If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                    dc = New DataColumn()
                                    dc.ColumnName = Include(i).Name
                                    dc.DataType = Type.GetType("System.DateTime")

                                    dt.Columns.Add(dc)
                                End If

                                'build the columns
                                strColumns = strColumns & Include(i).Name & m_strDelimiter

                                If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                    If GetDateFromYYYYMMDDDecimal(Include(i).Value) = cZeroDate Then
                                        strValues = strValues & "Null"
                                    Else
                                        strValues = strValues &
                                                    "CONVERT(DATETIME, " +
                                                    StringToField(
                                                        Format(CDate(GetDateFromYYYYMMDDDecimal(Include(i).Value)),
                                                               "yyyy-MM-dd HH:mm:ss")) + ", 120)"
                                    End If
                                    strValues = strValues & m_strDelimiter
                                End If

                                strDataValues = strDataValues & Include(i).Value & m_strDelimiter
                                If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                    strCreateTable = strCreateTable & dc.ColumnName & " DATETIME,"
                                End If
                            Catch ex As Exception
                                Dim intNextCol As Integer = 2
                                Do While dt.Columns.Contains(Include(i).Name & intNextCol.ToString)
                                    intNextCol = intNextCol + 1
                                Loop

                                dc = New DataColumn()
                                dc.ColumnName = Include(i).Name & intNextCol.ToString
                                dc.DataType = Type.GetType("System.DateTime")
                                dt.Columns.Add(dc)

                                'build the columns
                                strColumns = strColumns & Include(i).Name & m_strDelimiter

                                If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                    If GetDateFromYYYYMMDDDecimal(Include(i).Value) = cZeroDate Then
                                        strValues = strValues & "Null"
                                    Else
                                        strValues = strValues &
                                                    "CONVERT(DATETIME, " +
                                                    StringToField(
                                                        Format(CDate(GetDateFromYYYYMMDDDecimal(Include(i).Value)),
                                                               "yyyy-MM-dd HH:mm:ss")) + ", 120)"
                                    End If
                                    strValues = strValues & m_strDelimiter
                                End If

                                strDataValues = strDataValues & Include(i).Value.ToString.Replace("12:00:00 AM", "NULL") &
                                                m_strDelimiter
                                If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                    strCreateTable = strCreateTable & dc.ColumnName & " DATETIME,"
                                End If
                            End Try

                        Case "CORE.FRAMEWORK.CORE.FRAMEWORK.DDECIMAL", "CORE.FRAMEWORK.CORE.FRAMEWORK.DINTEGER",
                            "CORE.WINDOWS.UI.CORE.WINDOWS.COREDECIMAL", "CORE.WINDOWS.UI.CORE.WINDOWS.COREINTEGER"

                            Try
                                ' If we have an integer or decimal in a temp table that is stored in memory,
                                ' save the decimal value ("18,0" for integer, "18,2" if decimal 2, etc.)
                                If SubType = SubFileType.Temp AndAlso Not hasItemCache Then
                                    If _
                                        (Include(i).GetType.ToString.ToUpper = "CORE.WINDOWS.UI.CORE.WINDOWS.COREINTEGER" OrElse
                                         Include(i).GetType.ToString.ToUpper = "CORE.WINDOWS.UI.CORE.WINDOWS.COREDECIMAL" OrElse
                                         Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DDECIMAL" OrElse
                                         Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DINTEGER") _
                                        Then
                                        htDecimals.Add(Include(i).Name.ToString.ToUpper, "18,0")
                                    Else
                                        htDecimals.Add(Include(i).Name.ToString.ToUpper, "18,2")
                                    End If
                                End If

                                If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                    dc = New DataColumn()
                                    dc.ColumnName = Include(i).Name
                                    If (Include(i).GetType.ToString.ToUpper = "CORE.WINDOWS.UI.CORE.WINDOWS.COREINTEGER" OrElse
                                           Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DINTEGER") Then
                                        dc.DataType = Type.GetType("System.Int64")
                                    Else
                                        dc.DataType = Type.GetType("System.Decimal")
                                    End If
                                    If Include(i).Size > 0 Then
                                        If Not hsLenght.Contains(Include(i).Name.ToString.ToLower) Then _
                                            hsLenght.Add(Include(i).Name.ToString.ToLower, Include(i).Size)
                                    End If

                                    dt.Columns.Add(dc)
                                End If

                                strColumns = strColumns & Include(i).Name & m_strDelimiter
                                If _
                                    (Include(i).GetType.ToString.ToUpper = "CORE.WINDOWS.UI.CORE.WINDOWS.COREINTEGER" OrElse
                                     Include(i).GetType.ToString.ToUpper = "CORE.WINDOWS.UI.CORE.WINDOWS.COREDECIMAL" OrElse
                                     Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DDECIMAL" OrElse
                                     Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DINTEGER") _
                                    AndAlso Include(i).IsSubtotal Then
                                    SubTotalValue = Include(i).SubTotalValue
                                    If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                        strValues = strValues & SubTotalValue & m_strDelimiter
                                    strDataValues = strDataValues & SubTotalValue & m_strDelimiter
                                Else
                                    If _
                                        (Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DDECIMAL" OrElse
                                         Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DINTEGER") AndAlso
                                        Include(i).IsMaximum Then
                                        SubTotalValue = Include(i).MaximumValue
                                        If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) Then strValues = strValues & SubTotalValue & m_strDelimiter
                                        strDataValues = strDataValues & SubTotalValue & m_strDelimiter
                                    End If
                                    If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                        strValues = strValues & Include(i).Value & m_strDelimiter
                                    strDataValues = strDataValues & Include(i).Value & m_strDelimiter
                                End If

                                If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                    If _
                                        (Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DDECIMAL" OrElse
                                         Include(i).GetType.ToString.ToUpper = "CORE.WINDOWS.UI.CORE.WINDOWS.COREDECIMAL") Then
                                        strCreateTable = strCreateTable & dc.ColumnName & " DECIMAL(18,2),"
                                    Else
                                        strCreateTable = strCreateTable & dc.ColumnName & " FLOAT" & ","
                                    End If
                                End If
                            Catch ex As Exception
                                Dim intNextCol As Integer = 2
                                Do While dt.Columns.Contains(Include(i).Name & intNextCol.ToString)
                                    intNextCol = intNextCol + 1
                                Loop

                                dc = New DataColumn()
                                dc.ColumnName = Include(i).Name & intNextCol.ToString
                                dc.DataType = Type.GetType("System.Decimal")
                                If Include(i).Size > 0 Then
                                    If Not hsLenght.Contains(Include(i).Name.ToString.ToLower & intNextCol.ToString) _
                                        Then _
                                        hsLenght.Add(Include(i).Name.ToString.ToLower & intNextCol.ToString,
                                                     Include(i).Size)
                                End If
                                dt.Columns.Add(dc)

                                strColumns = strColumns & Include(i).Name & m_strDelimiter
                                If _
                                    (Include(i).GetType.ToString.ToUpper = "CORE.WINDOWS.UI.CORE.WINDOWS.COREINTEGER" OrElse
                                     Include(i).GetType.ToString.ToUpper = "CORE.WINDOWS.UI.CORE.WINDOWS.COREDECIMAL" OrElse
                                     Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DDECIMAL" OrElse
                                     Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DINTEGER") _
                                    AndAlso Include(i).IsSubtotal Then
                                    SubTotalValue = Include(i).SubTotalValue
                                    If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                        strValues = strValues & SubTotalValue & m_strDelimiter
                                    strDataValues = strDataValues & SubTotalValue & m_strDelimiter
                                Else
                                    If _
                                        (Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DDECIMAL" OrElse
                                         Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DINTEGER") AndAlso
                                        Include(i).IsMaximum Then
                                        SubTotalValue = Include(i).MaximumValue
                                        If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) Then strValues = strValues & SubTotalValue & m_strDelimiter
                                        strDataValues = strDataValues & SubTotalValue & m_strDelimiter
                                    End If
                                    If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                                        strValues = strValues & Include(i).Value & m_strDelimiter
                                    strDataValues = strDataValues & Include(i).Value & m_strDelimiter
                                End If

                                If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                    If _
                                        (Include(i).GetType.ToString.ToUpper = "CORE.FRAMEWORK.CORE.FRAMEWORK.DDECIMAL" OrElse
                                         Include(i).GetType.ToString.ToUpper = "CORE.WINDOWS.UI.CORE.WINDOWS.COREDECIMAL") Then
                                        strCreateTable = strCreateTable & dc.ColumnName & " DECIMAL(18,2),"
                                    Else
                                        strCreateTable = strCreateTable & dc.ColumnName & " FLOAT" & ","
                                    End If
                                End If
                            End Try

                        Case "CORE.FRAMEWORK.CORE.FRAMEWORK.DDATE", "CORE.WINDOWS.UI.CORE.WINDOWS.COREDATE"

                            Try
                                If Not blnQTPSubFile OrElse blnAppendSubFile Then
                                    dc = New DataColumn()
                                    dc.ColumnName = Include(i).Name
                                    dc.DataType = Type.GetType("System.DateTime")

                                    dt.Columns.Add(dc)
                                End If

                                strColumns = strColumns & Include(i).Name & m_strDelimiter

                                If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                    If GetDateFromYYYYMMDDDecimal(Include(i).Value) = cZeroDate Then
                                        strValues = strValues & "Null"
                                    Else
                                        strValues = strValues &
                                                    "CONVERT(DATETIME, " +
                                                    StringToField(
                                                        Format(CDate(GetDateFromYYYYMMDDDecimal(Include(i).Value)),
                                                               "yyyy-MM-dd HH:mm:ss")) + ", 120)"
                                    End If
                                    strValues = strValues & m_strDelimiter
                                End If

                                strDataValues = strDataValues & Include(i).Value & m_strDelimiter
                                If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                    strCreateTable = strCreateTable & dc.ColumnName & " DATETIME,"
                                End If
                            Catch ex As Exception
                                Dim intNextCol As Integer = 2
                                Do While dt.Columns.Contains(Include(i).Name & intNextCol.ToString)
                                    intNextCol = intNextCol + 1
                                Loop

                                dc = New DataColumn()
                                dc.ColumnName = Include(i).Name & intNextCol.ToString
                                dc.DataType = Type.GetType("System.DateTime")
                                dt.Columns.Add(dc)

                                strColumns = strColumns & Include(i).Name & m_strDelimiter

                                If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                    strValues = strValues &
                                                GetDateFromYYYYMMDDDecimal(Include(i).Value).ToString.Replace(
                                                    "12:00:00 AM", "NULL") & m_strDelimiter
                                    If GetDateFromYYYYMMDDDecimal(Include(i).Value) = cZeroDate Then
                                        strValues = strValues & "Null"
                                    Else
                                        strValues = strValues &
                                                    "CONVERT(DATETIME, " +
                                                    StringToField(
                                                        Format(CDate(GetDateFromYYYYMMDDDecimal(Include(i).Value)),
                                                               "yyyy-MM-dd HH:mm:ss")) + ", 120)"
                                    End If
                                    strValues = strValues & m_strDelimiter
                                End If

                                If Not blnQTPSubFile AndAlso ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                                    strCreateTable = strCreateTable & dc.ColumnName & " DATETIME,"
                                End If
                            End Try
                    End Select

                Next

                'If Not strInsertRowSQL.ToString = "" Then

                If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then _
                    strValues = strValues.Substring(0, strValues.Length - 1)
                strDataValues = strDataValues.Substring(0, strDataValues.Length - 1)
                strColumns = ""
                For i As Integer = 0 To dt.Columns.Count - 1
                    If _
                        dt.Columns.Item(i).ColumnName.ToLower <> "row_id" AndAlso
                        dt.Columns.Item(i).ColumnName.ToLower <> "checksum_value" Then
                        strColumns = strColumns & dt.Columns(i).ColumnName & m_strDelimiter
                    End If
                Next

                strColumns = strColumns.Substring(0, strColumns.Length - 1)

                If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                    'create insert sql

                    strInsertRowSQL.Append("(")
                    strInsertRowSQL.Append(strColumns)
                    strInsertRowSQL.Append(")")
                    strInsertRowSQL.Append(" VALUES ")
                    strInsertRowSQL.Append("(")
                    strInsertRowSQL.Append(strValues)
                    strInsertRowSQL.Append(")")

                Else

                    If Not ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso IsKeepText) Then
                        If Not blnQTPSubFile OrElse blnAppendSubFile Then
                            dc = New DataColumn()
                            dc.ColumnName = "CHECKSUM_VALUE"
                            dc.DataType = Type.GetType("System.Decimal")
                            dt.Columns.Add(dc)
                        End If

                        'build the columns
                        strColumns = strColumns & m_strDelimiter & "CHECKSUM_VALUE"
                        'strValues = strValues & "~" & "0" ' Not used
                        strDataValues = strDataValues & m_strDelimiter & "0"

                        If Not blnQTPSubFile OrElse blnAppendSubFile Then
                            dc = New DataColumn()
                            dc.ColumnName = "ROW_ID"
                            dc.DataType = Type.GetType("System.String")
                            dt.Columns.Add(dc)
                        End If

                        'build the columns
                        strColumns = strColumns & m_strDelimiter & "ROW_ID"
                        'strValues = strValues & "~" & StringToField(Now.TimeOfDay.TotalMilliseconds.ToString & (intSubFileRow).ToString) ' Not used
                        strDataValues = strDataValues & m_strDelimiter & Now.TimeOfDay.TotalMilliseconds.ToString &
                                        (intSubFileRow).ToString
                    End If

                    arrColumns = strColumns.Split(m_strDelimiter)
                    arrValues = strDataValues.Split(m_strDelimiter)
                    rw = dt.NewRow
                    For j As Integer = 0 To dt.Columns.Count - 1
                        If _
                            dt.Columns(j).DataType.ToString = "System.DateTime" AndAlso
                            (arrValues(j) = "0" OrElse arrValues(j) = "") Then
                        ElseIf dt.Columns(j).DataType.ToString = "System.DateTime" Then
                            Dim _
                                dateTimeInfo As _
                                    New DateTime(CInt(arrValues(j).ToString.PadRight(16, "0").Substring(0, 4)),
                                                 CInt(arrValues(j).ToString.PadRight(16, "0").Substring(4, 2)),
                                                 CInt(arrValues(j).ToString.PadRight(16, "0").Substring(6, 2)),
                                                 CInt(arrValues(j).ToString.PadRight(16, "0").Substring(8, 2)),
                                                 CInt(arrValues(j).ToString.PadRight(16, "0").Substring(10, 2)),
                                                 CInt(arrValues(j).ToString.PadRight(16, "0").Substring(12, 4)))
                            rw.Item(arrColumns(j)) = dateTimeInfo
                        Else
                            rw.Item(arrColumns(j)) = arrValues(j)
                        End If
                    Next
                    dt.Rows.Add(rw)
                    'strValues = "" ' Not used
                    strColumns = ""
                End If
                'End If

                'Dim strConnect As String = GetConnectionString()
                If Not blnQTPSubFile Then
                    If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                        strCreateTableSQL.Append("(").Append(" ROWID uniqueidentifier NULL DEFAULT (newid()), ")
                        strCreateTableSQL.Append(strCreateTable).Append(" CHECKSUM_VALUE FLOAT DEFAULT 0 ").Append(")")
                    End If

                    'Check if table already exists
                    Dim blnKeepTable As Boolean
                    If IsNothing(ConfigurationManager.AppSettings("KeepSubFile")) Then
                        blnKeepTable = False
                    Else
                        blnKeepTable = ConfigurationManager.AppSettings("KeepSubFile").ToUpper = "TRUE"
                    End If



                    strSQL = New StringBuilder(String.Empty)
                    strSQL.Append("SELECT * FROM ").Append("").Append("sysobjects WHERE TYPE='U' AND NAME='").
                        Append(strName).Append("'")

                    objReader = SqlHelper.ExecuteReader(strConnect, CommandType.Text, strSQL.ToString)

                    If objReader.Read Then
                        strSQL.Remove(0, strSQL.Length)
                        If strSchema <> "" Then
                            strSQL.Append("DROP TABLE ").Append(strSchema).Append(strName)
                        Else
                            strSQL.Append("DROP TABLE ").Append(strName)
                        End If
                        SqlHelper.ExecuteNonQuery(strConnect, CommandType.Text, strSQL.ToString)
                    End If

                    If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) Then
                        'Table does not exists
                        'Create Table
                        SqlHelper.ExecuteNonQuery(strConnect, CommandType.Text, strCreateTableSQL.ToString)
                    End If
                End If

                If ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not IsKeepText) AndAlso Not blnDeletedSubFile Then
                    SqlHelper.ExecuteNonQuery(strConnect, CommandType.Text, strInsertRowSQL.ToString.Replace(m_strDelimiter, ","))
                End If

                If _
                    Not _
                    Session(UniqueSessionID + "hsSubfileKeepText").Contains(strName) _
                    Then
                    Session(UniqueSessionID + "hsSubfileKeepText").Add(strName,
                                                                       hsLenght)
                ElseIf _
                    IsNothing(
                        Session(UniqueSessionID + "hsSubfileKeepText").Item(strName)) _
                    Then
                    Session(UniqueSessionID + "hsSubfileKeepText").Remove(strName)
                    Session(UniqueSessionID + "hsSubfileKeepText").Add(strName,
                                                                       hsLenght)
                End If

                If SubType = SubFileType.TempText OrElse ((SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso IsKeepText) Then

                    If (SubType = SubFileType.Keep OrElse SubType = SubFileType.Portable) AndAlso Not arrKeepFile.Contains(strName) Then
                        arrKeepFile.Add(strName)
                    End If

                    ' GW2018. Added. As soon as we formed the first record, create the MiniDictionary
                    'g_recordCount = g_recordCount + 1
                    'If (g_recordCount = 1) Then
                    WriteMiniDictionaryFile(strName, dt, Session(UniqueSessionID + "hsSubfileKeepText").Item(strName))
                    'End If

                    If dt.Rows.Count > 4999 Then
                        PutDataTextTable(strName, dt, Session(UniqueSessionID + "hsSubfileKeepText").Item(strName))
                        blnOver5000Records = True
                        dt.Clear()
                    End If

                End If

                blnQTPSubFile = True

                If (blnDeletedSubFile OrElse Not IsKeepText) AndAlso dt.Rows.Count > 0 Then
                    dt.Rows.RemoveAt(0)
                End If

                If Session(UniqueSessionID + "hsSubfile").Contains(strName) Then
                    Session(UniqueSessionID + "hsSubfile").Item(strName) = dt
                Else
                    Session(UniqueSessionID + "hsSubfile").Add(strName, dt)
                End If

                'AddRecordsRead(strName, 0, LogType.OutPut)

                If blnDeletedSubFile Then
                    'AddRecordsRead(strName, 0, LogType.Added)
                    AddRecordsProcessed(strName, 0, LogType.Added)
                Else
                    'AddRecordsRead(strName, 1, LogType.Added)
                    AddRecordsProcessed(strName, 1, LogType.Added)
                End If

                If Not arrSubFiles.Contains(strName) Then
                    arrSubFiles.Add(strName)
                    If (Not m_hsFileInOutput.Contains(strName)) Then
                        m_hsFileInOutput.Add(strName, strName)
                    End If
                End If

            Catch ex As Exception

                WriteError(ex)

            Finally

                If Not IsNothing(objReader) Then
                    objReader.Close()
                    objReader = Nothing
                End If
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
                If Not IsNothing(dc) Then
                    dc.Dispose()
                    dc = Nothing
                End If
                rw = Nothing
                arrColumns = Nothing
                arrValues = Nothing

                hsLenght = Nothing
                hsSubfileKeepText = Nothing

            End Try
        End Sub


        Public Function GetSubSize(size As Integer, datatype As String) As Integer

            If datatype = "System.Integer" OrElse datatype = "System.Int64" Then

                Select Case size
                    Case 1
                        Return 6
                    Case 2
                        Return 6
                    Case 3
                        Return 6
                    Case 4
                        Return 6

                    Case 5
                        Return 11
                    Case 6
                        Return 11
                    Case 7
                        Return 11
                    Case 8
                        Return 11
                    Case 9
                        Return 11

                    Case 10
                        Return 16
                    Case 11
                        Return 16
                    Case 12
                        Return 16
                    Case 13
                        Return 16
                    Case 14
                        Return 16

                    Case Else
                        Return 21


                End Select

            Else
                ' Commented out the addition + 1 here. Moved to WriteMiniDictionary
                'Return size + 1
                Return size

            End If



        End Function
        Private Function GetTextTableStructure(ByVal fileName As String) As DataTable
            Dim strFilePath As String = ""
            Dim strFileColumn As String = strFilePath

            strFilePath = Directory.GetCurrentDirectory()



            If Not IsNothing(Session("PortableSubFiles")) AndAlso DirectCast(Session("PortableSubFiles"), ArrayList).Contains(fileName) Then
                If strFileColumn.EndsWith("\") Then
                    strFileColumn = strFilePath & fileName & ".psd"
                Else
                    strFileColumn = strFilePath & "\" & fileName & ".psd"
                End If
            Else
                If strFileColumn.EndsWith("\") Then
                    strFileColumn = strFilePath & fileName & ".sfd"
                Else
                    strFileColumn = strFilePath & "\" & fileName & ".sfd"
                End If
            End If


            If Not File.Exists(strFileColumn) Then

                If Not IsNothing(Session("PortableSubFiles")) AndAlso DirectCast(Session("PortableSubFiles"), ArrayList).Contains(fileName) Then
                    If strFileColumn.EndsWith("\") Then
                        strFileColumn = strFilePath & fileName & ".psd"
                    Else
                        strFileColumn = strFilePath & "\" & fileName & ".psd"
                    End If
                Else
                    If strFileColumn.EndsWith("\") Then
                        strFileColumn = strFilePath & fileName & ".sfd"
                    Else
                        strFileColumn = strFilePath & "\" & fileName & ".sfd"
                    End If
                End If

            End If


            Dim strFile As String = String.Empty
            Dim sr As New StreamReader(strFileColumn)
            Dim dt As New DataTable
            Dim strText As String = String.Empty
            Dim arrStructure() As String
            Dim intPlaceholder As Integer = 0
            Dim intLinelength As Integer = 0
            Dim hsLength As New Hashtable
            Dim strTextName As String = String.Empty

            Dim dc As DataColumn

            Try


                strText = sr.ReadLine

                Do While Not IsNothing(strText)
                    arrStructure = strText.Split(",")

                    dc = New DataColumn()
                    dc.ColumnName = arrStructure(0)

                    dc.DataType = System.Type.GetType(arrStructure(1))
                    hsLength.Add(arrStructure(0), arrStructure(2))

                    dt.Columns.Add(dc)

                    intLinelength = intLinelength + VAL(arrStructure(2))

                    strText = sr.ReadLine
                Loop

                sr.Close()


                Return dt

            Catch ex As Exception
                Return dt
            End Try

        End Function

        Public Sub WriteSub(ByVal ParamArray Include() As Object)

            Dim fleTemp As SqlFileObject
            Dim intTableCount As Integer = 0
            Dim strValues As String = String.Empty
            Dim strColumns As String = String.Empty

            For i As Integer = 0 To Include.Length - 1

                Select Case Include(i).GetType.ToString.ToUpper

                    Case "CORE.WINDOWS.UI.CORE.WINDOWS.SQLFILEOBJECT"
                        intTableCount = intTableCount + 1
                        fleTemp = Include(i)

                        If i = Include.Length - 1 OrElse Include(i + 1).GetType.ToString <> "System.String" Then

                            For j As Integer = 0 To fleTemp.Columns.Count - 1

                                If _
                                    fleTemp.Columns.Item(j).ColumnName <> "ROW_ID" AndAlso
                                    fleTemp.Columns.Item(j).ColumnName <> "CHECKSUM_VALUE" Then

                                    strColumns = strColumns & fleTemp.Columns.Item(j).ColumnName & m_strDelimiter

                                    Select Case fleTemp.GetObjectType(fleTemp.Columns.Item(j).ColumnName)
                                        Case "System.String"

                                            Try

                                                strValues = strValues &
                                                            StringToField(
                                                                fleTemp.GetStringValue(
                                                                    fleTemp.Columns.Item(j).ColumnName)) & m_strDelimiter

                                            Catch ex As Exception

                                            End Try

                                        Case "System.DateTime"

                                            Try
                                                strValues = strValues &
                                                            fleTemp.GetNumericDateTimeValue(
                                                                fleTemp.Columns.Item(j).ColumnName) & m_strDelimiter

                                            Catch ex As Exception

                                            End Try

                                        Case "System.Decimal", "System.Double", "System.Int32", "System.Single"

                                            Try
                                                strValues = strValues &
                                                            fleTemp.GetDecimalValue(fleTemp.Columns.Item(j).ColumnName) &
                                                            m_strDelimiter

                                            Catch ex As Exception

                                            End Try

                                    End Select

                                End If

                            Next

                        End If
                    Case "SYSTEM.STRING"

                        'build the Values
                        Select Case fleTemp.GetObjectType(Include(i))
                            Case "System.String"

                                Try

                                    'build the columns
                                    strColumns = strColumns & Include(i) & m_strDelimiter
                                    strValues = strValues & StringToField(fleTemp.GetStringValue(Include(i))) & m_strDelimiter

                                Catch ex As Exception

                                End Try

                            Case "System.DateTime"

                                Try

                                    'build the columns
                                    strColumns = strColumns & Include(i) & m_strDelimiter
                                    strValues = strValues & fleTemp.GetDateValue(Include(i)) & m_strDelimiter

                                Catch ex As Exception

                                End Try

                            Case "System.Decimal", "System.Double", "System.Int32", "System.Single"

                                Try

                                    'build the columns
                                    strColumns = strColumns & Include(i) & m_strDelimiter
                                    strValues = strValues & fleTemp.GetDecimalValue(Include(i)) & m_strDelimiter

                                Catch ex As Exception

                                End Try

                        End Select

                    Case "CORE.FRAMEWORK.CORE.FRAMEWORK.DCHARACTER", "CORE.FRAMEWORK.CORE.FRAMEWORK.DVARCHAR",
                        "CORE.WINDOWS.UI.CORE.WINDOWS.CORECHARACTER", "CORE.WINDOWS.UI.CORE.WINDOWS.COREDATE"

                        Try

                            strColumns = strColumns & Include(i).Name & m_strDelimiter
                            strValues = strValues & StringToField(Include(i).Value) & m_strDelimiter

                        Catch ex As Exception

                        End Try

                    Case "CORE.FRAMEWORK.CORE.FRAMEWORK.DDECIMAL", "CORE.FRAMEWORK.CORE.FRAMEWORK.DINTEGER",
                        "CORE.WINDOWS.UI.CORE.WINDOWS.COREDECIMAL", "CORE.WINDOWS.UI.CORE.WINDOWS.COREINTEGER"

                        Try

                            strColumns = strColumns & Include(i).Name & m_strDelimiter
                            strValues = strValues & Include(i).Value & m_strDelimiter

                        Catch ex As Exception

                        End Try

                    Case "CORE.FRAMEWORK.CORE.FRAMEWORK.DDATE", "CORE.WINDOWS.UI.CORE.WINDOWS.COREDATE"

                        Try

                            strColumns = strColumns & Include(i).Name & m_strDelimiter
                            strValues = strValues & Include(i).Value & m_strDelimiter

                        Catch ex As Exception

                        End Try
                End Select

            Next

            If Not blnQTPSubFile Then
                WriteLogFile(vbNewLine & strColumns.Replace(m_strDelimiter, ",") & vbNewLine)
                blnQTPSubFile = True
            End If

            WriteLogFile(vbNewLine & strValues.Replace(m_strDelimiter, ",") & vbNewLine)
        End Sub

        Protected Function GetRPSystemval(strName As String, Optional ByVal blnNoSession As Boolean = False) As Object

            Dim objReader As IDataReader
            Dim strSQL As New StringBuilder("")

            strSQL.Append("SELECT SYSTEM_VALUE FROM RPSYSTEMVAL ")
            If blnNoSession Then
                strSQL.Append(" WHERE SESSION_ID = ").Append(StringToField(" "))
            Else
                strSQL.Append(" WHERE SESSION_ID = ").Append(StringToField(NumberedSessionID.Value))
            End If
            strSQL.Append(" AND NAME = ").Append(StringToField(strName))
            objReader = OracleHelper.ExecuteReader(GetConnectionString, CommandType.Text, strSQL.ToString)

            If objReader.Read Then
                Return objReader.Item(0).ToString()
            Else
                Return ""
            End If
        End Function

        Public Sub ChangeSubName(strName As String, strPrefix As String, Optional ByVal strSuffix As String = "")

            Dim strFiles() As String
            strFiles = Directory.GetFiles(Directory.GetCurrentDirectory())
            Dim strFilePath As String = Directory.GetCurrentDirectory()
            If Not strFilePath.Trim.EndsWith("\") Then
                strFilePath = strFilePath.Trim & "\"
            End If
            Dim intLastNumber As Integer = 0
            Dim intTempNumber As Integer = 0
            Dim sqlconnect As New SqlConnection(GetConnectionString)
            Dim fi As FileInfo
            Dim blnFoundMatch As Boolean = False

            Dim CURRYEAR As String = ASCII(SysDate(sqlconnect), 8).Substring(2, 2)
            Dim BEGYEAR As Decimal = NConvert(ASCII(SysDate(sqlconnect), 8).Substring(0, 4) + "0101")
            Dim CURRDAYS As String = ASCII((Days(SysDate(sqlconnect)) - Days(BEGYEAR) + 1), 3)
            Dim JULDAY As String = CURRYEAR + CURRDAYS

            sqlconnect.Close()
            sqlconnect.Dispose()

            For i As Integer = 0 To strFiles.Length - 1

                fi = New FileInfo(strFiles(i))

                If blnFoundMatch AndAlso Not fi.Name.StartsWith(strPrefix + JULDAY) Then
                    Exit For
                End If

                If fi.Name.StartsWith(strPrefix + JULDAY) AndAlso (fi.Name.IndexOf(".sfd") <= 0 OrElse fi.Name.IndexOf(".psd") <= 0) Then
                    intTempNumber = VAL(fi.Name.Replace(strPrefix + JULDAY, ""))
                    If intTempNumber > intLastNumber Then
                        intLastNumber = intTempNumber
                    End If
                    blnFoundMatch = True
                End If

            Next

            If File.Exists(strFilePath & strName) Then
                fi = New FileInfo(strFilePath & strName)
                If strSuffix.Length > 0 Then
                    If Not strSuffix.Trim.StartsWith(".") Then
                        strSuffix = "." & strSuffix.Trim
                    End If
                    fi.MoveTo(strFilePath & strPrefix + JULDAY + (intLastNumber + 1).ToString & strSuffix)
                Else
                    fi.MoveTo(strFilePath & strPrefix + JULDAY + (intLastNumber + 1).ToString)
                End If



                If Not IsNothing(Session("PortableSubFiles")) AndAlso DirectCast(Session("PortableSubFiles"), ArrayList).Contains(strName) Then
                    If File.Exists(strFilePath & strName & ".psd") Then
                        fi = New FileInfo(strFilePath & strName & ".psd")
                        fi.MoveTo(strFilePath & strPrefix + JULDAY + (intLastNumber + 1).ToString & ".psd")
                    End If
                Else
                    If File.Exists(strFilePath & strName & ".sfd") Then
                        fi = New FileInfo(strFilePath & strName & ".sfd")
                        fi.MoveTo(strFilePath & strPrefix + JULDAY + (intLastNumber + 1).ToString & ".sfd")
                    End If
                End If

            End If

            fi = Nothing
        End Sub

#End If

        Protected Friend Sub MoveFile(SourceFileName As String, DestinationFileName As String)

            ' Update the Last Access Time to the Session Manager
            SessionInformation.UpdateSessionAccessTime(UniqueSessionID)

            Dim reportDirectory As String = ConfigurationManager.AppSettings("CompletedReportsPath")
            Dim sharedDrive As String = ConfigurationManager.AppSettings("SharedDrive")
            Dim fileName As String = String.Empty
            Dim fileGroup As String = String.Empty
            Dim fileAccount As String = String.Empty
            Dim fileEquate As String = String.Empty
            Dim variable As String = String.Empty
            Dim extension As String = String.Empty
            Dim destinationFile As String = String.Empty
            Dim strUserId As String = Session(UniqueSessionID + "m_strUser")
            strUserId = strUserId.Trim

            ' Determine the file equate variable and filename.
            variable = DestinationFileName.Split("="c)(0).Trim
            fileEquate = DestinationFileName.Split("="c)(1).Trim

            ' Get the file name, group and account.
            Select Case fileEquate.Split("."c).Length
                Case 1
                    fileName = fileEquate.Split("."c)(0)
                    fileGroup = Me.Session(UniqueSessionID + "m_strGROUP")
                    fileAccount = Me.Session(UniqueSessionID + "m_strACCOUNT")
                Case 2
                    fileName = fileEquate.Split("."c)(0)
                    fileGroup = fileEquate.Split("."c)(1)
                    fileAccount = Me.Session(UniqueSessionID + "m_strACCOUNT")
                Case 3
                    fileName = fileEquate.Split("."c)(0)
                    fileGroup = fileEquate.Split("."c)(1)
                    fileAccount = fileEquate.Split("."c)(2)
            End Select

            destinationFile = sharedDrive & "\" & variable

            ' Delete the file if it exists.
            If My.Computer.FileSystem.FileExists(destinationFile) Then
                My.Computer.FileSystem.DeleteFile(destinationFile)
            End If

            ' Copy the file.
            My.Computer.FileSystem.CopyFile(reportDirectory & "\" & strUserId & "\Reports\" & SourceFileName,
                                            destinationFile)

            Try


                If SshConnectionOpen Then
                    Dim purge As Boolean = False
                    If Me.ScreenType = ScreenTypes.QTP OrElse Me.ScreenType = ScreenTypes.QUIZ Then purge = True

                    ' Log the location of files moved to AMXW.
                    Dim fullName As String = fileName
                    If fileGroup Is Nothing Then fileGroup = String.Empty
                    If fileAccount Is Nothing Then fileAccount = String.Empty
                    If fileGroup.Trim.Length > 0 Then fullName &= "." & fileGroup
                    If fileAccount.Trim.Length > 0 Then fullName &= "." & fileAccount
                    m_LogFile.Append(vbNewLine)
                    m_LogFile.Append("Transfer file to AMXW: ").Append(fullName).Append(", 0").Append(vbNewLine)

                    ' Register file on AMXW.

                Else
                    m_Error.Append("      ").Append("SSH connection failed, please contact IT support.").Append(
                        vbNewLine)
                    m_LogFile.Append("      ").Append("SSH connection failed, please contact IT support.").Append(
                        vbNewLine)
                End If

            Catch ex As Exception
                WriteError(ex)
            Finally
                If m_LogFile.Length > 0 Then WriteLogFile(m_LogFile.ToString)
            End Try
        End Sub

        Protected Friend Overridable Sub Request(strName As String)
            Try




                m_intMaxRecordsToRetrieve = -1
                ' Initialize the connections objects.

#If TARGET_DB = "INFORMIX" Then
                cnnQUERY = Session(UniqueSessionID + "cnnQUERY")
                cnnTRANS_UPDATE = Session(UniqueSessionID + "cnnTRANS_UPDATE")
                trnTRANS_UPDATE = Session(UniqueSessionID + "trnTRANS_UPDATE")

                If IsNothing(cnnTRANS_UPDATE) Then
                    cnnTRANS_UPDATE = New IfxConnection(GetInformixConnectionString)
                    cnnTRANS_UPDATE.Open()
                    trnTRANS_UPDATE = cnnTRANS_UPDATE.BeginTransaction
                    cnnQUERY = New IfxConnection(GetInformixConnectionString)
                End If

                Session.Remove(UniqueSessionID + "EOF")
#End If
                Try
                    InitializeTransactionObjects()
                Catch ex As CustomApplicationException
                    Throw ex
                Catch ex As Exception
                    Throw ex
                End Try
                Try
                    InitializeFiles()
                Catch ex As CustomApplicationException
                    Throw ex
                Catch ex As Exception
                    Throw ex
                End Try

                hsSubFileSize = Session(UniqueSessionID + "hsSubFileSize")
                If IsNothing(hsSubFileSize) Then hsSubFileSize = New Hashtable

                NumberedSessionID.Value = Session(UniqueSessionID + "NumberedSessionID")
                QTPSessionID = Session(UniqueSessionID + "QTPSessionID")
                CallInitializeInternalValues()
                If IsNothing(Session(UniqueSessionID + "alSubTempFile")) Then _
                    Session(UniqueSessionID + "alSubTempFile") = New ArrayList

                m_LogFile.Remove(0, m_LogFile.Length)
                If Not IsNothing(Session("Log")) Then
                    m_LogFile.Append(vbNewLine).Append(Session("Log")).Append(vbNewLine)
                    Session("Log") = Nothing
                End If
                m_LogFile.Append(vbNewLine).Append(vbNewLine)

                m_LogFile.Append("Run:     ").Append(Me.Name).Append(vbNewLine)

                m_LogFile.Append(("Request: " & strName).ToString.PadRight(40))
                m_LogFile.Append(Now.Day.ToString.PadLeft(2, "0")).Append("/").Append(Now.Month.ToString.PadLeft(2, "0")) _
                    .Append("/").Append(Now.Year.ToString).Append(" ")
                m_LogFile.Append(TimeOfDay.ToLongTimeString)
                m_LogFile.Append(vbNewLine)

                If m_ClassParameters.ToString().Trim() <> String.Empty Then
                    m_LogFile.Append(vbNewLine)
                    m_LogFile.Append("Parameters").Append(vbNewLine)
                    m_LogFile.Append(m_ClassParameters.ToString())
                    m_ClassParameters.Remove(0, m_ClassParameters.Length)
                End If

                m_LogFile.Append(vbNewLine).Append(vbNewLine)
                m_LogFile.Append("Records read:").Append(vbNewLine)

                m_SortOrder = Nothing
                m_intSortOrder = 0
                blnQTPSubFile = False

                If IsNothing(Session(UniqueSessionID + "hsSubfile")) Then
                    Session(UniqueSessionID + "hsSubfile") = New SortedList
                End If

                If IsNothing(Session(UniqueSessionID + "hsSubfileKeepText")) Then
                    Session(UniqueSessionID + "hsSubfileKeepText") = New SortedList
                End If

                GC.Collect()

            Catch ex As CustomApplicationException

                Throw ex

            Catch ex As Exception

                ExceptionManager.Publish(ex)
                Throw ex

            End Try
        End Sub

        Protected Friend Overridable Sub WriteError(ex As CustomApplicationException)
            Dim strError As String = String.Empty

            If Not CancelQTPs Then
                CurrentQTPCancel = True
            End If
            CancelQTPs = True


            If ex.MessageText <> "" Then
                strError = ex.MessageText
            Else
                strError = ex.Message
            End If



            If strError <> "No Records Found." Then 'IM.NoRecords
                If strError.Length > 2 AndAlso strError.ToUpper.Substring(0, 3) = "IM." Then
                    strError = strError.Substring(3)
                ElseIf strError.Trim = "Exception of type 'System.OutOfMemoryException' was thrown." Then
                    strError = "The Server does not have the required memory available."
                End If

                If Not strError.ToUpper.Substring(0, 3) = "IM." Then
                    ExceptionManager.Publish(ex)
                End If

                m_Error.Append("      ").Append(strError).Append(vbNewLine)
            End If
        End Sub

        Protected Friend Overridable Sub WriteError(ex As Exception)
            Dim strError As String = String.Empty

            strError = ex.Message

            If strError = "Error" Then
                strError = DirectCast(ex, CustomApplicationException).MessageText
            End If

            If Not CancelQTPs Then
                CurrentQTPCancel = True
            End If
            CancelQTPs = True


            If strError.ToUpper.Substring(0, 3) = "IM." Then
                strError = strError.Substring(3)
            ElseIf strError.Trim = "Exception of type 'System.OutOfMemoryException' was thrown." Then
                strError = "The Server does not have the required memory available."
            End If

            If Not strError.ToUpper.Substring(0, 3) = "IM." Then
                ExceptionManager.Publish(ex)
            End If

            m_Error.Append("      ").Append(strError).Append(vbNewLine)
        End Sub

        ' Used in QTP/Quiz when joining multiple sqls into one to determine if we need to call the
        ' VAL function.
        Protected Friend Sub SetJoinColumnInfo(ByRef file As IFileObject, field As String)
            m_fleJoinFile = file
            m_strJoinColumn = field
        End Sub

        ''' --- UseSqlVal --------------------------------------------------------
        ''' <summary>
        '''     Returns true of false depending on whether the SqlVal setting is set
        '''     in the Web.Config file
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function SqlValDB() As String

            If m_strSqlValDB.Length = 0 Then
                If Not ConfigurationManager.AppSettings("SqlValDB") Is Nothing Then
                    m_strSqlValDB = ConfigurationManager.AppSettings("SqlValDB")
                Else
                    m_strSqlValDB = " "
                End If
            End If
            Return m_strSqlValDB
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''     Converts a string into a Decimal.
        ''' </summary>
        ''' <param name="Value">A string.</param>
        ''' <returns>A Decimal.</returns>
        ''' <remarks>
        '''     Will only convert numeric values and remove character values.
        ''' </remarks>
        ''' <example>
        '''     VAL("123") returns 123<br />
        '''     VAL("$12") returns 12
        ''' </example>
        ''' <history>
        '''     [Campbell]	4/6/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Function VAL2(Value As String, Optional ByVal StartPosition As Integer = 0,
                                Optional ByVal Length As Integer = 0) As Object

            If StartPosition > 0 Then
                Value = Substring(Value, StartPosition, Length)
            End If

            ' Remove any trailing spaces.
            Value = Value.TrimEnd

            Try
                ' Check if we are joining SQLs to return a single SQL statement.  If a GetStringValue
                ' uses the VAL2, we need to ensure that the VAL function is called in the database.
                If _
                    SqlValDB.Trim.Length > 0 AndAlso (ScreenType = ScreenTypes.QTP OrElse ScreenType = ScreenTypes.QUIZ) AndAlso
                    Not m_fleJoinFile Is Nothing Then
                    If m_fleJoinFile.WhereColumn.Contains(m_strJoinColumn) Then
                        Dim index As Integer = m_fleJoinFile.WhereColumn.IndexOf(m_strJoinColumn)
                        Dim joinString As String = m_fleJoinFile.WhereColumn.Item(index)
                        Dim firstTilde As Integer = joinString.IndexOf("~")
                        Dim secondTilde As Integer = joinString.IndexOf("~", firstTilde + 1)
                        If secondTilde > -1 Then
                            If StartPosition > 0 Then
                                joinString = joinString.Substring(0, firstTilde + 1) + SqlValDB() + "VAL(Substring(" +
                                             joinString.Substring(firstTilde + 1, secondTilde - firstTilde - 1) + "," +
                                             StartPosition.ToString + "," + Length.ToString + "))" +
                                             joinString.Substring(secondTilde)
                            Else
                                joinString = joinString.Substring(0, firstTilde + 1) + SqlValDB() + "VAL(" +
                                             joinString.Substring(firstTilde + 1, secondTilde - firstTilde - 1) + ")" +
                                             joinString.Substring(secondTilde)
                            End If
                            m_fleJoinFile.WhereColumn.Item(index) = joinString
                        End If
                        m_fleJoinFile = Nothing
                        m_strJoinColumn = String.Empty
                    End If
                End If

                '
                If IsNumeric(Value) Then
                    Return CDec(Value)

                    ' TODO: Revisit DECIMAL code.
                    'If InStr(1, strNumber, ".") > 0 And blnDecimal Then
                    '    VAL = VAL * (10 ^ (Len(Trim(strNumber)) - InStr(1, strNumber, ".")))
                    'End If
                Else
                    Dim intPosition As Integer
                    Dim strNewNumber As String = String.Empty

                    If Value.StartsWith("0") Then
                        strNewNumber = Value
                        Do While strNewNumber.StartsWith("0")
                            strNewNumber = strNewNumber.Substring(1)
                        Loop

                        If strNewNumber.Length = 0 Then strNewNumber = "0"

                        If IsNumeric(strNewNumber) Then
                            Return CDec(strNewNumber)
                        End If

                        strNewNumber = ""
                    End If

                    If Not HttpContext.Current.Session(UniqueSessionID + "QtpStr") Is Nothing Then
                        ' This is to ensure that when the VAL2 is called when the ElementOwner is being
                        ' used (from GetDecimalValue, GetNumericDateValue, etc.), that we still fail
                        ' and return the string value.  Pat had coded this to handle returning one SQL
                        ' for all the GetData() calls within Quiz/QTP.
                        HttpContext.Current.Session.Remove(UniqueSessionID + "QtpStr")

                        ' Loop through the string and remove any non-numeric characters.
                        For intPosition = 1 To Value.Length
                            ' Remove non-numeric characters.
                            If Asc(Value.Substring(intPosition, 1)) > 47 And Asc(Value.Substring(intPosition, 1)) < 58 _
                                Then
                                strNewNumber &= Value.Substring(intPosition, 1)
                            End If
                        Next
                    Else
                        ' Loop through the string and remove any non-numeric characters.
                        For intPosition = 0 To Value.Length - 1
                            ' Remove non-numeric characters.
                            If Asc(Value.Substring(intPosition, 1)) > 47 And Asc(Value.Substring(intPosition, 1)) < 58 _
                                Then
                                strNewNumber &= Value.Substring(intPosition, 1)
                            End If
                        Next
                    End If

                    ' Return the new number.
                    If IsNumeric(strNewNumber) Then
                        Return CDec(strNewNumber)
                    Else
                        Return 0
                    End If
                End If

            Catch ex As Exception
                If Not IsNumeric(Value) Then
                    Return Value
                Else
                    Return 0
                End If
            End Try
        End Function

        Protected Friend Overridable Sub EndRequest(strName As String, ByVal ParamArray strSubFile() As Object)

            Dim intSpace As Integer = 12
            Dim intUnchanged As Integer = 0
            Dim blnAddTitle As Boolean = False
            Dim strtemp As String = String.Empty
            Dim intSubCount As Integer = 0

            Try
                If IsAxiant AndAlso CancelQTPs Then

                    If m_Error.Length > 0 Then
                        m_LogFile.Append(vbNewLine)
                        m_LogFile.Append("Error:").Append(vbNewLine)
                        m_LogFile.Append(m_Error.ToString).Append(vbNewLine)
                    End If

                    If CurrentQTPCancel Then
                        m_LogFile.Append(vbNewLine).Append("Changes made since the last commit have been rolled back to a stable state. ").Append(vbNewLine)
                        m_LogFile.Append("Therefore, statistics reported may be incorrect. ").Append(vbNewLine).Append(vbNewLine)
                    Else
                        m_LogFile.Append(vbNewLine).Append("Request ").Append(strName).Append(" condition is false--skipping request.").Append(vbNewLine).Append(vbNewLine)
                    End If


                    WriteLogFile(m_LogFile.ToString)
                    Return
                End If



                dtSortOrder = New DataTable
                strSortOrder = ""
                dcSysDate = 0
                dcSysTime = 0
                dcSysDateTime = 0
                Session(UniqueSessionID + "hsSubFileSize") = hsSubFileSize
                hsSubFileSize = Nothing

                RaiseEvent SaveTempFile(Me, New PageStateEventArgs("_"))
                RaiseSavePageState()

                m_blnNoRecords = False
                m_strNoRecordsLevel = String.Empty
                Dim arrRemove As New ArrayList

                If Not IsNothing(Session(UniqueSessionID + "hsSubfile")) Then
                    'Dim Enumerator As IDictionaryEnumerator = Session(UniqueSessionID + "hsSubfile").GetEnumerator


                    'While Enumerator.MoveNext

                    Dim subkey As String
                    For Each subkey In Session(UniqueSessionID + "hsSubfile").Keys

                        If _
                           arrKeepFile.Contains(subkey) OrElse
                           (alSubTempText.Contains(subkey) OrElse
                            ((ConfigurationManager.AppSettings("SubfileKEEPtoTEXT") & "").ToUpper = "TRUE" AndAlso
                             Not _
                             Session(UniqueSessionID + "alSubTempFile").Contains(
                                 subkey & "_" & Session("SessionID")))) AndAlso
                           Not _
                           (subkey.ToUpper.EndsWith("_TEMP") AndAlso Me.ScreenType = ScreenTypes.QUIZ) _
                           Then

                            If IsNothing(Session("TempFiles")) OrElse Not DirectCast(Session("TempFiles"), ArrayList).Contains(subkey) Then
                                PutDataTextTable(subkey, Session(UniqueSessionID + "hsSubfile")(subkey),
                                           Session(UniqueSessionID + "hsSubfileKeepText").Item(subkey),
                                           strSubFile)
                                Session(UniqueSessionID + "hsSubfile").Item(subkey).Clear()
                            End If

                            'ElseIf Enumerator.Key.ToString.ToUpper.EndsWith("_TEMP") AndAlso Me.ScreenType = ScreenTypes.QUIZ Then
                            '    If Session(UniqueSessionID + "alSubTempFile").Contains(Enumerator.Key.ToString & "_" & Session("SessionID")) Then Session(UniqueSessionID + "alSubTempFile").Remove(Enumerator.Key.ToString & "_" & Session("SessionID"))
                        End If
                        'End While

                    Next

                    For i As Integer = 0 To arrRemove.Count - 1
                        Session(UniqueSessionID + "hsSubfile").Remove(arrRemove.Item(i))
                    Next
                End If

                If arrFileInRequests.Count > 0 Then
                    If arrReadInRequests.Count > 0 Then
                        For i As Integer = 0 To arrReadInRequests.Count - 1
                            If arrReadInRequests(i) <> "" Then
                                m_LogFile.Append("  ").Append(arrReadInRequests(i))

                                For j As Integer = 0 To ((intSpace * 2) - (arrReadInRequests(i).ToString.Length + 3))
                                    m_LogFile.Append(" ")
                                Next

                                If m_hsFileInRequests.ContainsKey(arrReadInRequests(i) & "_Read") Then
                                    strtemp = m_hsFileInRequests.Item(arrReadInRequests(i) & "_Read")
                                    m_LogFile.Append(strtemp.PadLeft(intSpace))
                                    intUnchanged = m_hsFileInRequests.Item(arrReadInRequests(i) & "_Read")
                                Else
                                    m_LogFile.Append("0".PadLeft(intSpace))
                                End If

                                m_LogFile.Append(vbNewLine)
                            End If
                        Next
                    End If

                    'If intTransactions > 0 Then
                    m_LogFile.Append(vbNewLine & "Transactions Processed: ")
                    strtemp = intTransactions.ToString.PadLeft(intSpace)
                    m_LogFile.Append(strtemp & vbNewLine & vbNewLine)
                    'End If

                    'For i As Integer = 0 To arrFileInRequests.Count - 1
                    '    If m_hsFileInOutput.Count > 0 Then
                    '        If Not blnAddTitle Then
                    '            m_LogFile.Append(vbNewLine)
                    '            m_LogFile.Append("Records processed:             Added")

                    '            m_LogFile.Append("Updated".PadLeft(intSpace))
                    '            m_LogFile.Append("Unchanged".PadLeft(intSpace))
                    '            m_LogFile.Append("Deleted".PadLeft(intSpace))

                    '            m_LogFile.Append(vbNewLine)

                    '            blnAddTitle = True
                    '        End If

                    '        If m_hsFileInOutput.Contains(arrFileInRequests(i)) Then
                    '            intUnchanged = m_hsFileInRequests.Item(arrFileInRequests(i) & "_Read")

                    '            m_LogFile.Append("  ").Append(arrFileInRequests(i))

                    '            For j As Integer = 0 To ((intSpace * 2) - (arrFileInRequests(i).ToString.Length + 3))
                    '                m_LogFile.Append(" ")
                    '            Next

                    '            If m_hsFileInRequests.ContainsKey(arrFileInRequests(i) & "_Added") Then
                    '                strtemp = m_hsFileInRequests.Item(arrFileInRequests(i) & "_Added")
                    '                intUnchanged = intUnchanged - m_hsFileInRequests.Item(arrFileInRequests(i) & "_Added")
                    '                m_LogFile.Append(strtemp.PadLeft(intSpace))
                    '            Else
                    '                m_LogFile.Append("0".PadLeft(intSpace))
                    '            End If

                    '            If m_hsFileInRequests.ContainsKey(arrFileInRequests(i) & "_Updated") Then
                    '                strtemp = m_hsFileInRequests.Item(arrFileInRequests(i) & "_Updated")
                    '                m_LogFile.Append(strtemp.PadLeft(intSpace))
                    '                intUnchanged = intUnchanged - m_hsFileInRequests.Item(arrFileInRequests(i) & "_Updated")
                    '            Else
                    '                m_LogFile.Append("0".PadLeft(intSpace))
                    '            End If

                    '            If m_hsFileInRequests.ContainsKey(arrFileInRequests(i) & "_Deleted") Then
                    '                intUnchanged = intUnchanged - m_hsFileInRequests.Item(arrFileInRequests(i) & "_Deleted")
                    '            End If
                    '            If intUnchanged < 0 Then intUnchanged = 0
                    '            m_LogFile.Append(intUnchanged.ToString.PadLeft(intSpace))

                    '            If m_hsFileInRequests.ContainsKey(arrFileInRequests(i) & "_Deleted") Then
                    '                strtemp = m_hsFileInRequests.Item(arrFileInRequests(i) & "_Deleted")
                    '                m_LogFile.Append(strtemp.PadLeft(intSpace))
                    '            Else
                    '                m_LogFile.Append("0".PadLeft(intSpace))
                    '            End If

                    '            m_LogFile.Append(vbNewLine)
                    '        End If
                    '    End If
                    'Next

                    'File object where records have been addded, modified, or deleted.
                    For i As Integer = 0 To arrFilesProcessed.Count - 1
                        If m_hsFileInOutput.Count > 0 Then
                            If (arrFileInRequests.Contains(arrFilesProcessed(i))) Then

                                If Not blnAddTitle Then
                                    m_LogFile.Append(vbNewLine)
                                    m_LogFile.Append("Records processed:             Added")

                                    m_LogFile.Append("Updated".PadLeft(intSpace))
                                    m_LogFile.Append("Unchanged".PadLeft(intSpace))
                                    m_LogFile.Append("Deleted".PadLeft(intSpace))

                                    m_LogFile.Append(vbNewLine)

                                    blnAddTitle = True
                                End If

                                If m_hsFileInOutput.Contains(arrFilesProcessed(i)) Then
                                    intUnchanged = m_hsFilesProcessed.Item(arrFilesProcessed(i) & "_Read")

                                    m_LogFile.Append("  ").Append(arrFilesProcessed(i))

                                    For j As Integer = 0 To ((intSpace * 2) - (arrFilesProcessed(i).ToString.Length + 3))
                                        m_LogFile.Append(" ")
                                    Next

                                    If m_hsFilesProcessed.ContainsKey(arrFilesProcessed(i) & "_Added") Then
                                        strtemp = m_hsFilesProcessed.Item(arrFilesProcessed(i) & "_Added")
                                        intUnchanged = intUnchanged -
                                                       m_hsFilesProcessed.Item(arrFilesProcessed(i) & "_Added")
                                        m_LogFile.Append(strtemp.PadLeft(intSpace))
                                    Else
                                        m_LogFile.Append("0".PadLeft(intSpace))
                                    End If

                                    If m_hsFilesProcessed.ContainsKey(arrFilesProcessed(i) & "_Updated") Then
                                        strtemp = m_hsFilesProcessed.Item(arrFilesProcessed(i) & "_Updated")
                                        m_LogFile.Append(strtemp.PadLeft(intSpace))
                                        intUnchanged = intUnchanged -
                                                       m_hsFilesProcessed.Item(arrFilesProcessed(i) & "_Updated")
                                    Else
                                        m_LogFile.Append("0".PadLeft(intSpace))
                                    End If

                                    If m_hsFilesProcessed.ContainsKey(arrFilesProcessed(i) & "_Unchanged") Then
                                        intUnchanged = m_hsFilesProcessed.Item(arrFilesProcessed(i) & "_Unchanged")
                                    End If
                                    If intUnchanged < 0 Then intUnchanged = 0
                                    m_LogFile.Append(intUnchanged.ToString.PadLeft(intSpace))

                                    If m_hsFilesProcessed.ContainsKey(arrFilesProcessed(i) & "_Deleted") Then
                                        strtemp = m_hsFilesProcessed.Item(arrFilesProcessed(i) & "_Deleted")
                                        m_LogFile.Append(strtemp.PadLeft(intSpace))
                                    Else
                                        m_LogFile.Append("0".PadLeft(intSpace))
                                    End If

                                    m_LogFile.Append(vbNewLine)
                                End If
                            End If
                        End If
                    Next

                    For i As Integer = 0 To arrFilesProcessed.Count - 1
                        If m_hsFileInOutput.Count > 0 Then
                            If (Not arrFileInRequests.Contains(arrFilesProcessed(i))) Then

                                If Not blnAddTitle Then
                                    m_LogFile.Append(vbNewLine)
                                    m_LogFile.Append("Records processed:             Added")

                                    m_LogFile.Append("Updated".PadLeft(intSpace))
                                    m_LogFile.Append("Unchanged".PadLeft(intSpace))
                                    m_LogFile.Append("Deleted".PadLeft(intSpace))

                                    m_LogFile.Append(vbNewLine)

                                    blnAddTitle = True
                                End If

                                If m_hsFileInOutput.Contains(arrFilesProcessed(i)) Then
                                    intUnchanged = m_hsFilesProcessed.Item(arrFilesProcessed(i) & "_Read")

                                    m_LogFile.Append("  ").Append(arrFilesProcessed(i))

                                    For j As Integer = 0 To ((intSpace * 2) - (arrFilesProcessed(i).ToString.Length + 3))
                                        m_LogFile.Append(" ")
                                    Next

                                    If m_hsFilesProcessed.ContainsKey(arrFilesProcessed(i) & "_Added") Then
                                        strtemp = m_hsFilesProcessed.Item(arrFilesProcessed(i) & "_Added")
                                        intUnchanged = intUnchanged -
                                                       m_hsFilesProcessed.Item(arrFilesProcessed(i) & "_Added")
                                        m_LogFile.Append(strtemp.PadLeft(intSpace))
                                    Else
                                        m_LogFile.Append("0".PadLeft(intSpace))
                                    End If

                                    If m_hsFilesProcessed.ContainsKey(arrFilesProcessed(i) & "_Updated") Then
                                        strtemp = m_hsFilesProcessed.Item(arrFilesProcessed(i) & "_Updated")
                                        m_LogFile.Append(strtemp.PadLeft(intSpace))
                                        intUnchanged = intUnchanged -
                                                       m_hsFilesProcessed.Item(arrFilesProcessed(i) & "_Updated")
                                    Else
                                        m_LogFile.Append("0".PadLeft(intSpace))
                                    End If

                                    If m_hsFilesProcessed.ContainsKey(arrFilesProcessed(i) & "_Unchanged") Then
                                        intUnchanged = m_hsFilesProcessed.Item(arrFilesProcessed(i) & "_Unchanged")
                                    End If
                                    If intUnchanged < 0 Then intUnchanged = 0
                                    m_LogFile.Append(intUnchanged.ToString.PadLeft(intSpace))

                                    If m_hsFilesProcessed.ContainsKey(arrFilesProcessed(i) & "_Deleted") Then
                                        strtemp = m_hsFilesProcessed.Item(arrFilesProcessed(i) & "_Deleted")
                                        m_LogFile.Append(strtemp.PadLeft(intSpace))
                                    Else
                                        m_LogFile.Append("0".PadLeft(intSpace))
                                    End If

                                    m_LogFile.Append(vbNewLine)
                                End If
                            End If
                        End If
                    Next

                    ' Write out the information where an Output did not add, update or delete any records.
                    Dim keys As ICollection = m_hsFileInOutput.Keys
                    Dim key, value As Object
                    For Each key In keys
                        value = m_hsFileInOutput(key)
                        If Not arrFilesProcessed.Contains(value) Then
                            If Not blnAddTitle Then
                                m_LogFile.Append(vbNewLine)
                                m_LogFile.Append("Records processed:             Added")

                                m_LogFile.Append("Updated".PadLeft(intSpace))
                                m_LogFile.Append("Unchanged".PadLeft(intSpace))
                                m_LogFile.Append("Deleted".PadLeft(intSpace))

                                m_LogFile.Append(vbNewLine)

                                blnAddTitle = True
                            End If
                            m_LogFile.Append("  ").Append(value)

                            For j As Integer = 0 To ((intSpace * 2) - (value.ToString.Length + 3))
                                m_LogFile.Append(" ")
                            Next

                            m_LogFile.Append("0".PadLeft(intSpace))
                            m_LogFile.Append("0".PadLeft(intSpace))
                            m_LogFile.Append("0".PadLeft(intSpace))
                            m_LogFile.Append("0".PadLeft(intSpace))
                            m_LogFile.Append(vbNewLine)
                        End If
                    Next

                    ' Write out the information for the SubFile.
                    'For i As Integer = 0 To arrSubFiles.Count - 1
                    '    If Not blnAddTitle Then
                    '        m_LogFile.Append(vbNewLine)
                    '        m_LogFile.Append("Records processed:             Added")

                    '        m_LogFile.Append("Updated".PadLeft(intSpace))
                    '        m_LogFile.Append("Unchanged".PadLeft(intSpace))
                    '        m_LogFile.Append("Deleted".PadLeft(intSpace))

                    '        m_LogFile.Append(vbNewLine)

                    '        blnAddTitle = True
                    '    End If

                    '    m_LogFile.Append("  ").Append(arrSubFiles(i))

                    '    For j As Integer = 0 To ((intSpace * 2) - (arrSubFiles(i).ToString.Length + 3))
                    '        m_LogFile.Append(" ")
                    '    Next

                    '    If arrFilesProcessed.Contains(arrSubFiles(i)) Then
                    '        If m_hsFilesProcessed.ContainsKey(arrSubFiles(i) & "_Added") Then
                    '            strtemp = m_hsFilesProcessed.Item(arrSubFiles(i) & "_Added")
                    '            m_LogFile.Append(strtemp.PadLeft(intSpace))
                    '        Else
                    '            m_LogFile.Append("0".PadLeft(intSpace))
                    '        End If

                    '        m_LogFile.Append("0".PadLeft(intSpace))
                    '        m_LogFile.Append("0".PadLeft(intSpace))
                    '        m_LogFile.Append("0".PadLeft(intSpace))
                    '        m_LogFile.Append(vbNewLine)
                    '    Else
                    '        m_LogFile.Append("0".PadLeft(intSpace))
                    '        m_LogFile.Append("0".PadLeft(intSpace))
                    '        m_LogFile.Append("0".PadLeft(intSpace))
                    '        m_LogFile.Append("0".PadLeft(intSpace))
                    '        m_LogFile.Append(vbNewLine)
                    '    End If
                    'Next

                    ' Write out the information for the SubFile that was never written to.
                    If Not blnAddTitle AndAlso Me.ScreenType = ScreenTypes.QUIZ Then
                        ' Remove the Request files from the SubFile list.  The remaining subfile is the one
                        ' that is in the SubFile statement but never got executed.
                        For i As Integer = 0 To arrFileInRequests.Count - 1
                            If arrSubFiles.Contains(arrFileInRequests(i)) Then
                                arrSubFiles.Remove(arrFileInRequests(i))
                            End If
                        Next

                        If arrSubFiles.Count > 0 Then
                            m_LogFile.Append(vbNewLine)
                            m_LogFile.Append("Records processed:             Added")

                            m_LogFile.Append("Updated".PadLeft(intSpace))
                            m_LogFile.Append("Unchanged".PadLeft(intSpace))
                            m_LogFile.Append("Deleted".PadLeft(intSpace))

                            m_LogFile.Append(vbNewLine)

                            blnAddTitle = True
                            m_LogFile.Append("  ").Append(arrSubFiles(0))
                            For j As Integer = 0 To ((intSpace * 2) - (arrSubFiles(0).ToString.Length + 3))
                                m_LogFile.Append(" ")
                            Next
                            m_LogFile.Append("0".PadLeft(intSpace))
                            m_LogFile.Append("0".PadLeft(intSpace))
                            m_LogFile.Append("0".PadLeft(intSpace))
                            m_LogFile.Append("0".PadLeft(intSpace))
                            m_LogFile.Append(vbNewLine)
                        End If
                    End If
                End If

                If m_Error.Length > 0 Then
                    m_LogFile.Append(vbNewLine)
                    m_LogFile.Append("Error:").Append(vbNewLine)
                    m_LogFile.Append(m_Error.ToString).Append(vbNewLine)
                End If

                m_LogFile.Append(vbNewLine)
                m_LogFile.Append(("End Request: " & strName).ToString.PadRight(40))
                m_LogFile.Append(Now.Day.ToString.PadLeft(2, "0")).Append("/").Append(Now.Month.ToString.PadLeft(2, "0")) _
                    .Append("/").Append(Now.Year.ToString).Append(" ")
                m_LogFile.Append(TimeOfDay.ToLongTimeString)
                m_LogFile.Append(vbNewLine).Append(vbNewLine).Append(vbNewLine)

                WriteLogFile(m_LogFile.ToString)

                m_LogFile.Remove(0, m_LogFile.Length)
                m_hsFileInRequests = New Hashtable
                arrFileInRequests = Nothing
                arrReadInRequests = Nothing
                m_hsFileInOutput = New SortedList
                m_SortFileOrder = 0

                If Not IsNothing(m_dtbDataTable) Then
                    m_dtbDataTable.Dispose()
                    m_dtbDataTable = Nothing
                End If

#If TARGET_DB = "INFORMIX" Then
                Session(UniqueSessionID + "cnnQUERY") = cnnQUERY
                Session(UniqueSessionID + "cnnTRANS_UPDATE") = cnnTRANS_UPDATE
                Session(UniqueSessionID + "trnTRANS_UPDATE") = trnTRANS_UPDATE
#Else
                Try
                    TRANS_UPDATE(TransactionMethods.Commit)

                Catch ex As Exception

                End Try

#End If

            Catch ex As CustomApplicationException

                Throw ex

            Catch ex As Exception

                ExceptionManager.Publish(ex)
                Throw ex

            Finally

                Try
                    CloseTransactionObjects()
                Catch ex As CustomApplicationException
                    Throw ex
                Catch ex As Exception
                    Throw ex
                End Try
                GC.Collect()

            End Try
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [mayur]	8/19/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function GetDEFAULT_BATCH_FILE_DIRECTORY() As String
            If m_strDEFAULT_BATCH_FILE_DIRECTORY = "" Then
                m_strDEFAULT_BATCH_FILE_DIRECTORY = ConfigurationManager.AppSettings("Default_Batch_File_Directory")
                m_strDEFAULT_BATCH_FILE_DIRECTORY = m_strDEFAULT_BATCH_FILE_DIRECTORY.Replace("UserID", Environment.UserName)
            End If

            Return m_strDEFAULT_BATCH_FILE_DIRECTORY
        End Function

        Protected Sub WriteLogFile(strText As String)
            Try

                Dim sw As StreamWriter
                Dim Fs As FileStream
                Dim strDirectory As String = GetDEFAULT_BATCH_FILE_DIRECTORY()
                Dim newFile As String = ""

                If Not strDirectory.Trim = "" Then
                    If Not Directory.Exists(strDirectory) Then Directory.CreateDirectory(strDirectory)
                    If _
                        (Not ConfigurationManager.AppSettings("JobOutPut") Is Nothing AndAlso
                         ConfigurationManager.AppSettings("JobOutPut").ToUpper() = "TRUE") Then
                        newFile = strDirectory & "\" & Session("JobOutPut") & ".txt"
                    Else
                        newFile = strDirectory & "\" & Session(UniqueSessionID + "LogName") & ".txt"
                    End If


                    If File.Exists(newFile) Then
                        Fs = New FileStream(newFile, FileMode.Append, FileAccess.Write, FileShare.None)
                    Else
                        Fs = New FileStream(newFile, FileMode.CreateNew, FileAccess.Write, FileShare.None)
                    End If
                    sw = New StreamWriter(Fs, Encoding.Default)
                    sw.Write(strText)
                    sw.Flush()
                    sw.Close()

                End If

            Catch ex As Exception

                ExceptionManager.Publish(ex)
                Throw ex

            End Try
        End Sub

        Public Sub WriteGlobalParametersToLogFile()

            Try


                If m_GlobalParameters.ToString().Trim() <> String.Empty Then
                    m_LogFile.Remove(0, m_LogFile.Length)
                    m_LogFile.Append(vbNewLine)
                    m_LogFile.Append("Global Parameters").Append(vbNewLine)
                    m_LogFile.Append(m_GlobalParameters.ToString())
                    WriteLogFile(m_LogFile.ToString())

                    m_GlobalParameters.Remove(0, m_GlobalParameters.Length)
                End If


            Catch ex As Exception

                ExceptionManager.Publish(ex)
                Throw ex

            End Try
        End Sub

        Public Sub StoreClassParametersForLogFile(line As String)
            Try

                m_ClassParameters.Append(line).Append(vbNewLine)

            Catch ex As Exception
                ExceptionManager.Publish(ex)
                Throw ex

            End Try
        End Sub

        Public Sub StoreGlobalParametersForLogFile(line As String)
            Try

                m_GlobalParameters.Append(line).Append(vbNewLine)

            Catch ex As Exception
                ExceptionManager.Publish(ex)
                Throw ex

            End Try
        End Sub

        Public Sub AddRecordsRead(strFile As String, intRecords As Integer, LogType As LogType)

            If _
                LogType = LogType.Added Or LogType = LogType.Deleted Or LogType = LogType.Updated Or
                LogType = LogType.OutPut Or LogType = LogType.UnChanged Then
                AddRecordsProcessed(strFile, intRecords, LogType)
            Else
                If Not LogType = LogType.OutPut AndAlso Not arrFileInRequests.Contains(strFile) Then
                    If Not blnHasBeenSort Then
                        arrFileInRequests.Add(strFile)
                    End If
                End If

                '            Select Case LogType
                'Case LogType.Added
                '    If m_hsFileInRequests.ContainsKey(strFile & "_Added") Then
                '        m_hsFileInRequests.Item(strFile & "_Added") = m_hsFileInRequests.Item(strFile & "_Added") + intRecords
                '    Else
                '        m_hsFileInRequests.Add(strFile & "_Added", intRecords)
                '    End If
                'Case LogType.Deleted
                '    If m_hsFileInRequests.ContainsKey(strFile & "_Deleted") Then
                '        m_hsFileInRequests.Item(strFile & "_Deleted") = m_hsFileInRequests.Item(strFile & "_Deleted") + intRecords
                '    Else
                '        m_hsFileInRequests.Add(strFile & "_Deleted", intRecords)
                '    End If
                '                Case LogType.Read
                If Not blnHasBeenSort Then
                    If Not arrReadInRequests.Contains(strFile) Then
                        arrReadInRequests.Add(strFile)
                    End If
                    If m_hsFileInRequests.ContainsKey(strFile & "_Read") Then
                        m_hsFileInRequests.Item(strFile & "_Read") = m_hsFileInRequests.Item(strFile & "_Read") +
                                                                     intRecords
                    Else
                        m_hsFileInRequests.Add(strFile & "_Read", intRecords)
                    End If
                End If
                'Case LogType.Updated
                '    If m_hsFileInRequests.ContainsKey(strFile & "_Updated") Then
                '        m_hsFileInRequests.Item(strFile & "_Updated") = m_hsFileInRequests.Item(strFile & "_Updated") + intRecords
                '    Else
                '        m_hsFileInRequests.Add(strFile & "_Updated", intRecords)
                '    End If

                'Case LogType.OutPut
                '    If Not m_hsFileInOutput.Contains(strFile) Then
                '        m_hsFileInOutput.Add(strFile, strFile)
                '    End If
                'End Select
            End If
        End Sub

        Public Sub AddRecordsProcessed(strFile As String, intRecords As Integer, LogType As LogType)

            If Not arrFilesProcessed.Contains(strFile) Then
                'If Not blnHasBeenSort Then
                arrFilesProcessed.Add(strFile)
                'End If
            End If

            Select Case LogType
                Case LogType.Added

                    AddRecordsProcessed(strFile, intRecords, LogType.OutPut)

                    If m_hsFilesProcessed.ContainsKey(strFile & "_Added") Then
                        m_hsFilesProcessed.Item(strFile & "_Added") = m_hsFilesProcessed.Item(strFile & "_Added") +
                                                                      intRecords
                    Else
                        m_hsFilesProcessed.Add(strFile & "_Added", intRecords)
                    End If
                Case LogType.Deleted
                    If m_hsFilesProcessed.ContainsKey(strFile & "_Deleted") Then
                        m_hsFilesProcessed.Item(strFile & "_Deleted") = m_hsFilesProcessed.Item(strFile & "_Deleted") +
                                                                        intRecords
                    Else
                        m_hsFilesProcessed.Add(strFile & "_Deleted", intRecords)
                    End If
                Case LogType.Updated
                    If m_hsFilesProcessed.ContainsKey(strFile & "_Updated") Then
                        m_hsFilesProcessed.Item(strFile & "_Updated") = m_hsFilesProcessed.Item(strFile & "_Updated") +
                                                                        intRecords
                    Else
                        m_hsFilesProcessed.Add(strFile & "_Updated", intRecords)
                    End If
                Case LogType.UnChanged
                    If m_hsFilesProcessed.ContainsKey(strFile & "_Unchanged") Then
                        m_hsFilesProcessed.Item(strFile & "_Unchanged") = m_hsFilesProcessed.Item(strFile & "_Unchanged") +
                                                                        intRecords
                    Else
                        m_hsFilesProcessed.Add(strFile & "_Unchanged", intRecords)
                    End If
                Case LogType.OutPut
                    If Not m_hsFileInOutput.Contains(strFile) Then
                        m_hsFileInOutput.Add(strFile, strFile)
                    End If
            End Select
        End Sub

        Public Sub AddRecordsProcessed(strFile As String, strFileAlias As String, intRecords As Integer, LogType As LogType)

            If strFileAlias.Length > 0 Then
                strFile = strFileAlias
            End If

            If Not arrFilesProcessed.Contains(strFile) Then
                'If Not blnHasBeenSort Then
                arrFilesProcessed.Add(strFile)
                'End If
            End If

            Select Case LogType
                Case LogType.Added

                    AddRecordsProcessed(strFile, intRecords, LogType.OutPut)

                    If m_hsFilesProcessed.ContainsKey(strFile & "_Added") Then
                        m_hsFilesProcessed.Item(strFile & "_Added") = m_hsFilesProcessed.Item(strFile & "_Added") +
                                                                      intRecords
                    Else
                        m_hsFilesProcessed.Add(strFile & "_Added", intRecords)
                    End If
                Case LogType.Deleted
                    If m_hsFilesProcessed.ContainsKey(strFile & "_Deleted") Then
                        m_hsFilesProcessed.Item(strFile & "_Deleted") = m_hsFilesProcessed.Item(strFile & "_Deleted") +
                                                                        intRecords
                    Else
                        m_hsFilesProcessed.Add(strFile & "_Deleted", intRecords)
                    End If
                Case LogType.Updated
                    If m_hsFilesProcessed.ContainsKey(strFile & "_Updated") Then
                        m_hsFilesProcessed.Item(strFile & "_Updated") = m_hsFilesProcessed.Item(strFile & "_Updated") +
                                                                        intRecords
                    Else
                        m_hsFilesProcessed.Add(strFile & "_Updated", intRecords)
                    End If
                Case LogType.UnChanged
                    If m_hsFilesProcessed.ContainsKey(strFile & "_Unchanged") Then
                        m_hsFilesProcessed.Item(strFile & "_Unchanged") = m_hsFilesProcessed.Item(strFile & "_Unchanged") +
                                                                        intRecords
                    Else
                        m_hsFilesProcessed.Add(strFile & "_Unchanged", intRecords)
                    End If
                Case LogType.OutPut
                    If Not m_hsFileInOutput.Contains(strFile) Then
                        m_hsFileInOutput.Add(strFile, strFile)
                    End If
            End Select
        End Sub


#Region " Methods to Save/Retrieve State "

        ''' --- RetrieveState ------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of RetrieveState.
        ''' </summary>
        ''' <param name="InField"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Friend Overridable Sub RetrieveState(Optional ByVal InField As Boolean = False)
            'Retrieve State information by overriding this method into a Derived page
            'Note: At present we are not Retrieving state of CoreBaseTypes internally
            'TODO: to be changed to Save/Retrieve State Internally
        End Sub

        ''' --- SaveState ----------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of SaveState.
        ''' </summary>
        ''' <param name="InField"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Friend Overridable Sub SaveState(Optional ByVal InField As Boolean = False)
            'Save State information by overriding this method into a Derived page
            'Note: At present we are not saving state of CoreBaseTypes internally
            'TODO: to be changed to Save/Retrieve State Internally
        End Sub

        ''' --- RetrieveParamsReceived ---------------------------------------------
        ''' <summary>
        '''     This method is called to handle the values received by this screen.
        '''     objects.
        ''' </summary>
        ''' <remarks>
        '''     Use the RetrieveParamsReceived method to handle assigning the values passed in to
        '''     the screen to the appropriate File/Temporary objects.
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Overridable Sub RetrieveParamsReceived()
            'Retrieve Params Received from State information by overriding this method into a Derived page
        End Sub

        ''' --- RetrieveInitalizeParamsReceived ---------------------------------------------
        ''' <summary>
        '''     This method is called to handle the values received by this screen.
        '''     objects.
        ''' </summary>
        ''' <remarks>
        '''     Use the RetrieveInitalizeParamsReceived method to handle assigning the values passed in to
        '''     the screen to the appropriate File/Temporary objects.
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Overridable Sub RetrieveInitalizeParamsReceived()
            'Retrieve Params Received from State information by overriding this method into a Derived page
        End Sub

        ''' --- SaveInitalizeParamsReceived -------------------------------------------------
        ''' <summary>
        '''     This method is called to handle updating the values received by this screen.
        '''     objects.
        ''' </summary>
        ''' <remarks>
        '''     Use the SaveInitalizeParamsReceived method to handle updating the values from the
        '''     File/Temporary objects that were passed in to this screen.
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/5/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Overridable Sub SaveInitalizeParamsReceived()
            'Save Params Received into State information by overriding this method into a Derived page
        End Sub

        ''' --- AddDateFunction --------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Wraps the date field within the appropriate date function code.
        ''' </summary>
        ''' <param name="Field">The field to add the function around.</param>
        ''' <remarks>
        '''     Returns a string with the date function.
        ''' </remarks>
        ''' <example>
        '''     1. AddDateFunction("EMPLOYEE.START_DATE") will return
        '''     " TO_NUMBER(TO_CHAR(EMPLOYEE.START_DATE, 'YYYYMMDD'))" <br />
        ''' </example>
        ''' <history>
        '''     [Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Protected Function AddDateFunction(Field As String) As String

            Dim sb As StringBuilder = New StringBuilder(255)

            If ConfigurationManager.AppSettings("AuthenticationDatabase") Is Nothing OrElse
               ConfigurationManager.AppSettings("AuthenticationDatabase").ToString.Equals(cORACLE) Then
                Return sb.Append("TO_NUMBER(TO_CHAR(").Append(Field).Append(", 'YYYYMMDD'))").ToString
            Else
                Return sb.Append("CONVERT(INTEGER, CONVERT(CHAR(8), ").Append(Field).Append(", 112))").ToString
            End If
        End Function

        ''' --- GetWhereClauseString --------------------------------------------------
        ''' <summary>
        '''     Generates a string value containing a SQL WHERE clause.
        ''' </summary>
        ''' <param name="Field1">The first field in the SQL statement.</param>
        ''' <param name="Operator">The Operator value.</param>
        ''' <param name="Field2">The second field in the SQL statement</param>
        ''' <param name="AddWhere">
        '''     Indicates that this is the first field in the WHERE clause and the keyword WHERE is to be
        '''     appended.  This is passed in using a variable.
        ''' </param>
        ''' <remarks>
        '''     Returns a formatted SQL WHERE CLAUSE by concatenating the parameters Field1, Operator and Field2 for date fields to
        '''     ensure that
        '''     fields with a NULL are also returned if necessary.
        ''' </remarks>
        ''' <example>
        '''     1. GetWhereClauseString("EMPLOYEE.START_DATE", "=", 0, True) will return
        '''     " WHERE EMPLOYEE.START_DATE IS NULL" <br />
        '''     2. GetWhereClauseString("EMPLOYEE.START_DATE", "&lt;", 19991231, True) will return
        '''     " WHERE (EMPLOYEE.START_DATE IS NULL OR TO_NUMBER(TO_CHAR(EMPLOYEE.START_DATE,'YYYYMMDD')) &lt; 19991231)" <br />
        '''     3. GetWhereClauseString(19991231, "&gt;", "EMPLOYEE.START_DATE", True) will return
        '''     " WHERE (19991231 &gt; (TO_NUMBER(TO_CHAR(EMPLOYEE.START_DATE,'YYYYMMDD')) OR EMPLOYEE.START_DATE IS NULL)" <br />
        ''' </example>
        ''' <history>
        '''     [Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Function GetWhereClauseString(Field1 As String, [Operator] As String, Field2 As String,
                                                AddWhere As Boolean) As String

            Dim sb As StringBuilder = New StringBuilder(String.Empty)

            If AddWhere Then
                sb.Append(" WHERE ")
            Else
                sb.Append(" AND ")
            End If

            sb.Append(GetWhereClauseString(Field1, [Operator], Field2))

            Return sb.ToString
        End Function


        ''' --- GetWhereClauseString --------------------------------------------------
        ''' <summary>
        '''     Generates a string value containing a SQL WHERE clause.
        ''' </summary>
        ''' <param name="Field1">The first field in the SQL statement.</param>
        ''' <param name="Operator">The Operator value.</param>
        ''' <param name="Field2">The second field in the SQL statement</param>
        ''' <remarks>
        '''     Returns a formatted SQL WHERE CLAUSE by concatenating the parameters Field1, Operator and Field2 for date fields to
        '''     ensure that
        '''     fields with a NULL are also returned if necessary.
        ''' </remarks>
        ''' <example>
        '''     1. GetWhereClauseString("EMPLOYEE.START_DATE", "=", 0, True) will return
        '''     " WHERE EMPLOYEE.START_DATE IS NULL" <br />
        '''     2. GetWhereClauseString("EMPLOYEE.START_DATE", "&lt;", 19991231, True) will return
        '''     " WHERE (EMPLOYEE.START_DATE IS NULL OR TO_NUMBER(TO_CHAR(EMPLOYEE.START_DATE,'YYYYMMDD')) &lt; 19991231)" <br />
        '''     3. GetWhereClauseString(19991231, "&gt;", "EMPLOYEE.START_DATE", True) will return
        '''     " WHERE (19991231 &gt; (TO_NUMBER(TO_CHAR(EMPLOYEE.START_DATE,'YYYYMMDD')) OR EMPLOYEE.START_DATE IS NULL)" <br />
        ''' </example>
        ''' <history>
        '''     [Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Function GetWhereClauseString(Field1 As String, [Operator] As String, Field2 As String) As String

            Dim sb As StringBuilder = New StringBuilder(String.Empty)
            Dim arrField2() As String = Field2.Split(",")

            If [Operator].ToUpper = "IN" Then

                For i As Integer = 0 To arrField2.Length - 1
                    If sb.Length > 0 Then sb.Append(" OR ")
                    sb.Append(GetWhereClauseString(Field1, "=", CDec(arrField2(i).Trim)))
                Next

            Else
                sb.Append("(")
                sb.Append((Field1)).Append(" ").Append([Operator]).Append(" ").Append((Field2))

                If [Operator].Trim.Equals("=") Then
                    sb.Append(" OR ( ").Append(Field1).Append(" IS NULL ").Append(" AND ").Append(Field2).Append(
                        " IS NULL )")
                ElseIf [Operator].Trim.Equals("<") Then
                    sb.Append(" OR ( ").Append(Field1).Append(" IS NULL ").Append(" AND ").Append(Field2).Append(
                        " IS NOT NULL )")
                ElseIf [Operator].Trim.Equals(">") Then
                    sb.Append(" OR ( ").Append(Field1).Append(" IS NOT NULL ").Append(" AND ").Append(Field2).Append(
                        " IS NULL )")
                ElseIf [Operator].Trim.Equals("<>") Then
                    sb.Append(" OR (( ").Append(Field1).Append(" IS NOT NULL ").Append(" AND ").Append(Field2).Append(
                        " IS NULL ) ")
                    sb.Append(" OR ( ").Append(Field1).Append(" IS NULL ").Append(" AND ").Append(Field2).Append(
                        " IS NOT NULL ))")
                End If

                sb.Append(")")
            End If

            Return sb.ToString
        End Function

        ''' --- GetWhereClauseString --------------------------------------------------
        ''' <summary>
        '''     Generates a string value containing a SQL WHERE clause.
        ''' </summary>
        ''' <param name="Field1">The first field in the SQL statement.</param>
        ''' <param name="Operator">The Operator value.</param>
        ''' <param name="Field2">The second field in the SQL statement</param>
        ''' <param name="AddWhere">
        '''     Indicates that this is the first field in the WHERE clause and the keyword WHERE is to be
        '''     appended.  This is passed in using a variable.
        ''' </param>
        ''' <remarks>
        '''     Returns a formatted SQL WHERE CLAUSE by concatenating the parameters Field1, Operator and Field2 for date fields to
        '''     ensure that
        '''     fields with a NULL are also returned if necessary.
        ''' </remarks>
        ''' <example>
        '''     1. GetWhereClauseString("EMPLOYEE.START_DATE", "=", 0, True) will return
        '''     " WHERE EMPLOYEE.START_DATE IS NULL" <br />
        '''     2. GetWhereClauseString("EMPLOYEE.START_DATE", "&lt;", 19991231, True) will return
        '''     " WHERE (EMPLOYEE.START_DATE IS NULL OR TO_NUMBER(TO_CHAR(EMPLOYEE.START_DATE,'YYYYMMDD')) &lt; 19991231)" <br />
        '''     3. GetWhereClauseString(19991231, "&gt;", "EMPLOYEE.START_DATE", True) will return
        '''     " WHERE (19991231 &gt; (TO_NUMBER(TO_CHAR(EMPLOYEE.START_DATE,'YYYYMMDD')) OR EMPLOYEE.START_DATE IS NULL)" <br />
        ''' </example>
        ''' <history>
        '''     [Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Function GetWhereClauseString(Field1 As String, [Operator] As String, Field2 As Decimal,
                                                AddWhere As Boolean) As String

            Dim sb As StringBuilder = New StringBuilder(String.Empty)

            If AddWhere Then
                sb.Append(" WHERE ")
            Else
                sb.Append(" AND ")
            End If

            sb.Append(GetWhereClauseString(Field1, [Operator], Field2))

            Return sb.ToString
        End Function

        ''' --- GetWhereClauseString --------------------------------------------------
        ''' <summary>
        '''     Generates a string value containing a SQL WHERE clause.
        ''' </summary>
        ''' <param name="Field1">The first field in the SQL statement.</param>
        ''' <param name="Operator">The Operator value.</param>
        ''' <param name="Field2">The second field in the SQL statement</param>
        ''' <remarks>
        '''     Returns a formatted SQL WHERE CLAUSE by concatenating the parameters Field1, Operator and Field2 for date fields to
        '''     ensure that
        '''     fields with a NULL are also returned if necessary.
        ''' </remarks>
        ''' <example>
        '''     1. GetWhereClauseString("EMPLOYEE.START_DATE", "=", 0, True) will return
        '''     " WHERE EMPLOYEE.START_DATE IS NULL" <br />
        '''     2. GetWhereClauseString("EMPLOYEE.START_DATE", "&lt;", 19991231, True) will return
        '''     " WHERE (EMPLOYEE.START_DATE IS NULL OR TO_NUMBER(TO_CHAR(EMPLOYEE.START_DATE,'YYYYMMDD')) &lt; 19991231)" <br />
        '''     3. GetWhereClauseString(19991231, "&gt;", "EMPLOYEE.START_DATE", True) will return
        '''     " WHERE (19991231 &gt; (TO_NUMBER(TO_CHAR(EMPLOYEE.START_DATE,'YYYYMMDD')) OR EMPLOYEE.START_DATE IS NULL)" <br />
        ''' </example>
        ''' <history>
        '''     [Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Function GetWhereClauseString(Field1 As String, [Operator] As String, Field2 As Decimal) As String

            Dim sb As StringBuilder = New StringBuilder(String.Empty)

            If Field2 = 0 Then
                If [Operator].Trim.Equals("=") Then
                    sb.Append(Field1).Append(" IS NULL ")
                ElseIf [Operator].Trim.Equals("<>") OrElse [Operator].Trim.Equals("!=") Then
                    sb.Append(Field1).Append(" IS NOT NULL ")
                Else
                    If [Operator].Trim.IndexOf("=") > -1 Then
                        sb.Append("(").Append(Field1).Append(" IS NULL OR ").Append(AddDateFunction(Field1)).Append(" ") _
                            .Append([Operator]).Append(" 0)")
                    Else
                        sb.Append(AddDateFunction(Field1)).Append(" ").Append([Operator]).Append(" 0")
                    End If
                End If
            Else
                If [Operator].IndexOf("<") > -1 Then
                    sb.Append("(").Append(Field1).Append(" IS NULL OR ").Append(AddDateFunction(Field1)).Append(" ").
                        Append([Operator]).Append(" ").Append(Field2).Append(")")
                Else
                    sb.Append(AddDateFunction(Field1)).Append(" ").Append([Operator]).Append(" ").Append(Field2)
                End If
            End If

            Return sb.ToString
        End Function

        ''' --- GetWhereClauseString --------------------------------------------------
        ''' <summary>
        '''     Generates a string value containing a SQL WHERE clause.
        ''' </summary>
        ''' <param name="Field1">The first field in the SQL statement.</param>
        ''' <param name="Operator">The Operator value.</param>
        ''' <param name="Field2">The second field in the SQL statement</param>
        ''' <param name="AddWhere">
        '''     Indicates that this is the first field in the WHERE clause and the keyword WHERE is to be
        '''     appended.  This is passed in using a variable.
        ''' </param>
        ''' <remarks>
        '''     Returns a formatted SQL WHERE CLAUSE by concatenating the parameters Field1, Operator and Field2 for date fields to
        '''     ensure that
        '''     fields with a NULL are also returned if necessary.
        ''' </remarks>
        ''' <example>
        '''     1. GetWhereClauseString("EMPLOYEE.START_DATE", "=", 0, True) will return
        '''     " WHERE EMPLOYEE.START_DATE IS NULL" <br />
        '''     2. GetWhereClauseString("EMPLOYEE.START_DATE", "&lt;", 19991231, True) will return
        '''     " WHERE (EMPLOYEE.START_DATE IS NULL OR TO_NUMBER(TO_CHAR(EMPLOYEE.START_DATE,'YYYYMMDD')) &lt; 19991231)" <br />
        '''     3. GetWhereClauseString(19991231, "&gt;", "EMPLOYEE.START_DATE", True) will return
        '''     " WHERE (19991231 &gt; (TO_NUMBER(TO_CHAR(EMPLOYEE.START_DATE,'YYYYMMDD')) OR EMPLOYEE.START_DATE IS NULL)" <br />
        ''' </example>
        ''' <history>
        '''     [Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Function GetWhereClauseString(Field1 As Decimal, [Operator] As String, Field2 As String,
                                                ByRef AddWhere As Boolean) As String

            Dim sb As StringBuilder = New StringBuilder(String.Empty)

            If AddWhere Then
                sb.Append(" WHERE ")
            Else
                sb.Append(" AND ")
            End If

            sb.Append(GetWhereClauseString(Field1, [Operator], Field2))

            Return sb.ToString
        End Function

        ''' --- GetWhereClauseString --------------------------------------------------
        ''' <summary>
        '''     Generates a string value containing a SQL WHERE clause.
        ''' </summary>
        ''' <param name="Field1">The first field in the SQL statement.</param>
        ''' <param name="Operator">The Operator value.</param>
        ''' <param name="Field2">The second field in the SQL statement</param>
        ''' <remarks>
        '''     Returns a formatted SQL WHERE CLAUSE by concatenating the parameters Field1, Operator and Field2 for date fields to
        '''     ensure that
        '''     fields with a NULL are also returned if necessary.
        ''' </remarks>
        ''' <example>
        '''     1. GetWhereClauseString("EMPLOYEE.START_DATE", "=", 0, True) will return
        '''     " WHERE EMPLOYEE.START_DATE IS NULL" <br />
        '''     2. GetWhereClauseString("EMPLOYEE.START_DATE", "&lt;", 19991231, True) will return
        '''     " WHERE (EMPLOYEE.START_DATE IS NULL OR TO_NUMBER(TO_CHAR(EMPLOYEE.START_DATE,'YYYYMMDD')) &lt; 19991231)" <br />
        '''     3. GetWhereClauseString(19991231, "&gt;", "EMPLOYEE.START_DATE", True) will return
        '''     " WHERE (19991231 &gt; (TO_NUMBER(TO_CHAR(EMPLOYEE.START_DATE,'YYYYMMDD')) OR EMPLOYEE.START_DATE IS NULL)" <br />
        ''' </example>
        ''' <history>
        '''     [Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Function GetWhereClauseString(Field1 As Decimal, [Operator] As String, Field2 As String) As String

            Dim sb As StringBuilder = New StringBuilder(String.Empty)

            If Field1 = 0 Then
                If [Operator].Trim.Equals("=") Then
                    sb.Append(Field2).Append(" IS NULL ")
                Else
                    If [Operator].Trim.IndexOf("=") > -1 Then
                        sb.Append("(").Append(Field2).Append(" IS NULL OR 0 ").Append([Operator]).Append(" ").Append(
                            AddDateFunction(Field2)).Append(")")
                    Else
                        sb.Append("0 ").Append([Operator]).Append(" ").Append(AddDateFunction(Field2))
                    End If
                End If
            Else
                If [Operator].IndexOf(">") > -1 Then
                    sb.Append("(").Append(Field2).Append(" IS NULL OR ").Append(Field1).Append(" ").Append([Operator]).
                        Append(" ").Append(AddDateFunction(Field2)).Append(")")
                Else
                    sb.Append(Field1).Append(" ").Append([Operator]).Append(" ").Append(AddDateFunction(Field2))
                End If
            End If

            Return sb.ToString
        End Function

#If TARGET_DB = "INFORMIX" Then

        ''' --- GetData ------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' 	Summary of GetData.
        ''' </summary>
        ''' <param name="FileObject"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Function GetData(ByRef FileObject As IfxFileObject) As Boolean
            Return GetData(FileObject, String.Empty, String.Empty, String.Empty, GetDataOptions.None,
m_intRecordsToFillInFindOrDetailFind)
        End Function

        ''' --- GetData ------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' 	Summary of GetData.
        ''' </summary>
        ''' <param name="FileObject"></param>
        ''' <param name="GetDataBehaviour"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Function GetData(ByRef FileObject As IfxFileObject, ByVal GetDataBehaviour As GetDataOptions) As Boolean
            Return GetData(FileObject, String.Empty, String.Empty, String.Empty, GetDataBehaviour,
m_intRecordsToFillInFindOrDetailFind)
        End Function

        ''' --- GetData ------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' 	Summary of GetData.
        ''' </summary>
        ''' <param name="FileObject"></param>
        ''' <param name="WhereClause"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Function GetData(ByRef FileObject As IfxFileObject, ByVal WhereClause As String) As Boolean
            Return GetData(FileObject, WhereClause, String.Empty, String.Empty, GetDataOptions.None,
m_intRecordsToFillInFindOrDetailFind)
        End Function

        ''' --- GetData ------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' 	Summary of GetData.
        ''' </summary>
        ''' <param name="FileObject"></param>
        ''' <param name="WhereClause"></param>
        ''' <param name="OrderByClause"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Function GetData(ByRef FileObject As IfxFileObject, _
            ByVal WhereClause As String, _
            ByVal OrderByClause As String) As Boolean
            Return GetData(FileObject, WhereClause, OrderByClause, String.Empty, GetDataOptions.None,
m_intRecordsToFillInFindOrDetailFind)
        End Function

        ''' --- GetData ------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' 	Summary of GetData.
        ''' </summary>
        ''' <param name="FileObject"></param>
        ''' <param name="WhereClause"></param>
        ''' <param name="GetDataBehaviour"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Function GetData(ByRef FileObject As IfxFileObject, _
            ByVal WhereClause As String, _
            ByVal GetDataBehaviour As GetDataOptions) As Boolean
            'Return FileObject.GetData(WhereClause, GetDataBehaviour)
            Return GetData(FileObject, WhereClause, String.Empty, String.Empty, GetDataBehaviour,
m_intRecordsToFillInFindOrDetailFind)
        End Function

        ''' --- GetData ------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' 	Summary of GetData.
        ''' </summary>
        ''' <param name="FileObject"></param>
        ''' <param name="WhereClause"></param>
        ''' <param name="OrderByClause"></param>
        ''' <param name="GetDataBehaviour"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Function GetData(ByRef FileObject As IfxFileObject, _
            ByVal WhereClause As String, _
            ByVal OrderByClause As String, _
            ByVal GetDataBehaviour As GetDataOptions) As Boolean
            'Return FileObject.GetData(WhereClause, OrderByClause, GetDataBehaviour)
            Return GetData(FileObject, WhereClause, OrderByClause, String.Empty, GetDataBehaviour,
m_intRecordsToFillInFindOrDetailFind)
        End Function

        ''' --- GetData ------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' 	Summary of GetData.
        ''' </summary>
        ''' <param name="FileObject"></param>
        ''' <param name="IsOverrided"></param>
        ''' <param name="OverrideSQL"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Function GetData(ByRef FileObject As IfxFileObject, _
            ByVal IsOverrided As Boolean, _
            ByVal OverrideSQL As String) As Boolean
            'Return FileObject.GetData(IsOverrided, OverrideSQL)
            Return GetData(FileObject, String.Empty, String.Empty, OverrideSQL, GetDataOptions.None,
m_intRecordsToFillInFindOrDetailFind)
        End Function

        ''' --- GetData ------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' 	Retrieve data from the database.
        ''' </summary>
        ''' <param name="FileObject"></param>
        ''' <param name="IsOverrided"></param>
        ''' <param name="OverrideSQL"></param>
        ''' <param name="GetDataBehaviour"></param>
        ''' <remarks>Use this method if you ever need to pass a complete SQL statement with GetDataBehaviour.
        ''' <para>
        '''     <list type="numbered">
        '''         <item>Don't use this construct to generate Overrided SQL Statement internally.
        '''             i.e. Use this method if you ever need to pass GetDataBehaviour
        '''             other than GetDataBehaviour.CreateSubSelect.</item>
        '''         <item>To pass GetDataBehaviour.CreateSubSelect use another method, if you need
        '''             to pass Where Clause and Order By clause along with Auto Overrided SQL
        '''             e.g. GetData(WhereClause, OrderByClause,  GetDataOptions.CreateSubSelect)
        '''             <para>
        '''                 If you pass OverrideSQL along with GetDataBehaviour =  GetDataOptions.CreateSubSelect
        '''                 this method will use passed OverrideSQL, completely ignoring the  GetDataOptions.CreateSubSelect
        '''             </para></item>
        '''         <item>The first parameter "IsOverrided" is added to add overloaded method Passing it as false has NO impact,
        '''             i.e. whether you pass True or False this function will treat it as True.</item>
        '''     </list>
        ''' </para>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Function GetData(ByRef FileObject As IfxFileObject, _
            ByVal IsOverrided As Boolean, _
            ByVal OverrideSQL As String, _
            ByVal GetDataBehaviour As GetDataOptions) As Boolean

            Return GetData(FileObject, String.Empty, String.Empty, OverrideSQL, GetDataBehaviour,
m_intRecordsToFillInFindOrDetailFind)
        End Function

        ''' --- GetData ------------------------------------------------------------
        ''' <exclude/>
        '''
        ''' <summary>
        ''' 	Summary of GetData.
        ''' </summary>
        ''' <param name="FileObject"></param>
        ''' <param name="WhereClause"></param>
        ''' <param name="OrderByClause"></param>
        ''' <param name="OverrideSQL"></param>
        ''' <param name="GetDataBehaviour"></param>
        ''' <param name="RecordsToFill"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Overridable Function GetData(ByRef FileObject As IfxFileObject, _
                    ByVal WhereClause As String, _
                    ByVal OrderByClause As String, _
                    ByVal OverrideSQL As String, _
                    ByVal GetDataBehaviour As GetDataOptions, _
                    ByRef RecordsToFill As Integer) As Boolean

            Dim blnReturnValue As Boolean
            blnReturnValue = FileObject.GetData(WhereClause, OrderByClause, OverrideSQL, GetDataBehaviour, RecordsToFill
)
            Return blnReturnValue
        End Function

#Else

        ''' --- GetData ------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of GetData.
        ''' </summary>
        ''' <param name="FileObject"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetData(ByRef FileObject As OracleFileObject) As Boolean
            Return _
                GetData(FileObject, String.Empty, String.Empty, String.Empty, GetDataOptions.None,
                        m_intRecordsToFillInFindOrDetailFind)
        End Function

        ''' --- GetData ------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of GetData.
        ''' </summary>
        ''' <param name="FileObject"></param>
        ''' <param name="GetDataBehaviour"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetData(ByRef FileObject As OracleFileObject, GetDataBehaviour As GetDataOptions) As Boolean
            Return _
                GetData(FileObject, String.Empty, String.Empty, String.Empty, GetDataBehaviour,
                        m_intRecordsToFillInFindOrDetailFind)
        End Function

        ''' --- GetData ------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of GetData.
        ''' </summary>
        ''' <param name="FileObject"></param>
        ''' <param name="WhereClause"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetData(ByRef FileObject As OracleFileObject, WhereClause As String) As Boolean
            Return _
                GetData(FileObject, WhereClause, String.Empty, String.Empty, GetDataOptions.None,
                        m_intRecordsToFillInFindOrDetailFind)
        End Function

        ''' --- GetData ------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of GetData.
        ''' </summary>
        ''' <param name="FileObject"></param>
        ''' <param name="WhereClause"></param>
        ''' <param name="OrderByClause"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetData(ByRef FileObject As OracleFileObject,
                                WhereClause As String,
                                OrderByClause As String) As Boolean
            'Return FileObject.GetData(WhereClause, OrderByClause)
            Return _
                GetData(FileObject, WhereClause, OrderByClause, String.Empty, GetDataOptions.None,
                        m_intRecordsToFillInFindOrDetailFind)
        End Function

        ''' --- GetData ------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of GetData.
        ''' </summary>
        ''' <param name="FileObject"></param>
        ''' <param name="WhereClause"></param>
        ''' <param name="GetDataBehaviour"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetData(ByRef FileObject As OracleFileObject,
                                WhereClause As String,
                                GetDataBehaviour As GetDataOptions) As Boolean
            'Return FileObject.GetData(WhereClause, GetDataBehaviour)
            Return _
                GetData(FileObject, WhereClause, String.Empty, String.Empty, GetDataBehaviour,
                        m_intRecordsToFillInFindOrDetailFind)
        End Function

        ''' --- GetData ------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of GetData.
        ''' </summary>
        ''' <param name="FileObject"></param>
        ''' <param name="WhereClause"></param>
        ''' <param name="OrderByClause"></param>
        ''' <param name="GetDataBehaviour"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetData(ByRef FileObject As OracleFileObject,
                                WhereClause As String,
                                OrderByClause As String,
                                GetDataBehaviour As GetDataOptions) As Boolean
            'Return FileObject.GetData(WhereClause, OrderByClause, GetDataBehaviour)
            Return _
                GetData(FileObject, WhereClause, OrderByClause, String.Empty, GetDataBehaviour,
                        m_intRecordsToFillInFindOrDetailFind)
        End Function

        ''' --- GetData ------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of GetData.
        ''' </summary>
        ''' <param name="FileObject"></param>
        ''' <param name="IsOverrided"></param>
        ''' <param name="OverrideSQL"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetData(ByRef FileObject As OracleFileObject,
                                IsOverrided As Boolean,
                                OverrideSQL As String) As Boolean
            'Return FileObject.GetData(IsOverrided, OverrideSQL)
            Return _
                GetData(FileObject, String.Empty, String.Empty, OverrideSQL, GetDataOptions.None,
                        m_intRecordsToFillInFindOrDetailFind)
        End Function

        ''' --- GetData ------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Retrieve data from the database.
        ''' </summary>
        ''' <param name="FileObject"></param>
        ''' <param name="IsOverrided"></param>
        ''' <param name="OverrideSQL"></param>
        ''' <param name="GetDataBehaviour"></param>
        ''' <remarks>
        '''     Use this method if you ever need to pass a complete SQL statement with GetDataBehaviour.
        '''     <para>
        '''         <list type="numbered">
        '''             <item>
        '''                 Don't use this construct to generate Overrided SQL Statement internally.
        '''                 i.e. Use this method if you ever need to pass GetDataBehaviour
        '''                 other than GetDataBehaviour.CreateSubSelect.
        '''             </item>
        '''             <item>
        '''                 To pass GetDataBehaviour.CreateSubSelect use another method, if you need
        '''                 to pass Where Clause and Order By clause along with Auto Overrided SQL
        '''                 e.g. GetData(WhereClause, OrderByClause,  GetDataOptions.CreateSubSelect)
        '''                 <para>
        '''                     If you pass OverrideSQL along with GetDataBehaviour =  GetDataOptions.CreateSubSelect
        '''                     this method will use passed OverrideSQL, completely ignoring the  GetDataOptions.CreateSubSelect
        '''                 </para>
        '''             </item>
        '''             <item>
        '''                 The first parameter "IsOverrided" is added to add overloaded method Passing it as false has NO impact,
        '''                 i.e. whether you pass True or False this function will treat it as True.
        '''             </item>
        '''         </list>
        '''     </para>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetData(ByRef FileObject As OracleFileObject,
                                IsOverrided As Boolean,
                                OverrideSQL As String,
                                GetDataBehaviour As GetDataOptions) As Boolean

            Return _
                GetData(FileObject, String.Empty, String.Empty, OverrideSQL, GetDataBehaviour,
                        m_intRecordsToFillInFindOrDetailFind)
        End Function

        ''' --- GetData ------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of GetData.
        ''' </summary>
        ''' <param name="FileObject"></param>
        ''' <param name="WhereClause"></param>
        ''' <param name="OrderByClause"></param>
        ''' <param name="OverrideSQL"></param>
        ''' <param name="GetDataBehaviour"></param>
        ''' <param name="RecordsToFill"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Overridable Function GetData(ByRef FileObject As OracleFileObject,
                                            WhereClause As String,
                                            OrderByClause As String,
                                            OverrideSQL As String,
                                            GetDataBehaviour As GetDataOptions,
                                            ByRef RecordsToFill As Integer) As Boolean

            Dim blnReturnValue As Boolean
            blnReturnValue = FileObject.GetData(WhereClause, OrderByClause, OverrideSQL, GetDataBehaviour, RecordsToFill)

            Return blnReturnValue
        End Function

        ''' --- GetData ------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of GetData.
        ''' </summary>
        ''' <param name="FileObject"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetData(ByRef FileObject As SqlFileObject) As Boolean
            Return _
                GetData(FileObject, String.Empty, String.Empty, String.Empty, GetDataOptions.None,
                        m_intRecordsToFillInFindOrDetailFind)
        End Function

        ''' --- GetData ------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of GetData.
        ''' </summary>
        ''' <param name="FileObject"></param>
        ''' <param name="GetDataBehaviour"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetData(ByRef FileObject As SqlFileObject, GetDataBehaviour As GetDataOptions) As Boolean
            Return _
                GetData(FileObject, String.Empty, String.Empty, String.Empty, GetDataBehaviour,
                        m_intRecordsToFillInFindOrDetailFind)
        End Function

        ''' --- GetData ------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of GetData.
        ''' </summary>
        ''' <param name="FileObject"></param>
        ''' <param name="WhereClause"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetData(ByRef FileObject As SqlFileObject, WhereClause As String) As Boolean
            Return _
                GetData(FileObject, WhereClause, String.Empty, String.Empty, GetDataOptions.None,
                        m_intRecordsToFillInFindOrDetailFind)
        End Function

        ''' --- GetData ------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of GetData.
        ''' </summary>
        ''' <param name="FileObject"></param>
        ''' <param name="WhereClause"></param>
        ''' <param name="OrderByClause"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetData(ByRef FileObject As SqlFileObject,
                                WhereClause As String,
                                OrderByClause As String) As Boolean
            'Return FileObject.GetData(WhereClause, OrderByClause)
            Return _
                GetData(FileObject, WhereClause, OrderByClause, String.Empty, GetDataOptions.None,
                        m_intRecordsToFillInFindOrDetailFind)
        End Function

        ''' --- GetData ------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of GetData.
        ''' </summary>
        ''' <param name="FileObject"></param>
        ''' <param name="WhereClause"></param>
        ''' <param name="GetDataBehaviour"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetData(ByRef FileObject As SqlFileObject,
                                WhereClause As String,
                                GetDataBehaviour As GetDataOptions) As Boolean
            'Return FileObject.GetData(WhereClause, GetDataBehaviour)
            Return _
                GetData(FileObject, WhereClause, String.Empty, String.Empty, GetDataBehaviour,
                        m_intRecordsToFillInFindOrDetailFind)
        End Function

        ''' --- GetData ------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of GetData.
        ''' </summary>
        ''' <param name="FileObject"></param>
        ''' <param name="WhereClause"></param>
        ''' <param name="OrderByClause"></param>
        ''' <param name="GetDataBehaviour"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetData(ByRef FileObject As SqlFileObject,
                                WhereClause As String,
                                OrderByClause As String,
                                GetDataBehaviour As GetDataOptions) As Boolean
            'Return FileObject.GetData(WhereClause, OrderByClause, GetDataBehaviour)
            Return _
                GetData(FileObject, WhereClause, OrderByClause, String.Empty, GetDataBehaviour,
                        m_intRecordsToFillInFindOrDetailFind)
        End Function

        ''' --- GetData ------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of GetData.
        ''' </summary>
        ''' <param name="FileObject"></param>
        ''' <param name="IsOverrided"></param>
        ''' <param name="OverrideSQL"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetData(ByRef FileObject As SqlFileObject,
                                IsOverrided As Boolean,
                                OverrideSQL As String) As Boolean
            'Return FileObject.GetData(IsOverrided, OverrideSQL)
            Return _
                GetData(FileObject, String.Empty, String.Empty, OverrideSQL, GetDataOptions.None,
                        m_intRecordsToFillInFindOrDetailFind)
        End Function

        ''' --- GetData ------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Retrieve data from the database.
        ''' </summary>
        ''' <param name="FileObject"></param>
        ''' <param name="IsOverrided"></param>
        ''' <param name="OverrideSQL"></param>
        ''' <param name="GetDataBehaviour"></param>
        ''' <remarks>
        '''     Use this method if you ever need to pass a complete SQL statement with GetDataBehaviour.
        '''     <para>
        '''         <list type="numbered">
        '''             <item>
        '''                 Don't use this construct to generate Overrided SQL Statement internally.
        '''                 i.e. Use this method if you ever need to pass GetDataBehaviour
        '''                 other than GetDataBehaviour.CreateSubSelect.
        '''             </item>
        '''             <item>
        '''                 To pass GetDataBehaviour.CreateSubSelect use another method, if you need
        '''                 to pass Where Clause and Order By clause along with Auto Overrided SQL
        '''                 e.g. GetData(WhereClause, OrderByClause,  GetDataOptions.CreateSubSelect)
        '''                 <para>
        '''                     If you pass OverrideSQL along with GetDataBehaviour =  GetDataOptions.CreateSubSelect
        '''                     this method will use passed OverrideSQL, completely ignoring the  GetDataOptions.CreateSubSelect
        '''                 </para>
        '''             </item>
        '''             <item>
        '''                 The first parameter "IsOverrided" is added to add overloaded method Passing it as false has NO impact,
        '''                 i.e. whether you pass True or False this function will treat it as True.
        '''             </item>
        '''         </list>
        '''     </para>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Function GetData(ByRef FileObject As SqlFileObject,
                                IsOverrided As Boolean,
                                OverrideSQL As String,
                                GetDataBehaviour As GetDataOptions) As Boolean

            Return _
                GetData(FileObject, String.Empty, String.Empty, OverrideSQL, GetDataBehaviour,
                        m_intRecordsToFillInFindOrDetailFind)
        End Function

        ''' --- GetData ------------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of GetData.
        ''' </summary>
        ''' <param name="FileObject"></param>
        ''' <param name="WhereClause"></param>
        ''' <param name="OrderByClause"></param>
        ''' <param name="OverrideSQL"></param>
        ''' <param name="GetDataBehaviour"></param>
        ''' <param name="RecordsToFill"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Overridable Function GetData(ByRef FileObject As SqlFileObject,
                                            WhereClause As String,
                                            OrderByClause As String,
                                            OverrideSQL As String,
                                            GetDataBehaviour As GetDataOptions,
                                            ByRef RecordsToFill As Integer) As Boolean

            Dim blnReturnValue As Boolean
            Dim strFileName As String

            m_intGetSequence += 1

            ' Get the file name (either Alias name or Base name).
            If FileObject.AliasName.TrimEnd.Length > 0 Then
                strFileName = FileObject.AliasName
            Else
                strFileName = FileObject.BaseName
            End If

            strFileName &= m_intGetSequence.ToString

            Dim blnMethodWasExecuted As Boolean


            blnMethodWasExecuted = MethodWasExecuted(m_strGetFlag, m_intGetSequence, "GET_FLAG")


            If Not blnMethodWasExecuted Then

                blnReturnValue = FileObject.GetData(WhereClause, OrderByClause, OverrideSQL, GetDataBehaviour,
                                                    RecordsToFill)

                Me.InternalPageState(
                    FileObject.AliasName + FileObject.BaseName + "_GetData_" & m_intGetSequence.ToString) =
                    FileObject.GetInternalValues()
                Me.InternalPageState(FileObject.AliasName + FileObject.BaseName + "_GetData") =
                    FileObject.GetInternalValues()

                ' Save the sequence information and set a flag indicating ACCEPT was run.

                SetMethodExecutedFlag(m_strGetFlag, "GET_FLAG", m_intGetSequence)


            Else

                FileObject.SetInternalValues(
                    CType(
                        Me.InternalPageState(
                            FileObject.AliasName + FileObject.BaseName + "_GetData_" & m_intGetSequence.ToString),
                        Hashtable))

                Me.Session(UniqueSessionID + "AccessOk") = FileObject.Exists

                blnReturnValue = True
            End If

            Return blnReturnValue
        End Function

#End If

        ''' --- GetWhereCondition --------------------------------------------------
        ''' <summary>
        '''     Generates a string value containing a SQL WHERE clause.
        ''' </summary>
        ''' <param name="FieldName">The name of the field in the SQL statement.</param>
        ''' <param name="Value">The value to assign to the field.</param>
        ''' <param name="blnAddWhere">
        '''     Indicates that this is the first field in the WHERE clause and the keyword WHERE is to be
        '''     appended.
        ''' </param>
        ''' <remarks>
        '''     Returns a formatted SQL Where Condition by concatenating the parameters FieldName and Value.
        '''     This function will return nothing if the passed Value is a null date (01/01/0001).
        '''     or space.
        ''' </remarks>
        ''' <example>
        ''' </example>
        ''' <note>
        '''     This function should only be used in the Find procedure.
        ''' </note>
        ''' <history>
        '''     [Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function GetWhereCondition(FieldName As String, Value As DateTime,
                                          Optional ByRef blnAddWhere As Boolean = False) As String

            Dim strReturnValue As StringBuilder = New StringBuilder("")

            Try
                Dim d As OldCoreDate = New OldCoreDate(Value)

                If Value <> cNullDate Then
                    If ConfigurationManager.AppSettings("AuthenticationDatabase").ToString.Equals(cORACLE) Then
                        If blnAddWhere = True Then
                            strReturnValue.Append(" WHERE ")
                            strReturnValue.Append(" CorePackage.CORE_TONUM(")
                            strReturnValue.Append(FieldName)
                            strReturnValue.Append(" )")
                            blnAddWhere = False
                        Else
                            strReturnValue.Append(" AND ")
                            strReturnValue.Append(" CorePackage.CORE_TONUM(")
                            strReturnValue.Append(FieldName)
                            strReturnValue.Append(" )")
                        End If
                    Else
                        If blnAddWhere = True Then
                            strReturnValue.Append(" WHERE ")
                            strReturnValue.Append(" dbo.CORE_TONUM(")
                            strReturnValue.Append(FieldName)
                            strReturnValue.Append(" )")
                            blnAddWhere = False
                        Else
                            strReturnValue.Append(" AND ")
                            strReturnValue.Append(" dbo.CORE_TONUM(")
                            strReturnValue.Append(FieldName)
                            strReturnValue.Append(" )")
                        End If
                    End If

                    strReturnValue.Append(" = ")
                    strReturnValue.Append(d.Value)
                End If

                Return strReturnValue.ToString

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try
        End Function

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function GetWhereCondition(FieldName As String, Value As Object, ByRef blnAddWhere As Boolean,
                                          IsBlankLiteral As Boolean) As String
            Return GetWhereCondition(FieldName, Value.ToString, blnAddWhere, IsBlankLiteral, False)
        End Function

        '<EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        'Public Function GetWhereCondition(ByVal FieldName As String, ByVal Value As Object, ByRef blnAddWhere As Boolean) As String
        '    Return GetWhereCondition(FieldName, Value.ToString, blnAddWhere, False, False)
        'End Function

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function GetWhereCondition(FieldName As String, Value As String, ByRef blnAddWhere As Boolean) As String
            Return GetWhereCondition(FieldName, Value.ToString, blnAddWhere, False, False)
        End Function

        '<EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)> _
        'Public Function GetWhereCondition(ByVal FieldName As String, ByVal Value As Object, ByRef blnAddWhere As Boolean, ByVal IsBlankLiteral As Boolean, ByVal IsGeneric As Boolean) As String
        '    Return GetWhereCondition(FieldName, Value.ToString, blnAddWhere, IsBlankLiteral, IsGeneric)
        'End Function

        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Function GetWhereCondition(FieldName As String, Value As String, ByRef blnAddWhere As Boolean,
                                          IsBlankLiteral As Boolean) As String
            Return GetWhereCondition(FieldName, Value.ToString, blnAddWhere, IsBlankLiteral, False)
        End Function

        ''' --- GetWhereCondition --------------------------------------------------
        ''' <summary>
        '''     Generates a string value containing a SQL WHERE clause.
        ''' </summary>
        ''' <param name="FieldName">The name of the field in the SQL statement.</param>
        ''' <param name="Value">The value to assign to the field.</param>
        ''' <param name="blnAddWhere">
        '''     Indicates that this is the first field in the WHERE clause and the keyword WHERE is to be
        '''     appended.  This is passed in using a variable.
        ''' </param>
        ''' <param name="IsBlankLiteral">Set this to True if we are passing a blank value (constant).</param>
        ''' <remarks>
        '''     Returns a formatted SQL Where Condition by concatenating the parameters FieldName and Value and substituting the
        '''     wildcard character (@) and creating a LIKE clause.  This function will return nothing if the passed Value is blank
        '''     unless IsBlankLiteral is set to true.
        '''     or space.
        ''' </remarks>
        ''' <example>
        '''     1. GetWhereCondition("RegionCode", "AABB", blnAddWhere) will return
        '''     " WHERE RegionCode = 'AABB'" <br />
        '''     2. GetWhereCondition("RegionCode", "AABB") will return
        '''     " AND RegionCode = 'AABB'" <br />
        '''     3. GetWhereCondition("RegionCode", "@") will return
        '''     " AND RegionCode LIKE '%'" <br />
        '''     4. GetWhereCondition("RegionCode", "%", blnAddWhere) will return
        '''     " WHERE RegionCode LIKE '%'" <br />
        '''     5. GetWhereCondition("RegionCode", " ", blnAddWhere, True) will return
        '''     " WHERE RegionCode = ' ' Or RegionCode IS NULL"
        ''' </example>
        ''' <note>
        '''     This function should only be used in the Find procedure.
        ''' </note>
        ''' <history>
        '''     [Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Private Function GetWhereCondition(FieldName As String, Value As String, ByRef blnAddWhere As Boolean,
                                           IsBlankLiteral As Boolean, IsGeneric As Boolean) As String

            Dim strReturnValue As StringBuilder = New StringBuilder("")

            Try

                If Value.Trim.Length > 0 Then
                    If blnAddWhere = True Then
                        strReturnValue.Append(" WHERE ")
                        strReturnValue.Append(FieldName)
                        blnAddWhere = False
                    Else
                        strReturnValue.Append(" AND ")
                        strReturnValue.Append(FieldName)
                    End If

                    If IsNothing(m_strGenericRetrievalCharacter) OrElse m_strGenericRetrievalCharacter.Length = 0 Then
                        m_strGenericRetrievalCharacter = "@"
                    End If

                    If IsGeneric AndAlso Value.EndsWith(m_strGenericRetrievalCharacter + m_strGenericRetrievalCharacter) _
                        Then
                        'e.g. If the user enters M@@, all data records will be retrieved where the index begins with letter M to the highest value (that is the last segment value).
                        Value = Value.Replace(m_strGenericRetrievalCharacter, String.Empty)
                        If Value.Equals(String.Empty) Then
                            'In case user type one or more "@" (or character set as GenericRetrievalCharacter)
                            strReturnValue.Append(" LIKE '%'")
                        Else
                            strReturnValue.Append(" >= ")
                            strReturnValue.Append(StringToField(Value.Trim))
                        End If
                    ElseIf Value.IndexOf(m_strGenericRetrievalCharacter) >= 0 Then
                        Value = Replace(Value, m_strGenericRetrievalCharacter, "%")
                        strReturnValue.Append(" Like ")
                        strReturnValue.Append(StringToField(Value.Trim))
                    Else
                        strReturnValue.Append(" = ")
                        strReturnValue.Append(StringToField(Value))
                    End If
                Else
                    '---------------
                    'Changed to " " as literal string while calling "GetWhereCondition" from "Find" procedure
                    'where as in similar case when called from "SelectProcessing", whole condition will be ignored
                    'September 12, 2005 11:23
                    '---------------
                    If blnAddWhere = True Then
                        strReturnValue.Append(" WHERE (")
                        strReturnValue.Append(FieldName)
                        blnAddWhere = False
                    Else
                        strReturnValue.Append(" AND (")
                        strReturnValue.Append(FieldName)
                    End If
                    strReturnValue.Append(" = ")
                    strReturnValue.Append(StringToField(Value))
                    strReturnValue.Append(" OR ")
                    strReturnValue.Append(FieldName)
                    strReturnValue.Append(" IS NULL)")
                End If

                Return strReturnValue.ToString

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try
        End Function

#If TARGET_DB = "INFORMIX" Then

        <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
        Public Overridable Function WhileRetrieving(ByRef FileObject As IfxFileObject, Optional ByVal WhereClause As _
String = "", Optional ByVal OrderByClause As String = "", Optional ByVal Sequential As Boolean = False, Optional ByVal _
Backward As Boolean = False, Optional ByVal IsOptional As Boolean = False) As Boolean

            Dim blnReturnValue As Boolean
            blnReturnValue = FileObject.WhileRetrieving(WhereClause, OrderByClause, Sequential, Backward, IsOptional)

            Return blnReturnValue
        End Function

#Else

        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Overridable Function WhileRetrieving(ByRef FileObject As SqlFileObject,
                                                    Optional ByVal WhereClause As String = "",
                                                    Optional ByVal OrderByClause As String = "",
                                                    Optional ByVal Sequential As Boolean = False,
                                                    Optional ByVal Backward As Boolean = False,
                                                    Optional ByVal IsOptional As Boolean = False) As Boolean

            Dim blnReturnValue As Boolean
            blnReturnValue = FileObject.WhileRetrieving(WhereClause, OrderByClause, Sequential, Backward, IsOptional)

            Return blnReturnValue
        End Function

#End If

        ''' --- OldValue -----------------------------------------------------------
        ''' <summary>
        '''     Returns the value of the underlying record buffer during editing.
        ''' </summary>
        ''' <param name="Name">A String containing the name of field.</param>
        ''' <param name="Value">A String containing the current value of field.</param>
        ''' <remarks>
        '''     The OldValue function returns the current item in the underlying record buffer.  If the value passed in
        '''     as value is not found, then this value is returned in case OldValue is used on a field that is not currently
        '''     executing the Edit procedure.
        '''     <note>
        '''         OldValue can should only be used during the Edit procedure to return the value in
        '''         the associated record buffer.  FieldText or FieldValue are used to handle the new value
        '''         associated to this field.
        '''     </note>
        ''' </remarks>
        ''' <example>T_TEMP.Value = OldValue("SURNAME", "Smith")</example>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Function OldValue(Name As String, Value As String) As String

            ' If the OldValue we are retrieving is the same as
            ' the current item on which the validate is executing,
            ' then return the value from the array, otherwise return
            ' the value passed in.

            If IsUsingSqlServer() Then
                Name = Name.Substring(Name.IndexOf("dbo.") + 4)
            End If

            If m_OldValue.Field = Name Then
                Return m_OldValue.FieldText
            Else
                Return Value
            End If
        End Function

        ''' --- OldValue -----------------------------------------------------------
        ''' <summary>
        '''     Returns the value of the underlying record buffer during editing.
        ''' </summary>
        ''' <param name="Name">A String containing the name of field.</param>
        ''' <param name="Value">A String containing the current value of field.</param>
        ''' <remarks>
        '''     The OldValue function returns the current item in the underlying record buffer.  If the value passed in
        '''     as value is not found, then this value is returned in case OldValue is used on a field that is not currently
        '''     executing the Edit procedure.
        '''     <note>
        '''         OldValue can should only be used during the Edit procedure to return the value in
        '''         the associated record buffer.  FieldText or FieldValue are used to handle the new value
        '''         associated to this field.
        '''     </note>
        ''' </remarks>
        ''' <example>T_TEMP.Value = OldValue("YEAR", 1961)</example>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Function OldValue(Name As String, Value As Decimal) As Decimal

            ' If the OldValue we are retrieving is the same as
            ' the current item on which the validate is executing,
            ' then return the value from the array, otherwise return
            ' the value passed in.

            If IsUsingSqlServer() Then
                Name = Name.Substring(Name.IndexOf("dbo.") + 4)
            End If

            If m_OldValue.Field = Name Then
                Return m_OldValue.FieldValue
            Else
                Return Value
            End If
        End Function

        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Function OldValue(Name As String, Value As Object) As Decimal

            ' If the OldValue we are retrieving is the same as
            ' the current item on which the validate is executing,
            ' then return the value from the array, otherwise return
            ' the value passed in.

            If IsUsingSqlServer() Then
                Name = Name.Substring(Name.IndexOf("dbo.") + 4)
            End If

            If m_OldValue.Field = Name Then
                Return m_OldValue.FieldValue
            Else
                Return Value
            End If
        End Function

        ''' --- OldValue -----------------------------------------------------------
        ''' <summary>
        '''     Returns the value of the underlying record buffer during editing.
        ''' </summary>
        ''' <param name="Name">A String containing the name of field.</param>
        ''' <param name="Value">A String containing the current value of field.</param>
        ''' <remarks>
        '''     The OldValue function returns the current item in the underlying record buffer.  If the value passed in
        '''     as value is not found, then this value is returned in case OldValue is used on a field that is not currently
        '''     executing the Edit procedure.
        '''     <note>
        '''         OldValue can should only be used during the Edit procedure to return the value in
        '''         the associated record buffer.  FieldText or FieldValue are used to handle the new value
        '''         associated to this field.  <br />
        '''     </note>
        ''' </remarks>
        ''' <example>T_TEMP.Value = OldValue("EMP_DATE", SysDateTime)</example>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)>
        Protected Function OldValue(Name As String, Value As DateTime) As DateTime

            ' If the OldValue we are retrieving is the same as
            ' the current item on which the validate is executing,
            ' then return the value from the array, otherwise return
            ' the value passed in.

            If IsUsingSqlServer() Then
                Name = Name.Substring(Name.IndexOf("dbo.") + 4)
            End If

            If m_OldValue.Field = Name Then
                Return CDate(m_OldValue.FieldText)
            Else
                Return Value
            End If
        End Function

        ''' --- IsUsingSqlServer ------------------------------------------------------
        ''' <exclude />
        ''' <summary>
        '''     Summary of IsUsingSqlServer.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        '''     [Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function IsUsingSqlServer() As TriState
            If m_blnIsUsingSqlServer = TriState.UseDefault Then
                If ConfigurationManager.AppSettings("AuthenticationDatabase") Is Nothing OrElse
                   ConfigurationManager.AppSettings("AuthenticationDatabase").ToString.Equals(cSQL_SERVER) Then
                    m_blnIsUsingSqlServer = TriState.True
                Else
                    m_blnIsUsingSqlServer = TriState.False
                End If
            End If
            Return (m_blnIsUsingSqlServer = TriState.True)
        End Function

#End Region

#End Region
    End Class
End Namespace
