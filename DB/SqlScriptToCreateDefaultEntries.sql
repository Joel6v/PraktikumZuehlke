USE zuehlkepraktikum;
-- To execute this with MySQL Workbench, you must change the prefernces from the editor
-- Make sure the Ids matches with the foreign keys, Id's start at 1
-- -----------------------------------------------------
-- Table 'race'
-- -----------------------------------------------------
DELETE FROM race;
INSERT INTO race (name, health, magicka, stamina, skill, imageMale, imageFemale) VALUES
('Nord', 85, 40, 85, 1, LOAD_FILE(''), LOAD_FILE('')),
('Redguard', 85, 55, 70, 2, LOAD_FILE(''), LOAD_FILE('')),
('Altmer', 50, 100, 60, 3, LOAD_FILE(''), LOAD_FILE('')),
('Orc', 100, 55, 60, 0, LOAD_FILE(''), LOAD_FILE('')),
('Khajit', 65, 45, 100, 4, LOAD_FILE(''), LOAD_FILE(''));

-- -----------------------------------------------------
-- Tables from type 'clothing'
-- -----------------------------------------------------
DELETE FROM headgear;
INSERT INTO headhear (name, defense, image) VALUE
('Default Headgear', 1, LOAD_FILE(''));
DELETE FROM chest;
INSERT INTO chest (name, defense, image) VALUE
('Default Chest', 2, LOAD_FILE(''));
DELETE FROM gloves;
INSERT INTO gloves (name, defense, image) VALUE
('Default Gloves', 1, LOAD_FILE(''));
DELETE FROM legs;
INSERT INTO legs (name, defense, image) VALUE
('Default Legs', 1, LOAD_FILE(''));

-- -----------------------------------------------------
-- Table 'weapon'
-- -----------------------------------------------------
DELETE FROM weapon;
INSERT INTO weapon (name, damagePerHit, attackSpeed, image) VALUES
('Dagger', 14, 3, LOAD_FILE('')),
('Sword', 31, 1, LOAD_FILE('')),
('War Axe', 34, 0, LOAD_FILE('')),
('Bow', 17, 2, LOAD_FILE('')),
('Staff', 22, 1, LOAD_FILE(''));

-- -----------------------------------------------------
-- Table 'consumable'
-- -----------------------------------------------------
DELETE FROM consumable;
INSERT INTO consumable (name, image) VALUES
('Potion', LOAD_FILE('')),
('Scroll', LOAD_FILE('')),
('Food', LOAD_FILE('')),
('Ingredient', LOAD_FILE('')),
('Lockpick', LOAD_FILE(''));

-- -----------------------------------------------------
-- Table 'user'
-- -----------------------------------------------------
DELETE FROM user;
INSERT INTO user (name, password, timestamp) VALUE
('TestUser1', '532eaabd9574880dbf76b9b8cc00832c20a6ec113d682299550d7a6e0f345e25', NOW()); -- Password: Test

-- -----------------------------------------------------
-- Table 'character'
-- -----------------------------------------------------
DELETE FROM characterconfiguration;
INSERT INTO characterconfiguration (name, timestamp, userId, raceId, headgearId, chestId, glovesId, legsId, weaponId, consumableId) VALUE
('TestCharacter', NOW(), 1, 1, 1, 1, 1, 1, 1, 1);