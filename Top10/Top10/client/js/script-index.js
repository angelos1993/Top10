function validateLogin() {
    var requiredInput = "required-input";
    var isValid = true;
    var elmUsername = $("[id$=TxtUsername]");
    var elmPassword = $("[id$=TxtPassword]");
    elmUsername.removeClass(requiredInput);
    elmPassword.removeClass(requiredInput);
    var txtUsername = elmUsername.val().trim();
    var txtPassword = elmPassword.val().trim();
    elmUsername.val(txtUsername);
    elmPassword.val(txtPassword);
    if (txtUsername === null || txtUsername === "") {
        isValid = false;
        elmUsername.addClass(requiredInput);
    }
    if (txtPassword === null || txtPassword === "") {
        isValid = false;
        elmPassword.addClass(requiredInput);
    }
    return isValid;
}