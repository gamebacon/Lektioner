from Bank import Bank


def clear(num):
    for i in range(0, num):
        print()


class Main:
    def __init__(self):
        self.bank = Bank()
        self.current_customer = None
        self.go()

    def go(self):
        while True:
            inp = input("Jag är...\n(1)Kund (2)Bank\n").lower()

            if inp == "0":
                break
            elif inp == "1":
                person_number = input("Ange ditt personnummer (YYYYMMDDXXXX)\n")
                customer = self.bank.get_customer(person_number)
                if customer is None:
                    print("Det fanns inget konto registrerat med personnumret \"%s\"." % person_number)
                else:
                    self.customer_ui(customer)
                    break
            elif inp == "2":
                self.bank()
            else:
                print("Skriv \"1\" eller \"2\". Alternativt \"0\" för att avsluta.")

    def customer_ui(self, customer):
        clear(50)
        self.current_customer = customer
        print("Inloggad som: %s %s." % (self.current_customer.first_name, self.current_customer.last_name))

        while True:
            inp = input("(1)Hantera konton (2)Avsluta\n")
            if inp == "1":
                self.accounts_ui()
            elif inp == "2":
                return

    def account_ui(self, account):
        while True:
            inp = input("(1)Ta ut pengar (2)Sätt in pengar (3)Avbryt")
            if inp == "1":
                amount = intput("Ange summan du vill ta ut: ")
                print(amount)
            elif inp == "2":
                amount = intput("Ange summan du vill sätta in: ")
                print(amount)
            else:
                return

    def accounts_ui(self):
        for line in self.current_customer.accounts_str():
            print(line)

        num_inp = input("Ange kontonummer\n")

        account = self.current_customer.get_account(num_inp)

        if account is not None:
            self.account_ui(account)
        else:
            print("Du har inget konto med kontonummer \"%s\"." % num_inp)


def intput(prompt):
    while True:
        try:
            inp = int(input(prompt))
            if inp > 0:
                return inp
        except:
            pass

if __name__ == '__main__':
    main = Main()
