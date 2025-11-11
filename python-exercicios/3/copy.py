#!/usr/bin/env python3

file = input(">> Digite o nome do arquivo de origem: ")
dest_file = input(">> Digite o nome do arquivo de destino: ")

with open(file, "r") as f_src:
    content = f_src.read()
    with open(dest_file, "w") as f_dest:
        f_dest.write(content)