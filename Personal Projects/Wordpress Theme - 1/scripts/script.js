function section() {

	if ($('#tabs-holder').height() > $('#section').height() && ($(document).width()>966)) {

		$('#section').css('height', $('#tabs-holder').height() + 38);
	}
}

function miniImageContainer() {

	if ($('#mini-image-contaner').height() > $('#post-shadow').height()) {

		$('#mini-image-contaner').css('height', $('#post-shadow').height());
		$('#mini-image-contaner').css('overflow', 'auto');
	}

}

function fancyBox() {
	$("a.grouped_elements").fancybox({
		'transitionIn' : 'elastic',
		'transitionOut' : 'elastic',
		'speedIn' : 600,
		'speedOut' : 200,
		'overlayShow' : true,
		'scrolling' : 'yes',

	});

}

function expandElement() {

	$('div.expandable').expander({
		slicePoint : 260, // default is 100
		expandPrefix : ' ', // default is '... '
		expandText : 'Continue Reading', // default is 'read more'
		collapseTimer : 0, // re-collapses after 5 seconds; default is 0, so no re-collapsing
		userCollapseText : 'End Reading', // default is 'read less'
		moreClass : 'reading-button',
		lessClass : 'ending-button',
		collapseSpeed : 200,
		expandSpeed : 250,
		afterExpand : function() {

			$('#mini-image-contaner').css('height', $('#post-shadow').height());

		},

		onCollapse : function() {

			setTimeout("$('#mini-image-contaner').css('height', $('#post-shadow').height())", 300)

		}
	});

}

function easyTab() {

	$('.tab-container ').easytabs({

		tabActiveClass : "active-tab",
		tabs : '.tabs > ul > li'

	});

	$('.tab-container').bind('easytabs:after', function() {

		if ($('#tabs-holder').height() >= $('#section').height() - 2) {

			$('#section').css('height', $('#tabs-holder').height() + 18);
		}
	});
}



function imageSlider() {

	$('.blueberry').blueberry();
}


$(document).ready(function() {

  var counter=0;
  
	imageSlider();
	expandElement();
	miniImageContainer();
	fancyBox();
	easyTab();
	section();

	$(window).resize(function() {
		if($(document).width() > 966 && !counter) {
            
           
			$('#section').css('height', $('#tabs-holder').height()+38 );
			counter=1;
		}
		
		if($(document).width() < 966 ) {
			
			$('#section').css('height','auto');
		}
		
		if ($('#mini-image-contaner').height() > $('#post-shadow').height() && ($(document).width()>966)) {

		$('#mini-image-contaner').css('height', $('#post-shadow').height());
		$('#mini-image-contaner').css('overflow', 'auto');
	}

	});
});
