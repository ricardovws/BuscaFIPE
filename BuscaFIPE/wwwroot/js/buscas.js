function buscaMarcas(veiculo) {

    var url = '/Home/MostraMarcas' + '?' + 'veiculo=' + veiculo
    //$.get(url, { veiculo: veiculo })
    
    $("#listaDeMarcas").load(url);
    $('#opcoesMarcas').focus()

}

