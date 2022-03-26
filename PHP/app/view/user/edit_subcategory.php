<div class="container mt-5 border bg-secondary rounded">
    <div class="row text-center">
        <form action="" class="col-md-8 mx-auto pt-5" method="POST">
        <label class="form-label text-white" for="subcategory_name">Subcategory: </label>
        <input class="col-6" type="text" name="subcategory_name" id="subcategory_name" value="<?php echo $subcategory->name; ?>">
        <button name="edit" class="btn btn-success border fw-bold"><i class="fa-solid fa-floppy-disk"></i>  Save</button>
        </form>
    </div>
</div>