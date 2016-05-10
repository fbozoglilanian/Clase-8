(function() {
    'use-strict';

    angular.module('Tresana')
        .controller('Users.Controller', function($scope) {
            var ctrl = this;

            $scope.users = [
                { name: "Alejandro", lastName: "Tocar" },
                { name: "Gabriel", lastName: "Piffaretti" }
            ];
        });
})();