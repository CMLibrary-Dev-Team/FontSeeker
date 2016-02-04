Imports FontSeeker
Imports System.IO
''' <summary>
''' An analyzer for ASS Subtitle
''' </summary>
Public Class ASSAnalyzer
    Implements SubtitleAnalyzer


    Private Property stream As Stream

    Public Sub CloseSubtitle() Implements SubtitleAnalyzer.CloseSubtitle
        If stream IsNot Nothing Then stream.Close()
    End Sub

    Public Sub OpenSubtitle(Stream As Stream) Implements SubtitleAnalyzer.OpenSubtitle
        Me.stream = Stream
    End Sub

    Public Sub OpenSubtitle(Filename As String) Implements SubtitleAnalyzer.OpenSubtitle
        Me.stream = New FileStream(Filename, FileMode.Open)
    End Sub

    Public Function CheckSubtitle() As Boolean Implements SubtitleAnalyzer.CheckSubtitle
        Dim subFile As New StreamReader(Me.stream)
        Dim isAss As Boolean = False
        Dim line As String = subFile.ReadLine()
        While line IsNot Nothing Or isAss = False
            If line.ToLower() = "[script info]" Then isAss = True
            line = subFile.ReadLine()
        End While
        subFile.Close()
        subFile.Dispose()
        Return isAss
    End Function

    Public Function LoadFonts() As List(Of String) Implements SubtitleAnalyzer.LoadFonts
        'If CheckSubtitle() = False Then Return New List(Of String)
        Dim subFile As New StreamReader(Me.stream)
        Dim readyGetFontFlag As Boolean = False
        Dim isLoadingFontFlag As Boolean = False
        Dim fontList As New List(Of String) ' Storage to save fontlist
        Dim line As String = subFile.ReadLine
        While line IsNot Nothing
            If readyGetFontFlag = True Then 'Start to load font name
                If line.TrimStart().ToLower().StartsWith("style") Then
                    isLoadingFontFlag = True
                    'get font names
                    Dim fontname As String = line.TrimStart.Substring(5).TrimStart().Split(",")(1)
                    'add to list
                    If fontList.Contains(fontname) = False Then fontList.Add(fontname)
                ElseIf isLoadingFontFlag = True
                    Exit While
                End If
            End If
            'Means the following lines will contain font
            If line.ToLower = "[v4+ styles]" Then readyGetFontFlag = True
            line = subFile.ReadLine()
        End While
        subFile.Close()
        subFile.Dispose()
        Return fontList
    End Function

End Class
