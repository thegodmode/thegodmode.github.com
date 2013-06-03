var Class = (function() {
	function createClass(properties) {
		var f = function() {
			this.init.apply(this, arguments);
		}
		for (var prop in properties) {
			f.prototype[prop] = properties[prop];
		}
		if (!f.prototype.init) {
			f.prototype.init = function() {}
		}
		return f;
	}

	Function.prototype.inherit = function(parent) {
		var oldPrototype = this.prototype;
		var prototype = new parent();
		this.prototype = Object.create(prototype);
		this.prototype._super = prototype;
		for (var prop in oldPrototype) {
			this.prototype[prop] = oldPrototype[prop];
		}
	}

	return {
		create: createClass,
	};
}());

var favoriteSideBar = (function() {
	'use strict';

	var SideBar = Class.create({
		init: function() {
			this.setOfFolders = [];
			this.setOfURLs = [];
		},
		addUrl: function(title, url) {
			var url = new URL(title, url);
			this.setOfURLs.push(url);
			return this;
		},
		addFolder: function(title) {
			var folder = new Folrder(title);
			this.setOfFolders.push(folder);
			return folder;
		},
		serialize: function() {
			var container = document.querySelector('#favoriteSideBar');
			if (container) {
				while (container.firstChild) {
					container.removeChild(container.firstChild);
				}
				container.parentNode.removeChild(container);
			}


			var sideBarContainer = document.createElement('div');
			sideBarContainer.id = 'favoriteSideBar';
			var sideUrlsContainer = document.createElement('div');
			sideUrlsContainer.id = 'favoriteUrls';

			var fragmentUrls = document.createDocumentFragment();
			for (var i = 0; i < this.setOfURLs.length; i++) {
				fragmentUrls.appendChild(this.setOfURLs[i]._serialize());
			}

			var fragmentFolders = document.createDocumentFragment();
			for (var i = 0; i < this.setOfFolders.length; i++) {
				fragmentFolders.appendChild(this.setOfFolders[i]._serialize());
			}

			sideUrlsContainer.appendChild(fragmentUrls);
			sideBarContainer.appendChild(sideUrlsContainer);
			sideBarContainer.appendChild(fragmentFolders);
			document.body.appendChild(sideBarContainer);
		}

	});

	var Folrder = Class.create({
		init: function(title) {
			this.setOfURLs = [];
			this.title = title;
		},
		addUrl: function(title, url) {
			var url = new URL(title, url);
			this.setOfURLs.push(url);
			return this;
		},
		_serialize: function() {

			var folderContainer = document.createElement('div');
			folderContainer.className = 'folder';
			var folderName = document.createElement('h2');
			folderName.innerHTML = this.title;
			var fragment = document.createDocumentFragment();
			for (var i = 0; i < this.setOfURLs.length; i++) {
				fragment.appendChild(this.setOfURLs[i]._serialize());
			}
			folderContainer.appendChild(folderName);
			folderContainer.appendChild(fragment);
			return folderContainer;
		}

	});

	var URL = Class.create({
		init: function(title, url) {
			this.title = title;
			this.url = url;
		},
		_serialize: function() {
			var link = document.createElement('a');
			var content = document.createElement('div')
			content.innerHTML = this.title;
			link.href = this.url;
			link.title = this.title;
			link.target = "_blank";
			link.appendChild(content)
			return link;
		}
	});

	return {

		getSideBar: function() {
			return new SideBar();
		}
	}
}());

var sideBar = favoriteSideBar.getSideBar();
sideBar.addUrl("Telerik Acedemy", "http://telerikacademy.com/");
sideBar.addUrl("Google", "http://google.com/");

var folder = sideBar.addFolder('newFolder');
folder.addUrl("YouTube", "http://www.youtube.com/");
folder.addUrl("Facebook", "https://www.facebook.com/");

var folder1 = sideBar.addFolder('newFolder1');
folder1.addUrl("YouTube", "http://www.youtube.com/");
folder1.addUrl("Facebook", "https://www.facebook.com/");

sideBar.serialize();

sideBar.addUrl("Zamunda", "http://zamunda.net/");
sideBar.serialize();

