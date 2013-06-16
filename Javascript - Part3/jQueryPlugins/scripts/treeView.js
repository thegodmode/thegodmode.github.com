(function($) {
	'use strict';
	var Tree = {

		init: function(selector) {
			this.$container = $(selector);
			this.$children = [];
			return this;
		},
		addNode: function(value, href) {
			var node = Object.create(Item);
			node.init(value, href);
			this.$children.push(node);
			return node;
		},
		serialize: function() {
			this.$container.empty();

			var $list = $('<ul></ul>');
			$list.on('click', 'li', function(event) {
                event.stopPropagation();
               	$(this).children('ul').slideToggle();
			});

			for (var i = 0; i < this.$children.length; i++) {
				$list.append(this.$children[i].serialize());
			};

			this.$container.append($list);
			return this;
		}

	}

	var Item = {

		init: function(value, href) {
			this.value = value;
			this.href = href;
			this.$children = [];
			return this;
		},
		addNode: function(value, href) {
			var node = Object.create(Item);
			node.init(value, href);
			this.$children.push(node);
			return node;
		},
		serialize: function() {
			var $li = $('<li></li>');

			var $href = $('<a></a>');
			$href.attr('href', this.href);
			$href.append(this.value);

			$li.append($href);

			if (this.$children.length > 0) {
				var $list = $('<ul></ul>');
				$list.css('display', 'none');
				for (var i = 0; i < this.$children.length; i++) {
					$list.append(this.$children[i].serialize());
				};
				$li.append($list);
			}

			return $li;
		}
	}


	$.fn.treeView = function() {

		var treeView = Object.create(Tree);
		treeView.init(this);
		return treeView;
	}

}(jQuery));