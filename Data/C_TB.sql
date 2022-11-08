-- --------------------------------------------------------
-- Хост:                         .
-- Версия сервера:               Microsoft SQL Server 2019 (RTM-GDR) (KB4583458) - 15.0.2080.9
-- Операционная система:         Windows 10 Pro 10.0 <X64> (Build 19042: )
-- HeidiSQL Версия:              11.2.0.6213
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES  */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Дамп структуры базы данных ComissionTB
DROP DATABASE IF EXISTS "ComissionTB";
CREATE DATABASE IF NOT EXISTS "ComissionTB";
USE "ComissionTB";

-- Дамп структуры для таблица ComissionTB.AspNetRoleClaims
DROP TABLE IF EXISTS "AspNetRoleClaims";
CREATE TABLE IF NOT EXISTS "AspNetRoleClaims" (
	"Id" INT NOT NULL,
	"RoleId" INT NOT NULL,
	"ClaimType" NVARCHAR(max) NULL DEFAULT NULL COLLATE 'Cyrillic_General_CI_AS',
	"ClaimValue" NVARCHAR(max) NULL DEFAULT NULL COLLATE 'Cyrillic_General_CI_AS',
	PRIMARY KEY ("Id"),
	FOREIGN KEY INDEX "FK_AspNetRoleClaims_AspNetRoles_RoleId" ("RoleId"),
	CONSTRAINT "FK_AspNetRoleClaims_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "AspNetRoles" ("Id") ON UPDATE NO_ACTION ON DELETE CASCADE
);

-- Дамп данных таблицы ComissionTB.AspNetRoleClaims: -1 rows
/*!40000 ALTER TABLE "AspNetRoleClaims" DISABLE KEYS */;
/*!40000 ALTER TABLE "AspNetRoleClaims" ENABLE KEYS */;

-- Дамп структуры для таблица ComissionTB.AspNetRoles
DROP TABLE IF EXISTS "AspNetRoles";
CREATE TABLE IF NOT EXISTS "AspNetRoles" (
	"Id" INT NOT NULL,
	"Descript" NVARCHAR(30) NULL DEFAULT NULL COLLATE 'Cyrillic_General_CI_AS',
	"Name" NVARCHAR(256) NULL DEFAULT NULL COLLATE 'Cyrillic_General_CI_AS',
	"NormalizedName" NVARCHAR(256) NULL DEFAULT NULL COLLATE 'Cyrillic_General_CI_AS',
	"ConcurrencyStamp" NVARCHAR(max) NULL DEFAULT NULL COLLATE 'Cyrillic_General_CI_AS',
	PRIMARY KEY ("Id")
);

-- Дамп данных таблицы ComissionTB.AspNetRoles: -1 rows
/*!40000 ALTER TABLE "AspNetRoles" DISABLE KEYS */;
INSERT INTO "AspNetRoles" ("Id", "Descript", "Name", "NormalizedName", "ConcurrencyStamp") VALUES
	(1, 'Администратор', 'admin', 'ADMIN', '57f04138-f811-424e-9701-742523db861f'),
	(2, 'Председатель', 'preds', 'PREDS', '0b923875-e37f-4fa8-b978-85e4e0fa635d'),
	(3, 'Секретарь', 'secr', 'SECR', 'e58022c3-dc92-49eb-8e6a-af286ff9c035'),
	(4, 'Член комиссии', 'comission', 'COMISSION', 'e592051f-d6c8-40f4-a7c8-6296b41dabc2'),
	(5, 'Пользователь', 'ordinal', 'ORDINAL', '1c4ffccd-615c-4370-9593-1c2de84b289a'),
	(6, 'Начальник цеха', 'npodr', 'NPODR', '1c4ffccd-615c-4370-9593-1c2de84b289y');
/*!40000 ALTER TABLE "AspNetRoles" ENABLE KEYS */;

-- Дамп структуры для таблица ComissionTB.AspNetUserClaims
DROP TABLE IF EXISTS "AspNetUserClaims";
CREATE TABLE IF NOT EXISTS "AspNetUserClaims" (
	"Id" INT NOT NULL,
	"UserId" INT NOT NULL,
	"ClaimType" NVARCHAR(max) NULL DEFAULT NULL COLLATE 'Cyrillic_General_CI_AS',
	"ClaimValue" NVARCHAR(max) NULL DEFAULT NULL COLLATE 'Cyrillic_General_CI_AS',
	PRIMARY KEY ("Id"),
	FOREIGN KEY INDEX "FK_AspNetUserClaims_AspNetUsers_UserId" ("UserId"),
	CONSTRAINT "FK_AspNetUserClaims_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON UPDATE NO_ACTION ON DELETE CASCADE
);

