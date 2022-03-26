-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2022. Már 24. 14:41
-- Kiszolgáló verziója: 10.4.20-MariaDB
-- PHP verzió: 8.0.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `e-budget`
--
CREATE DATABASE IF NOT EXISTS `e-budget` DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;
USE `e-budget`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `categories_expense`
--

CREATE TABLE `categories_expense` (
  `id` int(11) NOT NULL,
  `name` varchar(50) COLLATE utf8_hungarian_ci NOT NULL,
  `user_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `categories_income`
--

CREATE TABLE `categories_income` (
  `id` int(11) NOT NULL,
  `name` varchar(50) COLLATE utf8_hungarian_ci NOT NULL,
  `user_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `currencies`
--

CREATE TABLE `currencies` (
  `id` int(11) NOT NULL,
  `currency_code` char(3) CHARACTER SET utf8 NOT NULL,
  `name` varchar(50) COLLATE utf8_hungarian_ci NOT NULL
) ENGINE=InnoDB AVG_ROW_LENGTH=2340 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `subcategories_expense`
--

CREATE TABLE `subcategories_expense` (
  `id` int(11) NOT NULL,
  `name` varchar(50) COLLATE utf8_hungarian_ci NOT NULL,
  `categories_expense_id` int(11) NOT NULL,
  `user_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `transactions_expense`
--

CREATE TABLE `transactions_expense` (
  `id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `date` datetime NOT NULL,
  `categories_expense_id` int(11) NOT NULL,
  `subcategories_expense_id` int(11) NOT NULL,
  `amount` double NOT NULL,
  `currency_id` int(11) NOT NULL,
  `comment` text COLLATE utf8_hungarian_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `transactions_income`
--

CREATE TABLE `transactions_income` (
  `id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `date` datetime NOT NULL,
  `categories_income_id` int(11) NOT NULL,
  `subcategories_income_id` int(11) DEFAULT NULL,
  `amount` double NOT NULL,
  `currency_id` int(11) NOT NULL,
  `comment` text COLLATE utf8_hungarian_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `name` varchar(50) COLLATE utf8_hungarian_ci NOT NULL,
  `email` varchar(64) COLLATE utf8_hungarian_ci NOT NULL,
  `password` varchar(64) COLLATE utf8_hungarian_ci NOT NULL,
  `currency_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- A nézet helyettes szerkezete `view_alltransactions`
-- (Lásd alább az aktuális nézetet)
--
CREATE TABLE `view_alltransactions` (
`UserId` int(11)
,`type` varchar(7)
,`id` int(11)
,`Category` varchar(50)
,`Subcategory` varchar(50)
,`Amount` double
,`Currency_code` char(3)
,`Date` datetime
,`Comment` mediumtext
);

-- --------------------------------------------------------

--
-- Nézet szerkezete `view_alltransactions`
--
DROP TABLE IF EXISTS `view_alltransactions`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_alltransactions`  AS SELECT
    `t_i`.`user_id` AS `UserId`,
    'income' AS `type`,
    `t_i`.`id` AS `id`,
    `c_i`.`name` AS `Category`,
    NULL AS `Subcategory`,
    `t_i`.`amount` AS `Amount`,
    `c`.`currency_code` AS `Currency_code`,
    `t_i`.`date` AS `Date`,
    `t_i`.`comment` AS `Comment`
FROM
    (
        (
            (
                `transactions_income` `t_i`
            JOIN `categories_income` `c_i`
            ON
                (
                    `t_i`.`categories_income_id` = `c_i`.`id`
                )
            )
        JOIN `currencies` `c`
        ON
            (`t_i`.`currency_id` = `c`.`id`)
        )
    JOIN `users` `u`
    ON
        (`t_i`.`user_id` = `u`.`id`)
    )
UNION
SELECT
    `t_e`.`user_id` AS `UserId`,
    'expense' AS `type`,
    `t_e`.`id` AS `id`,
    `c_e`.`name` AS `Category`,
    `s_e`.`name` AS `Subcategory`,
    `t_e`.`amount` AS `Amount`,
    `c`.`currency_code` AS `Currency_code`,
    `t_e`.`date` AS `Date`,
    `t_e`.`comment` AS `Comment`
FROM
    (
        (
            (
                (
                    `transactions_expense` `t_e`
                JOIN `categories_expense` `c_e`
                ON
                    (
                        `t_e`.`categories_expense_id` = `c_e`.`id`
                    )
                )
            JOIN `subcategories_expense` `s_e`
            ON
                (
                    `t_e`.`subcategories_expense_id` = `s_e`.`id`
                )
            )
        JOIN `currencies` `c`
        ON
            (`t_e`.`currency_id` = `c`.`id`)
        )
    JOIN `users` `u`
    ON
        (`t_e`.`user_id` = `u`.`id`)
    );

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `categories_expense`
--
ALTER TABLE `categories_expense`
  ADD PRIMARY KEY (`id`),
  ADD KEY `FK_categories_expense` (`user_id`);

--
-- A tábla indexei `categories_income`
--
ALTER TABLE `categories_income`
  ADD PRIMARY KEY (`id`),
  ADD KEY `FK_categories_income` (`user_id`);

--
-- A tábla indexei `currencies`
--
ALTER TABLE `currencies`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `currency_code` (`currency_code`);

--
-- A tábla indexei `subcategories_expense`
--
ALTER TABLE `subcategories_expense`
  ADD PRIMARY KEY (`id`),
  ADD KEY `FK_subcategories_e_cat_e_id` (`categories_expense_id`),
  ADD KEY `user_id` (`user_id`);

--
-- A tábla indexei `transactions_expense`
--
ALTER TABLE `transactions_expense`
  ADD PRIMARY KEY (`id`),
  ADD KEY `FK_transactions_expense` (`currency_id`),
  ADD KEY `FK_transactions_expense_subcategories_expense_id` (`subcategories_expense_id`),
  ADD KEY `FK_transactions_expense_users_id` (`user_id`),
  ADD KEY `FK_transactions_expense_categories_expense_id` (`categories_expense_id`);

--
-- A tábla indexei `transactions_income`
--
ALTER TABLE `transactions_income`
  ADD PRIMARY KEY (`id`),
  ADD KEY `FK_transactions_income` (`currency_id`),
  ADD KEY `FK_transactions_income_users_id` (`user_id`),
  ADD KEY `categories_income_id` (`categories_income_id`);

--
-- A tábla indexei `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `email` (`email`),
  ADD KEY `FK_users` (`currency_id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `categories_expense`
--
ALTER TABLE `categories_expense`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `categories_income`
--
ALTER TABLE `categories_income`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `currencies`
--
ALTER TABLE `currencies`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `subcategories_expense`
--
ALTER TABLE `subcategories_expense`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `transactions_expense`
--
ALTER TABLE `transactions_expense`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `transactions_income`
--
ALTER TABLE `transactions_income`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `subcategories_expense`
--
ALTER TABLE `subcategories_expense`
  ADD CONSTRAINT `subcategories_expense_ibfk_1` FOREIGN KEY (`categories_expense_id`) REFERENCES `categories_expense` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Megkötések a táblához `transactions_expense`
--
ALTER TABLE `transactions_expense`
  ADD CONSTRAINT `transactions_expense_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `transactions_expense_ibfk_2` FOREIGN KEY (`categories_expense_id`) REFERENCES `categories_expense` (`id`);

--
-- Megkötések a táblához `transactions_income`
--
ALTER TABLE `transactions_income`
  ADD CONSTRAINT `FK_transactions_income_categories_income_id` FOREIGN KEY (`categories_income_id`) REFERENCES `categories_income` (`id`),
  ADD CONSTRAINT `transactions_income_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Megkötések a táblához `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `FK_users` FOREIGN KEY (`currency_id`) REFERENCES `currencies` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
