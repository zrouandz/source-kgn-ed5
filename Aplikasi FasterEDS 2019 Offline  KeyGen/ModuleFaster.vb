Imports System.Security.Cryptography
Imports System.Text

Public Class ModuleFaster
    Friend NotInheritable Class ModuleFaster
        ' Methods
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

    End Class

End Class
