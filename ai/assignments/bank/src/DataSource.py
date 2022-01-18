from src.Account import Account
from src.Customer import Customer


class DataSource:

    def datasource_conn(self):
        pass

    def get_all(self):
        customers = []
        file = open("data/customers.txt", "rt")
        all_text = file.read()
        lines = all_text.split('\n')

        for line in lines:
            transactions = []
            accounts = []

            all_data = line.split(',')

            personal_data = all_data[0].split(":")
            id = personal_data[0]
            name = personal_data[1]
            person_number = personal_data[2]

            for all_account_data in all_data[1].split("#"):
                account_data = all_account_data.split(":")
                account_id = account_data[0]
                account_type = account_data[1]
                account_balance = account_data[2]
                account = Account(account_id, account_type, account_balance)
                accounts.append(account)

            customer = Customer(id, name, person_number, accounts, transactions)
            customers.append(customer)

        file.close()
        return customers
