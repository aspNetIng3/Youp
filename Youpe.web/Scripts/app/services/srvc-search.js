

appRoot.factory('SearchServices', ['$resource', function ($resource) {

           var MyResource = $resource('/api/:action/:query', {
               query: '@query'
           }, {
               search: {
                   method: 'GET',
                   params: {
                       action: "search",
                       query: '@query'
                   }
               }
           });
           return MyResource;
       }]);