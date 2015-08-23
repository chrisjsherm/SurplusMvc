define(['chrisjsherm.counter', 'app/config'],
    function (counter, config) {

        return {
            initCountdown: init
        };

        function init() {
            var countdown = new counter({
                seconds: config.sessionTimoutSeconds,

                onUpdateStatus: function (second) {
                    // change the UI that displays the seconds remaining in the timeout.
                    if (parseInt(second, 10) < config.sessionTimeoutWarningSeconds) {
                        $('#timeoutModal').foundation('reveal', 'open');
                        $('.counter').text(second);
                    }
                },

                onCounterEnd: function () {
                    window.location.assign(config.logoutUrl);
                },
            });

            // Start counter.
            countdown.start();

            /* Restart the counter after successful Ajax requests.
             * Close the modal if it's open.
             */
            $(document).ajaxSuccess(function () {
                countdown.restart();
                $('#timeoutModal').foundation('reveal', 'close');
            });

            // Hit the session action if the user closes the modal.
            $('.close-reveal-modal').on('click', function () {
                $.get(config.extendSessionUrl);
            });

            // Hook 'Continue button' to the default close anchor.
            $('span.button-close-reveal-modal').on('click', function () {
                $('a.close-reveal-modal').trigger('click');
            });
        }
    });