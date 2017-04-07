BEGIN TRANSACTION;
CREATE TABLE "SyncListFinding" (
	`id`	INTEGER,
	`name`	TEXT NOT NULL,
	`colorJson`	TEXT,
	`texturePath`	TEXT,
	PRIMARY KEY(`id`)
);
INSERT INTO `SyncListFinding` VALUES (1,'Pale Skin','{"r":0.99, "g":0.87, "b":0.80, "a":1.0}','0');
INSERT INTO `SyncListFinding` VALUES (3,'Tanned Skin','{"r":0.83, "g":0.70, "b":0.52, "a":1.0}','0');
INSERT INTO `SyncListFinding` VALUES (4,'Dark Skin','{"r":0.65, "g":0.49, "b":0.47, "a":1.0}','0');
INSERT INTO `SyncListFinding` VALUES (5,'Low Oxygen','{"r":0.90, "g":0.93, "b":1.0, "a":1.0}','0');
INSERT INTO `SyncListFinding` VALUES (6,'Purple Rash','0','Textures/purpleRash');
COMMIT;
