<div class="container mt-5 border col-md-8 rounded" style="background-color: #f1f1f1;">
    <div class="row text-center pb-5">
        <form action=""  class="col-md-10 mx-auto pt-5" method="POST">
            <label class="form-label" for="subcategory_name">Subcategory: </label>
            <input class="col-6" type="text" name="subcategory_name" id="subcategory_name" value="<?php echo $subcategory->name; ?>">
            <button name="edit" class="btn btn-success border fw-bold"><i class="fa-solid fa-floppy-disk"></i>  Save</button>
        </form>
    </div>
</div>