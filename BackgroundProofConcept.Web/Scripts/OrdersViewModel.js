var OrdersViewModel = function () {
    var self = this;
    var orderHub = $.connection.ordenesHub;    

    this.Orders = ko.observableArray([]);

    this.Order = ko.observable(new Order());

    this.showNewOrderDialog = function () {
        $('#modal').modal();
    };

    this.save = function () {
        var request = ko.mapping.toJS(self.Order());
        orderHub.server.sendOrder(request).done(function () {
            self.Orders.push(self.Order());
            self.Order(new Order());
            $('#modal').modal('hide');
        });
    };


    orderHub.client.doneOrder = function (id) {
        for (var i = 0; i < self.Orders().length; i++) {
            var o = self.Orders()[i];
            if (o.Id() == id) o.Completar();
        }
    };

    $.connection.hub.start();

}