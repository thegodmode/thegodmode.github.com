(function(e,t,n,r){"use strict";if(!e.webshims){var i=navigator.browserLanguage||navigator.language||e("html").attr("lang")||"";e.webshims={addReady:function(t){e(function(){t(n,e([]))})},ready:function(e,t){t()},activeLang:function(){return i}}}var s=e.webshims,o={},u=!1,a,f,l=function(e){s.refreshCustomValidityRules(e.target)};s.customErrorMessages={},s.addCustomValidityRule=function(t,n,r){o[t]=n,s.customErrorMessages[t]||(s.customErrorMessages[t]=[],s.customErrorMessages[t][""]=r||t),e.isReady&&u&&e("input, select, textarea").each(function(){c(this)})},s.refreshCustomValidityRules=function(t){if(!t.form||!f&&!e.prop(t,"willValidate"))return;a=!0;var n=e.data(t,"customMismatchedRule"),r=e.prop(t,"validity")||{},i="";if(n||!r.customError){var u=e(t).val();e.each(o,function(r,o){i=o(t,u)||"",n=r;if(i)return typeof i!="string"&&(i=e(t).data("errormessage")||t.getAttribute("x-moz-errormessage")||s.customErrorMessages[r][s.activeLang()]||s.customErrorMessages[r][""]),typeof i=="object"&&(i=i[r]||i.customError||i.defaultMessage),!1}),i&&e.data(t,"customMismatchedRule",n),e(t).setCustomValidity(i)}a=!1};var c=s.refreshCustomValidityRules;s.ready("forms",function(){u=!0;var t=e.fn.setCustomValidity||function(e){return this.each(function(){this.setCustomValidity&&this.setCustomValidity(e)})};e.fn.setCustomValidity=function(e){return a||this.data("customMismatchedRule",""),t.apply(this,arguments)},e(n).bind("change",l),s.addReady(function(t,n){f=!0,e("input, select, textarea",t).add(n.filter("input, select, textarea")).each(function(){c(this)}),f=!1}),e(n).bind("refreshCustomValidityRules",l)})})(jQuery,window,document),function(e,t,n,r){"use strict";var i=e.webshims.addCustomValidityRule;i("partialPattern",function(t,n){if(!n||!t.getAttribute("data-partial-pattern"))return;var r=e(t).data("partial-pattern");if(!r)return;return!(new RegExp("("+r+")","i")).test(n)},"This format is not allowed here."),i("tooShort",function(t,n){if(!n||!t.getAttribute("data-minlength"))return;return e(t).data("minlength")>n.length},"Entered value is too short.");var s={};i("group-required",function(t,r){var i=t.name;if(!i||t.type!=="checkbox"||!e(t).hasClass("group-required"))return;var o=e(t.form&&t.form[i]||n.getElementsByName(i)),u=o.filter(":enabled:checked");return s[i]&&clearTimeout(s[i]),s[i]=setTimeout(function(){o.unbind("click.groupRequired").bind("click.groupRequired",function(){o.filter(".group-required").each(function(){e.webshims.refreshCustomValidityRules(this)})})},9),!u[0]},"Please check one of these checkboxes."),i("creditcard",function(t,n){if(!n||!e(t).hasClass("creditcard-input"))return;n=n.replace(/\-/g,"");if(n!=n*1)return!0;var r=n.length,i=0,s=1,o;while(r--)o=parseInt(n.charAt(r),10)*s,i+=o-(o>9)*9,s^=3;return!(i%10===0&&i>0)},"Please enter a valid credit card number");var o={prop:"value","from-prop":"value",toggle:!1},u=function(t){return e(t.form[t.name]).filter('[type="radio"]')};e.webshims.ready("form-core",function(){e.webshims.modules&&(u=e.webshims.modules["form-core"].getGroupElements||u)}),i("dependent",function(t,r){if(!t.getAttribute("data-dependent-validation"))return;var i=e(t).data("dependentValidation"),s;if(!i)return;var a=function(n){var r=e.prop(i.masterElement,i["from-prop"]);s&&(r=e.inArray(r,s)!==-1),i.toggle&&(r=!r),e.prop(t,i.prop,r)};if(!i._init||!i.masterElement){typeof i=="string"&&(i={from:i}),i.masterElement=n.getElementById(i.from)||n.getElementsByName(i.from||[])[0];if(!i.masterElement||!i.masterElement.form)return;/radio|checkbox/i.test(i.masterElement.type)?(i["from-prop"]||(i["from-prop"]="checked"),!i.prop&&i["from-prop"]=="checked"&&(i.prop="disabled")):i["from-prop"]||(i["from-prop"]="value"),i["from-prop"].indexOf("value:")===0&&(s=i["from-prop"].replace("value:","").split("||"),i["from-prop"]="value"),i=e.data(t,"dependentValidation",e.extend({_init:!0},o,i)),i.prop!=="value"||s?e(i.masterElement.type==="radio"&&u(i.masterElement)||i.masterElement).bind("change",a):e(i.masterElement).bind("change",function(){e.webshims.refreshCustomValidityRules(t),e(t).is(".user-error, .user-success")&&e(t).trigger("refreshvalidityui")})}return i.prop=="value"&&!s?e.prop(i.masterElement,"value")!=r:(a(),"")},"The value of this field does not repeat the value of the other field")}(jQuery,window,document);