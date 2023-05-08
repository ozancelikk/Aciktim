using Core.Entities.Concrete.DBEntities;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

        }
        public UserAccessToken CreateTokenForUser(User user, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityTokenForUser(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);


            return new UserAccessToken
            {
                UserId = user.Id,
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public AccessToken CreateTokenForCustomer(Customer customer, List<OperationClaim> claims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityTokenForCustomer(_tokenOptions, customer, signingCredentials, claims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);


            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration,
                CustomerId = customer.Id
            };
        }

        public JwtSecurityToken CreateJwtSecurityTokenForUser(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaimsForUser(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }


        public JwtSecurityToken CreateJwtSecurityTokenForCustomer(TokenOptions tokenOptions, Customer customer,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaimsForCustomer(customer, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaimsForUser(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();

            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }

        private IEnumerable<Claim> SetClaimsForCustomer(Customer customer, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();

            claims.AddNameIdentifier(customer.Id.ToString());
            claims.AddEmail(customer.MailAddress);
            claims.AddName($"{customer.FirstName} {customer.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }

        private IEnumerable<Claim> SetClaimsForRestaurant(Restaurant restaurant, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();

            claims.AddNameIdentifier(restaurant.Id.ToString());
            claims.AddEmail(restaurant.MailAddress);
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }

        public JwtSecurityToken CreateJwtSecurityTokenForRestaurant(TokenOptions tokenOptions, Restaurant restaurant,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaimsForRestaurant(restaurant, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        public RestaurantAccessToken CreateTokenForRestaurant(Restaurant restaurant, List<OperationClaim> claims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityTokenForRestaurant(_tokenOptions, restaurant, signingCredentials, claims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);


            return new RestaurantAccessToken
            {
                RestaurantId = restaurant.Id,
                Token = token,
                Expiration = _accessTokenExpiration,
                Status=restaurant.Status,
            };

        }
    }
}
