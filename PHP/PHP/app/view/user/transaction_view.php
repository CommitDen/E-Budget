<div class="container">
    <div class="row">
        <div class="mt-2 mb-3">
            <h3 class="col-lg-4" id="Balance">Balance: <span id="balance"></span> <?php echo ucfirst($_SESSION['defCurrency']); ?></h3>
            <h3 class="col-lg-4" id="totalExpense">Expense total: <span id="expense"></span> <?php echo ucfirst($_SESSION['defCurrency']); ?></h3>
            <h3 class="col-lg-4" id="totalIncome">Income total: <span id="income"></span> <?php echo ucfirst($_SESSION['defCurrency']); ?></h3>
        </div>
    </div>
            <div class="col-12 col-md-12">
                <div class="row">
                    <div class="col-3 col-md-3 mb-4 mb-md-0 mx-auto">   
                        <form action="">
                            <select name="type_filter" class="custom-select form-control" id="type_filter">
                                <option value="">Type</option>
                                <option value="expense">Expense</option>
                                <option value="income">Income</option>
                            </select>
                        </form>
                    </div>
                    <div class="col-3 col-md-3 mb-4 mb-md-0 mx-auto">   
                        <form action="">
                            <select onchange="loadSubcategories(this);" name="category_filter" class="custom-select form-control" id="category_filter">
                                <option value="">Category</option>
                                <?php 
                                    foreach ($categories as $category) {
                                        echo "<option value=".$category->name.":".$category->id.">".$category->name."</option>";
                                    }    
                                ?>
                            </select>
                        </form>
                    </div>
                    <div class="col-3 col-md-3 mb-4 mb-md-0 mx-auto">   
                        <form action="">
                            <select name="subcategory_filter" class="custom-select form-control" id="subcategory_filter">
                                <option value="">Subcategory</option>
                            </select>
                        </form>
                    </div>
                    <div class="col-3 col-md-3 mb-4 mb-md-0 mx-auto">   
                        <form action="">
                            <select name="currency_filter" class="custom-select form-control" id="currency_filter">
                                <option value="">Currency</option>
                                <?php 
                                    foreach ($currencies as $currency) {
                                        echo "<option value=".$currency->id.">".$currency->currency_code."</option>";
                                    }
                                ?>
                            </select>
                        </form>
                    </div>
                    
            </div>
            <div class="col-12 col-md-12">
                <div class="row">
                        <div class="col-6 col-md-6 mb-4 mb-md-0 mx-auto">
                            <label for="from_date_filter" class="">Date from:</label>
                            <input type="date" name="from_date_filter" class="form-control" value="<?php echo date('Y-m-01'); ?>" id="from_date_filter">
                        </div>
                        <div class="col-6 col-md-6 mb-4 mb-md-0 mx-auto">
                            <label for="to_date_filter" class="">Date to:</label>
                            <input type="date" name="to_date_filter" value="<?php echo date('Y-m-t'); ?>" class="form-control" id="to_date_filter">
                        </div>
                        
                </div>
            </div>
            
            
            <div class="row">
                <div class="col-12 mt-3 mb-2">
                    <div class="position-relative">
                        <a href="index.php?controller=TransactionController&action=loadAddNewTransaction" class="btn btn-success border fw-bold"><i class="fa-solid fa-plus"></i> Add transaction</a>
                        <button class="btn btn-primary border ms-2 fw-bold position-absolute top-0 end-0" name="filter" id="filter">
                            <i class="fa-solid fa-filter"></i> Filter
                        </button>
                        
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-12 mb-3">
                    <div class="position-relative">
                        <button class="btn btn-danger border ms-2 fw-bold position-absolute top-0 end-0" name="clear" id="Clear">
                            <i class="fa-solid fa-filter-circle-xmark"></i> Clear
                        </button>
                    </div>
                </div>
            </div>
            
    

    <div class="row">
        <div class="col-xs-12">
            <table class="table table-bordered table-striped table-hover" width="100%" id="transaction_table">
                <thead class="thead-dark">
                    <tr class="bg-dark text-white">
                    <th scope="">Category</th>
                    <th scope="">Subcategory</th>
                    <th scope="">Amount</th>
                    <th scope="">Currency</th>
                    <th scope="">Date</th>
                    <th scope="">Comment</th>
                    <th class="text-center">Actions</th>
                    </tr>
                </thead>
                
            </table>
        </div>
    </div>
</div>

    


