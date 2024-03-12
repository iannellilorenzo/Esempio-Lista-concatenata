﻿#region LinkedList

public class Nodo
{
    public int Dato { get; set; }
    public Nodo Successivo { get; set; }

    public Nodo(int value)
    {
        Dato = value;
    }
}

public class ListaCollegata
{
    private Nodo testa;

    public ListaCollegata()
    {
        testa = null;
    }

    // Inserisci un nodo in testa
    public void InserisciInTesta(int dato)
    {
        Nodo nuovoNodo = new(dato);
        testa = nuovoNodo;
    }

    // Inserisci un nodo in coda
    public void InserisciInCoda(int dato)
    {
        Nodo nuovoNodo = new(dato);
        if (testa == null)
        {
            testa = nuovoNodo;
            return;
        }

        Nodo corrente = testa;
        while (corrente.Successivo != null)
        {
            corrente = corrente.Successivo;
        }

        corrente.Successivo = nuovoNodo;
    }

    // Inserisci un nodo al centro (dopo un nodo specifico)
    public bool InserisciAlCentro(int dato, int nodoPrecedente)
    {
        Nodo nuovoNodo = new(dato);
        Nodo corrente = testa;

        while (corrente != null)
        {
            if (corrente.Dato == nodoPrecedente)
            {
                nuovoNodo.Successivo = corrente.Successivo;
                corrente.Successivo = nuovoNodo;
                return true;
            }
            corrente = corrente.Successivo;
        }

        return false;
    }

    // Cancella un nodo in testa
    public bool CancellaInTesta()
    {
        if (testa != null)
        {
            Nodo temp = testa;
            testa = testa.Successivo;
            temp = null;
            return true;
        }
        
        return false;
    }

    // Cancella un nodo in coda
    public bool CancellaInCoda()
    {
        if (testa == null)
        {
            return false;
        }

        if (testa.Successivo == null)
        {
            testa = null;
            return true;
        }

        Nodo corrente = testa;
        while (corrente.Successivo.Successivo != null)
        {
            corrente = corrente.Successivo;
        }

        corrente.Successivo = null;
        return true;
    }

    // Cancella un nodo al centro (dopo un nodo specifico)
    public int CancellaAlCentro(int nodoPrecedente)
    {
        if (testa == null)
        {
            return -1; // exit status per lista vuota
        }

        if (testa.Dato == nodoPrecedente)
        {
            Nodo temp = testa;
            testa = testa.Successivo;
            temp = null;
            return 0;
        }

        Nodo corrente = testa;

        while (corrente.Successivo != null)
        {
            if (corrente.Successivo.Dato == nodoPrecedente)
            {
                Nodo temp = corrente.Successivo;
                corrente.Successivo = corrente.Successivo.Successivo;
                temp = null;
                return 0; // exit status per andato a buon fine
            }
            corrente = corrente.Successivo;
        }

        return -2; // exit status per nodo precedente non trovato
    }

    // Stampa la lista
    public override string ToString()
    {
        string s = "";
        Nodo corrente = testa;
        while (corrente != null)
        {
            s+=corrente.Dato + " ";
            corrente = corrente.Successivo;
        }
        return s;
    }
}

#endregion

public class PilaInteri
{
    private LinkedList<int> _pila;

    public LinkedList<int> Pila
    {
        get => _pila;
        set => _pila = value;
    }

    public PilaInteri()
    {
        Pila = new();
    }

    // lifo - last in first out
    public void Push(int value)
    {
        Pila.AddLast(value);
    }

    public bool Pop()
    {
        if (Pila.Count == 0)
        {
            return false; // pila vuota
        }

        Pila.RemoveLast();

        return true;
    }

    public override string ToString()
    {
        string str = "";

        foreach(int item in Pila)
        {
            str += $"Valore: {item}\n";
        }

        return str;
    }
}

class Program
{
    static void Main()
    {
        #region TestLinkedList

        ListaCollegata lista = new();

        lista.InserisciInTesta(3);
        lista.InserisciInTesta(2);
        lista.InserisciInTesta(1);

        lista.InserisciInCoda(4);
        Console.WriteLine(lista);

        lista.InserisciAlCentro(23, 2);
        Console.WriteLine(lista);

        lista.CancellaInTesta();
        Console.WriteLine(lista);

        lista.CancellaInCoda();
        Console.WriteLine(lista);

        lista.CancellaAlCentro(2);
        Console.WriteLine(lista);

        #endregion

        Console.Clear();

        #region TestPilaInteri

        PilaInteri stack = new();
        Random rng = new();

        Console.WriteLine("Valori pushati (casuali):");
        for (int i = 0; i < 10; i++)
        {
            stack.Push(i + rng.Next(0, 101));
        }
        Console.WriteLine(stack.ToString());

        stack.Pop();

        Console.WriteLine("Valori post-pop:");
        Console.WriteLine(stack.ToString());

        #endregion

        //Console.Clear();
    }
}
