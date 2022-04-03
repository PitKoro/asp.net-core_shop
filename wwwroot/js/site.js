function addToCart(id) {
    $.post("Cart/AddToCart", { id: id })
        .done(function (data) {
            console.log(`output ${data}`);
        });
}