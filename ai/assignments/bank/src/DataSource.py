from src.Account import Account
from src.Customer import Customer
from src.Transaction import Transaction


class DataSource:

    def datasource_conn(self):
        pass

    def save_all(self, customers):
        file = open("data/customers.txt", "wt")

        text = ""

        for customer in customers.values():
            text += "%s:%s:%s:%s," % (customer.id, customer.first_name, customer.last_name, customer.person_number)
            for account in customer.get_accounts().values():
                text += "%s:%s:%s#" % (account.id, account.type, account.balance)
            text = text[0:-1] + "\n"


        print(text)
        file.write(text)
        file.close()
        pass

    # Map<account_id, List<Transaction>>
    def get_all_transactions(self):
        all_transactions = {}
        file = open("data/transactions.txt", "rt")
        lines = file.read().split('\n')

        for line in lines:
            account_transactions = []
            data = line.split(",")
            account_id = data[0]
            for transactions in data[1].split("#"):
                for transaction in transactions.split(":"):
                    id = transaction[0]
                    date = transaction[1]
                    amount = transaction[2]
                    account_transactions.append(Transaction(id, date, amount))
            all_transactions[account_id] = account_transactions
        return all_transactions

    def get_all(self):
        customers = {}
        all_transactions = self.get_all_transactions()
        file = open("data/customers.txt", "rt")
        lines = file.read().split('\n')

        for line in lines:
            accounts = {}

            if len(line) == 0:
                continue

            all_data = line.split(',')

            personal_data = all_data[0].split(":")
            customer_id = personal_data[0]
            first_name = personal_data[1]
            last_name = personal_data[2]
            person_number = personal_data[3]

            for all_account_data in all_data[1].split("#"):
                account_data = all_account_data.split(":")
                account_id = account_data[0]
                account_type = account_data[1]
                account_balance = float(account_data[2])
                transactions = all_transactions.get(account_id)
                account = Account(account_id, account_type, account_balance, transactions)
                accounts[account_id] = account

            customer = Customer(customer_id, first_name, last_name, person_number, accounts)
            customers[person_number] = customer;

        file.close()
        return customers
