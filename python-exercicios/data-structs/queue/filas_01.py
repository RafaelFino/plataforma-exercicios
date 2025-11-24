# Exercício Filas 1 - Criando uma fila
from collections import deque
fila = deque()
fila.extend(["Alice", "Bruno", "Carla"])
print("Fila:", list(fila))
