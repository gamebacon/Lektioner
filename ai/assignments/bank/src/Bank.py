import datetime

from src.Account import Account
from src.Customer import Customer
from src.DataSource import DataSource

from src.Transaction import Transaction


class Bank:

    def __init__(self):
        self.datasource = DataSource()
        self.customers = self.datasource.get_all()
        self.all_customer_accounts = {}

        for customer in self.customers.values():
            for account in customer.get_accounts().values():
                self.all_customer_accounts[account.id] = account;

    def save(self):
        self.datasource.save_all(self.customers)

    def is_account(self, account_id):
        return self.all_customer_accounts.__contains__(account_id)

    # create new account id
    def __get_new_account_id(self, customer):
        if len(customer.accounts.values()) == 0:
            return "1000"
        else:
            return str(int(list(customer.accounts.values())[-1].id) + 1)

    # Returns a dictionary with all accounts
    def get_all_customer_accounts(self):
        return self.all_customer_accounts

    # Returns a list of all customers
    def get_customers(self):
        return self.customers.values()

    # Returns a specified customer
    def get_customer(self, person_number):
        return self.customers.get(person_number)

    # Change customer names
    # Returns true if successful, returns false if no customer was found
    def change_customer_name(self, new_first_name, new_last_name, person_number):
        customer = self.get_customer(person_number)
        if customer is not None:
            customer.first_name = new_first_name
            customer.last_name = new_last_name
            return True
        return False

    # Creates a new customer.
    # Returns false if the person is already a customer, true otherwise.
    def add_customer(self, first_name, last_name, person_number):
        if self.customers.get(person_number) is None:
            new_id = str(int(list(self.customers.values())[-1].id) + 1)
            new_customer = Customer(new_id, first_name, last_name, person_number, {})
            self.customers[person_number] = new_customer
            return True
        else:
            return False

    # Removes a customer from the bank.
    # Returns account information including the total balance.
    def remove_customer(self, person_number):
        customer = self.get_customer(person_number)
        del self.customers[person_number]
        return customer.accounts_str()

    # Add account to existing customer.
    # returns newly created id. -1 if no account was created.
    def add_account(self, person_number):
        customer = self.get_customer(person_number)
        new_account_id = -1
        if customer is not None:
            new_account_id = self.__get_new_account_id(customer)
            new_account = Account(new_account_id, "Debit konto", 0.0, [])
            customer.add_account(new_account)
        return new_account_id

    # Returns a textual presentation of a specified account
    def get_account(self, person_number, account_id):
        customer = self.get_customer(person_number)
        account = customer.get_accounts()[account_id]
        return account.__str__

    # Withdraw money from a specified account
    # Returns true if successful, false if the amount wasn't available.
    def withdraw(self, person_number, account_id, amount):
        customer = self.get_customer(person_number)
        account = customer.get_account(account_id)
        if account.get_balance() - amount >= 0:
            account.withdraw(amount)
            return True
        return False

    # Withdraw money from a specified account
    # Returns true if successful
    def deposit(self, person_number, account_id, amount):
        customer = self.get_customer(person_number)
        account = customer.get_account(account_id)
        account.deposit(amount)
        return True

    # Removes the account
    # Returns a textual presentation of the removed account
    def close_account(self, person_number, account_id):
        customer = self.get_customer(person_number)
        account = customer.get_account(account_id)
        del customer.get_accounts()[account_id]
        return account.__str__



    # Returns all transaction history for specified account
    def get_transactions(self, person_number, account_id):
        customer = self.get_customer(person_number)
        account = customer.get_account(account_id)
        return account.get_transactions()
