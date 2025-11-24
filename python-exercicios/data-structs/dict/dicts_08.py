# Exercício Dicionários 8 - Dicionário de dicionários (turma)
turma = {
    "ana": {"idade": 19, "nota": 8.5},
    "bruno": {"idade": 21, "nota": 7.0},
    "carla": {"idade": 20, "nota": 9.2},
}
aluno = input("Digite o nome do aluno para ver a nota: ").strip()
if aluno in turma:
    print(f"Nota de {aluno}:", turma[aluno]["nota"])
else:
    print("Aluno não encontrado na turma.")
