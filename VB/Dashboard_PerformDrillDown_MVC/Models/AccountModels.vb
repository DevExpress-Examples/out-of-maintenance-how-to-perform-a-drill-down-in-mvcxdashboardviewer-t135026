Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.Globalization
Imports System.Web.Mvc
Imports System.Web.Security

Namespace Dashboard_PerformDrillDown_MVC.Models


    Public Class ChangePasswordModel
        <Required, DataType(DataType.Password), Display(Name := "Current password")> _
        Public Property OldPassword() As String

        <Required, StringLength(100, ErrorMessage := "The {0} must be at least {2} characters long.", MinimumLength := 6), DataType(DataType.Password), Display(Name := "New password")> _
        Public Property NewPassword() As String

        <DataType(DataType.Password), Display(Name := "Confirm new password"), System.Web.Mvc.Compare("NewPassword", ErrorMessage := "The new password and confirmation password do not match.")> _
        Public Property ConfirmPassword() As String
    End Class

    Public Class LoginModel
        <Required, Display(Name := "User name")> _
        Public Property UserName() As String

        <Required, DataType(DataType.Password), Display(Name := "Password")> _
        Public Property Password() As String


        Private rememberMe_Renamed? As Boolean
        <Display(Name := "Remember me?")> _
        Public Property RememberMe() As Boolean?
            Get
                Return If(rememberMe_Renamed, False)
            End Get
            Set(ByVal value? As Boolean)
                rememberMe_Renamed = value
            End Set
        End Property
    End Class

    Public Class RegisterModel
        <Required, Display(Name := "User name")> _
        Public Property UserName() As String

        <Required, RegularExpression("\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage := "Please enter a valid email address."), DataType(DataType.EmailAddress), Display(Name := "Email address")> _
        Public Property Email() As String

        <Required, StringLength(100, ErrorMessage := "The {0} must be at least {2} characters long.", MinimumLength := 6), DataType(DataType.Password), Display(Name := "Password")> _
        Public Property Password() As String

        <DataType(DataType.Password), Display(Name := "Confirm password"), System.Web.Mvc.Compare("Password", ErrorMessage := "The password and confirmation password do not match.")> _
        Public Property ConfirmPassword() As String
    End Class
End Namespace