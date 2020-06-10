window.functions = {
    layout: {
        configNav: function () {
            $(".sidebar-menu").tree();
        }
    },
    util: {
        iCheck: function(inputName) {
            $(inputName).iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' 
            });
        },
        onOpenModal: function (modalName) {
            console.log("sdsd")
            $("#" + modalName).modal("show");
        },
        onCloseModal: function (modalName) {
            $("#" + modalName).modal("hide");
        }
    }
}