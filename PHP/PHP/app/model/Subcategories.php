<?php
namespace app\model;
use app\Database as Db;

    class Subcategories {
        private int $id;
        private string $subcategory;
        private int $category_id;

        public function getId(){
            return $this->id;
        }

        public function getSubcategory(){
            return $this->subcategory;
        }

        public function getCategoryId(){
            return $this->category_id;
        }

        public function __set($name, $value){
            $this->subcategory[$name] = $value;
        }
    }