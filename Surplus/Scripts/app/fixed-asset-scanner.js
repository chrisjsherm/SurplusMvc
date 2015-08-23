define(['app/config'],
    function (config) {

        return {
            init: initScanner,
        };

        function initScanner() {
            $('input[name=VTBarcode').blur(function () {
                var self = this;

                var barcode = $(self).val();

                if (barcode === 'N/A') {
                    return true;
                }

                return scanBarcode(barcode);
            });
        }

        function scanBarcode (barcode) {
            $.getJSON(config.validateFixedAssetUrl + barcode)
                .done(function (result) {
                    // Need to implement.
                    console.log('Success.', result);
                })
                .fail(function (result) {
                    // Need to implement.
                    console.log('Fail.', result);

                    $("#VTBarcode").addClass("input-validation-error");
                    $("span[data-valmsg-for='VTBarcode']").append("<span>" +
                        "Title Error" + "</span>");
                });
        }
    });