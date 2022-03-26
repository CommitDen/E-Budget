<div class="container d-flex align-items-center justify-content-center w-50 mt-5 bg-dark p-5 border border-white rounded">
    <form action="" class="col-6 text-start text-white" method="POST">
        <div class="mb-5">
            <h1>Settings</h1>
        </div>
        <div class="mb-3">
            <label for="name" class="form-label fw-bold">Name*:</label>
            <input type="text" name="name" class="form-control" id="name" value="<?php echo $user->name;?>">
        </div>
        <div class="mb-3">
            <label for="email" class="form-label fw-bold">E-mail*:</label>
            <input type="email" name="email" class="form-control" id="email" value="<?php echo $user->email;?>">
        </div>
        <div class="mb-3">
            <label for="pwd" class="form-label fw-bold">Password*:</label>
            <input type="password" name="pwd" class="form-control" id="pwd">
        </div>
        <div class="mb-3">
            <label for="pwdConfirm" class="form-label fw-bold">Password confirmation*:</label>
            <input type="password" name="pwdConfirm" class="form-control" id="pwdConfirm">
        </div>
        <div class="mb-3">
            <select name="currencyId" id="">
                <?php 
                    $selected = "";
                    foreach ($currencies as $currency) {
                        ($currency->currency_code == $default_currency->currency_code) ?  $selected = "selected" : $selected = "";
                        echo "<option value=" . $currency->id . " $selected>". strtoupper($currency->currency_code) ."</option>";
                    }
                ?>
            </select>
        </div>
        <div class="text-center">
            <button type="submit" class="btn btn-dark border border-primary m-4 col-4 offset-4" name="update">Update</button>
        </div>
        <div class="text-center">
            <a href="index.php?controller=TransactionController&action=deleteUser" class="btn btn-danger text-white border border-white-10 m-2 col-4 offset-4" name="deleteUser">Delete account</a>
        </div>
    </form>
</div>


