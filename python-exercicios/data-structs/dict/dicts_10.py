# Exercício Dicionários 10 - Sistema simples de cadastro de produtos
produtos = {}
while True:
    print("\nOpções: [1] Adicionar [2] Listar [3] Atualizar quantidade [4] Sair")
    op = input("Escolha: ").strip()
    if op == "1":
        nome = input("Nome do produto: ").strip()
        preco = float(input("Preço: "))
        qtd = int(input("Quantidade: "))
        produtos[nome] = {"preco": preco, "qtd": qtd}
        print("Produto adicionado.")
    elif op == "2":
        if not produtos:
            print("Nenhum produto cadastrado.")
        else:
            for nome, info in produtos.items():
                print(f"{nome} - Preço: {info['preco']} - Qtde: {info['qtd']}")
    elif op == "3":
        nome = input("Produto a atualizar: ").strip()
        if nome in produtos:
            qtd = int(input("Nova quantidade: "))
            produtos[nome]["qtd"] = qtd
            print("Quantidade atualizada.")
        else:
            print("Produto não encontrado.")
    elif op == "4":
        break
    else:
        print("Opção inválida.")
