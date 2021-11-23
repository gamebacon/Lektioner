import with.william.airport.Airport;
import with.william.airport.Flight;
import with.william.airport.Gate;
import with.william.airport.Terminal;
import with.william.airport.airplane.Airplane;
import with.william.airport.airplane.PassengerPlane;
import with.william.airport.human.*;
import with.william.airport.other.BoardingPass;
import with.william.airport.other.FlightClass;
import with.william.airport.other.NoPilotException;
import with.william.airport.util.Country;
import with.william.airport.other.Passport;
import with.william.airport.util.Util;

import java.time.Duration;
import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.format.DateTimeParseException;
import java.util.*;


public class Driver {

    private Scanner scanner = new Scanner(System.in);

    private enum Action {
        NONE,
        EXIT,
        VIEW_MONITORS,
        VIEW_BOARDING_PASS,
        GO_TO_TERMINAL,
        GO_TO_GATE,
        WAIT,
        BOARD_PLANE,
        BUY_TICKET;

        @Override
        public String toString() {
            return super.toString().replace("_", " ");
        }



    }

    public static void main(String[] args) {
        new Driver().go();
    }


    public void go() {

        Airport tegel = new Airport("Tegel", Country.GERMANY);
        Cleaner cleaner5 = new Cleaner("Jason", Country.GERMANY, LocalDate.parse("1972-04-11"));
        Security security5= new Security("Ann", Country.GERMANY, LocalDate.parse("1998-11-03"));
        Pilot pilot4 = new Pilot("Hanson", Country.GERMANY, LocalDate.parse("1999-05-10"));
        Pilot pilot5 = new Pilot("Albert", Country.GERMANY, LocalDate.parse("1991-10-14"));
        tegel.getPeople().add(cleaner5);
        tegel.getPeople().add(security5);
        tegel.getPeople().add(pilot4);
        tegel.getPeople().add(pilot5);

        Airport arlanda = new Airport("Arlanda", Country.SWEDEN);
        Cleaner cleaner3 = new Cleaner("Anton", Country.SWEDEN, LocalDate.parse("1972-02-12"));
        Security security4 = new Security("Oscar", Country.SWEDEN, LocalDate.parse("1985-01-04"));
        Pilot pilot = new Pilot("Jacob", Country.SWEDEN, LocalDate.parse("1999-05-10"));
        Pilot pilot3 = new Pilot("Maria", Country.SWEDEN, LocalDate.parse("1991-10-14"));
        arlanda.getPeople().add(cleaner3);
        arlanda.getPeople().add(pilot);
        arlanda.getPeople().add(security4);
        arlanda.getPeople().add(pilot3);

        Airport heathrow = new Airport("Heathrow", Country.ENGLAND);
        Cleaner cleaner2 = new Cleaner("Mark", Country.ENGLAND, LocalDate.parse("1992-02-12"));
        Security security2 = new Security("Daniel", Country.ENGLAND, LocalDate.parse("1982-05-10"));
        Security security3 = new Security("Robert", Country.ENGLAND, LocalDate.parse("1995-01-04"));
        Pilot pilot2 = new Pilot("Rebecka", Country.ENGLAND, LocalDate.parse("1993-10-14"));
        heathrow.getPeople().add(cleaner2);
        heathrow.getPeople().add(pilot2);
        heathrow.getPeople().add(security2);


        Airport kastrup = new Airport("Kastrup", Country.DENMARK);
        Cleaner cleaner1 = new Cleaner("Anna", Country.DENMARK, LocalDate.parse("1992-02-12"));
        Security security1 = new Security("Emil", Country.DENMARK, LocalDate.parse("1982-05-10"));
        Pilot pilot1 = new Pilot("Oscar", Country.DENMARK, LocalDate.parse("1993-10-14"));
        kastrup.getPeople().add(pilot1);
        kastrup.getPeople().add(cleaner1);
        kastrup.getPeople().add(security2);

        PassengerPlane airplane = new PassengerPlane();
        airplane.pilots.add(pilot1);


        Flight kastrupToHeathrow = new Flight(heathrow, LocalDateTime.parse("2021-11-20T10:23:30"), 135, airplane);
        kastrup.scheduleFlight(0, 0, kastrupToHeathrow);

        Flight kastrupToTegel = new Flight(tegel, LocalDateTime.parse("2021-11-20T19:04:30"), 120, airplane);
        kastrup.scheduleFlight(0, 0, kastrupToTegel);

        Flight kastrupToArlanda = new Flight(arlanda, LocalDateTime.parse("2021-11-20T23:04:30"), 140, airplane);
        kastrup.scheduleFlight(2, 2, kastrupToArlanda);

        Flight kastrupToHeathrow2 = new Flight(heathrow, LocalDateTime.parse("2021-11-20T23:59:30"), 320, airplane);
        kastrup.scheduleFlight(1, 0, kastrupToHeathrow2);

        Flight kastrupToTegel2 = new Flight(tegel, LocalDateTime.parse("2021-11-20T22:04:30"), 320, airplane);
        kastrup.scheduleFlight(2, 1, kastrupToTegel2);



        Flight heathrowToTegel = new Flight(tegel, LocalDateTime.parse("2021-11-21T10:02:30"), 340, airplane);
        heathrow.scheduleFlight(2, 2, heathrowToTegel);

        Flight heathrowToKastrup = new Flight(kastrup, LocalDateTime.parse("2021-11-21T19:04:30"), 240, airplane);
        heathrow.scheduleFlight(1, 2, heathrowToKastrup);
















        Airport currentAirport = kastrup;
        Terminal currentTerminal = currentAirport.getTerminals().get(0);
        Gate currentGate = null;
        LocalDateTime currentTime = LocalDateTime.parse("2021-11-20T06:32:30");

        System.out.println("Who are you?");

        Passport userPassport = createPassport();
        Traveler traveler = new Traveler(userPassport.getFullName(), userPassport.getCountry(), userPassport.getDateOfBirth());

        clear();
        System.out.println("Passport created!");
        System.out.println("You are now ready to explore the world!");


        Action action = Action.NONE;

        while(action != Action.EXIT) {

            //display info
            System.out.println("###################################################");
            System.out.println(String.format("Location: %s%s - %s", currentTerminal.getName(), currentGate != null ? String.format(", %s", currentGate.getName()) : "", currentAirport.toString()));
            System.out.println(String.format("Balance $%.2f", traveler.getBalance()));
            System.out.println(String.format("Time %s", currentTime.format(Util.formatter)));
            System.out.println("###################################################");

            //display actions.
            for(int i = 1; i < Action.values().length; i++)
                System.out.print(String.format("%d(%s) \n", i, Action.values()[i]));

            //take input
            try {
                action = Action.values()[Integer.parseInt(scanner.nextLine())];
                clear();
            } catch (Exception e) { action = Action.NONE; }

            System.out.println(action.toString());
            System.out.println("###################################################");

            switch (action) {

                case EXIT -> {
                    System.out.println("Come back soon!");
                    break;
                }

                case GO_TO_TERMINAL -> {
                    while(true) {
                        System.out.println("Please choose which terminal to transfer to.");

                        for (int i = 1; i <= currentAirport.getTerminals().size(); i++)
                            System.out.println(String.format("%d(Terminal %d)", i, i));

                        try {
                            currentTerminal = currentAirport.getTerminals().get(GetIntput() - 1);
                            System.out.println("Transferring to " + currentTerminal.getName() + "..");
                            currentGate = null;
                            break;
                        } catch (Exception e) {}


                    }
                }

                case GO_TO_GATE -> {
                    while(true) {
                        System.out.println("Please choose which gate to transfer to.");

                        for (int i = 1; i <= currentTerminal.getGates().size(); i++)
                            System.out.println(String.format("%d(Gate %d)", i, i));

                        try {
                            currentGate = currentTerminal.getGates().get(GetIntput() - 1);
                            System.out.println(String.format("Transferring to %s..", currentGate.getName()));
                            break;
                        } catch (Exception e) {}


                    }
                }

                case VIEW_MONITORS -> {
                    currentAirport.ViewMonitors();
                }

                case VIEW_BOARDING_PASS -> {
                    if(traveler.getBoardingpass().size() == 0)
                        System.out.println("No boarding pass purchased.");

                    for(BoardingPass boardingpass : traveler.getBoardingpass())
                        System.out.println(boardingpass.toString());
                }

                case WAIT -> {
                    String in = GetInput(String.format("Current time: %s\nHow long would you like to wait? (HH:mm)\n", currentTime.format(Util.formatter)), "[0-9]{1}[0-9]{1}:[0-9]{1}[0-9]{1}");

                    traveler.waiting();

                    int hours = Integer.parseInt(in.split(":")[0]);
                    int minutes = Integer.parseInt(in.split(":")[1]);
                    currentTime = currentTime.plusHours(hours);
                    currentTime = currentTime.plusMinutes(minutes);
                }

                case BOARD_PLANE -> {
                    if(currentGate != null) {
                        if(currentGate.getFlights().size() > 0) {
                            while(true) {
                                Collections.sort(currentGate.getFlights());

                                System.out.println("   | No.  | Time  |  Destination ");
                                System.out.println("---------------------------------------------------");
                                for (int i = 0; i < currentGate.getFlights().size(); i++) {
                                    Flight flight = currentGate.getFlights().get(i);
                                    System.out.println(String.format("%d) | %s", i + 1, flight.toString()));
                                }

                                System.out.println("0) Exit");
                                System.out.println("---------------------------------------------------");

                                try {
                                    System.out.println("Which one would you like to board?");

                                    Flight flight = currentGate.getFlights().get(GetIntput() - 1);



                                    BoardingPass currentBoardingPass = null;

                                    for (BoardingPass boardingPass : traveler.getBoardingpass())
                                        if (boardingPass.getFlight().equals(flight)) {
                                            currentBoardingPass = boardingPass;
                                        }

                                    if (currentBoardingPass != null) {
                                        if (Duration.between(currentTime, flight.getDepartureTime()).toMinutes() > 10) {
                                            System.out.println(String.format("This flight is not boarding until %s.", Util.timeUntil(currentTime, flight.getDepartureTime())));
                                        } else {
                                            System.out.println("Boarding..");
                                            Airplane airplane1 = flight.getAirplane();

                                            try {
                                                airplane1.Fly();
                                            } catch (NoPilotException e) {
                                                System.out.println("Can't take of, pilot missing.");
                                                break;
                                            }

                                            traveler.getBoardingpass().remove(currentBoardingPass);
                                            currentGate.getFlights().remove(flight);
                                            currentGate = null;
                                            currentTime = currentTime.plusHours(1);
                                            currentAirport = flight.getDestination();
                                            currentTerminal = currentAirport.getTerminals().get(0);

                                            break;
                                        }
                                    } else {
                                        System.out.println("You don't have a ticket for this flight!");
                                    }


                                } catch (Exception e) {
                                    //e.printStackTrace();
                                    break;
                                }
                            }
                        } else {
                            System.out.println("No flights departing from this gate.");
                        }
                    } else {
                        System.out.println("Go to a gate first.");
                    }
                }


                case BUY_TICKET -> {
                    List<Flight> allFlights = new ArrayList<Flight>();

                    for(Terminal terminal : currentAirport.getTerminals()) {
                        for(Gate gate : terminal.getGates()) {
                            allFlights.addAll(gate.getFlights());
                        }
                    }

                    Collections.sort(allFlights);

                    while(true) {
                        System.out.println("   Price | No.  | Time  | Destination ");
                        System.out.println("---------------------------------------------------");
                        for(int i = 0; i < allFlights.size(); i++) {
                            Flight flight = allFlights.get(i);
                            System.out.println(String.format("%d) $%.0f | %s", i + 1, flight.getPrice(), flight.toString()));
                        }
                        System.out.println("0) Exit");
                        System.out.println("---------------------------------------------------");

                        try {
                            System.out.println("Which one would you like?");
                            
                            Flight flight = allFlights.get(GetIntput() - 1);

                            if(flight.getPrice() <= traveler.getBalance()) {
                                FlightClass preferredClass;
                                float totalExpenses = flight.getPrice();
                                String seat = "";

                                for(String availableSeat : flight.getAirplane().passengersList.keySet())
                                    if(flight.getAirplane().passengersList.get(availableSeat) == null) //free
                                        seat = availableSeat;

                                    if(seat.equals("")) {
                                        System.out.println("Sorry, this flight is fully booked!");
                                        break;
                                    }


                                while(true) {
                                    String classTextPrompt = String.format("Would you like to purchase first class for an extra $%.1f? (yes/no)\n", FlightClass.FIRST_CLASS.GetPrice());
                                    preferredClass = GetInput(classTextPrompt, "(yes)|(no)").equals("yes") ? FlightClass.FIRST_CLASS : FlightClass.BUSINESS;

                                    if(preferredClass == FlightClass.FIRST_CLASS && traveler.getBalance() < (preferredClass.GetPrice() + flight.getPrice()))
                                        System.out.println("You can't afford this!");
                                    else {
                                        totalExpenses += FlightClass.FIRST_CLASS.GetPrice();
                                        break;
                                    }
                                }

                                BoardingPass boardingpass = new BoardingPass(flight, seat, preferredClass);

                                boolean confirmation = GetInput(String.format("%s\nTotal $%.2f, Please confirm purchase. (yes/no)\n", boardingpass.toString(), totalExpenses), "(yes)|(no)").equals("yes");

                                if(confirmation) {
                                    System.out.println("Ticket added to your inventory.");
                                    traveler.setBalance(traveler.getBalance() - totalExpenses);
                                    traveler.getBoardingpass().add(boardingpass);
                                    flight.getAirplane().passengersList.put(seat, traveler);
                                } else
                                    continue;

                            } else {
                                System.out.println(String.format("Not enough funds. ($%.2f)", traveler.getBalance()));
                            }

                            break;
                        } catch (Exception e) {
                            //e.printStackTrace();
                            break;
                        }

                    }
                }

            }


        }

    }

