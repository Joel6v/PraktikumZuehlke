namespace CharacterConfigurator.Model.DbEnum
{
    public enum ModelTypeDb
    {
        [StringDbTable("characterConfiguration")] //New name in the DB, because character is a syntax name
        [StringDbColumns(["name", "user_userId", "race_raceId", "clothing_headgearId", "clothing_chestId", "clothing_glovesId", "clothing_legsId", "weapon_weaponId", "consumable_consumableId"])]
        [ColumnAmountImage(0)]
        CHARACTER,
        [StringDbTable("clothing")]
        [StringDbColumns(["name", "defense", "clothingType", "image"])]
        [ColumnAmountImage(1)]
        CLOTHING, 
        [StringDbTable("consumable")]
        [StringDbColumns(["name", "image"])]
        [ColumnAmountImage(1)]
        CONSUMABLE,
        [StringDbTable("race")]
        [StringDbColumns(["name", "health", "magicka", "stamina", "skill", "sex", "imageMale", "imageFemale"])]
        [ColumnAmountImage(2)]
        RACE,
        [StringDbTable("user")]
        [StringDbColumns(["name", "password"])]
        [ColumnAmountImage(0)]
        USER,
        [StringDbTable("weapon")]
        [StringDbColumns(["name", "damagePerHit", "attackSpeed", "image"])]
        [ColumnAmountImage(1)]
        WEAPON
    }
}
