class Account:
    def __init__(self, id, type, balance):
        self.id = id
        self.type = type
        self.balance = balance

    def __str__(self):
        return "%s | %s | %s SEK " % (self.id, self.type, self.balance)

    def withdraw(self, amount):
        self.balance -= amount

    def deposit(self, amount):
        self.balance += amount

    def get_balance(self):
        return self.balance

    def get_id(self):
        return self.id
