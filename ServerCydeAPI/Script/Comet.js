/*
* ServerCyde
*
* Copyright (c) 2011 ServerCyde
*
* Date: 2010-11-15 17:58:16 +0300 (Mon, 15 Nov 2010)
*/
/// <reference path="jquery-1.6.1.js" />



ServerCyde.Comet = (function () {
        //todo unsubscribe, trial (subscribe till response)
        var lastcalltime = new Date(),
            waittillreconnect = 0;
           Subscribe = function(id, callback) {
            
            function ReSubscribe(data) {
                
                waittillreconnect = 1
                
                if (callback)
                {    callback(data.Message);}
                else
                {
                    alert(data.Message);
                }
                Subscribe(id, callback);
            }

            function ReConnect(data)
            {
                var now = new Date();
                if ((now.getMilliseconds() - lastcalltime.getMilliseconds()) > 20) {
                    Subscribe(id, callback);
                    lastcalltime = now;
                }
                else {
                    setTimeout(function() {ReConnect(data);}, waittillreconnect);
                    waittillreconnect = waittillreconnect * 10;
                }

            }

            // will add eventsource when browsers allow CORS
            if (window.opera) {
                API.CDPost("/Comet/APICometSubscribe/?ChannelID="+ id, {}, ReSubscribe, ReConnect, true);
            }
            else{  
                API.Get("/Comet/APICometSubscribe/", {ChannelID : id}, ReSubscribe, ReConnect);
            } 

        },
        Publish = function(id, message, callback, errorcallback) {  
            API.Post("/Comet/APICometPost/", {ChannelID : id, message : message}, callback, errorcallback);
        },
        UserCount = function(id, callback, errorcallback) {  
            API.Post("/Comet/Count/", {ChannelID : id}, callback, errorcallback);
        }; 

        return { Subscribe : Subscribe, Publish : Publish, UserCount : UserCount };

    })(); 