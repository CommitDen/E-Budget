<?php
namespace app\model;
use app\Database as Db;

    class CategoriesDao{
        public function categoriesExpenseQuery(){
            $db = new Db();
            $conn = $db->getConnection();
            $statement = $conn->prepare("SELECT categories_expense.name, categories_expense.id FROM categories_expense WHERE categories_expense.user_id = {$_SESSION['userId']} OR categories_expense.user_id IS NULL;");
            $statement->setFetchMode(\PDO::FETCH_OBJ);
            $statement->execute();
            return $statement->fetchAll();
        }

        public function categoriesIncomeQuery(){
            $db = new Db();
            $conn = $db->getConnection();
            $statement = $conn->prepare("SELECT categories_income.name, categories_income.id FROM categories_income WHERE categories_income.user_id = {$_SESSION['userId']} OR categories_income.user_id IS NULL;");
            $statement->setFetchMode(\PDO::FETCH_OBJ);
            $statement->execute();
            return $statement->fetchAll();
        }

        public function allCategoriesQuery(){
            $db = new Db();
            $conn = $db->getConnection();
            $statement = $conn->prepare("SELECT 'expense' AS 'type', categories_expense.id, categories_expense.name, categories_expense.user_id FROM categories_expense WHERE categories_expense.user_id = {$_SESSION['userId']} OR categories_expense.user_id IS NULL UNION SELECT 'income' AS 'type', categories_income.id, categories_income.name, categories_income.user_id FROM categories_income WHERE categories_income.user_id = {$_SESSION['userId']} OR categories_income.user_id IS NULL;");
            $statement->setFetchMode(\PDO::FETCH_OBJ);
            $statement->execute();
            return $statement->fetchAll();
        }

        public function deleteCategory(int $id, bool $type){
            $db = new Db();
            $conn = $db->getConnection();
            $suffix = "";
            ($type) ? $suffix = "_expense" : $suffix = "_income";
            $statement = $conn->prepare("DELETE FROM categories{$suffix} WHERE categories{$suffix}.user_id = {$_SESSION['userId']} AND categories{$suffix}.id = {$id} ;");
            $statement->execute();
        }

        public function getCategoryById(int $id, bool $type){
            $db = new Db();
            $conn = $db->getConnection();
            $suffix = "";
            ($type) ? $suffix = "_expense" : $suffix = "_income";
            $statement = $conn->prepare("SELECT categories{$suffix}.name, categories{$suffix}.id FROM categories{$suffix} WHERE (categories{$suffix}.user_id = {$_SESSION['userId']} OR categories{$suffix}.user_id IS NULL) AND categories{$suffix}.id = {$id};");
            $statement->setFetchMode(\PDO::FETCH_OBJ);
            $statement->execute();
            return $statement->fetch();
        }

        public function editCategory(int $id, bool $type){
            $category = $_POST['category_name'];
            $db = new Db();
            $conn = $db->getConnection();
            $suffix = "";
            ($type) ? $suffix = "_expense" : $suffix = "_income";
            $statement = $conn->prepare("UPDATE categories{$suffix} SET categories{$suffix}.name = '{$category}' WHERE categories{$suffix}.user_id = {$_SESSION['userId']} AND categories{$suffix}.id = {$id};");
            $statement->execute();
        }

        public function addCategory(bool $type){
            $category = $_POST['categoryAdd'];
            $db = new Db();
            $conn = $db->getConnection();
            $suffix = "";
            ($type) ? $suffix = "_expense" : $suffix = "_income";
            $statement = $conn->prepare("INSERT INTO categories{$suffix} VALUES(NULL, '{$category}', {$_SESSION['userId']});");
            $statement->execute();
        }

        public function isUserOwned(int $id, bool $type, string $category){
            $db = new Db();
            $conn = $db->getConnection();
            $suffix = "";
            ($type) ? $suffix = "_expense" : $suffix = "_income";
            $statement = $conn->prepare("SELECT count(*) AS 'bool' FROM categories{$suffix} WHERE categories{$suffix}.user_id = {$_SESSION['userId']} AND categories{$suffix}.id = {$id};");
            $statement->setFetchMode(\PDO::FETCH_OBJ);
            $statement->execute();
            return $statement->fetch();
        }





    }
?>