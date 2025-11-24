#!/usr/bin/env python3

file = input(">> Digite o nome do arquivo para escrever: ")
with open(file, "w") as f:
    content = input(">> Digite o conteúdo para escrever no arquivo: ")
    f.write(content)    