Imports Microsoft.Win32
Imports Microsoft.Win32.Registry

Module RegistryAccess
    Public Sub WriteKey(parentkey As String, keyname As String)
        Dim regKey As RegistryKey
        regKey = CurrentUser.OpenSubKey(parentkey, True)
        regKey.CreateSubKey(keyname)
        regKey.Close()
    End Sub
    Public Sub DeleteKey(ByVal ApplicationName As String)
        Dim CU As Microsoft.Win32.RegistryKey = Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Run")
        With CU
            .OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)
            .DeleteValue(ApplicationName, False)
        End With
    End Sub
    Public Sub WriteSetting(keyname As String, attrnm As String, Optional attrval As Object = "NULL")
        Dim regKey As RegistryKey
        regKey = CurrentUser.OpenSubKey(keyname, True)
        Try
            regKey.SetValue(attrnm, attrval)
        Catch e As ArgumentNullException
            regKey.SetValue(attrnm, "")
            regKey.Close()
        End Try
    End Sub
    Public Function ReadSetting(keyname As String, attrnm As String) As Object
        Dim regKey As RegistryKey
        Dim attrval As Object
        Try
            regKey = CurrentUser.OpenSubKey(keyname, True)
            attrval = regKey.GetValue(attrnm)
            regKey.Close()
        Catch e As NullReferenceException
            attrval = 0
        End Try
        Return attrval
    End Function
End Module
