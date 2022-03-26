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
INNER JOIN currencies ,,
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
SELECT 'i'AS tipus,t_i.id, c_i.name, t_i.amount, c.currency_code, t_i.date, t_i.comment
FROM transactions_income AS t_i
INNER JOIN categories_income AS c_i ON t_i.categories_income_id = c_i.id 
INNER JOIN currencies AS c ON t_i.currency_id = c.id 
INNER JOIN users AS u ON t_i.user_id = u.id
WHERE u.id = 1
UNION
SELECT 'e' AS tipus,t_e.id, c_e.name, t_e.amount, c.currency_code, t_e.date, t_e.comment
FROM transactions_expense AS t_e
INNER JOIN categories_expense AS c_e ON t_e.categories_expense_id = c_e.id 
INNER JOIN subcategories_expense AS s_e ON c_e.id=s_e.categories_expense_id
INNER JOIN currencies AS c ON t_e.currency_id = c.id 
INNER JOIN users AS u ON t_e.user_id = u.id
WHERE u.id = 1;