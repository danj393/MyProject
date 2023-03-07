
using System;

namespace Name
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Main");
            int[,] deck1 = Deck.newDeck();


            while (true) {
                Console.WriteLine("Deal    - deals top card from deck");
                Console.WriteLine("Riffle  - riffle shuffle deck  ");
                Console.WriteLine("FY      - Fisher-Yates shuffle deck");
                Console.WriteLine("Deck    - Prints the full deck");
                Console.WriteLine("End     - Ends the programme");
                string userinput = Console.ReadLine();
                while (userinput is null){
                    userinput = Console.ReadLine();
                }
                if (userinput.ToLower() == "deal"){
                    deck1 = Card.dealCard(deck1);
                }
                if (userinput.ToLower() == "riffle"){
                    deck1 = Deck.riffleShuffle(deck1);
                    Console.WriteLine("");
                }
                if (userinput.ToLower() == "fy"){
                    deck1 = Deck.fishyate(deck1);
                    Console.WriteLine("");
                }
                if (userinput.ToLower() == "deck"){
                    int decklength = deck1.GetLength(0);
                    int i;
                    for (i = 0; i < decklength; i++){
                        deck1 = Card.dealCard(deck1);
                    }
                    
                }
                if (userinput.ToLower() == "end"){
                    Console.WriteLine("");
                    break;
                    
                }

                
            }

            

            

            
            

        }
    }


    class Card
    {

    public static int[,] dealCard(int[,] deck)
    {
    int decklength = deck.GetLength(0);
    if (decklength == 0){
        Console.WriteLine("Deck out of cards, programme terminating");
        System.Environment.Exit(1);
    }
    int topcardNumber = deck[decklength-1,0];
    int topcardSuit = deck[decklength-1,1];
    Console.WriteLine();
    if (topcardNumber <= 10){
        Console.Write(topcardNumber);
    }
    if (topcardNumber == 11){
        Console.Write("Jack");
    }
    if (topcardNumber == 12){
        Console.Write("Queen");
    }
    if (topcardNumber == 13){
        Console.Write("King");
    }
    
    if (topcardSuit == 1)
    {
        Console.WriteLine(" of Spades");
    }
    if (topcardSuit == 2)
    {
        Console.WriteLine(" of Clubs");
    }
    if (topcardSuit == 3)
    {
        Console.WriteLine(" of Diamonds");
    }
    if (topcardSuit == 4)
    {
        Console.WriteLine(" of Hearts");
    }
    Console.WriteLine(" ");

    int[,] newdeck = new int[decklength-1,2];
    int i;
    for(i = 0; i < decklength -1; i++){
        newdeck[i,0] = deck[i,0];
        newdeck[i,1] = deck[i,1];
    }

    return(newdeck);

    }




    public static int[] newCard(int num, int suit){
    int cardNumber = num;
    int cardSuit = suit;
    /*
        1 = spades
        2 = clubs
        3 = diamonds
        4 = hearts

        Jack = 11
        Queen = 12
        King = 13
    */

    int[] card = {cardNumber,cardSuit};
    return(card);

    }

    }


    class Deck
    {

    public static int[,] newDeck(){


            int[,] newdeck = new int[52,2];


            
            int suit;
            int count = 0;
            for(suit = 1; suit < 5; suit++){

                int num;
                for(num = 1; num < 14; num++){

                    int[] newcard = Card.newCard(num,suit);
                    newdeck[count,0] = (newcard[0]);
                    newdeck[count,1] = (newcard[1]);
                    

                    count++;

                }


            }
            //Console.WriteLine(newdeck);
            
            return(newdeck);

            /*
            return (new int[,] { { 1, 1 }, { 1, 2 }, { 1, 3 }, { 1, 4 }, { 1, 5 }, { 1, 6 }, { 1, 7 }, { 1, 8 }, { 1, 9 }, { 1, 10 }, { 1, 11 }, { 1, 12 }, { 1, 13 },
             { 2, 1 }, { 2, 2 }, { 2, 3 }, { 2, 4 }, { 2, 5 }, { 2, 6 }, { 2, 7 }, { 2, 8 }, { 2, 9 }, { 2, 10 }, { 2, 11 }, { 2, 12 }, { 2, 13 },
             { 3, 1 }, { 3, 2 }, { 3, 3 }, { 3, 4 }, { 3, 5 }, { 3, 6 }, { 3, 7 }, { 3, 8 }, { 3, 9 }, { 3, 10 }, { 3, 11 }, { 3, 12 }, { 3, 13 },
             { 4, 1 }, { 4, 2 }, { 4, 3 }, { 4, 4 }, { 4, 5 }, { 4, 6 }, { 4, 7 }, { 4, 8 }, { 4, 9 }, { 4, 10 }, { 4, 11 }, { 4, 12 }, { 4, 13 }
            });

            */
         
    }

    public static int[,] riffleShuffle(int[,] deck){

        int decklength = deck.GetLength(0);
        if (decklength < 1){
        Console.WriteLine("Not enough cards to shuffle");
        return(deck);
    }
        int midpoint = decklength/2;
        //Console.WriteLine(midpoint);
        
        int[,] firsthalf = new int[midpoint,2];
        int[,] secondhalf = new int[midpoint,2];
        int[,] shuffledlist = new int[decklength,2];

        int i;
        // midpoint = 25
        // total = 51
        for(i = 0; i < midpoint; i++){
            firsthalf[i,0] = deck[i,0];
            firsthalf[i,1] = deck[i,1];
        }
        int upperbound = decklength;
        if (decklength%2 == 1){
            upperbound-=1;
        }

        for(i = midpoint; i < upperbound; i++){
            secondhalf[i - midpoint,0] = deck[i,0];
            secondhalf[i - midpoint,1] = deck[i,1];
        }
        int count = 0;
        for(i = 0; i < midpoint; i++){
            shuffledlist[count,0] = firsthalf[i,0];
            shuffledlist[count,1] = firsthalf[i,1];

            count++;

            shuffledlist[count,0] = secondhalf[i,0];
            shuffledlist[count,1] = secondhalf[i,1];

            count++;
        }

        if (decklength%2 == 1){
            shuffledlist[decklength - 1,0] = deck[decklength - 1,0];
            shuffledlist[decklength - 1,1] = deck[decklength - 1,1];
        }



        return(shuffledlist);
    }

    public static int[,] fishyate(int[,] deck){

        int decklength = deck.GetLength(0);
        int[,] templist = deck;
        int[] availablelocations = new int[decklength];
        int i;
        for (i = 0; i < decklength; i++){
            availablelocations[i] = i;
        }
        
        
        int[,] shuffledlist = new int[decklength,2];

        Random rnd = new Random();
        for (i = 0; i < decklength; i++){

            bool findingspace = true;
            while (findingspace){
                int listnum = rnd.Next(0,decklength);

                if (availablelocations.Contains(listnum)){
                    shuffledlist[i,0] = deck[listnum,0];
                    shuffledlist[i,1] = deck[listnum,1];
                    availablelocations[listnum] = -1;
                    findingspace = false;


                }
                else
                {
                    listnum = rnd.Next(0,decklength);
                }

            }
            
        }
        


        return(shuffledlist);
    }



    }
    

}

