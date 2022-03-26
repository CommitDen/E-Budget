<?php
namespace app\model;
use app\Database as Db;

    class Categories {
        private int $id;
        private string $category;

        public function getId(){
            return $this->id;
        }

        public function getCategory(){
            return $this->category;
        }

        public function __set($name, $value){
            $this->category[$name] = $value;
        }
    }