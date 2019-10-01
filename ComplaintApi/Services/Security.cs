using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using ComplaintApi.Models;

namespace ComplaintApi.Services
{
    public class Security
    {
        public string hash(string password,byte[] salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

            return hashed;
        }

        public string hashNewPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            var randomNumber = RandomNumberGenerator.Create();
            randomNumber.GetBytes(salt);

            return hash(password, salt);
        }

        public bool authenticate(UserMasterDto user, string username, string password)
        {
            byte[] salt = user.Salt;
            string hashedPassword = hash(password, salt);

            if (username == user.Name && hashedPassword == user.Password)
            {
                return true;
            }
            else return false;
        }


    }
}
