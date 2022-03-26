<div class="container">
    <div class="row">
    <div class="col-md-8 mx-auto">
    <div class="table-responsive">
            <table class="table table-striped mt-5">
                <thead class="thead-dark">
                    <tr class="bg-dark text-white">
                    <th scope="" class='col-1'>Categories</th>
                    <th scope="" class='col-2 text-end'></th>
                    </tr>
                </thead>
                <tbody>
                    <?php
                        foreach ($categories as $category) {
                            echo "<tr>";
                            echo "<td class='col-1 align-middle'>" . $category->name . "</td>";
                            echo "<td class='col-2 text-end'>";
                            if ($category->type == "income" && $category->user_id != $_SESSION['userId']) {
                                $edit = "disabled";
                                $delete = "";
                                $disabled = "disabled";
                            }
                            elseif ($category->type == "income" && $category->user_id == $_SESSION['userId']) {
                                $delete = "href='index.php?controller=TransactionController&action=load_delete_category&category=$category->name'";
                                $disabled = "";
                                $edit = "disabled";
                            }
                            elseif ($category->type == "expense" && $category->user_id != $_SESSION['userId']) {
                                $edit = "";
                                $delete = "";
                                $disabled = "disabled";
                            }
                            else {
                                $delete = "href='index.php?controller=TransactionController&action=load_delete_category&category=$category->name'";
                                $disabled = "";
                                $edit = "";
                            }
                            echo "<a class='btn btn-warning me-2 $edit' href='index.php?controller=TransactionController&action=load_edit_category&category=$category->name'><i class='btn-group btn-group-lg far fa-edit'></i> Edit </a>";
                            echo "<a class='btn btn-danger $disabled' $delete><i class='btn-group btn-group-lg far fa-trash-can'></i> Delete </a>";
                            echo "</td>";
                            echo "</tr>";
                        }
                        
                    ?>
                </tbody>
            </table>
            <div class="col-12 text-center">
                <a class='btn btn-warning me-2' href='index.php?controller=TransactionController&action=load_add_category'><i class='btn-group btn-group-lg fa-solid fa-plus'></i> Add new category </a>
            </div>
    </div>
    </div>
    </div>
</div>




