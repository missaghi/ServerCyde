/*
* ServerCyde
*
* Copyright (c) 2011 ServerCyde
*
* Date: 2010-11-15 17:58:16 +0300 (Mon, 15 Nov 2010)
*/
/// <reference path="jquery-1.6.1.js" />


$.support.cors = true;
var ServerCyde = (function () {
    
    var ServerURL = "[%protocol%]://[%hostname%]/API";
    var APIURL = ServerURL + "/[%siteid%]"

    var API = (function () {

        var
        result = function(errors, valid, result) {
            this.val = {Errors : errors || new Array(),
                        Valid : valid || true };
            if (result)
                this.val.Result = result;
        },
        ToObject = function(data) {
            
            var newresultset = new Array();

            $.each(data, function (i, item) {
                var newresult = { Name: item.Name, Attributes : {}};
                $.each(item.Attributes, function (a, attribute) { 
                    newresult.Attributes[attribute.Name] = attribute.Value;
                });
                newresultset.push(newresult);
            });
            
            return newresultset;
        },
        ParsePath = function(path) { 
            if (path.indexOf("http") == 0) { return path; } else { return APIURL + path;}
        },
        get = function (post_target_url, params, callback, errorcallback) {
            
            if (/chrome/.test( navigator.userAgent.toLowerCase() ) )//)('withCredentials' in new XMLHttpRequest()) 
            {
                $.ajax({  
                    url: ParsePath(post_target_url),
                    data: params, 
                    dataType: 'json',
                    success:function (data) { HandleResponse(data, callback, errorcallback) },  
                    error:function (jqXHR, textStatus, errorThrown) { errorcallback( new result([(errorThrown || "Undefined Error: Possible origin URL mismatch.")], false) ); }
                    });
             }
            else
            {
                $.ajax({  
                    url: ParsePath(post_target_url),
                    data: params, 
                    dataType: 'jsonp',
                    success:function (data) { HandleResponse(data, callback, errorcallback) },  
                    error:function (jqXHR, textStatus, errorThrown) { errorcallback( new result([(errorThrown || "Undefined Error: Possible origin URL mismatch.")], false)); }
                    });
            }
        },
        post = function (post_target_url, params, callback, errorcallback) {

            if (undefined == errorcallback)
            {    errorcallback = DefaultErrorHandler;}
            // Post the cool way on new browsers otherwise use a hidden iframe to post, redirect to a local URL allowing access to the href and preventing FF from POSTDATA waring on reload. Haven't tested clicking sound on IE6/7 should probably use easyXDM
            if (false) // 'withCredentials' in new XMLHttpRequest()) 
            {
                // NOT SENDING COOKIES ARGH
                $.ajax({
                    type: 'POST',
                    url: ParsePath(post_target_url),
                    data: params,
                    dataType: 'json', 
                    beforeSend: function(xhr){
                        xhr.withCredentials = true;
                    },
                    success: function (data) { HandleResponse(data, callback, errorcallback) },
                    error: function (jqXHR, textStatus, errorThrown) { errorcallback( new result([(errorThrown || "Undefined Error: Possible origin URL mismatch.")], false)); }
                });
            }
            else {
                crossDomainPost(post_target_url, params, callback, errorcallback)
            }

        },
        crossDomainPost = function (post_target_url, params, callback, errorcallback, isLongPolling) {

            var uniqueString = "cyde" + new Date().getTime().toString() + Math.random()*9999,
            iframe = $("<iframe name='" + uniqueString + "' />").hide(),
            form = $("<form />"); // construct a form with hidden inputs, targeting the iframe

            form[0].target = uniqueString;
            if (post_target_url.indexOf("?") > 0)
            {    form[0].action = ParsePath(post_target_url) + "&ver=" + uniqueString;}
            else
            {    form[0].action = ParsePath(post_target_url) + "?ver=" + uniqueString;            }
            form[0].method = "POST";
            $(form).append("<input type='hidden' name='ServerCydeRequestType' value='failsafe' />");
            // repeat for each parameter
            

            function AddItemToForm(key,val)
            {
             if (key) {
                    var input = $("<input type='hidden' />");
                    $(input).attr("name", key);
                    $(input).val(val);
                    $(form).append(input);
                }
            }

            if (typeof params === "string")
            {
                var vars = params.split("&");
                for (var i = 0; i < vars.length; i++) {
                    var pair = vars[i].split("=");
                    if (pair[0] != undefined) {
                        AddItemToForm(unescape(pair[0].replace(/\+/g, " ")), unescape((pair[1] || "").replace(/\+/g, " ")));
                    }
                }
            } 
            else
            {
                if (params != null)
                    $.each(params, AddItemToForm);
            }

            $("body").append(iframe).append(form);
            form.submit();

            var loc = window.frames[uniqueString].location.href,
            queryTime = 0;

            function poll(post_target_url, callback, errorcallback, isLongPolling) {
                if (loc != window.frames[uniqueString].location.href)
                    getResponse(getParameterByName("id", window.frames[uniqueString].location.href), callback, errorcallback);
                else {
                    if (queryTime > 10000) {
                        if (errorcallback)
                        errorcallback(  new result(["Server not responding." + post_target_url], false) );
                        else {alert("pollfailed:" + post_target_url);}
                    }
                    else {
                        if (isLongPolling)
                            queryTime = queryTime + 50;
                        setTimeout(function() {poll(post_target_url, callback, errorcallback, isLongPolling)}, 50);
                    }
                }
            }
            poll(post_target_url, callback, errorcallback, isLongPolling);
        },
        getResponse = function (id, callback, errorcallback) {
            $.ajax({
                url: ServerURL + "/APIResponse/",
                data: { "id": id },
                dataType: 'jsonp', 
                success: function (data) { HandleResponse(data, callback, errorcallback) },
                error: function (jqXHR, textStatus, errorThrown) { errorcallback(new result([errorThrown], false) ); }
            });
        },
        HandleResponse = function (data, callback, errorcallback) {
            if (data.val.Valid) 
             {   
                if (callback) 
                    {  
                        function toObj() { return ToObject(this);   }
                        if (data.Result)
                            data.Result.ToObject = toObj;
                        callback(data); 
                    }
            }
            else { errorcallback(data); }
            
        },
        DefaultErrorHandler = function (data) {
            //Default Error Handler
            alert("DefaultErrorHandler:" + data.val.Errors.join("<br />"));
        },
        getParameterByName = function (name, url) {
            name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
            var regexS = "[\\?&]" + name + "=([^&#]*)";
            var regex = new RegExp(regexS);
            var results = regex.exec(url || window.location.href);
            if (results == null)
                return "";
            else
                return decodeURIComponent(results[1].replace(/\+/g, " "));
        };

        return { Post: post, Get : get, CDPost : crossDomainPost};

    })();

    var Comet =  (function () {
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

    var User =  (function () {
        var UpdateDetails = function(success) {
            
            function filldata(data) {
                    UserDetails.id = data.Person.ID;
                    UserDetails.name = data.Person.Name
                    UserDetails.isAuthenticated = data.Person.IsAuthenticated
                    UserDetails.isConfirmed = data.Person.isConfirmed;
                    success(UserDetails);
            }
            
             API.Post("/Person/GetCurrentPerson/", null, filldata);
        },
        GetByID = function(data, success, failed) {  
            API.Post("/Person/GetPersonByID/", data, function() {UpdateDetails(success, failed)}, failed);
        },
        SignUp = function(data, success, failed) {  
            API.Post("/Person/SignUp/", data, function() {UpdateDetails(success, failed)}, failed);
        },
        SignIn = function(credentials, success, failed) {  
            API.Post("/Person/Signin/", credentials, function() {UpdateDetails(success, failed)}, failed);
        },
        SignOut = function(success, failed) {  
            API.Post("/Person/SignOut/", null , function() {UpdateDetails(success, failed)}, failed);
        },
        Forgot = function(email, success, failed) {  
            API.Post("/Person/Signin/", email, success, failed);
        },
        ResendConfirmation = function(id, success, failed) {
            API.Post("/Person/SendConfirmation/", id, success, failed);
        },
        ChangePassword = function(passwords, success, failed) {  
            API.Post("/Person/ChangePassword/", passwords, success, failed);
        },
        ChangeName = function(namepassword, success, failed) {  
            API.Post("/Person/ChangeName/", namepassword, function() {UpdateDetails(success, failed)}, failed);
        }, 
        ChangeEmail = function(emailpassword, success, failed) {  
            API.Post("/Person/ChangeEmail/", emailpassword, function() {UpdateDetails(success, failed)}, failed);
        },
        UserDetails = { id : 0, isAuthenticated : false, name :"", isConfirmed : false},
        Details = function(callback) { 
        
            if (UserDetails.id == 0)
            {
                UpdateDetails(callback);
            }
            else{
                callback(UserDetails);
            }
        }; 

        var oAuth =  (function () {

            var targetWin;
            function PopupCenter(pageURL, title, w, h) {
                if ($(window).width() > 768 && w != undefined && w) {
                    var left = ($(window).width() / 2) - (w / 2);
                    var top = ($(window).height() / 2) - (h / 2);
                    targetWin = window.open(pageURL, title, 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
                }
                else
                {
                    targetWin = window.open(pageURL, title, 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no');
                }
            }

            var Facebook = function(scope, success, failed) {
                
                function callback(usersuccess) {
                    UpdateDetails(usersuccess);
                }
                
                var client_id = "[%FBKey%]";
                var uniqueString = "oAuth" + new Date().getTime().toString() + Math.random()*9999;

                if (scope.indexOf("email") == -1)
                { scope = "email," + scope; }

                var oAuthData = {scope : scope};
                oAuthData.client_id = client_id;
                oAuthData.redirect_uri =   window.location.protocol + "//" + window.location.hostname + "/servercyde";   // APIURL + "/oAuth/Facebook/" + uniqueString;
                oAuthData.response_type = "code";
               
               var targetUrl = "https://www.facebook.com/dialog/oauth?" + $.param(oAuthData);
                //popup if big window else _blank
                 PopupCenter(targetUrl , "Facebook", 800, 600);
                 
                 var loc = targetWin.location.href,
                 queryTime = 0;

                function poll(post_target_url, pollcallback, pollerrorcallback, isLongPolling) {
                    
                    var changed = false;

                    try { changed = (loc != targetWin.location.href); }
                    catch (e) {}

                    if (changed)
                    {
                        try { API.Post("/Person/Oauth/Facebook/" + targetWin.location.href.substr(targetWin.location.href.indexOf("?")), {}, pollcallback, failed); targetWin.close(); }
                        catch (err) { loc = targetWin.location.href; setTimeout(function() {poll(post_target_url, pollcallback, pollerrorcallback, isLongPolling)}, 50); }
                        
                    }
                    else {
                        if (queryTime > 30000) {
                            if (pollerrorcallback)
                            pollerrorcallback(new result(["User didn't approve in sufficient time" + post_target_url], false) );
                            else {alert("oauthpollfailed:" + post_target_url);}
                        }
                        else {
                            if (isLongPolling)
                                queryTime = queryTime + 50;
                            setTimeout(function() {poll(post_target_url, pollcallback, pollerrorcallback, isLongPolling)}, 50);
                        }
                    }
                }
                poll(targetUrl, function() { callback(success); }, failed, true);
            };
    
            return { Facebook : Facebook };
    
    })();


    var APIs =  (function () {

            var createdate="[%currenttime%]"[%apiscalls%];
    
            return { [%apiscallsreturn%] };
    
    })();


    
        return { SignIn : SignIn, Details : Details, ResendConfirmation : ResendConfirmation, Forgot : Forgot, SignOut : SignOut, SignIn : SignIn, SignUp : SignUp, oAuth : oAuth };
    
    })();

    var SimpleDB = (function () {

        var Select = (function () {

            var createdate="[%currenttime%]"[%selects%]; 
        
            return { [%returnselects%] };

        })(); 

        
        var Modify = (function () {

            var createdate="[%currenttime%]"[%modifys%]; 
        
            return { [%returnmodifys%] };

        })(); 

        
        var Get = (function () {

            var createdate="[%currenttime%]"[%gets%]; 
        
            return { [%returngets%] };

        })(); 
        
        return { Select : Select, Modify : Modify, Get : Get };

    })();

    var Email = (function () {

        var createdate="[%currenttime%]"[%emails%]; 
        
        return { [%returnemails%] };

    })(); 

    return { SimpleDB: SimpleDB, Comet : Comet, User : User, Email : Email };

})();

