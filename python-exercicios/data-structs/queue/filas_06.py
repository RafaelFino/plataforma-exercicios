# Exercício Filas 6 - Fila com loop de atendimento
from collections import deque
fila = deque(["C1","C2","C3","C4","C5"])
while fila:
    atual = fila.popleft()
    print("Atendendo:", atual)
print("Todos atendidos.")
