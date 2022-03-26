<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>E-Budget</title>
    <link rel="icon" type="image/x-icon" href="app/favicon.ico">
    <link rel="stylesheet" href="app\css\bootstrap.min.css">
    <script src="js/jquery-3.6.0.min.js"></script>
 
    <link rel="stylesheet" type="text/css" href="DataTables/datatables.min.css"/>
 
    <script type="text/javascript" src="DataTables/datatables.min.js"></script>


    <link rel="stylesheet" type="text/css" href="css\style.css">
    <script src="https://kit.fontawesome.com/726d8295c9.js" crossorigin="anonymous"></script>
</head>
<div class="container">
    <div class="row">
        <div class=" mt-5">
            <h3 class="col-4" id="Balance">Balance: <span id="balance"></span> <?php echo ucfirst($_SESSION['defCurrency']); ?></h3>
            <h3 class="col-4" id="totalExpense">Expense total: <span id="expense"></span> <?php echo ucfirst($_SESSION['defCurrency']); ?></h3>
            <h3 class="col-4" id="totalIncome">Income total: <span id="income"></span> <?php echo ucfirst($_SESSION['defCurrency']); ?></h3>
        </div>
    </div>
    <div class="row justify-content-md-center">
            <select name="type_filter" class="ms-2 col-sm-1" id="type_filter">
                <option value="">Type</option>
                <option value="expense">Expense</option>
                <option value="income">Income</option>
            </select>
            <select onchange="loadSubcategories(this);" name="category_filter" class="ms-2 col-sm-2" id="category_filter">
                <option value="">Category</option>
                <?php 
                    foreach ($categories as $category) {
                        echo "<option value=".$category->name.":".$category->id.">".$category->name."</option>";
                    }    
                ?>
            </select>

            <select name="subcategory_filter" class="ms-2 col-sm-2" id="subcategory_filter">
                <option value="">Subcategory</option>
            </select>
            <select name="currency_filter" class="ms-2 col-sm-1" id="currency_filter">
                <option value="">Currency</option>
                <?php 
                    foreach ($currencies as $currency) {
                        echo "<option value=".$currency->id.">".$currency->currency_code."</option>";
                    }
                ?>
            </select>
            <button class="col-1 btn btn-secondary border border-primary ms-2 fw-bold" name="clear" id="Clear">
                <i class="fa-solid fa-filter-circle-xmark"></i> Clear
            </button>
        
    </div>
    <div class="row d-flex justify-content-md-center mt-2">
            <div class="col-auto mt-1">
                <label for="from_date_filter" class="">Date from:</label>
            </div>
            <input type="date" name="from_date_filter" class="col-sm-2 ps-0 ms-0" value="<?php echo date('Y-m-01'); ?>" id="from_date_filter">
            <div class="col-auto mt-1">
                <label for="to_date_filter" class="">Date to:</label>
            </div>
            <input type="date" name="to_date_filter" value="<?php echo date('Y-m-t'); ?>" class="col-sm-2" id="to_date_filter">
            <button class="ms-2 btn-sm btn-secondary border border-primary fw-bold" name="filter" id="filter">
                <i class="fa-solid fa-filter"></i> Filter
            </button>
    </div>
    <div class="row">
        <div class="col-12 mt-3">
            <a href="index.php?controller=TransactionController&action=loadAddNewTransaction" class="btn btn-secondary border border-primary ms-2 fw-bold"><i class="fa-solid fa-plus"></i> Add transaction</a>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-12 text-center">
            <table class="col-sm-12 table table-striped table-hover text-center table-bordered mt-5 align-middle" id="transaction_table">
                <thead class="thead-dark">
                    <tr class="bg-dark text-white">
                    <th scope="col">Category</th>
                    <th scope="col">Subcategory</th>
                    <th scope="col">Amount</th>
                    <th scope="col">Currency</th>
                    <th scope="col">Date</th>
                    <th scope="col">Comment</th>
                    <th>Actions</th>
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
    responsive: {
        breakpoints: [
        {name: 'bigdesktop', width: Infinity},
        {name: 'meddesktop', width: 1480},
        {name: 'smalldesktop', width: 1280},
        {name: 'medium', width: 1188},
        {name: 'tabletl', width: 1024},
        {name: 'btwtabllandp', width: 848},
        {name: 'tabletp', width: 768},
        {name: 'mobilel', width: 480},
        {name: 'mobilep', width: 320}
        ]
    },
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
   balance(type_filter, category_filter, subcategory_filter, currency_filter, from_date_filter, to_date_filter);
   function balance(type_filter, category_filter, subcategory_filter, currency_filter, from_date_filter, to_date_filter){
        $.ajax({    
            type: "POST",
            url: "balance.php",
            dataType: "json",
            data: {type_filter:type_filter, category_filter:category_filter, subcategory_filter:subcategory_filter, currency_filter:currency_filter, from_date_filter:from_date_filter, to_date_filter:to_date_filter},       
            success: function(data){
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
