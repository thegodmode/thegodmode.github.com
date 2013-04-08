(function(e){"use strict";var t=/webkit/i.test(navigator.userAgent),n=window.Modernizr,r=e.webshims,i=r.bugs,s=e('<form action="#" style="width: 1px; height: 1px; overflow: hidden;"><select name="b" required="" /><input required="" name="a" /></form>'),o=function(){if(s[0].querySelector)try{i.findRequired=!s[0].querySelector("select:required")}catch(e){i.findRequired=!1}},u=e("input",s).eq(0),a=function(e){r.loader.loadList(["dom-extend"]),r.ready("dom-extend",e)};i.findRequired=!1,i.validationMessage=!1,r.capturingEventPrevented=function(t){if(!t._isPolyfilled){var n=t.isDefaultPrevented,r=t.preventDefault;t.preventDefault=function(){return clearTimeout(e.data(t.target,t.type+"DefaultPrevented")),e.data(t.target,t.type+"DefaultPrevented",setTimeout(function(){e.removeData(t.target,t.type+"DefaultPrevented")},30)),r.apply(this,arguments)},t.isDefaultPrevented=function(){return!!(n.apply(this,arguments)||e.data(t.target,t.type+"DefaultPrevented")||!1)},t._isPolyfilled=!0}};if(!n.formvalidation||i.bustedValidity)o();else{r.capturingEvents(["input"]),r.capturingEvents(["invalid"],!0);if(window.opera||window.testGoodWithFix)s.appendTo("head"),o(),i.validationMessage=!u.prop("validationMessage"),r.reTest(["form-native-extend","form-message"]),s.remove(),e(function(){a(function(){var t=function(e){e.preventDefault()};["form","input","textarea","select"].forEach(function(n){var i=r.defineNodeNameProperty(n,"checkValidity",{prop:{value:function(){r.fromSubmit||e(this).on("invalid.checkvalidity",t),r.fromCheckValidity=!0;var n=i.prop._supvalue.apply(this,arguments);return r.fromSubmit||e(this).unbind("invalid.checkvalidity",t),r.fromCheckValidity=!1,n}}})})})});t&&!r.bugs.bustedValidity&&function(){var t=/^(?:textarea|input)$/i,n=!1;document.addEventListener("contextmenu",function(e){t.test(e.target.nodeName||"")&&(n=e.target.form)&&setTimeout(function(){n=!1},1)},!1),e(window).on("invalid",function(e){e.originalEvent&&n&&n==e.target.form&&(e.wrongWebkitInvalid=!0,e.stopImmediatePropagation())})}()}jQuery.webshims.register("form-core",function(e,r,i,s,o,u){var a={checkbox:1,radio:1},f=e([]),l=r.bugs,c={radio:1},h=function(t){t=e(t);var n,r,i=f;return c[t[0].type]&&(r=t.prop("form"),n=t[0].name,n?r?i=e(r[n]):i=e(s.getElementsByName(n)).filter(function(){return!e.prop(this,"form")}):i=t,i=i.filter('[type="radio"]')),i},p=r.getContentValidationMessage=function(t,n,r){var i=e(t).data("errormessage")||t.getAttribute("x-moz-errormessage")||"";return r&&i[r]&&(i=i[r]),typeof i=="object"&&(n=n||e.prop(t,"validity")||{valid:1},n.valid||e.each(n,function(e,t){if(t&&e!="valid"&&i[e])return i=i[e],!1})),typeof i=="object"&&(i=i.defaultMessage),i||""},d={number:1,range:1,date:1},v=function(t){var n=!1;return e(e.prop(t,"elements")).each(function(){n=e(this).is(":invalid");if(n)return!1}),n};e.extend(e.expr[":"],{"valid-element":function(t){return e.nodeName(t,"form")?!v(t):!!e.prop(t,"willValidate")&&!!g(t)},"invalid-element":function(t){return e.nodeName(t,"form")?v(t):!!e.prop(t,"willValidate")&&!g(t)},"required-element":function(t){return!!e.prop(t,"willValidate")&&!!e.prop(t,"required")},"user-error":function(t){return e.prop(t,"willValidate")&&e(t).hasClass("user-error")},"optional-element":function(t){return!!e.prop(t,"willValidate")&&e.prop(t,"required")===!1},"in-range":function(t){if(!d[e.prop(t,"type")]||!e.prop(t,"willValidate"))return!1;var n=e.prop(t,"validity");return!!(n&&!n.rangeOverflow&&!n.rangeUnderflow)},"out-of-range":function(t){if(!d[e.prop(t,"type")]||!e.prop(t,"willValidate"))return!1;var n=e.prop(t,"validity");return!(!n||!n.rangeOverflow&&!n.rangeUnderflow)}}),["valid","invalid","required","optional"].forEach(function(t){e.expr[":"][t]=e.expr.filters[t+"-element"]}),e.expr[":"].focus=function(e){try{var t=e.ownerDocument;return e===t.activeElement&&(!t.hasFocus||t.hasFocus())}catch(n){}return!1},n.formvalidation&&t&&!r.bugs.bustedValidity&&function(){var t=function(){var e;(e=this.validity)&&!e.customError&&this.setCustomValidity("")};r.addReady(function(n,r){n!==s&&e('input[type="radio"]:invalid',n).add(r.filter('input[type="radio"]:invalid')).each(t)})}();var m=e.event.customEvent||{},g=function(t){return(e.prop(t,"validity")||{valid:1}).valid};(l.bustedValidity||l.findRequired)&&function(){var t=e.find,r=e.find.matchesSelector,i=/(\:valid|\:invalid|\:optional|\:required|\:in-range|\:out-of-range)(?=[\s\[\~\.\+\>\:\#*]|$)/ig,o=function(e){return e+"-element"};e.find=function(){var e=Array.prototype.slice,n=function(n){var r=arguments;return r=e.call(r,1,r.length),r.unshift(n.replace(i,o)),t.apply(this,r)};for(var r in t)t.hasOwnProperty(r)&&(n[r]=t[r]);return n}();if(!n.prefixed||n.prefixed("matchesSelector",s.documentElement))e.find.matchesSelector=function(e,t){return t=t.replace(i,o),r.call(this,e,t)}}();var y=e.prop,b={selectedIndex:1,value:1,checked:1,disabled:1,readonly:1};e.prop=function(t,n,r){var i=y.apply(this,arguments);return t&&"form"in t&&b[n]&&r!==o&&e(t).hasClass(S)&&g(t)&&(e(t).getShadowElement().removeClass(x),n=="checked"&&r&&h(t).not(t).removeClass(x).removeAttr("aria-invalid")),i};var w=function(t,n){var r;return e.each(t,function(t,i){if(i)return r=t=="customError"?e.prop(n,"validationMessage"):t,!1}),r},E=function(e){var t;try{t=s.activeElement.name===e}catch(n){}return t},S="user-error",x="user-error form-ui-invalid",T="user-success",N="user-success form-ui-valid",C={time:1,date:1,month:1,datetime:1,week:1,"datetime-local":1},k=function(n){var r,i;if(!n.target)return;r=e(n.target).getNativeElement()[0];if(r.type=="submit"||!e.prop(r,"willValidate"))return;i=e.data(r,"webshimsswitchvalidityclass");var s=function(){if(n.type=="focusout"&&r.type=="radio"&&E(r.name))return;var i=e.prop(r,"validity"),s=e(r).getShadowElement(),o,u,f,c,p;if(t&&n.type=="change"&&!l.bustedValidity&&C[s.prop("type")]&&s.is(":focus"))return;e(r).trigger("refreshCustomValidityRules"),i.valid?s.hasClass(T)||(o=N,u=x,c="changedvaliditystate",f="changedvalid",a[r.type]&&r.checked&&h(r).not(r).removeClass(u).addClass(o).removeAttr("aria-invalid"),e.removeData(r,"webshimsinvalidcause")):(p=w(i,r),e.data(r,"webshimsinvalidcause")!=p&&(e.data(r,"webshimsinvalidcause",p),c="changedvaliditystate"),s.hasClass(S)||(o=x,u=N,a[r.type]&&!r.checked&&h(r).not(r).removeClass(u).addClass(o),f="changedinvalid")),o&&(s.addClass(o).removeClass(u),setTimeout(function(){e(r).trigger(f)},0)),c&&setTimeout(function(){e(r).trigger(c)},0),e.removeData(n.target,"webshimsswitchvalidityclass")};i&&clearTimeout(i),n.type=="refreshvalidityui"?s():e.data(r,"webshimsswitchvalidityclass",setTimeout(s,9))};e(s).on(u.validityUIEvents||"focusout change refreshvalidityui",k),m.changedvaliditystate=!0,m.refreshCustomValidityRules=!0,m.changedvalid=!0,m.changedinvalid=!0,m.refreshvalidityui=!0,r.triggerInlineForm=function(t,n){e(t).trigger(n)},r.modules["form-core"].getGroupElements=h;var L=function(){r.scrollRoot=t||s.compatMode=="BackCompat"?e(s.body):e(s.documentElement)};L(),r.ready("DOM",L),r.getRelOffset=function(t,n){t=e(t);var r=e(n).offset(),i;return e.swap(e(t)[0],{visibility:"hidden",display:"inline-block",left:0,top:0},function(){i=t.offset()}),r.top-=i.top,r.left-=i.left,r},r.validityAlert=function(){var t="span",n,o=!1,u=!1,a=!1,f,l={hideDelay:5e3,showFor:function(t,n,r,s){l._create(),t=e(t);var u=e(t).getShadowElement(),c=l.getOffsetFromBody(u);l.clear(),s?this.hide():(this.getMessage(t,n),this.position(u,c),this.show(),this.hideDelay&&(o=setTimeout(f,this.hideDelay)),e(i).on("resize.validityalert reposoverlay.validityalert",function(){clearTimeout(a),a=setTimeout(function(){l.position(u)},9)})),r||this.setFocus(u,c)},getOffsetFromBody:function(e){return r.getRelOffset(n,e)},setFocus:function(o,u){var a=e(o).getShadowFocusElement(),l=r.scrollRoot.scrollTop(),c=(u||a.offset()).top-30,h;r.getID&&t=="label"&&n.attr("for",r.getID(a)),l>c&&(r.scrollRoot.animate({scrollTop:c-5},{queue:!1,duration:Math.max(Math.min(600,(l-c)*1.5),80)}),h=!0);try{a[0].focus()}catch(p){}h&&(r.scrollRoot.scrollTop(l),setTimeout(function(){r.scrollRoot.scrollTop(l)},0)),setTimeout(function(){e(s).on("focusout.validityalert",f)},10),e(i).triggerHandler("reposoverlay")},getMessage:function(t,r){r||(r=p(t[0])||t.prop("customValidationMessage")||t.prop("validationMessage")),r?e("span.va-box",n).text(r):this.hide()},position:function(t,r){r=r?e.extend({},r):l.getOffsetFromBody(t),r.top+=t.outerHeight(),n.css(r)},show:function(){n.css("display")==="none"&&n.css({opacity:0}).show(),n.addClass("va-visible").fadeTo(400,1)},hide:function(){n.removeClass("va-visible").fadeOut()},clear:function(){clearTimeout(u),clearTimeout(o),e(s).unbind(".validityalert"),e(i).unbind(".validityalert"),n.stop().removeAttr("for")},_create:function(){if(n)return;n=l.errorBubble=e("<"+t+' class="validity-alert-wrapper" role="alert"><span  class="validity-alert"><span class="va-arrow"><span class="va-arrow-box"></span></span><span class="va-box"></span></span></'+t+">").css({position:"absolute",display:"none"}),r.ready("DOM",function(){n.appendTo("body"),e.fn.bgIframe&&n.bgIframe()})}};return f=e.proxy(l,"hide"),l}(),function(){var t,n=[],r,i;e(s).on("invalid",function(i){if(i.wrongWebkitInvalid)return;var o=e(i.target),u=o.getShadowElement();u.hasClass(S)||(u.addClass(x).removeClass(N),setTimeout(function(){e(i.target).trigger("changedinvalid").trigger("changedvaliditystate")},0));if(!t){t=e.Event("firstinvalid"),t.isInvalidUIPrevented=i.isDefaultPrevented;var a=e.Event("firstinvalidsystem");e(s).triggerHandler(a,{element:i.target,form:i.target.form,isInvalidUIPrevented:i.isDefaultPrevented}),o.trigger(t)}t&&t.isDefaultPrevented()&&i.preventDefault(),n.push(i.target),i.extraData="fix",clearTimeout(r),r=setTimeout(function(){var r={type:"lastinvalid",cancelable:!1,invalidlist:e(n)};t=!1,n=[],e(i.target).trigger(r,r)},9),o=null,u=null})}(),e.fn.getErrorMessage=function(){var t="",n=this[0];return n&&(t=p(n)||e.prop(n,"customValidationMessage")||e.prop(n,"validationMessage")),t},u.replaceValidationUI&&r.ready("DOM forms",function(){e(s).on("firstinvalid",function(t){t.isInvalidUIPrevented()||(t.preventDefault(),e.webshims.validityAlert.showFor(t.target))})})})})(jQuery);