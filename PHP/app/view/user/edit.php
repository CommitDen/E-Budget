<div class="row">
	<div class="jumbotron jumbotron-fluid bg-info text-white pt-3 pb-3">
    	<h1 class="display-3 text-center"> Transaction edit </h1>
	</div>
</div>
<div class="container mt-5 d-flex justify-content-center">
    <div class="col-sm-6">
        <form method="POST" action="index.php?controller=TransactionController&action=update&id=<?php echo $selectedTransaction->id ;?>">
            <div class="form-group">
                <label for="category">Category</label>
                <select onchange="loadSubcategories(this);" class="form-select" aria-label="category" name="selectedTransaction[category]" id="category">
                    <?php
                    $selected = "";
                        foreach ($allCategories as $category) {
                        ($category->name == $selectedTransaction->Category) ? $selected = "selected" :$selected = "";
                        echo "<option value=".$category->name.":".$category->id." $selected>".$category->name."</option>";
                        }
                        ?>
                </select>
                <?php
                if(!empty($_POST['selectedTransaction[category]'])) {
                    $selected = $_POST['selectedTransaction[category]'];
                    echo 'You have chosen: ' . $selected;
                }
                ?>
            </div>
            
            <div class="form-group">
                <label for="subcategory">Subcategory</label>
                <select class="form-select" aria-label="subcategory" name="selectedTransaction[subcategory]" id="selectedTransaction[subcategory]">
                
                </select>
                <?php
                   
                ?>
            </div>
            <div class="form-group">
                <label for="amount">Amount</label>
                <input type="number" class="form-control" name="selectedTransaction[amount]" value="<?php echo $selectedTransaction->Amount ;?>" id="amount"> 
            </div>
            <div class="form-group">
                <label for="currencyCode">Currency code</label>
                <select class="form-select" aria-label="currencyCode" name="selectedTransaction[currency]" id="currencyCode">
                    <?php 
                    $selected = "";
                    foreach ($currencies as $currency) {
                       ($currency->currency_code == $selectedTransaction->Currency_code) ? $selected = "selected" :$selected = "";
                       echo "<option value=".$currency->id." $selected>".$currency->currency_code."</option>";
                    }
                    ?>
                </select>
            </div>
            <div class="form-group">
                <label for="selectedTransaction[date]">Date</label>
                <?php
                    $createDate = new DateTime($selectedTransaction->Date);
                    $strip = $createDate->format('Y-m-d');
                ?>
                <input type="date" name="selectedTransaction[date]" value="<?php echo $strip; ?>">
            </div>
            <div class="form-group">
                <label for="selectedTransaction[comment]">Comment</label>
                <input type="text" class="form-control" name="selectedTransaction[comment]" value="<?php echo $selectedTransaction->Comment; ?>"> 
            </div>
            <div class="form-group mt-3 justify-content-between d-flex">
                <a class="btn btn-warning" href="javascript:history.go(-1)">
                    <i class="fas fa-arrow-left"></i> Back
				</a>
                <button class="btn btn-success text-white" name="selectedTransaction[edit]" type="submit">
                   Edit <i class="fas fa-save"></i>
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
        let subcategory_name = <?php echo json_encode($selectedTransaction->Subcategory); ?>; 
        if (category_income.some(e => e.name === category_name)) {
            document.getElementById('selectedTransaction[subcategory]').innerHTML = "";
        }
        else {
            var options = "";
            for (let index = 0; index < subcategories.length; index++) {
                if (subcategories[index].categories_expense_id == category_id) {
                    let selected = (subcategories[index].name == subcategory_name) ? "selected" : "";
                    options += "<option value="+subcategories[index].id+" "+selected+">"+subcategories[index].name+"</option>";
                } 
            }
            document.getElementById('selectedTransaction[subcategory]').innerHTML = options;
        }
   } 
</script>