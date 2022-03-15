var index = {
    api_url = "https://localhost:5000/api/",
    onLoad: function () {
        debugger;
        this.getCart();
    },

    getCart: function () {
        Core.CallAPI("GET", "cart/", null, function () { alert("test"); }, "false");
    }
}

$(document).ready(function () {
    index.onLoad();
});