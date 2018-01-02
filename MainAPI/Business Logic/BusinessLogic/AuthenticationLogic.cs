using GruntifyV4.Model.Master.Contract.Entities.SignUp;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GruntifyV4.Logic.SignUp
{
    public class AuthenticationLogic
    {
        UserLogic _userLogic;
        CvLogic _organisationLogic;
        byte[] _jwtSigningKey;

        public AuthenticationLogic(UserLogic userLogic, CvLogic organisationLogic)
        {
            _userLogic = userLogic;
            _organisationLogic = organisationLogic;
            _jwtSigningKey = Encoding.UTF8.GetBytes("Blahblah_ThisIs_@longKEY>XWAQTds15564plo");
        }
        /// <summary>
        /// Attempt to login user by matching the payload password against the user password.
        /// Return a JWT containing all user workspaces
        /// </summary>
        /// <param name="user"></param>
        /// <param name="rawPassword"></param>
        /// <returns>Authentication Token for specified User</returns>
        public async Task<string> AuthenticateUserAsync(User user, string rawPassword)
        {
            var passwordMatch = _userLogic.IsPasswordMatching(user, rawPassword);

            if (passwordMatch)
            {
                return await GenerateJwtToken(user);
            }

            return string.Empty;
        }

        private async Task<string> GenerateJwtToken(User user)
        {
            IEnumerable<string> workspaceUrlList = await _organisationLogic.GetWorkspacesUrlForUser(user.Id);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("workspaces", string.Join("|", workspaceUrlList))
            };

            var key = new SymmetricSecurityKey(_jwtSigningKey);
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(7);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
