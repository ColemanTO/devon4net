﻿using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OASP4Net.Infrastructure.JWT.MVC.Controller
{
    public interface IOASP4NetJWTController
    {
        JwtSecurityToken GetCurrentUser();
        Claim GetUserClaim(string claimName, JwtSecurityToken jwtUser = null);
        IEnumerable<Claim> GetUserClaims(JwtSecurityToken jwtUser = null);
    }
}