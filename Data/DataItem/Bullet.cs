using System.ComponentModel.DataAnnotations;

namespace StalNoteSite.Data.DataItem;

public class Bullet
{
    public Bullet() { }

    [Display(Name = "Id")]
    public int Id { get; set; }

    //+
    [Display(Name = "Stalcraft Id")]
    [MaxLength(20)]
    public string ItemId { get; set; }


    [Display(Name = "Разброс")]
    public double Spread { get; set; }


    [Display(Name = "Урон")]
    public double Damage { get; set; }


    [Display(Name = "Число поражающих эл-тов")]
    public double NumberOfProjectiles { get; set; }


    [Display(Name = "Под Тип")]
    [MaxLength(30)]
    public string SubType { get; set; }
    //+
    [Display(Name = "Тип")]
    [MaxLength(30)]
    public string Type { get; set; }

    //+
    [Display(Name = "Название")]
    [MaxLength(50)]
    public string Name { get; set; }

    //+
    [Display(Name = "Класс")]
    [MaxLength(30)]
    public string Class { get; set; }

    //+
    [Display(Name = "Вес")]
    public double Weight { get; set; }


    [Display(Name = "Тип Патрона")]
    [MaxLength(30)]
    public string AmmoType { get; set; }


    [Display(Name = "Бронебойность")]
    public double ArmorPenetration { get; set; }


    [Display(Name = "Кровотечение")]
    public double Bleeding { get; set; }


    [Display(Name = "Останавливающее действие")]
    public double StoppingPower { get; set; }


    [Display(Name = "Горение")]
    public double Burning { get; set; }
}
