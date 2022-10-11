using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sariyerpedo.Areas.admin.Models;
using sariyerpedo.BUSSINES.Engine;
using sariyerpedo.BUSSINES.Service;
using sariyerpedo.COMMON.Helpers.Cyroptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace sariyerpedo.Areas.admin.Controllers
{
    [Area("admin")]
    public class editorController : Controller
    {
        private readonly IUserService _userService;

        public editorController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        public IActionResult home()
        {
            return View();
        }

        [HttpGet]
        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> loginToEditor(LoginViewModel model)
        {
            try
            {
                string passCrypto = new Crypto().TryEncrypt(model.Password);
                var user = _userService.login(model.UserName, passCrypto);

                if (model == null)
                {
                    ViewBag.Message = "Geçersiz Kimlik";
                    return View(model);
                }
                else
                {

                    var getUser = _userService.getUserByName(model.UserName);

                    var userClaims = new List<Claim>()
                        {
                            new Claim("Name", getUser.UserName),
                            new Claim("UserId", getUser.Id.ToString()),
                            new Claim(ClaimTypes.Name, getUser.UserName),
                            new Claim(ClaimTypes.NameIdentifier, getUser.Id.ToString()),
                        };

                    var userIdentity = new ClaimsIdentity(userClaims, "User Identity");
                    var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });

                    await HttpContext.SignInAsync(
                        userPrincipal,
                        new AuthenticationProperties
                        {
                            IsPersistent = model.isRemember,
                            ExpiresUtc = DateTime.UtcNow.AddYears(15)
                        });

                    return Redirect("home");
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public IActionResult logout()
        {
            HttpContext.SignOutAsync();
            return Redirect("/admin/editor/login");
        }
    }
}
