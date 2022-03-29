<div class="container">
    <div class="row p-5 mx-auto">
            <form action="" class="border rounded col-lg-6 col-md-8 mx-auto p-3" style="background-color: #f1f1f1;" method="POST">
                <div class="form-group text-center mb-3">
                    <h1>E-Budget</h1>
                </div>
                <div class="form-group col-lg-6 col-sm-10 offset-lg-3 offset-sm-1 mb-3">
                    <label for="Email" class="form-label fw-bold">Email</label>
                    <input type="text" name="email" id="Email" class="form-control">
                </div>
                <div class="form-group col-lg-6 col-sm-10 offset-lg-3 offset-sm-1 mb-3">
                    <label for="Pwd" class="form-label fw-bold">Password</label>
                    <input type="password" name="pwd" id="Pwd" class="form-control">
                </div>
                <div class="text-center mt-1 mb-3">
                    <button type="submit" name="login" href="index.php?controller=TransactionController&action=login" class="btn-lg btn-primary border m-3">Login</button><br>
                    <a href="index.php?controller=TransactionController&action=sign_up" name="signUp" class="m-2">Sign up</a>
                </div>
            </form>
    </div>
</div>
    
