Imports System.Security.Cryptography
Imports System.Text
Imports System.Runtime.CompilerServices

Public Class Form1
    Public Shared Function Decrypt(ByVal [text] As String, ByVal password As String) As String
        Dim managed As New RijndaelManaged
        Dim provider As New MD5CryptoServiceProvider
        Dim destinationArray As Byte() = New Byte(&H20 - 1) {}
        Dim sourceArray As Byte() = provider.ComputeHash(Encoding.ASCII.GetBytes(password))
        Array.Copy(sourceArray, 0, destinationArray, 0, &H10)
        Array.Copy(sourceArray, 0, destinationArray, 15, &H10)
        managed.Key = destinationArray
        managed.Mode = CipherMode.ECB
        Dim transform As ICryptoTransform = managed.CreateDecryptor
        Dim inputBuffer As Byte() = Convert.FromBase64String([text])
        Return Encoding.ASCII.GetString(transform.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length))
    End Function
    Public Shared Function Encrypt(ByVal [text] As String, ByVal password As String) As String
        Dim managed As New RijndaelManaged
        Dim provider As New MD5CryptoServiceProvider
        Dim destinationArray As Byte() = New Byte(&H20 - 1) {}
        Dim sourceArray As Byte() = provider.ComputeHash(Encoding.ASCII.GetBytes(password))
        Array.Copy(sourceArray, 0, destinationArray, 0, &H10)
        Array.Copy(sourceArray, 0, destinationArray, 15, &H10)
        managed.Key = destinationArray
        managed.Mode = CipherMode.ECB
        Dim transform As ICryptoTransform = managed.CreateEncryptor
        Dim bytes As Byte() = Encoding.ASCII.GetBytes([text])
        Return Convert.ToBase64String(transform.TransformFinalBlock(bytes, 0, bytes.Length))
    End Function
    Public Function GetDriveSerialNumber() As String
        Dim DriveSerial As Integer
        'Create a FileSystemObject object
        Dim fso As Object = CreateObject("Scripting.FileSystemObject")
        Dim Drv As Object = fso.GetDrive(fso.GetDriveName(Application.StartupPath))
        With Drv
            If .IsReady Then
                DriveSerial = .SerialNumber
            Else    '"Drive Not Ready!"
                DriveSerial = -1
            End If
        End With
        Return DriveSerial.ToString("X2")
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim str2 As String = Form1.Encrypt(Me.TextBox1.Text, "#@!zX780HgFFr0%56ZZZWERT*^")
        TextBox2.Text = str2
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Clipboard.SetText(TextBox2.Text)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form2.ShowDialog()
    End Sub
End Class


