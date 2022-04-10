<?php
namespace app\model;
use app\Database as Db;
use app\model\User;

    class UserDao {

        public function login($email, $password){
            $db = new Db();
            $conn = $db->getConnection();
            $statement = $conn->prepare("SELECT `users`.`id` FROM `users` WHERE `users`.`email` = '{$email}' AND `users`.`password` = '{$password}';");
            $statement->setFetchMode(\PDO::FETCH_OBJ);
            $statement->execute();
            $stdclass = $statement->fetch();
            return $stdclass->id;
        }

        public function checkIfPasswordIsCorrect($email, $password){
            $db = new Db();
            $conn = $db->getConnection();
            $statement = $conn->prepare("SELECT IF(users.password='{$password}', true, false) AS 'bool' FROM users WHERE users.email='{$email}' ;");
            $statement->setFetchMode(\PDO::FETCH_OBJ);
            $statement->execute();
            return $statement->fetch();
        }


        public function newUserAdd($user){
            $db = new Db();
            $conn = $db->getConnection();
            $sql = "INSERT INTO users VALUES (NULL, :username, :email, :pwd, :currency_id);";
            $statement = $conn->prepare($sql);
            $statement->execute([
                ':username' => $user->getName,
                ':email' => $user->getEmail,
                ':pwd' => $user->getPassword,
                ':currency_id' => $user->getCurrencyId,
            ]);
        }

        public function findUserById($id){
            $db = new Db();
            $conn = $db->getConnection();
            $statement = $conn->prepare("SELECT * FROM view_alltransactions WHERE UserId = :id");
            $statement->setFetchMode(\PDO::FETCH_OBJ);
            $statement->execute([
                ':id' => $id,
            ]);
            return $statement->fetchAll();
        }

        public function checkIfEmailIsAvailable($email){
            $db = new Db();
            $conn = $db->getConnection();
            $statement = $conn->prepare("SELECT count(*) AS 'bool' FROM users WHERE users.email='{$email}';");
            $statement->setFetchMode(\PDO::FETCH_OBJ);
            $statement->execute();
            return $statement->fetch();
        }

        public function getDefaultCurrency(){
            $db = new Db();
            $conn = $db->getConnection();
            $statement = $conn->prepare("SELECT currencies.currency_code, users.currency_id FROM users INNER JOIN currencies ON users.currency_id=currencies.id WHERE users.id={$_SESSION['userId']};");
            $statement->setFetchMode(\PDO::FETCH_OBJ);
            $statement->execute();
            return $statement->fetch();
        }


        public function getUserData(){
            $db = new Db();
            $conn = $db->getConnection();
            $statement = $conn->prepare("SELECT users.name, users.email FROM users WHERE users.id={$_SESSION['userId']};");
            $statement->setFetchMode(\PDO::FETCH_OBJ);
            $statement->execute();
            return $statement->fetch();
        }

        public function updateUserData(string $query){
            $db = new Db();
            $conn = $db->getConnection();
            $statement = $conn->prepare($query);
            $statement->execute();
        }

        public function deleteUser(){
            $db = new Db();
            $conn = $db->getConnection();
            $query = "DELETE FROM users WHERE users.id = {$_SESSION['userId']}";
            $statement = $conn->prepare($query);
            $statement->execute();
            $query = "DELETE FROM categories_income WHERE categories_income.user_id = {$_SESSION['userId']}";
            $statement = $conn->prepare($query);
            $statement->execute();
            $query = "DELETE FROM categories_expense WHERE categories_expense.user_id = {$_SESSION['userId']}";
            $statement = $conn->prepare($query);
            $statement->execute();
        }
    }