    public int GetIntput() {
        int out = -1;

        try {
            out = Integer.parseInt(scanner.nextLine());
        } catch(Exception e) {}

        return out;
    }



    public String GetInput(String prompt, String regex) {
        String in = "";

        while(!in.matches(regex)) {

            System.out.print(prompt);
            in = scanner.nextLine();
        }

        return in;
    }

    public void waitMilli(int milli) {
        try {
            Thread.sleep(milli);
        } catch (InterruptedException e) {}
    }

    public void clear()  {
        for(int i = 0; i < 100; i++)
            System.out.println();
    }

    public Passport createPassport() {
        Passport passport;

        while(true) {

            String fullName = GetInput("Full name: ", "[A-Öa-ö- ]+");

            Country country;
            while (true) {
                    String countryS = "";
                try {
                    countryS = GetInput("Country: ", "[A-Öa-ö]+");
                    country = Country.valueOf(countryS.toUpperCase());
                    break;
                } catch (Exception e) {
                    System.out.println(String.format("The country \"%s\" was not found, try another.", countryS));
                }
            }

            LocalDate dateOfBirth;
            while(true) {
                String dateOfBirthStr = GetInput("Date of birth (yyyy-MM-dd): ", "(\\d){4}[-](\\d){2}[-](\\d){2}");
                try {
                    dateOfBirth = LocalDate.parse(dateOfBirthStr);
                    break;
                } catch (DateTimeParseException e) {}
            }

            System.out.println("Now press \"Enter\" with your thump.");
            scanner.nextLine();
            System.out.println("Scanning fingerprint...");
            waitMilli(1500);
            System.out.println("Done Scanning.");
            waitMilli(2000);
            clear();

            passport = new Passport(fullName, country, dateOfBirth);
            System.out.println(passport.toString());

            String in = GetInput("Please verify, is this correct? (yes/no)\n", "(yes)|(no)");
            System.out.println(in);

            if(in.equalsIgnoreCase("yes"))
                break;
        }
        return passport;
    }

}
