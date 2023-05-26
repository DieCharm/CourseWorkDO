using CourseWorkDO;

class Program
{
    public static void SaveInMathCadFormat(int[] vector, string Path, string name) // приймає int-вектор
    {// Метод записує вектор значень (які є координатами точок по одній з координатних осей графіка)
     //в файл у вигляді тексту, який читається програмою MathCad, в якій можна створити новий графік та додати на нього
     //   один вектор значень як координати майбутніх точок по горизонтальній осі (це ніби вектор аргументів функції),
     //а інший вектор значень - відповідно координати точок по вертикальній осі (це ніби вектор значень функції).
        try
        {
            StreamWriter swMatrix = new(Path, false);//
            swMatrix.Write("(:= (@LABEL VARIABLE {0}) ", name);
            swMatrix.Write("(@MATRIX " + vector.Length + " " + 1 + " ");
            for (int i = 0; i < vector.Length; i++)
            {
                string el = Convert.ToString(vector[i]);
                //swMatrix.Write(arr[i, j] + " ");
                swMatrix.Write(el + " ");
                //for (int j = 0; j < Column; j++)
                //{

                //}
            }
            swMatrix.WriteLine("))");
            swMatrix.Close();
        }
        catch (DirectoryNotFoundException e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("Change the specified path to the file with mathCad format to an existing one, " +
                              "or create the specified path on your computer,\n" +
                              "then " +
                              "press Enter to save the Matrix to the created path...\n" +
                              //"Enter new path here or  " +
                              "just press Enter if you already changed the directory:");

            Console.ReadLine(); //waiting the user create the missing directory,
            SaveInMathCadFormat(vector, Path, name);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message); Console.WriteLine("Exception source: {0}", e.Source);
        }

    }

    public static void SaveInMathCadFormat(double[] vector, string Path, string name) // приймає double-вектор
    {// Метод записує вектор значень (які є координатами точок по одній з координатних осей графіка)
     //в файл у вигляді тексту, який читається програмою MathCad, в якій можна створити новий графік та додати на нього
     //   один вектор значень як координати майбутніх точок по горизонтальній осі (це ніби вектор аргументів функції),
     //а інший вектор значень - відповідно координати точок по вертикальній осі (це ніби вектор значень функції).
        try
        {
            StreamWriter swMatrix = new(Path, false);//
            swMatrix.Write("(:= (@LABEL VARIABLE {0}) ", name);
            swMatrix.Write("(@MATRIX " + vector.Length + " " + 1 + " ");
            for (int i = 0; i < vector.Length; i++)
            {
                string el = Convert.ToString(vector[i]).Replace(',', '.');
                //swMatrix.Write(arr[i, j] + " ");
                swMatrix.Write(el + " ");
                //for (int j = 0; j < Column; j++)
                //{

                //}
            }
            swMatrix.WriteLine("))");
            swMatrix.Close();
        }
        catch (DirectoryNotFoundException e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("Change the specified path to the file with mathCad format to an existing one, " +
                              "or create the specified path on your computer,\n" +
                              "then " +
                              "press Enter to save the Matrix to the created path...\n" +
                              //"Enter new path here or  " +
                              "just press Enter if you already changed the directory:");

            Console.ReadLine(); //waiting the user create the missing directory,
            SaveInMathCadFormat(vector, Path, name);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message); Console.WriteLine("Exception source: {0}", e.Source);
        }

    }
    public static void PrintMatrix(int[,] matrix, int n, int m, string name)
    {
        //int n = (int)Math.Sqrt(matrix.Length);
        //Console.WriteLine(matrix.Length);
        Console.WriteLine("\n" + name);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
                Console.Write(matrix[i, j] + " "/*"\t"*/);
            Console.WriteLine();
        }
    }

    public static int[,] GenMatrix(int n, int m) //генерація матриці n на m
    {
        int[,] matr = new int[n, m];
        Random rnd = new();
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                matr[i, j] = rnd.Next(1, 10);
        return matr;
    }
    public static void MultiplyMatrixByScalar(ref int[,] matr, int k, int n, int m) //множить матрицю [n; m] на коефіцієнт 
    {
        //int[,] matr = new int[n, m];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                matr[i, j] *= k;
        //return matr;
    }
    public static void GeneratorOfIndividualTasks(int n, int k1, int k2, ref int[,] t, ref int[,] Ra, ref int[,] Rb)
    {
        t = GenMatrix(n, 2);
        Ra = GenMatrix(n + 1, n);
        Rb = GenMatrix(n + 1, n);

        MultiplyMatrixByScalar(ref t, k2, n, 2);    // k2 впливає на тривалості t
        MultiplyMatrixByScalar(ref Ra, k1, n + 1, n); // k1 впливає на час переналаштування tau
        MultiplyMatrixByScalar(ref Rb, k1, n + 1, n);
    }

    //public static void Experiment_4(int k1, int k2, int[,] t, int[,] Ra, int[,] Rb)
    //{                        //подаємо на вхід k1=1 та k2=1
    //    int iterations = 20;
    //    int n_max = 30; //розмірність задачі n змінюватиметься від 1 до 30

    //    double[] DeviationGreedy_depending_on_n = new double[n_max];
    //    string PathDeviationGreedy = @"D:\KPI\6_sem\Теорія розкладів\DO_course work\4\DO_course work\Experiment_4\Відхилення_ЦФ_жадібного_алгоритму_залежно_від_n.txt";

    //    double[] DeviationSPT_depending_on_n = new double[n_max];
    //    string PathDeviationSPT = @"D:\KPI\6_sem\Теорія розкладів\DO_course work\4\DO_course work\Experiment_4\Відхилення_ЦФ_SPT-алгоритму_залежно_від_n.txt";

    //    double[] DeviationLocal_1_depending_on_n = new double[n_max];
    //    string PathDeviationLocal_1 = @"D:\KPI\6_sem\Теорія розкладів\DO_course work\4\DO_course work\Experiment_4\Відхилення_ЦФ_локального_пошуку_1_залежно_від_n.txt";

    //    double[] DeviationLocal_2_depending_on_n = new double[n_max];
    //    string PathDeviationLocal_2 = @"D:\KPI\6_sem\Теорія розкладів\DO_course work\4\DO_course work\Experiment_4\Відхилення_ЦФ_локального_пошуку_2_залежно_від_n.txt";


    //    int[] n_values = new int[n_max];
    //    string Path_n = @"D:\KPI\6_sem\Теорія розкладів\DO_course work\4\DO_course work\Experiment_3\Масив значень n.txt";

    //    for (int i = 1; i <= n_max; i++)
    //    {
    //        double[] DeviationGreedyArr = new double[iterations];
    //        double[] DeviationSPTArr = new double[iterations];
    //        for (int j = 0; j < iterations; j++)
    //        {
    //            //на кожній з 20ти ітерацій генерується своя інд задача та знаходиться значення еталонного розв'язку для неї
    //            GeneratorOfIndividualTasks(i, k1, k2, ref t, ref Ra, ref Rb);

    //            //Знаходимо еталонне (найкраще) значення ЦФ:
    //            int makespanStandard = Get_Standard(i, t, Ra, Rb);

    //            //Тут має знаходитись мейкспан для жадбіного. Поки стоїть 2 як заглушка
    //            int makespanGreedy = 2;
    //            //List<int>[] S = жадібний алгоритм(n, ....)
    //            //Makespan(Ra, Rb, t, S, ref makespanGreedy);

    //            //Тут знаходимо мейкспан для СПТ:
    //            List<int>[] S = SPT(t, Ra, Rb, i);
    //            int makespanSPT = Makespan(Ra, Rb, t, S); //він знаходиться по результаючому розкладу S, який повернув алгоритм

    //            //Тут поки що замість жадібного підставляємо лок_пошук_1:
    //            //makespanGreedy = LocalPoshukAlhorythmType1(Ra, Rb, t, S, makespanSPT);


    //            //Визначаємо відхилення жадібного від еталону (у відсотках) та записуємо в масив: 
    //            double DeviationGreedy = RelativeDeviation(makespanGreedy, makespanStandard);
    //            DeviationGreedyArr[j] = DeviationGreedy;

    //            //Визначаємо відхилення СПТ від еталону (у відсотках) та записуємо в масив: 
    //            double DeviationSPT = RelativeDeviation(makespanSPT, makespanStandard);
    //            DeviationSPTArr[j] = DeviationSPT;
    //        }

    //        //визначаємо середні відхилення (тобто рахуємо середнє арифметичне із вже порахованого масиву відхилень) значень ЦФ для А1 та А2 відновно
    //        //І це ми робимо на кожній ітерації, тобто при кожному k від 1 до 30 включно
    //        DeviationGreedy_depending_on_n[i - 1] = CalculateAverage(DeviationGreedyArr);
    //        DeviationSPT_depending_on_n[i - 1] = CalculateAverage(DeviationSPTArr);

    //        n_values[i - 1] = i; //заповнюємо масив значеннь змінного параметра k1
    //    }
    //    SaveInMathCadFormat(DeviationGreedy_depending_on_n, PathDeviationGreedy, "Deviation_Greedy"); //nameGreedy
    //    SaveInMathCadFormat(DeviationSPT_depending_on_n, PathDeviationSPT, "Deviation_SPT"); //nameSPT

    //    SaveInMathCadFormat(n_values, Path_n, "n");
    //}

    //public static void Experiment_2(int n, int k1, int[,] t, int[,] Ra, int[,] Rb)
    //{                        //подаємо на вхід k1=1
    //    int iterations = 20;
    //    int k2max = 30; //k2 змінюватиметься від 1 до 30

    //    double[] DeviationGreedy_depending_on_K2 = new double[k2max];
    //    string PathDeviationGreedy = @"D:\KPI\6_sem\Теорія розкладів\DO_course work\4\DO_course work\Experiment_2\Відхилення_ЦФ_жадібного_алгоритму_залежно_від_k2.txt";

    //    double[] DeviationSPT_depending_on_K2 = new double[k2max];
    //    string PathDeviationSPT = @"D:\KPI\6_sem\Теорія розкладів\DO_course work\4\DO_course work\Experiment_2\Відхилення_ЦФ_SPT-алгоритму_залежно_від_k2.txt";

    //    int[] k2_values = new int[k2max];
    //    string Path_k1 = @"D:\KPI\6_sem\Теорія розкладів\DO_course work\4\DO_course work\Experiment_2\Масив значень k2.txt";

    //    for (int i = 1; i <= k2max; i++)
    //    {
    //        double[] DeviationGreedyArr = new double[iterations];
    //        double[] DeviationSPTArr = new double[iterations];
    //        for (int j = 0; j < iterations; j++)
    //        {
    //            //на кожній з 20ти ітерацій генерується своя інд задача та знаходиться значення еталонного розв'язку для неї
    //            GeneratorOfIndividualTasks(n, k1, i, ref t, ref Ra, ref Rb); //  і - це значення k на одній з 30ти ітерацій

    //            //Знаходимо еталонне (найкраще) значення ЦФ:
    //            int makespanStandard = Get_Standard(n, t, Ra, Rb);

    //            //Тут має знаходитись мейкспан для жадбіного. Поки стоїть 2 як заглушка
    //            int makespanGreedy = 2;
    //            //List<int>[] S = жадібний алгоритм(n, ....)
    //            //Makespan(Ra, Rb, t, S, ref makespanGreedy);

    //            //Тут знаходимо мейкспан для СПТ:
    //            List<int>[] S = SPT(t, Ra, Rb, n);
    //            int makespanSPT = Makespan(Ra, Rb, t, S); //він знаходиться по результаючому розкладу S, який повернув алгоритм

    //            //Тут поки що замість жадібного підставляємо лок_пошук_1:
    //            //makespanGreedy = LocalPoshukAlhorythmType1(Ra, Rb, t, S, ref makespanSPT);


    //            //Визначаємо відхилення жадібного від еталону (у відсотках) та записуємо в масив: 
    //            double DeviationGreedy = RelativeDeviation(makespanGreedy, makespanStandard);
    //            DeviationGreedyArr[j] = DeviationGreedy;

    //            //Визначаємо відхилення СПТ від еталону (у відсотках) та записуємо в масив: 
    //            double DeviationSPT = RelativeDeviation(makespanSPT, makespanStandard);
    //            DeviationSPTArr[j] = DeviationSPT;
    //        }

    //        //визначаємо середні відхилення (тобто рахуємо середнє арифметичне із вже порахованого масиву відхилень) значень ЦФ для А1 та А2 відновно
    //        //І це ми робимо на кожній ітерації, тобто при кожному k від 1 до 30 включно
    //        DeviationGreedy_depending_on_K2[i - 1] = CalculateAverage(DeviationGreedyArr);
    //        DeviationSPT_depending_on_K2[i - 1] = CalculateAverage(DeviationSPTArr);

    //        k2_values[i - 1] = i; //заповнюємо масив значеннь змінного параметра k1
    //    }
    //    SaveInMathCadFormat(DeviationGreedy_depending_on_K2, PathDeviationGreedy, "Deviation_Greedy"); //nameGreedy
    //    SaveInMathCadFormat(DeviationSPT_depending_on_K2, PathDeviationSPT, "Deviation_SPT"); //nameSPT

    //    SaveInMathCadFormat(k2_values, Path_k1, "k2");
    //}

    
    public static void Experiment_1(int n, int k2, int[,] t, int[,] Ra, int[,] Rb, int[] I)
    {                        //подаємо на вхід k2=1
        int iterations = 20;
        int k1max = 30; //k1 змінюватиметься від 1 до 30

        int step = 1;

        double[] DeviationGreedy_depending_on_K = new double[k1max];
        string PathDeviationGreedy = @"D:\KPI\6_sem\Теорія розкладів\DO_course work\4\DO_course work\Experiment_1\Відхилення_ЦФ_жадібного_алгоритму_залежно_від_k1.txt";

        double[] DeviationSPT_depending_on_K = new double[k1max];
        string PathDeviationSPT = @"D:\KPI\6_sem\Теорія розкладів\DO_course work\4\DO_course work\Experiment_1\Відхилення_ЦФ_SPT-алгоритму_залежно_від_k1.txt";

        int[] k_values = new int[k1max];
        string Path_k1 = @"D:\KPI\6_sem\Теорія розкладів\DO_course work\4\DO_course work\Experiment_1\Масив значень k1.txt";

        for (int i = 1; i <= k1max; i++)
        {
            double[] DeviationGreedyArr = new double[iterations];
            double[] DeviationSPTArr = new double[iterations];
            for (int j = 0; j < iterations; j++)
            {
                //на кожній з 20ти ітерацій генерується своя інд задача та знаходиться значення еталонного розв'язку для неї
                GeneratorOfIndividualTasks(n, i*step, k2, ref t, ref Ra, ref Rb);

                //Знаходимо еталонне (найкраще) значення ЦФ:
                int makespanStandard = Get_Standard(n, t, Ra, Rb, I);

                //Тут знаходимо мейкспан для жадбіного:                
                List<int>[] S_Greedy = Algorithms.JadibnyAlhorythm(Ra, Rb, t, I);
                int makespanGreedy = Helpers.Makespan(Ra, Rb, t, S_Greedy);

                //Тут знаходимо мейкспан для СПТ:
                List<int>[] S = Algorithms.SPT(t, Ra, Rb, n);
                int makespanSPT = Helpers.Makespan(Ra, Rb, t, S); //він знаходиться по результаючому розкладу S, який повернув алгоритм

                ////Тут поки що замість жадібного підставляємо лок_пошук_1:
                //makespanGreedy = LocalPoshukAlhorythmType1(Ra, Rb, t, S, makespanSPT);


                //Визначаємо відхилення жадібного від еталону (поки не у відсотках,а в долях) та записуємо в масив: 
                double DeviationGreedy = RelativeDeviation(makespanGreedy, makespanStandard);
                DeviationGreedyArr[j] = DeviationGreedy;

                //Визначаємо відхилення СПТ від еталону (у відсотках) та записуємо в масив: 
                double DeviationSPT = RelativeDeviation(makespanSPT, makespanStandard);
                DeviationSPTArr[j] = DeviationSPT;
            }

            //визначаємо середні відхилення (тобто рахуємо середнє арифметичне із вже порахованого масиву відхилень) значень ЦФ для А1 та А2 відновно
            //І це ми робимо на кожній ітерації, тобто при кожному k від 1 до 30 включно
            DeviationGreedy_depending_on_K[i - 1] = CalculateAverage(DeviationGreedyArr);
            DeviationSPT_depending_on_K[i - 1] = CalculateAverage(DeviationSPTArr);

            k_values[i - 1] = i* step; //заповнюємо масив значеннь змінного параметра k1
        }
        SaveInMathCadFormat(DeviationGreedy_depending_on_K, PathDeviationGreedy, "Deviation_Greedy"); //nameGreedy
        SaveInMathCadFormat(DeviationSPT_depending_on_K, PathDeviationSPT, "Deviation_SPT"); //nameSPT

        SaveInMathCadFormat(k_values, Path_k1, "k1");
    }
    public static double CalculateAverage(double[] arr)
    {
        if (arr.Length == 0)
        {
            return 0.0; // або ви можете повернути значення, яке вважаєте за потрібне у такому випадку
        }

        double sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        double average = sum / arr.Length;
        return average;
    }

    public static double RelativeDeviation(int makespan, int makespanStandard)
    { // рахуємо, на скільки відсотків makespan досліджуваного алгоритму відхиляється від makespanStandard
        int difference = makespan - makespanStandard;
        double deviation = (double)difference / makespanStandard; //* 100;

        return deviation;
        //якщо виникає ділення на 0, то повертаємо результат 0 (це можна реалізувати, аби не було похибок)
    }
    
    public static int Get_Standard(int n, int[,] t, int[,] Ra, int[,] Rb, int[] I)
    {   
        //Тут знаходимо мейкспан для жадбіного:                
        List<int>[] S_Greedy = Algorithms.JadibnyAlhorythm(Ra, Rb, t, I);
        int makespanGreedy = Helpers.Makespan(Ra, Rb, t, S_Greedy);

        //Тут знаходимо мейкспан дл SPT:
        List<int>[] S = Algorithms.SPT(t, Ra, Rb, n);
        int makespanSPT = Helpers.Makespan(Ra, Rb, t, S);

        List<int>[] S_Loc_1 = Algorithms.LocalPoshukAlhorythmType1(Ra, Rb, t, S, makespanSPT);
        int makespanLocalSearch_1 = Helpers.Makespan(Ra, Rb, t, S_Loc_1);
        //S = LocalSearch_1(n, ....)                
        //Makespan(Ra, Rb, t, S, ref makespanLocalSearch_1);

        int makespanLocalSearch_2 = 1000000000; //це поки що значення-заглушка
        ////S = LocalSearch_2(n, ....)                
        //Makespan(Ra, Rb, t, S, ref makespanLocalSearch_2);

        int makespanStandard = new[] { makespanGreedy, makespanSPT, makespanLocalSearch_1, makespanLocalSearch_2 }.Min();

        return makespanStandard;
    }

    static void Menu1()
    {
        Console.WriteLine("Введiть номер роздiлу, який вас цiкавить: \n 1) Робота з iндивiдуальною задачею; \n 2) Експериментальне дослiдження алгоритмiв;");
    }
    static int Menu2(int i)
    {
        Console.WriteLine("Введiть номер пункту, який вiдповiдає типу подачi даних: \n 1) Введення даних вручну;\n 2) Згенерувати данi випадковим чином; \n 3) Зчитати з файлу;");
        int menuChoice2 = Convert.ToInt32(Console.ReadLine());
        if (menuChoice2 == 1)
        {
            //Введення вручну всіх параметрів
            return (i = 1);
        }
        else if (menuChoice2 == 2)
        {
            //Генерація рандомно
            return (i = 2);
        }
        else if (menuChoice2 == 3)
        {
            //Список
            return (i = 3);
        }
        else
        {
            Console.WriteLine("bb");
            Environment.Exit(0);
            return i;
        }
    }
    static void Menu3(ref int n, ref int[,] t, ref int[,] Ra, ref int[,] Rb)
    {
        Console.WriteLine("Введiть тип експериментального дослiдження: \n 1) Виконати експеримент 1 та вивести його результати; \n 2) Виконати експеримент 2 та вивести його результати; \n 3) Виконати експеримент 3 та вивести його результати;\n 4) Виконати експеримент 4 та вивести його результати;\n 5) Виконати та вивести результати одразу всiх експериментів.");
        int menuChoice4 = Convert.ToInt32(Console.ReadLine());
        if ((menuChoice4 == 1))
        {
            //Experiment1 - змінюємо к1 (переналаштування R (тау) )
            n = 30;     //передаємо першому експерименту фіксовані n = 30;  та  k2 = 1;
            int k2 = 1; //

            int[] I = new int[n];
            I = new int[n];
            for (int j = 0; j < n; j++)
            {
                I[j] = j;
            }
            //PrintArr(I);

            Console.WriteLine("Результати експерименту 1 записанi у файли папки Experiment_1");
            Experiment_1(n, k2, t, Ra, Rb, I);


            GeneratorOfIndividualTasks(n, 10, k2, ref t, ref Ra, ref Rb);
            PrintMatrix(t, n, 2, "Generated t:");
            PrintMatrix(Ra, n + 1, n, "Generated Ra:");
            PrintMatrix(Rb, n + 1, n, "Generated Rb:");

            int best = Get_Standard(n, t, Ra, Rb, I);
            Console.WriteLine(best);
            Console.WriteLine();

            

            //string PathTEST = @"D:\KPI\6_sem\Теорія розкладів\DO_course work\4\DO_course work\test.txt";
            //string PathTEST2 = @"D:\KPI\6_sem\Теорія розкладів\DO_course work\4\DO_course work\test2.txt";
            //int[] testArrInt = { 1, 2, 5, 10, 100 };
            //double[] testArr = { 1.7, 2, 5.325235, 10, 100.003 };
            //SaveInMathCadFormat(testArr, PathTEST, "testArr");
            //SaveInMathCadFormat(testArrInt, PathTEST2, "testArrInt");


            Environment.Exit(0); //це теж заглушка на перший час
        }
        else if (menuChoice4 == 2)
        {
            //Experiment2 - змінюємо к2 (тривалість t)
            n = 30;     //передаємо другому експерименту фіксовані n = 30;  та  k1 = 1;
            int k1 = 1; //

            int[] I = new int[n];
            I = new int[n];
            for (int j = 0; j < n; j++)
            {
                I[j] = j;
            }
            //Experiment_2(n, k1, t, Ra, Rb); //k2 задано всередині експерименту =30
            Console.WriteLine("Результати експерименту 2 записанi у файли папки Experiment_2");

            GeneratorOfIndividualTasks(n, k1, 10, ref t, ref Ra, ref Rb);
            PrintMatrix(t, n, 2, "Generated t:");
            PrintMatrix(Ra, n + 1, n, "Generated Ra:");
            PrintMatrix(Rb, n + 1, n, "Generated Rb:");

            int best = Get_Standard(n, t, Ra, Rb, I);
            Console.WriteLine(best);
            Console.WriteLine();



            //string PathTEST = @"D:\KPI\6_sem\Теорія розкладів\DO_course work\4\DO_course work\test.txt";
            //string PathTEST2 = @"D:\KPI\6_sem\Теорія розкладів\DO_course work\4\DO_course work\test2.txt";
            //int[] testArrInt = { 1, 2, 5, 10, 100 };
            //double[] testArr = { 1.7, 2, 5.325235, 10, 100.003 };
            //SaveInMathCadFormat(testArr, PathTEST, "testArr");
            //SaveInMathCadFormat(testArrInt, PathTEST2, "testArrInt");



            Environment.Exit(0); //це теж заглушка на перший час
        }
        else if (menuChoice4 == 3)
        {
            //Experiment3 - змінюємо n (к-ть деталей)
            int k1 = 1;   //передаємо третьому експерименту фіксовані  k1 = 1;  k2 = 1
            int k2 = 1; //

            //Experiment_3(k1, k2, t, Ra, Rb); //k2 задано всередині експерименту =30
            Console.WriteLine("Результати експерименту 3 записанi у файли папки Experiment_3");
        }
        else if (menuChoice4 == 4)
        {
            //Experiment4 - змінюємо n (к-ть деталей)
            int k1 = 1;   //передаємо третьому експерименту фіксовані  k1 = 1;  k2 = 1
            int k2 = 1; //

            //Experiment_4(k1, k2, t, Ra, Rb, I); //k2 задано всередині експерименту =30
            Console.WriteLine("Результати експерименту 4 записанi у файли папки Experiment_4");
        }
        else if (menuChoice4 == 5)
        {
            //AllExperiments +093+H3r
        }
    }
    
    static void Main()
    {
        int n = 0; //розмірність (к-ть деталей)
        int[,] t = new int[,] { }; //Матриця тривалостей з n рядків та 2 стовпців
        int[,] Ra = new int[,] { }; /*Матриця переналаштувань верстата А*/
        int[,] Rb = new int[,] { }; //Матриця переналаштувань верстата B 
        int[] I = new int[] { }; //Масив деталей (робіт) довжиною n

        Menu1();
        int menuChoice1 = Convert.ToInt32(Console.ReadLine());
        if (menuChoice1 == 1)
        {
            int i = 0;
            i = Menu2(i);
            if (i == 1)
            {/*Вручну */}
            else if (i == 2)
            {/*Random */}
            if (i == 3) //тут мають послідовно викликатися всі 4 алгоритми та виводитись їх результати
            {
                string PathRa = @"D:\KPI\6_sem\Теорія розкладів\DO_course work\4\DO_course work\Ra.txt";//@"D:\KPI\6_sem\Теорія розкладів\DO_course work\4\DO_course work\Ra.txt";
                string PathRb = @"D:\KPI\6_sem\Теорія розкладів\DO_course work\4\DO_course work\Rb.txt";//@"D:\KPI\6_sem\Теорія розкладів\DO_course work\4\DO_course work\Rb.txt";
                string PathT = @"D:\KPI\6_sem\Теорія розкладів\DO_course work\4\DO_course work\t.txt";//@"D:\KPI\6_sem\Теорія розкладів\DO_course work\4\DO_course work\t.txt";
                
                n = 5;
                I = new int[n];
                for (int j = 0; j < n; j++)
                {
                    I[j] = j;
                }
                //PrintArr(I);

                //Зчитування файлу
                t = Helpers.ReadMatrix(PathT, n, 2);
                Ra = Helpers.ReadMatrix(PathRa, n + 1, n);
                Rb = Helpers.ReadMatrix(PathRb, n + 1, n);
                Helpers.Print(t, n, 2, "Матриця тривалостей:");
                Helpers.Print(Ra, n + 1, n, "Матриця переналаштувань для верстата А:");
                Helpers.Print(Rb, n + 1, n, "Матриця переналаштувань для верстата B:");

                Console.WriteLine(readTheMaxtrix(t));
                Console.WriteLine(readTheMaxtrix(Ra));
                Console.WriteLine(readTheMaxtrix(Rb));
            }

            //JadibnyAlhorythm();
            List<int>[] S_Greedy = Algorithms.JadibnyAlhorythm(Ra, Rb, t, I);
            Console.WriteLine("\nРезультуючий розклад Жадiбного алгоритму:");
            Helpers.PrintSchedule(S_Greedy);
            //PrintList(S_Greedy[0]);
            //PrintList(S_Greedy[1]);

            int makespanGreedy = Helpers.Makespan(Ra, Rb, t, S_Greedy);
            Console.WriteLine("\nmakespan Жадiбного алгоритму = " + makespanGreedy);


            //SPT();
            List<int>[] S_SPT = Algorithms.SPT(t, Ra, Rb, n);
            Console.WriteLine("\nРезультуючий розклад SPT-алгоритму:");
            Helpers.PrintSchedule(S_SPT);
            //PrintList(S[0]);
            //PrintList(S[1]);

            int makespanSPT = Helpers.Makespan(Ra, Rb, t, S_SPT);
            Console.WriteLine("\nmakespan SPT-алгоритму = " + makespanSPT);


            //LocalPoshukAlhorythmType1();
            List<int>[] S_Loc_1 = Algorithms.LocalPoshukAlhorythmType1(Ra, Rb, t, S_SPT, makespanSPT);

            int makespanLoc_1 = Helpers.Makespan(Ra, Rb, t, S_Loc_1);
            Console.WriteLine("\nmakespan Лок. пошуку з перестановками мiж машинами = " + makespanLoc_1);


            //LocalPoshukAlhorythmType2();
            List<int>[] S_Loc_2 = Algorithms.LocalSearchWithReplacesInsideOfMachine(S_SPT, t, Ra, Rb, n);
            Console.WriteLine("\nРозклад лок. пошуку з перестановками всерединi машин:");
            Helpers.PrintSchedule(S_SPT);

            int makespanLoc_2 = Helpers.Makespan(Ra, Rb, t, S_Loc_2);
            Console.WriteLine("\nmakespan лок. пошуку з перестановками всерединi машин = " + makespanLoc_2);



            Console.WriteLine("Type 1 if you want to go back, or 0 if you want to shut down the program:");
            int lastChoice = Convert.ToInt32(Console.ReadLine());
            if (lastChoice == 1)
            { Menu2(i); }
            else if (lastChoice == 0)
            { Environment.Exit(0); }
        }
        else if (menuChoice1 == 2)
        { Menu3(ref n, ref t, ref  Ra, ref  Rb); } 
        else { Environment.Exit(0); };
        Console.ReadLine();
    }
    
    public static int readTheMaxtrix(int[,] t)
    {
        int columns = t.GetLength(1);
        return columns;
    }
}