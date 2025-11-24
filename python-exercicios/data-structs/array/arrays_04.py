# Exercício Arrays 4 - Alterando valores
from array import array
arr = array('i', [0,1,2,3,4,5])
i = int(input("Digite o índice a alterar (0-based): "))
v = int(input("Digite o novo valor inteiro: "))
if 0 <= i < len(arr):
    arr[i] = v
    print("Array atualizado:", arr.tolist())
else:
    print("Índice fora do intervalo.")
