Imports System.Reflection

' Attribute to mark controls that should remain enabled in read-only mode
<AttributeUsage(AttributeTargets.Property Or AttributeTargets.Field, AllowMultiple:=False)>
Public Class AllowIfReadOnlyAttribute
    Inherits Attribute
End Class

' Base class for access control logic
Public Class AccessControlBase
    ' Simulate DB check for user access (replace with real DB logic)
    Public Shared Function IsUserReadOnly(userName As String) As Boolean
        ' TODO: Query your DB for user access. For now, always return True (read-only)
        Return True ' Change to True to simulate read-only access
    End Function

    ' Recursively disable controls except those marked with AllowIfReadOnly
    Public Shared Sub ApplyReadOnlyMode(ctrl As Control)
        Dim parentType = ctrl.GetType()
        ' Gather all controls marked as allowed via AllowIfReadOnly property
        Dim allowedControls As New HashSet(Of Control)()
        For Each prop In parentType.GetProperties(BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.NonPublic)
            If prop.GetCustomAttribute(GetType(AllowIfReadOnlyAttribute)) IsNot Nothing Then
                Dim val = prop.GetValue(ctrl)
                If TypeOf val Is Control Then
                    allowedControls.Add(CType(val, Control))
                End If
            End If
        Next
        For Each child As Control In ctrl.Controls
            If Not allowedControls.Contains(child) Then
                If TypeOf child Is TextBox Then
                    CType(child, TextBox).ReadOnly = True
                ElseIf TypeOf child Is Button OrElse TypeOf child Is DropDownList OrElse TypeOf child Is CheckBox OrElse TypeOf child Is RadioButton Then
                    CType(child, WebControl).Enabled = False
                End If
                ' Recursively apply to children
                ApplyReadOnlyMode(child)
            End If
        Next
    End Sub
End Class
