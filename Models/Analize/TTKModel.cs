using StalNoteSite.Data.DataItem;
using StalNoteSite.Data.Users;

namespace StalNoteSite.Analize.Models
{
    public class TTKModel
    {
        public List<Bullet> Bullets { get; set; }
        public List<UserCase> caseItems;
        public List<ArmorItem> allArmorItems;
        public List<WeaponItem> allWeaponItems;
    }
}
