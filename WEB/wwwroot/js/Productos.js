function seleccionarProducto() {
    var codigoCompra = $('#compra').val();

    if (codigoCompra !== '') {
        $.ajax({
            type: 'GET',
            url: '/Home/ConsultaProducto',
            dataType: 'json',
            data: {
                codigoCompra
            },
            success: function (response) {
                $('#saldoAnterior').val(response.saldo);
                $('#MontoAbono').attr('max', response.saldo);
                $('#MontoAbono').val(0);
                $('#abonar').removeAttr('disabled');
                $('#CodigoCompraPrincipalID').val(codigoCompra);
            }
        });
    }
}

function limpiarCampos() {
    $('#saldoAnterior').val('');
    $('#MontoAbono').val('0');
    $('#MontoAbono').attr('max', '1');
    $('#abonar').attr('disabled', 'true');
}