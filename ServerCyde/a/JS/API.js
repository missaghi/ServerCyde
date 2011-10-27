/// <reference path="jquery-1.6.1.js" />

var Comet = (function () {

            var SiteID = '[%siteid%]', 
            Breathe = function () {

                function success(data) {
                    $("#pulse").append(data);
                    C02level = 0;
                    TryingToReconnect = false;
                    Breathe(); 
                    eval(data.JSONP); 
                }

                var data = {currentroom : }

                $.ajax({
                    url: "/comet",
                    dataType: 'json',
                    data: data,
                    timeout: 40000,
                    error: function (jqXHR, textstatus, errorThrown) { C02level = 30; },
                    success: success
                });
            },

            MonitorC02 = function () {
                setTimeout(MonitorC02, 1000);
                C02level = C02level + 1;
                if (C02level == 40)
                    $.jGrowl("Server not responding", { sticky: true, handle: "notify", header: "Server not responding." });
                else if (C02level > 30) {
                    if ((30 - (C02level % 30)) > 10) {
                        $("#notify .message").html("Retrying in " + (30 - (C02level % 30)) + " seconds <br /> <a href='' onclick='Breathe(); Comet.C02level = 30; return false;'>retry now</a>");
                    }
                    else if (C02level % 30 == 10) {
                        $("#notify .message").text("Trying to reconnect.");
                        TryingToReconnect = true;
                        Breathe();
                    }
                }
                else {
                    $("#notify .message").text("Connection re-established!");
                    setTimeout('("#notify").trigger("jGrowl.close");', 2000);
                }
            };

            return { Breathe: Breathe, MonitorC02: MonitorC02 };

        })();

        $().ready(function () {

            Comet.Breathe();
            Comet.MonitorC02(); 
        });