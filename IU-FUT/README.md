# IU-FUT - Sistema de Gerenciamento de Partidas de Futebol

Sistema desktop desenvolvido em C# (.NET 8.0) para gerenciamento de partidas de futebol, times, jogadores e campos.

## 📋 Pré-requisitos

Antes de instalar e executar o projeto, certifique-se de ter instalado:

### 1. .NET SDK 8.0 ou superior
- **Download**: [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- **Verificação**: Abra o terminal e execute:
  ```bash
  dotnet --version
  ```
  Deve retornar a versão 8.0.x ou superior.

### 2. SQL Server Express (ou superior)
- **Download**: [SQL Server Express](https://www.microsoft.com/sql-server/sql-server-downloads)
- **Alternativa**: SQL Server LocalDB (incluído com Visual Studio)
- **Verificação**: Certifique-se de que o SQL Server está rodando e acessível

### 3. Visual Studio 2022 (Recomendado) ou Visual Studio Code
- **Download Visual Studio**: [Visual Studio 2022 Community](https://visualstudio.microsoft.com/downloads/)
- **Workloads necessários**: 
  - Desenvolvimento para desktop com .NET
  - Desenvolvimento de aplicativos .NET

### 4. Git (para clonar o repositório)
- **Download**: [Git](https://git-scm.com/downloads)
- **Verificação**: Execute no terminal:
  ```bash
  git --version
  ```

## 🚀 Como Clonar o Repositório

### Opção 1: Via HTTPS
```bash
git clone https://github.com/seu-usuario/IU-FUT.git
cd IU-FUT
```

### Opção 2: Via SSH
```bash
git clone git@github.com:seu-usuario/IU-FUT.git
cd IU-FUT
```

### Opção 3: Download ZIP
1. Acesse o repositório no GitHub
2. Clique em "Code" → "Download ZIP"
3. Extraia o arquivo ZIP
4. Abra a pasta extraída

## ⚙️ Configuração do Banco de Dados

### 1. Criar o Banco de Dados

Abra o SQL Server Management Studio (SSMS) ou use o `sqlcmd` e execute:

```sql
CREATE DATABASE [iu-fut]
GO
```

### 2. Configurar a String de Conexão

O projeto está configurado para usar a seguinte string de conexão padrão:
```
Server=localhost\SQLEXPRESS;Database=iu-fut;Trusted_Connection=True;Encrypt=False
```

**Para alterar a string de conexão:**
1. Abra o arquivo `IU-FUT/Models/IuFutContext.cs`
2. Localize o método `OnConfiguring`
3. Altere a string de conexão conforme necessário:
   ```csharp
   optionsBuilder.UseSqlServer("Server=SEU_SERVIDOR;Database=iu-fut;Trusted_Connection=True;Encrypt=False");
   ```

### 3. Executar Migrações (se aplicável)

Se o projeto usar Entity Framework Migrations:
```bash
cd IU-FUT
dotnet ef database update
```

**Nota**: Este projeto pode usar Code First ou Database First. Verifique se há migrações configuradas.

## 🔧 Instalação e Execução

### Passo 1: Restaurar Dependências
```bash
cd IU-FUT
dotnet restore
```

### Passo 2: Compilar o Projeto
```bash
dotnet build
```

### Passo 3: Executar o Projeto

**Opção A: Via Visual Studio**
1. Abra o arquivo `IU-FUT.sln` no Visual Studio
2. Pressione `F5` ou clique em "Iniciar"

**Opção B: Via Terminal**
```bash
dotnet run --project IU-FUT/IU-FUT.csproj
```

**Opção C: Executar o Executável**
Após compilar, o executável estará em:
```
IU-FUT/bin/Debug/net8.0-windows/IU-FUT.exe
```

## 📦 Estrutura do Projeto

```
IU-FUT/
├── Controllers/          # Controladores (lógica de negócio)
│   ├── CampoController.cs
│   ├── JogadorController.cs
│   ├── PartidaController.cs
│   └── TimeController.cs
├── Models/              # Modelos de dados (Entity Framework)
│   ├── Campo.cs
│   ├── IuFutContext.cs
│   ├── Jogador.cs
│   ├── Partidum.cs
│   ├── Time.cs
│   └── TimePartidum.cs
├── Views/               # Formulários Windows Forms
│   ├── LoginForm.cs
│   ├── MainForm.cs
│   ├── CadastroCampoForm.cs
│   ├── CadastroJogadorForm.cs
│   ├── CadastroPartidaForm.cs
│   ├── CadastroTimeForm.cs
│   ├── ConsultarPartidaForm.cs
│   └── ConsultarTimeForm.cs
├── Program.cs           # Ponto de entrada da aplicação
└── IU-FUT.csproj        # Arquivo de projeto
```

## 🎯 Funcionalidades

### Casos de Uso Implementados

1. **Cadastrar Campo**
   - Criar, alterar, excluir e consultar campos de futebol

2. **Cadastrar Jogador**
   - Criar, alterar, excluir e consultar jogadores
   - Sistema de autenticação

3. **Cadastrar Partida**
   - Criar, alterar, excluir e consultar partidas
   - Associação com campos e times

4. **Cadastrar Time**
   - Criar, alterar, excluir e consultar times
   - Gerenciamento de jogadores no time

5. **Consultar Partida**
   - Visualizar partidas disponíveis
   - Solicitar participação em partidas
   - Verificação de vagas e inscrições

6. **Consultar Time**
   - Visualizar times cadastrados
   - Solicitar ingresso em times

## 🔐 Primeiro Acesso

1. Execute o aplicativo
2. Na tela de login, você precisará criar um jogador primeiro
3. Use o menu "Cadastrar Jogador" para criar sua conta
4. Após criar, faça login com o e-mail e senha cadastrados

## 🛠️ Tecnologias Utilizadas

- **.NET 8.0**: Framework principal
- **Windows Forms**: Interface gráfica
- **Entity Framework Core 8.0**: ORM para acesso a dados
- **SQL Server**: Banco de dados
- **C#**: Linguagem de programação

## 📝 Regras de Negócio

### RN01 - Validações Gerais
- Campos obrigatórios devem ser preenchidos
- E-mails devem ser únicos
- Datas devem ser válidas e futuras (quando aplicável)

### RN02 - Participação em Partidas
- Limite de 2 times por partida
- Jogador deve estar em um time para participar de partidas
- Verificação de vagas disponíveis

### RN03 - Participação em Times
- Jogador não pode estar em mais de um time da mesma partida
- Verificação de conflitos de participação

## 🐛 Solução de Problemas

### Erro: "Não é possível conectar ao servidor SQL Server"
- Verifique se o SQL Server está rodando
- Confirme a string de conexão em `IuFutContext.cs`
- Teste a conexão usando o SQL Server Management Studio

### Erro: "Banco de dados não encontrado"
- Crie o banco de dados manualmente (veja seção "Configuração do Banco de Dados")
- Ou execute as migrações do Entity Framework

### Erro: "Package restore failed"
- Verifique sua conexão com a internet
- Execute `dotnet restore` novamente
- Limpe o cache: `dotnet nuget locals all --clear`

### Erro de Compilação
- Certifique-se de ter o .NET SDK 8.0 instalado
- Execute `dotnet clean` e depois `dotnet build`
- Verifique se todas as dependências estão instaladas

## 📄 Licença

Este projeto é de uso educacional/acadêmico.

## 👥 Contribuidores

- Equipe de Desenvolvimento IU-FUT

## 📧 Contato

Para dúvidas ou suporte, entre em contato através do repositório.

---

**Desenvolvido com ❤️ usando .NET e Windows Forms**

