<?php
namespace app\model;
use app\Database as Db;
    class TransactionsDao {
        public function findTransactionById(string $type, int $id){
            $db = new Db();
            $conn = $db->getConnection();
            $statement = $conn->prepare("SELECT * FROM view_alltransactions WHERE view_alltransactions.id =".$id." AND view_alltransactions.UserId =".$_SESSION['userId']." AND view_alltransactions.type='".$type."';");
            $statement->setFetchMode(\PDO::FETCH_OBJ);
            $statement->execute();
            return $statement->fetch();
        }

        public function addNewTransaction(string $table){
            $transaction = new Transactions();
            $parts = explode(":", filter_var($_POST['newTransaction']['category'], FILTER_SANITIZE_STRING));
            $transaction->getDate = filter_var($_POST['newTransaction']['date'], FILTER_SANITIZE_STRING);
            $transaction->getCategoryId = $parts[1];
            $transaction->getSubCategoryId = (isset($_POST['newTransaction']['subcategory'])) ? filter_var($_POST['newTransaction']['subcategory'], FILTER_SANITIZE_STRING) : "NULL";
            $transaction->getAmount = filter_var($_POST['newTransaction']['amount'], FILTER_SANITIZE_STRING);
            $transaction->getComment = filter_var($_POST['newTransaction']['comment'], FILTER_SANITIZE_STRING);
            $transaction->getCurrencyId = filter_var($_POST['newTransaction']['currency'], FILTER_SANITIZE_STRING);

            $db = new Db();
            $conn = $db->getConnection();
            $sql = "INSERT INTO {$table} VALUES (NULL, {$_SESSION['userId']},'{$transaction->getDate}',{$transaction->getCategoryId},{$transaction->getSubCategoryId},{$transaction->getAmount},{$transaction->getCurrencyId},'{$transaction->getComment}');";
            $statement = $conn->prepare($sql);
            $statement->execute();
        }

        public function updateTransactionExpense(int $id){
            $transaction = new Transactions();
            $parts = explode(':', $_POST['selectedTransaction']['category']);
            $transaction->getId = $id;
            $transaction->getDate = $_POST['selectedTransaction']['date'];
            $transaction->getCategoryId = $parts[1];
            $transaction->getSubCategoryId = $_POST['selectedTransaction']['subcategory'];
            $transaction->getAmount = $_POST['selectedTransaction']['amount'];
            $transaction->getComment = $_POST['selectedTransaction']['comment'];
            $transaction->getCurrencyId = $_POST['selectedTransaction']['currency'];

            $db = new Db();
            $conn = $db->getConnection();
            $sql = "UPDATE transactions_expense SET date= :t_date, categories_expense_id = :categoryId, subcategories_expense_id = :subcategoryId, amount = :amount, comment = :t_comment, currency_id = :currencyId WHERE transactions_expense.id = :transactionId AND transactions_expense.user_id=:userId;";
            $statement = $conn->prepare($sql);
            $statement->execute([
                ':transactionId' => $transaction->getId,
                ':t_date' => $transaction->getDate,
                ':categoryId' => $transaction->getCategoryId,
                ':subcategoryId' => $transaction->getSubCategoryId,
                ':amount' => $transaction->getAmount,
                ':t_comment' => $transaction->getComment,
                ':currencyId' => $transaction->getCurrencyId,
                ':userId' => $_SESSION['userId'],
            ]);
        }

        public function updateTransactionIncome(int $id){
            $transaction = new Transactions();
            $parts = explode(':', $_POST['selectedTransaction']['category']);
            $transaction->getId = $id;
            $transaction->getDate = $_POST['selectedTransaction']['date'];
            $transaction->getCategoryId = $parts[1];
            $transaction->getAmount = $_POST['selectedTransaction']['amount'];
            $transaction->getComment = $_POST['selectedTransaction']['comment'];
            $transaction->getCurrencyId = $_POST['selectedTransaction']['currency'];

            $db = new Db();
            $conn = $db->getConnection();
            $sql = "UPDATE transactions_income SET date= :t_date, categories_income_id = :categoryId, subcategories_income_id = NULL, amount = :amount, comment = :t_comment, currency_id = :currencyId WHERE transactions_income.id = :transactionId AND transactions_income.user_id=:userId;";
            $statement = $conn->prepare($sql);
            $statement->execute([
                ':transactionId' => $transaction->getId,
                ':t_date' => $transaction->getDate,
                ':categoryId' => $transaction->getCategoryId,
                ':amount' => $transaction->getAmount,
                ':t_comment' => $transaction->getComment,
                ':currencyId' => $transaction->getCurrencyId,
                ':userId' => $_SESSION['userId'],
            ]);
        }

        public function deleteTransaction(int $id, string $table){
            $db = new Db();
            $conn = $db->getConnection();
            $sql = "DELETE FROM {$table} WHERE {$table}.id={$id};";
            $statement = $conn->prepare($sql);
            $statement->execute();
        }

        public function getMonthlyExpensesData(){
            $first_day_of_current_month = date('Y-m-01');
            $last_day_of_current_month = date('Y-m-t');

            $db = new Db();
            $conn = $db->getConnection();
            $statement = $conn->prepare("SELECT view_alltransactions.Category, SUM(view_alltransactions.Amount) AS 'Amount' FROM view_alltransactions WHERE view_alltransactions.UserId={$_SESSION['userId']} AND view_alltransactions.Date BETWEEN '{$first_day_of_current_month}' AND '{$last_day_of_current_month}' AND view_alltransactions.type='expense' GROUP BY view_alltransactions.Category;");
            $statement->setFetchMode(\PDO::FETCH_OBJ);
            $statement->execute();
            return $statement->fetchAll();
        }

        public function getMonthlyIncomeData(){
            $first_day_of_current_month = date('Y-m-01');
            $last_day_of_current_month = date('Y-m-t');

            $db = new Db();
            $conn = $db->getConnection();
            $statement = $conn->prepare("SELECT view_alltransactions.type, SUM(view_alltransactions.Amount) AS 'Amount' FROM view_alltransactions WHERE view_alltransactions.UserId={$_SESSION['userId']} AND view_alltransactions.Date BETWEEN '{$first_day_of_current_month}' AND '{$last_day_of_current_month}' GROUP BY view_alltransactions.type;");
            $statement->setFetchMode(\PDO::FETCH_OBJ);
            $statement->execute();
            return $statement->fetchAll();
        }

        public function getYearlyData(){
            $first_day_of_current_year = date('Y-m-d', strtotime('first day of january this year'));
            $last_day_of_current_year = date('Y-m-d', strtotime('last day of december this year'));

            $db = new Db();
            $conn = $db->getConnection();
            $statement = $conn->prepare("SELECT view_alltransactions.type, MONTHNAME(view_alltransactions.Date) AS 'Month', SUM(view_alltransactions.Amount) AS 'Amount' FROM view_alltransactions WHERE view_alltransactions.Date BETWEEN '{$first_day_of_current_year}' AND '{$last_day_of_current_year}' AND view_alltransactions.UserId={$_SESSION['userId']} GROUP BY view_alltransactions.type, MONTHNAME(view_alltransactions.Date) ORDER BY view_alltransactions.Date ASC;");
            $statement->setFetchMode(\PDO::FETCH_OBJ);
            $statement->execute();
            return $statement->fetchAll();
        }



    }
?>