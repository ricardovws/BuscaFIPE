function buscaMarcas() {

    var veiculo = getValue('opcoesVeiculos')
    
    var url = '/Home/MostraMarcas' + '?' + 'veiculo=' + veiculo
    $("#listaDeMarcas").load(url);
    $('#opcoesMarcas').focus()

}

function buscaModelos() {

    var veiculo = getValue('opcoesVeiculos')
    var codigoMarca = getValue('opcoesMarcas')
   
    var url = '/Home/MostraModelos' + '?' + 'veiculo=' + veiculo + '&' + 'codigoMarca=' + codigoMarca
    $("#listaDeModelos").load(url);
}

function buscaAnos() {
    
    var veiculo = getValue('opcoesVeiculos')
    var codigoMarca = getValue('opcoesMarcas')
    var codigoModelo = getValue('opcoesModelos')

    var url = '/Home/MostraAnos' + '?' + 'veiculo=' + veiculo + '&' + 'codigoMarca=' + codigoMarca
        + '&' + 'codigoModelo=' + codigoModelo 
    
    $("#listaDeAnos").load(url);
}

function buscaVeiculo() {

    var veiculo = getValue('opcoesVeiculos')
    var codigoMarca = getValue('opcoesMarcas')
    var codigoModelo = getValue('opcoesModelos')
    var codigoAno = getValue('opcoesAnos')

    var url = '/Home/MostraVeiculo' + '?' + 'veiculo=' + veiculo + '&' + 'codigoMarca=' + codigoMarca
        + '&' + 'codigoModelo=' + codigoModelo + '&' + 'codigoAno=' + codigoAno
    
    $("#veiculoSelecionado").load(url);
}

function getValue(id) {
    var element = document.getElementById(id)
    var elementValue = element.options[element.selectedIndex].value

    return elementValue;
}