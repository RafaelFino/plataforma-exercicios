# Exercício Filas 10 - Simulação completa - caixa de banco
from collections import deque
fila = deque()
print("Simulação de fila: digite 'chegou' para adicionar cliente, 'atender' para atender, 'sair' para encerrar.")
while True:
    cmd = input("Comando: ").strip().lower()
    if cmd == "chegou":
        nome = input("Nome do cliente: ").strip()
        fila.append(nome)
        print("Cliente adicionado.")
    elif cmd == "atender":
        if fila:
            print("Atendendo:", fila.popleft())
        else:
            print("Fila vazia.")
    elif cmd == "sair":
        break
    else:
        print("Comando inválido.")
    print("Estado atual da fila:", list(fila))
