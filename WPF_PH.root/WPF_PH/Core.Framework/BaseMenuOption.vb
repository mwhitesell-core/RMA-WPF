Imports System.ComponentModel
Imports System.Text
Imports System.Collections.Specialized
Imports System.Configuration
Imports Core.ExceptionManagement
Imports Core.Framework.Core.Security



Namespace Core.Framework
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: BaseClass
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' 
    ''' <summary>
    ''' Summary of BaseClass.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Always)> _
    Public Class BaseClass
        'BaseMenuOption
        Inherits Component

#Region "Members"

        ''' --- m_strUserID --------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_strUserID.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private m_strUserID As String

        ''' --- m_strSignOnAccount --------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_strSignOnAccount.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private m_strSignOnAccount As String

        ''' --- m_objParentOption --------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_objParentOption.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private m_objParentOption As BaseClass

        'BaseMenuOption
        ''' --- m_strPageName ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_strPageName.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private m_strPageName As String

        ' Variables used for SQL.
        ''' --- m_strWhere ---------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_strWhere.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_strWhere As StringBuilder

        ''' --- m_strOrderBy -------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_strOrderBy.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_strOrderBy As StringBuilder

        ''' --- m_strSQL -----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_strSQL.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_strSQL As StringBuilder

        ''' --- m_intPath ----------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Integer value that is set by the Path method based on the criteria selected.  
        '''     This value is used by the Find method to determine the retrieval of data.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> Protected m_intPath As Integer

        ' 
        ''' --- FieldText ----------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	 Contains the most recent character value in the field.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> Protected FieldText As String = String.Empty

        ' 
        ''' --- FieldValue ---------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	 Contains the most recent numeric or date value in the field.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> Protected FieldValue As Decimal

        ' 

        ''' --- m_blnInPostFindOrDetailPostFind -----------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnInPostFindOrDetailPostFind.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_blnInPostFindOrDetailPostFind As Boolean = False

        ' Default PowerHouse variables.
        ''' --- m_blnFindMode ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnFindMode.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_blnFindMode As Boolean

        ' Indicates that the user is in FIND mode.
        ''' --- m_blnEntryMode -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnEntryMode.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_blnEntryMode As Boolean

        ' Indicates that the user is in ENTRY mode.
        ''' --- m_blnChangeMode ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnChangeMode.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_blnChangeMode As Boolean

        ' Indicates that the user is in CHANGE mode.
        ''' --- m_blnCorrectMode ---------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnCorrectMode.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_blnCorrectMode As Boolean

        ' Indicates that the user is in CORRECT mode.
        ''' --- m_blnSelectMode ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnSelectMode.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_blnSelectMode As Boolean

        ' Indicates that the user is in SELECT mode.
        ''' --- m_intScreenLevel ---------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_intScreenLevel.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_intScreenLevel As Integer

        ' Indicates the current level of the screen.
        ''' --- m_blnCommandOK -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnCommandOK.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_blnCommandOK As Boolean

        ' PowerHouse COMMANDOK variable.
        ''' --- AmxwReturnValue -----------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Holds the return value from a RunCommandAmxw.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> Protected AmxwReturnValue As String = String.Empty

        ' Variables used for Activities.
        ''' --- m_blnChange --------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnChange.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_blnChange As Boolean

        ''' --- m_blnDelete --------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnDelete.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_blnDelete As Boolean

        ''' --- m_blnEntry ---------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnEntry.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_blnEntry As Boolean

        ''' --- m_blnFind ----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnFind.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_blnFind As Boolean

        ' For use of Occurrence Property and m_intOccurrence Variable 
        ' please see Notes on Occurrence Property
        ''' --- m_intOccurrence ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_intOccurrence.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Public m_intOccurrence As Integer = 0

        ' Used to store the current Occurrence of a CLUSTER variable.

        ''' --- m_intPreviousOccurrence --------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_intPreviousOccurrence.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private m_intPreviousOccurrence As Integer = -1

        ' Variables used to store Occurrence and Current Record position

        ''' --- m_blnSaveOccurrence ------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnSaveOccurrence.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected Friend m_blnSaveOccurrence As Boolean = True

        ' Used in a call to FileObject.FOR method
        ''' --- m_blnInFind --------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnInFind.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected Friend m_blnInFind As Boolean = False

        ' Used in FileObject to check if GetData is from Find or not
        ''' --- m_blnInFindOrDetailFind --------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnInFindOrDetailFind.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected Friend m_blnInFindOrDetailFind As Boolean = False

        ' Used in FileObject to check if For is in Find/DetailFind.

        ''' --- m_blnInInitialize -----------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnInInitialize.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected m_blnInInitialize As Boolean = False

        ''' --- m_blnIsInAppendOrEntry ---------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnIsInAppendOrEntry.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected Friend m_blnIsInAppendOrEntry As Boolean = False

        ' Used in FileObject to check if For is in Entry or Append.

        ''' --- dicCoreDictionary --------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of dicCoreDictionary.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private Shared dicCoreDictionary() As CoreDictionary

        ' Used to store the Core Dictionaries
        ''' --- colDictionaryKeys --------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of colDictionaryKeys.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private Shared colDictionaryKeys As HybridDictionary

        ' Used to hold 5 Characters Language-Culture which is the key and corresponding Index that can be used in an Array

        ' Used in a call to FileObject.FOR method
        ''' --- m_hstNestedForInfo -------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_hstNestedForInfo.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected Friend m_hstNestedForInfo As Hashtable

        ' m_hstNestedForInfo is a list of NestedFor, for the current FileObject

        ''' --- m_strLastForID -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_strLastForID.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private m_strLastForID As String

        ' m_strLastForID denotes the most ID Number for inner most For

        ''' --- m_intLastForIDNumber -----------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_intLastForIDNumber.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected Friend m_intLastForIDNumber As Integer = -1

        ' m_intLastForIDNumber denotes the most ID Number for inner most For
        ''' --- m_sorNestedForIDs --------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_sorNestedForIDs.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Protected Friend m_sorNestedForIDs As SortedList

        ''' --- m_stScreenType -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_stScreenType.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private m_stScreenType As ScreenTypes

#End Region

