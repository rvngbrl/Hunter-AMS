Public Class Printing
    Private Sub PrintDocument1_PrintPage(sender As Object, e As Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim ReportFont As Font = New Drawing.Font("Nirmala", 12)
        e.Graphics.DrawString("My Example report Title", ReportFont, Brushes.Chocolate, 100, 100)
        e.Graphics.DrawString("My Body title", ReportFont, Brushes.Chocolate, 100, 135)
    End Sub

    Private Sub PrintPreviewControl1_Click(sender As Object, e As EventArgs) Handles PrintPreviewControl1.Click

    End Sub

End Class