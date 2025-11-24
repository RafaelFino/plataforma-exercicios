#!/usr/bin/env python3

print(">> Digite uma lista de números (separados por espaço) para calcular a média:")
numeros = input(">> Números: ")
lista_numeros = [float(num) for num in numeros.split()]
media = sum(lista_numeros) / len(lista_numeros)
print("## A média é " + str(media))