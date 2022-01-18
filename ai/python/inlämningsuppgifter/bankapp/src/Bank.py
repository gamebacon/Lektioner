
class Bank:
	def _init_(self):
		self.customers = []
		


	def _load(self):
		return;



	def get_customers(self):
		return self.customers


	def add_customer(self, name, person_number):
		customer = self.customers.get(person_number)
		if(customer == None):
			newCustomer = Customer(name, person_number)
			self.customers[person_number] = newCustomer
			return true
		return false

	def get_customer(self, person_number):
		return customers.get(person_number)

	def change_customer_name(self, person_number, new_name):
		customer = customers.get(person_number)
		if(customer != None):
			customer.name = new_name
			return true
		return false
	
	def remove_customer(self, person_number):
		customers.remove(person_number)

	def add_account(self, person_number):
		account = Account("hej")
		return account.id;


