Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Configuration
Imports System.Linq
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms


Public Class Form1


    Public globalIP As String = ""


    Public Function GetStatus(ByVal ipaddress As String) As String
        Try
            Dim port As Int32 = 60001
            Dim client As TcpClient = New TcpClient(ipaddress, port)
            Dim data As Byte() = System.Text.Encoding.ASCII.GetBytes("00")
            Dim stream As NetworkStream = client.GetStream()
            stream.Write(data, 0, data.Length)
            data = New Byte(255) {}
            Dim responseData As String = String.Empty
            Dim bytes As Int32 = stream.Read(data, 0, data.Length)
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes)
            stream.Close()
            client.Close()
            Return responseData
        Catch ex As Exception
            MessageBox.Show("Fail to connect to relay board. Error details: " & ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Return ""
        End Try
    End Function

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
            MessageBox.Show("Fail to connect to relay board. Error details: " & ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Return False
        End Try
    End Function

    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
        SendTcpPacket("1", "on", globalIP)
        button17.PerformClick()
    End Sub

    Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
        SendTcpPacket("1", "off", globalIP)
        button17.PerformClick()
    End Sub

    Private Sub button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button3.Click
        SendTcpPacket("2", "on", globalIP)
        button17.PerformClick()
    End Sub

    Private Sub button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button4.Click
        SendTcpPacket("2", "off", globalIP)
        button17.PerformClick()
    End Sub

    Private Sub button5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button5.Click
        SendTcpPacket("3", "on", globalIP)
        button17.PerformClick()
    End Sub

    Private Sub button6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button6.Click
        SendTcpPacket("3", "off", globalIP)
        button17.PerformClick()
    End Sub

    Private Sub button7_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button7.Click
        SendTcpPacket("4", "on", globalIP)
        button17.PerformClick()
    End Sub

    Private Sub button8_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button8.Click
        SendTcpPacket("4", "off", globalIP)
        button17.PerformClick()
    End Sub

    Private Sub button9_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button9.Click
        SendTcpPacket("5", "on", globalIP)
        button17.PerformClick()
    End Sub

    Private Sub button10_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button10.Click
        SendTcpPacket("5", "off", globalIP)
        button17.PerformClick()
    End Sub

    Private Sub button11_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button11.Click
        SendTcpPacket("6", "on", globalIP)
        button17.PerformClick()
    End Sub

    Private Sub button12_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button12.Click
        SendTcpPacket("6", "off", globalIP)
        button17.PerformClick()
    End Sub

    Private Sub button13_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button13.Click
        SendTcpPacket("7", "on", globalIP)
        button17.PerformClick()
    End Sub

    Private Sub button14_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button14.Click
        SendTcpPacket("7", "off", globalIP)
        button17.PerformClick()
    End Sub

    Private Sub button15_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button15.Click
        SendTcpPacket("8", "on", globalIP)
        button17.PerformClick()
    End Sub

    Private Sub button16_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button16.Click
        SendTcpPacket("8", "off", globalIP)
        button17.PerformClick()
    End Sub

    Private Sub button17_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button17.Click
        Dim responseData = GetStatus(globalIP)

        If responseData.Substring(0, 1) = "1" Then
            pictureBox1.Image = My.Resources._on
        Else
            pictureBox1.Image = My.Resources.off
        End If

        If responseData.Substring(1, 1) = "1" Then
            pictureBox2.Image = My.Resources._on
        Else
            pictureBox2.Image = My.Resources.off
        End If

        If responseData.Substring(2, 1) = "1" Then
            pictureBox3.Image = My.Resources._on
        Else
            pictureBox3.Image = My.Resources.off
        End If

        If responseData.Substring(3, 1) = "1" Then
            pictureBox4.Image = My.Resources._on
        Else
            pictureBox4.Image = My.Resources.off
        End If

        If responseData.Substring(4, 1) = "1" Then
            pictureBox5.Image = My.Resources._on
        Else
            pictureBox5.Image = My.Resources.off
        End If

        If responseData.Substring(5, 1) = "1" Then
            pictureBox6.Image = My.Resources._on
        Else
            pictureBox6.Image = My.Resources.off
        End If

        If responseData.Substring(6, 1) = "1" Then
            pictureBox7.Image = My.Resources._on
        Else
            pictureBox7.Image = My.Resources.off
        End If

        If responseData.Substring(7, 1) = "1" Then
            pictureBox8.Image = My.Resources._on
        Else
            pictureBox8.Image = My.Resources.off
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Dim AppName As String = ""
        Dim IPAddress As String = ""
        Dim Sensor1 As String = ""
        Dim Sensor2 As String = ""
        Dim Sensor3 As String = ""
        Dim Sensor4 As String = ""
        Dim Sensor5 As String = ""
        Dim Sensor6 As String = ""
        Dim Sensor7 As String = ""
        Dim Sensor8 As String = ""

        Try
            AppName = ConfigurationManager.AppSettings("AppName")
            IPAddress = ConfigurationManager.AppSettings("IPAddress")
            Sensor1 = ConfigurationManager.AppSettings("Sensor1")
            Sensor2 = ConfigurationManager.AppSettings("Sensor2")
            Sensor3 = ConfigurationManager.AppSettings("Sensor3")
            Sensor4 = ConfigurationManager.AppSettings("Sensor4")
            Sensor5 = ConfigurationManager.AppSettings("Sensor5")
            Sensor6 = ConfigurationManager.AppSettings("Sensor6")
            Sensor7 = ConfigurationManager.AppSettings("Sensor7")
            Sensor8 = ConfigurationManager.AppSettings("Sensor8")
        Catch ex As Exception
            MessageBox.Show("App.Config not found in same folder as executable, verify why the file is missing and try again.")
            Application.[Exit]()
        End Try

        If AppName <> "" Then
            label1.Text = AppName
            Me.Text = AppName
        End If

        If Sensor1 <> "" Then
            label2.Text = Sensor1
        End If

        If Sensor2 <> "" Then
            label3.Text = Sensor2
        End If

        If Sensor3 <> "" Then
            label4.Text = Sensor3
        End If

        If Sensor4 <> "" Then
            label5.Text = Sensor4
        End If

        If Sensor5 <> "" Then
            label6.Text = Sensor5
        End If

        If Sensor6 <> "" Then
            label7.Text = Sensor6
        End If

        If Sensor7 <> "" Then
            label8.Text = Sensor7
        End If

        If Sensor8 <> "" Then
            label9.Text = Sensor8
        End If

        globalIP = IPAddress
        button17.PerformClick()
    End Sub

End Class

