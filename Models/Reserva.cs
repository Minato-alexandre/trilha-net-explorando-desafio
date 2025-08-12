namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }
        private bool ValidaHospede;

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            // *IMPLEMENTE AQUI*
            try
            {
                foreach (Pessoa pessoa in hospedes)
                {
                    if (string.IsNullOrEmpty(pessoa.Nome))
                    {
                        throw new Exception("Nome do hóspede é obrigatório");
                    }
                    else
                    {
                        ValidaHospede = true;
                    }
                }
            }
            catch
            {
                throw new Exception("Erro ao cadastrar hóspedes");
            }

            if (ValidaHospede)
            {
                Hospedes = hospedes;
                try
                {
                    if (Suite.Capacidade >= hospedes.Count)
                    {
                        Console.WriteLine("Hóspedes cadastrados com sucesso!");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao cadastrar hóspedes: " + ex.Message);
                }
            }
            else
            {
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                // *IMPLEMENTE AQUI*
                throw new Exception("Capacidade da suíte excedida");


            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            // *IMPLEMENTE AQUI*
            if (Hospedes != null)
            {
                return Hospedes.Count;
            }
            return Hospedes.Count; 
        }

        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            // *IMPLEMENTE AQUI*
            if (DiasReservados >= 10)
            {
                Suite.ValorDiaria -= Suite.ValorDiaria*10/100;
            }
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            // *IMPLEMENTE AQUI*
            /*if (true)
            /{
                valor = 0;
            }
*/
            return valor;
        }
    }
}