#Region "Abstract Methods"

        ''' --- ResetValues --------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Calls the ResetValues method which resets the Initial values for Temporary and File classes.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Protected Overridable Sub ResetValues()

        End Sub

        ''' --- Initialize ---------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Initialize.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Protected Overridable Function Initialize() As Boolean

        End Function

        ''' --- RunDesigner --------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RunDesigner.
        ''' </summary>
        ''' <param name="strDesigner"></param>
        ''' <param name="PageMode"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public Overridable Function RunDesigner(ByVal strDesigner As String, ByVal PageMode As PageModeTypes) _
            As Boolean

        End Function

        ''' --- Path ---------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' Establishes how record retrieval should be performed by the Find method.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' Use the Path method to determine how the record retrieval of Primary 
        ''' and Secondary files should be performed by the Find method.  This method is initiated 
        ''' when the Find sequence is initiated.  This method sets the m_intPath member variable
        ''' with the appropriate value based on the values entered on the screen by the user.
        ''' <para>
        ''' <note>This method will be overriden in the derived screen and is generated
        ''' by the Renaissance Architect PreCompiler if this method does not already exist
        ''' and the FindActivity on the screen is set to True.</note>
        ''' </para>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Protected Overridable Function Path() As Boolean

        End Function

        ''' --- PostPath -----------------------------------------------------------
        ''' 
        ''' <summary>
        ''' Performs processing upon successful completion of the Path method.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' Use the PostPath method to perform any additional processing after
        ''' successful completion of the Path method and prior to the Find method.  
        ''' <br/><br/>
        ''' NOTE: Override this method in the derived screen if you want to perform PostPath
        ''' processing.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Protected Overridable Function PostPath() As Boolean

        End Function

        ''' --- Find ---------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' Retrieves data records based on the Path method.
        ''' </summary>
        ''' <remarks>
        ''' Use the Find method to retrieve data that is to be displayed on the 
        ''' screen.
        ''' <br/><br/>
        ''' NOTE: This method will be overriden in the derived screen and is generated
        ''' by the Renaissance Architect PreCompiler if no Find method was coded and
        ''' the FindActivity for the screen is set to True.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Protected Overridable Function Find() As Boolean

            Return True

        End Function

        ''' --- PostFind -----------------------------------------------------------
        ''' 
        ''' <summary>
        ''' Performs processing upon the successful completion of the Find method.
        ''' </summary>
        ''' <remarks>
        ''' Use the PostFind method to perform specific processing after successfully
        ''' completing the Find method.  This method is called prior to displaying the 
        ''' retrieved data on the screen.
        ''' <br/><br/>
        ''' NOTE: Override this method in the derived screen if you want to perform PostFind
        ''' processing.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Protected Overridable Function PostFind() As Boolean

            Return True

        End Function

        ''' --- DetailFind ---------------------------------------------------------
        ''' 
        ''' <summary>
        ''' Performs data record retrieval for the Detail file and any files that occur
        ''' with this file.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' Use the DetailFind method to perform data retrieval for Detail files 
        ''' and any files that occur with this file.  This method is executed after Find 
        ''' and PostFind methods.
        ''' <br/><br/>
        ''' NOTE: This method will be overriden in the derived screen and is generated
        ''' by the Renaissance Architect PreCompiler if this method does not already exist
        ''' and the FindActivity on the screen is set to True.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Protected Overridable Function DetailFind() As Boolean

        End Function

        ''' --- DetailPostFind -----------------------------------------------------
        ''' 
        ''' <summary>
        ''' Performs processing upon the successful completion of the DetailFind method.
        ''' </summary>
        ''' <remarks>
        ''' Use the DeatilPostFind method to perform specific processing after successfully
        ''' completing the DetailFind method.  This method is called prior to displaying the 
        ''' retrieved data on the screen.
        ''' <br/><br/>
        ''' NOTE: Override this method in the derived screen if you want to perform DetailPostFind
        ''' processing.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Protected Overridable Function DetailPostFind() As Boolean

        End Function

        ''' --- PreUpdate ----------------------------------------------------------
        ''' 
        ''' <summary>
        ''' Performs processing prior to the Update method.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' Use the PreUpdate method to perform specific processing prior to executing
        ''' the Update method.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Protected Overridable Function PreUpdate() As Boolean

            Return True

        End Function

        ''' --- PostUpdate ---------------------------------------------------------
        ''' 
        ''' <summary>
        ''' Performs processing upon successful completion of the Update method.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' Use the PostUpdate method to perform specific processing upon successful
        ''' completion of the Update method.  
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Protected Overridable Function PostUpdate() As Boolean

            Return True

        End Function

        '---------------------------------------------
        ' Default SaveParamsReceived procedure.
        '---------------------------------------------
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' This method is called to handle updating the values received by this screen.
        ''' objects.
        ''' </summary>
        ''' <remarks>
        ''' Use the SaveParamsReceived method to handle updating the values from the 
        ''' File/Temporary objects that were passed in to this screen.
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Protected Overridable Sub SaveParamsReceived()

        End Sub

        ''' --- Update -------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' Performs processing to update the database.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' The Update method is used to update the database with new, modified or deleted records.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Protected Friend Overridable Function Update() As Boolean

            Return True

        End Function

        ''' --- Delete -------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' This method marks data records for deletion in Primary files and associated
        ''' Secondary and Detail files.
        ''' </summary>
        ''' <remarks>
        ''' The Delete method is invoked by pressing the Delete button on the 
        ''' toolbar.  This method is used to mark data records for deletion in Primary
        ''' files and associated Secondary and Detail files.
        ''' <br/><br/>
        ''' NOTE: This method will be overriden in the derived screen and is generated
        ''' by the Renaissance Architect Precompiler if it doesn't exists and the 
        ''' DeleteActivity property has been set to True on the page.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Protected Friend Overridable Function Delete() As Boolean

            Return True

        End Function

        ''' --- DetailDelete -------------------------------------------------------
        ''' 
        ''' <summary>
        ''' This method marks data records for deletion in Detail files.
        ''' </summary>
        ''' <remarks>
        ''' The DetailDelete method is invoked by pressing the Detail Delete button 
        ''' on the grid.  This method is used to mark data records for deletion in Detail 
        ''' files.
        ''' <br/><br/>
        ''' NOTE: This method will be overriden in the derived screen and is generated
        ''' by the Renaissance Architect Precompiler if it doesn't exists providing the 
        ''' DeleteActivity property  has been set to True on the page.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Protected Friend Overridable Function DetailDelete() As Boolean

            Return True

        End Function


        ''' --- Exit ---------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' Performs processing prior to closing the current screen.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' Use the Exit method to perform processing prior to closing the current
        ''' screen.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Protected Overridable Function [Exit]() As Boolean

        End Function

#End Region

#Region "Screen Variable Definitions"

        ''' --- m_blnAutoReturn ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_blnAutoReturn.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Private m_blnAutoReturn As Boolean