-- Дамп данных таблицы ComissionTB.AspNetUserClaims: -1 rows
/*!40000 ALTER TABLE "AspNetUserClaims" DISABLE KEYS */;
/*!40000 ALTER TABLE "AspNetUserClaims" ENABLE KEYS */;

-- Дамп структуры для таблица ComissionTB.AspNetUserLogins
DROP TABLE IF EXISTS "AspNetUserLogins";
CREATE TABLE IF NOT EXISTS "AspNetUserLogins" (
	"LoginProvider" NVARCHAR(450) NOT NULL COLLATE 'Cyrillic_General_CI_AS',
	"ProviderKey" NVARCHAR(450) NOT NULL COLLATE 'Cyrillic_General_CI_AS',
	"ProviderDisplayName" NVARCHAR(max) NULL DEFAULT NULL COLLATE 'Cyrillic_General_CI_AS',
	"UserId" INT NOT NULL,
	PRIMARY KEY ("LoginProvider", "ProviderKey"),
	FOREIGN KEY INDEX "FK_AspNetUserLogins_AspNetUsers_UserId" ("UserId"),
	CONSTRAINT "FK_AspNetUserLogins_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON UPDATE NO_ACTION ON DELETE CASCADE
);

-- Дамп данных таблицы ComissionTB.AspNetUserLogins: -1 rows
/*!40000 ALTER TABLE "AspNetUserLogins" DISABLE KEYS */;
/*!40000 ALTER TABLE "AspNetUserLogins" ENABLE KEYS */;

-- Дамп структуры для таблица ComissionTB.AspNetUserRoles
DROP TABLE IF EXISTS "AspNetUserRoles";
CREATE TABLE IF NOT EXISTS "AspNetUserRoles" (
	"UserId" INT NOT NULL,
	"RoleId" INT NOT NULL,
	PRIMARY KEY ("RoleId", "UserId"),
	FOREIGN KEY INDEX "FK_AspNetUserRoles_AspNetRoles_RoleId" ("RoleId"),
	FOREIGN KEY INDEX "FK_AspNetUserRoles_AspNetUsers_UserId" ("UserId"),
	CONSTRAINT "FK_AspNetUserRoles_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "AspNetRoles" ("Id") ON UPDATE NO_ACTION ON DELETE CASCADE,
	CONSTRAINT "FK_AspNetUserRoles_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON UPDATE NO_ACTION ON DELETE CASCADE
);

-- Дамп данных таблицы ComissionTB.AspNetUserRoles: -1 rows
/*!40000 ALTER TABLE "AspNetUserRoles" DISABLE KEYS */;
INSERT INTO "AspNetUserRoles" ("UserId", "RoleId") VALUES
	(1, 1),
	(1, 4),
	(2, 4),
	(2, 5),
	(2, 6),
	(3, 2),
	(3, 3),
	(3, 4),
	(3, 6),
	(4, 4),
	(4, 6),
	(5, 4),
	(6, 2),
	(6, 5),
	(6, 6),
	(8, 5),
	(8, 6),
	(11, 5),
	(11, 6);
/*!40000 ALTER TABLE "AspNetUserRoles" ENABLE KEYS */;

