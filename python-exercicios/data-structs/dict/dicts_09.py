# Exercício Dicionários 9 - Contando frequência de palavras
texto = input("Digite uma frase: ").strip().lower()
palavras = texto.split()
freq = {}
for p in palavras:
    freq[p] = freq.get(p, 0) + 1
print("Frequência de palavras:")
for palavra, cont in freq.items():
    print(f"'{palavra}': {cont}")
