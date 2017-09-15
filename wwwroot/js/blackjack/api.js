// Card arrays
var card_dealer = [];
var card_player = [];

// The scores for each player
var total_dealer = 0;
var total_player = 0;

// Set to true when we are waiting for a card to be drawn
var drawing = false;

// Gets an http request from the blackjack api
function getCard(callback)
{
    // The JSON object returned by our request
    var result;

    // Create a request
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function()
    {
        if (xhttp.readyState == 4 && xhttp.status == 200)
        {
            // Process the request and the display the cards
            callback(xhttp.responseText);
        }
    };

    // Send an http request
    xhttp.open("GET", "/api", true);
    xhttp.send();

    // Pause the game until a card is drawn
    drawing = true;
}

// Check to see if a card has already been used
function verifyCard(card)
{
    for (i = 0; i < card_player.length; ++i)
    {
        if (card.face == card_player[i].face && card.suit == card_player[i].suit)
        {
            return false;
        }
    }
    for (i = 0; i < card_dealer.length; ++i)
    {
        if (card.face == card_dealer[i].face && card.suit == card_dealer[i].suit)
        {
            return false;
        }
    }
    return true;
}

// Functions to set cards based on api input
function playerCard(obj)
{
    // Abort the draw if the game is over
    if (gameover == true)
    {
        return;
    }

    // Convert the JSON text in to an object
    var card = JSON.parse(obj);

    if (verifyCard(card))
    {
        // Add the card and update the pictures
        card_player.push(card);
        showCards();

        // Calculate the score of the dealer
        total_player = total(card_player);
        document.getElementById("playertext").innerHTML = "Player (" + total_player + ")";

        // Check for a bust and continue the game
        checkWinner();
        drawing = false;
    }
    else
    {
        // Draw a new card
        getCard(playerCard);
    }
}

function dealerCard(obj)
{
    // Abort the draw if the game is over
    if (gameover == true)
    {
        return;
    }

    // Convert the JSON text in to an object
    var card = JSON.parse(obj);

    if (verifyCard(card))
    {
        // Add the card and update the pictures
        card_dealer.push(card);
        showCards();

        // Calculate the score of the dealer
        total_dealer = total(card_dealer);
        document.getElementById("dealertext").innerHTML = "Dealer (" + total_dealer + ")";

        // Check for a bust and continue the game
        checkWinner();
        drawing = false;
    }
    else
    {
        // Draw a new card
        getCard(dealerCard);
    }
}

// Get the total score for a player's hand
function total(array)
{
    var score = 0;
    var aces = 0;

    // Get the base score value
    for (i = 0; i < array.length; i++)
    {
        score += array[i].value;
        if (array[i].face == "A")
        {
            aces += 1;
        }
    }

    // Raise the value of aces if applicable
    while (aces > 0)
    {
        if (score < 13)
        {
            score += 9;
            aces--;
        }
        else
        {
            aces = 0;
        }
    }

    return score;
}

// Displays each player's cards
function showCards()
{
    for (i = 0; i < 11; i++)
    {
        // Show the player's card
        if (i < card_player.length)
        {
            document.getElementById("player"+i).src = card_player[i].image;
        }
        else
        {
            document.getElementById("player"+i).src = "";
        }

        // Show the dealer's card
        if (i < card_dealer.length)
        {
            document.getElementById("dealer"+i).src = card_dealer[i].image;
        }
        else
        {
            document.getElementById("dealer"+i).src = "";
        }
    }
}