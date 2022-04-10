<?php 
namespace app\controller;
    use app\model\Transactions;
    use app\model\TransactionsDao;
    use app\model\User;
    use app\model\UserDao;
    use app\model\CurrencyDao;
    use app\model\Categories;
    use app\model\CategoriesDao;
    use app\model\Subcategories;
    use app\model\SubcategoriesDao;
    use app\model\FilterDao;
    class TransactionController {

        public function logout(){
            session_destroy();
        }

        public function boolConverter(int $i){
            if ($i == 1) {
                return true;
            }
            else {
                return false;
            }
        }

        public function load($folder, $view, $data = []){
            extract($data);
            ob_start();
            include("app/view/{$folder}/{$view}.php"); 
            return $data;
        }

        public function passwordValidation(){
            $password = $_POST['pwd'];
            $uppercase = preg_match("/[A-Z]/", $password);
            $lowercase = preg_match("/[a-z]/", $password);
            $number    = preg_match("/\d/", $password);
            $specialChar = preg_match("/\W/", $password);

            if($uppercase > 0 && $lowercase > 0 && $number > 0 && $specialChar > 0 && strlen($password) > 8) {
                return true;
            }
            else {
                return false;
            }
        }

        public function createSalt($email){
            $utf8 = utf8_encode($email);
            $bytes = unpack('C*', $utf8);
            $salt = "";
            $long = 0x00;

            foreach ($bytes as $byte) {
                $long = $long^$byte;
                $salt .= strval($byte);
            }
            return $salt;
        }

        public function loadSignUp(){
            $currencyDaoObj = new CurrencyDao();
            $currencies = $currencyDaoObj->allCurrenciesQuery();
            $user = new User();
            $userDaoObj = new UserDao();
            if (isset($_POST['regData'])) {
                $user->getName = filter_var($_POST['name'], FILTER_SANITIZE_STRING);
                $user->getEmail = filter_var($_POST['email'], FILTER_SANITIZE_STRING);
                $user->getPassword = hash('sha256', filter_var($_POST['pwd'], FILTER_SANITIZE_STRING). $this->createSalt($user->getEmail));
                $password_confirmation = hash('sha256', filter_var($_POST['pwdConfirm'], FILTER_SANITIZE_STRING). $this->createSalt($user->getEmail));
                $user->getCurrencyId = $_POST['currencyId'];
                if ($user->getName != "" && strlen($user->getName) >= 5 && preg_match("/^[a-zA-Z-' ]*$/", $user->getName)) {
                    if (!(!filter_var($user->getEmail, FILTER_VALIDATE_EMAIL))) {
                        if (!$this->boolConverter($userDaoObj->checkIfEmailIsAvailable($user->getEmail)->bool)) {
                            if ($this->passwordValidation()) {
                               if ($password_confirmation == $user->getPassword) {
                                $userDaoObj->newUserAdd($user);
                                header("Location: index.php");
                               }
                               else {
                                echo "<script>alert('Password and password confirmation must match!')</script>";
                               }
                            }
                            else {
                                echo "<script>alert('Password does not match the following requirements: 8 char length, at least one lowercase character, at least one uppercase character, at least one special character!')</script>";
                            }
                        }
                        else {
                            echo "<script>alert('This email is already in use on another account!')</script>";
                        }
                    }
                    else {
                        echo "<script>alert('Incorrect email format!')</script>";
                    }
                }
                else {
                    echo "<script>alert('Name can only contain letters, dash, space, apostrophe and has to be at least 5 characters long!')</script>";
                }
            }
            
            return $this->load('user', 'sign_up', [
                'currencies' => $currencies,
            ]);
        }

        public function validateUser(){
            $user = new User();
            $userDaoObj = new UserDao();
            if (isset($_POST['login'])) {
                $email = filter_var($_POST['email'], FILTER_SANITIZE_STRING);
                $password = hash('sha256', filter_var($_POST['pwd'], FILTER_SANITIZE_STRING). $this->createSalt($email));
                if (!$this->boolConverter($userDaoObj->checkIfEmailIsAvailable($email)->bool)) {
                    echo "<script>alert('Incorrect email')</script>";
                }
                else {
                    if ($this->boolConverter($userDaoObj->checkIfPasswordIsCorrect($email, $password)->bool)) {
                        $userId = $userDaoObj->login($email, $password);
                        session_start();
                        $_SESSION['userId'] = $userId;
                        $_SESSION['defCurrency'] = $userDaoObj->getDefaultCurrency()->currency_code;
                        $_SESSION['defCurrencyId'] = $userDaoObj->getDefaultCurrency()->id;
                        header('Location: index.php?controller=TransactionController&action=transactions');
                        return $this->tableFill($userId);
                    }
                    else {
                        echo "<script>alert('Incorrect password')</script>";
                    }
                }
            }
        }


        public function tableFill(int $id){
            $userDaoObj = new UserDao();
            $categoriesDaoObj = new CategoriesDao();
            $subcategoriesDaoObj = new SubcategoriesDao();
            $currencyDaoObj = new CurrencyDao();
            $currencies = $currencyDaoObj->allCurrenciesQuery();
            $categoriesIncome = $categoriesDaoObj->categoriesIncomeQuery();
            $allCategories = $categoriesDaoObj->allCategoriesQuery();
            $allSubcategories = $subcategoriesDaoObj->subcategoriesExpenseQuery();
            $userTransactions = $userDaoObj->findUserById($id);
            
            return $this->load('user', 'transaction_view', [
                'transactions' => $userTransactions,
                'categories' => $allCategories,
                'subcategories' => $allSubcategories,
                'categories_income' => $categoriesIncome,
                'currencies' => $currencies,
            ]);
        }



        public function getDefaultData(){
            $categoriesDaoObj = new CategoriesDao();
            $subcategoriesDaoObj = new SubcategoriesDao();
            $categoryExpenses = $categoriesDaoObj->categoriesExpenseQuery();
            $categoryIncome = $categoriesDaoObj->categoriesIncomeQuery();
            $categories = $categoriesDaoObj->allCategoriesQuery();
            $subcategoriesExpense = $subcategoriesDaoObj->subcategoriesExpenseQuery();
        }

        public function edit(string $type, int $id){
            $categoriesDaoObj = new CategoriesDao();
            $subcategoriesDaoObj = new SubcategoriesDao();
            $transactionsDaoObj = new TransactionsDao();
            $currencyDaoObj = new CurrencyDao();

            $currencies = $currencyDaoObj->allCurrenciesQuery();
            $selectedTransaction = $transactionsDaoObj->findTransactionById($type ,$id);
            $allCategories = $categoriesDaoObj->allCategoriesQuery();
            $categoriesIncome = $categoriesDaoObj->categoriesIncomeQuery();
            $allSubcategories = $subcategoriesDaoObj->subcategoriesExpenseQuery();

            return $this->load('user', 'edit', [
                'selectedTransaction' => $selectedTransaction,
                'allCategories'       => $allCategories,
                'categoriesIncome'    => $categoriesIncome,
                'allSubcategories'    => $allSubcategories,
                'currencies'          => $currencies,
            ]);
        }

        public function loadNewTransaction(){
            $categoriesDaoObj = new CategoriesDao();
            $subcategoriesDaoObj = new SubcategoriesDao();
            $currencyDaoObj = new CurrencyDao();

            $currencies = $currencyDaoObj->allCurrenciesQuery();
            $allCategories = $categoriesDaoObj->allCategoriesQuery();
            $categoriesIncome = $categoriesDaoObj->categoriesIncomeQuery();
            $allSubcategories = $subcategoriesDaoObj->subcategoriesExpenseQuery();

            
           

            return $this->load('user', 'add_transaction', [
                'allCategories' => $allCategories,
                'categoriesIncome' => $categoriesIncome,
                'allSubcategories' => $allSubcategories,
                'currencies' => $currencies,
            ]);
        }

        public function addNewTransaction(){
            $transactionsDaoObj = new TransactionsDao();
            $categoriesDaoObj = new CategoriesDao();
            $categoriesIncome = $categoriesDaoObj->categoriesIncomeQuery();
            $parts = explode(":", $_POST['newTransaction']['category']);
            $categoryName = $parts[0];
            $init = false;
            if (isset($_POST['newTransaction']['add'])) {
                if (isset($_POST['newTransaction']['amount']) && $_POST['newTransaction']['amount'] > 0) {
                    for ($i=0; $i < count($categoriesIncome); $i++) { 
                        if ($categoriesIncome[$i]->name == $categoryName) {
                            $init = true;
                        }
                    }
                    if ($init) {
                        $table = "transactions_income";
                    }
                    else {
                        $table = "transactions_expense";
                    }
                    $transactionsDaoObj->addNewTransaction($table);
                    header('Location: index.php?controller=TransactionController&action=transactions');
                }
                else {
                    echo "<script>alert('Missing data: Amount!'); window.location.replace('index.php?controller=TransactionController&action=loadAddNewTransaction');</script>";
                }
            }
        }

        public function updateTransactionExpense(int $id){
            $transactionDao = new TransactionsDao();
            $transactionDao->updateTransactionExpense($id);
            header("Location: index.php?controller=TransactionController&action=transactions");
        }

        public function updateTransactionIncome(int $id){
            $transactionDao = new TransactionsDao();
            $transactionDao->updateTransactionIncome($id);
            header("Location: index.php?controller=TransactionController&action=transactions");
        }

        public function update(int $id){
            $categoriesDaoObj = new CategoriesDao();
            $categoriesIncome = $categoriesDaoObj->categoriesIncomeQuery();
            $allCategories = $categoriesDaoObj->allCategoriesQuery();
            $parts = explode(":", $_POST['selectedTransaction']['category']);
            $categoryName = $parts[0];
            $init = false;
            if (isset($_POST['selectedTransaction']['edit'])) {
                for ($i=0; $i < count($categoriesIncome); $i++) { 
                    if ($categoriesIncome[$i]->name == $categoryName) {
                        $init = true;
                    }
                }
                if ($init) {
                    $this->updateTransactionIncome($id);
                }
                else {
                    $this->updateTransactionExpense($id);
                }
            }
        }

        public function loadDeleteTransactions(string $type, int $id){
            $transactionsDaoObj = new TransactionsDao();
            $selectedTransaction = $transactionsDaoObj->findTransactionById($type, $id);
            return $this->load('user', 'delete', [
                'transaction' => $selectedTransaction,
            ]);
        }

        public function deleteTransaction(int $id, string $category){
            $transactionDao = new TransactionsDao();
            $categoriesDaoObj = new CategoriesDao();
            $categoriesIncome = $categoriesDaoObj->categoriesIncomeQuery();
            
            $init = false;

            if (isset($_POST['delete'])) {
                for ($i=0; $i < count($categoriesIncome); $i++) { 
                    if ($categoriesIncome[$i]->name == $category) {
                        $init = true;
                    }
                }
                if ($init) {
                    $table = "transactions_income";
                }
                else {
                    $table = "transactions_expense";
                }
                $transactionDao->deleteTransaction($id, $table);
                header('Location: index.php?controller=TransactionController&action=transactions');
            }

        }

        public function loadCategories(){
            $categoriesDaoObj = new CategoriesDao();
            $allCategories = $categoriesDaoObj->allCategoriesQuery();
            return $this->load('user', 'categories', [
                'categories' => $allCategories,
               
            ]);
        }

        public function loadAddCategory(){
            $categoriesDaoObj = new CategoriesDao();
            $allCategories = $categoriesDaoObj->allCategoriesQuery();
            $bool = true;
            if (isset($_POST['add_category'])) {
                if (isset($_POST['categoryAdd']) && strlen($_POST['categoryAdd']) >= 5) {
                    $type = $this->boolConverter($_POST['category_type']);
                    for ($i=0; $i < count($allCategories); $i++) { 
                        if ($allCategories[$i]->name == $_POST['categoryAdd']) {
                            $bool = false;
                            break;
                        }
                    }
                    if ($bool) {
                        $categoriesDaoObj->addCategory($type);
                        header('Location: index.php?controller=TransactionController&action=categories');
                    }
                    else {
                        echo "<script>alert('This category already exists');</script>";
                    }
                }
                else {
                    echo "<script>alert('Category name can not be shorter than 5 letters!'); window.location.replace('index.php?controller=TransactionController&action=load_add_category');</script>";
                }
                
            }

            return $this->load('user', 'add_category', [
                'categories' => $allCategories,
            ]);
        }

        public function loadDeleteCategory($category){
            $categoriesDaoObj = new CategoriesDao();
            $categoriesExpense = $categoriesDaoObj->categoriesExpenseQuery();
            $categoriesIncome = $categoriesDaoObj->categoriesIncomeQuery();
            $for = $this->isExpense($category);

            if (isset($_POST['delete'])) {
                $categoriesDaoObj->deleteCategory($for->id, $for->type);
                header('Location: index.php?controller=TransactionController&action=categories');
            }
            

            return $this->load('user', 'delete_category', [
                'category' => $category,
            ]);
            
        }

        public function loadEditCategory($category){
            $categoriesDaoObj = new CategoriesDao();
            $subcategoriesDaoObj = new SubcategoriesDao();
            $categoryObj = $this->isExpense($category);
            $isUserOwned = $this->boolConverter($categoriesDaoObj->isUserOwned($categoryObj->id, $categoryObj->type, $category)->bool);

            $subcategories = $subcategoriesDaoObj->getSubcategoriesofCategory($categoryObj->id);
            $selectedCategory = $categoriesDaoObj->getCategoryById($categoryObj->id, $categoryObj->type);
            $_SESSION['prev'] = $selectedCategory->name;
        
            return $this->load('user', 'edit_category', [
                'selectedCategory' => $selectedCategory,
                'subcategories' => $subcategories,
                'isUserOwned' => $isUserOwned,
                'isExpense' => $categoryObj->type,
            ]);
        }

        public function editCategory($selectedCategory){
            $categoriesDaoObj = new CategoriesDao();
            $category = $this->isExpense($selectedCategory);
            if (isset($_POST['edit'])) {
                $categoryName = $_POST['category_name'];
                if (strlen($selectedCategory) >= 5) {
                    if ($this->boolConverter($categoriesDaoObj->isUserOwned($category->id, $category->type, $categoryName)->bool)) {
                        $categoriesDaoObj->editCategory($category->id, $category->type);
                        header('Location: index.php?controller=TransactionController&action=categories');
                    }
                    else {
                        echo "<script>alert('Default categories can not be edited');</script>";
                    }
                }
                else {
                    echo "<script>alert('The category has to be at least 5 characters long');</script>";
                }
            }
        }

        public function isExpense($category){
            $categoriesDaoObj = new CategoriesDao();
            $subcategoriesDaoObj = new SubcategoriesDao();
            $categoriesExpense = $categoriesDaoObj->categoriesExpenseQuery();
            $categoriesIncome = $categoriesDaoObj->categoriesIncomeQuery();
            for ($i=0; $i < count($categoriesIncome); $i++) { 
                if ($categoriesIncome[$i]->name == $category) {
                    $bool = false;
                    $id = $categoriesIncome[$i]->id;
                }
            }

            for ($i=0; $i < count($categoriesExpense); $i++) { 
                if ($categoriesExpense[$i]->name == $category) {
                    $bool = true;
                    $id = $categoriesExpense[$i]->id;
                }
            }
            $object = new \stdClass();
            $object->type = $bool;
            $object->id = $id;
            return $object;
        }

        public function loadAddSubcategory($category){
            $subcategoriesDaoObj = new SubcategoriesDao();
            $categoriesDaoObj = new CategoriesDao();
            $categoriesExpense = $categoriesDaoObj->categoriesExpenseQuery();
            $categoriesIncome = $categoriesDaoObj->categoriesIncomeQuery();
            $categoryObj = $this->isExpense($category);
            $subcategories = $subcategoriesDaoObj->getSubcategoriesofCategory($categoryObj->id);
            $bool = true;
            $id = $this->isExpense($category)->id;
            
            if (isset($_POST['add_subcategory'])) {
                for ($i=0; $i < count($subcategories); $i++) { 
                    if ($subcategories[$i]->name == $_POST['subcategoryAdd']) {
                        $bool = false;
                    }
                }
                if (strlen($_POST['subcategoryAdd']) >= 5) {
                    if ($bool) {
                        $subcategoriesDaoObj->addSubcategory($id);
                        header('Location: index.php?controller=TransactionController&action=load_edit_category&category='.$category);
                    }
                    else {
                        echo "<script>alert('This subcategory already exists!');</script>";
                    }
                }
                else {
                    echo "<script>alert('Subcategory name can not be shorter than 5 letters!');</script>";
                }
            }
            return $this->load('user', 'add_subcategory', [
                'subcategories' => $subcategories,
            ]);
        }

        public function loadEditSubcategory(int $id){
            $subcategoriesDaoObj = new SubcategoriesDao();
            $bool = true;
            $subcategory = $subcategoriesDaoObj->getSubcategoryById($id);
            $category_id = $subcategory->categories_expense_id;
            $subcategories = $subcategoriesDaoObj->getSubcategoriesofCategory($category_id);
            if (isset($_POST['edit'])) {
                $newSubcategory = $_POST['subcategory_name'];
                $id = $subcategory->id;
                for ($i=0; $i < count($subcategories); $i++) { 
                    if ($subcategories[$i]->name == $_POST['subcategory_name']) {
                        $bool = false;
                    }
                }
                if (strlen($_POST['subcategory_name']) >= 5) {
                    if ($bool) {
                        $subcategoriesDaoObj->updateSubcategory($id);
                        header('Location: index.php?controller=TransactionController&action=load_edit_category&category='.$_SESSION['prev']);
                    }
                    else {
                        echo "<script>alert('This subcategory already exists');</script>";
                    }
                }
                else {
                    echo "<script>alert('Subcategory name can not be shorter than 5 letters');</script>";
                }
            }

            return $this->load('user', 'edit_subcategory', [
                'subcategory' => $subcategory,
            ]);
        }

        public function loadDeleteSubcategory(int $id){
            $subcategoriesDaoObj = new SubcategoriesDao();
            $subcategory = $subcategoriesDaoObj->getSubcategoryById($id);
            if (isset($_POST['delete'])) {
                $subcategoriesDaoObj->deleteSubcategory($id);
                header('Location: index.php?controller=TransactionController&action=load_edit_category&category='.$_SESSION['prev']);
            }
            

            return $this->load('user', 'delete_subcategory', [
                'subcategory' => $subcategory,
            ]);
        }

        public function filter(){
            $filterDao = new FilterDao();
            $filterDao->filter();
            echo "<script>console.log(data);</script>";
        }


        public function loadSettings(){
            $currencyDaoObj = new CurrencyDao();
            $currencies = $currencyDaoObj->allCurrenciesQuery();
            $userDaoObj = new UserDao();
            $userData = $userDaoObj->getUserData();
            $defCurrency = $userDaoObj->getDefaultCurrency();
            $queries = "UPDATE users SET ";
            $end = "WHERE users.id=". $_SESSION['userId'] . ";";
            $pass_set = false;
            

            if (isset($_POST['update'])) {
                if (isset($_POST['name']) && $_POST['name'] != $userData->name) {
                   if (preg_match("/^[a-zA-Z-' ]*$/", $_POST['name']) && $_POST['name'] != "" && strlen($_POST['name']) >= 5) {
                        $name = filter_var($_POST['name'], FILTER_SANITIZE_STRING);
                        $queries .= " name='". $name ."',";
                   }
                   else {
                    echo "<script>alert('Name can only contain letters, dash, space, apostrophe and has to be at least 5 characters long!')</script>";
                    }
                }
                if (isset($_POST['email']) && $_POST['email'] != $userData->email) {
                    if (!(!filter_var($_POST['email'], FILTER_VALIDATE_EMAIL))) {
                        if (!$this->boolConverter($userDaoObj->checkIfEmailIsAvailable($_POST['email'])->bool)) {
                            if (isset($_POST['pwd']) && $_POST['pwd'] != "" && isset($_POST['pwdConfirm']) && $_POST['pwdConfirm'] != "") {
                                if ($_POST['pwd'] == $_POST['pwdConfirm']) {
                                    if ($this->passwordValidation()) {
                                        $hash = hash('sha256', filter_var($_POST['pwd'], FILTER_SANITIZE_STRING). $this->createSalt($userData->email));
                                        $email = filter_var($_POST['email'], FILTER_SANITIZE_STRING);
                                        $queries .= " email='". $email ."', password='". $hash ."',";
                                        
                                    }
                                    else {
                                        echo "<script>alert('Password does not match the following requirements-8 char length -at least one lowercase character -at least one uppercase character -at least one special character')</script>";
                                    }
                                }
                                else {
                                    $pass_set = true;
                                    echo "<script>alert('Password and password confirmation must match!')</script>";
                                }
                            }
                            else {
                                echo "<script>alert('Updating email requires password confirmation!');</script>";
                            }
                            
                        }
                        else {
                            echo "<script>alert('This email is already in use on another account!')</script>";
                        }
                    }
                    else {
                        echo "<script>alert('Incorrect email format!')</script>";
                    }
                }

                if (!strpos($queries, "password") !== false && $pass_set == false) {
                    if (isset($_POST['pwd']) && isset($_POST['pwdConfirm']) && $_POST['pwd'] != "" && $_POST['pwdConfirm']) {
                        if ($_POST['pwd'] == $_POST['pwdConfirm']) {
                            if ($this->passwordValidation()) {
                                $hash = hash('sha256', filter_var($_POST['pwd'], FILTER_SANITIZE_STRING). $this->createSalt($userData->email));
                                $queries .= " password='". $hash ."',";
                            }
                            else {
                                echo "<script>alert('Password does not match the following requirements-8 char length -at least one lowercase character -at least one uppercase character -at least one special character')</script>";
                            }
                        }
                        else {
                            echo "<script>alert('Password and password confirmation must match!')</script>";
                        }
                    }
                }
                
                
                if (isset($_POST['currencyId']) && $_POST['currencyId'] != $_SESSION['defCurrencyId']) {
                    $queries .= " currency_id=" . $_POST['currencyId'] . " "; 
                }

                if (substr($queries, -1) == ",") {
                   $queries = substr($queries, 0, -1);
                }
                $queries .= $end;
                if (strpos($queries, "name") !== false|| strpos($queries, "email") !== false || strpos($queries, "password") !== false || strpos($queries, "currency_id") !== false) {
                    $userDaoObj->updateUserData($queries);
                }
                echo "<script>console.log(".$queries.")</script>";
            
            }
            

            return $this->load('user', 'settings', [
                'currencies' => $currencies,
                'default_currency' => $defCurrency,
                'user' => $userData,
            ]);
        }

        public function loadReports(){
            $transactionDao = new TransactionsDao();
            $monthly_expense = $transactionDao->getMonthlyExpensesData();
            $monthly_income = $transactionDao->getMonthlyIncomeData();
            $yearly_data = $transactionDao->getYearlyData();
            $expense_categories = array();
            $expense_amounts = array();
            $income_amounts = array();
            $months = array();
            $yearly_incomes = array();
            $yearly_expenses = array();
            foreach ($monthly_expense as $expense) {
                array_push($expense_categories, $expense->Category);
                array_push($expense_amounts, $expense->Amount);
            }

            foreach ($monthly_income as $income) {
                array_push($income_amounts, $income->Amount);
            }
            foreach ($yearly_data as $month) {
                if (!in_array($month->Month, $months, true)) {
                    array_push($months, $month->Month);
                }
                
                if ($month->type == "income") {
                    array_push($yearly_incomes, $month->Amount);
                }
                else {
                    array_push($yearly_expenses, $month->Amount);
                }
                
            }

            return $this->load('user', 'reports', [
                'expense_categories' => $expense_categories,
                'expense_amounts'    => $expense_amounts,
                'income_amounts'     => $income_amounts,
                'months'             => $months,
                'yearly_incomes'     => $yearly_incomes,
                'yearly_expenses'    => $yearly_expenses,
            ]);

        }

        function loadDeleteUser(){
            if (isset($_POST['delete'])) {
                $userDaoObj = new userDao();
                $userDaoObj->deleteUser();
                session_destroy();
                header('Location: index.php?controller=TransactionController&action=login');
            }

            return $this->load('user', 'delete_user');
        }

    

        function loadHomepage(){
            if (isset($_SESSION['userId'])) {
                header("Location: index.php?controller=TransactionController&action=transactions");
            }
            else {
                header("Location: index.php?controller=TransactionController&action=login");
            }
        }
        
    }
?>