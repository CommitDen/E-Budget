<?php
namespace app\model;
use app\Database as Db;

    class FilterDao{
        function filter(){
            $column = array('Category', 'Subcategory', 'Amount', 'Currency_code', 'Date', 'Comment');
            $filterList = array();

            $query = "
            SELECT * FROM view_alltransactions 
            ";


            if (isset($_POST['filter'])) {
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
                    array_push($filterList, "date_filter:" . $_POST['from_date_filter'] . ":" . $_POST['to_date_filter']);
                }
            }

            if (count($filterList) > 0) {
                $query .= " WHERE ";
                foreach ($filterList as $filter) {
                    if (substr($query, -1) == "'") {
                        $query .= " AND";
                    }
                    $parts = explode(":", $filter);
                    $query .= stringbuilder($parts);
                }

                if(isset($_POST['order']))
                {
                $query .= ' ORDER BY '.$column[$_POST['order']['0']['column']].' '.$_POST['order']['0']['dir'].' ';
                }
                else
                {
                $query .= ' ORDER BY view_alltransactions.Date DESC ';
                }
            }

            

           

            $query1 = '';

            if($_POST["length"] != -1)
            {
            $query1 = 'LIMIT ' . $_POST['start'] . ', ' . $_POST['length'];
            }

            $db = new Db();

            $connect = $db->getConnection();

            $statement = $connect->prepare($query);

            $statement->execute();

            $number_filter_row = $statement->rowCount();

            $statement = $connect->prepare($query . $query1);

            $statement->execute();

            $result = $statement->fetchAll();



            $data = array();

            foreach($result as $row)
            {
                $sub_array = array();
                $sub_array[] = $row['type'];
                $sub_array[] = $row['Category'];
                $sub_array[] = $row['Subcategory'];
                $sub_array[] = $row['Amount'];
                $sub_array[] = $row['Currency_code'];
                $sub_array[] = $row['Date'];
                $sub_array[] = $row['Comment'];
                $data[] = $sub_array;
            }

            function count_all_data($connect)
            {
                $query = "SELECT * FROM view_alltransactions";
                $statement = $connect->prepare($query);
                $statement->execute();
                return $statement->rowCount();
            }

            $output = array(
                "draw"       =>  intval($_POST["draw"]),
                "recordsTotal"   =>  count_all_data($connect),
                "recordsFiltered"  =>  $number_filter_row,
                "data"       =>  $data
            );

            echo json_encode($output);


        }

        function stringbuilder($parts){
            $case = $parts[0];
            $value = $parts[1];

            switch ($case) {
                case 'type_filter':
                    $query = " view_alltransactions.type = '$value'";
                    break;
                case 'category_filter':
                    $query = " view_alltransactions.Category = '$value'";
                    break;
                case 'subcategory_filter':
                    $query = " view_alltransactions.Subcategory = '$value'";
                    break;
                case 'currency_filter':
                    $query = " view_alltransactions.Currency_code = '$value'";
                    break;
                case 'date_filter':
                    $value2 = $parts[2];
                    $query = " view_alltransactions.Date BETWEEN '$value' AND '$value2'";
                    break;
                default:
                    break;
            }
        }

    }
?>