-- Дамп структуры для таблица ComissionTB.AspNetUsers
DROP TABLE IF EXISTS "AspNetUsers";
CREATE TABLE IF NOT EXISTS "AspNetUsers" (
	"Id" INT NOT NULL,
	"tabNo" INT NOT NULL,
	"userFio" NVARCHAR(50) NOT NULL COLLATE 'Cyrillic_General_CI_AS',
	"userFirstName" NVARCHAR(50) NOT NULL COLLATE 'Cyrillic_General_CI_AS',
	"userSecName" NVARCHAR(50) NULL DEFAULT NULL COLLATE 'Cyrillic_General_CI_AS',
	"userPriem" DATETIME2(7) NOT NULL,
	"userDismis" DATETIME2(7) NULL DEFAULT NULL,
	"dolgnid_dl" INT NULL DEFAULT NULL,
	"UserName" NVARCHAR(256) NULL DEFAULT NULL COLLATE 'Cyrillic_General_CI_AS',
	"NormalizedUserName" NVARCHAR(256) NULL DEFAULT NULL COLLATE 'Cyrillic_General_CI_AS',
	"Email" NVARCHAR(256) NULL DEFAULT NULL COLLATE 'Cyrillic_General_CI_AS',
	"NormalizedEmail" NVARCHAR(256) NULL DEFAULT NULL COLLATE 'Cyrillic_General_CI_AS',
	"EmailConfirmed" BIT NOT NULL,
	"PasswordHash" NVARCHAR(max) NULL DEFAULT NULL COLLATE 'Cyrillic_General_CI_AS',
	"SecurityStamp" NVARCHAR(max) NULL DEFAULT NULL COLLATE 'Cyrillic_General_CI_AS',
	"ConcurrencyStamp" NVARCHAR(max) NULL DEFAULT NULL COLLATE 'Cyrillic_General_CI_AS',
	"PhoneNumber" NVARCHAR(max) NULL DEFAULT NULL COLLATE 'Cyrillic_General_CI_AS',
	"PhoneNumberConfirmed" BIT NOT NULL,
	"TwoFactorEnabled" BIT NOT NULL,
	"LockoutEnd" DATETIMEOFFSET NULL DEFAULT NULL,
	"LockoutEnabled" BIT NOT NULL,
	"AccessFailedCount" INT NOT NULL,
	PRIMARY KEY ("Id"),
	FOREIGN KEY INDEX "FK_AspNetUsers_tDolgn_dolgnid_dl" ("dolgnid_dl"),
	CONSTRAINT "FK_AspNetUsers_tDolgn_dolgnid_dl" FOREIGN KEY ("dolgnid_dl") REFERENCES "tDolgn" ("id_dl") ON UPDATE NO_ACTION ON DELETE NO_ACTION
);

