USE zuehlkepraktikum;
-- To execute this with MySQL Workbench, you must change the prefernces from the editor
-- Make sure the Ids matches with the foreign keys
-- -----------------------------------------------------
-- Table 'race'
-- -----------------------------------------------------
DELETE FROM race;
INSERT INTO race (name, health, magicka, stamina, skill, sex) VALUES
('Nord', 85, 40, 85, 1, 0),
('Redguard', 85, 55, 70, 2, 0),
('Altmer', 50, 100, 60, 3, 0),
('Orc', 100, 55, 60, 0, 0),
('Khajit', 65, 45, 100, 4, 0);

-- -----------------------------------------------------
-- Table 'clothing'
-- -----------------------------------------------------
DELETE FROM clothing;
INSERT INTO clothing (name, defense, clothingType) VALUES
('Default Headgear', 1, 0),
('Default Chest', 2, 1),
('Default Gloves', 1, 2),
('Default Legs', 1, 3);

-- -----------------------------------------------------
-- Table 'weapon'
-- -----------------------------------------------------
DELETE FROM weapon;
INSERT INTO weapon (name, damagePerHit, attackSpeed) VALUES
('Dagger', 14, 3),
('Sword', 31, 1),
('War Axe', 34, 0),
('Bow', 17, 2),
('Staff', 22, 1);

-- -----------------------------------------------------
-- Table 'consumable'
-- -----------------------------------------------------
DELETE FROM consumable;
INSERT INTO consumable (name) VALUES
('Potion'),
('Scroll'),
('Food'),
('Ingredient'),
('Lockpick');

-- -----------------------------------------------------
-- Table 'user'
-- -----------------------------------------------------
DELETE FROM user;
INSERT INTO user (name, password) VALUE
('TestUser1', '532eaabd9574880dbf76b9b8cc00832c20a6ec113d682299550d7a6e0f345e25'); -- Password: Test

-- -----------------------------------------------------
-- Table 'character'
-- -----------------------------------------------------
DELETE FROM characterconfiguration;
INSERT INTO characterconfiguration (name, user_userId, race_raceId, clothing_headgearId, clothing_chestId, clothing_glovesId, clothing_legsId, weapon_weaponId, consumable_consumableId) VALUE
('TestCharacter', 1, 1, 1, 2, 3, 4, 1, 1);