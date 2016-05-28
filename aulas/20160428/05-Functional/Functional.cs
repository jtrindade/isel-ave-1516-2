using System;
using System.Collections;
using System.Collections.Generic;

// Delegates in Action: exemplos de utilização de delegates.
//
// Programação Funcional.
//
public static class Functional
{
    public delegate void Action1<X>(X obj);
    public delegate Y Func1<X,Y>(X obj);

    //
    // Aplique-se a função 'action' a cada elemento de 'source'.
    //
    public static void Apply<T>(this IEnumerable<T> source, Action1<T> action)
    {
        foreach (T obj in source)
        {
            action(obj);
        }
    }

    //
    // Produza-se um IEnumerable em que cada elemento resulta de
    // aplicar 'func' a um elemento de 'source'.
    //
    // Implementação 'eager', que usa uma colecção para guardar o resultado
    // do processamento de toda a sequência de entrada.
    //
    public static IEnumerable<U> EagerMap<T,U>(this IEnumerable<T> source, Func1<T,U> func)
    {
        IList<U> res = new List<U>();
        foreach (T obj in source)
        {
            res.Add(func(obj));
        }
        return res;
    }

    //
    // Produza-se um IEnumerable em que cada elemento resulta de
    // aplicar 'func' a um elemento de 'source'.
    //
    // Implementação 'lazy' de algoritmo de Map, que vai calculando os resultados
    // à medida que forem sendo precisos.
    //
    // Usa duas classes auxiliares, com as implementações de IEnumerable e IEnumerator,
    // semelhantes ao par Iterable / Iterator de Java.
    //
    #region LazyMap
    
    class MapEnumerator<T,U> : IEnumerator<U>
    {
        private IEnumerator<T> source;
        private Func1<T,U> func;
        
        private bool finished = false;
        private U curr;
        
        public MapEnumerator(IEnumerator<T> source, Func1<T,U> func)
        {
            this.source = source;
            this.func = func;
        }
        
        public bool MoveNext()
        {
            if (source.MoveNext()) {
                curr = func(source.Current);    // <<< Uso 'lazy' do delegate 'func'.
                return true;
            }
            finished = true;
            return false;
        }
        
        public U Current
        {
            get {
                if (finished)
                    throw new InvalidOperationException();
                
                return curr;
            }
        }
        
        public void Reset()
        {
            throw new NotSupportedException();
        }
        
        Object IEnumerator.Current
        {
            get { return Current; }
        }
        
        public void Dispose() {}
    }
    
    class MapEnumerable<T,U> : IEnumerable<U>
    {
        private IEnumerable<T> source;
        private Func1<T,U> func;
        
        public MapEnumerable(IEnumerable<T> source, Func1<T,U> func)
        {
            this.source = source;
            this.func = func;
        }
        
