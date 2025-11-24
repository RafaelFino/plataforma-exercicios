# Exercício Dicionários 5 - Removendo chave
aluno = {"nome": "João", "idade": 20, "curso": "Python Básico"}
curso = aluno.pop("curso", None)
print("Curso removido:", curso)
print("Dicionário agora:", aluno)
