Feature: Cadastra de Séries
	Eu sou professor e quero cadastrar uma série


@mytag
Scenario: Cadastrar uma nova Série
	Given Eu estou logado no site Diario Escolar
	And Estou na página principal
	When Eu clico no link Séries
	And Eu clico no link Cadastrar nova série
	And Eu preencho o formulário com os seguintes campos
		| Field | Value |
		| Ano   | 2012  |
		| Serie | 1B    |
	And Eu clico em Salvar
	Then Eu devo ser redirecionado para a página de listagem de séries e ver a mensagem "Série incluída com sucesso!"


