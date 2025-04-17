USE zuehlkepraktikum;
-- To execute this with MySQL Workbench, you must change the prefernces from the editor
-- Make sure the Ids matches with the foreign keys, Id's start at 1
-- Move the folder 'Images' into the 'secure_file.priv' folder and may change the path from the variable '@folder'
GRANT FILE ON *.* TO 'root'@'localhost';
SHOW VARIABLES LIKE 'secure_file_priv';
SET @folder = 'C:\\ProgramData\\MySQL\\MySQL Server 8.0\\Uploads\\Image\\';
SELECT LOAD_FILE(CONCAT(@folder, 'Weapon\\dagger.png')) IS NOT NULL AS 'Weapon Dagger exists?'; -- checks if the files are existing and accessable
-- -----------------------------------------------------
-- Table 'race'
-- -----------------------------------------------------
DELETE FROM race;
INSERT INTO race (name, health, magicka, stamina, skill, imageMale, imageFemale) VALUES
('Nord', 85, 40, 85, 1, LOAD_FILE(CONCAT(@folder, 'Race\\Male\\nord.png')), LOAD_FILE(CONCAT(@folder, 'Race\\Female\\nord.png'))),
('Redguard', 85, 55, 70, 2, LOAD_FILE(CONCAT(@folder, 'Race\\Male\\redguard.png')), LOAD_FILE(CONCAT(@folder, 'Race\\Female\\redguard.png'))),
('Altmer', 50, 100, 60, 3, LOAD_FILE(CONCAT(@folder, 'Race\\Male\\altmer.png')), LOAD_FILE(CONCAT(@folder, 'Race\\Female\\altmer.png'))),
('Orc', 100, 55, 60, 0, LOAD_FILE(CONCAT(@folder, 'Race\\Male\\orc.png')), LOAD_FILE(CONCAT(@folder, 'Race\\Female\\orc.png'))),
('Khajiit', 65, 45, 100, 4, LOAD_FILE(CONCAT(@folder, 'Race\\Male\\khajiit.png')), LOAD_FILE(CONCAT(@folder, 'Race\\Female\\khajiit.png')));

-- -----------------------------------------------------
-- Tables from type 'clothing'
-- -----------------------------------------------------
DELETE FROM headgear;
INSERT INTO headgear (name, defense, image) VALUES
('None', 0, LOAD_FILE(CONCAT(@folder, 'Clothing\\Headwear\\headwear_none.png'))),
('Chefs Hat', 3, LOAD_FILE(CONCAT(@folder, 'Clothing\\Headwear\\chefs_hat.png'))),
('Cowl', 3, LOAD_FILE(CONCAT(@folder, 'Clothing\\Headwear\\cowl.png'))),
('Fine Hat', 2, LOAD_FILE(CONCAT(@folder, 'Clothing\\Headwear\\fine_hat.png'))),
('Hat', 1, LOAD_FILE(CONCAT(@folder, 'Clothing\\Headwear\\hat.png')));
DELETE FROM chest;
INSERT INTO chest (name, defense, image) VALUES
('None', 0, LOAD_FILE(CONCAT(@folder, 'Clothing\\Body\\body_none.png'))),
('Blue Clothes', 3, LOAD_FILE(CONCAT(@folder, 'Clothing\\Body\\blue_clothes.png'))),
('Yellow Clothes', 3, LOAD_FILE(CONCAT(@folder, 'Clothing\\Body\\yellow_clothes.png'))),
('Blue Dress', 3, LOAD_FILE(CONCAT(@folder, 'Clothing\\Body\\blue_dress.png'))),
('Brown Dress', 3, LOAD_FILE(CONCAT(@folder, 'Clothing\\Body\\brown_dress.png'))),
('White Tunic', 3, LOAD_FILE(CONCAT(@folder, 'Clothing\\Body\\white_tunic.png'))),
('Chefs Tunic', 6, LOAD_FILE(CONCAT(@folder, 'Clothing\\Body\\chefs_tunic.png'))),
('Fine Clothes', 5, LOAD_FILE(CONCAT(@folder, 'Clothing\\Body\\fine_clothes.png'))),
('Ragged Robes', 4, LOAD_FILE(CONCAT(@folder, 'Clothing\\Body\\ragged_robes.png'))),
('Ragged Trousers', 4, LOAD_FILE(CONCAT(@folder, 'Clothing\\Body\\ragged_trousers.png')));
DELETE FROM gloves;
INSERT INTO gloves (name, defense, image) VALUES
('None', 0, LOAD_FILE(CONCAT(@folder, 'Clothing\\Gloves\\gloves_none.png'))),
('Brown Gloves', 1, LOAD_FILE(CONCAT(@folder, 'Clothing\\Gloves\\gloves.png'))),
('Mystic Gloves', 5, LOAD_FILE(CONCAT(@folder, 'Clothing\\Gloves\\mystic_gloves.png'))),
('Shrouded Gloves', 3, LOAD_FILE(CONCAT(@folder, 'Clothing\\Gloves\\shrouded_gloves.png'))),
('Vampire Gloves', 4, LOAD_FILE(CONCAT(@folder, 'Clothing\\Gloves\\vampire_gloves.png')));
DELETE FROM legs;
INSERT INTO legs (name, defense, image) VALUES
('None', 0, LOAD_FILE(CONCAT(@folder, 'Clothing\\Shoes\\shoes_none.png'))),
('Boots', 3, LOAD_FILE(CONCAT(@folder, 'Clothing\\Shoes\\boots.png'))),
('Footwraps', 1, LOAD_FILE(CONCAT(@folder, 'Clothing\\Shoes\\footwraps.png'))),
('Vampire Boots', 4, LOAD_FILE(CONCAT(@folder, 'Clothing\\Shoes\\vampire_boots.png'))),
('Wrapped Boots', 2, LOAD_FILE(CONCAT(@folder, 'Clothing\\Shoes\\wrapped_boots.png')));
-- -----------------------------------------------------
-- Table 'weapon'
-- -----------------------------------------------------
DELETE FROM weapon;
INSERT INTO weapon (name, damagePerHit, attackSpeed, image) VALUES
('None', 3, 2, LOAD_FILE(CONCAT(@folder, 'Weapon\\weapon_none.png'))),
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
-- INSERT INTO user (name, password, timestamp) VALUES
-- ('User1', 'E6FA3CA87B1B641AB646D3B4933BBA8D0970763F030B6578A60ABDEAE7366247', NOW()); -- Password: Test

-- -----------------------------------------------------
-- Table 'character'
-- -----------------------------------------------------
DELETE FROM characterconfiguration;
-- INSERT INTO characterconfiguration (name, timestamp, userId, raceId, headgearId, chestId, glovesId, legsId, weaponId, consumableId) VALUES
-- ('TestCharacter', NOW(), 1, 1, 1, 1, 1, 1, 1, 1);