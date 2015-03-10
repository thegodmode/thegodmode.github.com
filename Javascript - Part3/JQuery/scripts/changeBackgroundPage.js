$(document).ready(function() {

	$('#colorPicker').on('change', function() {
         
         var color = $(this).val();
         $('body').css('background-color',color);

	})

});