<script type="text/javascript" language="javascript">
    window.onload = loadSubcategories(document.getElementById('category_filter'));
   function loadSubcategories(sel){
        let selected = "";
        selected = "";
        let parts = document.getElementById('category_filter').value.split(":");
        let category_id = parts[1];
        let subcategories = <?php echo json_encode($subcategories); ?>;
        let category_name = sel.options[sel.selectedIndex].text;
        let category_income = <?php echo json_encode($categories_income); ?>;
        if (category_income.some(e => e.name === category_name)) {
            document.getElementById('subcategory_filter').innerHTML = "<option value=''>Subcategory</option>";
        }
        else {
            var options = "<option value=''>Subcategory</option> ";
            for (let index = 0; index < subcategories.length; index++) {
                if (selected != ""  && selected == subcategories[index].name) {
                    selected = "selected";
                }
                else{
                    selected = "";
                }
                
                if (subcategories[index].categories_expense_id == category_id) {
                    options += "<option value='"+subcategories[index].id+"' "+selected+">"+subcategories[index].name+"</option>";
                } 
            }
            document.getElementById('subcategory_filter').innerHTML = options;
        }
   } 


    $(document).ready(function(){
    var from_date_filter = $('#from_date_filter').val();
    var to_date_filter = $('#to_date_filter').val();
   
    fill_datatable(null, null, null, null, from_date_filter, to_date_filter);
    
  
  function fill_datatable(type_filter = '', category_filter = '', subcategory_filter= '', currency_filter = '', from_date_filter = '', to_date_filter = '')
  {
   var dataTable = $('#transaction_table').DataTable({
    responsive: true,
    columns: [
    { orderable: true },
    { orderable: true },
    { orderable: true },
    { orderable: true },
    { orderable: true },
    { orderable: true },
    { orderable: false },
    ],
    
    
    "processing" : true,
    "serverSide" : true,
    "order" : [],
    "searching" : false,
    "ajax" : {
     url:"filter.php",
     type:"POST",
     data:{
        type_filter:type_filter, category_filter:category_filter, subcategory_filter:subcategory_filter, currency_filter:currency_filter, from_date_filter:from_date_filter, to_date_filter:to_date_filter
     }
    }
   });
   dataTable.draw();
   balance(type_filter, category_filter, subcategory_filter, currency_filter, from_date_filter, to_date_filter);
   function balance(type_filter, category_filter, subcategory_filter, currency_filter, from_date_filter, to_date_filter){
        $.ajax({    
            type: "POST",
            url: "balance.php",
            dataType: "json",
            data: {type_filter:type_filter, category_filter:category_filter, subcategory_filter:subcategory_filter, currency_filter:currency_filter, from_date_filter:from_date_filter, to_date_filter:to_date_filter},       
            success: function(data){
                console.log(data.balance, data.expense_total, data.income_total);
                $("#balance").html(data.balance); 
                $("#expense").html(data.expense_total); 
                $("#income").html(data.income_total); 
            }
        });
    }
  }
    

  $('#filter').click(function(){
   var type_filter = $('#type_filter').val();
   var category_filter = $('#category_filter').val();
   var subcategory_filter = $('#subcategory_filter').val();
   var currency_filter = $('#currency_filter').val();
   var from_date_filter = $('#from_date_filter').val();
   var to_date_filter = $('#to_date_filter').val();
   

   $('#transaction_table').DataTable().destroy();
    fill_datatable(type_filter, category_filter, subcategory_filter, currency_filter, from_date_filter, to_date_filter);
  });

  $('#Clear').click(function(){
    var type = $('#type_filter').get(0);
    var category = $('#category_filter').get(0);
    var subcategory = $('#subcategory_filter').get(0);
    var currency = $('#currency_filter').get(0);
    
    type.selectedIndex = 0;
    category.selectedIndex = 0;
    loadSubcategories($('#category_filter').get(0));
    subcategory.selectedIndex = 0;
    currency.selectedIndex = 0;

    const formatDate = (date) => {
        let d = new Date(date);
        let month = (d.getMonth() + 1).toString();
        let day = d.getDate().toString();
        let year = d.getFullYear();
        if (month.length < 2) {
            month = '0' + month;
        }
        if (day.length < 2) {
            day = '0' + day;
        }
        return [year, month, day].join('-');
    }
    
    var firstDay = <?php echo json_encode(date('Y-m-01')); ?>;
    var lastDay = <?php echo json_encode(date('Y-m-t')); ?>;
    $("#from_date_filter").val(formatDate(new Date(firstDay)));
    $("#to_date_filter").val(formatDate(new Date(lastDay)));
    $('#transaction_table').DataTable().destroy();
    fill_datatable(null, null, null, null, formatDate(new Date(firstDay)), formatDate(new Date(lastDay)));
  });
  
  
 });




</script>
