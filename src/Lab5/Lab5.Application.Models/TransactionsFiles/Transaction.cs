namespace Lab5.Application.Models.TransactionsFiles;

public record Transaction(long IdTrans, string IdUname, decimal Amount, TransactionType Ttype);