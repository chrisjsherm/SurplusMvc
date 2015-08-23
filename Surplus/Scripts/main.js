require(['app/countdown', 'jquery.phoenix', 'app/fixed-asset-scanner'],
    function (counter, phoenix, scanner) {

        // Initialize Foundation.
        $(document).foundation();

        // Initialize timeout counter.
        counter.initCountdown();

        // Save/retrieve select form inputs to Local Storage.
        $('.phoenix-input').phoenix();

        // Initialize fixed asset scanner.
        scanner.init();
    });