$("#btnSearch").click(function () {
    ListaData();
});

function ListaData() {
    var Url = "/Produtos/getProdutosPorNome"
    $.ajax({
        url: Url,
        type: "POST",
        success: function (response) {
            var tHTML = '';
            $.each(response, function (i, item) {
                tHTML += "<tr>" +
                    "<td>" + item.ID + "</td>" +
                    "<td>" + item.ProdutoName + "</td>" +
                    "<td>" + item.Valor + "</td>" +
                    "<td>" + item.Descricao + "</td>" +
                    "</tr>"
            });
            $("#tblProdutos").append(tHTML);
        }
    });
}