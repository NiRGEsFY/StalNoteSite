using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.EntityFrameworkCore;
using StalNoteSite.Data.Users;
using System.ComponentModel.DataAnnotations;

namespace StalNoteSite;

[PrimaryKey(nameof(Id))]
public class User : IdentityUser<long>
{
    private bool disposed;
    public override long Id { get; set; }

    public UserTelegram UserTelegram { get; set; }
    public UserToken UserToken { get; set; }
    public UserConfig UserConfig { get; set; }
    public ICollection<UserItem> UserItems { get; set; }
    [Display(Name = "Начало действия роли")]
    public DateTime? StartRole { get; set; }
    [Display(Name = "Конец действия роли")]
    public DateTime? EndRole { get; set; }
    public User()
    {
        UserItems = new List<UserItem>();
        UserTelegram = new UserTelegram();
        UserToken = new UserToken();
    }
    public User(StalNoteSite.Models.Users.RegisterModel model)
        : this()
    {
        //using (var context = new Stalcraft2Context())
        //{
        //    var tempRole = context.Roles.Where(x => x.Name == "Новичек").FirstOrDefault();
        //    this.Role = tempRole;
        //    this.RoleId = tempRole.Id;
        //}
        this.Email = model.Email;
        this.UserName = model.UserName;
    }
}