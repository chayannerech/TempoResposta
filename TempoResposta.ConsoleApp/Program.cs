namespace TempoResposta.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                int N = RecebeN();

                string[] amigoRecebeu = new string[N], amigoEnviou = new string[N];
                string saida = "";
                int[] recebeu = new int[N], enviou = new int[N];
                int tempo = 0;

                Evento(ref amigoRecebeu, ref amigoEnviou, ref recebeu, ref enviou, ref tempo, N);
                ContaTempo(amigoRecebeu, amigoEnviou, recebeu, enviou, ref saida);

                string[] amigo = new string[N];
                int[] tempoTotal = new int[N];

                OrganizaAmigosTempo(saida, ref amigo, ref tempoTotal);
                SomaOsTempos(ref tempoTotal, ref amigo);

                int[] tempoResposta = new int[N];

                PoeEmOrdem(ref amigo, tempoTotal, ref tempoResposta);
                Saida(tempoResposta, amigo);

                if (DeveContinuar()) break;
            }
        }
        static int RecebeN()
        {
            int N = 0;
            while (N < 1 || N > 20)
            {
                Console.WriteLine("Insira 0 < N < 21");
                N = Convert.ToInt32(Console.ReadLine());
            }
            return N;
        }
        static void Evento(ref string[] amigoRecebeu, ref string[] amigoEnviou, ref int[] recebeu, ref int[] enviou, ref int tempo, int N)
        {
            for (int i = 0; i < N; i++)
            {
                string[] evento = RecebeEvento();
                OrganizaEvento(evento, i, ref amigoRecebeu, ref amigoEnviou, ref recebeu, ref enviou, ref tempo);
            }
        }
        static string[] RecebeEvento()
        {
            string[] evento = new string[3];

            do
            {
                evento = Console.ReadLine().Split(' ');
                if (Convert.ToInt32(evento[1]) < 1 || Convert.ToInt32(evento[1]) > 100 || (evento[0] != "R" && evento[0] != "E" && evento[0] != "T")) Console.WriteLine("Erro");
            }
            while (Convert.ToInt32(evento[1]) < 1 || Convert.ToInt32(evento[1]) > 100 || (evento[0] != "R" && evento[0] != "E" && evento[0] != "T"));

            return evento;
        }
        static void OrganizaEvento(string[] evento, int i, ref string[] amigoRecebeu, ref string[] amigoEnviou, ref int[] recebeu, ref int[] enviou, ref int tempo)
        {
            if (evento[0] == "R")
            {
                amigoRecebeu[i] += evento[1];
                recebeu[i] += tempo;
            }

            if (evento[0] == "E")
            {
                if (!amigoRecebeu.Contains(evento[1])) Console.WriteLine("Erro");
                amigoEnviou[i] = evento[1];
                enviou[i] = tempo;
            }

            if (evento[0] == "T")
            {
                if (amigoRecebeu == null) Console.WriteLine("Erro");
                tempo += Convert.ToInt32(evento[1]) - 1;
            }
            else tempo++;
        }
        static void ContaTempo(string[] amigoRecebeu, string[] amigoEnviou, int[] recebeu, int[] enviou, ref string saida)
        {
            int contagem = 0;

            for (int i = 0; i < recebeu.Length; i++)
            {
                for (int j = 0; j < enviou.Length; j++)
                {
                    if (amigoRecebeu[i] == amigoEnviou[j] && j > i && amigoEnviou[j] != null)
                    {
                        contagem = enviou[j] - recebeu[i];
                        break;
                    }
                    contagem = 1000;
                }
                if (amigoRecebeu[i] != null) saida = saida + $"{amigoRecebeu[i]}/{contagem}/";
            }
        }
        static void OrganizaAmigosTempo(string saida, ref string[] amigo, ref int[] tempoTotal)
        {
            string[] pares = saida.Split('/');
            int contador = 0;

            for (int j = 0; j < pares.Length - 1; j++)
            {
                if (j % 2 == 0) amigo[contador] = pares[j];
                else
                {
                    tempoTotal[contador] = Convert.ToInt32(pares[j]);
                    contador++;
                }
            }
        }
        static void SomaOsTempos(ref int[] tempoTotal, ref string[] amigo)
        {
            for (int i = 0; i < tempoTotal.Length; i++)
            {
                for (int j = i + 1; j < tempoTotal.Length; j++)
                {
                    if (amigo[i] == amigo[j])
                    {
                        tempoTotal[i] = tempoTotal[i] + tempoTotal[j];
                        tempoTotal[j] = 0;
                        amigo[j] = " ";
                    }
                }
            }
        }
        static void PoeEmOrdem(ref string[] amigo, int[] tempoTotal, ref int[] tempoResposta)
        {
            string[] organiza = new string[amigo.Length];
            Array.Copy(amigo, organiza, amigo.Length);
            Array.Sort(amigo);

            for (int i = 0; i < amigo.Length; i++)
            {
                for (int j = 0; j < amigo.Length; j++)
                {
                    if (amigo[i] == organiza[j]) tempoResposta[i] = tempoTotal[j];
                }
            }
        }
        static void Saida(int[] tempoResposta, string[] amigo)
        {
            Console.WriteLine("\nSaída:");
            for (int i = 0; i < tempoResposta.Length; i++)
            {
                if (tempoResposta[i] >= 1000) tempoResposta[i] = -1;
                if (amigo[i] != " " && amigo[i] != null) Console.WriteLine($"{amigo[i]} {tempoResposta[i]}");
            }
        }
        static bool DeveContinuar()
        {
            Console.WriteLine("\nDeseja repetir? [S,N]");
            string continua = Console.ReadLine();
            return continua == "n" || continua == "N";
        }
    }
}
