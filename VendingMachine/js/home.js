$(document).ready(function()
{
loadVendingItems();

var amount = 0;
var quarters = 0;
var dime = 0;
var nickel = 0;
var penny = 0;

function loadVendingItems(){
    clearVendingTables();

    var boxOne = $('#snickers');
    var boxTwo = $('#mms');
    var boxThree = $('#pringles');
    var boxFour = $('#reeses');
    var boxFive = $('#pretzels');
    var boxSix = $('#twinkies');
    var boxSeven = $('#doritos');
    var boxEight = $('#almondjoy');
    var boxNine = $('#trident');

    $.ajax ({
        type: 'GET',
        url: 'http://localhost:8080/items',
        success: function (data, status){
            $.each(data, function(index, item){
                var id = item.id;
                var name = item.name;
                var price = item.price;
                var quantity = item.quantity;

                var row = '<tr>';
                    row += '<td>' + id + '</td>'+'<tr>';
                    row += '<tr>'+'<td>' + name + '</td>'+'<tr>';
                    row += '<tr>'+'<td>'+"$" + price.toFixed(2) + '</td>'+'<tr>';
                    row += '<tr>'+'<td>' + "Quantity Left: " + quantity + '</td>';
                    row += '</tr>';

                    switch (id) {
                        case 1:
                            boxOne.append(row);
                            break;
                        case 2:
                            boxTwo.append(row);
                            break;
                        case 3:
                            boxThree.append(row);
                            break;
                        case 4:
                            boxFour.append(row);
                            break;
                        case 5:
                            boxFive.append(row);
                            break;
                        case 6:
                            boxSix.append(row);
                            break;
                        case 7:
                            boxSeven.append(row);
                            break;
                        case 8:
                            boxEight.append(row);
                            break;
                        case 9:
                            boxNine.append(row);
                            break;
                        default:
                            break;
                    }

            });
        },
        error: function(){
            $('#errorMessages')
            .append($('<li>')
                .attr({class: 'list-group-item list-group-item-danger'})
                .text('Error calling web service.  Please try again later.'));
        }
    });
}

$('#makePurchase').on('click', function(){
    if($('#itemToPurchase').val() == "")
    {
        $('#messages').val('Please make a selection')
        return;
    }
    makePurchase();
})

function makePurchase(){
    
    var purchaseAmount = $('#moneyIn').val();

    $.ajax({
        type:'GET',
        url: 'http://localhost:8080/money/'+purchaseAmount+'/item/'+ $('#itemToPurchase').val(),
        success: function(data){
            var message="";
            for(var key in data){
                message +=key + " : " + data[key]+", ";
            }
            message = message.substring(0,message.length-1);
            $('#change').val(message);
            $('#messages').val("Thank you!")
            loadVendingItems();
            amount = 0;
            $('#moneyIn').val(amount.toFixed(2));
        },
        
        error: function(data,status,error){
            $('#messages').val(data.responseJSON.message);
            console.log(data);
        }
    })
}

function enterItem(id){
    $('#itemToPurchase').val(id)
}

$('#snicker').on('click',function(){
    enterItem(1)
});

$('#mm').on('click',function(){
    enterItem(2)
});

$('#pringle').on('click',function(){
    enterItem(3)
});

$('#reese').on('click',function(){
    enterItem(4)
});

$('#pretzel').on('click',function(){
    enterItem(5)
});

$('#twinkie').on('click',function(){
    enterItem(6)
});

$('#dorito').on('click',function(){
    enterItem(7)
});

$('#almondjoys').on('click',function(){
    enterItem(8)
});

$('#tridents').on('click',function(){
    enterItem(9)
});

$('#changeReturn').on('click', function(){
    $('#messages').val('');
    $('#change').val('');
    $('#moneyIn').val('0.00')
    amount *=100;
    quarters = Math.floor(amount /25);
    amount -= (quarters * 25)
    dime = Math.floor(amount/ 10);
    amount -= (dime * 10)
    nickel = Math.floor(amount / 5);
    amount -= (nickel * 5)
    penny = Math.floor(amount / 1);
    amount -= (penny)
    $('#change').val('quarters: '+quarters + ', dimes: '+ dime+', nickels: '+nickel+', pennies: '+penny);
    $('#itemToPurchase').val('')
})

function clearVendingTables(){
    $('#snickers').empty();
    $('#mms').empty();
    $('#pringles').empty();
    $('#reeses').empty();
    $('#pretzels').empty();
    $('#twinkies').empty();
    $('#doritos').empty();
    $('#almondjoy').empty();
    $('#trident').empty();
}

$('#addDollar').on('click', function(){
    amount += 1.00;
    $('#moneyIn').val(amount.toFixed(2))
});

$('#addDime').on('click', function(){
    amount += .10;
    $('#moneyIn').val(amount.toFixed(2))
});

$('#addQuarter').on('click', function(){
    amount += .25;
    $('#moneyIn').val(amount.toFixed(2))
});

$('#addNickel').on('click', function(){
    amount += .05;
    $('#moneyIn').val(amount.toFixed(2))
});

});

