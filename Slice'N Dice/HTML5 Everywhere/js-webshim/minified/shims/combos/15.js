(function(e){if(navigator.geolocation)return;var t=function(){setTimeout(function(){throw"document.write is overwritten by geolocation shim. This method is incompatible with this plugin"},1)},n=0,r=e.webshims.cfg.geolocation||{};navigator.geolocation=function(){var i,s={getCurrentPosition:function(n,s,o){var u=2,a,f,l,c=function(){if(l)return;if(i){l=!0,n(e.extend({timestamp:(new Date).getTime()},i)),p();if(window.JSON&&window.sessionStorage)try{sessionStorage.setItem("storedGeolocationData654321",JSON.stringify(i))}catch(t){}}else s&&!u&&(l=!0,p(),s({code:2,message:"POSITION_UNAVAILABLE"}))},h=function(){u--,d(),c()},p=function(){e(document).unbind("google-loader",p),clearTimeout(f),clearTimeout(a)},d=function(){if(i||!window.google||!google.loader||!google.loader.ClientLocation)return!1;var t=google.loader.ClientLocation;return i={coords:{latitude:t.latitude,longitude:t.longitude,altitude:null,accuracy:43e3,altitudeAccuracy:null,heading:parseInt("NaN",10),velocity:null},address:e.extend({streetNumber:"",street:"",premises:"",county:"",postalCode:""},t.address)},!0},v=function(){if(i)return;d();if(i||!window.JSON||!window.sessionStorage)return;try{i=sessionStorage.getItem("storedGeolocationData654321"),i=i?JSON.parse(i):!1,i.coords||(i=!1)}catch(e){i=!1}};v();if(!!i){setTimeout(c,1);return}if(r.confirmText&&!confirm(r.confirmText.replace("{location}",location.hostname))){s&&s({code:1,message:"PERMISSION_DENIED"});return}e.ajax({url:"http://freegeoip.net/json/",dataType:"jsonp",cache:!0,jsonp:"callback",success:function(e){u--;if(!e)return;i=i||{coords:{latitude:e.latitude,longitude:e.longitude,altitude:null,accuracy:43e3,altitudeAccuracy:null,heading:parseInt("NaN",10),velocity:null},address:{city:e.city,country:e.country_name,countryCode:e.country_code,county:"",postalCode:e.zipcode,premises:"",region:e.region_name,street:"",streetNumber:""}},c()},error:function(){u--,c()}}),clearTimeout(f),!window.google||!window.google.loader?f=setTimeout(function(){r.destroyWrite&&(document.write=t,document.writeln=t),e(document).one("google-loader",h),e.webshims.loader.loadScript("http://www.google.com/jsapi",!1,"google-loader")},800):u--,o&&o.timeout?a=setTimeout(function(){p(),s&&s({code:3,message:"TIMEOUT"})},o.timeout):a=setTimeout(function(){u=0,c()},1e4)},clearWatch:e.noop};return s.watchPosition=function(e,t,r){return s.getCurrentPosition(e,t,r),n++,n},s}(),e.webshims.isReady("geolocation",!0)})(jQuery),jQuery.webshims.register("details",function(e,t,n,r,i,s){var o=function(t){var n=e(t).parent("details");if(n[0]&&n.children(":first").get(0)===t)return n},u=function(t,n){t=e(t),n=e(n);var r=e.data(n[0],"summaryElement");e.data(t[0],"detailsElement",n);if(!r||t[0]!==r[0])r&&(r.hasClass("fallback-summary")?r.remove():r.unbind(".summaryPolyfill").removeData("detailsElement").removeAttr("role").removeAttr("tabindex").removeAttr("aria-expanded").removeClass("summary-button").find("span.details-open-indicator").remove()),e.data(n[0],"summaryElement",t),n.prop("open",n.prop("open"))},a=function(t){var n=e.data(t,"summaryElement");return n||(n=e("> summary:first-child",t),n[0]?u(n,t):(e(t).prependPolyfill('<summary class="fallback-summary">'+s.text+"</summary>"),n=e.data(t,"summaryElement"))),n};t.createElement("summary",function(){var n=o(this);if(!n||e.data(this,"detailsElement"))return;var r,i,s=e.attr(this,"tabIndex")||"0";u(this,n),e(this).on({"focus.summaryPolyfill":function(){e(this).addClass("summary-has-focus")},"blur.summaryPolyfill":function(){e(this).removeClass("summary-has-focus")},"mouseenter.summaryPolyfill":function(){e(this).addClass("summary-has-hover")},"mouseleave.summaryPolyfill":function(){e(this).removeClass("summary-has-hover")},"click.summaryPolyfill":function(t){var n=o(this);if(n){if(!i&&t.originalEvent)return i=!0,t.stopImmediatePropagation(),t.preventDefault(),e(this).trigger("click"),i=!1,!1;clearTimeout(r),r=setTimeout(function(){t.isDefaultPrevented()||n.prop("open",!n.prop("open"))},0)}},"keydown.summaryPolyfill":function(t){(t.keyCode==13||t.keyCode==32)&&!t.isDefaultPrevented()&&(i=!0,t.preventDefault(),e(this).trigger("click"),i=!1)}}).attr({tabindex:s,role:"button"}).prepend('<span class="details-open-indicator" />'),t.moveToFirstEvent(this,"click")});var f;t.defineNodeNamesBooleanProperty("details","open",function(t){var n=e(e.data(this,"summaryElement"));if(!n)return;var r=t?"removeClass":"addClass",i=e(this);if(!f&&s.animate){i.stop().css({width:"",height:""});var o={width:i.width(),height:i.height()}}n.attr("aria-expanded",""+t),i[r]("closed-details-summary").children().not(n[0])[r]("closed-details-child");if(!f&&s.animate){var u={width:i.width(),height:i.height()};i.css(o).animate(u,{complete:function(){e(this).css({width:"",height:""})}})}}),t.createElement("details",function(){f=!0;var t=a(this);e.prop(this,"open",e.prop(this,"open")),f=!1})});