Imports System.Data.SqlClient
Module InventoryReportHelper
    Public Function StkcardPrevbal(fromdateval As DateTime, itemdescval As String, expfromval As DateTime, exptoval As DateTime) As DataSet
        Dim retval As DataSet
        Dim RemoteDataSet As New DataSet
        Try
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(3) As SqlParameter
            Dim fromdate As New SqlParameter("@fromdate", SqlDbType.DateTime, 10) : fromdate.Direction = ParameterDirection.Input : fromdate.Value = fromdateval : Params(0) = fromdate
            Dim itemdesc As New SqlParameter("@itemdesc", SqlDbType.VarChar, 50) : itemdesc.Direction = ParameterDirection.Input : itemdesc.Value = itemdescval : Params(1) = itemdesc
            Dim expfrom As New SqlParameter("@expfrom", SqlDbType.DateTime, 10) : expfrom.Direction = ParameterDirection.Input : expfrom.Value = expfromval : Params(2) = expfrom
            Dim expto As New SqlParameter("@expto", SqlDbType.DateTime, 10) : expto.Direction = ParameterDirection.Input : expto.Value = exptoval : Params(3) = expto
            BusinessObject.Sub_Show(ServerPath2, "StkcardPrevbal", CommandType.StoredProcedure, RemoteDataSet, "Table1", Params)
            retval = RemoteDataSet
        Catch ex As Exception
        End Try
        Return retval
    End Function

    Public Function StkcardReportInsert(itemcodeval As String, fromdateval As DateTime, prevbalval As Decimal) As Boolean
        Dim retval As Boolean = True
        Dim RemoteDataSet As New DataSet
        Try
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(2) As SqlParameter
            Dim itemcode As New SqlParameter("@itemcode", SqlDbType.VarChar, 10) : itemcode.Direction = ParameterDirection.Input : itemcode.Value = itemcodeval : Params(0) = itemcode
            Dim fromdate As New SqlParameter("@fromdate", SqlDbType.DateTime, 10) : fromdate.Direction = ParameterDirection.Input : fromdate.Value = fromdateval : Params(1) = fromdate
            Dim prevbal As New SqlParameter("@prevbal", SqlDbType.Money, 10) : prevbal.Direction = ParameterDirection.Input : prevbal.Value = prevbalval : Params(2) = prevbal
            BusinessObject.Sub_Show(ServerPath2, "StkcardReportInsert", CommandType.StoredProcedure, RemoteDataSet, "Table1", Params)
        Catch ex As Exception
            MsgBox("Error in InventoryReportHelper.StkcardReportInsert : " & ex.Message)
            retval = False
        End Try
        Return retval
    End Function

    Public Function StkcardReportDeleteAll() As Boolean
        Dim retval As Boolean = True
        Dim RemoteDataSet As New DataSet
        Try
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            BusinessObject.Sub_Show(ServerPath2, "StkcardReportDeleteAll", CommandType.StoredProcedure, RemoteDataSet, "Table1")
        Catch ex As Exception
            MsgBox("Error in InventoryReportHelper.StkcardReportDeleteAll : " & ex.Message)
            retval = False
        End Try
        Return retval
    End Function

 
    Public Function StkcardReportForecastUpdate(itemcodeval As String, fcstdateval As DateTime, forecastval As Decimal, moaveval As Decimal) As Boolean
        Dim retval As Boolean = True
        Dim RemoteDataSet As New DataSet
        Try
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(3) As SqlParameter
            Dim itemcode As New SqlParameter("@itemcode", SqlDbType.VarChar, 10) : itemcode.Direction = ParameterDirection.Input : itemcode.Value = itemcodeval : Params(0) = itemcode
            Dim monthyear As New SqlParameter("@monthyear", SqlDbType.DateTime, 10) : monthyear.Direction = ParameterDirection.Input : monthyear.Value = fcstdateval : Params(1) = monthyear
            Dim forecast As New SqlParameter("@forecast", SqlDbType.Money, 12) : forecast.Direction = ParameterDirection.Input : forecast.Value = forecastval : Params(2) = forecast
            Dim moave As New SqlParameter("@moave", SqlDbType.Money, 12) : moave.Direction = ParameterDirection.Input : moave.Value = moaveval : Params(3) = moave
            BusinessObject.Sub_Show(ServerPath2, "StkcardReportForecastUpdate", CommandType.StoredProcedure, RemoteDataSet, "Table1", Params)
        Catch ex As Exception
            MsgBox("Error in InventoryReportHelper.StkcardReportForecastUpdate : " & ex.Message)
            retval = False
        End Try
        Return retval
    End Function

    Public Function GetAndUpdateIntransit(fromdateval As DateTime, todateval As DateTime, itemdescval As String) As Boolean
        Dim retval As Boolean = True
        Dim itemcode As String = ""
        Dim intransit As Decimal = 0.0
        Dim monthctr As Integer = 0
        Dim deliverydate As DateTime
        Dim RemoteDataSet As New DataSet
        Try
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(2) As SqlParameter
            Dim fromdate As New SqlParameter("@fromdate", SqlDbType.DateTime, 10) : fromdate.Direction = ParameterDirection.Input : fromdate.Value = fromdateval : Params(0) = fromdate
            Dim todate As New SqlParameter("@todate", SqlDbType.DateTime, 10) : todate.Direction = ParameterDirection.Input : todate.Value = todateval : Params(1) = todate
            Dim itemdesc As New SqlParameter("@itemdesc", SqlDbType.VarChar, 50) : itemdesc.Direction = ParameterDirection.Input : itemdesc.Value = itemdescval : Params(2) = itemdesc
            BusinessObject.Sub_Show(ServerPath2, "PODetailSelect", CommandType.StoredProcedure, RemoteDataSet, "Table1", Params)
            For Each drow As DataRow In RemoteDataSet.Tables(0).Rows
                Try
                    itemcode = drow("itemcode")
                    intransit = drow("qty")
                    deliverydate = drow("deliverydate")
                    StkcardReportIntransitUpdate(itemcode, deliverydate, intransit)
                Catch ex As Exception
                    MsgBox("Error in InventoryReportHelper.GetAndUpdateIntransit: " & ex.Message)
                End Try
            Next
            retval = False
        Catch ex As Exception
        End Try
        Return retval
    End Function
    Public Function StkcardReportIntransitUpdate(itemcodeval As String, deliverydateval As DateTime, intransitval As Decimal) As Boolean
        Dim retval As Boolean = True
        Dim RemoteDataSet As New DataSet
        Try
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(2) As SqlParameter
            Dim itemcode As New SqlParameter("@itemcode", SqlDbType.VarChar, 10) : itemcode.Direction = ParameterDirection.Input : itemcode.Value = itemcodeval : Params(0) = itemcode
            Dim monthyear As New SqlParameter("@monthyear", SqlDbType.DateTime, 10) : monthyear.Direction = ParameterDirection.Input : monthyear.Value = deliverydateval : Params(1) = monthyear
            Dim intransit As New SqlParameter("@intransit", SqlDbType.Money, 12) : intransit.Direction = ParameterDirection.Input : intransit.Value = intransitval : Params(2) = intransit
            BusinessObject.Sub_Show(ServerPath2, "StkcardReportIntransitUpdate", CommandType.StoredProcedure, RemoteDataSet, "Table1", Params)
        Catch ex As Exception
            MsgBox("Error in InventoryReportHelper.StkcardReportIntransitUpdate : " & ex.Message)
            retval = False
        End Try
        Return retval
    End Function
    Public Function StkcardReportInsertRecords(ds As DataSet, fromdate As DateTime, todate As DateTime) As Boolean
        Dim retval As Boolean = True
        Dim itemcode As String = ""
        Dim prevbal As Decimal = 0.0
        Dim monthctr As Integer = 0
        Try
            For Each drow As DataRow In ds.Tables(0).Rows
                Try
                    itemcode = drow("itemcode")
                    prevbal = drow("endqty")
                    StkcardReportInsert(itemcode, fromdate, prevbal)
                    monthctr = 1
                    While DateAdd(DateInterval.Month, monthctr, fromdate) <= todate
                        StkcardReportInsert(itemcode, DateAdd(DateInterval.Month, monthctr, fromdate), 0)
                        monthctr = monthctr + 1
                    End While
                Catch ex As Exception
                    MsgBox("Error in InventoryReportHelper.StkcardReportInsertRecord: " & ex.Message)
                End Try
            Next
        Catch ex As Exception
            retval = False
        End Try
        Return retval
    End Function

    Private Function MonthlyAverage(ByVal dataSet As DataSet, itemcode As String) As Decimal
        Dim retval As Decimal = 0.0
        Try
            ' Presumes a DataTable named "Orders" that has a column named "Total."
            Dim table As DataTable
            table = dataSet.Tables(0)

            ' Declare an object variable.
            Dim sumObject As Object
            'sumObject = table.Compute("avg(qty)", "Itemcode = '" & itemcode & "'")
            sumObject = table.Compute("avg(forecast)", "Itemcode = '" & itemcode & "'")
            retval = sumObject
        Catch ex As Exception

        End Try
        Return retval
    End Function

    Public Function StkcardReportComputeBalances(fromdateval As DateTime, todateval As DateTime, itemdescval As String, _percentfactor As Integer) As Boolean
        Dim retval As Boolean = True
        Dim previtemcode As String = ""
        Dim itemcode As String = ""
        Dim prevbal As Decimal = 0.0
        Dim forecast As Decimal = 0.0
        Dim begbal As Decimal = 0.0
        Dim intransit As Decimal = 0.0
        Dim endbal As Decimal = 0.0
        Dim monthyear As DateTime
        Dim moave As Decimal = 0.0
        Dim RemoteDataSet As New DataSet
        Dim percentfactor As Decimal = _percentfactor / 100.0
        Try
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            BusinessObject.Sub_Show(ServerPath2, "StkcardReportSelect", CommandType.StoredProcedure, RemoteDataSet, "Table1")
            For Each drow As DataRow In RemoteDataSet.Tables(0).Rows
                Try
                    itemcode = drow("itemcode")
                    If previtemcode <> itemcode Then
                        'then it is new record/item
                        prevbal = drow("prevbal")
                    Else
                        prevbal = endbal
                    End If
                    forecast = drow("forecast")
                    begbal = prevbal - forecast
                    intransit = drow("intransit")
                    endbal = begbal + intransit
                    monthyear = drow("monthyear")
                    moave = MonthlyAverage(RemoteDataSet, itemcode)
                    'no need to compute here, moave = moave + (moave * percentfactor)
                    StkcardReportUpdateBalances(itemcode, prevbal, begbal, endbal, monthyear, moave)
                    StkcardReportUpdateReorderQty(itemcode, monthyear)
                    StkcardReportUpdateNegativeQty()
                    StkcardReportUpdateStockStatus()
                Catch ex As Exception
                    MsgBox("Error in InventoryReportHelper.ComputeBalances: " & ex.Message)
                End Try
                previtemcode = drow("itemcode")
            Next
            retval = False
        Catch ex As Exception
        End Try
        Return retval
    End Function
    Public Function StkcardReportUpdateBalances(itemcodeval As String, prevbalval As Decimal, begbalval As Decimal, endbalval As Decimal, monthyearval As DateTime, moaveval As Decimal) As Boolean
        Dim retval As Boolean = True
        Dim RemoteDataSet As New DataSet
        Try
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(5) As SqlParameter
            Dim itemcode As New SqlParameter("@itemcode", SqlDbType.VarChar, 10) : itemcode.Direction = ParameterDirection.Input : itemcode.Value = itemcodeval : Params(0) = itemcode
            Dim prevbal As New SqlParameter("@prevbal", SqlDbType.Money, 12) : prevbal.Direction = ParameterDirection.Input : prevbal.Value = prevbalval : Params(1) = prevbal
            Dim begbal As New SqlParameter("@begbal", SqlDbType.Money, 12) : begbal.Direction = ParameterDirection.Input : begbal.Value = begbalval : Params(2) = begbal
            Dim endbal As New SqlParameter("@endbal", SqlDbType.Money, 12) : endbal.Direction = ParameterDirection.Input : endbal.Value = endbalval : Params(3) = endbal
            Dim monthyear As New SqlParameter("@monthyear", SqlDbType.DateTime, 10) : monthyear.Direction = ParameterDirection.Input : monthyear.Value = monthyearval : Params(4) = monthyear
            Dim moave As New SqlParameter("@moave", SqlDbType.Money, 12) : moave.Direction = ParameterDirection.Input : moave.Value = moaveval : Params(5) = moave
            BusinessObject.Sub_Show(ServerPath2, "StkcardReportUpdateBalances", CommandType.StoredProcedure, RemoteDataSet, "Table1", Params)
        Catch ex As Exception
            MsgBox("Error in InventoryReportHelper.StkcardReportUpdateBalances : " & ex.Message)
            retval = False
        End Try
        Return retval
    End Function
    Public Function StkcardReportUpdateReorderQty(itemcodeval As String, monthyearval As DateTime) As Boolean
        Dim retval As Boolean = True
        Dim RemoteDataSet As New DataSet
        Try
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(1) As SqlParameter
            Dim itemcode As New SqlParameter("@itemcode", SqlDbType.VarChar, 10) : itemcode.Direction = ParameterDirection.Input : itemcode.Value = itemcodeval : Params(0) = itemcode
            Dim monthyear As New SqlParameter("@monthyear", SqlDbType.DateTime, 10) : monthyear.Direction = ParameterDirection.Input : monthyear.Value = monthyearval : Params(1) = monthyear
            BusinessObject.Sub_Show(ServerPath2, "StkcardReportUpdateReorderQty", CommandType.StoredProcedure, RemoteDataSet, "Table1", Params)
        Catch ex As Exception
            MsgBox("Error in InventoryReportHelper.StkcardReportUpdateReorderQty : " & ex.Message)
            retval = False
        End Try
        Return retval
    End Function
    Public Function StkcardReportUpdateNegativeQty() As Boolean
        Dim retval As Boolean = True
        Dim RemoteDataSet As New DataSet
        Try
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            BusinessObject.Sub_Show(ServerPath2, "StkcardReportUpdateNegativeQty", CommandType.StoredProcedure, RemoteDataSet, "Table1")
        Catch ex As Exception
            MsgBox("Error in InventoryReportHelper.StkcardReportUpdateNegativeQty : " & ex.Message)
            retval = False
        End Try
        Return retval
    End Function
    Public Function StkcardReportUpdateStockStatus() As Boolean
        Dim retval As Boolean = True
        Dim RemoteDataSet As New DataSet
        Try
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            BusinessObject.Sub_Show(ServerPath2, "StkcardReportUpdateStockStatus", CommandType.StoredProcedure, RemoteDataSet, "Table1")
        Catch ex As Exception
            MsgBox("Error in InventoryReportHelper.StkcardReportUpdateStockStatus : " & ex.Message)
            retval = False
        End Try
        Return retval
    End Function
    Public Function GetAndUpdateForecast(fromdateval As DateTime, todateval As DateTime, itemdescval As String, _percentfactor As Integer) As Boolean
        Dim retval As Boolean = True
        Dim itemcode As String = ""
        Dim forecast As Decimal = 0.0
        Dim monthctr As Integer = 0
        Dim fcstdate As DateTime
        Dim moave As Decimal
        Dim RemoteDataSet As New DataSet
        Dim percentfactor As Decimal = _percentfactor / 100.0
        Try
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(2) As SqlParameter
            Dim fromdate As New SqlParameter("@fromdate", SqlDbType.DateTime, 10) : fromdate.Direction = ParameterDirection.Input : fromdate.Value = fromdateval : Params(0) = fromdate
            Dim todate As New SqlParameter("@todate", SqlDbType.DateTime, 10) : todate.Direction = ParameterDirection.Input : todate.Value = todateval : Params(1) = todate
            Dim itemdesc As New SqlParameter("@itemdesc", SqlDbType.VarChar, 50) : itemdesc.Direction = ParameterDirection.Input : itemdesc.Value = itemdescval : Params(2) = itemdesc
            BusinessObject.Sub_Show(ServerPath2, "ForecastSelect", CommandType.StoredProcedure, RemoteDataSet, "Table1", Params)
            For Each drow As DataRow In RemoteDataSet.Tables(0).Rows
                Try
                    itemcode = drow("itemcode")
                    forecast = drow("qty") + drow("qty") * percentfactor
                    fcstdate = drow("fcstdate")
                    'computed already with balances moave = MonthlyAverage(RemoteDataSet, itemcode)
                    StkcardReportForecastUpdate(itemcode, fcstdate, forecast, moave)
                Catch ex As Exception
                    MsgBox("Error in InventoryReportHelper.StkcardReportInsertRecord: " & ex.Message)
                End Try
            Next
            retval = False
        Catch ex As Exception
        End Try
        Return retval
    End Function
    Public Function GetAndUpdateSales(fromdateval As DateTime, todateval As DateTime, itemdescval As String, _percentfactor As Integer) As Boolean
        Dim retval As Boolean = True
        Dim itemcode As String = ""
        Dim forecast As Decimal = 0.0
        Dim monthctr As Integer = 0
        Dim fcstdate As DateTime
        Dim moave As Decimal
        Dim RemoteDataSet As New DataSet
        Dim percentfactor As Decimal = _percentfactor / 100.0
        Try
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(2) As SqlParameter
            Dim fromdate As New SqlParameter("@fromdate", SqlDbType.DateTime, 10) : fromdate.Direction = ParameterDirection.Input : fromdate.Value = fromdateval : Params(0) = fromdate
            Dim todate As New SqlParameter("@todate", SqlDbType.DateTime, 10) : todate.Direction = ParameterDirection.Input : todate.Value = todateval : Params(1) = todate
            Dim itemdesc As New SqlParameter("@itemdesc", SqlDbType.VarChar, 50) : itemdesc.Direction = ParameterDirection.Input : itemdesc.Value = itemdescval : Params(2) = itemdesc
            BusinessObject.Sub_Show(ServerPath2, "DirectSalesSelect", CommandType.StoredProcedure, RemoteDataSet, "Table1", Params)
            For Each drow As DataRow In RemoteDataSet.Tables(0).Rows
                Try
                    itemcode = drow("itemcode")
                    forecast = drow("qty") + drow("qty") * percentfactor
                    fcstdate = drow("fcstdate")
                    'average already computed with balances moave = MonthlyAverage(RemoteDataSet, itemcode)
                    StkcardReportForecastUpdate(itemcode, fcstdate, forecast, moave)
                Catch ex As Exception
                    MsgBox("Error in InventoryReportHelper.StkcardReportInsertRecord: " & ex.Message)
                End Try
            Next
            retval = False
        Catch ex As Exception
        End Try
        Return retval
    End Function

    Public Function GetAndUpdateSalesandFcst(fromdateval As DateTime, todateval As DateTime, itemdescval As String, _percentfactor As Integer) As Boolean
        Dim retval As Boolean = True
        Dim itemcode As String = ""
        Dim forecast As Decimal = 0.0
        Dim monthctr As Integer = 0
        Dim fcstdate As DateTime
        Dim moave As Decimal
        Dim RemoteDataSet As New DataSet
        Dim percentfactor As Decimal = _percentfactor / 100.0
        Try
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(2) As SqlParameter
            Dim fromdate As New SqlParameter("@fromdate", SqlDbType.DateTime, 10) : fromdate.Direction = ParameterDirection.Input : fromdate.Value = fromdateval : Params(0) = fromdate
            Dim todate As New SqlParameter("@todate", SqlDbType.DateTime, 10) : todate.Direction = ParameterDirection.Input : todate.Value = todateval : Params(1) = todate
            Dim itemdesc As New SqlParameter("@itemdesc", SqlDbType.VarChar, 50) : itemdesc.Direction = ParameterDirection.Input : itemdesc.Value = itemdescval : Params(2) = itemdesc
            BusinessObject.Sub_Show(ServerPath2, "ForecastSalesSelect", CommandType.StoredProcedure, RemoteDataSet, "Table1", Params)
            For Each drow As DataRow In RemoteDataSet.Tables(0).Rows
                Try
                    itemcode = drow("itemcode")
                    forecast = drow("qty") + drow("qty") * percentfactor
                    fcstdate = drow("fcstdate")
                    'average already computed with balances moave = MonthlyAverage(RemoteDataSet, itemcode)
                    StkcardReportForecastUpdate(itemcode, fcstdate, forecast, moave)
                Catch ex As Exception
                    MsgBox("Error in InventoryReportHelper.StkcardReportInsertRecord: " & ex.Message)
                End Try
            Next
            retval = False
        Catch ex As Exception
        End Try
        Return retval
    End Function
End Module
