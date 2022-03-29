<div class="container">
    <div class="row p-5 mx-auto">
        <form action="" class="border rounded col-lg-6 col-md-8 mx-auto p-5" style="background-color: #f1f1f1;" method="POST">
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
                <label for="currencyId" class="form-label fw-bold">Currency:</label>
                <select name="currencyId" id="" class="form-select">
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
                <button type="submit" class="btn btn-success border m-2" name="update"><i class="fa-solid fa-wrench"></i> Update</button>
            </div>
            <div class="text-center">
                <a href="index.php?controller=TransactionController&action=deleteUser" class="btn btn-danger border mt-3" name="deleteUser"><i class="fa-solid fa-trash-can"></i> Delete account</a>
            </div>
        </form>
    </div>
</div>


