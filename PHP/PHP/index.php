<?php
include 'app\Database.php';
include 'app\model\User.php';
include 'app\model\UserDao.php';
include 'app\model\Exchange.php';
include 'app\model\Transactions.php';
include 'app\model\TransactionsDao.php';
include 'app\controller\TransactionController.php';
include 'app\model\Currency.php';
include 'app\model\CurrencyDao.php';
include 'app\model\Categories.php';
include 'app\model\CategoriesDao.php';
include 'app\model\Subcategories.php';
include 'app\model\SubcategoriesDao.php';
include 'app\model\FilterDao.php';



use app\model\User;
use app\controller\TransactionController;
session_start();

?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>E-Budget</title>
    <link rel="icon" type="image/x-icon" href="app/favicon.ico">
    <link rel="stylesheet" href="app\css\bootstrap.min.css">
    <script src="css\bootstrap-5.0.2-dist\js\bootstrap.min.js"></script>
    <script src="js/jquery-3.6.0.min.js"></script>
    <link rel="stylesheet" type="text/css" href="DataTables/datatables.min.css"/>
    <script type="text/javascript" src="DataTables/datatables.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.4/Chart.js"></script>
    <script src="https://kit.fontawesome.com/726d8295c9.js" crossorigin="anonymous"></script>
    <link rel="stylesheet" type="text/css" href="css/style.css">
</head>
<body class="container mx-auto mt-5 pt-4">
    <nav class="navbar fixed-top navbar-expand-lg navbar-light bg-light">
        <div class="container-fluid">
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="navbar-collapse collapse" id="navbarNav">
            <?php
                echo "<ul class='navbar-nav'>";
                if(isset($_SESSION['userId'])) {
                    echo "<li class='nav-item'><a class='nav-link' href='index.php?controller=TransactionController&action=transactions'> Budget </a></li>";
                    echo "<li class='nav-item'><a class='nav-link' href='index.php?controller=TransactionController&action=categories'> Categories </a></li>";
                    echo "<li class='nav-item'><a class='nav-link' href='index.php?controller=TransactionController&action=reports'> Reports </a></li>";
                    echo "<li class='nav-item'><a class='nav-link' href='index.php?controller=TransactionController&action=settings'> Settings </a></li>";
                    echo "<li class='nav-item'><a class='nav-link' href='index.php?controller=TransactionController&action=logout'> Logout </a></li>";
                    } else {
                    echo "<li class='nav-item'><a class='nav-link' href='index.php?controller=TransactionController&action=sign_up'> Sign up </a></li>";
                    echo "<li class='nav-item'><a class='nav-link' href='index.php?controller=TransactionController&action=login'> Login </a></li>";
                    
                    }
                echo "</ul>";
            ?>
        </div>
    </nav>


<?php
$controllerName = (isset($_GET['controller']))?$_GET['controller']:'TransactionController';
$actionName = (isset($_GET['action']))?$_GET['action']:'index';

switch ($controllerName) {
    case 'TransactionController':
        $controller = new TransactionController();
        switch ($actionName) {
            case 'index':
                $content = $controller->loadHomepage();
                break;
            case 'login':
                $content = $controller->load('user', 'login');
                $content = $controller->validateUser();
                break;
            case 'sign_up':
                $content = $controller->loadSignUp();
                break;
            case 'logout':
                $content = $controller->logout();
                header("Location: index.php?controller=TransactionController&action=login");
                break;
            case 'transactions':
                $content = $controller->tableFill($_SESSION['userId']);
                break;
            case 'delete':
                $content = $controller->loadDeleteTransactions($_GET['type'], $_GET['id']);
                break;
            case 'deleteTransaction':
                $content = $controller->deleteTransaction($_GET['id'], $_GET['category']);
                break;
            case 'edit':
                $content = $controller->edit($_GET['type'], $_GET['id']);
                break;
            case 'update':
                $content = $controller->update($_GET['id']);
                break;
            case 'settings':
                $content = $controller->loadSettings();
                break;
            case 'update_settings':
                $content = $controller->updateSettings();
                break;
            case 'addNewTransaction':
                $content = $controller->addNewTransaction();
                break;
            case 'loadAddNewTransaction':
                $content = $controller->loadNewTransaction();
                break;
            case 'categories':
                $content = $controller->loadCategories();
                break;
            case 'load_add_category':
                $content = $controller->loadAddCategory();
                break;
            case 'load_delete_category':
                $content = $controller->loadDeleteCategory($_GET['category']);
                break;
            case 'load_edit_category':
                $content = $controller->loadEditCategory($_GET['category']);
                break;
            case 'load_add_subcategory':
                $content = $controller->loadAddSubcategory($_GET['category']);
                break;
            case 'load_edit_subcategory':
                $content = $controller->loadEditSubcategory($_GET['id']);
                break;
            case 'load_delete_subcategory':
                $content = $controller->loadDeleteSubcategory($_GET['id']);
                break;
            case 'edit_category':
                $content = $controller->editCategory($_GET['category']);
                break;
            case 'filter':
                $content = $controller->filter();
                break;
            case 'reports':
                $content = $controller->loadReports();
                break;
            case 'deleteUser':
                $content = $controller->loadDeleteUser();
                break;
            default:
                break;
        }
        break;
}


?>


</body>
</html>

