using System;

class AirlineReservationsSystem
{
    private static bool[] seats = new bool[10]; // Represents the seating chart, initialized to false (empty seats)

    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Airline Reservation System!");

        while (true)
        {
            Console.WriteLine("\nPlease type 1 for First Class or 2 for Economy: ");
            int choice;

            if (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
            {
                Console.WriteLine("Invalid choice. Please try again.");
                continue;
            }

            bool seatAssigned = AssignSeat(choice);
            if (!seatAssigned)
            {
                Console.WriteLine("Sorry, the section you selected is full.");

                if (choice == 1)
                {
                    Console.WriteLine("Would you like a seat in the Economy section? (Type 'yes' or 'no')");
                }
                else
                {
                    Console.WriteLine("Would you like a seat in the First Class section? (Type 'yes' or 'no')");
                }

                string alternateChoice = Console.ReadLine().ToLower();
                if (alternateChoice == "yes")
                {
                    int alternateSection = (choice == 1) ? 2 : 1;
                    seatAssigned = AssignSeat(alternateSection);
                    if (!seatAssigned)
                    {
                        Console.WriteLine("Sorry, the alternate section is also full. Next flight leaves in 3 hours.");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Next flight leaves in 3 hours.");
                    break;
                }
            }

            Console.WriteLine("Seat successfully assigned!");
            DisplaySeatingChart();
            break;
        }
    }

    private static bool AssignSeat(int section)
    {
        int startSeat = (section == 1) ? 0 : 5;
        int endSeat = (section == 1) ? 4 : 9;

        for (int i = startSeat; i <= endSeat; i++)
        {
            if (!seats[i])
            {
                seats[i] = true;
                return true;
            }
        }
        return false;
    }

    private static void DisplaySeatingChart()
    {
        Console.WriteLine("\nCurrent Seating Chart:");
        for (int i = 0; i < seats.Length; i++)
        {
            Console.WriteLine($"Seat {i + 1}: {(seats[i] ? "Occupied" : "Available")}");
        }
        Console.ReadKey();
    }
}