class Pizza:    
    Sabor = ""
    Tamanho = ""
    Valor = 0.0

class Cardapio:
    Pizzas = []

    def add_pizza(self, pizza):
        self.Pizzas.append(pizza)

    def listar_pizzas(self) -> list:
        return self.Pizzas
    
    def buscar_pizza_por_sabor(self, sabor: str) -> list:
        ret = []
        for pizza in self.Pizzas:
            if pizza.Sabor.lower().find(sabor.lower()) != -1:
                ret.append(pizza)
        
        return ret
    
    def remover_pizza_por_sabor(self, sabor: str) -> bool:
        for pizza in self.Pizzas:
            if pizza.Sabor.lower() == sabor.lower():
                self.Pizzas.remove(pizza)
                return True
        return False
        
    def atualizar_valor_pizza(self, sabor: str, novo_valor: float):
        for pizza in self.Pizzas:
            if pizza.Sabor.lower().find(sabor.lower()) != -1:
                pizza.Valor = novo_valor

def inicializar_cardapio_padrao() -> Cardapio:
    cardapio = Cardapio()

    pizza1 = Pizza()
    pizza1.Sabor = "Margherita"
    pizza1.Tamanho = "Média"
    pizza1.Valor = 25.0
    cardapio.add_pizza(pizza1)

    pizza2 = Pizza()
    pizza2.Sabor = "Pepperoni"
    pizza2.Tamanho = "Grande"
    pizza2.Valor = 30.0
    cardapio.add_pizza(pizza2)

    pizza3 = Pizza()
    pizza3.Sabor = "Quatro Queijos"
    pizza3.Tamanho = "Pequena"
    pizza3.Valor = 20.0
    cardapio.add_pizza(pizza3)

    pizza4 = Pizza()
    pizza4.Sabor = "Frango com Catupiry"
    pizza4.Tamanho = "Média"
    pizza4.Valor = 28.0
    cardapio.add_pizza(pizza4)

    pizza5 = Pizza()
    pizza5.Sabor = "Calabresa"
    pizza5.Tamanho = "Grande"
    pizza5.Valor = 27.0
    cardapio.add_pizza(pizza5)

    pizza6 = Pizza()
    pizza6.Sabor = "Portuguesa"
    pizza6.Tamanho = "Média"
    pizza6.Valor = 29.0
    cardapio.add_pizza(pizza6)

    pizza7 = Pizza()
    pizza7.Sabor = "Dois Queijos"
    pizza7.Tamanho = "Pequena"          
    pizza7.Valor = 22.0
    cardapio.add_pizza(pizza7)

    return cardapio    

Cardapio = inicializar_cardapio_padrao()

print("Cardápio de Pizzas:")
for pizza in Cardapio.listar_pizzas():
    print(f"\tSabor: {pizza.Sabor}, Tamanho: {pizza.Tamanho}, Valor: R$ {pizza.Valor:.2f}")


print("\nAtualizando valor da pizza Pepperoni:")
if Cardapio.atualizar_valor_pizza("Pepperoni", 32.0):
    print("Valor atualizado com sucesso.")


print("\nBuscando pizzas:")
pizzas_encontradas = Cardapio.buscar_pizza_por_sabor("pep")
for pizza in pizzas_encontradas:
    print(f"\tSabor: {pizza.Sabor}, Tamanho: {pizza.Tamanho}, Valor: R$ {pizza.Valor:.2f}")       


    