# Exercício Arrays 6 - Inserindo valores no meio
from array import array
arr = array('i', [1,2,3,4])
pos = int(input(f"Digite posição para inserir (0 a {len(arr)}): "))
val = int(input("Digite valor inteiro: "))
if 0 <= pos <= len(arr):
    arr.insert(pos, val)
    print("Array:", arr.tolist())
else:
    print("Posição inválida.")
