function guid() {
    function s4() {
        return Math.floor((1 + Math.random()) * 0x10000)
          .toString(16)
          .substring(1);
    }
    return s4() + s4() + '-' + s4() + '-' + s4() + '-' +
      s4() + '-' + s4() + s4() + s4();
}

var Order = function () {
    var self = this;
    this.Id = ko.observable(guid());
    this.Client = ko.observable('Jesus Angulo');
    this.Amount = ko.observable(141192);
    this.Completado = ko.observable(false);
    this.Completar = function () {
        self.Completado(true);
    }
}