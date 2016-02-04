Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports FontSeeker
<TestClass()> Public Class SubtitleAnalyzerTest

    <TestMethod()> Public Sub TestASSAnalyzer()
        Dim ass As New ASSAnalyzer()
        ass.OpenSubtitle("z:\1.ass")
        'Console.WriteLine(ass.CheckSubtitle().ToString())
        Console.WriteLine(String.Join(Environment.NewLine, ass.LoadFonts))
    End Sub

End Class