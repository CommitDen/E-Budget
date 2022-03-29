<?php
namespace app\model;
use app\Database as Db;

    class SubcategoriesDao{
        public function subcategoriesExpenseQuery(){
            $db = new Db();
            $conn = $db->getConnection();
            $statement = $conn->prepare("SELECT subcategories_expense.name, subcategories_expense.id, subcategories_expense.categories_expense_id FROM subcategories_expense WHERE subcategories_expense.user_id IS NULL OR subcategories_expense.user_id = ". $_SESSION['userId'] . ";");
            $statement->setFetchMode(\PDO::FETCH_OBJ);
            $statement->execute();
            return $statement->fetchAll();
        }

        public function getSubcategoriesOfCategory(int $id){
            $db = new Db();
            $conn = $db->getConnection();
            $statement = $conn->prepare("SELECT subcategories_expense.name, subcategories_expense.id, subcategories_expense.categories_expense_id, subcategories_expense.user_id FROM subcategories_expense WHERE (subcategories_expense.user_id IS NULL OR subcategories_expense.user_id = ". $_SESSION['userId'] . ") AND subcategories_expense.categories_expense_id = {$id};");
            $statement->setFetchMode(\PDO::FETCH_OBJ);
            $statement->execute();
            return $statement->fetchAll();
        }

        public function addSubcategory(int $id){
            $subcategory = $_POST['subcategoryAdd'];
            $db = new Db();
            $conn = $db->getConnection();
            $statement = $conn->prepare("INSERT INTO subcategories_expense VALUES(NULL, '{$subcategory}', {$id}, {$_SESSION['userId']});");
            $statement->execute();
        }

        public function getCategoryIdOfSubcategory(int $id){
            $db = new Db();
            $conn = $db->getConnection();
            $statement = $conn->prepare("SELECT subcategories_expense.categories_expense_id FROM subcategories_expense WHERE subcategories_expense.user_id = ". $_SESSION['userId'] . " AND subcategories_expense.id = {$id};");
            $statement->setFetchMode(\PDO::FETCH_OBJ);
            $statement->execute();
            return $statement->fetch();
        }

        public function getSubcategoryById(int $id){
            $db = new Db();
            $conn = $db->getConnection();
            $statement = $conn->prepare("SELECT * FROM subcategories_expense WHERE (subcategories_expense.user_id = ". $_SESSION['userId'] . " OR subcategories_expense.user_id IS NULL) AND subcategories_expense.id = {$id};");
            $statement->setFetchMode(\PDO::FETCH_OBJ);
            $statement->execute();
            return $statement->fetch();
        }

        public function updateSubcategory(int $id){
            $subcategory = $_POST['subcategory_name'];
            $db = new Db();
            $conn = $db->getConnection();
            $statement = $conn->prepare("UPDATE subcategories_expense SET subcategories_expense.name = '{$subcategory}' WHERE subcategories_expense.id = {$id};");
            $statement->execute();
        }

        public function deleteSubcategory(int $id){
            $db = new Db();
            $conn = $db->getConnection();
            $statement = $conn->prepare("DELETE FROM subcategories_expense WHERE subcategories_expense.user_id = {$_SESSION['userId']} AND subcategories_expense.id = {$id} ;");
            $statement->execute();
        }

    }
?>