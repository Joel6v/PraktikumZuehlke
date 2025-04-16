USE zuehlkepraktikum;
-- To execute this with MySQL Workbench, you must change the prefernces from the editor
-- Make sure the Ids matches with the foreign keys, Id's start at 1
-- Move the folder 'Images' into the 'secure_file.priv' folder and may change the path from the variable '@folder'
GRANT FILE ON *.* TO 'root'@'localhost';
SHOW VARIABLES LIKE 'secure_file_priv';
SET @folder = 'C:\\Program Files\\MySQL\\MySQL Server 8.0\\Uploads\\Image\\';
SELECT LOAD_FILE(CONCAT(@folder, 'Weapon\\dagger.png')) IS NOT NULL AS 'Weapon Dagger exists?'; -- checks if the files are existing and accessable
-- -----------------------------------------------------
-- Table 'race'
-- -----------------------------------------------------
DELETE FROM race;
INSERT INTO race (name, health, magicka, stamina, skill, imageMale, imageFemale) VALUES
('Nord', 85, 40, 85, 1, LOAD_FILE(CONCAT(@folder, 'Race\\Female\\robin.png')), LOAD_FILE(CONCAT(@folder, 'Race\\Female\\robin.png'))),
('Redguard', 85, 55, 70, 2, LOAD_FILE(CONCAT(@folder, 'Race\\Female\\robin.png')), LOAD_FILE(CONCAT(@folder, 'Race\\Female\\robin.png'))),
('Altmer', 50, 100, 60, 3, LOAD_FILE(CONCAT(@folder, 'Race\\Female\\robin.png')), LOAD_FILE(CONCAT(@folder, 'Race\\Female\\robin.png'))),
('Orc', 100, 55, 60, 0, LOAD_FILE(CONCAT(@folder, 'Race\\Female\\robin.png')), LOAD_FILE(CONCAT(@folder, 'Race\\Female\\robin.png'))),
('Khajit', 65, 45, 100, 4, LOAD_FILE(CONCAT(@folder, 'Race\\Female\\robin.png')), LOAD_FILE(CONCAT(@folder, 'Race\\Female\\robin.png')));

-- -----------------------------------------------------
-- Tables from type 'clothing'
-- -----------------------------------------------------
DELETE FROM headgear;
INSERT INTO headgear (name, defense, image) VALUES
('None', 1, LOAD_FILE(CONCAT(@folder, 'Clothing\\Headwear\\headwear_none.png'))),
('Cowl', 1, LOAD_FILE(CONCAT(@folder, 'Clothing\\Headwear\\cowl.png'))),
('Fine Hat', 1, LOAD_FILE(CONCAT(@folder, 'Clothing\\Headwear\\fine_hat.png'))),
('Hat', 1, LOAD_FILE(CONCAT(@folder, 'Clothing\\Headwear\\hat.png')));
DELETE FROM chest;
INSERT INTO chest (name, defense, image) VALUES
('None', 2, LOAD_FILE(CONCAT(@folder, 'Clothing\\Body\\Body_none.png'))),
('Ragged Robes', 2, LOAD_FILE(CONCAT(@folder, 'Clothing\\Body\\ragged_robes.png'))),
('Ragged Trousers', 2, LOAD_FILE(CONCAT(@folder, 'Clothing\\Body\\ragged_trousers.png')));
DELETE FROM gloves;
INSERT INTO gloves (name, defense, image) VALUES
('None', 1, LOAD_FILE(CONCAT(@folder, 'Clothing\\Gloves\\gloves_none.png'))),
('Vampire', 1, LOAD_FILE(CONCAT(@folder, 'Clothing\\Gloves\\vampire_gloves.png')));
DELETE FROM legs;
INSERT INTO legs (name, defense, image) VALUES
('None', 1, LOAD_FILE(CONCAT(@folder, 'Clothing\\Shoes\\shoes_none.png'))),
('Vampire Boots', 1, LOAD_FILE(CONCAT(@folder, 'Clothing\\Shoes\\vampire_boots.png')));

-- -----------------------------------------------------
-- Table 'weapon'
-- -----------------------------------------------------
DELETE FROM weapon;
INSERT INTO weapon (name, damagePerHit, attackSpeed, image) VALUES
('Dagger', 14, 3, LOAD_FILE(CONCAT(@folder, 'Weapon\\dagger.png'))),
('Sword', 31, 1, LOAD_FILE(CONCAT(@folder, 'Weapon\\sword.png'))),
('War Axe', 34, 0, LOAD_FILE(CONCAT(@folder, 'Weapon\\war_axe.png'))),
('Bow', 17, 2, LOAD_FILE(CONCAT(@folder, 'Weapon\\bow.png'))),
('Staff', 22, 1, LOAD_FILE(CONCAT(@folder, 'Weapon\\staff.png')));

-- -----------------------------------------------------
-- Table 'consumable'
-- -----------------------------------------------------
DELETE FROM consumable;
INSERT INTO consumable (name, image) VALUES
('None', LOAD_FILE(CONCAT(@folder, 'Consumable\\consumable_none.png'))),
('Potion', LOAD_FILE(CONCAT(@folder, 'Consumable\\potion.png'))),
('Poison', LOAD_FILE(CONCAT(@folder, 'Consumable\\poison.png'))),
('Scroll', LOAD_FILE(CONCAT(@folder, 'Consumable\\scroll.png'))),
('Food', LOAD_FILE(CONCAT(@folder, 'Consumable\\food.png'))),
('Ingredient', LOAD_FILE(CONCAT(@folder, 'Consumable\\ingredient.png'))),
('Lockpick', LOAD_FILE(CONCAT(@folder, 'Consumable\\lockpick.png')));

-- -----------------------------------------------------
-- Table 'user'
-- -----------------------------------------------------
DELETE FROM user;
INSERT INTO user (name, password, timestamp) VALUES
('TestUser1', '532eaabd9574880dbf76b9b8cc00832c20a6ec113d682299550d7a6e0f345e25', NOW()); -- Password: Test

-- -----------------------------------------------------
-- Table 'character'
-- -----------------------------------------------------
DELETE FROM characterconfiguration;
INSERT INTO characterconfiguration (name, timestamp, userId, raceId, headgearId, chestId, glovesId, legsId, weaponId, consumableId) VALUES
('TestCharacter', NOW(), 1, 1, 1, 1, 1, 1, 1, 1);