using System;
using System.Collections.Generic;

namespace HotLikes.Controllers
{
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using HotLikes.Data;
    using HotLikes.ViewModels.Account;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;
    using HotLikes.Models;
    using System.Text.RegularExpressions;
    using System.Net;
    using HotLikes.Controllers.Helpers;

    [Authorize]
    public class AccountController : BaseController
    {
        public AuthenticationIdentityManager IdentityManager { get; private set; }

        private Microsoft.Owin.Security.IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public AccountController(IUowData data) : base(data)
        {
            IdentityManager = new AuthenticationIdentityManager(
                new IdentityStore(new HotLikesContext()));
        }

        public AccountController(AuthenticationIdentityManager manager, IUowData data) : base(data)
        {
            IdentityManager = manager;
        }
               
        [AllowAnonymous]
        public ActionResult Login()
        {
            return RedirectToAction("Index", "Home");
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = UserUtils.GetUserByEmail(model.Email, this.Data);

                if (user != null)
                {
                    if (user.IsVerified)
                    {
                        IdentityResult result = await IdentityManager.Authentication.CheckPasswordAndSignInAsync(AuthenticationManager, model.Email, model.Password, model.RememberMe);
                        if (result.Success)
                        {
                            ModelState.Clear();
                            return RedirectToAction("Index", "User");
                        }
                        else
                        {
                            AddErrors(result);
                        }
                    }
                    else
                    {
                        ViewBag.Email = user.UserName;
                        ViewBag.LinkToMail = ViewBag.Email.Substring(ViewBag.Email.LastIndexOf('@') + 1);
                        this.TempData["email"] = ViewBag.Email;
                        return View("UserVerification");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The Email was not found");
                }
            }

            // If we got this far, something failed, redisplay form
            return View("ErrorLogin");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ResendEmail()
        {
            if (this.TempData["email"] != null)
            {
                var email = this.TempData["email"].ToString();
                var user = UserUtils.GetUserByEmail(email, this.Data);
                
                if (user != null)
                {
                    string fullName = user.FirstName + " " + user.LastName;
                    EmailSender.SendEmail(user.UserName,
                        fullName, user.VerificationKey, user.Id);
                
                    var mailAddress = email.Substring(email.LastIndexOf('@') + 1);
                    return Json(mailAddress, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.NoContent);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public  async Task<ActionResult> UserVerification(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newUser = model.Create();

                var result = await IdentityManager.Users.CreateLocalUserAsync(newUser, model.Password);
               
                if (result.Success)
                {
                    string fullName = newUser.FirstName + " " + newUser.LastName;
                    EmailSender.SendEmail(newUser.UserName,
                        fullName, newUser.VerificationKey, newUser.Id);
                    ViewBag.Email = newUser.UserName;
                    ViewBag.LinkToMail = ViewBag.Email.Substring(ViewBag.Email.LastIndexOf('@') + 1);
                    this.TempData["email"] = ViewBag.Email;
                   
                    return View("UserVerification");
                }
                else
                {
                    AddErrors(result);
                }
            }
            
            TempData["errors"] = ModelState;
            return RedirectToAction("Index", "Home");
        }

        // POST: /Account/Register
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> Register(string key, string id)
        {
            var user = UserUtils.GetUserById(id, this.Data);
                
            if (user != null)
            {
                if (user.IsVerified)
                {
                    return RedirectToAction("Index", "User");
                }
                else if (user.VerificationKey == key)
                {
                    user.IsVerified = true;
                    this.Data.SaveChanges();
                    await IdentityManager.Authentication.SignInAsync(AuthenticationManager, user.Id, isPersistent: false);
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Verification Key");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid User");
            }

            return View("Error");
        }
        
        // POST: /Account/Disassociate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Disassociate(string loginProvider, string providerKey)
        {
            string message = null;
            IdentityResult result = await IdentityManager.Logins.RemoveLoginAsync(User.Identity.GetUserId(), loginProvider, providerKey);
            if (result.Success)
            {
                message = "The external login was removed.";
            }
            else
            {
                message = result.Errors.FirstOrDefault();
            }

            return RedirectToAction("Manage", new { Message = message });
        }

        //
        // GET: /Account/Manage
        public async Task<ActionResult> Manage(string message)
        {
            ViewBag.StatusMessage = message ?? "";
            ViewBag.HasLocalPassword = await IdentityManager.Logins.HasLocalLoginAsync(User.Identity.GetUserId());
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View();
        }

        //
        // POST: /Account/Manage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Manage(ManageUserViewModel model)
        {
            string userId = User.Identity.GetUserId();
            bool hasLocalLogin = await IdentityManager.Logins.HasLocalLoginAsync(userId);
            ViewBag.HasLocalPassword = hasLocalLogin;
            ViewBag.ReturnUrl = Url.Action("Manage");
            if (hasLocalLogin)
            { 
                if (ModelState.IsValid)
                {
                    IdentityResult result = await IdentityManager.Passwords.ChangePasswordAsync(User.Identity.GetUserName(), model.OldPassword, model.NewPassword);
                    if (result.Success)
                    {
                        return RedirectToAction("Manage", new { Message = "Your password has been changed." });
                    }
                    else
                    {
                        AddErrors(result);
                    }
                }
            }
            else
            {
                // User does not have a local password so remove any validation errors caused by a missing OldPassword field
                ModelState state = ModelState["OldPassword"];
                if (state != null)
                {
                    state.Errors.Clear();
                }

                if (ModelState.IsValid)
                {
                    // Create the local login info and link it to the user
                    IdentityResult result = await IdentityManager.Logins.AddLocalLoginAsync(userId, User.Identity.GetUserName(), model.NewPassword);
                    if (result.Success)
                    {
                        return RedirectToAction("Manage", new { Message = "Your password has been set." });
                    }
                    else
                    {
                        AddErrors(result);
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { loginProvider = provider, ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string loginProvider, string returnUrl)
        {
            ClaimsIdentity id = await IdentityManager.Authentication.GetExternalIdentityAsync(AuthenticationManager);
            // Sign in this external identity if its already linked
            IdentityResult result = await IdentityManager.Authentication.SignInExternalIdentityAsync(AuthenticationManager, id);
            if (result.Success) 
            {
                return RedirectToLocal(returnUrl);
            }
            else if (User.Identity.IsAuthenticated)
            {
                // Try to link if the user is already signed in
                result = await IdentityManager.Authentication.LinkExternalIdentityAsync(id, User.Identity.GetUserId());
                if (result.Success)
                {
                    return RedirectToLocal(returnUrl);
                }
                else 
                {
                    return View("ExternalLoginFailure");
                }
            }
            else
            {
                // Otherwise prompt to create a local user
                ViewBag.ReturnUrl = returnUrl;
                ViewBag.LoginProvider = loginProvider;
                return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { UserName = id.Name });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Manage");
            }
            
            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                IdentityResult result = await IdentityManager.Authentication.CreateAndSignInExternalUserAsync(AuthenticationManager, new User(model.UserName));
                if (result.Success)
                {
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    AddErrors(result);
                }
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        [AllowAnonymous]
        [ChildActionOnly]
        public ActionResult ExternalLoginsList(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return (ActionResult)PartialView("_ExternalLoginsListPartial", new List<AuthenticationDescription>(AuthenticationManager.GetExternalAuthenticationTypes()));
        }

        [ChildActionOnly]
        public ActionResult RemoveAccountList()
        {
            return Task.Run(async () =>
            {
                var linkedAccounts = new List<IUserLogin>(await IdentityManager.Logins.GetLoginsAsync(User.Identity.GetUserId()));
                ViewBag.ShowRemoveButton = linkedAccounts.Count > 1;
                return (ActionResult)PartialView("_RemoveAccountPartial", linkedAccounts);
            }).Result;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && IdentityManager != null)
            {
                IdentityManager.Dispose();
                IdentityManager = null;
            }
            base.Dispose(disposing);
        }

        #region Helpers
        
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                if (error.Contains("Username"))
                {
                    Regex r = new Regex("Username");
                    string str = r.Replace(error, "Email");
                    ModelState.AddModelError("", str);
                }
                else
                {
                    ModelState.AddModelError("", error);
                }
            }
        }
        
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        
        private class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUrl)
            {
                LoginProvider = provider;
                RedirectUrl = redirectUrl;
            }
            
            public string LoginProvider { get; set; }
            
            public string RedirectUrl { get; set; }
            
            public override void ExecuteResult(ControllerContext context)
            {
                context.HttpContext.GetOwinContext().Authentication.Challenge(new AuthenticationProperties() { RedirectUrl = RedirectUrl }, LoginProvider);
            }
        }
        
        #endregion
    }
}