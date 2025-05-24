Public Class GridUserControl
    Inherits BaseUserControl

    ' Property to expose btnSearch and mark as allowed in read-only mode
    <AllowIfReadOnly>
    Protected ReadOnly Property AllowedBtnSearch As Button
        Get
            Return btnSearch
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim people = New List(Of Person) From {
                New Person With {.Name = "Alice"},
                New Person With {.Name = "Bob"},
                New Person With {.Name = "Charlie"}
            }
            GridView1.DataSource = people
            GridView1.DataBind()
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim txt As TextBox = CType(e.Row.FindControl("txtName"), TextBox)
            'If txt IsNot Nothing Then txt.ReadOnly = True

            Dim ddl As DropDownList = CType(e.Row.FindControl("ddlCategory"), DropDownList)

        End If
    End Sub

End Class