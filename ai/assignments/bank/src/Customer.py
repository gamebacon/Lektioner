class Customer:

    def __init__(self, id, first_name, last_name, person_number, accounts, transactions):
        self.id = id
        self.first_name = first_name
        self.last_name = last_name
        self.person_number = person_number
        self.accounts = accounts
        self.transactions = transactions

    def __str__(self):
        return "{%s, %s %s, %s}" % (self.id, self.first_name, self.last_name, self.person_number)

    # Returns account dictionary
    # with account_id as key and the account for value
    def get_accounts(self):
        return self.accounts

    def get_account(self, account_id):
        return self.accounts[account_id]

    # todo
    def add_account(self, account):
        self.accounts[account.id] = account

    def set_first_name(self, first_name):
        self.first_name = first_name

    def set_last_name(self, last_name):
        self.last_name = last_name

    def accounts_str(self):
        result = [0]
        for account in self.get_accounts():
            result[0] += account.balance
            result.append(account.__str__())
        return result
