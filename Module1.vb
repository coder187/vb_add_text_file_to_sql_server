Imports System.Data.SqlClient
Imports System.IO
Module Module1


    Sub Main()
        Dim conStr As String = "Server=SERVER;Database=DB;Trusted_Connection=True;"
        Dim dbCnn As SqlConnection = New SqlConnection(conStr)

        Dim fileReader As StreamReader
        fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\\users\\zxcv\\downloads\\colors.txt")
        Dim stringReader As String
        Dim i As Integer = 0
        Dim ErrCount As Integer = 0

        dbCnn.Open()

        Do
            stringReader = fileReader.ReadLine()
            If Len(stringReader) > 0 Then
                i = i + 1
                If InsertRecord(dbCnn, stringReader) < 1 Then
                    ErrCount = ErrCount + 1
                End If
            End If
        Loop Until (stringReader Is Nothing)
        dbCnn.Close()
        MsgBox(i & " records inserted with " & ErrCount & " Error(s).")
    End Sub

    Function InsertRecord(dbCnn As SqlConnection, sStringToInsert As String) As Integer
        Try
            Dim cmd As SqlCommand = New SqlCommand("insert into colors (c1,c2) values(1," & Chr(39) & sStringToInsert & Chr(39) & ")", dbCnn)
            Return cmd.ExecuteNonQuery()
        Catch ex As Exception
            Return 0
        End Try
    End Function
End Module
