-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Már 25. 15:10
-- Kiszolgáló verziója: 10.4.28-MariaDB
-- PHP verzió: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `augmentedanarchy`
--

DELIMITER $$
--
-- Eljárások
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `changeEmail` (IN `usernameIN` VARCHAR(100), IN `emailIN` VARCHAR(100), IN `pwIN` CHAR(128))   BEGIN
    DECLARE temp INT;

    SELECT COUNT(*) INTO temp FROM users WHERE nev = usernameIN and jelszo = pwIN;

	SELECT temp as 'darab';
    IF temp = 1 THEN
        UPDATE users SET email = emailIN WHERE nev = usernameIN;
        SELECT 'Sikeres beszúrás' AS 'result';
    ELSE
        SELECT 'Nem található egyezés' AS 'result';
    END IF;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `changePassword` (IN `oldPW` CHAR(128), IN `newPW` CHAR(128), IN `usernameIN` VARCHAR(100))   BEGIN
    DECLARE temp INT;

    SELECT COUNT(*) INTO temp FROM users WHERE nev = usernameIN and jelszo = oldPW;

	SELECT temp as 'darab';
    IF temp = 1 THEN
        UPDATE users SET jelszo = newPW WHERE nev = usernameIN;
        SELECT 'Sikeres beszúrás' AS 'result';
    ELSE
        SELECT 'Nem található egyezés' AS 'result';
    END IF;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `changeUsername` (IN `oldUsername` VARCHAR(100), IN `pwIN` CHAR(128), IN `newUsername` VARCHAR(100))   BEGIN
    DECLARE temp INT;

    SELECT COUNT(*) INTO temp FROM users WHERE nev = oldUsername and jelszo = pwIN;

	SELECT temp as 'darab';
    IF temp = 1 THEN
        UPDATE users SET nev = newUsername WHERE nev = oldUsername;
        SELECT 'Sikeres beszúrás' AS 'result';
    ELSE
        SELECT 'Nem található egyezés' AS 'result';
    END IF;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllMapScores` ()   SELECT map_id,user_id,map_time,health,score FROM mapscores$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getMapScores` (IN `mapID` INT)   SELECT user_id,map_time,health,score FROM mapscores WHERE map_id = mapID$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getPlayerAllMapScores` (IN `userID` INT)   SELECT map_id,map_time,health,score FROM mapscores WHERE user_id = userID$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getPlayerMapScores` (IN `mapID` INT, IN `userID` INT)   SELECT health,map_time,score FROM mapscores WHERE map_id = mapID AND user_id = userID$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `registrateUser` (IN `emailIN` VARCHAR(100), IN `usernameIN` VARCHAR(100), IN `passwordIN` CHAR(128))   BEGIN
    DECLARE userCount INT;

    SELECT COUNT(*) INTO userCount FROM users WHERE nev = usernameIN OR email = emailIN;

    IF userCount = 0 THEN
        INSERT INTO users (nev, jelszo, email) VALUES (usernameIN, passwordIN, emailIN);
        SELECT 'TRUE' AS isDone;
    ELSE
        SELECT 'ERROR' AS isDone;
    END IF;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `uploadMapScore` (IN `userID` INT(11), IN `mapID` INT(100), IN `healthIN` INT, IN `maptimeIN` TIME, IN `scoresIN` INT)   INSERT INTO mapscores (map_id,user_id,map_time,health,score) VALUES (mapID,userID,maptimeIN,healthIN,scoresIN)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `validateLogin` (IN `usernameIN` VARCHAR(100), IN `passwordIN` CHAR(128))   SELECT CASE WHEN EXISTS(
        SELECT nev, jelszo FROM users WHERE nev = usernameIN and jelszo = passwordIN
    )
    THEN 'TRUE'
    ELSE 'FALSE'
END AS 'isValid'$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `mapscores`
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
-- A tábla adatainak kiíratása `mapscores`
--

INSERT INTO `mapscores` (`record_id`, `map_id`, `user_id`, `map_time`, `health`, `score`) VALUES
(1, 1, 2, '00:02:15', 200, 6500),
(2, 2, 3, '00:03:12', 200, 4000),
(3, 2, 1, '00:06:00', 145, 1450);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `players`
--

CREATE TABLE `players` (
  `user_id` int(11) NOT NULL,
  `character_id` int(11) NOT NULL,
  `skills` varchar(200) NOT NULL,
  `inventory` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `users`
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
-- A tábla adatainak kiíratása `users`
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
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `mapscores`
--
ALTER TABLE `mapscores`
  ADD PRIMARY KEY (`record_id`),
  ADD KEY `user_id` (`user_id`);

--
-- A tábla indexei `players`
--
ALTER TABLE `players`
  ADD PRIMARY KEY (`character_id`),
  ADD KEY `user_id` (`user_id`);

--
-- A tábla indexei `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `mapscores`
--
ALTER TABLE `mapscores`
  MODIFY `record_id` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT a táblához `players`
--
ALTER TABLE `players`
  MODIFY `character_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `mapscores`
--
ALTER TABLE `mapscores`
  ADD CONSTRAINT `mapscores_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);

--
-- Megkötések a táblához `players`
--
ALTER TABLE `players`
  ADD CONSTRAINT `players_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
