using System.ComponentModel.DataAnnotations;

namespace Xelat.Project.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}