using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NavOS.Basecode.AdminApp.Models
{
    /// <summary>
    /// Login View Model
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>ユーザーID</summary>
        [JsonPropertyName("AdminEmail")]
        [Required(ErrorMessage = "Email is required.")]
        public string AdminEmail { get; set; }
        /// <summary>パスワード</summary>
        [JsonPropertyName("password")]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
