namespace CourseWorkDO;

public class Helpers
{
    public static int[,] ReadMatrix(string Path, int n, int m) //зчитує матрицю з файлу по шляху Path та повертає її
    {
        int[,] matrix = new int[,] { }; //пуста матриця, в яку записується зчитана з файлу матриця
        try
        {
            string[] lines = File.ReadAllLines(Path);
            //int n = lines.Length;

            matrix = new int[n, m];

            string rowOfMatrix;
            for (int i = 0; i < n; i++)
            {
                rowOfMatrix = (lines[i]);

                char[] whitespace = new char[] { ' ', '\t' };
                string[] elsOfMatrix = rowOfMatrix.Split(whitespace);
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = Convert.ToInt32(elsOfMatrix[j]);
                }
            }
        }

        catch (DirectoryNotFoundException e)
        {
            Console.WriteLine("\n" + e.Message);
            Console.WriteLine("Change the specified file path to an existing one, " +
                              "or create the specified path on your computer and paste the appropriate file there,\n" +
                              "then " +
                              "press Enter to read the Matrix from the added file...\n" +
                              "Enter new path here or  only press Enter if you already changed the directory:");

            string rightPathName = Console.ReadLine(); //waiting the user create the missing file and directory,
                                                       //or will input another file path that exists
            while (rightPathName != "" && !rightPathName.Contains(":"))
            {
                Console.WriteLine("Wrong input path. Path must have ':' and slash characters. Try again:");
                rightPathName = Console.ReadLine();
            }
            if (rightPathName != "") //
            {
                Path = @rightPathName;
            }
            return ReadMatrix(Path, n, m); //виклик ЦЬОГО Ж методу читання матриці та одразу ж повернення
        }                                //повернутого ним 2-вимірного масиву типу [n,m]
                                        //без запису його у нову (другу за рахунком в цьому методі) змінну
                                       //типу [n,m], щоб не захаращувати новим об'єктом оперативну пам'ять.
                                      //Тобто це така-собі рекурсія, що припиняється, як тільки файл буде додано.
                                     //Перша за рахунком змінна  int[,] matrix = new int[,] { }; є порожньою, тому не захаращує RAM
        catch (FileNotFoundException e)
        {
            Console.WriteLine("\n" + e.Message);
            Console.WriteLine("Paste the needed file on the path above  " +
                              "and then " +
                              "press Enter to read the Matrix from the added file...");
            Console.ReadKey(); //waiting the user add the missing file
            return ReadMatrix(Path, n, m); //пояснення аналогічне до попереднього
        }
        catch (Exception e)
        {
            Console.WriteLine("\n" + e.Message); Console.WriteLine("Exception source: {0}", e.Source);
        }

