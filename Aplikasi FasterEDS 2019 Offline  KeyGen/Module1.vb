Module Module1
    Private Declare Function WriteProcessMemory Lib "KERNEL32" (ByVal Handle As Integer, ByVal Address As Integer, ByRef Value As Long, ByVal Size As Integer, ByRef BystesWritten As Integer) As Long
    Private Declare Function ReadProcessMemory Lib "KERNEL32" (ByVal Handle As Integer, ByVal Address As Integer, ByRef Value As Long, ByVal Size As Integer, ByRef BystesWritten As Integer) As Long
    Public Declare Function ReadMemoryByte Lib "KERNEL32" Alias "ReadProcessMemory" (ByVal Handle As Integer, ByVal Address As Integer, ByRef Value As Byte, Optional ByVal Size As Integer = 1, Optional ByRef BytesRead As Integer = 0) As Byte
    Public Declare Function ReadMemoryShort Lib "KERNEL32" Alias "ReadProcessMemory" (ByVal Handle As Integer, ByVal Address As Integer, ByRef Value As Byte, Optional ByVal Size As Integer = 1, Optional ByRef BytesRead As Integer = 0) As Short
    Public Declare Function ReadMemoryInteger Lib "KERNEL32" Alias "ReadProcessMemory" (ByVal Handle As Integer, ByVal Address As Integer, ByRef Value As Integer, Optional ByVal Size As Integer = 4, Optional ByRef BytesRead As Integer = 0) As Integer
    Public Declare Function ReadMemoryLong Lib "KERNEL32" Alias "ReadProcessMemory" (ByVal Handle As Integer, ByVal Address As Integer, ByRef Value As Byte, Optional ByVal Size As Integer = 1, Optional ByRef BytesRead As Integer = 0) As Long
    Public Declare Function ReadMemoryFloat Lib "KERNEL32" Alias "ReadProcessMemory" (ByVal Handle As Integer, ByVal Address As Integer, ByRef Value As Byte, Optional ByVal Size As Integer = 1, Optional ByRef BytesRead As Integer = 0) As Single
    Public Declare Function ReadMemoryDouble Lib "KERNEL32" Alias "ReadProcessMemory" (ByVal Handle As Integer, ByVal Address As Integer, ByRef Value As Byte, Optional ByVal Size As Integer = 1, Optional ByRef BytesRead As Integer = 0) As Double

    Public Sub WriteMemoryByte(ByVal ProcessName As String, ByVal Address As Integer, ByVal Value As Byte)
        Dim Open = Process.GetProcessesByName(ProcessName)
        If Open.Length = 0 Then
            Exit Sub
        End If
        WriteProcessMemory(Open(0).Handle, Address, Value, 1, 0)
    End Sub

    Public Sub WriteMemoryShort(ByVal ProcessName As String, ByVal Address As Integer, ByVal Value As Short)
        Dim Open = Process.GetProcessesByName(ProcessName)
        If Open.Length = 0 Then
            Exit Sub
        End If
        WriteProcessMemory(Open(0).Handle, Address, Value, 2, 0)
    End Sub

    Public Sub WriteMemoryInteger(ByVal ProcessName As String, ByVal Address As Integer, ByVal Value As Integer)
        Dim Open = Process.GetProcessesByName(ProcessName)
        If Open.Length = 0 Then
            Exit Sub
        End If
        WriteProcessMemory(Open(0).Handle, Address, Value, 4, 0)
    End Sub

    Public Sub WriteMemoryLong(ByVal ProcessName As String, ByVal Address As Integer, ByVal Value As Long)
        Dim Open = Process.GetProcessesByName(ProcessName)
        If Open.Length = 0 Then
            Exit Sub
        End If
        WriteProcessMemory(Open(0).Handle, Address, Value, 8, 0)
    End Sub

    Public Sub WriteMemoryFloat(ByVal ProcessName As String, ByVal Address As Integer, ByVal Value As Single)
        Dim Open = Process.GetProcessesByName(ProcessName)
        If Open.Length = 0 Then
            Exit Sub
        End If
        WriteProcessMemory(Open(0).Handle, Address, Value, 8, 0)
    End Sub

    Public Sub WriteMemoryDouble(ByVal ProcessName As String, ByVal Address As Integer, ByVal Value As Double)
        Dim Open = Process.GetProcessesByName(ProcessName)
        If Open.Length = 0 Then
            Exit Sub
        End If
        WriteProcessMemory(Open(0).Handle, Address, Value, 8, 0)
    End Sub

    Public Sub WriteMemoryASM(ByVal ProcessName As String, ByVal Address As Integer, ByVal Array As Byte())
        Dim Open = Process.GetProcessesByName(ProcessName)
        If Open.Length = 0 Then
            Exit Sub
        End If
        For Value As Byte = LBound(Array) To UBound(Array)
            WriteProcessMemory(Open(0).Handle, Address + Value, Array(Value), 1, 0)
        Next
    End Sub

    Public Sub WriteMemoryPointer(ByVal ProcessName As String, ByVal Pointer As Integer, ByVal Value As Integer, ByVal ParamArray OFFSet As Integer())
        Dim Open = Process.GetProcessesByName(ProcessName)
        If Open.Length = 0 Then
            Exit Sub
        End If
        Dim Handle As Integer = Process.GetProcessesByName(ProcessName)(0).Handle
        For Each I As Integer In OFFSet
            ReadMemoryInteger(Handle, Pointer, Pointer)
            Pointer += I
        Next
        WriteProcessMemory(Open(0).Handle, Pointer, Value, 4, 0)
    End Sub

    Public Sub ReadMemoryPointer(ByVal ProcessName As String, ByVal Pointer As Integer, ByRef Value As Integer, ByVal ParamArray OFFSet As Integer())
        If Process.GetProcessesByName(ProcessName).Length = 0 Then
            Exit Sub
        End If
        Dim Handle As Integer = Process.GetProcessesByName(ProcessName)(0).Handle
        For Each I As Integer In OFFSet
            ReadMemoryInteger(Handle, Pointer, Pointer)
            Pointer += I
        Next
        ReadMemoryInteger(Handle, Pointer, Value)
    End Sub
End Module
