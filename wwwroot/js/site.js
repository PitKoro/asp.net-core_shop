function addToCart(id) {
    console.log(`Input: ${typeof(id)}`);
    $.post("Cart/AddToCart", { id: id })
        .done(function (data) {
            console.log(`output ${data}`);
        });
}