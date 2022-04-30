﻿using Tarefas.db;
bool sair = false;
while (!sair)
{
    string opcao = UI.SelecionaOpcaoEmMenu();

    switch (opcao)
    {
        case "L": ListarTodasAsTarefas(); break;
        case "P": ListarTarefasPendentes(); break;
        case "I": ListarTarefasPorId(); break;
        case "D": ListarTarefasPorDescricao(); break;
        case "N": IncluirNovaTarefa(); break;
        case "A": AlterarDescricaoDaTarefa(); break;
        case "C": ConcluirTarefa(); break;
        case "E": ExcluirTarefa(); break;

        case "S":
            sair = true;
            break;

        default:
            UI.ExibeErro("\nOpção não reconhecida.");
            break;
    }

    Console.Write("\nPressione uma tecla para continuar...");
    Console.ReadKey();
}

void ListarTodasAsTarefas()
{
    UI.ExibeDestaque("\n-- Listar todas as Tarefas ---");
    using (var _db = new tarefasContext())
    {
        var tarefas = _db.Tarefa.ToList<Tarefa>();
        Console.WriteLine($"{tarefas.Count()} tarefas encontradas.") ;
        foreach (var tarefa in tarefas)
        {
            Console.WriteLine($"[{(tarefa.Concluida ? "X" : " ")}] # {tarefa.Id}: {tarefa.Descricao}");
        }
    }
}

void ListarTarefasPendentes()
{
    UI.ExibeDestaque("\n-- Listar Tarefas Pendentes ---");
     using (var _db = new tarefasContext())
    {
        var tarefas = _db.Tarefa
        .Where(t => !t.Concluida)
        .OrderByDescending (t => t.Id)
        .ToList<Tarefa>();
        Console.WriteLine($"{tarefas.Count()} tarefas encontradas.") ;
        foreach (var tarefa in tarefas)
        {
            Console.WriteLine($"[{(tarefa.Concluida ? "X" : " ")}] # {tarefa.Id}: {tarefa.Descricao}");
        }
    }
}

void ListarTarefasPorDescricao()
{
    UI.ExibeDestaque("\n-- Listar Tarefas por Descrição ---");
    string descricao = UI.SelecionaDescricao();
    // Continue daqui
    Console.WriteLine(descricao);
}

void ListarTarefasPorId()
{
    UI.ExibeDestaque("\n-- Listar Tarefas por Id ---");
    int id = UI.SelecionaId();
    // Continue daqui
    Console.WriteLine(id);
}

void IncluirNovaTarefa()
{
    UI.ExibeDestaque("\n-- Incluir Nova Tarefa ---");
    string descricao = UI.SelecionaDescricao();
    // Continue daqui
    Console.WriteLine(descricao);
}

void AlterarDescricaoDaTarefa()
{
    UI.ExibeDestaque("\n-- Alterar Descrição da Tarefa ---");
    int id = UI.SelecionaId();
    string descricao = UI.SelecionaDescricao();
    // Continue daqui
    Console.WriteLine(id);
    Console.WriteLine(descricao);
}

void ConcluirTarefa()
{
    UI.ExibeDestaque("\n-- Concluir Tarefa ---");
    int id = UI.SelecionaId();
    // Continue daqui
    Console.WriteLine(id);
}

void ExcluirTarefa()
{
    UI.ExibeDestaque("\n-- Excluir Tarefa ---");
    int id = UI.SelecionaId();
    // Continue daqui
    Console.WriteLine(id);
}
