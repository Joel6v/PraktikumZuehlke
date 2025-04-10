using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Model.DbEnum
{
    public enum ModelTypeDb
    {
        [StringDbTable("character")]
        [StringDbColumns(["name", "sex", "user_userId", "race_raceId", "clothing_headgearId", "clothing_chestId", "clothing_glovesId", "clothing_legsId", "weapon_weaponId", "consumable_consumableId"])]
        CHARACTER,
        [StringDbTable("clothing")]
        [StringDbColumns(["name", "defense", "clothingType"])]
        CLOTHING,
        [StringDbTable("consumable")]
        [StringDbColumns(["name"])]
        CONSUMABLE,
        [StringDbTable("race")]
        [StringDbColumns(["name", "health", "magicka", "stamina", "skill"])]
        RACE,
        [StringDbTable("user")]
        [StringDbColumns(["name", "password"])]
        USER,
        [StringDbTable("weapon")]
        [StringDbColumns(["name", "damagePerHit", "attackSpeed"])]
        WEAPON
    }
}
