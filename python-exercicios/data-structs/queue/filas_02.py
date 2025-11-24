# Exercício Filas 2 - Enfileirar
from collections import deque
fila = deque()
print("Digite 3 nomes que chegaram:")
for _ in range(3):
    fila.append(input().strip())
print("Fila atual:", list(fila))
