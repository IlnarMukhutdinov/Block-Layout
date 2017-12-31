using System;
using System.Windows.Forms;

namespace Graph_placement_algorithm
{
    class Config_matrix
    {
        private static int[,] adjMatrixC1, adjMatrixC2;

        public int index1 = 0, index2 = 0;

        public static int[,] ResultAdjMatrixC { get; set; }

        public static int[] InternalLinksInResultMatrix { get; set; }

        public static int[] ExternalLinksInResultMatrix { get; set; }

        public static int[,] AdjMatrixC { get; set; }

        public static int[] LocalDegree { get; set; }

        public static int[] LocalDegreeInResultMatrix { get; set; }

        public static string[] VertexShape { get; set; }

        public static int L { get; set; }

        public static int Piececount { get; set; }

        public static int InitialN { get; set; }

        public static int N { get; set; }

        public static int M { get; set; }

        public static void MatrixCreate()
        {
            AdjMatrixC = new int[N, N];
            VertexShape = new string[N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    AdjMatrixC[i, j] = 0;
                }
                VertexShape[i] = "x" + (i + 1);
            }
        }

        public static void ResultMatrixCreate()
        {
            InitialN = N;
            ResultAdjMatrixC = new int[InitialN, InitialN];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    ResultAdjMatrixC[i, j] = 0;
                }
            }
        }

        public static void LocalDegreeCount()
        {
            LocalDegree = new int[N];

            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    LocalDegree[i] += AdjMatrixC[i, j];
        }

        public static void InternalLinksInResultMatrixCount()
        {
            InternalLinksInResultMatrix = new int[L];
            int pieceCount = 0;
            for (int i = 0; i < L; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    for (int k = j + 1; k < M; k++)
                    {
                        InternalLinksInResultMatrix[i] = InternalLinksInResultMatrix[i] + ResultAdjMatrixC[j + M * pieceCount, k + M * pieceCount];
                    }
                }
                pieceCount++;
            }
        }

        public static void ExternalLinksInResultMatrixCount()
        {
            ExternalLinksInResultMatrix = new int[(L * (L - 1)) / 2];
            int pieceCount = 0;
            switch (L)
            {
                case 2:
                    for (int i = 0; i < M; i++)
                    {
                        for (int j = 0; j < M; j++)
                        {
                            ExternalLinksInResultMatrix[0] +=
                                ResultAdjMatrixC[j + M * pieceCount, j + M * (pieceCount + 1)];
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < ExternalLinksInResultMatrix.Length - 1; i++)
                    {
                        for (int j = 0; j < M; j++)
                        {
                            for (int k = 0; k < M; k++)
                            {
                                ExternalLinksInResultMatrix[i] +=
                                    ResultAdjMatrixC[j + M * pieceCount, k + M * (pieceCount + 1)];
                            }
                        }
                        pieceCount++;
                    }
                    for (int i = 0; i < M; i++)
                    {
                        for (int j = 0; j < M; j++)
                        {
                            ExternalLinksInResultMatrix[2] += ResultAdjMatrixC[i, j + M * 2];
                        }
                    }
                    break;
                case 4:
                    pieceCount = 0;
                    for (int i = 0; i < ExternalLinksInResultMatrix.Length - 3; i++)
                    {
                        for (int j = 0; j < M; j++)
                        {
                            for (int k = 0; k < M; k++)
                            {
                                ExternalLinksInResultMatrix[i] +=
                                    ResultAdjMatrixC[j + M * pieceCount, k + M * (pieceCount + 1)];
                            }
                        }
                        pieceCount++;
                    }
                    pieceCount = 2;
                    for (int i = 3; i < ExternalLinksInResultMatrix.Length - 1; i++)
                    {
                        for (int j = 0; j < M; j++)
                        {
                            for (int k = 0; k < M; k++)
                            {
                                ExternalLinksInResultMatrix[i] += ResultAdjMatrixC[j, k + M * pieceCount];
                            }
                        }
                        pieceCount++;
                    }
                    for (int i = 0; i < M; i++)
                    {
                        for (int j = 0; j < M; j++)
                        {
                            ExternalLinksInResultMatrix[5] += ResultAdjMatrixC[i + M, j + 3 * M];
                        }
                    }
                    break;
            }
        }
        
        public void C1C2Create()
        {
            int i = index1, j = index1;
            index2 = index1 + M;
            adjMatrixC1 = new int[M, M];
            adjMatrixC2 = new int[N - M, N - M];
            for (int count1 = 0; count1 < M; count1++)
            {
                j = index1;
                for (int count2 = 0; count2 < M; count2++)
                {
                    adjMatrixC1[count1, count2] = AdjMatrixC[i, j];
                    j++;
                }
                i++;
            }
            index2 = index1 + M;
            i = index2;
            j = index2;

            for (int count1 = 0; count1 < N - M; count1++)
            {
                j = index2;
                for (int count2 = 0; count2 < N - M; count2++)
                {
                    adjMatrixC2[count1, count2] = AdjMatrixC[i, j];
                    j++;
                }
                i++;
            }
        }

        public void AdjMatrixShow()
        {
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                {
                    if (j == N - 1)
                        Console.WriteLine(AdjMatrixC[i, j]);
                    else
                        Console.Write(AdjMatrixC[i, j] + " ");
                }
        }

        public void C1C2MatrixShow()
        {
            for (int i = 0; i < M; i++)
                for (int j = 0; j < M; j++)
                {
                    if (j == M - 1)
                        Console.WriteLine(adjMatrixC1[i, j]);
                    else
                        Console.Write(adjMatrixC1[i, j] + " ");
                }
            Console.WriteLine("\n\n");
            for (int i = 0; i < N - M; i++)
                for (int j = 0; j < N - M; j++)
                {
                    if (j == N - M - 1)
                        Console.WriteLine(adjMatrixC2[i, j]);
                    else
                        Console.Write(adjMatrixC2[i, j] + " ");
                }
        }

        public void LocalDegreeShow()
        {
            for (int i = 0; i < N; i++)
                Console.Write(LocalDegree[i] + " ");
        }
    }
    
}