Imports System.IO

Public Interface SubtitleAnalyzer
    Sub OpenSubtitle(Filename As String)
    Sub CloseSubtitle()
    Sub OpenSubtitle(Stream As Stream)
    Function LoadFonts() As List(Of String)
    Function CheckSubtitle() As Boolean
End Interface
