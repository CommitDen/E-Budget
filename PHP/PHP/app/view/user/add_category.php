<div class="container">
    <div class="row">    
        <form action="" class="border rounded col-lg-6 col-md-8 mx-auto p-5" style="background-color: #f1f1f1;" method="POST">
            <div class="row text-center mb-2">
                <h2>Add new category</h2>
            </div>
            <div class="row">
                <label for="categoryAdd" class="form-label mb-2">Category</label>
                <input type="text" name="categoryAdd" id="categoryAdd" class="form-control mb-2">
            </div>
            <div class="row">
                <label for="category_type" class="form-label mb-2">Type</label>
                <select name="category_type" id="" class="form-select mb-3">
                    <option value="1">Expense</option>
                    <option value="0">Income</option>
                </select>
            </div>
            <div class="text-center">
                <button type="submit" class="btn btn-primary mt-4" name="add_category"><i class='btn-group btn-group-lg fa-solid fa-plus'></i> Add</button>
            </div>
        </form>
    </div>
</div>
