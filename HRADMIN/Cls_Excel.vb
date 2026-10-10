Imports System.Data
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json
Imports System.Web

Public Class Cls_Excel
    Dim myStream As Stream = Nothing
    Dim openFileDialog1 As New OpenFileDialog()
    Dim strPath As String = ""
    Dim strQ As String = ""
    Public PathReport As String = "D:\Leave\LeaveReport" '"D:\LeaveReport.xls"
    Public PahtMaster As String = "\\192.168.0.160\hr\Master-Excel-Leave-Report\Master-Leave-Report.xls"
    'Public PahtMaster As String = "Master\Master-Leave-Report.xls"
    Public Function OpenExcelFile() As String


        openFileDialog1.InitialDirectory = "D:\"
        openFileDialog1.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            myStream = openFileDialog1.OpenFile()
            If (myStream IsNot Nothing) Then
                strPath = openFileDialog1.FileName
            End If
        End If

        OpenExcelFile = strPath
    End Function

    Public Sub ImportMembers(path As String)

        SetAllConnectionDB()

        ClsInsert = New Cls_Insert
        ClsEncodMD5 = New Cls_FcnEncodMD5
        Dim empCode As String, empName As String, empSurname As String, empSex As String, empPass As String, empEmail As String
        Dim empPcode As String, empPosition As String, empSection As String, empDept As String, empDeptFlow As String
        Dim empStartWork As String, empBirthday As String, empExp As Integer, BusPosition As String
        Dim remainAL As Double, remainBL As Double, remainBDL As Double
        Dim remainSL As Double, remainFL As Double, remainPL As Double
        Dim remainM1L As Double, remainM2L As Double, remainM3L As Double
        Dim remainVCL As Double, remainAL_RATIO As Double, remainAL_EMERGENCY As Double, remainWFH As Double
        Dim remainSPL As Double, ALFromYear As Double, ALThisYear As Double, BLThisYear As Double
        Dim passPro As String, empGroup As String
        Dim checkImport As Boolean = False
        'Try

        Dim MyConnection As System.Data.OleDb.OleDbConnection
        'Dim dataSet As System.Data.DataSet
        Dim dataTable As DataTable
        Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
        Dim listEmpData As New List(Of String)
        Dim insertCommands As New List(Of String)()
        Dim insertCommandsSmart As New List(Of String)()
        Dim mfgGroupMembers As New List(Of Dictionary(Of String, Object))()
        Dim engineerGroupMembers As New List(Of Dictionary(Of String, Object))()
        Dim engineerSync As New Cls_EngineerGroupSync
        Try
            MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;")
            MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [member$]", MyConnection)

            'dataSet = New System.Data.DataSet
            'MyCommand.Fill(dataSet)
            dataTable = New DataTable
            MyCommand.Fill(dataTable)



            For Each record In dataTable.Rows
                empCode = Trim(record("empCode").ToString).ToUpperInvariant()
                If empCode = "" Then
                    Exit For
                End If

                strQ = ""
                strQ = "select empCode from member where empCode ='" & empCode & "'"
                'If Not ClsGetData.GetData(Connection, strQ) Then
                empName = Trim(record("empName"))
                empSurname = Trim(record("empSurname"))
                empSex = Trim(record("empSex"))
                empPass = ClsEncodMD5.EncodePasswordMD5(Trim(record("Password ( ID Card )")))
                empEmail = IIf(Trim(record("empEmail").ToString()) = "", "-", Trim(record("empEmail").ToString))
                empPcode = Trim(record("empPcode"))
                empPosition = Trim(record("empPosition"))
                empSection = Trim(record("empSection"))
                empDept = Trim(record("empDept"))
                engineerSync.AddMember(engineerGroupMembers, empCode, empDept, empSection)
                If UCase(Trim(empDept)) = "MFG" OrElse UCase(Trim(empDept)) = "MFG." Then
                    Dim mfgGroupMember As New Dictionary(Of String, Object)
                    mfgGroupMember("USER_NAME") = empCode
                    mfgGroupMember("EMP_DEPT") = empDept
                    mfgGroupMembers.Add(mfgGroupMember)
                End If
                empDeptFlow = Trim(record("deptFlow"))
                empStartWork = Trim(Format(record("empStartwork (dd-mm-yyyy)"), "yyyy-MM-dd"))
                empBirthday = Trim(Format(record("empBirthday (dd-mm-yyyy)"), "yyyy-MM-dd"))
                empExp = If(Not IsDBNull(record("empExp")), Trim(record("empExp")), 0)
                BusPosition = If(Not IsDBNull(record("Bus-Position")), record("Bus-Position").ToString, "-")
                remainAL = If(Not IsDBNull(record("remainAL")), Trim(record("remainAL")), 0)
                remainBL = If(Not IsDBNull(record("remainBL")), Trim(record("remainBL")), 0)
                remainBDL = If(Not IsDBNull(record("remainBDL")), Trim(record("remainBDL")), 0)
                remainSL = If(Not IsDBNull(record("remainSL")), Trim(record("remainSL")), 0)
                remainFL = If(Not IsDBNull(record("remainFL")), Trim(record("remainFL")), 0)
                remainPL = If(Not IsDBNull(record("remainPL")), Trim(record("remainPL")), 0)
                remainM1L = If(Not IsDBNull(record("remainM1L")), Trim(record("remainM1L")), 0)
                remainM2L = If(Not IsDBNull(record("remainM2L")), Trim(record("remainM2L")), 0)
                remainM3L = If(Not IsDBNull(record("remainM3L")), Trim(record("remainM3L")), 0)
                remainSPL = If(Not IsDBNull(record("remainSPL")), Trim(record("remainSPL")), 0)

                'ALFromYear = Trim(record("AL from Year"))
                'ALThisYear = Trim(record("AL This Year"))
                'BLThisYear = Trim(record("BL This Year"))
                passPro = UCase(Trim(record("Pass Pro")))
                empGroup = If(Not IsDBNull(record("Group")), UCase(Trim(record("Group"))), "")
                'TotalALThisYear = ALFromYear + ALThisYear

                '03-Oct-22 Jiraphat T. Add type leave
                remainVCL = If(Not IsDBNull(record("VCL")), Trim(record("VCL")), 0)
                remainAL_RATIO = If(Not IsDBNull(record("AL RATIO")), Trim(record("AL RATIO")), 0)
                remainAL_EMERGENCY = If(Not IsDBNull(record("AL EMERGENCY")), Trim(record("AL EMERGENCY")), 0)
                remainWFH = If(Not IsDBNull(record("WFH")), Trim(record("WFH")), 0)

                Dim rawresp As String = ""
                Dim titleCourteryName As String
                Dim genderId As String

                If (empSex = "Male" Or empSex = "male") Then
                    genderId = 1
                Else
                    genderId = 2
                End If

                If (passPro = "No" Or passPro = "NO") Then
                    passPro = 0
                Else
                    passPro = 1
                End If

                If (empName.Contains("MR.") Or empName.Contains("Mr.")) Then
                    titleCourteryName = 1
                ElseIf (empName.Contains("MRS.") Or empName.Contains("Mrs.")) Then
                    titleCourteryName = 2
                Else
                    titleCourteryName = 3
                End If

                'Remove 2024-11-14

                'Dim prefixName As String = "^MRS.|MS.|MR."
                'empName = Regex.Replace(empName, prefixName, String.Empty)

                rawresp = "{""EMP_CODE"":""" & empCode & """,""EMP_NAME"":""" & empName & """,""EMP_SURNAME"":""" & empSurname & """,""EMP_SEX"":""" & empSex & """"
                rawresp = rawresp & ", ""EMP_PASS"":""" & empPass & """,""EMP_EMAIL"":""" & empEmail & """,""EMP_PCODE"":""" & empPcode & """,""EMP_POSITION"":""" & empPosition & """"
                rawresp = rawresp & ", ""EMP_SECTION"":""" & empSection & """,""EMP_DEPT"":""" & empDept & """,""EMP_DEPT_FLOW"":""" & empDeptFlow & """,""EMP_START_WORK"":""" & empStartWork & """"
                rawresp = rawresp & ", ""EMP_BIRTHDAY"":""" & empBirthday & """,""EMP_EXP"":""" & empExp & """,""BUS_POSITION"":""" & BusPosition & """"
                rawresp = rawresp & ", ""LIST_REMAIN_DAY"": [{ ""REMAIN_AL"" : """ & remainAL & """ } , {""REMAIN_BL"" : """ & remainBL & """  }, {""REMAIN_BDL"" : """ & remainBDL & """ }"
                rawresp = rawresp & ", { ""REMAIN_SL"":""" & remainSL & """ } , { ""REMAIN_FL"":""" & remainFL & """ } , { ""REMAIN_PL"":""" & remainPL & """} ,{ ""REMAIN_SPL"":""" & remainSPL & """}"
                rawresp = rawresp & ", { ""REMAIN_M1L"":""" & remainM1L & """ } , {""REMAIN_M2L"":""" & remainM2L & """ } , {""REMAIN_M3L"":""" & remainM3L & """}]"
                rawresp = rawresp & ", ""TITLE_OF_COURTESY_ID"":""" & titleCourteryName & """ , ""GENDER_ID"":""" & genderId & """ , ""COMPANY_ALPHABET"":""" & "FFT" & """"
                rawresp = rawresp & ", ""PASS_PRO"":""" & passPro & """ , ""EMP_GROUP"":""" & empGroup & """ , ""COMPANY_ID"":""" & 1 & """}"

                'listEmpData.Add(rawresp)

                strQ = ""
                strQ = strQ & "  Insert into member(empCode,empName,empSurname,empSex"
                strQ = strQ & " ,empPass,empEmail,empPcode,empPosition,empSection,empDept"
                strQ = strQ & " ,deptFlow,empStartwork,empBirthday,empExp,bus_position,emp_group) "
                strQ = strQ & "  Values('" & empCode & "','" & empName & "','"
                strQ = strQ & empSurname & "','" & empSex & "','" & empPass & "','" & empEmail & "','"
                strQ = strQ & empPcode & "','" & empPosition & "','" & empSection & "','" & empDept & "','"
                strQ = strQ & empDeptFlow & "','" & empStartWork & "','" & empBirthday & "','" & empExp & "','" & BusPosition & "','" & empGroup & "');"



                ' ########### อย่าลืมมาบลอออก ###########
                ' ClsInsert.Insert(Connection, strQ)
                insertCommands.Add(strQ)
                'SetAllConnectionDB_Smart()
                'ClsInsert.Insert(Connection, strQ)

                'checkImport = True
                'Else
                '    MsgBox("empCode : " & empCode & " มีอยู่แล้วไม่สามารถเพิ่ม empCode นี้เข้าไปได้")
                'End If


            Next


            SetAllConnectionDB_Smart()

            For Each record In dataTable.Rows
                empCode = Trim(record("empCode").ToString).ToUpperInvariant()
                If empCode = "" Then
                    Exit For
                End If

                strQ = ""
                strQ = "select empCode from member where empCode ='" & empCode & "'"
                'If Not ClsGetData.GetData(Connection, strQ) Then
                empName = Trim(record("empName"))
                empSurname = Trim(record("empSurname"))
                empSex = Trim(record("empSex"))
                empPass = ClsEncodMD5.EncodePasswordMD5(Trim(record("Password ( ID Card )")))
                empEmail = IIf(Trim(record("empEmail").ToString()) = "", "-", Trim(record("empEmail").ToString))
                empPcode = Trim(record("empPcode"))
                empPosition = Trim(record("empPosition"))
                empSection = Trim(record("empSection"))
                empDept = Trim(record("empDept"))
                empDeptFlow = Trim(record("deptFlow"))
                empStartWork = Trim(Format(record("empStartwork (dd-mm-yyyy)"), "yyyy-MM-dd"))
                empBirthday = Trim(Format(record("empBirthday (dd-mm-yyyy)"), "yyyy-MM-dd"))
                empExp = If(Not IsDBNull(record("empExp")), Trim(record("empExp")), 0)
                BusPosition = If(Not IsDBNull(record("Bus-Position")), record("Bus-Position").ToString, "-")
                remainAL = If(Not IsDBNull(record("remainAL")), Trim(record("remainAL")), 0)
                remainBL = If(Not IsDBNull(record("remainBL")), Trim(record("remainBL")), 0)
                remainBDL = If(Not IsDBNull(record("remainBDL")), Trim(record("remainBDL")), 0)
                remainSL = If(Not IsDBNull(record("remainSL")), Trim(record("remainSL")), 0)
                remainFL = If(Not IsDBNull(record("remainFL")), Trim(record("remainFL")), 0)
                remainPL = If(Not IsDBNull(record("remainPL")), Trim(record("remainPL")), 0)
                remainM1L = If(Not IsDBNull(record("remainM1L")), Trim(record("remainM1L")), 0)
                remainM2L = If(Not IsDBNull(record("remainM2L")), Trim(record("remainM2L")), 0)
                remainM3L = If(Not IsDBNull(record("remainM3L")), Trim(record("remainM3L")), 0)
                remainSPL = If(Not IsDBNull(record("remainSPL")), Trim(record("remainSPL")), 0)

                'ALFromYear = Trim(record("AL from Year"))
                '    ALThisYear = Trim(record("AL This Year"))
                '    BLThisYear = Trim(record("BL This Year"))
                passPro = UCase(Trim(record("Pass Pro")))
                empGroup = If(Not IsDBNull(record("Group")), UCase(Trim(record("Group"))), "")
                'TotalALThisYear = ALFromYear + ALThisYear

                '03-Oct-22 Jiraphat T. Add type leave
                remainVCL = If(Not IsDBNull(record("VCL")), Trim(record("VCL")), 0)
                remainAL_RATIO = If(Not IsDBNull(record("AL RATIO")), Trim(record("AL RATIO")), 0)
                remainAL_EMERGENCY = If(Not IsDBNull(record("AL EMERGENCY")), Trim(record("AL EMERGENCY")), 0)
                remainWFH = If(Not IsDBNull(record("WFH")), Trim(record("WFH")), 0)

                Dim rawresp As String = ""
                Dim titleCourteryName As String
                Dim genderId As String

                If (empSex = "Male" Or empSex = "male") Then
                    genderId = 1
                Else
                    genderId = 2
                End If

                If (passPro = "No" Or passPro = "NO") Then
                    passPro = 0
                Else
                    passPro = 1
                End If

                If (empName.Contains("MR.") Or empName.Contains("Mr.")) Then
                    titleCourteryName = 1
                ElseIf (empName.Contains("MRS.") Or empName.Contains("Mrs.")) Then
                    titleCourteryName = 2
                Else
                    titleCourteryName = 3
                End If

                'Remove 2024-11-14

                'Dim prefixName As String = "^MRS.|MS.|MR."
                'empName = Regex.Replace(empName, prefixName, String.Empty)

                rawresp = "{""EMP_CODE"":""" & empCode & """,""EMP_NAME"":""" & empName & """,""EMP_SURNAME"":""" & empSurname & """,""EMP_SEX"":""" & empSex & """"
                rawresp = rawresp & ", ""EMP_PASS"":""" & empPass & """,""EMP_EMAIL"":""" & empEmail & """,""EMP_PCODE"":""" & empPcode & """,""EMP_POSITION"":""" & empPosition & """"
                rawresp = rawresp & ", ""EMP_SECTION"":""" & empSection & """,""EMP_DEPT"":""" & empDept & """,""EMP_DEPT_FLOW"":""" & empDeptFlow & """,""EMP_START_WORK"":""" & empStartWork & """"
                rawresp = rawresp & ", ""EMP_BIRTHDAY"":""" & empBirthday & """,""EMP_EXP"":""" & empExp & """,""BUS_POSITION"":""" & BusPosition & """"
                rawresp = rawresp & ", ""LIST_REMAIN_DAY"": [{ ""REMAIN_AL"" : """ & remainAL & """ } , {""REMAIN_BL"" : """ & remainBL & """  }, {""REMAIN_BDL"" : """ & remainBDL & """ }"
                rawresp = rawresp & ", { ""REMAIN_SL"":""" & remainSL & """ } , { ""REMAIN_FL"":""" & remainFL & """ } , { ""REMAIN_PL"":""" & remainPL & """} ,{ ""REMAIN_SPL"":""" & remainSPL & """}"
                rawresp = rawresp & ", { ""REMAIN_M1L"":""" & remainM1L & """ } , {""REMAIN_M2L"":""" & remainM2L & """ } , {""REMAIN_M3L"":""" & remainM3L & """}]"
                rawresp = rawresp & ", ""TITLE_OF_COURTESY_ID"":""" & titleCourteryName & """ , ""GENDER_ID"":""" & genderId & """ , ""COMPANY_ALPHABET"":""" & "FFT" & """"
                rawresp = rawresp & ", ""PASS_PRO"":""" & passPro & """ , ""EMP_GROUP"":""" & empGroup & """ , ""COMPANY_ID"":""" & 1 & """}"

                listEmpData.Add(rawresp)

                strQ = ""
                strQ = strQ & "  Insert into member_fed(empCode,empName,empSurname,empSex"
                strQ = strQ & " ,empPass,empEmail,empPcode,empPosition,empSection,empDept"
                strQ = strQ & " ,deptFlow,empStartwork,empBirthday,empExp,bus_position,emp_group) "
                strQ = strQ & "  Values('" & empCode & "','" & empName & "','"
                strQ = strQ & empSurname & "','" & empSex & "','" & empPass & "','" & empEmail & "','"
                strQ = strQ & empPcode & "','" & empPosition & "','" & empSection & "','" & empDept & "','"
                strQ = strQ & empDeptFlow & "','" & empStartWork & "','" & empBirthday & "','" & empExp & "','" & BusPosition & "','" & empGroup & "');"

                'SetAllConnectionDB()
                'ClsInsert.Insert(Connection, strQ)

                ' ClsInsert.Insert(Connection, strQ)
                insertCommandsSmart.Add(strQ)

                'Else
                '    MsgBox("empCode : " & empCode & " มีอยู่แล้วไม่สามารถเพิ่ม empCode นี้เข้าไปได้")
                'End If


            Next

            checkImport = True

            'If checkImport Then
            '    MsgBox("ทำการ Import ข้อมูลเรียบร้อย")
            'End If

            MyConnection.Close()

        Catch Ex As Exception

            MsgBox(" Program error : " & Ex.Message)
            Exit Sub
        End Try

        '03-Oct-22 Jiraphat T. Add type leave
        If checkImport Then


            Dim ResultData = Post_request(listEmpData)
            Dim statusRes As Boolean = ResultData.Item("Status")
            Dim ErrorRes = ResultData.Item("Message")

            If (statusRes = False) Then



                MsgBox("Insert Data to API server error : " & ErrorRes)

                Exit Sub

            Else

                SetAllConnectionDB()
                Dim dbLeaveImportSucceeded As Boolean = ClsInsert.ExecuteTransaction(Connection, insertCommands)

                If Not dbLeaveImportSucceeded Then
                    MsgBox("Import to db_leave failed. person and department groups were not synced.")
                    Exit Sub
                End If

                SetAllConnectionDB_Smart()
                Dim personImportSucceeded As Boolean = ClsInsert.ExecuteTransaction(Connection, insertCommandsSmart)

                If Not personImportSucceeded Then
                    MsgBox("Import to person failed. Department groups were not synced.")
                    Exit Sub
                End If

                Dim mfgSync As New Cls_MfgGroupSync
                Dim mfgSyncSucceeded As Boolean = mfgSync.SyncMembers(mfgGroupMembers)
                Dim engineerSyncSucceeded As Boolean = engineerSync.SyncMembers(engineerGroupMembers)
                If mfgSyncSucceeded = False Then
                    MsgBox("Member import succeeded, but MFG Group sync failed : " & mfgSync.LastErrorMessage)
                ElseIf mfgSync.LastWarningMessage <> "" Then
                    MsgBox("Sync MFG Group Warning : " & mfgSync.LastWarningMessage)
                End If

                If engineerSyncSucceeded = False Then
                    MsgBox("Member import succeeded, but Engineer Group sync failed : " & engineerSync.LastErrorMessage)
                ElseIf engineerSync.LastWarningMessage <> "" Then
                    MsgBox("Sync Engineer Group Warning : " & engineerSync.LastWarningMessage)
                End If

                If Not mfgSyncSucceeded OrElse Not engineerSyncSucceeded Then Exit Sub

                MsgBox("ทำการ Import ข้อมูลเรียบร้อย")

            End If







        End If

    End Sub

    Private Function Post_request(listEmpData)

        Dim all1s As New List(Of String)

        For i As Integer = 0 To listEmpData.Count - 1
            If listEmpData(i) IsNot Nothing AndAlso listEmpData(i).Trim() <> "" Then
                all1s.Add(listEmpData(i))
            End If
        Next


        ' Join array of JSON strings and wrap in square brackets
        ' Dim jsonArrayString As String = "[" & String.Join(",", all1s) & "]"
        Dim jsonArrayString As String = "[" & String.Join(",", all1s.ToArray()) & "]"
        ' URL-encode it since it's form-urlencoded
        ' Dim postData As String = "DATA=" & HttpUtility.UrlEncode(jsonArrayString)
        Dim postData As String = "DATA=" & Uri.EscapeDataString(jsonArrayString)


        Dim tempCookies As New CookieContainer
        Dim encoding As New UTF8Encoding
        Dim byteData As Byte() = encoding.GetBytes(postData)

        Dim postReq As HttpWebRequest = DirectCast(WebRequest.Create(iUrl), HttpWebRequest)
        postReq.Method = "POST"
        postReq.KeepAlive = True
        postReq.ContentType = "application/x-www-form-urlencoded"
        postReq.UserAgent = "Mozilla/5.0..."
        postReq.ContentLength = byteData.Length

        Using postreqstream As Stream = postReq.GetRequestStream()
            postreqstream.Write(byteData, 0, byteData.Length)
        End Using

        Dim postresponse As HttpWebResponse = DirectCast(postReq.GetResponse(), HttpWebResponse)
        tempCookies.Add(postresponse.Cookies)

        Dim resultData As String
        Using postreqreader As New StreamReader(postresponse.GetResponseStream())
            resultData = postreqreader.ReadToEnd()
        End Using

        ' Deserialize directly if response is valid JSON
        Dim jsonResult As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(resultData)

        Return jsonResult

    End Function

    Private Function Post_request__(listEmpData)

        Dim all1s As String = ""

        For i As Integer = 0 To listEmpData.Count - 1
            If listEmpData(i) <> "" Then

                all1s = all1s & If(all1s = "", "", ",") & listEmpData(i)

            End If
        Next

        Dim postData As String = $"DATA=[{all1s}]"
        Dim tempCookies As New CookieContainer
        Dim encoding As New UTF8Encoding
        Dim byteData As Byte() = encoding.GetBytes(postData)

        Dim postReq As HttpWebRequest = DirectCast(WebRequest.Create(iUrl), HttpWebRequest)
        postReq.Method = "POST"
        postReq.KeepAlive = True

        postReq.ContentType = "application/x-www-form-urlencoded"

        postReq.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; ru; rv:1.9.2.3) Gecko/20100401 Firefox/4.0 (.NET CLR 3.5.30729)"
        postReq.ContentLength = byteData.Length

        Dim postreqstream As Stream = postReq.GetRequestStream()
        postreqstream.Write(byteData, 0, byteData.Length)
        postreqstream.Close()
        Dim postresponse As HttpWebResponse

        postresponse = DirectCast(postReq.GetResponse(), HttpWebResponse)
        tempCookies.Add(postresponse.Cookies)
        Dim postreqreader As New StreamReader(postresponse.GetResponseStream())
        Dim resultData As String = postreqreader.ReadToEnd

        Dim tokenJson = JsonConvert.SerializeObject(resultData)

        Dim jsonResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(resultData)
        'Dim firstItem = jsonResult.Item("Status")


        Return jsonResult

    End Function



    'Public Sub ImportExcelFileRemainLeave()


    '    openFileDialog1.InitialDirectory = "D:\"
    '    openFileDialog1.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*"
    '    openFileDialog1.FilterIndex = 2
    '    openFileDialog1.RestoreDirectory = True

    '    If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
    '        'Try
    '        myStream = openFileDialog1.OpenFile()
    '        If (myStream IsNot Nothing) Then
    '            strPath = openFileDialog1.FileName
    '            'ImportRemainLeave(strPath)

    '        End If
    '        If (myStream IsNot Nothing) Then
    '            myStream.Close()
    '        End If
    '    End If
    'End Sub

    Public Sub ImportRemainLeave(path As String)
        SetAllConnectionDB()

        ClsUpdateData = New Cls_UpdateData
        Dim empCode As String, empName As String, empSurname As String
        Dim remainAL As Double, remainBL As Double, remainBDL As Double
        Dim remainSL As Double, remainFL As Double, remainPL As Double
        Dim remainM1L As Double, remainM2L As Double, remainM3L As Double
        Dim remainSPL As Double ', ALFromYear As Double, ALThisYear As Double

        'Try

        Dim MyConnection As System.Data.OleDb.OleDbConnection
        'Dim dataSet As System.Data.DataSet
        Dim dataTable As DataTable
        Dim MyCommand As System.Data.OleDb.OleDbDataAdapter

        ' Try
        MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;")
        MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection)

        'dataSet = New System.Data.DataSet
        'MyCommand.Fill(dataSet)
        dataTable = New DataTable
        MyCommand.Fill(dataTable)
        frmSetRemainLeave.dataGridRemainLeave.Rows.Clear()
        frmSetRemainLeave.dataGridRemainLeave.ColumnCount = 5
        frmSetRemainLeave.dataGridRemainLeave.Columns(0).Name = "EMPCODE"
        frmSetRemainLeave.dataGridRemainLeave.Columns(1).Name = "NAME"
        frmSetRemainLeave.dataGridRemainLeave.Columns(2).Name = "SURNAME"
        frmSetRemainLeave.dataGridRemainLeave.Columns(3).Name = "TYPE_LEAVE"
        frmSetRemainLeave.dataGridRemainLeave.Columns(4).Name = "REMAIN"

        frmSetRemainLeave.dataGridRemainLeave.Columns(0).Width = 100
        frmSetRemainLeave.dataGridRemainLeave.Columns(1).Width = 100
        frmSetRemainLeave.dataGridRemainLeave.Columns(2).Width = 100
        frmSetRemainLeave.dataGridRemainLeave.Columns(3).Width = 100
        frmSetRemainLeave.dataGridRemainLeave.Columns(4).Width = 100

        With frmSetRemainLeave.dataGridRemainLeave.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Navy
            .ForeColor = Color.White
            .Font = New Font(frmSetRemainLeave.dataGridRemainLeave.Font, FontStyle.Bold)
        End With

        For Each record In dataTable.Rows
            empCode = Trim(record("empCode")).ToString
            empName = Trim(record("Name")).ToString
            empSurname = Trim(record("Surname")).ToString
            remainAL = CDbl(Trim(record("AL")).ToString)
            remainBL = CDbl(Trim(record("BL")).ToString)
            remainBDL = CDbl(Trim(record("BDL")).ToString)
            remainSL = CDbl(Trim(record("SL")).ToString)
            remainFL = CDbl(Trim(record("FL")).ToString)
            remainPL = CDbl(Trim(record("PL")).ToString)
            remainM1L = CDbl(Trim(record("M1L")).ToString)
            remainM2L = CDbl(Trim(record("M2L")).ToString)
            remainM3L = CDbl(Trim(record("M3L")).ToString)
            remainSPL = CDbl(Trim(record("SPL")).ToString)

            ' Udpate multirows and multicolumns http://stuporglue.org/update-multiple-rows-at-once-with-different-values-in-mysql/
            strQ = ""
            strQ = strQ & " UPDATE remain_leave as rem ,set_pass_pro pass, al_bl_status ab "
            strQ = strQ & " SET remain = CASE "
            strQ = strQ & "     WHEN rem.type_leave = 'AL'  THEN '" & remainAL & "'"
            strQ = strQ & "     WHEN rem.type_leave = 'BL'  THEN '" & remainBL & "'"
            strQ = strQ & "     WHEN rem.type_leave = 'BDL'  THEN '" & remainBDL & "'"
            strQ = strQ & "     WHEN rem.type_leave = 'SL'  THEN '" & remainSL & "'"
            strQ = strQ & "     WHEN rem.type_leave = 'FL'  THEN '" & remainFL & "'"
            strQ = strQ & "     WHEN rem.type_leave = 'PL'  THEN '" & remainPL & "'"
            strQ = strQ & "     WHEN rem.type_leave = 'M1L'  THEN '" & remainM1L & "'"
            strQ = strQ & "     WHEN rem.type_leave = 'M2L'  THEN '" & remainM2L & "'"
            strQ = strQ & "     WHEN rem.type_leave = 'M3L'  THEN '" & remainM3L & "'"
            strQ = strQ & "     WHEN rem.type_leave = 'SPL'  THEN '" & remainSPL & "'"
            strQ = strQ & " ELSE remain"
            strQ = strQ & " End, "
            strQ = strQ & "  pass.pass_pro ='YES', ab.al_in_this_year = '" & remainAL & "', ab.bl_in_this_year = '" & remainBL & "'"
            strQ = strQ & " where rem.empCode = '" & empCode & "'"
            strQ = strQ & " and pass.empCode = '" & empCode & "'"
            strQ = strQ & " and ab.empCode = '" & empCode & "'"


            ClsUpdateData.Update(Connection, strQ)

            frmSetRemainLeave.dataGridRemainLeave.Rows.Add(empCode, empName, empSurname, "AL", remainAL)
            frmSetRemainLeave.dataGridRemainLeave.Rows.Add(empCode, empName, empSurname, "BL", remainBL)
            frmSetRemainLeave.dataGridRemainLeave.Rows.Add(empCode, empName, empSurname, "BDL", remainBDL)
            frmSetRemainLeave.dataGridRemainLeave.Rows.Add(empCode, empName, empSurname, "SL", remainSL)
            frmSetRemainLeave.dataGridRemainLeave.Rows.Add(empCode, empName, empSurname, "FL", remainFL)
            frmSetRemainLeave.dataGridRemainLeave.Rows.Add(empCode, empName, empSurname, "PL", remainPL)
            frmSetRemainLeave.dataGridRemainLeave.Rows.Add(empCode, empName, empSurname, "M1L", remainM1L)
            frmSetRemainLeave.dataGridRemainLeave.Rows.Add(empCode, empName, empSurname, "M2L", remainM2L)
            frmSetRemainLeave.dataGridRemainLeave.Rows.Add(empCode, empName, empSurname, "M3L", remainM3L)
            frmSetRemainLeave.dataGridRemainLeave.Rows.Add(empCode, empName, empSurname, "SPL", remainSPL)


            'strQ = ""
            'strQ = strQ & " update al_bl_status set "
            'strQ = strQ & "  al_in_this_year = '" & remainAL & "', bl_in_this_year = '" & remainBL & "'"
            'strQ = strQ & " where empCode ='" & empCode & "'"
            'ClsUpdateData.Update(Connection, strQ)
        Next
        MsgBox("ทำการ Import ข้อมูลเรียบร้อย")
        MyConnection.Close()
        'Catch Ex As Exception
        'Catch Ex As Exception
        ' MsgBox(" Program error : " & Ex.Message)
        ' Exit Sub
        'End Try
    End Sub


    Public Sub ImportHolidays(path As String, ByRef GridView As DataGridView)
        SetAllConnectionDB()

        ClsInsert = New Cls_Insert
        ClsGetData = New Cls_GetData
        ClsSQLDateFormat = New Cls_SQLDateFormat
        Dim Holiday As String, Title As String, HolidayCode As String
        'Dim DateTemp As Date
        'Try

        Dim MyConnection As System.Data.OleDb.OleDbConnection
        'Dim dataSet As System.Data.DataSet
        Dim dataTable As DataTable
        Dim MyCommand As System.Data.OleDb.OleDbDataAdapter

        ' Try
        MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;")
        MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [Holiday$]", MyConnection)

        'dataSet = New System.Data.DataSet
        'MyCommand.Fill(dataSet)
        dataTable = New DataTable
        MyCommand.Fill(dataTable)
        GridView.ColumnCount = 2
        GridView.Columns(0).Name = "Holiday"
        GridView.Columns(1).Name = "Title"
        GridView.Columns(2).Name = "Hodliday Code"


        'frmSetRemainLeave.dataGridRemainLeave.Columns(0).Width = 100
        'frmSetRemainLeave.dataGridRemainLeave.Columns(1).Width = 100


        With frmSetRemainLeave.dataGridRemainLeave.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Navy
            .ForeColor = Color.White
            .Font = New Font(frmSetRemainLeave.dataGridRemainLeave.Font, FontStyle.Bold)
        End With

        For Each record In dataTable.Rows
            Holiday = Trim(ClsSQLDateFormat.SQLDateFormat(record("Holiday").ToString()))
            'DateTemp = Holiday
            Title = Trim(record("Title")).ToString
            HolidayCode = Trim(record("Holiday Code")).ToString

            strQ = ""
            strQ = strQ & "select day_holiday from holidays where day_holiday = '" & Holiday & "'"

            If Not ClsGetData.GetData(Connection, strQ) Then
                strQ = ""
                strQ = strQ & " Insert into holidays(day_holiday,Title_holiday,holiday_code) values('" & Holiday & "','" & Title & "','" & HolidayCode & "')"
                ClsInsert.Insert(Connection, strQ)
            End If
        Next

        SetAllConnectionDB_Smart()
        For Each record In dataTable.Rows
            Holiday = Trim(ClsSQLDateFormat.SQLDateFormat(record("Holiday").ToString()))
            'DateTemp = Holiday
            Title = Trim(record("Title")).ToString
            HolidayCode = Trim(record("Holiday Code")).ToString

            strQ = ""
            strQ = strQ & "select day_holiday from holidays where day_holiday = '" & Holiday & "'"

            If Not ClsGetData.GetData(Connection, strQ) Then
                strQ = ""
                strQ = strQ & " Insert into holidays(day_holiday,Title_holiday,holiday_code) values('" & Holiday & "','" & Title & "','" & HolidayCode & "')"
                ClsInsert.Insert(Connection, strQ)
            End If
        Next

        releaseObject(MyCommand)
        MsgBox("ทำการ Import ข้อมูลเรียบร้อย")
        MyConnection.Close()
        'Catch Ex As Exception
        'Catch Ex As Exception
        ' MsgBox(" Program error : " & Ex.Message)
        ' Exit Sub
        'End Try
    End Sub


    Public xlApp As Microsoft.Office.Interop.Excel.Application
    Public xlWorkBook As Microsoft.Office.Interop.Excel.Workbook

    Public xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
    Public xlRange As Microsoft.Office.Interop.Excel.Range
    Public misValue As Object = System.Reflection.Missing.Value
    Public Overridable Sub ExportExcel(DatagridView As DataGridView)

        Dim rowsExcel As Integer = 2
        Dim columnsExcel As Integer = 1
        Dim Value As String
        Dim arrayTemp As String() = {}
        Dim randomNumber As New Random

        xlApp = New Microsoft.Office.Interop.Excel.Application
        'xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkBook = xlApp.Workbooks.Add(misValue) 'PathtMaster
        xlWorkSheet = xlWorkBook.Sheets("sheet1")
        xlRange = xlWorkSheet.Range("F2")
        For Each foundFile As String In My.Computer.FileSystem.GetFiles("D:\Leave", FileIO.SearchOption.SearchAllSubDirectories, "*.*")
            My.Computer.FileSystem.DeleteFile(foundFile, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        Next
        For i = 0 To DatagridView.RowCount - 1
            For j = 0 To DatagridView.ColumnCount - 3
                'For k As Integer = 1 To DatagridView.Columns.Count
                'xlWorkSheet.Cells(1, k) = DatagridView.Columns(k - 1).HeaderText
                Value = Trim(DatagridView.Rows(i).Cells(j).Value)
                arrayTemp = Value.Split(vbCrLf)


                ' remove wrap text in Column Leave Date Columns 5  
                If j = 5 Then
                    xlWorkSheet.Cells(rowsExcel, columnsExcel) = arrayTemp(0) '& " - " & Trim(arrayTemp(1))
                    xlRange.Offset(i, 0).WrapText = False
                Else
                    xlWorkSheet.Cells(rowsExcel, columnsExcel) = Value
                End If
                'Next
                columnsExcel = columnsExcel + 1
            Next
            columnsExcel = 1
            rowsExcel = rowsExcel + 1
        Next
        Dim strSaveas As String = PathReport & CStr(randomNumber.Next(1, 1000)) & ".xls"
        If IO.File.Exists(strSaveas) = True Then
            'Kill(PathReport)
            strSaveas = PathReport & CStr(randomNumber.Next(1, 5000)) & ".xls"
            xlWorkSheet.SaveAs(strSaveas)
        Else
            xlWorkSheet.SaveAs(strSaveas)
        End If

        xlWorkBook.Close()
        xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)

        Dim res As MsgBoxResult
        res = MsgBox("ทำการ Export ข้อมูลเรียบร้อย ไฟล์ถูกบันทึกไว้ที่ " & strSaveas & ", คูณต้องการที่จะเปิดไฟล์หรือไม่?", MsgBoxStyle.YesNo)
        If (res = MsgBoxResult.Yes) Then
            Process.Start(strSaveas)
        End If

    End Sub

    Public Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
End Class


