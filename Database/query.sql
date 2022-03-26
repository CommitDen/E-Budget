//Login
SELECT id FROM `users` 
WHERE email = '{0}' 
AND password = '{1}';

// Expenses query
SELECT t.id, c.name, s.name, t.amount, currencies.currency_code, t.date, t.comment 
FROM transactions_expense AS t 
INNER JOIN categories_expense AS c 
ON t.categories_expense_id = c.id 
INNER JOIN subcategories_expense AS s 
ON c.id = s.categories_expense_id 
INNER JOIN currencies 
ON t.currency_id = currencies.id 
INNER JOIN users AS u ON t.user_id = u.id
WHERE u.id=5 
AND t.subcategories_expense_id=s.id;

// Income query
SELECT t.id, c.name, t.amount, currencies.currency_code, t.comment
FROM transactions_income AS t 
INNER JOIN categories_income AS c ON t.categories_income_id = c.id 
INNER JOIN currencies ON t.currency_id = currencies.id 
INNER JOIN users AS u ON t.user_id = u.id 
WHERE u.id={0} ;

// Update Expense data
UPDATE {8} SET `date`='{1}', `category_expense_id` = '{2}',
 `subcategory_expense_id`='{3}', 
 `amount` = '{4}', 
 `comment` = '{5}', 
 `currency_id` = '{6}' 
 WHERE `transactions`.`id` = '{0}' 
 AND `transactions`.`user_id`='{7}';
 //Insert==>, T.Trans_id, date, cat_id, sub_cat_id, value, comment, currency_id, Id, table
 
// Update Income data
UPDATE {7} SET `date`='{1}',
 `category_expense_id` = '{2}', 
 `amount` = '{3}', 
 `comment` = '{4}', 
 `currency_id` = '{5}' 
 WHERE `transactions`.`id` = '{0}' 
 AND `transactions`.`user_id`='{6}';
 //Insert==>, T.Trans_id, date, cat_id, value, comment, currency_id, Id, table
 
// Delete Expense data
DELETE FROM transactions_expense AS t WHERE t.id='{0}';
 //Insert==>, T.Trans_id

// Delete Income data 
DELETE FROM transactions_income AS t WHERE t.id='{0}';
 //Insert==>, T.Trans_id

// Load Combobox Dictionaries
/Categories
SELECT c.id, c.name FROM categories_income AS c, users WHERE users.id='{0}' OR users.id IS NULL
SELECT c.id, c.name FROM categories_expense AS c, users WHERE users.id='{0}' OR users.id IS NULL
/Subcategories
SELECT s.id, s.name FROM subcategories_expense AS s
/Currencies
SELECT c.id, c.currency_code FROM currencies AS c

//All transactions
select `t_i`.`user_id` AS `UserId`,'income' AS `type`,`t_i`.`id` AS `id`,`c_i`.`name` AS `Category`,NULL AS `Subcategory`,`t_i`.`amount` AS `Amount`,`c`.`currency_code` AS `Currency_code`,`t_i`.`date` AS `Date`,`t_i`.`comment` AS `Comment` from (((`e-budget`.`transactions_income` `t_i` join `e-budget`.`categories_income` `c_i` on(`t_i`.`categories_income_id` = `c_i`.`id`)) join `e-budget`.`currencies` `c` on(`t_i`.`currency_id` = `c`.`id`)) join `e-budget`.`users` `u` on(`t_i`.`user_id` = `u`.`id`)) union select `t_e`.`user_id` AS `UserId`,'expense' AS `type`,`t_e`.`id` AS `id`,`c_e`.`name` AS `Category`,`s_e`.`name` AS `Subcategory`,`t_e`.`amount` AS `Amount`,`c`.`currency_code` AS `Currency_code`,`t_e`.`date` AS `Date`,`t_e`.`comment` AS `Comment` from ((((`e-budget`.`transactions_expense` `t_e` join `e-budget`.`categories_expense` `c_e` on(`t_e`.`categories_expense_id` = `c_e`.`id`)) join `e-budget`.`subcategories_expense` `s_e` on(`t_e`.`subcategories_expense_id` = `s_e`.`id`)) join `e-budget`.`currencies` `c` on(`t_e`.`currency_id` = `c`.`id`)) join `e-budget`.`users` `u` on(`t_e`.`user_id` = `u`.`id`))