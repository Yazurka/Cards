// script.js

// create the module and name it scotchApp
// also include ngRoute for all our routing needs
var scotchApp = angular.module('scotchApp', ['ngRoute']);

// configure our routes
scotchApp.config(function ($routeProvider) {
    $routeProvider

        // route for the username page
        .when('/', {
            templateUrl: 'pages/usernamePage.html',
            controller: 'usernameController'
        })

        // route for the startpage
        .when('/startpage', {
            templateUrl: 'pages/startpage.html',
            controller: 'startpageController'
        })

        // route for the game lobby page
        .when('/gameLobby/:id', { 
            templateUrl: 'pages/gameLobbyPage.html',
            controller: 'gameLobbyController'
        })

            // route for the game page
        .when('/game/:id', {
            templateUrl: 'pages/boardPage.html',
            controller: 'boardController'
        });

});

scotchApp.controller('mainController', function ($scope) {
    $scope.$on('usernameEvent', function (event, data) {
        $scope.username = data;
    });
    $scope.$on('gameIdEvent', function (event, data) {
        $scope.gameID = data;
    });
});

//create the controller and inject Angular's $scope
scotchApp.controller('usernameController', function ($scope, $routeParams, $location) {
    // create a message to display in our view
    $scope.username = "";
    $scope.submitUsername = function () {
        $scope.$emit('usernameEvent', $scope.username);
        $location.url('/startpage')
    };
});

scotchApp.controller('startpageController', function ($scope, $routeParams, $location) {
    $scope.createGame = function () {
        $location.url('/gameLobby/' + 'sexualTension')
    };
    $scope.joinGame = function () {
        $scope.$emit('gameIdEvent', $scope.gameID);
        $location.url('/gameLobby/' + $scope.gameID)
    };
});

scotchApp.controller('gameLobbyController', function ($scope, $http, $routeParams, $location) {
    $scope.gameID = $routeParams.id;
    $scope.startGame = function () {
        $location.url('/game/' + $scope.gameID)
    };
});

scotchApp.controller('boardController', function ($scope) {
  
});

