/// <reference path="../libs/jquery-2.0.3.js" />
/// <reference path="../libs/q.js" />
/// <reference path="../libs/mustache.js" />
/// <reference path="DataPersister.js" />

define(["jquery", "class", "dataPersister", "ui", "mustache", "underscore"],
       function ($, Class, dataPersister, ui, Mustache, underscore) {
           var controller = (function () {
               var Controller = Class.create({

                   init: function (selector, baseUrl) {
                       this.parentContainer = $(selector);
                       this.persister = dataPersister.get(baseUrl);
                       this.templateContainer = {}
                       this.intervalId = ""
                   },
                   loadUI: function () {
                       var self = this;
                       if (this.persister.isUserLoggin()) {
                           document.location.href = "#/game"
                       }
                       else {
                           this.loadLoginUI();
                       }
                   },
                   registerEvents: function () {
                       var self = this;
                       this.parentContainer.on("click", "#login-button", function () {
                           var user = {

                               username: $("#login-username-input").val(),
                               password: $("#login-password-input").val()
                           }
                           self.persister.loginPersister.login(user)
                           .then(function (result) {
                               self.saveDataLocalStorage(result);
                               document.location.href = "#/game"
                           });
                           return false;
                       });
                       this.parentContainer.on("click", "#register-button", function () {
                           var user = {

                               username: $("#register-username-input").val(),
                               password: $("#register-password-input").val(),
                               nickname: $("#register-nickname-input").val()
                           }
                           self.persister.loginPersister.register(user)
                           .then(function (result) {
                               self.saveDataLocalStorage(result);
                               document.location.href = "#/game"
                           });
                           return false;
                       });
                       this.parentContainer.on("click", "#to-register", function () {
                           document.location.href = "#/register"
                       });
                       this.parentContainer.on("click", "#to-login", function () {
                           document.location.href = "#/home"
                       });
                       this.parentContainer.on("click", "#logout", function () {
                           var sessionKey = localStorage.getItem("sessionKey");
                           self.persister.loginPersister.logout(sessionKey)
                           .then(function () {
                               localStorage.clear();
                               clearInterval(self.intervalId);
                               document.location.href = "#/home"
                           });
                       });
                       this.parentContainer.on("click", "#create-game-button", function () {
                           var game = {
                               title: $("#create-game").val(),
                           }
                           var sessionKey = localStorage.getItem("sessionKey");
                           self.persister.gamePersister.create(game, sessionKey)
                           .then(function () {
                               alert("Game Created");
                               self.loadMyGames();
                           });

                           return false;
                       });
                       this.parentContainer.on("click", "#open a", function () {
                           var game = {
                               id: $(this).children()[0].id
                           }
                           var sessionKey = localStorage.getItem("sessionKey");
                           self.persister.gamePersister.join(game, sessionKey)
                           .then(function () {
                               alert("Join Successfull");
                               self.loadMyGames();
                           });

                           return false;
                       });
                       this.parentContainer.on("click", "#my-active a", function () {
                           var id = $(this).children()[0].id
                           var sessionKey = localStorage.getItem("sessionKey");
                           self.persister.gamePersister.start(id, sessionKey)
                           .then(function () {
                               alert("Game Started!");
                               self.loadMyGames();
                           });

                           return false;
                       });
                       this.parentContainer.on("click", "#inprogress a", function () {
                           var id = $(this).children()[0].id
                           var sessionKey = localStorage.getItem("sessionKey");
                           self.persister.gamePersister.start(id, sessionKey)
                           .then(function (gameField) {
                                  
                           });

                           return false;
                       });
                   },
                   loadRegisterUI: function () {
                       var self = this;
                       ui.getRegisterUI().then(function (dataHtml) {
                           self.parentContainer.html(dataHtml);
                       });
                   },            
                   loadLoginUI: function () {
                       var self = this;
                       ui.getLoginUI().then(function (htmlData) {
                           self.parentContainer.html(htmlData);
                       });
                   },
                   loadGameUI: function () {
                       var self = this;

                       if (!localStorage.getItem("nickname")) {
                           self.parentContainer.html("<div><p>We need to Login First</p</div>");
                           return;
                       }
              
                       ui.getGameUI().then(function (dataHtml) {
                           self.parentContainer.html(dataHtml);
                           var nickname = localStorage.getItem("nickname");
                           $("#nickname").html("Hello " + nickname);
                           self.loadMyGames();
                           self.loadOpenGames();
                           self.loadScores();
                           self.RefreshUI();
                       });
                   },
                   loadMyGames: function () {
                       var self = this;
                       var sessionKey = localStorage.getItem("sessionKey");
                       this.persister.gamePersister.active(sessionKey)
                       .then(function (result) {
                           if (!self.templateContainer.myActive) {
                               ui.getMyActiveGamesTemplate().then(function (activeTemplate) {
                                   ui.getOpenGamesTemplate().then(function (openTemplate) {
                                       self.templateContainer.myActive = activeTemplate;
                                       self.templateContainer.open = openTemplate;
                                       var filtered = underscore.groupBy(result, function (result) {
                                           return result.status;
                                       });
                                       var resultInHtml = Mustache.render(self.templateContainer.open, filtered.full);
                                       $("#ready").html(resultInHtml);
                                       var resultInHtml = Mustache.render(self.templateContainer.open, filtered["in-progress"]);
                                       $("#inprogress").html(resultInHtml);
                                       var resultInHtml = Mustache.render(self.templateContainer.myActive, filtered.open);
                                       $("#active").html(resultInHtml)
                                   })
                               });
                               
                           }
                           else {
                               var filtered = underscore.groupBy(result, function (result) {
                                   return result.status;
                               });
                               var resultInHtml = Mustache.render(self.templateContainer.open, filtered.full);
                               $("#ready").html(resultInHtml);
                               var resultInHtml = Mustache.render(self.templateContainer.open, filtered.in - progress);
                               $("#inprogress").html(resultInHtml);
                               var resultInHtml = Mustache.render(self.templateContainer.myActive, filtered.open);
                               $("#active").html(resultInHtml)
                           }
                       });
                   },
                   loadOpenGames: function () {
                       var self = this;
                       var sessionKey = localStorage.getItem("sessionKey");
                       this.persister.gamePersister.open(sessionKey)
                       .then(function (result) {
                           if (!self.templateContainer.open) {
                               ui.getOpenGamesTemplate().then(function (template) {
                                   self.templateContainer.open = template;
                                   var resultInHtml = Mustache.render(self.templateContainer.open, result);
                                   $("#open").html(resultInHtml)
                               });
                           }
                           else {
                               var resultInHtml = Mustache.render(self.templateContainer.open, result);
                               $("#open").html(resultInHtml)
                           }
                       });
                   },
                   loadScores: function () {
                       var self = this;
                       var sessionKey = localStorage.getItem("sessionKey");
                       this.persister.loginPersister.score(sessionKey)
                       .then(function (result) {
                           if (!self.templateContainer.score) {
                               ui.getScoreTemplate().then(function (template) {
                                   self.templateContainer.score = template;
                                   var resultInHtml = Mustache.render(self.templateContainer.score, result);
                                   $("#scores").html(resultInHtml)
                               })
                           }
                           else {
                               var resultInHtml = Mustache.render(self.templateContainer.score, result);
                               $("#scores").html(resultInHtml)
                           }
                       });
                   },
                   RefreshUI: function () {
                       var self = this;
                       self.intervalId = setInterval(function () {
                           self.loadOpenGames();
                           self.loadScores();
                       }, 50000);
                   },
                   saveDataLocalStorage: function(result) {
                       localStorage.setItem("nickname", result.nickname);
                       localStorage.setItem("sessionKey", result.sessionKey);
                   }
           
               });
               return {

                   get: function (selector, baseUrl) {
                       return new Controller(selector, baseUrl);
                   }
               }
           }());

           return controller;
       });