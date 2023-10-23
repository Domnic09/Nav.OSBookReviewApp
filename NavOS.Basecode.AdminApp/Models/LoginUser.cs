using NavOS.Basecode.Data.Models;
using static NavOS.Basecode.Resources.Constants.Enums;

namespace NavOS.Basecode.AdminApp.Models
{
    /// <summary>
    /// Login User Model
    /// </summary>
    public class LoginUser
    {
        /// <summary>
        /// Login Result
        /// </summary>
        public LoginResult loginResult { get; set; }
        /// <summary>
        /// Message
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// Access Token
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// Expires In
        /// </summary>
        public int expires_in { get; set; }
        /// <summary>
        /// User Data
        /// </summary>
        public Admin userData { get; set; }
    }
}
