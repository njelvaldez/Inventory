Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Collections.Generic

Module modDeclarations
    Public Const Quote As String = "'"
    Public Const ExportPath As String = "C:\Export\"
    Public Const ExpPath1 As String = "C:\Export\1\"
    Public Const ExpPath2 As String = "C:\Export\2\"
    Public Const ExpPath3 As String = "C:\Export\3\"
    Public Const ExpPath4 As String = "C:\Export\4\"
    Public Const ExpPath5 As String = "C:\Export\5\"
    Public Const ExpPath6 As String = "C:\Export\6\"
    Public Const ExpPath7 As String = "C:\Export\7\"
    Public Const ExpPath8 As String = "C:\Export\8\"
    Public Const ExpPath9 As String = "C:\Export\9\"
    Public Const ExpPath10 As String = "C:\Export\10\"
    Public Const ExpPath11 As String = "C:\Export\11\"
    Public Const ExpPath12 As String = "C:\Export\12\"
    Public GlobalItemRowNumbers As New Dictionary(Of String, String)

    Public ServerPath As String = ConfigurationManager.AppSettings.Item("ServerPath").ToString()
    Public ServerPath2 As String = ConfigurationManager.AppSettings.Item("ServerPath2").ToString()
    Public TASServerPath As String = ConfigurationManager.AppSettings.Item("TASServerPath").ToString()

    'Public Const ServerPath As String = "Initial Catalog=NewScores_test; " & _
    '                                    "Data Source    =MICdb;     " & _
    '                                    "user id        =sa;        " & _
    '                                    "password       =jynxz;     " & _
    '                                    "Pooling        =True;      " & _
    '                                    "Max Pool Size  =1000;      " & _
    '                                    "Min Pool Size  =10;        " & _
    '                                    "Connect timeout = 10000;   " & _
    '                                    "Persist Security Info=False "
    'Public Const ServerPath2 As String = "Initial Catalog=ScoresDotNet_Test; " & _
    '                                     "Data Source    =MICdb;       " & _
    '                                     "user id        =sa;          " & _
    '                                     "password       =jynxz;       " & _
    '                                     "Pooling        =True;        " & _
    '                                     "Max Pool Size  =1000;        " & _
    '                                     "Min Pool Size  =10;          " & _
    '                                     "Connect timeout = 10000;   " & _
    '                                     "Persist Security Info=False  "

    '[>>rnj_popoy**added for development testing
    'Public Const ServerPath As String = "Initial Catalog=NewScores_test; " & _
    '                                    "Data Source    =MICdb;     " & _
    '                                    "user id        =sa;        " & _
    '                                    "password       =jynxz;     " & _
    '                                    "Pooling        =True;      " & _
    '                                    "Max Pool Size  =1000;      " & _
    '                                    "Min Pool Size  =10;        " & _
    '                                    "Connect timeout = 10000;   " & _
    '                                    "Persist Security Info=False "
    'Public Const ServerPath2 As String = "Initial Catalog=ScoresDotNet_test; " & _
    '                                     "Data Source    =MICdb;       " & _
    '                                     "user id        =sa;          " & _
    '                                     "password       =jynxz;       " & _
    '                                     "Pooling        =True;        " & _
    '                                     "Max Pool Size  =1000;        " & _
    '                                     "Min Pool Size  =10;          " & _
    '                                     "Connect timeout = 10000;   " & _
    '                                     "Persist Security Info=False  "
    '07172012<<]

    'Public Const ServerPath As String = "Initial Catalog=NewScores; " & _
    '                                    "Data Source    =NMPCBACKUP; " & _
    '                                    "user id        =sa;        " & _
    '                                    "password       =jynxz;     " & _
    '                                    "Pooling        =True;        " & _
    '                                    "Max Pool Size  =1000;        " & _
    '                                    "Min Pool Size  =10;         " & _
    '                                    "Connect timeout = 10000;   " & _
    '                                    "Persist Security Info=False"
    'Public Const ServerPath2 As String = "Initial Catalog=ScoresDotNet;" & _
    '                                     "Data Source    =NMPCBACKUP;   " & _
    '                                     "user id        =sa;          " & _
    '                                     "password       =jynxz;       " & _
    '                                     "Pooling        =True;        " & _
    '                                     "Max Pool Size  =1000;        " & _
    '                                     "Min Pool Size  =10;         " & _
    '                                     "Connect timeout = 10000;   " & _
    '                                     "Persist Security Info=False  "

    'Public Const ServerPath As String = "Initial Catalog=NewScores; " & _
    '                                    "Data Source    =006DTdcbrion2; " & _
    '                                    "user id        =sa;        " & _
    '                                    "password       =jynxz;     " & _
    '                                    "Pooling        =True;        " & _
    '                                    "Max Pool Size  =1000;        " & _
    '                                    "Min Pool Size  =10;         " & _
    '                                    "Connect timeout = 10000;   " & _
    '                                    "Persist Security Info=False"
    'Public Const ServerPath2 As String = "Initial Catalog=ScoresDotNet;" & _
    '                                     "Data Source    =006DTdcbrion2;   " & _
    '                                     "user id        =sa;          " & _
    '                                     "password       =jynxz;       " & _
    '                                     "Pooling        =True;        " & _
    '                                     "Max Pool Size  =1000;        " & _
    '                                     "Min Pool Size  =10;         " & _
    '                                     "Connect timeout = 10000;   " & _
    '                                     "Persist Security Info=False  "

    'Public Const ServerPath As String = "Initial Catalog=NewScores; " & _
    '                                    "Data Source    =006DTmisDCB; " & _
    '                                    "user id        =sa;        " & _
    '                                    "password       =jynxz;     " & _
    '                                    "Pooling        =True;        " & _
    '                                    "Max Pool Size  =1000;        " & _
    '                                    "Min Pool Size  =10;         " & _
    '                                    "Connect timeout = 10000;   " & _
    '                                    "Persist Security Info=False"
    'Public Const ServerPath2 As String = "Initial Catalog=ScoresDotNet;" & _
    '                                     "Data Source    =006DTmisDCB;   " & _
    '                                     "user id        =sa;          " & _
    '                                     "password       =jynxz;       " & _
    '                                     "Pooling        =True;        " & _
    '                                     "Max Pool Size  =1000;        " & _
    '                                     "Min Pool Size  =10;         " & _
    '                                     "Connect timeout = 10000;   " & _
    '                                     "Persist Security Info=False  "

    Public Filds(100) As Object
    Public VarArr(1000) As String
    Public Fld0 As String, Fld1 As String, Fld2 As String, Fld3 As String, Fld4 As String
    Public Fld5 As String, Fld6 As String, Fld7 As String, Fld8 As String, Fld9 As String
    Public Fld10 As String, Fld11 As String, Fld12 As String, Fld13 As String
    Public Fld14 As String, Fld15 As String, Fld16 As VariantType, Fld17 As VariantType
    Public Fld18 As String, Fld19 As String, Fld20 As String
    Public TBMPicturePath As String
    Public DBMPicturePath As String
    Public GrdCols As Integer
    Public Itm_EditMode As Boolean = False
    Public PMR_EditMode As Boolean = False
    Public DSM_EditMode As Boolean = False
    Public btnSw As Boolean = False, ItmClsd As Boolean = False
    Public cancelProcess As Boolean = False
    Public MyFrmItm As Object
    Public z As String, gUserID As String, gUserName As String, gRole As String
    Public i As Integer, ChildCtr As Integer = 0
    Public TF As Boolean, chiralDist As Boolean, MHdist As Boolean
    Public AppPath As String, CommDate As String, CommDate2 As String
    Public gCurrUser As String, territoryXCode As String
    Public StordProcName As String, gCode As String, gDesc As String
    Public SPparam As Boolean = False, CloseFrm As Boolean = False

    'Public Const ServerPath As String = "Initial Catalog=NewScores;Data Source=vista;user id=sa;password=jynxz; Max Pool Size=75; Min Pool Size=5;Persist Security Info=False"
    'Public Const ServerPath2 As String = "Initial Catalog=ScoresDotNet;Data Source=vista;user id=sa;password=jynxz; Max Pool Size=75; Min Pool Size=5;Persist Security Info=False"

    '[>>rnj_popoy**added
    Public _s0District, _s1District, _s2District, _s3District, _s4District, _s5District, _s6District, _
        _s7District, _s8District, _s9District, _s10District, _s11District, _gDistrictCode As String

    Public _s0TerritoryArea, _s1TerritoryArea, _s2TerritoryArea, _s3TerritoryArea, _
        _s4TerritoryArea, _s5TerritoryArea, _s6TerritoryArea, _s7TerritoryArea, _s8TerritoryArea As String

    Public _s0TerritoryAreaBrick, _s1TerritoryAreaBrick, _s2TerritoryAreaBrick, _s3TerritoryAreaBrick, _
        _s4TerritoryAreaBrick, _s5TerritoryAreaBrick, _s6TerritoryAreaBrick As String

    Public _s0TerritoryAreaPMR, _s1TerritoryAreaPMR, _s2TerritoryAreaPMR, _s3TerritoryAreaPMR, _
        _s4TerritoryAreaPMR, _s5TerritoryAreaPMR As String

    Public _bConfirmed As Boolean = False, _bConfirmedDC As Boolean = False, _
        _bConfirmedDN As Boolean = False, _bConfirmedDim As Boolean = False, _
        _bConfirmedMED As Boolean = False, _bConfirmedMSD As Boolean = False, _
        _bConfirmedSD As Boolean = False, _bConfirmedED As Boolean = False, _
        _bConfirmedSDDuplicated As Boolean = False, _bConfirmedAllEntry As Boolean = False, _
        _bConfirmedEndDateMax As Boolean = False
    '10012012<<]

End Module
