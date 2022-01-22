from src.Account import Account
from src.Customer import Customer
from src.Transaction import Transaction, get_id


def __write__(file_name, text):
    file = open(file_name, "wt")
    file.write(text)
    file.close()
    pass


def __read__(file_name):
    file = open(file_name, "rt")
    text = file.read()
    file.close()
    return text;


class DataSource:

    def datasource_conn(self):
        pass

    def save_all(self, customers):
        text = ""
        for customer in customers.values():
            text += "%s:%s:%s:%s," % (customer.id, customer.first_name, customer.last_name, customer.person_number)
            for account in customer.get_accounts().values():
                text += "%s:%s:%s#" % (account.id, account.type, account.balance)
            text = text[0:-1] + "\n"
        __write__("data/customers.txt", text)
        self.__save_transactions__(customers)

    # Saves all the transactions
    def __save_transactions__(self, customers):
        text = ""
        for customer in customers.values():
            for account in customer.get_accounts().values():
                text += str(account.id) + ","
                for transaction in account.get_transactions():
                    text += "%s;%s;%s#" % (transaction.id, transaction.date, transaction.amount)
                text = text[0:-1] + "\n"
        __write__("data/transactions.txt", text)

    # Returns a dictionary of all account's and their transactions
    # With account-id as key and a tuple of the account's transactions
    def __get_all_transactions__(self):
        all_transactions = {}
        lines = __read__("data/transactions.txt").split("\n")

        for line in lines:
            if len(line) == 0:
                continue
            account_transactions = []
            data = line.split(",")
            account_id = int(data[0])
            if len(data) > 1 and len(data[1]) > 0:
                for transaction in data[1].split("#"):
                    transaction_details = transaction.split(";")
                    id = transaction_details[0]
                    date = transaction_details[1]
                    amount = transaction_details[2]
                    t = Transaction(id, date, amount)
                    account_transactions.append(t)
            account_transactions.sort(key=get_id)
            all_transactions[account_id] = account_transactions
        return all_transactions

    def get_all(self):
        customers = {}
        all_transactions = self.__get_all_transactions__()
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

            # print(">%s<"%line)
            if len(all_data) > 1:
                for all_account_data in all_data[1].split("#"):
                    account_data = all_account_data.split(":")
                    account_id = int(account_data[0])
                    account_type = account_data[1]
                    account_balance = float(account_data[2])
                    transactions = all_transactions.get(account_id)
                    account = Account(account_id, account_type, account_balance, transactions if transactions else [])
                    accounts[account_id] = account

            customer = Customer(customer_id, first_name, last_name, person_number, accounts)
            customers[person_number] = customer;

        file.close()
        return customers
