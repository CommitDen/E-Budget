<div class="container mt-5 border bg-secondary rounded">
    <div class="row text-center">
        <form action="index.php?controller=TransactionController&action=edit_category&category=<?php echo $selectedCategory->name; ?>" class="col-md-8 mx-auto pt-5" method="POST">
        <label class="form-label text-white" for="category_name">Category: </label>
        <input class="col-6" type="text" name="category_name" id="category_name" value="<?php echo $selectedCategory->name; ?>" <?php if(!$isUserOwned) echo "disabled"; ?> >
        <button name="edit" class="btn btn-success border fw-bold" <?php if(!$isUserOwned) echo "disabled"; ?>><i class="fa-solid fa-floppy-disk"></i>  Save</button>
        </form>
    </div>
    <?php
        if ($isExpense) {
            echo '<div class="row">
             <div class="col-md-8 mx-auto">
             <div class="table-responsive">
             <table class="table table-striped mt-5">
             <thead class="thead-dark">
             <tr class="bg-dark text-white">
             <th scope="" class="col-1">Subcategories</th>
             <th scope="" class="col-2 text-end"></th>
             </tr>
             </thead>
                <tbody class="bg-white">';
                            
                    foreach ($subcategories as $subcategory) {
                        if ($subcategory->user_id != $_SESSION['userId']) {
                            $disabled = "disabled";
                        }
                        else {
                            $disabled = "";  
                        }
                        echo "<tr>";
                        echo "<td class='col-1 align-middle'>" . $subcategory->name . "</td>";
                        echo "<td class='col-2 text-end'>";
                        echo "<a class='btn btn-warning me-2 $disabled' href='index.php?controller=TransactionController&action=load_edit_subcategory&id=$subcategory->id'><i class='btn-group btn-group-lg far fa-edit'></i> Edit </a>";
                        echo "<a class='btn btn-danger $disabled' href='index.php?controller=TransactionController&action=load_delete_subcategory&id=$subcategory->id'><i class='btn-group btn-group-lg far fa-trash-can'></i> Delete </a>";
                        echo "</td>";
                        echo "</tr>";
                    }
                    

            echo '</tbody>
            </table>
                    
            <div class="col-12 text-center mb-5 mt-5">
            <a class="btn btn-warning me-2" href="index.php?controller=TransactionController&action=load_add_subcategory&category='. $selectedCategory->name . '"><i class="btn-group btn-group-lg fa-solid fa-plus"></i> Add new Subcategory </a>
            </div>
            </div>
            </div>   
            </div>';
        }
    ?>
</div>



