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

--
-- A tábla adatainak kiíratása `categories_income`
--

INSERT INTO `categories_income` (`id`, `name`, `user_id`) VALUES
(1, 'Paycheck', NULL),
(2, 'Predictable bonuses', NULL),
(3, 'Investment income', NULL),
(4, 'Miscellaneous income', NULL);

--
-- A tábla adatainak kiíratása `currencies`
--

INSERT INTO `currencies` (`id`, `currency_code`, `name`) VALUES
(1, '1in', '1inch Network'),
(2, 'ada', 'Cardano'),
(3, 'aed', 'United Arab Emirates Dirham'),
(4, 'afn', 'Afghan afghani'),
(5, 'alg', 'Algorand'),
(6, 'all', 'Albanian lek'),
(7, 'amd', 'Armenian dram'),
(8, 'ang', 'Netherlands Antillean Guilder'),
(9, 'aoa', 'Angolan kwanza'),
(10, 'ars', 'Argentine peso'),
(11, 'ato', 'Atomic Coin'),
(12, 'aud', 'Australian dollar'),
(13, 'ava', 'Avalanche'),
(14, 'awg', 'Aruban florin'),
(15, 'azn', 'Azerbaijani manat'),
(16, 'bam', 'Bosnia-Herzegovina Convertible Mark'),
(17, 'bbd', 'Bajan dollar'),
(18, 'bch', 'Bitcoin Cash'),
(19, 'bdt', 'Bangladeshi taka'),
(20, 'bgn', 'Bulgarian lev'),
(21, 'bhd', 'Bahraini dinar'),
(22, 'bif', 'Burundian Franc'),
(23, 'bmd', 'Bermudan dollar'),
(24, 'bnb', 'Binance Coin'),
(25, 'bnd', 'Brunei dollar'),
(26, 'bob', 'Bolivian boliviano'),
(27, 'brl', 'Brazilian real'),
(28, 'bsd', 'Bahamian dollar'),
(29, 'btc', 'Bitcoin'),
(30, 'btn', 'Bhutan currency'),
(31, 'bus', 'Binance USD'),
(32, 'bwp', 'Botswanan Pula'),
(33, 'byn', 'New Belarusian Ruble'),
(34, 'byr', 'Belarusian Ruble'),
(35, 'bzd', 'Belize dollar'),
(36, 'cad', 'Canadian dollar'),
(37, 'cdf', 'Congolese franc'),
(38, 'chf', 'Swiss franc'),
(39, 'chz', 'Chiliz'),
(40, 'clf', 'Chilean Unit of Account (UF)'),
(41, 'clp', 'Chilean peso'),
(42, 'cny', 'Chinese Yuan'),
(43, 'cop', 'Colombian peso'),
(44, 'crc', 'Costa Rican ColĂłn'),
(45, 'cro', 'Crypto.com Chain Token'),
(46, 'cuc', 'Cuban peso'),
(47, 'cup', 'Cuban Peso'),
(48, 'cve', 'Cape Verdean escudo'),
(49, 'czk', 'Czech koruna'),
(50, 'dai', 'Dai'),
(51, 'djf', 'Djiboutian franc'),
(52, 'dkk', 'Danish krone'),
(53, 'dog', 'Dogecoin'),
(54, 'dop', 'Dominican peso'),
(55, 'dot', 'Dotcoin'),
(56, 'dzd', 'Algerian dinar'),
(57, 'egl', 'Elrond'),
(58, 'egp', 'Egyptian pound'),
(59, 'enj', 'Enjin Coin'),
(60, 'ern', 'Eritrean nakfa'),
(61, 'etb', 'Ethiopian birr'),
(62, 'etc', 'Ethereum Classic'),
(63, 'eth', 'Ether'),
(64, 'eur', 'Euro'),
(65, 'fil', 'FileCoin'),
(66, 'fjd', 'Fijian dollar'),
(67, 'fkp', 'Falkland Islands pound'),
(68, 'ftt', 'FarmaTrust'),
(69, 'gbp', 'Pound sterling'),
(70, 'gel', 'Georgian lari'),
(71, 'ggp', 'GGPro'),
(72, 'ghs', 'Ghanaian cedi'),
(73, 'gip', 'Gibraltar pound'),
(74, 'gmd', 'Gambian dalasi'),
(75, 'gnf', 'Guinean franc'),
(76, 'grt', 'Golden Ratio Token'),
(77, 'gtq', 'Guatemalan quetzal'),
(78, 'gyd', 'Guyanaese Dollar'),
(79, 'hkd', 'Hong Kong dollar'),
(80, 'hnl', 'Honduran lempira'),
(81, 'hrk', 'Croatian kuna'),
(82, 'htg', 'Haitian gourde'),
(83, 'huf', 'Hungarian forint'),
(84, 'icp', 'Internet Computer'),
(85, 'idr', 'Indonesian rupiah'),
(86, 'ils', 'Israeli New Shekel'),
(87, 'imp', 'CoinIMP'),
(88, 'inj', 'Injective'),
(89, 'inr', 'Indian rupee'),
(90, 'iqd', 'Iraqi dinar'),
(91, 'irr', 'Iranian rial'),
(92, 'isk', 'Icelandic krĂłna'),
(93, 'jep', 'Jersey Pound'),
(94, 'jmd', 'Jamaican dollar'),
(95, 'jod', 'Jordanian dinar'),
(96, 'jpy', 'Japanese yen'),
(97, 'kes', 'Kenyan shilling'),
(98, 'kgs', 'Kyrgystani Som'),
(99, 'khr', 'Cambodian riel'),
(100, 'kmf', 'Comorian franc'),
(101, 'kpw', 'North Korean won'),
(102, 'krw', 'South Korean won'),
(103, 'ksm', 'Kusama'),
(104, 'kwd', 'Kuwaiti dinar'),
(105, 'kyd', 'Cayman Islands dollar'),
(106, 'kzt', 'Kazakhstani tenge'),
(107, 'lak', 'Laotian Kip'),
(108, 'lbp', 'Lebanese pound'),
(109, 'lin', 'ChainLink'),
(110, 'lkr', 'Sri Lankan rupee'),
(111, 'lrd', 'Liberian dollar'),
(112, 'lsl', 'Lesotho loti'),
(113, 'ltc', 'Litecoin'),
(114, 'ltl', 'Lithuanian litas'),
(115, 'lun', 'Luna Coin'),
(116, 'lvl', 'Latvian lats'),
(117, 'lyd', 'Libyan dinar'),
(118, 'mad', 'Moroccan dirham'),
(119, 'mat', 'Polygon'),
(120, 'mdl', 'Moldovan leu'),
(121, 'mga', 'Malagasy ariary'),
(122, 'mkd', 'Macedonian denar'),
(123, 'mmk', 'Myanmar Kyat'),
(124, 'mnt', 'Mongolian tugrik'),
(125, 'mop', 'Macanese pataca'),
(126, 'mro', 'Mauritanian ouguiya'),
(127, 'mur', 'Mauritian rupee'),
(128, 'mvr', 'Maldivian rufiyaa'),
(129, 'mwk', 'Malawian kwacha'),
(130, 'mxn', 'Mexican peso'),
(131, 'myr', 'Malaysian ringgit'),
(132, 'mzn', 'Mozambican Metical'),
(133, 'nad', 'Namibian dollar'),
(134, 'ngn', 'Nigerian naira'),
(135, 'nio', 'Nicaraguan cĂłrdoba'),
(136, 'nok', 'Norwegian krone'),
(137, 'npr', 'Nepalese rupee'),
(138, 'nzd', 'New Zealand dollar'),
(139, 'omr', 'Omani rial'),
(140, 'one', 'Menlo One'),
(141, 'pab', 'Panamanian balboa'),
(142, 'pen', 'Sol'),
(143, 'pgk', 'Papua New Guinean kina'),
(144, 'php', 'Philippine peso'),
(145, 'pkr', 'Pakistani rupee'),
(146, 'pln', 'Poland zĹ‚oty'),
(147, 'pyg', 'Paraguayan guarani'),
(148, 'qar', 'Qatari Rial'),
(149, 'ron', 'Romanian leu'),
(150, 'rsd', 'Serbian dinar'),
(151, 'rub', 'Russian ruble'),
(152, 'rwf', 'Rwandan Franc'),
(153, 'sar', 'Saudi riyal'),
(154, 'sbd', 'Solomon Islands dollar'),
(155, 'scr', 'Seychellois rupee'),
(156, 'sdg', 'Sudanese pound'),
(157, 'sek', 'Swedish krona'),
(158, 'sgd', 'Singapore dollar'),
(159, 'shi', 'Shiba Inu'),
(160, 'shp', 'Saint Helena pound'),
(161, 'sll', 'Sierra Leonean leone'),
(162, 'sol', 'Sola'),
(163, 'sos', 'Somali shilling'),
(164, 'srd', 'Surinamese dollar'),
(166, 'svc', 'Salvadoran ColĂłn'),
(167, 'syp', 'Syrian pound'),
(168, 'szl', 'Swazi lilangeni'),
(169, 'thb', 'Thai baht'),
(170, 'the', 'Theta'),
(171, 'tjs', 'Tajikistani somoni'),
(172, 'tmt', 'Turkmenistani manat'),
(173, 'tnd', 'Tunisian dinar'),
(174, 'top', 'Tongan PaĘ»anga'),
(175, 'trx', 'TRON'),
(176, 'try', 'Turkish lira'),
(177, 'ttd', 'Trinidad & Tobago Dollar'),
(178, 'twd', 'New Taiwan dollar'),
(179, 'tzs', 'Tanzanian shilling'),
(180, 'uah', 'Ukrainian hryvnia'),
(181, 'ugx', 'Ugandan shilling'),
(182, 'uni', 'Universe'),
(183, 'usd', 'United States dollar');

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


