class Account:
    def __init__(self, id, type, balance):
        self.id = id
        self.type = type
        self.balance = balance

    def __str__(self):
        return "{ id: %s, type: %s, balance: %s }"%(self.id, self.type, self.balance)
