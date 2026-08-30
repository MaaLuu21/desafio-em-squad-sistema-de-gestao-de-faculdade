# Sistema de Gestão de Faculdade

Projeto desenvolvido em **C#** para praticar os principais conceitos de **Programação Orientada a Objetos (POO)** por meio de um sistema de gestão acadêmica executado no Console.

O sistema permite cadastrar cursos, professores, alunos e disciplinas, realizar matrículas, lançar notas, consultar boletins e enviar notificações.

## Lógica do sistema

O programa foi estruturado a partir das principais entidades de uma faculdade:

- `Pessoa`: classe abstrata que reúne os dados comuns de alunos e professores.
- `Aluno`: herda de `Pessoa` e possui número de matrícula.
- `Professor`: herda de `Pessoa` e possui registro e especialidade.
- `Curso`: possui código, nome, tipo e uma lista de disciplinas.
- `Disciplina`: possui código, nome, carga horária e um professor responsável.
- `Matricula`: cria o vínculo entre um aluno e um curso.
- `Boletim`: pertence a uma matrícula e armazena as notas daquele vínculo acadêmico.
- `NotaDisciplina`: relaciona uma disciplina à nota obtida e à situação acadêmica do aluno.

Os dados são armazenados em memória por meio de coleções `List<T>`. O programa permanece em execução através de um menu interativo com `while` e `switch`, que direciona o usuário para cada funcionalidade.

### Fluxo principal

```text
Professor ───────► Disciplina ───────► Curso
                                      ▲
                                      │
Aluno ───────────────► Matrícula ─────┘
                           │
                           ▼
                        Boletim
                           │
                           ▼
                    Notas + Situação
```

O fluxo acadêmico funciona da seguinte forma:

1. Cursos, professores e alunos são cadastrados.
2. Cada disciplina é cadastrada com um professor responsável.
3. As disciplinas são vinculadas aos cursos.
4. Um aluno pode ser matriculado em um ou mais cursos.
5. Cada matrícula cria automaticamente um boletim próprio.
6. As notas são lançadas somente para disciplinas pertencentes ao curso da matrícula.
7. A situação acadêmica é calculada conforme o tipo do curso.
8. O sistema permite consultar os dados cadastrados e enviar notificações para alunos e professores.

## Funcionalidades

O menu principal disponibiliza as seguintes opções:

1. **Cadastrar curso**
2. **Cadastrar professor**
3. **Cadastrar aluno**
4. **Cadastrar disciplina**
5. **Vincular disciplina a um curso**
6. **Matricular aluno em curso**
7. **Lançar nota**
8. **Consultar pessoas**
9. **Consultar cursos**
10. **Consultar matrículas**
11. **Consultar boletim**
12. **Enviar notificação**
0. **Sair**

## Estrutura do projeto

```text
SistemaGestaoDeFaculdade/
│
├── Entities/
│   ├── Aluno.cs
│   ├── Boletim.cs
│   ├── Curso.cs
│   ├── Disciplina.cs
│   ├── Matricula.cs
│   ├── NotaDisciplina.cs
│   ├── Pessoa.cs
│   └── Professor.cs
│
├── Enums/
│   └── TipoCurso.cs
│
├── Program.cs
└── SistemaGestaoDeFaculdade.csproj
```

## Como executar

O projeto utiliza **.NET 10.0**.

Com o SDK correspondente instalado, abra o terminal na pasta do projeto e execute:

```bash
dotnet run
```

O menu de gestão da faculdade será exibido diretamente no Console.
