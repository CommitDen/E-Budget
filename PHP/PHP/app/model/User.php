<?php 
namespace app\model;
use app\Database as Db;
use app\model\UserDao;
    class User {
        private int $id;
        private string $name;
        private string $email;
        private string $password;
        private int $currency_id;

        public function getId(){
            return $this->id;
        }

        public function getName(){
            return $this->name;
        }

        public function getEmail(){
            return $this->email;
        }

        public function getPassword(){
            return $this->password;
        }

        public function getCurrencyId(){
            return $this->currency_id;
        }

    }
?>