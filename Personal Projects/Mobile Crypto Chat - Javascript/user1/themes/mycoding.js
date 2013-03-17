
   var serviceURL =
                     "http://mobilecryptochat.apphb.com/MobileCryptoChatService.svc";
   var refreshIntervalId = "";
   var phonebook = [ "+359883472013","+359883472183","+359883472299","+359897877047","+359885130191"] ;
   var upgradeSpeed = "" ;
   var ID = "";
   var generalKey="";
   var MSISDN = "";
   var sessionID=""
      
   function sendSuccess (message) {
   
    
	  $('#resultArea').append('<div id="send">'+'You:'+ message + '</div>');
	  $('#chatArea').val("");
	  $('#resultArea').scrollTop(300000);
	  
      
   }
   
   
   
   function sendError(err) {
   
    $('#error').show();
    $('#error_1').show();
  
      if(err.status==403){
			 
			  $('#error').html("Invalid Session");
			  window.location.href = "#loginPage";
			 
       }



         if(err.status==404){
			 
			 $('#error_1').html("User is offline");
			 $('#chatArea').hide("slow");
			 $('#textInput').hide("slow");
			  $('#abort').hide("slow");
			 
        }
 
         if(err.status==500){
			 
			 $('#error').html("general error");
			 window.location.href = "#chatPage";

			 
         } 
 
  setTimeout('$("#error_1").hide("slow")',3000);
  setTimeout('$("#error").hide("slow")',3000);  
   }
   
   $("#chatArea").keypress(function(event){
   
        if (event.keyCode==13)
		{
		    var message = $("#chatArea").val();
			var encryptedMsg = GibberishAES.enc(message,generalKey);
			var data = {
		
	               "sessionID":ID,
	               "recipientMSISDN":MSISDN,
                   "encryptedMsg": encryptedMsg

	                   };
					   
					      $.ajax({
                                url: serviceURL + "/send-chat-message",
                                type: "POST",
                                contentType: "application/json",
                                dataType: "json",
			                    data: JSON.stringify(data),
                                success:sendSuccess(message),
			                    error: sendError
                               });  			 
					   
			
               			
			
		     
		}
   });

 $("#updateSpeed").bind("vclick",function(){
   $("ul").slideToggle();
});



 $(".list").click(function(){
     
	 $("ul").css('display' , 'none');
	 $('#error').hide();
	 upgradeSpeed = $(this).val();
	 localStorage.setItem('upgradeSpeed',upgradeSpeed);
	
	  
});


  function  inviteError (err){
  
  $('#error').show();
  $('#error_1').show();
  
  if(err.status==403){
			 
			 $('#error').html("Invalid Session");
			  window.location.href = "#loginPage";
			 
}



if(err.status==404){
			 
			 $('#error_1').html("User is offline or you invite yourself");
			 window.location.href = "#chatPage";
			 setTimeout('$("#error_1").hide("slow")',3000);
}
 
if(err.status==500){
			 
			 $('#error').html("Cannot invite this user ... general error");
			 window.location.href = "#chatPage";

			 
} 

   
  setTimeout('$("#error").hide("slow")',3000); 
  
  }
  function listOfUsers (users) {
	  
	  
		$("#red").css('display' , 'inline-block');
		$("#green").css('display' , 'none');
		
     
	 
	 
	for (i=0 ; i< users.length ; i++ ){
	   for (n=0; n<phonebook.length; n++)
	      {   
		     
			  
			  if(users[i] == phonebook[n]){
					
							  
var temp = "#"+(users[i].substring(users[i].indexOf('+')+1 ));
		 
				$(temp).find("#red").css('display' , 'none');
				$(temp).find("#green").css('display' , 'inline-block');
				  			  
				  
			  }
			  
			  	 
		 }
	}
	 
	  
	  
  }

  function logoutSuccessful(response) {
  
  clearInterval(refreshIntervalId);
  window.location.href = "#loginPage";
  $("#resultArea").empty();
  $('#chatArea').css('display','none');
  $('#textInput').css('display','none');
}

  function logoutError(err) {

  $('#error_1').show();
   
 if(err.status==403){
			 
			
			 window.location.href = "#loginPage";
			 $('#error_1').html("");
			 
}


 if(err.status==500){
			 
			 $('#error_1').html("General Error");
			 window.setTimeout('window.location.href = "#loginPage"',4000);
}




}
function connectSuccessful(response) {

$('#error_1').html("");
$('#chatArea').empty();
$('#abort').hide();
window.location.href = "#chatPage";
var STR = JSON.stringify(response);
ID = response.sessionID;
if(upgradeSpeed=="")
{
  upgradeSpeed = 5000;

}
     
	$.ajax({
            url: serviceURL + "/list-users/" + ID,
            type: "GET",
            contentType: "application/json",
            dataType: "json",
            success: listOfUsers,
			error: logoutError
        });  
		
  refreshIntervalId = setInterval('getNextMessage()',upgradeSpeed);
}

 function registerError(err) {
          
		  window.location.href = "#loginPage";
		  $('#error').show();	 
             if(err.status==404){
			 
			 $('#error').html("You are already register");

                  }			

             if(err.status==500){
			 
			 $('#error').html("Server or network is down try again later");

                  }							  
          
                
        }
		
		function loginError(err) {
          
		  $('#error').show();	 
		  
             if(err.status==403){
			 
			 $('#error').html("Invalid msisdn or password");
              
                  }			

             if(err.status==404){
			 
			 $('#error').html("Invalid authCode ");

                  }	


             if(err.status==500){
			 
			 $('#error').html("Login Failed");

                  }						  
          
         
          setTimeout('$("#error").hide("slow")',3000);        
        }
		
		
	function checkMobile(mobile){
	       
          var y = mobile;
                    
           if(isNaN(y)||y.indexOf(" ")!=-1)
           {
              alert("Enter valid mobile number")
              return false;
           }
         
           if (y.charAt(0)!="+")
           {
                alert("it should start with +");
                return false
           } 
		   
		     if (y.length>13 || y.length<13)
           {
                alert("enter 13 characters");
                return false;
           }
		   
		   else {
		   
		       return true;
		   }
		   
		   
      	}
	
    
	
	$("#registerButton").click(function(event){
	 	var mobile = $("#regMobileNumber").val()
		var pass = $("#passRegister").val()
		var authCode=Crypto.SHA1(mobile+pass);
		localStorage.setItem('mobileNumber',mobile);
		localStorage.setItem('pass', pass);
								
	     var userData = {
	   
	    "msisdn": mobile,
        "authCode": authCode
	   
	   };
	   
	   if(checkPass(pass) && checkMobile(mobile))
	   {
	  
        $.ajax({
            url: serviceURL + "/register",
            type: "POST",
            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify(userData),
            success:connectSuccessful,
            error: registerError
        }); 
	  }
	
	});
	
	  function checkUpdateSpeed() {
	  
	   
	     if (upgradeSpeed == "" && upgradeSpeed == "0")
		    {
			    $('#error').show()
			    $('#error').html("Configurate Connection First!");
				setTimeout(' $("#error").hide("slow")',3000);
			}
	     else{
		 
		   return 1;
		 }
	      
	  }
	
 $('#Login').click(function (event) {
      
	 	var mobile = $("#mobileNumber").val();
		var pass = $("#pass").val();
		var authCode=Crypto.SHA1(mobile+pass);
		localStorage.setItem('mobileNumber',mobile);
		localStorage.setItem('pass', pass);
								
	     var userData = {
	   
	    "msisdn": mobile,
        "authCode": authCode
	   
	   };
	   
	   if(checkPass(pass) && checkMobile(mobile) && checkUpdateSpeed() )
	   {
                          
            $.ajax({
            url: serviceURL + "/login",
            type: "POST",
            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify(userData),
            success:connectSuccessful,
            error: loginError
        });
				
		}
		
    });
	
	function checkPass (pass) {
	
	     if(pass.length<6 || pass.length>10) {
		  
		        alert("Incorrect password");
                return false;
		 
		 }
		 else {
		 
		       return true;
		 }


     }	
	
	
	$(".return").click(function (event) {
	
	 $('#error').html("");
	 $('#error_1').html("");
	
	});
	
	
	 $('#LogOut').click(function () {
      	  
		 
            $.ajax({
            url: serviceURL + "/logout/" + ID,
            type: "GET",
            contentType: "application/json",
            dataType: "json",
            success:logoutSuccessful,
            error: logoutError
        });
    });
	 
	
	$(".return").click(function (event) {
	
	 $('#error').html("");
	
	});
	
	

 
  
  
  $(".person").click(function () {
	  
	  
     	 generalKey = prompt("Enter Secret Key","");
		 if (generalKey != '' && generalKey != null)
		 {
	    var randomValue = randomFromTo(0,999999999);
		var challenge = GibberishAES.enc(randomValue,generalKey);
		var mobile = $(this).find(".mobile").text();
		mobile=(mobile.substring(mobile.indexOf('Mobile')+7)); // get only digits and "+"
		 
		
		var data = {
		
	               "sessionID":ID,
	               "recipientMSISDN":mobile,
                   "challenge": challenge

	   
	   };
		
		
	          $.ajax({
            url: serviceURL + "/invite-user",
            type: "POST",
            contentType: "application/json",
            dataType: "json",
			data: JSON.stringify(data),
            success:inviteSuccess ,
			error: inviteError
        }); 
		
		}
						
  }); 
  
  function inviteSuccess () {
  
   
    $('#resultArea').append('<div id="invitation">Invitation Send.Waiting user response...</div>');
    window.location.href = "#chatPage";
	$('#error').hide();
  }
  
  function randomFromTo(from, to){
       return Math.floor(Math.random() * (to - from + 1) + from);
    }
 


 
 window.onbeforeunload = function (e) {
    var e = e || window.event;

    // For IE and Firefox
    if (e) {
        e.returnValue = 'Leaving the page';
    }

    // For Safari
    return 'Leaving the page';
};

 function messageError (err){
 
  $('#error').show();
  
 
 if(err.status==403) {
  
    $("#error").html("Invalid Session!");
	clearInterval(refreshIntervalId);
	window.location.href = "#loginPage";
 
 }
 
 if(err.status==500) {
  
    $("#error").html("General Error");
 
 }
   
  setTimeout('$("#error").hide("slow")',3000); 
 }
 
 
 function getNextMessage() {
 
   
   
       $.ajax({
            url: serviceURL + "/get-next-message/" + ID,
            type: "GET",
            contentType: "application/json",
            dataType: "json",
			success:messageSuccess ,
			error: messageError
        }); 
 
 }
 
 function chatSuccess () {
  $('#resultArea').empty();
  $('#resultArea').append('<div id="invitation">'+'Chat session start'+'</div>');
  $('#chatArea').show('slow');
  $('#textInput').show('slow');
  $('#abort').show('slow');
  
 
 }
 
 function chatError (err) {
 
  $('#error').show();
  $('#error_1').show();
  
  if(err.status==403){
			 
			 $('#error').html("Invalid Session");
			  window.location.href = "#loginPage";
			 
}



if(err.status==404){
			 
			 $('#error_1').html("User is offline");
			window.location.href = "#chatPage";
			 
}
 
if(err.status==500){
			 
			 $('#error').html("general error");
			 window.location.href = "#chatPage";

			 
} 

  setTimeout('$("#error_1").hide("slow")',3000);
  setTimeout('$("#error").hide("slow")',3000); 
    
  
 }
 function messageSuccess (message) {
   
	      
     	 var m = JSON.stringify(message);
		 
		 sessionID = m.substring ((m.indexOf('"msgText"')+11), m.indexOf('",'));
		 var string = m.substring ((m.indexOf('"msgType"')+11));
		 var messageType = string.substring(0,string.indexOf('"'));
		 var msisdn = string.substring((string.indexOf('"msis')+10),string.indexOf('"}'));
	         
			if(msisdn.length == 13) {
			    
				MSISDN = msisdn;
			}
			
			
		
			
	    
	
	  
	  if( messageType == "MSG_USER_ONLINE") {
	   
	                     for (n=0; n<phonebook.length; n++)
						   {
						      if(phonebook[n]== MSISDN)
						           {
								    var id = "#" + MSISDN.substring(1);
							        $(id).find("#red").css('display' , 'none');
							        $(id).find("#green").css('display' , 'inline-block');
						            var name = $(id).text();
								    $("#error_1").empty();
									$('#error_1').append('<div id="login">'+name+' log in</div>');
									$('#error_1').show('slow');
									setTimeout("$('#error_1').hide('slow')",3000)
							       
							
							
							     }
						   }
	                    
						 					 
						 }
						 
	 if( messageType == "MSG_USER_OFFLINE") {
	                   
					   for (n=0; n<phonebook.length; n++)
						   {
						      if(phonebook[n]== MSISDN)
						           {
								    var id = "#" + MSISDN.substring(1);
							       	$(id).find("#green").css('display' , 'none');
							        $(id).find("#red").css('display' , 'inline-block');
						            var name = $(id).text();
									$("#error_1").empty();
									$('#error_1').append('<div id="logoff">'+ name +' log off</div>');
									$('#error_1').show('slow');
							        setTimeout("$('#error_1').hide('slow')",3000)
							
							
							     }
						 
						 
						 }

         }						 
      				 
	 if( messageType == "MSG_CHALLENGE") {
	 
	 
                        	 for (n=0; n<phonebook.length; n++)
						       {
						      if(phonebook[n]== MSISDN)
						           {
								    var id = "#" + MSISDN.substring(1);
							       	var name = $(id).text();
									window.location.href = "#dialogPage";
									$("#hdialog").html( name + " Invite You to Chat.");
						           }
							   }
								   
	                  
	
	
	}      
					
						
					
	
						 						 
		 	
	 
	 
		 
	 if( messageType == "MSG_RESPONSE") {
	                     
					   $('#resultArea').append('<div id="invitation">'+'Checking the response...'+'</div>');
						
					    try{

                             var randomValue = GibberishAES.dec(sessionID,generalKey);

                        } catch(e) {
						 alert('Wrong key !!');
						 $('#resultArea').append('<div id="invitation">'+'Invalid response'+'</div>');
						 var data = {
		
	                                         "sessionID":ID,
	                                         "recipientMSISDN":MSISDN,
                                     };
					 				        
                                $.ajax({
                                url: serviceURL + "/cancel-chat",
                                type: "POST",
                                contentType: "application/json",
                                dataType: "json",
			                    data: JSON.stringify(data),
                                success:cancelSuccess ,
			                    error: cancelError
                               });  			 
						 
						 	 
						  }
						 
						 $('#resultArea').append('<div id="invitation">'+'Response OK'+'</div>');
						 
						  var data = {
		
	                                         "sessionID":ID,
	                                         "recipientMSISDN":MSISDN,
                                     };
					 				        
                                $.ajax({
                                url: serviceURL + "/start-chat",
                                type: "POST",
                                contentType: "application/json",
                                dataType: "json",
			                    data: JSON.stringify(data),
                                success:chatSuccess ,
			                    error: chatError
                               });  			 
						 
						 	 
						 
						 }	

     if(messageType == "MSG_START_CHAT") {
	                     
						 $('#resultArea').empty();
	                     $('#resultArea').append('<div id="invitation">'+'Chat session start'+'</div>');
						 $('#chatArea').show('slow')
                         $('#textInput').show('slow');
						 $('#abort').show('slow');
						 
						 }	
     if(messageType == "MSG_CANCEL_CHAT") {
	                    
	                    $('#resultArea').append('<div id="invitation"> Invitation/Chat Cancel!</div>');
                        $('#abort').hide('slow');
                        $('#chatArea').hide('slow');
                        $('#textInput').hide('slow');
						 
						 
						 }							 
	 if (messageType == "MSG_CHAT_MESSAGE") {
	                   
	                     try {
                                								
                             var decryptedMsg = GibberishAES.dec(sessionID,generalKey);

                           } catch(e) {
						 
						  alert('Fatal error');
							}	
						var id = "#" + MSISDN.substring(1);
						var name = $(id).text();
						$('#resultArea').append('<div id="receive">'+ name+':'+decryptedMsg +'</div>');
						$('#resultArea').scrollTop(300000);
             						
						
       }
 
 
 }
 
 function responseSuccess () {
 
  window.location.href = "#chatPage";
  $('#resultArea').append('<div id="invitation"> Response Send!</div>');
  $('#error_1').hide();
 }
 
 function responseError (err) {
  
  $('#error').show();
  $('#error_1').show();
  
  if(err.status==403){
			 
			 $('#error').html("Invalid Session");
			  window.location.href = "#loginPage";
			 
}



if(err.status==404){
			 
			 $('#error_1').html("User is offline");
			window.location.href = "#chatPage";
			 
}
 
if(err.status==500){
			 
			 $('#error').html("general error");
			 window.location.href = "#chatPage";

			 
} 
  setTimeout('$("#error_1").hide("slow")',3000);
  setTimeout('$("#error").hide("slow")',3000); 
    
 }
 function cancelSuccess() {
 
  window.location.href = "#chatPage";
  $('#resultArea').append('<div id="invitation"> Invitation/Chat Cancel!</div>');
  $('#abort').hide('slow');
  $('#chatArea').hide('slow');
  $('#textInput').hide('slow');
  $('#error_1').hide();
  $('#resultArea').scrollTop(300000);
  
  }
 
 function cancelError(err) {
 
  $('#error').show();
  $('#error_1').show();
  
  if(err.status==403){
			 
			 $('#error').html("Invalid Session");
			  window.location.href = "#loginPage";
			 
}



if(err.status==404){
			 
			 $('#error_1').html("User is offline");
			 window.location.href = "#chatPage";
			 $('#chatArea').hide("slow");
			 $('#textInput').hide("slow");
			 $('#abort').hide("slow");
			
			 
}
 
if(err.status==500){
			 
			 $('#error').html("general error");
			 window.location.href = "#chatPage";

			 
} 

 setTimeout('$("#error_1").hide("slow")',3000);
 setTimeout('$("#error").hide("slow")',3000); 
  $('#chatArea').hide("slow");
  $('#textArea').hide("slow");
 
    
 }
 
 					
 $('#abort').click(function () {				
							
				   var data = {
		
	               "sessionID":ID,
	               "recipientMSISDN":MSISDN,
                         };
					 				        
            $.ajax({
            url: serviceURL + "/cancel-chat",
            type: "POST",
            contentType: "application/json",
            dataType: "json",
			data: JSON.stringify(data),
            success:cancelSuccess ,
			error: cancelError
           });  			 
						 
						 });
 
 
 
    $('#confirm').click(function () {
						 
						
      	                 generalKey = prompt("Enter Secret Key for chat with this user","");
		                 if (generalKey != '' && generalKey != null) {
 						 try{

                             var randomValue = GibberishAES.dec(sessionID,generalKey);

                        } catch(e) {
						
						 alert('Wrong key !!');
						 return;				 
						 }
						     
												
          				 var response = GibberishAES.enc(999999999-randomValue,generalKey);
						
						 var data = {
		
	               "sessionID":ID,
	               "recipientMSISDN":MSISDN,
                   "response": response

	                   };
					 				        
                        $.ajax({
            url: serviceURL + "/response-chat-invitation",
            type: "POST",
            contentType: "application/json",
            dataType: "json",
			data: JSON.stringify(data),
            success:responseSuccess ,
			error: responseError
           }); 
		   }
		   
		   
		    }); 
			
									
		 $('#reject').click(function () {				
							
				   var data = {
		
	               "sessionID":ID,
	               "recipientMSISDN":MSISDN,
                         };
					 				        
            $.ajax({
            url: serviceURL + "/cancel-chat",
            type: "POST",
            contentType: "application/json",
            dataType: "json",
			data: JSON.stringify(data),
            success:cancelSuccess ,
			error: cancelError
           });  			 
						 
						 });
$('#backb').click(function () {	
				 
				 
    $("#error_1").hide();

});				

$("#loginPage").ready(function() {

     var mobile = localStorage.getItem('mobileNumber');
	 var pass = localStorage.getItem('pass');
	 upgradeSpeed = localStorage.getItem('upgradeSpeed');
	 if(mobile && pass){
	 
	      $("#mobileNumber").val(mobile);
		  $("#pass").prop("type","password");
		  $("#pass").val(pass);
	 }
 
}); 
 
