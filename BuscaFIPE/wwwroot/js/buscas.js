function buscaMarcas(veiculo) {

    var url = '/Home/MostraMarcas' + '?' + 'veiculo=' + veiculo
    $("#listaDeMarcas").load(url);
    $('#opcoesMarcas').focus()

}

function buscaModelos(codigoMarca) {

    var e = document.getElementById('opcoesVeiculos');
    var veiculo = e.options[e.selectedIndex].value;

   
    var url = '/Home/MostraModelos' + '?' + 'veiculo=' + veiculo + '&' + 'codigoMarca=' + codigoMarca
    $("#listaDeModelos").load(url);
}

function buscaAnos(codigoModelo) {
    var v = document.getElementById('opcoesVeiculos');
    var veiculo = v.options[v.selectedIndex].value;

  

    var m = document.getElementById('opcoesMarcas');
    var codigoMarca = m.options[m.selectedIndex].value;

   

    var url = '/Home/MostraAnos' + '?' + 'veiculo=' + veiculo + '&' + 'codigoMarca=' + codigoMarca
        + '&' + 'codigoModelo=' + codigoModelo 
    
    $("#listaDeAnos").load(url);
}

function buscaVeiculo(codigoAno) {
    var v = document.getElementById('opcoesVeiculos');
    var veiculo = v.options[v.selectedIndex].value;

    var m = document.getElementById('opcoesMarcas');
    var codigoMarca = m.options[m.selectedIndex].value;

    var mo = document.getElementById('opcoesModelos');
    var codigoModelo = mo.options[mo.selectedIndex].value;

    var url = '/Home/MostraVeiculo' + '?' + 'veiculo=' + veiculo + '&' + 'codigoMarca=' + codigoMarca
        + '&' + 'codigoModelo=' + codigoModelo + '&' + 'codigoAno=' + codigoAno
    debugger;
    $("#veiculoSelecionado").load(url);
}