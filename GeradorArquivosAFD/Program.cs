using System;
using System.IO;

namespace GeradorArquivosAFD
{
    internal class Program
    {
        /// <summary>
        /// Utilitário responsável por gerar arquivos AFD para testes.
        /// </summary>
        /// <remarks>Escrito por Adélio Júnior em 20/02/2019</remarks>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Console.WriteLine(" ------------------------------------------------- ");
            Console.WriteLine("|             Gerador de Arquivos AFD             |");
            Console.WriteLine(" ------------------------------------------------- ");
            Console.WriteLine();
            Console.WriteLine("Informe um ano:");

            var ano = Console.ReadLine();

            Console.WriteLine("Bom(a) garoto(a)");
            Console.WriteLine("Agora informe um número de PIS, ou então uma lista com números separados por vírgula:");
            var pisEntrada = Console.ReadLine();

            var listaPis = pisEntrada.Split(',');

            var tipoRegistro = "3";
            var numeroLinha = 1;
            var diretorio = "C://arquivos_afd";

            if(!Directory.Exists(diretorio))
            {
                Directory.CreateDirectory(diretorio);
            }


            for (int mes = 1; mes <= 12; mes++)
            {
                var diasMes = mes == 2 ? 28 : 30;
                var mesFmt = mes.ToString().PadLeft(2, '0');
                var nomeArquivo = diretorio + "//afd_" + mesFmt + ano + ".txt";
                StreamWriter writer = new StreamWriter(nomeArquivo);

                for (var dia = 1; dia <= diasMes; dia++)
                {
                    var diaFmt = dia.ToString().PadLeft(2, '0');
                    var data = DateTime.Parse(diaFmt + "/" + mesFmt + "/" + ano);

                    if (data.DayOfWeek != DayOfWeek.Saturday && data.DayOfWeek != DayOfWeek.Sunday)
                    {


                        Console.WriteLine(diaFmt + "/" + mesFmt + "/" + ano);

                        foreach (string pis in listaPis)
                        {
                            var numeroLinhaFmt = numeroLinha.ToString().PadLeft(9, '0');
                            var linha = numeroLinhaFmt + tipoRegistro + diaFmt + mesFmt + ano;
                            writer.WriteLine(gerarBatidas(linha, pis, "0800"));
                            numeroLinha++;
                            numeroLinhaFmt = numeroLinha.ToString().PadLeft(9, '0');
                            linha = numeroLinhaFmt + tipoRegistro + diaFmt + mesFmt + ano;
                            writer.WriteLine(gerarBatidas(linha, pis, "1200"));
                            numeroLinha++;
                            numeroLinhaFmt = numeroLinha.ToString().PadLeft(9, '0');
                            linha = numeroLinhaFmt + tipoRegistro + diaFmt + mesFmt + ano;
                            writer.WriteLine(gerarBatidas(linha, pis, "1400"));
                            numeroLinha++;
                            numeroLinhaFmt = numeroLinha.ToString().PadLeft(9, '0');
                            linha = numeroLinhaFmt + tipoRegistro + diaFmt + mesFmt + ano;
                            writer.WriteLine(gerarBatidas(linha, pis, "1800"));
                            numeroLinha++;
                        }

                    }
                }
                writer.Close();

            }
            Console.WriteLine("Muito bom, chegamos ao fim.");
            Console.WriteLine("Obrigado pela sua compania.");
        }

        private static string gerarBatidas(string linha, string pis, string hora)
        {
            return linha + hora + pis.PadLeft(12, '0');
        }
    }
}
