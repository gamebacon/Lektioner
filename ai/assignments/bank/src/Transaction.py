class Transaction:
    def __init__(self, id, date, amount):
        self.id = id
        self.date = date
        self.amount = amount

    def __str__(self):
        return "%s, %s, %s" % (self.id, self.date, self.amount)
