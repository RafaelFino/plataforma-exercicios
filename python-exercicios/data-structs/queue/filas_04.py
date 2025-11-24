# Exercício Filas 4 - Verificando o próximo
from collections import deque
fila = deque(["A","B","C"])
if fila:
    print("Próximo da fila:", fila[0])
else:
    print("Fila vazia.")
