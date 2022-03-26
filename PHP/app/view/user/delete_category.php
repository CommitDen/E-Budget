<div class="row">
    <div class="col-sm-12">
        <div class="jumbotron bg-info text-white pt-3 pb-3">
            <h1 class="display-3 text-center"> Delete category </h1>
        </div>
    </div>
</div>
<div class="row">
    <div class="container d-flex align-items-center justify-content-center">
           <form action="" method="POST">
                <div class="col-sm-12 justify-content-center">
                    <div class="d-flex pt-5">
                        <a class="btn btn-warning" href="javascript:history.go(-1)">
                            <i class="fas fa-arrow-left"></i> Back
                        </a>
                        <h3> Category: <?php echo $category; ?> </h3>
                        <button class="btn btn-danger" type="submit" name="delete"> Delete
                            <i class="fas fa-trash"></i>
                        </button>
                    </div>
                </div>
            </form>
    </div>
</div>