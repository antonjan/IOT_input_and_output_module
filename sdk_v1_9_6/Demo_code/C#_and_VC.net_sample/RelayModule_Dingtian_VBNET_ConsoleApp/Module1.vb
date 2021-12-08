Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net.Sockets
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading.Tasks

Module RelayModule_Dingtian_VBNET_ConsoleApp

    Sub Main(ByVal args As String())
        If args.Length = 3 Then
            Dim ipAddress As String = args(0)
            Dim relayNumber As String = args(1)
            Dim desiredState As String = args(2).ToLower()
            Dim ip As Regex = New Regex("\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b")
            Dim result As MatchCollection = ip.Matches(ipAddress)

            If result.Count <> 0 Then

                If desiredState = "on" OrElse desiredState = "off" Then

                    If relayNumber = "1" OrElse relayNumber = "2" OrElse relayNumber = "3" OrElse relayNumber = "4" OrElse relayNumber = "5" OrElse relayNumber = "6" OrElse relayNumber = "7" OrElse relayNumber = "8" Then
                        SendTcpPacket(relayNumber, desiredState, ipAddress)
                    Else
                        Console.WriteLine("Relay must be a number from 1 to 8")
                    End If
                Else
                    Console.WriteLine("Invalid State informed. Please use only ON or OFF.")
                End If
            Else
                Console.WriteLine("Invalid IP address, please check the command and try again")
            End If
        Else
            Console.WriteLine("Use: RelayModule_Dingtian_VBNET_ConsoleApp [IPAddress] [RelayNumber(1~8)] [DesiredState(on/off)]")
            Console.WriteLine("Example: RelayModule_Dingtian_VBNET_ConsoleApp 192.168.1.100 1 on")
        End If
    End Sub

    Public Function SendTcpPacket(ByVal relaynumber As String, ByVal status As String, ByVal ipaddress As String) As Boolean
        Try
            Dim text As String = ""
            Dim port As Int32 = 60001
            Dim client As TcpClient = New TcpClient(ipaddress, port)

            If relaynumber = "1" Then

                If status = "on" Then
                    text = "11"
                Else
                    text = "21"
                End If
            End If

            If relaynumber = "2" Then

                If status = "on" Then
                    text = "12"
                Else
                    text = "22"
                End If
            End If

            If relaynumber = "3" Then

                If status = "on" Then
                    text = "13"
                Else
                    text = "23"
                End If
            End If

            If relaynumber = "4" Then

                If status = "on" Then
                    text = "14"
                Else
                    text = "24"
                End If
            End If

            If relaynumber = "5" Then

                If status = "on" Then
                    text = "15"
                Else
                    text = "25"
                End If
            End If

            If relaynumber = "6" Then

                If status = "on" Then
                    text = "16"
                Else
                    text = "26"
                End If
            End If

            If relaynumber = "7" Then

                If status = "on" Then
                    text = "17"
                Else
                    text = "27"
                End If
            End If

            If relaynumber = "8" Then

                If status = "on" Then
                    text = "18"
                Else
                    text = "28"
                End If
            End If

            Dim data As Byte() = System.Text.Encoding.ASCII.GetBytes(text)
            Dim stream As NetworkStream = client.GetStream()
            stream.Write(data, 0, data.Length)
            stream.Close()
            client.Close()
            Return True
        Catch ex As Exception
            Console.WriteLine("Fail to connect to relay board. Error details: " & ex.ToString())
            Return False
        End Try
    End Function

End Module
