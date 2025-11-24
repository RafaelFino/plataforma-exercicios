# Exercício Arrays 8 - Convertendo lista para array
from array import array
entrada = input("Digite números separados por espaço: ").strip()
lista = [int(x) for x in entrada.split() if x]
arr = array('i', lista)
print("Array resultante:", arr.tolist())