#End Region

#Region "Properties"

        ''' --- Mode ---------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' This member supports the Renaissance Architect Framework infrastructure and 
        ''' is not intended to be used directly from your code.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/5/2005	Created
        '''     [Mark]      19/7/2005   Used summary from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public Overridable Property Mode() As PageModeTypes
            Get

            End Get
            Set(ByVal Value As PageModeTypes)

            End Set
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets a value indicating that the screen will automatically close and
        ''' return to the calling screen.
        ''' </summary>
        ''' <returns>True indicates that the screen will close and return to the calling screen.</returns>
        ''' <remarks>
        ''' Use the AutoReturn property to indicate that the screen should exit upon successfully 
        ''' completing update sequence (PreUpdate,Update, and PostUpdate procedures).
        ''' </remarks>
        ''' <history>
        ''' 	[mayur]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Property AutoReturn() As Boolean
            Get
                Return m_blnAutoReturn
            End Get
            Set(ByVal Value As Boolean)
                m_blnAutoReturn = Value
            End Set
        End Property

        '--------------------------
        ' ChangeMode property.
        '--------------------------
        ''' --- ChangeMode ---------------------------------------------------------
        '''
        ''' <summary>
        ''' 	The screen is in Find mode and data has been displayed.  The user can
        '''     now update values.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Browsable(False), _
            EditorBrowsable(EditorBrowsableState.Always)> _
        Public ReadOnly Property ChangeMode() As Boolean
            Get
                Return m_blnChangeMode
            End Get
        End Property

        '--------------------------
        ' CorrectMode property.
        '--------------------------
        ''' --- CorrectMode --------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	The screen is in Entry mode and the Entry procedure has completed.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Browsable(False), _
            EditorBrowsable(EditorBrowsableState.Always)> _
        Public ReadOnly Property CorrectMode() As Boolean
            Get
                Return m_blnCorrectMode
            End Get
        End Property

        '--------------------------
        ' EntryMode property.
        '--------------------------
        ''' --- EntryMode ----------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	The screen is in the Entry sequence or appending data.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Browsable(False), _
            EditorBrowsable(EditorBrowsableState.Always)> _
        Public ReadOnly Property EntryMode() As Boolean
            Get
                Return m_blnEntryMode
            End Get
        End Property

        '--------------------------
        ' FindMode property.
        '--------------------------
        ''' --- FindMode -----------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	The screen is performing Find mode initialization, retrieving records,
        '''     or displaying records.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <Browsable(False), _
            EditorBrowsable(EditorBrowsableState.Always)> _
        Public ReadOnly Property FindMode() As Boolean
            Get
                Return m_blnFindMode
            End Get
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Returns the logged-on user.
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <example>T_TEMP.Value = SignOnAccount()</example>
        ''' <history>
        ''' 	[mayur]	3/18/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Protected ReadOnly Property SignOnAccount() As String
            Get
                Return UserAccount()
            End Get
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' SignOnUser returns the logged-on user.
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <example>T_TEMP.Value = SignOnUser()</example>
        ''' <history>
        ''' 	[mayur]	3/18/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Protected ReadOnly Property SignOnUser() As String
            Get
                'Return UserID()
            End Get
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' SignOnGroup returns the user's logon group.
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mayur]	3/18/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Protected ReadOnly Property SignOnGroup() As String
            Get
                'Return UserID()
            End Get
        End Property

        ''' --- Occurrence ---------------------------------------------------------
        ''' 
        ''' <summary>
        ''' Gets the Occurrence value.
        ''' </summary>
        ''' <value>An integer value representing the current occurrence.</value>
        ''' <remarks>
        ''' The Occurrence property indicates the number of times a loop has executed or
        ''' the current record occurrence within a grid.  For example, if working with the 
        ''' third record in a grid, the value of occurrence is 3.  If a FOR loop is executing
        ''' while working on the third record, the occurrence will be the number of times the
        ''' loop has executed.  When breaking out of the loop, the occurrence will have a 
        ''' value of 3 once again.
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public ReadOnly Property Occurrence() As Integer
            Get
                Return m_intOccurrence + 1
            End Get
        End Property

        ''' --- ChangeActivity -----------------------------------------------------
        ''' 
        ''' <summary>
        ''' Gets or sets a value indicating that the current screen is updatable.
        ''' </summary>
        ''' <value>True if the screen is updatable.</value>
        ''' <remarks>
        ''' Use the ChangeActivity property to indicate that the user can update records
        ''' on the current screen.
        ''' <br/><br/>
        ''' NOTE: If ChangeActivity or DeleteActivity is true, then FindActivity returns True.
        ''' If ChangeActivity, DeleteActivity, FindActivity and EntryActivity are all False,
        ''' then all these activities are considered True indicating that the user can find,
        ''' delete, change and add new records on the current screen unless the code prohibits
        ''' this explicitly (ie. by removing the code from within the Entry procedure).
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Property ChangeActivity() As Boolean
            Get
                ' If all the activities are FALSE (which means the default - none of the activities were set),
                ' then PowerHouse sets the activities to TRUE.
                If m_blnChange = False And m_blnDelete = False And m_blnEntry = False And m_blnFind = False Then
                    Return True
                Else
                    Return m_blnChange
                End If
            End Get
            Set(ByVal Value As Boolean)
                m_blnChange = Value
            End Set
        End Property

        ''' --- DeleteActivity -----------------------------------------------------
        ''' 
        ''' <summary>
        ''' Gets or sets a value indicating that the current screen allows deleting records.
        ''' </summary>
        ''' <value>True if the screen allows the deletion of records.</value>
        ''' <remarks>
        ''' Use the DeleteActivity property to indicate that the user can delete records
        ''' on the current screen.
        ''' <br/><br/>
        ''' NOTE: If ChangeActivity or DeleteActivity is true, then FindActivity returns True.
        ''' If ChangeActivity, DeleteActivity, FindActivity and EntryActivity are all False,
        ''' then all these activities are considered True indicating that the user can find,
        ''' delete, change and add new records on the current screen unless the code prohibits
        ''' this explicitly (ie. by removing the code from within the Entry procedure).
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Property DeleteActivity() As Boolean
            Get
                ' If all the activities are FALSE (which means the default - none of the activities were set),
                ' then PowerHouse sets the activities to TRUE.
                If m_blnChange = False And m_blnDelete = False And m_blnEntry = False And m_blnFind = False Then
                    Return True
                Else
                    Return m_blnDelete
                End If
            End Get
            Set(ByVal Value As Boolean)
                m_blnDelete = Value
            End Set
        End Property

        ''' --- EntryActivity ------------------------------------------------------
        ''' 
        ''' <summary>
        ''' Gets or sets a value indicating that the current screen allows adding new records.
        ''' </summary>
        ''' <value>True if the screen allows adding new records.</value>
        ''' <remarks>
        ''' Use the EntryActivity property to indicate that the user can add new records
        ''' on the current screen.
        ''' <br/><br/>
        ''' NOTE: If ChangeActivity, DeleteActivity, FindActivity and EntryActivity are all False,
        ''' then all these activities are considered True indicating that the user can find,
        ''' delete, change and add new records on the current screen unless the code prohibits
        ''' this explicitly (ie. by removing the code from within the Entry procedure).
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Property EntryActivity() As Boolean
            Get
                ' If all the activities are FALSE (which means the default - none of the activities were set),
                ' then PowerHouse sets the activities to TRUE.
                If m_blnChange = False And m_blnDelete = False And m_blnEntry = False And m_blnFind = False Then
                    Return True
                Else
                    Return m_blnEntry
                End If
            End Get
            Set(ByVal Value As Boolean)
                m_blnEntry = Value
            End Set
        End Property

        ''' --- FindActivity -------------------------------------------------------
        ''' 
        ''' <summary>
        ''' Gets or sets a value indicating that the current screen allows finding records.
        ''' </summary>
        ''' <value>True if the screen allows the finding of records.</value>
        ''' <remarks>
        ''' Use the DeleteActivity property to indicate that the user can find records
        ''' on the current screen.
        ''' <br/><br/>
        ''' NOTE: If ChangeActivity or DeleteActivity is true, then FindActivity returns True.
        ''' If ChangeActivity, DeleteActivity, FindActivity and EntryActivity are all False,
        ''' then all these activities are considered True indicating that the user can find,
        ''' delete, change and add new records on the current screen unless the code prohibits
        ''' this explicitly (ie. by removing the code from within the Entry procedure).
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Property FindActivity() As Boolean
            Get
                ' If all the activities are FALSE (which means the default - none of the activities were set),
                ' then PowerHouse sets the activities to TRUE.
                If m_blnChange = False And m_blnDelete = False And m_blnEntry = False And m_blnFind = False Then
                    Return True
                Else
                    ' If Change or Delete is set to TRUE, then FIND is implied.
                    If m_blnChange Or m_blnDelete Then
                        Return True
                    Else
                        Return m_blnFind
                    End If
                End If
            End Get
            Set(ByVal Value As Boolean)
                m_blnFind = Value
            End Set
        End Property

        ''' --- Name ---------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Specifies the name of the Page (Screen).
        ''' </summary>
        ''' <remarks>
        ''' <para>This function is overridable so that the developer has the option
        ''' of coding their own procedure to suite the needs of the specific screen
        ''' they are working on. By doing so, the screens functionality is tied to the 
        ''' Renaissance Architect Framework.</para>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Overridable Property Name() As String
            Get
                Return m_strPageName
            End Get
            Set(ByVal Value As String)
                m_strPageName = Value
            End Set
        End Property

        ''' --- FormName -----------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	The name of the screen.  This name is displayed on the standard toolbar.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Property FormName() As String
            Get
                Return m_strPageName
            End Get
            Set(ByVal Value As String)
                m_strPageName = Value
            End Set
        End Property

        ''' --- Level --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Page (Screen) Level property
        ''' </summary>
        ''' <remarks>
        ''' <para>This function is overridable so that the developer has the option
        ''' of coding their own procedure to suite the needs of the specific screen
        ''' they are working on. By doing so, the screens functionality is tied to the 
        ''' Renaissance Architect Framework.</para>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Overridable Property Level() As Integer
            Get
                'Should be implemented in derived class
                'Return ViewState("ScreenLevel")
            End Get
            Set(value As Integer)

            End Set
        End Property

        ''' --- ParentOption -------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Summary of ParentOption.
        ''' </summary>
        ''' <remarks>
        ''' <para>This function is overridable so that the developer has the option
        ''' of coding their own procedure to suite the needs of the specific screen
        ''' they are working on. By doing so, the screens functionality is tied to the 
        ''' Renaissance Architect Framework.</para>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Protected Friend Overridable Property ParentOption() As BaseClass 'BaseMenuOption
            Get
                Return m_objParentOption
            End Get
            Set(ByVal Value As BaseClass) 'BaseMenuOption)
                m_objParentOption = Value
            End Set
        End Property

        ''' --- AccessOk -----------------------------------------------------------
        ''' 
        ''' <summary>
        ''' When a record is retrieved, the property AccessOk is set to true or false 
        ''' depending on whether the retrieval succeeds or fails.
        ''' </summary>
        ''' <returns>A Boolean.</returns>
        ''' <remarks>
        ''' <para>This function is overridable so that the developer has the option
        ''' of coding their own procedure to suite the needs of the specific screen
        ''' they are working on. By doing so, the screens functionality is tied to the 
        ''' Renaissance Architect Framework.</para>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Overridable Property AccessOk() As Boolean
            'The ACCESSOK condition relates to a session and not to a specific screen.
            Get
                'Must be overrided in the derived class
            End Get
            Set(value As Boolean)

            End Set
        End Property

        ''' --- ScreenType ---------------------------------------------------------
        ''' 
        ''' <summary>
        ''' Gets or sets a value indicating the screen type.
        ''' </summary>
        ''' <value>The posible values are ScreenTypes.NonGrid, ScreenTypes.Grid, 
        ''' ScreenTypes.Composite and ScreenTypes.Ghost.</value>
        ''' <remarks>
        ''' Use the ScreenType property to indicate whether the current screen is 
        ''' a grid or non-grid screen, a composite screen (grid with primary which requires
        ''' the pagination and navigation toolbars), or a ghost screen.  
        ''' </remarks>
        ''' <note>Changing this value to a value other then what was generated may have undesired results.
        ''' </note>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Property ScreenType() As ScreenTypes
            Get
                Return m_stScreenType
            End Get
            Set(ByVal Value As ScreenTypes)
                m_stScreenType = Value
            End Set
        End Property

#End Region

#Region "Methods"


        ''' --- m_Node -------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of m_Node.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Public m_Node As String = ""

        '-------------------------------------------------------------------
        ' Name: SetCurrentRecordPosition
        ' Note: This Method is for internal use
        ' Function: This function gets a record count based on the current
        '           WHERE clause passed in, and based on NavigationType
        '           it sets the position of the Current Record
        ' Example: SetCurrentRecordPosition(MyFile, "WhereClause", "SelectIfCondition", "AccessClause, "OrderByClause")
        '-------------------------------------------------------------------
        ''' --- SetCurrentRecordPosition -------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of SetCurrentRecordPosition.
        ''' </summary>
        ''' <param name="File"></param>
        ''' <param name="WhereClause"></param>
        ''' <param name="SelectIf"></param>
        ''' <param name="AccessClause"></param>
        ''' <param name="OrderByClause"></param>
        ''' <param name="WholeWhereCondition"></param>
        ''' <param name="SkippedRecords"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public Function SetCurrentRecordPosition(ByVal File As BaseFileObject, ByVal WhereClause As String, _
                                                  ByVal SelectIf As String, ByVal AccessClause As String, _
                                                  ByVal OrderByClause As String, ByRef WholeWhereCondition As String, _
                                                  ByVal SkippedRecords As Integer) As String

            Try
                Dim strBaseName As String
                Dim strAliasName As String
                Dim intRecordCount As Integer
                Dim intOccurs As Integer
                Dim strRelation As String
                Dim strSQL As StringBuilder = New StringBuilder("")

                With File
                    strBaseName = .BaseName
                    strAliasName = .AliasName
                    intOccurs = .Occurs

                    'Occurs can't be Zero; by default Occurs is 1 
                    If intOccurs = 0 Then intOccurs = 1

                End With
                If WholeWhereCondition Is Nothing Then WholeWhereCondition = String.Empty
                BuildWhereCondition(WholeWhereCondition, WhereClause)
                BuildWhereCondition(WholeWhereCondition, AccessClause)
                BuildWhereCondition(WholeWhereCondition, SelectIf)

                If strAliasName.Trim.Length = 0 Then
                    strRelation = strBaseName
                Else
                    strRelation = strAliasName
                End If

                ' Add the navigation code.
                ' Set the record number when in FIND mode.
                If Mode = PageModeTypes.Find Then
                    intRecordCount = File.GetRecordCount(WholeWhereCondition)
                    File.TotalRecordsFound = intRecordCount

                    If SkippedRecords > 0 Then
                        With File
                            Dim intTotalSkippedRecords As Integer
                            intTotalSkippedRecords = .TotalSkippedRecords + SkippedRecords
                            .TotalSkippedRecords = intTotalSkippedRecords
                        End With
                    End If
                End If

            Catch ex As CustomApplicationException

                ExceptionManager.Publish(ex)
                Throw ex

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex

            End Try

            Return Nothing

        End Function

        ''' --- LoadDictionaries ---------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of LoadDictionaries.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public Shared Sub LoadDictionaries()
            'Read the Dictionary File paths from the Config File
            Dim _
                nvcDictionarySettings As NameValueCollection = _
                    CType(ConfigurationManager.GetSection("coreAppSettings/Dictionaries"), NameValueCollection)

            With nvcDictionarySettings
                'Declare a loca variable to hold multiple Dictionaries
                Dim objDictionaries(.Count - 1) As CoreDictionary

                '
                colDictionaryKeys = New HybridDictionary
                For i As Integer = 0 To .Count - 1
                    colDictionaryKeys.Item(nvcDictionarySettings.Keys.Item(i)) = i
                    'We are not checking whether Dictionary File is exist or not
                    'So Path Provided in Web.Confi for Dictionary File should point to
                    'a valid Dictionary File
                    objDictionaries(i) = New CoreDictionary(nvcDictionarySettings.Item(i))
                Next

                dicCoreDictionary = objDictionaries
            End With
        End Sub

        ''' --- GetDictionaryItem --------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of GetDictionaryItem.
        ''' </summary>
        ''' <param name="Language"></param>
        ''' <param name="FieldId"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public Shared Function GetDictionaryItem(ByVal Language As String, ByVal FieldId As String) _
            As CoreDictionaryItem
            If dicCoreDictionary Is Nothing Then
                LoadDictionaries()
            End If

            If colDictionaryKeys.Contains(Language) Then
                Return dicCoreDictionary(CInt(colDictionaryKeys.Item(Language))).GetDictionaryItem(FieldId)
            Else
                ' There is no dictionary for the passed Language
                Return Nothing
            End If
        End Function

        ''' --- ReturnAndClose -----------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Will throw an exception if screen is not used as a ghost screen.
        ''' </summary>
        ''' <remarks>
        ''' <para>This function is overridable so that the developer has the option
        ''' of coding their own procedure to suite the needs of the specific screen
        ''' they are working on. By doing so, the screens functionality is tied to the 
        ''' Renaissance Architect Framework.</para>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Protected Friend Overridable Sub ReturnAndClose()

            'Throw an exception only if screen is not used as the ghost screen
            ThrowCustomApplicationException(cReturn)

        End Sub

       

        ''' --- UserAccount -------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Retrieves the account of the current user.
        ''' </summary>
        ''' <remarks>
        ''' <para>This function is overridable so that the developer has the option
        ''' of coding their own procedure to suite the needs of the specific screen
        ''' they are working on. By doing so, the screens functionality is tied to the 
        ''' Renaissance Architect Framework.</para>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Overridable Function UserAccount() As String
            If m_strSignOnAccount Is Nothing Then
                Dim objSecurityManager As New SecurityManager
                m_strSignOnAccount = objSecurityManager.GetCurrentAccount
                objSecurityManager = Nothing
            End If
            Return m_strSignOnAccount
        End Function

        ''' --- CallFind -----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of CallFind.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public Overridable Sub CallFind()
            Try

                ' Call the Path procedure.
                Path()
                PostPath()
                ' This happens after SELECT processing.

                m_blnInFind = True
                m_blnInFindOrDetailFind = True
                Find()
                m_blnInFindOrDetailFind = False
                m_blnInPostFindOrDetailPostFind = True
                PostFind()
                m_blnInPostFindOrDetailPostFind = False
                m_blnInFindOrDetailFind = True
                DetailFind()
                m_blnInFindOrDetailFind = False
                m_blnInPostFindOrDetailPostFind = True
                DetailPostFind()
                m_blnInPostFindOrDetailPostFind = False
                m_blnInFind = False

            Catch ex As CustomApplicationException
                m_blnInFind = False
                Throw ex

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex
            End Try

        End Sub


        ''' --- CallEntry -----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of CallEntry.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public Overridable Sub CallEntry()
            Try

                Mode = PageModeTypes.Entry

                PreEntry()
                Entry()
                PostEntry()

            Catch ex As CustomApplicationException
                Throw ex

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex
            End Try

        End Sub

        '---------------------------------------------
        ' Default TRANS_UPDATE procedure.
        '---------------------------------------------
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Perform a Commit or Rollback on the default update transaction.
        ''' </summary>
        ''' <param name="Method">TransactionMethods.Commit or TransactionMethods.Rollback</param>
        ''' <remarks>
        ''' NOTE: This method will be overriden in the derived screen and is generated
        ''' by the Renaissance Architect PreCompiler.
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Protected Friend Overridable Sub TRANS_UPDATE(ByVal Method As TransactionMethods)

        End Sub

        '---------------------------------------------
        ' ExecuteNamedTransactions procedure to call named transactions.
        '---------------------------------------------
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Perform a Commit or Rollback on named transaction during the Update phase if no Commit was explicitly
        ''' coded by the developer.
        ''' </summary>
        ''' <param name="Method">TransactionMethods.Commit or TransactionMethods.Rollback</param>
        ''' <remarks>
        ''' NOTE: This method will be overriden in the derived screen and is generated
        ''' by the Renaissance Architect PreCompiler.
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Protected Friend Overridable Sub ExecuteNamedTransactions(ByVal Method As TransactionMethods)

        End Sub

        ''' --- CallEntry -----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of CallEntry.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public Overridable Sub CallUpdate()
            Try

                If Mode = PageModeTypes.Find Then
                    Mode = PageModeTypes.Change
                ElseIf Mode = PageModeTypes.Entry Then
                    Mode = PageModeTypes.Correct
                End If

                PreUpdate()
                Update()

                ' Commit the default transaction (TRANS_UPDATE).
                TRANS_UPDATE(TransactionMethods.Commit)
                ExecuteNamedTransactions(TransactionMethods.Commit)


                PostUpdate()

                'Save The Recieving list after the Update
                SaveParamsReceived()

                ' Commit the default transaction (TRANS_UPDATE).
                TRANS_UPDATE(TransactionMethods.Commit)
                ExecuteNamedTransactions(TransactionMethods.Commit)


            Catch ex As CustomApplicationException
                Throw ex

            Catch ex As Exception

                ' Write the exception to the event log and throw an error.
                ExceptionManager.Publish(ex)
                Throw ex
            End Try

        End Sub

        ''' --- CallExit -----------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of CallExit.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public Overridable Function CallExit() As Boolean
            Return [Exit]()
        End Function

        ''' --- DoExternal ---------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Executes an external program.
        ''' </summary>
        ''' <param name="External">A String containing the command to execute.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Protected Function DoExternal(ByVal External As String) As Boolean

            DoExternal(External, Nothing)

        End Function

        ''' --- DoExternal ---------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Executes an exteranl program.
        ''' </summary>
        ''' <param name="External">A String containing the command to execute.</param>
        ''' <param name="Parameters">An array of command parameters.</param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Protected Function DoExternal(ByVal External As String, ByVal ParamArray Parameters() As Object) As Boolean

            ' TODO: Add code for DoExternal.  Created wrapper class for generation purpose.

        End Function

        ''' --- RunCommand ---------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of RunCommand.
        ''' </summary>
        ''' <param name="Command"></param>
        ''' <param name="OnError"></param>
        ''' <param name="NoWarn"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Protected Function RunCommand(ByVal Command As String, _
                                       Optional ByVal OnError As OnErrorOptions = OnErrorOptions.Terminate, _
                                       Optional ByVal NoWarn As Boolean = False) As Boolean

            ' TODO: Add code for RunCommand.  Created wrapper class for generation purpose.

        End Function

        ''' --- For ----------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Summary of For.
        ''' </summary>
        ''' <param name="OccursTimes"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Function [For](ByVal OccursTimes As Integer) As Boolean
            'Note: in case of calls to nested For call NestedFor with ID starting with "For"
            Return NestedFor("InterFor1", OccursTimes)
        End Function

        ''' --- NestedFor ----------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Summary of NestedFor.
        ''' </summary>
        ''' <param name="ForID"></param>
        ''' <param name="OccursTimes"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Function NestedFor(ByVal ForID As String, ByVal OccursTimes As Integer) As Boolean
            'Note: in case of calls to nested For call NestedFor with ID starting with "For"

            'TODO: Needs to be tested
            'Notes:
            'The behaviour of For function has following differences from the Legacy App:
            '1.	It will produce unexpected results if it has direct or indirect nested For/WhileRetrieve (discussed in WhileRetrieve of BaseFileObject).
            '2. Whenever there is "Break" inside the For loop it is necessary to 
            '   Reset m_blnSaveOccurence through Break
            '3. OccursTimes is assumed to be One based, however m_intOccurrence
            '   which is used to loop through all occurrence is zero based
            '4. To access the global Occurrence use Occurrence Property which is one based

            If m_hstNestedForInfo Is Nothing Then m_hstNestedForInfo = New Hashtable

            'If m_hstNestedForInfo contains the passed ForID,
            'Move to the next Record using the Occurrence
            'Otherwise see Else part for comments
            If m_hstNestedForInfo.Contains(ForID) Then
                ' Reached at either Last Value in FileObject i.e. EOF or 
                ' upto Occurs then Reset OccursTimes and Position in an Array
                If (m_intOccurrence + 1) >= OccursTimes Then 'm_intOccurrence is zero based and OccursTimes is one based
                    'we need to reset some variables inside the Break method
                    'so that subsequent FOR Statements (if any) can start 
                    'from First Value
                    Break(ForID)
                    'We are using Break to reset these variables

                    'Return False so that we can exit from the Do While Loop in derived Page
                    Return False
                Else
                    'Move to next Occurrence and bind Grid Fields if screen has grid
                    SetOccurrence(m_intOccurrence + 1)
                End If
            Else
                'If m_hstNestedForInfo doesn't contain the passed ForID
                'Create a new instance of ForInfo using the current occurrence and CurrentRow
                'and add it to the m_hstNestedForInfo
                m_hstNestedForInfo.Add(ForID, New ForInfo(m_intOccurrence, m_intOccurrence))

                'Increment the m_intLastForIDNumber which denotes the ID number for inner most For
                m_intLastForIDNumber += 1
                If m_intLastForIDNumber = 0 Then
                    'If this is the first (outer most) For
                    'Create the m_sorNestedForIDs
                    m_sorNestedForIDs = New SortedList

                    'Update m_sorNestedForIDs with the ForID, which is used 
                    'to determine For in Break (w/o parameters) method
                    m_sorNestedForIDs.Add(m_intLastForIDNumber, ForID)
                End If

                ' Preserve the current Occurence and Start from the first (i.e. 0) Occurrence
                'm_intPreviousOccurrence = m_intOccurrence

                'Start from the first Value i.e. 0
                SetOccurrence(0)

                ''Set it to False so that Else part can move position in an array
                'm_blnSaveOccurrence = False
            End If

            'Return True to continue looping through all records in a file in derived Page
            Return True

        End Function

        ''' --- Break --------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Summary of Break.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        '''     [Mark]      19/7/2005   Copied the nDocs info from page.aspx.vb
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Sub Break()
            'This function can be called from the derived page whenever there is a Break inside the For loop

            'If "For" and "Break" method is used properly, m_strLastForID should always have
            'the value set during a Call to "For" or "ForMissing"
            Me.Break(Me.m_strLastForID)
        End Sub

        ''' --- Break --------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Break.
        ''' </summary>
        ''' <param name="ForID"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private Sub Break(ByVal ForID As String)
            'This function should not be called from outside the Base Page

            If Not m_hstNestedForInfo.Contains(ForID) Then
                'To avoid Error exit
                Exit Sub
            End If

            Dim objForInfo As ForInfo

            'Get the ForInfo for the passed "ForID"
            objForInfo = CType(m_hstNestedForInfo(ForID), ForInfo)

            'Reset Main Occurrence on the Page to Previous Value and if applicable, bind Grid Fields
            Me.SetOccurrence(objForInfo.PreviousOccurrence)

            'Release the reference to ForInfo
            objForInfo = Nothing

            'Remove the ForInfo object from NestedForInfo hash table
            m_hstNestedForInfo.Remove(ForID)

            'Reduce the LastForIDNumber by one
            m_intLastForIDNumber -= 1

            'If there is no nested For left, 
            'remove the reference to m_sorNestedForIDs and m_strLastForID 
            'otherwise get the m_strLastForID from the m_sorNestedForIDs
            If m_intLastForIDNumber = -1 Then
                m_sorNestedForIDs = Nothing
                m_strLastForID = Nothing

                'Note: m_intLastForIDNumber and m_hstNestedForInfo should work hand-in-hand,
                'if m_intLastForIDNumber becomes negative, ideally m_hstNestedForInfo should not contain any item
                'however to release the reference we are clearing and than releasing the m_hstNestedForInfo
                m_hstNestedForInfo.Clear()
                m_hstNestedForInfo = Nothing
            Else
                m_strLastForID = CStr(m_sorNestedForIDs.Item(m_intLastForIDNumber))
            End If
        End Sub

        ''' --- SetOccurrence ------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of SetOccurrence.
        ''' </summary>
        ''' <param name="NewOccurrence"></param>
        ''' <param name="Reset"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public Overridable Function SetOccurrence(ByVal NewOccurrence As Integer, _
                                                   Optional ByVal Reset As Boolean = False) As Boolean
            'Note: This function should not be called from outside the Framework
            If Me.m_intOccurrence <> NewOccurrence Then
                Me.m_intOccurrence = NewOccurrence
            End If
        End Function

        ''' --- CallRunDesigner ----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of CallRunDesigner.
        ''' </summary>
        ''' <param name="Designer"></param>
        ''' <param name="PageMode"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public Overridable Function CallRunDesigner(ByVal Designer As String, ByVal PageMode As PageModeTypes, _
                                                     Optional ByVal blnExit As Boolean = False) As Boolean
            Return RunDesigner(Designer, PageMode)
        End Function

        ''' --- CallInitialize -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of CallInitialize.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public Overridable Function CallInitialize() As Boolean
            Return Initialize()
        End Function

        ''' --- CallInitialize -----------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of CallInitialize.
        ''' </summary>
        ''' <param name="Mode"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public Overridable Function CallInitialize(ByVal Mode As PageModeTypes) As Boolean

            Return Initialize()
        End Function

        ''' --- SetAccessOk --------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of SetAccessOk.
        ''' </summary>
        ''' <param name="AccessOk"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/16/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public Overridable Sub SetAccessOk(ByVal AccessOk As Boolean)
            'The ACCESSOK condition relates to a session and not to a specific screen.
            'Must be overrided in the derived page
        End Sub

        '---------------------------------------------
        ' Default Backout procedure.
        '---------------------------------------------
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Performs processing when the user backs out of the Entry sequence or fails
        ''' to update a change.
        ''' </summary>
        ''' <remarks>
        ''' Use the Backout method to perform processing when the user fails to 
        ''' complete the Entry sequence or fails to update a change.  A warning is given
        ''' to the user indicating that data changes will be lost.
        ''' <br/><br/>
        ''' NOTE: Override this method in the derived screen if you want to perform Backout
        ''' processing.
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Protected Overridable Function Backout() As Boolean

            Return True

        End Function

        '---------------------------------------------
        ' Lock procedure.
        '---------------------------------------------
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Locks a table or record in the database.
        ''' </summary>
        ''' <param name="FileObject">A reference to a file object.</param>
        ''' <param name="LockTypes">A lock type of either Record, File or Base</param>
        ''' <remarks>
        ''' Use the Lock method to lock a record or table in the database.  
        ''' </remarks>
        ''' <example>Lock(fleEMPLOYEE) <br/>
        '''         Lock(fleEMPLOYEE, LockTypes.File)
        ''' </example>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Protected Overridable Function Lock(ByVal FileObject As BaseFileObject, _
                                             Optional ByVal LockTypes As LockTypes = LockTypes.Record) As Boolean

            Return FileObject.Lock(LockTypes)

        End Function

        '---------------------------------------------
        ' Lock procedure.
        '---------------------------------------------
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Unlocks a table or record in the database.
        ''' </summary>
        ''' <param name="FileObject">A reference to a file object.</param>
        ''' <param name="LockTypes">A lock type of either Record, File or Base</param>
        ''' <remarks>
        ''' Use the Unlock method to unlock a table or record that has previously
        ''' been locked.
        ''' </remarks>
        ''' <example>Unlock(fleEMPLOYEE) <br/>
        '''         Unlock(fleEMPLOYEE, LockTypes.File)
        ''' </example>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Protected Overridable Function Unlock(ByVal FileObject As BaseFileObject, _
                                               Optional ByVal LockTypes As LockTypes = LockTypes.Record) As Boolean

            Return FileObject.Unlock(LockTypes)

        End Function

        '---------------------------------------------
        ' Default PreEntry procedure.
        '---------------------------------------------
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Perform processing prior to the Entry sequence.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' Use the PreEntry method to perform any processing prior to the Entry
        ''' sequence.  This method can be used to perform tests or calculations.
        ''' <br/><br/>
        ''' NOTE: Override this method in the derived screen if you want to perform PreEntry
        ''' processing.
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Protected Overridable Function PreEntry() As Boolean

        End Function

        '---------------------------------------------
        ' Default Entry procedure.
        '---------------------------------------------
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Performs the standard Entry sequence.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' Use the Entry method to perform the entering of new data records.  
        ''' <para>
        ''' <note>This method will be overriden in the derived screen and is generated
        ''' by the Renaissance Architect PreCompiler if this method does not already exist
        ''' and the EntryActivity on the screen is set to True.</note>
        ''' </para>
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Protected Overridable Function Entry() As Boolean

        End Function

        '---------------------------------------------
        ' Post Entry procedure.
        '---------------------------------------------
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Perform any processing after successful completion of the Entry sequence.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' Use the PostEntry method to perform any subsequent processing upon
        ''' successful completion of the Entry sequence.
        ''' <br/><br/>
        ''' NOTE: Override this method in the derived screen if you want to perform PostEntry
        ''' processing.
        ''' </remarks>
        ''' <history>
        ''' 	[Chris]	05/04/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Protected Overridable Function PostEntry() As Boolean

        End Function

        ''' --- AuditStatus --------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Returns an "N", "D", or "C" value indicating the status of the current record.
        ''' </summary>
        ''' <param name="File">The File class for which to check the status.</param>
        ''' <remarks>
        ''' The AuditStatus method returns an "N" for a new record, "D" for a record marked for deletion, and a "C" for a changed record.
        ''' </remarks>
        ''' <example>
        ''' T_AUDIT_STATUS.Value = AuditStatus(fleEMPLOYEE)
        ''' </example>
        ''' <history>
        ''' 	[Campbell]	7/4/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Protected Function AuditStatus(ByRef File As IFileObject) As String

            Return File.AuditStatus()

        End Function

#End Region
    End Class

#Region "Class: MenuOptionEventArgs"

    ''' ----------------------------------------------------------------------------
    ''' 
    ''' Class	: MenuOptionEventArgs
    ''' 
    ''' ----------------------------------------------------------------------------
    ''' <exclude/>
    ''' 
    ''' <summary>
    ''' 	Summary of MenuOptionEventArgs.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Campbell]	6/16/2005	Created
    ''' </history>
    ''' --- End of Comments ----------------------------------------------------
    <EditorBrowsable(EditorBrowsableState.Always)> _
    Public Class MenuOptionEventArgs
        Inherits EventArgs

        ''' --- OptionName ---------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of OptionName.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Public OptionName As String

        'Option Name/Designer Name; Descriptive or short name
        ''' --- OptionParams -------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of OptionParams.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Public OptionParams As String

        'Parameters for the MenuOption
        ''' --- Node ---------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Node.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Public Node As Object

        'Respective Tree Node
        ''' --- Tag ----------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of Tag.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/27/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Advanced)> Public Tag As Object

        'Any other Parameters

        ''' --- New ------------------------------------------------------------
        ''' <exclude/>
        ''' 
        ''' <summary>
        ''' 	Summary of New.
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/17/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Sub New()
            MyBase.New()
        End Sub

        ''' --- New ------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Summary of New.
        ''' </summary>
        ''' <param name="TreeNode"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/17/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Sub New(ByVal TreeNode As Object)
            MyBase.New()
            Node = TreeNode
        End Sub

        ''' --- New ------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Summary of New.
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/17/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String)
            MyBase.New()
            OptionName = Name
        End Sub

        ''' --- New ------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Summary of New.
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <param name="TreeNode"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/17/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal TreeNode As Object)
            MyBase.New()
            OptionName = Name
            Node = TreeNode
        End Sub

        ''' --- New ------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Summary of New.
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <param name="Params"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/17/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal Params As String)
            MyBase.New()
            OptionName = Name
            OptionParams = Params
        End Sub

        ''' --- New ------------------------------------------------------------
        ''' 
        ''' <summary>
        ''' 	Summary of New.
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <param name="Params"></param>
        ''' <param name="TreeNode"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Campbell]	6/17/2005	Created
        ''' </history>
        ''' --- End of Comments ----------------------------------------------------
        <EditorBrowsable(EditorBrowsableState.Always)> _
        Public Sub New(ByVal Name As String, ByVal Params As String, ByVal TreeNode As Object)
            MyBase.New()
            OptionName = Name
            OptionParams = Params
            Node = TreeNode
        End Sub
    End Class

#End Region
End Namespace
