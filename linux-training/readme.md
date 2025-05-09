# 🧑‍🏫 Guia para os Alunos: Usando GitHub Codespaces com Linux

## ✅ Pré-requisitos

- Ter acesso à internet  
- Um navegador atualizado (Chrome, Firefox, Edge etc.)

---

## 🔹 Passo 1: Criar uma Conta no GitHub

1. Acesse: [https://github.com](https://github.com)
2. Clique em **Sign up** (cadastrar).
3. Preencha os campos:
   - Nome de usuário
   - E-mail
   - Senha
4. Confirme o e-mail acessando sua caixa de entrada e clicando no link enviado pelo GitHub.
5. Finalize as configurações iniciais sugeridas (pode pular se preferir).

---

## 🔹 Passo 2: Acessar o Repositório com os Exercícios

1. Entre com sua conta no GitHub.
2. Acesse este link:  
   👉 [https://github.com/RafaelFino/Linux-prepare](https://github.com/RafaelFino/Linux-prepare)

---

## 🔹 Passo 3: Abrir o Repositório no Codespaces

1. No canto superior direito da página do repositório, clique no botão verde **Code**.
2. Clique na aba **Codespaces**.
3. Clique em **Create codespace on main**.
4. Aguarde alguns minutos até que o ambiente seja criado. Ele abrirá automaticamente com um terminal e editor de arquivos.

> ⚠️ Caso o botão "Codespaces" não apareça, peça aos alunos para habilitarem o Codespaces:
> - Acesse [https://github.com/codespaces](https://github.com/codespaces)
> - Clique em “Try Codespaces” ou "Create Codespace" e autorize se necessário

---

## 🔹 Passo 4: Executar o Script de Preparação do Ambiente

Com o terminal já aberto no Codespaces:

1. Rode o seguinte comando no terminal:

```bash
bash <(curl -s https://raw.githubusercontent.com/RafaelFino/Linux-prepare/main/github-workspaces.sh)
