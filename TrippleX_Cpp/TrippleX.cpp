#include <iostream>
#include <ctime>

void PrintIntroduction(int Difficulty)
{
    std::cout << "\n\n         +---+         +---+\n";
    std::cout << "        +-----+       +-----+\n";
    std::cout << "       +-------+     +-------+\n";
    std::cout << "       +--------+   +--------+\n";
    std::cout << "        +-------------------+\n";
    std::cout << "        +---+  +-----+  +---+\n";
    std::cout << "       +----+  +-----+  +----+\n";
    std::cout << "       +---------------------+\n";
    std::cout << "        +-------------------+\n";
    std::cout << "     +   +-------+  +------+   +\n";
    std::cout << "     +-+  +---------------+  +-+\n";
    std::cout << "     +--+  +-------------+  +--+\n";
    std::cout << "     +---------+      +--------+\n";
    std::cout << "     +-------------------------+\n";
    std::cout << "     +----------+   +----------+\n";
    std::cout << "     +-------------------------+\n";
    std::cout << "     +--------+       +--------+\n";
    std::cout << "     +-----+             +-----+\n";
    std::cout << "     +---+                 +---+\n";
    std::cout << "     +--+                   +--+\n";
    std::cout << "     +-+                     +-+\n";
    std::cout << "     +                         +\n";

 //Introduction, telling about the situation and giving the user an idea of what is going on and what is expected from them
    std::cout << "\nBigbo the talking bear is about to arrange boulders into a wall on the eastern border of the forest.\n";
    std::cout << "This way he can ensure that the honey bears is not breaking in and stealing honey on his territory.\n";
    std::cout << "But the wall is not yet finished and there are still three large holes in the wall.\n";  
    std::cout << "Bigbos wall have currently progressed to level: "<<Difficulty;
}

bool PlayGame(int Difficulty)
{
    PrintIntroduction(Difficulty);
    //generate a random number based on the level difficulty offset by itself this way no zeros get included and the games difficulty increases more at each level
    const int BouldersA = rand()%Difficulty+Difficulty;
    const int BouldersB = rand()%Difficulty+Difficulty;
    const int BouldersC = rand()%Difficulty+Difficulty;

    const int BoulderSum = BouldersA + BouldersB + BouldersC;
    const int BoulderProduct = (BouldersA*BouldersB)*BouldersC;

    //print out instructions to user
    std::cout << "\n\nA number of boulders are missing at each of the holes\n";   
    std::cout << "+ Togheter they add up to: "<<BoulderSum;
    std::cout << "\n+ The boulders missing at each hole multiplies to give: "<<BoulderProduct; 
    std::cout << "\n Can you help Bigbo figure out how many boulders he needs to fill each of the holes?\n"; 
    
    //store player guess
    int GuessA, GuessB, GuessC;
    std::cin >> GuessA >> GuessB >> GuessC;
    

    int GuessSum = GuessA + GuessB + GuessC;
    int GuessProduct = (GuessA*GuessB)*GuessC; 
    //Check if players guess is correct
    if(GuessSum == BoulderSum && GuessProduct == BoulderProduct)
    {
        std::cout << "\nGood job that was exactly the amount of boulders missing in Bigbos wall";
        return true;
    }
    else
    {
        std::cout << "\nYou gave poor Bigbo the wrong amount of boulers.\n";
        std::cout << "Now he will spend the rest of the evening figiuring out why they wont match the holes in his wall\n";
        return false;
    }
}


int main()
{
    srand(time(NULL)); // randomizes the rand seed based on the time of the day giving more random results

    int LevelDifficulty = 1;

    while (LevelDifficulty<=10)
    {      
        bool bLevelComplete = PlayGame(LevelDifficulty);
        std::cin.clear();//this clears any input errors
        std::cin.ignore();// this clears the input buffer

        if (bLevelComplete)
        {
            ++LevelDifficulty;
        }
        
    }
    std::cout << "\nCongratulations you helped bigbo completing his wall and fill all the holes with boulders.";
    std::cout << "\n Now he wont have to wonrry about the honey bears breaking into his territory anymore.";
    return 0;
}