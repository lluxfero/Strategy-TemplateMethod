// Клиентский код выбирает конкретную стратегию
int[] array = { 20, 5, 1, -78, 12, 2 };
Context context = new(array);

QuickSortStrategy sort1 = new();
Client.ClientCode(context, sort1);

MergeSortStrategy sort2 = new();
Client.ClientCode(context, sort2);


class Client
{
    public static void ClientCode(Context context, IStrategy strategy)
    {
        context.SetStrategy(strategy);
        context.Sort();
    }
}

// Контекст определяет интерфейс, представляющий интерес для клиентов
class Context
{
    // Контекст хранит ссылку на один из объектов Стратегии
    private IStrategy _strategy;
    private int[] array;

    public Context(int[] array)
    {
        this.array = array;
    }

    public void SetStrategy(IStrategy strategy)
    {
        this._strategy = strategy;
    }

    // Контекст делегирует некоторую работу объекту Стратегии.
    public void Sort()
    {
        int[] result = this._strategy.DoSortAlgorithm(this.array);
        for (int i = 0; i < result.Length; i++)
            Console.Write($"{result[i]} ");
        Console.WriteLine("\n");
    }
}

// Интерфейс Стратегии
public interface IStrategy
{
    int[] DoSortAlgorithm(int[] data);
}

// Конкретные Стратегии
class QuickSortStrategy : IStrategy
{
    int[] quickAlgorithm(int[] array, int first, int last)
    {
        if (array.Length < 2) return array;
        int pivot = array[last];
        int pIndex = first;
        for (int i = first; i < last; i++)
            if (array[i] <= pivot)
            {
                (array[i], array[pIndex]) = (array[pIndex], array[i]);
                pIndex++;
            }
        (array[last], array[pIndex]) = (array[pIndex], array[last]);
        if (pIndex > 0) quickAlgorithm(array, 0, pIndex - 1);
        if (last > pIndex) quickAlgorithm(array, pIndex + 1, last);
        return array;
    }
    public int[] DoSortAlgorithm(int[] array)
    {
        Console.WriteLine("Производится быстрая сортировка..");
        quickAlgorithm(array, 0, array.Length - 1);
        return array;
    }
}

class MergeSortStrategy : IStrategy
{
    int[] mergeAlgorithm(int[] array, int first, int last)
    {
        if (last - first < 1) return array;

        if (last - first == 1)
            if (array[first] > array[last])
                (array[first], array[last]) = (array[last], array[first]);

        mergeAlgorithm(array, first, first + (last - first) / 2);
        mergeAlgorithm(array, first + (last - first) / 2 + 1, last);

        int[] result = new int[last - first + 1];
        int x = 0;
        int i = first;
        int j = first + (last - first) / 2 + 1;
        while (i <= first + (last - first) / 2 && j <= last)
        {
            if (array[j] < array[i])
                result[x++] = array[j++];
            else
                result[x++] = array[i++];
        }
        while (i <= first + (last - first) / 2)
            result[x++] = array[i++];
        while (j <= last)
            result[x++] = array[j++];
        for (int k = first; k <= last; k++)
            array[k] = result[k - first];
        return array;
    }
    public int[] DoSortAlgorithm(int[] array)
    {
        Console.WriteLine("Производится сортировка слиянием..");
        mergeAlgorithm(array, 0, array.Length - 1);
        return array;
    }
}

//Производится быстрая сортировка..
//-78 1 2 5 12 20

//Производится сортировка слиянием..
//-78 1 2 5 12 20