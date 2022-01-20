from Bank import Bank


def clear(num, msg = ""):
    for i in range(0, num-1):
        print()
    print(msg)


class Main:
    def __init__(self):
        self.bank = Bank()
        self.current_customer = None
        self.start_ui()
        self.bank.save()

    def start_ui(self):
        while True:
            inp = input("Jag är...\n(1)Kund (2)Bank\n")
            if inp == "1":
                if self.customer_login_ui():
                    break
            elif inp == "2":
                self.bank_ui()
                break
            elif inp == "0":
                break
            else:
                print("Skriv \"1\" eller \"2\". Alternativt \"0\" för att avsluta.")

    def bank_ui(self):
        while True:
            inp = input("(1)Visa kunder (2)Hantera kund (3)Ny Kund (4)Avsluta\n")
            if inp is "1":
                self.bank_display_customers_ui()
            elif inp is "2":
                customer = self.get_customer_ui()
                if customer is not None:
                    self.bank_customer_ui(customer)
            elif inp is "3":
                self.bank_new_customer_ui()
            else:
                break

    def bank_display_customers_ui(self):
        for customer in self.bank.get_customers():
            print(customer.__str__())

    def get_customer_ui(self):
        while True:
            person_number = input("Ange ett personnummer: ")
            customer = self.bank.get_customer(person_number)
            if customer is None:
                print("En person med personnummer \"%s\" hittades inte." % person_number)
                ok()
                break
            else:
                return customer

    def bank_customer_ui(self, customer):
        while True:
            print("------- %s %s, %s ---------" % (customer.first_name, customer.last_name, customer.get_person_number()))
            inp = input("(1)Kunduppgifter (2)Konton (3)Radera (4)Avbryt\n")
            if inp is "1":
                self.bank_modify_customer_ui(customer)
            elif inp is "2":
                self.bank_customer_accounts_ui(customer)
            elif inp is "3":
                self.bank_remove_customer_ui(customer)
                return
            else:
                return

    def bank_modify_customer_ui(self, customer):
        while True:
            inp = input("(1)Ändra förnamn (2)Ändra efternamn (3)Avbryt\n")
            if inp is "1":
                customer.set_first_name(input("Nytt förnamn: "))
            elif inp is "2":
                customer.set_last_name(input("Nytt efternamn: "))
            else:
                return

    def bank_customer_accounts_ui(self, customer):
        while True:
            inp = input("(1)Nytt konto (2)Hantera konto (3)Avbryt\n")
            if inp is "1":
                new_account_id = self.bank.add_account(customer.get_person_number())
                print("A new account was created with id %s." % new_account_id)
                ok()
            elif inp is "2":
                self.bank_customer_account_ui(customer)
            else:
                return

    def bank_customer_account_ui(self, customer):
        account = self.get_customer_account(customer)
        if account is not None:
            while True:
                clear(50)
                print("> " + account.__str__())
                inp = input("(1)Visa transaktioner (2)Avsluta konto (3)Avbryt\n")
                if inp is "1":
                    print(self.bank.get_transactions(customer.get_person_number(), account.id))
                    ok()
                    continue
                elif inp is "2":
                    self.bank_delete_account_ui(customer, account)
                return

    def bank_delete_account_ui(self, customer, account):
        if input("Ange kontonumret för att radera kontot: ") == account.id:
            self.bank.close_account(customer.get_person_number(), account.id)
            print("Kontot togs bort och du fick tillbaka %s kr" % account.balance)
        else:
            print("Du angav fel kontonummer.")
        ok()

    def bank_remove_customer_ui(self, customer):
        inp = input("Ange personnumret for att konfirmera radering.\n")
        if  inp == customer.get_person_number():
            self.bank.remove_customer(customer.person_number)
            print("Kundkontot för %s togs bort." % customer.get_full_name())
        else:
            print("Du angav fel personnummer.")
        ok()

    def bank_new_customer_ui(self):
        first_name = input("Ange förnamn: ")
        last_name = input("Ange efternamn: ")
        person_number = input("Ange personnummer: ")
        if self.bank.add_customer(first_name, last_name, person_number):
            print("Ett kundkonto skapades för %s %s." % (first_name, last_name))
        else:
            print("Ett kundkonto med personnumret \"%s\" finns redan." % person_number)
        ok()

    def customer_login_ui(self):
        person_number = input("Ange ditt personnummer (YYYYMMDDXXXX)\n")
        customer = self.bank.get_customer(person_number)
        if customer is None:
            print("Det fanns inget konto registrerat med personnumret \"%s\"." % person_number)
            ok()
        else:
            self.current_customer = customer
            print("Du är inloggad som %s %s." % (self.current_customer.first_name, self.current_customer.last_name))
            self.customer_ui(customer)
        return customer is not None

    def customer_ui(self, customer):
        while True:
            inp = input("(1)Hantera konton (2)Avsluta\n")
            if inp == "1":
                account = self.get_customer_account(customer)
                if account is not None:
                    self.account_ui(account)
            elif inp == "2":
                return

    def withdraw_ui(self, account, amount):
        withdraw_response = self.bank.withdraw(self.current_customer.get_person_number(), account.id, amount)
        if withdraw_response is True:
            print("\nDu har tagit ut %s kr (Resterande belopp %s SEK)" % (amount, account.balance))
        else:
            print("\nDu har inte tillräckligt med pengar på ditt konto. (%s SEK)" % account.balance)
        ok()

    def deposit_ui(self, account, amount):
        deposit_response = self.bank.deposit(self.current_customer.get_person_number(), account.id, amount)
        if deposit_response is True:
            print("\nDu har gjort en insättning på %s kr (Nuvarande belopp %s SEK)" % (amount, account.balance))
        else:
            print("\nNågot gick fel..\n")
        ok()

    def account_ui(self, account):
        while True:
            clear(50)
            print("> " + account.__str__())
            inp = input("\n(1)Uttag (2)Insättning (3)Historik (4)Avbryt\n")
            if inp is "1" or inp is "2":
                amount = intput("Ange mängd: ")
                if inp == "1":
                    self.withdraw_ui(account, amount)
                elif inp == "2":
                    self.deposit_ui(account, amount)
            elif inp is "3":
                clear(50, account.view_transactions())
                ok()
            else:
                return

    # Returns a specified account
    def get_customer_account(self, customer):
        clear(50)
        for line in customer.accounts_str():
            print(line)
        num_inp = input("Ange ett kontonummer: ")

        account = customer.get_account(num_inp)

        if account is None:
            print("Ett konto med kontonummer \"%s\" hittades inte." % num_inp)
            ok()
        else:
            return account


def ok(prompt = "(1)Ok\n"):
    ok = input(prompt)
    clear(50)

def intput(prompt):
    while True:
        try:
            inp = int(input(prompt))
            if inp > 0:
                return inp
        except:
            pass


Main()
