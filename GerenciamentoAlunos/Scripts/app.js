var GerenciamentoAlunos = (function () {

    var urlApi = "api/Alunoes/";

    var criarItemAluno = function (aluno) {

        var conteudo = "";

        for (var key in aluno) {
            conteudo += "<td>" + aluno[key] + "</td>";
        }

        var btnAtualizar = '<button type="button" class="btn btn-default" onclick="GerenciamentoAlunos.SetCurrentAluno(' + aluno.Id + ')"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></button>';
        var btnRemover = '<button type="button" class="btn btn-default" onclick="GerenciamentoAlunos.Delete(' + aluno.Id + ')"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></button>';

        return "<tr>" + conteudo + "<td>" + btnAtualizar + "</td><td>" + btnRemover + "</td>" + "</tr>";
    }

    var mensagemAlunos = '<tr class="alunos-vazio"><td colspan="4" style="text-align: center">Não há alunos cadastrados.</td></tr>';

    var buscarAlunos = function (url, sucesso, erro) {
        $.getJSON(url, function (dados) {
            sucesso(dados);
        }).fail(function () {
            erro();
        });
    }

    return {
        CarregarAlunos: function () {

            var url = urlApi;
            var ra = $("#raAluno").val();
            if (ra) {
                url += ra;
            }

            buscarAlunos(url, function (alunos) {
                $(".todos-alunos").empty();

                console.log(alunos);
                if (alunos.length === 0) {
                    $(".todos-alunos").append(mensagemAlunos);
                    return;
                }

                for (var i = 0; i < alunos.length; i++) {
                    $(".todos-alunos").append(criarItemAluno(alunos[i]));
                }
            }, function () {
                $(".todos-alunos").empty();
                $(".todos-alunos").append(mensagemAlunos);
            });

        },
        AddOrUpdate: function () {
            var self = this;
            var aluno = {
                Ra: $("#inputRA").val(),
                Nome: $("#inputNome").val(),
                Cidade: $("#inputCidade").val()
            };

            var id = $("#hdIdAluno").val();
            var url = urlApi;
            if (id) {
                aluno.Id = id;
                url += id;
            }

            $.post(url, aluno, function (data) {
                console.log(data);
                self.CarregarAlunos();
            });

            $(".add-or-update-aluno input").val("");
            return false;
        },
        SetCurrentAluno: function (alunoId) {

            var url = urlApi + "id/" + alunoId;

            buscarAlunos(url, function (alunos) {
                if (alunos.length > 1) {
                    alert("Ocorreu um erro.");
                    return;
                }
                var aluno = alunos[0];

                $("#inputRA").val(aluno.Ra);
                $("#inputNome").val(aluno.Nome);
                $("#inputCidade").val(aluno.Cidade);
                $("#hdIdAluno").val(aluno.Id);

            }, function () {
                alert("Ocorreu um erro.");
            });
        },
        Delete: function (idAluno) {
            var self = this;
            var url = urlApi + "apagar/" + idAluno;

            $.post(url, function (data) {
                console.log(data);
                self.CarregarAlunos();
            });
        },
        Init: function () {
            var self = this;
            $(document).ready(function () {
                self.CarregarAlunos();
            });
            return self;
        }
    }
}()).Init();