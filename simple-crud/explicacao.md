// Modelo Latidor
\models
    pizza.py
        *Sabor
        *Tamanho
        *Preco
    cardapio.py
        *Pizzas
\services
    cardapio_service.py
        *cardapio_storage
        >AddPizza
            -> Inseriri pizzas no storage
        >BuscarPizza
            -> Buscar pizzas no storage
        >AlterarPizza
            -> Alterar pizzas no storage
        >RemovePizza
            -> Remover pizzas no storage
\storage
    cardapio_storage.py
        >AddPizza
            -> gravar no storage os dados de uma pizza
        >BuscarPizza
            -> buscar no storage os dados de uma pizza
        >AlterarPizza
            -> alterar no storage os dados de uma pizza
        >RemovePizza
            -> remover do storage os dados de uma pizza



# Modelo Cão que late (no futuro vamos falar disso)
\controllers    
    pizza.py
        *Sabor
        *Tamanho
        *Preco
        *pizza_storage
        >CriarPizza
        >AlterarPreco
        >ApagarPizza
    cardapio.py
        *Pizzas
        *cardapio_storage
        >AdicionarPizza
        >BuscarPizza    
        >RemoverPizza
\storage
    pizza_storage.py
        AddPizza
        BuscarPizza
        AlterarPizza
        RemovePizza
    cardapio_storage.py
        AddPizza
        BuscarPizza
        AlterarPizza
        RemovePizza
