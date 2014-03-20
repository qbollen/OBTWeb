//Validate Login
function ValidateLogin() {
    var username = document.getElementById("txtUserName");
	if(username.value == ""){
		alert("user name can not empty!");
		return false;
	}

	var password = document.getElementById("txtPwd");
	if(password.value == ""){
		alert("password can not empty!");
		return false;
	}

	var validatecode = document.getElementById("txtCode");
	if(validatecode.value == ""){
		alert("validate code can not empty!");
		return false;
	}

	return true;
}