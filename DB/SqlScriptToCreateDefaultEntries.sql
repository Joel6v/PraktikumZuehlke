-- -----------------------------------------------------
-- Table 'race'
-- -----------------------------------------------------
INSERT INTO race (name, health, magicka, stamina, skill) VALUES
('Nord', 85, 40, 85, 1),
('Redguard', 85, 55, 70, 2),
('Altmer', 50, 100, 60, 3),
('Orc', 100, 55, 60, 0),
('Khajit', 65, 45, 100, 4);

-- -----------------------------------------------------
-- Table 'clothing'
-- -----------------------------------------------------
INSERT INTO clothing (name, defense, clothingType) VALUES
('Default Headgear', 1, 0),
('Default Chest', 2, 1),
('Default Gloves', 1, 2),
('Default Legs', 1, 3);

-- -----------------------------------------------------
-- Table 'weapon'
-- -----------------------------------------------------
INSERT INTO weapon (name, damagePerHit, attackSpeed) VALUES
('Daggers', 14, 3),
('Swords', 31, 1),
('War Axes', 34, 0),
('Bows', 17, 2),
('Staff', 22, 1);

-- -----------------------------------------------------
-- Table 'consumable'
-- -----------------------------------------------------
INSERT INTO consumable (name) VALUES
('Potion'),
('Scroll'),
('Food'),
('Ingredient'),
('Lockpick');

-- -----------------------------------------------------
-- Table 'consumable'
-- -----------------------------------------------------