using System;

namespace Bank
{
    public class BankAccount
    {
        //Mensagens de erro
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";
        public const string CreditAmountLessOrEqualThanZeroMessege = "Credit amount is less than zero";
        //atribustos
        private readonly string m_customerName;
        private double m_balance;

        //construtor
        public BankAccount() { }
        public BankAccount(String customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        //propriedades - Encapsulamento
        public string CustomerName
        {
            get { return m_customerName; }
        }
        public double Balance
        {
            get { return m_balance; }
        }

        // métodos da classe
        /// <summary>
        /// O metodo ira fazer um debito na conta
        /// </summary>
        /// <param name="amount">Valor que sera debitado</param>
        public void Debit(double amount)
        {
            if (amount > m_balance)
            {
                throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }
            if (amount < 0)
            {
                throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }
            m_balance -= amount;
        }
        /// <summary>
        /// O metodo ira creditar um valor na conta
        /// </summary>
        /// <param name="amount">Valor a ser creditado</param>
        public void Credit(double amount)
        {
            if (amount <= 0)
            {
                throw new System.ArgumentOutOfRangeException("amount", amount, CreditAmountLessOrEqualThanZeroMessege);
            }
            m_balance += amount;
        }

        public static void Main()
        {
            BankAccount ba = new BankAccount("Murilo", 11.99);
            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance id ${0}", ba.Balance);
        }
    }
}
