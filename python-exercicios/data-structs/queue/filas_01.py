# Exercício Filas 1 - Criando uma fila
from collections import deque
fila = deque()
fila.extend(["Alice", "Bruno", "Carla"])
print("Fila:", list(fila))

while len(fila) > 0:
    atendido = fila.popleft()
    print("Atendendo:", atendido)
    print("Fila restante:", list(fila))