var categoryApp;
!function () {
    "use strict"; categoryApp = angular.module("category_App", ["ui.router"])
}(),
    categoryApp.config(["$locationProvider", "$stateProvider", "$urlRouterProvider", "$urlMatcherFactoryProvider", "$compileProvider",
        function (e, t, o, r, l) {
            window.history && window.history.pushState && e.html5Mode({ enabled: !0, requireBase: !0 })
                .hashPrefix("!"),
                r.strictMode(!1),
                l.debugInfoEnabled(!1),
                t.state("home", {
                    url: "/",
                    templateUrl: "./views/home/home.html",
                    controller: "HomeController"
                })
                    .state("category", {
                        url: "/category",
                        templateUrl: "./views/category/category.html",
                        controller: "CategoryController"
                    })
                    .state("device", {
                        url: "/device",
                        templateUrl: "./views/device/device.html",
                        controller: "DeviceController"
                    })
                    .state("about", {
                        url: "/about",
                        templateUrl: "./views/about/about.html", controller: "AboutController"
                    }),
                o.otherwise("/home")
        }]),
    categoryApp.controller("AboutController", ["$scope", "$http", function (e, t) {
        e.title = "About Page"
    }]),
    categoryApp.controller("HomeController", ["$scope", function (e) {
        e.message = "This Page has MVC Core on the Server Side and AngularJS on the Client Side!"
    }]),
    categoryApp.controller("CategoryController", ["$scope", "$http", function (t, o) {
        function r() {
            o({
                method: "GET",
                url: "/api/Categories/"
            }).
                then(function (e) {
                    t.ListCategory = e.data
                }, function (e) {
                    console.log(e)
                })
        }
        function p() {
            o({
                method: "GET",
                url: "/api/Devices/"
            }).then(function (e) {
                t.ListDevice = e.data
            }, function (e) {
                console.log(e)
            })
        }

        t.title = "All Categories",
            t.ListCategory = null,
            t.ListDevice = null;
        t.categoryModel = {},
            t.categoryModel.categoryID = 0,
            r(),
            p(),
            t.getCategory = function (e) {
                o({ method: "GET", url: "/api/Categories/" + parseInt(e.categoryID) }).
                    then(function (e) {
                        t.categoryModel = e.data
                    }, function (e) {
                        console.log(e)
                    })
            },
            t.saveCategory = function () {
                o({
                    method: "POST",
                    url: "/api/Categories/",
                    data: t.categoryModel
                }).then(function (e) {
                    t.reset(), r()
                }, function (e) {
                    console.log(e)
                })
            },
            t.updateCategory = function () {
                o({
                    method: "PUT",
                    url: "/api/Categories/" + parseInt(t.categoryModel.categoryID),
                    data: t.categoryModel
                }).
                    then(function (e) {
                        t.reset(), r()
                    }, function (e) {
                        console.log(e)
                    })
            }, t.deleteCategory = function (e) {
                confirm("You are about to delete " + e.categoryName + ". Are you sure?") && o({
                    method: "DELETE",
                    url: "/api/Categories/" + parseInt(e.categoryID)
                }).then(function (e) {
                    t.reset(), r()
                }, function (e) {
                    console.log(e)
                })
            }, t.reset = function () {
                t.categoryModel = {}, t.categoryModel.categoryID = 0
            }
    }]),
    //, categoryApp.directive("navbarMenu", function () {
    //    return { restrict: "E", templateUrl: "views/shared/navbar/nav.html" }
    //}),
    categoryApp.directive("sidebarMenu", function () {
        return {
            restrict: "E",
            templateUrl: "views/shared/sidebar/menu.html"
        }
    }),
    categoryApp.component('categoryList', {
        templateUrl: './views/category/category-list.component.html',
        controller: 'CategoryController'
    }),



// Device

categoryApp.controller('DeviceController', ['$scope','$http', 'DeviceFactory', function (t, o, Devicefactory) {
    Init();
    //$scope.deviceModel = {};
    function Init() {

        Devicefactory.getDevices().then(function (response) {
            t.DeviceList = response.data;
        })
    }
    function r() {
        o({
            method: "GET",
            url: "/api/Categories/"
        }).
            then(function (e) {
                t.CategoryList = e.data
            }, function (e) {
                console.log(e)
            })
    }
        t.title = "All Categories",
            t.CategoryList = null,
        t.deviceModel = {},
        t.deviceModel.deviceID = 0,
        r(),
        t.getDevice = function (e) {
            o({ method: "GET", url: "/api/Devices/" + parseInt(e.deviceID) }).
                then(function (e) {
                    t.deviceModel = e.data
                }, function (e) {
                    console.log(e)
                })
        },
        t.saveDevice = function () {
            o({
                method: "POST",
                url: "/api/Devices/",
                data: t.deviceModel
            }).then(function (e) {
                t.reset(), r()
            }, function (e) {
                console.log(e)
            })
        },
        t.updateDevice = function () {
            o({
                method: "PUT",
                url: "/api/Devices/" + parseInt(t.deviceModel.deviceID),
                data: t.deviceModel
            }).
                then(function (e) {
                    t.reset(), r()
                }, function (e) {
                    console.log(e)
                })
        }, t.deleteDevice = function (e) {
            confirm("You are about to delete " + e.deviceName + ". Are you sure?") && o({
                method: "DELETE",
                url: "/api/Devices/" + parseInt(e.deviceID)
            }).then(function (e) {
                t.reset(), r()
            }, function (e) {
                console.log(e)
            })
        }, t.reset = function () {
            t.deviceModel = {}, t.deviceModel.deviceID = 0
        }
}])

// base Url
var baseUrl = "https://localhost:44368/api/Devices/";

categoryApp.factory('DeviceFactory', function ($http) {
    var device = {};
    device.getDevices = function () {
        return $http.get(baseUrl)
    }
    return device;
})