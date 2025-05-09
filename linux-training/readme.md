# 🐧 Guia passo a passo: Usando GitHub Codespaces para treinar Linux

Este guia vai te ensinar a:

1. Criar uma conta no GitHub
2. Acessar o repositório com os exercícios
3. Criar um Codespace (um ambiente Linux direto no navegador!)
4. Rodar um script de preparação com um único comando

---

## 🧾 1. Criar uma conta no GitHub

1. Acesse: [https://github.com](https://github.com)
2. Clique no botão **Sign up** (ou "Cadastrar-se")
3. Preencha:
   - **Username** (nome de usuário)
   - **Email**
   - **Senha**
4. Clique em **Create account**
5. Confirme o e-mail (verifique sua caixa de entrada)
6. Finalize o processo seguindo os passos do site (pode pular questionários se quiser)

---

## 🔗 2. Acessar o repositório de exercícios

1. Após fazer login, vá para este link:  
   👉 [https://github.com/RafaelFino/plataforma-exercicios](https://github.com/RafaelFino/plataforma-exercicios)

---

## 💻 3. Criar um Codespace (ambiente Linux no navegador)

> ⚠️ É necessário que a sua conta seja **gratuita com verificação por e-mail** para usar Codespaces.

1. Na página do repositório, clique no botão verde **<> Code**
2. No menu que aparece, clique na aba **Codespaces**
3. Clique no botão **Create codespace on main**
4. Espere o ambiente abrir. Ele vai carregar um **VS Code Web**, com terminal, editor de arquivos e tudo!

---

## 🛠️ 4. Executar o script prepare.sh

Agora que o Codespace está pronto, vamos usar o terminal embutido.

1. Quando o Codespace abrir, clique no menu superior em **Terminal > New Terminal** (ou use o atalho `Ctrl + \``)
2. No terminal, digite este comando e pressione **Enter**:

```bash
bash <(curl -s https://raw.githubusercontent.com/RafaelFino/plataforma-exercicios/refs/heads/main/linux-training/prepare.sh)
