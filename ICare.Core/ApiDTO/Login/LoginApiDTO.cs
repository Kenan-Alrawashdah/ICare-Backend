using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICare.Core.ApiDTO
{
    public class LoginApiDTO
    {
        public class Request
        {
            /// <summary>
            /// 
            /// </summary>
            /// <example>Test@test.test</example>
            [Required]
            [MaxLength(50)]
            public string Email { get; set; }

            /// <summary>
            /// 
            /// </summary>
            /// <example>Q!qwe123</example>
            [Required]
            [MaxLength(50)]
            public string Password { get; set; }
        }

        public class Response
        {
            /// <summary>
            /// 
            /// </summary>
            public string AccessToken { get; set; }


            public string RefreshToken { get; set; }

        }
    }
}
