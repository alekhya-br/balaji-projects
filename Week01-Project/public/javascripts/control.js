$(document).ready(function() { 'use strict';
    $('#submit').click(insertOrder);
});

function insertOrder() {
    $('#myList').html('');

    var currentdate = new Date();
    var datetime = currentdate.getHours() + ":" + currentdate.getMinutes() + ":" + currentdate.getMilliseconds();

    var storeNumber = [98053 , 98007, 98077, 98055, 98011, 98046];
    var itemNumber = [123456, 123654, 321456, 321654, 654123,
        654321, 543216, 354126, 621453, 623451];
    var storeRandom = Math.floor(Math.random()* store.length);
    var personID = Math.floor((Math.random()* 24)+1);
    var itemNumberRandom = Math.floor(Math.random() * itemNumber.length);
    var price = Math.floor(Math.random() * (15 - 5 + 1) + 5);

    var order = {
        "itemNumber" : itemNumber[itemNumberRandom],
        "timePurch" : datetime,
        "storeNumber":storeNumber[storeRandom],
        "pricePaid":price,
        "salesPersonID":personID
    }

    for (var property in order) {
        if (order.hasOwnProperty(property)) {
            var jsonString = JSON.stringify(order);
            $.each(JSON.parse(jsonString), function(key, value) {
                $('#myList').append('<li>' + key + '' + value + '</li>')
            })
        }
    }

}