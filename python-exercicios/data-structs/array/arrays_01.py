# Exercício Arrays 1 - Criando um array de inteiros
from array import array
arr = array('i', [int(input(f"Digite inteiro {_+1}: ")) for _ in range(5)])
print("Array:", arr.tolist())
