const uri = 'api/storefront';
let products = null;
let order = [];
let numberOfItems = 0;

$(document).ready(function () {
    getData();
});

//gets and displays intial Json from controller
function getData() {
    $.ajax({
        type: 'GET',
        url: uri,
        success: function (data) {
            $('#title').empty();
            $('#products').empty();

            //title
            $('<span class="text-center">Storefront</span>').appendTo($('#title'));

            //product list headers
            $('<div class="col-lg-6 text-right "><h3>Name</h3></div>' +
                '<div class="col-lg-6 text-left"><h3>Price</h3></div>').appendTo($('#products'));
            //checkout button
            $('<button onclick="submit()">Checkout</button>').appendTo($('#submit'));
            $.each(data, function (index, item) {
               
                $('<div class="col-lg-6 text-right">' + item.name + '</div>' +
                    //Displays price as USD 
                    '<div class="col-lg-1 center-block">' + item.price.toLocaleString("en-US", { style: "currency", currency: "USD" }) + '</div>' +
                    //Add to cart button
                    '<div class="col-lg-5 text-left"><button onclick="addItem(' + item.id + ')">Add To Cart</button></div>'
                    ).appendTo($('#products'));
            });

            products = data;
        }
    });
}

//Adds selected items to order, increments numberOfItems and displays a count of selected items
function addItem(id) { 
    $.each(products, function (key, item) {
        if (item.id === id) {
            order.push(item);
            numberOfItems++;
        }       
    });
    $('#orderItems').empty();
    $('<span>Items in Cart ' + numberOfItems + '</span>').appendTo($('#orderItems'));
}

//Sends order items back to controller and displays returned reciept data
function submit() {
    
    $.ajax({
        type: 'POST',
        accepts: 'application/json',
        url: uri,
        contentType: 'application/json',
        data: JSON.stringify(order),
        error: function (jqXHR, textStatus, errorThrown) {
            alert('here');
        },
        success: function (data) {

                $('#title').empty();
                $('#products').empty();
                $('#submit').empty();
                $('#orderItems').empty();

               //title
                $('<span>Reciept</span>').appendTo($('#title'));

                //Displays order product names and prices after taxes in USD
                for (var i = 0; i < data.orderItems.length; i++) {
                    $('<div class="col-lg-12">' + data.orderItems[i].key + ':' +
                        data.orderItems[i].value.toLocaleString("en-US", { style: "currency", currency: "USD" })
                        + '</div>').appendTo($('#products'));
                };

                //Displays order total and total sales taxes in USD
                $('<div class="col-lg-12"> Sales Taxes: ' + data.salesTaxes.toLocaleString("en-US", { style: "currency", currency: "USD" })
                    + '</div>' +
                    '<div class="col-lg-12"> Total: ' + data.total.toLocaleString("en-US", { style: "currency", currency: "USD" })
                    + '</div>').appendTo($('#products'));

       
        }
    });
}

