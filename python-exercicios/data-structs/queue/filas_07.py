# Exercício Filas 7 - Sistema de senha
from collections import deque
fila = deque()
senha_atual = 0
while True:
    op = input("Digite 'gerar', 'atender' ou 'sair': ").strip().lower()
    if op == "gerar":
        senha_atual += 1
        fila.append(senha_atual)
        print(f"Senha gerada: {senha_atual}")
    elif op == "atender":
        if fila:
            s = fila.popleft()
            print(f"Atendendo senha: {s}")
        else:
            print("Nenhuma senha na fila.")
    elif op == "sair":
        break
    else:
        print("Opção inválida.")
