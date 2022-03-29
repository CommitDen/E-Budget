<div class="container">
    <div class="row p-5 mt-5 mx-auto">
        <form action="" class="border rounded col-lg-6 col-md-8 mx-auto p-5" style="background-color: #f1f1f1;" method="POST">
            <div class="mb-5">
                <h1>E-Budget</h1>
            </div>
            <div class="mb-3">
                <label for="Name" class="form-label fw-bold">Name*:</label>
                <input type="text" name="name" class="form-control" id="Name">
            </div>
            <div class="mb-3">
                <label for="Email" class="form-label fw-bold">E-mail*:</label>
                <input type="email" name="email" class="form-control" id="Email">
            </div>
            <div class="mb-3">
                <label for="Pwd" class="form-label fw-bold">Password*:</label>
                <input type="password" name="pwd" class="form-control" id="Pwd">
            </div>
            <div class="mb-3">
                <label for="PwdConfirm" class="form-label fw-bold">Password confirmation*:</label>
                <input type="password" name="pwdConfirm" class="form-control" id="PwdConfirm">
            </div>
            <div class="mb-3">
                <select name="currencyId" id="">
                    <?php 
                        $selected = "";
                        foreach ($currencies as $currency) {
                            ($currency->currency_code == "eur") ?  $selected = "selected" : $selected = "";
                            echo "<option value=" . $currency->id . " $selected>". strtoupper($currency->currency_code) ."</option>";
                        }
                    ?>
                </select>
            </div>
            <div class="text-center">
                <button type="submit" class="btn-lg btn-primary border mb-4" name="regData">Sign Up</button>
            </div>
            <div class="text-center">
                <a href="index.php?controller=TransactionController&action=login" class="" name="backToLogin">Login</a>
            </div>
        </form>
    </div>
</div>