        public IEnumerator<U> GetEnumerator()
        {
            return new MapEnumerator<T,U>(source.GetEnumerator(), func);
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public static IEnumerable<U> Map<T,U>(this IEnumerable<T> source, Func1<T,U> func)
    {
        return new MapEnumerable<T,U>(source, func);
    }

    #endregion

    //
    // Produza-se um IEnumerable em que cada elemento resulta de
    // aplicar 'func' a um elemento de 'source'.
    //
    // Implementação 'lazy' de algoritmo de Map, que vai calculando os resultados
    // à medida que forem sendo precisos.
    //
    // Usa a palavra-chave yield, levando a que o compilador de C# gere automaticamente
    // uma implementação equivalente à apresentada no passo anterior ('LazyMap').
    //
    
    #region LazyMapWithYield
    
    public static IEnumerable<U> YieldedMap<T,U>(this IEnumerable<T> source, Func1<T,U> func)
    {
        foreach (T obj in source)
        {
            yield return func(obj);
        }
    }

    #endregion

    // 
    // Produza-se uma sub-sequência com os 'n' primeiros elementos da
    // sequência de entrada 'source'.
    //
    // Versão 'eager'.
    //
    public static IEnumerable<T> EagerTake<T>(this IEnumerable<T> source, int n)
    {
        IList<T> res = new List<T>();
        foreach (T obj in source)
        {
            if (n <= 0) break;
            n -= 1;

            res.Add(obj);
        }
        return res;
    }

    // 
    // Produza-se uma sub-sequência com os 'n' primeiros elementos da
    // sequência de entrada 'source'.
    //
    // Versão 'lazy'.
    //
    #region LazyTake
    
    class TakeEnumerator<T> : IEnumerator<T>
    {
        private IEnumerator<T> source;
        private int n;
        
        private bool finished = false;
        private T curr;
        
        public TakeEnumerator(IEnumerator<T> source, int n)
        {
            this.source = source;
            this.n = n;
        }
        
        public bool MoveNext()
        {
            if (n > 0 && source.MoveNext()) {
                curr = source.Current;           // <<< Obtenção 'lazy' de um elemento da sequência.
                n -= 1;
                return true;
            }
            finished = true;
            return false;
        }
        
        public T Current
        {
            get {
                if (finished)
                    throw new InvalidOperationException();
                
                return curr;
            }
        }
        
        public void Reset()
        {
            throw new NotSupportedException();
        }

        Object IEnumerator.Current
        {
            get { return Current; }
        }

        public void Dispose()
        {
            source.Dispose();
        }
    }
    
    class TakeEnumerable<T> : IEnumerable<T>
    {
        private IEnumerable<T> source;
        private int n;
        
        public TakeEnumerable(IEnumerable<T> source, int n)
        {
            this.source = source;
            this.n = n;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new TakeEnumerator<T>(source.GetEnumerator(), n);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public static IEnumerable<T> Take<T>(this IEnumerable<T> source, int n)
    {
        return new TakeEnumerable<T>(source, n);
    }

    #endregion

    public static void Main(String[] args)
    {
        if (args.Length == 0)
        {
            args = new String[] { "alpha", "beta", "gamma", "delta", "epsilon" };
        }

        int[] ints = new int[] { 1, 22, 333, 4444, 55555 };
        
        // Utilizar *apenas uma* das linhas abaixo.
        // Devido ao uso de 'var' na declaração, vals será do tipo String[] ou
        // int[] conforme a linha escolhida.
        // O código a seguir é válido para ambos os casos.

        //var vals = args;
        var vals = ints;
        
        // Estilo imperativo
        foreach (var arg in vals)
        {
            Console.WriteLine(arg);
        }
        
        // Estilo funcional
        Apply(vals, Console.WriteLine);

        // Utilização de Apply como 'método de extensão'.
        // Permitido devido ao uso da palavra-chave 'this' no primeiro argumento do método Apply.
        vals.Apply(Console.WriteLine);
        
        Console.WriteLine();
        
        // Transformação misturada com acção final.
        vals.Apply(o => { Console.WriteLine(o.ToString().Length); });

        // Separação entre transformação (Map) e acção final (Apply).
        vals.Map(o => o.ToString().Length).Apply(Console.WriteLine);
        
        Console.WriteLine();
        
        // Restrição da sequência de saída a 3 elementos.
        // Questão: quantas vezes é invocado o delegate configurado em Map?
        vals.Map(o => o.ToString().Length).Take(3).Apply(Console.WriteLine);
        
        Console.WriteLine();
        
        int count;

        // Uso de EagerMap. count será igual ao número de elementos da sequência de entrada.
        count = 0;
        vals.EagerMap(o => { count++; return o.ToString().Length; }).Take(3).Apply(Console.WriteLine);
        Console.WriteLine("count: {0}", count);

        // Uso de (lazy) Map. count não será maior do que 3.
        count = 0;
        vals.Map(o => { count++; return o.ToString().Length; }).Take(3).Apply(Console.WriteLine);
        Console.WriteLine("count: {0}", count);

        // Uso de (lazy) YieldedMap. count não será maior do que 3.
        count = 0;
        vals.YieldedMap(o => { count++; return o.ToString().Length; }).Take(3).Apply(Console.WriteLine);
        Console.WriteLine("count: {0}", count);
    }
}
