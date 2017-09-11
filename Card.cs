using System;

namespace bfaubion_webapp
{
    public class Card
    {
        public int value;
        public string face;
        public string suit;
        public string image;
        private static string[] faces = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
        private static string[] suits = {"spade", "club", "diamond", "heart"};
        private static string image_source = "https://upload.wikimedia.org/wikipedia/commons/thumb/";
        private static string[] image_url = {
            // Spades
            "2/25/Playing_card_spade_A.svg/192px-Playing_card_spade_A.svg.png",
            "f/f2/Playing_card_spade_2.svg/192px-Playing_card_spade_2.svg.png",
            "5/52/Playing_card_spade_3.svg/192px-Playing_card_spade_3.svg.png",
            "2/2c/Playing_card_spade_4.svg/192px-Playing_card_spade_4.svg.png",
            "9/94/Playing_card_spade_5.svg/192px-Playing_card_spade_5.svg.png",
            "d/d2/Playing_card_spade_6.svg/192px-Playing_card_spade_6.svg.png",
            "6/66/Playing_card_spade_7.svg/192px-Playing_card_spade_7.svg.png",
            "2/21/Playing_card_spade_8.svg/192px-Playing_card_spade_8.svg.png",
            "e/e0/Playing_card_spade_9.svg/192px-Playing_card_spade_9.svg.png",
            "8/87/Playing_card_spade_10.svg/192px-Playing_card_spade_10.svg.png",
            "b/bd/Playing_card_spade_J.svg/192px-Playing_card_spade_J.svg.png",
            "5/51/Playing_card_spade_Q.svg/192px-Playing_card_spade_Q.svg.png",
            "9/9f/Playing_card_spade_K.svg/192px-Playing_card_spade_K.svg.png",
            // Clubs
            "3/36/Playing_card_club_A.svg/192px-Playing_card_club_A.svg.png",
            "f/f5/Playing_card_club_2.svg/192px-Playing_card_club_2.svg.png",
            "6/6b/Playing_card_club_3.svg/192px-Playing_card_club_3.svg.png",
            "3/3d/Playing_card_club_4.svg/192px-Playing_card_club_4.svg.png",
            "5/50/Playing_card_club_5.svg/192px-Playing_card_club_5.svg.png",
            "a/a0/Playing_card_club_6.svg/192px-Playing_card_club_6.svg.png",
            "4/4b/Playing_card_club_7.svg/192px-Playing_card_club_7.svg.png",
            "e/eb/Playing_card_club_8.svg/192px-Playing_card_club_8.svg.png",
            "2/27/Playing_card_club_9.svg/192px-Playing_card_club_9.svg.png",
            "3/3e/Playing_card_club_10.svg/192px-Playing_card_club_10.svg.png",
            "b/b7/Playing_card_club_J.svg/192px-Playing_card_club_J.svg.png",
            "f/f2/Playing_card_club_Q.svg/192px-Playing_card_club_Q.svg.png",
            "2/22/Playing_card_club_K.svg/192px-Playing_card_club_K.svg.png",
            // Diamonds
            "d/d3/Playing_card_diamond_A.svg/192px-Playing_card_diamond_A.svg.png",
            "5/59/Playing_card_diamond_2.svg/192px-Playing_card_diamond_2.svg.png",
            "8/82/Playing_card_diamond_3.svg/192px-Playing_card_diamond_3.svg.png",
            "2/20/Playing_card_diamond_4.svg/192px-Playing_card_diamond_4.svg.png",
            "f/fd/Playing_card_diamond_5.svg/192px-Playing_card_diamond_5.svg.png",
            "8/80/Playing_card_diamond_6.svg/192px-Playing_card_diamond_6.svg.png",
            "e/e6/Playing_card_diamond_7.svg/192px-Playing_card_diamond_7.svg.png",
            "7/78/Playing_card_diamond_8.svg/192px-Playing_card_diamond_8.svg.png",
            "9/9e/Playing_card_diamond_9.svg/192px-Playing_card_diamond_9.svg.png",
            "3/34/Playing_card_diamond_10.svg/192px-Playing_card_diamond_10.svg.png",
            "a/af/Playing_card_diamond_J.svg/192px-Playing_card_diamond_J.svg.png",
            "0/0b/Playing_card_diamond_Q.svg/192px-Playing_card_diamond_Q.svg.png",
            "7/78/Playing_card_diamond_K.svg/192px-Playing_card_diamond_K.svg.png",
            // Hearts
            "5/57/Playing_card_heart_A.svg/192px-Playing_card_heart_A.svg.png",
            "d/d5/Playing_card_heart_2.svg/192px-Playing_card_heart_2.svg.png",
            "b/b6/Playing_card_heart_3.svg/192px-Playing_card_heart_3.svg.png",
            "a/a2/Playing_card_heart_4.svg/192px-Playing_card_heart_4.svg.png",
            "5/52/Playing_card_heart_5.svg/192px-Playing_card_heart_5.svg.png",
            "c/cd/Playing_card_heart_6.svg/192px-Playing_card_heart_6.svg.png",
            "9/94/Playing_card_heart_7.svg/192px-Playing_card_heart_7.svg.png",
            "5/50/Playing_card_heart_8.svg/192px-Playing_card_heart_8.svg.png",
            "5/50/Playing_card_heart_9.svg/192px-Playing_card_heart_9.svg.png",
            "9/98/Playing_card_heart_10.svg/192px-Playing_card_heart_10.svg.png",
            "4/46/Playing_card_heart_J.svg/192px-Playing_card_heart_J.svg.png",
            "7/72/Playing_card_heart_Q.svg/192px-Playing_card_heart_Q.svg.png",
            "d/dc/Playing_card_heart_K.svg/192px-Playing_card_heart_K.svg.png"
        };

        // The default constructor creates a random card
        public Card()
        {
            Random random_draw = new Random();
            draw(random_draw.Next(0,52));
        }

        // Create a card with a specified id
        public Card(int id)
        {
            if (id <= 51 && id >= 0)
            {
                draw(id);
            }
            else
            {
                draw(0);
            }
        }

        // Creates a card based on its position in a deck of cards sorted by value and suit
        public void draw(int id)
        {
            // Set the suit
            int suit_id = id / 13;
            suit = suits[suit_id];

            // Set the value
            int card_id = id % 13;
            if (card_id < 9)
            {
                value = card_id + 1;
            }
            else
            {
                value = 10;
            }

            // Set the face
            face = faces[card_id];

            // Set the image
            image = image_source + image_url[id];
        }

        // Returns a JSON object for this object
        public string json()
        {
            return "{\"value\":" + value + ",\"face\":\"" + face + "\",\"suit\":\"" + suit + "\",\"image\":\"" + image + "\"}";;
        }
    }
}