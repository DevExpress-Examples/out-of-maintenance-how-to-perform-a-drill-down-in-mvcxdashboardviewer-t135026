Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Routing
Imports System.Web.Security
Imports Dashboard_PerformDrillDown_MVC.Models

Namespace Dashboard_PerformDrillDown_MVC.Controllers
    Public Class AccountController
        Inherits Controller

        '
        ' GET: /Account/Login
        Public Function Login() As ActionResult
            Return View()
        End Function

        '
        ' POST: /Account/Login

        <HttpPost> _
        Public Function Login(ByVal model As LoginModel, ByVal returnUrl As String) As ActionResult
            If ModelState.IsValid Then
                If Membership.ValidateUser(model.UserName, model.Password) Then
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe.Value)
                    If Url.IsLocalUrl(returnUrl) AndAlso returnUrl.Length > 1 AndAlso returnUrl.StartsWith("/") AndAlso (Not returnUrl.StartsWith("//")) AndAlso (Not returnUrl.StartsWith("/\")) Then
                        Return Redirect(returnUrl)
                    Else
                        Return RedirectToAction("Index", "Home")
                    End If
                Else
                    ModelState.AddModelError("", "The user name or password provided is incorrect.")
                End If
            End If

            ' If we got this far, something failed, redisplay form
            Return View(model)
        End Function

        '
        ' GET: /Account/LogOff

        Public Function LogOff() As ActionResult
            FormsAuthentication.SignOut()
            Return RedirectToAction("Index", "Home")
        End Function

        '
        ' GET: /Account/Register

        Public Function Register() As ActionResult
            Return View()
        End Function

        '
        ' POST: /Account/Register

        <HttpPost> _
        Public Function Register(ByVal model As RegisterModel) As ActionResult
            If ModelState.IsValid Then
                ' Attempt to register the user
                            Dim createStatus As MembershipCreateStatus = Nothing
                Membership.CreateUser(model.UserName, model.Password, model.Email, Nothing, Nothing, True, Nothing, createStatus)

                If createStatus = MembershipCreateStatus.Success Then
                    FormsAuthentication.SetAuthCookie(model.UserName, False) ' createPersistentCookie
                    Return RedirectToAction("Index", "Home")
                Else
                    ModelState.AddModelError("", ErrorCodeToString(createStatus))
                End If
            End If

            ' If we got this far, something failed, redisplay form
            Return View(model)
        End Function

        '
        ' GET: /Account/ChangePassword

        <Authorize> _
        Public Function ChangePassword() As ActionResult
            Return View()
        End Function

        '
        ' POST: /Account/ChangePassword

        <HttpPost, Authorize> _
        Public Function ChangePassword(ByVal model As ChangePasswordModel) As ActionResult
            If ModelState.IsValid Then
                ' ChangePassword will throw an exception rather
                ' than return false in certain failure scenarios.
                Dim changePasswordSucceeded As Boolean
                Try
                    Dim currentUser As MembershipUser = Membership.GetUser(User.Identity.Name, True) ' userIsOnline
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword)
                Catch e1 As Exception
                    changePasswordSucceeded = False
                End Try

                If changePasswordSucceeded Then
                    Return RedirectToAction("ChangePasswordSuccess")
                Else
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.")
                End If

            End If

            ' If we got this far, something failed, redisplay form
            Return View(model)
        End Function

        '
        ' GET: /Account/ChangePasswordSuccess

        Public Function ChangePasswordSuccess() As ActionResult
            Return View()
        End Function

        #Region "Status Codes"
        Private Shared Function ErrorCodeToString(ByVal createStatus As MembershipCreateStatus) As String
            ' See http://go.microsoft.com/fwlink/?LinkID=177550 for
            ' a full list of status codes.
            Select Case createStatus
                Case MembershipCreateStatus.DuplicateUserName
                    Return "User name already exists. Please enter a different user name."

                Case MembershipCreateStatus.DuplicateEmail
                    Return "A user name for that e-mail address already exists. Please enter a different e-mail address."

                Case MembershipCreateStatus.InvalidPassword
                    Return "The password provided is invalid. Please enter a valid password value."

                Case MembershipCreateStatus.InvalidEmail
                    Return "The e-mail address provided is invalid. Please check the value and try again."

                Case MembershipCreateStatus.InvalidAnswer
                    Return "The password retrieval answer provided is invalid. Please check the value and try again."

                Case MembershipCreateStatus.InvalidQuestion
                    Return "The password retrieval question provided is invalid. Please check the value and try again."

                Case MembershipCreateStatus.InvalidUserName
                    Return "The user name provided is invalid. Please check the value and try again."

                Case MembershipCreateStatus.ProviderError
                    Return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator."

                Case MembershipCreateStatus.UserRejected
                    Return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator."

                Case Else
                    Return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator."
            End Select
        End Function
        #End Region
    End Class
End Namespace