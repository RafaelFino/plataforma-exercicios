# Exercício Arrays 10 - Comparação prática array vs lista (memória)
from array import array
import sys
lista = [i for i in range(100000)]
arr = array('i', lista)
print("Tamanho em bytes (lista):", sys.getsizeof(lista))
print("Tamanho em bytes (array):", sys.getsizeof(arr))
print("Informação adicional do array (buffer_info):", arr.buffer_info())
