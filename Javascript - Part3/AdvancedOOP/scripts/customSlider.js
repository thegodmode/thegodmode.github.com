(function() {
	'use strict';
	if (!Object.create) {
		Object.create = function(obj) {
			function Fun() {}
			Fun.prototype = obj;
			return new Fun();
		};
	}

	if (!Object.prototype.extend) {
		Object.prototype.extend = function(properties) {
			function Fun() {};
			Fun.prototype = Object.create(this);
			for (var prop in properties) {
				Fun.prototype[prop] = properties[prop];
			}
			Fun.prototype._super = this;
			return new Fun();
		}
	}
}());

var imageSlider = (function() {
	'use strict';

	var Slider = {
		init: function(selector) {
			this.container = document.querySelector(selector);
			self.container = this.container;
			this.images = [];
			self.images = this.images;
		},
		addImage: function(title, thumbnailUrl, largeUrl) {
			var image = Object.create(Image);
			image.init(title, thumbnailUrl, largeUrl)
			this.images.push(image);
			return this;
		},
		serialize: function() {
			while (this.container.firstChild) {
				this.container.removeChild(this.container.firstChild);
			};

			var list = document.createElement('ul');
			this.addEventHandler(list, 'click', this.showImageInFullSize);
			var fragment = document.createDocumentFragment();
			fragment.appendChild(list);

			for (var i = 0; i < this.images.length; i++) {
				var li = document.createElement('li');
				list.appendChild(li);
				li.appendChild(this.images[i].serialize());

			};

			var leftArrow = document.createElement('div');
			leftArrow.id = 'leftArrow';
			this.addEventHandler(leftArrow, 'click', this.leftArrowEvent);
			fragment.appendChild(leftArrow);

			var rightArrow = document.createElement('div');
			rightArrow.id = 'rightArrow';
			fragment.appendChild(rightArrow);
			this.addEventHandler(rightArrow, 'click', this.rightArrowEvent);
			this.container.appendChild(fragment);

			this.addActiveClass();
		},
		addActiveClass: function() {
			var container = this.container;
			var img = container.querySelector('ul li img');
			img.className = 'active';
		},
		addEventHandler: function(element, event, eventHandler) {
			if (element.addEventListener) {
				element.addEventListener(event, eventHandler, false);
			} else if (element.attachEvent) {
				element.attachEvent("on" + event, eventHandler);
			} else {
				element[event] = eventHandler;
			}
		},
		rightArrowEvent: function() {
			var img = self.container.querySelector('.active');
			img.className = 'unactive';
			var nextImage;
			if (img.parentNode.nextSibling) {
				nextImage = img.parentNode.nextSibling.firstChild;
				nextImage.className = 'active';
			} else {

				nextImage = self.container.querySelector('ul li img');
				nextImage.className = 'active';
			}
		},
		leftArrowEvent: function() {
			var img = self.container.querySelector('.active');
			img.className = 'unactive';
			var nextImage;
			if (img.parentNode.previousSibling) {
				nextImage = img.parentNode.previousSibling.firstChild;
				nextImage.className = 'active';
			} else {
				nextImage = self.container.querySelector('ul').lastChild.firstChild;
				nextImage.className = 'active';
			}
		},
		showImageInFullSize: function(event) {
			var container = document.querySelector('#bigImageContainer');

			if (container) {

				document.body.removeChild(container);
			}

			var target = event.target;
			for (var i = 0; i < self.images.length; i++) {
				if (self.images[i].title == target.title) {
					var div = document.createElement('div');
					div.id = 'bigImageContainer';
					var bigImage = document.createElement('img');
					bigImage.title = self.images[i].title;
					bigImage.src = self.images[i].largeUrl;
					div.appendChild(bigImage);
					document.body.appendChild(div);
					break;
				}
			}
		}
	}

	var Image = {
		init: function(title, thumbnailUrl, largeUrl) {
			this.title = title;
			this.thumbnailUrl = thumbnailUrl;
			this.largeUrl = largeUrl;
		},
		serialize: function() {
			var image = document.createElement('img');
			image.title = this.title;
			image.src = this.thumbnailUrl;
			return image;
		}

	}

	return {
		getImageSlider: function(selector) {
			var imgSlider = Object.create(Slider);
			imgSlider.init(selector);
			return imgSlider;
		}
	}
}());

var slider = imageSlider.getImageSlider("#slider");

slider.addImage("First", "images/tubnail.jpg", "images/large.jpg");
slider.addImage("Second", "images/smallEarth.jpg", "images/largeEarth.jpg");
slider.serialize();
slider.serialize();