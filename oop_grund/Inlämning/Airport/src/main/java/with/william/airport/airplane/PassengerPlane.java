package with.william.airport.airplane;

import with.william.airport.human.Traveler;
import with.william.airport.other.NoPilotException;

import java.util.HashMap;
import java.util.Map;

public class PassengerPlane extends Airplane {

    public Map<String, Traveler> passengersList = new HashMap<>(); // added seat and passengers map.

    public PassengerPlane() {

        for(int i = 1; i <= 9; i++) {
            for(char c : "ABCD".toCharArray()) {
                passengersList.put(i + "" +  c, null);
            }
        }

    }


    @Override
    public void Fly() throws NoPilotException {
        super.Fly();

        for (String seat : passengersList.keySet())
            passengersList.put(seat, null);

    }
}
