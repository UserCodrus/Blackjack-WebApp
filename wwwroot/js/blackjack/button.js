// Script for the hit button
function hitButton()
{
    if (gameover == true)
    {
        newGame();
        return;
    }

    if (drawing == false)
    {
        if (pstand == false)
        {
            getCard(playerCard);
            dealerPlay();
        }
        else
        {
            dealerPlay();
            checkWinner()
        }
    }
}

// Script for the stand button
function standButton()
{
    if (gameover == true)
    {
        newGame();
        return;
    }

    if (drawing == false)
    {
        if (pstand == false)
        {
            pstand = true;
            document.getElementById("playertext").innerHTML += " - Standing";
            document.getElementById("footer").innerHTML = "Press hit or stand to continue.";
            dealerPlay();
        }
        else
        {
            dealerPlay();
            checkWinner()
        }
    }
}