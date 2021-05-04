using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Intv.Helpers;
using Intv.Models;
using Intv.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Intv.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly DapperService dapperService;
        public AccountController(DapperService service)
        {
            dapperService = service;
        }
        /// <summary>
        /// Авторизация пользователья
        /// login:admin@gmail.com pass:123456,
        /// login:customer1@mail.ru pass:111111,
        /// login:customer2@mail.ru pass:222222,
        /// login:customer3@mail.ru pass:333333,
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("login")]
        [HttpPost]
        public ActionResult Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { message = Validation.getValidationErrors(model) });
            }
           
            var identity = GetClaimsIdentity(model.login, model.password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Логин или пароль неправильно" });
            }

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt
            };

            return Json(response);
        }

        private ClaimsIdentity GetClaimsIdentity(string username, string password)
        {
           UsersModel user = UsersModel.GetAuthUser(dapperService, username, password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, Roles.getRoleName(user.Role))
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            return null;
        }
    }

}