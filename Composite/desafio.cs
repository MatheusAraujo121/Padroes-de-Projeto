using System;
using System.Collections.Generic;

public interface IProjetoComponente
{
    void Exibir(int nivel = 0);
    int ContarTarefas();
}

public class Tarefa : IProjetoComponente
{
    public string Nome { get; set; }

    public Tarefa(string nome)
    {
        Nome = nome;
    }

    public void Exibir(int nivel = 0)
    {
        Console.WriteLine(new string(' ', nivel * 2) + "- Tarefa: " + Nome);
    }

    public int ContarTarefas()
    {
        return 1;
    }
}


public class Projeto : IProjetoComponente
{
    public string Nome { get; set; }
    private List<IProjetoComponente> componentes = new List<IProjetoComponente>();
 
    public Projeto(string nome)
    {
        Nome = nome;
    }
 
    public void Adicionar(IProjetoComponente componente)
    {
        componentes.Add(componente);
    }
 
    public void Exibir(int nivel = 0)
    {
        Console.WriteLine(new string(' ', nivel * 2) + "+ Projeto: " + Nome);
        foreach (var componente in componentes)
        {
            componente.Exibir(nivel + 1);
        }
    }

      public int ContarTarefas()
    {
        int total = 0;
        foreach (var componente in componentes)
        {
            total += componente.ContarTarefas();
        }
        return total;
    }
}

public class Program
{
    public static void Main()
    {
        Projeto projetoPrincipal = new Projeto("Sistema Web");

        Tarefa tarefa1 = new Tarefa("Configurar banco de dados");
        Tarefa tarefa2 = new Tarefa("Criar layout da home");

        Projeto subProjeto = new Projeto("Módulo de Autenticação");
        subProjeto.Adicionar(new Tarefa("Tela de login"));
        subProjeto.Adicionar(new Tarefa("Validação de usuário"));

        projetoPrincipal.Adicionar(tarefa1);
        projetoPrincipal.Adicionar(tarefa2);
        projetoPrincipal.Adicionar(subProjeto);

        projetoPrincipal.Exibir();

        Console.WriteLine($"\nTotal de tarefas: {projetoPrincipal.ContarTarefas()}");
    }
}