--
-- A tábla adatainak kiíratása `users`
--

INSERT INTO `users` (`id`, `name`, `email`, `password`, `currency_id`) VALUES
(1, 'user1', 'user1@test.com', '0d38d98d0af429070a6a4b2c2d6feff03ae2a68d6fd0f162445c69ea4f5c6294', 64);

--
-- A tábla adatainak kiíratása `transactions_expense`
--

INSERT INTO `transactions_expense` (`id`, `user_id`, `date`, `categories_expense_id`, `subcategories_expense_id`, `amount`, `currency_id`, `comment`) VALUES
(6, 1, '2022-01-03 00:00:00', 5, 22, 125.5, 64, ''),
(14, 1, '2022-01-03 00:00:00', 2, 6, 120.5, 64, ''),
(15, 1, '2022-01-03 00:00:00', 4, 16, 45.5, 64, ''),
(16, 1, '2022-01-03 00:00:00', 1, 2, 768.98, 64, ''),
(20, 1, '2022-01-10 00:00:00', 3, 9, 53.4, 64, '2022 1/2'),
(21, 1, '2022-01-13 00:00:00', 4, 16, 125.7, 64, ''),
(24, 1, '2022-02-02 00:00:00', 7, 32, 34, 64, ''),
(25, 1, '2022-02-16 00:00:00', 3, 11, 25, 64, ''),
(26, 1, '2022-02-08 00:00:00', 3, 13, 15, 64, ''),
(27, 1, '2022-02-04 00:00:00', 3, 14, 10, 64, ''),
(28, 1, '2022-03-11 00:00:00', 2, 6, 2342, 64, ''),
(29, 1, '2022-02-15 00:00:00', 4, 16, 35, 64, ''),
(30, 1, '2022-02-09 00:00:00', 7, 32, 28.8, 64, ''),
(39, 1, '2022-03-11 00:00:00', 8, 35, 201, 64, ''),
(40, 1, '2022-03-11 00:00:00', 5, 21, 2000, 64, ''),
(41, 1, '2022-03-11 00:00:00', 4, 18, 200, 64, ''),
(42, 1, '2022-03-31 00:00:00', 2, 7, 120, 66, '');

--
-- A tábla adatainak kiíratása `transactions_income`
--

INSERT INTO `transactions_income` (`id`, `user_id`, `date`, `categories_income_id`, `subcategories_income_id`, `amount`, `currency_id`, `comment`) VALUES
(4, 1, '2022-01-01 00:00:00', 1, NULL, 3500, 64, ''),
(5, 1, '2022-02-01 00:00:00', 1, NULL, 3500, 64, '');


-- --------------------------------------------------------


/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
