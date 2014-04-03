


appRoot.factory('apiFactory', function ($http) {
    var url = 'api/blogs/';

    return {
        get: function () {
            return $http.get(url);
        },
        add: function (entity) {
            return $http.post(url, entity);
        },
        delete: function (entity) {
            return $http.delete(url + entity.id);
        },
        update: function (entity) {
            return $http.put(url + entity.id, entity);
        }
    };
});


appRoot.factory('notificationFactory', function () {
    return {
        success: function () {
            toastr.success("Success");
        },
        error: function (text) {
            toastr.error(text, "Error ! ");
        }
    };
});


appRoot.controller('BlogController', function ($scope, apiFactory, notificationFactory) {
    $scope.blogs = [];
    $scope.addMode = false;
    var blogFactory = apiFactory;

    $scope.toggleAddMode = function () {
        $scope.addMode = !$scope.addMode;
    };

    $scope.toggleEditMode = function (blog) {
        blog.editMode = !blog.editMode;
    };

    var getBlogsSuccessCallback = function (data, status) {
        $scope.blogs = data;
    };

    var successCallback = function (data, status, headers, config) {
        notificationFactory.success();

        return blogFactory.get().success(getBlogsSuccessCallback).error(errorCallback);
    };

    var successPostCallback = function (data, status, headers, config) {
        successCallback(data, status, headers, config).success(function () {
            $scope.toggleAddMode();
            $scope.blog = {};
        });
    };

    var errorCallback = function (data, status, headers, config) {
        notificationFactory.error(data.ExceptionMessage);
    };





    blogFactory.get().success(getBlogsSuccessCallback).error(errorCallback);

    $scope.addBlog = function () {
        blogFactory.add($scope.blog).success(successPostCallback).error(errorCallback);
    };

    $scope.deleteBlog = function (blog) {
        blogFactory.delete(blog).success(successCallback).error(errorCallback);
    };

    $scope.updateBlog = function (blog) {
        blogFactory.update(blog).success(successCallback).error(errorCallback);
    };
});
