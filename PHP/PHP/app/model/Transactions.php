<?php
namespace app\model;
use app\Database as Db;

    class Transactions {
        private int $id;
        private int $user_id;
        private DateTime $date;
        private int $category_id;
        private int $subcategory_id;
        private int $amount;
        private string $comment;
        private int $currency_id;


        public function getId(){
            return $this->id;
        }

        public function getUserID(){
            return $this->user_id;
        }

        public function getDateTime(){
            return $this->date;
        }

        public function getCategoryId(){
            return $this->category_id;
        }

        public function getSubCategoryId(){
            return $this->subcategory_id;
        }

        public function getAmount(){
            return $this->amount;
        }

        public function getComment(){
            return $this->comment;
        }

        public function getCurrencyId(){
            return $this->currency_id;
        }


    }


?>