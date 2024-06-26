﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Filters;
using RepositoryPattern.Models;
using RepositoryPattern.Models.Req;
using RepositoryPattern.Services;

namespace RepositoryPattern.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthensController : ControllerBase
    {
        AuthenService _auth;
        public AuthensController(AuthenService auth)
        {
            _auth = auth;
        }

        WebphimonlineContext db = new WebphimonlineContext();
        [ServiceFilter(typeof(testFilter))]

        [HttpPost("testlog")]
        public IActionResult testLog([FromBody] Taikhoan req)
        {
            var check = db.Taikhoans.FirstOrDefault(x => x.Email == req.Email);
            var accessToken = _auth.GenerateAccessToken(req);
            var refresToken = _auth.GenerateRefreshToken();
            if (check  == null)
            {
                return BadRequest("Email exist!");
            }
            check.RefreshToken = refresToken;
            db.Taikhoans.Update(check);
            db.SaveChanges();
            if (accessToken == "500")
            {
                return BadRequest("Invaild email or pass");
            }
            var response = new TokenReq
            {
                AccessToken = accessToken,
                RefreshToken = refresToken
            };
            return Ok(response);
        }

        
        [HttpPost("refresh")]

        public IActionResult Refresh(TokenReq req)
        {

            var newAccessToken = _auth.GenerateAccessTokenFromRefreshToken(req.RefreshToken);
            var reponse = new TokenReq
            {
                AccessToken = newAccessToken,
                RefreshToken = req.RefreshToken
            };
            return Ok(reponse);
        }


        [HttpPost("Register")]
        public IActionResult Register([FromBody] Taikhoan req)
        {
            try
            {
                var check =_auth.register(req);
                return Ok(check);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
