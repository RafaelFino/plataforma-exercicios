# Exercício Dicionários 7 - Dicionário de listas (média)
aluno = {"nome": input("Nome do aluno: ").strip(), "notas": []}
print("Digite 4 notas (uma por linha):")
for _ in range(4):
    aluno["notas"].append(float(input()))
media = sum(aluno["notas"]) / len(aluno["notas"])
print("Aluno:", aluno["nome"])
print("Notas:", aluno["notas"])
print("Média:", media)
