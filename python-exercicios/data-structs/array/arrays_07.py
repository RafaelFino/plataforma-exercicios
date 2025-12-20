# Exercício Arrays 7 - Removendo itens
from array import array
arr = array('i', [5,6,7, 7, 7, 8,9])
val = int(input("Digite valor a remover: "))
try:
    arr.remove(val)
    print("Valor removido. Array:", arr.tolist())
except ValueError:
    print("Valor não encontrado no array.")
