# Exercício Listas 6 - Removendo elementos da lista
frutas = ["maçã", "banana", "laranja"]
item = input("Digite o nome da fruta a remover: ").strip()
if item in frutas:
    frutas.remove(item)
    print(f"'{item}' removida. Lista agora:", frutas)
else:
    print(f"A fruta '{item}' não está na lista.")
