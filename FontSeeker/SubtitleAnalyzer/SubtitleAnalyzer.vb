Public Interface SubtitleAnalyzer
    Sub OpenSubtitle(Filename As String)
    Function LoadFonts() As List(Of String)
    Function CheckSubtitle() As Boolean
End Interface
