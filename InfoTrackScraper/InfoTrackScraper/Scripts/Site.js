$(function () {
	$("#DefaultSearchIsChecked").click(function () {
		if ($("#DefaultSearchIsChecked").prop("checked")) {
			$("#SearchText").val("land registry search");
		}
		else {
			$("#SearchText").val("");
		}
	})

	$("#SearchButton").click(function(e) {
		if($("#SearchText").val() == "") {
			e.preventDefault();
			alert("Search field is empty.")
		}
	})
})