#!/usr/bin/env python3

file = input(">> Digite o nome do arquivo para contar linhas: ")

with open(file, "r") as f:
    lines = f.readlines()
    line_count = len(lines)
    print("## Número de linhas no arquivo: " + str(line_count)) 