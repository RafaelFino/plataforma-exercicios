# Exercício Filas 9 - Clonando filas
from collections import deque
orig = deque(["a","b","c","d","e"])
copia = deque(orig)  # cópia independente
print("Original:", list(orig))
print("Cópia:", list(copia))
