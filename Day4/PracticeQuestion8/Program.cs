using System;
using System.Collections.Generic;

namespace Banking
{
    // Interface
    public interface ITransaction
    {
        void Validate();
        void Execute();
        void Rollback();
        void Log();
    }

    // Account Class
    public class BankAccount
    {
        public double Balance { get; private set; }

        public BankAccount(double balance)
        {
            Balance = balance;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            Balance -= amount;
        }
    }

    // Transaction History
    public class TransactionProcessor
    {
        private Stack<ITransaction> history = new Stack<ITransaction>();

        public void Process(ITransaction transaction)
        {
            transaction.Validate();
            transaction.Execute();
            transaction.Log();

            history.Push(transaction);
        }

        // Bonus: Undo Last Transaction
        public void UndoLastTransaction()
        {
            if (history.Count > 0)
            {
                ITransaction transaction = history.Pop();
                transaction.Rollback();
                Console.WriteLine("Last Transaction Undone");
            }
            else
            {
                Console.WriteLine("No Transaction Found");
            }
        }
    }
}

namespace Banking.Deposit
{
    using Banking;

    // Sealed Class
    public sealed class DepositTransaction : ITransaction
    {
        private BankAccount account;

        // Property
        public double Amount { get; set; }

        public DepositTransaction(BankAccount account, double amount)
        {
            this.account = account;
            Amount = amount;
        }

        public void Validate()
        {
            if (Amount <= 0)
                throw new Exception("Invalid Deposit Amount");
        }

        public void Execute()
        {
            account.Deposit(Amount);
        }

        public void Rollback()
        {
            account.Withdraw(Amount);
        }

        public void Log()
        {
            Console.WriteLine($"Deposit ₹{Amount} Successful");
        }
    }
}

namespace Banking.Transfer
{
    using Banking;

    // Sealed Class
    public sealed class TransferTransaction : ITransaction
    {
        private BankAccount fromAccount;
        private BankAccount toAccount;

        public double Amount { get; set; }

        public TransferTransaction(
            BankAccount from,
            BankAccount to,
            double amount)
        {
            fromAccount = from;
            toAccount = to;
            Amount = amount;
        }

        public void Validate()
        {
            if (Amount <= 0)
                throw new Exception("Invalid Amount");

            if (fromAccount.Balance < Amount)
                throw new Exception("Insufficient Balance");
        }

        public void Execute()
        {
            fromAccount.Withdraw(Amount);
            toAccount.Deposit(Amount);
        }

        public void Rollback()
        {
            toAccount.Withdraw(Amount);
            fromAccount.Deposit(Amount);
        }

        public void Log()
        {
            Console.WriteLine($"Transfer ₹{Amount} Successful");
        }
    }
}

class Program
{
    static void Main()
    {
        Banking.BankAccount account1 = new Banking.BankAccount(10000);
        Banking.BankAccount account2 = new Banking.BankAccount(5000);

        Banking.TransactionProcessor processor =
            new Banking.TransactionProcessor();

        Banking.Deposit.DepositTransaction deposit =
            new Banking.Deposit.DepositTransaction(account1, 2000);

        processor.Process(deposit);

        Banking.Transfer.TransferTransaction transfer =
            new Banking.Transfer.TransferTransaction(
                account1,
                account2,
                3000);

        processor.Process(transfer);

        Console.WriteLine();

        Console.WriteLine("Account1 Balance : " + account1.Balance);
        Console.WriteLine("Account2 Balance : " + account2.Balance);

        Console.WriteLine();

        processor.UndoLastTransaction();

        Console.WriteLine();

        Console.WriteLine("After Undo");

        Console.WriteLine("Account1 Balance : " + account1.Balance);
        Console.WriteLine("Account2 Balance : " + account2.Balance);
    }
}