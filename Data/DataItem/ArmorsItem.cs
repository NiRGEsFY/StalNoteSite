using System.ComponentModel.DataAnnotations;

namespace StalNoteSite.Data.DataItem;

public class ArmorItem
{
    public ArmorItem() { }

    [Key]
    [Display(Name = "Id")]
    public int Id { get; set; }


    [Display(Name = "Stalcraft Id")]
    [MaxLength(20)]
    public string ItemId { get; set; }


    [Display(Name = "Main Type")]
    [MaxLength(30)]
    public string Type { get; set; }


    [Display(Name = "Sub Type")]
    [MaxLength(30)]
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


    [Display(Name = "Периодическое лечение")]
    public double PeriodicHealing { get; set; }


    [Display(Name = "Кровотечение")]
    public double Bleeding { get; set; }


    [Display(Name = "Стойкость")]
    public double Stability { get; set; }


    [Display(Name = "Восстановление выносливости")]
    public double StaminaRegeneration { get; set; }


    [Display(Name = "Выносливость")]
    public double Stamina { get; set; }


    [Display(Name = "Скорость передвижения")]
    public double MoveSpeed { get; set; }


    [Display(Name = "Переносимый вес")]
    public double CarryWeight { get; set; }


    [Display(Name = "Пулестойкость")]
    public double BulletResistance { get; set; }


    [Display(Name = "Защита от разрыва")]
    public double LacerationProtection { get; set; }


    [Display(Name = "Защита от взрыва")]
    public double ExplosionProtection { get; set; }


    [Display(Name = "Электрозащита")]
    public double ResistanceToElectricity { get; set; }


    [Display(Name = "Защита от огня")]
    public double ResistanceToFire { get; set; }


    [Display(Name = "Химзащита")]
    public double ResistanceToChemicals { get; set; }


    [Display(Name = "Защита от радиации")]
    public double RadiationProtection { get; set; }


    [Display(Name = "Защита от температуры")]
    public double ThermalProtection { get; set; }


    [Display(Name = "Защита от биозаражения")]
    public double BioinfectionProtection { get; set; }


    [Display(Name = "Защита от пси-излучения")]
    public double PsyProtection { get; set; }


    [Display(Name = "Защита от кровотечения")]
    public double BleedingProtection { get; set; }


    [Display(Name = "Совместимые рюкзаки")]
    [MaxLength(40)]
    public string? CompatibleBackpacks { get; set; }


    [Display(Name = "Совместимые контейнеры")]
    [MaxLength(40)]
    public string? CompatibleContainers { get; set; }


    [Display(Name = "Особенности")]
    [MaxLength(500)]
    public string? Features { get; set; }


    [Display(Name = "Описание")]
    [MaxLength(1000)]
    public string? Description { get; set; }
}
