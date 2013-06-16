var InsertController = (function($) {
	'use strict';

	function insertBeforeElement(element, content) {

		content.insertBefore(element);

	}


	function insertAfterElement(element, content) {

		content.insertAfter(element);


	}


	return {

		inserBeforeElement: function(element, content) {

			insertBeforeElement(element, content)
		},
		insertAfterElement: function(element, content) {
			insertAfterElement(element, content)

		}
	}


}(jQuery));

$(document).ready(function() {


	var element = $(document.createElement('div'));
	element.attr('id','before');
	InsertController.inserBeforeElement($("ul"),element);


	var element1 = $(document.createElement('div'));
	element1.attr('id','after');
	InsertController.insertAfterElement($("ul"),element1);
});