-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Jan 31. 10:40
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

CREATE DEFINER=`root`@`localhost` PROCEDURE `registrateUser` (IN `usernameIN` VARCHAR(100), IN `emailIN` VARCHAR(100), IN `passwordIN` CHAR(128))   BEGIN
    DECLARE userCount INT;

    SELECT COUNT(*) INTO userCount FROM users WHERE nev = usernameIN OR email = emailIN;

    IF userCount = 0 THEN
        INSERT INTO users (nev, jelszo, email) VALUES (usernameIN, passwordIN, emailIN);
        SELECT 'Sikeres beszúrás' AS isValid;
    ELSE
        SELECT 'Már létezik ilyen felhasználó' AS isValid;
    END IF;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `validateLogin` (IN `nevIN` VARCHAR(100), IN `jelszoIN` CHAR(128))   SELECT CASE WHEN EXISTS(
        SELECT nev, jelszo FROM users WHERE nev = nevIN and jelszo = jelszoIN
    )
    THEN 'TRUE'
    ELSE 'FALSE'
END AS 'isValid'$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `achievements`
--

CREATE TABLE `achievements` (
  `achievement_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `kills` int(11) NOT NULL,
  `elapsedTime` time NOT NULL,
  `bestTime` time NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `achievements`
--

INSERT INTO `achievements` (`achievement_id`, `user_id`, `kills`, `elapsedTime`, `bestTime`) VALUES
(1, 1, 10, '00:15:01', '00:11:01');

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
(5, 'nonbinary', 'binary@non.com', '9a3a45d01531a20e89ac6ae10b0b0beb0492acd7216a368aa062d1a5fecaf9cd', '2024-01-18 11:31:04', '2024-01-18 11:31:04');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `achievements`
--
ALTER TABLE `achievements`
  ADD PRIMARY KEY (`achievement_id`),
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
-- AUTO_INCREMENT a táblához `achievements`
--
ALTER TABLE `achievements`
  MODIFY `achievement_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT a táblához `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `achievements`
--
ALTER TABLE `achievements`
  ADD CONSTRAINT `achievements_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
