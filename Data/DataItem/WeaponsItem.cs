using System.ComponentModel.DataAnnotations;

namespace StalNoteSite.Data.DataItem;

public class WeaponItem
{
    public WeaponItem() { }

    [Key]
    [Display(Name = "Id")]
    public int Id { get; set; }


    [Display(Name = "Stalcraft Id")]
    [MaxLength(30)]
    public string ItemId { get; set; }


    [Display(Name = "Main Type")]
    [MaxLength(50)]
    public string Type { get; set; }


    [Display(Name = "Sub Type")]
    [MaxLength(50)]
    public string SubType { get; set; }


    [Display(Name = "Заточка")]
    public int Pottential { get; set; }


    [Display(Name = "Название")]
    [MaxLength(100)]
    public string Name { get; set; }


    [Display(Name = "Ранг")]
    [MaxLength(30)]
    public string Rank { get; set; }


    [Display(Name = "Класс")]
    [MaxLength(30)]
    public string Class { get; set; }


    [Display(Name = "Вес")]
    public double Weight { get; set; }


    [Display(Name = "Тип патрона")]
    [MaxLength(20)]
    public string? AmmoType { get; set; }


    [Display(Name = "Урон")]
    public double Damage { get; set; }


    [Display(Name = "")]
    public double StartDamage { get; set; }


    [Display(Name = "")]
    public double EndDamage { get; set; }


    [Display(Name = "")]
    public double DamageDecreaseStart { get; set; }


    [Display(Name = "")]
    public double DamageDecreaseEnd { get; set; }


    [Display(Name = "Объем магазина")]
    public double MagazineCapacity { get; set; }


    [Display(Name = "Максимальная дистанция")]
    public double MaxDistance { get; set; }


    [Display(Name = "Скорострельность")]
    public double RateOfFire { get; set; }


    [Display(Name = "Перезарядка")]
    public double Reload { get; set; }


    [Display(Name = "Тактическая перезарядка")]
    public double TacticalReload { get; set; }


    [Display(Name = "Разброс")]
    public double Spread { get; set; }


    [Display(Name = "Разброс от бедра")]
    public double HipFireSpread { get; set; }


    [Display(Name = "Вертикальная отдача")]
    public double VerticalRecoil { get; set; }


    [Display(Name = "Горизонтальная отдача")]
    public double HorizontalRecoil { get; set; }


    [Display(Name = "Доставание")]
    public double DrawTime { get; set; }


    [Display(Name = "Прицеливание")]
    public double AimingTime { get; set; }


    [Display(Name = "Урон в голову")]
    public double DamageModifierHeadshot { get; set; }


    [Display(Name = "Урон по конечностям")]
    public double DamageModifierLimb { get; set; }


    [Display(Name = "Урон по мутантам")]
    public double DamageToMutants { get; set; }


    [Display(Name = "Описание")]
    [MaxLength(1000)]
    public string? Description { get; set; }


    [Display(Name = "Кровотечение")]
    public double Bleeding { get; set; }


    [Display(Name = "Бронебойность")]
    public double ArmorPenetration { get; set; }


    [Display(Name = "Останавливающее действие")]
    public double StoppingPower { get; set; }


    [Display(Name = "Особенности")]
    [MaxLength(200)]
    public string? Features { get; set; }
}
