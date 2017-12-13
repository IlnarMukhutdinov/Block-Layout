using Graph_placement_algorithm;
namespace Course_Work__WF_Block_Layout_
{
    class SwapResult
    {
        public bool Flag { get; set; }
        public int I { get; set; }
        public int J { get; set; }

        public SwapResult(bool flag, int i, int j)
        {
            Flag = flag;
            I = i;
            J = j;
        }

        public SwapResult()
        {
            
        }
    }
    class Algorithm
    {


        public static int[] InnerLinkC1 { get; set; }

        public static int[] InnerLinkC2 { get; set; }

        public static int[] ExternalLinkC1 { get; set; }

        public static int[] ExternalLinkC2 { get; set; }

        public static int[] Connectivity { get; set; }

        public static int[,] Delta { get; set; }

        public static void InternalLinksCount()
        {
            InnerLinkC1 = new int[Config_matrix.M];
            InnerLinkC2 = new int[Config_matrix.N - Config_matrix.M];
            for (int i = 0; i < Config_matrix.M; i++)
                for (int j = 0; j < Config_matrix.M; j++)
                {
                    InnerLinkC1[i] += Config_matrix.AdjMatrixC[i, j];
                }

            for (int i = Config_matrix.M; i < Config_matrix.N; i++)
                for (int j = Config_matrix.M; j < Config_matrix.N; j++)
                {
                    InnerLinkC2[i - Config_matrix.M] += Config_matrix.AdjMatrixC[i, j];
                }
        }

        public static void ExternalLinksCount()
        {
            ExternalLinkC1 = new int[Config_matrix.M];
            ExternalLinkC2 = new int[Config_matrix.N - Config_matrix.M];
            for (int i = 0; i < Config_matrix.M; i++)
            {
                ExternalLinkC1[i] = Config_matrix.LocalDegree[i] - InnerLinkC1[i];
            }

            for (int i = Config_matrix.M; i < Config_matrix.N; i++)
            {
                ExternalLinkC2[i - Config_matrix.M] = Config_matrix.LocalDegree[i] - InnerLinkC2[i - Config_matrix.M];
            }
        }

        public static void ConnectivityCount()
        {
            Connectivity = new int[Config_matrix.N];
            for (int i = 0; i < Config_matrix.N; i++)
                if (i < Config_matrix.M)
                    Connectivity[i] = ExternalLinkC1[i] - InnerLinkC1[i];
                else
                    Connectivity[i] = ExternalLinkC2[i - Config_matrix.M] - InnerLinkC2[i - Config_matrix.M];
        }

        public static void DeltaCount()
        {
            Delta = new int[Config_matrix.M, Config_matrix.N - Config_matrix.M];
            for (int i = 0; i < Config_matrix.M; i++)
                for (int j = 0; j < Config_matrix.N - Config_matrix.M; j++)
                {
                    Delta[i, j] = Connectivity[i] + Connectivity[j + Config_matrix.M] - 2 * Config_matrix.AdjMatrixC[i, j + Config_matrix.M];
                }

        }

        public static SwapResult SwapVertex()
        {
            int count = 0, max = 0, isave = 0, jsave = 0;

            for (int i = 0; i < Config_matrix.M; i++)
                for (int j = 0; j < Config_matrix.N - Config_matrix.M; j++)
                {
                    if (Delta[i, j] > 0)
                    {
                        count++;
                        if (max == 0)
                        {
                            max = Delta[i, j];
                            isave = i;
                            jsave = j;
                        }
                        else
                        {
                            if (Delta[i, j] > max)
                            {
                                max = Delta[i, j];
                                isave = i;
                                jsave = j;
                            }
                            else if (Delta[i, j] == max)
                            {
                                if (Config_matrix.LocalDegree[i] + Config_matrix.LocalDegree[j + Config_matrix.M] < Config_matrix.LocalDegree[isave] + Config_matrix.LocalDegree[jsave + Config_matrix.M])
                                {
                                    isave = i;
                                    jsave = j;
                                }
                                else if (Config_matrix.LocalDegree[i] + Config_matrix.LocalDegree[j + Config_matrix.M] == Config_matrix.LocalDegree[isave] + Config_matrix.LocalDegree[jsave + Config_matrix.M])
                                {
                                    if (i < isave)
                                    {
                                        isave = i;
                                        jsave = j;
                                    }
                                    else if (i == isave)
                                    {
                                        if (j < jsave)
                                        {
                                            jsave = j;
                                        }
                                    }
                                }
                            }

                        }
                    }

                }
            if (count != 0)
            {
                for (int j = 0, k = 0; j < Config_matrix.N; j++)
                {
                    int savevalue = Config_matrix.AdjMatrixC[isave, j];
                    Config_matrix.AdjMatrixC[isave, j] = Config_matrix.AdjMatrixC[jsave + Config_matrix.M, k];
                    Config_matrix.AdjMatrixC[jsave + Config_matrix.M, k] = savevalue;

                    Config_matrix.AdjMatrixC[j, isave] = Config_matrix.AdjMatrixC[k, jsave + Config_matrix.M];
                    Config_matrix.AdjMatrixC[k, jsave + Config_matrix.M] = savevalue;
                    k++;
                }

                string saveshape = Config_matrix.VertexShape[isave + Config_matrix.Piececount * Config_matrix.M];
                Config_matrix.VertexShape[isave + Config_matrix.Piececount * Config_matrix.M] = Config_matrix.VertexShape[jsave + Config_matrix.M + Config_matrix.Piececount * Config_matrix.M];
                Config_matrix.VertexShape[jsave + Config_matrix.M + Config_matrix.Piececount * Config_matrix.M] = saveshape;

                return new SwapResult(true, isave, jsave);
            }
            return new SwapResult(false, 0, 0);
        }

        public static void Solve()
        {
            for (; Config_matrix.Piececount < Config_matrix.L - 1; Config_matrix.Piececount++)
            {
                do
                {
                    Config_matrix.LocalDegreeCount();
                    InternalLinksCount();
                    ExternalLinksCount();
                    ConnectivityCount();
                    DeltaCount();
                } while (SwapVertex().Flag);

                int[,] savearr = new int[Config_matrix.N - Config_matrix.M, Config_matrix.N - Config_matrix.M];
                for (int i = Config_matrix.M; i < Config_matrix.N; i++)
                    for (int j = Config_matrix.M; j < Config_matrix.N; j++)
                    {
                        savearr[i - Config_matrix.M, j - Config_matrix.M] = Config_matrix.AdjMatrixC[i, j];
                    }

                Config_matrix.N -= Config_matrix.M;
                Config_matrix.AdjMatrixC = new int[Config_matrix.N, Config_matrix.N];

                for (int i = 0; i < Config_matrix.N; i++)
                    for (int j = 0; j < Config_matrix.N; j++)
                    {
                        Config_matrix.AdjMatrixC[i, j] = savearr[i, j];
                    }
            }
        }
    }
}
