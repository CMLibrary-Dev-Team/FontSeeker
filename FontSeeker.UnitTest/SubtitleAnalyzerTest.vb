Imports System.Text
Imports System.IO
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports FontSeeker
<TestClass()> Public Class SubtitleAnalyzerTest

    <TestMethod()> Public Sub TestASSAnalyzer()
        For Each item As String In Directory.GetFiles("z:\", "*.ass", SearchOption.TopDirectoryOnly)
            Dim ass As New ASSAnalyzer()
            ass.OpenSubtitle(item)
            'Console.WriteLine(ass.CheckSubtitle().ToString())
            Console.WriteLine(String.Join(Environment.NewLine, ass.LoadFonts))
            Console.WriteLine()
            ass.CloseSubtitle()
        Next
    End Sub

End Class