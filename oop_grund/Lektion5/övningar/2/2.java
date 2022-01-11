class Two {

	public static void main(String[] args) {
		new Two();
	}

	public Two() {


		int num = range(15, -10);
		System.out.println(num);
		System.out.println(num <= 0 ? "You get a candy!" : "No candy");

	}

	public static int range(int max, int min) {
		return (int)(Math.random() * ((max - min) + 1)) + min;
	}

	

}
