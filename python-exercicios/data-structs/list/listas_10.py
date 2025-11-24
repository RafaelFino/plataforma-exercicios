# Exercício Listas 10 - Filtrando elementos (pares)
entrada = input("Digite números separados por espaço: ").strip()
nums = [int(x) for x in entrada.split() if x]
pares = [n for n in nums if n % 2 == 0]
print("Números pares:", pares)
