# Exercício Listas 9 - Lista com loop (soma)
nums = []
print("Digite 5 números (um por linha):")

for _ in range(5):
    nums.append(float(input()))
soma = 0

# jeito bonito
for n in nums:
    print("Número:", n)
    soma += n



for n in nums:
    soma += n
print("Números:", nums)
print("Soma total:", soma)
