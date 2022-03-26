<?php

include 'app\Database.php';
use app\Database as Db;
session_start();

$db = new Db();

$filterList = array();
            
            $query = "
            SELECT 
            view_alltransactions.id, view_alltransactions.type, view_alltransactions.Amount,
            view_alltransactions.Currency_code, view_alltransactions.Date FROM view_alltransactions 
            WHERE view_alltransactions.UserId = " . $_SESSION['userId'] . " ";


            if (isset($_POST['type_filter']) && $_POST['type_filter'] != "") {
                array_push($filterList, "type_filter:" . $_POST['type_filter']);
            }
            if (isset($_POST['category_filter']) && $_POST['category_filter'] != "") {
                array_push($filterList, "category_filter:" . $_POST['category_filter']);
                if (isset($_POST['subcategory_filter']) && $_POST['subcategory_filter'] != "") {
                    array_push($filterList, "subcategory_filter:" . $_POST['subcategory_filter']);
                }
            }
            if (isset($_POST['currency_filter']) && $_POST['currency_filter'] != "") {
                array_push($filterList, "currency_filter:" . $_POST['currency_filter']);
            }
            if (isset($_POST['from_date_filter']) && $_POST['from_date_filter'] != "" && isset($_POST['to_date_filter']) && $_POST['to_date_filter'] != "") {
                
            }
            array_push($filterList, "date_filter:" . $_POST['from_date_filter'] . ":" . $_POST['to_date_filter']);
            if (count($filterList) > 0) {
                foreach ($filterList as $filter) {
                    $parts = explode(":", $filter);
                    $query .= stringbuilder($parts);
                }
            }
           

            $connect = $db->getConnection();

            $statement = $connect->prepare($query);

            $statement->execute();

            $result = $statement->fetchAll();

            $income_total = 0;
            $expense_total = 0;


            foreach($result as $row)
            {
                if ($row['Currency_code'] == $_SESSION['defCurrency']) {
                    $amount = $row['Amount'];
                }
                else {
                    if ($row['Date'] >= date("Y-m-d")) {
                        $date = date('Y-m-d',strtotime("-1 days"));
                    }
                    else {
                        $date = $row['Date'];
                    }
                    $json = file_get_contents('https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/'.$date.'/currencies/'.$row['Currency_code'].'/'.$_SESSION['defCurrency'].'.json');
                    $obj = json_decode($json);
                    $amount = $obj->$_SESSION['defCurrency']*$row['Amount'];
                }
                
                if ($row['type'] == "income") {
                    $income_total += $amount;
                }
                else {
                    $expense_total += $amount;
                }
            }

            $query = "SELECT 
            view_alltransactions.id, view_alltransactions.type, view_alltransactions.Amount,
            view_alltransactions.Currency_code, view_alltransactions.Date FROM view_alltransactions 
            WHERE view_alltransactions.UserId = " . $_SESSION['userId'] . ";";

            $statement = $connect->prepare($query);

            $statement->execute();

            $result = $statement->fetchAll();

            $balance = 0;

            foreach($result as $row)
            {
                if ($row['Currency_code'] == $_SESSION['defCurrency']) {
                    $amount = $row['Amount'];
                }
                else {
                    if ($row['Date'] >= date("Y-m-d")) {
                        $date = date('Y-m-d',strtotime("-1 days"));
                    }
                    else {
                        $date = $row['Date'];
                    }
                    $json = file_get_contents('https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/'.$date.'/currencies/'.$row['Currency_code'].'/'.$_SESSION['defCurrency'].'.json');
                    $obj = json_decode($json);
                    $amount = $obj->$_SESSION['defCurrency']*$row['Amount'];
                }
                
                if ($row['type'] == "income") {
                    $balance += $amount;
                }
                else {
                    $balance -= $amount;
                }
            }
            $balance = round($balance, 2);
            $expense_total = round($expense_total, 2);
            $income_total = round($income_total, 2);

            $output = array(
                "expense_total" => $expense_total,
                "income_total"  => $income_total,
                "balance"       => $balance
            );

            echo json_encode($output);

            
            function stringbuilder($parts){
                $case = $parts[0];
                $value = $parts[1];
    
                switch ($case) {
                    case 'type_filter':
                        $query = " AND view_alltransactions.type = '$value'";
                        break;
                    case 'category_filter':
                        $query = " AND view_alltransactions.Category = '$value'";
                        break;
                    case 'subcategory_filter':
                        $query = " AND view_alltransactions.Subcategory = '$value'";
                        break;
                    case 'currency_filter':
                        $query = " AND view_alltransactions.Currency_code = '$value'";
                        break;
                    case 'date_filter':
                        $value2 = $parts[2];
                        $query = " AND view_alltransactions.Date BETWEEN '$value' AND '$value2'";
                        break;
                    default:
                        break;
                }
                return $query;
            }

            

?>