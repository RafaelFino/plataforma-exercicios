#!/usr/bin/env python3

file = input(">> Digite o nome do arquivo para ler: ")
with open(file, "r") as f:
    content = f.read()
    print("## Conteúdo do arquivo:\n" + content)

    