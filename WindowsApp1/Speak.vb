Imports System.Speech.Synthesis
Public Class Speak
    Private Sub New()
    End Sub

    Private Shared ss As System.Speech.Synthesis.SpeechSynthesizer
    Private Shared p As Prompt
    'Private Shared pOld As Prompt
    Public Shared Sub Text(ByVal text As String)
        If String.IsNullOrEmpty(text) Then Return
        Static pOld As Prompt
        If ss Is Nothing Then
            ss = New Speech.Synthesis.SpeechSynthesizer()
            ss.SetOutputToDefaultAudioDevice()

        End If
        p = New Prompt(text)
        If pOld IsNot Nothing AndAlso Not pOld.IsCompleted Then ss.SpeakAsyncCancel(pOld)
        pOld = p
        ss.SpeakAsync(p)
        'ss.SpeakAsync(text)
    End Sub
End Class
