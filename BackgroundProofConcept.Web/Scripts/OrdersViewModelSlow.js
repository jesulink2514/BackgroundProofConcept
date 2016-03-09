var OrdersViewModel = function () {
    var self = this;
    
    this.Orders = ko.observableArray([]);

    this.Order = ko.observable(new Order());

    this.IsLoading = ko.observable(false);

    this.showNewOrderDialog = function () {
        $('#modal').modal();
    };

    this.save = function () {
        var request = ko.mapping.toJS(self.Order());
        self.IsLoading(true);
        $.ajax({
            url: '/Home/sendOrder',
            method: "post",
            contentType:"json",
            data:request            
        }).done(function () {
            self.IsLoading(false);
            self.Orders.push(self.Order());
            self.Order(new Order());
            $('#modal').modal('hide');            
        });
    };
}