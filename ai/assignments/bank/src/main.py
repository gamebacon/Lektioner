
from Bank import Bank


from src.DataSource import DataSource

if __name__ == '__main__':
    accounts = DataSource().get_all()
    bank = Bank()


    while True:
        inp = input("Are you a (1)Customer or a (2)Bank?")

        if inp == "quit":
            break