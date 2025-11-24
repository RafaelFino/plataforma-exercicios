# Exercício Arrays 5 - Adicionando valores
from array import array
arr = array('i', [1,2,3])
v = int(input("Digite um inteiro para adicionar ao final: "))
arr.append(v)
print("Array:", arr.tolist())
