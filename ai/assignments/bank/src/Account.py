import datetime

from src.Transaction import Transaction


class Account:
    def __init__(self, id, type, balance, transactions):
        self.id = id
        self.type = type
        self.balance = balance
        self.transactions = transactions

    def __str__(self):
        return "%s | %s | %s SEK " % (self.id, self.type, self.balance)

    def withdraw(self, amount):
        self.balance -= amount
        self.new_transaction(-amount)

    def deposit(self, amount):
        self.balance += amount
        self.new_transaction(amount)

    def get_balance(self):
        return self.balance

    def get_id(self):
        return self.id

    def new_transaction(self, amount):
        transaction_id = -1;
        date = datetime.date.today()
        transaction = Transaction(transaction_id, date, amount)
        self.transactions.append(transaction)
        print(transaction.__str__())


