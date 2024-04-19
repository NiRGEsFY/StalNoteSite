using System.ComponentModel.DataAnnotations;

namespace StalNoteSite.Data.DataItem;

public class CaseItem
{

    public CaseItem() { }

    [Display(Name = "Id")]
    public int Id { get; set; }

    //+
    [Display(Name = "Stalcraft Id")]
    [MaxLength(20)]
    public string ItemId { get; set; }

    //+
    [Display(Name = "Тип")]
    [MaxLength(50)]
    public string Type { get; set; }

    //+
    [Display(Name = "Тип Контейнера")]
    [MaxLength(50)]
    public string? CaseType { get; set; }

    //+
    [Display(Name = "Название")]
    [MaxLength(50)]
    public string Name { get; set; }

    //+
    [Display(Name = "Ранг")]
    [MaxLength(50)]
    public string Rank { get; set; }

    //+
    [Display(Name = "Класс")]
    [MaxLength(50)]
    public string Class { get; set; }

    //+
    [Display(Name = "Вес")]
    public double Weight { get; set; }


    [Display(Name = "Внутренняя защита")]
    public double InnerProtection { get; set; }


    [Display(Name = "Эффективность")]
    public double Effectiveness { get; set; }


    [Display(Name = "Вместимость")]
    public int Capacity { get; set; }

    [Display(Name = "Переносимый вес")]
    public double CarryWeight { get; set; }

    [Display(Name = "Температура")]
    public double Temperature { get; set; }


    [Display(Name = "Биологическое заражение")]
    public double BiologicalInfection { get; set; }


    [Display(Name = "Радиация")]
    public double Radiation { get; set; }


    [Display(Name = "Описание")]
    [MaxLength(1000)]
    public string? Description { get; set; }
}
