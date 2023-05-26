namespace CourseWorkDO;

public class Algorithms
{
    public static List<int>[] JadibnyAlhorythm(int[,] Ra, int[,] Rb, int[,] t, int[] I) //спільний алгоритм
    {
        int FA = 0, FB = 0;
        List<int> SA = new List<int>();
        int[] currentSAListOfWorksInArray = new int[] { };
        List<int> SB = new List<int>();
        int[] currentSBListOfWorksInArray = new int[] { };
        List<int> IList = I.ToList();

        int n = t.Length / 2;

        int[] ta = new int[n];
        int[] tb = new int[n];
        Helpers.rewriteMatrixIntoVectors(t, ref ta, ref tb);
        List<int> taList = ta.ToList();
        taList.Insert(0, 0);
        ta = taList.ToArray();
        List<int> tbList = tb.ToList();
        tbList.Insert(0, 0);
        tb = tbList.ToArray();

        int lastWorkDoneA = -1;
        int lastWorkDoneB = -1;
        int maxTime = -1;
        while (IList.Count > 0)
        {
            /*if (IList.Count == 1)
            {
                if (FA == FB)
                {
                    int maxWorkIndex = -1;
                    foreach (int i in IList)
                    {
                        int sumTimeA = t[i, 0] + Ra[lastWorkDoneA, i];
                        int sumTimeB = t[i, 0] + Rb[lastWorkDoneB, i];
                        if (sumTimeA >= sumTimeB)
                        {
                            maxTime = sumTimeB;
                            maxWorkIndex = i;
                            if (maxWorkIndex != -1)
                            {
                                SB.Add(maxWorkIndex);
                                lastWorkDoneB = maxWorkIndex;
                                IList.Remove(maxWorkIndex);
                                currentSAListOfWorksInArray = SB.ToArray();
                                Console.WriteLine($"FB:{FB += maxTime}");
                            }
                        }
                        else
                        {
                            maxTime = sumTimeA;
                            maxWorkIndex = i;
                            if (maxWorkIndex != -1)
                            {
                                SA.Add(maxWorkIndex);
                                lastWorkDoneA = maxWorkIndex;
                                IList.Remove(maxWorkIndex);
                                currentSAListOfWorksInArray = SA.ToArray();
                                Console.WriteLine($"FA:{FA += maxTime}");
                            }
                        }
                        break;
                    }

                }
                break;
            }*/
            if (FA <= FB)
            {
                maxTime = -1;
                int maxWorkIndex = -1;
                foreach (int i in IList)
                {
                    if (lastWorkDoneA == -1)
                    {
                        int sumTime = t[i, 0] + Ra[0, i];
                        int sumTimeB = t[i, 1] + Rb[0, i];
                        if (sumTime > maxTime && sumTime <= t[i, 1] + Rb[0, i])
                        {
                            maxTime = sumTime;
                            maxWorkIndex = i;
                        }
                    }
                    else
                    {
                        int sumTime = t[i, 0] + Ra[lastWorkDoneA + 1, i];
                        int sumTimeB = t[i, 1] + Rb[lastWorkDoneA + 1, i];
                        if (sumTime > maxTime && sumTime <= t[i, 0] + Rb[lastWorkDoneA + 1, i])
                        {
                            maxTime = sumTime;
                            maxWorkIndex = i;
                        }
                    }
                }
                if (maxWorkIndex != -1)
                {
                    SA.Add(maxWorkIndex);
                    lastWorkDoneA = maxWorkIndex;
                    IList.Remove(maxWorkIndex);
                    currentSAListOfWorksInArray = SA.ToArray();
                    //Console.WriteLine($"FA:{FA += maxTime}");
                    FA += maxTime;
                }
            }
            else
            {
                maxTime = -1;
                int maxWorkIndex = -1;
                foreach (int i in IList)
                {
                    if (lastWorkDoneB == -1)
                    {
                        int sumTime = t[i, 1] + Rb[0, i];
                        int sumTimeA = t[i, 0] + Ra[0, i];
                        if (sumTime > maxTime && sumTime <= t[i, 0] + Ra[0, i])
                        {
                            maxTime = sumTime;
                            maxWorkIndex = i;
                        }
                    }
                    else
                    {
                        int sumTime = t[i, 1] + Rb[lastWorkDoneB + 1, i];
                        int sumTimeA = t[i, 0] + Ra[lastWorkDoneB + 1, i];
                        if (sumTime > maxTime && sumTime <= t[i, 0] + Ra[lastWorkDoneB + 1, i])
                        {
                            maxTime = sumTime;
                            maxWorkIndex = i;
                        }
                    }
                }
                if (maxWorkIndex != -1)
                {
                    SB.Add(maxWorkIndex);
                    lastWorkDoneB = maxWorkIndex;
                    IList.Remove(maxWorkIndex);
                    currentSBListOfWorksInArray = SB.ToArray();
                    //Console.WriteLine($"FB:{FB += maxTime}");
                    FB += maxTime;
                }
            }
        }
        List<int>[] S = new List<int>[2];
        S[0] = SA;
        S[1] = SB;
        for (int i = 0; i < S[0].Count; i++)
        {
            S[0][i]++;
        }
        for (int i = 0; i < S[1].Count; i++)
        {
            S[1][i]++;
        }
        //Console.WriteLine($"Makespan Jadibnoho Alhorythmu :{Makespan(Ra, Rb, t, S)}");
        return S;
    }
    public static List<int>[] SPT(int[,] t, int[,] Ra, int[,] Rb, int n) //Єдинорогов
    {
        List<Work> ta = new List<Work>();
        List<Work> tb = new List<Work>();
        Helpers.rewriteMatrixIntoVectors(t, ref ta, ref tb);
        //PrintWorkVector(ta);
        //PrintWorkVector(tb);

        List<Work> SA = new List<Work>();
        List<Work> SB = new List<Work>();

        //PrintWorkVector(ta);
        //PrintWorkVector(tb);

        ta = ta.OrderBy(w => w.Time).ToList();
        tb = tb.OrderBy(w => w.Time).ToList();


        //Console.Write("\nВідсортований за тривалiстю вектор ta:       ");
        //PrintWorkVector(ta);
        //PrintWorkVector(tb);

        //int c = 0;
        for (int i = 1; i <= n; i++)
        {
            if (i % 4 == 1 || i % 4 == 0)
            {
                SA.Add(ta[0]);
                int indx = ta[0].Number; //знаходимо номер першої роботи зі списку тривалостей для А

                ta.RemoveAt(0); //видаляємо перший елемент зі списку тривалостей для А. Або: ta.RemoveAll(x => x.Number == indx);
                tb.RemoveAll(x => x.Number == indx);
            }
            else if (i % 4 == 2 || (i + 1) % 4 == 0)
            {
                SB.Add(tb[0]);
                int indx = tb[0].Number; //знаходимо номер першої роботи зі списку тривалостей для B

                tb.RemoveAt(0); //видаляємо перший елемент зі списку тривалостей для B
                ta.RemoveAll(x => x.Number == indx);
            }
            /*c++;*/
        }
        //Console.WriteLine("к-ть ітерацій фору: "+c);

        //Console.Write("\nta i tb пiсля алгоритму SPT:       ");
        //PrintWorkVector(ta);
        //PrintWorkVector(tb);

        //Console.Write("\n--SA i SB пiсля алгоритму SPT:       ");

        //PrintWorkVector(SA);
        //PrintWorkVector(SB);
        //Console.Write("--\n");

        List<int>[] S = new List<int>[2];
        S[0] = Helpers.rewrite_WorkNumbers_to_IntList(SA);
        S[1] = Helpers.rewrite_WorkNumbers_to_IntList(SB);

        return S; //цей алгоритм спочатку повертає розклад, а по цього розкладу потім рахуємо мейкспан
    }
    public static List<int>[] LocalPoshukAlhorythmType1(int[,] Ra, int[,] Rb, int[,] t, List<int>[] S, int makespan)
    {
        List<int>[] STemp = new List<int>[2];
        int[] SA = S[0].ToArray();
        int[] SB = S[1].ToArray();
        int FA = makespan;
        int makespanNew = 0;
        int n;
        if (SA.Length >= SB.Length)
            n = SB.Length;
        else
            n = SA.Length;
        for (int i = 0; i < n; i++) // <= / < ?
        {
            var temp = 0;
            temp = SA[SA.Length - 1 - i];
            SA[SA.Length - 1 - i] = SB[SB.Length - 1 - i];
            SB[SB.Length - 1 - i] = temp;

            STemp[0] = SA.ToList();
            STemp[1] = SB.ToList();

            makespanNew = Helpers.Makespan(Ra, Rb, t, STemp);
            if (makespanNew <= FA)
            {
                FA = makespanNew;
            }
            else
            {
                var temp1 = 0;
                temp1 = SA[SA.Length - 1 - i];
                SA[SA.Length - 1 - i] = SB[SB.Length - 1 - i];
                SB[SB.Length - 1 - i] = temp1;
            }

        }
        //Console.WriteLine($"Makespan of the Local Search between the engines:{makespanNew}");
        return STemp;
    }
    public static List<int>[] LocalSearchWithReplacesInsideOfMachine(List<int>[] S, int[,] t, int[,] RaInit, int[,] RbInit, int n) //Сабадаш
    {
        var ta = new int[n];
        var tb = new int[n];
        for (int i = 0; i < n; i++)
        {
            ta[i] = t[i, 0];
            tb[i] = t[i, 1];
        }
        List<int> taList = ta.ToList();
        taList.Insert(0, 0);
        ta = taList.ToArray();

        List<int> tbList = tb.ToList();
        tbList.Insert(0, 0);
        tb = tbList.ToArray();

        var Pa = GetAllPermutations.Permute(S[0].ToArray());
        var Pb = GetAllPermutations.Permute(S[1].ToArray());

        var Sa = S[0].ToArray();
        var Sb = S[1].ToArray();

        var Ra = Helpers.ConvertMatrix(RaInit, n);
        var Rb = Helpers.ConvertMatrix(RbInit, n);

        var Fa = Helpers.F(Sa.Length - 1, Ra, ta, Sa);
        var Fb = Helpers.F(Sb.Length - 1, Rb, tb, Sb);

        while ((Pa.Count != 0 && Fa > Fb) || (Pb.Count != 0 && Fa < Fb))
        {
            while (Pa.Count != 0 && Fa > Fb)
            {
                var PaCurr = Pa[^1].ToArray();
                var FTemp = Helpers.F(PaCurr.Length - 1, Ra, ta, PaCurr);
                Pa.RemoveAt(Pa.Count - 1);
                if (FTemp < Fa)
                {
                    Sa = PaCurr;
                    Fa = FTemp;
                }
            }
            while (Pb.Count != 0 && Fa < Fb)
            {
                var PbCurr = Pa[Pa.Count].ToArray();
                var FTemp = Helpers.F(PbCurr.Length - 1, Rb, tb, PbCurr);
                Pa.RemoveAt(Pb.Count - 1);
                if (FTemp < Fb)
                {
                    Sb = PbCurr;
                    Fb = FTemp;
                }
            }
        }

        List<int>[] result = new List<int>[2];
        result[0] = Sa.ToList();
        result[1] = Sb.ToList();

        return result;
    }
}