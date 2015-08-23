define([],
    function () {

        var self = {
            extendSessionUrl: '/api/session',
            logoutUrl: '/cas/logout',
            sessionTimoutSeconds: 1170,
            sessionTimeoutWarningSeconds: 91,
            validateFixedAssetUrl: '/api/validatefixedasset/',
            validFixedAssetBarcodeLength: 9,
        }

        return self;
    });