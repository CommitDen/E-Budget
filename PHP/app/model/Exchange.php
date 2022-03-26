<?php
namespace app\model;
use app\Database as Db;

    class Exchange {
        private int $id;
        private string $currency;
        private float $value;
        private DateTime $date;

        public function getId(){
            return $this->id;
        }

        public function getCurrency(){
            return $this->currency;
        }

        public function getValue(){
            return $this->value;
        }

        public function getDate(){
            return $this->date;
        }
    }