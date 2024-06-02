using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StalNoteSite;

[PrimaryKey(nameof(Id))]
public class UserTelegram
{
    public int Id { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
    [Required]
    [Display(Name = "Id")]
    public long UserTelegramId { get; set; }
    [Required]
    [Display(Name = "ChatId")]
    public long ChatId { get; set; }
    [MaxLength(50)]
    [Display(Name = "Логин")]
    public string? UserName { get; set; }
    [MaxLength(50)]
    [Display(Name = "Имя")]
    public string? FirstName { get; set; }
    [MaxLength(50)]
    [Display(Name = "Фамилия")]
    public string? LastName { get; set; }
}