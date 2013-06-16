var gamePortalController = (function($) {
	'use strict';

	function createSlider(selector, interval, sliderWidth) {
		$.ajax({
			url: 'data-base/data.txt',
			type: 'GET',
			success: function(data, textStatus, xhr) {
				var parseData = JSON.parse(data);
				var slider = Slider.createSlider(selector, sliderWidth, interval);
				for (var i = 0; i < parseData.games.length; i++) {
					var name = parseData.games[i].name;
					var info = parseData.games[i].info;
					var srcPic = parseData.games[i].srcPic;
					var gameLink = parseData.games[i].gameLink;
					var category = parseData.games[i].category;
					slider._addSliderItem(name, info, srcPic, gameLink, category);
				}

				slider._serialize();
			},
			error: function(xhr, textStatus, errorThrown) {
				console.log(textStatus);
			}
		});

	}
	
	return {

		serialize: function(options) {

			createSlider(options.sliderSelector, options.sliderIterval, options.sliderWidth);
			
		}
	}

}(jQuery));

$(document).ready(function($) {

	gamePortalController.serialize({

		sliderSelector: "#slider-content",
		sliderIterval: 6000,
		sliderWidth: 950,
	});

});