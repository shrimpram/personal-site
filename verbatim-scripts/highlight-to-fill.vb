Sub ConvertHighlightsToFills()
    Dim rng As Range
    Dim char As Range
    Dim highlightColor As Long

    ' Check if there is a selection
    If Selection.Type = wdSelectionIP Then
        MsgBox "No text selected. Please select the text you want to modify.", vbExclamation
        Exit Sub
    End If

    ' Set the range to the current selection
    Set rng = Selection.Range

    ' Loop through each character in the selection
    For Each char In rng.Characters
        ' Check if the character is highlighted
        If char.HighlightColorIndex <> wdNoHighlight Then
            ' Get the RGB color based on the highlight index
            highlightColor = HighlightColorToRGB(char.HighlightColorIndex)

            ' Set the background color to the highlight color
            char.Shading.BackgroundPatternColor = highlightColor

            ' Remove the highlight
            char.HighlightColorIndex = wdNoHighlight
        End If
    Next char

    ' Display a confirmation message box
    MsgBox "Done!", vbInformation

    ' Clean up
    Set rng = Nothing
    Set char = Nothing
End Sub

Function HighlightColorToRGB(HighlightIndex As Integer) As Long
    Select Case HighlightIndex
        Case wdYellow
            HighlightColorToRGB = RGB(255, 255, 0)
        Case wdBrightGreen
            HighlightColorToRGB = RGB(0, 255, 0)
        Case wdGray25
            HighlightColorToRGB = RGB(210, 210, 210)
        Case wdTurquoise
            HighlightColorToRGB = RGB(0, 255, 255)
        Case wdPink
            HighlightColorToRGB = RGB(255, 0, 255)
        Case wdBlue
            HighlightColorToRGB = RGB(0, 0, 255)
        Case wdRed
            HighlightColorToRGB = RGB(255, 0, 0)
        Case wdDarkBlue
            HighlightColorToRGB = RGB(0, 0, 128)
        Case wdTeal
            HighlightColorToRGB = RGB(0, 128, 128)
        Case wdGreen
            HighlightColorToRGB = RGB(0, 128, 0)
        Case wdViolet
            HighlightColorToRGB = RGB(128, 0, 128)
        Case wdDarkRed
            HighlightColorToRGB = RGB(128, 0, 0)
        Case wdDarkYellow
            HighlightColorToRGB = RGB(128, 128, 0)
        Case wdGray50
            HighlightColorToRGB = RGB(128, 128, 128)
        Case wdBlack
            HighlightColorToRGB = RGB(0, 0, 0)
        Case Else
            HighlightColorToRGB = RGB(255, 255, 255) ' Default to white for unknown colors
    End Select
End Function
