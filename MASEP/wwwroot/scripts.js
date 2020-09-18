window.ShowAlert = (message) => {
    alert(message);
}

window.Validate = (dob) => {

	var today = new Date();
	document.getElementById("datepicker").innerHTML = today;

	var maxDate = $('#datepicker').datepicker('option', 'maxDate');
	$('#datepicker').datepicker('option', 'maxDate', '+0m +0w');
}