--
-- Table structure for `characters` (A tábla szerkezete a `characters` táblához)
--

CREATE TABLE `characters` (
  `id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `class` varchar(6) NOT NULL,
  `health` int(5) NOT NULL,
  `equipped` varchar(128) NOT NULL,
  `acquired` varchar(128) NOT NULL,
  `currency` int(11) NOT NULL,
  `exp` int(11) NOT NULL,
  `stage` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Data for table `characters` (A tábla adatainak kiíratása `characters` tábla)
--

INSERT INTO `characters` (`id`, `user_id`, `class`, `health`, `equipped`, `acquired`, `currency`, `exp`, `stage`) VALUES
(1, 1, 'ranger', 100, '{MB1 : \"Shock Arrow\", MB2 : \"Shock Roller\"}', '{\"Shock Arrow\", \"Shock Roller\"}', 0, 0, 0),
(2, 2, 'ranger', 55, '{MB1 : \"Shock Arrow\", MB2 : \"Shock Roller\"}', '{\"Shock Arrow\", \"Shock Roller\"}', 0, 0, 0);

-- --------------------------------------------------------

--
-- Table structure for `mapscores` (A tábla szerkezete a `mapscores` táblához)
--

CREATE TABLE `mapscores` (
  `record_id` int(100) NOT NULL,
  `map_id` int(100) NOT NULL,
  `user_id` int(11) NOT NULL,
  `map_time` time NOT NULL,
  `health` int(11) NOT NULL,
  `score` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Data for table `mapscores` (A tábla adatainak kiíratása `mapscores` tábla)
--

INSERT INTO `mapscores` (`record_id`, `map_id`, `user_id`, `map_time`, `health`, `score`) VALUES
(1, 1, 2, '00:02:15', 200, 6500),
(2, 2, 3, '00:03:12', 200, 4000),
(3, 2, 1, '00:06:00', 145, 1450);

-- --------------------------------------------------------

--
-- Table structure for `sessions` (A tábla szerkezete a `sessions` táblához)
--

CREATE TABLE `sessions` (
  `id` int(11) NOT NULL,
  `token` int(11) NOT NULL,
  `character_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Data for table `sessions` (A tábla adatainak kiíratása `sessions` tábla)
--

INSERT INTO `sessions` (`id`, `token`, `character_id`) VALUES
(1, 1234, 2),
(2, 5678, 1);

-- --------------------------------------------------------

--
-- Table structure for `users` (A tábla szerkezete a `users` táblához)
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `nev` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `jelszo` char(128) NOT NULL,
  `regisztracioDatuma` timestamp NOT NULL DEFAULT current_timestamp(),
  `modositasDatuma` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Data for table `users` (A tábla adatainak kiíratása `users` tábla)
--

INSERT INTO `users` (`id`, `nev`, `email`, `jelszo`, `regisztracioDatuma`, `modositasDatuma`) VALUES
(1, 'asd', 'wasd@gmail.com', 'd404559f602eab6fd602ac7680dacbfaadd13630335e951f097af3900e9de176b6db28512f2e000b9d04fba5133e8b1c6e8df59db3a8ab9d60be4b97cc9e81db', '2024-01-03 22:32:52', '2024-01-29 13:17:45'),
(2, 'TestUser', 'test@email.com', 'fe2592b42a727e977f055947385b709cc82b16b9a87f88c6abf3900d65d0cdc3', '2024-01-08 14:44:33', '2024-01-08 14:44:33'),
(3, 'tanar', 'tanar@tanar.com', 'f98ceb6183689a37ac3b29acd239845008b5955417e68d17998a501f66943407', '2024-01-15 13:52:00', '2024-01-15 13:52:00'),
(4, 'each', 'each@moon.com', '9e78b43ea00edcac8299e0cc8df7f6f913078171335f733a21d5d911b6999132', '2024-01-16 11:52:31', '2024-01-16 11:52:31'),
(5, 'nonbinary', 'binary@non.com', '9a3a45d01531a20e89ac6ae10b0b0beb0492acd7216a368aa062d1a5fecaf9cd', '2024-01-18 11:31:04', '2024-01-18 11:31:04'),
(10, 'vfx', 'vfx@gmai.com', 'b0f7b137049a80f705de46ab408ec7797a6e6b5e1682fdff1b222aef9b144a2a232d1900d0be4801f6896261b4f55fa3148806070a2449594afb83458c997e96', '2024-02-28 10:43:00', '2024-02-28 10:43:00'),
(11, 'vf', 'vf', '95c914d92d2e70981be0f0acbf2a36670c8406a07ada88d0df71c0249c930368020594790435db2734aa7228833551a4d5d4d300e3d92ed23122e13071a183d8', '2024-02-28 10:43:56', '2024-02-28 10:43:56'),
(12, 'PJani', 'probajanos@gmail.com', '23ea1396a56a5116bb86fabd22cf0e798b07a26fd57904777d23a644dd32d7430c9a7a56aec382cc2a92ca5ba23bb8e4cda817be9413c85ba4803aa8601071c3', '2024-02-29 08:32:27', '2024-02-29 08:32:27'),
(13, 'thc', 'thc@gmail.com', '3c9909afec25354d551dae21590bb26e38d53f2173b8d3dc3eee4c047e7ab1c1eb8b85103e3be7ba613b31bb5c9c36214dc9f14a42fd7a2fdb84856bca5c44c2', '2024-02-29 09:43:10', '2024-02-29 09:43:10'),
(14, 'jahhh', 'kakaka@gmail.com', '3c9909afec25354d551dae21590bb26e38d53f2173b8d3dc3eee4c047e7ab1c1eb8b85103e3be7ba613b31bb5c9c36214dc9f14a42fd7a2fdb84856bca5c44c2', '2024-03-06 12:54:38', '2024-03-06 12:54:38'),
(19, 'kxv', 'kxv@gmail.com', '3c9909afec25354d551dae21590bb26e38d53f2173b8d3dc3eee4c047e7ab1c1eb8b85103e3be7ba613b31bb5c9c36214dc9f14a42fd7a2fdb84856bca5c44c2', '2024-03-25 14:03:55', '2024-03-25 14:03:55');

--
-- Indexes for the displayed tables
--

--
-- Indexes for table `characters` (A tábla indexei `characters` táblához)
--
ALTER TABLE `characters`
  ADD PRIMARY KEY (`id`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `mapscores` (A tábla indexei `mapscores` táblához)
--
ALTER TABLE `mapscores`
  ADD PRIMARY KEY (`record_id`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `sessions` (A tábla indexei `sessions` táblához)
--
ALTER TABLE `sessions`
  ADD PRIMARY KEY (`id`),
  ADD KEY `character_id` (`character_id`);

--
-- Indexes for table `users` (A tábla indexei `users` táblához)
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT values for the displayed tables
--

--
-- AUTO_INCREMENT for table `characters` (AUTO_INCREMENT a táblához `characters`)
--
ALTER TABLE `characters`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `mapscores` (AUTO_INCREMENT a táblához `mapscores`)
--
ALTER TABLE `mapscores`
  MODIFY `record_id` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `sessions` (AUTO_INCREMENT a táblához `sessions`)
--
ALTER TABLE `sessions`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `users` (AUTO_INCREMENT a táblához `users`)
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- Constraints for the displayed tables
--

--
-- Constraints for table `characters` (Megkötések a táblához `characters` táblához)
--
ALTER TABLE `characters`
  ADD CONSTRAINT `characters_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);

--
-- Constraints for table `mapscores` (Megkötések a táblához `mapscores` táblához)
--
ALTER TABLE `mapscores`
  ADD CONSTRAINT `mapscores_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);
--
-- Constraints for table `sessions` (Megkötések a táblához `sessions` táblához)
--
ALTER TABLE `sessions`
  ADD CONSTRAINT `sessions_ibfk_1` FOREIGN KEY (`character_id`) REFERENCES `characters` (`id`);
COMMIT;


-- PROCEDURE: changeEmail (changeEmail)
-- DESCRIPTION: Updates the email of a user in the users table. (Frissíti a felhasználó e-mail címét a users táblában.)
-- PARAMETERS:
--   - usernameIN: The username of the user. (A felhasználó felhasználóneve.)
--   - emailIN: The new email to be set. (Az új e-mail cím, amely beállításra kerül.)
--   - pwIN: The password of the user. (A felhasználó jelszava.)
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `changeEmail` (
  IN `usernameIN` VARCHAR(100),
  IN `emailIN` VARCHAR(100),
  IN `pwIN` CHAR(128)
)
BEGIN
  DECLARE temp INT;

  SELECT COUNT(*) INTO temp FROM users WHERE nev = usernameIN AND jelszo = pwIN;

  IF temp = 1 THEN
    UPDATE users SET email = emailIN WHERE nev = usernameIN;
    SELECT 'TRUE' AS 'result'; -- Successful insertion
  ELSE
    SELECT 'Nem található egyezés' AS 'result'; -- No match found
  END IF;
END //
DELIMITER ;

-- PROCEDURE: changePassword (changePassword)
-- DESCRIPTION: Updates the password of a user in the users table. (Frissíti a felhasználó jelszavát a users táblában.)
-- PARAMETERS:
--   - oldPW: The old password of the user. (A felhasználó régi jelszava.)
--   - newPW: The new password to be set. (Az új jelszó, amely beállításra kerül.)
--   - usernameIN: The username of the user. (A felhasználó felhasználóneve.)
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `changePassword` (
  IN `oldPW` CHAR(128),
  IN `newPW` CHAR(128),
  IN `usernameIN` VARCHAR(100)
)
BEGIN
  DECLARE temp INT;

  SELECT COUNT(*) INTO temp FROM users WHERE nev = usernameIN AND jelszo = oldPW;

  IF temp = 1 THEN
    UPDATE users SET jelszo = newPW WHERE nev = usernameIN;
    SELECT 'TRUE' AS 'result'; -- Successful insertion
  ELSE
    SELECT 'Nem található egyezés' AS 'result'; -- No match found
  END IF;
END //
DELIMITER ;

-- PROCEDURE: changeUsername (changeUsername)
-- DESCRIPTION: Updates the username of a user in the users table. (Frissíti a felhasználó felhasználónevét a users táblában.)
-- PARAMETERS:
--   - oldUsername: The old username of the user. (A felhasználó régi felhasználóneve.)
--   - pwIN: The password of the user. (A felhasználó jelszava.)
--   - newUsername: The new username to be set. (Az új felhasználónév, amely beállításra kerül.)
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `changeUsername` (
  IN `oldUsername` VARCHAR(100),
  IN `pwIN` CHAR(128),
  IN `newUsername` VARCHAR(100)
)
BEGIN
  DECLARE temp INT;

  SELECT COUNT(*) INTO temp FROM users WHERE nev = oldUsername AND jelszo = pwIN;

  IF temp = 1 THEN
    UPDATE users SET nev = newUsername WHERE nev = oldUsername;
    SELECT 'TRUE' AS 'result'; -- Successful insertion
  ELSE
    SELECT 'Nem található egyezés' AS 'result'; -- No match found
  END IF;
END //
DELIMITER ;

-- PROCEDURE: createCharacter (createCharacter)
-- DESCRIPTION: Creates a new character for a user in the characters table. (Létrehoz egy új karaktert a felhasználó számára a characters táblában.)
-- PARAMETERS:
--   - id_user: The ID of the user. (A felhasználó azonosítója.)
--   - result: The output parameter to store the result of the operation. (A művelet eredményének tárolására szolgáló kimeneti paraméter.)
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `createCharacter` (
  IN `id_user` INT(11),
  OUT `result` VARCHAR(100)
)
BEGIN
  DECLARE temp INT;
  SELECT COUNT(*) INTO temp FROM characters WHERE user_id = id_user;
  IF temp = 0 THEN
    INSERT INTO characters (user_id, class, health, equipped, acquired, currency, exp, stage)
    VALUES (id_user, "ranger", 100, '{MB1 : "Shock Arrow", MB2 : "Shock Roller"}' ,'{"Shock Arrow", "Shock Roller"}',0,0,0);
    SELECT 'TRUE' as 'result'; -- Successful insertion
  ELSE
    SELECT 'Már van karakter a felhasználónak' as 'result' ; -- User already has a character
  END IF;
END //
DELIMITER ;

-- PROCEDURE: getAllMapScores (getAllMapScores)
-- DESCRIPTION: Retrieves all map scores from the mapscores table. (Visszaadja az összes térkép pontszámot a mapscores táblából.)
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllMapScores` ()
BEGIN
  SELECT map_id, user_id, map_time, health, score FROM mapscores;
END //
DELIMITER ;

-- PROCEDURE: getCharacterData (getCharacterData)
-- DESCRIPTION: Retrieves character data based on the provided token from the characters table. (Visszaadja a karakteradatokat a megadott token alapján a characters táblából.)
-- PARAMETERS:
--   - tokenInput: The token used to identify the session. (A munkamenet azonosítására használt token.)
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `getCharacterData` (IN `tokenInput` INT(11))
BEGIN
  SELECT * FROM characters WHERE id IN (
    SELECT character_id FROM sessions WHERE token = tokenInput
  );
END //
DELIMITER ;

-- PROCEDURE: getMapScores (getMapScores)
-- DESCRIPTION: Retrieves map scores for a specific map from the mapscores table. (Visszaadja a térkép pontszámait egy adott térképről a mapscores táblából.)
-- PARAMETERS:
--   - mapID: The ID of the map. (A térkép azonosítója.)
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `getMapScores` (IN `mapID` INT)
BEGIN
  SELECT user_id, map_time, health, score FROM mapscores WHERE map_id = mapID;
END //
DELIMITER ;

-- PROCEDURE: getPlayerAllMapScores (getPlayerAllMapScores)
-- DESCRIPTION: Retrieves all map scores for a specific player from the mapscores table. (Visszaadja az összes térkép pontszámát egy adott játékosnak a mapscores táblából.)
-- PARAMETERS:
--   - userID: The ID of the player. (A játékos azonosítója.)
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `getPlayerAllMapScores` (IN `userID` INT)
BEGIN
  SELECT map_id, map_time, health, score FROM mapscores WHERE user_id = userID;
END //
DELIMITER ;

-- PROCEDURE: getPlayerMapScores (getPlayerMapScores)
-- DESCRIPTION: Retrieves map scores for a specific player and map from the mapscores table. (Visszaadja a térkép pontszámait egy adott játékosnak és térképnek a mapscores táblából.)
-- PARAMETERS:
--   - mapID: The ID of the map. (A térkép azonosítója.)
--   - userID: The ID of the player. (A játékos azonosítója.)
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `getPlayerMapScores` (IN `mapID` INT, IN `userID` INT)
BEGIN
  SELECT health, map_time, score FROM mapscores WHERE map_id = mapID AND user_id = userID;
END //
DELIMITER ;

-- PROCEDURE: registrateUser (registrateUser)
-- DESCRIPTION: Registers a new user in the users table. (Regisztrál egy új felhasználót a users táblában.)
-- PARAMETERS:
--   - emailIN: The email of the user. (A felhasználó e-mail címe.)
--   - usernameIN: The username of the user. (A felhasználó felhasználóneve.)
--   - passwordIN: The password of the user. (A felhasználó jelszava.)
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `registrateUser` (
  IN `emailIN` VARCHAR(100),
  IN `usernameIN` VARCHAR(100),
  IN `passwordIN` CHAR(128)
)
BEGIN
  DECLARE userCount INT;

  SELECT COUNT(*) INTO userCount FROM users WHERE nev = usernameIN OR email = emailIN;

  IF userCount = 0 THEN
    INSERT INTO users (nev, jelszo, email) VALUES (usernameIN, passwordIN, emailIN);
    SELECT 'TRUE' AS isDone;
  ELSE
    SELECT 'ERROR' AS isDone;
  END IF;
END //
DELIMITER ;

-- PROCEDURE: updateCharacterData (updateCharacterData)
-- DESCRIPTION: Updates the health of a character based on the provided token in the characters table. (Frissíti a karakter egészségét a megadott token alapján a characters táblában.)
-- PARAMETERS:
--   - tokenInput: The token used to identify the session. (A munkamenet azonosítására használt token.)
--   - healthInput: The new health value to be set. (Az új egészségérték, amely beállításra kerül.)
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `updateCharacterData` (IN `tokenInput` INT(11), IN `healthInput` INT(11))
BEGIN
  UPDATE characters SET health = healthInput WHERE id IN (
    SELECT character_id FROM sessions WHERE token = tokenInput
  );
  
    SELECT "TRUE" as 'result';
END //
DELIMITER ;

-- PROCEDURE: uploadMapScore (uploadMapScore)
-- DESCRIPTION: Uploads a new map score to the mapscores table. (Feltölt egy új térkép pontszámot a mapscores táblába.)
-- PARAMETERS:
--   - userID: The ID of the user. (A felhasználó azonosítója.)
--   - mapID: The ID of the map. (A térkép azonosítója.)
--   - healthIN: The health value achieved in the map. (A térképen elért egészségérték.)
--   - maptimeIN: The time taken to complete the map. (A térkép befejezéséhez szükséges idő.)
--   - scoresIN: The score achieved in the map. (A térképen elért pontszám.)
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `uploadMapScore` (
  IN `userID` INT(11),
  IN `mapID` INT(100),
  IN `healthIN` INT,
  IN `maptimeIN` TIME,
  IN `scoresIN` INT
)
BEGIN
  INSERT INTO mapscores (map_id, user_id, map_time, health, score)
  VALUES (mapID, userID, maptimeIN, healthIN, scoresIN);
  SELECT "TRUE" as 'result';
END //
DELIMITER ;

-- PROCEDURE: validateLogin (validateLogin)
-- DESCRIPTION: Validates the login credentials of a user in the users table. (Ellenőrzi a felhasználó bejelentkezési adatait a users táblában.)
-- PARAMETERS:
--   - usernameIN: The username of the user. (A felhasználó felhasználóneve.)
--   - passwordIN: The password of the user. (A felhasználó jelszava.)
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `validateLogin` (
  IN `usernameIN` VARCHAR(100),
  IN `passwordIN` CHAR(128)
)
BEGIN
  SELECT CASE WHEN EXISTS(
    SELECT nev, jelszo FROM users WHERE nev = usernameIN AND jelszo = passwordIN
  )
  THEN 'TRUE'
  ELSE 'FALSE'
  END AS 'isValid';
END //
DELIMITER ;
