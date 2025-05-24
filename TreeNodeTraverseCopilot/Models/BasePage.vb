' Base page that uses AccessControlBase
Public Class BasePage
    Inherits System.Web.UI.Page

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        ' Example: check user and apply read-only mode
        If AccessControlBase.IsUserReadOnly(User.Identity.Name) Then
            AccessControlBase.ApplyReadOnlyMode(Me)
        End If
    End Sub
End Class

' Base user control that uses AccessControlBase
Public Class BaseUserControl
    Inherits System.Web.UI.UserControl

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        If AccessControlBase.IsUserReadOnly(Context.User.Identity.Name) Then
            AccessControlBase.ApplyReadOnlyMode(Me)
        End If
    End Sub
End Class
