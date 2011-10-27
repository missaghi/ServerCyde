// <reference path="jquery-1.6.1.js" />
var SC = (function () {
    var FnArray = function () {
        return {
            funcs: new Array,
            add: function (f) {
                if (typeof f != "function") {
                    f = new Function(f);
                }
                this.funcs[this.funcs.length] = f;
            },
            execute: function () {
                for (var i = 0; i < this.funcs.length; i++) {
                    this.funcs[i]();
                }
            }
        };
    },
        initcall = new FnArray(), //callbacks
        mode = '',
        temp = '',
        SubmitForm = function (elem) {
            $(".example").val('');
            $(elem).closest('form').submit();
        },
        Dialog = function (url) {

            var xmlDoc;

            $.ajax({
                type: 'POST', //post required to excced GET  length restriction
                url: url,
                dataType: 'html',
                success: function (data) {

                    //cross platform xml object creation from w3schools
                    try //Internet Explorer
                        {
                        xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
                        xmlDoc.async = "false";
                        xmlDoc.loadXML(data);
                    }
                    catch (e) {
                        try // Firefox, Mozilla, Opera, etc.
                            {
                            parser = new DOMParser();
                            xmlDoc = parser.parseFromString(data, "text/xml");
                        }
                        catch (e) {
                            alert(e.message);
                            return;
                        }
                    }

                    var body = xmlDoc.getElementsByTagName("body")[0].innerHTML,
                        title = xmlDoc.getElementsByTagName("title")[0].childNodes[0].nodeValue;

                    $('<div></div>')
		                        .html(body)
		                        .dialog({ title: title, minWidth: 600, height: 400 });
                }
            });
        },
        Example = function () { //make inputs behave nicely with example text
            $('textarea[title]:empty, input[title][value=""]').each(function () {
                if ($(this).val() == '' || $(this).val() == $(this).attr('title')) {
                    $(this).addClass('example');
                    $(this).val($(this).attr('title'));
                    $(this).one('focus', function () {
                        $(this).removeClass("example").val("");
                    });
                }
                $(this).one('blur', function () {
                    Example();
                });
            });
        },
        EnterForms = function () {
            $("textarea[maxlength], input[maxlength]").focus(function () {
                $(this).charCount({ allowed: $(this).attr('maxlength') });
                $(this).blur(function () { $(this).next().remove(); });
            });
        },
        Uniforms = function () {
            $(".button, .submit").button();
            $(".buttonset").buttonset();
            $("form input:checkbox, form input:radio, form input:file, input:text").uniform();
        },
        AddInit = function (func) { initcall.add(func); },
        Ready = function () {
            $(".ajaxdialog").click(function () {
                Dialog($(this).attr('href'));
                return false;
            });

            $(".box").append('<img src="/a/img/footer.png"  style="position:absolute;bottom:-11px; width:100%; height:10px; left:0px;"  />');

            //$(".equalHeight").equalHeights();

            $(".tip").tooltip({
                showURL: false, delay: 0, track: true, showBody: " - "
            });

            //AddInit(EnterForms);
            AddInit(Example);
            AddInit(Uniforms);

            if (initcall)
                initcall.execute();


        };

    $().ready(Ready);

    return { AddInit: AddInit, SubmitForm: SubmitForm };

})();


