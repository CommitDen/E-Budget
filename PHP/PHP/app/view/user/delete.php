<div class="row">
    <div class="col-sm-12">
        <div class="jumbotron bg-light border pt-3 pb-3">
            <h3 class="display-4 text-center"> Delete transaction </h3>
        </div>
    </div>
</div>
<div class="row">
           <form action="index.php?controller=TransactionController&action=deleteTransaction&id=<?php echo $transaction->id ;?>&category=<?php echo $transaction->Category ;?>" method="POST">
                        <div class="row text-center mt-3">
                            <h4> Id: <?php echo $transaction->id; ?> </h4>
                        </div>
                        <div class="text-center mt-2">
                            <a class="btn btn-warning" href="javascript:history.go(-1)">
                                <i class="fas fa-arrow-left"></i> Back
                            </a>
                            <button class="btn btn-danger" type="submit" name="delete"> Delete
                                <i class="fas fa-trash-can"></i>
                            </button>
                        </div>
            </form>
    </div>
</div>