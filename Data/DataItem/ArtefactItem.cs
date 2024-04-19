using System.ComponentModel.DataAnnotations;

namespace StalNoteSite.Data.DataItem;

public class ArtefactItem
{
    public ArtefactItem() { }


    [Display(Name = "Id")]
    public int Id { get; set; }


    [Display(Name = "StalCraft Id")]
    [MaxLength(10)]
    public string ItemId { get; set; }


    [Display(Name = "Тип")]
    [MaxLength(25)]
    public string Type { get; set; }


    [Display(Name = "Категория")]
    [MaxLength(30)]
    public string Category { get; set; }


    [Display(Name = "Подтип")]
    [MaxLength(30)]
    public string SubType { get; set; }


    [Display(Name = "Название")]
    [MaxLength(100)]
    public string Name { get; set; }


    [Display(Name = "Вес")]
    public double Weight { get; set; }


    [Display(Name = "Потенциал")]
    public int Pottential { get; set; }

    //Параметры влияющие на скорость передвижения пользователя
    #region Speed


    [Display(Name = "Максимальный переносимый вес")]
    public double CarryWeightMax { get; set; }


    [Display(Name = "Минимальный переносимый вес")]
    public double CarryWeightMin { get; set; }


    [Display(Name = "Максимальная скорость передвижения")]
    public double SpeedMax { get; set; }


    [Display(Name = "Минимальная скорость передвижения")]
    public double SpeedMin { get; set; }


    [Display(Name = "Максимальная выносливость")]
    public double StaminaMax { get; set; }


    [Display(Name = "Минимальная выносливость")]
    public double StaminaMin { get; set; }


    [Display(Name = "Максимальное восстановление выносливости")]
    public double StaminaRegenerationMax { get; set; }


    [Display(Name = "Минимальное восстановление выносливости")]
    public double StaminaRegenerationMin { get; set; }


    #endregion

    //Параметры увеличивающие живучесть
    #region Vitality

    [Display(Name = "Максимальная защита от разрыва")]
    public double LacerationProtectionMax { get; set; }


    [Display(Name = "Минимальная защита от разрыва")]
    public double LacerationProtectionMin { get; set; }


    [Display(Name = "Максимальная защита от взрыва")]
    public double ExplosionProtectionMax { get; set; }


    [Display(Name = "Минимальная защита от взрыва")]
    public double ExplosionProtectionMin { get; set; }


    [Display(Name = "Максимальная стойкость")]
    public double StabilityMax { get; set; }


    [Display(Name = "Минимальная стойкость")]
    public double StabilityMin { get; set; }


    [Display(Name = "Максимальная эффективность лечения")]
    public double HealingEffectivenessMax { get; set; }


    [Display(Name = "Минимальная эффективность лечения")]
    public double HealingEffectivenessMin { get; set; }


    [Display(Name = "Максимальная пулестойкость")]
    public double BulletResistanceMax { get; set; }


    [Display(Name = "Минимальная пулестойкость")]
    public double BulletResistanceMin { get; set; }


    [Display(Name = "Максимальная регенерация здоровьы")]
    public double HealthRegenerationMax { get; set; }


    [Display(Name = "Минимальная регенерация здоровьы")]
    public double HealthRegenerationMin { get; set; }


    [Display(Name = "Максимальная живучесть")]
    public double VitalityMax { get; set; }


    [Display(Name = "Минимальная живучесть")]
    public double VitalityMin { get; set; }


    [Display(Name = "Максимальное кровотечение")]
    public double BleedingMax { get; set; }


    [Display(Name = "Минимальное кровотечение")]
    public double BleedingMin { get; set; }


    #endregion

    //Заражения
    #region Infection


    [Display(Name = "Максимальное биологическое заражение")]
    public double BioinfectionInfectionMax { get; set; }


    [Display(Name = "Минимальное биологическое заражение")]
    public double BioinfectionInfectionMin { get; set; }


    [Display(Name = "Максимальное сопротивление биозаражению")]
    public double BioinfectionResistanceMax { get; set; }


    [Display(Name = "Минимальное сопротивление биозаражению")]
    public double BioinfectionResistanceMin { get; set; }


    [Display(Name = "Максимальная защита от биозаражения")]
    public double BioinfectionProtectionMax { get; set; }


    [Display(Name = "Минимальная защита от биозаражения")]
    public double BioinfectionProtectionMin { get; set; }


