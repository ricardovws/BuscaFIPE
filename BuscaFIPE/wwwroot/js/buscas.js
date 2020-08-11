
function limpaDados(id, dados) {
    var url = '/Home/LimpaDados?dados=' + dados
    $(id).load(url)
}


function buscaMarcas() {
  
    var url = '/Home/MostraMarcas?veiculo=' +
        getValue('opcoesVeiculos')

    $("#listaDeMarcas").load(url)

    limpaDados('#opcoesAnos', 'Anos')
    limpaDados('#opcoesModelos', 'Modelos')
    limpaDados('#veiculoSelecionado', 'Veiculo')

    $('#opcoesMarcas').focus()

}

function buscaModelos() {
   
    var url = '/Home/MostraModelos?veiculo=' +
        getValue('opcoesVeiculos') +
        '&codigoMarca=' +
        getValue('opcoesMarcas')

    $("#listaDeModelos").load(url)

    limpaDados('#opcoesAnos', 'Anos')
    limpaDados('#veiculoSelecionado', 'Veiculo')

    $('#opcoesModelos').focus()
}

function buscaAnos() {
    
    var url = '/Home/MostraAnos?veiculo=' +
        getValue('opcoesVeiculos') +
        '&codigoMarca=' +
        getValue('opcoesMarcas') +
        '&codigoModelo=' +
        getValue('opcoesModelos') 

    $("#listaDeAnos").load(url)

    limpaDados('#veiculoSelecionado', 'Veiculo')

    $('#opcoesAnos').focus()
}

function buscaVeiculo() {

    var url = '/Home/MostraVeiculo?veiculo=' +
        getValue('opcoesVeiculos') +
        '&codigoMarca=' +
        getValue('opcoesMarcas') +
        '&codigoModelo=' +
        getValue('opcoesModelos') +
        '&codigoAno=' +
        getValue('opcoesAnos')

    $("#veiculoSelecionado").load(url);

}

function getValue(id) {
    var element = document.getElementById(id)
    var elementValue = element.options[element.selectedIndex].value

    return elementValue;
}