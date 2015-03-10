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

			var $list = $('<ul></ul>');
			for (var i = 0; i < this.$children.length; i++) {
				$list.append(this.$children[i]._serialize());
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
			$li = $('<li></li>');
			$li.append(this.value);

			$href = $('<a></a>');
			$href.attr('href', this.href);

			$li.append($href);

			if (this.$children.length > 0) {
				$list = $('<ul></ul>');
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