# Exercício Listas 4 - Adicionando elementos ao final
frutas = ["maçã", "banana", "laranja"]
print("Adicione 3 frutas (pressione Enter após cada uma):")
for _ in range(3):
    f = input().strip()
    frutas.append(f)
print("Lista final:", frutas)
