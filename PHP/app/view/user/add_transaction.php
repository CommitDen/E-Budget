<div class="row">
	<div class="jumbotron jumbotron-fluid bg-info text-white pt-3 pb-3">
    	<h1 class="display-3 text-center"> Add transaction </h1>
	</div>
</div>
<div class="container mt-5 d-flex justify-content-center">
    <div class="col-sm-6">
        <form method="POST" action="index.php?controller=TransactionController&action=addNewTransaction">
            <div class="form-group">
                <label for="category">Category</label>
                <select onchange="loadSubcategories(this);" class="form-select" aria-label="category" name="newTransaction[category]" id="category">
                    <?php
                        foreach ($allCategories as $category) {
                        echo "<option value=".$category->name.":".$category->id." >".$category->name."</option>";
                        }
                        ?>
                </select>
                <?php
                if(!empty($_POST['newTransaction']['category'])) {
                    $selected = $_POST['newTransaction']['category'];
                    echo 'You have chosen: ' . $selected;
                }
                ?>
            </div>
            
            <div class="form-group">
                <label for="subcategory">Subcategory</label>
                <select class="form-select" aria-label="subcategory" name="newTransaction[subcategory]" id="newTransaction[subcategory]">
                
                </select>
                <?php
                   
                ?>
            </div>
            <div class="form-group">
                <label for="amount">Amount</label>
                <input type="number" class="form-control" name="newTransaction[amount]" id="amount"> 
            </div>
            <div class="form-group">
                <label for="currencyCode">Currency code</label>
                <select class="form-select" aria-label="currencyCode" name="newTransaction[currency]" id="currencyCode">
                    <?php
                    $selected = "";
                    foreach ($currencies as $currency) {
                        ($currency->currency_code == $_SESSION['defCurrency']) ? $selected = "selected" : $selected = "";
                       echo "<option value=".$currency->id." $selected>".$currency->currency_code."</option>";
                    }
                    ?>
                </select>
                
            </div>
            <div class="form-group">
                <label for="newTransaction[date]">Date</label>
                <input type="date" name="newTransaction[date]" value="<?php echo date("Y-m-d"); ?>">
            </div>
            <div class="form-group">
                <label for="newTransaction[comment]">Comment</label>
                <input type="text" class="form-control" name="newTransaction[comment]"> 
            </div>
            <div class="form-group mt-3 justify-content-between d-flex">
                <a class="btn btn-warning" href="javascript:history.go(-1)">
                    <i class="fas fa-arrow-left"></i> Back
				</a>
                <button class="btn btn-success text-white" name="newTransaction[add]" type="submit">
                   Add <i class="fas fa-save"></i>
                </button>
            </div>
        </form>
    </div>

</div>

<script>
    window.onload = loadSubcategories(document.getElementById('category'));
   function loadSubcategories(sel){
        let parts = document.getElementById('category').value.split(":");
        let category_id = parts[1];
        let subcategories = <?php echo json_encode($allSubcategories); ?>;
        let category_name = sel.options[sel.selectedIndex].text;
        let category_income = <?php echo json_encode($categoriesIncome); ?>;
        if (category_income.some(e => e.name === category_name)) {
            document.getElementById('newTransaction[subcategory]').innerHTML = "";
        }
        else {
            var options = "";
            for (let index = 0; index < subcategories.length; index++) {
                if (subcategories[index].categories_expense_id == category_id) {
                    options += "<option value="+subcategories[index].id+">"+subcategories[index].name+"</option>";
                } 
            }
            document.getElementById('newTransaction[subcategory]').innerHTML = options;
        }
   } 

</script>