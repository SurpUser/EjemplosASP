using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using EjemploLogin.Models;
using System.Data.SqlClient;
using System.Data;

namespace EjemploLogin.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=ROOT-PC\\SURPUSER;Initial Catalog=SurpUserDB;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Usuario where email='" + Email.Text + "' and contrasena ='" + Password.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Response.Write("<script>alert('Bienvenido"+Email.Text +"')</script>");
                Response.Redirect("../Inicio.aspx");
                
            }
            else
            {
                Response.Write("<script>alert('por favor ingrese un Email y Contraseña valido')</script>");
            }
            /* if (IsValid)
             {
                 // Validate the user password
                 var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                 var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                 // This doen't count login failures towards account lockout
                 // To enable password failures to trigger lockout, change to shouldLockout: true
                 var result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout: false);

                 switch (result)
                 {
                     case SignInStatus.Success:
                         IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                         break;
                     case SignInStatus.LockedOut:
                         Response.Redirect("/Account/Lockout");
                         break;
                     case SignInStatus.RequiresVerification:
                         Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}", 
                                                         Request.QueryString["ReturnUrl"],
                                                         RememberMe.Checked),
                                           true);
                         break;
                     case SignInStatus.Failure:
                     default:
                         FailureText.Text = "Invalid login attempt";
                         ErrorMessage.Visible = true;
                         break;
                 }
             }*/
        }
    }
}