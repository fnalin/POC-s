(function () {
    this.url = "http://localhost:51882/api/Pessoas/GetPessoasAsync?";
    this.params = { nome: "", cpf: "" };

    $("#dadosText").on('change keydown paste input', function () {
        params.nome = params.cpf = "";
        var texto = this.value;

        if (isNaN(texto))
            params.nome = texto;
        else
            params.cpf = texto;
    });

    $("#dadosText").autocomplete({
        minLength: 2,
        source: function (request, response) {
            $.ajax({
                url: url + $.param(params),
                dataType: "json",
                type: 'GET',
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            label: item.Nome + " " + item.CPF,
                            id: item.Id,
                            nome: item.Nome,
                            cpf: item.CPF
                        };
                    }));
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    if (XMLHttpRequest.status === 404)
                        response(null);
                    else
                        alert('status:' + XMLHttpRequest.status + ', status text: ' + XMLHttpRequest.statusText);
                },
            });
        },


        select: function (event, ui) {
            $(this).val("");
            var $tr = $("<tr />");
            $("<td />").text(ui.item.id).appendTo($tr);
            $("<td />").text(ui.item.nome).appendTo($tr);
            $("<td />").text(ui.item.cpf).appendTo($tr);
            $("#tabelaPessoas>table>tbody").append($tr);
            event.preventDefault();
        },


    });
})();