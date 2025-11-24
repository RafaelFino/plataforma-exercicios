# Exercício Listas 7 - Ordenando listas
nums = []
print("Digite 5 números (um por linha):")
for _ in range(5):
    nums.append(int(input()))
print("Original:", nums)
asc = sorted(nums)
desc = sorted(nums, reverse=True)
print("Ordem crescente:", asc)
print("Ordem decrescente:", desc)
