from Bank import Bank

from src.DataSource import DataSource


def _bank():
    print("Bank!")


def _customer():
    print("Kund!")


if __name__ == '__main__':
    bank = Bank()

    while True:
        inp = input("Jag är...\n(1)Kund (2)Bank\n").lower()

        if inp == "0":
            break
        elif inp == "1":
            _customer()
        elif inp == "2":
            _bank()
        else:
            print("Skriv \"1\" eller \"2\". Alternativt \"0\" för att avsluta.")