        return matrix;
    }

    public static void Print(int[,] matrix, int n, int m, string name)
    {
        //int n = (int)Math.Sqrt(matrix.Length);
        //Console.WriteLine(matrix.Length);
        Console.WriteLine("\n" + name);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
                Console.Write(matrix[i, j] + " ");
            Console.WriteLine();
        }
    }

    public static List<int> rewrite_WorkNumbers_to_IntList(List<Work> WorkVector)
    {
        List<int> IntList = new List<int>();
        for (int i = 0; i < WorkVector.Count; i++)
        {
            IntList.Add(WorkVector[i].Number + 1);
        }
        return IntList;
    }

    public static void rewriteMatrixIntoVectors(int[,] t, ref List<Work> ta, ref List<Work> tb)
    {
        for (int i = 0; i < t.Length / 2; i++)
        {
            var work = new Work()
            {
                Number = i,
                Time = t[i, 0]
            };
            ta.Add(work);

            var workB = new Work()
            {
                Number = i,
                Time = t[i, 1]
            };
            tb.Add(workB);
        }
    }
    public static void rewriteMatrixIntoVectors(int[,] t, ref int[] ta, ref int[] tb)
    {
        for (int i = 0; i < t.Length / 2; i++)
        {
            ta[i] = t[i, 0];
            tb[i] = t[i, 1];
        }
    }

    public static void PrintWorkVector(List<Work> worklist)
    {
        Console.Write("\nТривалiсть роботи:  ");

        foreach (var w in worklist)
        {
            Console.Write(w.Time + "\t");
        }
        Console.Write("\nНомер роботи:       ");
        foreach (var w in worklist)
        {
            Console.Write((w.Number + 1) + "\t");
        }
        Console.Write("\n\n");
        //Тривалість роботи:
        //Номер роботи:     
    }

    public static void PrintSchedule(List<int>[] S)
    {
        Console.Write("Пiдрозклад верстата А:  ");
        PrintList(S[0]);
        
        Console.Write("Пiдрозклад верстата B:  ");
        PrintList(S[1]);
    }
    public static void PrintList(List<int> list)
    {
        foreach (int number in list)
        {
            Console.Write(number + " ");
        }
        Console.Write("\n");
    }

    public static void PrintArr(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }

    public static int F(int r, int[,] T, int[] t, int[] iB)
    {       //F oбчислює тривалiсть виконання пiдрозкладів (які передаються замість iB)
        //Console.WriteLine(r);
        //PrintArr(t);
        //PrintArr(iB);

        //F_B(int r, int[,] T, int[] t, int[] iB);
        if (r == 0) //значення F1 (трив прох 1ї роботи)
        {
            int TT = T[iB[r], 0];
            int tt = t[iB[r] - 1];
            return TT + tt;
        }
        else //значення Fr (трив прох r-ї роботи)
        {
            int TT = T[iB[r], iB[r - 1]];
            int tt = t[iB[r] - 1];
            int F_previous = F(r - 1, T, t, iB);
            return TT + tt + F_previous;
        }
    }

    public static int Makespan(int[,] Ra_init, int[,] Rb_init, int[,] t, List<int>[] S)
    {
        int[] SA = S[0].ToArray();
        int[] SB = S[1].ToArray();

        int n = t.Length / 2;

        int[] taArr = new int[n];
        int[] tbArr = new int[n];
        rewriteMatrixIntoVectors(t, ref taArr, ref tbArr);

        List<int> taList = taArr.ToList();
        taList.Insert(0, 0);
        int[] ta = taList.ToArray();

        List<int> tbList = tbArr.ToList();
        tbList.Insert(0, 0);
        int[] tb = tbList.ToArray();

        int[,] RA = ConvertMatrix(Ra_init, n);//матр налаштувань у потрібному форматі
        int[,] RB = ConvertMatrix(Rb_init, n);
        //Print(RB, n+1, n+1, "");

        //int q = SA.Length;
        ////if(--q== SA.Length - 1) { Console.WriteLine("OK"); }
        //Console.WriteLine("Тривалiсть проходження" + q + "-ї роботи пiдрозкладу SA" + " складає\t" + F(--q, RA, ta, SA) + " хв");

        //q = SB.Length;
        //Console.WriteLine("Тривалiсть проходження" + q + "-ї роботи пiдрозкладу SB" + " складає\t" + F(--q, RB, tb, SB) + " хв");

        return Math.Max(F(SA.Length - 1, RA, ta, SA), F(SB.Length - 1, RB, tb, SB));
    }
    public static int[,] ConvertMatrix(int[,] R, int n)
    {
        int[,] newR = new int[n + 1, n + 1];
        int[] tmpArr = new int[n + 1];

        tmpArr[0] = 0;
        for (int i = 1; i <= n; i++)
        {
            tmpArr[i] = R[0, i - 1];
        }

        //for (int i = 0; i < tmpArr.Length; i++)
        //{
        //    Console.Write(tmpArr[i] + " ");
        //}

        for (int i = 0; i <= n; i++)
        {
            newR[0, i] = 0;
            newR[i, 0] = tmpArr[i];
            for (int j = 1; j <= n; j++)
            {
                newR[i, j] = R[i, j - 1];
            }
        }
        return newR;
    }
}