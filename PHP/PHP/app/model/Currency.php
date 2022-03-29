<?php
namespace app\model;
use app\Database as Db;

    class Currency {
        private int $id;
        private string $currencycode;

        public function getId(){
            return $this->id;
        }

        public function getCurrencyCode(){
            return $this->currencycode;
        }
    }


?>