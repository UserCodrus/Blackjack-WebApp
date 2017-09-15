// Win and loss counter
var wins = 0;
var losses = 0;

// Game variables
var pstand = false;
var dstand = false;
var gameover = false;

// Sets the wins and losses display
function showScore()
{
    document.getElementById("win").innerHTML = "Wins: " + wins;
    document.getElementById("lose").innerHTML = "Losses: " + losses;
}

// Empty arrays and draw cards at the start of the game
function newGame()
{
    gameover = false;

    // Reset arrays and standing flags
    card_player = [];
    card_dealer = [];

    pstand = false;
    dstand = false;

    total_player = 0;
    total_dealer = 0;

    // Draw two cards for each player
    getCard(playerCard);
    getCard(dealerCard);
    getCard(playerCard);
    getCard(dealerCard);

    // Reset the game over text
    document.getElementById("footer").innerHTML = "";
}

// Update the score and start a new game
function endGame(state)
{
    if (state == 1)
    {
        // Player wins
        wins += 1;
        document.getElementById("footer").innerHTML = "Player Wins! Press hit or stand to restart.";
    }
    else if (state == 0)
    {
        // Dealer wins
        losses += 1;
        document.getElementById("footer").innerHTML = "Dealer Wins! Press hit or stand to restart.";
    }
    else
    {
        // Game is a draw
        document.getElementById("footer").innerHTML = "Draw! Press hit or stand to restart.";
    }

    // Display the score and start a new game
    showScore();
    showCards();
    gameover = true;
}

// Check for a winner and end the game if anyone wins
function checkWinner()
{
    if (gameover == true)
    {
        return;
    }

    // End if a player busts
    if (total_player > 21 && total_dealer > 21)
    {
        endGame(2);
        return true;
    }
    if (total_player > 21)
    {
        endGame(0);
        return true;
    }
    if (total_dealer > 21)
    {
        endGame(1);
        return true;
    }

    // Both players are standing
    if (pstand == true && dstand == true)
    {
        if (total_player > total_dealer)
        {
            endGame(1);
            return true;
        }
        else if (total_dealer > total_player)
        {
            endGame(0);
            return true;
        }
        else
        {
            endGame(2);
            return true;
        }
    }

    // Nobody won yet
    return false;
}

// The dealer's ai routine
function dealerPlay()
{
    // Skip a turn if the dealer is standing
    if (dstand == true)
    {
        checkWinner();
        return;
    }

    // Stand if the player busts
    if (total_player > 21)
    {
        dstand = true;
        document.getElementById("dealertext").innerHTML += " - Standing";
        return;
    }

    // Stand if the player is standing and we have a higher score
    if (pstand == true && total_dealer > total_player)
    {
        dstand = true;
        document.getElementById("dealertext").innerHTML += " - Standing";
        return;
    }

    // Draw a card if the player is standing and score is less than the player
    if (pstand == true && total_dealer < total_player)
    {
        getCard(dealerCard);
        return;
    }

    // Stand if the dealer is over 18
    if (total_dealer > 18)
    {
        dstand = true;
        document.getElementById("dealertext").innerHTML += " - Standing";
        return;
    }

    if (pstand == false && total_dealer <= total_player)
    {
        getCard(dealerCard);
        return;
    }

    // Draw if the dealer has a low hand
    if (total_dealer < 17)
    {
        getCard(dealerCard);
        return;
    }

    // Stand if none of the above is applicable
    dstand = true;
    document.getElementById("dealertext").innerHTML += " - Standing";
    return;
}