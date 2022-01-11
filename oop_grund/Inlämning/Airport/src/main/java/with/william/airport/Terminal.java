package with.william.airport;

import with.william.airport.util.Util;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class Terminal {

    private String name; //added name for identification.

    private List<Gate> gates = new ArrayList<>();

    public Terminal(String name) {

        this.name = name;

        for(int j = 1; j <= 3; j++) {
            gates.add(new Gate("Gate " + j));
        }

    }

    public List<Gate> getGates() {
        return gates;
    }



    @Override
    public String toString() {
        String out = "";
        List<Flight> allFlights = new ArrayList<Flight>();

        for(Gate gate : gates)
            allFlights.addAll(gate.getFlights());

        Collections.sort(allFlights);

        for(Flight flight : allFlights) {
            out += String.format("%s | %s | %s | %s\n",
                    flight.getFlightNumber(),
                    flight.getDepartureTime().format(Util.formatter),
                    flight.getGate().getName(),
                    flight.getDestination().toString());
        }
            //out += flight.toString() + "\n";


        return out;
    }

    public String getName() {
        return name;
    }
}
