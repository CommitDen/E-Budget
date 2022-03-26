-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2022. Feb 07. 18:40
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

--
-- A tábla adatainak kiíratása `categories_expense`
--

INSERT INTO `categories_expense` (`id`, `name`, `user_id`) VALUES
(1, 'Housing', NULL),
(2, 'Children', NULL),
(3, 'Utility', NULL),
(4, 'Transportation', NULL),
(5, 'Debt', NULL),
(6, 'Insurance', NULL),
(7, 'Food', NULL),
(8, 'Pets', NULL),
(9, 'Healthcare', NULL);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `categories_income`
--

CREATE TABLE `categories_income` (
  `id` int(11) NOT NULL,
  `name` varchar(50) COLLATE utf8_hungarian_ci NOT NULL,
  `user_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `categories_income`
--

INSERT INTO `categories_income` (`id`, `name`, `user_id`) VALUES
(1, 'Paycheck', NULL),
(2, 'Predictable bonuses', NULL),
(3, 'Investment income', NULL),
(4, 'Miscellaneous income', NULL);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `currencies`
--

CREATE TABLE `currencies` (
  `id` int(11) NOT NULL,
  `currency_code` char(3) CHARACTER SET utf8 NOT NULL,
  `name` varchar(50) COLLATE utf8_hungarian_ci NOT NULL
) ENGINE=InnoDB AVG_ROW_LENGTH=2340 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `currencies`
--

INSERT INTO `currencies` (`id`, `currency_code`, `name`) VALUES
(1, 'ada', 'Cardano'),
(2, 'aed', 'United Arab Emirates Dirham'),
(3, 'afn', 'Afghan afghani'),
(4, 'all', 'Albanian lek'),
(5, 'amd', 'Armenian dram'),
(6, 'ang', 'Netherlands Antillean Guilder'),
(7, 'aoa', 'Angolan kwanza'),
(8, 'ars', 'Argentine peso'),
(9, 'aud', 'Australian dollar'),
(10, 'awg', 'Aruban florin'),
(11, 'azn', 'Azerbaijani manat'),
(12, 'bam', 'Bosnia-Herzegovina Convertible Mark'),
(13, 'bbd', 'Bajan dollar'),
(14, 'bch', 'Bitcoin Cash'),
(15, 'bdt', 'Bangladeshi taka'),
(16, 'bgn', 'Bulgarian lev'),
(17, 'bhd', 'Bahraini dinar'),
(18, 'bif', 'Burundian Franc'),
(19, 'bmd', 'Bermudan dollar'),
(20, 'bnb', 'Binance Coin'),
(21, 'bnd', 'Brunei dollar'),
(22, 'bob', 'Bolivian boliviano'),
(23, 'brl', 'Brazilian real'),
(24, 'bsd', 'Bahamian dollar'),
(25, 'btc', 'Bitcoin'),
(26, 'btn', 'Bhutan currency'),
(27, 'bwp', 'Botswanan Pula'),
(28, 'byn', 'New Belarusian Ruble'),
(29, 'byr', 'Belarusian Ruble'),
(30, 'bzd', 'Belize dollar'),
(31, 'cad', 'Canadian dollar'),
(32, 'cdf', 'Congolese franc'),
(33, 'chf', 'Swiss franc'),
(34, 'clf', 'Chilean Unit of Account (UF)'),
(35, 'clp', 'Chilean peso'),
(36, 'cny', 'Chinese Yuan'),
(37, 'cop', 'Colombian peso'),
(38, 'crc', 'Costa Rican ColĂłn'),
(39, 'cuc', 'Cuban peso'),
(40, 'cup', 'Cuban Peso'),
(41, 'cve', 'Cape Verdean escudo'),
(42, 'czk', 'Czech koruna'),
(43, 'djf', 'Djiboutian franc'),
(44, 'dkk', 'Danish krone'),
(45, 'dog', 'Dogecoin'),
(46, 'dop', 'Dominican peso'),
(47, 'dzd', 'Algerian dinar'),
(48, 'egp', 'Egyptian pound'),
(49, 'ern', 'Eritrean nakfa'),
(50, 'etb', 'Ethiopian birr'),
(51, 'etc', 'Ethereum Classic'),
(52, 'eth', 'Ether'),
(53, 'eur', 'Euro'),
(54, 'fjd', 'Fijian dollar'),
(55, 'fkp', 'Falkland Islands pound'),
(56, 'gbp', 'Pound sterling'),
(57, 'gel', 'Georgian lari'),
(58, 'ggp', 'GGPro'),
(59, 'ghs', 'Ghanaian cedi'),
(60, 'gip', 'Gibraltar pound'),
(61, 'gmd', 'Gambian dalasi'),
(62, 'gnf', 'Guinean franc'),
(63, 'gtq', 'Guatemalan quetzal'),
(64, 'gyd', 'Guyanaese Dollar'),
(65, 'hkd', 'Hong Kong dollar'),
(66, 'hnl', 'Honduran lempira'),
(67, 'hrk', 'Croatian kuna'),
(68, 'htg', 'Haitian gourde'),
(69, 'huf', 'Hungarian forint'),
(70, 'idr', 'Indonesian rupiah'),
(71, 'ils', 'Israeli New Shekel'),
(72, 'imp', 'CoinIMP'),
(73, 'inr', 'Indian rupee'),
(74, 'iqd', 'Iraqi dinar'),
(75, 'irr', 'Iranian rial'),
(76, 'isk', 'Icelandic krĂłna'),
(77, 'jep', 'Jersey Pound'),
(78, 'jmd', 'Jamaican dollar'),
(79, 'jod', 'Jordanian dinar'),
(80, 'jpy', 'Japanese yen'),
(81, 'kes', 'Kenyan shilling'),
(82, 'kgs', 'Kyrgystani Som'),
(83, 'khr', 'Cambodian riel'),
(84, 'kmf', 'Comorian franc'),
(85, 'kpw', 'North Korean won'),
(86, 'krw', 'South Korean won'),
(87, 'kwd', 'Kuwaiti dinar'),
(88, 'kyd', 'Cayman Islands dollar'),
(89, 'kzt', 'Kazakhstani tenge'),
(90, 'lak', 'Laotian Kip'),
(91, 'lbp', 'Lebanese pound'),
(92, 'lin', 'ChainLink'),
(93, 'lkr', 'Sri Lankan rupee'),
(94, 'lrd', 'Liberian dollar'),
(95, 'lsl', 'Lesotho loti'),
(96, 'ltc', 'Litecoin'),
(97, 'ltl', 'Lithuanian litas'),
(98, 'lvl', 'Latvian lats'),
(99, 'lyd', 'Libyan dinar'),
(100, 'mad', 'Moroccan dirham'),
(101, 'mdl', 'Moldovan leu'),
(102, 'mga', 'Malagasy ariary'),
(103, 'mkd', 'Macedonian denar'),
(104, 'mmk', 'Myanmar Kyat'),
(105, 'mnt', 'Mongolian tugrik'),
(106, 'mop', 'Macanese pataca'),
(107, 'mro', 'Mauritanian ouguiya'),
(108, 'mur', 'Mauritian rupee'),
(109, 'mvr', 'Maldivian rufiyaa'),
(110, 'mwk', 'Malawian kwacha'),
(111, 'mxn', 'Mexican peso'),
(112, 'myr', 'Malaysian ringgit'),
(113, 'mzn', 'Mozambican Metical'),
(114, 'nad', 'Namibian dollar'),
(115, 'ngn', 'Nigerian naira'),
(116, 'nio', 'Nicaraguan cĂłrdoba'),
(117, 'nok', 'Norwegian krone'),
(118, 'npr', 'Nepalese rupee'),
(119, 'nzd', 'New Zealand dollar'),
(120, 'omr', 'Omani rial'),
(121, 'pab', 'Panamanian balboa'),
(122, 'pen', 'Sol'),
(123, 'pgk', 'Papua New Guinean kina'),
(124, 'php', 'Philippine peso'),
(125, 'pkr', 'Pakistani rupee'),
(126, 'pln', 'Poland zĹ‚oty'),
(127, 'pyg', 'Paraguayan guarani'),
(128, 'qar', 'Qatari Rial'),
(129, 'ron', 'Romanian leu'),
(130, 'rsd', 'Serbian dinar'),
(131, 'rub', 'Russian ruble'),
(132, 'rwf', 'Rwandan Franc'),
(133, 'sar', 'Saudi riyal'),
(134, 'sbd', 'Solomon Islands dollar'),
(135, 'scr', 'Seychellois rupee'),
(136, 'sdg', 'Sudanese pound'),
(137, 'sek', 'Swedish krona'),
(138, 'sgd', 'Singapore dollar'),
(139, 'shp', 'Saint Helena pound'),
(140, 'sll', 'Sierra Leonean leone'),
(141, 'sos', 'Somali shilling'),
(142, 'srd', 'Surinamese dollar'),
(143, 'std', 'SĂŁo TomĂ© and PrĂ­ncipe Dobra (pre-2018)'),
(144, 'svc', 'Salvadoran ColĂłn'),
(145, 'syp', 'Syrian pound'),
(146, 'szl', 'Swazi lilangeni'),
(147, 'thb', 'Thai baht'),
(148, 'the', 'Theta'),
(149, 'tjs', 'Tajikistani somoni'),
(150, 'tmt', 'Turkmenistani manat'),
(151, 'tnd', 'Tunisian dinar'),
(152, 'top', 'Tongan PaĘ»anga'),
(153, 'trx', 'TRON'),
(154, 'try', 'Turkish lira'),
(155, 'ttd', 'Trinidad & Tobago Dollar'),
(156, 'twd', 'New Taiwan dollar'),
(157, 'tzs', 'Tanzanian shilling'),
(158, 'uah', 'Ukrainian hryvnia'),
(159, 'ugx', 'Ugandan shilling'),
(160, 'usd', 'United States dollar');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `exchange`
--

CREATE TABLE `exchange` (
  `currency_rate_id` int(11) NOT NULL,
  `currency_rate_date` datetime NOT NULL,
  `from_currency_code` char(3) CHARACTER SET utf8 NOT NULL,
  `to_currency_code` char(3) CHARACTER SET utf8 NOT NULL,
  `exchange_rate` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

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

--
-- A tábla adatainak kiíratása `subcategories_expense`
--

INSERT INTO `subcategories_expense` (`id`, `name`, `categories_expense_id`, `user_id`) VALUES
(1, 'Mortgage', 1, NULL),
(2, 'Rent', 1, NULL),
(3, 'Household', 1, NULL),
(4, 'HOA', 1, NULL),
(5, 'Insurance', 1, NULL),
(6, 'Tuition', 2, NULL),
(7, 'School supplies', 2, NULL),
(8, 'Child support', 2, NULL),
(9, 'Water', 3, NULL),
(10, 'Hot Water', 3, NULL),
(11, 'Electricity', 3, NULL),
(12, 'Natural gas', 3, NULL),
(13, 'Internet', 3, NULL),
(14, 'Cell phone bill', 3, NULL),
(15, 'Trash collection', 3, NULL),
(16, 'Gas', 4, NULL),
(17, 'Car maintenance and repairs', 4, NULL),
(18, 'Parking fees', 4, NULL),
(19, 'Toll payments', 4, NULL),
(20, 'Student loans', 5, NULL),
(21, 'Credit cards', 5, NULL),
(22, 'Car payment', 5, NULL),
(23, 'Miscellaneous', 5, NULL),
(24, 'Homeowners', 6, NULL),
(25, 'Renters', 6, NULL),
(26, 'Car', 6, NULL),
(27, 'Life', 6, NULL),
(28, 'Health', 6, NULL),
(29, 'Dental', 6, NULL),
(30, 'Medications', 9, NULL),
(31, 'Vision care', 9, NULL),
(32, 'Groceries', 7, NULL),
(33, 'Eating out', 7, NULL),
(34, 'Grooming', 8, NULL),
(35, 'Veterinarian', 8, NULL),
(36, 'Pet food and supplies', 8, NULL),
(37, 'Medications', 8, NULL),
(38, 'Accessories', 8, NULL);

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

--
-- A tábla adatainak kiíratása `transactions_expense`
--

INSERT INTO `transactions_expense` (`id`, `user_id`, `date`, `categories_expense_id`, `subcategories_expense_id`, `amount`, `currency_id`, `comment`) VALUES
(6, 1, '2022-01-03 00:00:00', 5, 22, 125.5, 53, ''),
(14, 1, '2022-01-03 00:00:00', 2, 6, 120.5, 53, ''),
(15, 1, '2022-01-03 00:00:00', 4, 16, 45.5, 53, ''),
(16, 1, '2022-01-03 00:00:00', 1, 2, 768.98, 53, ''),
(20, 1, '2022-01-10 00:00:00', 3, 9, 53.4, 53, '2022 1/2'),
(21, 1, '2022-01-13 00:00:00', 4, 16, 125.7, 53, ''),
(22, 1, '2022-02-17 00:00:00', 4, 17, 250, 53, 'Engine repair, spark plugs replaced at 75000km, next at 125000km'),
(23, 1, '2022-02-05 00:00:00', 1, 2, 1200, 53, ''),
(24, 1, '2022-02-02 00:00:00', 7, 32, 34, 53, ''),
(25, 1, '2022-02-16 00:00:00', 3, 11, 25, 53, ''),
(26, 1, '2022-02-08 00:00:00', 3, 13, 15, 53, ''),
(27, 1, '2022-02-04 00:00:00', 3, 14, 10, 53, ''),
(28, 1, '2022-02-02 00:00:00', 4, 16, 35, 53, ''),
(29, 1, '2022-02-15 00:00:00', 4, 16, 35, 53, ''),
(30, 1, '2022-02-09 00:00:00', 7, 32, 28.8, 53, '');

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

--
-- A tábla adatainak kiíratása `transactions_income`
--

INSERT INTO `transactions_income` (`id`, `user_id`, `date`, `categories_income_id`, `subcategories_income_id`, `amount`, `currency_id`, `comment`) VALUES
(4, 1, '2022-01-01 00:00:00', 1, NULL, 3500, 53, ''),
(5, 1, '2022-02-01 00:00:00', 1, NULL, 3500, 53, '');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `name` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `email` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `password` varchar(150) COLLATE utf8_hungarian_ci NOT NULL,
  `currency_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `users`
--

INSERT INTO `users` (`id`, `name`, `email`, `password`, `currency_id`) VALUES
(1, 'User1', 'user1@test.com', 'zau8sKFooqq7506AJvhBtYQazUIJ/t5+wHbg+dFmdDM=', 53);

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

CREATE VIEW view_alltransactions AS select t_i.user_id AS UserId,'income' AS type,t_i.id AS id,c_i.name AS Category,NULL AS Subcategory,t_i.amount AS Amount,c.currency_code AS Currency_code,t_i.date AS Date,t_i.comment AS Comment from (((transactions_income t_i join categories_income c_i on(t_i.categories_income_id = c_i.id)) join currencies c on(t_i.currency_id = c.id)) join users u on(t_i.user_id = u.id)) union select t_e.user_id AS UserId,'expense' AS type,t_e.id AS id,c_e.name AS Category,s_e.name AS Subcategory,t_e.amount AS Amount,c.currency_code AS Currency_code,t_e.date AS Date,t_e.comment AS Comment from ((((transactions_expense t_e join categories_expense c_e on(t_e.categories_expense_id = c_e.id)) join subcategories_expense s_e on(t_e.subcategories_expense_id = s_e.id)) join currencies c on(t_e.currency_id = c.id)) join users u on(t_e.user_id = u.id));

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
-- A tábla indexei `exchange`
--
ALTER TABLE `exchange`
  ADD PRIMARY KEY (`currency_rate_id`),
  ADD UNIQUE KEY `currency_rate_date` (`currency_rate_date`),
  ADD UNIQUE KEY `from_currency_code` (`from_currency_code`),
  ADD UNIQUE KEY `to_currency_code` (`to_currency_code`);

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT a táblához `categories_income`
--
ALTER TABLE `categories_income`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT a táblához `currencies`
--
ALTER TABLE `currencies`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=162;

--
-- AUTO_INCREMENT a táblához `exchange`
--
ALTER TABLE `exchange`
  MODIFY `currency_rate_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `subcategories_expense`
--
ALTER TABLE `subcategories_expense`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=48;

--
-- AUTO_INCREMENT a táblához `transactions_expense`
--
ALTER TABLE `transactions_expense`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=34;

--
-- AUTO_INCREMENT a táblához `transactions_income`
--
ALTER TABLE `transactions_income`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT a táblához `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `subcategories_expense`
--
ALTER TABLE `subcategories_expense`
  ADD CONSTRAINT `FK_subcategories_e_cat_e_id` FOREIGN KEY (`categories_expense_id`) REFERENCES `categories_expense` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Megkötések a táblához `transactions_expense`
--
ALTER TABLE `transactions_expense`
  ADD CONSTRAINT `FK_transactions_expense_categories_expense_id` FOREIGN KEY (`categories_expense_id`) REFERENCES `categories_expense` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_transactions_expense_users_id` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);

--
-- Megkötések a táblához `transactions_income`
--
ALTER TABLE `transactions_income`
  ADD CONSTRAINT `FK_transactions_income_categories_income_id` FOREIGN KEY (`categories_income_id`) REFERENCES `categories_income` (`id`),
  ADD CONSTRAINT `FK_transactions_income_users_id` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);

--
-- Megkötések a táblához `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `FK_users` FOREIGN KEY (`currency_id`) REFERENCES `currencies` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
