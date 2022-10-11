﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using sariyerpedo.BUSSINES.DTOS.RoleData;
using sariyerpedo.BUSSINES.DTOS.UserData;
using sariyerpedo.BUSSINES.Service;
using sariyerpedo.COMMON.Helpers.Cyroptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sariyerpedo.Areas.admin.Controllers
{
    [Area("admin")]
    public class hesapController : Controller
    {
        #region Fields

        private readonly IRoleService _roleService;
        private readonly IUserService _userService;
        public hesapController(IRoleService roleService, IUserService userService)
        {
            _roleService = roleService;
            _userService = userService;
        }

        #endregion

        #region Rol İşlemleri

        [HttpGet]
        [Authorize]
        public IActionResult roller()
        {
            #region ViewBag

            ViewBag.pTitle = "Roller";
            ViewBag.pageTitle = "Hesap";
            ViewBag.Title = "Roller";

            #endregion
            return View(_roleService.GetAll());
        }

        [HttpGet]
        [Authorize]
        public IActionResult rolkayit()
        {
            #region ViewBag

            ViewBag.pTitle = "Rol Kayıt";
            ViewBag.pageTitle = "Hesap";
            ViewBag.Title = "Rol Kayıt";

            #endregion
            return View();
        }

        [HttpPost]
        public IActionResult rolekle(RoleDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _roleService.Insert(model);
                    return Redirect("roller");
                }
                else
                {
                    return View(nameof(rolkayit));
                }
            }
            catch (Exception ex)
            {
                return View(nameof(rolkayit));
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult rolduzenle(int ID)
        {

            var role = _roleService.Get(ID);

            #region ViewBag

            ViewBag.pTitle = role.roleName;
            ViewBag.pageTitle = "Rol Düzenle";
            ViewBag.Title = role.roleName;

            #endregion

            return View(role);
        }

        [HttpPost]
        public IActionResult rolguncelle(RoleDto model)
        {
            try
            {
                var rolGetir = _roleService.Get(model.Id);
                rolGetir.roleName = model.roleName;
                rolGetir.UpdatedTime = model.UpdatedTime;
                rolGetir.IsActive = model.IsActive;

                _roleService.Update(rolGetir);
                return Redirect("roller");
            }
            catch (Exception ex)
            {
                return RedirectToAction("rolduzenle", "hesap", new { ID = model.Id });
            }
        }

        #endregion

        #region Kullanıcı İşlemleri

        [HttpGet]
        [Authorize]
        public IActionResult kullanicilar()
        {
            #region ViewBag

            ViewBag.pTitle = "Kullanıcılar";
            ViewBag.pageTitle = "Hesap";
            ViewBag.Title = "Kullanıcılar";

            #endregion

            return View(_userService.GetAll());
        }

        [HttpGet]
        [Authorize]
        public IActionResult kullanicikayit()
        {
            #region ViewBag

            ViewBag.pTitle = "Kullanıcı Kayıt";
            ViewBag.pageTitle = "Hesap";
            ViewBag.Title = "Kullanıcı Kayıt";

            #endregion

            var roller = _roleService.GetAll();
            ViewBag.Roller = new SelectList(roller, "ID", "roleName");
            return View();
        }

        [HttpPost]
        public IActionResult kullaniciekle(UserDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Password = new Crypto().TryEncrypt(model.Password);
                    _userService.Insert(model);

                    return Redirect("kullanicilar");
                }
                else
                {
                    return Redirect("kullanicilar");
                }
            }
            catch (Exception ex)
            {
                return Redirect("kullanicilar");
            }

        }

        [HttpGet]
        [Authorize]
        public IActionResult kullaniciduzenle(int Id)
        {
            #region ViewBag

            ViewBag.pTitle = "Kullanıcı Güncelle";
            ViewBag.pageTitle = "Hesap";
            ViewBag.Title = "Kullanıcı Güncelle";

            #endregion

            var user = _userService.Get(Id);
            string passwordDeCrypt = new Crypto().TryDecrypt(user.Password);
            user.Password = passwordDeCrypt;

            var roles = _roleService.GetAll();
            ViewBag.Roller = new SelectList(roles, "ID", "roleName", user.RoleId);
            return View(user);
        }

        [HttpPost]
        public IActionResult kullaniciguncelle(UserDto model)
        {
            try
            {
                model.Password = new Crypto().TryEncrypt(model.Password);

                var user = _userService.Get(model.Id);
                user.Password = model.Password;
                user.DisplayName = model.DisplayName;
                user.UpdatedTime = DateTime.Now;
                user.UserName = model.UserName;
                user.RoleId = model.RoleId;
                user.IsActive = model.IsActive;

                _userService.Update(model);
                return Redirect("kullanicilar");
            }
            catch (Exception)
            {
                return RedirectToAction("kullaniciduzenle", "hesap", new { Id = model.Id });

            }
        }

        public IActionResult kullanicisil(int Id)
        {
            _userService.Delete(Id);
            return Redirect("kullanicilar");
        }

        public IActionResult kullanicidurumduzenle(int Id)
        {
            try
            {
                var user = _userService.Get(Id);

                if (user.IsActive == true)
                    user.IsActive = false;
                else
                    user.IsActive = true;

                _userService.Update(user);
                return Redirect("kullanicilar");
            }
            catch (Exception ex)
            {
                return Redirect("kullanicilar");
            }

        }

        #endregion

    }
}
