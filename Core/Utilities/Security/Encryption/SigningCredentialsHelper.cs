﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    //Tokenı encrypt ederken securityKey ve kullandığımız algoritmayı tutan nesnedir.
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
