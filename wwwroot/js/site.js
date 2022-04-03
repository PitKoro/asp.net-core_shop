function addToCart(id) {
    $.post("Cart/AddToCart", { id: id })
        .done(function (data) {
            $(".js-cart-text-with-quantity").empty().append(`КОРЗИНА (${JSON.parse(data).totalQuantity})`);
            console.log(`output ${JSON.parse(data).totalQuantity}`);
        });
}