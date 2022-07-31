var x = $("#SearchText").val();

$(function () {

	$("#DefaultSearchIsChecked").click(function () {
		if ($("#DefaultSearchIsChecked").prop("checked")) {
			$("#SearchText").val("land registry searches");
		}
		else {
			$("#SearchText").val("");
		}
	})
})