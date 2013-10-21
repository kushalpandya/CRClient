Imports System.Text
Imports System.Xml

Module CyberoamMethods
    Dim NOTCONNECTED As Boolean
    Public LOGINSTATE As Byte 'Multivalue flag, Not connected=0, Logged-in=1, Problem in Login=2, Logout=3, Problem in Logout=4
    Function WRequest(ByVal URL As String, ByVal method As String, ByVal POSTdata As String, ByRef doc As XmlDocument, Optional ByVal xmlFlag As Boolean = True) As Boolean
        Try
            Dim request As Net.HttpWebRequest = Net.WebRequest.Create(URL)
            request.Accept = "*/*"
            request.AllowAutoRedirect = True
            request.UserAgent = "http_requester/0.1"
            request.Timeout = 60000
            request.Method = method
            request.Proxy = Nothing

            If request.Method = "POST" Then
                request.ContentType = "application/x-www-form-urlencoded"

                Dim encoding As New ASCIIEncoding()
                Dim postByteArray() As Byte = encoding.GetBytes(POSTdata)
                request.ContentLength = postByteArray.Length
                Dim postStream As IO.Stream = request.GetRequestStream()
                postStream.Write(postByteArray, 0, postByteArray.Length)
                postStream.Close()
            End If
            Dim response As Net.HttpWebResponse = request.GetResponse()
            If xmlFlag Then
                If response.StatusCode = Net.HttpStatusCode.OK Or response.StatusCode = Net.HttpStatusCode.Created Then
                    doc.Load(response.GetResponseStream)
                End If
            End If
            response.Close()
            NOTCONNECTED = False
            Return True
        Catch e As System.Net.WebException
            NOTCONNECTED = True
            Return False
        Catch e As Exception
            Return False
        End Try

    End Function

    Public Function Login() As Boolean
        Dim xDoc As New XmlDocument
        WRequest("http://" & IPADDR & ":" & PORTNO & "/login.xml", "post", "mode=191&username=" & USERNAME & "&password=" & PASSWORD &
                        "&a=" & DateTime.Now.Subtract(New DateTime(1970, 1, 1)).TotalMilliseconds.ToString(), xDoc)
        If NOTCONNECTED <> True Then
            If xDoc.GetElementsByTagName("status")(0).InnerText.ToLower().IndexOf("live") <> -1 Then
                CONNECTEDFLAG = True

                frmMain.tmLogout.Enabled = True
                ShowMsg("You have successfully logged in", 1)
                LOGINSTATE = 1
                Return True
            Else
                ShowMsg(xDoc.GetElementsByTagName("message")(0).InnerText, 2)
                LOGINSTATE = 2
                Return False
            End If
        Else
            ShowMsg("You are not connected to network", 2)
            LOGINSTATE = 0
            Return False
        End If
    End Function

    Public Function Logoff() As Boolean
        If CONNECTEDFLAG = True Then
            Dim XDoc As New XmlDocument
            If WRequest("http://" & IPADDR & ":" & PORTNO & "/logout.xml", "post", "mode=193&username=" & USERNAME & "&a=" &
                        DateTime.Now.Subtract(New DateTime(1970, 1, 1)).TotalMilliseconds.ToString(), XDoc) Then
                Dim msg As String
                If XDoc.InnerText.ToLower.Contains("status") = -1 Then
                    ShowMsg("Error occured while logging out!", 2)
                    Return False
                End If
                msg = XDoc.GetElementsByTagName("message")(0).InnerText

                If XDoc.GetElementsByTagName("status")(0).InnerText.ToLower <> "login" Then
                    ShowMsg(msg, 2)
                    LOGINSTATE = 4
                    Return False
                Else
                    ShowMsg(msg, 1)
                    LOGINSTATE = 3
                    CONNECTEDFLAG = False
                    frmMain.tmLogout.Enabled = False
                    Return True
                End If

            End If
            ShowMsg("Error occured while logging out!", 2)
            LOGINSTATE = 4
            Return False
        End If
        ShowMsg("Error occured while logging out!", 2)
        LOGINSTATE = 4
        Return False
    End Function
End Module
