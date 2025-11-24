# Exercício Filas 8 - Fila com prioridade simples
from collections import deque
fila_normal = deque()
fila_prio = deque()
# exemplo: adicionar alguns
fila_normal.extend(["N1","N2"])
fila_prio.extend(["P1"])
# ao atender:
def atender():
    if fila_prio:
        return fila_prio.popleft()
    elif fila_normal:
        return fila_normal.popleft()
    else:
        return None
print("Atendendo:", atender())
print("Filas agora - Prioritária:", list(fila_prio), "Normal:", list(fila_normal))
