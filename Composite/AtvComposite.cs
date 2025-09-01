using System;
using System.Collections.Generic;

public abstract class HoraTrabalhada
{
    public abstract int GetHoraTrabalhada();
    public virtual void Add(HoraTrabalhada componente) { }
    public virtual void Remove(HoraTrabalhada componente) { }
}

public class Funcionario : HoraTrabalhada
{
    public string Nome { get; set; }
    public int Horas { get; set; }

    public Funcionario(string nome, int horas)
    {
        Nome = nome;
        Horas = horas;
    }

    public override int GetHoraTrabalhada()
    {
        Console.WriteLine($"Funcionário: {Nome}, Horas: {Horas}");
        return Horas;
    }
}

public class Organizacao : HoraTrabalhada
{
    public string Nome { get; set; }
    private List<HoraTrabalhada> componentes = new List<HoraTrabalhada>();
    public Organizacao(string nome)
    {
        Nome = nome;
    }
    public override int GetHoraTrabalhada()
    {
        Console.WriteLine($"\nOrganização: {Nome}");
        int total = 0;
        foreach (var componente in componentes)
        {
            total += componente.GetHoraTrabalhada();
        }
        Console.WriteLine($"Total de horas em {Nome}: {total}");
        return total;
    }
    public override void Add(HoraTrabalhada componente)
    {
        componentes.Add(componente);
    }
    public override void Remove(HoraTrabalhada componente)
    {
        componentes.Remove(componente);
    }
}

public class Program
{
    public static void Main()
    {
        Organizacao empresa = new Organizacao("Empresa XPTO");

        Organizacao departamento1 = new Organizacao("Departamento de TI");
        departamento1.Add(new Funcionario("Alice", 40));
        departamento1.Add(new Funcionario("Bob", 38));
        departamento1.Add(new Funcionario("Carlos", 42));

        Organizacao departamento2 = new Organizacao("Departamento de RH");
        departamento2.Add(new Funcionario("Diana", 36));
        departamento2.Add(new Funcionario("Eduardo", 44));
        departamento2.Add(new Funcionario("Fernanda", 40));

        empresa.Add(departamento1);
        empresa.Add(departamento2);

        Console.WriteLine("Horas Trabalhadas:\n");
        int totalHoras = empresa.GetHoraTrabalhada();
        Console.WriteLine($"\nTotal geral de horas trabalhadas: {totalHoras}");
    }
}
