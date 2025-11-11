#!/usr/bin/env python3

num = int(input(">> Digite um número para calcular o fatorial: "))
fatorial = 1
for i in range(2, num + 1):
    fatorial *= i   

print("## O fatorial de " + str(num) + " é " + str(fatorial))