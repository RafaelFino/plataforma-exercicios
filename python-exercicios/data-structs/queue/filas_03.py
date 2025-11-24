# Exercício Filas 3 - Desenfileirar
from collections import deque
fila = deque(["João","Maria","Pedro"])
atendido = fila.popleft()
print("Atendido:", atendido)
print("Fila agora:", list(fila))