-- Дамп данных таблицы ComissionTB.AspNetUsers: -1 rows
/*!40000 ALTER TABLE "AspNetUsers" DISABLE KEYS */;
INSERT INTO "AspNetUsers" ("Id", "tabNo", "userFio", "userFirstName", "userSecName", "userPriem", "userDismis", "dolgnid_dl", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount") VALUES
	(1, 1, 'Админов', 'Админ', 'Админыч', '2020-11-10 00:00:00.0000000', NULL, 1, 'admin@mail.ru', 'ADMIN@MAIL.RU', 'admin@mail.ru', 'ADMIN@MAIL.RU', b'0', 'AQAAAAEAACcQAAAAEOKdd1UjJzrnGKzq8g6h76la/3Q/AL/d9ruU07AKqnusXpOj6b2SuhbK0v79D44vCA==', '5FH2PLE2I52LTU2Z5D2JD2X3C6MJ5WQS', '0f8839ee-045b-43fb-a5b8-94fefae38fdc', NULL, b'0', b'0', NULL, b'0', 0),
	(2, 0, 'Мирошкин', 'Василий', 'Михайлович', '2019-10-19 00:00:00.0000000', NULL, 3, 'mirosh@mail.ru', 'MIROSH@MAIL.RU', 'mirosh@mail.ru', 'MIROSH@MAIL.RU', b'0', 'AQAAAAEAACcQAAAAEDQDDBAV0doRmukzVI5W3tRebl1FmKrQeX4qKRY9OM7zUaozQkECbkRbWps7meXCUA==', 'EQCAJBI4FHNA3IMABXCYOXYKNGJ4EHEN', '49287776-8cf0-45e8-b77c-4db0c488b9a8', NULL, b'0', b'0', NULL, b'1', 0),
	(3, 0, 'Коноплева', 'Мария', 'Семеновна', '2018-11-24 00:00:00.0000000', NULL, 2, 'konopa@admin.ru', 'KONOPA@ADMIN.RU', 'konopa@admin.ru', 'KONOPA@ADMIN.RU', b'0', 'AQAAAAEAACcQAAAAECQ/oF4yg+cha3gstmHCh/Ot9a5CnhXI0eD6sf5mXJEe5glPNMM2DVU8b/ZJAMLyhw==', 'UM2RYGLDRCE5SGNPSNPDFGFBT7ODX7AI', 'fd00aff0-86e0-440d-b409-d8ca08a30f36', NULL, b'0', b'0', NULL, b'1', 0),
	(4, 0, 'Кривонос ', 'Евгений', 'Олегович', '2019-08-16 00:00:00.0000000', NULL, 3, 'nos@mail.ru', 'NOS@MAIL.RU', 'nos@mail.ru', 'NOS@MAIL.RU', b'0', 'AQAAAAEAACcQAAAAEBIHBTiIcFwrYpL6D2bljge1sXcyRY8C4A+UFXDg+3DebRwfAu3743L2NVZjUvNhwQ==', 'DHHX2ASK5IFWA6JWL7WD56M7LRGJ5KB7', 'be19dd81-3b55-435f-a361-119393d86410', NULL, b'0', b'0', NULL, b'1', 0),
	(5, 0, 'Косолапов', 'Михаил', 'Семенович', '0001-01-01 00:00:00.0000000', NULL, 5, 'k-lapa@maail.ru', 'K-LAPA@MAAIL.RU', 'k-lapa@maail.ru', 'K-LAPA@MAAIL.RU', b'0', 'AQAAAAEAACcQAAAAEIQecvAohUmriOtlWsZFc7b4eZOpsib3z+vnNdSq4ot037S1QvL0cwTJd8X8ODXZJQ==', '4YJK5YH3BXMWVDSSNA5HECMLATLQM53D', '8cc9ed50-5ea6-4b02-b0d6-263358609fbf', NULL, b'0', b'0', NULL, b'1', 0),
	(6, 0, 'Потапов', 'Николай', 'Михайлович', '2021-03-14 00:00:00.0000000', NULL, 6, 'nikol@mail.ru', 'NIKOL@MAIL.RU', 'nikol@mail.ru', 'NIKOL@MAIL.RU', b'0', 'AQAAAAEAACcQAAAAENeI3gdnsb9820Jn7vk3kojEgyCFirMBGy3VbPZJ9y8STcikGR/R4gY4s7NtHWcQuw==', 'SQ4KEXFDEHWSZIH46VQB7PWSJ5IMHYMY', '2e740f58-8df8-4bb8-b1be-23c20b1061bb', NULL, b'0', b'0', NULL, b'1', 0),
	(8, 0, 'Пилипцов', 'Николай ', 'Михайлович', '2021-01-12 00:00:00.0000000', NULL, 9, 'pilip@mail.ru', 'PILIP@MAIL.RU', 'pilip@mail.ru', 'PILIP@MAIL.RU', b'0', 'AQAAAAEAACcQAAAAEK6xcJOGXoNc7UaIsD8ncj2oe5Nrdl0GahGm3YTxbxjBkF8SLEEGeax2/ZRF5mYvZA==', 'C3AY22IROWSEYD2VY3CPQK3PDPKBSF7S', 'bb7c6636-e231-49a1-b887-934d65529380', NULL, b'0', b'0', NULL, b'1', 0),
	(9, 0, 'Костин', 'Потап', 'Николаевич', '2019-01-14 00:00:00.0000000', NULL, 3, 'kostin@mail.ru', 'KOSTIN@MAIL.RU', 'kostin@mail.ru', 'KOSTIN@MAIL.RU', b'0', 'AQAAAAEAACcQAAAAELbQ1x8i2DgkpuhPyg0lFZeBZxA+uptgdCxq7lQBBgdcmUTFupqRq6tI81M7tPYWNQ==', 'OPG34MYZZQPBAA6QQMD2J26Q5DOKZ3WZ', 'b623c142-e721-4892-b148-e0fd19c5ecc2', NULL, b'0', b'0', NULL, b'1', 0),
	(11, 0, 'Зубакин', 'Алексей', 'Петрович', '0001-01-01 00:00:00.0000000', NULL, 3, 'zuba@mail.ru', 'ZUBA@MAIL.RU', 'zuba@mail.ru', 'ZUBA@MAIL.RU', b'0', 'AQAAAAEAACcQAAAAEKFUvkoKISV13GHRamRUwOTpesXcVDO0s2PRMboltRwWjyyxh2ITIsjR6TvIjWVI6g==', 'XBL2Q7PYQMXCH3EJWYHWYC4NBX3OOZ73', '78f9361c-ab78-4851-b937-b28f1095988b', NULL, b'0', b'0', NULL, b'1', 0);
/*!40000 ALTER TABLE "AspNetUsers" ENABLE KEYS */;

-- Дамп структуры для таблица ComissionTB.AspNetUserTokens
DROP TABLE IF EXISTS "AspNetUserTokens";
CREATE TABLE IF NOT EXISTS "AspNetUserTokens" (
	"UserId" INT NOT NULL,
	"LoginProvider" NVARCHAR(450) NOT NULL COLLATE 'Cyrillic_General_CI_AS',
	"Name" NVARCHAR(450) NOT NULL COLLATE 'Cyrillic_General_CI_AS',
	"Value" NVARCHAR(max) NULL DEFAULT NULL COLLATE 'Cyrillic_General_CI_AS',
	PRIMARY KEY ("LoginProvider", "Name", "UserId"),
	FOREIGN KEY INDEX "FK_AspNetUserTokens_AspNetUsers_UserId" ("UserId"),
	CONSTRAINT "FK_AspNetUserTokens_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON UPDATE NO_ACTION ON DELETE CASCADE
);

-- Дамп данных таблицы ComissionTB.AspNetUserTokens: -1 rows
/*!40000 ALTER TABLE "AspNetUserTokens" DISABLE KEYS */;
/*!40000 ALTER TABLE "AspNetUserTokens" ENABLE KEYS */;

-- Дамп структуры для таблица ComissionTB.cex
DROP TABLE IF EXISTS "cex";
CREATE TABLE IF NOT EXISTS "cex" (
	"id_cex" INT NOT NULL,
	"cexName" NVARCHAR(100) NOT NULL COLLATE 'Cyrillic_General_CI_AS',
	"appUserId" INT NULL DEFAULT NULL,
	PRIMARY KEY ("id_cex"),
	FOREIGN KEY INDEX "FK_cex_AspNetUsers_appUserId" ("appUserId"),
	CONSTRAINT "FK_cex_AspNetUsers_appUserId" FOREIGN KEY ("appUserId") REFERENCES "AspNetUsers" ("Id") ON UPDATE NO_ACTION ON DELETE NO_ACTION
);

-- Дамп данных таблицы ComissionTB.cex: -1 rows
/*!40000 ALTER TABLE "cex" DISABLE KEYS */;
INSERT INTO "cex" ("id_cex", "cexName", "appUserId") VALUES
	(1, 'Сборочный', 4),
	(2, 'Автоматно-Высадочный', 5),
	(3, 'Административный', 6),
	(4, 'Автоматно-Сварочный', 2),
	(5, 'Покрасочный', 8),
	(7, 'Гальванический', 11);
/*!40000 ALTER TABLE "cex" ENABLE KEYS */;

-- Дамп структуры для таблица ComissionTB.mailSetting
DROP TABLE IF EXISTS "mailSetting";
CREATE TABLE IF NOT EXISTS "mailSetting" (
	"PostMail" NVARCHAR(250) NULL DEFAULT NULL COLLATE 'Cyrillic_General_CI_AS',
	"PostSmtp" NVARCHAR(250) NULL DEFAULT NULL COLLATE 'Cyrillic_General_CI_AS',
	"PostPort" INT NOT NULL,
	"PostPass" NVARCHAR(max) NULL DEFAULT NULL COLLATE 'Cyrillic_General_CI_AS',
	"mail_id" INT NOT NULL,
	PRIMARY KEY ("mail_id")
);

-- Дамп данных таблицы ComissionTB.mailSetting: -1 rows
/*!40000 ALTER TABLE "mailSetting" DISABLE KEYS */;
INSERT INTO "mailSetting" ("PostMail", "PostSmtp", "PostPort", "PostPass", "mail_id") VALUES
	(NULL, 'smtp.yandex.ru', 25, NULL, 1);
/*!40000 ALTER TABLE "mailSetting" ENABLE KEYS */;

-- Дамп структуры для таблица ComissionTB.tAkt
DROP TABLE IF EXISTS "tAkt";
CREATE TABLE IF NOT EXISTS "tAkt" (
	"aktNo" INT NOT NULL,
	"cexid_cex" INT NULL DEFAULT NULL,
	"aktDate" DATETIME2(7) NOT NULL DEFAULT 'getdate()',
	"ocenka" NVARCHAR(max) NULL DEFAULT NULL COLLATE 'Cyrillic_General_CI_AS',
	"PredsIdId" INT NULL DEFAULT NULL,
	"SekrIdId" INT NULL DEFAULT NULL,
	"aktNum" INT NOT NULL DEFAULT '(0)',
	"SoglCnt" INT NOT NULL DEFAULT '(0)',
	"SoglHave" INT NOT NULL DEFAULT '(0)',
	"SoglPreds" BIT NULL DEFAULT NULL,
	"SoglSecr" BIT NULL DEFAULT NULL,
	PRIMARY KEY ("aktNo"),
	FOREIGN KEY INDEX "FK_tAkt_cex_cexid_cex" ("cexid_cex"),
	FOREIGN KEY INDEX "FK_tAkt_AspNetUsers_PredsIdId" ("PredsIdId"),
	FOREIGN KEY INDEX "FK_tAkt_AspNetUsers_SekrIdId" ("SekrIdId"),
	CONSTRAINT "FK_tAkt_cex_cexid_cex" FOREIGN KEY ("cexid_cex") REFERENCES "cex" ("id_cex") ON UPDATE NO_ACTION ON DELETE NO_ACTION,
	CONSTRAINT "FK_tAkt_AspNetUsers_PredsIdId" FOREIGN KEY ("PredsIdId") REFERENCES "AspNetUsers" ("Id") ON UPDATE NO_ACTION ON DELETE NO_ACTION,
	CONSTRAINT "FK_tAkt_AspNetUsers_SekrIdId" FOREIGN KEY ("SekrIdId") REFERENCES "AspNetUsers" ("Id") ON UPDATE NO_ACTION ON DELETE NO_ACTION
);

-- Дамп данных таблицы ComissionTB.tAkt: -1 rows
/*!40000 ALTER TABLE "tAkt" DISABLE KEYS */;
INSERT INTO "tAkt" ("aktNo", "cexid_cex", "aktDate", "ocenka", "PredsIdId", "SekrIdId", "aktNum", "SoglCnt", "SoglHave", "SoglPreds", "SoglSecr") VALUES
	(1, 4, '0001-01-01 00:00:00.0000000', NULL, 6, 3, 1, 2, 0, b'0', b'0'),
	(2, 2, '0001-01-01 00:00:00.0000000', NULL, 6, 3, 2, 2, 0, b'0', b'0'),
	(3, 4, '2021-03-03 00:00:00.0000000', NULL, 6, 3, 3, 4, 0, b'0', b'0'),
	(5, 4, '2021-03-30 00:00:00.0000000', NULL, 6, 3, 5, 3, 0, b'0', b'0'),
	(6, 4, '2021-03-30 00:00:00.0000000', NULL, 5, 3, 6, 4, 0, b'0', b'0'),
	(10, 3, '2021-04-15 00:00:00.0000000', 'удовлетворительно', 5, 3, 10, 4, 3, b'1', b'1'),
	(11, 5, '2021-04-14 00:00:00.0000000', 'удовлетворительно', 6, 3, 14, 2, 0, b'0', b'0'),
	(12, 7, '2021-04-30 00:00:00.0000000', NULL, 6, 3, 8452, 2, 0, b'0', b'0');
/*!40000 ALTER TABLE "tAkt" ENABLE KEYS */;

-- Дамп структуры для таблица ComissionTB.tDolgn
DROP TABLE IF EXISTS "tDolgn";
CREATE TABLE IF NOT EXISTS "tDolgn" (
	"id_dl" INT NOT NULL,
	"dlName" NVARCHAR(50) NOT NULL COLLATE 'Cyrillic_General_CI_AS',
	PRIMARY KEY ("id_dl")
);

-- Дамп данных таблицы ComissionTB.tDolgn: -1 rows
/*!40000 ALTER TABLE "tDolgn" DISABLE KEYS */;
INSERT INTO "tDolgn" ("id_dl", "dlName") VALUES
	(1, 'Системный администратор'),
	(2, 'Гл. бухгалтер'),
	(3, 'Начальник цеха'),
	(4, 'Ст. мастер'),
	(5, 'Начальник участка'),
	(6, 'Гл. инженер'),
	(7, 'Мастер'),
	(8, 'Директор'),
	(9, 'Инженер ОТБ');
/*!40000 ALTER TABLE "tDolgn" ENABLE KEYS */;

-- Дамп структуры для таблица ComissionTB.tPom
DROP TABLE IF EXISTS "tPom";
CREATE TABLE IF NOT EXISTS "tPom" (
	"id_pom" INT NOT NULL,
	"pomName" NVARCHAR(100) NOT NULL COLLATE 'Cyrillic_General_CI_AS',
	"cexid_cex" INT NULL DEFAULT NULL,
	PRIMARY KEY ("id_pom"),
	FOREIGN KEY INDEX "FK_tPom_cex_cexid_cex" ("cexid_cex"),
	CONSTRAINT "FK_tPom_cex_cexid_cex" FOREIGN KEY ("cexid_cex") REFERENCES "cex" ("id_cex") ON UPDATE NO_ACTION ON DELETE NO_ACTION
);

-- Дамп данных таблицы ComissionTB.tPom: -1 rows
/*!40000 ALTER TABLE "tPom" DISABLE KEYS */;
INSERT INTO "tPom" ("id_pom", "pomName", "cexid_cex") VALUES
	(1, 'Караульное', 2),
	(2, 'Бытовое', 2),
	(3, 'Приема пищи', 2),
	(4, 'Караульное', 4),
	(5, 'Каб. директора', 3),
	(6, 'Каб. гл. бухгалтера', 3),
	(7, 'Бухгалтерия', 3),
	(8, 'Отдел кадров', 3),
	(9, 'Основное производственное', 5),
	(10, 'Проходная цеха', 5),
	(11, 'Комната отдыха', 5),
	(13, 'Основное производственное', 7),
	(14, 'Камера гальванопокрытия', 7),
	(15, 'Транспортная проходная', 7),
	(16, 'Проходная №1', 7),
	(17, 'Проходная №2', 7);
/*!40000 ALTER TABLE "tPom" ENABLE KEYS */;

-- Дамп структуры для таблица ComissionTB.tPredp
DROP TABLE IF EXISTS "tPredp";
CREATE TABLE IF NOT EXISTS "tPredp" (
	"prNo" INT NOT NULL,
	"prText" NVARCHAR(max) NOT NULL COLLATE 'Cyrillic_General_CI_AS',
	"prDate" DATETIME2(7) NOT NULL,
	"prIspNote" NVARCHAR(max) NOT NULL COLLATE 'Cyrillic_General_CI_AS',
	"prIspDate" DATETIME2(7) NOT NULL,
	"aktNo" INT NULL DEFAULT NULL,
	"appUserId" INT NULL DEFAULT NULL,
	"pomid_pom" INT NULL DEFAULT NULL,
	"osnova" NVARCHAR(max) NULL DEFAULT NULL COLLATE 'Cyrillic_General_CI_AS',
	PRIMARY KEY ("prNo"),
	FOREIGN KEY INDEX "FK_tPredp_AspNetUsers_appUserId" ("appUserId"),
	FOREIGN KEY INDEX "FK_tPredp_tAkt_aktNo" ("aktNo"),
	FOREIGN KEY INDEX "FK_tPredp_tPom_pomid_pom" ("pomid_pom"),
	CONSTRAINT "FK_tPredp_tAkt_aktNo" FOREIGN KEY ("aktNo") REFERENCES "tAkt" ("aktNo") ON UPDATE NO_ACTION ON DELETE NO_ACTION,
	CONSTRAINT "FK_tPredp_AspNetUsers_appUserId" FOREIGN KEY ("appUserId") REFERENCES "AspNetUsers" ("Id") ON UPDATE NO_ACTION ON DELETE NO_ACTION,
	CONSTRAINT "FK_tPredp_tPom_pomid_pom" FOREIGN KEY ("pomid_pom") REFERENCES "tPom" ("id_pom") ON UPDATE NO_ACTION ON DELETE NO_ACTION
);

-- Дамп данных таблицы ComissionTB.tPredp: -1 rows
/*!40000 ALTER TABLE "tPredp" DISABLE KEYS */;
INSERT INTO "tPredp" ("prNo", "prText", "prDate", "prIspNote", "prIspDate", "aktNo", "appUserId", "pomid_pom", "osnova") VALUES
	(2, 'Заменить огнетушитель', '2021-03-18 00:00:00.0000000', 'Заменен на новый.', '2021-03-04 00:00:00.0000000', 3, 5, 3, 'Основание не требуется'),
	(3, 'Оформить плакаты о пожарной безопасности', '2021-03-03 00:00:00.0000000', '', '0001-01-01 00:00:00.0000000', 3, 5, 4, 'Основание не требуется'),
	(4, 'Заменить огнетушитель', '2021-04-10 00:00:00.0000000', 'Произведена замена огнетушителя', '2021-04-06 00:00:00.0000000', 6, 5, 2, 'Основание не требуется'),
	(5, 'Оформить стенд противопож. безопасности', '2021-04-07 00:00:00.0000000', '', '0001-01-01 00:00:00.0000000', 6, NULL, 2, 'Основание не требуется'),
	(6, 'Освободить запасный выход', '2021-04-07 00:00:00.0000000', '', '0001-01-01 00:00:00.0000000', 6, 5, 4, 'Основание не требуется'),
	(7, 'Замена огнетушителя', '2021-04-13 00:00:00.0000000', '', '0001-01-01 00:00:00.0000000', 5, NULL, 3, 'Основание не требуется'),
	(8, 'Оформить плакаты по ТБ', '2021-04-08 00:00:00.0000000', '', '0001-01-01 00:00:00.0000000', 5, NULL, 4, 'Основание не требуется'),
	(9, 'Очистить подход к запасному выходу', '2021-04-15 00:00:00.0000000', '', '0001-01-01 00:00:00.0000000', 10, NULL, 7, 'Основание не требуется'),
	(11, 'Убрать коробки', '2021-04-30 00:00:00.0000000', '', '0001-01-01 00:00:00.0000000', 10, NULL, 8, 'Основание не требуется'),
	(12, 'Убрать мусор возле транспортных ворот', '2021-05-07 00:00:00.0000000', '', '0001-01-01 00:00:00.0000000', 11, NULL, 10, 'Основание не требуется'),
	(13, 'Починить замок запасного выхода', '2021-05-06 00:00:00.0000000', '', '0001-01-01 00:00:00.0000000', 11, NULL, 11, 'Основание не требуется');
/*!40000 ALTER TABLE "tPredp" ENABLE KEYS */;

-- Дамп структуры для таблица ComissionTB.tSostav
DROP TABLE IF EXISTS "tSostav";
CREATE TABLE IF NOT EXISTS "tSostav" (
	"id_st" INT NOT NULL,
	"aktNo" INT NULL DEFAULT NULL,
	"userId" INT NULL DEFAULT NULL,
	"isSogl" BIT NULL DEFAULT NULL,
	PRIMARY KEY ("id_st"),
	FOREIGN KEY INDEX "FK_tSostav_AspNetUsers_userId" ("userId"),
	FOREIGN KEY INDEX "FK_tSostav_tAkt_aktNo" ("aktNo"),
	CONSTRAINT "FK_tSostav_tAkt_aktNo" FOREIGN KEY ("aktNo") REFERENCES "tAkt" ("aktNo") ON UPDATE NO_ACTION ON DELETE NO_ACTION,
	CONSTRAINT "FK_tSostav_AspNetUsers_userId" FOREIGN KEY ("userId") REFERENCES "AspNetUsers" ("Id") ON UPDATE NO_ACTION ON DELETE NO_ACTION
);

-- Дамп данных таблицы ComissionTB.tSostav: -1 rows
/*!40000 ALTER TABLE "tSostav" DISABLE KEYS */;
INSERT INTO "tSostav" ("id_st", "aktNo", "userId", "isSogl") VALUES
	(3, 6, 4, NULL),
	(4, 3, 4, NULL),
	(5, 3, 2, NULL),
	(6, 6, 5, NULL),
	(8, 5, 2, NULL),
	(9, 10, 2, b'1'),
	(10, 10, 4, NULL);
/*!40000 ALTER TABLE "tSostav" ENABLE KEYS */;

-- Дамп структуры для таблица ComissionTB.__EFMigrationsHistory
DROP TABLE IF EXISTS "__EFMigrationsHistory";
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
	"MigrationId" NVARCHAR(150) NOT NULL COLLATE 'Cyrillic_General_CI_AS',
	"ProductVersion" NVARCHAR(32) NOT NULL COLLATE 'Cyrillic_General_CI_AS',
	PRIMARY KEY ("MigrationId")
);

