# Exercício Arrays 9 - Array de floats e média
from array import array
arr = array('f', [])
print("Digite 5 números decimais (um por linha):")
for _ in range(5):
    arr.append(float(input()))
media = sum(arr) / len(arr)
print("Array:", arr.tolist())
print("Média:", media)
