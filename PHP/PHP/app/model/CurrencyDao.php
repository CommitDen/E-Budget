<?php
namespace app\model;
use app\Database as Db;

    class CurrencyDao {
        public function allCurrenciesQuery(){
            $db = new Db();
            $conn = $db->getConnection();
            $statement = $conn->prepare("SELECT currencies.currency_code, currencies.id FROM currencies");
            $statement->setFetchMode(\PDO::FETCH_OBJ);
            $statement->execute();
            return $statement->fetchAll();
        }
    }


?>