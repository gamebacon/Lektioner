import sys

arg = int(sys.argv[1])

cost = arg 


if cost > 1000:
	cost -= cost * .2
elif cost > 500:
	cost -= cost * .1

print("Kostnaden på köpet är %.1f kr"%(cost))
