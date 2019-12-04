


function CallOutMessage(Type, Header, Message) {
    if (Type == 'success') {
        $('.callout').addClass('callout-success');
    }
    else if (Type == 'error') {
        $('.callout').addClass('callout-danger');
    }
    else {
        $('callout').hide();
        return;
    }

    $('#callOutHeader').html(Header);
    $('#callOutMessage').html(Message);
    $('.callout').show();
}