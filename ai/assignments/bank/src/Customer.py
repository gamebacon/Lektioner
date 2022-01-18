class Customer:

    def __init__(self, id, name, person_number, accounts, transactions):
        self.id = id
        self.name = name
        self.person_number = person_number
        self.accounts = accounts
        self.transactions = transactions

    def __str__(self):
        return "{ id: %s, name: %s, person_number: %s }" % (self.id, self.name, self.person_number)
