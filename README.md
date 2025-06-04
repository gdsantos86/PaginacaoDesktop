# PaginacaoDesktop

Um projeto exemplo de implementação de paginação em aplicações Windows Forms (WinForms) usando C# e .NET Framework.

## 📋 Sobre o Projeto

Este projeto demonstra como implementar um sistema de paginação eficiente em aplicações desktop Windows Forms, permitindo navegar através de grandes conjuntos de dados de forma organizada e performática.

## 🚀 Funcionalidades

- Sistema de paginação completo para Windows Forms
- Navegação entre páginas de dados
- Controle de quantidade de registros por página
- Interface intuitiva para o usuário
- Estrutura organizada e reutilizável

## 🛠️ Tecnologias Utilizadas

- **C#** - Linguagem de programação
- **Windows Forms** - Framework para interface desktop
- **.NET Framework** - Plataforma de desenvolvimento
- **Entity Framework** - Para acesso a dados

## 📁 Estrutura do Projeto

```
PaginacaoDesktop/
├── Context/                    # Contexto de dados
│   ├── ProdutoDbInitializer.cs
│   └── ProdutoDbContext.cs
├── Entities/                   # Entidades do modelo
│   └── Produto.cs
├── Migrations/                 # Migrações do banco de dados
├── Pagination/                 # Lógica de paginação
│   └── ParametrosPaginacao.cs
├── Properties/                 # Propriedades do projeto
│   ├── AssemblyInfo.cs
│   ├── Resources.Designer.cs
│   ├── Resources.resx
│   └── Settings.Designer.cs
├── Views/                      # Formulários da aplicação
│   ├── frmProdutos.Designer.cs
│   ├── frmProdutos.cs
│   └── frmProdutos.resx
├── App.config                  # Configurações da aplicação
├── PaginacaoDesktop.csproj     # Arquivo do projeto
├── Program.cs                  # Ponto de entrada da aplicação
└── packages.config             # Pacotes NuGet
```

## ⚙️ Pré-requisitos

- Visual Studio 2017 ou superior
- .NET Framework 4.5 ou superior
- SQL Server ou SQL Server Express (para o banco de dados)

## 🔧 Instalação e Configuração

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/gdsantos86/PaginacaoDesktop.git
   ```

2. **Abra o projeto:**
   - Execute o Visual Studio
   - Abra o arquivo `PaginacaoDesktop.sln` ou `PaginacaoDesktop.csproj`

3. **Restaure os pacotes NuGet:**
   ```
   Tools > NuGet Package Manager > Package Manager Console
   Update-Package -reinstall
   ```

4. **Configure a string de conexão:**
   - Edite o arquivo `App.config`
   - Atualize a connection string para apontar para seu banco de dados

5. **Execute as migrações:**
   ```
   Enable-Migrations (se necessário)
   Update-Database
   ```

## 🎯 Como Usar

1. **Execute a aplicação** pressionando F5 ou através do menu Debug > Start Debugging

2. **Interface de Paginação:**
   - Use os controles de navegação para navegar entre as páginas
   - Configure a quantidade de registros por página
   - Visualize os dados organizados de forma paginada

3. **Funcionalidades principais:**
   - Navegação: Primeira, Anterior, Próxima, Última página
   - Controle de registros por página
   - Exibição do total de registros e páginas

## 📖 Exemplo de Uso

O projeto inclui um exemplo prático com a entidade `Produto`, demonstrando:

- Como configurar o contexto de dados
- Como implementar parâmetros de paginação
- Como criar a interface de usuário para navegação
- Como integrar a paginação com controles WinForms

## 📝 Licença

Este projeto está disponível sob a Licença MIT para uso livre como exemplo e referência. 
Sinta-se à vontade para usar, modificar e aprender com o código.

## 👤 Autor

**Gustavo Santos** - [@gdsantos86](https://github.com/gdsantos86)
