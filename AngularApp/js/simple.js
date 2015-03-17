$(function () {
	
	$.cookie("visits", "10");

	console.debug($.cookie("visits"))
	$.removeCookie("visits");
})