Imports System.ComponentModel

Namespace Core.Framework

    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Enum PaginationClick As Byte
        NotSet = 0
        First = 1
        Previous = 2
        [Next] = 4
        Last = 8
        [GoTo] = 16

    End Enum
    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Enum OnError As Byte
        Report = 0
    End Enum
    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Enum FilePosition As Byte
        NotSet = 0
        First = 1
        Last = 2
    End Enum
    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Enum SortType As Byte
        Descending = 0
        Ascending = 1
        Numeric = 2
        NumericDescending = 4
    End Enum

    ''' --- ScreenTypes --------------------------------------------------------
    '''
    ''' <summary>
    ''' Specifies the types of screens.
    ''' </summary>
    ''' <remarks>
    ''' <para>
    '''     <list type="bullet">
    '''         <item>NonGrid -  This screen has no repeating data</item>
    '''         <item>Grid - This screen contains repeating data</item>
    '''         <item>Composite -  This screen contains repeating and non-repeating data (ie. Primary-Detail screen)</item>
    '''         <item>Ghost - This screen has no interface and runs as a process</item>
    '''     </list>
    ''' </para>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Enum ScreenTypes As Byte
        NonGrid = 0
        Grid = 1
        Composite = 2
        Ghost = 4
        QTP = 8
        Service = 16
        QUIZ = 32
    End Enum

    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Enum JobScriptType As Byte
        Keep = 0
        SetSystemval = 1
        QTP = 2
        QUIZ = 4
        Job = 8
        Screen = 16
    End Enum

    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Enum ItemType As Byte
        Positive = 0
        Negative = 1
    End Enum

    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Enum SubFileType As Byte
        Keep = 0
        Temp = 1
        KeepText = 2
        TempText = 4
        Pass = 8
        KeepTable = 16  ' Subfile to be written to a permanent table.
        Portable = 32
        KeepSQL = 64
    End Enum

    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Enum SubFileMode As Byte
        None = 0
        Append = 1
        Overwrite = 2
    End Enum

    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Enum FileType As Byte
        DataFile = 0
        TempFile = 1
        SubFile = 2
        TextFile = 4
        SubFileTable = 8
        PortableSubFile = 16
        SequentialDataBase = 32
    End Enum


    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Enum OutPutType As Byte
        Update = 0
        Add = 1
        Delete = 2
        Add_Update = 4
    End Enum


    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Enum LogType As Byte
        Read = 0
        Added = 1
        Updated = 2
        Deleted = 4
        OutPut = 8
        UnChanged = 16
    End Enum

    'This Enum can be used to determine which action caused Web Request.
    ''' --- PageActionType -----------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of PageActionType.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Enum PageActionType As Byte
        NotSet = 0
        ToolbarClick = 1
        DesignerClick = 2
        PaginationClick = 3
        DataListButtonClick = 4
        InFieldValidation = 5
        NewRequest = 6
        SubScreenClick = 7
    End Enum

    ''' --- ReturnFieldType ----------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of ReturnFieldType.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Enum ReturnFieldType As Byte
        [String] = 0
        [Decimal] = 1
        [Date] = 2
        NumericDate = 3
    End Enum

    ''' --- StateMedium --------------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of StateMedium.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Enum StateMedium As Byte
        PageOnClient = 0
        SessionOnServer = 1
        DatabaseOnServer = 2
        DiskOnServer = 3
    End Enum

    ''' --- RecordBufferType ---------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of RecordBufferType.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Enum RecordBufferType As Byte
        [Get] = 0
        [Set] = 1
    End Enum

    ''' --- DesignerStatus -----------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of DesignerStatus.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Enum DesignerStatus As Byte
        NotClicked = 0
        Clicked = 1
        Cancelled = 2
    End Enum

    ''' --- DataListActionTypes ------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of DataListActionTypes.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Enum DataListActionTypes As Byte
        NotSet = 0
        Update = 1
        Add = 2        ' Add is used to Append a record in a grid if grid has space to Add a record i.e. records displayed in a Grid is less then the Occurs.
        Delete = 3
        GridNew = 4     ' GridNew although similar to Add it in the way that GridNew is used to Append a Record in a Grid if Grid-Full records are displayed on a Grid
        [Select] = 5   'Not Used ????
        Pagination = 6
    End Enum

    ''' --- DataListButtons ----------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of DataListButtons.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Enum DataListButtons As Byte
        NotSet = 0
        EditRecordButton = 1  ' Includes Add and Edit both
        DeleteRecordButton = 2
        NewRecordButton = 3   ' Although similar to Add, however it clears all grid rows and enables only first row as new record.
        SelectRecordButton = 4    'Checkbox
    End Enum

    ''' --- PaginationTypes ----------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of PaginationTypes.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Enum PaginationTypes As Byte
        [Default] = 0
        FirstNextOnly = 1
    End Enum

    ''' --- DataListRowButtonModeTypes -----------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of DataListRowButtonModeTypes.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Enum DataListRowButtonModeTypes As Byte
        Edit = 0
        Design = 1
    End Enum

    ''' --- BooleanTypes -------------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of BooleanTypes.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Enum BooleanTypes
        [True] = -1
        [False] = 1
        NotSet = 0
    End Enum

    ''' --- DataTypes ----------------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of DataTypes.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Enum DataTypes As Byte
        NotSet = 0
        Character = 1
        Numeric = 2
        [Date] = 3
    End Enum

    ''' --- ItemDataTypes ----------------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of DataTypes.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Enum ItemDataTypes As Byte
        NotSet = 0
        Character = 1
        Numeric = 2
        [Date] = 3
        [Integer] = 4
        SignedInteger = 5
        UnsignedNumeric = 6
    End Enum

    ''' --- ShiftTypes ---------------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of ShiftTypes.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Enum ShiftTypes As Byte
        NotSet = 0
        NoShift = 1
        UpShift = 2
        DownShift = 3
    End Enum

    ' Used for Windows apps.
    ''' --- WinLabelPositionTypes ----------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of WinLabelPositionTypes.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Enum WinLabelPositionTypes As Byte
        NotSet = 0
        Top = 1
        Left = 2
        Bottom = 3
        Right = 4
    End Enum

    ''' --- WinToolbarImageOptions ---------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of WinToolbarImageOptions.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Enum WinToolbarImageOptions As Byte
        Both = 0
        ImageOnly = 1
        LabelOnly = 2
    End Enum

    ' Used for WEB apps.
    ''' --- LabelPositionTypes -------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of LabelPositionTypes.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Enum LabelPositionTypes As Byte
        NotSet = 0
        TopLeft = 1
        LeftTop = 2
        LeftBottom = 3
    End Enum

    ''' --- BehaviorTypes ------------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of BehaviorTypes.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Enum BehaviorTypes As Byte
        NotSet = 0
        EntryFind = 1
        Entry = 2
        Find = 3
        Change = 4
        ChangeFind = 5
        ChangeEntry = 6
        ChangeEntryFind = 7
    End Enum

    Public Enum AlignText As Byte
        NotSet = 0
        Left = 1
        Right = 2
    End Enum

    ''' --- ValidateTypes ------------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of ValidateTypes.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Enum ValidateTypes As Byte
        Accept = 0
        Request = 1
        Edit = 2
        Display = 3
    End Enum

    ''' --- PageModeTypes ------------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Specifies the Mode types in which the designer is run for menu classes.
    ''' </summary>
    ''' <remarks>
    ''' <para>
    '''     <list type="bullet">
    '''         <item>NoMode -  No mode is specified</item>
    '''         <item>Find - Run through the Find phase</item>
    '''         <item>Entry -  This screen contains repeating and non-repeating data (ie. Primary-Detail screen)</item>
    '''         <item>Select - This screen has no interface and runs as a process</item>
    '''         <item>Correct - This screen has no interface and runs as a process</item>
    '''         <item>Change - This screen has no interface and runs as a process</item>
    '''         <item>Unknown - This screen has no interface and runs as a process</item>
    '''     </list>
    ''' </para>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Enum PageModeTypes
        NoMode = 0
        Find = 1
        Entry = 2
        [Select] = 3
        Correct = 4
        Change = 5
        Unknown = -1
    End Enum

    'If you add items to this enum, please update ConvertModeString() in DevStudio too.
    'This will make sure that menus are still extracted correctly from the repository.
    ''' --- RunScreenModes -----------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	Specifies the Mode for the subscreen.
    ''' </summary>
    ''' <remarks>
    ''' <para>
    '''     <list type="bullet">
    '''         <item>NoneSelected -  No mode was specified</item>
    '''         <item>Find - The subscreen is in Find mode when it first appears</item>
    '''         <item>Entry -  The subscreen is in Entry mode when it first appears</item>
    '''         <item>Select - Not supported.</item>
    '''         <item>Correct - The subscreen is in Correct mode when it first appears</item>
    '''         <item>Change - The subscreen is in Change mode when it first appears</item>
    '''         <item>Null - The subscreen is not in any mode when it first appears</item>
    '''         <item>Same - The subscreen is in the same mode as the current screen when it first appears</item>
    '''         <item>Ghost - This screen is being called as a ghost screen</item>
    '''     </list>
    ''' </para>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Enum RunScreenModes As Byte
        NoneSelected = 0
        Find = 1
        Entry = 2
        [Select] = 3
        Correct = 4 ' Added for Slave screens.
        Change = 5  ' Added for Slave screens.
        Null = 5
        Same = 6
        Ghost = 7
    End Enum

    ''' --- FileTypes ----------------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	Specifies the types of File classes.
    ''' </summary>
    ''' <remarks>
    ''' <para>
    '''     <list type="bullet">
    '''         <item>Audit - Used to record data changes in a record structure and is usually associated with another File class.</item>
    '''         <item>Delete - Allows data records to be deleted from a file.</item>
    '''         <item>Designer - A record structure that is totally under the control of the developer.</item>
    '''         <item>Primary - The main file access by the screen</item>
    '''         <item>Master - A Primary, Secondary or Detail file passed from a higher-level screen.</item>
    '''         <item>Detail - A repeating record structure with a variable number of data records in relation to a Master or Primary file.</item>
    '''         <item>Secondary - A record structure in a file that is also to be updated in relation to record-structures in Primary or Detail Files.</item>
    '''         <item>Reference - A read-only file used for validation or retrieval.</item>
    '''     </list>
    ''' </para>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Enum FileTypes As Byte
        Primary = 0
        Secondary = 1
        Detail = 2
        Reference = 3
        Master = 4
        Designer = 5
        Delete = 6
        Audit = 7
        Cursor = 8
    End Enum

    ''' --- DatabaseTypes ------------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of DatabaseTypes.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Enum DatabaseTypes As Byte
        Oracle = 0     'Use the OracleClient from Microsoft  
        SqlServer = 1  'Use the SqlClient from Microsoft
        ODP = 2        'Use "Oracle Data Provider" from Oracle
        Informix = 3
    End Enum

    ''' --- ExtractOption ------------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	Specifies the options for the DateExtract function.
    ''' </summary>
    ''' <remarks>
    ''' <para>
    '''     <list type="bullet">
    '''         <item>Year - Returns a four-digit year.</item>
    '''         <item>Month - Returns a number between 1 and 12.</item>
    '''         <item>Day - Returns a number between 1 and 31.</item>
    '''         <item>Hour - Returns a number between 0 and 23.</item>
    '''         <item>Minute - Returns a number between 0 and 59.</item>
    '''         <item>Second - Returns a number between 0 and 59.</item>
    '''         <item>OptionDate - Returns the date portion of the item as a number in the form YYYYMMDD.</item>
    '''         <item>Time - Returns the time portion of the item as a number in the form HHMMSSTTT (where TTT represents thousandths of seconds).</item>
    '''     </list>
    ''' </para>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Enum ExtractOption As Byte
        Year
        Month
        Day
        Hour
        Minute
        Second
        OptionDate
        Time
    End Enum

    ''' --- ResourceTypes ------------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	Specifies the type of resource files.
    ''' </summary>
    ''' <remarks>
    ''' <para>
    '''     <list type="bullet">
    '''         <item>Message - The resource file containing the error, warning, and informational messages.</item>
    '''         <item>Label - The resource file containing the screen labels.</item>
    '''         <item>Help - </item>
    '''         <item>Description - </item>
    '''     </list>
    ''' </para>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Enum ResourceTypes As Byte
        Message = 0
        Label = 1
        Help = 2
        Description = 3
    End Enum

    ''' --- WindowTypes --------------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	Specifies how the window is opened.
    ''' </summary>
    ''' <remarks>
    ''' <para>
    '''     <list type="bullet">
    '''         <item>Modal - A window which prevents the user from interacting with other windows in the application.</item>
    '''         <item>NonModal - A window that does not restrict the user's interaction with other opened windows.</item>
    '''     </list>
    ''' </para>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Enum WindowTypes As Byte
        Modal = 0
        NonModal = 1
    End Enum

    ''' --- ToolbarIcons -------------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of ToolbarIcons.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Enum ToolbarIcons
        NotSet = 0
        Menu = 1
        Find = 2
        Add = 3
        Submit = 4
        Cancel = 5
        Print = 6
        First = 7
        Previous = 8
        [Next] = 9
        Last = 10
        Delete = 11
        Help = 12
        Language = 13
        [Exit] = 14
        CustomToolbox = 15
        SubmitExit = 16
        Unknown = -1
    End Enum

    ''' --- NavigationTypes ----------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of NavigationTypes.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Enum NavigationTypes As Byte
        None = 0
        First = 1
        Previous = 2
        [Next] = 3
        Last = 4
        Find = 5
        Entry = 6
        Cancel = 7
        Delete = 8
        Submit = 9
    End Enum

    ''' --- TransactionMethods -------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	Specifies the type of method used on a transaction.
    ''' </summary>
    ''' <remarks>
    ''' <para>
    '''     <list type="bullet">
    '''         <item>Commit - Saves any changes made by the transaction to the database.</item>
    '''         <item>Rollback - Undoes cahanges made by the transaction and returns the data to its state prior to the transaction.</item>
    '''     </list>
    ''' </para>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Enum TransactionMethods As Byte
        Commit = 0
        Rollback = 1
    End Enum

    ''' --- MessageTypes -------------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of MessageTypes.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Enum MessageTypes As Byte
        [Error] = 0
        Warning = 1
        Information = 2
        Severe = 3
        Lookup = 4
        [Return] = 5
        ErrorAsInformation = 6   'Displays a message with an 'Error' icon, however doesn't stop processing
    End Enum

    ''' --- AppendStatus -------------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of AppendStatus.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Enum AppendStatus As Byte
        NotSet = 0          'Notset / Unknown
        Appending = 1       'Started Append procedure, however is not yet finished running it
        Appended = 2        'Append procedure has finished running on this row
    End Enum

    ''' --- GridRowStatus ------------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of GridRowStatus.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Enum GridRowStatus As Byte
        NotSet = 0          'Notset / Unknown
        UnchangedOld = 1    'Unchanged exsting record
        UnchangedNew = 2    'Unchanged new record
        Adding = 3          'Clicked on EditButton of a Blank Row in a Grid
        Editing = 4         'Clicked on EditButton of an existing Row in a grid
        Added = 5           'Added record modified (at least one field of new record has changed)
        Edited = 6          'Existing record modified (at least one field of new record has changed)
        Deleted = 7         'Record marked for deletion
        AsItIs = 8          'This enum can be used to pass the Default parameter while Calling SetStatus from the Derived Page in BeforeClick or Click event of Designer/GridButton controls
    End Enum

    ''' --- GridRowStatusCommand -----------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of GridRowStatusCommand.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Enum GridRowStatusCommand As Byte
        NotSet = 0          ' Notset / Unknown
        Change = 1          ' Will Change Status from Adding and Editing to Added and Edited respectively
        Add = 2             ' At present not used 
        Edit = 3            ' Will change Status from UnchangedOld to Editing and from UnchangedNew to Adding
        Delete = 4          ' If Current Status is Deleted then sets a PreviousStatus as CurrentStatus, otherwise marks as Deleted
        Designer = 5        ' Will change UnchangedOld to Editing and UnchangedNew to Adding, otherwise leave the current status unchanged
        DeleteAll = 6       ' Will mark each record for Deletion, on Toolbar's Delete Button Click
        Idle = 7            ' Will change status to NotSet
        None = 8            ' Will change status to NotSet
    End Enum


    ' Use in the Round function in QDesign
    ''' --- RoundOptionTypes ---------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	Specifies the number to be rounded.
    ''' </summary>
    ''' <remarks>
    ''' <para>
    '''     <list type="bullet">
    '''         <item>Near - To the nearest number.</item>
    '''         <item>Up - Toward positive infinity.</item>
    '''         <item>Down - Toward negative infinity.</item>
    '''         <item>Zero - Toward zero.</item>
    '''     </list>
    ''' </para>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Enum RoundOptionTypes As Byte
        Near = 0
        Up = 1
        Down = 2
        Zero = 3
    End Enum

    ''' --- PutTypes -----------------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	Specifies the type of data records to update.
    ''' </summary>
    ''' <remarks>
    ''' <para>
    '''     <list type="bullet">
    '''         <item>None</item>
    '''         <item>[New] - Only new data records are processed by the PUT.</item>
    '''         <item>Deleted - Only data records marked for deletion are processed by the PUT.</item>
    '''         <item>NonDeleted - Data records not marked for deletion are processed by the PUT.</item>
    '''     </list>
    ''' </para>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Enum PutTypes As Byte
        None = 0
        [New] = 1
        Deleted = 2
        NotDeleted = 3
    End Enum

    'Reset option constants for TEMPORARY object.
    ''' --- ResetTypes ---------------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	Specifies when to reset the temporary variables to their initial values.
    ''' </summary>
    ''' <remarks>
    ''' <para>
    '''     <list type="bullet">
    '''         <item>Reset</item>
    '''         <item>ResetAtMode - Resets the temporary variables when Entry mode or Find mode initialization occurs.</item>
    '''         <item>ResetAtStartup - Resets the temporary variables when the screen is opened from a higher level screen.</item>
    '''         <item>NotApplicable</item>
    '''     </list>
    ''' </para>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Enum ResetTypes As Byte
        Reset = 0
        ResetAtMode = 1
        ResetAtStartup = 2
        NotApplicable = 3
    End Enum

    ' Reset option on PUT statement.
    ''' --- ResetOptions -------------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	Summary of ResetOptions.
    ''' </summary>
    ''' <remarks>
    ''' <para>
    '''     <list type="bullet">
    '''         <item>NoReset - The record buffers and status are not reset after the update.</item>
    '''         <item>Reset - The record buffers and status are reset after the update.</item>
    '''     </list>
    ''' </para>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Enum ResetOptions As Integer
        NoReset = 0
        Reset = -1
    End Enum

    'Data type constants for TEMPORARY object.
    ''' --- TempTypes ----------------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of TempTypes.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Enum TempTypes As Byte
        Character = 0
        [Integer] = 1
        [Long] = 2
        [Decimal] = 3
        [Date] = 4
        VarChar = 5
        Float = 6
    End Enum

    'Include State to Load/Save
    ''' --- ObjectState --------------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of ObjectState.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Enum ObjectState As Integer
        FileObjectsAndCoreBaseTypes = 0
        OnlyCoreBaseTypes = 1
        OnlyFileObjects = 2
        OnlyResetAtStartUp = 4
        MoveStartUpToBaseTypes = 8
        None = -1
    End Enum

    'Allow SelectProcessing on Grid, NonGrid or not
    ''' --- SelectProcessing ---------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of SelectProcessing.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Enum SelectProcessing As Byte
        Disable = 0
        OnPrimary = 1
        OnPrimaryAndGrid = 2
    End Enum

    'Allow SelectProcessing on Grid, NonGrid or not
    ''' --- ResetDesigner ------------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	Specified when to reset the designer.
    ''' </summary>
    ''' <remarks>
    ''' <para>
    '''     <list type="bullet">
    '''         <item>OnSubmit - Once set, stays in Designer Mode, untill submit or cancel.</item>
    '''         <item>InSamePostBack - Reset in same postback, suitable for designer that only performs some business logic.</item>
    '''         <item>InNextPostBack - At present not used.</item>
    '''     </list>
    ''' </para>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Enum ResetDesigner As Byte
        OnSubmit = 0        ' Once set, stays in Designer Mode, untill submit or cancel
        InSamePostBack = 1  ' Reset in same postback, suitable for designer that only performs some business logic
        InNextPostBack = 2  ' At present not used. However in future it will reset the Designer Mode in next postback, may be, suitable for designers that executes Run Screen
    End Enum

    ' Used on the GetData (File object)
    ''' --- GetDataOptions -----------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	Summary of GetDataOptions.
    ''' </summary>
    ''' <remarks>
    ''' <para>
    '''     <list type="bullet">
    '''         <item>None</item>
    '''         <item>IsOptional - Continue processing the code, even if data records are not found.</item>
    '''         <item>Sequential - Access the data records sequentially.</item>
    '''         <item>AddRecordToBuffer - Used internally by the Renaissance framework. Do not use in your code.</item>
    '''         <item>CreateSubSelect - The CreateSubSelect option should only be used for a Detail file (in the DetailFind method)</item>
    '''         <item>SingleFetch - This option indicates that the GetData will retrieve the records once and each subsequent GetData will move to the next record position during the loop.</item>
    ''' or for a Primary file (in the Find method).  This parameter indicates that we are retrieving
    ''' a subset of the records that meet the filter (WHERE clause) criteria, based on the Occurs property
    ''' value and the current record(s) displayed.  If the Occurs is set to 5, then only five records are retrieved at one time.</item>
    '''     </list>
    ''' </para>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Enum GetDataOptions As Byte
        None = 0
        IsOptional = 1
        Sequential = 2
        AddRecordToBuffer = 4
        CreateSubSelect = 8
        SingleFetch = 16
        CreateRecordsForOccurs = 32
        ForOccurence = 64
    End Enum

    ' OnError option on RunCommand verb.
    ''' --- OnErrorOptions -----------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	Specifies what action to take if a system error occurs during execution.
    ''' </summary>
    ''' <remarks>
    ''' <para>
    '''     <list type="bullet">
    '''         <item>Continue - The error is ignored and processing of the code continues.</item>
    '''         <item>Terminate - The error is processed and execution of the code terminates. Terminate is the default.</item>
    '''     </list>
    ''' </para>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Enum OnErrorOptions As Byte
        [Continue] = 0
        Terminate = 1
    End Enum

    ''' --- PushTypes ----------------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	Specifies which command the push verb executes.
    ''' </summary>
    ''' <remarks>
    ''' <para>
    '''     <list type="bullet">
    '''         <item>Append - Execute the Append procedure.</item>
    '''         <item>Delete - Execute the Delete procedure.</item>
    '''         <item>Entry - Execute the Entry procedure.</item>
    '''         <item>Find - Execute the Find procedure.</item>
    '''         <item>PreviousData - Executes the command to display the previous set of n data records in a grid.</item>
    '''         <item>PreviousRecord - Executes the command to scroll back one primary record.</item>
    '''         <item>NextData - Executes the command to display the next set of n data records in a grid.</item>
    '''         <item>NextRecord - Execute the command to scroll forward one primary record.</item>
    '''         <item>LastRecord - Execute the command to scroll to the last primary record.</item>
    '''         <item>FirstRecord - Execute the command to scroll to the first primary record.</item>
    '''         <item>[Return] - Execute the command to return to the previous window.</item>
    '''         <item>Update - Execute the Update function.</item>
    '''     </list>
    ''' </para>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Enum PushTypes As Byte
        Append = 0
        Delete = 1
        Entry = 2
        Find = 3
        PreviousData = 4
        PreviousRecord = 5
        NextData = 6
        NextRecord = 7
        LastRecord = 8
        FirstRecord = 9
        [Return] = 10
        Update = 11
        Return_to_stop = 12
    End Enum

    ''' --- LockTypes ----------------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	Specifies the type of lock.
    ''' </summary>
    ''' <remarks>
    ''' <para>
    '''     <list type="bullet">
    '''         <item>NotSet</item>
    '''         <item>Record - Lock at the record level.</item>
    '''         <item>File - Lock at the table level.</item>
    '''         <item>Base - Not Supported.</item>
    '''     </list>
    ''' </para>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Enum LockTypes As Byte
        NotSet = 0
        Record = 1
        File = 2
        Base = 3
    End Enum

    ''' --- ScreenActivities ---------------------------------------------------
    ''' 
    ''' <summary>
    ''' 	Specifies the activities that can be performed on the screen.
    ''' </summary>
    ''' <remarks>
    ''' <para>
    '''     <list type="bullet">
    '''         <item>None - No activities can be executed on the screen.</item>
    '''         <item>Find - Existing records can be searched for.</item>
    '''         <item>Entry - New records can be added.</item>
    '''         <item>Change - Existing records can be modified.</item>
    '''         <item>Delete - Existing records can be deleted.</item>
    '''     </list>
    ''' </para>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Always)>
    Public Enum ScreenActivities As Byte
        None = 0
        Find = 1
        Entry = 2
        Change = 4
        Delete = 8
    End Enum

    ''' --- FieldAttributes ----------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of FieldAttributes.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Enum FieldAttributes As Byte
        ElementName = 0
        AlternateElementName = 1
        BwzFlag = 2
        DecimalPosition = 3
        ElementSize = 4
        ElementTypeCode = 5
        Heading = 6
        Fill = 7
        FloatValue = 8
        DateFormatCode = 9
        Label = 10
        Help = 11
        DefaultValue = 12
        InputScale = 13
        ItemDataTypeCode = 14
        ItemSize = 15
        LeadingSign = 16
        OutputScale = 17
        PatternValue = 18
        Picture = 19
        ShiftInputCode = 20
        Separator = 21
        Significance = 22
        TrailingSign = 23
        Description = 24
        Values = 25
        ControlType = 26
        LabelIsHyperLink = 27
        LabelUrl = 28
        DisplayClass = 29
        Usage = 30
    End Enum

    ''' --- FunctionKeys ----------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of FunctionKeys.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Enum FunctionKeys As Byte
        NotSet = 0
        F1 = 1
        F2 = 2
        F3 = 3
        F4 = 4
        F5 = 5
        F6 = 6
        F7 = 7
        F8 = 8
        F9 = 9
        F10 = 10
        F11 = 11
        F12 = 12
    End Enum

    ''' --- SearchTypes ----------------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	This is used for the LookupNotOn.  See notes in Validate.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Enum SearchTypes As Byte
        Sequential = 0
        Filtered = 1    ' Where clause criteria added.
    End Enum

    ' Used for Windows apps.
    ''' --- WinLabelPositionTypes ----------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of WinLabelPositionTypes.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Enum ScreenProperties As Byte
        Top = 0
        Left = 1
        Width = 2
        Height = 3
    End Enum

    ' Used for Windows apps.
    ''' --- WinLabelPositionTypes ----------------------------------------------
    ''' <exclude />
    ''' 
    ''' <summary>
    ''' 	Summary of WinLabelPositionTypes.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public Enum ParmPrompts As Byte
        Field = 0
        Type = 1
        Size = 2
        Label = 3
        Prompt = 4
        Values = 5
        ShiftType = 6
        Lookuptable = 7
        Lookupcolumn = 8
        Passbackcolumn = 9
        Flabel = 10
    End Enum

End Namespace