-- Дамп данных таблицы ComissionTB.__EFMigrationsHistory: -1 rows
/*!40000 ALTER TABLE "__EFMigrationsHistory" DISABLE KEYS */;
INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES
	('20210308045032_mg-000', '5.0.3'),
	('20210314134739_mg-001', '5.0.4'),
	('20210315034251_mg-002', '5.0.4'),
	('20210328062603_mg-003', '5.0.4'),
	('20210328100337_mg-004', '5.0.4'),
	('20210328215838_mg-005', '5.0.4'),
	('20210328220615_mg-006', '5.0.4'),
	('20210329214030_mg-007', '5.0.4'),
	('20210330103153_mg-008', '5.0.4'),
	('20210331183320_mg-009', '5.0.4'),
	('20210404134033_mg-010', '5.0.4'),
	('20210407155258_mg-011', '5.0.4'),
	('20210408185907_mg-012', '5.0.4'),
	('20210421082310_mg-013', '5.0.4'),
	('20210422104149_mg-014', '5.0.4'),
	('20210422113009_mg-015', '5.0.4'),
	('20210422113156_mg-016', '5.0.4'),
	('20210422121131_mg-017', '5.0.4'),
	('20210424061234_mg-018', '5.0.4'),
	('20210424065632_mg-019', '5.0.4');
/*!40000 ALTER TABLE "__EFMigrationsHistory" ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