    [Display(Name = "Максимальное сопротивление Пси-излучение")]
    public double PsyEmissionsResistanceMax { get; set; }


    [Display(Name = "Минимальное сопротивление Пси-излучение")]
    public double PsyEmissionsResistanceMin { get; set; }


    [Display(Name = "Максимальная защита от пси-излучения")]
    public double PsyEmissionsProtectionMax { get; set; }


    [Display(Name = "Минимальная защита от пси-излучения")]
    public double PsyEmissionsProtectionMin { get; set; }


    [Display(Name = "Максимальное пси-излучение")]
    public double PsyEmissionsMax { get; set; }


    [Display(Name = "Минимальное пси-излучение")]
    public double PsyEmissionsMin { get; set; }


    [Display(Name = "Максимальная защита от Радиация")]
    public double RadiationProtectionMax { get; set; }


    [Display(Name = "Минимальная защита от Радиация")]
    public double RadiationProtectionMin { get; set; }


    [Display(Name = "Максимальное сопротивление Радиации")]
    public double RadiationResistanceMax { get; set; }


    [Display(Name = "Минимальное сопротивление Радиации")]
    public double RadiationResistanceMin { get; set; }


    [Display(Name = "Максимальноя радиация")]
    public double RadiationMax { get; set; }


    [Display(Name = "Минимальнрая радиация")]
    public double RadiationMin { get; set; }


    [Display(Name = "Максимальная защита от температура")]
    public double TemperatureProtectionMax { get; set; }


    [Display(Name = "Минимальная защита от температура")]
    public double TemperatureProtectionMin { get; set; }


    [Display(Name = "Максимальное сопротивление температуре")]
    public double TemperatureResistanceMax { get; set; }


    [Display(Name = "Минимальное сопротивление температуре")]
    public double TemperatureResistanceMin { get; set; }


    [Display(Name = "Максимальная температура")]
    public double TemperatureMax { get; set; }


    [Display(Name = "Минимальная температура")]
    public double TemperatureMin { get; set; }


    [Display(Name = "Максимальная защита от огня")]
    public double ResistToFireMax { get; set; }


    [Display(Name = "Минимальная защита от огня")]
    public double ResistToFireMin { get; set; }



    [Display(Name = "Максимальная химзащита")]
    public double ResistanceToChemicalsMax { get; set; }


    [Display(Name = "Минимальная химзащита")]
    public double ResistanceToChemicalsMin { get; set; }


    [Display(Name = "Максимальный холод")]
    public double FrostMax { get; set; }


    [Display(Name = "Минимальный холод")]
    public double FrostMin { get; set; }

    #endregion

    //Реакции на урон
    #region Reactions


    [Display(Name = "Максимальная реакция на разрыв")]
    public double ReactionToLacerationMax { get; set; }


    [Display(Name = "Минимальная реакция на разрыв")]
    public double ReactionToLacerationMin { get; set; }


    [Display(Name = "Максимальная реакция на электричество")]
    public double ReactionToElectricityMax { get; set; }


    [Display(Name = "Минимальная реакция на электричество")]
    public double ReactionToElectricityMin { get; set; }


    [Display(Name = "Максимальная реакция на хим. ожог")]
    public double ReactionToChemicalBurnsMin { get; set; }


    [Display(Name = "Минимальная реакция на хим. ожог")]
    public double ReactionToChemicalBurnsMax { get; set; }


    [Display(Name = "Максимальная реакция на ожог")]
    public double ReactionToBurnsMax { get; set; }


    [Display(Name = "Минимальная реакция на ожог")]
    public double ReactionToBurnsMin { get; set; }


    #endregion

    //Другие параметры
    #region Other


    [Display(Name = "Срабатывает при")]
    public double TriggersDamage { get; set; }


    [Display(Name = "Максимальоне снижает урон на")]
    public double ReducesDamageByMax { get; set; }


    [Display(Name = "Минимальное снижает урон на")]
    public double ReducesDamageByMin { get; set; }


    [Display(Name = "Максимальная перезарядка")]
    public double ReloadMax { get; set; }


    [Display(Name = "Минимальная перезарядка")]
    public double ReloadMin { get; set; }


    [Display(Name = "Максимальный заряд за активацию")]
    public double ChargeRequiredToActivateMax { get; set; }


    [Display(Name = "Минимальный заряд за активацию")]
    public double ChargeRequiredToActivateMin { get; set; }


    #endregion
}
