namespace CharacterConfigurator.Model.DbEnum
{
    public enum ModelTypeDb
    {
        [StringDbTable("characterConfiguration")] //New name in the DB, because character is a syntax name
        [StringDbColumns(["name", "timestamp", "userId", "raceId", "headgearId", "chestId", "glovesId", "legsId", "weaponId", "consumableId", "sex"])]
        CHARACTER,
        [StringDbTable("consumable")]
        [StringDbColumns(["name", "image"])]
        CONSUMABLE,
        [StringDbTable("race")]
        [StringDbColumns(["name", "health", "magicka", "stamina", "skill", "sex", "imageMale", "imageFemale"])]
        RACE,
        [StringDbTable("user")]
        [StringDbColumns(["name", "password", "timestamp"])]
        USER,
        [StringDbTable("weapon")]
        [StringDbColumns(["name", "damagePerHit", "attackSpeed", "image"])]
        WEAPON,
        [StringDbTable("headgear")]
        [StringDbColumns(["name", "defense", "image"])]
        HEADGEAR,
        [StringDbTable("chest")]
        [StringDbColumns(["name", "defense", "image"])]
        CHEST,
        [StringDbTable("gloves")]
        [StringDbColumns(["name", "defense", "image"])]
        GLOVES,
        [StringDbTable("legs")]
        [StringDbColumns(["name", "defense", "image"])]
        LEGS
    }
}
