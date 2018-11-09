
console.log('test!');

$(document).ready(function docReady() {

        $('#submit-btn').on('click', submitUser);



$('#popup-btn').magnificPopup({
    
        type: 'inline',
        items: {src: '#modal'},
        preloader: false,
        modal: true
    });

});

function submitUser()
{

    console.log('clicked submit button');
    var first_name = $('#first_name').val();
    var last_name = $('#last_name').val();
    var email = $('#email').val();
    var pwd = $('#pwd').val();
    console.log('first_name: ' + first_name);
    console.log('last_name: ' + last_name);
    console.log('email: ' + email);
    console.log('pwd: ' + pwd);

    var ajaxAddress = 'api/customer/insertuser/?firstname='+first_name+'&lastname='+last_name+'&email='+email+'&pass='+pwd;        
    ///api/events/GetPreviewImageLocation/?eventImageLocation=
                $.ajax(ajaxAddress,
                                {
                                    async: true,
                                    type: 'POST',
                                    data: null,
                                    contentType: false,
                                    processData: false,
                                    success: function(data)
                                    {
                                        console.log('success');
                                    },
                                    cache: false,
                                    contentType: false,
                                    processData: false

                                    });
console.log('after ajax');

}