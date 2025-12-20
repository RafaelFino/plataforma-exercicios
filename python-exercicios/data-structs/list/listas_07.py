import random
from datetime import datetime as Datetime
# Exercício Listas 7 - Ordenando listas
nums = []

for i in range(10000000):
    v = random.randint(0, i+1)
    nums.append(v)

start = Datetime.now()
asc = sorted(nums)
desc = sorted(nums, reverse=True)
elapsed = Datetime.now() - start

print("Tempo de ordenação:", elapsed)
# print("Ordem crescente:", asc)
# print("Ordem decrescente:", desc)
